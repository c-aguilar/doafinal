Imports System.Threading
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Indentification
    ''' <summary>
    ''' Holds the main form with many functions common to all of SDK actions.
    ''' </summary>
    Public Property IdentifiedBadge As String

    ''' <summary>
    ''' Initialize the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Identification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                        'MessageBox.Show("No se encontró ningún lector de huellas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Message_lbl.Text = "Sin lector de huellas."
                        Message_lbl.ForeColor = Color.Red
                    Else
                        My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                        My.Settings.Save()
                        Start()
                        Fingerprint.RefreshFingerprintDatabase()
                    End If
                Else
                    Start()
                    Fingerprint.RefreshFingerprintDatabase()
                End If
            Else
                Dim selector As New ReaderSelection
                selector.ShowDialog()
                If Fingerprint.Current.Reader Is Nothing Then
                    ' MessageBox.Show("No se encontró ningún lector de huellas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Message_lbl.Text = "Sin lector de huellas."
                    Message_lbl.ForeColor = Color.Red
                Else
                    My.Settings.FingerprintReaderSerialnumber = Fingerprint.Current.Reader.Description.SerialNumber
                    My.Settings.Save()
                    Start()
                    Fingerprint.RefreshFingerprintDatabase()
                End If
            End If
        Else
            Start()
            Fingerprint.RefreshFingerprintDatabase()
        End If
    End Sub

    Private Sub Start()
        If Not Fingerprint.Current.OpenReader() Then
            Me.Close()
        End If

        If Not Fingerprint.Current.StartCaptureAsync(AddressOf Me.OnCaptured) Then
            Me.Close()
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


            Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ANSI)

            For Each fiv As Fid.Fiv In captureResult.Data.Views
                Fingerprint_pb.Image = Fingerprint.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height)
            Next


            If resultConversion.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                SendMessage(Action.SendMessageERROR, "Error de lectura.")
                Return
            End If

            Dim identifyResult = Comparison.Identify(resultConversion.Data, 0, Fingerprint.FingerprintDatabaseFMDArray, Fingerprint.ThresholdScore, 2)

            If identifyResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                SendMessage(Action.SendMessageERROR, "Huella no identificada.")
            End If

            If identifyResult.Indexes.Length = 1 Then
                SendMessage(Action.SendMessageOK, "Acceso autorizado.")
                Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
                Me.IdentifiedBadge = Fingerprint.FingerprintsDatabaseList.Item(identifyResult.Indexes(0).GetValue(0)).Badge
                Me.DialogResult = Windows.Forms.DialogResult.OK
                CloseForm()
            Else
                SendMessage(Action.SendMessageERROR, "Huella no identificada.")
            End If
        Catch ex As Exception
            SendMessage(Action.SendMessageERROR, "Error:  " & ex.Message)
        End Try
    End Sub

    Private Sub Enrollment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Fingerprint.Current.Reader IsNot Nothing Then
            Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
        End If
    End Sub


    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Delegate Sub CloseIt()

    Private Sub CloseForm()
        On Error Resume Next
        If Me.InvokeRequired Then
            Dim sValue As New CloseIt(AddressOf CloseForm)
            Invoke(sValue)
        Else
            Me.Close()
        End If
    End Sub

#Region "SendMessage"
    Public Enum Action
        SendMessageOK
        SendMessageERROR
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal action As Action, ByVal payload As String)
    Private Sub SendMessage(ByVal action As Action, ByVal payload As String)
        On Error Resume Next

        If Me.Message_lbl.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {action, payload})
        Else
            Select Case action
                Case Indentification.Action.SendMessageERROR
                    Message_lbl.Text = payload
                    Message_lbl.ForeColor = Color.DarkRed
                    Fingerprint_pb.BackColor = Color.DarkRed
                Case Indentification.Action.SendMessageOK
                    Message_lbl.Text = payload
                    Message_lbl.ForeColor = Color.Green
                    Fingerprint_pb.BackColor = Color.Green
            End Select
        End If
    End Sub
#End Region

    Private Sub Alter_link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Alter_link.LinkClicked
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            SendMessage(Action.SendMessageOK, "Acceso autorizado.")
            Fingerprint.Current.CancelCaptureAndCloseReader(AddressOf Me.OnCaptured)
            Me.IdentifiedBadge = newAdmin.User.Badge
            Me.DialogResult = Windows.Forms.DialogResult.OK
            CloseForm()
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub
End Class