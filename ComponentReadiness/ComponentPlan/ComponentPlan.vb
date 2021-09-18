Public Class ComponentPlan
    Public Property LoadDate As Date
    Dim _production_plan As ProductionPlan
    Public Shared Property CoverageProfiles As New Dictionary(Of String, CoverageProfile)
    Public Shared Property PlanningCalendars As New Dictionary(Of String, PlanningCalendar)
    Public Shared Property Suppliers As New Dictionary(Of String, Supplier)
    Public Shared Property MRPOwners As New Dictionary(Of String, String)
    Public Shared Property Flags As New Dictionary(Of String, Flag)
    Public Shared Property BusinessScheduledChanges As New Dictionary(Of String, ScheduledChange)
    Public Shared Property MaterialScheduledChanges As New Dictionary(Of String, ScheduledChange)
    Public Property Items As New Dictionary(Of String, ComponentPlanItem)
    Dim thread_A As Threading.Thread
    Dim thread_B As Threading.Thread
    Dim thread_C As Threading.Thread
    Dim thread_D As Threading.Thread
    Dim thread_A_finished As Boolean = False
    Dim thread_B_finished As Boolean = False
    Dim thread_C_finished As Boolean = False
    Dim thread_D_finished As Boolean = False
    Dim open_orders_dt As DataTable
    Dim planned_orders_dt As DataTable
    Dim transits_dt As DataTable
    Dim promises_dt As DataTable
    Dim raw_material As DataTable
    Dim flags_dt As DataTable
    Dim map_dt As DataTable
    Dim current_random_stock_dt As DataTable
    Dim current_service_stock_dt As DataTable
    Dim current_wip_stock_dt As DataTable
    Dim current_quality_stock_dt As DataTable

    Private Sub GetOrders()
        open_orders_dt = SQL.Current.GetDatatable(String.Format("SELECT O.*, C.CallOff, dbo.Sys_UnitConversion(O.Partnumber, C.UoM, C.Quantity, R.UoM) AS CallOffQuantity, C.Extra, dbo.Sys_UnitConversion(O.Partnumber, O.UoM, O.Quantity, R.UoM) AS QuantityBuM, dbo.Sys_UnitConversion(O.Partnumber, O.UoM, O.Status, R.UoM) AS StatusBuM,O.Comment FROM Ord_OpenOrders AS O INNER JOIN Sys_RawMaterial AS R ON O.Partnumber = R.Partnumber LEFT OUTER JOIN (SELECT Partnumber, CallOff, PickUpDate, Quantity, UoM, Extra, ASN FROM Ord_CallOffs WHERE Closed = 0) AS C ON C.Partnumber = O.Partnumber AND C.PickUpDate = O.ShipDate WHERE O.[Active] = 1 AND [AvailabilityDate] <= '{0}' AND O.Quantity >= 1 AND C.ASN IS NULL;", Me.Horizon.ToString("yyyy-MM-dd")), "OpenOrders")
        planned_orders_dt = SQL.Current.GetDatatable(String.Format("SELECT P.*,dbo.Sys_UnitConversion(P.Partnumber, P.UoM, P.Quantity, R.UoM) AS QuantityBuM FROM Ord_PlannedOrders AS P INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber WHERE Agreement <> '' AND [AvailabilityDate] BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")), "PlannedOrders")
        thread_A_finished = True
    End Sub

    Private Sub GetTransits()
        transits_dt = SQL.Current.GetDatatable(String.Format("SELECT T.Partnumber,T.DeliveryDate,T.DeliveryNumber,T.PO,T.Items,T.UoM,T.Quantity,CONVERT(BIT, CASE WHEN T.RealDate IS NULL THEN 1 ELSE 0 END) AS Edited,ISNULL(T.RealDate,T.AvailabilityDate) AS AvailabilityDate,T.ExternalDocument,T.PRONumber,T.ID,dbo.Sys_UnitConversion(T.Partnumber, T.UoM, T.Quantity, R.UoM) AS QuantityBuM FROM Ord_Transits AS T INNER JOIN Sys_RawMaterial AS R ON T.Partnumber = R.Partnumber WHERE T.Active = 1 AND ISNULL(T.RealDate,T.AvailabilityDate) BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")), "Transits")
        promises_dt = SQL.Current.GetDatatable(String.Format("SELECT P.*,U.Fullname,dbo.Sys_UnitConversion(P.Partnumber, P.UoM, P.Quantity, R.UoM) AS QuantityBuM FROM Ord_ManualPromises AS P INNER JOIN Sys_Users AS U ON P.Username = U.Username INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber WHERE P.[Active] = 1 AND P.[AvailabilityDate] BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")), "Promises")
        thread_B_finished = True
    End Sub

    Private Sub GetRaw()
        raw_material = SQL.Current.GetDatatable(String.Format("SELECT *,dbo.Smk_Locations(Partnumber) AS SmkLocation FROM Sys_RawMaterial WHERE IsRaw=1;"), "RawMaterial")
        flags_dt = SQL.Current.GetDatatable("SELECT F.Partnumber,F.Flag FROM Sys_PartnumberFlags AS F INNER JOIN Sys_PartnumberFlagsDescription AS D ON F.Flag = D.Flag WHERE D.Area IN ('ORD','CR')")
        thread_C_finished = True
    End Sub

    Private Sub GetStock()
        current_random_stock_dt = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE [Status] IN ('N','P','Q','S','T') AND RedTag = 0 GROUP BY Partnumber;"), "Random")

        current_service_stock_dt = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE [Status] IN ('C','O','U') AND RedTag = 0 AND Sloc <> '0002' GROUP BY Partnumber;"), "Service")

        current_quality_stock_dt = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE [Status] NOT IN ('E','D') AND RedTag = 1 GROUP BY Partnumber;"), "Quality")

        current_wip_stock_dt = SQL.Current.GetDatatable("SELECT Partnumber,Date,Quantity,Usage FROM Ord_CurrentWIP;") 'SQL.Current.GetDatatable(String.Format("SELECT W.Partnumber,W.[Date],dbo.Sys_UnitConversion(W.Partnumber,W.UoM,W.Quantity,R.UoM) AS Quantity, ISNULL((SELECT SUM(M.Quantity * B.Quantity) FROM Sys_CurrentBOM AS B INNER JOIN FGR_SerialMovements AS M ON B.Material = M.Material AND Movement = 'BKF' WHERE Partnumber = W.Partnumber AND M.[Date] > W.[Date]),0) AS Usage FROM (SELECT * FROM (SELECT [Partnumber],[Date],[Quantity],[UoM],[Username],ROW_NUMBER() OVER(PARTITION BY Partnumber ORDER BY [Date] DESC) AS Row FROM Ord_WIPStock) AS R1 WHERE R1.Row = 1 AND R1.Quantity > 0) AS W INNER JOIN Sys_RawMaterial AS R ON W.Partnumber = R.Partnumber"), "WIP")
        thread_D_finished = True
    End Sub

    Public Sub New(production_plan As ProductionPlan, horizon As Date)
        Me.LoadDate = Delta.CurrentDate
        'CARGAR EL DICCIONARIO DE COMPONENTES
        Me.Horizon = horizon.Date
        thread_A_finished = False
        thread_B_finished = False
        thread_C_finished = False
        thread_D_finished = False
        thread_A = New Threading.Thread(AddressOf GetOrders)
        thread_B = New Threading.Thread(AddressOf GetTransits)
        thread_C = New Threading.Thread(AddressOf GetRaw)
        thread_D = New Threading.Thread(AddressOf GetStock)
        thread_A.Start()
        thread_B.Start()
        thread_C.Start()
        thread_D.Start()
        While Not thread_A_finished OrElse Not thread_B_finished OrElse Not thread_C_finished

        End While

        ComponentPlan.RefreshCoverageProfiles()
        ComponentPlan.RefreshPlanningCalendars()
        ComponentPlan.RefreshSuppliers()
        ComponentPlan.RefreshMRPs()
        ComponentPlan.RefreshBusinessScheduledChanges()
        ComponentPlan.RefreshMaterialScheduledChanges()
        ComponentPlan.RefreshFlags()

        For Each row As DataRow In raw_material.Rows
            Me.Items.Add(row.Item("Partnumber"), New ComponentPlanItem(New RawMaterial(row.Item("Partnumber"), Delta.NullReplace(row.Item("Description"), ""), row.Item("UoM"), row.Item("RoundingValue"), row.Item("UnitCost"), row.Item("MRP"), Delta.NullReplace(row.Item("SupplierPartnumber"), ""), Delta.NullReplace(row.Item("SupplierNumber"), ""), Delta.NullReplace(row.Item("SupplierName"), ""), Delta.NullReplace(row.Item("Container"), ""), row.Item("MaterialType"), row.Item("ConsumptionType"), Delta.NullReplace(row.Item("LabelLegend"), ""), row.Item("Expirable"), Delta.NullReplace(row.Item("GRT"), 0), Delta.NullReplace(row.Item("PTF"), 0), Delta.NullReplace(row.Item("PC"), ""), Delta.NullReplace(row.Item("MOQ"), 1), Delta.NullReplace(row.Item("CP"), ""), row.Item("Fixed"), row.Item("MRP2"), Delta.NullReplace(row.Item("Document"), ""), Delta.NullReplace(row.Item("DocumentItem"), ""), row.Item("OrderUnit"), row.Item("WeightOnGr"), row.Item("IsSensitive"), NullReplace(row.Item("OrderingComment"), ""), row.Item("BOMIssueFactor"), row.Item("MfgConsumptionControl"), row.Item("MasterLabel"), row.Item("ChildLabelQuantity"), row.Item("UnitWeightValidated")), Me.Horizon, NullReplace(row.Item("SmkLocation"), "")))
            With Me.Items.Item(row.Item("Partnumber"))
                For Each trans_row In transits_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(trans_row.Item("AvailabilityDate")) Then .Items.Add(trans_row.Item("AvailabilityDate"), New ComponentPlanItemDate(trans_row.Item("AvailabilityDate")))
                    .Items.Item(trans_row.Item("AvailabilityDate")).Transits.Add(trans_row.Item("ID"), New Transit(trans_row.Item("ID"), trans_row.Item("DeliveryDate"), trans_row.Item("AvailabilityDate"), trans_row.Item("DeliveryNumber"), trans_row.Item("PO"), trans_row.Item("UoM"), trans_row.Item("Quantity"), trans_row.Item("QuantityBuM"), Delta.NullReplace(trans_row.Item("PRONumber"), ""), Delta.NullReplace(trans_row.Item("ExternalDocument"), ""), trans_row.Item("Edited")))
                Next
                For Each openord_row In open_orders_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    'LAS ORDENES SE AGREGAN CON LA FECHA DE LLEGADA, NO DE PICKUP
                    If Not .Items.ContainsKey(openord_row.Item("AvailabilityDate")) Then .Items.Add(openord_row.Item("AvailabilityDate"), New ComponentPlanItemDate(openord_row.Item("AvailabilityDate")))
                    If Not .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.ContainsKey(openord_row.Item("ID")) Then .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.Add(openord_row.Item("ID"), New OpenOrder(openord_row.Item("ID"), openord_row.Item("SupplierNumber"), openord_row.Item("SupplierName"), openord_row.Item("Quantity"), openord_row.Item("Status"), openord_row.Item("UoM"), openord_row.Item("ShipDate"), openord_row.Item("GRP"), openord_row.Item("AvailabilityDate"), openord_row.Item("Fix"), openord_row.Item("PurchaseDocument"), openord_row.Item("Item"), openord_row.Item("Kanban"), openord_row.Item("External"), openord_row.Item("QuantityBuM"), openord_row.Item("StatusBuM"), NullReplace(openord_row.Item("Comment"), ""), False))
                    If Not IsDBNull(openord_row.Item("CallOff")) Then .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.Item(openord_row.Item("ID")).CallOffs.Add(openord_row.Item("CallOff"), New CallOff(openord_row.Item("CallOff"), Delta.NullReplace(openord_row.Item("CallOffQuantity"), 0), Delta.NullReplace(openord_row.Item("Extra"), False)))
                Next
                For Each planord_row In planned_orders_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(planord_row.Item("AvailabilityDate")) Then .Items.Add(planord_row.Item("AvailabilityDate"), New ComponentPlanItemDate(planord_row.Item("AvailabilityDate")))
                    .Items.Item(planord_row.Item("AvailabilityDate")).PlannedOrders.Add(planord_row.Item("ID"), New PlannedOrder(planord_row.Item("ID"), planord_row.Item("PlannedOrder"), planord_row.Item("PlantIn"), planord_row.Item("Quantity"), planord_row.Item("UoM"), planord_row.Item("OpeningDate"), planord_row.Item("Agreement"), planord_row.Item("GRT"), planord_row.Item("AvailabilityDate"), planord_row.Item("QuantityBuM")))
                Next
                For Each promi_row In promises_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(promi_row.Item("AvailabilityDate")) Then .Items.Add(promi_row.Item("AvailabilityDate"), New ComponentPlanItemDate(promi_row.Item("AvailabilityDate")))
                    .Items.Item(promi_row.Item("AvailabilityDate")).Promises.Add(promi_row.Item("ID"), New Promise(promi_row.Item("ID"), promi_row.Item("Quantity"), promi_row.Item("UoM"), promi_row.Item("AvailabilityDate"), promi_row.Item("QuantityBuM"), promi_row.Item("Comment"), promi_row.Item("Fullname")))
                Next
            End With
        Next

        For Each row As DataRow In flags_dt.Rows
            Me.Items.Item(row.Item("Partnumber")).Flags.Add(row.Item("Flag"))
        Next

        open_orders_dt = Nothing
        planned_orders_dt = Nothing
        transits_dt = Nothing
        promises_dt = Nothing
        raw_material = Nothing
        flags_dt = Nothing

        RefreshProductionPlan(production_plan)
        While Not thread_D_finished

        End While
        RefreshStock()
    End Sub

    Public Sub New(production_plan As ProductionPlan, partnumber As String, horizon As Date)
        Me.LoadDate = Delta.CurrentDate
        Me.Horizon = horizon.Date
        _production_plan = production_plan

        ComponentPlan.RefreshCoverageProfiles()
        ComponentPlan.RefreshPlanningCalendars()
        ComponentPlan.RefreshSuppliers()
        ComponentPlan.RefreshMRPs()
        ComponentPlan.RefreshBusinessScheduledChanges()
        ComponentPlan.RefreshMaterialScheduledChanges()
        ComponentPlan.RefreshFlags()
        RefreshPartnumber(partnumber, Me.Horizon)
    End Sub
    Private Sub New()

    End Sub

    Public Sub RefreshPartnumber(partnumber As String, horizon As Date)
        'ACTUALIZAR EL PRODUCTION PLAN SOLO SI SU HORIZONTE ES MENOR AL QUE SE QUIERE VISUALIZAR DEL COMPONENTE O EL PLAN HA CAMBIADO
        'SE LE AGREGAN 30 DIAS MAS PARA QUE EL MIN MAX SEA CALCULADO LO MEJOR POSIBLE EN LOS ULTIMOS DIAS DEL HORIZONTE, ASI SE HACE TAMBIEN EN LA PRIMER CARGA
        Dim prodplan_updated As Boolean = False
        If horizon > Me.ProductionPlan.Horizon.AddDays(-30) OrElse _
            SQL.Current.GetDate("SELECT MAX([Date]) AS [Date] FROM (SELECT MAX([Date]) AS [Date] FROM Sch_DailyProductionPlanMovements UNION ALL SELECT MAX([Date]) AS [Date] FROM PR_ProductionPlanMovements) AS MD", Me.ProductionPlan.LastChangeDate) > Me.ProductionPlan.LastChangeDate Then
            Me.ProductionPlan.Update(horizon.AddDays(30))
            prodplan_updated = True
        End If

        'ORDENES CON SU CALLOFF
        Dim open_orders_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT O.*, C.CallOff, dbo.Sys_UnitConversion(O.Partnumber, C.UoM, C.Quantity, R.UoM) AS CallOffQuantity, C.Extra, dbo.Sys_UnitConversion(O.Partnumber, O.UoM, O.Quantity, R.UoM) AS QuantityBuM,dbo.Sys_UnitConversion(O.Partnumber, O.UoM, O.Status, R.UoM) AS StatusBuM,O.Comment FROM Ord_OpenOrders AS O INNER JOIN Sys_RawMaterial AS R ON O.Partnumber = R.Partnumber LEFT OUTER JOIN (SELECT Partnumber, CallOff, PickUpDate, Quantity, UoM, Extra, ASN FROM Ord_CallOffs WHERE Closed = 0) AS C ON C.Partnumber = O.Partnumber AND C.PickUpDate = O.ShipDate WHERE O.[Active] = 1 AND [AvailabilityDate] <= '{0}' AND O.Quantity >= 1 AND C.ASN IS NULL AND O.Partnumber = '{1}';", horizon.ToString("yyyy-MM-dd"), partnumber), "OpenOrders")
        'PLANNED ORDERS
        Dim planned_orders_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT P.*,dbo.Sys_UnitConversion(P.Partnumber, P.UoM, P.Quantity, R.UoM) AS QuantityBuM FROM Ord_PlannedOrders AS P INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber WHERE P.Partnumber = '{2}' AND Agreement <> '' AND [AvailabilityDate] BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), horizon.ToString("yyyy-MM-dd"), partnumber), "PlannedOrders")
        'TRANSITOS
        Dim transits_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT T.Partnumber,T.DeliveryDate,T.DeliveryNumber,T.PO,T.Items,T.UoM,T.Quantity,CONVERT(BIT, CASE WHEN T.RealDate IS NULL THEN 1 ELSE 0 END) AS Edited,ISNULL(T.RealDate,T.AvailabilityDate) AS AvailabilityDate,T.ExternalDocument,T.PRONumber,T.ID,dbo.Sys_UnitConversion(T.Partnumber, T.UoM, T.Quantity, R.UoM) AS QuantityBuM FROM Ord_Transits AS T INNER JOIN Sys_RawMaterial AS R ON T.Partnumber = R.Partnumber WHERE T.Partnumber = '{2}' AND T.Active = 1 AND ISNULL(T.RealDate,T.AvailabilityDate) BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), horizon.ToString("yyyy-MM-dd"), partnumber), "Transits")

        Dim promises_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT P.*,U.Fullname,dbo.Sys_UnitConversion(P.Partnumber, P.UoM, P.Quantity, R.UoM) AS QuantityBuM FROM Ord_ManualPromises AS P INNER JOIN Sys_Users AS U ON P.Username = U.Username INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber WHERE P.[Active] = 1 AND P.Partnumber = '{2}' AND P.[AvailabilityDate] BETWEEN '{0}' AND '{1}';", Delta.CurrentDate.ToString("yyyy-MM-dd"), horizon.ToString("yyyy-MM-dd"), partnumber), "Promises")

        Dim raw_material As DataTable = SQL.Current.GetDatatable(String.Format("SELECT *,dbo.Smk_Locations(Partnumber) AS SmkLocation FROM Sys_RawMaterial WHERE Partnumber = '{0}';", partnumber))
        Dim flags_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT F.Partnumber,F.Flag FROM Sys_PartnumberFlags AS F INNER JOIN Sys_PartnumberFlagsDescription AS D ON F.Flag = D.Flag WHERE D.Area IN ('ORD','CR') AND F.Partnumber = '{0}'", partnumber))

        For Each row As DataRow In raw_material.Rows 'SOLO SERA 1 ROW
            Me.Items.Remove(row.Item("Partnumber"))
            Me.Items.Add(row.Item("Partnumber"), New ComponentPlanItem(New RawMaterial(row.Item("Partnumber"), Delta.NullReplace(row.Item("Description"), ""), row.Item("UoM"), row.Item("RoundingValue"), row.Item("UnitCost"), row.Item("MRP"), Delta.NullReplace(row.Item("SupplierPartnumber"), ""), Delta.NullReplace(row.Item("SupplierNumber"), ""), Delta.NullReplace(row.Item("SupplierName"), ""), Delta.NullReplace(row.Item("Container"), ""), row.Item("MaterialType"), row.Item("ConsumptionType"), Delta.NullReplace(row.Item("LabelLegend"), ""), row.Item("Expirable"), Delta.NullReplace(row.Item("GRT"), 0), Delta.NullReplace(row.Item("PTF"), 0), Delta.NullReplace(row.Item("PC"), ""), Delta.NullReplace(row.Item("MOQ"), 1), Delta.NullReplace(row.Item("CP"), ""), row.Item("Fixed"), row.Item("MRP2"), Delta.NullReplace(row.Item("Document"), ""), Delta.NullReplace(row.Item("DocumentItem"), ""), row.Item("OrderUnit"), row.Item("WeightOnGr"), row.Item("IsSensitive"), NullReplace(row.Item("OrderingComment"), ""), row.Item("BOMIssueFactor"), row.Item("MfgConsumptionControl"), row.Item("MasterLabel"), row.Item("ChildLabelQuantity"), row.Item("UnitWeightValidated")), horizon, NullReplace(row.Item("SmkLocation"), "")))
            With Me.Items.Item(row.Item("Partnumber"))
                For Each trans_row In transits_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(trans_row.Item("AvailabilityDate")) Then .Items.Add(trans_row.Item("AvailabilityDate"), New ComponentPlanItemDate(trans_row.Item("AvailabilityDate")))
                    .Items.Item(trans_row.Item("AvailabilityDate")).Transits.Add(trans_row.Item("ID"), New Transit(trans_row.Item("ID"), trans_row.Item("DeliveryDate"), trans_row.Item("AvailabilityDate"), trans_row.Item("DeliveryNumber"), trans_row.Item("PO"), trans_row.Item("UoM"), trans_row.Item("Quantity"), trans_row.Item("QuantityBuM"), Delta.NullReplace(trans_row.Item("PRONumber"), ""), Delta.NullReplace(trans_row.Item("ExternalDocument"), ""), trans_row.Item("Edited")))
                Next
                For Each openord_row In open_orders_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(openord_row.Item("AvailabilityDate")) Then .Items.Add(openord_row.Item("AvailabilityDate"), New ComponentPlanItemDate(openord_row.Item("AvailabilityDate")))
                    If Not .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.ContainsKey(openord_row.Item("ID")) Then .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.Add(openord_row.Item("ID"), New OpenOrder(openord_row.Item("ID"), openord_row.Item("SupplierNumber"), openord_row.Item("SupplierName"), openord_row.Item("Quantity"), openord_row.Item("Status"), openord_row.Item("UoM"), openord_row.Item("ShipDate"), openord_row.Item("GRP"), openord_row.Item("AvailabilityDate"), openord_row.Item("Fix"), openord_row.Item("PurchaseDocument"), openord_row.Item("Item"), openord_row.Item("Kanban"), openord_row.Item("External"), openord_row.Item("QuantityBuM"), openord_row.Item("StatusBuM"), NullReplace(openord_row.Item("Comment"), ""), False))
                    If Not IsDBNull(openord_row.Item("CallOff")) Then .Items.Item(openord_row.Item("AvailabilityDate")).OpenOrders.Item(openord_row.Item("ID")).CallOffs.Add(openord_row.Item("CallOff"), New CallOff(openord_row.Item("CallOff"), Delta.NullReplace(openord_row.Item("CallOffQuantity"), 0), Delta.NullReplace(openord_row.Item("Extra"), False)))
                Next
                For Each planord_row In planned_orders_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(planord_row.Item("AvailabilityDate")) Then .Items.Add(planord_row.Item("AvailabilityDate"), New ComponentPlanItemDate(planord_row.Item("AvailabilityDate")))
                    .Items.Item(planord_row.Item("AvailabilityDate")).PlannedOrders.Add(planord_row.Item("ID"), New PlannedOrder(planord_row.Item("ID"), planord_row.Item("PlannedOrder"), planord_row.Item("PlantIn"), planord_row.Item("Quantity"), planord_row.Item("UoM"), planord_row.Item("OpeningDate"), planord_row.Item("Agreement"), planord_row.Item("GRT"), planord_row.Item("AvailabilityDate"), planord_row.Item("QuantityBuM")))
                Next

                For Each promi_row In promises_dt.Select(String.Format("Partnumber = '{0}'", .Partnumber.Partnumber))
                    If Not .Items.ContainsKey(promi_row.Item("AvailabilityDate")) Then .Items.Add(promi_row.Item("AvailabilityDate"), New ComponentPlanItemDate(promi_row.Item("AvailabilityDate")))
                    .Items.Item(promi_row.Item("AvailabilityDate")).Promises.Add(promi_row.Item("ID"), New Promise(promi_row.Item("ID"), promi_row.Item("Quantity"), promi_row.Item("UoM"), promi_row.Item("AvailabilityDate"), promi_row.Item("QuantityBuM"), promi_row.Item("Comment"), promi_row.Item("Fullname")))
                Next
                .DeltaRandomStock = SQL.Current.GetScalar(String.Format("SELECT SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('N','P','Q','S','T') AND RedTag = 0 GROUP BY Partnumber;", .Partnumber.Partnumber))
                .DeltaServiceStock = SQL.Current.GetScalar(String.Format("SELECT SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('C','O','U') AND RedTag = 0 AND Sloc <> '0002' GROUP BY Partnumber;", .Partnumber.Partnumber))
                .QualityStock = SQL.Current.GetScalar(String.Format("SELECT SUM(CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] NOT IN ('E','D') AND RedTag = 1 GROUP BY Partnumber;", .Partnumber.Partnumber))
            End With
        Next

        'BUSCAR ARNESES QUE USAN ACTUALMENTE EL COMPONENTE O LOS QUE LO VAN A USAR
        Dim selected_harns = From d In Me.ProductionPlan.Items
                Where d.Value.Harn.BOM.Items.ContainsKey(partnumber) OrElse BusinessScheduledChanges.Where(Function(w) w.Value.Items.Where(Function(x) x.Value.NewPartnumber = partnumber).Any()).Any()

        If Not prodplan_updated Then
            Dim material_toupdate As New List(Of String)
            For Each i In selected_harns
                material_toupdate.Add(i.Key)
            Next
            Me.ProductionPlan.Update(material_toupdate)
        End If

        For Each row As DataRow In flags_dt.Rows
            Me.Items.Item(row.Item("Partnumber")).Flags.Add(row.Item("Flag"))
        Next

        RefreshProductionPlan(partnumber)

        'SE ACTUALIZA EL WIP HASTA EL FINAL PARA PODER TENER LA INFO DE LOS REQUERIMIENTO PREVIAMENTE
        With Me.Items.Item(partnumber)
            SQL.Current.Execute(String.Format("MERGE Ord_CurrentWIP AS target USING (SELECT * FROM vw_Ord_CurrentWIP WHERE Partnumber = '{0}') AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Date] = source.[Date], Quantity = source.Quantity, Usage = source.Usage WHEN NOT MATCHED THEN INSERT (Partnumber,[Date],Quantity,Usage) VALUES (source.Partnumber,source.[Date],source.[Quantity],source.Usage);", partnumber))
            .WIPStockDate = SQL.Current.GetDate(String.Format("SELECT [Date] FROM Ord_CurrentWIP WHERE Partnumber = '{0}';", .Partnumber.Partnumber), Date.MinValue)
            .WIPStock = Math.Max(SQL.Current.GetScalar(String.Format("SELECT Quantity - (Usage*{1}) FROM Ord_CurrentWIP WHERE Partnumber = '{0}';", partnumber, .Partnumber.BOMIssueFactor), ), 0)
        End With
        Me.Items.Item(partnumber).IsActive = True
    End Sub

    Public Function GetScheduledChange(business As String, material As String, partnumber As String, [date] As Date) As String
        If ComponentPlan.MaterialScheduledChanges.ContainsKey(material) AndAlso ComponentPlan.MaterialScheduledChanges.Item(material).Items.ContainsKey(partnumber) AndAlso [date] >= ComponentPlan.MaterialScheduledChanges.Item(material).Items.Item(partnumber).EffectiveDate Then
            Return ComponentPlan.MaterialScheduledChanges.Item(material).Items.Item(partnumber).NewPartnumber
        ElseIf ComponentPlan.BusinessScheduledChanges.ContainsKey(business.ToLower) AndAlso ComponentPlan.BusinessScheduledChanges.Item(business.ToLower).Items.ContainsKey(partnumber) AndAlso [date] >= ComponentPlan.BusinessScheduledChanges.Item(business.ToLower).Items.Item(partnumber).EffectiveDate Then
            Return ComponentPlan.BusinessScheduledChanges.Item(business.ToLower).Items.Item(partnumber).NewPartnumber
        Else
            Return partnumber
        End If
    End Function

    Public Function IsScheduledChange(business As String, material As String, partnumber As String) As Boolean
        If ComponentPlan.MaterialScheduledChanges.ContainsKey(material) AndAlso (ComponentPlan.MaterialScheduledChanges.Item(material).Items.ContainsKey(partnumber) OrElse ComponentPlan.MaterialScheduledChanges.Item(material).Items.Where(Function(w) w.Value.NewPartnumber = partnumber).Any) Then
            Return True
        ElseIf ComponentPlan.BusinessScheduledChanges.ContainsKey(business.ToLower) AndAlso (ComponentPlan.BusinessScheduledChanges.Item(business.ToLower).Items.ContainsKey(partnumber) OrElse ComponentPlan.BusinessScheduledChanges.Item(business.ToLower).Items.Where(Function(w) w.Value.NewPartnumber = partnumber).Any) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public ReadOnly Property ProductionPlan As ProductionPlan
        Get
            Return _production_plan
        End Get
    End Property

    'Public Function RequirementsToPivotDatatable(partnumber As String, horizon As Date) As DataTable
    '    Dim dt As New DataTable("Requerimientos")
    '    dt.Columns.Add("Material")
    '    dt.Columns.Add("Negocio")
    '    dt.Columns.Add("Fecha", GetType(Date))
    '    dt.Columns.Add("Cantidad", GetType(Decimal))

    '    Dim query = From i In Me.ProductionPlan.Items
    '                Where i.Value.Harn.BOM.Items.ContainsKey(partnumber)

    '    For Each item In query
    '        For Each day In item.Value.Items
    '            If day.Key <= horizon.Date AndAlso GetScheduledChange(item.Value.Harn.Business, item.Value.Harn.Material, partnumber, day.Key) = partnumber Then 'COMPROBAR QUE NO HAYA CAMBIO DE ING DONDE SE DEJE DE USAR EL COMPONENTE
    '                Dim accum As Decimal = item.Value.Accumulated(day.Key)
    '                If accum > 0 Then
    '                    dt.Rows.Add(item.Value.Harn.Material, item.Value.Harn.Business, day.Key, accum * item.Value.Harn.BOM.Items.Item(partnumber).Usage)
    '                    If Me.Items.Item(partnumber).Partnumber.BOMIssueFactor <> 1 Then dt.Rows.Add("BOM Issue", "", day.Key, accum * item.Value.Harn.BOM.Items.Item(partnumber).Usage * (Me.Items.Item(partnumber).Partnumber.BOMIssueFactor - 1))
    '                End If
    '            End If
    '        Next
    '    Next

    '    'For Each item In ComponentPlan.BusinessScheduledChanges
    '    '    For Each business In item.Value.Items.Where(Function(w) w.Value.NewPartnumber = partnumber)
    '    '        For Each pp In Me.ProductionPlan.Items.Where(Function(w) w.Value.Harn.Business = business.Key AndAlso w.Value.Harn.BOM.Items.ContainsKey(business.Value.OldPartnumber))
    '    '            For Each day In pp.Value.Items.Where(Function(w) w.Key >= business.Value.EffectiveDate)
    '    '                Dim accum As Decimal = pp.Value.Accumulated(day.Key)
    '    '                If accum > 0 Then
    '    '                    dt.Rows.Add(pp.Value.Harn.Material, business.Key, day.Key, accum * pp.Value.Harn.BOM.Items.Item(business.Value.OldPartnumber).Usage)
    '    '                    If Me.Items.Item(business.Value.OldPartnumber).Partnumber.BOMIssueFactor <> 1 Then dt.Rows.Add("BOM Issue", "", day.Key, accum * pp.Value.Harn.BOM.Items.Item(business.Value.OldPartnumber).Usage * (Me.Items.Item(business.Value.OldPartnumber).Partnumber.BOMIssueFactor - 1))
    '    '                End If
    '    '            Next
    '    '        Next
    '    '    Next
    '    'Next

    '        dt.DefaultView.Sort = "[Fecha] ASC"

    '        Dim pivoter As New PivotTable(dt.DefaultView.ToTable)
    '        Dim pivot As DataTable = pivoter.PivotDates("Material", "Negocio", "Cantidad", AggregateFunction.First, "Fecha", "System.Decimal")
    '        'Dim p As DataTable = DatatablePivoter.Get(dt, {"Material", "Negocio"}, {"Fecha"}, {"Cantidad"}, {AggregateFunction.Sum}, , True)
    '        'p.TableName = "Requerimientos"
    '        pivot.TableName = "Requerimientos"
    '        Return pivot
    'End Function
    Public Sub RefreshProductionPlan(production_plan As ProductionPlan)
        _production_plan = production_plan
        'For Each item In Me.Items ESTO NO SE NECESITA PORQUE LA PROPIEDAD Requirement SIEMPRE SE INICIALIZA EN 0
        '    For Each [date] In item.Value.Items
        '        [date].Value.Requirement = 0
        '    Next
        'Next

        Dim real_partnumber As String
        For Each harn In production_plan.Items
            'AGREGAR UN ProductionPlanItemDate DEL DIA ACTUAL EN CERO, SINO EXISTIERA, A TODOS LOS PLANES DE PRODUCCION PARA QUE LOS PLANES QUE NO SE HAYAN CUMPLIDO HASTA LA FECHA SE PUEDAN RECORRER EN LA FUNCION Accumulated
            If Not harn.Value.Items.ContainsKey(Delta.CurrentDate.Date) Then harn.Value.Items.Add(Delta.CurrentDate.Date, New ProductionPlanItemDate(Delta.CurrentDate.Date, 0, 0))
            For Each pp_item_date In harn.Value.Items
                Dim accum As Integer = harn.Value.Accumulated(pp_item_date.Key)
                If accum > 0 Then 'SI EL ACUMULADO ES CERO NO TIENE SENTIDO ENTRAR A SU BOM
                    For Each bom_part In harn.Value.Harn.BOM.Items
                        real_partnumber = GetScheduledChange(harn.Value.Harn.Business.Name, harn.Value.Harn.Material, bom_part.Value.Partnumber, pp_item_date.Key) 'OBTENER EL COMPONENTE REAL, PUEDE SER EL MISMO O UNO NUEVO SI HAY CAMBIO DE INGENIERIA
                        If Not Me.Items.Item(real_partnumber).Items.ContainsKey(pp_item_date.Key) Then Me.Items.Item(real_partnumber).Items.Add(pp_item_date.Key, New ComponentPlanItemDate(pp_item_date.Key))
                        Me.Items.Item(real_partnumber).Items.Item(pp_item_date.Key).Requirement += accum * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage * Me.Items.Item(real_partnumber).Partnumber.BOMIssueFactor
                    Next
                End If
            Next

            If harn.Value.PastDue > 0 Then 'SI NO TIENEN PASTDUE NO TIENE SENTIDO ENTRAR A SU BOM
                For Each bom_part In harn.Value.Harn.BOM.Items
                    real_partnumber = GetScheduledChange(harn.Value.Harn.Business.Name, harn.Value.Harn.Material, bom_part.Value.Partnumber, CurrentDate.Date) 'VALIDAR SI EL COMPONENTE SE ESTA ACTUALMENTE USANDO O YA HAY UN CAMBIO PROGRAMADO
                    If Not Me.Items.Item(real_partnumber).Items.ContainsKey(CurrentDate.Date) Then Me.Items.Item(real_partnumber).Items.Add(CurrentDate.Date, New ComponentPlanItemDate(CurrentDate.Date))
                    Me.Items.Item(real_partnumber).PastDue += harn.Value.PastDue * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage * Me.Items.Item(real_partnumber).Partnumber.BOMIssueFactor
                Next
            End If
        Next
    End Sub

    Public Sub RefreshProductionPlan(partnumber As String)

        Dim requirements_dt As New DataTable("Requerimientos")
        requirements_dt.Columns.Add("Material")
        requirements_dt.Columns.Add("Negocio")
        requirements_dt.Columns.Add("Fecha", GetType(Date))
        requirements_dt.Columns.Add("Cantidad", GetType(Decimal))

        Me.Items.Item(partnumber).PastDue = 0
        For Each [date] In Me.Items.Item(partnumber).Items
            [date].Value.Requirement = 0
        Next

        For Each harn In Me.ProductionPlan.Items
            If harn.Value.Harn.BOM.Items.ContainsKey(partnumber) OrElse IsScheduledChange(harn.Value.Harn.Business.Name, harn.Value.Harn.Material, partnumber) Then
                'AGREGAR UN ProductionPlanItemDate DEL DIA ACTUAL EN CERO, SINO EXISTIERA, A TODOS LOS PLANES DE PRODUCCION PARA QUE LOS PLANES QUE NO SE HAYAN CUMPLIDO HASTA LA FECHA SE PUEDAN RECORRER EN LA FUNCION Accumulated
                If Not harn.Value.Items.ContainsKey(Delta.CurrentDate.Date) Then harn.Value.Items.Add(Delta.CurrentDate.Date, New ProductionPlanItemDate(Delta.CurrentDate.Date, 0, 0))
                For Each pp_item_date In harn.Value.Items
                    For Each bom_part In harn.Value.Harn.BOM.Items
                        If partnumber = GetScheduledChange(harn.Value.Harn.Business.Name, harn.Value.Harn.Material, bom_part.Value.Partnumber, pp_item_date.Key) Then 'OBTENER EL COMPONENTE REAL, PUEDE SER EL MISMO O UNO NUEVO SI HAY CAMBIO DE INGENIERIA
                            Dim accum As Integer = harn.Value.Accumulated(pp_item_date.Key)
                            If Not Me.Items.Item(partnumber).Items.ContainsKey(pp_item_date.Key) Then Me.Items.Item(partnumber).Items.Add(pp_item_date.Key, New ComponentPlanItemDate(pp_item_date.Key))
                            Me.Items.Item(partnumber).Items.Item(pp_item_date.Key).Requirement += accum * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage * Me.Items.Item(partnumber).Partnumber.BOMIssueFactor
                            requirements_dt.Rows.Add(harn.Value.Harn.Material, harn.Value.Harn.Business.Name, pp_item_date.Key, accum * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage * Me.Items.Item(partnumber).Partnumber.BOMIssueFactor)
                        End If
                    Next
                Next

                If harn.Value.PastDue > 0 Then 'SI NO TIENEN PASTDUE NO TIENE SENTIDO ENTRAR A SU BOM
                    For Each bom_part In harn.Value.Harn.BOM.Items
                        If partnumber = GetScheduledChange(harn.Value.Harn.Business.Name, harn.Value.Harn.Material, bom_part.Value.Partnumber, CurrentDate.Date) Then 'VALIDAR SI EL COMPONENTE SE ESTA ACTUALMENTE USANDO O YA HAY UN CAMBIO PROGRAMADO
                            If Not Me.Items.Item(partnumber).Items.ContainsKey(CurrentDate.Date) Then Me.Items.Item(partnumber).Items.Add(CurrentDate.Date, New ComponentPlanItemDate(CurrentDate.Date))
                            Me.Items.Item(partnumber).PastDue += harn.Value.PastDue * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage * Me.Items.Item(partnumber).Partnumber.BOMIssueFactor
                        End If
                    Next
                End If
            End If


            'For Each bom_part In harn.Value.Harn.BOM.Items
            '    For Each pp_item_date In harn.Value.Items
            '        If partnumber = GetScheduledChange(harn.Value.Harn.Business, bom_part.Value.Partnumber, pp_item_date.Key) Then 'OBTENER EL COMPONENTE REAL, PUEDE SER EL MISMO O UNO NUEVO SI HAY CAMBIO DE INGENIERIA
            '            If Not Me.Items.Item(partnumber).Items.ContainsKey(pp_item_date.Key) Then Me.Items.Item(partnumber).Items.Add(pp_item_date.Key, New ComponentPlanItemDate(pp_item_date.Key))
            '            Me.Items.Item(partnumber).Items.Item(pp_item_date.Key).Requirement += harn.Value.Accumulated(pp_item_date.Key) * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage
            '        End If
            '    Next
            '    If partnumber = GetScheduledChange(harn.Value.Harn.Business, bom_part.Value.Partnumber, CurrentDate.Date) Then 'VALIDAR SI EL COMPONENTE SE ESTA ACTUALMENTE USANDO O YA HAY UN CAMBIO PROGRAMADO
            '        If Not Me.Items.Item(partnumber).Items.ContainsKey(CurrentDate.Date) Then Me.Items.Item(partnumber).Items.Add(CurrentDate.Date, New ComponentPlanItemDate(CurrentDate.Date))
            '        Me.Items.Item(partnumber).PastDue += harn.Value.PastDue * harn.Value.Harn.BOM.Items.Item(bom_part.Value.Partnumber).Usage
            '    End If
            'Next
        Next

        requirements_dt.DefaultView.Sort = "[Fecha] ASC"
        Dim pivoter As New PivotTable(requirements_dt.DefaultView.ToTable)
        Dim pivot As DataTable = pivoter.PivotDates("Material", "Negocio", "Cantidad", AggregateFunction.First, "Fecha", "System.Decimal")
        pivot.TableName = "Requerimientos"
        Me.Items(partnumber).Requirements = pivot
    End Sub

    Public Sub RefreshStock()
        For Each row As DataRow In current_random_stock_dt.Rows
            If Me.Items.ContainsKey(row.Item("Partnumber")) Then Me.Items.Item(row.Item("Partnumber")).DeltaRandomStock = row.Item("Quantity")
        Next

        For Each row As DataRow In current_service_stock_dt.Rows
            If Me.Items.ContainsKey(row.Item("Partnumber")) Then Me.Items.Item(row.Item("Partnumber")).DeltaServiceStock = row.Item("Quantity")
        Next

        For Each row As DataRow In current_quality_stock_dt.Rows
            If Me.Items.ContainsKey(row.Item("Partnumber")) Then Me.Items.Item(row.Item("Partnumber")).QualityStock = row.Item("Quantity")
        Next

        For Each row As DataRow In current_wip_stock_dt.Rows
            If Me.Items.ContainsKey(row.Item("Partnumber")) Then
                With Me.Items.Item(row.Item("Partnumber"))
                    .WIPStock = Math.Max(row.Item("Quantity") - (row.Item("Usage") * .Partnumber.BOMIssueFactor), 0)
                    .WIPStockDate = row.Item("Date")
                End With
            End If
        Next
    End Sub
    Public Property Horizon As Date
    Public Function Clone() As ComponentPlan
        Dim cc_clone As New ComponentPlan()
        cc_clone._production_plan = Me.ProductionPlan.Clone()
        cc_clone.Horizon = Me.Horizon
        For Each i In Me.Items
            cc_clone.Items.Add(i.Key, i.Value.Clone())
        Next
        Return cc_clone
    End Function

    Public Shared Sub RefreshBusinessScheduledChanges()
        Dim scheduled_chages_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Business,OldPartnumber,NewPartnumber,EffectiveDate FROM CR_BusinessScheduledChanges WHERE [Active] = 1"))
        ComponentPlan.BusinessScheduledChanges.Clear()
        For Each row As DataRow In scheduled_chages_dt.Rows
            If Not BusinessScheduledChanges.ContainsKey(row.Item("Business").ToString.ToLower) Then BusinessScheduledChanges.Add(row.Item("Business").ToString.ToLower, New ScheduledChange(row.Item("Business").ToString.ToLower))
            BusinessScheduledChanges.Item(row.Item("Business").ToString.ToLower).Items.Add(row.Item("OldPartnumber"), New ScheduledPartnumberChange(row.Item("OldPartnumber"), row.Item("NewPartnumber"), row.Item("EffectiveDate")))
        Next
    End Sub

    Public Shared Sub RefreshMaterialScheduledChanges()
        Dim scheduled_chages_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Material,OldPartnumber,NewPartnumber,EffectiveDate FROM CR_MaterialScheduledChanges WHERE [Active] = 1"))
        ComponentPlan.MaterialScheduledChanges.Clear()
        For Each row As DataRow In scheduled_chages_dt.Rows
            If Not MaterialScheduledChanges.ContainsKey(row.Item("Material")) Then MaterialScheduledChanges.Add(row.Item("Material"), New ScheduledChange(row.Item("Material")))
            MaterialScheduledChanges.Item(row.Item("Material")).Items.Add(row.Item("OldPartnumber"), New ScheduledPartnumberChange(row.Item("OldPartnumber"), row.Item("NewPartnumber"), row.Item("EffectiveDate")))
        Next
    End Sub

    Public Shared Sub RefreshCoverageProfiles()
        Dim coverage_profiles_dt As DataTable = SQL.Current.GetDatatable("SELECT ID, CoverageDays, HorizonWeeks FROM Ord_CoverageProfile")
        ComponentPlan.CoverageProfiles.Clear()
        For Each row As DataRow In coverage_profiles_dt.Rows
            ComponentPlan.CoverageProfiles.Add(row.Item("ID").ToString.ToUpper, New CoverageProfile(row.Item("ID").ToString.ToUpper, row.Item("CoverageDays"), row.Item("HorizonWeeks")))
        Next
    End Sub
    Public Shared Sub RefreshPlanningCalendars()
        Dim planning_calendar_dt As DataTable = SQL.Current.GetDatatable("SELECT * FROM Ord_PlanningCalendar")
        ComponentPlan.PlanningCalendars.Clear()
        For Each row As DataRow In planning_calendar_dt.Rows
            ComponentPlan.PlanningCalendars.Add(row.Item("ID").ToString.ToUpper, New PlanningCalendar(row.Item("ID").ToString.ToUpper, row.Item("Sunday_1"), row.Item("Monday_1"), row.Item("Tuesday_1"), row.Item("Wednesday_1"), row.Item("Thursday_1"), row.Item("Friday_1"), row.Item("Saturday_1"), row.Item("Sunday_2"), row.Item("Monday_2"), row.Item("Tuesday_2"), row.Item("Wednesday_2"), row.Item("Thursday_2"), row.Item("Friday_2"), row.Item("Saturday_2"), row.Item("Sunday_3"), row.Item("Monday_3"), row.Item("Tuesday_3"), row.Item("Wednesday_3"), row.Item("Thursday_3"), row.Item("Friday_3"), row.Item("Saturday_3"), row.Item("Sunday_4"), row.Item("Monday_4"), row.Item("Tuesday_4"), row.Item("Wednesday_4"), row.Item("Thursday_4"), row.Item("Friday_4"), row.Item("Saturday_4"), row.Item("Sunday_5"), row.Item("Monday_5"), row.Item("Tuesday_5"), row.Item("Wednesday_5"), row.Item("Thursday_5"), row.Item("Friday_5"), row.Item("Saturday_5")))
        Next
    End Sub
    Public Shared Sub RefreshSuppliers()
        Dim suppliers_dt As DataTable = SQL.Current.GetDatatable("SELECT * FROM Ord_Suppliers")
        ComponentPlan.Suppliers.Clear()
        For Each row As DataRow In suppliers_dt.Rows
            ComponentPlan.Suppliers.Add(row.Item("Supplier"), New Supplier(row.Item("Supplier"), row.Item("Name"), row.Item("TrucksPerWeek"), row.Item("TransitTime"), row.Item("PremiumTransit"), row.Item("DeliveriesPerWeek"), row.Item("ResponseTime"), row.Item("Ratio"), row.Item("CoverageProfile"), row.Item("Lean"), row.Item("InHouse")))
        Next
    End Sub
    Public Shared Sub RefreshMRPs()
        Dim mrp_dt As DataTable = SQL.Current.GetDatatable("SELECT UPPER(MRP) AS MRP,UPPER(U.Username) AS Username,FullName FROM Ord_MRPControllers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE ProcurementType= 'R' ORDER BY FullName,MRP;")
        ComponentPlan.MRPOwners.Clear()
        For Each row As DataRow In mrp_dt.Rows
            ComponentPlan.MRPOwners.Add(row.Item("MRP"), row.Item("FullName"))
        Next
    End Sub
    Public Shared Sub RefreshFlags()
        Dim flags As DataTable = SQL.Current.GetDatatable("SELECT [Flag],[Description],[Area],[HexaColor] FROM Sys_PartnumberFlagsDescription WHERE Area IN ('ORD','CR')")
        ComponentPlan.Flags.Clear()
        For Each row As DataRow In flags.Rows
            ComponentPlan.Flags.Add(row.Item("Flag"), New Flag(row.Item("Flag"), row.Item("Description"), ColorTranslator.FromHtml("#" & row.Item("HexaColor"))))
        Next
    End Sub
