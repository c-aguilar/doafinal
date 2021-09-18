Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_btn.Click
        If User.Current.Login(UsernameTextBox.Text.Trim, PasswordTextBox.Text.Trim) Then
            My.Settings.LastLogon = UsernameTextBox.Text.ToUpper
            My.Settings.Save()
            Me.Hide()
            'Delta.Log("Login on Delta ERP", "Login")
            Dim main As New Main
            main.ShowDialog(Me)
            main.Dispose()
            Me.Close()
        Else
            FlashAlerts.ShowError("Usario y/o contraseña incorrectos.")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm = Me
        CAguilar.CAguilar.Key = "VroDfEydtLWY2ui8iXY/l+REy+ZEN7ykcioz5ikIPstUuNGE/oFM6wZKSeGQsJVHAWXiN9L33YQbDZ8dmg62OtsZd7pxCRWDohYOjwLy05U="
        SQL.Current.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        If Not My.Settings.LastLogon = "" Then
            UsernameTextBox.Text = My.Settings.LastLogon
        End If
        Me.Text = APP
        CAguilar.Language.Current = "ES"
        CAguilar.CAguilar.APP = APP

    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UsernameTextBox.Text <> "" Then
            PasswordTextBox.Focus()
        End If
    End Sub
End Class
