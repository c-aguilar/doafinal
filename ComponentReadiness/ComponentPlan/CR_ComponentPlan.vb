Public Class CR_ComponentPlan
    Dim Main_Component_Plan As ComponentPlan
    Dim SelectedItem As ComponentPlanItem
    Dim Main_DT As DataTable
    Dim selected_mrps As New ArrayList
    Dim horizon_main_forecast As Date
    Dim global_horizon_date As Date
    Dim global_updated_time As Date
    Dim search_box As SearchBox
    Dim MRPCs As New Dictionary(Of String, MRPC)
    Private Sub CR_ComponentPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mrp_dt As DataTable
        If User.Current.IsAdmin OrElse {"CR Supervisor", "ORD Supervisor", "PC Manager"}.Contains(User.Current.Role) OrElse User.Current.HasPermission("Ordering_ComponentPlan_Administrator_flag") Then
            mrp_dt = SQL.Current.GetDatatable("SELECT UPPER(MRP) AS MRP,UPPER(U.Username) AS Username,FullName FROM Ord_MRPControllers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE ProcurementType= 'R' ORDER BY FullName,MRP;")
        Else
            mrp_dt = SQL.Current.GetDatatable(String.Format("SELECT UPPER(MRP) AS MRP,UPPER(U.Username) AS Username,FullName FROM Ord_MRPControllers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE ProcurementType= 'R' AND M.Username = '{0}' ORDER BY FullName,MRP;", User.Current.Username))
        End If
        For Each row As DataRow In mrp_dt.Rows
            MRPCs.Add(row.Item("MRP").ToString.ToUpper, New MRPC(row.Item("MRP"), row.Item("Username"), row.Item("FullName")))
        Next
        mrp_dt.Rows.Add("*", "*", "Todos")
        GF.FillCombobox(DashboardMRP_cbo, mrp_dt.DefaultView.ToTable(True, "Fullname", "Username"), "Fullname", "Username")
        DashboardMRP_cbo.SelectedItem = "Todos"
        If MRPCs.Any(Function(x) x.Value.Username = User.Current.Username) Then
            selected_mrps.Add(MRPCs.Where(Function(x) x.Value.Username = User.Current.Username).ToList)
        End If
        horizon_main_forecast = LastSaturday(Delta.CurrentDate.Date.AddDays(25))
        global_horizon_date = LastSaturday(Delta.CurrentDate.Date.AddDays(120))
        search_box = New SearchBox
        search_box.MdiParent = Me.MdiParent
        search_box.SetNewDataGridView(ComponentPlan_dgv)
        CType(PartnumberPromises_dgv.Columns("Promise_Delete_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.cross_16
        ClearPartnumberData()
        UpdateJobUpdates()
    End Sub

    Private Sub Flags_cmsi_Click(sender As Object, e As EventArgs)
        Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If item.Checked Then
            SQL.Current.Insert("Sys_PartnumberFlags", {"Partnumber", "Flag"}, {SelectedItem.Partnumber.Partnumber, item.Tag})
            SelectedItem.Flags.Add(item.Tag)
        Else
            SQL.Current.Delete("Sys_PartnumberFlags", {"Partnumber", "Flag"}, {SelectedItem.Partnumber.Partnumber, item.Tag})
            SelectedItem.Flags.Remove(item.Tag)
        End If
        ShowFlags()
        RefreshSelectedItemDataRow()
    End Sub

    Private Sub RefreshSelectedItemDataRow()
        If Main_DT IsNot Nothing Then
            Dim row As DataRow = Main_DT.Rows.Find(SelectedItem.Partnumber.Partnumber)
            If row IsNot Nothing Then
                row.Item("Partnumber") = SelectedItem.Partnumber.Partnumber
                row.Item("Description") = SelectedItem.Partnumber.Description
                row.Item("MRP") = SelectedItem.Partnumber.MRP
                row.Item("Owner") = If(ComponentPlan.MRPOwners.ContainsKey(SelectedItem.Partnumber.MRP), ComponentPlan.MRPOwners.Item(SelectedItem.Partnumber.MRP), "S/D")
                row.Item("UoM") = SelectedItem.Partnumber.UoM
                row.Item("SmkLocation") = SelectedItem.SmkLocation
                row.Item("RoundingValue") = SelectedItem.Partnumber.OrderStdPack
                row.Item("UnitCost") = SelectedItem.Partnumber.UnitCost
                row.Item("SupplierNumber") = SelectedItem.Partnumber.SupplierNumber
                row.Item("SupplierName") = SelectedItem.Partnumber.SupplierName
                row.Item("Lean Ordering") = If(ComponentPlan.Suppliers.ContainsKey(SelectedItem.Partnumber.SupplierNumber), ComponentPlan.Suppliers.Item(SelectedItem.Partnumber.SupplierNumber).LeanOrdering, False)
                row.Item("InHouse") = If(ComponentPlan.Suppliers.ContainsKey(SelectedItem.Partnumber.SupplierNumber), ComponentPlan.Suppliers.Item(SelectedItem.Partnumber.SupplierNumber).InHouse, False)
                row.Item("Document") = SelectedItem.Partnumber.Document
                row.Item("DocumentItem") = SelectedItem.Partnumber.DocumentItem
                row.Item("GRT") = SelectedItem.Partnumber.GRT
                row.Item("PTF") = SelectedItem.Partnumber.PlanningTimeFence
                row.Item("PC") = SelectedItem.Partnumber.PlanningCalendar
                row.Item("CP") = SelectedItem.Partnumber.CoverageProfile
                row.Item("Flags") = String.Join(",", ComponentPlan.Flags.Where(Function(w) SelectedItem.Flags.Contains(w.Key)).Select(Function(s) s.Value.Description).ToArray)
                row.Item("Comment") = SelectedItem.Partnumber.OrderingComment
                row.Item("WIP Date") = SelectedItem.WIPStockDate
                row.Item("WIP Stock") = SelectedItem.WIPStock
                row.Item("Delta Service Stock") = SelectedItem.DeltaServiceStock
                row.Item("Delta Random Stock") = SelectedItem.DeltaRandomStock
                row.Item("Delta Cost") = SelectedItem.DeltaStock * SelectedItem.Partnumber.UnitCost
                row.Item("Status") = StatusName(SelectedItem.Status(Delta.CurrentDate.Date))
                row.Item("Past Due") = SelectedItem.PastDue

                Dim current_date = Delta.CurrentDate.Date
                If DOH_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = SelectedItem.StockBalance(current_date)
                        Dim usage As Decimal = SelectedItem.AverageDailyDemand(current_date)
                        If usage = 0 Then
                            If new_stock > 0 Then
                                row.Item(current_date.ToString("MM/dd/yyyy")) = 9999
                            Else
                                row.Item(current_date.ToString("MM/dd/yyyy")) = 0
                            End If
                        Else
                            row.Item(current_date.ToString("MM/dd/yyyy")) = Math.Round(new_stock / usage, 1)
                        End If
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Cost_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = SelectedItem.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = new_stock * SelectedItem.Partnumber.UnitCost
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Status_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = SelectedItem.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = StatusName(SelectedItem.Status(current_date))
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Pieces_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = SelectedItem.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = new_stock
                        current_date = current_date.AddDays(1)
                    End While
                End If
            End If
        End If
    End Sub

    Private Sub LoadMainComponentPlan()
        LoadingScreen.Show()
        Try
            Dim production_plan As New ProductionPlan(global_horizon_date) 'SE LE AGREGA OTRO MES AL PLAN DE PRODUCCION PARA QUE EL MIN Y MAX DEL PLAN DE COMPONENTES SEA CORRECTAMENTE CALCULADO EN LOS ULTIMOS DIAS, DE LO CONTRARIO SE INTERPRETARA QUE NO HAY REQUERIMIENTOS FUTUROS
            Main_Component_Plan = New ComponentPlan(production_plan, global_horizon_date)
            LoadMainDatatable()

            Flags_cms.Items.Clear()
            For Each i In ComponentPlan.Flags
                Dim item As New ToolStripMenuItem
                item.Tag = i.Key
                item.Text = i.Value.Description
                item.CheckOnClick = True
                AddHandler item.Click, AddressOf Flags_cmsi_Click
                Flags_cms.Items.Add(item)
            Next
            LoadingScreen.Hide()
        Catch ex As Exception
            LoadingScreen.Hide()
            Main_Component_Plan = Nothing
            SelectedItem = Nothing
            ClearPartnumberData()
            FlashAlerts.ShowError("Error al generar el plan de componentes.")
        End Try
    End Sub

    'Private Sub LoadSingleComponentPlan(partnumber As String)
    '    LoadingScreen.Show()
    '    Try
    '        ComponentPlan.RefreshFlags()
    '        Flags_cms.Items.Clear()
    '        For Each i In ComponentPlan.Flags
    '            Dim item As New ToolStripMenuItem
    '            item.Tag = i.Key
    '            item.Text = i.Value.Description
    '            item.CheckOnClick = True
    '            AddHandler item.Click, AddressOf Flags_cmsi_Click
    '            Flags_cms.Items.Add(item)
    '        Next
    '        Dim production_plan As New ProductionPlan(global_horizon_date.AddDays(30)) 'SE LE AGREGA OTRO MES AL PLAN DE PRODUCCION PARA QUE EL MIN Y MAX DEL PLAN DE COMPONENTES SEA CORRECTAMENTE CALCULADO EN LOS ULTIMOS DIAS, DE LO CONTRARIO SE INTERPRETARA QUE NO HAY REQUERIMIENTOS FUTUROS
    '        Main_Component_Plan = New ComponentPlan(production_plan, partnumber, global_horizon_date)
    '        LoadComponentPlanItem(partnumber)
    '        Main_Component_Plan = Nothing
    '        LoadingScreen.Hide()
    '    Catch ex As Exception
    '        LoadingScreen.Hide()
    '        Main_Component_Plan = Nothing
    '        SelectedItem = Nothing
    '        ClearPartnumberData()
    '        FlashAlerts.ShowError("Error al generar el plan de componentes.")
    '    End Try
    'End Sub

    Private Sub UpdateJobUpdates()
        Dim update_date As Date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_TransitsJob_LastRunning", Date.MinValue))
        TransitsLastUpdate_lbl.Text = String.Format("Tránsitos: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 30 Then
            TransitsLastUpdate_lbl.BackColor = Color.Red
            TransitsLastUpdate_lbl.ForeColor = Color.White
        Else
            TransitsLastUpdate_lbl.BackColor = Color.Transparent
            TransitsLastUpdate_lbl.ForeColor = Color.DimGray
        End If

        update_date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_InternalOpenOrdersJob_LastRunning", Date.MinValue))
        OpenOrdersInternalLastUpdate_lbl.Text = String.Format("Ord. Abiertas Int: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 30 Then
            OpenOrdersInternalLastUpdate_lbl.BackColor = Color.Red
            OpenOrdersInternalLastUpdate_lbl.ForeColor = Color.White
        Else
            OpenOrdersInternalLastUpdate_lbl.BackColor = Color.Transparent
            OpenOrdersInternalLastUpdate_lbl.ForeColor = Color.DimGray
        End If

        update_date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_ExternalOpenOrdersJob_LastRunning", Date.MinValue))
        OpenOrdersExternalLastUpdate_lbl.Text = String.Format("Ord. Abiertas Ext: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 30 Then
            OpenOrdersExternalLastUpdate_lbl.BackColor = Color.Red
            OpenOrdersExternalLastUpdate_lbl.ForeColor = Color.White
        Else
            OpenOrdersExternalLastUpdate_lbl.BackColor = Color.Transparent
            OpenOrdersExternalLastUpdate_lbl.ForeColor = Color.DimGray
        End If

        update_date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_PlannedOrdersJob_LastRunning", Date.MinValue))
        PlannedOrdersLastUpdate_lbl.Text = String.Format("Ord. Planeadas: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 30 Then
            PlannedOrdersLastUpdate_lbl.BackColor = Color.Red
            PlannedOrdersLastUpdate_lbl.ForeColor = Color.White
        Else
            PlannedOrdersLastUpdate_lbl.BackColor = Color.Transparent
            PlannedOrdersLastUpdate_lbl.ForeColor = Color.DimGray
        End If

        update_date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_SupplierAttainmentJob_LastRunning", Date.MinValue))
        CallOffLastUpdate_lbl.Text = String.Format("Call Off Attain: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 30 Then
            CallOffLastUpdate_lbl.BackColor = Color.Red
            CallOffLastUpdate_lbl.ForeColor = Color.White
        Else
            CallOffLastUpdate_lbl.BackColor = Color.Transparent
            CallOffLastUpdate_lbl.ForeColor = Color.DimGray
        End If

        update_date = CDate(SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", "SYS_BOMJob_LastRunning", Date.MinValue))
        BOMLastUpdate_lbl.Text = String.Format("Bill Of Mat: {0}", update_date.ToString("M/d/yy hh:mm tt"))
        If DateDiff(DateInterval.Day, update_date, Delta.CurrentDate) >= 2 Then
            BOMLastUpdate_lbl.BackColor = Color.Red
            BOMLastUpdate_lbl.ForeColor = Color.White
        Else
            BOMLastUpdate_lbl.BackColor = Color.Transparent
            BOMLastUpdate_lbl.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub LoadMainDatatable()
        FormatComponentPlanGrid()
        ComponentPlan_dgv.DataSource = Nothing
        Main_DT = New DataTable("ComponentPlan")
        Main_DT.Columns.Add("Partnumber", GetType(String))
        Main_DT.Columns.Add("Description", GetType(String))
        Main_DT.Columns.Add("MRP", GetType(String))
        Main_DT.Columns.Add("Owner", GetType(String))
        Main_DT.Columns.Add("UoM", GetType(String))
        Main_DT.Columns.Add("SmkLocation", GetType(String))
        Main_DT.Columns.Add("RoundingValue", GetType(Decimal))
        Main_DT.Columns.Add("UnitCost", GetType(Decimal))
        Main_DT.Columns.Add("SupplierNumber", GetType(String))
        Main_DT.Columns.Add("SupplierName", GetType(String))
        Main_DT.Columns.Add("Lean Ordering", GetType(Boolean))
        Main_DT.Columns.Add("InHouse", GetType(Boolean))
        Main_DT.Columns.Add("Document", GetType(String))
        Main_DT.Columns.Add("DocumentItem", GetType(String))
        Main_DT.Columns.Add("GRT", GetType(Integer))
        Main_DT.Columns.Add("PTF", GetType(Integer))
        Main_DT.Columns.Add("PC", GetType(String))
        Main_DT.Columns.Add("CP", GetType(String))
        Main_DT.Columns.Add("Flags", GetType(String))
        Main_DT.Columns.Add("Comment", GetType(String))
        Main_DT.Columns.Add("Daily Usage", GetType(Decimal))
        Main_DT.Columns.Add("Days of Coverage", GetType(Decimal))
        Main_DT.Columns.Add("Next Transit Quantity", GetType(Decimal))
        Main_DT.Columns.Add("Next Transit Date", GetType(Date))
        Main_DT.Columns.Add("Next Transit Delivery", GetType(String))
        Main_DT.Columns.Add("WIP Stock", GetType(Decimal))
        Main_DT.Columns.Add("WIP Date", GetType(Date))
        Main_DT.Columns.Add("Delta Service Stock", GetType(Decimal))
        Main_DT.Columns.Add("Delta Random Stock", GetType(Decimal))
        Main_DT.Columns.Add("Delta Cost", GetType(Decimal))
        Main_DT.Columns.Add("Status", GetType(String))
        Main_DT.Columns.Add("Past Due", GetType(Decimal))
        Dim day As Date = Delta.CurrentDate.Date
        While day <= horizon_main_forecast.Date
            If Status_rb.Checked Then
                Main_DT.Columns.Add(day.ToString("MM/dd/yyyy"), GetType(String))
            Else
                Main_DT.Columns.Add(day.ToString("MM/dd/yyyy"), GetType(Decimal))
            End If
            day = day.AddDays(1)
        End While
        Main_DT.PrimaryKey = {Main_DT.Columns("Partnumber")}

        For Each part In Main_Component_Plan.Items
            If selected_mrps.Contains(part.Value.Partnumber.MRP) Then
                Dim row As DataRow = Main_DT.NewRow
                row.Item("Partnumber") = part.Value.Partnumber.Partnumber
                row.Item("Description") = part.Value.Partnumber.Description
                row.Item("MRP") = part.Value.Partnumber.MRP
                row.Item("Owner") = If(ComponentPlan.MRPOwners.ContainsKey(part.Value.Partnumber.MRP), ComponentPlan.MRPOwners.Item(part.Value.Partnumber.MRP), "S/D")
                row.Item("UoM") = part.Value.Partnumber.UoM
                row.Item("SmkLocation") = part.Value.SmkLocation
                row.Item("RoundingValue") = part.Value.Partnumber.OrderStdPack
                row.Item("UnitCost") = part.Value.Partnumber.UnitCost
                row.Item("SupplierNumber") = part.Value.Partnumber.SupplierNumber
                row.Item("SupplierName") = part.Value.Partnumber.SupplierName
                row.Item("Lean Ordering") = If(ComponentPlan.Suppliers.ContainsKey(part.Value.Partnumber.SupplierNumber), ComponentPlan.Suppliers.Item(part.Value.Partnumber.SupplierNumber).LeanOrdering, False)
                row.Item("InHouse") = If(ComponentPlan.Suppliers.ContainsKey(part.Value.Partnumber.SupplierNumber), ComponentPlan.Suppliers.Item(part.Value.Partnumber.SupplierNumber).InHouse, False)
                row.Item("Document") = part.Value.Partnumber.Document
                row.Item("DocumentItem") = part.Value.Partnumber.DocumentItem
                row.Item("GRT") = part.Value.Partnumber.GRT
                row.Item("PTF") = part.Value.Partnumber.PlanningTimeFence
                row.Item("PC") = part.Value.Partnumber.PlanningCalendar
                row.Item("CP") = part.Value.Partnumber.CoverageProfile
                row.Item("Flags") = String.Join(",", ComponentPlan.Flags.Where(Function(w) part.Value.Flags.Contains(w.Key)).Select(Function(s) s.Value.Description).ToArray)
                row.Item("Comment") = part.Value.Partnumber.OrderingComment
                row.Item("Daily Usage") = part.Value.AverageDailyDemand(Delta.CurrentDate.Date)
                row.Item("Days of Coverage") = part.Value.DaysOfCoverage(part.Value.StockBalance(Delta.CurrentDate.Date), Delta.CurrentDate)
                row.Item("Next Transit Quantity") = part.Value.NextTransitQuantity()
                row.Item("Next Transit Date") = part.Value.NextTransitDate()
                row.Item("Next Transit Delivery") = part.Value.NextTransitDelivery()
                row.Item("WIP Date") = part.Value.WIPStockDate
                row.Item("WIP Stock") = part.Value.WIPStock
                row.Item("Delta Random Stock") = part.Value.DeltaRandomStock
                row.Item("Delta Service Stock") = part.Value.DeltaServiceStock
                row.Item("Delta Cost") = part.Value.DeltaStock * part.Value.Partnumber.UnitCost
                row.Item("Status") = StatusName(part.Value.Status(Delta.CurrentDate.Date))
                row.Item("Past Due") = part.Value.PastDue

                Dim current_date = Delta.CurrentDate.Date
                Dim has_requirement As Boolean = False
                If DOH_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = part.Value.StockBalance(current_date)
                        Dim usage As Decimal = part.Value.AverageDailyDemand(current_date)
                        If usage = 0 Then
                            If new_stock > 0 Then
                                row.Item(current_date.ToString("MM/dd/yyyy")) = 9999
                            Else
                                row.Item(current_date.ToString("MM/dd/yyyy")) = 0
                            End If
                        Else
                            row.Item(current_date.ToString("MM/dd/yyyy")) = Math.Round(new_stock / usage, 1)
                        End If
                        If new_stock > 0 OrElse (part.Value.Items.ContainsKey(current_date.Date) AndAlso part.Value.Items(current_date.Date).Requirement > 0) Then has_requirement = True 'VALIDAR NUMEROS DE PARTE SIN REQUERIMIENTO O INVENTARIO
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Cost_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = part.Value.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = new_stock * part.Value.Partnumber.UnitCost
                        If new_stock > 0 OrElse (part.Value.Items.ContainsKey(current_date.Date) AndAlso part.Value.Items(current_date.Date).Requirement > 0) Then has_requirement = True 'VALIDAR NUMEROS DE PARTE SIN REQUERIMIENTO O INVENTARIO
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Status_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = part.Value.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = StatusName(part.Value.Status(current_date))
                        If new_stock > 0 OrElse (part.Value.Items.ContainsKey(current_date.Date) AndAlso part.Value.Items(current_date.Date).Requirement > 0) Then has_requirement = True 'VALIDAR NUMEROS DE PARTE SIN REQUERIMIENTO O INVENTARIO
                        current_date = current_date.AddDays(1)
                    End While
                ElseIf Pieces_rb.Checked Then
                    While current_date.Date <= horizon_main_forecast.Date
                        Dim new_stock As Decimal = part.Value.StockBalance(current_date)
                        row.Item(current_date.ToString("MM/dd/yyyy")) = new_stock
                        If new_stock > 0 OrElse (part.Value.Items.ContainsKey(current_date.Date) AndAlso part.Value.Items(current_date.Date).Requirement > 0) Then has_requirement = True 'VALIDAR NUMEROS DE PARTE SIN REQUERIMIENTO O INVENTARIO
                        current_date = current_date.AddDays(1)
                    End While
                End If
                If has_requirement OrElse part.Value.TransitsSum > 0 OrElse part.Value.OrdersSum > 0 Then
                    part.Value.IsActive = True
                    Main_DT.Rows.Add(row)
                End If
                'OMITIR NUMEROS DE PARTE SIN REQUERIMIENTO,SIN INVENTARIO Y SIN ORDENES
            End If
        Next
        ComponentPlan_dgv.DataSource = Main_DT.DefaultView
    End Sub
    'Private Function ColumnDefaultState(name As String) As Boolean
    '    If My.Settings.ComponentPlan_ColumnsLayout.ContainsKey(name) Then
    '        Return My.Settings.ComponentPlan_ColumnsLayout.Item(name)
    '    Else
    '        Return True
    '    End If
    'End Function

    Private Sub FormatComponentPlanGrid()
        With ComponentPlan_dgv
            .DataSource = Nothing
            .Columns.Clear()
            Dim cs As New DataGridViewCellStyle
            cs.Alignment = DataGridViewContentAlignment.TopRight
            cs.Format = "N1"
            cs.Font = New Font("Calibri", 9, FontStyle.Regular)
            cs.SelectionBackColor = Color.FromArgb(171, 178, 185)

            Dim partnumber_column As New DataGridViewLinkColumn
            partnumber_column.HeaderText = "No. de Parte"
            partnumber_column.DataPropertyName = "Partnumber"
            partnumber_column.Name = "Partnumber"
            partnumber_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            partnumber_column.CellTemplate.Style.BackColor = Color.FromArgb(43, 81, 120)
            partnumber_column.DefaultCellStyle.ForeColor = Color.White
            partnumber_column.DefaultCellStyle.Font = New Font("Calibri", 11, FontStyle.Bold)
            partnumber_column.Width = 70
            partnumber_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(127, 179, 213)
            partnumber_column.ActiveLinkColor = Color.White
            partnumber_column.VisitedLinkColor = Color.White
            partnumber_column.LinkColor = Color.White
            partnumber_column.SortMode = DataGridViewColumnSortMode.Automatic
            partnumber_column.Frozen = True

            Dim description_column As New DataGridViewTextBoxColumn
            description_column.HeaderText = "Descripcion"
            description_column.DataPropertyName = "Description"
            description_column.Name = "Description"
            description_column.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            description_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            description_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            description_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            description_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            description_column.Width = 120
            description_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim mrp_column As New DataGridViewTextBoxColumn
            mrp_column.HeaderText = "MRP"
            mrp_column.DataPropertyName = "MRP"
            mrp_column.Name = "MRP"
            mrp_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            mrp_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            mrp_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            mrp_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            mrp_column.Width = 40
            mrp_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            mrp_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim owner_column As New DataGridViewTextBoxColumn
            owner_column.HeaderText = "Dueño"
            owner_column.DataPropertyName = "Owner"
            owner_column.Name = "Owner"
            owner_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            owner_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            owner_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            owner_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            owner_column.Width = 60
            owner_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            owner_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim uom_column As New DataGridViewTextBoxColumn
            uom_column.HeaderText = "Unidad"
            uom_column.DataPropertyName = "UoM"
            uom_column.Name = "UoM"
            uom_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            uom_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            uom_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            uom_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            uom_column.Width = 45
            uom_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            uom_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


            Dim smk_column As New DataGridViewTextBoxColumn
            smk_column.HeaderText = "Local"
            smk_column.DataPropertyName = "SmkLocation"
            smk_column.Name = "SmkLocation"
            smk_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            smk_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            smk_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            smk_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            smk_column.Width = 45
            smk_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            smk_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim stdpack_column As New DataGridViewTextBoxColumn
            stdpack_column.HeaderText = "Std. Pack"
            stdpack_column.DataPropertyName = "RoundingValue"
            stdpack_column.Name = "RoundingValue"
            stdpack_column.DefaultCellStyle.Format = "N1"
            stdpack_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            stdpack_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            stdpack_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            stdpack_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            stdpack_column.Width = 60
            stdpack_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            stdpack_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim unitcost_column As New DataGridViewTextBoxColumn
            unitcost_column.HeaderText = "Costo Unitario"
            unitcost_column.DataPropertyName = "UnitCost"
            unitcost_column.Name = "UnitCost"
            unitcost_column.DefaultCellStyle.Format = "C6"
            unitcost_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            unitcost_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            unitcost_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            unitcost_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            unitcost_column.Width = 50
            unitcost_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            unitcost_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim supplierno_columnm As New DataGridViewTextBoxColumn
            supplierno_columnm.HeaderText = "No. de Proveedor"
            supplierno_columnm.DataPropertyName = "SupplierNumber"
            supplierno_columnm.Name = "SupplierNumber"
            supplierno_columnm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            supplierno_columnm.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            supplierno_columnm.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            supplierno_columnm.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            supplierno_columnm.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            supplierno_columnm.Width = 80
            supplierno_columnm.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim suppliername_columnm As New DataGridViewTextBoxColumn
            suppliername_columnm.HeaderText = "Nombre de Proveedor"
            suppliername_columnm.DataPropertyName = "SupplierName"
            suppliername_columnm.Name = "SupplierName"
            suppliername_columnm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            suppliername_columnm.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            suppliername_columnm.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            suppliername_columnm.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            suppliername_columnm.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            suppliername_columnm.Width = 120
            suppliername_columnm.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

            Dim lean_column As New DataGridViewCheckBoxColumn
            lean_column.HeaderText = "Lean"
            lean_column.DataPropertyName = "Lean Ordering"
            lean_column.Name = "Lean Ordering"
            lean_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            lean_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            lean_column.Width = 60
            lean_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

            Dim inhouse_column As New DataGridViewCheckBoxColumn
            inhouse_column.HeaderText = "In House"
            inhouse_column.DataPropertyName = "InHouse"
            inhouse_column.Name = "InHouse"
            inhouse_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            inhouse_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            inhouse_column.Width = 60
            inhouse_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

            Dim document_column As New DataGridViewTextBoxColumn
            document_column.HeaderText = "T(SA)"
            document_column.DataPropertyName = "Document"
            document_column.Name = "Document"
            document_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            document_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            document_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            document_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            document_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            document_column.Width = 80
            document_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim documentitem_column As New DataGridViewTextBoxColumn
            documentitem_column.HeaderText = "Item"
            documentitem_column.DataPropertyName = "DocumentItem"
            documentitem_column.Name = "DocumentItem"
            documentitem_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            documentitem_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            documentitem_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            documentitem_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            documentitem_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            documentitem_column.Width = 55
            documentitem_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim grt_column As New DataGridViewTextBoxColumn
            grt_column.HeaderText = "GRT"
            grt_column.DataPropertyName = "GRT"
            grt_column.Name = "GRT"
            grt_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grt_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            grt_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            grt_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            grt_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            grt_column.Width = 40
            grt_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim ptf_column As New DataGridViewTextBoxColumn
            ptf_column.HeaderText = "PTF"
            ptf_column.DataPropertyName = "PTF"
            ptf_column.Name = "PTF"
            ptf_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ptf_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            ptf_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            ptf_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            ptf_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            ptf_column.Width = 40
            ptf_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim pc_column As New DataGridViewTextBoxColumn
            pc_column.HeaderText = "Plang. Cal."
            pc_column.DataPropertyName = "PC"
            pc_column.Name = "PC"
            pc_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            pc_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            pc_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            pc_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            pc_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            pc_column.Width = 40
            pc_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim cp_column As New DataGridViewTextBoxColumn
            cp_column.HeaderText = "Cvg. Prof."
            cp_column.DataPropertyName = "CP"
            cp_column.Name = "CP"
            cp_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cp_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            cp_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            cp_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            cp_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            cp_column.Width = 40
            cp_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim flag_column As New DataGridViewTextBoxColumn
            flag_column.HeaderText = "Banderas"
            flag_column.DataPropertyName = "Flags"
            flag_column.Name = "Banderas"
            flag_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            flag_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            flag_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            flag_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            flag_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            flag_column.Width = 70
            flag_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim comment_column As New DataGridViewTextBoxColumn
            comment_column.HeaderText = "Comentario"
            comment_column.DataPropertyName = "Comment"
            comment_column.Name = "Comentario"
            comment_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            comment_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            comment_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            comment_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            comment_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)
            comment_column.Width = 120
            comment_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim usage_column As New DataGridViewTextBoxColumn
            usage_column.HeaderText = "Uso Diario"
            usage_column.DataPropertyName = "Daily Usage"
            usage_column.Name = "Daily Usage"
            usage_column.DefaultCellStyle = cs
            usage_column.Width = 60
            usage_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            usage_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            usage_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            usage_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            usage_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim docv_column As New DataGridViewTextBoxColumn
            docv_column.HeaderText = "Dias Cubiertos"
            docv_column.DataPropertyName = "Days of Coverage"
            docv_column.Name = "Days of Coverage"
            docv_column.DefaultCellStyle = cs
            docv_column.Width = 60
            docv_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            docv_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            docv_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            docv_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            docv_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim transit_date_column As New DataGridViewTextBoxColumn
            transit_date_column.HeaderText = "Próximo Tránsito"
            transit_date_column.DataPropertyName = "Next Transit Date"
            transit_date_column.Name = "Next Transit Date"
            transit_date_column.DefaultCellStyle.Format = "M"
            transit_date_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            transit_date_column.Width = 60
            transit_date_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            transit_date_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            transit_date_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            transit_date_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            transit_date_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim transit_column As New DataGridViewTextBoxColumn
            transit_column.HeaderText = "Tránsito"
            transit_column.DataPropertyName = "Next Transit Quantity"
            transit_column.Name = "Next Transit Quantity"
            transit_column.DefaultCellStyle = cs
            transit_column.Width = 60
            transit_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            transit_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            transit_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            transit_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            transit_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim transit_delivery_column As New DataGridViewTextBoxColumn
            transit_delivery_column.HeaderText = "Delivery"
            transit_delivery_column.DataPropertyName = "Next Transit Delivery"
            transit_delivery_column.Name = "Next Transit Delivery"
            transit_delivery_column.Width = 60
            transit_delivery_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            transit_delivery_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            transit_delivery_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            transit_delivery_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            transit_delivery_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim wip_date_column As New DataGridViewTextBoxColumn
            wip_date_column.HeaderText = "Fecha WIP"
            wip_date_column.DataPropertyName = "WIP Date"
            wip_date_column.Name = "WIP Date"
            wip_date_column.DefaultCellStyle.Format = "M"
            wip_date_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            wip_date_column.Width = 60
            wip_date_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            wip_date_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            wip_date_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            wip_date_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            wip_date_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)


            Dim dailyusage_column As New DataGridViewTextBoxColumn
            dailyusage_column.HeaderText = "Uso Diario"
            dailyusage_column.DataPropertyName = "Daily Usage"
            dailyusage_column.Name = "Daily Usage"
            dailyusage_column.DefaultCellStyle = cs
            dailyusage_column.Width = 60
            dailyusage_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dailyusage_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            dailyusage_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            dailyusage_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            dailyusage_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim wip_column As New DataGridViewTextBoxColumn
            wip_column.HeaderText = "Inventario WIP"
            wip_column.DataPropertyName = "WIP Stock"
            wip_column.Name = "WIP Stock"
            wip_column.DefaultCellStyle = cs
            wip_column.Width = 60
            wip_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            wip_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            wip_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            wip_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            wip_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim stock_column As New DataGridViewTextBoxColumn
            stock_column.HeaderText = "Inventario Reserva"
            stock_column.DataPropertyName = "Delta Random Stock"
            stock_column.Name = "Delta Random Stock"
            stock_column.DefaultCellStyle = cs
            stock_column.Width = 60
            stock_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            stock_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            stock_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            stock_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            stock_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim stock_service_column As New DataGridViewTextBoxColumn
            stock_service_column.HeaderText = "Inventario Servicio"
            stock_service_column.DataPropertyName = "Delta Service Stock"
            stock_service_column.Name = "Delta Service Stock"
            stock_service_column.DefaultCellStyle = cs
            stock_service_column.Width = 60
            stock_service_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            stock_service_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            stock_service_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            stock_service_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            stock_service_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim cost_column As New DataGridViewTextBoxColumn
            cost_column.HeaderText = "Costo"
            cost_column.DataPropertyName = "Delta Cost"
            cost_column.Name = "Delta Cost"
            cost_column.DefaultCellStyle.Format = "C1"
            cost_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cost_column.Width = 60
            cost_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            cost_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            cost_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            cost_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            cost_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim status_column As New DataGridViewTextBoxColumn
            status_column.HeaderText = "Estatus"
            status_column.DataPropertyName = "Status"
            status_column.Name = "Status"
            status_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            status_column.Width = 80
            status_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            status_column.CellTemplate.Style.BackColor = Color.FromArgb(213, 216, 220)
            status_column.DefaultCellStyle.ForeColor = Color.FromArgb(23, 32, 42)
            status_column.DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
            status_column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 101, 115)

            Dim pastdue_column As New DataGridViewTextBoxColumn
            pastdue_column.HeaderText = "Past Due"
            pastdue_column.DataPropertyName = "Past Due"
            pastdue_column.Name = "Past Due"
            pastdue_column.DefaultCellStyle = cs
            pastdue_column.Width = 80
            pastdue_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns.Add(partnumber_column)
            .Columns.Add(description_column)
            .Columns.Add(mrp_column)
            .Columns.Add(owner_column)
            .Columns.Add(uom_column)
            .Columns.Add(smk_column)
            .Columns.Add(stdpack_column)
            .Columns.Add(unitcost_column)
            .Columns.Add(supplierno_columnm)
            .Columns.Add(suppliername_columnm)
            .Columns.Add(lean_column)
            .Columns.Add(inhouse_column)
            .Columns.Add(document_column)
            .Columns.Add(documentitem_column)
            .Columns.Add(grt_column)
            .Columns.Add(ptf_column)
            .Columns.Add(pc_column)
            .Columns.Add(cp_column)
            .Columns.Add(flag_column)
            .Columns.Add(comment_column)
            .Columns.Add(dailyusage_column)
            .Columns.Add(docv_column)
            .Columns.Add(transit_date_column)
            .Columns.Add(transit_column)
            .Columns.Add(transit_delivery_column)
            .Columns.Add(wip_date_column)
            .Columns.Add(wip_column)
            .Columns.Add(stock_column)
            .Columns.Add(stock_service_column)
            .Columns.Add(cost_column)
            .Columns.Add(status_column)
            .Columns.Add(pastdue_column)

            Dim current_date As Date = Delta.CurrentDate
            While current_date.Date <= horizon_main_forecast.Date
                Dim new_date_col As New DataGridViewTextBoxColumn
                new_date_col.HeaderText = current_date.ToString("MM/dd")
                new_date_col.DataPropertyName = current_date.ToString("MM/dd/yyyy")
                new_date_col.Name = current_date.ToString("MM/dd/yyyy")
                If Status_rb.Checked Then
                    new_date_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf Cost_rb.Checked Then
                    new_date_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    new_date_col.DefaultCellStyle.Format = "C1"
                Else
                    new_date_col.DefaultCellStyle = cs
                End If
                new_date_col.Width = 80
                new_date_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(new_date_col)
                current_date = current_date.AddDays(1)
            End While

            Dim column_setting As String = User.Current.GetSetting("CR_ComponentPlan_GeneralDataGridView")
            If column_setting <> "" Then
                For Each col As ColumnStatus In Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of ColumnStatus))(column_setting)
                    If .Columns.Contains(col.Name) Then
                        .Columns.Item(col.Name).Visible = col.Visible
                        .Columns.Item(col.Name).DisplayIndex = If(col.DisplayIndex >= 32, .Columns.Item(col.Name).DisplayIndex, col.DisplayIndex)
                    End If
                Next
            End If
            partnumber_column.Visible = True
        End With
    End Sub

    Private Class ColumnStatus
        Public Sub New(name As String, display_index As Integer, visible As Boolean)
            Me.Name = name
            Me.DisplayIndex = display_index
            Me.Visible = visible
        End Sub
        Public Property Visible As Boolean
        Public Property DisplayIndex As Integer
        Public Property Name As String
    End Class

    Private Sub ComponentPlan_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles ComponentPlan_dgv.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso IsDate(ComponentPlan_dgv.Columns(e.ColumnIndex).Name) AndAlso (Critical_chk.Checked OrElse Minimum_chk.Checked OrElse Normal_chk.Checked OrElse Excess_chk.Checked OrElse Obsolete_chk.Checked) Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            Dim status = Main_Component_Plan.Items.Item(ComponentPlan_dgv.Rows(e.RowIndex).Cells("Partnumber").Value).Status(CDate(ComponentPlan_dgv.Columns(e.ColumnIndex).Name))
            If Critical_chk.Checked AndAlso status = ComponentPlanItemStatus.Critical Then
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
            ElseIf Minimum_chk.Checked AndAlso status = ComponentPlanItemStatus.Minimum Then
                e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
            ElseIf Normal_chk.Checked AndAlso status = ComponentPlanItemStatus.Normal Then
                e.Graphics.FillRectangle(Brushes.YellowGreen, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
            ElseIf Excess_chk.Checked AndAlso status = ComponentPlanItemStatus.Excess Then
                e.Graphics.FillRectangle(Brushes.DarkSlateBlue, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
            ElseIf Obsolete_chk.Checked AndAlso status = ComponentPlanItemStatus.Obsolete Then
                e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        If Main_Component_Plan IsNot Nothing Then
            Dim col_list As New List(Of ColumnStatus)
            For Each col As DataGridViewColumn In ComponentPlan_dgv.Columns
                col_list.Add(New ColumnStatus(col.Name, col.DisplayIndex, col.Visible))
            Next
            User.Current.SaveSetting("CR_ComponentPlan_GeneralDataGridView", col_list)
        End If
        Dim background As New FadeBackground()
        Dim mrp_selector As New CR_MRPSelectDialog
        mrp_selector.Horizon_dtp.MaxDate = global_horizon_date
        mrp_selector.SelectedDate = horizon_main_forecast
        mrp_selector.SelectedMRPs = selected_mrps
        mrp_selector.MRPCs = MRPCs
        background.Show()
        If mrp_selector.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ClearPartnumberData()
            horizon_main_forecast = mrp_selector.SelectedDate.Date
            selected_mrps = mrp_selector.SelectedMRPs
            background.Close()
            LoadMainComponentPlan()
        Else
            background.Close()
        End If
        background.Dispose()
        mrp_selector.Dispose()
    End Sub

    Private Sub Critical_chk_CheckStateChanged(sender As Object, e As EventArgs) Handles Normal_chk.CheckStateChanged, Minimum_chk.CheckStateChanged, Excess_chk.CheckStateChanged, Critical_chk.CheckStateChanged, Obsolete_chk.CheckStateChanged
        ComponentPlan_dgv.Invalidate()
    End Sub

    Private Sub FilterWeeks_tbr_Scroll(sender As Object, e As EventArgs) Handles FilterWeeks_tbr.Scroll
        If FilterWeeks_tbr.Value = 21 Then
            FilterWeeks_lbl.Text = "Semanas: Todo"
        Else
            FilterWeeks_lbl.Text = "Semanas: " & FilterWeeks_tbr.Value
        End If
    End Sub

    Private Sub FilterApply_btn_Click(sender As Object, e As EventArgs) Handles FilterApply_btn.Click
        LoadingScreen.Show()
        Dim selected_status As ComponentPlanItemStatus
        Select Case FilterStatus_cbo.SelectedItem
            Case "Criticos"
                selected_status = ComponentPlanItemStatus.Critical
            Case "Minimos"
                selected_status = ComponentPlanItemStatus.Minimum
            Case "Normales"
                selected_status = ComponentPlanItemStatus.Normal
            Case "Excesos"
                selected_status = ComponentPlanItemStatus.Excess
            Case "Obsoletos"
                selected_status = ComponentPlanItemStatus.Obsolete
            Case Else
                Main_DT.DefaultView.RowFilter = ""
                ComponentPlan_dgv.DefaultRowFilter = "" 'ES NECESARIO ESTABLECER ESTA PROPIEDAD CON EL MISMO FILTRO PARA QUE EL DATAGRIDVIEWWITHFILTERS NO ELIMINE ESTA CONDICION CON CADA FILTRO APLICADO POR COLUMNA
                LoadingScreen.Hide()
                Exit Sub
        End Select

        Dim filtered_partnumbers As New ArrayList
        Dim filter_date As Date = If(FilterWeeks_tbr.Value = 21, global_horizon_date, Delta.CurrentDate.AddDays(FilterWeeks_tbr.Value * 7))
        For Each item In Main_Component_Plan.Items
            For Each item_date In item.Value.Items
                If item_date.Value.Date >= Delta.CurrentDate.Date AndAlso item_date.Value.Date.Date <= filter_date.Date AndAlso item.Value.Status(item_date.Value.Date) = selected_status Then
                    filtered_partnumbers.Add(item.Value.Partnumber.Partnumber)
                    Exit For 'CON QUE AL MENOS UN ITEM CUMPLA LA CONDICION NO ES NECESARIO SEGUIR EVALUANDO LOS DEMAS
                End If
            Next
        Next
        Dim filter_string As String = String.Format("Partnumber IN ('{0}')", String.Join("','", filtered_partnumbers.ToArray))
        Main_DT.DefaultView.RowFilter = filter_string
        ComponentPlan_dgv.DefaultRowFilter = filter_string 'ES NECESARIO ESTABLECER ESTA PROPIEDAD CON EL MISMO FILTRO PARA QUE EL DATAGRIDVIEWWITH FILTERS NO ELIMINE ESTA CONDICION CON CADA FILTRO APLICADO POR COLUMNA
        LoadingScreen.Hide()
    End Sub

    Private Sub ComponentPlan_dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ComponentPlan_dgv.CellContentDoubleClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 AndAlso Main_Component_Plan IsNot Nothing Then
            LoadComponentPlanItem(ComponentPlan_dgv.Rows(e.RowIndex).Cells("Partnumber").Value)
        End If
    End Sub
#Region "No de Parte"
    Private Sub ClearPartnumberData()
        Flags_flp.Controls.Clear()
        SelectedItem = Nothing
        QualityStock_lbl.Text = ""
        WIPQuantity_lbl.Text = ""
        WIPDate_lbl.Text = ""
        Status_lbl.Text = ""
        Stock_lbl.Text = ""
        Cost_lbl.Text = ""
        DOH_lbl.Text = ""
        PastDueOrders_lbl.Text = ""
        Transits_lbl.Text = ""
        Partnumber_txt.Text = ""
        Description_lbl.Text = ""
        MRP_lbl.Text = ""
        StdPack_lbl.Text = ""
        MOQ_lbl.Text = ""
        UnitCost_lbl.Text = ""
        SupplierNumber_lbl.Text = ""
        SupplierName_lbl.Text = ""
        DocumentItem_lbl.Text = ""
        PTF_lbl.Text = ""
        GRT_lbl.Text = ""
        PlanningCalendar_lbl.Text = ""
        CoverageProfile_lbl.Text = ""
        SupplierResponseTime_lbl.Text = ""
        Owner_lbl.Text = ""
        DailyUsage_lbl.Text = ""
        BOMIssueFactor_lbl.Text = ""
        Fix_chk.CheckState = CheckState.Indeterminate
        MRP2_chk.CheckState = CheckState.Indeterminate
        Sensitive_chk.CheckState = CheckState.Indeterminate
        LeanOrdering_lbl.Visible = False
        InHouse_lbl.Visible = False
        For Each s In Forecast_chrt.Series
            s.Points.Clear()
        Next
        PartnumberRequirement_dgv.DataSource = Nothing
        PartnumberForecast_dgv.DataSource = Nothing

        If PartnumberTransits_dgv.DataSource IsNot Nothing Then
            CType(PartnumberTransits_dgv.DataSource, DataTable).Rows.Clear()
            CType(PartnumberOpenOrders_dgv.DataSource, DataTable).Rows.Clear()
            CType(PartnumberPlannedOrders_dgv.DataSource, DataTable).Rows.Clear()

            Transits_tab.Text = String.Format("Tránsitos ({0})", PartnumberTransits_dgv.Rows.Count)
            OpenOrders_tab.Text = String.Format("Órdenes Abiertas ({0})", PartnumberOpenOrders_dgv.Rows.Count)
            PlannedOrders_tab.Text = String.Format("Órdenes Planeadas ({0})", PartnumberPlannedOrders_dgv.Rows.Count)
            Promises_tab.Text = String.Format("Promesas ({0})", PartnumberPromises_dgv.Rows.Count)
        End If
        Comment_rtb.Clear()
        SelectItemUpdate_lbl.Text = ""
        SelectItemUpdate_lbl.BackColor = Color.Transparent
        LastConsumption_lbl.Text = ""
        LastConsumption_lbl.BackColor = Color.Transparent
        QuickTasks_flp.Controls.Clear()
    End Sub


    Private Sub SaveComment()
        If SelectedItem IsNot Nothing Then
            If SQL.Current.Update("Sys_RawMaterial", "OrderingComment", Comment_rtb.Text, "Partnumber", SelectedItem.Partnumber.Partnumber) Then
                SelectedItem.Partnumber.OrderingComment = Comment_rtb.Text
            End If
        End If
    End Sub

    Private Sub ShowFlags()
        Flags_flp.Controls.Clear()
        For Each flag In SelectedItem.Flags
            Dim flag_lbl As New Label
            flag_lbl.Text = ComponentPlan.Flags.Item(flag).Description
            flag_lbl.ForeColor = Color.White
            flag_lbl.BackColor = ComponentPlan.Flags.Item(flag).Color
            flag_lbl.Margin = New Padding(5, 5, 0, 0)
            flag_lbl.Padding = New Padding(5, 2, 5, 2)
            flag_lbl.AutoSize = True
            flag_lbl.TextAlign = ContentAlignment.MiddleCenter
            Flags_flp.Controls.Add(flag_lbl)
        Next
    End Sub

    Private Sub LoadComponentPlanItem(partnumber As String)
        LoadingScreen.Show()
        SaveComment() 'GUARDAR COMENTARIO ANTES DE CAMBIAR DE NP
        ClearPartnumberData()
        Main_Component_Plan.RefreshPartnumber(partnumber, global_horizon_date)
        SelectedItem = Main_Component_Plan.Items.Item(partnumber)
        SelectedItem.RefreshQuickTasks()
        ShowFlags()
        RefreshItemUpdatingTime()
        RefreshSelectedItemDataRow()
        With SelectedItem
            Comment_rtb.Text = .Partnumber.OrderingComment
            Status_lbl.Text = StatusName(.Status(Delta.CurrentDate))
            WIPQuantity_lbl.Text = String.Format("{0} {1}", FormatNumber(.WIPStock, 1), .Partnumber.UoM.ToString)
            WIPDate_lbl.Text = .WIPStockDate.ToString("MM/dd/yy")
            Stock_lbl.Text = String.Format("{0} {1}", FormatNumber(.DeltaStock, 1), .Partnumber.UoM.ToString)
            QualityStock_lbl.Text = String.Format("{0} {1}", FormatNumber(.QualityStock, 1), .Partnumber.UoM.ToString)
            Cost_lbl.Text = FormatCurrency(.DeltaStock * .Partnumber.UnitCost, 1)
            DOH_lbl.Text = If(.AverageDailyDemand(Delta.CurrentDate) = 0, "OBSOLETO", FormatNumber(.DeltaStock / .AverageDailyDemand(Delta.CurrentDate), 1))
            PastDueOrders_lbl.Text = .PastDueOrdersCount
            Transits_lbl.Text = String.Format("{0} {1}", FormatNumber(.Items.Sum(Function(s) s.Value.SumTransit), 1), .Partnumber.UoM.ToString)
            DailyUsage_lbl.Text = FormatNumber(.AverageDailyDemand(Delta.CurrentDate), 1)
            BOMIssueFactor_lbl.Text = .Partnumber.BOMIssueFactor
            With .Partnumber
                Partnumber_txt.Text = .Partnumber
                Description_lbl.Text = .Description
                MRP_lbl.Text = .MRP
                StdPack_lbl.Text = FormatNumber(.RoundingValue, 1)
                MOQ_lbl.Text = FormatNumber(.MOQ, 1)
                UnitCost_lbl.Text = FormatCurrency(.UnitCost, 6)
                SupplierNumber_lbl.Text = .SupplierNumber
                SupplierName_lbl.Text = .SupplierName
                DocumentItem_lbl.Text = If(.Document = "", "", String.Format("{0} ({1})", .Document, .DocumentItem))
                PTF_lbl.Text = .PlanningTimeFence
                GRT_lbl.Text = .GRT
                SupplierResponseTime_lbl.Text = If(ComponentPlan.Suppliers.ContainsKey(.SupplierNumber), ComponentPlan.Suppliers.Item(.SupplierNumber).ResponseTime, 0)
                PlanningCalendar_lbl.Text = String.Format("{0} ({1})", .PlanningCalendar, If(ComponentPlan.PlanningCalendars.ContainsKey(.PlanningCalendar), ComponentPlan.PlanningCalendars.Item(.PlanningCalendar).WeeklyShipments, 5))
                CoverageProfile_lbl.Text = String.Format("{0} ({1})", .CoverageProfile, If(ComponentPlan.CoverageProfiles.ContainsKey(.CoverageProfile), ComponentPlan.CoverageProfiles.Item(.CoverageProfile).CoverageDays, 10))
                Owner_lbl.Text = If(ComponentPlan.MRPOwners.ContainsKey(.MRP), ComponentPlan.MRPOwners.Item(.MRP), "N/D")
                If ComponentPlan.Suppliers.ContainsKey(.SupplierNumber) AndAlso ComponentPlan.Suppliers.Item(.SupplierNumber).LeanOrdering Then
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOff_col").Visible = True
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOffQuantity_col").Visible = True
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_ExtraCallOff_col").Visible = True
                    LeanOrdering_lbl.Visible = True
                Else
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOff_col").Visible = False
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOffQuantity_col").Visible = False
                    PartnumberOpenOrders_dgv.Columns("OpenOrders_ExtraCallOff_col").Visible = False
                    LeanOrdering_lbl.Visible = False
                End If
                InHouse_lbl.Visible = If(ComponentPlan.Suppliers.ContainsKey(.SupplierNumber), ComponentPlan.Suppliers.Item(.SupplierNumber).InHouse, False)

                If .Fixed Then
                    Fix_chk.Checked = True
                    Fix_chk.CheckState = CheckState.Checked
                Else
                    Fix_chk.Checked = False
                    Fix_chk.CheckState = CheckState.Unchecked
                End If
                If .MRP2 Then
                    MRP2_chk.Checked = True
                    MRP2_chk.CheckState = CheckState.Checked
                Else
                    MRP2_chk.Checked = False
                    MRP2_chk.CheckState = CheckState.Unchecked
                End If
                If .Sensitive Then
                    Sensitive_chk.Checked = True
                    Sensitive_chk.CheckState = CheckState.Checked
                Else
                    Sensitive_chk.CheckState = False
                    Sensitive_chk.CheckState = CheckState.Unchecked
                End If
            End With

            Dim inventario As Decimal = .DeltaStock
            Dim day As Date = Delta.CurrentDate
            If .Items.Count > 0 Then
                day = Delta.CurrentDate
                While Between(day, Delta.CurrentDate, .Horizon)
                    Forecast_chrt.Series("Inventario").Points.AddXY(day, .StockBalance(day))
                    Forecast_chrt.Series("Mínimo").Points.AddXY(day, .Minimum(day))
                    Forecast_chrt.Series("Máximo").Points.AddXY(day, .Maximum(day))
                    Forecast_chrt.Series("Crítico").Points.AddXY(day, 0)
                    day = day.AddDays(1)
                End While
            Else
                Forecast_chrt.Series("Inventario").Points.AddXY(Delta.CurrentDate.Date, inventario)
                Forecast_chrt.Series("Mínimo").Points.AddXY(Delta.CurrentDate.Date, .Minimum(Delta.CurrentDate.Date))
                Forecast_chrt.Series("Máximo").Points.AddXY(Delta.CurrentDate.Date, .Maximum(Delta.CurrentDate.Date))
                Forecast_chrt.Series("Inventario").Points.AddXY(Delta.CurrentDate.AddDays(30).Date, inventario)
                Forecast_chrt.Series("Mínimo").Points.AddXY(Delta.CurrentDate.AddDays(30).Date, .Minimum(Delta.CurrentDate.Date))
                Forecast_chrt.Series("Máximo").Points.AddXY(Delta.CurrentDate.AddDays(30).Date, .Maximum(Delta.CurrentDate.Date))
                Forecast_chrt.Series("Crítico").Points.AddXY(Delta.CurrentDate.Date, 0)
                Forecast_chrt.Series("Crítico").Points.AddXY(Delta.CurrentDate.AddDays(30).Date, 0)
            End If


            'ARMAR EL DATATABLE
            Dim component_forecast As New DataTable(.Partnumber.Partnumber)
            component_forecast.Columns.Add("Detalle")
            day = Delta.CurrentDate
            While Between(day, Delta.CurrentDate, .Horizon)
                component_forecast.Columns.Add(day.ToShortDateString, GetType(Decimal))
                day = day.AddDays(1)
            End While

            'LLENAR EL DATATABLE
            Dim initial_stock As DataRow = component_forecast.NewRow
            Dim transits As DataRow = component_forecast.NewRow
            Dim open_orders As DataRow = component_forecast.NewRow
            Dim planned_orders As DataRow = component_forecast.NewRow
            Dim requirements As DataRow = component_forecast.NewRow
            Dim new_stock As DataRow = component_forecast.NewRow
            Dim new_doh As DataRow = component_forecast.NewRow
            Dim minimum As DataRow = component_forecast.NewRow
            Dim maximum As DataRow = component_forecast.NewRow

            Dim accum_stock As Decimal = .DeltaStock + .WIPStock

            initial_stock.Item("Detalle") = "Inventario Inicial"
            transits.Item("Detalle") = "Tránsitos"
            open_orders.Item("Detalle") = "Órdenes Abiertas"
            planned_orders.Item("Detalle") = "Órdenes Planeadas"
            requirements.Item("Detalle") = "Requerimiento"
            new_stock.Item("Detalle") = "Inventario Final"
            new_doh.Item("Detalle") = "Dias Cubiertos"
            minimum.Item("Detalle") = "Mínimo"
            maximum.Item("Detalle") = "Máximo"


            day = Delta.CurrentDate
            While Between(day, Delta.CurrentDate, .Horizon)
                If .Items.ContainsKey(day.Date) Then
                    With .Items(day.Date)
                        initial_stock.Item(day.ToShortDateString) = accum_stock
                        transits.Item(day.ToShortDateString) = .SumTransit + .SumPromise
                        open_orders.Item(day.ToShortDateString) = .SumOpenOrder
                        planned_orders.Item(day.ToShortDateString) = .SumPlannedOrder
                        requirements.Item(day.ToShortDateString) = .Requirement
                    End With
                Else
                    initial_stock.Item(day.ToShortDateString) = accum_stock
                    transits.Item(day.ToShortDateString) = 0
                    open_orders.Item(day.ToShortDateString) = 0
                    planned_orders.Item(day.ToShortDateString) = 0
                    requirements.Item(day.ToShortDateString) = 0
                End If
                minimum.Item(day.ToShortDateString) = .Minimum(day)
                maximum.Item(day.ToShortDateString) = .Maximum(day)
                accum_stock = .StockBalance(day)
                new_stock.Item(day.ToShortDateString) = accum_stock
                'Dim usage As Decimal = .AverageDailyDemand(day)
                'If usage = 0 Then
                '    new_doh.Item(day.ToShortDateString) = 9999
                'Else
                '    new_doh.Item(day.ToShortDateString) = Math.Round(accum_stock / usage, 1)
                'End If
                new_doh.Item(day.ToShortDateString) = .DaysOfCoverage(accum_stock, day)

                day = day.AddDays(1)
            End While

            component_forecast.Rows.Add(initial_stock)
            component_forecast.Rows.Add(transits)
            component_forecast.Rows.Add(open_orders)
            component_forecast.Rows.Add(planned_orders)
            component_forecast.Rows.Add(requirements)
            component_forecast.Rows.Add(new_stock)
            component_forecast.Rows.Add(new_doh)
            component_forecast.Rows.Add(minimum)
            component_forecast.Rows.Add(maximum)

            'ARMAR EL DATAGRIDVIEW
            Dim details_col As New DataGridViewTextBoxColumn
            With details_col
                .Name = "Detalle"
                .DataPropertyName = "Detalle"
                .HeaderText = "Detalle"
                .CellTemplate.Style.BackColor = Color.FromArgb(43, 81, 120)
                .CellTemplate.Style.SelectionBackColor = Color.FromArgb(127, 179, 213)
                .DefaultCellStyle.BackColor = Color.FromArgb(43, 81, 120)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(127, 179, 213)
                .DefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
                .Width = 130
            End With
            PartnumberForecast_dgv.Columns.Add(details_col)
            day = Delta.CurrentDate
            While Between(day, Delta.CurrentDate, .Horizon)
                Dim date_col As New DataGridViewTextBoxColumn
                With date_col
                    .Name = day.ToShortDateString
                    .DataPropertyName = day.ToShortDateString
                    .HeaderText = day.ToString("MM/dd")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    .DefaultCellStyle.Format = "N1"
                    .Width = 75
                End With
                PartnumberForecast_dgv.Columns.Add(date_col)
                day = day.AddDays(1)
            End While
            PartnumberForecast_dgv.DataSource = component_forecast
            PartnumberForecast_dgv.Columns("Detalle").Frozen = True

            'ESTABLECER LOS DATAGRIDVIEW
            PartnumberTransits_dgv.DataSource = .TransitsToDatable()
            PartnumberOpenOrders_dgv.DataSource = .OpenOrdersToDatatable()
            PartnumberPlannedOrders_dgv.DataSource = .PlannedOrdersToDatatable()
            PartnumberPromises_dgv.DataSource = .PromisesToDatable

            Transits_tab.Text = String.Format("Tránsitos ({0})", PartnumberTransits_dgv.Rows.Count)
            OpenOrders_tab.Text = String.Format("Órdenes Abiertas ({0})", PartnumberOpenOrders_dgv.Rows.Count)
            PlannedOrders_tab.Text = String.Format("Órdenes Planeadas ({0})", PartnumberPlannedOrders_dgv.Rows.Count)
            Promises_tab.Text = String.Format("Promesas ({0})", PartnumberPromises_dgv.Rows.Count)

        End With
        PartnumberRequirement_dgv.DataSource = SelectedItem.Requirements
        PartnumberRequirement_dgv.Columns("Material").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        PartnumberRequirement_dgv.Columns("Negocio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        PartnumberRequirement_dgv.Columns("Material").Frozen = True

        For Each i In SelectedItem.Items
            Select Case i.Value.SuggestedTask.Action
                Case QuickTasksAction.AddOrder
                    Dim new_button As New Button
                    new_button.Size = New Size(105, 36)
                    new_button.FlatStyle = FlatStyle.Flat
                    new_button.BackColor = Color.LightGray
                    new_button.FlatAppearance.BorderSize = 0
                    new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                    new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                    new_button.Cursor = Cursors.Hand
                    new_button.BackgroundImageLayout = ImageLayout.None
                    new_button.BackgroundImage = My.Resources.bullet_add
                    new_button.Text = String.Format("{0} {1}{3}{2}", FormatNumber(i.Value.SuggestedTask.Quantity, 1), SelectedItem.Partnumber.UoM.ToString, i.Key.ToShortDateString, vbCrLf)
                    new_button.Tag = i.Value
                    AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                    QuickTasks_flp.Controls.Add(new_button)
                Case QuickTasksAction.CancelOrder
                    For Each o In i.Value.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.CancelOrder Then
                            Dim new_button As New Button
                            new_button.Size = New Size(105, 36)
                            new_button.FlatStyle = FlatStyle.Flat
                            new_button.BackColor = Color.LightGray
                            new_button.FlatAppearance.BorderSize = 0
                            new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                            new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                            new_button.Cursor = Cursors.Hand
                            new_button.BackgroundImageLayout = ImageLayout.None
                            new_button.BackgroundImage = My.Resources.bullet_delete
                            new_button.Text = String.Format("{0} {1}{3}{2}", FormatNumber(o.Value.Quantity, 1), o.Value.UoM, o.Value.ShipDate.ToShortDateString, vbCrLf)
                            new_button.Tag = i.Value
                            AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                            QuickTasks_flp.Controls.Add(new_button)
                        End If
                    Next
                Case QuickTasksAction.FixCancel
                    For Each o In i.Value.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.FixCancel Then
                            Dim new_button As New Button
                            new_button.Size = New Size(105, 36)
                            new_button.FlatStyle = FlatStyle.Flat
                            new_button.BackColor = Color.LightGray
                            new_button.FlatAppearance.BorderSize = 0
                            new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                            new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                            new_button.Cursor = Cursors.Hand
                            new_button.BackgroundImageLayout = ImageLayout.None
                            new_button.BackgroundImage = My.Resources.bullet_wrench
                            new_button.Text = String.Format("{0} {1}{3}{2}", FormatNumber(o.Value.Quantity, 1), o.Value.UoM, o.Value.ShipDate.ToShortDateString, vbCrLf)
                            new_button.Tag = i.Value
                            AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                            QuickTasks_flp.Controls.Add(new_button)
                        End If
                    Next
                Case QuickTasksAction.FixAdjust
                    For Each o In i.Value.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.FixAdjust Then
                            Dim new_button As New Button
                            new_button.Size = New Size(105, 36)
                            new_button.FlatStyle = FlatStyle.Flat
                            new_button.BackColor = Color.LightGray
                            new_button.FlatAppearance.BorderSize = 0
                            new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                            new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                            new_button.Cursor = Cursors.Hand
                            new_button.BackgroundImageLayout = ImageLayout.None
                            new_button.BackgroundImage = My.Resources.bullet_wrench
                            new_button.Text = String.Format("{0} => {1} {2}{3}{4}", FormatNumber(o.Value.QuantityInBuM, 1), FormatNumber(o.Value.RealQuantityInBuM, 1), SelectedItem.Partnumber.UoM.ToString, vbCrLf, o.Value.ShipDate.ToShortDateString)
                            new_button.Tag = i.Value
                            AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                            QuickTasks_flp.Controls.Add(new_button)
                        End If
                    Next
                    'Case QuickTasksAction.FixAndDealing
                    '    For Each o In i.Value.OpenOrders
                    '        If o.Value.QuickTask = QuickTasksAction.FixAdjust Then
                    '            Dim new_button As New Button
                    '            new_button.Size = New Size(105, 35)
                    '            new_button.BackgroundImageLayout = ImageLayout.None
                    '            new_button.BackgroundImage = My.Resources.wrench_16
                    '            new_button.Text = String.Format("{0} => {1} {2}{3}{4}", FormatNumber(o.Value.QuantityInBuM, 1), FormatNumber(o.Value.RealQuantityInBuM, 1), SelectedItem.Partnumber.UoM.ToString, vbCrLf, o.Value.ShipDate.ToShortDateString)
                    '            new_button.Tag = i.Value
                    '            AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                    '            QuickTasks_flp.Controls.Add(new_button)
                    '        ElseIf o.Value.QuickTask = QuickTasksAction.FixCancel Then
                    '            Dim new_button As New Button
                    '            new_button.Size = New Size(105, 35)
                    '            new_button.BackgroundImageLayout = ImageLayout.None
                    '            new_button.BackgroundImage = My.Resources.delete_16
                    '            new_button.Text = String.Format("{0} {1}{3}{2}", FormatNumber(o.Value.Quantity, 1), o.Value.UoM, o.Value.ShipDate.ToShortDateString, vbCrLf)
                    '            new_button.Tag = i.Value
                    '            AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                    '            QuickTasks_flp.Controls.Add(new_button)
                    '        End If
                    '    Next
                Case QuickTasksAction.IncreaseOrder
                    Dim new_button As New Button
                    new_button.Size = New Size(105, 36)
                    new_button.FlatStyle = FlatStyle.Flat
                    new_button.BackColor = Color.LightGray
                    new_button.FlatAppearance.BorderSize = 0
                    new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                    new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                    new_button.Cursor = Cursors.Hand
                    new_button.BackgroundImageLayout = ImageLayout.None
                    new_button.BackgroundImage = My.Resources.bullet_up
                    new_button.Text = String.Format("{0} {1}{3}{2}", i.Value.SuggestedTask.Quantity, SelectedItem.Partnumber.UoM.ToString, i.Key.ToShortDateString, vbCrLf)
                    new_button.Tag = i.Value
                    AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                    QuickTasks_flp.Controls.Add(new_button)
                Case QuickTasksAction.DecreaseOrder
                    Dim new_button As New Button
                    new_button.Size = New Size(105, 36)
                    new_button.FlatStyle = FlatStyle.Flat
                    new_button.BackColor = Color.LightGray
                    new_button.FlatAppearance.BorderSize = 0
                    new_button.FlatAppearance.MouseOverBackColor = Color.Gold
                    new_button.FlatAppearance.MouseDownBackColor = Color.GreenYellow
                    new_button.Cursor = Cursors.Hand
                    new_button.BackgroundImageLayout = ImageLayout.None
                    new_button.BackgroundImage = My.Resources.bullet_down
                    new_button.Text = String.Format("{0} {1}{3}{2}", i.Value.SuggestedTask.Quantity, SelectedItem.Partnumber.UoM.ToString, i.Key.ToShortDateString, vbCrLf)
                    new_button.Tag = i.Value
                    AddHandler new_button.Click, AddressOf ButtonQuickTask_Click
                    QuickTasks_flp.Controls.Add(new_button)
                Case QuickTasksAction.Dealing, QuickTasksAction.FixAndDealing

            End Select
        Next
        Main_tab.SelectTab("Partnumber_tab")
        LoadingScreen.Hide()
    End Sub
#End Region

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        search_box.Show()
        search_box.BringToFront()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Main_DT IsNot Nothing Then
            'Dim colors As List(Of CAguilar.MyExcel.ColorRange) = MyExcel.GetArrayColorFromDataGridView(ComponentPlan_dgv)
            Delta.Export(Main_DT, "Plan de Componentes")
        End If
    End Sub

    Private Sub PartnumberForecast_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles PartnumberForecast_dgv.CellFormatting
        If e.ColumnIndex > 0 AndAlso e.RowIndex >= 0 Then
            If IsNumeric(e.Value) AndAlso e.Value < 0 Then e.CellStyle.ForeColor = Color.Red
            If Not ProductionPlan.WorkingCalendar.Item(CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name).Date) Then
                e.CellStyle.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Private Sub PartnumberRefresh_btn_Click(sender As Object, e As EventArgs) Handles PartnumberRefresh_btn.Click
        If Main_Component_Plan IsNot Nothing AndAlso SelectedItem IsNot Nothing Then
            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
        End If
    End Sub

    Private Sub Partnumber_Export_btn_Click(sender As Object, e As EventArgs) Handles Partnumber_Export_btn.Click
        If SelectedItem IsNot Nothing Then
            LoadingScreen.Show()
            If MyExcel.SaveAs({PartnumberRequirement_dgv.DataSource, PartnumberPlannedOrders_dgv.DataSource, PartnumberOpenOrders_dgv.DataSource, PartnumberTransits_dgv.DataSource, PartnumberPromises_dgv.DataSource, PartnumberForecast_dgv.DataSource}, False) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub PartnumberRequirement_dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PartnumberRequirement_dgv.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left AndAlso PartnumberRequirement_dgv.Columns(e.ColumnIndex).Name = "Material" AndAlso PartnumberRequirement_dgv.Rows(e.RowIndex).Cells("Material").Value <> "BOM Issue" Then
            Dim cell_rec = PartnumberRequirement_dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            Dim dgv_point = PartnumberRequirement_dgv.PointToScreen(System.Drawing.Point.Empty)
            Dim harn_info As New CR_HarnRequirementDetails
            harn_info.Material = PartnumberRequirement_dgv.Rows(e.RowIndex).Cells("Material").Value
            harn_info.DefaultLocation = New Drawing.Point(cell_rec.X + dgv_point.X, cell_rec.Y + dgv_point.Y)
            harn_info.Show()
        End If
    End Sub

    Private Sub PartnumberForecast_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles PartnumberForecast_dgv.DataBindingComplete
        For Each row As DataGridViewRow In PartnumberForecast_dgv.Rows
            If "Órdenes Abiertas" = row.Cells("Detalle").Value Then
                For Each cell As DataGridViewCell In row.Cells
                    If Not cell.ColumnIndex = 0 Then cell.ContextMenuStrip = Orders_cms
                Next
            ElseIf "Órdenes Planeadas" = row.Cells("Detalle").Value Then
                For Each cell As DataGridViewCell In row.Cells
                    If Not cell.ColumnIndex = 0 Then cell.ContextMenuStrip = PlannedOrders_cms
                Next
            End If
        Next
    End Sub

#Region "CMS ORDENES"
    Dim cms_selected_date As Date
    Private Sub PartnumberForecast_dgv_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles PartnumberForecast_dgv.CellContextMenuStripNeeded
        If e.ContextMenuStrip IsNot Nothing Then
            cms_selected_date = CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name)
            PartnumberForecast_dgv.ClearSelection()
            PartnumberForecast_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        End If
    End Sub

    Private Sub Orders_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Orders_cms.Opening
        With SelectedItem
            If .Items.ContainsKey(cms_selected_date) AndAlso .Items.Item(cms_selected_date).OpenOrders.Count > 0 Then
                AdjustOrder_cmsi.Enabled = True
                AddOrder_cmsi.Enabled = False
            Else
                AddOrder_cmsi.Enabled = True
                AdjustOrder_cmsi.Enabled = False
            End If
        End With
    End Sub

    Private Sub AddOrder_cmsi_Click(sender As Object, e As EventArgs) Handles AddOrder_cmsi.Click
        If SelectedItem IsNot Nothing Then
            With SelectedItem
                Dim background As New FadeBackground()
                Dim pickup_date As Date = BackWorkDay(cms_selected_date, .Partnumber.GRT).Date  'CALCULAR LA FECHA DONDE SE DEBE AGREGAR LA ORDEN PARA QUE LLEGUE A TIEMPO
                Dim suggest_quantity As Decimal
                If SelectedItem.Items.ContainsKey(cms_selected_date) AndAlso SelectedItem.Items.Item(cms_selected_date).SuggestedTask.Action = QuickTasksAction.AddOrder Then
                    suggest_quantity = SelectedItem.Items.Item(cms_selected_date).SuggestedTask.Quantity
                Else
                    suggest_quantity = .Partnumber.RoundByStdPack(.Minimum(cms_selected_date) - .StockBalance(cms_selected_date))
                End If
                If pickup_date < Delta.CurrentDate.Date Then
                    pickup_date = Delta.CurrentDate.Date
                End If
                Dim order As New CR_ComponentPlanNewOrder
                order.Partnumber = SelectedItem.Partnumber.Partnumber
                order.Quantity = Math.Max(suggest_quantity, 0)
                order.PickUpDate = pickup_date
                order.TSA = SelectedItem.Partnumber.Document
                order.Item = SelectedItem.Partnumber.DocumentItem
                background.Show()
                If order.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    background.Close()
                    LoadingScreen.Show()
                    Dim sap As New SAP
                    If sap.Available Then
                        If sap.ME38(.Partnumber.Partnumber, order.TSA, order.Item, True, order.PickUpDate, order.Quantity) Then
                            If UpdateOpenOrders(.Partnumber.Partnumber) Then
                                LoadingScreen.Hide()
                                Dim scroll_h As Integer
                                scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
                                LoadComponentPlanItem(.Partnumber.Partnumber)
                                PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
                                PartnumberForecast_dgv.Rows(2).Cells(cms_selected_date.ToShortDateString).Selected = True
                                FlashAlerts.ShowConfirm("Orden generada correctamente.")
                            Else
                                FlashAlerts.ShowInformation("La orden se genero en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                            End If
                            LoadingScreen.Hide()
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al crear la orden.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                    End If
                Else
                    background.Close()
                End If
                background.Dispose()
                order.Dispose()
            End With
        End If
    End Sub

    Private Sub AdjustOrder_cmsi_Click(sender As Object, e As EventArgs) Handles AdjustOrder_cmsi.Click
        If SelectedItem IsNot Nothing Then
            With SelectedItem
                Dim selected_id As Integer = 0
                Dim background As New FadeBackground()
                If .Items.Item(cms_selected_date).OpenOrders.Count = 1 Then
                    For Each i In .Items.Item(cms_selected_date).OpenOrders
                        selected_id = i.Key
                    Next
                ElseIf .Items.Item(cms_selected_date).OpenOrders.Count > 1 Then

                    Dim orders_dt As New DataTable
                    orders_dt.Columns.Add("ID", GetType(Integer))
                    orders_dt.Columns.Add("SupplierNumber", GetType(String))
                    orders_dt.Columns.Add("SupplierName", GetType(String))
                    orders_dt.Columns.Add("Quantity", GetType(Decimal))
                    orders_dt.Columns.Add("UoM", GetType(String))
                    orders_dt.Columns.Add("ShipDate", GetType(Date))
                    For Each i In .Items.Item(cms_selected_date).OpenOrders
                        orders_dt.Rows.Add(i.Value.ID, i.Value.SupplierNumber, i.Value.SupplierName, i.Value.Quantity, i.Value.UoM, i.Value.ShipDate)
                    Next
                    Dim selector As New CR_ComponentePlanSelectOrderDialog
                    selector.Datasource = orders_dt
                    background.Show()
                    If selector.ShowDialog = Windows.Forms.DialogResult.OK Then
                        selected_id = selector.SelectedID
                    Else
                        background.Close()
                        background.Dispose()
                        selector.Dispose()
                        Exit Sub
                    End If
                    background.Close()
                    selector.Dispose()
                Else
                    Exit Sub
                End If

                Dim suggest_quantity As Decimal
                If SelectedItem.Items.ContainsKey(cms_selected_date) Then
                    Select Case SelectedItem.Items.Item(cms_selected_date).SuggestedTask.Action
                        Case QuickTasksAction.DecreaseOrder, QuickTasksAction.IncreaseOrder, QuickTasksAction.FixAdjust, QuickTasksAction.FixAndDealing
                            suggest_quantity = SelectedItem.Items.Item(cms_selected_date).SuggestedTask.Quantity
                        Case QuickTasksAction.CancelOrder, QuickTasksAction.FixCancel
                            suggest_quantity = 0
                        Case Else
                            suggest_quantity = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity
                    End Select
                Else
                    suggest_quantity = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity
                End If

                Dim order As New CR_ComponentPlanNewOrder
                order.Partnumber = SelectedItem.Partnumber.Partnumber
                order.Quantity = Math.Max(suggest_quantity, 0)
                order.PickUpDate = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).ShipDate
                order.TSA = SelectedItem.Partnumber.Document
                order.Item = SelectedItem.Partnumber.DocumentItem
                order.EditMode = True
                background.Show()
                If order.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    background.Close()
                    LoadingScreen.Show()
                    Dim sap As New SAP
                    If sap.Available Then
                        If sap.ME38(SelectedItem.Partnumber.Partnumber, order.TSA, order.Item, .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).ShipDate, .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity, order.PickUpDate, order.Quantity) Then
                            If UpdateOpenOrders(.Partnumber.Partnumber) Then
                                LoadingScreen.Hide()
                                Dim scroll_h As Integer
                                scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
                                LoadComponentPlanItem(.Partnumber.Partnumber)
                                PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
                                PartnumberForecast_dgv.Rows(2).Cells(cms_selected_date.ToShortDateString).Selected = True
                                FlashAlerts.ShowConfirm("Orden modificada correctamente.")
                            Else
                                LoadingScreen.Hide()
                                FlashAlerts.ShowInformation("La orden se actualizo en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                            End If
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al modificar la orden.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                    End If
                Else
                    background.Close()
                End If
                background.Dispose()
                order.Dispose()
            End With
        End If
    End Sub
#End Region
#Region "SINCRONIZAR"
    Private Function UpdateTransits(partnumber As String) As Boolean
        Dim sap As New SAP
        If sap.Available Then
            Dim filename As String = GF.TempTXTPath
            If sap.Y_DN3_47000497(Parameter("SYS_PlantCode"), partnumber, "*", filename) Then
                If Not IO.File.Exists(filename) Then
                    SQL.Current.Execute(String.Format("UPDATE Ord_Transits SET [Active] = 0 WHERE [Active] = 1 AND Interplant = 0 AND Partnumber = '{0}';", partnumber))
                    Return True
                Else
                    Dim transits = CSV.Datatable(filename, vbTab, True, False, 4)
                    Try
                        Dim table As New DataTable
                        table.Columns.Add("Partnumber")
                        table.Columns.Add("DeliveryDate")
                        table.Columns.Add("DeliveryNumber")
                        table.Columns.Add("PONumber")
                        table.Columns.Add("POItems")
                        table.Columns.Add("UoM")
                        table.Columns.Add("Quantity", GetType(Decimal))
                        table.Columns.Add("AvailabilityDate")
                        table.Columns.Add("ExternalDocumentNo")
                        table.Columns.Add("PRONumber")

                        Dim mapping(9) As SqlClient.SqlBulkCopyColumnMapping
                        mapping(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                        mapping(1) = New SqlClient.SqlBulkCopyColumnMapping("DeliveryDate", "DeliveryDate")
                        mapping(2) = New SqlClient.SqlBulkCopyColumnMapping("DeliveryNumber", "DeliveryNumber")
                        mapping(3) = New SqlClient.SqlBulkCopyColumnMapping("PONumber", "PO")
                        mapping(4) = New SqlClient.SqlBulkCopyColumnMapping("POItems", "Items")
                        mapping(5) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
                        mapping(6) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
                        mapping(7) = New SqlClient.SqlBulkCopyColumnMapping("AvailabilityDate", "AvailabilityDate")
                        mapping(8) = New SqlClient.SqlBulkCopyColumnMapping("ExternalDocumentNo", "ExternalDocument")
                        mapping(9) = New SqlClient.SqlBulkCopyColumnMapping("PRONumber", "PRONumber")

                        For Each row As DataRow In transits.Rows
                            table.Rows.Add(RawMaterial.Format(row("Material")), CDate(row("Delivery Date")).ToString("yyyy-MM-dd"), row("Delivery"), row("PO Number"), row("PO Item Number"), row("Order Unit of measure"), CDec(row("Quantity")), CDate(row("Availability Date")).ToString("yyyy-MM-dd"), row.Item("External Document No"), row.Item("PRO Number"))
                        Next

                        If SQL.Current.Upsert(table, "tmpTransits", "CREATE TABLE #tmpTransits ([Partnumber] [char](8) NOT NULL,[DeliveryDate] [date] NOT NULL,[DeliveryNumber] [varchar](20) NOT NULL,[PO] [varchar](20) NOT NULL,[Items] [varchar](5) NOT NULL,[UoM] [varchar](3) NOT NULL,[Quantity] [decimal](10, 3) NOT NULL,[AvailabilityDate] [date] NOT NULL,[ExternalDocument] [varchar](50) NULL,[PRONumber] [varchar](50) NULL);", String.Format("UPDATE Ord_Transits SET [Active] = 0 WHERE [Active] = 1 AND Interplant = 0 AND Partnumber = '{0}'; MERGE Ord_Transits AS target USING #tmpTransits AS source ON target.Partnumber = source.Partnumber AND target.DeliveryDate = source.DeliveryDate AND target.DeliveryNumber = source.DeliveryNumber AND target.Quantity = source.Quantity AND target.ExternalDocument = source.ExternalDocument WHEN MATCHED THEN UPDATE SET PRONumber = source.PRONumber, [Active] = 1 WHEN NOT MATCHED THEN INSERT (Partnumber,DeliveryDate,DeliveryNumber,PO,Items,UoM,Quantity,AvailabilityDate,ExternalDocument,PRONumber,Active,Interplant) VALUES (source.Partnumber,source.DeliveryDate,source.DeliveryNumber,source.PO,source.Items,source.UoM,source.Quantity,source.AvailabilityDate,source.ExternalDocument,source.PRONumber,1,0);", partnumber)) Then
                            UpdateTransits = True
                        Else
                            UpdateTransits = False
                        End If
                        table.Dispose()
                    Catch ex As Exception
                        UpdateTransits = False
                    Finally
                        TryDelete(filename)
                    End Try
                End If

            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function UpdateOpenOrders(partnumber As String) As Boolean
        Dim sap As New SAP
        If sap.Available Then
            Dim filename As String = GF.TempTXTPath
            Dim in_flag As Boolean = False
            Dim ex_flag As Boolean = False
            Dim transits As Boolean = False
            'AL NO SABER SI EL USUARIO PUSO UN TSA O SA EL SISTEMA BAJARA TODAS LAS ORDENES INTERNAS Y EXTERNAS NUEVAMENTE
            If sap.Y_DN3_47000368(Parameter("Sys_PlantCode"), filename, , , , partnumber, True, True, True, , 99) Then 'EXTERNAL
                If Not IO.File.Exists(filename) Then
                    SQL.Current.Execute(String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 1 AND Partnumber = '{0}';", partnumber))
                    ex_flag = True
                Else
                    Dim openorders = CSV.Datatable(filename, vbTab, True, False, 5)
                    Try
                        openorders.DefaultView.RowFilter = "Material <> '' AND [Open Qty] NOT LIKE ',%' AND Delivery = '' AND NOT (([Column6] <> '' AND [Status]='0') OR ([Open Qty] = '' AND [Column6] <> '0' AND [Column6] NOT LIKE '-%'))"
                        Dim table As New DataTable
                        table.Columns.Add("Partnumber")
                        table.Columns.Add("SupplierNumber")
                        table.Columns.Add("SupplierName")
                        table.Columns.Add("Quantity", GetType(Decimal))
                        table.Columns.Add("Status", GetType(Decimal))
                        table.Columns.Add("UoM")
                        table.Columns.Add("ShipDate", GetType(Date))
                        table.Columns.Add("GRP")
                        table.Columns.Add("AvailabilityDate", GetType(Date))
                        table.Columns.Add("Fix", GetType(Boolean))
                        table.Columns.Add("PurchaseDocument")
                        table.Columns.Add("Item")
                        table.Columns.Add("Kanban", GetType(Boolean))
                        table.Columns.Add("External", GetType(Boolean))

                        For Each row As DataRowView In openorders.DefaultView
                            table.Rows.Add(RawMaterial.Format(row.Item("Material")), row.Item("Supplier"), row.Item("Name"), row.Item("Open Qty"), row.Item("Status"), row.Item("Unit of Measure"), CDate(row.Item("Ship Date")), row.Item("GRP"), WorkDay(CDate(row.Item("Ship Date")), CInt(row.Item("GRP"))), row.Item("Fix") = "*", row.Item("Purch.Doc."), row.Item("Item"), row.Item("Kanb") = "YES", True)
                        Next
                        If table.Rows.Count > 0 Then
                            ex_flag = SQL.Current.Upsert(table, "tmpOrders", "CREATE TABLE #tmpOrders([Partnumber] [char](8) NOT NULL,[SupplierNumber] [char](7) NOT NULL,[SupplierName] [varchar](50) NOT NULL,[Quantity] [decimal](18, 3) NOT NULL,[Status] [decimal](18, 3) NULL,[UoM] [varchar](3) NOT NULL,[ShipDate] [date] NOT NULL,[GRP] [smallint] NOT NULL,[AvailabilityDate] [date] NOT NULL,[Fix] [bit] NOT NULL,[PurchaseDocument] [char](9) NOT NULL,[Item] [varchar](4) NOT NULL,[Kanban] [bit] NOT NULL,[External] [bit] NOT NULL)", String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 1 AND Partnumber = '{0}'; MERGE Ord_OpenOrders AS target USING #tmpOrders AS source ON target.Partnumber = source.Partnumber AND target.SupplierNumber = source.SupplierNumber AND target.ShipDate = source.ShipDate AND target.[External] = source.[External] WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity, Status = source.Status, UoM = source.UoM, Fix = source.Fix, Kanban = source.Kanban, Active = 1 WHEN NOT MATCHED THEN INSERT (Partnumber,SupplierNumber,SupplierName,Quantity,Status,UoM,ShipDate,GRP,AvailabilityDate,Fix,PurchaseDocument,Item,Kanban,[External]) VALUES (source.Partnumber,source.SupplierNumber,source.SupplierName,source.Quantity,source.Status,source.UoM,source.ShipDate,source.GRP,source.AvailabilityDate,source.Fix,source.PurchaseDocument,source.Item,source.Kanban,source.[External]);", partnumber))
                        Else
                            SQL.Current.Execute(String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 1 AND Partnumber = '{0}';", partnumber))
                            ex_flag = True
                        End If
                        table.Dispose()
                    Catch ex As Exception

                    Finally
                        TryDelete(filename)
                    End Try
                End If
            End If
            filename = GF.TempTXTPath
            If sap.Y_DN3_47000368(Parameter("Sys_PlantCode"), filename, , , , partnumber, False, True, True, , 99) Then 'INTERNAL
                If Not IO.File.Exists(filename) Then
                    SQL.Current.Execute(String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 0 AND Partnumber = '{0}';", partnumber))
                    SQL.Current.Execute(String.Format("UPDATE Ord_Transits SET [Active] = 0 WHERE [Active] = 1 AND Interplant = 1 AND Partnumber = '{0}';", partnumber))
                    in_flag = True
                Else
                    Dim openorders = CSV.Datatable(filename, vbTab, True, False, 5)
                    Try
                        openorders.DefaultView.RowFilter = "Material <> '' AND [Open Qty] NOT LIKE ',%' AND Delivery = '' AND NOT (([Column6] <> '' AND [Status]='0') OR ([Open Qty] = '' AND [Column6] <> '0' AND [Column6] NOT LIKE '-%'))"
                        Dim table As New DataTable
                        table.Columns.Add("Partnumber")
                        table.Columns.Add("SupplierNumber")
                        table.Columns.Add("SupplierName")
                        table.Columns.Add("Quantity", GetType(Decimal))
                        table.Columns.Add("Status", GetType(Decimal))
                        table.Columns.Add("UoM")
                        table.Columns.Add("ShipDate", GetType(Date))
                        table.Columns.Add("GRP")
                        table.Columns.Add("AvailabilityDate", GetType(Date))
                        table.Columns.Add("Fix", GetType(Boolean))
                        table.Columns.Add("PurchaseDocument")
                        table.Columns.Add("Item")
                        table.Columns.Add("Kanban", GetType(Boolean))
                        table.Columns.Add("External", GetType(Boolean))

                        For Each row As DataRowView In openorders.DefaultView
                            table.Rows.Add(RawMaterial.Format(row.Item("Material")), row.Item("Supplier"), row.Item("Name"), row.Item("Open Qty"), row.Item("Status"), row.Item("Unit of Measure"), CDate(row.Item("Ship Date")), row.Item("GRP"), WorkDay(CDate(row.Item("Ship Date")), CInt(row.Item("GRP"))), row.Item("Fix") = "*", row.Item("Purch.Doc."), row.Item("Item"), row.Item("Kanb") = "YES", False)
                        Next
                        If table.Rows.Count > 0 Then
                            in_flag = SQL.Current.Upsert(table, "tmpOrders", "CREATE TABLE #tmpOrders([Partnumber] [char](8) NOT NULL,[SupplierNumber] [char](7) NOT NULL,[SupplierName] [varchar](50) NOT NULL,[Quantity] [decimal](18, 3) NOT NULL,[Status] [decimal](18, 3) NULL,[UoM] [varchar](3) NOT NULL,[ShipDate] [date] NOT NULL,[GRP] [smallint] NOT NULL,[AvailabilityDate] [date] NOT NULL,[Fix] [bit] NOT NULL,[PurchaseDocument] [char](9) NOT NULL,[Item] [varchar](4) NOT NULL,[Kanban] [bit] NOT NULL,[External] [bit] NOT NULL)", String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 0 AND Partnumber = '{0}'; MERGE Ord_OpenOrders AS target USING #tmpOrders AS source ON target.Partnumber = source.Partnumber AND target.SupplierNumber = source.SupplierNumber AND target.ShipDate = source.ShipDate AND target.[External] = source.[External] WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity, Status = source.Status, UoM = source.UoM, Fix = source.Fix, Kanban = source.Kanban, Active = 1 WHEN NOT MATCHED THEN INSERT (Partnumber,SupplierNumber,SupplierName,Quantity,Status,UoM,ShipDate,GRP,AvailabilityDate,Fix,PurchaseDocument,Item,Kanban,[External]) VALUES (source.Partnumber,source.SupplierNumber,source.SupplierName,source.Quantity,source.Status,source.UoM,source.ShipDate,source.GRP,source.AvailabilityDate,source.Fix,source.PurchaseDocument,source.Item,source.Kanban,source.[External]);", partnumber))
                        Else
                            SQL.Current.Execute(String.Format("UPDATE Ord_OpenOrders SET [Active] = 0 WHERE [Active] = 1 AND [External] = 0 AND Partnumber = '{0}';", partnumber))
                            in_flag = True
                        End If
                        table.Dispose()


                        '====================== TRANSITOS PACKARD ========================
                        Dim last_date As Date
                        Dim table_transits As New DataTable
                        table_transits.Columns.Add("Partnumber")
                        table_transits.Columns.Add("DeliveryDate")
                        table_transits.Columns.Add("DeliveryNumber")
                        table_transits.Columns.Add("PONumber")
                        table_transits.Columns.Add("POItems")
                        table_transits.Columns.Add("UoM")
                        table_transits.Columns.Add("Quantity", GetType(Decimal))
                        table_transits.Columns.Add("AvailabilityDate")
                        table_transits.Columns.Add("ExternalDocumentNo")
                        table_transits.Columns.Add("PRONumber")

                        Dim mapping_transits(9) As SqlClient.SqlBulkCopyColumnMapping
                        mapping_transits(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                        mapping_transits(1) = New SqlClient.SqlBulkCopyColumnMapping("DeliveryDate", "DeliveryDate")
                        mapping_transits(2) = New SqlClient.SqlBulkCopyColumnMapping("DeliveryNumber", "DeliveryNumber")
                        mapping_transits(3) = New SqlClient.SqlBulkCopyColumnMapping("PONumber", "PO")
                        mapping_transits(4) = New SqlClient.SqlBulkCopyColumnMapping("POItems", "Items")
                        mapping_transits(5) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
                        mapping_transits(6) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
                        mapping_transits(7) = New SqlClient.SqlBulkCopyColumnMapping("AvailabilityDate", "AvailabilityDate")
                        mapping_transits(8) = New SqlClient.SqlBulkCopyColumnMapping("ExternalDocumentNo", "ExternalDocument")
                        mapping_transits(9) = New SqlClient.SqlBulkCopyColumnMapping("PRONumber", "PRONumber")

                        openorders.DefaultView.RowFilter = "Material <> '' AND Delivery <> '' AND [In-Transit] <> ''"
                        For Each row As DataRowView In openorders.DefaultView
                            If row.Item("Ship Date") <> "" Then
                                last_date = CDate(row.Item("Ship Date")).Date
                            End If
                            table_transits.Rows.Add(RawMaterial.Format(row("Material")), last_date, row("Delivery"), row("Purch.Doc."), row("Item"), row("Unit of Measure"), CDec(row("In-Transit")), WorkDay(last_date, CInt(row.Item("GRP"))), "", "")
                        Next
                        If SQL.Current.Upsert(table_transits, "tmpTransits", "CREATE TABLE #tmpTransits ([Partnumber] [char](8) NOT NULL,[DeliveryDate] [date] NOT NULL,[DeliveryNumber] [varchar](20) NOT NULL,[PO] [varchar](20) NOT NULL,[Items] [varchar](5) NOT NULL,[UoM] [varchar](3) NOT NULL,[Quantity] [decimal](10, 3) NOT NULL,[AvailabilityDate] [date] NOT NULL,[ExternalDocument] [varchar](50) NULL,[PRONumber] [varchar](50) NULL);", String.Format("UPDATE Ord_Transits SET [Active] = 0 WHERE [Active] = 1 AND Interplant = 1 AND Partnumber = '{0}'; MERGE Ord_Transits AS target USING #tmpTransits AS source ON target.Partnumber = source.Partnumber AND target.DeliveryDate = source.DeliveryDate AND target.DeliveryNumber = source.DeliveryNumber AND target.Quantity = source.Quantity AND target.Interplant = 1 WHEN MATCHED THEN UPDATE SET PRONumber = source.PRONumber, [Active] = 1 WHEN NOT MATCHED THEN INSERT (Partnumber,DeliveryDate,DeliveryNumber,PO,Items,UoM,Quantity,AvailabilityDate,ExternalDocument,PRONumber,Active,Interplant) VALUES (source.Partnumber,source.DeliveryDate,source.DeliveryNumber,source.PO,source.Items,source.UoM,source.Quantity,source.AvailabilityDate,source.ExternalDocument,source.PRONumber,1,1);", partnumber)) Then
                            transits = True
                        End If
                        table_transits.Dispose()

                        '=======================================
                    Catch ex As Exception

                    Finally
                        TryDelete(filename)
                    End Try
                End If
            End If
            If in_flag AndAlso ex_flag AndAlso transits Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function UpdatePlannedOrders(partnumber As String) As Boolean
        Dim sap As New SAP
        If sap.Available Then
            Dim filename As String = GF.TempTXTPath
            If sap.AQ25SYSTQV000696_AS_PLNORGR(Parameter("SYS_PlantCode"), partnumber, filename) Then
                If Not IO.File.Exists(filename) Then
                    SQL.Current.Execute(String.Format("DELETE FROM Ord_PlannedOrders WHERE Partnumber = '{0}';", partnumber))
                    Return True
                Else
                    Dim planneorders = CSV.Datatable(filename, vbTab, True, False, 2)
                    Try
                        Dim table As New DataTable
                        table.Columns.Add("Partnumber")
                        table.Columns.Add("PlannedOrder")
                        table.Columns.Add("PlantIn")
                        table.Columns.Add("Quantity", GetType(Decimal))
                        table.Columns.Add("UoM")
                        table.Columns.Add("OpeningDate")
                        table.Columns.Add("Agreement")
                        table.Columns.Add("GRT", GetType(Integer))
                        table.Columns.Add("AvailabilityDate")

                        Dim mapping(8) As SqlClient.SqlBulkCopyColumnMapping
                        mapping(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                        mapping(1) = New SqlClient.SqlBulkCopyColumnMapping("PlannedOrder", "PlannedOrder")
                        mapping(2) = New SqlClient.SqlBulkCopyColumnMapping("PlantIn", "PlantIn")
                        mapping(3) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
                        mapping(4) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
                        mapping(5) = New SqlClient.SqlBulkCopyColumnMapping("OpeningDate", "OpeningDate")
                        mapping(6) = New SqlClient.SqlBulkCopyColumnMapping("Agreement", "Agreement")
                        mapping(7) = New SqlClient.SqlBulkCopyColumnMapping("GRT", "GRT")
                        mapping(8) = New SqlClient.SqlBulkCopyColumnMapping("AvailabilityDate", "AvailabilityDate")

                        For Each row As DataRow In planneorders.Rows
                            If Not row.Item("Pln open").ToString.Trim = "" Then table.Rows.Add(RawMaterial.Format(row.Item("Material")), row.Item("Plnd order"), row.Item("PrPn"), row.Item("Ord.quantity"), row.Item("BUn"), CDate(row.Item("Pln open")).ToString("yyyy-MM-dd"), row.Item("Agmt."), row.Item("GRT"), WorkDay(CDate(row.Item("Pln open")), row.Item("GRT")).ToString("yyyy-MM-dd"))
                        Next
                        Dim max_id = SQL.Current.GetScalar(String.Format("SELECT MAX(ID) FROM Ord_PlannedOrders WHERE Partnumber = '{0}';", partnumber))
                        If SQL.Current.Bulk(table, "Ord_PlannedOrders", mapping) Then
                            SQL.Current.Execute(String.Format("DELETE FROM Ord_PlannedOrders WHERE ID <= {0} AND Partnumber = '{1}';", max_id, partnumber))
                            UpdatePlannedOrders = True
                        Else
                            UpdatePlannedOrders = False
                        End If
                        table.Dispose()
                    Catch ex As Exception
                        UpdatePlannedOrders = False
                    Finally
                        TryDelete(filename)
                    End Try
                End If
            Else
                UpdatePlannedOrders = False
            End If
        Else
            Return False
        End If
    End Function
#End Region

#Region "PARTNUMBER LOAD"

#Region "DISEÑO DGV"
    Private Sub PartnumberForecast_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles PartnumberForecast_dgv.CellPainting
        'DIBUJAR LAS LINEAS DONDE TERMINA EL PTF Y SRT
        If e.ColumnIndex > 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            Dim col_date As Date = CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name).Date

            If e.RowIndex >= 0 AndAlso PartnumberForecast_dgv.Rows(e.RowIndex).Cells("Detalle").Value = "Inventario Final" Then
                Select Case SelectedItem.Status(col_date)
                    Case ComponentPlanItemStatus.Critical
                        e.Graphics.FillRectangle(Brushes.Red, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
                    Case ComponentPlanItemStatus.Minimum
                        e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
                    Case ComponentPlanItemStatus.Normal
                        e.Graphics.FillRectangle(Brushes.YellowGreen, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
                    Case ComponentPlanItemStatus.Excess
                        e.Graphics.FillRectangle(Brushes.DarkSlateBlue, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
                    Case ComponentPlanItemStatus.Obsolete
                        e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds.Left, e.CellBounds.Bottom - 3, e.CellBounds.Width, 3)
                End Select
            End If

            If e.RowIndex >= 0 AndAlso PartnumberForecast_dgv.Rows(e.RowIndex).Cells("Detalle").Value = "Órdenes Abiertas" AndAlso SelectedItem.Items.ContainsKey(col_date) Then
                Select Case SelectedItem.Items.Item(col_date).SuggestedTask.Action
                    Case QuickTasksAction.AddOrder
                        e.Graphics.DrawImage(My.Resources.bullet_add, e.CellBounds.Left, e.CellBounds.Top)
                    Case QuickTasksAction.IncreaseOrder
                        e.Graphics.DrawImage(My.Resources.bullet_up, e.CellBounds.Left, e.CellBounds.Top)
                    Case QuickTasksAction.DecreaseOrder
                        e.Graphics.DrawImage(My.Resources.bullet_down, e.CellBounds.Left, e.CellBounds.Top)
                    Case QuickTasksAction.CancelOrder
                        e.Graphics.DrawImage(My.Resources.bullet_delete, e.CellBounds.Left, e.CellBounds.Top)
                    Case QuickTasksAction.Dealing, QuickTasksAction.FixAndDealing
                        e.Graphics.DrawImage(My.Resources.red_warning_16, e.CellBounds.Left, e.CellBounds.Top)
                    Case QuickTasksAction.FixAdjust, QuickTasksAction.FixCancel
                        e.Graphics.DrawImage(My.Resources.bullet_wrench, e.CellBounds.Left, e.CellBounds.Top)
                    Case Else 'None
                End Select
            End If

            'VALIDAR SI EL SUPPLIER ES LEAN O NO
            If ComponentPlan.Suppliers.ContainsKey(SelectedItem.Partnumber.SupplierNumber) AndAlso ComponentPlan.Suppliers.Item(SelectedItem.Partnumber.SupplierNumber).LeanOrdering Then
                'SI ES LEAN DIBUJAR LINEAS DE PTF Y SRT
                With ComponentPlan.Suppliers.Item(SelectedItem.Partnumber.SupplierNumber)
                    If col_date = SelectedItem.EndOfPTF AndAlso col_date = .EndOfSRT Then
                        If e.RowIndex = -1 Then
                            e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 27, e.CellBounds.Top + 1, 27, 12)
                            e.Graphics.DrawString("PTF", New Font(PartnumberForecast_dgv.DefaultCellStyle.Font.FontFamily, 7), Brushes.White, e.CellBounds.Right - 25, e.CellBounds.Top + 1)
                            e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 1, e.CellBounds.Top + 1, 1, e.CellBounds.Height - 1)

                            e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 27, e.CellBounds.Top + 13, 26, 12)
                            e.Graphics.DrawString("SRT", New Font(PartnumberForecast_dgv.DefaultCellStyle.Font.FontFamily, 7), Brushes.White, e.CellBounds.Right - 25, e.CellBounds.Top + 13)
                            e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 2, e.CellBounds.Top + 13, 1, e.CellBounds.Height - 1)
                        Else
                            e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 1, e.CellBounds.Top, 1, e.CellBounds.Height)
                            e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 2, e.CellBounds.Top, 1, e.CellBounds.Height)
                        End If
                    Else
                        If col_date = SelectedItem.EndOfPTF Then
                            If e.RowIndex = -1 Then
                                e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 27, e.CellBounds.Top + 1, 27, 12)
                                e.Graphics.DrawString("PTF", New Font(PartnumberForecast_dgv.DefaultCellStyle.Font.FontFamily, 7), Brushes.White, e.CellBounds.Right - 25, e.CellBounds.Top + 1)
                                e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 2, e.CellBounds.Top + 1, 2, e.CellBounds.Height - 1)
                            Else
                                e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 2, e.CellBounds.Top, 2, e.CellBounds.Height)
                            End If
                        End If
                        If col_date = .EndOfSRT Then
                            If e.RowIndex = -1 Then
                                e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 27, e.CellBounds.Top + 1, 27, 12)
                                e.Graphics.DrawString("SRT", New Font(PartnumberForecast_dgv.DefaultCellStyle.Font.FontFamily, 7), Brushes.White, e.CellBounds.Right - 25, e.CellBounds.Top + 1)
                                e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 2, e.CellBounds.Top + 1, 2, e.CellBounds.Height - 1)
                            Else
                                e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds.Right - 2, e.CellBounds.Top, 2, e.CellBounds.Height)
                            End If
                        End If
                    End If
                End With
            Else
                'SI NO ES LEAN DIBUJAR SOLO LINEA DE PTF
                If col_date = SelectedItem.EndOfPTF Then
                    If e.RowIndex = -1 Then
                        e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 27, e.CellBounds.Top + 1, 27, 12)
                        e.Graphics.DrawString("PTF", New Font(PartnumberForecast_dgv.DefaultCellStyle.Font.FontFamily, 7), Brushes.White, e.CellBounds.Right - 25, e.CellBounds.Top + 1)
                        e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 2, e.CellBounds.Top + 1, 2, e.CellBounds.Height - 1)
                    Else
                        e.Graphics.FillRectangle(Brushes.OrangeRed, e.CellBounds.Right - 2, e.CellBounds.Top, 2, e.CellBounds.Height)
                    End If
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub PartnumberOpenOrders_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles PartnumberOpenOrders_dgv.CellPainting

        If e.RowIndex >= 0 Then
            If e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_Date_col").Index AndAlso CDate(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_Date_col").Value) < CurrentDate.Date AndAlso PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_Status_col").Value < 0 Then 'DIBUJAR ICONO DE WARNING POR CUESTION DEL PASTDUE
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.red_warning_16, e.CellBounds.Left, e.CellBounds.Top)
                e.Handled = True
            ElseIf e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_Status_col").Index AndAlso e.Value >= 0 Then 'DIBUJAR WARNING MORADO POR CUESTION DE SOBRE EMBARQUE
                'Select Case SelectedItem.Status(CDate(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_AvailabilityDate_col").Value).Date)
                '    Case ComponentPlanItemStatus.Excess, ComponentPlanItemStatus.Obsolete

                'End Select
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.purple_warning_16, e.CellBounds.Left, e.CellBounds.Top, 12, 12)
                e.Handled = True
            ElseIf e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_AvailabilityDate_col").Index AndAlso CDate(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_Date_col").Value) >= CurrentDate.Date Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Select Case SelectedItem.Status(CDate(e.Value).Date)
                    Case ComponentPlanItemStatus.Critical
                        e.Graphics.FillRectangle(Brushes.Red, e.CellBounds.Right - 3, e.CellBounds.Top, 3, e.CellBounds.Height)
                    Case ComponentPlanItemStatus.Minimum
                        e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds.Right - 3, e.CellBounds.Top, 3, e.CellBounds.Height)
                    Case ComponentPlanItemStatus.Normal
                        e.Graphics.FillRectangle(Brushes.YellowGreen, e.CellBounds.Right - 3, e.CellBounds.Top, 3, e.CellBounds.Height)
                    Case ComponentPlanItemStatus.Excess
                        e.Graphics.FillRectangle(Brushes.DarkSlateBlue, e.CellBounds.Right - 3, e.CellBounds.Top, 3, e.CellBounds.Height)
                    Case ComponentPlanItemStatus.Obsolete
                        e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds.Right - 3, e.CellBounds.Top, 3, e.CellBounds.Height)
                End Select
                e.Handled = True
            ElseIf e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOff_col").Index AndAlso PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_CallOffIssue_col").Value Then 'PROBLEMAS DE CALL OFF
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.red_warning_16, e.CellBounds.Left, e.CellBounds.Top)
                e.Handled = True
            ElseIf e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_CallOffQuantity_col").Index AndAlso PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_CallOffIssue_col").Value AndAlso Not IsNothing(e.Value) Then 'CANTIDAD DEL CALLOFF DIFERENTE A LA CANTIDAD DE LA ORDEN
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.red_warning_16, e.CellBounds.Left, e.CellBounds.Top)
                e.Handled = True
            End If
        End If
    End Sub
