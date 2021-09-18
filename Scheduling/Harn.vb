Public Class Harn
    Public Shared Function Format(material As String) As String
        Return Strings.Right("00000000" & Strings.Trim(material), 8)
    End Function
    Public Shared Function Exist(material As String) As Boolean
        Return SQL.Current.Exists("Sch_Materials", "Material", material)
    End Function
    Public Sub New(material As String)
        Dim material_record = SQL.Current.GetRecord("Sch_Materials", "Material", material)
        If material_record IsNot Nothing AndAlso material_record.Count > 0 Then
            Me.Exists = True
            Me.Material = material.ToUpper
            Me.CustomerPN = material_record.Item("customerpn")
            Me.Description = material_record.Item("description")
            Me.StdPack = If(material_record.Item("stdpack") = "", 1, material_record.Item("stdpack"))
            Me.Business = New Business(material_record.Item("business"), "") 'WAREHOUSE VACIO
            Me.Class = material_record.Item("class")
            Me.MRP = material_record.Item("mrp")
            'Dim bom As DataTable = SQL.Current.GetDatatable(String.Format("SELECT B.Quantity, R.* FROM vw_Sys_BOM_Stg3 AS B INNER JOIN Sys_RawMaterial AS R ON B.Partnumber = R.Partnumber WHERE Material = '{0}';", Me.Material))
            Dim bom As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Sys_BOM_Stg3 WHERE Material = '{0}';", Me.Material))
            'For Each row As DataRow In bom.Rows
            '    Me.BOM.Items.Add(New BOMItem(New RawMaterial(row.Item("Partnumber"), Delta.NullReplace(row.Item("Description"), ""), row.Item("UoM"), row.Item("RoundingValue"), row.Item("UnitCost"), row.Item("MRP"), Delta.NullReplace(row.Item("SupplierPartnumber"), ""), Delta.NullReplace(row.Item("SupplierNumber"), ""), Delta.NullReplace(row.Item("SupplierName"), ""), Delta.NullReplace(row.Item("Container"), ""), row.Item("MaterialType"), row.Item("ConsumptionType"), Delta.NullReplace(row.Item("LabelLegend"), ""), row.Item("Expirable"), Delta.NullReplace(row.Item("GRT"), 0), Delta.NullReplace(row.Item("PTF"), 0), Delta.NullReplace(row.Item("PC"), ""), Delta.NullReplace(row.Item("MOQ"), 1), Delta.NullReplace(row.Item("CP"), ""), row.Item("Fixed"), row.Item("MRP2"), Delta.NullReplace(row.Item("Document"), ""), Delta.NullReplace(row.Item("DocumentItem"), ""), row.Item("OrderUnit"), row.Item("WeightOnGr")), row.Item("Quantity")))
            'Next
            For Each row As DataRow In bom.Rows
                Me.BOM.Items.Add(row.Item("Partnumber"), New BOMItem(row.Item("Partnumber"), row.Item("Quantity")))
            Next
        Else
            Me.Exists = False
        End If
    End Sub
    Public Sub New(material As String, customerpn As String, description As String, stdpack As Integer, business As Business, [class] As String, mrp As String, bom As BOM)
        Me.Exists = True
        Me.Material = material.ToUpper
        Me.CustomerPN = customerpn
        Me.Description = description
        Me.StdPack = stdpack
        Me.Business = business
        Me.Class = [class]
        Me.BOM = bom
    End Sub
    Public Sub New(material As String, mrp As String, business As Business)
        Me.Material = material
        Me.Business = business
    End Sub
    Public Property Material As String
    Public Property CustomerPN As String
    Public Property Description As String
    Public Property StdPack As Integer
    Public Property Business As Business
    Public Property [Class] As String
    Public Property BOM As BOM
    Public Property Exists As Boolean
    Public Property MRP As String
End Class
