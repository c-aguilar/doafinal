Public Class RawMaterial
    Public Shared Function GetDescription(partnumber) As String
        Return SQL.Current.GetString("Description", "Sys_RawMaterial", "Partnumber", partnumber, "")
    End Function
    Public Shared Function GetUoM(partnumber) As UnitOfMeasure
        Select Case SQL.Current.GetString("UoM", "Sys_RawMaterial", "Partnumber", partnumber, "").ToUpper
            Case "PC"
                Return UnitOfMeasure.PC
            Case "M"
                Return UnitOfMeasure.M
            Case "FT"
                Return UnitOfMeasure.FT
            Case "LB"
                Return UnitOfMeasure.LB
            Case "KG"
                Return UnitOfMeasure.KG
            Case "L"
                Return UnitOfMeasure.L
            Case Else
                Return UnitOfMeasure.PC
        End Select
    End Function
    Public Shared Function GetMRP(partnumber) As String
        Return SQL.Current.GetString("MRP", "Sys_RawMaterial", "Partnumber", partnumber, "")
    End Function

    Public Shared Function GetServiceLocations(partnumber) As String
        Return SQL.Current.GetString(String.Format("SELECT dbo.Smk_Locations('{0}');", partnumber))
    End Function

    Public Shared Function GetConsumptionType(partnumber) As ConsumptionType
        Select Case StrConv(SQL.Current.GetString("ConsumptionType", "Sys_RawMaterial", "Partnumber", partnumber, ""), VbStrConv.ProperCase)
            Case "Total"
                Return ConsumptionType.Total
            Case "Mixed"
                Return ConsumptionType.Mixed
            Case "Partial"
                Return ConsumptionType.Partial
            Case Else
                Return ConsumptionType.Total
        End Select
    End Function

    Public Shared Function GetMaterialType(partnumber) As MaterialType
        Select Case StrConv(SQL.Current.GetString("MaterialType", "Sys_RawMaterial", "Partnumber", partnumber, ""), VbStrConv.ProperCase)
            Case "Component"
                Return MaterialType.Component
            Case "Cable"
                Return MaterialType.Cable
            Case "Terminal"
                Return MaterialType.Terminal
            Case "Tape"
                Return MaterialType.Tape
            Case "Conduit"
                Return MaterialType.Conduit
            Case Else
                Return MaterialType.Component
        End Select
    End Function

    Public Shared Function Exists(Partnumber) As Boolean
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
            Me.Partnumber = part.Item("partnumber")
            Me.Description = part.Item("description")
            Select Case part.Item("uom").ToString.ToUpper
                Case "PC"
                    Me.UoM = UnitOfMeasure.PC
                Case "M"
                    Me.UoM = UnitOfMeasure.M
                Case "FT"
                    Me.UoM = UnitOfMeasure.FT
                Case "KG"
                    Me.UoM = UnitOfMeasure.KG
                Case "LB"
                    Me.UoM = UnitOfMeasure.LB
                Case "L"
                    Me.UoM = UnitOfMeasure.L
            End Select
            Select Case part.Item("orderunit").ToString.ToUpper
                Case "PC"
                    Me.OrderUnit = UnitOfMeasure.PC
                Case "M"
                    Me.OrderUnit = UnitOfMeasure.M
                Case "FT"
                    Me.OrderUnit = UnitOfMeasure.FT
                Case "KG"
                    Me.OrderUnit = UnitOfMeasure.KG
                Case "LB"
                    Me.OrderUnit = UnitOfMeasure.LB
                Case "L"
                    Me.OrderUnit = UnitOfMeasure.L
            End Select
            Me.RoundingValue = part.Item("roundingvalue")
            Me.UnitCost = part.Item("unitcost")
            Me.MRP = part.Item("mrp")
            Me.SupplierPartnumber = part.Item("supplierpartnumber")
            Me.SupplierName = part.Item("suppliername")
            Me.Container = part.Item("container")
            Select Case StrConv(part.Item("materialtype"), VbStrConv.ProperCase)
                Case "Tape"
                    _Type = MaterialType.Tape
                Case "Terminal"
                    _Type = MaterialType.Terminal
                Case "Component"
                    _Type = MaterialType.Component
                Case "Cable"
                    _Type = MaterialType.Cable
                Case "Conduit"
                    _Type = MaterialType.Conduit
            End Select
            Select Case StrConv(part.Item("consumptiontype"), VbStrConv.ProperCase)
                Case "Partial"
                    Me.Consumption = ConsumptionType.Partial
                Case "Mixed"
                    Me.Consumption = ConsumptionType.Mixed
                Case Else
                    Me.Consumption = ConsumptionType.Total
            End Select
            Me.Expirable = part.Item("expirable")
            Me.ReceivingLabelLegend = part.Item("labellegend")
        Else
            Me.Partnumber = partnumber
            Me.Exist = False
        End If
    End Sub
    Public Property Exist As Boolean
    Public Property Partnumber As String
    Public Property Description As String
    Public Property UoM As UnitOfMeasure
    Public Property OrderUnit As UnitOfMeasure
    Public Property RoundingValue As Decimal
    Public Property UnitCost As Decimal
    Public Property MRP As String
    Public Property SupplierPartnumber As String
    Public Property SupplierName As String
    Public Property Container As String
    Public Property Type As MaterialType
    Public Property Consumption As ConsumptionType
    Public Property Expirable As Boolean
    Public Property ReceivingLabelLegend As String


    Public Enum UnitOfMeasure
        PC
        M
        FT
        LB
        KG
        L
    End Enum

    Public Enum ConsumptionType
        Mixed
        Total
        [Partial]
    End Enum

    Public Enum MaterialType
        Cable
        Terminal
        Component
        Conduit
        Tape
    End Enum
End Class