End Class

Public Enum ComponentPlanItemStatus
    Normal
    Minimum
    Excess
    Critical
    Obsolete
    Inactive
End Enum

Public Class ComponentPlanItem
    Dim wsd_calculated As Boolean = False
    Dim _wsd As Decimal = 0
    Dim _endofptf As Date
    Private Sub New()

    End Sub
    Public Sub New(partnumber As RawMaterial, horizon As Date, smk_location As String)
        Me.Partnumber = partnumber
        Me.Horizon = horizon
        _endofptf = WorkDay(Delta.CurrentDate, Me.Partnumber.PlanningTimeFence).Date 'SEGUN RUVALCABA EL PERIODO CONGELADO ES EL PTF-GR
        Me.SmkLocation = smk_location
    End Sub
    Public Property IsActive As Boolean = False
    Public Property SmkLocation As String
    Public Property Horizon As Date
    Public Property UpdateTime As Date = Delta.CurrentDate
    Public ReadOnly Property EndOfPTF As Date
        Get
            Return _endofptf
        End Get
    End Property
    Public Property Partnumber As RawMaterial
    Public Property PastDue As Decimal = 0
    Public Property DeltaRandomStock As Decimal = 0
    Public Property DeltaServiceStock As Decimal = 0
    Public ReadOnly Property DeltaStock As Decimal
        Get
            Return Me.DeltaRandomStock + Me.DeltaServiceStock
        End Get
    End Property
    Public Property QualityStock As Decimal = 0
    Public Property WIPStock As Decimal = 0
    Public Property WIPStockDate As Date = Date.MinValue.Date
    Public Property Items As New Dictionary(Of Date, ComponentPlanItemDate)

    Public Function Status([date] As Date) As ComponentPlanItemStatus
        Dim stock = Me.StockBalance([date])
        Dim add = Me.AverageDailyDemand([date])

        If Not HasRequirement16Weeks([date]) Then
            Return ComponentPlanItemStatus.Obsolete
        ElseIf stock < 0 OrElse (stock = 0 AndAlso add > 0) Then
            Return ComponentPlanItemStatus.Critical
        ElseIf stock < Me.Minimum([date]) Then
            Return ComponentPlanItemStatus.Minimum
        ElseIf stock > Me.Maximum([date]) Then
            Return ComponentPlanItemStatus.Excess
        Else
            Return ComponentPlanItemStatus.Normal
        End If



        'If stock < 0 OrElse (stock = 0 AndAlso add > 0) Then
        '    Return ComponentPlanItemStatus.Critical
        'ElseIf stock < Me.Minimum([date]) Then
        '    Return ComponentPlanItemStatus.Minimum
        'ElseIf add > 0 AndAlso stock > Maximum([date]) Then
        '    Return ComponentPlanItemStatus.Excess
        'ElseIf add > 0 AndAlso stock >= Minimum([date]) AndAlso stock <= Maximum([date]) Then
        '    Return ComponentPlanItemStatus.Normal
        'ElseIf add = 0 AndAlso stock > 0 Then
        '    If HasRequirement16Weeks([date]) Then
        '        Return ComponentPlanItemStatus.Excess
        '    Else
        '        Return ComponentPlanItemStatus.Obsolete
        '    End If
        'Else
        '    Return ComponentPlanItemStatus.Normal
        'End If
    End Function

    Public Property Requirements() As DataTable

    Public Function TransitsToDatable() As DataTable
        Dim dt As New DataTable("Transitos")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("PO")
        dt.Columns.Add("Documento Ext.")
        dt.Columns.Add("PRO No.")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        dt.Columns.Add("Modificada", GetType(Boolean))
        Dim query = From i In Me.Items
                    Where i.Key <= Me.Horizon
                    Order By i.Key

        For Each item In query
            For Each transit_item In item.Value.Transits
                dt.Rows.Add(transit_item.Value.ID, transit_item.Value.PO, transit_item.Value.ExternalDocument, transit_item.Value.PRONumber, transit_item.Value.DeliveryDate, transit_item.Value.Quantity, transit_item.Value.UoM, transit_item.Value.AvailabilityDate, transit_item.Value.Edited)
            Next
        Next
        Return dt
    End Function

    Public Function PromisesToDatable() As DataTable
        Dim dt As New DataTable("Promesas")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        dt.Columns.Add("Comentario", GetType(String))
        dt.Columns.Add("Usuario", GetType(String))
        Dim query = From i In Me.Items
                    Where i.Key <= Me.Horizon
                    Order By i.Key

        For Each item In query
            For Each promise In item.Value.Promises
                dt.Rows.Add(promise.Value.ID, promise.Value.Quantity, promise.Value.UoM, promise.Value.AvailabilityDate, promise.Value.Comment, promise.Value.Username)
            Next
        Next
        Return dt
    End Function

    Public Function OpenOrdersToDatatable() As DataTable
        Dim dt As New DataTable("Ordenes Abiertas")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("No. de Proveedor")
        dt.Columns.Add("Proveedor")
        dt.Columns.Add("PO")
        dt.Columns.Add("Item")
        dt.Columns.Add("Kanban", GetType(Boolean))
        dt.Columns.Add("External", GetType(Boolean))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Estatus", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("GRP", GetType(Integer))
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        dt.Columns.Add("Fix", GetType(Boolean))
        dt.Columns.Add("Comentario", GetType(String))
        dt.Columns.Add("CallOff")
        dt.Columns.Add("Cantidad CallOff")
        dt.Columns.Add("Extra CallOff")
        dt.Columns.Add("CallOff Issue", GetType(Boolean))
        Dim query = From i In Me.Items
                    Where i.Key <= Me.Horizon
                    Order By i.Key
        For Each item In query
            For Each order_item In item.Value.OpenOrders
                'LOS CALLOFFS SE CONCATENAN, LAS CANTIDAD SE SUMAN Y MIENTRAS EXTRA UN EXTRA SE PODRA EL VALOR EN TRUE
                dt.Rows.Add(order_item.Value.ID, order_item.Value.SupplierNumber, order_item.Value.SupplierName, order_item.Value.Document, order_item.Value.Item, order_item.Value.Kanban, order_item.Value.External, order_item.Value.QuantityInBuM, order_item.Value.StatusInBuM, order_item.Value.UoM, order_item.Value.ShipDate, order_item.Value.GRP, order_item.Value.AvailabilityDate, order_item.Value.Fix, order_item.Value.Comment, String.Join(",", order_item.Value.CallOffs.Keys.ToArray), order_item.Value.CallOffs.Sum(Function(x) x.Value.Quantity), If(order_item.Value.CallOffs.Where(Function(w) w.Value.Extra = True).Count > 0, True, False), order_item.Value.CallOffIssue)
            Next
        Next
        Return dt
    End Function

    Public Function PlannedOrdersToDatatable()
        Dim dt As New DataTable("Ordenes Planeadas")
        dt.Columns.Add("No. de Orden")
        dt.Columns.Add("Planta")
        dt.Columns.Add("PO")
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("GRT", GetType(Integer))
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        Dim query = From i In Me.Items
                    Where i.Key <= Me.Horizon
                    Order By i.Key
        For Each item In query
            For Each order_item In item.Value.PlannedOrders
                dt.Rows.Add(order_item.Value.PlannnedOrder, order_item.Value.PlantIn, order_item.Value.Agreement, order_item.Value.Quantity, order_item.Value.UoM, order_item.Value.OpeningDate, order_item.Value.GRT, order_item.Value.AvailabilityDate)
            Next
        Next
        Return dt
    End Function

    Public Function AverageDailyDemand([date] As Date) As Decimal
        Dim sunday As Date = LastSunday([date]).AddDays(7 * If(ComponentPlan.CoverageProfiles.ContainsKey(Me.Partnumber.CoverageProfile), ComponentPlan.CoverageProfiles.Item(Me.Partnumber.CoverageProfile).HorizonWeeks, 4))
        Dim requirement = 0
        Dim working_days As Integer = 0
        While [date] <= sunday
            If Me.Items.ContainsKey([date].Date) Then requirement += Me.Items.Item([date].Date).Requirement
            If ProductionPlan.WorkingCalendar([date].Date) Then working_days += 1
            [date] = [date].AddDays(1)
        End While
        If requirement > 0 And working_days > 0 Then
            If Me.Partnumber.UoM = RawMaterial.UnitOfMeasure.PC Then
                Return Math.Ceiling(requirement / working_days)  'REQUERIMIENTO / DIAS HABILES
            Else
                Return requirement / working_days
            End If
        Else
            Return 0
        End If
    End Function

    Public Function HasRequirement16Weeks([date] As Date) As Boolean
        Dim last As Date = [date].AddDays(7 * 16)
        Return Me.Items.Any(Function(x) Between(x.Key, [date], last) And x.Value.Requirement > 0)
    End Function

    'Public Function SafetyStock() As Decimal
    '    Return Math.Ceiling(Me.WeeklyStandardDeviation * CP_IND * Math.Sqrt(Me.ReplenishmentLeadTime)) '.95 = SERVICE LEVEL REQUIRED
    'End Function

    Public Function StockBalance([date] As Date) As Decimal
        Dim sum_balance = Me.Items.Where(Function(w) Between(w.Key, Delta.CurrentDate, [date])).Sum(Function(x) x.Value.SumPlannedOrder + x.Value.SumOpenOrder + x.Value.SumTransit + x.Value.SumPromise - x.Value.Requirement)
        If Me.Partnumber.UoM = RawMaterial.UnitOfMeasure.PC Then
            Return Math.Round(Me.DeltaStock + Me.WIPStock + Delta.NullReplace(sum_balance, 0), 0) 'TOMAR EL CUENTA EL INVENTARIO MANUAL
        Else
            Return Me.DeltaStock + Me.WIPStock + Delta.NullReplace(sum_balance, 0) 'TOMAR EL CUENTA EL INVENTARIO MANUAL
        End If
    End Function

    Public Function DaysOfCoverage(stock As Decimal, [date] As Date) As Integer
        Dim covereddays As Integer = 0
        Dim accumulated As Decimal = 0
        If Me.Items.ContainsKey([date].Date) Then accumulated += Me.Items.Item([date].Date).Requirement
        While [date] <= Me.Horizon AndAlso stock >= accumulated
            covereddays += 1
            [date] = [date].AddDays(1)
            If Me.Items.ContainsKey([date].Date) Then accumulated += Me.Items.Item([date].Date).Requirement
        End While
        Return covereddays
    End Function

    'Public Function PhysicalInventoryBalance([date] As Date) As Decimal
    '    Dim wd_count As Integer = WorkingDays(Me.PhysicalInventoryDate, Delta.CurrentDate) 'DIAS QUE HAN TRANSCURRIDO DESDE EL INVENTARIO FISICO HASTA HOY
    '    Dim remaining_phy_stock As Decimal = Me.PhysicalInventoryQuantity - Me.AverageDailyDemand([date]) * wd_count 'RESTAR LOS DIAS DE INVENTARIO NECESARIO AL INVENTARIO FISICO
    '    If remaining_phy_stock < 0 Then remaining_phy_stock = 0 'SI EL RESULTADO ES NEGATIVO, DEJARLO EN CERO
    '    Return remaining_phy_stock
    'End Function

    Public Function PastDueOrdersCount() As Integer
        Dim pd As Integer = 0
        For Each i In Me.Items
            pd += i.Value.OpenOrders.Where(Function(w) w.Value.ShipDate < Delta.CurrentDate.Date AndAlso w.Value.RealQuantityInBuM > 0).Count()
        Next
        Return pd
    End Function

    Public Function NextTransitDate() As Object
        For Each i In Me.Items.Where(Function(w) w.Value.SumTransit > 0).OrderBy(Function(o) o.Key)
            Return i.Key
        Next
        Return DBNull.Value
    End Function
    Public Function NextTransitQuantity() As Object
        For Each i In Me.Items.Where(Function(w) w.Value.SumTransit > 0).OrderBy(Function(o) o.Key)
            Return i.Value.Transits.First().Value.QuantityBuM
        Next
        Return DBNull.Value
    End Function
    Public Function NextTransitDelivery() As Object
        For Each i In Me.Items.Where(Function(w) w.Value.SumTransit > 0).OrderBy(Function(o) o.Key)
            Return i.Value.Transits.First().Value.DeliveryNumber
        Next
        Return DBNull.Value
    End Function

    Public Function TransitsSum() As Decimal
        Return Me.Items.Sum(Function(s) s.Value.SumTransit + s.Value.SumPromise)
    End Function

    Public Function OrdersCount() As Integer
        Dim count As Integer = 0
        For Each i In Me.Items
            count += i.Value.OpenOrders.Where(Function(w) w.Value.RealQuantityInBuM > 0 AndAlso w.Value.ShipDate >= Delta.CurrentDate.Date).Count() + i.Value.PlannedOrders.Where(Function(w) w.Value.QuantityBuM > 0 AndAlso w.Value.OpeningDate >= Delta.CurrentDate.Date).Count()
        Next
        Return count
    End Function

    Public Function OrdersSum() As Decimal
        Return Me.Items.Sum(Function(s) s.Value.SumOpenOrder + s.Value.SumPlannedOrder)
    End Function

    Public Function CallOffIssuesCount() As Integer
        Dim count As Integer = 0
        For Each i In Me.Items
            count += i.Value.OpenOrders.Where(Function(w) w.Value.CallOffIssue).Count()
        Next
        Return count
    End Function

    Public Function Minimum([date] As Date) As Decimal
        If ComponentPlan.CoverageProfiles.ContainsKey(Me.Partnumber.CoverageProfile) Then
            With ComponentPlan.CoverageProfiles.Item(Me.Partnumber.CoverageProfile)
                Return Math.Ceiling(.CoverageDays * AverageDailyDemand([date]))
            End With
        Else
            'Return 0 'DOHIndex indica que si no tiene CP valido sea cero
            Return Math.Ceiling(5 * AverageDailyDemand([date])) 'SI EL NUMERO DE PARTE NO CONTIENEN UN COVERAGE PROFILE VALIDO, EL SISTEMA REGRESARA UN MINIMO DE 5 DIAS DE USO TOMANDO 2 SEMANAS DE FORECAST
        End If
    End Function

    Public Function Maximum([date] As Date) As Decimal
        Dim working_days As Integer = 5
        Dim max As Decimal = 0
        'If ComponentPlan.PlanningCalendars.ContainsKey(Me.Partnumber.PlanningCalendar) Then
        '    max = (Minimum([date]) + (working_days * AverageDailyDemand([date]))) / ComponentPlan.PlanningCalendars.Item(Me.Partnumber.PlanningCalendar).WeeklyShipments
        'Else 'SI EL NUMERO DE PARTE NO CONTIENE UN PLANNIG CALENDAR VALIDO ENTONCES SE TOMARAN 5 COMO SHIPMENTS POR DEFAULT
        '    max = (Minimum([date]) + (working_days * AverageDailyDemand([date]))) / 5
        'End If
        'Return Me.Partnumber.RoundByStdPack(max) + Minimum([date])

        If ComponentPlan.CoverageProfiles.ContainsKey(Me.Partnumber.CoverageProfile) Then
            With ComponentPlan.CoverageProfiles.Item(Me.Partnumber.CoverageProfile)
                If ComponentPlan.PlanningCalendars.ContainsKey(Me.Partnumber.PlanningCalendar) Then
                    Return Me.Partnumber.RoundByStdPack((.CoverageDays + (working_days / ComponentPlan.PlanningCalendars.Item(Me.Partnumber.PlanningCalendar).WeeklyShipments)) * AverageDailyDemand([date])) + Minimum([date])
                Else
                    Return Me.Partnumber.RoundByStdPack((.CoverageDays + (working_days / 5)) * AverageDailyDemand([date])) + Minimum([date]) 'SI EL NUMERO DE PARTE NO CONTIENE UN PLANNIG CALENDAR VALIDO ENTONCES SE TOMARAN 5 COMO SHIPMENTS POR DEFAULT
                End If
            End With
        Else
            If ComponentPlan.PlanningCalendars.ContainsKey(Me.Partnumber.PlanningCalendar) Then
                Return Me.Partnumber.RoundByStdPack(((working_days / ComponentPlan.PlanningCalendars.Item(Me.Partnumber.PlanningCalendar).WeeklyShipments)) * AverageDailyDemand([date])) + Minimum([date])
            Else
                Return Me.Partnumber.RoundByStdPack(((working_days / 5)) * AverageDailyDemand([date])) + Minimum([date]) 'SI EL NUMERO DE PARTE NO CONTIENE UN PLANNIG CALENDAR VALIDO ENTONCES SE TOMARAN 5 COMO SHIPMENTS POR DEFAULT
            End If
        End If

    End Function

    'Public ReadOnly Property WeeklyStandardDeviation As Decimal 'WEEKLY STANDARD DEVIATION
    '    Get
    '        If wsd_calculated Then
    '            Return _wsd
    '        Else
    '            If Me.HistoricalDemand.Count > 1 Then
    '                _wsd = Statistics.Statistics.StandardDeviation(Me.HistoricalDemand.Values)
    '            Else
    '                _wsd = 0
    '            End If
    '            wsd_calculated = True
    '            Return _wsd
    '        End If
    '    End Get
    'End Property

    'Public Property HistoricalDemand As New Dictionary(Of Date, Double)

    Public ReadOnly Property ReplenishmentLeadTime As Integer 'REPLENISHMENT LEAD TIME (WEEKS)
        Get
            Return 12
        End Get
    End Property

    Public Flags As New List(Of String)

    Public Function Clone() As ComponentPlanItem
        Dim cci_clone As New ComponentPlanItem()
        cci_clone.Partnumber = Me.Partnumber
        cci_clone.Horizon = Me.Horizon
        cci_clone.PastDue = Me.PastDue
        cci_clone.DeltaRandomStock = Me.DeltaRandomStock
        cci_clone.DeltaServiceStock = Me.DeltaServiceStock
        cci_clone.WIPStock = Me.WIPStock
        cci_clone.WIPStockDate = Me.WIPStockDate
        cci_clone.UpdateTime = Me.UpdateTime
        cci_clone._endofptf = Me.EndOfPTF
        For Each i In Me.Items
            cci_clone.Items.Add(i.Key, i.Value.Clone())
        Next
        For Each i In Me.Flags
            cci_clone.Flags.Add(i)
        Next
        Return cci_clone
    End Function

    Public Property SuggestedClone As ComponentPlanItem

    Public Sub RefreshQuickTasks()
        For Each i In Me.Items
            i.Value.SuggestedTask.Action = QuickTasksAction.None
            i.Value.SuggestedTask.Quantity = 0
        Next
        If Me.Partnumber.Document = "" Then Exit Sub
        Dim clone As ComponentPlanItem = Me.Clone()
        Me.SuggestedClone = clone
        Dim suggest_qty As Decimal = 0
        If ComponentPlan.Suppliers.ContainsKey(clone.Partnumber.SupplierNumber) Then
            With ComponentPlan.Suppliers.Item(clone.Partnumber.SupplierNumber)
                If .LeanOrdering Then 'PRIMERO DETECTAR CUALES ORDENES NO LLEGARAN O NO LLEGARAN CON LA CANTIDAD ORDENADA
                    For Each i In Me.Items
                        For Each o In i.Value.OpenOrders
                            'If o.Value.RealQuantityInBuM = 0 Then
                            '    o.Value.QuickTask = QuickTasksAction.FixCancel
                            '    i.Value.SuggestedTask.Action = QuickTasksAction.FixCancel
                            '    i.Value.SuggestedTask.Quantity = 0
                            'ElseIf o.Value.QuantityInBuM <= o.Value.RealQuantityInBuM + 1 OrElse o.Value.QuantityInBuM >= o.Value.RealQuantityInBuM - 1 Then 'TOLERANCIA DE 1 PC
                            '    o.Value.QuickTask = QuickTasksAction.FixAdjust
                            '    i.Value.SuggestedTask.Action = QuickTasksAction.FixAdjust
                            '    i.Value.SuggestedTask.Quantity = o.Value.RealQuantityInBuM
                            'End If
                            If o.Value.CallOffIssue And o.Value.RealQuantityInBuM > 0 Then 'CONTIENE CALLOFF
                                o.Value.QuickTask = QuickTasksAction.FixAdjust
                                i.Value.SuggestedTask.Action = QuickTasksAction.FixAdjust
                                i.Value.SuggestedTask.Quantity = o.Value.RealQuantityInBuM
                            ElseIf o.Value.CallOffIssue Then  'SIN CALLOFF
                                o.Value.QuickTask = QuickTasksAction.FixCancel
                                i.Value.SuggestedTask.Action = QuickTasksAction.FixCancel
                                i.Value.SuggestedTask.Quantity = 0
                            End If
                        Next
                    Next
                End If

                Dim day As Date = Delta.CurrentDate.Date
                Dim min_date As Date = Delta.CurrentDate.Date
                Dim max_date As Date = If(.LeanOrdering, WorkDay(.EndOfSRT, clone.Partnumber.GRT), WorkDay(Delta.CurrentDate, clone.Partnumber.GRT)) 'MENOR O IGUAL A ESTA FECHA NO ES POSIBLE REACCIONAR
                While day <= clone.Horizon AndAlso Between(day, min_date, max_date)
                    'ESTE CICLO AYUDA A IDENTIFICAR SI EL COMPONENTE ESTA O ESTARA CRITICO DENTRO DEL SRT + GRT (LEAN) O DESPUES DEL GR (NO LEAN)
                    'SI ES ASI, SOLO SE SUGERIRA NEGOCIAR POR CIERTA CANTIDAD Y TERMINARA
                    Select Case clone.Status(day)
                        Case ComponentPlanItemStatus.Critical
                            suggest_qty = clone.Partnumber.RoundByStdPack(clone.Minimum(day) - clone.StockBalance(day)) 'CANTIDAD SUFICIENTE PARA LLEGAR AL MINIMO Y CUBRIR EL FALTANTE
                            If Not Me.Items.ContainsKey(day) Then Me.Items.Add(day, New ComponentPlanItemDate(day))
                            If Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.None Then
                                Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.Dealing
                                Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                            Else
                                Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.FixAndDealing
                                Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                            End If
                            Exit Sub
                    End Select
                    day = day.AddDays(1)
                End While

                ''EN TEORIA NO DEBERIA HABER ORDENES CON PROBLEMAS DESPUES DEL SRT/GR, POR LO QUE EL SIGUIENTE PROCESO NO CONTEMPLA EL TASK 'FIX'
                'day = If(.LeanOrdering, .EndOfSRT.AddDays(1), today.AddDays(clone.Partnumber.GRT + 1)).Date  'UN DIA DESPUES DEL SRT
                'max_date = If(.LeanOrdering, .EndOfSRT.AddDays(1), today.AddDays(clone.Partnumber.GRT + 1))

                min_date = If(.LeanOrdering, WorkDay(.EndOfSRT, clone.Partnumber.GRT + 1), WorkDay(Delta.CurrentDate.Date, clone.Partnumber.GRT + 1)) 'DESPUES O EN ESTA FECHA ES POSIBLE REACCIONAR
                day = min_date
                max_date = WorkDay(clone.EndOfPTF, clone.Partnumber.GRT)  'FUERA DE ESTA FECHA NO ES NECESARIO REALIZAR NADA, SAP LO DEBE AJUSTAR CON LA CORRIDA DE MRP
                While day <= clone.Horizon AndAlso Between(day, min_date, max_date)
                    Dim status = clone.Status(day)
                    If status = ComponentPlanItemStatus.Minimum OrElse status = ComponentPlanItemStatus.Critical Then
                        'CRITICO Y MINIMO ES EL MISMO PROCESO, SOLO CAMBIA EL STATUS
                        Dim pickup_date As Date = BackWorkDay(day, clone.Partnumber.GRT) 'CALCULAR LA FECHA DONDE SE DEBE AGREGAR LA ORDEN PARA QUE LLEGUE A TIEMPO
                        suggest_qty = clone.Partnumber.RoundByStdPack(clone.Minimum(day) - clone.StockBalance(day))
                        If Not Me.Items.ContainsKey(day) Then Me.Items.Add(day, New ComponentPlanItemDate(day))
                        If Me.Items.Item(day).OpenOrders.Where(Function(w) w.Value.SupplierNumber = Me.Partnumber.SupplierNumber).Count() > 0 Then
                            Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.IncreaseOrder
                            Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty + Me.Items.Item(day).SumOpenOrder
                            Me.Items.Item(day).OpenOrders.First().Value.QuickTask = QuickTasksAction.IncreaseOrder
                        Else
                            Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.AddOrder
                            Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                        End If
                        'AGREGAR ORDEN FICTICIA PARA QUE LOS SIGUIENTES DIAS SE RECALCULEN
                        If Not clone.Items.ContainsKey(day) Then clone.Items.Add(day, New ComponentPlanItemDate(day))
                        If clone.Items.Item(day).OpenOrders.ContainsKey(0) Then
                            clone.Items.Item(day).OpenOrders.Item(0).QuantityInBuM = suggest_qty
                            clone.Items.Item(day).OpenOrders.Item(0).Quantity = suggest_qty
                            clone.Items.Item(day).OpenOrders.Item(0).Fake = True
                        Else
                            'STATUS EN NEGATIVO PARA QUE LA CANTIDAD DE REALQUANTITYINBUM REGRESE ALGO
                            clone.Items.Item(day).OpenOrders.Add(0, New OpenOrder(0, .Number, .Name, suggest_qty, -suggest_qty, clone.Partnumber.UoM.ToString, pickup_date, .TransitTime, day, False, clone.Partnumber.Document, clone.Partnumber.DocumentItem, False, Not .InHouse, suggest_qty, -suggest_qty, "", True))
                        End If
                    ElseIf status = ComponentPlanItemStatus.Excess OrElse status = ComponentPlanItemStatus.Obsolete Then
                        'EXCESO Y OBSOLETO ES EL MISMO PROCESO, SOLO CAMBIA EL STATUS
                        If clone.Items.ContainsKey(day) Then
                            For Each o In clone.Items(day).OpenOrders.Where(Function(w) w.Value.RealQuantityInBuM > 0 AndAlso w.Value.ShipDate >= Delta.CurrentDate.Date)
                                Dim temporal_qty As Decimal = o.Value.RealQuantityInBuM
                                'VALIDAR SI CANCELANDO LA ORDEN NO AFECTAMOS
                                o.Value.QuantityInBuM = 0
                                Select Case clone.Status(day)
                                    Case ComponentPlanItemStatus.Critical, ComponentPlanItemStatus.Minimum 'SIGNIFICA QUE LA ORDEN SI ES NECESARIA PERO EN MENOR CANTIDAD
                                        suggest_qty = clone.Partnumber.RoundByStdPack(clone.Minimum(day))
                                        If suggest_qty < temporal_qty Then 'VALIDAR QUE LA CANTIDAD SUGERIDA NO SEA MAYOR A LA ACTUAL EN LA ORDEN (NO DEBERIA)
                                            'MANTENER LA ORDEN PERO BAJAR LA CANTIDAD
                                            Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.DecreaseOrder
                                            Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                                            Me.Items.Item(day).OpenOrders.Item(o.Key).QuickTask = QuickTasksAction.DecreaseOrder
                                            o.Value.QuantityInBuM = suggest_qty
                                            o.Value.Fake = True
                                        Else 'MANTENER LA ORDEN TAN CUAL, NO ES POSIBLE CANCELARLA O SE AFECTARA A FUTURO
                                            o.Value.QuantityInBuM = temporal_qty
                                            o.Value.Fake = True
                                        End If
                                    Case Else
                                        'ES POSIBLE CANCELAR LA ORDEN SIN AFECTAR A FUTURO
                                        Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.CancelOrder
                                        Me.Items.Item(day).SuggestedTask.Quantity = 0
                                        Me.Items.Item(day).OpenOrders.Item(o.Key).QuickTask = QuickTasksAction.CancelOrder
                                        o.Value.QuantityInBuM = 0
                                        o.Value.Fake = True
                                End Select
                            Next
                        End If
                    End If
                    day = day.AddDays(1)
                End While

                day = max_date.AddDays(1) 'COMENZAR A REVISAR LAS ORDENES MANUALES FUERA DEL PTF
                While Between(day, max_date, clone.Horizon)
                    Dim status = clone.Status(day)
                    If clone.Items.ContainsKey(day) AndAlso (status = ComponentPlanItemStatus.Excess OrElse status = ComponentPlanItemStatus.Obsolete) Then
                        For Each o In clone.Items.Item(day).OpenOrders.Where(Function(w) w.Value.Fix)
                            Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.CancelOrder
                            Me.Items.Item(day).SuggestedTask.Quantity = 0
                            Me.Items.Item(day).OpenOrders.Item(o.Key).QuickTask = QuickTasksAction.CancelOrder
                            o.Value.QuantityInBuM = 0
                            o.Value.Fake = True
                        Next
                    End If
                    day = day.AddDays(1)
                End While
            End With
        Else
            'RECORRER TODO EL FORECAST
            Dim min_date As Date = Delta.CurrentDate.AddDays(1).Date
            Dim day As Date = min_date
            Dim max_date As Date = clone.Horizon
            While day <= clone.Horizon AndAlso Between(day, min_date, max_date)
                Dim status = clone.Status(day)
                If status = ComponentPlanItemStatus.Minimum OrElse status = ComponentPlanItemStatus.Critical Then
                    'CRITICO Y MINIMO ES EL MISMO PROCESO, SOLO CAMBIA EL STATUS
                    Dim pickup_date As Date = BackWorkDay(day, clone.Partnumber.GRT) 'CALCULAR LA FECHA DONDE SE DEBE AGREGAR LA ORDEN PARA QUE LLEGUE A TIEMPO
                    suggest_qty = clone.Partnumber.RoundByStdPack(clone.Minimum(day) - clone.StockBalance(day))
                    If Not Me.Items.ContainsKey(day) Then Me.Items.Add(day, New ComponentPlanItemDate(day))
                    If Me.Items.Item(day).OpenOrders.Where(Function(w) w.Value.SupplierNumber = Me.Partnumber.SupplierNumber).Count() > 0 Then
                        Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.IncreaseOrder
                        Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty + Me.Items.Item(day).SumOpenOrder
                        Me.Items.Item(day).OpenOrders.First().Value.QuickTask = QuickTasksAction.IncreaseOrder
                    Else
                        Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.AddOrder
                        Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                    End If
                    'AGREGAR ORDEN FICTICIA PARA QUE LOS SIGUIENTES DIAS SE RECALCULEN
                    If Not clone.Items.ContainsKey(day) Then clone.Items.Add(day, New ComponentPlanItemDate(day))
                    If clone.Items.Item(day).OpenOrders.ContainsKey(0) Then
                        clone.Items.Item(day).OpenOrders.Item(0).QuantityInBuM = suggest_qty
                        clone.Items.Item(day).OpenOrders.Item(0).Quantity = suggest_qty
                        clone.Items.Item(day).OpenOrders.Item(0).Fake = True
                    Else
                        'STATUS EN NEGATIVO PARA QUE LA CANTIDAD DE REALQUANTITYINBUM REGRESE ALGO
                        clone.Items.Item(day).OpenOrders.Add(0, New OpenOrder(0, "", "", suggest_qty, -suggest_qty, clone.Partnumber.UoM.ToString, pickup_date, clone.Partnumber.GRT, day, False, clone.Partnumber.Document, clone.Partnumber.DocumentItem, False, True, suggest_qty, -suggest_qty, "", True))
                    End If
                ElseIf status = ComponentPlanItemStatus.Excess OrElse status = ComponentPlanItemStatus.Obsolete Then
                    'EXCESO Y OBSOLETO ES EL MISMO PROCESO, SOLO CAMBIA EL STATUS
                    If clone.Items.ContainsKey(day) Then
                        For Each o In clone.Items(day).OpenOrders.Where(Function(w) w.Value.RealQuantityInBuM > 0 AndAlso w.Value.ShipDate >= Delta.CurrentDate.Date)
                            Dim temporal_qty As Decimal = o.Value.RealQuantityInBuM
                            'VALIDAR SI CANCELANDO LA ORDEN NO AFECTAMOS
                            o.Value.QuantityInBuM = 0
                            Select Case clone.Status(day)
                                Case ComponentPlanItemStatus.Critical, ComponentPlanItemStatus.Minimum 'SIGNIFICA QUE LA ORDEN SI ES NECESARIA PERO EN MENOR CANTIDAD
                                    suggest_qty = clone.Partnumber.RoundByStdPack(clone.Minimum(day))
                                    If suggest_qty < temporal_qty Then 'VALIDAR QUE LA CANTIDAD SUGERIDA NO SEA MAYOR A LA ACTUAL EN LA ORDEN (NO DEBERIA)
                                        'MANTENER LA ORDEN PERO BAJAR LA CANTIDAD
                                        Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.DecreaseOrder
                                        Me.Items.Item(day).SuggestedTask.Quantity = suggest_qty
                                        Me.Items.Item(day).OpenOrders.Item(o.Key).QuickTask = QuickTasksAction.DecreaseOrder
                                        o.Value.QuantityInBuM = suggest_qty
                                        o.Value.Fake = True
                                    Else 'MANTENER LA ORDEN TAN CUAL, NO ES POSIBLE CANCELARLA O SE AFECTARA A FUTURO
                                        o.Value.QuantityInBuM = temporal_qty
                                        o.Value.Fake = True
                                    End If
                                Case Else
                                    'ES POSIBLE CANCELAR LA ORDEN SIN AFECTAR A FUTURO
                                    Me.Items.Item(day).SuggestedTask.Action = QuickTasksAction.CancelOrder
                                    Me.Items.Item(day).SuggestedTask.Quantity = 0
                                    Me.Items.Item(day).OpenOrders.Item(o.Key).QuickTask = QuickTasksAction.CancelOrder
                                    o.Value.QuantityInBuM = 0
                                    o.Value.Fake = True
                            End Select
                        Next
                    End If
                End If
                day = day.AddDays(1)
            End While
        End If
        '##### RESUMIR ######################
        For Each item In Me.Items
            Select Case item.Value.SuggestedTask.Action
                Case QuickTasksAction.CancelOrder 'QUITAR LOS CANCEL ORDERS DONDE SE TENGA QUE AGREGAR UNA ORDEN EN LOS PROXIMOS DIAS
                    If Me.Items.Where(Function(x) x.Value.SuggestedTask.Action = QuickTasksAction.AddOrder AndAlso Between(x.Key, WorkDay(item.Key, 1), WorkDay(item.Key, 3))).Any Then
                        item.Value.SuggestedTask.Action = QuickTasksAction.None
                        item.Value.SuggestedTask.Quantity = 0
                        With Me.Items.Where(Function(x) x.Value.SuggestedTask.Action = QuickTasksAction.AddOrder AndAlso Between(x.Key, WorkDay(item.Key, 1), WorkDay(item.Key, 3))).First
                            .Value.SuggestedTask.Action = QuickTasksAction.None
                            .Value.SuggestedTask.Quantity = 0
                        End With
                    End If
                Case QuickTasksAction.AddOrder
                    If Me.Items.Where(Function(x) x.Value.SuggestedTask.Action = QuickTasksAction.CancelOrder AndAlso x.Key > item.Key).Any Then
                        With Me.Items.Where(Function(x) x.Value.SuggestedTask.Action = QuickTasksAction.CancelOrder AndAlso x.Key > item.Key).OrderBy(Function(o) o.Key).First
                            Dim days As Integer = DateDiff(DateInterval.Day, item.Key, .Key)
                            Dim critical_posibility As Boolean = False
                            For i = 0 To days - 1
                                If Me.Status(item.Key.AddDays(i)) = ComponentPlanItemStatus.Critical Then
                                    critical_posibility = True
                                    Exit For
                                End If
                            Next
                            If Not critical_posibility Then
                                item.Value.SuggestedTask.Action = QuickTasksAction.None
                                item.Value.SuggestedTask.Quantity = 0
                                .Value.SuggestedTask.Action = QuickTasksAction.None
                                .Value.SuggestedTask.Quantity = 0
                            End If
                        End With
                    End If
            End Select
        Next
    End Sub
