Public Class SysUserPermissions
    Dim _user As User
    Dim _option As SysModuleOptions
    Dim _enabled As Boolean

    Public Property user() As User
        Get
            Return _user
        End Get
        Set(value As User)
            _user = value
        End Set
    End Property

    Public Property moduleOption() As SysModuleOptions
        Get
            Return _option
        End Get
        Set(value As SysModuleOptions)
            _option = value
        End Set
    End Property

    Public Property enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
        End Set
    End Property

    Public Sub New(ByVal user As User, ByVal moduleOption As SysModuleOptions, ByVal enabled As Boolean)
        Me.user = user
        Me.moduleOption = moduleOption
        Me.enabled = enabled
    End Sub
End Class
