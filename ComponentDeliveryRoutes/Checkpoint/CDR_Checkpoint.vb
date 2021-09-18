Public Class CDR_Checkpoint
    Dim current_route_carrousel As Integer = 0
    Dim timers_stopped As Boolean = False
    Private Sub CDR_Checkpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Warehouse_lbl.Text = String.Format("Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        Missing_timer_Tick(Nothing, Nothing)
        Positions_timer_Tick(Nothing, Nothing)
        Carrousel_timer_Tick(Nothing, Nothing)
    End Sub

    'Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
    '    Using br As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, Color.FromArgb(52, 73, 94), Color.FromArgb(26, 36, 42), 90.0F)
    '        e.Graphics.FillRectangle(br, Me.ClientRectangle)
    '    End Using
    'End Sub

    Private Sub CDR_Checkpoint_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Option_txt.Focus()
    End Sub

    Private Sub Option_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Option_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            ReadOption()
        End If
    End Sub

    Private Sub Option_txt_Validated(sender As Object, e As EventArgs) Handles Option_txt.Validated
        If Option_txt.Text <> "" Then
            ReadOption()
        End If
    End Sub

    Private Sub ReadOption()
        timers_stopped = True
        Dim option_scan As String = Option_txt.Text.ToUpper.Trim
        Option_txt.Clear()
        Select Case option_scan
            Case ""
                Exit Sub
            Case "EXIT"
                Dim fadeback As New FadeBackground(CDR_ExitRoute)
                fadeback.ShowDialog()
                UpdatePositions()
                Option_txt.Focus()
            Case "EMPTY"
                Dim fadeback As New FadeBackground(CDR_EmptyContainers)
                fadeback.ShowDialog()
                Option_txt.Focus()
            Case "MISS", "CRITICAL"
                Dim fadeback As New FadeBackground(CDR_MissingPartnumbers)
                fadeback.ShowDialog()
                Option_txt.Focus()
            Case "PRINT"
                Dim fadeback As New FadeBackground(CDR_PrintKanban)
                fadeback.ShowDialog()
                Option_txt.Focus()
            Case "FIND"
                Dim fadeback As New FadeBackground(CDR_FindManufacturing)
                fadeback.ShowDialog()
                Option_txt.Focus()
            Case "WEIGHT"
                If CBool(Parameter("CDR_HealingContainerization_Enabled", False, True)) Then
                    Dim fadeback As New FadeBackground(CDR_HealingContainerization)
                    fadeback.ShowDialog()
                End If
                Option_txt.Focus()
            Case Else
                If CDR.Routes.Exists(Function(f) f.Name.ToLower = option_scan.ToLower) Then
                    Dim route As CDR.Route = CDR.Routes.Find(Function(f) f.Name.ToLower = option_scan.ToLower)
                    Dim background As New FadeBackground()
                    background.Show()
                    'VERIFICAR SI LA RUTA LA REALIZO EL CHECKLIST INICIAL
                    If Not route.Started Then
                        Dim checklist As New CDR_StartingWorkChecklist
                        checklist.Route = route.Route
                        If checklist.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            'UNA VEZ REALIZADO EL CHECKLIST YA PUEDE REGISTRAR SU PRIMER ENTRADA
                            route.Started = True

                            'VERIFICAR SI ESTA FUERA O DENTRO, POR CUESTION DEL TURNO ANTERIOR
                            If route.Status = CDR.Status.OUT Then
                                Dim scan As New CDR_KanbanScan
                                scan.Route = route
                                scan.ShowDialog()
                                scan.Dispose()
                            Else
                                Dim fadeback As New FadeBackground(CDR_ExitRoute)
                                fadeback.ShowDialog()
                                UpdatePositions()
                            End If
                            DisplayRouteInfo(route.Route)
                            Option_txt.Focus()
                        End If
                        checklist.Dispose()
                    Else
                        'VERIFICA QUE LA RUTA HAYA SALIDO O SE ENCUENTRE DENTRO DEL PERIODO DE GRACIA PARA SEGUIR ESCANEANDO
                        If route.Status = CDR.Status.OUT OrElse SQL.Current.GetScalar(String.Format("SELECT TOP 1 DATEDIFF(MINUTE,[InDate],GETDATE()) FROM CDR_RoutesLoopRegister WHERE Route = {0} AND CONVERT(DATE,[InDate]) = CONVERT(DATE,GETDATE()) ORDER BY [InDate] DESC", route.Route)) <= Parameter("CDR_GracePeriod") Then
                            Dim scan As New CDR_KanbanScan
                            scan.Route = route
                            scan.ShowDialog()
                            scan.Dispose()
                            DisplayRouteInfo(route.Route)
                            Option_txt.Focus()
                        Else
                            Option_txt.Focus()
                            FlashAlerts.ShowError("La ruta se encuentra en Supermercado.")
                        End If
                    End If
                    background.Close()
                    background.Dispose()
                    UpdatePositions()
                Else
                    Option_txt.Focus()
                    FlashAlerts.ShowError("Opción incorrecta.")
                End If
        End Select
        timers_stopped = False
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        Dim fadeback As New FadeBackground(CDR_ExitRoute)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Missing_btn_Click(sender As Object, e As EventArgs) Handles Missing_btn.Click
        Dim fadeback As New FadeBackground(CDR_MissingPartnumbers)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Missing_timer_Tick(sender As Object, e As EventArgs) Handles Missing_timer.Tick
        If Not timers_stopped AndAlso SQL.Current.Available Then
            Missing_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber,M.[Date],O.FullName,M.Answer,~M.Active AS [Active] FROM Smk_MissingAlerts AS M INNER JOIN Smk_Operators AS O ON M.Badge = O.Badge WHERE (M.Active = 1 OR (CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()) AND dbo.Sys_Shift([Date]) = dbo.Sys_Shift(GETDATE()))) AND Warehouse = '{0}'", My.Settings.Warehouse))
        End If
    End Sub

    Private Sub UpdatePositions()
        Positions_dgv.Rows.Clear()
        Dim cnt As Integer = 1
        Dim routes = CDR.Routes.FindAll(Function(f) f.Started = True).OrderByDescending(Function(f) f.MovedContainers)
        For Each r In routes
            Positions_dgv.Rows.Add(String.Format("{0}º", cnt), r.OperatorName, r.Name, r.Route, r.Status.ToString)
            cnt += 1
        Next
        Positions_dgv.ClearSelection()
    End Sub

    Private Sub Positions_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Positions_dgv.CellFormatting
        If e.RowIndex >= 0 Then
            If Positions_dgv.Rows(e.RowIndex).Cells("status").Value = "IN" Then
                'e.CellStyle.ForeColor = Color.FromArgb(88, 171, 103)
                If e.ColumnIndex = Positions_dgv.Columns("color_flag").Index Then
                    e.CellStyle.BackColor = Color.FromArgb(88, 171, 103)
                End If
            Else
                'e.CellStyle.ForeColor = Color.FromArgb(84, 63, 115)
                If e.ColumnIndex = Positions_dgv.Columns("color_flag").Index Then
                    e.CellStyle.BackColor = Color.FromArgb(84, 63, 115) '(70, 52, 96)
                End If
            End If
        End If
    End Sub

    Private Sub Carrousel_timer_Tick(sender As Object, e As EventArgs) Handles Carrousel_timer.Tick
        If timers_stopped OrElse Not SQL.Current.Available Then Exit Sub
        Dim route = CDR.Routes.Find(Function(f) f.Route > current_route_carrousel And f.Started = True)
        If route IsNot Nothing Then
            current_route_carrousel = route.Route
            DisplayRouteInfo(current_route_carrousel)
        Else
            route = CDR.Routes.Find(Function(f) f.Started = True)
            If route IsNot Nothing Then
                current_route_carrousel = route.Route
                DisplayRouteInfo(current_route_carrousel)
            Else
                Picture_pb.Image = Nothing
                OperatorName_lbl.Text = ""
                LoopsGoal_lbl.Text = ""
                LoopsCnt_lbl.Text = ""
                ContainersGoal_lbl.Text = ""
                ContainersCount_lbl.Text = ""
                WorkloadGoal_lbl.Text = ""
                WorkloadPercent_lbl.Text = ""
                Route_lbl.Text = ""
                ATT_lbl.Text = ""
                DailyContainers_lbl.Text = ""
                DailyLoops_lbl.Text = ""
                PrimaryWalkings_lbl.Text = ""
                SecondaryWalkings_lbl.Text = ""
                DesignWorkload_chart.Series(0).Points(0).SetValueY(0)
                DesignWorkload_chart.Series(0).Points(1).SetValueY(1)
                DesignWorkload_chart.Titles(0).Text = ""
                Containers_chrt.Series(0).Points.Clear()
                Containers_chrt.Series(1).Points.Clear()
                Time_chrt.Series(0).Points.Clear()
                Time_chrt.Series(1).Points.Clear()
                Week_chrt.Series(0).Points.Clear()
                Week_chrt.Series(1).Points.Clear()
            End If
        End If
    End Sub

    Private Sub Positions_timer_Tick(sender As Object, e As EventArgs) Handles Positions_timer.Tick
        If Not timers_stopped AndAlso SQL.Current.Available Then UpdatePositions()
    End Sub

    Private Sub DisplayRouteInfo(route_id As Integer)
        Containers_chrt.Series(0).Points.Clear()
        Containers_chrt.Series(1).Points.Clear()
        Time_chrt.Series(0).Points.Clear()
        Time_chrt.Series(1).Points.Clear()
        Week_chrt.Series(0).Points.Clear()
        Week_chrt.Series(1).Points.Clear()

        'Containers_chrt.Series(0).Color = Color.Black
        'Containers_chrt.Series(1).Color = Color.LimeGreen
        CDR.RefreshRoute(route_id) 'ACTUALIZAR AL INFO DE LA RUTA
        Dim route = CDR.Routes.Find(Function(f) f.Route = route_id)
        Dim shift = CDR.Shifts.Find(Function(f) f.Name = route.Shift)
        Picture_pb.Image = Delta.GetUserPhoto(route.Badge)
        OperatorName_lbl.Text = String.Format("{0} | {1} | Turno {2}", route.OperatorName, route.Badge, route.Shift)

        Dim emptys As Integer = SQL.Current.GetScalar(String.Format("SELECT COUNT(ID) FROM Smk_SerialMovements WHERE Movement = 'DER' AND Badge = '{0}' AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()) AND dbo.Sys_Shift([Date]) = '{1}';", route.Badge, route.Shift))
        Dim proportion As Decimal = DateDiff(DateInterval.Minute, shift.Start, Now()) / DateDiff(DateInterval.Minute, shift.Start, shift.Ending)

        Dim real_wkl = ((route.MovedContainers * Parameter("CDR_ATT")) + (((route.PrimaryWalkings + route.SecondaryWalkings) / 2) * route.LoopsCounter) + (emptys * Parameter("CDR_Workload_EmptyDeclaration_Seconds", 30)) + (route.ExtraPaid * proportion)) / shift.Seconds
        Dim goal_wkl = ((route.ContainersDailyGoal * proportion * Parameter("CDR_ATT")) + (((route.PrimaryWalkings + route.SecondaryWalkings) / 2) * (route.LoopsGoal * proportion)) + (emptys * Parameter("CDR_Workload_EmptyDeclaration_Seconds", 30)) + (route.ExtraPaid * proportion)) / shift.Seconds

        Dim desing_wkl = ((route.ContainersDailyGoal * Parameter("CDR_ATT")) + (((route.PrimaryWalkings + route.SecondaryWalkings) / 2) * route.LoopsGoal) + (route.ExtraPaid)) / shift.Seconds
        Route_lbl.Text = route.Name
        DailyLoops_lbl.Text = String.Format("Vueltas por día: {0}", route.LoopsGoal)
        ATT_lbl.Text = String.Format("Tiempo elemento: {0}", Parameter("CDR_ATT"))
        PrimaryWalkings_lbl.Text = String.Format("Caminares primarios: {0}", route.PrimaryWalkings)
        SecondaryWalkings_lbl.Text = String.Format("Caminares secundarios: {0}", route.SecondaryWalkings)
        DailyContainers_lbl.Text = String.Format("Contenedores por día: {0}", route.ContainersDailyGoal)
        DesignWorkload_chart.Series(0).Points(0).SetValueY(desing_wkl)
        DesignWorkload_chart.Series(0).Points(1).SetValueY(1 - desing_wkl)
        DesignWorkload_chart.Titles(0).Text = FormatPercent(desing_wkl, 1)

        WorkloadBar_chart.Series(0).Points.Item(0).SetValueY(real_wkl)
        WorkloadBar_chart.Series(1).Points.Item(0).SetValueY(1 - real_wkl)
        WorkloadPercent_lbl.Text = FormatPercent(real_wkl, 1)
        WorkloadGoal_lbl.Text = FormatPercent(goal_wkl, 1)
        If real_wkl >= (goal_wkl * 0.95) AndAlso real_wkl <= (goal_wkl * 1.05) Then
            WorkloadBar_chart.Series(0).Color = Color.GreenYellow
        ElseIf real_wkl >= (goal_wkl * 0.9) AndAlso real_wkl <= (goal_wkl * 1.1) Then
            WorkloadBar_chart.Series(0).Color = Color.Gold
        Else
            WorkloadBar_chart.Series(0).Color = Color.Crimson
        End If

        LoopsBar_chart.Series(0).Points.Item(0).SetValueY(route.LoopsCounter)
        LoopsBar_chart.Series(1).Points.Item(0).SetValueY(route.LoopsGoal - route.LoopsCounter)
        LoopsCnt_lbl.Text = route.LoopsCounter
        LoopsGoal_lbl.Text = Math.Truncate(route.LoopsGoal * proportion)
        If route.LoopsCounter >= Math.Truncate(route.LoopsGoal * proportion * 0.95) AndAlso route.LoopsCounter <= Math.Truncate(route.LoopsGoal * proportion * 1.05) Then
            LoopsBar_chart.Series(0).Color = Color.GreenYellow
        ElseIf route.LoopsCounter >= Math.Truncate(route.LoopsGoal * proportion * 0.9) AndAlso route.LoopsCounter <= Math.Truncate(route.LoopsGoal * proportion * 1.1) Then
            LoopsBar_chart.Series(0).Color = Color.Gold
        Else
            LoopsBar_chart.Series(0).Color = Color.Crimson
        End If

        ContainersBar_chart.Series(0).Points.Item(0).SetValueY(route.MovedContainers)
        ContainersBar_chart.Series(1).Points.Item(0).SetValueY(route.ContainersDailyGoal - route.MovedContainers)
        ContainersCount_lbl.Text = route.MovedContainers
        ContainersGoal_lbl.Text = Math.Truncate(route.ContainersDailyGoal * proportion)
        If route.MovedContainers >= Math.Truncate(route.ContainersDailyGoal * proportion * 0.95) AndAlso route.MovedContainers <= Math.Truncate(route.ContainersDailyGoal * proportion * 1.05) Then
            ContainersBar_chart.Series(0).Color = Color.GreenYellow
        ElseIf route.MovedContainers >= Math.Truncate(route.ContainersDailyGoal * proportion * 0.9) AndAlso route.MovedContainers <= Math.Truncate(route.ContainersDailyGoal * proportion * 1.1) Then
            ContainersBar_chart.Series(0).Color = Color.Gold
        Else
            ContainersBar_chart.Series(0).Color = Color.Crimson
        End If

        Dim cnt As Integer = 1
        Time_chrt.ChartAreas(0).AxisY.Maximum = 70
        For Each l As CDR.Loop In route.Loops
            Containers_chrt.Series(0).Points.AddXY(l.InDate, l.Containers)
            Containers_chrt.Series(1).Points.AddXY(l.InDate, route.ContainersLoopGoal)
            If l.Completed AndAlso DateDiff(DateInterval.Minute, l.InDate, l.OutDate) > 0 Then
                If DateDiff(DateInterval.Minute, l.InDate, l.OutDate) > Time_chrt.ChartAreas(0).AxisY.Maximum Then
                    Time_chrt.ChartAreas(0).AxisY.Maximum = DateDiff(DateInterval.Minute, l.InDate, l.OutDate)
                End If
                Time_chrt.Series(0).Points.AddXY(cnt, DateDiff(DateInterval.Minute, l.InDate, l.OutDate))

                If cnt < route.Loops.Count AndAlso DateDiff(DateInterval.Minute, l.OutDate, route.Loops.Item(cnt).InDate) > 0 Then
                    If DateDiff(DateInterval.Minute, l.OutDate, route.Loops.Item(cnt).InDate) > Time_chrt.ChartAreas(0).AxisY.Maximum Then
                        Time_chrt.ChartAreas(0).AxisY.Maximum = DateDiff(DateInterval.Minute, l.OutDate, route.Loops.Item(cnt).InDate)
                    End If
                    Time_chrt.Series(1).Points.AddXY(cnt, DateDiff(DateInterval.Minute, l.OutDate, route.Loops.Item(cnt).InDate))

                End If
            End If
            cnt += 1
        Next

        emptys = SQL.Current.GetScalar(String.Format("SELECT COUNT(ID) FROM Smk_SerialMovements WHERE Movement = 'DER' AND Badge = '{0}' AND DATEPART(WK,InDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY,InDate) = DATEPART(YY,GETDATE()) AND dbo.Sys_Shift([Date]) = '{1}';", route.Badge, route.Shift))
        Week_chrt.ChartAreas(0).AxisY2.Maximum = route.ContainersDailyGoal
        Dim cnt_week As DataTable = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,InDate) AS [Date],COUNT(ID) AS Loops,SUM(Kanbans) AS Containers  FROM CDR_RoutesLoopRegister AS R INNER JOIN (SELECT LoopID,COUNT(Kanban) AS Kanbans FROM CDR_RoutesLoopKanbans GROUP BY LoopID) AS C ON R.ID = C.LoopID WHERE DATEPART(WK,InDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY,InDate) = DATEPART(YY,GETDATE()) AND Badge = '{0}' AND dbo.Sys_Shift(InDate) = '{1}' GROUP BY CONVERT(DATE,InDate) ORDER BY CONVERT(DATE,InDate)", route.Badge, route.Shift))
        For Each d As DataRow In cnt_week.Rows
            Dim wk As Single = ((d.Item("Containers") * Parameter("CDR_ATT")) + (((route.PrimaryWalkings + route.SecondaryWalkings) / 2) * d.Item("Loops")) + (emptys * Parameter("CDR_Workload_EmptyDeclaration_Seconds", 30)) + route.ExtraPaid) / shift.Seconds
            Week_chrt.Series(1).Points.AddXY(d.Item("Date"), wk)
            Week_chrt.Series(0).Points.AddXY(d.Item("Date"), d.Item("Containers"))
        Next
    End Sub

    Private Sub CDR_Checkpoint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        timers_stopped = True
        Carrousel_timer.Stop()
        Missing_timer.Stop()
        Positions_timer.Stop()
        Carrousel_timer.Enabled = False
        Missing_timer.Enabled = False
        Positions_timer.Enabled = False
        Carrousel_timer.Dispose()
        Missing_timer.Dispose()
        Positions_timer.Dispose()
        CDR.CleanRoutesInfo()
        Me.Dispose()
    End Sub

    'Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint
    '    Using br As New System.Drawing.Drawing2D.LinearGradientBrush(Panel8.ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(210, 210, 210), 90.0F)
    '        e.Graphics.FillRectangle(br, Panel8.ClientRectangle)
    '    End Using
    'End Sub

    Private Sub Positions_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Positions_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            DisplayRouteInfo(Positions_dgv.SelectedRows.Item(0).Cells("route").Value)
            Option_txt.Focus()
        End If
    End Sub
End Class