End Class

Public Class QuickTask
    Public Sub New(action As QuickTasksAction, quantity As Decimal)
        Me.Action = action
        Me.Quantity = quantity
    End Sub
    Public Property Action As QuickTasksAction
    Public Property Quantity As Decimal
End Class

Public Enum QuickTasksAction
    CancelOrder
    AddOrder
    DecreaseOrder
    IncreaseOrder
    Dealing
    FixAdjust
    FixCancel
    FixAndDealing
    None
End Enum
Public Class ComponentPlanItemDate
    Private Sub New()

    End Sub
    Public Sub New([date] As Date)
        Me.Date = [date]
    End Sub
    Public Property [Date] As Date
    Public Property Requirement As Decimal = 0
    Public ReadOnly Property SumOpenOrder As Decimal
        Get
            'IGNORAR ORDENES PAST DUE
            Dim total As Decimal = 0
            For Each order In Me.OpenOrders.Where(Function(w) w.Value.ShipDate >= Delta.CurrentDate.Date)
                total += order.Value.RealQuantityInBuM
            Next
            Return total
        End Get
    End Property

    Public ReadOnly Property SumPlannedOrder As Decimal
        Get
            'IGNORAR ORDENES PAST DUE
            Return Delta.NullReplace(Me.PlannedOrders.Where(Function(W) W.Value.OpeningDate >= Delta.CurrentDate.Date).Sum(Function(x) x.Value.QuantityBuM), CDec(0))
        End Get
    End Property


    Public ReadOnly Property SumTransit As Decimal
        Get
            Return Delta.NullReplace(Me.Transits.Sum(Function(x) x.Value.QuantityBuM), CDec(0))
        End Get
    End Property

    Public ReadOnly Property SumPromise As Decimal
        Get
            Return Delta.NullReplace(Me.Promises.Sum(Function(x) x.Value.QuantityBuM), CDec(0))
        End Get
    End Property
    Public Property Transits As New Dictionary(Of Integer, Transit)
    Public Property OpenOrders As New Dictionary(Of Integer, OpenOrder)
    Public Property PlannedOrders As New Dictionary(Of Integer, PlannedOrder)
    Public Property Promises As New Dictionary(Of Integer, Promise)
    Public Property SuggestedTask As New QuickTask(QuickTasksAction.None, 0)
    Public Function Clone() As ComponentPlanItemDate
        Dim cpid_clone As New ComponentPlanItemDate
        cpid_clone.Date = Me.Date
        cpid_clone.Requirement = Me.Requirement
        cpid_clone.SuggestedTask.Action = Me.SuggestedTask.Action
        cpid_clone.SuggestedTask.Quantity = Me.SuggestedTask.Quantity
        For Each i In Me.Transits
            cpid_clone.Transits.Add(i.Key, i.Value.Clone())
        Next
        For Each i In Me.OpenOrders
            cpid_clone.OpenOrders.Add(i.Key, i.Value.Clone())
        Next
        For Each i In Me.PlannedOrders
            cpid_clone.PlannedOrders.Add(i.Key, i.Value.Clone())
        Next
        For Each i In Me.Promises
            cpid_clone.Promises.Add(i.Key, i.Value.Clone())
        Next
        Return cpid_clone
    End Function
