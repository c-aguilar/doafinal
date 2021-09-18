Public Class Smk_CableCheckpoint
    Dim last_shift As String = Delta.CurrentShift
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Public Sub LoadSettings()
        Warehouse_lbl.Text = String.Format("Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        My.Settings.WarehouseTerminalScale = SQL.Current.Exists("Smk_Warehouses", {"Warehouse", "TerminalScaleEnabled"}, {My.Settings.Warehouse, 1})
        If CBool(Parameter("SMK_CableActiveCutterRoutes", "False")) Then
            timerClean.Enabled = True
            Registry_tsm.Visible = True
        Else
            Registry_tsm.Visible = False
            timerClean.Enabled = False
        End If
        If CBool(Parameter("SMK_CableActiveRewindOption", "False")) Then
            NewReel_tsm.Visible = True
            Rewind_btn.Visible = True
        End If
        If CBool(Parameter("SMK_CableActiveInventoryOption", "False")) Then
            Inventory_tsm.Visible = True
        End If
        RefreshCounters()
    End Sub

    Private Sub BuscarSerieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindRandom_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableSearchRandom)
        fadeback.ShowDialog()
    End Sub

    Private Sub BuscarNPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindService_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableSearchService)
        fadeback.ShowDialog()
    End Sub

    Private Sub F2CambioEntreCortadorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCutter_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableCutterChange)
        fadeback.ShowDialog()
    End Sub

    Private Sub ReimprimirKanbanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reprint_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableSerialReprint)
        fadeback.ShowDialog()
    End Sub

    Private Sub PendientesDeSurtirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialPending_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CablePendingNextSerials)
        fadeback.ShowDialog()
    End Sub

    Private Sub BarrilesEnCortadorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialOnCutter_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableSerialsOnCutters)
        fadeback.ShowDialog()
    End Sub

    Private Sub RegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Registry_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableRoutesRegistry)
        fadeback.ShowDialog()
    End Sub

    Private Sub timerClean_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerClean.Tick
        If SQL.Current.Available AndAlso last_shift <> Delta.CurrentShift Then
            SQL.Current.Update("Smk_CableOperatorRegistry", "Active", 0, "Active", 0)
        End If
    End Sub

    Private Sub timerWork_Tick(sender As Object, e As EventArgs) Handles timerWork.Tick
        RefreshCounters()
    End Sub

    Private Sub RefreshCounters()
        If SQL.Current.Available Then
            Pendings_lbl.Text = SQL.Current.GetScalar("COUNT(Serialnumber)", "Smk_CableNextSerials", "Warehouse", My.Settings.Warehouse)
            TerminalsOnCutters_lbl.Text = SQL.Current.GetScalar("COUNT(*)", "vw_Smk_Serials", {"Status", "Warehouse", "MaterialType"}, {"C", My.Settings.Warehouse, "Terminal"})
            CableOnCutter_lbl.Text = SQL.Current.GetScalar("COUNT(*)", "vw_Smk_Serials", {"Status", "Warehouse", "MaterialType"}, {"C", My.Settings.Warehouse, "Cable"})
            MoreThan6_lbl.Text = SQL.Current.GetScalar(String.Format("SELECT COUNT(*) FROM vw_Smk_Serials WHERE Status = 'C' AND DATEDIFF(HOUR,dbo.Smk_SerialLastCutterDate(ID),GETDATE()) >= 6 AND Warehouse = '{0}'", My.Settings.Warehouse))
        End If
    End Sub


    Private Sub RebobinadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewReel_tsm.Click
        Dim fadeback As New FadeBackground(Smk_CableNewReel)
        fadeback.ShowDialog()
        Option_txt.Clear()
        Option_txt.Focus()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Inventory_tsm.Click
        Dim fadeback As New FadeBackground(Smk_APITicketSelector)
        fadeback.ShowDialog()
        Option_txt.Clear()
        Option_txt.Focus()
    End Sub

    Private Sub Empty_btn_Click(sender As Object, e As EventArgs) Handles Empty_btn.Click
        Dim fadeback As New FadeBackground(Smk_CableDeclareEmpty)
        fadeback.ShowDialog()
        Option_txt.Clear()
        Option_txt.Focus()
    End Sub

    Private Sub Option_txt_TextChanged(sender As Object, e As EventArgs) Handles Option_txt.TextChanged
        Select Case Option_txt.Text.ToUpper
            Case "EMPTY", "VACIO", "OPEN", "ABRIR"
                ReadScan()
            Case "REWIND"
                If CBool(Parameter("SMK_CableActiveRewindOption", "False")) Then
                    ReadScan()
                End If
            Case Else
                If SMK.IsSerialFormat(Option_txt.Text) Then
                    ReadScan()
                End If
        End Select
    End Sub

    Private Sub ReadScan()
        Select Case Option_txt.Text.ToUpper
            Case "OPEN", "ABRIR"
                Dim fadeback As New FadeBackground(Smk_CableRandomToService)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "EMPTY", "VACIO"
                Dim fadeback As New FadeBackground(Smk_CableDeclareEmpty)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "REWIND"
                If CBool(Parameter("SMK_CableActiveRewindOption", "False")) Then
                    Dim fadeback As New FadeBackground(Smk_CableNewReel)
                    fadeback.ShowDialog()
                    Option_txt.Clear()
                    Option_txt.Focus()
                End If
            Case Else
                If SMK.IsSerialFormat(Option_txt.Text) Then
                    Dim serial As New Serialnumber(Option_txt.Text)
                    If serial.Exists Then
                        If serial.RedTag Then
                            Clean()
                            FlashAlerts.ShowError("Serie bloqueada por Calidad.")
                        ElseIf serial.InvoiceTrouble Then
                            Log(serial.SerialNumber, "Smk_TryOpenSerialOnTracker", "DeltaERP")
                            Clean()
                            FlashAlerts.ShowError("Serie se encuentra en Tracker de Problemas.")
                        ElseIf serial.Type = RawMaterial.MaterialType.Cable Then
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                                Case Serialnumber.SerialStatus.Stored
                                    Dim background As New FadeBackground()
                                    Dim rtc As New Smk_CableRandomToCutter
                                    rtc.Serial = serial
                                    background.Show()
                                    rtc.ShowDialog()
                                    background.Close()
                                    background.Dispose()
                                    Option_txt.Clear()
                                    Option_txt.Focus()
                                Case Serialnumber.SerialStatus.OnCutter
                                    Dim background As New FadeBackground()
                                    Dim cts As New Smk_CableCutterToService
                                    cts.Serial = serial
                                    background.Show()
                                    cts.ShowDialog()
                                    background.Close()
                                    background.Dispose()
                                    Option_txt.Clear()
                                    Option_txt.Focus()
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                                    Dim background As New FadeBackground()
                                    Dim stc As New Smk_CableServiceToCutter
                                    stc.serial = serial
                                    background.Show()
                                    stc.ShowDialog()
                                    background.Close()
                                    background.Dispose()
                                    Option_txt.Clear()
                                    Option_txt.Focus()
                                Case Serialnumber.SerialStatus.Empty
                                    Clean()
                                    FlashAlerts.ShowError("La serie ya fue declarada vacía.")
                            End Select
                        ElseIf serial.Type = RawMaterial.MaterialType.Calibre Then
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                                Case Serialnumber.SerialStatus.Stored
                                    Dim background As New FadeBackground()
                                    Dim rtc As New Smk_TerminalRandomToCutter_New
                                    rtc.Serial = serial
                                    background.Show()
                                    rtc.ShowDialog()
                                    background.Close()
                                    background.Dispose()
                                    Option_txt.Clear()
                                    Option_txt.Focus()
                                Case Serialnumber.SerialStatus.OnCutter
                                    If serial.Weight > 0 Then 'SOLO ROLLOS QUE SI FUERON PESADOS
                                        Dim background As New FadeBackground()
                                        Dim cts As New Smk_TerminalCutterToService_New
                                        cts.Serial = serial
                                        background.Show()
                                        cts.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Else 'ROLLOS QUE ESTABAN EN USO ANTES DE LA IMPLEMENTACION
                                        Dim background As New FadeBackground()
                                        Dim cts As New Smk_TerminalCutterToService2_New
                                        cts.Serial = serial
                                        background.Show()
                                        cts.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    End If
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                                    If serial.Weight = 0 And serial.CurrentQuantity > 0 Then 'NO HA SIDO PESADO EL CARRETE
                                        Dim background As New FadeBackground()
                                        Dim rtc As New Smk_TerminalRandomToCutter_New
                                        rtc.Serial = serial
                                        background.Show()
                                        rtc.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Else
                                        Dim background As New FadeBackground()
                                        Dim stc As New Smk_CableServiceToCutter
                                        stc.serial = serial
                                        background.Show()
                                        stc.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    End If

                                Case Serialnumber.SerialStatus.Empty
                                    Clean()
                                    FlashAlerts.ShowError("La serie ya fue declarada vacía.")
                            End Select
                        ElseIf serial.Type = RawMaterial.MaterialType.Terminal Then
                            If My.Settings.WarehouseTerminalScale Then
                                Select Case serial.Status
                                    Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                        Clean()
                                        FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                                    Case Serialnumber.SerialStatus.Stored
                                        Dim background As New FadeBackground()
                                        Dim rtc As New Smk_TerminalRandomToCutter_New
                                        rtc.Serial = serial
                                        background.Show()
                                        rtc.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Case Serialnumber.SerialStatus.OnCutter
                                        If serial.Weight > 0 Then 'SOLO ROLLOS QUE SI FUERON PESADOS
                                            Dim background As New FadeBackground()
                                            Dim cts As New Smk_TerminalCutterToService_New
                                            cts.Serial = serial
                                            background.Show()
                                            cts.ShowDialog()
                                            background.Close()
                                            background.Dispose()
                                            Option_txt.Clear()
                                            Option_txt.Focus()
                                        Else 'ROLLOS QUE ESTABAN EN USO ANTES DE LA IMPLEMENTACION
                                            Dim background As New FadeBackground()
                                            Dim cts As New Smk_TerminalCutterToService2_New
                                            cts.Serial = serial
                                            background.Show()
                                            cts.ShowDialog()
                                            background.Close()
                                            background.Dispose()
                                            Option_txt.Clear()
                                            Option_txt.Focus()
                                        End If
                                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                                        If serial.Weight = 0 And serial.CurrentQuantity > 0 Then 'NO HA SIDO PESADO EL CARRETE
                                            Dim background As New FadeBackground()
                                            Dim rtc As New Smk_TerminalRandomToCutter_New
                                            rtc.Serial = serial
                                            background.Show()
                                            rtc.ShowDialog()
                                            background.Close()
                                            background.Dispose()
                                            Option_txt.Clear()
                                            Option_txt.Focus()
                                        Else
                                            Dim background As New FadeBackground()
                                            Dim stc As New Smk_CableServiceToCutter
                                            stc.serial = serial
                                            background.Show()
                                            stc.ShowDialog()
                                            background.Close()
                                            background.Dispose()
                                            Option_txt.Clear()
                                            Option_txt.Focus()
                                        End If

                                    Case Serialnumber.SerialStatus.Empty
                                        Clean()
                                        FlashAlerts.ShowError("La serie ya fue declarada vacía.")
                                End Select
                            Else
                                Select Case serial.Status
                                    Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                        Clean()
                                        FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                                    Case Serialnumber.SerialStatus.Stored
                                        Dim background As New FadeBackground()
                                        Dim rtc As New Smk_TerminalRandomToCutter
                                        rtc.Serial = serial
                                        background.Show()
                                        rtc.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Case Serialnumber.SerialStatus.OnCutter
                                        Dim background As New FadeBackground()
                                        Dim cts As New Smk_TerminalCutterToService
                                        cts.Serial = serial
                                        background.Show()
                                        cts.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                                        Dim background As New FadeBackground()
                                        Dim stc As New Smk_CableServiceToCutter
                                        stc.serial = serial
                                        background.Show()
                                        stc.ShowDialog()
                                        background.Close()
                                        background.Dispose()
                                        Option_txt.Clear()
                                        Option_txt.Focus()
                                    Case Serialnumber.SerialStatus.Empty
                                        Clean()
                                        FlashAlerts.ShowError("La serie ya fue declarada vacía.")
                                End Select
                            End If
                        Else
                            Clean()
                            FlashAlerts.ShowError("Tipo de material incorrecto.")
                        End If
                    Else
                        Clean()
                        FlashAlerts.ShowError("La serie no existe.")
                    End If
                    serial = Nothing
                Else
                    FlashAlerts.ShowInformation("Serie incorrecta.")
                End If
        End Select
    End Sub

    Private Sub Clean()
        Option_txt.Clear()
        Option_txt.Focus()
    End Sub

    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Dim fadeback As New FadeBackground(Smk_CableRandomToService)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Smk_CableCheckpoint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Rewind_btn_Click(sender As Object, e As EventArgs) Handles Rewind_btn.Click
        Dim fadeback As New FadeBackground(Smk_CableNewReel)
        fadeback.ShowDialog()
        Option_txt.Clear()
        Option_txt.Focus()
    End Sub

    Private Sub Settings_tsm_Click(sender As Object, e As EventArgs) Handles Settings_tsm.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("Supermarket_CableScaleSettings_Change_flag") Then
                Dim settings As New Smk_SmkSettings
                settings.ShowDialog()
                settings.Dispose()
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub

    Private Sub MoreThan6_lbl_Click(sender As Object, e As EventArgs) Handles MoreThan6_lbl.Click
        ShowPopup(SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS [No. de Serie],Partnumber AS [No. de Parte],CurrentQuantity AS [Cantidad Actual],UoM AS Unidad,Location AS [Local de Servicio],WarehouseName AS Estacion ,dbo.Smk_SerialLastCutterName(ID) AS Cortadora,DATEDIFF(HOUR,dbo.Smk_SerialLastCutterDate(ID),GETDATE()) AS Horas FROM vw_Smk_Serials WHERE Status = 'C' AND DATEDIFF(HOUR,dbo.Smk_SerialLastCutterDate(ID),GETDATE()) >= 6 AND Warehouse = '{0}' ORDER BY DATEDIFF(HOUR,dbo.Smk_SerialLastCutterDate(ID),GETDATE()) DESC", My.Settings.Warehouse)), "+6 Horas", 800, 400, Option_txt.PointToScreen(New Point(0, 0)))
    End Sub
End Class
