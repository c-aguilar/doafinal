Public Class BOM
    Implements ICloneable

    Public Sub New(material As String)
        Me.Material = material
    End Sub
    Public Property Material As String
    Public Property Items As New Dictionary(Of String, BOMItem)

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class
Public Class BOMItem
    Sub New(partnumber As String, usage As Decimal)
        Me.Partnumber = partnumber.ToUpper
        Me.Usage = usage
    End Sub
    Public Property Partnumber As String
    Public Property Usage As Decimal
End Class