End Class

Public Class Transit
    Implements ICloneable

    Public Sub New(id As Integer, delivery_date As Date, availability_date As Date, delivery_number As String, po As String, uom As String, quantity As Decimal, quantity_bum As Decimal, pro_number As String, external_document As String, edited As Boolean)
        Me.ID = id
        Me.DeliveryDate = delivery_date
        Me.AvailabilityDate = availability_date
        Me.DeliveryNumber = delivery_number
        Me.PO = po
        Me.UoM = uom
        Me.Quantity = quantity
        Me.QuantityBuM = quantity_bum
        Me.PRONumber = pro_number
        Me.ExternalDocument = external_document
        Me.Edited = edited
    End Sub
    Public Property ID As Integer
    Public Property DeliveryDate As Date
    Public Property AvailabilityDate As Date
    Public Property DeliveryNumber As String
    Public Property PO As String
    Public Property UoM As String
    Public Property Quantity As Decimal
    Public Property QuantityBuM As Decimal
    Public Property PRONumber As String
    Public Property ExternalDocument As String
    Public Property Edited As Boolean

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class

Public Class Promise
    Implements ICloneable

    Public Sub New(id As Integer, quantity As Decimal, uom As String, availability_date As Date, quantity_bum As Decimal, comment As String, username As String)
        Me.ID = id
        Me.Quantity = quantity
        Me.UoM = uom
        Me.AvailabilityDate = availability_date
        Me.QuantityBuM = quantity_bum
        Me.Comment = comment
        Me.Username = username
    End Sub
    Public Property ID As Integer
    Public Property AvailabilityDate As Date
    Public Property UoM As String
    Public Property Quantity As Decimal
    Public Property QuantityBuM As Decimal
    Public Property Comment As String
    Public Property Username As String
    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class

