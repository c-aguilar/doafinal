Public Class Seal
    Public Sub New(partnumber As String)
        Me.Partnumber = partnumber
        Me.Color = SQL.Current.GetString("Color", "PE_Seals", "Partnumber", partnumber, "")
    End Sub
    Public Sub New(partnumber As String, color As String)
        Me.Partnumber = partnumber
        Me.Color = color
    End Sub
    Public Property Partnumber As String
    Public Property Color As String
End Class
