Public Class SysModuleOptions
    Dim _module As String
    Dim _form As String
    Dim _option As String
    Dim _description As String
    Dim _order As String

    Public Property module_() As String
        Get
            Return _module
        End Get
        Set(value As String)
            _module = value
        End Set
    End Property

    Public Property form() As String
        Get
            Return _form
        End Get
        Set(value As String)
            _form = value
        End Set
    End Property

    Public Property option_() As String
        Get
            Return _option
        End Get
        Set(value As String)
            _option = value
        End Set
    End Property

    Public Property description() As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Property order() As String
        Get
            Return _order
        End Get
        Set(value As String)
            _order = value
        End Set
    End Property

    Public Sub New(ByVal module_ As String, ByVal form As String, ByVal option_ As String, ByVal description As String, ByVal order As String)
        Me.module_ = module_
        Me.form = form
        Me.option_ = option_
        Me.description = description
        Me.order = order
    End Sub

End Class