Public Class ScheduledChange
    Public Sub New(main_item As String)
        Me.MainItem = main_item
    End Sub
    Public Property MainItem As String
    Public Property Items As New Dictionary(Of String, ScheduledPartnumberChange)
End Class

Public Class ScheduledPartnumberChange
    Public Sub New(old_partnumber As String, new_partnumber As String, effective_date As Date)
        Me.OldPartnumber = old_partnumber
        Me.NewPartnumber = new_partnumber
        Me.EffectiveDate = effective_date
    End Sub
    Public Property OldPartnumber As String
    Public Property NewPartnumber As String
    Public Property EffectiveDate As Date
End Class

Public Class CallOff
    Implements ICloneable

    Public Sub New(number As String, quantity As Decimal, extra As Boolean)
        Me.Number = number
        Me.Quantity = quantity
        Me.Extra = extra
    End Sub
    Public Property Number As String
    Public Property Quantity As Decimal
    Public Property Extra As Boolean

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class
Public Class OpenOrder
    Public Sub New(id As Integer, supplier_number As String, supplier_name As String, quantity As Decimal, status As Decimal, uom As String, ship_date As Date, grp As Integer, availability_date As Date, fix As Boolean, document As String, item As String, kanban As Boolean, external As Boolean, quantity_bum As Decimal, status_bum As Decimal, comment As String, fake As Boolean)
        Me.ID = id
        Me.SupplierName = supplier_name
        Me.SupplierNumber = supplier_number
        Me.Quantity = quantity
        Me.Status = status
        Me.UoM = uom
        Me.ShipDate = ship_date
        Me.GRP = grp
        Me.AvailabilityDate = availability_date
        Me.Fix = fix
        Me.Document = document
        Me.Item = item
        Me.Kanban = kanban
        Me.External = external
        Me.QuantityInBuM = quantity_bum
        Me.StatusInBuM = status_bum
        Me.Fake = fake
        Me.Comment = comment
    End Sub
    Public Property Fake As Boolean
    Public Property ID As Integer
    Public Property SupplierNumber As String
    Public Property SupplierName As String
    Public Property Quantity As Decimal
    Public Property Status As Decimal
    Public Property UoM As String
    Public Property ShipDate As Date
    Public Property GRP As Integer
    Public Property AvailabilityDate As Date
    Public Property Fix As Double
    Public Property Document As String
    Public Property Item As String
    Public Property Kanban As Boolean
    Public Property External As Boolean
    Public Property QuantityInBuM As Decimal
    Public Property StatusInBuM As Decimal
    Public Property Comment As String
    Public Property CallOffs As New Dictionary(Of String, CallOff)
    Public Property QuickTask As QuickTasksAction = QuickTasksAction.None
    Public ReadOnly Property CallOffIssue As Boolean
        Get
            If Me.IsLeanOrdering Then
                If Me.QuantityInBuM = 0 AndAlso Me.CallOffs.Count > 0 Then 'CALL OFF SIN ORDEN
                    Return False
                ElseIf Me.ShipDate > ComponentPlan.Suppliers.Item(Me.SupplierNumber).EndOfSRT Then 'FUERA DEL SRT NO PUEDE HABER PROBLEMAS DE CALL OFFS
                    Return False
                ElseIf Delta.NullReplace(Me.CallOffs.Sum(Function(x) x.Value.Quantity), 0) >= QuantityInBuM - 1 AndAlso Delta.NullReplace(Me.CallOffs.Sum(Function(x) x.Value.Quantity), 0) <= QuantityInBuM + 1 Then 'LA CANTIDAD DE LOS CALL OFFS ES LA MISMA DE LA SCHEDULE LINE, TOLERANCIA DE 1 PC
                    Return False
                ElseIf Me.StatusInBuM >= 0 Then 'LOS ADELANTOS DE LOS EMBARQUES CONSUMEN LAS SCH LINES FUTURAS Y NO ES NECESARIO QUE SE LE ASIGNE UN CALLOFF
                    Return False
                Else
                    Return True
                End If
            Else 'SINO ES LEAN ORDERING NUNCA HAY PROBLEMAS DE CALL OFFS
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property IsLeanOrdering As Boolean
        Get
            Return ComponentPlan.Suppliers.ContainsKey(Me.SupplierNumber) AndAlso ComponentPlan.Suppliers.Item(Me.SupplierNumber).LeanOrdering
        End Get
    End Property
    Public ReadOnly Property RealQuantityInBuM As Decimal 'REGRESA LA CANTIDAD REAL DE LA ORDEN, CONSIDERANDO SI EL PROVEEDOR ES LEAN ORDERING Y SI SE GENERO EL CALLOFF PARA LA ORDEN
        Get
            If Me.IsLeanOrdering Then
                If Me.ShipDate > ComponentPlan.Suppliers.Item(Me.SupplierNumber).EndOfSRT Then 'FUERA DEL SRT NO SE DEBE TOMAR EN CUENTA LOS CALL OFFS
                    'EL STATUS INDICA SI HAY UN SOBRE EMBARQUE O ADELANTO, POR LO TANTO SE DEBE CONTEMPLAR QUE UN EMBARQUE PUEDE "CONSUMIR" LAS SIGUIENTES ORDENES
                    Return If(Me.Fake, Me.QuantityInBuM, If(Me.StatusInBuM >= 0, 0, Math.Min(Me.QuantityInBuM, Math.Abs(Me.StatusInBuM))))
                Else 'EN EL CASO DE LOS LEAN ORDERING, LOS CALL OFFS SON LOS QUE INDICAN CUANTO LLEGARA
                    Return Delta.NullReplace(Me.CallOffs.Sum(Function(x) x.Value.Quantity), 0)
                End If
            Else
                'EL STATUS INDICA SI HAY UN SOBRE EMBARQUE O ADELANTO, POR LO TANTO SE DEBE CONTEMPLAR QUE UN EMBARQUE PUEDE "CONSUMIR" LAS SIGUIENTES ORDENES
                Return If(Me.Fake, Me.QuantityInBuM, If(Me.StatusInBuM >= 0, 0, Math.Min(Me.QuantityInBuM, Math.Abs(Me.StatusInBuM))))
            End If
        End Get
    End Property

    Public Function Clone() As OpenOrder
        Dim o_clone As New OpenOrder(Me.ID, Me.SupplierNumber, Me.SupplierName, Me.Quantity, Me.Status, Me.UoM, Me.ShipDate, Me.GRP, Me.AvailabilityDate, Me.Fix, Me.Document, Me.Item, Me.Kanban, Me.External, Me.QuantityInBuM, Me.StatusInBuM, "", Me.Fake)
        For Each c In Me.CallOffs
            o_clone.CallOffs.Add(c.Key, New CallOff(c.Value.Number, c.Value.Quantity, c.Value.Extra))
        Next
        Return o_clone
    End Function
