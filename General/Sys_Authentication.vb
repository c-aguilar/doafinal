Public Class Sys_Authentication
    Public Property User As New User
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_btn.Click
        If User.Login(UsernameTextBox.Text.Trim, PasswordTextBox.Text.Trim) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            FlashAlerts.ShowError("Usario y/o contraseña incorrectos.")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UsernameTextBox.Focus()
    End Sub

    Private Sub Smk_CableLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = APP
    End Sub
End Class
