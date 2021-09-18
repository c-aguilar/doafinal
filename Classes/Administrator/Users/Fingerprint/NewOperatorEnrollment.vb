Imports System.Threading
Imports System.Collections.Generic
Imports DPUruNet
Imports DPUruNet.Constants

Public Class NewOperatorEnrollment
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
        For i = 1 To CInt(Parameter("SYS_BadgeLength", 9))
            Badge_txt.Mask &= "0"
        Next
        GF.FillCombobox(Shift_cbo, SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift")

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
                        Fingerprint_btn.Enabled = False
                    Else
                        My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                        My.Settings.Save()
                    End If
                End If
            Else
                Dim selector As New ReaderSelection
                selector.ShowDialog()
                If Fingerprint.Current.Reader Is Nothing Then
                    Fingerprint_btn.Enabled = False
                Else
                    My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                End If
            End If
        End If
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
                            If SQL.Current.Insert("Smk_Operators", {"Badge", "Firstname", "Lastname", "Area", "Shift", "Department", "Fingerprint"}, {Badge_txt.Text, Firstname_txt.Text, Lastname_txt.Text, "MFG", Shift_cbo.SelectedValue, Department_txt.Text, fmd_str}) Then
                                Fingerprint_btn.Enabled = True
                                txtEnroll.Text = String.Empty
                                Badge_txt.Clear()
                                Department_txt.Clear()
                                Firstname_txt.Clear()
                                Lastname_txt.Clear()
                                Shift_cbo.SelectedIndex = -1
                                count = 0
                                preenrollmentFmds.Clear()
                                Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
                                SendMessage(Action.SendMessage, "Operador registrado con éxito!")
                                SendMessage(Action.SendMessage, "Usuario: " & Badge_txt.Text)
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
                        Return
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

    Private Sub Start_btn_Click(sender As Object, e As EventArgs) Handles Fingerprint_btn.Click
        Result_pb.Image = Nothing
        If Badge_txt.MaskCompleted Then
            If Shift_cbo.SelectedIndex > -1 Then
                If Firstname_txt.Text <> "" AndAlso Lastname_txt.Text <> "" Then
                    If Not SQL.Current.Exists("Smk_Operators", "Badge", Badge_txt.Text) Then
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
                        Fingerprint_btn.Enabled = False
                    Else
                        FlashAlerts.ShowError("El número de gafete ya se encuentra registrado.")
                    End If
                Else
                    FlashAlerts.ShowInformation("Ingresa el nombre completo del operador.")
                End If
            Else
                FlashAlerts.ShowInformation("Selecciona el turno.")
            End If
        Else
            FlashAlerts.ShowInformation(String.Format("El número de gafete debe contener {0} caracteres.", Parameter("SYS_BadgeLength", 9)))
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

    Private Sub Cancel_btn_Click_1(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.Close()
    End Sub
End Class