End Class

Public Class PlannedOrder
    Implements ICloneable

    Public Sub New(id As Integer, planned_order As String, plant_in As String, quantity As Decimal, uom As String, opening_date As Date, agreement As String, grt As Integer, availability_date As Date, quantity_bum As Decimal)
        Me.ID = id
        Me.PlannnedOrder = planned_order
        Me.PlantIn = plant_in
        Me.Quantity = quantity
        Me.UoM = uom
        Me.OpeningDate = opening_date
        Me.Agreement = agreement
        Me.GRT = grt
        Me.AvailabilityDate = availability_date
        Me.QuantityBuM = quantity_bum
    End Sub
    Public Property ID As Integer
    Public Property PlannnedOrder As String
    Public Property PlantIn As String
    Public Property Quantity As Decimal
    Public Property UoM As String
    Public Property OpeningDate As Date
    Public Property Agreement As String
    Public Property GRT As Integer
    Public Property AvailabilityDate As Date
    Public Property QuantityBuM As Decimal

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class

Public Class CoverageProfile
    Public Sub New(id As String, coverage_days As Decimal, horizon_weeks As Integer)
        Me.ID = id
        Me.CoverageDays = coverage_days
        Me.HorizonWeeks = horizon_weeks
    End Sub
    Public Property ID As String
    Public Property CoverageDays As Decimal
    Public Property HorizonWeeks As Integer