#End Region

#End Region

    Private Sub PhysicalInventoryQuantity_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles WIPQuantity_lbl.MouseDoubleClick
        If SelectedItem IsNot Nothing Then
            Dim background As New FadeBackground()
            background.Show()
            Dim new_pi As New CR_PhysicalInventoryDialog
            new_pi.Partnumber = SelectedItem.Partnumber.Partnumber
            new_pi.UoM = SelectedItem.Partnumber.UoM.ToString
            new_pi.Quantity = SelectedItem.WIPStock
            If new_pi.ShowDialog = Windows.Forms.DialogResult.OK Then
                background.Close()
                If SQL.Current.Insert("Ord_WIPStock", {"Partnumber", "Quantity", "UoM", "Username"}, {new_pi.Partnumber, new_pi.Quantity, new_pi.UoM, User.Current.Username}) Then
                    LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                Else
                    FlashAlerts.ShowError("Error al guardar la información.")
                End If
            Else
                background.Close()
            End If
            new_pi.Dispose()
        End If
    End Sub

    Private Sub LoadDashboard()
        LoadingScreen.Show()
        Dim excess_cost, obsolete_cost, critical_count, minimum_count, ok_count, excess_count, obsolete_count, ok_cost, critical_cost, minimum_cost, service_count, service_cost As Decimal
        Dim cancel_count, increase_count, decrease_count, add_count As Integer
        Dim cancel_cost, increase_cost, decrease_cost, add_cost As Decimal
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive) 'RECORRER TODOS LOS ITEMS DEL COMPONENT PLAN
                i.Value.RefreshQuickTasks()
                For Each j In i.Value.Items
                    Select Case j.Value.SuggestedTask.Action
                        Case QuickTasksAction.AddOrder
                            add_count += 1
                            add_cost += j.Value.SuggestedTask.Quantity * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.CancelOrder
                            cancel_count += 1
                            cancel_cost -= j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.CancelOrder).Sum(Function(s) s.Value.QuantityInBuM) * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.IncreaseOrder
                            increase_count += 1
                            increase_cost += (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder) * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.DecreaseOrder
                            decrease_count += 1
                            decrease_cost -= (j.Value.SumOpenOrder - j.Value.SuggestedTask.Quantity) * i.Value.Partnumber.UnitCost
                    End Select
                Next

                Select Case i.Value.Status(Delta.CurrentDate.Date)
                    Case ComponentPlanItemStatus.Critical
                        critical_count += 1
                        critical_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Minimum
                        minimum_count += 1
                        minimum_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Normal
                        ok_count += 1
                        ok_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Excess
                        excess_count += 1
                        excess_cost += (i.Value.StockBalance(Delta.CurrentDate.Date) - i.Value.Maximum(Delta.CurrentDate.Date)) * i.Value.Partnumber.UnitCost
                        ok_cost += i.Value.Maximum(Delta.CurrentDate.Date) * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Obsolete
                        If i.Value.DeltaStock + i.Value.WIPStock > 0 Then
                            If i.Value.Partnumber.MRP = "999" Then
                                service_count += 1
                                service_cost += (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost
                            Else
                                obsolete_count += 1
                                obsolete_cost += (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost
                            End If
                        End If
                End Select
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                i.Value.RefreshQuickTasks()
                For Each j In i.Value.Items
                    Select Case j.Value.SuggestedTask.Action
                        Case QuickTasksAction.AddOrder
                            add_count += 1
                            add_cost += j.Value.SuggestedTask.Quantity * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.CancelOrder
                            cancel_count += 1
                            cancel_cost -= j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.CancelOrder).Sum(Function(s) s.Value.QuantityInBuM) * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.IncreaseOrder
                            increase_count += 1
                            increase_cost += (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder) * i.Value.Partnumber.UnitCost
                        Case QuickTasksAction.DecreaseOrder
                            decrease_count += 1
                            decrease_cost -= (j.Value.SumOpenOrder - j.Value.SuggestedTask.Quantity) * i.Value.Partnumber.UnitCost
                    End Select
                Next

                Select Case i.Value.Status(Delta.CurrentDate.Date)
                    Case ComponentPlanItemStatus.Critical
                        critical_count += 1
                        critical_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Minimum
                        minimum_count += 1
                        minimum_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Normal
                        ok_count += 1
                        ok_cost += i.Value.DeltaStock * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Excess
                        excess_count += 1
                        excess_cost += (i.Value.StockBalance(Delta.CurrentDate.Date) - i.Value.Maximum(Delta.CurrentDate.Date)) * i.Value.Partnumber.UnitCost
                        ok_cost += i.Value.Maximum(Delta.CurrentDate.Date) * i.Value.Partnumber.UnitCost
                    Case ComponentPlanItemStatus.Obsolete
                        If i.Value.DeltaStock > 0 Then
                            If i.Value.Partnumber.MRP = "999" Then
                                service_count += 1
                                service_cost += (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost
                            Else
                                obsolete_count += 1
                                obsolete_cost += (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost
                            End If
                        End If
                End Select
            Next
        End If
        CriticalCount_lbl.Text = FormatNumber(critical_count, 0)
        CriticalCost_lbl.Text = FormatCurrency(critical_cost, 1)
        MinimumCount_lbl.Text = FormatNumber(minimum_count, 0)
        MinimumCost_lbl.Text = FormatCurrency(minimum_cost, 1)
        OKCount_lbl.Text = FormatNumber(ok_count, 0)
        OKCost_lbl.Text = FormatCurrency(ok_cost, 1)
        ExcessCount_lbl.Text = FormatNumber(excess_count, 0)
        ExcessCost_lbl.Text = FormatCurrency(excess_cost, 1)
        ObsoleteCount_lbl.Text = obsolete_count
        ObsoleteCost_lbl.Text = FormatCurrency(obsolete_cost, 1)
        ServiceCount_lbl.Text = FormatNumber(service_count, 0)
        ServiceCost_lbl.Text = FormatCurrency(service_cost, 1)
        TotalCost_lbl.Text = FormatCurrency(critical_cost + minimum_cost + ok_cost + excess_cost + obsolete_cost + service_cost, 1)
        ActivePartnumbers_lbl.Text = FormatNumber(critical_count + minimum_count + ok_count + excess_count + service_count, 0)

        DashboardAddOrders_lbl.Text = FormatNumber(add_count, 0)
        DashboardAddOrdersCost_lbl.Text = FormatCurrency(add_cost, 1)
        DashboardCancelOrders_lbl.Text = FormatNumber(cancel_count, 0)
        DashboardCancelOrdersCost_lbl.Text = FormatCurrency(cancel_cost, 1)
        DashboardIncreaseOrders_lbl.Text = FormatNumber(increase_count, 0)
        DashboardIncreaseOrdersCost_lbl.Text = FormatCurrency(increase_cost, 1)
        DashboardDecreaseOrders_lbl.Text = FormatNumber(decrease_count, 0)
        DashboardDecreaseOrdersCost_lbl.Text = FormatCurrency(decrease_cost, 1)

        'ForecastStatus_chart.DataSource = GetDashboardForecast()
        ''ForecastStatus_chart.Series("Minimum").XValueMember = "Fecha"
        ''ForecastStatus_chart.Series("Minimum").YValueMembers = "Minimo"
        ''ForecastStatus_chart.Series("OK").XValueMember = "Fecha"
        ''ForecastStatus_chart.Series("OK").YValueMembers = "Normal"
        'ForecastStatus_chart.Series("Excess").XValueMember = "Fecha"
        'ForecastStatus_chart.Series("Excess").YValueMembers = "Exceso"
        'ForecastStatus_chart.Series("Obsolete").XValueMember = "Fecha"
        'ForecastStatus_chart.Series("Obsolete").YValueMembers = "Obsoleto"
        ''ForecastStatus_chart.Series("Service").XValueMember = "Fecha"
        ''ForecastStatus_chart.Series("Service").YValueMembers = "Servicio"
        'ForecastStatus_chart.Series("Real").XValueMember = "Fecha"
        'ForecastStatus_chart.Series("Real").YValueMembers = "Real"
        'ForecastStatus_chart.Series("Pronostico").XValueMember = "Fecha"
        'ForecastStatus_chart.Series("Pronostico").YValueMembers = "Pronostico"
        'ForecastStatus_chart.DataBind()


        TopCost_dgv.DataSource = GetDashboardTopCost()
        TopQuantity_dgv.DataSource = GetDashboardTopQuantity()
        If DashboardMRP_cbo.SelectedValue = "*" Then
            DashboardPastdueTransits_lbl.Text = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Ord_Transits WHERE Active = 1 AND AvailabilityDate < CONVERT(DATE,GETDATE())")
            DashboardPastDueOrders_lbl.Text = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Ord_OpenOrders WHERE Active = 1 AND ShipDate < CONVERT(DATE,GETDATE()) AND [Status] < 0")
            DashboardNoNeededRequirement_lbl.Text = Main_Component_Plan.Items.Where(Function(w) w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.OrdersSum > 0).Sum(Function(s) s.Value.OrdersCount)
            DashboardNoNeededRequirementCost_lbl.Text = FormatCurrency(Main_Component_Plan.Items.Where(Function(w) w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.OrdersSum > 0).Sum(Function(s) s.Value.OrdersSum * s.Value.Partnumber.UnitCost), 1)
            DashboardCallOffIssues_lbl.Text = Main_Component_Plan.Items.Sum(Function(w) w.Value.CallOffIssuesCount)
            DashboardRedTagCount_lbl.Text = FormatNumber(SQL.Current.GetScalar("SELECT COUNT(SerialNumber) FROM vw_Smk_Serials WHERE Status NOT IN ('E','D') AND RedTag = 1", 0), 0)
            DashboardRedTagCost_lbl.Text = FormatCurrency(SQL.Current.GetScalar("SELECT SUM(S.CurrentQuantityInBuM * R.UnitCost) FROM vw_Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Status NOT IN ('E','D') AND S.RedTag = 1", 0), 1)
            DashboardTrackerCount_lbl.Text = FormatNumber(SQL.Current.GetScalar("SELECT COUNT(SerialNumber) FROM Smk_Serials WHERE Status NOT IN ('E','D') AND InvoiceTrouble = 1"), 0)
            DashboardTrackerCost_lbl.Text = FormatCurrency(SQL.Current.GetScalar("SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM) * R.UnitCost) FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Status NOT IN ('E','D') AND S.InvoiceTrouble = 1"), 1)
        Else
            DashboardPastdueTransits_lbl.Text = FormatNumber(SQL.Current.GetScalar(String.Format("SELECT COUNT(T.ID) FROM Ord_Transits AS T INNER JOIN Sys_RawMaterial AS R ON T.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE T.Active = 1 AND T.AvailabilityDate < CONVERT(DATE,GETDATE()) AND M.Username = '{0}';", DashboardMRP_cbo.SelectedValue)), 0)
            DashboardPastDueOrders_lbl.Text = FormatNumber(SQL.Current.GetScalar(String.Format("SELECT COUNT(O.ID) FROM Ord_OpenOrders AS O INNER JOIN Sys_RawMaterial AS R ON O.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE O.Active = 1 AND O.ShipDate < CONVERT(DATE,GETDATE()) AND O.[Status] < 0 AND M.Username = '{0}'", DashboardMRP_cbo.SelectedValue)), 0)
            DashboardNoNeededRequirement_lbl.Text = FormatNumber(Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue AndAlso w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.OrdersSum > 0).Sum(Function(s) s.Value.OrdersCount), 0)
            DashboardNoNeededRequirementCost_lbl.Text = FormatCurrency(Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue AndAlso w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.OrdersSum > 0).Sum(Function(s) s.Value.OrdersSum * s.Value.Partnumber.UnitCost), 1)
            DashboardCallOffIssues_lbl.Text = FormatNumber(Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue).Sum(Function(w) w.Value.CallOffIssuesCount), 0)
            DashboardRedTagCount_lbl.Text = FormatNumber(SQL.Current.GetScalar(String.Format("SELECT COUNT(S.SerialNumber) FROM vw_Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE Status NOT IN ('E','D') AND RedTag = 1 AND M.Username = '{0}'", DashboardMRP_cbo.SelectedValue), 0), 0)
            DashboardRedTagCost_lbl.Text = FormatCurrency(SQL.Current.GetScalar(String.Format("SELECT SUM(S.CurrentQuantityInBuM * R.UnitCost) FROM vw_Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE S.Status NOT IN ('E','D') AND S.RedTag = 1 AND M.Username = '{0}'", DashboardMRP_cbo.SelectedValue), 0), 1)
            DashboardTrackerCount_lbl.Text = FormatNumber(SQL.Current.GetScalar(String.Format("SELECT COUNT(S.SerialNumber) FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE Status NOT IN ('E','D') AND InvoiceTrouble = 1 AND M.Username = '{0}'", DashboardMRP_cbo.SelectedValue), 0), 0)
            DashboardTrackerCost_lbl.Text = FormatCurrency(SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM) * R.UnitCost) FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE S.Status NOT IN ('E','D') AND S.InvoiceTrouble = 1 AND M.Username = '{0}'", DashboardMRP_cbo.SelectedValue), 0), 1)
        End If
        LoadingScreen.Hide()
    End Sub

    Private Function StatusName(status As ComponentPlanItemStatus) As String
        Select Case status
            Case ComponentPlanItemStatus.Critical
                Return "Crítico"
            Case ComponentPlanItemStatus.Minimum
                Return "Mínimo"
            Case ComponentPlanItemStatus.Normal
                Return "Normal"
            Case ComponentPlanItemStatus.Excess
                Return "Exceso"
            Case ComponentPlanItemStatus.Obsolete
                Return "Obsoleto"
            Case Else
                Return ""
        End Select
    End Function

    Private Sub Stock_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles Stock_lbl.MouseDoubleClick
        Dim smk_serilas As New CR_ActiveRawMaterialSerials
        smk_serilas.DefaultLocation = New Point(Stock_lbl.PointToScreen(Point.Empty).X, Stock_lbl.PointToScreen(Point.Empty).Y)
        smk_serilas.Partnumber = SelectedItem.Partnumber.Partnumber
        smk_serilas.Show()
    End Sub

    Private Sub CR_ComponentPlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Main_Component_Plan IsNot Nothing Then
            Dim col_list As New List(Of ColumnStatus)
            For Each col As DataGridViewColumn In ComponentPlan_dgv.Columns
                col_list.Add(New ColumnStatus(col.Name, col.DisplayIndex, col.Visible))
            Next
            User.Current.SaveSetting("CR_ComponentPlan_GeneralDataGridView", col_list)
        End If
        search_box.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Comment_rtb_Validated(sender As Object, e As EventArgs) Handles Comment_rtb.Validated
        SaveComment()
        RefreshSelectedItemDataRow()
    End Sub

    Private Sub PartnumberTransits_dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles PartnumberTransits_dgv.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = PartnumberTransits_dgv.Columns("Transit_AvailabilityDate_col").Index Then
            If SQL.Current.Update("Ord_Transits", "RealDate", PartnumberTransits_dgv.Rows(e.RowIndex).Cells("Transit_AvailabilityDate_col").Value, "ID", PartnumberTransits_dgv.Rows(e.RowIndex).Cells("Transit_ID_col").Value) Then
                LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
            Else
                FlashAlerts.ShowError("Error al ingresar la fecha nueva.")
            End If
        End If
    End Sub

    Private Sub NewPromise_btn_Click(sender As Object, e As EventArgs) Handles NewPromise_btn.Click
        If SelectedItem IsNot Nothing Then
            Dim background As New FadeBackground()
            Dim new_promise As New CR_ComponentPlanNewPromise
            new_promise.MinDate = Delta.CurrentDate.Date
            new_promise.Partnumber = SelectedItem.Partnumber.Partnumber
            new_promise.UoM = SelectedItem.Partnumber.UoM.ToString
            background.Show()
            If new_promise.ShowDialog = Windows.Forms.DialogResult.OK Then
                background.Close()
                If SQL.Current.Insert("Ord_ManualPromises", {"Partnumber", "Quantity", "UoM", "AvailabilityDate", "Comment", "Username"}, {SelectedItem.Partnumber.Partnumber, new_promise.Quantity, new_promise.UoM, new_promise.Date, new_promise.Comment, User.Current.Username}) Then
                    LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                Else
                    FlashAlerts.ShowError("Error al guardar la información de la promesa.")
                End If
            Else
                background.Close()
            End If
            background.Dispose()
            new_promise.Dispose()
        End If
    End Sub

    Private Sub PartnumberPromises_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PartnumberPromises_dgv.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = PartnumberPromises_dgv.Columns("Promise_Delete_btn").Index Then
            If MessageBox.Show("¿Eliminar promesa?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                SQL.Current.Update("Ord_ManualPromises", "Active", 0, "ID", PartnumberPromises_dgv.Rows(e.RowIndex).Cells("Promise_ID_col").Value)
                LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
            End If
        End If
    End Sub

    Private Sub NewOrder_btn_Click(sender As Object, e As EventArgs) Handles NewOrder_btn.Click
        If SelectedItem IsNot Nothing Then
            With SelectedItem
                Dim background As New FadeBackground()
                Dim pickup_date As Date = Delta.CurrentDate.Date  'CALCULAR LA FECHA DONDE SE DEBE AGREGAR LA ORDEN PARA QUE LLEGUE A TIEMPO
                Dim suggest_quantity = .Partnumber.RoundByStdPack(1)
                Dim order As New CR_ComponentPlanNewOrder
                order.Partnumber = SelectedItem.Partnumber.Partnumber
                order.Quantity = suggest_quantity
                order.PickUpDate = pickup_date
                order.TSA = SelectedItem.Partnumber.Document
                order.Item = SelectedItem.Partnumber.DocumentItem
                background.Show()
                If order.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    background.Close()
                    LoadingScreen.Show()
                    Dim sap As New SAP
                    If sap.Available Then
                        If sap.ME38(.Partnumber.Partnumber, order.TSA, order.Item, True, order.PickUpDate, order.Quantity) Then
                            If UpdateOpenOrders(.Partnumber.Partnumber) Then
                                LoadingScreen.Hide()
                                LoadComponentPlanItem(.Partnumber.Partnumber)
                                FlashAlerts.ShowConfirm("Orden generada correctamente.")
                            Else
                                FlashAlerts.ShowInformation("La orden se genero en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'.", 3)
                            End If
                            LoadingScreen.Hide()
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al crear la orden.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Sesion de SAP no encontrada.")
                    End If
                Else
                    background.Close()
                End If
                background.Close()
                order.Dispose()
            End With
        End If
    End Sub

    Private Sub UpdateDB_btn_Click(sender As Object, e As EventArgs) Handles UpdateDB_btn.Click
        If SelectedItem IsNot Nothing Then
            LoadingScreen.Show()
            Dim oo As Boolean = UpdateOpenOrders(SelectedItem.Partnumber.Partnumber)
            Dim po As Boolean = UpdatePlannedOrders(SelectedItem.Partnumber.Partnumber)
            Dim tr As Boolean = UpdateTransits(SelectedItem.Partnumber.Partnumber)
            LoadingScreen.Hide()
            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
            If oo AndAlso po AndAlso tr Then
                FlashAlerts.ShowConfirm("Actualizado correctamente.")
            ElseIf Not oo AndAlso Not po AndAlso Not tr Then
                FlashAlerts.ShowError("No fue posible sincronizar la información.")
            Else
                FlashAlerts.ShowInformation(String.Format("No fue posible sincronizar toda la información:{0}Ordenes abiertas: {1}{0}Ordenes planeadas: {2}{0}Tránsitos: {3}", vbCrLf, If(oo, "OK", "Error"), If(po, "OK", "Error"), If(tr, "OK", "Error")), 3)
            End If
        End If
    End Sub
    Private Sub QuickActions_dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            LoadComponentPlanItem(ComponentPlan_dgv.Rows(e.RowIndex).Cells("Quick_Partnumber_col").Value)
        End If
    End Sub

    Private Sub Simulation_btn_Click(sender As Object, e As EventArgs) Handles Simulation_btn.Click
        If SelectedItem IsNot Nothing Then
            Dim simulator As New CR_ComponentPlanSimulation
            simulator.Partnumber = SelectedItem.Clone()
            simulator.ShowDialog()
            simulator.Dispose()
        End If
    End Sub

    Private Sub ImportPhysicalInventory_btn_Click(sender As Object, e As EventArgs) Handles ImportPhysicalInventory_btn.Click
        Dim inventory As New CR_ImportPhysicalInventory
        If inventory.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Main_Component_Plan IsNot Nothing Then
                ClearPartnumberData()
                SQL.Current.Execute("MERGE Ord_CurrentWIP AS target USING vw_Ord_CurrentWIP AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Date] = source.[Date], Quantity = source.Quantity, Usage = source.Usage WHEN NOT MATCHED THEN INSERT (Partnumber,[Date],Quantity,Usage) VALUES (source.Partnumber,source.[Date],source.[Quantity],source.Usage);")
                LoadMainComponentPlan()
            Else
                FlashAlerts.ShowConfirm("Inventario almacenado.")
            End If
        End If
    End Sub

    Private Sub ButtonQuickTask_Click(sender As Object, e As EventArgs)
        Dim item_date As ComponentPlanItemDate = CType(CType(sender, Button).Tag, ComponentPlanItemDate)
        Select Case item_date.SuggestedTask.Action
            Case QuickTasksAction.AddOrder
                If ComponentPlan.Suppliers.ContainsKey(SelectedItem.Partnumber.SupplierNumber) Then
                    LoadingScreen.Show()
                    Dim sap As New SAP
                    If sap.Available Then
                        Dim pickup_date As Date = Delta.BackWorkDay(item_date.Date, ComponentPlan.Suppliers.Item(SelectedItem.Partnumber.SupplierNumber).TransitTime)
                        If sap.ME38(SelectedItem.Partnumber.Partnumber, SelectedItem.Partnumber.Document, SelectedItem.Partnumber.DocumentItem, True, pickup_date, item_date.SuggestedTask.Quantity) Then
                            If UpdateOpenOrders(SelectedItem.Partnumber.Partnumber) Then
                                LoadingScreen.Hide()
                                LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                                FlashAlerts.ShowConfirm("Orden generada correctamente.")
                            Else
                                FlashAlerts.ShowInformation("La orden se genero en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'.", 3)
                            End If
                            LoadingScreen.Hide()
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al crear la orden.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                    End If
                Else
                    FlashAlerts.ShowError("El número de parte no tiene un proveedor válido asignado.")
                End If
            Case QuickTasksAction.CancelOrder
                LoadingScreen.Show()
                Dim sap As New SAP
                If sap.Available Then
                    Dim cancelled As Boolean = False
                    For Each o In item_date.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.CancelOrder Then
                            If sap.ME38(SelectedItem.Partnumber.Partnumber, o.Value.Document, o.Value.Item, o.Value.ShipDate, o.Value.Quantity, o.Value.ShipDate, 0) Then
                                cancelled = True
                            End If
                        End If
                    Next
                    If cancelled Then
                        If UpdateOpenOrders(SelectedItem.Partnumber.Partnumber) Then
                            LoadingScreen.Hide()
                            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                            FlashAlerts.ShowConfirm("Orden cancelada correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("La orden se canceló en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible cancelar ninguna orden.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                End If
            Case QuickTasksAction.IncreaseOrder
                LoadingScreen.Show()
                Dim sap As New SAP
                If sap.Available Then
                    Dim increased As Boolean = False
                    For Each o In item_date.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.IncreaseOrder Then
                            If sap.ME38(SelectedItem.Partnumber.Partnumber, o.Value.Document, o.Value.Item, o.Value.ShipDate, o.Value.Quantity, o.Value.ShipDate, item_date.SuggestedTask.Quantity) Then
                                increased = True
                            End If
                        End If
                    Next
                    If increased Then
                        If UpdateOpenOrders(SelectedItem.Partnumber.Partnumber) Then
                            LoadingScreen.Hide()
                            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                            FlashAlerts.ShowConfirm("Orden incrementada correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("La orden se incremento en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible incrementar ninguna orden.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                End If
            Case QuickTasksAction.DecreaseOrder
                LoadingScreen.Show()
                Dim sap As New SAP
                If sap.Available Then
                    Dim decreased As Boolean = False
                    For Each o In item_date.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.DecreaseOrder Then
                            If sap.ME38(SelectedItem.Partnumber.Partnumber, o.Value.Document, o.Value.Item, o.Value.ShipDate, o.Value.Quantity, o.Value.ShipDate, item_date.SuggestedTask.Quantity) Then
                                decreased = True
                            End If
                        End If
                    Next
                    If decreased Then
                        If UpdateOpenOrders(SelectedItem.Partnumber.Partnumber) Then
                            LoadingScreen.Hide()
                            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                            FlashAlerts.ShowConfirm("Orden decrementada correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("La orden se decrementó en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible decrementar ninguna orden.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                End If
            Case QuickTasksAction.FixAdjust, QuickTasksAction.FixCancel
                LoadingScreen.Show()
                Dim sap As New SAP
                If sap.Available Then
                    Dim fixed As Boolean = False
                    For Each o In item_date.OpenOrders
                        If o.Value.QuickTask = QuickTasksAction.FixAdjust OrElse o.Value.QuickTask = QuickTasksAction.FixCancel OrElse o.Value.QuickTask = QuickTasksAction.FixAndDealing Then
                            If sap.ME38(SelectedItem.Partnumber.Partnumber, o.Value.Document, o.Value.Item, o.Value.ShipDate, o.Value.Quantity, o.Value.ShipDate, item_date.SuggestedTask.Quantity) Then
                                fixed = True
                            End If
                        End If
                    Next
                    If fixed Then
                        If UpdateOpenOrders(SelectedItem.Partnumber.Partnumber) Then
                            LoadingScreen.Hide()
                            LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                            FlashAlerts.ShowConfirm("Orden ajustada correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("La orden se ajustó en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible ajustar ninguna orden.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Sesión de SAP no encontrada.")
                End If
            Case QuickTasksAction.FixAndDealing

        End Select
    End Sub

    Private Sub DOH_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Status_rb.CheckedChanged, Pieces_rb.CheckedChanged, DOH_rb.CheckedChanged, Cost_rb.CheckedChanged
        If Main_Component_Plan IsNot Nothing AndAlso CType(sender, RadioButton).Checked Then
            LoadingScreen.Show()
            LoadMainDatatable()
            LoadingScreen.Hide()
        End If
    End Sub

    Private Sub LastConsumption_lbl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LastConsumption_lbl.MouseDoubleClick
        If SelectedItem IsNot Nothing AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            ShowPopup(SQL.Current.GetDatatable(String.Format("SELECT TOP 10 S.Serialnumber AS [No. de Serie], D.[Description] AS Movimiento, M.Quantity AS Cantidad, S.UoM AS Unidad, M.[Date] AS Fecha FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID WHERE S.Partnumber = '{0}' AND M.[Quantity] < 0 ORDER BY M.[Date] DESC;", SelectedItem.Partnumber.Partnumber), SelectedItem.Partnumber.Partnumber), "Top 10 - Ultimos movimientos", 500, 300, New Point(LastConsumption_lbl.PointToScreen(Point.Empty).X - 250, LastConsumption_lbl.PointToScreen(Point.Empty).Y))
        End If
    End Sub

    Private Sub Flags_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Flags_cms.Opening
        If SelectedItem IsNot Nothing Then
            For Each i As ToolStripMenuItem In Flags_cms.Items
                If SelectedItem.Flags.Contains(i.Tag) Then
                    i.Checked = True
                Else
                    i.Checked = False
                End If
            Next
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Status_timer_Tick(sender As Object, e As EventArgs) Handles Status_timer.Tick
        UpdateJobUpdates()
        If SelectedItem IsNot Nothing AndAlso SQL.Current.Available Then
            RefreshItemUpdatingTime()
        End If
    End Sub

    Private Sub RefreshItemUpdatingTime()
        SelectItemUpdate_lbl.Text = String.Format("Última actualización: {0}", SelectedItem.UpdateTime.ToString)
        If DateDiff(DateInterval.Minute, SelectedItem.UpdateTime, Delta.CurrentDate) >= 15 Then
            SelectItemUpdate_lbl.BackColor = Color.Red
            SelectItemUpdate_lbl.ForeColor = Color.White
        ElseIf DateDiff(DateInterval.Minute, SelectedItem.UpdateTime, Delta.CurrentDate) >= 10 Then
            SelectItemUpdate_lbl.BackColor = Color.Yellow
            SelectItemUpdate_lbl.ForeColor = Color.Black
        Else
            SelectItemUpdate_lbl.BackColor = Color.Transparent
            SelectItemUpdate_lbl.ForeColor = Color.Black
        End If
        Dim last_movement = SQL.Current.GetRecord(String.Format("SELECT TOP 1 M.Quantity,S.UoM, M.[Date] FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID WHERE S.Partnumber = '{0}' AND M.Quantity < 0 ORDER BY M.[Date] DESC", SelectedItem.Partnumber.Partnumber))
        If last_movement IsNot Nothing AndAlso last_movement.Count > 0 Then
            LastConsumption_lbl.Text = String.Format("Último descuento: {0} | {1} {2}", CDate(last_movement.Item("date")).ToString, Math.Abs(Math.Round(CDec(last_movement.Item("quantity")), 1)), last_movement.Item("uom"))
        Else
            LastConsumption_lbl.Text = "Último descuento: N/D"
        End If
    End Sub

    Private Sub DashboardRefresh_btn_Click(sender As Object, e As EventArgs) Handles DashboardRefresh_btn.Click
        If Main_Component_Plan IsNot Nothing AndAlso DashboardMRP_cbo.SelectedIndex >= 0 Then LoadDashboard()
    End Sub

    Private Sub TopQuantity_dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TopQuantity_dgv.CellContentDoubleClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 AndAlso Main_Component_Plan IsNot Nothing Then
            LoadComponentPlanItem(TopQuantity_dgv.Rows(e.RowIndex).Cells("TopQuantity_Partnumber_col").Value)
        End If
    End Sub

    Private Sub TopCost_dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TopCost_dgv.CellContentDoubleClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 AndAlso Main_Component_Plan IsNot Nothing Then
            LoadComponentPlanItem(TopCost_dgv.Rows(e.RowIndex).Cells("TopCost_Partnumber_col").Value)
        End If
    End Sub

    Private Sub DashboardPastdueTransits_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardPastdueTransits_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardPastDueTransit, "Tránsitos Past Due", 550, 250, New Point(Issues_pnl.Location.X + DashboardPastdueTransits_lbl.Location.X, Issues_pnl.Location.Y + DashboardPastdueTransits_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Cantidad", "N1"}, {"Fecha de Llegada", "M"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardPastDueOrders_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardPastDueOrders_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardPastDueOrder, "Órdenes Past Due", 650, 250, New Point(Issues_pnl.Location.X + DashboardPastDueOrders_lbl.Location.X, Issues_pnl.Location.Y + DashboardPastDueOrders_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Cantidad", "N1"}})
        End If
    End Sub

    Private Sub DashboardNoNeededRequirement_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardNoNeededRequirementCost_lbl.MouseDoubleClick, DashboardNoNeededRequirement_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardNoNeededOrder, "Órdenes sin Requerimiento", 740, 250, New Point(Issues_pnl.Location.X + DashboardNoNeededRequirement_lbl.Location.X, Issues_pnl.Location.Y + DashboardNoNeededRequirement_lbl.Location.Y), {{"Costo", "C1"}, {"Cantidad", "N1"}, {"Fecha de Embarque", "M"}})
        End If
    End Sub

    Private Sub DashboardCallOffIssues_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardCallOffIssues_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardCallOffIssue, "Problemas de Call Off", 750, 250, New Point(Issues_pnl.Location.X + DashboardCallOffIssues_lbl.Location.X, Issues_pnl.Location.Y + DashboardCallOffIssues_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Cantidad", "N1"}, {"Cantidad Call Off", "N1"}})
        End If
    End Sub

    Private Sub DashboardAddOrders_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardAddOrdersCost_lbl.MouseDoubleClick, DashboardAddOrders_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardAddOrder, "Agregar Órdenes", 593, 250, New Point(Suggests_pnl.Location.X + DashboardAddOrders_lbl.Location.X, Suggests_pnl.Location.Y + DashboardAddOrders_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Fecha de Llegada", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardIncreaseOrders_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardIncreaseOrdersCost_lbl.MouseDoubleClick, DashboardIncreaseOrders_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardIncreaseOrder, "Incrementar Órdenes", 650, 250, New Point(Suggests_pnl.Location.X + DashboardIncreaseOrders_lbl.Location.X, Suggests_pnl.Location.Y + DashboardIncreaseOrders_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardCancelOrders_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardCancelOrdersCost_lbl.MouseDoubleClick, DashboardCancelOrders_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardCancelOrder, "Cancelar Órdenes", 750, 250, New Point(Suggests_pnl.Location.X + DashboardCancelOrders_lbl.Location.X, Suggests_pnl.Location.Y + DashboardCancelOrders_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Fecha de Llegada", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardDecreaseOrders_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardDecreaseOrdersCost_lbl.MouseDoubleClick, DashboardDecreaseOrders_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardDecreaseOrder, "Decrementar Órdenes", 650, 250, New Point(Suggests_pnl.Location.X + DashboardDecreaseOrders_lbl.Location.X, Suggests_pnl.Location.Y + DashboardDecreaseOrders_lbl.Location.Y), {{"Fecha de Embarque", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardRedTagCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardRedTagCount_lbl.MouseDoubleClick, DashboardRedTagCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardRedtag, "Etiqueta Roja", 590, 250, New Point(Others_pnl.Location.X + DashboardRedTagCount_lbl.Location.X, Others_pnl.Location.Y + DashboardRedTagCount_lbl.Location.Y), {{"Fecha de Recibo", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub DashboardTrackerCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles DashboardTrackerCount_lbl.MouseDoubleClick, DashboardTrackerCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardTracker, "Tracker de Problemas", 590, 250, New Point(Others_pnl.Location.X + DashboardTrackerCount_lbl.Location.X, Others_pnl.Location.Y + DashboardTrackerCount_lbl.Location.Y), {{"Fecha de Recibo", "M"}, {"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub CriticalCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles CriticalCount_lbl.MouseDoubleClick, CriticalCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardCritical, "Crítico", 720, 250, New Point(Critical_pnl.Location.X + CriticalCount_lbl.Location.X, Critical_pnl.Location.Y + CriticalCount_lbl.Location.Y), {{"Cantidad Actual", "N1"}, {"Requerimiento Semana Actual", "N1"}, {"Recibos Semana Actual", "N1"}, {"Balance Semana Actual", "N1"}})
        End If
    End Sub

    Private Sub MinimumCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles MinimumCount_lbl.MouseDoubleClick, MinimumCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardMinimum, "Mínimo", 720, 250, New Point(Minimum_pnl.Location.X + MinimumCount_lbl.Location.X, Minimum_pnl.Location.Y + MinimumCount_lbl.Location.Y), {{"Cantidad Actual", "N1"}, {"Requerimiento Semana Actual", "N1"}, {"Recibos Semana Actual", "N1"}, {"Balance Semana Actual", "N1"}})
        End If
    End Sub

    Private Sub OKCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles OKCount_lbl.MouseDoubleClick, OKCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardNormal, "Normal", 720, 250, New Point(Normal_pnl.Location.X + OKCount_lbl.Location.X, Normal_pnl.Location.Y + OKCount_lbl.Location.Y), {{"Cantidad Actual", "N1"}, {"Requerimiento Semana Actual", "N1"}, {"Recibos Semana Actual", "N1"}, {"Balance Semana Actual", "N1"}})
        End If
    End Sub

    Private Sub ExcessCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles ExcessCount_lbl.MouseDoubleClick, ExcessCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardExcess, "Exceso", 550, 250, New Point(Excess_pnl.Location.X + ExcessCount_lbl.Location.X, Excess_pnl.Location.Y + ExcessCount_lbl.Location.Y), {{"Cantidad Actual", "N1"}, {"Maximo", "N1"}, {"Exceso", "N1"}, {"Costo", "C1"}, {"DOH", "N1"}, {"Uso Diario", "N1"}})
        End If
    End Sub

    Private Sub ObsoleteCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles ObsoleteCount_lbl.MouseDoubleClick, ObsoleteCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardObsolete, "Obsoleto", 390, 250, New Point(Obsolete_pnl.Location.X + ObsoleteCount_lbl.Location.X, Obsolete_pnl.Location.Y + ObsoleteCount_lbl.Location.Y), {{"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub ServiceCount_lbl_DoubleClick(sender As Object, e As MouseEventArgs) Handles ServiceCount_lbl.MouseDoubleClick, ServiceCost_lbl.MouseDoubleClick
        If Main_Component_Plan IsNot Nothing Then
            LocalPopup(GetDashboardService, "Servicio", 390, 250, New Point(Service_pnl.Location.X + ServiceCount_lbl.Location.X, Service_pnl.Location.Y + ServiceCount_lbl.Location.Y), {{"Cantidad", "N1"}, {"Costo", "C1"}})
        End If
    End Sub

    Private Sub LocalPopup(datasource As DataTable, title As String, width As Single, height As Single, location As Point, Optional format_list As String(,) = Nothing)
        Dim popup As New PopupReport
        popup.Size = New Size(width, height)
        popup.Datasource = datasource
        popup.Title = title
        popup.StartLocation = location
        popup.Formats = format_list
        popup.ReturnDataRow = False
        popup.DisposeOnClosing = True
        popup.TopLevel = False
        QuickVersion_tab.Controls.Add(popup)
        AddHandler popup.Report_dgv.CellContentDoubleClick, AddressOf Popup_CellContentDoubleClick
        popup.Show()
        popup.BringToFront()
    End Sub

    Private Sub Popup_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataRowView = CType(sender, DataGridView).Rows(e.RowIndex).DataBoundItem
            If row IsNot Nothing Then
                LoadComponentPlanItem(row.Item("No. de Parte"))
            End If
        End If
    End Sub

    Private Sub Dashboard_Export_btn_Click(sender As Object, e As EventArgs) Handles Dashboard_Export_btn.Click
        If Main_Component_Plan IsNot Nothing Then
            LoadingScreen.Show()
            Dim critical_dt As DataTable = GetDashboardCritical()
            Dim minimum_dt As DataTable = GetDashboardMinimum()
            Dim normal_dt As DataTable = GetDashboardNormal()
            Dim excess_dt As DataTable = GetDashboardExcess()
            Dim obsolete_dt As DataTable = GetDashboardObsolete()
            Dim service_dt As DataTable = GetDashboardService()
            Dim top_cost_dt As DataTable = GetDashboardTopCost()
            Dim top_quantity_dt As DataTable = GetDashboardTopQuantity()
            Dim forecast_dt As DataTable = GetDashboardForecast()
            Dim ord_pastdue_dt As DataTable = GetDashboardPastDueOrder()
            Dim transits_pastdue_dt As DataTable = GetDashboardPastDueTransit()
            Dim noneeded_orders_dt As DataTable = GetDashboardNoNeededOrder()
            Dim calloff_issues_dt As DataTable = GetDashboardCallOffIssue()
            Dim redtag_dt As DataTable = GetDashboardRedtag()
            Dim tracker_dt As DataTable = GetDashboardTracker()
            Dim add_orders_dt As DataTable = GetDashboardAddOrder()
            Dim cancel_orders_dt As DataTable = GetDashboardCancelOrder()
            Dim decrease_orders_dt As DataTable = GetDashboardDecreaseOrder()
            Dim increase_orders_dt As DataTable = GetDashboardIncreaseOrder()
            If MyExcel.SaveAs({decrease_orders_dt, increase_orders_dt, cancel_orders_dt, add_orders_dt, tracker_dt, redtag_dt, calloff_issues_dt, noneeded_orders_dt, ord_pastdue_dt, transits_pastdue_dt, top_cost_dt, top_quantity_dt, service_dt, obsolete_dt, excess_dt, normal_dt, minimum_dt, critical_dt, forecast_dt}, False) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Function GetDashboardService() As DataTable
        Dim dt As New DataTable("Servicio")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.DeltaStock + w.Value.WIPStock > 0 AndAlso w.Value.Partnumber.MRP = "999")
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost)
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.DeltaStock + w.Value.WIPStock > 0 AndAlso w.Value.Partnumber.MRP = "999" AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost)
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardObsolete() As DataTable
        Dim dt As New DataTable("Obsoleto")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.DeltaStock + w.Value.WIPStock > 0 AndAlso w.Value.Partnumber.MRP <> "999")
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost)
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.DeltaStock + w.Value.WIPStock > 0 AndAlso w.Value.Partnumber.MRP <> "999" AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, (i.Value.DeltaStock + i.Value.WIPStock) * i.Value.Partnumber.UnitCost)
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardExcess() As DataTable
        Dim dt As New DataTable("Exceso")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad Actual", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Maximo", GetType(Decimal))
        dt.Columns.Add("Exceso", GetType(Decimal))
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Uso Diario", GetType(Decimal))
        dt.Columns.Add("DOH", GetType(Decimal))


        Dim stock_balance, avg_usage, maximum As Decimal
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Excess)
                stock_balance = i.Value.StockBalance(Delta.CurrentDate)
                maximum = i.Value.Maximum(Delta.CurrentDate.Date)
                avg_usage = i.Value.AverageDailyDemand(Delta.CurrentDate)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, stock_balance, i.Value.Partnumber.UoM.ToString, maximum, stock_balance - maximum, (stock_balance - maximum) * i.Value.Partnumber.UnitCost, avg_usage, If(avg_usage > 0, stock_balance / avg_usage, 9999))
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Excess AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                stock_balance = i.Value.StockBalance(Delta.CurrentDate)
                maximum = i.Value.Maximum(Delta.CurrentDate.Date)
                avg_usage = i.Value.AverageDailyDemand(Delta.CurrentDate)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, stock_balance, i.Value.Partnumber.UoM.ToString, maximum, stock_balance - maximum, (stock_balance - maximum) * i.Value.Partnumber.UnitCost, avg_usage, If(avg_usage > 0, stock_balance / avg_usage, 9999))
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardNormal() As DataTable
        Dim dt As New DataTable("Normal")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad Actual", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Requerimiento Semana Actual", GetType(Decimal))
        dt.Columns.Add("Recibos Semana Actual", GetType(Decimal))
        dt.Columns.Add("Balance Semana Actual", GetType(Decimal), "[Cantidad Actual] + [Recibos Semana Actual] - [Requerimiento Semana Actual]")
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Normal)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Normal AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardMinimum() As DataTable
        Dim dt As New DataTable("Minimo")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad Actual", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Requerimiento Semana Actual", GetType(Decimal))
        dt.Columns.Add("Recibos Semana Actual", GetType(Decimal))
        dt.Columns.Add("Balance Semana Actual", GetType(Decimal), "[Cantidad Actual] + [Recibos Semana Actual] - [Requerimiento Semana Actual]")
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Minimum)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Minimum AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardCritical() As DataTable
        Dim dt As New DataTable("Critico")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad Actual", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Requerimiento Semana Actual", GetType(Decimal))
        dt.Columns.Add("Recibos Semana Actual", GetType(Decimal))
        dt.Columns.Add("Balance Semana Actual", GetType(Decimal), "[Cantidad Actual] + [Recibos Semana Actual] - [Requerimiento Semana Actual]")
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Critical)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.Status(Delta.CurrentDate) = ComponentPlanItemStatus.Critical AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UoM.ToString, i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.Requirement), i.Value.Items.Where(Function(w) Between(w.Value.Date, Delta.CurrentDate, NextSunday(Delta.CurrentDate))).Sum(Function(s) s.Value.SumTransit + s.Value.SumOpenOrder + s.Value.SumPromise + s.Value.SumPlannedOrder))
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardTracker() As DataTable
        If DashboardMRP_cbo.SelectedValue = "*" Then
            Return SQL.Current.GetDatatable("SELECT S.SerialNumber AS [No. de Serie],S.Partnumber AS [No. de Parte],S.Quantity AS Cantidad, S.UoM AS Unidad,S.Date AS [Fecha de Recibo], dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM) * R.UnitCost AS Costo FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Status NOT IN ('E','D') AND S.InvoiceTrouble = 1 ORDER BY S.Date", "Tracker")
        Else
            Return SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS [No. de Serie],S.Partnumber AS [No. de Parte],S.Quantity AS Cantidad, S.UoM AS Unidad,S.Date AS [Fecha de Recibo], dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM) * R.UnitCost AS Costo FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE S.Status NOT IN ('E','D') AND S.InvoiceTrouble = 1 AND M.Username = '{0}' ORDER BY S.Date", DashboardMRP_cbo.SelectedValue), "Tracker")
        End If
    End Function
    Private Function GetDashboardRedtag() As DataTable
        If DashboardMRP_cbo.SelectedValue = "*" Then
            Return SQL.Current.GetDatatable("SELECT S.SerialNumber AS [No. de Serie],S.Partnumber AS [No. de Parte],S.CurrentQuantity AS Cantidad,S.UoM AS Unidad,S.Date AS [Fecha de Recibo],S.CurrentQuantityInBuM * R.UnitCost AS Costo FROM vw_Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Status NOT IN ('E','D') AND S.RedTag = 1 ORDER BY S.Date", "Etiqueta Roja")
        Else
            Return SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS [No. de Serie],S.Partnumber AS [No. de Parte],S.CurrentQuantity AS Cantidad,S.UoM AS Unidad,S.Date AS [Fecha de Recibo],S.CurrentQuantityInBuM * R.UnitCost AS Costo FROM vw_Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE S.Status NOT IN ('E','D') AND S.RedTag = 1 AND M.Username = '{0}' ORDER BY S.Date", DashboardMRP_cbo.SelectedValue), "Etiqueta Roja")
        End If
    End Function
    Private Function GetDashboardDecreaseOrder() As DataTable
        Dim dt As New DataTable("Decrementar Ordenes")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Comentario", GetType(String))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive) 'RECORRER TODOS LOS ITEMS DEL COMPONENT PLAN
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.DecreaseOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.DecreaseOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, j.Value.SuggestedTask.Quantity - k.Value.QuantityInBuM, i.Value.Partnumber.UoM.ToString, (j.Value.SuggestedTask.Quantity - k.Value.QuantityInBuM) * i.Value.Partnumber.UnitCost, k.Value.Comment)
                    Next
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.DecreaseOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.DecreaseOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, j.Value.SuggestedTask.Quantity - k.Value.QuantityInBuM, i.Value.Partnumber.UoM.ToString, (j.Value.SuggestedTask.Quantity - k.Value.QuantityInBuM) * i.Value.Partnumber.UnitCost, k.Value.Comment)
                    Next
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardCancelOrder() As DataTable
        Dim dt As New DataTable("Cancelar Ordenes")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        dt.Columns.Add("Fix", GetType(Boolean))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Agregar Orden Previa", GetType(Boolean))
        dt.Columns.Add("Comentario", GetType(String))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive) 'RECORRER TODOS LOS ITEMS DEL COMPONENT PLAN
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.CancelOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.CancelOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, k.Value.AvailabilityDate, k.Value.Fix, k.Value.QuantityInBuM, i.Value.Partnumber.UoM.ToString, k.Value.QuantityInBuM * i.Value.Partnumber.UnitCost, i.Value.Items.Where(Function(w) w.Key < j.Key AndAlso (w.Value.SuggestedTask.Action = QuickTasksAction.AddOrder OrElse w.Value.SuggestedTask.Action = QuickTasksAction.IncreaseOrder)).Any(), k.Value.Comment)
                    Next
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.CancelOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.CancelOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, k.Value.AvailabilityDate, k.Value.Fix, k.Value.QuantityInBuM, i.Value.Partnumber.UoM.ToString, k.Value.QuantityInBuM * i.Value.Partnumber.UnitCost, i.Value.Items.Where(Function(w) w.Key < j.Key AndAlso (w.Value.SuggestedTask.Action = QuickTasksAction.AddOrder OrElse w.Value.SuggestedTask.Action = QuickTasksAction.IncreaseOrder)).Any(), k.Value.Comment)
                    Next
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardIncreaseOrder() As DataTable
        Dim dt As New DataTable("Incrementar Ordenes")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Comentario", GetType(String))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive) 'RECORRER TODOS LOS ITEMS DEL COMPONENT PLAN
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.IncreaseOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.IncreaseOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder), i.Value.Partnumber.UoM.ToString, (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder) * i.Value.Partnumber.UnitCost, k.Value.Comment)
                    Next
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.IncreaseOrder)
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.QuickTask = QuickTasksAction.IncreaseOrder)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder), i.Value.Partnumber.UoM.ToString, (j.Value.SuggestedTask.Quantity - j.Value.SumOpenOrder) * i.Value.Partnumber.UnitCost, k.Value.Comment)
                    Next
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardAddOrder() As DataTable
        Dim dt As New DataTable("Agregar Ordenes")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Fecha de Llegada", GetType(Date))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive) 'RECORRER TODOS LOS ITEMS DEL COMPONENT PLAN
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.AddOrder)
                    dt.Rows.Add(i.Value.Partnumber.Partnumber, BackWorkDay(j.Key, i.Value.Partnumber.GRT), j.Key, j.Value.SuggestedTask.Quantity, i.Value.Partnumber.UoM.ToString, j.Value.SuggestedTask.Quantity * i.Value.Partnumber.UnitCost)
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SuggestedTask.Action = QuickTasksAction.AddOrder)
                    dt.Rows.Add(i.Value.Partnumber.Partnumber, BackWorkDay(j.Key, i.Value.Partnumber.GRT), j.Key, j.Value.SuggestedTask.Quantity, i.Value.Partnumber.UoM.ToString, j.Value.SuggestedTask.Quantity * i.Value.Partnumber.UnitCost)
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardCallOffIssue() As DataTable
        Dim dt As New DataTable("Problemas de Call Off")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Call Off")
        dt.Columns.Add("Cantidad Call Off", GetType(Decimal))
        dt.Columns.Add("Comentario", GetType(String))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso w.Value.CallOffIssuesCount > 0)
                For Each j In i.Value.Items
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.CallOffIssue)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, k.Value.QuantityInBuM, k.Value.UoM, String.Join(",", k.Value.CallOffs.Keys.ToArray), k.Value.CallOffs.Sum(Function(s) s.Value.Quantity), k.Value.Comment)
                    Next
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive AndAlso MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue AndAlso w.Value.CallOffIssuesCount > 0)
                For Each j In i.Value.Items
                    For Each k In j.Value.OpenOrders.Where(Function(w) w.Value.CallOffIssue)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, k.Value.ShipDate, k.Value.QuantityInBuM, k.Value.UoM, String.Join(",", k.Value.CallOffs.Keys.ToArray), k.Value.CallOffs.Sum(Function(s) s.Value.Quantity), k.Value.Comment)
                    Next
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardNoNeededOrder() As DataTable
        Dim dt As New DataTable("Ordenes sin Requerimiento")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Unidad")
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Fecha de Embarque", GetType(Date))
        dt.Columns.Add("Fix", GetType(Boolean))
        dt.Columns.Add("Dueño", GetType(String))
        dt.Columns.Add("Comentario", GetType(String))
        If DashboardMRP_cbo.SelectedValue = "*" Then
            For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete AndAlso w.Value.OrdersSum > 0)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SumOpenOrder > 0)
                    For Each o In j.Value.OpenOrders.Where(Function(w) w.Value.RealQuantityInBuM > 0)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, o.Value.RealQuantityInBuM, i.Value.Partnumber.UoM.ToString, o.Value.RealQuantityInBuM * i.Value.Partnumber.UnitCost, o.Value.ShipDate, o.Value.Fix, If(ComponentPlan.MRPOwners.ContainsKey(i.Value.Partnumber.MRP), ComponentPlan.MRPOwners.Item(i.Value.Partnumber.MRP), "S/D"), o.Value.Comment)
                    Next
                Next
                For Each j In i.Value.Items.Where(Function(w) w.Value.SumPlannedOrder > 0)
                    For Each o In j.Value.PlannedOrders
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, o.Value.QuantityBuM, i.Value.Partnumber.UoM.ToString, o.Value.QuantityBuM * i.Value.Partnumber.UnitCost, o.Value.OpeningDate, False, If(ComponentPlan.MRPOwners.ContainsKey(i.Value.Partnumber.MRP), ComponentPlan.MRPOwners.Item(i.Value.Partnumber.MRP), "S/D"), "Orden Planeada")
                    Next
                Next
            Next
        Else
            For Each i In Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue AndAlso w.Value.Status(Delta.CurrentDate.Date) = ComponentPlanItemStatus.Obsolete)
                For Each j In i.Value.Items.Where(Function(w) w.Value.SumOpenOrder > 0)
                    For Each o In j.Value.OpenOrders.Where(Function(w) w.Value.RealQuantityInBuM > 0)
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, o.Value.RealQuantityInBuM, i.Value.Partnumber.UoM.ToString, o.Value.RealQuantityInBuM * i.Value.Partnumber.UnitCost, o.Value.ShipDate, o.Value.Fix, If(ComponentPlan.MRPOwners.ContainsKey(i.Value.Partnumber.MRP), ComponentPlan.MRPOwners.Item(i.Value.Partnumber.MRP), "S/D"), o.Value.Comment)
                    Next
                Next
                For Each j In i.Value.Items.Where(Function(w) w.Value.SumPlannedOrder > 0)
                    For Each o In j.Value.PlannedOrders
                        dt.Rows.Add(i.Value.Partnumber.Partnumber, o.Value.QuantityBuM, i.Value.Partnumber.UoM.ToString, o.Value.QuantityBuM * i.Value.Partnumber.UnitCost, o.Value.OpeningDate, False, If(ComponentPlan.MRPOwners.ContainsKey(i.Value.Partnumber.MRP), ComponentPlan.MRPOwners.Item(i.Value.Partnumber.MRP), "S/D"), "Orden Planeada")
                    Next
                Next
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardPastDueOrder() As DataTable
        If DashboardMRP_cbo.SelectedValue = "*" Then
            Return SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],SupplierName AS Proveedor,ShipDate AS [Fecha de Embarque],Quantity AS Cantidad,UoM AS Unidad,Comment AS Comentario FROM Ord_OpenOrders WHERE Active = 1 AND ShipDate < CONVERT(DATE,GETDATE()) AND [Status] < 0 AND Quantity >= 1 ORDER BY ShipDate,Proveedor,Partnumber", "Ordenes Past Due")
        Else
            Return SQL.Current.GetDatatable(String.Format("SELECT O.Partnumber AS [No. de Parte],O.SupplierName AS Proveedor,O.ShipDate AS [Fecha de Embarque],O.Quantity AS Cantidad,O.UoM AS Unidad,Comment AS Comentario FROM Ord_OpenOrders AS O INNER JOIN Sys_RawMaterial AS R ON O.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE O.Active = 1 AND O.ShipDate < CONVERT(DATE,GETDATE()) AND O.[Status] < 0 AND Quantity >= 1 AND M.Username = '{0}' ORDER BY O.ShipDate,O.SupplierNumber,O.Partnumber", DashboardMRP_cbo.SelectedValue), "Ordenes Past Due")
        End If
    End Function
    Private Function GetDashboardPastDueTransit() As DataTable
        If DashboardMRP_cbo.SelectedValue = "*" Then
            'Return SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],DeliveryDate AS [Fecha de Embarque],AvailabilityDate AS [Fecha de Llegada],Quantity AS Cantidad,UoM AS Unidad,dbo.Sys_UnitConversion(Partnumber,UoM,Quantity,'') * UnitCost AS Costo, DeliveryNumber AS [No. de Delivery] FROM Ord_Transits INNER JOIN Del WHERE Active = 1 AND AvailabilityDate < CONVERT(DATE,GETDATE()) ORDER BY DeliveryDate", "Transitos Past Due")
            Return SQL.Current.GetDatatable(String.Format("SELECT T.Partnumber AS [No. de Parte],T.DeliveryDate AS [Fecha de Embarque],AvailabilityDate AS [Fecha de Llegada],T.Quantity AS Cantidad,T.UoM AS Unidad,dbo.Sys_UnitConversion(T.Partnumber,T.UoM,T.Quantity,R.UoM) * R.UnitCost AS Costo, DeliveryNumber AS [No. de Delivery],U.Fullname AS [MRPC] FROM Ord_Transits AS T INNER JOIN Sys_RawMaterial AS R ON T.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE T.Active = 1 AND T.AvailabilityDate < CONVERT(DATE,GETDATE()) ORDER BY DeliveryDate;"), "Transitos Past Due")
        Else
            Return SQL.Current.GetDatatable(String.Format("SELECT T.Partnumber AS [No. de Parte],T.DeliveryDate AS [Fecha de Embarque],AvailabilityDate AS [Fecha de Llegada],T.Quantity AS Cantidad,T.UoM AS Unidad,dbo.Sys_UnitConversion(T.Partnumber,T.UoM,T.Quantity,R.UoM) * R.UnitCost AS Costo, DeliveryNumber AS [No. de Delivery] FROM Ord_Transits AS T INNER JOIN Sys_RawMaterial AS R ON T.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP WHERE T.Active = 1 AND T.AvailabilityDate < CONVERT(DATE,GETDATE()) AND M.Username = '{0}';", DashboardMRP_cbo.SelectedValue), "Transitos Past Due")
        End If
    End Function
    Private Function GetDashboardTopCost() As DataTable
        Dim dt As New DataTable("Top 10 Costo")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Estatus")
        If DashboardMRP_cbo.SelectedValue = "*" Then
            Dim top_cost = Main_Component_Plan.Items.OrderByDescending(Function(w) w.Value.Partnumber.UnitCost * (w.Value.DeltaStock + w.Value.WIPStock)).Take(10)
            For Each i In top_cost
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.Partnumber.UnitCost * (i.Value.DeltaStock + i.Value.WIPStock), i.Value.DeltaStock + i.Value.WIPStock, StatusName(i.Value.Status(Delta.CurrentDate)))
            Next
        Else
            Dim top_cost = Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue).OrderByDescending(Function(w) w.Value.Partnumber.UnitCost * (w.Value.DeltaStock + w.Value.WIPStock)).Take(10)
            For Each i In top_cost
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.Partnumber.UnitCost * (i.Value.DeltaStock + i.Value.WIPStock), i.Value.DeltaStock + i.Value.WIPStock, StatusName(i.Value.Status(Delta.CurrentDate)))
            Next
        End If
        Return dt
    End Function
    Private Function GetDashboardTopQuantity() As DataTable
        Dim dt As New DataTable("Top 10 Cantidad")
        dt.Columns.Add("No. de Parte")
        dt.Columns.Add("Cantidad", GetType(Decimal))
        dt.Columns.Add("Costo", GetType(Decimal))
        dt.Columns.Add("Estatus")
        If DashboardMRP_cbo.SelectedValue = "*" Then
            Dim top_quantity = Main_Component_Plan.Items.OrderByDescending(Function(w) w.Value.DeltaStock + w.Value.WIPStock).Take(10)
            For Each i In top_quantity
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UnitCost * (i.Value.DeltaStock + i.Value.WIPStock), StatusName(i.Value.Status(Delta.CurrentDate)))
            Next
        Else
            Dim top_quantity = Main_Component_Plan.Items.Where(Function(w) MRPCs.ContainsKey(w.Value.Partnumber.MRP) AndAlso MRPCs.Item(w.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue).OrderByDescending(Function(w) w.Value.DeltaStock + w.Value.WIPStock).Take(10)
            For Each i In top_quantity
                dt.Rows.Add(i.Value.Partnumber.Partnumber, i.Value.DeltaStock + i.Value.WIPStock, i.Value.Partnumber.UnitCost * (i.Value.DeltaStock + i.Value.WIPStock), StatusName(i.Value.Status(Delta.CurrentDate)))
            Next
        End If
        Return dt
    End Function


    Private Function GetDashboardForecast() As DataTable
        Dim dt As New DataTable("Forecast")
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("Minimo", GetType(Decimal))
        dt.Columns.Add("Normal", GetType(Decimal))
        dt.Columns.Add("Exceso", GetType(Decimal))
        dt.Columns.Add("Obsoleto", GetType(Decimal))
        dt.Columns.Add("Servicio", GetType(Decimal))
        dt.Columns.Add("Pronostico", GetType(Decimal))
        dt.Columns.Add("Real", GetType(Decimal), "Minimo + Normal + Exceso + Obsoleto + Servicio")

        Dim chart_excess_cost, chart_obsolete_cost, chart_ok_cost, chart_minimum_cost, chart_service_cost, chart_forecast_cost As Decimal
        Dim day As Date = Delta.CurrentDate.Date
        While day <= Me.Main_Component_Plan.Horizon
            chart_service_cost = 0
            chart_excess_cost = 0
            chart_obsolete_cost = 0
            chart_ok_cost = 0
            chart_minimum_cost = 0
            chart_forecast_cost = 0
            If DashboardMRP_cbo.SelectedValue = "*" Then
                For Each i In Main_Component_Plan.Items.Where(Function(w) w.Value.IsActive)
                    Select Case i.Value.Status(day)
                        Case ComponentPlanItemStatus.Minimum
                            chart_minimum_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Normal
                            chart_ok_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Excess
                            chart_excess_cost += (i.Value.StockBalance(day) - i.Value.Maximum(day)) * i.Value.Partnumber.UnitCost
                            chart_ok_cost += i.Value.Maximum(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Obsolete
                            If i.Value.Partnumber.MRP = "999" Then
                                chart_service_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                            Else
                                chart_obsolete_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                            End If
                    End Select
                    'chart_forecast_cost += Math.Max(i.Value.SuggestedClone.StockBalance(day) * i.Value.Partnumber.UnitCost, 0)
                Next
            Else
                For Each i In Main_Component_Plan.Items.Where(Function(x) x.Value.IsActive AndAlso MRPCs.ContainsKey(x.Value.Partnumber.MRP) AndAlso MRPCs.Item(x.Value.Partnumber.MRP).Username = DashboardMRP_cbo.SelectedValue)
                    Select Case i.Value.Status(day)
                        Case ComponentPlanItemStatus.Minimum
                            chart_minimum_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Normal
                            chart_ok_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Excess
                            chart_excess_cost += (i.Value.StockBalance(day) - i.Value.Maximum(day)) * i.Value.Partnumber.UnitCost
                            chart_ok_cost += i.Value.Maximum(day) * i.Value.Partnumber.UnitCost
                        Case ComponentPlanItemStatus.Obsolete
                            If i.Value.Partnumber.MRP = "999" Then
                                chart_service_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                            Else
                                chart_obsolete_cost += i.Value.StockBalance(day) * i.Value.Partnumber.UnitCost
                            End If
                    End Select
                    'chart_forecast_cost += Math.Max(i.Value.SuggestedClone.StockBalance(day) * i.Value.Partnumber.UnitCost, 0)
                Next
            End If
            dt.Rows.Add(day.ToShortDateString, chart_minimum_cost, chart_ok_cost, chart_excess_cost, chart_obsolete_cost, chart_service_cost, chart_forecast_cost)
            day = LastMonday(day.AddDays(14))
        End While
        Return dt
    End Function


    Private Sub Partnumber_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Partnumber_txt.KeyDown
        'If e.KeyCode = Keys.Enter AndAlso Main_Component_Plan Is Nothing AndAlso SMK.IsRawMaterialFormat(Partnumber_txt.Text) AndAlso RawMaterial.Exists(Partnumber_txt.Text) Then
        '    LoadSingleComponentPlan(Partnumber_txt.Text)
        'Else
        If e.KeyCode = Keys.Enter AndAlso Main_Component_Plan IsNot Nothing AndAlso Main_Component_Plan.Items.ContainsKey(Partnumber_txt.Text.ToUpper) Then
            LoadComponentPlanItem(Partnumber_txt.Text.ToUpper)
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso Main_Component_Plan IsNot Nothing AndAlso Not Main_Component_Plan.Items.ContainsKey(Partnumber_txt.Text.ToUpper) AndAlso SelectedItem IsNot Nothing Then
            Partnumber_txt.Text = SelectedItem.Partnumber.Partnumber
        End If
    End Sub

    Private Sub BOMIssueFactor_lbl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles BOMIssueFactor_lbl.MouseDoubleClick
        If SelectedItem IsNot Nothing Then
            Dim factor_box As New EnterBox
            factor_box.AcceptByEnter = True
            factor_box.Answer = SelectedItem.Partnumber.BOMIssueFactor
            factor_box.Question = "Factor de BOM Issue"
            If factor_box.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(factor_box.Answer) AndAlso CDec(factor_box.Answer) >= 0 Then
                If SQL.Current.Update("Sys_RawMaterial", "BOMIssueFactor", Math.Round(CDec(factor_box.Answer), 2), "Partnumber", SelectedItem.Partnumber.Partnumber) Then
                    If CDec(factor_box.Answer) <> 1 AndAlso Not SelectedItem.Flags.Contains("BOM") Then
                        SQL.Current.Insert("Sys_PartnumberFlags", {"Partnumber", "Flag"}, {SelectedItem.Partnumber.Partnumber, "BOM"})
                        RefreshSelectedItemDataRow()
                    End If
                    LoadComponentPlanItem(SelectedItem.Partnumber.Partnumber)
                Else
                    FlashAlerts.ShowError("Error al guardar la información.")
                End If
            End If
        End If
    End Sub

    Private Sub PlannedOrders_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PlannedOrders_cms.Opening
        With SelectedItem
            If .Items.ContainsKey(cms_selected_date) AndAlso .Items.Item(cms_selected_date).PlannedOrders.Count > 0 Then
                CancelOrder_cmsi.Enabled = True
            Else
                CancelOrder_cmsi.Enabled = False
            End If
        End With
    End Sub

    Private Sub CancelOrder_cmsi_Click(sender As Object, e As EventArgs) Handles CancelOrder_cmsi.Click
        'If SelectedItem IsNot Nothing Then
        '    With SelectedItem
        '        LoadingScreen.Show()
        '        Dim sap As New SAP
        '        If sap.Available Then
        '            If sap.ZMD16(.Partnumber.Partnumber, cms_selected_date) Then
        '                If UpdatePlannedOrders(.Partnumber.Partnumber) Then
        '                    Main_Component_Plan.RefreshPartnumber(SelectedItem.Partnumber.Partnumber, .Horizon)
        '                    LoadingScreen.Hide()
        '                    Dim scroll_h As Integer
        '                    scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
        '                    LoadComponentPlanItem(.Partnumber.Partnumber)
        '                    PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
        '                    PartnumberForecast_dgv.Rows(3).Cells(cms_selected_date.ToShortDateString).Selected = True
        '                    FlashAlerts.ShowConfirm("Orden cancelada correctamente.")
        '                Else
        '                    LoadingScreen.Hide()
        '                    FlashAlerts.ShowInformation("La orden se canceló en SAP pero no fue posible actualizar el plan. Utilice la opción 'Sincronizar...'", 3)
        '                End If
        '            Else
        '                LoadingScreen.Hide()
        '                FlashAlerts.ShowError("Error al cancelar la orden planeada.")
        '            End If
        '        Else
        '            LoadingScreen.Hide()
        '            FlashAlerts.ShowError("Sesión de SAP no encontrada.")
        '        End If
        '    End With
        'End If
    End Sub

    Private Sub PartnumberOpenOrders_dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles PartnumberOpenOrders_dgv.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = PartnumberOpenOrders_dgv.Columns("OpenOrders_Comment_col").Index Then
            If Not SQL.Current.Update("Ord_OpenOrders", "Comment", Delta.NullReplace(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, ""), "ID", PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_ID_col").Value) Then
                FlashAlerts.ShowError("No fue posible guardar el comentario.")
            Else
                SelectedItem.Items.Item(CDate(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_AvailabilityDate_col").Value).Date).OpenOrders.Item(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells("OpenOrders_ID_col").Value).Comment = Delta.NullReplace(PartnumberOpenOrders_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, "")
            End If
        End If
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        Try
            ComponentPlan_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Dim data_o As DataObject = ComponentPlan_dgv.GetClipboardContent()
            ComponentPlan_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Clipboard.SetDataObject(data_o, True)
            FlashAlerts.ShowConfirm("Copiado.")
        Catch ex As Exception
            FlashAlerts.ShowError("Error al copiar.")
        End Try
    End Sub

    Private Sub WIPDate_lbl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles WIPDate_lbl.MouseDoubleClick
        If SelectedItem IsNot Nothing Then
            ShowPopup(SQL.Current.GetDatatable(String.Format("SELECT TOP 10 [Date] AS Fecha,Quantity AS Cantidad,UoM AS Unidad,FullName AS Usuario FROM Ord_WIPStock AS W INNER JOIN Sys_Users AS U ON W.Username = U.Username WHERE Partnumber= '{0}' ORDER BY [Date] DESC", SelectedItem.Partnumber.Partnumber)), "Ultimas 10 actualizaciones", 400, 200, WIPDate_lbl.PointToScreen(System.Drawing.Point.Empty), {{"Fecha", "MM/dd/yy HH:mm"}, {"Cantidad", "N1"}})
        End If
    End Sub

    Private Sub RunAllSuggestions_btn_Click(sender As Object, e As EventArgs) Handles RunAllSuggestions_btn.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("Ordering_ComponentPlan_RunAllSuggestions_flag") Then
               
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub

    Private Sub CopyDashboard_btn_Click(sender As Object, e As EventArgs) Handles CopyDashboard_btn.Click
        Clipboard.SetText(String.Format("{1}{0}{2}", vbCrLf, String.Join(vbTab, "MRP", "Fecha", Critical_lbl.Text, Critical_lbl.Text & " $", Minimum_lbl.Text, Minimum_lbl.Text & " $", Normal_lbl.Text, Normal_lbl.Text & " $", Excess_lbl.Text, Excess_lbl.Text & " $", Obsolete_lbl.Text, Obsolete_lbl.Text & " $", Service_lbl.Text, Service_lbl.Text & " $", TotalPartnumbers_lbl.Text, TotalStock_lbl.Text, PastDueTransits_lbl.Text, IssueOrders_lbl.Text, NoNeededOrders_lbl.Text, NoNeededOrders_lbl.Text, CallOffIssues_lbl.Text, AddOrders_lbl.Text, AddOrders_lbl.Text & " $", IncreaseOrders_lbl.Text, IncreaseOrders_lbl.Text & " $", CancelOrders_lbl.Text, CancelOrders_lbl.Text & " $", DecreaseOrders_lbl.Text, DecreaseOrders_lbl.Text & " $", RedTag_lbl.Text, RedTag_lbl.Text & " $", Tracker_lbl.Text, Tracker_lbl.Text & " $"), String.Join(vbTab, DashboardMRP_cbo.GetItemText(DashboardMRP_cbo.SelectedItem), Delta.CurrentDate.ToString, CriticalCount_lbl.Text, CriticalCost_lbl.Text, MinimumCount_lbl.Text, MinimumCost_lbl.Text, OKCount_lbl.Text, OKCost_lbl.Text, ExcessCount_lbl.Text, ExcessCost_lbl.Text, ObsoleteCount_lbl.Text, ObsoleteCost_lbl.Text, ServiceCount_lbl.Text, ServiceCost_lbl.Text, ActivePartnumbers_lbl.Text, TotalCost_lbl.Text, DashboardPastdueTransits_lbl.Text, DashboardPastDueOrders_lbl.Text, DashboardNoNeededRequirement_lbl.Text, DashboardNoNeededRequirementCost_lbl.Text, DashboardCallOffIssues_lbl.Text, DashboardAddOrders_lbl.Text, DashboardAddOrdersCost_lbl.Text, DashboardIncreaseOrders_lbl.Text, DashboardIncreaseOrdersCost_lbl.Text, DashboardCancelOrders_lbl.Text, DashboardCancelOrdersCost_lbl.Text, DashboardDecreaseOrders_lbl.Text, DashboardDecreaseOrdersCost_lbl.Text, DashboardRedTagCount_lbl.Text, DashboardRedTagCost_lbl.Text, DashboardTrackerCount_lbl.Text, DashboardTrackerCost_lbl.Text)))
    End Sub
End Class
