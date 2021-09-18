Public Class PEColor
    Public Sub New(sapname As String)
        Dim record As Hashtable = SQL.Current.GetRecord("PE_Colors", "SAP_ShortName", sapname)
        Me.Name = record.Item("name")
        Me.TWShortName = record.Item("tw_shortname")
        Me.GSDShortName = record.Item("gsd_shortname")
        Me.SAPShortName = record.Item("sap_shortname")
        Me.Hexadecimal = record.Item("hexadecimal")
        Me.Color = ColorTranslator.FromHtml("#" & Me.Hexadecimal)
    End Sub
    Public Property Name As String
    Public Property TWShortName As String
    Public Property GSDShortName As String
    Public Property SAPShortName As String
    Public Property Hexadecimal As String
    Public Property Color As Color
End Class
