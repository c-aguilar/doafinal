Public Class CR_ComponentPlanSimulation
    Public Property Partnumber As ComponentPlanItem
    Private Sub CR_ComponentPlanSimulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "Simulación " & Partnumber.Partnumber.Partnumber
        LoadPartnumberInfo()
    End Sub

    Private Sub LoadPartnumberInfo()
        PartnumberForecast_dgv.DataSource = Nothing
        With Partnumber
            .RefreshQuickTasks()
            'ARMAR EL DATATABLE
            Dim component_forecast As New DataTable(.Partnumber.Partnumber)
            component_forecast.Columns.Add("Detalle")
            Dim day As Date = Delta.CurrentDate
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
            new_doh.Item("Detalle") = "DOH"
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
                new_doh.Item(day.ToShortDateString) = Math.Round(accum_stock / Math.Max(.AverageDailyDemand(day), 1), 1)
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
        End With
    End Sub

#Region "CMS ORDENES"
    Dim cms_open_col_index As Integer
    Dim cms_open_row_index As Integer
    Dim cms_selected_date As Date

    Private Sub PartnumberForecast_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles PartnumberForecast_dgv.DataBindingComplete
        For Each row As DataGridViewRow In PartnumberForecast_dgv.Rows
            If {"Órdenes Abiertas", "Órdenes Planeadas"}.Contains(row.Cells("Detalle").Value) Then
                For Each cell As DataGridViewCell In row.Cells
                    If Not cell.ColumnIndex = 0 Then cell.ContextMenuStrip = Orders_cms
                Next
            End If
        Next
    End Sub

    Private Sub PartnumberForecast_dgv_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles PartnumberForecast_dgv.CellContextMenuStripNeeded
        If e.ContextMenuStrip IsNot Nothing Then
            cms_open_col_index = e.ColumnIndex
            cms_open_row_index = e.RowIndex
            cms_selected_date = CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name)
            PartnumberForecast_dgv.ClearSelection()
            PartnumberForecast_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        End If
    End Sub

    Private Sub Orders_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Orders_cms.Opening
        With Partnumber
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
        With Partnumber
            Dim pickup_date As Date = BackWorkDay(cms_selected_date, .Partnumber.GRT).Date  'CALCULAR LA FECHA DONDE SE DEBE AGREGAR LA ORDEN PARA QUE LLEGUE A TIEMPO
            Dim suggest_quantity As Decimal
            If .Items.ContainsKey(cms_selected_date) AndAlso .Items.Item(cms_selected_date).SuggestedTask.Action = QuickTasksAction.AddOrder Then
                suggest_quantity = .Items.Item(cms_selected_date).SuggestedTask.Quantity
            Else
                suggest_quantity = .Partnumber.RoundByStdPack(.Minimum(cms_selected_date) - .StockBalance(cms_selected_date))
            End If
            If pickup_date < Delta.CurrentDate.Date.Date Then
                pickup_date = Delta.CurrentDate.Date
            End If
            Dim new_availabilitydate As Date = WorkDay(pickup_date, .Partnumber.GRT)
            If Not Partnumber.Items.ContainsKey(new_availabilitydate) Then
                Partnumber.Items.Add(new_availabilitydate, New ComponentPlanItemDate(new_availabilitydate))
            End If
            If Partnumber.Items.Item(new_availabilitydate).OpenOrders.Count = 0 Then
                Dim order As New CR_ComponentPlanNewOrderFake
                order.Partnumber = Partnumber.Partnumber.Partnumber
                order.Quantity = suggest_quantity
                order.PickUpDate = pickup_date
                If order.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Partnumber.Items.Item(new_availabilitydate).OpenOrders.Add(0, New OpenOrder(0, .Partnumber.SupplierNumber, .Partnumber.SupplierName, order.Quantity, 0, Partnumber.Partnumber.UoM.ToString, order.PickUpDate, .Partnumber.GRT, new_availabilitydate, True, .Partnumber.Document, .Partnumber.DocumentItem, False, False, order.Quantity, 0, "", True))
                    Dim scroll_h As Integer
                    scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
                    LoadPartnumberInfo()
                    PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
                    PartnumberForecast_dgv.Rows(2).Cells(cms_selected_date.ToShortDateString).Selected = True
                End If
                order.Dispose()
            End If
        End With
    End Sub

    Private Sub AdjustOrder_cmsi_Click(sender As Object, e As EventArgs) Handles AdjustOrder_cmsi.Click
        With Partnumber
            Dim selected_id As Integer = 0
            If .Items.ContainsKey(cms_selected_date) AndAlso .Items.Item(cms_selected_date).OpenOrders.Count = 1 Then
                For Each i In .Items.Item(cms_selected_date).OpenOrders
                    selected_id = i.Key
                Next
            ElseIf .Items.ContainsKey(cms_selected_date) AndAlso .Items.Item(cms_selected_date).OpenOrders.Count > 1 Then
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
                If selector.ShowDialog = Windows.Forms.DialogResult.OK Then
                    selected_id = selector.SelectedID
                    selector.Dispose()
                Else
                    selector.Dispose()
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            Dim suggest_quantity As Decimal
            If .Items.ContainsKey(cms_selected_date) Then
                Select Case .Items.Item(cms_selected_date).SuggestedTask.Action
                    Case QuickTasksAction.DecreaseOrder, QuickTasksAction.IncreaseOrder, QuickTasksAction.FixAdjust, QuickTasksAction.FixAndDealing
                        suggest_quantity = .Items.Item(cms_selected_date).SuggestedTask.Quantity
                    Case QuickTasksAction.CancelOrder, QuickTasksAction.FixCancel
                        suggest_quantity = 0
                    Case Else
                        suggest_quantity = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity
                End Select
            Else
                suggest_quantity = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity
            End If

            Dim order As New CR_ComponentPlanNewOrderFake
            order.Partnumber = .Partnumber.Partnumber
            order.Quantity = suggest_quantity
            order.PickUpDate = .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).ShipDate
            order.EditMode = True
            If order.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If order.PickUpDate <> .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).ShipDate Then
                    Dim new_availabilitydate As Date = WorkDay(order.PickUpDate, .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).GRP)
                    If Not Partnumber.Items.ContainsKey(new_availabilitydate) Then
                        Partnumber.Items.Add(new_availabilitydate, New ComponentPlanItemDate(new_availabilitydate))
                    End If
                    With .Items.Item(cms_selected_date).OpenOrders.Item(selected_id)
                        Partnumber.Items.Item(new_availabilitydate).OpenOrders.Add(0, New OpenOrder(0, .SupplierNumber, .SupplierName, order.Quantity, 0, Partnumber.Partnumber.UoM.ToString, order.PickUpDate, .GRP, new_availabilitydate, .Fix, .Document, .Item, .Kanban, .External, order.Quantity, 0, "", True))
                    End With
                    .Items.Item(cms_selected_date).OpenOrders.Remove(selected_id)
                    Dim scroll_h As Integer
                    scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
                    LoadPartnumberInfo()
                    PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
                    PartnumberForecast_dgv.Rows(2).Cells(cms_selected_date.ToShortDateString).Selected = True
                ElseIf order.Quantity <> .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).QuantityInBuM Then
                    If order.Quantity = 0 Then 'ORDEN CANCELADA
                        .Items.Item(cms_selected_date).OpenOrders.Remove(selected_id)
                    Else 'ORDEN AJUSTADA
                        .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).QuantityInBuM = order.Quantity
                        .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Quantity = order.Quantity
                        .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).UoM = .Partnumber.UoM.ToString
                        .Items.Item(cms_selected_date).OpenOrders.Item(selected_id).Fake = True
                    End If
                    Dim scroll_h As Integer
                    scroll_h = PartnumberForecast_dgv.HorizontalScrollingOffset
                    LoadPartnumberInfo()
                    PartnumberForecast_dgv.HorizontalScrollingOffset = scroll_h
                    PartnumberForecast_dgv.Rows(2).Cells(cms_selected_date.ToShortDateString).Selected = True
                End If
            End If
            order.Dispose()
        End With
    End Sub
