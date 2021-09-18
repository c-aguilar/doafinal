﻿Public Class User
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
                    Me.Role = SQL.Current.GetString("Role", "Sys_Users", "Username", username, "")
                    Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Username", username, "")
                    Me.OnDomain = True
                    Me.Username = username.ToLower
                    SQL.Current.Update("Sys_Users", "Password", W3D.EncryptData(password), "Username", username)
                    LoadPermissions()
                    Return True
                Else
                    Return False
                End If
            ElseIf SQL.Current.Exists("Sys_Users", {"Username", "Password"}, {username, W3D.EncryptData(password)}) Then
                Me.IsAdmin = False
                Me.FullName = SQL.Current.GetString("FullName", "Sys_Users", "Username", username, "")
                Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Username", username, "")
                Me.Badge = SQL.Current.GetString("Badge", "Sys_Users", "Username", username, "")
                Me.Role = SQL.Current.GetString("Role", "Sys_Users", "Username", username, "")
                Me.OnDomain = False
                Me.Username = username.ToLower
                LoadPermissions()
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function LoginByFingerprint(badge As String) As Boolean
        If SQL.Current.Exists("Sys_Users", {"Badge", "Active"}, {badge, 1}) Then
            Me.IsAdmin = SQL.Current.Exists("Sys_Users", {"Badge", "Active", "IsAdministrator"}, {badge, 1, 1})
            Me.FullName = SQL.Current.GetString("FullName", "Sys_Users", "Badge", badge, "")
            Me.Badge = SQL.Current.GetString("Badge", "Sys_Users", "Badge", badge, "")
            Me.Role = SQL.Current.GetString("Role", "Sys_Users", "Badge", badge, "").ToUpper
            Me.Language = SQL.Current.GetString("[Language]", "Sys_Users", "Badge", badge, "")
            Me.OnDomain = True
            Me.Username = SQL.Current.GetString("Username", "Sys_Users", "Badge", badge, "").ToLower
            LoadPermissions()
            Return True
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
        Me.Permissions = SQL.Current.GetList("[Option]", "Sys_UserPermissions", {"Username", "Enabled"}, {Me.Username, 1})
    End Sub

    Public Property IsAdmin As Boolean

    Public Property Permissions As ArrayList

    Public Property Username As String

    Public Property Badge As String

    Public Property OnDomain As Boolean

    Public Property FullName As String

    Public Property Role As String

    Public Property Language As String
        Get
            Return _lang
        End Get
        Set(value As String)
            _lang = value
            SQL.Current.Update("Sys_Users", "[Language]", value, "Username", Me.Username)
        End Set
    End Property

    'Public ReadOnly Property Properties As Hashtable
    '    Get
    '        If _properties Is Nothing Then
    '            _properties = ActiveDirectory.UserInfo(Me.Username)
    '        End If
    '        Return _properties
    '    End Get
    'End Property

    Public Function GetSetting(name As String) As String
        Return SQL.Current.GetString("Value", "Sys_UserSettings", {"Username", "Setting"}, {Me.Username, name}, "")
    End Function
    Public Sub SaveSetting(name As String, setting As Object)
        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(setting)
        If SQL.Current.Exists("Sys_UserSettings", {"Username", "Setting"}, {Me.Username, name}) Then
            SQL.Current.Update("Sys_UserSettings", {"Value"}, {json}, {"Username", "Setting"}, {Me.Username, name})
        Else
            SQL.Current.Insert("Sys_UserSettings", {"Value", "Username", "Setting"}, {json, Me.Username, name})
        End If
    End Sub
End Class
