Public Class Family
    Public Sub New(name As String)
        Me.Name = name.ToUpper
        For Each business_i In SQL.Current.GetList("Business", "Sch_Business", {"Family"}, {name})
            Me.Business.Add(New Business(business_i.ToString))
        Next
    End Sub
    Public Sub New(name As String, business As List(Of Business))
        Me.Name = name.ToUpper
        Me.Business = business
    End Sub
    Public Property Name As String = ""
    Public Property Business As New List(Of Business)
End Class
