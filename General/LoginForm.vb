Imports System.Runtime.InteropServices
Public Class LoginForm
    Dim plants As DataTable


    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, LogoPictureBox.MouseDown, PanelMain.MouseDown, DeltaLabel.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_btn.Click
        ChooseConnection()
        If User.Current.Login(UsernameTextBox.Text.Trim, PasswordTextBox.Text.Trim) Then
            GetIn()
        Else
            FlashAlerts.ShowError("Usuario y/o contraseña incorrectos.")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm = Me
        CAguilar.CAguilar.Key = "VroDfEydtLWY2ui8iXY/l+REy+ZEN7ykcioz5ikIPstUuNGE/oFM6wZKSeGQsJVHAWXiN9L33YQbDZ8dmg62OtsZd7pxCRWDohYOjwLy05U="
        If Not My.Settings.LastLogon = "" Then
            UsernameTextBox.Text = My.Settings.LastLogon
        End If
        Me.Text = APP
        CAguilar.Language.Current = "ES"
        CAguilar.CAguilar.APP = APP

        plants = New DataTable
        plants.Columns.Add("Plant")
        plants.Columns.Add("Name")
        plants.Rows.Add("FV34", "Past Model Service")
        plants.Rows.Add("FV38", "Rio Bravo Eléctricos V")
        plants.Rows.Add("FV37", "Rio Bravo Eléctricos IX")
        plants.Rows.Add("FV50", "Alambrados y Circuitos Eléctricos X")
        plants.Rows.Add("SBox", "Sand Box")

        GF.FillCombobox(Plant_cbo, plants, "Name", "Plant")
        Plant_cbo.SelectedValue = My.Settings.DefaultPlant
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UsernameTextBox.Text <> "" Then
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub ChooseConnection()
        Select Case Plant_cbo.SelectedValue
            Case "FV34"
                SQL.SetGlobalConnectionString("DLJ0KKMR2\SQLEXPRESS", "Delta", "sa", "PMSSystem2020")
            Case "FV38"
                SQL.SetGlobalConnectionString("DL1LV9XK2\EXPRESS2008", "Delta", "sa", "adminfv38")
            Case "FV37"
                SQL.SetGlobalConnectionString("DLBVQJ7M2\EXPRESSFV37", "Delta", "sa", "FV37-@dmin")
            Case "FV50"
                SQL.SetGlobalConnectionString("10.223.72.196\SQLEXPRESS", "Delta", "sa", "adminfv50")
            Case "SBox"
                SQL.SetGlobalConnectionString("DLJ0JFMR2\RBEVBACKUP", "Delta", "sa", "adminfv38")
                Delta.SandBox = True
        End Select
    End Sub

    Private Sub GetIn()
        My.Settings.LastLogon = UsernameTextBox.Text.ToUpper
        My.Settings.DefaultPlant = Plant_cbo.SelectedValue
        My.Settings.Save()
        Me.Hide()

        Dim main As New Main
        main.Text = "Delta ERP - " & Plant_cbo.GetItemText(Plant_cbo.SelectedItem)
        main.ShowDialog(Me)
        main.Dispose()
        Me.Close()
    End Sub

    Private Sub ByFingerprint_btn_Click(sender As Object, e As EventArgs) Handles ByFingerprint_btn.Click
        ChooseConnection()
        Dim badge As String = Fingerprint.GetBadge()
        If badge <> "" Then
            If User.Current.LoginByFingerprint(badge) Then
                GetIn()
            Else
                FlashAlerts.ShowError("Huella no reconocida.")
            End If
        End If
    End Sub
End Class
