Public Class [Operator]
    Public Sub New()

    End Sub
    Public Sub New(shift As String, checkin As Integer, checkout As Integer)
        Me.Shift = shift
        Me.CheckIn = checkin
        Me.CheckOut = checkout
    End Sub
    Public Property Shift As String
    Public Property CheckIn As Integer
    Public Property CheckOut As Integer
    Public ReadOnly Property BusyUntil As Integer
        Get
            If Me.Tasks.Count = 0 Then
                Return Me.CheckIn
            Else
                Return Me.Tasks.Last.End
            End If
        End Get
    End Property
    Public Property Tasks As New List(Of Task)
    Public Class Task
        Public Property Name As String
        Public Property Start As Integer
        Public Property [End] As Integer
    End Class
End Class