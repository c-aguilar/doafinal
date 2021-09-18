Public Class Smk_CableSerialReprint
    Private Sub Smk_CableSerialReprint_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub Serial_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Serial_txt.TextChanged
        If Serial_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub

    Private Sub Serial_txt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Serial_txt.KeyUp
        If e.KeyCode = Keys.Enter AndAlso SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub

    Private Sub ReadSerial()
        Dim serial As New Serialnumber(Serial_txt.Text)
        If serial.Exists Then
            REC.PrintLabel(Serial_txt.Text)
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowConfirm("Impresion enviada.")
        Else
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowError("La serie no existe.")
        End If
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Smk_CableSerialReprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class