Imports System.Threading
Imports System.Collections.Generic
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Enrollment
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>


    Dim preenrollmentFmds As List(Of Fmd)
    Private count As Integer

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Enrollment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Fingerprint.Current.Reader Is Nothing Then
            If My.Settings.FingerprintReaderSerialnumber <> "" Then
                Dim reader_found As Boolean = False
                Dim _readers As ReaderCollection
                _readers = ReaderCollection.GetReaders()
                For Each Reader As Reader In _readers
                    If Reader.Description.SerialNumber = My.Settings.FingerprintReaderSerialnumber Then
                        Fingerprint.Current.Reader = Reader
                        reader_found = True
                    End If
                Next
                If Not reader_found Then
                    Dim selector As New ReaderSelection
                    selector.ShowDialog()
                    If Fingerprint.Current.Reader Is Nothing Then
                        Start_btn.Enabled = False
                    Else
                        My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                        My.Settings.Save()
                        GetOperators()
                    End If
                Else
                    GetOperators()
                End If
            Else
                Dim selector As New ReaderSelection
                selector.ShowDialog()
                If Fingerprint.Current.Reader Is Nothing Then
                    Start_btn.Enabled = False
                Else
                    My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                    GetOperators()
                End If
            End If
        Else
            GetOperators()
        End If
    End Sub

    Private Sub GetOperators()
        GF.FillCombobox(Badge_cbo, SQL.Current.GetDatatable("SELECT Badge, FullName FROM Smk_Operators WHERE [Active] = 1 ORDER BY FullName"), "FullName", "Badge")
    End Sub

    ''' <summary>
    ''' Handler for when a fingerprint is captured.
    ''' </summary>
    ''' <param name="captureResult">contains info and data on the fingerprint capture</param>
    Public Sub OnCaptured(ByVal captureResult As CaptureResult)
        Try
            ' Check capture quality and throw an error if bad.
            If Not Fingerprint.Current.CheckCaptureResult(captureResult) Then Return

            count += 1

            Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ANSI)

            If resultConversion.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                Fingerprint.Current.Reset = True
                Throw New Exception("" & resultConversion.ResultCode.ToString())
            End If

            preenrollmentFmds.Add(resultConversion.Data)
            For Each fiv As Fid.Fiv In captureResult.Data.Views
                Fingerprint_pb.Image = Fingerprint.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height)
            Next

            SendMessage(Action.SendMessage, "Huella capturada. Conteo:  " & (count.ToString()))

            If count >= 4 Then
                Dim resultEnrollment As DataResult(Of Fmd) = DPUruNet.Enrollment.CreateEnrollmentFmd(Formats.Fmd.ANSI, preenrollmentFmds)

                If resultEnrollment.ResultCode = ResultCode.DP_SUCCESS Then
                    Fingerprint.RefreshFingerprintDatabase()
                    Dim identifyResult = Comparison.Identify(resultConversion.Data, 0, Fingerprint.FingerprintDatabaseFMDArray, Fingerprint.ThresholdScore, 2)
                    If identifyResult.ResultCode = Constants.ResultCode.DP_SUCCESS Then
                        If identifyResult.Indexes.Length = 0 Then
                            Dim fmd_str As String = Fmd.SerializeXml(resultEnrollment.Data)
                            If SQL.Current.Update("Smk_Operators", {"Fingerprint"}, {fmd_str}, "Badge", Badge_cbo.SelectedValue) Then
                                Start_btn.Enabled = True
                                txtEnroll.Text = String.Empty
                                preenrollmentFmds.Clear()
                                Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
                                SendMessage(Action.SendMessage, "Huella registrada con éxito!")
                                SendMessage(Action.SendMessage, "Usuario: " & Badge_cbo.SelectedValue)
                                Result_pb.Image = My.Resources.tick_32
                            Else
                                txtEnroll.Text = String.Empty
                                SendMessage(Action.SendMessage, "### Error en registro.  Intenta nuevamente. ###")
                                SendMessage(Action.SendMessage, "Coloca el dedo en el lector...")
                                Result_pb.Image = My.Resources.critical_32
                                count = 0
                                preenrollmentFmds.Clear()
                            End If
                            Return
                        Else
                            txtEnroll.Text = String.Empty
                            SendMessage(Action.SendMessage, "### Error huella duplicada ###")
                            SendMessage(Action.SendMessage, "### Se encontró una huella con las mismas características registrada en el sistema. ###")
                            SendMessage(Action.SendMessage, "Intenta nuevamente.")
                            SendMessage(Action.SendMessage, "Coloca el dedo en el lector...")
                            Result_pb.Image = My.Resources.critical_32
                            count = 0
                            preenrollmentFmds.Clear()
                            Return
                        End If
                    Else
                        txtEnroll.Text = String.Empty
                        SendMessage(Action.SendMessage, "Error en enrolamiento.  Intenta nuevamente.")
                        SendMessage(Action.SendMessage, "Coloca el dedo en el lector...")
                        Result_pb.Image = My.Resources.critical_32
                        count = 0
                        preenrollmentFmds.Clear()
                    End If
                ElseIf (resultEnrollment.ResultCode = Constants.ResultCode.DP_ENROLLMENT_INVALID_SET) Then
                    txtEnroll.Text = String.Empty
                    SendMessage(Action.SendMessage, "Error en enrolamiento.  Intenta nuevamente.")
                    SendMessage(Action.SendMessage, "Coloca el dedo en el lector...")
                    Result_pb.Image = My.Resources.critical_32
                    count = 0
                    preenrollmentFmds.Clear()
                    Return
                End If
            End If
            SendMessage(Action.SendMessage, "Coloca el mismo dedo en el lector...")
        Catch ex As Exception
            SendMessage(Action.SendMessage, "Error:  " & ex.Message)
            Result_pb.Image = My.Resources.critical_32
        End Try
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendMessage
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As String)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As String)
        On Error Resume Next

        If Me.txtEnroll.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case action.SendMessage
                    txtEnroll.Text += payload & vbCrLf & vbCrLf
                    txtEnroll.SelectionStart = txtEnroll.TextLength
                    txtEnroll.ScrollToCaret()
            End Select
        End If
    End Sub
#End Region

    Private Sub Start_btn_Click(sender As Object, e As EventArgs) Handles Start_btn.Click
        If Badge_cbo.SelectedIndex >= 0 Then
            Result_pb.Image = Nothing
            txtEnroll.Text = String.Empty
            preenrollmentFmds = New List(Of Fmd)
            count = 0
            SendMessage(Action.SendMessage, "Coloca el dedo en el lector...")

            If Not Fingerprint.Current.OpenReader() Then
                SendMessage(Action.SendMessage, "Error al abrir el lector.")
            End If

            If Not Fingerprint.Current.StartCaptureAsync(AddressOf Me.OnCaptured) Then
                SendMessage(Action.SendMessage, "Error al iniciar la lectura.")
            End If
            Start_btn.Enabled = False
        End If
    End Sub

    Private Sub Enrollment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Fingerprint.Current.Reader IsNot Nothing Then
            Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs)
        Dim d As New Indentification
        d.ShowDialog()
    End Sub
End Class