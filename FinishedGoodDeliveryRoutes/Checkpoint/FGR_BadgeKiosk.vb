Public Class FGR_Badge
    Public Property SelectedBadge As String
    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Badge_txt_TextChanged(sender As Object, e As EventArgs) Handles Badge_txt.TextChanged
        If Badge_txt.TextLength = Parameter("SYS_BadgeLength", 9) And IsNumeric(Badge_txt.Text) Then
            ReadBadge()
        ElseIf Badge_txt.TextLength = 10 Then
            ReadBadge()
        ElseIf Badge_txt.Text.Trim.ToUpper = "CLOSE" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub ReadBadge()
        If SQL.Current.Exists("Smk_Operators", {"Badge", "Active", "Area"}, {Strings.Right(Badge_txt.Text, Parameter("SYS_BadgeLength", 9)), 1, "FGR"}) Then
            Me.SelectedBadge = Strings.Right(Badge_txt.Text, Parameter("SYS_BadgeLength", 9))
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Badge_txt.Clear()
            Badge_txt.Focus()
            FlashAlerts.ShowError("Gafete no registrado.")
        End If
    End Sub

    Private Sub Smk_BadgeKiosk_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Badge_txt.Focus()
    End Sub

    Private Sub Badge_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Badge_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ReadBadge()
        End If
    End Sub

    Private Sub FGR_Badge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class