End Class

Public Class Supplier
    Dim _endofsrt As Date
    Public Sub New(number As String, name As String, trucks As Integer, transit As Integer, premium As Integer, deliveries As Integer, response As Integer, ratio As Decimal, coverage As Decimal, lean As Boolean, in_house As Boolean)
        Me.Number = number
        Me.Name = name
        Me.TrucksPerWeek = trucks
        Me.TransitTime = transit
        Me.PremiumTransit = premium
        Me.DeliveriesPerWeek = deliveries
        Me.ResponseTime = response
        Me.Ratio = ratio
        Me.CoverageProfile = coverage
        Me.LeanOrdering = lean
        Me.InHouse = in_house
        _endofsrt = WorkDay(Delta.CurrentDate, Me.ResponseTime).Date
    End Sub
    Public Property Number As String
    Public Property Name As String
    Public Property TrucksPerWeek As Integer
    Public Property TransitTime As Integer
    Public Property PremiumTransit As Integer
    Public Property DeliveriesPerWeek As Integer
    Public Property ResponseTime As Integer
    Public Property Ratio As Decimal
    Public Property CoverageProfile As Decimal
    Public Property LeanOrdering As Boolean
    Public Property InHouse As Boolean
    Public ReadOnly Property EndOfSRT As Date
        Get
            Return _endofsrt
        End Get
    End Property