#End Region

    Private Sub PartnumberForecast_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles PartnumberForecast_dgv.CellFormatting
        If e.ColumnIndex > 0 AndAlso e.RowIndex >= 0 Then
            If IsNumeric(e.Value) AndAlso e.Value < 0 Then e.CellStyle.ForeColor = Color.Red
            If Not ProductionPlan.WorkingCalendar.Item(CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name).Date) Then
                e.CellStyle.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Private Sub PartnumberForecast_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles PartnumberForecast_dgv.CellPainting
        'DIBUJAR LAS LINEAS DONDE TERMINA EL PTF Y SRT
        If e.ColumnIndex > 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            Dim col_date As Date = CDate(PartnumberForecast_dgv.Columns(e.ColumnIndex).Name).Date

            If e.RowIndex >= 0 AndAlso PartnumberForecast_dgv.Rows(e.RowIndex).Cells("Detalle").Value = "Inventario Final" Then
                Select Case Partnumber.Status(col_date)
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

            If e.RowIndex >= 0 AndAlso PartnumberForecast_dgv.Rows(e.RowIndex).Cells("Detalle").Value = "Órdenes Abiertas" AndAlso Partnumber.Items.ContainsKey(col_date) Then
                Select Case Partnumber.Items.Item(col_date).SuggestedTask.Action
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
            If ComponentPlan.Suppliers.ContainsKey(Partnumber.Partnumber.SupplierNumber) AndAlso ComponentPlan.Suppliers.Item(Partnumber.Partnumber.SupplierNumber).LeanOrdering Then
                'SI ES LEAN DIBUJAR LINEAS DE PTF Y SRT
                With ComponentPlan.Suppliers.Item(Partnumber.Partnumber.SupplierNumber)
                    If col_date = Partnumber.EndOfPTF AndAlso col_date = .EndOfSRT Then
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
                        If col_date = Partnumber.EndOfPTF Then
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
                If col_date = Partnumber.EndOfPTF Then
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
End Class