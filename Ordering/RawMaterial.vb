Public Class RawMaterial
    Public Shared Function Format(partnumber As String) As String
        Return Strings.Right("00000000" & Strings.Trim(partnumber.ToUpper), 8)
    End Function

    Public Shared Function GetSupplierNumber(partnumber As String) As String
        Return SQL.Current.GetString("SupplierNumber", "Sys_RawMaterial", "Partnumber", partnumber, "")
    End Function

    Public Shared Function GetSupplierName(partnumber As String) As String
        Return SQL.Current.GetString("SupplierName", "Sys_RawMaterial", "Partnumber", partnumber, "")
    End Function

    Public Shared Function GetDescription(partnumber As String) As String
        Return SQL.Current.GetString("Description", "Sys_RawMaterial", "Partnumber", partnumber, "")
    End Function

    Public Shared Function GetWeight(partnumber As String) As Decimal
        Return SQL.Current.GetScalar("WeightOnGr", "Sys_RawMaterial", "Partnumber", partnumber, 0)
    End Function

    Public Shared Function GetWeightByUoM(partnumber As String, uom As String) As Decimal
        Return SQL.Current.GetScalar("dbo.Sys_UnitConversion(Partnumber,'" & uom & "',1,UoM) * WeightOnGr", "Sys_RawMaterial", "Partnumber", partnumber, 0)
    End Function

    Public Shared Function GetMfgConsumptionQty(partnumber As String) As Decimal
        Return SQL.Current.GetScalar("MfgConsumptionQty", "Sys_RawMaterial", "Partnumber", partnumber, 0)
    End Function

    Public Shared Function GetUoM(partnumber As String) As UnitOfMeasure
        Return StrToUnitOfMeasure(SQL.Current.GetString("UoM", "Sys_RawMaterial", "Partnumber", partnumber, ""))
    End Function

    Public Shared Function GetUoMOptions(partnumber As String) As ArrayList
        Dim opts As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT UPPER(BuM) FROM (SELECT BuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}' UNION SELECT AuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}' UNION SELECT UoM FROM Sys_RawMaterial WHERE Partnumber = '{0}') AS B;", partnumber))
        If opts.Contains("M") AndAlso Not opts.Contains("FT") Then opts.Add("FT")
        If opts.Contains("FT") AndAlso Not opts.Contains("M") Then opts.Add("M")
        If opts.Contains("KG") AndAlso Not opts.Contains("LB") Then opts.Add("LB")
        If opts.Contains("LB") AndAlso Not opts.Contains("KG") Then opts.Add("KG")
        If opts.Contains("L") AndAlso Not opts.Contains("GAL") Then opts.Add("GAL")
        If opts.Contains("GAL") AndAlso Not opts.Contains("L") Then opts.Add("L")
        Return opts
    End Function

    Public Shared Function GetFlags(partnumber As String) As ArrayList
        Return SQL.Current.GetList("Flag", "Sys_PartnumberFlags", {"Partnumber"}, {partnumber})
    End Function

    Public Shared Function GetFlags(partnumber As String, area As String) As ArrayList
        Return SQL.Current.GetList(String.Format("SELECT F.Flag FROM Sys_PartnumberFlags AS F INNER JOIN Sys_PartnumberFlagsDescription AS D ON F.Flag = D.Flag WHERE F.Partnumber = '{0}' AND D.Area = '{1}';", partnumber, area))
    End Function

    Public Shared Function GetStrUoM(partnumber As String) As String
        Return SQL.Current.GetString("UoM", "Sys_RawMaterial", "Partnumber", partnumber, "").ToUpper
    End Function

    Public Shared Function ValidUoM(partnumber As String, uom As String) As Boolean
        If uom.ToUpper = RawMaterial.GetStrUoM(partnumber) Then
            Return True
        Else
            Return SQL.Current.Exists(String.Format("SELECT TOP 1 Partnumber FROM Sys_ConversionUnits WHERE Partnumber = '{0}' AND (BuM = '{1}' OR AuM = '{1}');", partnumber, uom))
        End If
    End Function

    Public Shared Function GetMRP(partnumber As String) As String
        Return SQL.Current.GetString("MRP", "Sys_RawMaterial", "Partnumber", partnumber, "").ToUpper
    End Function

    Public Shared Function GetMRPUserFullname(partnumber As String) As String
        Return SQL.Current.GetString("U.Fullname", "Sys_RawMaterial AS R INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP INNER JOIN Sys_Users AS U ON M.Username = U.Username", "R.Partnumber", partnumber, "")
    End Function

    Public Shared Function GetServiceLocations(partnumber As String) As String
        Return SQL.Current.GetString(String.Format("SELECT dbo.Smk_Locations('{0}');", partnumber))
    End Function

    Public Shared Function GetServiceLocation(partnumber As String, warehouse As String) As String
        Return SQL.Current.GetString(String.Format("SELECT Location FROM Smk_Map WHERE Partnumber = '{0}' AND Warehouse = '{1}';", partnumber, warehouse), "00000000")
    End Function

    Public Shared Function IsControlled(partnumber As String) As Boolean
        Return SQL.Current.Exists("Rec_ControlledPartnumbers", {"Partnumber", "Active"}, {partnumber, 1})
    End Function

    Public Shared Function GetOrderingComment(partnumber As String) As String
        Return SQL.Current.GetString("Sys_RawMaterial", "OrderingComment", "Partnumber", partnumber, "")
    End Function

    Public Shared Function IsSensitive(partnumber As String) As Boolean
        Return SQL.Current.Exists("Sys_RawMaterial", {"Partnumber", "IsSensitive"}, {partnumber, 1})
    End Function

    Public Shared Function GetMfgConsumptionControlType(partnumber As String) As MfgConsumptionControlType
        Return StrToMfgConsumptionControlType(SQL.Current.GetString("MfgConsumptionControl", "Sys_RawMaterial", "Partnumber", partnumber, ""))
    End Function

    Public Shared Function GetConsumptionType(partnumber As String) As ConsumptionType
        Return StrToConsumptionType(SQL.Current.GetString("ConsumptionType", "Sys_RawMaterial", "Partnumber", partnumber, ""))
    End Function

    Public Shared Function GetMaterialType(partnumber As String) As MaterialType
        Return StrToMaterialType(SQL.Current.GetString("MaterialType", "Sys_RawMaterial", "Partnumber", partnumber, ""))
    End Function

    Public Shared Function ConvertUoM(partnumber As String, from_uom As String, quantity As Decimal, to_unit As String) As Decimal
        Return SQL.Current.GetScalar(String.Format("SELECT dbo.Sys_UnitConversion('{0}','{1}',{2},'{3}');", partnumber, from_uom, quantity, to_unit))
    End Function

    Public Shared Function StrToMfgConsumptionControlType(type As String) As MfgConsumptionControlType
        Select Case type.ToUpper
            Case "N"
                Return MfgConsumptionControlType.None
            Case "D"
                Return MfgConsumptionControlType.Daily
            Case "W"
                Return MfgConsumptionControlType.Weekly
            Case "M"
                Return MfgConsumptionControlType.Monthly
            Case Else
                Return MfgConsumptionControlType.None
        End Select
    End Function

    Public Shared Function StrToConsumptionType(type As String) As ConsumptionType
        Select Case StrConv(type, VbStrConv.ProperCase)
            Case "Total"
                Return ConsumptionType.Total
            Case "Mixed"
                Return ConsumptionType.Mixed
            Case "Partial"
                Return ConsumptionType.Partial
            Case "Service"
                Return ConsumptionType.Service
            Case "Obsolete"
                Return ConsumptionType.Obsolete
            Case "Cao"
                Return ConsumptionType.CAO
            Case Else
                Return ConsumptionType.Total
        End Select
    End Function

    Public Shared Function StrToMaterialType(type As String) As MaterialType
        Select Case StrConv(type, VbStrConv.ProperCase)
            Case "Tape"
                Return MaterialType.Tape
            Case "Terminal"
                Return MaterialType.Terminal
            Case "Component"
                Return MaterialType.Component
            Case "Cable"
                Return MaterialType.Cable
            Case "Conduit"
                Return MaterialType.Conduit
            Case "Seal"
                Return MaterialType.Seal
            Case "TerminalAssembly"
                Return MaterialType.TerminalAssembly
            Case "Tube"
                Return MaterialType.Tube
            Case "Chemical"
                Return MaterialType.Chemical
            Case "Harness"
                Return MaterialType.Harness
            Case "Label"
                Return MaterialType.Label
            Case "Calibre"
                Return MaterialType.Calibre
            Case Else
                Return MaterialType.Component
        End Select
    End Function

    Public Shared Function StrToUnitOfMeasure(uom As String) As UnitOfMeasure
        Select Case uom.ToUpper
            Case "PC"
                Return UnitOfMeasure.PC
            Case "M"
                Return UnitOfMeasure.M
            Case "FT"
                Return UnitOfMeasure.FT
            Case "KG"
                Return UnitOfMeasure.KG
            Case "LB"
                Return UnitOfMeasure.LB
            Case "L"
                Return UnitOfMeasure.L
            Case "GAL"
                Return UnitOfMeasure.GAL
            Case "ROL"
                Return UnitOfMeasure.ROL
            Case Else
                Return UnitOfMeasure.PC
        End Select
    End Function

    Public Shared Function Exists(Partnumber As String) As Boolean
        Return SQL.Current.Exists("Sys_RawMaterial", "Partnumber", Partnumber)
    End Function

    Public Sub New(partnumber As String, Optional findbysupplierpartnumber As Boolean = False)
        Dim part As Hashtable
        If findbysupplierpartnumber Then
            part = SQL.Current.GetRecord("Sys_RawMaterial", "SupplierPartnumber", partnumber)
        Else
            part = SQL.Current.GetRecord("Sys_RawMaterial", "Partnumber", partnumber)
        End If
        If part.Count > 0 Then
            Me.Exist = True
            Me.Partnumber = partnumber.ToUpper
            Me.Description = part.Item("description")
            Me.UoM = StrToUnitOfMeasure(part.Item("uom"))
            Me.OrderUnit = StrToUnitOfMeasure(part.Item("orderunit"))
            Me.RoundingValue = part.Item("roundingvalue")
            Me.UnitCost = part.Item("unitcost")
            Me.MRP = part.Item("mrp").ToString.ToUpper
            Me.SupplierPartnumber = part.Item("supplierpartnumber")
            Me.SupplierName = part.Item("suppliername")
            Me.SupplierNumber = part.Item("suppliernumber")
            Me.Container = part.Item("container")
            _Type = RawMaterial.StrToMaterialType(part.Item("materialtype"))
            Me.Consumption = StrToConsumptionType(part.Item("consumptiontype"))
            Me.Expirable = part.Item("expirable")
            Me.ReceivingLabelLegend = part.Item("labellegend")
            Me.GRT = IIf(part.Item("grt") = "", 0, part.Item("grt"))
            Me.PlanningTimeFence = IIf(part.Item("ptf") = "", 0, part.Item("ptf"))
            Me.PlanningCalendar = part.Item("pc").ToString.ToUpper
            Me.MOQ = IIf(part.Item("moq") = "", Me.RoundingValue, part.Item("moq"))
            Me.CoverageProfile = part.Item("cp").ToString.ToUpper
            Me.Fixed = part.Item("fixed")
            Me.MRP2 = part.Item("mrp2")
            Me.Document = part.Item("document")
            Me.DocumentItem = part.Item("documentitem")
            Me.WeightOnGr = part.Item("weightongr")
            Me.Sensitive = part.Item("issensitive")
            Me.OrderingComment = part.Item("orderingcomment")
            Me.BOMIssueFactor = part.Item("bomissuefactor")
            Me.MasterLabel = CBool(part.Item("masterlabel"))
            Me.ChildQuantity = part.Item("childlabelquantity")
            Me.MfgConsumptionControl = StrToMfgConsumptionControlType(part.Item("mfgconsumptioncontrol"))
            Me.UnitWeightValidated = CBool(part.Item("unitweightvalidated"))
        Else
            Me.Partnumber = partnumber.ToUpper
            Me.Exist = False
        End If
    End Sub


    Public Sub New(partnumber As String, description As String, uom As String, rounding_value As Decimal, unit_cost As Decimal, mrp As String, supplier_partnumber As String, supplier_number As String, supplier_name As String, container As String, material_type As String, consumption_type As String, label_legend As String, expirable As Boolean, grt As Integer, ptf As Integer, pc As String, moq As Decimal, cp As String, fixed As Boolean, mrp2 As Boolean, document As String, document_item As String, order_unit As String, weightongr As Decimal, is_sensitive As Boolean, ordering_comment As String, bom_issuefactor As Decimal, mfg_consumption_control As String, master_label As Boolean, child_quantity As Decimal, unitweight_validated As Boolean)
        Me.Exist = True
        Me.Partnumber = partnumber.ToUpper
        Me.Description = description
        Me.UoM = StrToUnitOfMeasure(uom)
        Me.OrderUnit = StrToUnitOfMeasure(order_unit)
        Me.RoundingValue = rounding_value
        Me.UnitCost = unit_cost
        Me.MRP = mrp.ToUpper
        Me.SupplierPartnumber = supplier_partnumber
        Me.SupplierName = supplier_name
        Me.SupplierNumber = supplier_number
        Me.Container = container
        _Type = RawMaterial.StrToMaterialType(material_type)
        Me.Consumption = StrToConsumptionType(consumption_type)
        Me.Expirable = expirable
        Me.ReceivingLabelLegend = label_legend
        Me.GRT = grt
        Me.PlanningTimeFence = ptf
        Me.PlanningCalendar = pc.ToUpper
        Me.MOQ = moq
        Me.CoverageProfile = cp.ToUpper
        Me.Fixed = fixed
        Me.MRP2 = mrp2
        Me.Document = document
        Me.DocumentItem = document_item
        Me.WeightOnGr = weightongr
        Me.Sensitive = is_sensitive
        Me.OrderingComment = ordering_comment
        Me.BOMIssueFactor = bom_issuefactor
        Me.MasterLabel = master_label
        Me.ChildQuantity = child_quantity
        Me.MfgConsumptionControl = StrToMfgConsumptionControlType(mfg_consumption_control)
        Me.UnitWeightValidated = unitweight_validated
    End Sub
    Public Property OrderingComment As String
    Public Property Exist As Boolean
    Public Property Partnumber As String
    Public Property Description As String
    Public Property UoM As UnitOfMeasure
    Public Property OrderUnit As UnitOfMeasure
    Public Property RoundingValue As Decimal
    Public Property UnitCost As Decimal
    Public Property MRP As String
    Public Property SupplierPartnumber As String
    Public Property SupplierNumber As String
    Public Property SupplierName As String
    Public Property Container As String
    Public Property Type As MaterialType
    Public Property Consumption As ConsumptionType
    Public Property Expirable As Boolean
    Public Property ReceivingLabelLegend As String
    Public Property GRT As Integer
    Public Property PlanningTimeFence As Integer
    Public Property PlanningCalendar As String
    Public Property MOQ As Decimal
    Public Property CoverageProfile As String
    Public Property Fixed As Boolean
    Public Property MRP2 As Boolean
    Public Property Document As String
    Public Property DocumentItem As String
    Public Property WeightOnGr As Decimal
    Public Property Sensitive As Boolean
    Public Property BOMIssueFactor As Decimal
    Public Property MfgConsumptionControl As MfgConsumptionControlType
    Public Property MasterLabel As Boolean
    Public Property ChildQuantity As Decimal
    Public Property UnitWeightValidated As Boolean
    Public ReadOnly Property OrderStdPack
        Get
            Return Math.Max(Math.Max(Me.MOQ, Me.RoundingValue), 1)
        End Get
    End Property

    Public Function RoundByStdPack(quantity As Decimal) As Decimal
        Return Math.Ceiling(quantity / Me.OrderStdPack) * Me.OrderStdPack
    End Function

    Public Enum UnitOfMeasure
        PC
        M
        FT
        LB
        KG
        L
        ROL
        GAL
    End Enum

    Public Enum ConsumptionType
        Mixed
        Total
        [Partial]
        Service
        Obsolete
        CAO
    End Enum

    Public Enum MfgConsumptionControlType
        None
        Daily
        Weekly
        Monthly
    End Enum

    Public Enum MaterialType
        Cable
        Calibre
        Terminal
        TerminalAssembly
        Seal
        Component
        Conduit
        Tube
        Tape
        Chemical
        Harness
        Label
        Tie
        Pigtail
        Solder
    End Enum
End Class