End Class
Public Class PlanningCalendar
    Public Sub New(id As String, sunday_1 As Boolean, monday_1 As Boolean, tuesday_1 As Boolean, wednesday_1 As Boolean, thursday_1 As Boolean, friday_1 As Boolean, saturday_1 As Boolean, _
                    sunday_2 As Boolean, monday_2 As Boolean, tuesday_2 As Boolean, wednesday_2 As Boolean, thursday_2 As Boolean, friday_2 As Boolean, saturday_2 As Boolean, _
                    sunday_3 As Boolean, monday_3 As Boolean, tuesday_3 As Boolean, wednesday_3 As Boolean, thursday_3 As Boolean, friday_3 As Boolean, saturday_3 As Boolean, _
                    sunday_4 As Boolean, monday_4 As Boolean, tuesday_4 As Boolean, wednesday_4 As Boolean, thursday_4 As Boolean, friday_4 As Boolean, saturday_4 As Boolean, _
                    sunday_5 As Boolean, monday_5 As Boolean, tuesday_5 As Boolean, wednesday_5 As Boolean, thursday_5 As Boolean, friday_5 As Boolean, saturday_5 As Boolean)
        Me.ID = id
        Me.Sunday1 = sunday_1
        Me.Monday1 = monday_1
        Me.Tuesday1 = tuesday_1
        Me.Wednesday1 = wednesday_1
        Me.Thursday1 = thursday_1
        Me.Friday1 = friday_1
        Me.Saturday1 = saturday_1
        Me.Sunday2 = sunday_2
        Me.Monday2 = monday_2
        Me.Tuesday2 = tuesday_2
        Me.Wednesday2 = wednesday_2
        Me.Thursday2 = thursday_2
        Me.Friday2 = friday_2
        Me.Saturday2 = saturday_2
        Me.Sunday3 = sunday_3
        Me.Monday3 = monday_3
        Me.Tuesday3 = tuesday_3
        Me.Wednesday3 = wednesday_3
        Me.Thursday3 = thursday_3
        Me.Friday3 = friday_3
        Me.Saturday3 = saturday_3
        Me.Sunday4 = sunday_4
        Me.Monday4 = monday_4
        Me.Tuesday4 = tuesday_4
        Me.Wednesday4 = wednesday_4
        Me.Thursday4 = thursday_4
        Me.Friday4 = friday_4
        Me.Saturday4 = saturday_4
        Me.Sunday5 = sunday_5
        Me.Monday5 = monday_5
        Me.Tuesday5 = tuesday_5
        Me.Wednesday5 = wednesday_5
        Me.Thursday5 = thursday_5
        Me.Friday5 = friday_5
        Me.Saturday5 = saturday_5
    End Sub

    Public ReadOnly Property WeeklyShipments As Decimal
        Get
            Dim true_days As Integer = Sunday1 + Monday1 + Tuesday1 + Wednesday1 + Thursday1 + Friday1 + Saturday1 + _
                Sunday2 + Monday2 + Tuesday2 + Wednesday2 + Thursday2 + Friday2 + Saturday2 + Sunday3 + Monday3 + Tuesday3 + Wednesday3 + Thursday3 + Friday3 + Saturday3 + _
                Sunday4 + Monday4 + Tuesday4 + Wednesday4 + Thursday4 + Friday4 + Saturday4 + Sunday5 + Monday5 + Tuesday5 + Wednesday5 + Thursday5 + Friday5 + Saturday5
            Return (Math.Abs(true_days) / 35) * 7
        End Get
    End Property

    Public Property ID As String
    Public Property Sunday1 As Boolean
    Public Property Monday1 As Boolean
    Public Property Tuesday1 As Boolean
    Public Property Wednesday1 As Boolean
    Public Property Thursday1 As Boolean
    Public Property Friday1 As Boolean
    Public Property Saturday1 As Boolean
    Public Property Sunday2 As Boolean
    Public Property Monday2 As Boolean
    Public Property Tuesday2 As Boolean
    Public Property Wednesday2 As Boolean
    Public Property Thursday2 As Boolean
    Public Property Friday2 As Boolean
    Public Property Saturday2 As Boolean
    Public Property Sunday3 As Boolean
    Public Property Monday3 As Boolean
    Public Property Tuesday3 As Boolean
    Public Property Wednesday3 As Boolean
    Public Property Thursday3 As Boolean
    Public Property Friday3 As Boolean
    Public Property Saturday3 As Boolean
    Public Property Sunday4 As Boolean
    Public Property Monday4 As Boolean
    Public Property Tuesday4 As Boolean
    Public Property Wednesday4 As Boolean
    Public Property Thursday4 As Boolean
    Public Property Friday4 As Boolean
    Public Property Saturday4 As Boolean
    Public Property Sunday5 As Boolean
    Public Property Monday5 As Boolean
    Public Property Tuesday5 As Boolean
    Public Property Wednesday5 As Boolean
    Public Property Thursday5 As Boolean
    Public Property Friday5 As Boolean
    Public Property Saturday5 As Boolean
End Class

Public Class Flag
    Public Sub New(id As String, description As String, color As Color)
        Me.ID = id
        Me.Description = description
        Me.Color = color
    End Sub
    Public Property ID As String
    Public Property Description As String
    Public Property Color As Color
End Class

Public Class MRPC
    Public Sub New(mrp As String, username As String, name As String)
        Me.MRP = mrp
        Me.Username = username
        Me.Name = name
    End Sub
    Public Property MRP As String
    Public Property Username As String
    Public Property Name As String
End Class