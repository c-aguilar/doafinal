Public Class DDR_Checkpoint
    Dim current_cart_carrousel As String = ""
    Dim timers_stopped As Boolean = False
    Dim current_carrousel As CDR.Carrousel
    Dim scale_cntrl As Single = 1
    Private Sub CDR_Checkpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CDR.Carts.Clear()
        Warehouse_lbl.Text = String.Format("Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        For Each cart In CDR.Carts
            Carts_flp.Controls.Add(cart.Icon)
        Next
        UpdateMissing()
        ForwardCarrousel()
        Crono_timer.Enabled = True
        Carrousel_timer.Enabled = True
        Crono_timer.Start()
        Carrousel_timer.Start()
    End Sub

    'Private Sub ResizeCntrls(ByRef cntrl As Control)
    '    For Each c In cntrl.Controls
    '        ResizeCntrls(c)
    '    Next
    '    cntrl.Font = New Font(cntrl.Font.Name, cntrl.Font.Size * scale_cntrl)
    '    cntrl.Size.Width = cntrl.
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
            Case "CRITICAL"
                If AskBadge() Then
                    Dim background As New FadeBackground()
                    background.Show()
                    Dim critical As New DDR_DiscountCritical
                    critical.Badge = Me.CurrentBadge
                    critical.ShowDialog()
                    critical.Dispose()
                    background.Close()
                    background.Dispose()
                End If
                Option_txt.Focus()
            Case "IN"
                Dim background As New FadeBackground()
                background.Show()
                Dim in_cart As New DDR_InCart
                If in_cart.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    background.Close()
                    background.Dispose()
                    FlashAlerts.ShowConfirm("Entrada registrada.")
                Else
                    background.Close()
                    background.Dispose()
                End If
                in_cart.Dispose()
                Option_txt.Focus()
            Case "OUT"
                Dim background As New FadeBackground()
                background.Show()
                Dim out_cart As New DDR_OutCart
                If out_cart.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    background.Close()
                    background.Dispose()
                    FlashAlerts.ShowConfirm("Salida registrada.")
                Else
                    background.Close()
                    background.Dispose()
                End If
                out_cart.Dispose()
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
                If CDR.Carts.Exists(Function(f) f.ID.ToLower = option_scan.ToLower) Then

                    Dim cart As CDR.Cart = CDR.Carts.Find(Function(f) f.ID.ToLower = option_scan.ToLower)
                    cart.Refresh()
                    Dim background As New FadeBackground()
                    background.Show()


                    If Not CBool(Parameter("DDR_IMSFenceScan", "True")) Then 'IMPLEMENTACION DEL SISTEMA SIN ESCANEOS DE ENTREGA VACIO Y LLENO
                        If cart.Status = CDR.Status.Out Then
                            If AskBadge() Then
                                'REGISTRAR LLEGADA VACIO
                                SQL.Current.Insert("DDR_CartsLoopRegister", {"Cart", "CollectingBadge"}, {cart.ID, Me.CurrentBadge})
                                cart.Refresh() 'Actualizar el carro

                                'COMENZAR ESCANEO
                                Dim scan As New DDR_KanbanScan
                                scan.Badge = Me.CurrentBadge
                                scan.Cart = cart
                                scan.ShowDialog()
                                scan.Dispose()

                                background.Close()
                                background.Dispose()
                                cart.Refresh()
                                Option_txt.Focus()
                            Else
                                FlashAlerts.ShowInformation("Operación cancelada.")
                            End If
                            Exit Sub
                        ElseIf cart.Status = CDR.Status.WaitingDelivery Then
                            If AskBadge() Then
                                'CERRAR LA ULTIMA VUELTA
                                SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET DeliveringBadge = '{1}', DeliveryDate = GETDATE(), DeliveryEndDate = DATEADD(SECOND,1,GETDATE()), [Status] = 'D' WHERE ID = {0}", cart.CurrentLoopID, Me.CurrentBadge))

                                'REGISTRAR LLEGADA VACIO
                                SQL.Current.Insert("DDR_CartsLoopRegister", {"Cart", "CollectingBadge"}, {cart.ID, Me.CurrentBadge})
                                cart.Refresh() 'Actualizar el carro

                                'COMENZAR ESCANEO
                                Dim scan As New DDR_KanbanScan
                                scan.Badge = Me.CurrentBadge
                                scan.Cart = cart
                                scan.ShowDialog()
                                scan.Dispose()

                                background.Close()
                                background.Dispose()
                                cart.Refresh()
                                Option_txt.Focus()
                            Else
                                FlashAlerts.ShowInformation("Operación cancelada.")
                            End If
                            Exit Sub
                        ElseIf cart.Status = CDR.Status.Delivering Then
                            If AskBadge() Then
                                'CERRAR LA ULTIMA VUELTA
                                SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET DeliveryEndDate = DATEADD(SECOND,1,GETDATE()), [Status] = 'D' WHERE ID = {0}", cart.CurrentLoopID, Me.CurrentBadge))

                                'REGISTRAR LLEGADA VACIO
                                SQL.Current.Insert("DDR_CartsLoopRegister", {"Cart", "CollectingBadge"}, {cart.ID, Me.CurrentBadge})
                                cart.Refresh() 'Actualizar el carro

                                'COMENZAR ESCANEO
                                Dim scan As New DDR_KanbanScan
                                scan.Badge = Me.CurrentBadge
                                scan.Cart = cart
                                scan.ShowDialog()
                                scan.Dispose()

                                background.Close()
                                background.Dispose()
                                cart.Refresh()
                                Option_txt.Focus()
                            Else
                                FlashAlerts.ShowInformation("Operación cancelada.")
                            End If
                            Exit Sub
                        ElseIf cart.Status = CDR.Status.In Then
                            If AskBadge() Then
                                'MARCA VUELTA COMO PICKING
                                SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET PickingBadge = '{1}', PickingDate = GETDATE(), PickingEndDate = DATEADD(SECOND,1,GETDATE()), [Status] = 'P' WHERE ID = {0}", cart.CurrentLoopID, Me.CurrentBadge))
                                cart.Refresh()

                                If LabelMissingBins(cart.CurrentLoopID) Then
                                    Dim scan As New DDR_ExitCart
                                    scan.Badge = Me.CurrentBadge
                                    scan.Cart = cart
                                    scan.ShowDialog()
                                    scan.Dispose()

                                    background.Close()
                                    background.Dispose()
                                    cart.Refresh()
                                    Option_txt.Focus()
                                Else
                                    background.Close()
                                    background.Dispose()
                                    cart.Refresh()
                                    Option_txt.Focus()
                                    FlashAlerts.ShowError("Debes de corregir todas las kanbans.", 1, True)
                                End If
                            Else
                                FlashAlerts.ShowInformation("Operación cancelada.")
                            End If
                            Exit Sub
                        End If
                    End If


                    If cart.Status = CDR.Status.Out OrElse cart.Status = CDR.Status.Delivering Then
                        Dim in_cart As New DDR_InCart
                        in_cart.CartID = cart.ID
                        If in_cart.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            FlashAlerts.ShowConfirm("Entrada registrada.", 1, True)
                            If AskBadge() Then
                                Dim scan As New DDR_KanbanScan
                                scan.Badge = Me.CurrentBadge
                                scan.Cart = cart
                                If scan.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                    Option_txt.Focus()
                                    FlashAlerts.ShowConfirm("Bins registrados.", 1, True)
                                Else
                                    Option_txt.Focus()
                                    FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                                End If
                                scan.Dispose()
                            Else
                                Option_txt.Focus()
                                FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                            End If
                        Else
                            Option_txt.Focus()
                            FlashAlerts.ShowInformation("Operación cancelada.")
                        End If
                    ElseIf cart.Status = CDR.Status.WaitingDelivery Then
                        Dim out_cart As New DDR_OutCart
                        If out_cart.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            Option_txt.Focus()
                            FlashAlerts.ShowConfirm("Salida registrada.", 1, True)
                        Else
                            Option_txt.Focus()
                            FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                        End If
                    ElseIf cart.Status = CDR.Status.WaitingIn Then
                        If AskBadge() Then
                            Dim scan As New DDR_KanbanScan
                            scan.Badge = Me.CurrentBadge
                            scan.Cart = cart
                            If scan.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                Option_txt.Focus()
                                FlashAlerts.ShowConfirm("Bins registrados.", 1, True)
                            Else
                                Option_txt.Focus()
                                FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                            End If
                            scan.Dispose()
                        Else
                            Option_txt.Focus()
                            FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                        End If
                    ElseIf cart.Status = CDR.Status.In Then
                        Dim scan As New DDR_KanbanScan
                        scan.Badge = cart.ScannigInBadge
                        scan.Cart = cart
                        If scan.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            Option_txt.Focus()
                            FlashAlerts.ShowConfirm("Bins registrados.", 1, True)
                        Else
                            Option_txt.Focus()
                            FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                        End If
                        scan.Dispose()
                    ElseIf cart.Status = CDR.Status.Picking Then
                        'VALIDAR SI TERMINO DE PICKEAR
                        If cart.ScannedKanbans.Exists(Function(w) w.Status = CDR.ScannedKanban.PickingStatus.Hold OrElse w.Status = CDR.ScannedKanban.PickingStatus.PartiallyCompleted) Then 'FALTA ALGUNA KANBAN DE PICKEAR
                            If AskBadge() Then
                                If CBool(Parameter("DDR_AllowExitNoPickedup", "False", True)) Then
                                    If LabelMissingBins(cart.CurrentLoopID) Then
                                        Dim scan As New DDR_ExitCart
                                        scan.Badge = Me.CurrentBadge
                                        scan.Cart = cart
                                        scan.ShowDialog()
                                        scan.Dispose()
                                        Option_txt.Focus()
                                    Else
                                        Option_txt.Focus()
                                        FlashAlerts.ShowError("Debes de corregir todas las kanbans.", 1, True)
                                    End If
                                Else
                                    Option_txt.Focus()
                                    FlashAlerts.ShowError("El carro no ha sido completamente surtido.", 1, True)
                                End If
                            Else
                                FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                            End If
                        Else
                            If AskBadge() Then
                                If LabelMissingBins(cart.CurrentLoopID) Then
                                    Dim scan As New DDR_ExitCart
                                    scan.Badge = Me.CurrentBadge
                                    scan.Cart = cart
                                    If scan.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        Option_txt.Focus()
                                        FlashAlerts.ShowConfirm("Bins registrados.", 1, True)
                                    Else
                                        Option_txt.Focus()
                                        FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                                    End If
                                    scan.Dispose()
                                Else
                                    Option_txt.Focus()
                                    FlashAlerts.ShowError("Debes de corregir todas las kanbans.", 1, True)
                                End If
                            Else
                                Option_txt.Focus()
                                FlashAlerts.ShowInformation("Operación cancelada.", 1, True)
                            End If
                        End If
                    End If

                    background.Close()
                    background.Dispose()
                    cart.Refresh()
                Else
                    Option_txt.Focus()
                    FlashAlerts.ShowError("Opción incorrecta.")
                End If
        End Select
        timers_stopped = False
    End Sub

    Private Function LabelMissingBins(loopid As Integer) As Boolean
        If CBool(Parameter("DDR_FixMissingIDKanbans", "False")) Then
            If SQL.Current.Exists(String.Format("SELECT TOP 1 Kanban, S.Partnumber AS [No. de Parte], R.[Description] AS Descripcion, M.ID AS MovementID FROM DDR_CartsLoopKanbans AS K INNER JOIN Smk_DDRSerialDiscount AS D ON K.ID = D.KanbanLoopID INNER JOIN Smk_SerialMovements AS M ON D.SerialMovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber LEFT OUTER JOIN CDR_Kanbans AS CK ON K.Kanban = CK.ID WHERE LoopID = {0} AND (CK.Pieces IS NULL OR CK.Pieces <= 1)", loopid)) Then
                Dim mik As New DDR_MissingIDKanbans
                mik.ID_Loop = loopid
                If mik.ShowDialog = Windows.Forms.DialogResult.OK Then
                    mik.Dispose()
                    Return True
                Else
                    mik.Dispose()
                    Return False
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Public Property CurrentBadge As String
    Private Function AskBadge() As Boolean
        Dim background As New FadeBackground()
        background.Show()
        Dim badge As New Smk_BadgeKiosk
        If badge.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.CurrentBadge = badge.SelectedBadge
            badge.Dispose()
            background.Close()
            background.Dispose()
            Return True
        Else
            background.Close()
            background.Dispose()
            badge.Dispose()
            Return False
        End If
    End Function

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs)
        Dim fadeback As New FadeBackground(CDR_ExitRoute)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Missing_btn_Click(sender As Object, e As EventArgs)
        Dim fadeback As New FadeBackground(CDR_MissingPartnumbers)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Missing_timer_Tick(sender As Object, e As EventArgs) Handles Missing_timer.Tick
        UpdateMissing()
    End Sub

    Private Sub CleanOperatorInfo()
        Picture_pb.Image = Nothing
        Loops_flp.Controls.Clear()
        OperatorTotalTime_lbl.Text = ""
        OperatorAvgTime_lbl.Text = ""
        OperatorContainersCount_lbl.Text = ""
    End Sub

    Private Sub UpdateMissing()
        If Not timers_stopped AndAlso SQL.Current.Available Then
            Critical_dgv.DataSource = Nothing 'SQL.Current.GetDatatable(String.Format("SELECT K.Code AS Bin,K.Partnumber AS [No. de Parte], K.Business AS Negocio, L.PickingDate AS Fecha,ISNULL((SELECT Total FROM vw_Smk_AvailableStock WHERE Partnumber = K.Partnumber),0) AS [Inventario] FROM [DDR_CartsLoopKanbans] AS C INNER JOIN CDR_Kanbans AS K ON C.Kanban = K.ID INNER JOIN DDR_CartsLoopRegister AS L ON C.LoopID = L.ID INNER JOIN DDR_Carts AS CA ON L.Cart = CA.ID  WHERE C.[Status] = 'M' AND CA.Warehouse = '{0}'", My.Settings.Warehouse))
            ShiftCrtitical_lbl.Text = "N/D" ' Critical_dgv.Rows.Count
        End If
    End Sub

    Private Sub ForwardCarrousel()
        CleanOperatorInfo()
        If current_carrousel Is Nothing Then
            current_carrousel = New CDR.Carrousel
            GF.FillCombobox(Operator_cbo, SQL.Current.GetDatatable(String.Format("SELECT Fullname,Badge FROM Smk_Operators WHERE Badge IN ('{0}');", String.Join("','", current_carrousel.Badges.ToArray))), "Fullname", "Badge")
            'RefreshShiftMonitoring()
        End If

        Dim badge As String = current_carrousel.NextBadge()
        If badge = "" Then
            current_carrousel = New CDR.Carrousel
            GF.FillCombobox(Operator_cbo, SQL.Current.GetDatatable(String.Format("SELECT Fullname,Badge FROM Smk_Operators WHERE Badge IN ('{0}');", String.Join("','", current_carrousel.Badges.ToArray))), "Fullname", "Badge")
            If current_carrousel.Items.Count > 0 Then
                ForwardCarrousel()
            Else
                Operator_cbo.SelectedIndex = -1
                ShiftCarts_lbl.Text = ""
                ShiftContainers_lbl.Text = ""
                ShiftAvgCart_lbl.Text = ""
                ShiftAvgContainer_lbl.Text = ""
            End If
        Else
            Picture_pb.Image = Delta.GetUserPhoto(badge)
            Operator_cbo.SelectedValue = badge
            Dim last_operation As Date = SQL.Current.GetDate(String.Format("SELECT CAST(CONVERT(DATE,GETDATE()) AS DATETIME) + CAST(Start AS DATETIME) FROM Sys_Shifts WHERE Shift = '{0}';", CurrentShift))
            Dim bines As Integer = 0
            Dim total_bines, total_seconds, total_carts As Integer
            Dim seconds As Integer = 0
            Dim carts_count As Integer = 0
            For Each i As CDR.CarrouselItem In current_carrousel.Items
                If i.CollectingBadge = badge Then
                    carts_count += 1
                    Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Recoleccion", last_operation, i.ArrivalDate, i.TotalKanbans)
                    Loops_flp.Controls.Add(icon)
                    seconds += DateDiff(DateInterval.Second, last_operation, i.ArrivalDate)
                    bines += i.TotalKanbans
                    last_operation = i.ArrivalDate
                End If
                If i.ScanningBadge = badge Then
                    carts_count += 1
                    Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Escaneo ->", i.InDate, i.InEndDate, i.TotalKanbans)
                    Loops_flp.Controls.Add(icon)
                    seconds += DateDiff(DateInterval.Second, i.InDate, i.InEndDate)
                    bines += i.TotalKanbans
                    last_operation = i.InEndDate
                End If
                If i.PickingBadge = badge Then
                    carts_count += 1
                    Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Surtido", i.PickingDate, i.PickingEndDate, i.TotalKanbans)
                    Loops_flp.Controls.Add(icon)
                    seconds += DateDiff(DateInterval.Second, i.PickingDate, i.PickingEndDate)
                    bines += i.TotalKanbans
                    last_operation = i.PickingEndDate
                End If
                If i.ScanningOutBadge = badge Then
                    carts_count += 1
                    Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Escaneo <-", i.OutDate, i.OutEndDate, i.TotalKanbans)
                    Loops_flp.Controls.Add(icon)
                    seconds += DateDiff(DateInterval.Second, i.OutDate, i.OutEndDate)
                    bines += i.TotalKanbans
                    last_operation = i.OutEndDate
                End If
                If i.DeliveringBadge = badge Then
                    carts_count += 1
                    Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Entrega", i.DeliveryDate, i.DeliveryEndDate, i.TotalKanbans)
                    Loops_flp.Controls.Add(icon)
                    seconds += DateDiff(DateInterval.Second, i.DeliveryDate, i.DeliveryEndDate)
                    bines += i.TotalKanbans
                    last_operation = i.DeliveryEndDate
                End If
            Next

            OperatorContainersCount_lbl.Text = bines
            Dim seconds_avg As Integer = seconds / carts_count
            Dim minutes As Integer = Math.Floor(seconds / 60)
            Dim hours As Integer = Math.Floor(minutes / 60)
            seconds -= minutes * 60
            minutes -= hours * 60
            OperatorTotalTime_lbl.Text = String.Format("{0}:{1}", hours.ToString("00"), minutes.ToString("00"))

            minutes = Math.Floor(seconds_avg / 60)
            seconds = seconds_avg - (minutes * 60)
            OperatorAvgTime_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))


            total_carts = current_carrousel.Items.Where(Function(w) w.Status = CDR.Status.Delivering).Count
            total_seconds = current_carrousel.Items.Where(Function(w) w.Status = CDR.Status.Delivering).Sum(Function(s) DateDiff(DateInterval.Second, s.ArrivalDate, s.DeliveryDate))
            total_bines = current_carrousel.Items.Where(Function(w) w.Status = CDR.Status.Delivering).Sum(Function(s) s.TotalKanbans)
            ShiftCarts_lbl.Text = total_carts
            ShiftContainers_lbl.Text = total_bines

            If total_carts > 0 Then
                seconds_avg = total_seconds / total_carts
                minutes = Math.Floor(seconds_avg / 60)
                seconds = seconds_avg - (minutes * 60)
                ShiftAvgCart_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))
            Else
                ShiftAvgCart_lbl.Text = "0"
            End If

            If total_bines > 0 Then
                seconds_avg = total_seconds / total_bines
                minutes = Math.Floor(seconds_avg / 60)
                seconds = seconds_avg - (minutes * 60)
                ShiftAvgContainer_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))
            Else
                ShiftAvgContainer_lbl.Text = "0"
            End If
        End If
    End Sub

    Private Sub ForwardCarrousel(badge As String)
        CleanOperatorInfo()
        Picture_pb.Image = Delta.GetUserPhoto(badge)
        Dim last_operation As Date = SQL.Current.GetDate(String.Format("SELECT CAST(CONVERT(DATE,GETDATE()) AS DATETIME) + CAST(Start AS DATETIME) FROM Sys_Shifts WHERE Shift = '{0}';", CurrentShift))
        Dim bines As Integer = 0
        'Dim total_bines, total_seconds, total_carts As Integer
        Dim seconds As Integer = 0
        Dim carts_count As Integer = 0
        For Each i As CDR.CarrouselItem In current_carrousel.Items
            If i.CollectingBadge = badge Then
                carts_count += 1
                Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Recoleccion", last_operation, i.ArrivalDate, i.TotalKanbans)
                Loops_flp.Controls.Add(icon)
                seconds += DateDiff(DateInterval.Second, last_operation, i.ArrivalDate)
                bines += i.TotalKanbans
                last_operation = i.ArrivalDate
            End If
            If i.ScanningBadge = badge Then
                carts_count += 1
                Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Escaneo ->", i.InDate, i.InEndDate, i.TotalKanbans)
                Loops_flp.Controls.Add(icon)
                seconds += DateDiff(DateInterval.Second, i.InDate, i.InEndDate)
                bines += i.TotalKanbans
                last_operation = i.InEndDate
            End If
            If i.PickingBadge = badge Then
                carts_count += 1
                Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Surtido", i.PickingDate, i.PickingEndDate, i.TotalKanbans)
                Loops_flp.Controls.Add(icon)
                seconds += DateDiff(DateInterval.Second, i.PickingDate, i.PickingEndDate)
                bines += i.TotalKanbans
                last_operation = i.PickingEndDate
            End If
            If i.ScanningOutBadge = badge Then
                carts_count += 1
                Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Escaneo <-", i.OutDate, i.OutEndDate, i.TotalKanbans)
                Loops_flp.Controls.Add(icon)
                seconds += DateDiff(DateInterval.Second, i.OutDate, i.OutEndDate)
                bines += i.TotalKanbans
                last_operation = i.OutEndDate
            End If
            If i.DeliveringBadge = badge Then
                carts_count += 1
                Dim icon As New DDR_LoopIcon(carts_count, i.Cart, "Entrega", i.DeliveryDate, i.DeliveryEndDate, i.TotalKanbans)
                Loops_flp.Controls.Add(icon)
                seconds += DateDiff(DateInterval.Second, i.DeliveryDate, i.DeliveryEndDate)
                bines += i.TotalKanbans
                last_operation = i.DeliveryEndDate
            End If
        Next

        OperatorContainersCount_lbl.Text = bines
        Dim seconds_avg As Integer = seconds / carts_count
        Dim minutes As Integer = Math.Floor(seconds / 60)
        Dim hours As Integer = Math.Floor(minutes / 60)
        seconds -= minutes * 60
        minutes -= hours * 60
        OperatorTotalTime_lbl.Text = String.Format("{0}:{1}", hours.ToString("00"), minutes.ToString("00"))

        minutes = Math.Floor(seconds_avg / 60)
        seconds = seconds_avg - (minutes * 60)
        OperatorAvgTime_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))
    End Sub

    Private Sub Carrousel_timer_Tick(sender As Object, e As EventArgs) Handles Carrousel_timer.Tick
        ForwardCarrousel()
        Carts_flp.Controls.Clear()
        For Each cart In CDR.Carts
            cart.Refresh()
            Carts_flp.Controls.Add(cart.Icon)
        Next
    End Sub


    Private Sub CDR_Checkpoint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        timers_stopped = True
        Carrousel_timer.Stop()
        Missing_timer.Stop()
        Carrousel_timer.Enabled = False
        Missing_timer.Enabled = False
        Carrousel_timer.Dispose()
        Missing_timer.Dispose()
        CDR.CleanRoutesInfo()
        Me.Dispose()
    End Sub

    Private Sub Crono_timer_Tick(sender As Object, e As EventArgs) Handles Crono_timer.Tick
        For Each cart In CDR.Carts
            cart.Icon.RefreshCrono()
        Next
    End Sub

    Private Sub Critical_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Critical_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso Critical_dgv.Rows(e.RowIndex).Cells("Inventario").Value > 0 Then
            e.CellStyle.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub Operator_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Operator_cbo.SelectionChangeCommitted
        ForwardCarrousel(Operator_cbo.SelectedValue)
    End Sub
End Class