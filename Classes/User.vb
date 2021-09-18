Public Class User
    Private Shared _user As New User
    Dim _lang As String
    Public Shared ReadOnly Property Current As User
        Get
            Return _user
        End Get
    End Property

    Dim _properties As Hashtable
    Public Sub New()

    End Sub

    Public Sub New(username As String, password As String)
        Login(username, password)
    End Sub

    Public Function Login(username As String, password As String) As Boolean
        If SQL.Current.Exists("Sys_Users", {"Username", "Active"}, {username, 1}) Then
            If SQL.Current.Exists("Sys_Users", {"Username", "OnDomain"}, {username, 1}) Then
                If ActiveDirectory.ValidateCredentials(username, password) Then
                    Me.IsAdmin = SQL.Current.Exists("Sys_Users", {"Username", "Active", "IsAdministrator"}, {username, 1, 1})
                    Me.FullName = SQL.Current.GetString("FullName", "Sys_Users", "Username", username, "")
                    Me.Badge = SQL.Current.GetString("Badge", "Sys_Users", "Username", username, "")
                    Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Username", username, "")
                    Me.OnDomain = True
                    _Username = username.ToLower
                    LoadPermissions()
                    Return True
                Else
                    Return False
                End If
            Else
                If username.ToLower = "public" AndAlso password = "" Then
                    Me.IsAdmin = False
                    Me.FullName = SQL.Current.GetString("FullName", "Sys_Users", "Username", username, "")
                    Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Username", username, "")
                    Me.Badge = "000000000"
                    Me.OnDomain = False
                    _Username = username.ToLower
                    LoadPermissions()
                    Return True
                ElseIf SQL.Current.Exists("Sys_Users", {"Username", "Password"}, {username, W3D.EncryptData(password)}) Then
                    Me.IsAdmin = False
                    Me.FullName = SQL.Current.GetString("FullName", "Sys_Users", "Username", username, "")
                    Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Username", username, "")
                    Me.Badge = SQL.Current.GetString("Badge", "Sys_Users", "Username", username, "")
                    Me.OnDomain = False
                    _Username = username.ToLower
                    LoadPermissions()
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

    Public Function HasPermission([option] As String) As Boolean
        If Me.IsAdmin Then
            Return True
        Else
            Return Me.Permissions.Contains([option])
        End If
    End Function

    Private Sub LoadPermissions()
        Me.Permissions = SQL.Current.GetList(String.Format("SELECT [Option] FROM Sys_UserPermissions WHERE Username='{0}' AND Enabled=1;", Me.Username))
    End Sub

    Public Property IsAdmin As Boolean

    Public Property Permissions As ArrayList

    Public Property Username As String

    Public Property Badge As String

    Public Property OnDomain As Boolean

    Public Property FullName As String

    Public Property Language As String
        Get
            Return _lang
        End Get
        Set(value As String)
            _lang = value
            SQL.Current.Update("Sys_Users", "[Language]", value, "Username", Username)
        End Set
    End Property

    Public ReadOnly Property Properties As Hashtable
        Get
            If _properties Is Nothing Then
                _properties = ActiveDirectory.UserInfo(_Username)
            End If
            Return _properties
        End Get
    End Property
End Class
