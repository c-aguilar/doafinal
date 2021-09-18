Public Class FGR_SerialScan
    Public Property Badge As String
    Public Property Route As String


    Private Sub FGR_SerialScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Picture_pb.Image = Delta.GetUserPhoto(Me.Badge)

    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Serial_txt.Validated
        If Serial_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Serial_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub ReadKanban()
        If IsSerial(Serial_txt.Text) Then
            If Not AlreadyScanned(Serial_txt.Text) AndAlso Not SQL.Current.Exists("FGR_SerialMovements", {"Serialnumber", "Status"}, {Serial_txt.Text, "BKF"}) Then

            Else
                FlashAlerts.ShowInformation("Serie duplicada.")
            End If
        Else
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowError("Serie incorrecta.")
        End If
    End Sub

    Private Function AlreadyScanned(serial As String) As Boolean
        Return False
    End Function

    Private Function IsSerial(serial As String)
        If serial <> "" AndAlso ((serial.Length = 11 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2))) _
              OrElse (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1))) _
             OrElse (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("M") AndAlso IsNumeric(serial.Remove(0, 1)))) _
         OrElse (serial.Length = 11 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1))) _
         OrElse (serial.Length = 18 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2))) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class