Public Class Business
    Public Sub New(name As String)
        Me.Name = name.ToUpper
        Me.Warehouse = SQL.Current.GetString("Warehouse", "Sch_Business", "Business", name, "").ToUpper
    End Sub
    Public Sub New(name As String, warehouse As String)
        Me.Name = name.ToUpper
        Me.Warehouse = warehouse.ToUpper
    End Sub
    Public Property Name As String
    Public Property Warehouse As String
End Class
