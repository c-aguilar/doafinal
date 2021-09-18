'=====================DELTA ERP============================'
'========Desarrollado por Carlos Aguilar==================='
'======================2018================================'
Public Class Main
#Region "Form"
#Region "Events"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        MainForm = Me
        ChangeMenuLanguage()
        EnableMenu()
        If My.Settings.Warehouse = "" Then
            My.Settings.Warehouse = SQL.Current.GetString("SELECT TOP 1 Warehouse FROM Smk_Warehouses")
            My.Settings.Save()
        End If

        'If User.Current.OnDomain Then
        '    Me.ControlBox = False
        '    AD_bwkr.RunWorkerAsync()
        'Else
        '    Me.ControlBox = True
        'End If
        UserToolStripStatusLabel.Text = User.Current.FullName
        If User.Current.Language = "EN" Then
            Main_MyAccount_Language_English_mi.Checked = True
            Main_MyAccount_Language_Spanish_mi.Checked = False
        Else
            Main_MyAccount_Language_Spanish_mi.Checked = True
            Main_MyAccount_Language_English_mi.Checked = False
        End If
        UpdateDefaultButton()

        If Not User.Current.Username = "public" Then
            Alerts_nicon.Visible = True
            Alerts_timer.Enabled = True
            Alerts_timer_Tick(Nothing, Nothing)
        End If
        If Delta.SandBox Then DeltaStartButton.Text = "SandBox"
        'Me.Activate()



    End Sub
    Private Sub ChangeMenuLanguage()
        Main_About_mi.Text = Language.Sentence(88)
        Main_MyAccount_mi.Text = Language.Sentence(89)
        Main_Engineering_mi.Text = Language.Sentence(90)
        Main_Scheduling_mi.Text = Language.Sentence(91)
        Main_Receiving_mi.Text = Language.Sentence(92)
        Main_Quality_mi.Text = Language.Sentence(93)
        Main_Ordering_mi.Text = Language.Sentence(94)
        Main_CustomerService_mi.Text = Language.Sentence(95)
        Main_Supermarket_mi.Text = Language.Sentence(96)
        Main_DieCenter_mi.Text = Language.Sentence(97)
        Main_ComponentDeliveryRoutes_mi.Text = Language.Sentence(98)
        Main_Leadprep_mi.Text = Language.Sentence(99)
        Main_SecondaryLeadprep_mi.Text = Language.Sentence(100)
        Main_Manufacturing_mi.Text = Language.Sentence(101)
        Main_FinishGoodRoutes_mi.Text = Language.Sentence(102)
        Main_Shipping_mi.Text = Language.Sentence(103)
        Main_MaterialAnalyst_mi.Text = Language.Sentence(104)
        Main_Administrator_mi.Text = Language.Sentence(105)
        DeltaStartButton.Text = Language.Sentence(106)
        Main_MyAccount_Profile_mi.Text = Language.Sentence(107)
        Main_MyAccount_Vacations_mi.Text = Language.Sentence(108)
        Main_MyAccount_Password_mi.Text = Language.Sentence(109)
        Main_MyAccount_Language_mi.Text = Language.Sentence(110)
        Main_MyAccount_Language_Spanish_mi.Text = Language.Sentence(111)
        Main_MyAccount_Language_English_mi.Text = Language.Sentence(112)
        Main_Engineering_Database_mi.Text = Language.Sentence(113)
        Main_Engineering_Database_Leadcodes_mi.Text = Language.Sentence(114)
        Main_Engineering_Database_RawMaterial_mi.Text = Language.Sentence(115)
        Main_Engineering_Database_Cutters_mi.Text = Language.Sentence(116)
        Main_Engineering_Database_BOM_mi.Text = Language.Sentence(117)
        Main_Engineering_Database_Others_mi.Text = Language.Sentence(118)
        Main_Engineering_Reports_mi.Text = Language.Sentence(119)
        Main_Scheduling_Database_mi.Text = Language.Sentence(122)
        Main_Scheduling_Database_MRP_mi.Text = Language.Sentence(123)
        Main_Scheduling_Database_Families_mi.Text = Language.Sentence(124)
        Main_Scheduling_Database_Business_mi.Text = Language.Sentence(125)
        Main_Scheduling_Database_MaterialNumbers_mi.Text = Language.Sentence(126)
        Main_Scheduling_Database_Boards_mi.Text = Language.Sentence(127)
        Main_Scheduling_Database_MaterialBoard_mi.Text = Language.Sentence(128)
        Main_Scheduling_Database_1719Controls_mi.Text = Language.Sentence(129)
        Main_Scheduling_Database_Headcount_mi.Text = Language.Sentence(130)
        Main_Scheduling_Database_ContractedCapacity_mi.Text = Language.Sentence(131)
        Main_Scheduling_Database_ShippingDays_mi.Text = Language.Sentence(132)
        Main_Scheduling_SAP_mi.Text = Language.Sentence(133)
        Main_Scheduling_SAP_VL10_mi.Text = Language.Sentence(134)
        Main_Scheduling_SAP_ZMDESNR_mi.Text = Language.Sentence(135)
        Main_Scheduling_SAP_Inventory_mi.Text = Language.Sentence(136)
        Main_Scheduling_SAP_ProductionPlanExport_mi.Text = Language.Sentence(137)
        Main_Scheduling_SAP_ProductionPlanImport_mi.Text = Language.Sentence(138)
        Main_Scheduling_SAP_PrintLabels_mi.Text = Language.Sentence(139)
        Main_Scheduling_EPS_mi.Text = Language.Sentence(140)
        Main_Scheduling_EPS_Import_mi.Text = Language.Sentence(141)
        Main_Scheduling_ProductionPlan_mi.Text = Language.Sentence(142)
        Main_Scheduling_ProductionPlan_Low_mi.Text = Language.Sentence(143)
        Main_Scheduling_ProductionPlan_High_mi.Text = Language.Sentence(144)
        Main_Scheduling_Reports_mi.Text = Language.Sentence(145)
        Main_Scheduling_Reports_VL10_mi.Text = Language.Sentence(146)
        Main_Scheduling_Reports_VL10_Variations_mi.Text = Language.Sentence(147)
        Main_Scheduling_Reports_VL10_Capacity_mi.Text = Language.Sentence(148)
        Main_Scheduling_Reports_VL10_Headcount_mi.Text = Language.Sentence(149)
        Main_Scheduling_Reports_VL10_Current_mi.Text = Language.Sentence(150)
        Main_Scheduling_Reports_VL10_Waterfall_mi.Text = Language.Sentence(151)
        Main_Scheduling_Reports_ProductionPlan_mi.Text = Language.Sentence(152)
        Main_Scheduling_Reports_ProductionPlan_Headcount_mi.Text = Language.Sentence(153)
        Main_Scheduling_Reports_ProductionPlan_Waterfall_mi.Text = Language.Sentence(154)
        Main_Receiving_Labeling_mi.Text = Language.Sentence(155)
        Main_Receiving_Labels_mi.Text = Language.Sentence(156)
        Main_Receiving_Labels_New_mi.Text = Language.Sentence(157)
        Main_Receiving_Labels_Reprint_mi.Text = Language.Sentence(158)
        Main_Receiving_Labels_Delete_mi.Text = Language.Sentence(159)
        Main_Receiving_Reports_mi.Text = Language.Sentence(160)
        Main_Receiving_Reports_ScanningVsMB51_mi.Text = Language.Sentence(161)
        Main_Receiving_Reports_ScanningVsStored_mi.Text = Language.Sentence(162)
        Main_Receiving_Management_mi.Text = Language.Sentence(164)
        Main_Receiving_Management_Alerts_mi.Text = Language.Sentence(165)
        Main_Receiving_Management_LabelFlags_mi.Text = Language.Sentence(166)
        Main_Receiving_Management_Scanners_mi.Text = Language.Sentence(167)
        Main_Quality_Alerts_mi.Text = Language.Sentence(168)
        Main_Quality_Alerts_New_mi.Text = Language.Sentence(169)
        Main_Quality_Alerts_Remove_mi.Text = Language.Sentence(170)
        Main_Quality_Alerts_UnlockSerialnumber_mi.Text = Language.Sentence(171)
        Main_Quality_Reports_mi.Text = Language.Sentence(172)
        Main_Quality_Reports_History_mi.Text = Language.Sentence(173)
        Main_Quality_Reports_LockedSerialnumbers_mi.Text = Language.Sentence(174)
        Main_Ordering_Supermarket_mi.Text = Language.Sentence(175)
        Main_Ordering_Supermarket_Mover_mi.Text = Language.Sentence(176)
        Main_Ordering_Supermarket_Mover_New_mi.Text = Language.Sentence(177)
        Main_Ordering_Supermarket_Mover_Cancel_mi.Text = Language.Sentence(178)
        Main_Ordering_Supermarket_Mover_Approve_mi.Text = Language.Sentence(179)
        Main_Ordering_Supermarket_Mover_Print_mi.Text = Language.Sentence(180)
        Main_Ordering_Receiving_mi.Text = Language.Sentence(181)
        Main_Ordering_Receiving_ReportCritical_mi.Text = Language.Sentence(182)
        Main_Ordering_Management_mi.Text = Language.Sentence(183)
        Main_Ordering_Management_MRPControllers_mi.Text = Language.Sentence(184)
        Main_Ordering_Management_ImportForecast_mi.Text = Language.Sentence(185)
        Main_Ordering_Reports_mi.Text = Language.Sentence(186)
        Main_Ordering_Reports_MB51_mi.Text = Language.Sentence(187)
        Main_Ordering_Reports_MB51_261vsZ11_mi.Text = Language.Sentence(188)
        Main_Ordering_Reports_Forecast_mi.Text = Language.Sentence(189)
        Main_Ordering_Reports_Forecast_ForecastVsRealConsumption_mi.Text = Language.Sentence(190)
        Main_Ordering_Reports_Forecast_Waterfall_mi.Text = Language.Sentence(191)
        Main_Ordering_Reports_ABCAnalysis_mi.Text = Language.Sentence(194)
        Main_CustomerService_Tools_mi.Text = Language.Sentence(195)
        Main_CustomerService_Tools_SAP_mi.Text = Language.Sentence(196)
        Main_CustomerService_Tools_SAP_VA32_mi.Text = Language.Sentence(197)
        Main_Supermarket_Components_mi.Text = Language.Sentence(198)
        Main_Supermarket_Components_Store_mi.Text = Language.Sentence(199)
        Main_Supermarket_Components_Open_mi.Text = Language.Sentence(200)
        Main_Supermarket_Components_LocationChange_mi.Text = Language.Sentence(201)
        Main_Supermarket_Components_PartialDiscount_mi.Text = Language.Sentence(202)
        Main_Supermarket_Components_DeclareEmpty_mi.Text = Language.Sentence(203)
        Main_Supermarket_Components_ReactiveSerial_mi.Text = Language.Sentence(204)
        Main_Supermarket_Components_Find_mi.Text = Language.Sentence(205)
        Main_Supermarket_Components_ManualAdjustment_mi.Text = Language.Sentence(206)
        Main_Supermarket_Mover_mi.Text = Language.Sentence(207)
        Main_Supermarket_Mover_Print_mi.Text = Language.Sentence(208)
        Main_Supermarket_Mover_PickUp_mi.Text = Language.Sentence(209)
        Main_Supermarket_Management_mi.Text = Language.Sentence(210)
        Main_Supermarket_Management_PostTransfers_mi.Text = Language.Sentence(211)
        Main_Supermarket_Management_MaterialMaster_mi.Text = Language.Sentence(212)
        Main_Supermarket_Management_Map_mi.Text = Language.Sentence(213)
        Main_Supermarket_Management_Operators_mi.Text = Language.Sentence(214)
        Main_Supermarket_Reports_mi.Text = Language.Sentence(215)
        Main_Supermarket_Reports_SAPVsDelta_mi.Text = Language.Sentence(216)
        Main_Supermarket_Reports_MaterialExpired_mi.Text = Language.Sentence(217)
        Main_Supermarket_Reports_Audit_mi.Text = Language.Sentence(219)
        Main_DieCenter_PicklistCheckpoint_mi.Text = Language.Sentence(220)
        Main_DieCenter_PrintPicklist_mi.Text = Language.Sentence(221)
        Main_DieCenter_Management_mi.Text = Language.Sentence(222)
        Main_DieCenter_Management_Locations_mi.Text = Language.Sentence(223)
        Main_DieCenter_Management_Centers_mi.Text = Language.Sentence(224)
        Main_DieCenter_Management_Checkpoints_mi.Text = Language.Sentence(225)
        Main_ComponentDeliveryRoutes_Management_Checkpoints_mi.Text = Language.Sentence(226)
        Main_ComponentDeliveryRoutes_Database_mi.Text = Language.Sentence(227)
        Main_ComponentDeliveryRoutes_Database_Containerization_mi.Text = Language.Sentence(228)
        Main_ComponentDeliveryRoutes_Database_Engineering_mi.Text = Language.Sentence(229)
        Main_ComponentDeliveryRoutes_Database_ProductionControl_mi.Text = Language.Sentence(230)
        Main_ComponentDeliveryRoutes_Database_Business_mi.Text = Language.Sentence(231)
        Main_ComponentDeliveryRoutes_Database_Kanbans_mi.Text = Language.Sentence(232)
        Main_ComponentDeliveryRoutes_Management_mi.Text = Language.Sentence(233)
        Main_ComponentDeliveryRoutes_Management_Kanbans_mi.Text = Language.Sentence(234)
        Main_ComponentDeliveryRoutes_Management_Routes_mi.Text = Language.Sentence(235)
        Main_ComponentDeliveryRoutes_Management_Print_mi.Text = Language.Sentence(236)
        Main_ComponentDeliveryRoutes_Management_Workload_mi.Text = Language.Sentence(237)
        Main_ComponentDeliveryRoutes_Management_Operators_mi.Text = Language.Sentence(238)
        Main_ComponentDeliveryRoutes_Management_Checkpoints_mi.Text = Language.Sentence(239)
        Main_ComponentDeliveryRoutes_Reports_mi.Text = Language.Sentence(240)
        Main_ComponentDeliveryRoutes_Reports_EngineeringVsZCS12_mi.Text = Language.Sentence(241)
        Main_Leadprep_Miscellaneous_mi.Text = Language.Sentence(242)
        Main_Leadprep_Miscellaneous_Labels_mi.Text = Language.Sentence(243)
        Main_FinishGoodRoutes_Checkpoint_mi.Text = Language.Sentence(244)
        Main_FinishGoodRoutes_Management_mi.Text = Language.Sentence(245)
        Main_FinishGoodRoutes_Management_Checkpoints_mi.Text = Language.Sentence(246)
        Main_FinishGoodRoutes_Management_Operators_mi.Text = Language.Sentence(247)
        Main_FinishGoodRoutes_Management_Routes_mi.Text = Language.Sentence(248)
        Main_FinishGoodRoutes_Management_Backflush_mi.Text = Language.Sentence(249)
        Main_Shipping_Mover_mi.Text = Language.Sentence(250)
        Main_Shipping_Mover_Ship_mi.Text = Language.Sentence(251)
        Main_MaterialAnalyst_SAP_mi.Text = Language.Sentence(252)
        Main_MaterialAnalyst_SAP_MB51_mi.Text = Language.Sentence(253)
        Main_MaterialAnalyst_Reports_mi.Text = Language.Sentence(254)
        Main_MaterialAnalyst_Reports_MB51_mi.Text = Language.Sentence(255)
        Main_MaterialAnalyst_Reports_MB51_261vsZ11_mi.Text = Language.Sentence(256)
        Main_Administrator_Database_mi.Text = Language.Sentence(257)
        Main_Administrator_Database_WorkingDays_mi.Text = Language.Sentence(258)
        Main_Administrator_Database_Parameters_mi.Text = Language.Sentence(259)
        Main_Administrator_Database_RawMaterial_mi.Text = Language.Sentence(260)
        Main_Administrator_Database_RawMaterial_Update_mi.Text = Language.Sentence(261)
        Main_Administrator_Users_mi.Text = Language.Sentence(262)
        Main_Administrator_Users_Management_mi.Text = Language.Sentence(263)
        Main_Administrator_Users_Permissions_mi.Text = Language.Sentence(264)
        Main_Administrator_Users_Permissions_Clone_mi.Text = Language.Sentence(265)
        Main_Administrator_Users_NewPassword_mi.Text = Language.Sentence(266)

    End Sub

    Private Sub SessionTimer_Tick(sender As Object, e As EventArgs) Handles Session_timer.Tick
        If Not SQL.Current.Available OrElse DateDiff(DateInterval.Minute, SQL.Current.LastUse, Now) >= 30 Then
            Session_timer.Stop()
            MessageBox.Show(Language.Sentence(86), Language.Sentence(87), MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
    Private Sub bwAD_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles AD_bwkr.DoWork
        'UserToolStripStatusLabel.Text = User.Current.Properties("name")
        Me.ControlBox = True
    End Sub

    Private Sub bwAD_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles AD_bwkr.RunWorkerCompleted

    End Sub

#End Region
#Region "Functions"
    Private Sub EnableMenu()
        For Each item As ToolStripMenuItem In CType(Main_tsm.Items("DeltaStartButton"), ToolStripDropDownButton).DropDownItems
            ''AGREGAR ITEMS FALTANTES A BASE
            'If Not SQL.Current.Exists("Sys_ModuleOptions", "[Option]", item.Name) Then
            '    SQL.Current.Insert("Sys_ModuleOptions", {"Module", "Form", "[Option]", "[Description]", "[Order]"}, {"Desktop", "Main_Form", item.Name, "Control MenuItem", ""})
            'End If
            If Not User.Current.HasPermission(item.Name) Then
                item.Enabled = False
            End If
            EnableDropDownItems(item)
        Next
    End Sub
    Private Sub EnableDropDownItems(item As ToolStripMenuItem)
        For Each i As ToolStripMenuItem In item.DropDownItems
            ''AGREGAR ITEMS FALTANTES A BASE
            'If Not SQL.Current.Exists("Sys_ModuleOptions", "[Option]", i.Name) Then
            '    SQL.Current.Insert("Sys_ModuleOptions", {"Module", "Form", "[Option]", "[Description]", "[Order]"}, {"Desktop", "Main_Form", i.Name, "Control MenuItem", ""})
            'End If
            If Not User.Current.HasPermission(i.Name) Then
                i.Enabled = False
            End If
            EnableDropDownItems(i)
        Next
    End Sub
#End Region
#End Region

#Region "Scheduling"
#Region "Database"
    Private Sub MRPControllersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_MRP_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MRP,Username AS Usuario FROM Sch_MRPControllers ORDER BY MRP", {"MRP"}, User.Current.HasPermission("Database_Sch_MRPControllers_Add"), User.Current.HasPermission("Database_Sch_MRPControllers_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Usuario", SQL.Current.GetDatatable("SELECT Username,FullName FROM Sys_Users WHERE (Area IN ('Scheduling','Program Readiness') AND Role = 'Scheduler') OR Username IN (SELECT DISTINCT Username FROM Sch_MRPControllers) ORDER BY FullName"), "FullName", "Username"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub FamiliesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Families_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Family AS Familia,CrossDock,[Safety] FROM Sch_Families ORDER BY Family", {"Familia"}, User.Current.HasPermission("Database_Sch_Families_Add"), User.Current.HasPermission("Database_Sch_Families_Delete")))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub BusinessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Business_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Family AS Familia,Business AS Negocio,MRP,Warehouse AS Estacion,Manager AS Gerente FROM Sch_Business ORDER BY Business,Family", {"Negocio", "Familia"}, User.Current.HasPermission("Database_Sch_Business_Add"), User.Current.HasPermission("Database_Sch_Business_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Familia", SQL.Current.GetList("SELECT Family FROM Sch_Families ORDER BY Family").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("MRP", SQL.Current.GetList("SELECT MRP FROM Sch_MRPControllers ORDER BY MRP").ToArray))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub MaterialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_MaterialNumbers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Material,CustomerPN AS [NP Cliente],[Description] AS Descripcion,StdPack,Business AS Negocio,StartProduction AS [Arranque],EndProduction AS [Build Out],Class AS Clasificacion,MRP FROM Sch_Materials ORDER BY Material", {"Material"}, User.Current.HasPermission("Database_Sch_Materials_Add"), User.Current.HasPermission("Database_Sch_Materials_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Negocio", SQL.Current.GetList("SELECT Business FROM Sch_Business ORDER BY Business").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Clasificacion", SQL.Current.GetList("SELECT Class FROM Sch_MaterialClasses ORDER BY Class").ToArray))
        db_table.tables(0).OnlyDateFormatColumns.AddRange({"Arranque", "Build Out"})
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub BoardsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Boards_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Board AS Tablero,Class AS Clase,Volume AS Volumen,ShiftCombination AS Turnos,InstalledCapacity AS [Capacidad Instalada],RealCapacity AS [Capacidad Real],Business AS Negocio FROM Mfg_Boards ORDER BY Board", {"Tablero"}, User.Current.HasPermission("Database_Mfg_Boards_Add"), User.Current.HasPermission("Database_Mfg_Boards_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Clase", SQL.Current.GetList("SELECT Class FROM Mfg_BoardClasses ORDER BY Class").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Volumen", SQL.Current.GetList("SELECT Volume FROM Mfg_Volumes ORDER BY Volume").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turnos", SQL.Current.GetList("SELECT Combination FROM Sys_ShiftCombination ORDER BY Combination").ToArray))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub MaterialBoardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_MaterialBoard_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Material,Board AS Tablero,Active AS Activo FROM Sch_MaterialBoards ORDER BY Material,Board", {"Material", "Tablero"}, User.Current.HasPermission("Database_Sch_MaterialBoards_Add"), User.Current.HasPermission("Database_Sch_MaterialBoards_Delete")))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub ControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_1719Controls_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Material,Seconds AS Segundos,Operators AS Operadores FROM Eng_1719Controls ORDER BY Material", {"Material"}, User.Current.HasPermission("Database_Eng_1719Controls_Add"), User.Current.HasPermission("Database_Eng_1719Controls_Delete")))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub HeadcountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Headcount_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Family AS Familia,LowVolume AS [Bajo Volumen],HighVolume AS [Alto Volumen],Shift AS Turno FROM Mfg_Headcount ORDER BY Family,Shift", {"Familia", "Turno"}, User.Current.HasPermission("Database_Mfg_Headcount_Add"), User.Current.HasPermission("Database_Mfg_Headcount_Add")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Familia", SQL.Current.GetList("SELECT Family FROM Sch_Families ORDER BY Family").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetList("SELECT Shift FROM Sys_Shifts ORDER BY Shift").ToArray))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Scheduling_Database_ContractedCapacity_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_ContractedCapacity_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT * FROM Sch_ContractedCapacity_tmp ORDER BY BoardCode,Material", {"BoardCode", "Material"}, User.Current.HasPermission("Database_Sch_ContractedCapacity_tmp_Add"), User.Current.HasPermission("Database_Sch_ContractedCapacity_tmp_Delete")))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Database_ShippingDays_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_ShippingDays_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT * FROM Sch_ShippingDays ORDER BY Family", {"Family"}, User.Current.HasPermission("Database_Sch_ShippingDays_Add"), User.Current.HasPermission("Database_Sch_ShippingDays_Delete")))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "SAP"
    Private Sub Main_Scheduling_SAP_ZVT11_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ZMDESNR_mi.Click
        'DownloadZVT11()
        SCH.DownloadZMDESNR()
    End Sub
    Private Sub Main_Scheduling_SAP_VL10_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_VL10_mi.Click
        SCH.DownloadVL10()
    End Sub
    Private Sub Main_Scheduling_SAP_Inventory_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_Inventory_mi.Click
        SCH.DownloadCurrentInventory()
    End Sub
    Private Sub Main_Scheduling_SAP_ProductionPlan_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ProductionPlanExport_mi.Click
        OpenForm(Sch_CSVProductionPlanOptionsDialog, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Scheduling_Reports_VL10_Variations_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Variations_mi.Click
        OpenForm(Sch_VL10Variations, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Reports_VL10_Capacity_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Capacity_mi.Click
        OpenForm(Sch_VL10VsCapacityReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Reports_VL10_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Headcount_mi.Click
        OpenForm(Sch_VL10HeadcountReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Reports_ProductionPlan_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_ProductionPlan_Headcount_mi.Click
        OpenForm(Sch_ProductionPlanHeadcountReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Reports_VL10_Current_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Current_mi.Click
        LoadingScreen.Show()
        Dim srv As New SingleReportViewer
        srv.MdiParent = Me
        srv.DataSource = SQL.Current.GetDatatable("SELECT F.Family,B.Business,V.Material,DeliveryDate,dbo.DDC(F.Family, V.DeliveryDate, Mx.MaxDate) AS ProductionPlanDate,OpenQuantity,'' AS Flag FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_Families AS F ON B.Family = F.Family INNER JOIN (SELECT 'MxD' AS Flag, MAX(DownloadDate) AS MaxDate FROM Sch_VL10) AS Mx ON Mx.Flag = 'MxD' AND V.DownloadDate = Mx.MaxDate AND V.DeliveryDate >= Mx.MaxDate UNION ALL SELECT F.Family,B.Business,V.Material,DeliveryDate,DeliveryDate,OpenQuantity,'PastDue' AS Flag FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_Families AS F ON B.Family = F.Family INNER JOIN (SELECT 'MxD' AS Flag, MAX(DownloadDate) AS MaxDate FROM Sch_VL10) AS Mx ON Mx.Flag = 'MxD' AND V.DownloadDate = Mx.MaxDate AND V.DeliveryDate < Mx.MaxDate ORDER BY F.Family,B.Business,V.Material,DeliveryDate", "VL10")
        srv.Title = "Last VL10 Imported From SAP"
        srv.Show()
        LoadingScreen.Hide()
    End Sub
    Private Sub Main_Scheduling_Reports_ProductionPlan_Waterfall_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_ProductionPlan_Waterfall_mi.Click
        OpenForm(Sch_UploadWaterfallReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "ProductionPlan"
    Private Sub Main_Scheduling_ProductionPlan_Low_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ProductionPlan_Low_mi.Click
        OpenForm(Sch_ProductionPlanDailyLow, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Scheduling_ProductionPlan_High_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ProductionPlan_High_mi.Click
        OpenForm(Sch_ProductionPlanDailyHighVolume, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Functions"

    Private Sub Main_Scheduling_SAP_PrintLabels_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_PrintLabels_mi.Click
        OpenForm(Sch_SchedulingPrintLabels, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Scheduling_SAP_ProductionPlanImport_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ProductionPlanImport_mi.Click
        OpenForm(Sch_UploadDateRangeSelector, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Scheduling_EPS_Import_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_EPS_Import_mi.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            ofd.Title = "Open EPS Production Report..."
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadingScreen.Show()
                Dim txt_file As String = IO.Path.Combine(IO.Path.GetTempPath, String.Format("EPS_{0}.txt", Now.ToString("yyMMddHHmmss")))
                If MyExcel.TransformExcel(ofd.FileName, txt_file, Nothing, Nothing, False) Then
                    Dim dt_eps = CSV.Datatable(txt_file, vbTab, False, False)

                    Dim family As String = ""
                    Dim line As String = ""
                    Dim [date] As String = ""
                    Dim shift As String = ""
                    Dim np As String = ""
                    Dim rev As String = ""
                    Dim quantity As String = ""

                    Dim eps_rep As New DataTable
                    eps_rep.Columns.Add("Family", System.Type.GetType("System.String"))
                    eps_rep.Columns.Add("Line", System.Type.GetType("System.String"))
                    eps_rep.Columns.Add("Date", System.Type.GetType("System.DateTime"))
                    eps_rep.Columns.Add("Shift", System.Type.GetType("System.String"))
                    eps_rep.Columns.Add("Material", System.Type.GetType("System.String"))
                    eps_rep.Columns.Add("Revision", System.Type.GetType("System.String"))
                    eps_rep.Columns.Add("Quantity", System.Type.GetType("System.Int32"))

                    For Each l As DataRow In dt_eps.Rows
                        If l.Item(0) <> "" Then family = l.Item(0)
                        If family <> "Familia" Then
                            If l.Item(1) <> "" Then line = l.Item(1)
                            If l.Item(2) <> "" Then [date] = l.Item(2)
                            If l.Item(3) <> "" Then shift = l.Item(3)
                            If l.Item(5) <> "" Then
                                np = l.Item(5)
                                rev = l.Item(6)
                                quantity = l.Item(9)
                                eps_rep.Rows.Add(family, line, [date], shift, np.Trim, rev, quantity)
                            End If
                        End If
                    Next
                    TryDelete(txt_file)
                    Dim create As String = "CREATE TABLE #tmpEPS ([Family] [varchar](25) NOT NULL,[Line] [varchar](25) NOT NULL,[Date] [date] NOT NULL,[Shift] [char](1) NOT NULL,[Material] [char](8) NOT NULL,[Revision] [varchar](10) NOT NULL,[Quantity] [smallint] NOT NULL)"
                    Dim merge As String = "MERGE Sch_EPSProduction AS target USING #tmpEPS AS source " & _
                        "ON target.Family = source.Family AND target.Line = source.Line AND target.[Date] = source.[Date] AND target.Shift = source.Shift AND target.Material = source.Material " & _
                        "WHEN MATCHED AND target.Quantity < source.Quantity THEN " & _
                        "UPDATE SET target.Quantity = source.Quantity " & _
                        "WHEN NOT MATCHED THEN " & _
                        "INSERT (Family,Line,[Date],Shift,Revision,Material,Quantity) VALUES (source.Family,source.Line,source.[Date],source.Shift,source.Revision,source.Material,source.Quantity);"
                    If SQL.Current.Upsert(eps_rep, "tmpEPS", create, merge) Then
                        LoadingScreen.Hide()
                        MsgBox("Successfully done!", MsgBoxStyle.Information)
                    Else
                        LoadingScreen.Hide()
                        MsgBox("Error on importing.", MsgBoxStyle.Critical)
                    End If
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error on transforming EPS file.", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            MsgBox("Error on reading EPS file.", MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region
#End Region

#Region "Process Engineering"
#Region "Database"
    Private Sub Main_Engineering_Database_BOM_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_BOM_mi.Click
        Dim db_bom As New DatabaseEditor
        db_bom.SetConnectionString(SQL.Current.ConnectionString)
        db_bom.MdiParent = Me
        db_bom.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT * FROM PE_MaterialLeadcodes ORDER BY Material,Leadcode", {"Material", "Leadcode"}, True, True, ""))
        db_bom.Show()
    End Sub
    Private Sub Main_Engineering_Database_Leadcodes_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Leadcodes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode Locations", "SELECT * FROM PE_LeadcodeLocations ORDER BY Leadcode,Rack,Level,Rail", {"Leadcode", "Rack", "Level", "Rail"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode Master", "SELECT * FROM PE_Leadcodes ORDER BY Leadcode", {"Leadcode"}, True, True))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Engineering_Database_Cutters_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Cutters_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Cutters Master", "SELECT * FROM PE_Cutters ORDER BY ID", {"ID"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode-Cutter Relation", "SELECT * FROM PE_LeadcodeCutters ORDER BY Leadcode,CutterID", {"Leadcode", "CutterID"}, True, True))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Engineering_Database_RawMaterial_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_RawMaterial_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("MSpecs Master", "SELECT * FROM PE_MSpecs ORDER BY MSpec", {"MSpec"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Terminals Master", "SELECT * FROM PE_Terminals ORDER BY Terminal,Gage", {"Terminal", "Gage"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Seals Master", "SELECT * FROM PE_Seals ORDER BY Seal", {"Seal"}, True, True))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Engineering_Database_Others_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Others_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Colors", "SELECT * FROM PE_Colors ORDER BY Name", {"TW_ShortName"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Setup Times", "SELECT * FROM PE_Setups ORDER BY Type", {"Type"}, True, True))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Engineering_Reports_Errors_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Reports_Reporter_mi.Click
        OpenForm(ErrorReportViewer, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#End Region

#Region "Administrator"
#Region "Users"

    Private Sub Main_Administrator_Users_Management_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Management_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [Username],[FirstName],[LastName],[Email],[Role],[Area],[Badge],[Password],[IsAdministrator],[OnDomain],[Active],[Language] FROM Sys_Users ORDER BY Firstname,Lastname", {"Username"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Area", {"Customer Service", "Management", "Material Analyst", "Ordering", "Process Engineering", "Program Readiness", "Public", "Quality", "Die Center", "Scheduling", "Shipping", "Systems", "Supermarket", "Receiving", "ComponentDeliveryRoutes"}))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Role", SQL.Current.GetList("SELECT Role FROM Sys_UserRoles ORDER BY Role").ToArray))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Users_NewPassword_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_NewPassword_mi.Click
        Dim password = Alphanumeric.ToAlphanumeric(Now.ToString("ssmmddMMyy"))
        Dim encrypted As String = W3D.EncryptData(password)
        Clipboard.SetText(String.Format("Natural = [{0}],Encrypted = [{1}]", password, encrypted))
        MsgBox("Password copied on clipboard!", MsgBoxStyle.Information, APP)
    End Sub

#End Region
    Private Sub DatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_WorkingDays_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [Date] AS Fecha,[Week] AS Semana,[WorkingShifts] AS Turnos, [WeekStart] AS [Inicio de Semana] FROM Sys_Calendar WHERE Date >= DATEADD(D,-7,GETDATE()) ORDER BY Date", {"Fecha"}, True, True))
        Dim options As DataTable = SQL.Current.GetDatatable("SELECT Combination,[Description] FROM Sys_ShiftCombination")
        options.Rows.Add(DBNull.Value, "Dia Inhabil")
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turnos", options, "Description", "Combination"))
        db_table.tables(0).LimitedColumns(0).AllowNulls = True
        db_table.tables(0).OnlyDateFormatColumns.Add("Fecha")
        db_table.tables(0).OnlyDateFormatColumns.Add("Inicio de Semana")
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub ParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_Parameters_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT * FROM Sys_Parameters ORDER BY [Parameter]", {"Parameter"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Administrator_Database_RawMaterial_Update_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_Update_mi.Click
        Dim sap As New SAP
        If sap.Available Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempTXTPath
            If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(Parameter("SYS_PlantCode"), filename, "F", "*") Then
                Dim txt = CSV.Datatable(filename, vbTab, True, False)
                If txt IsNot Nothing Then
                    txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L'))"
                    txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                    txt.Columns.Add("DBL_RV", GetType(String), "Convert([ROUNDING_VALUE],'System.Double')")
                    txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")
                    txt.Columns.Add("DEC_NET_WEIGHT", GetType(Decimal), "IIF([NET_WEIGHT] = '', 0, Convert([NET_WEIGHT],'System.Decimal')) * IIF(WUM='KG',1000, IIF(WUM='LB', 453.592, 1))")
                    Dim mrps As DataTable = txt.DefaultView.ToTable(True, "MRP_CONTROLLER")
                    SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Ord_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'public');")
                    Dim bulk_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER", "DEC_NET_WEIGHT")
                    If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](150) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[UnitCost] [decimal](12, 7) NOT NULL,[MRP] [varchar](5),[weight] [decimal](10,3))", "MERGE Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Description] = source.[Description],RoundingValue = source.RoundingValue,UnitCost = source.UnitCost,target.MRP = source.MRP, target.UoM = source.UoM, target.IsRaw = 1, target.WeightOnGr = source.[Weight] WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],UoM,RoundingValue,UnitCost,MRP,OrderUnit,IsRaw,WeightOnGr,SupplierPartnumber) VALUES (source.Partnumber,source.[Description],source.UoM,source.RoundingValue,source.UnitCost,source.MRP,source.UoM,1,source.[weight],source.Partnumber);") Then
                        LoadingScreen.Hide()
                        FlashAlerts.ShowConfirm("¡Hecho!")
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error en el bulk de datos.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al leer el archivo.")
                End If
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al descargar la información.")
            End If
        Else
            FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
        End If
    End Sub
    Private Sub Main_Administrator_Users_Permissions_Clone_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Permissions_Clone_mi.Click
        OpenForm(ClonePermissionsFrom, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region

#Region "General"
    'Private Class TaskBarMinimizeButton
    '    Public Sub New(button As ToolStripButton, state As FormWindowState)
    '        Me.Button = button
    '        Me.State = state
    '    End Sub
    '    Public Property Button As ToolStripButton
    '    Public Property State As FormWindowState
    'End Class
    'Private Property TaskBarRegularFormButtons As New Dictionary(Of String, TaskBarMinimizeButton)
    'Private Property TaskBarDeltaReporterButtons As New Dictionary(Of String, TaskBarMinimizeButton)
    Private Sub OpenForm(new_form As Object, key As String, icon As Image, text As String, Optional mdi_parent As Boolean = True)
        GF.ReleaseMemory()
        If TaskBarButtonDictionary.ContainsKey(key) Then
            MinimizeMaximize(key)
        Else
            Dim form As Form = Activator.CreateInstance(new_form.GetType)
            form.Tag = key
            If mdi_parent Then
                form.MdiParent = Me
            End If
            Dim tsm_button As New TaskBarButton(key, form)
            tsm_button.Image = icon
            tsm_button.ImageAlign = ContentAlignment.MiddleLeft
            tsm_button.AutoSize = True
            tsm_button.Padding = New Padding(10, 0, 10, 0)
            tsm_button.Margin = New Padding(3, 0, 3, 0)
            tsm_button.BackColor = Color.LightGray
            tsm_button.Text = text

            AddHandler tsm_button.Click, AddressOf ButtonClick
            AddHandler form.FormClosed, AddressOf TaskBarCloseFormEvent
            AddHandler form.Resize, AddressOf TaskBarResizeFormEvent
            TaskBarButtonDictionary.Add(key, tsm_button)
            Main_tsm.Items.Add(tsm_button)
            form.Show()
        End If
    End Sub

    Private Sub OpenFormByRef(ByRef new_form As Form, key As String, icon As Image, text As String, Optional mdi_parent As Boolean = True)
        If TaskBarButtonDictionary.ContainsKey(key) Then
            new_form.Dispose() 'CANCELAR NUEVO FORM
            new_form = Nothing
            MinimizeMaximize(key) 'ABRIR EL ANTIGUO FORM
        Else
            'CREAR EL NUEVO FORM DENTRO DE LA BARRA DE TAREAS
            new_form.Tag = key
            If mdi_parent Then
                new_form.MdiParent = Me
            End If
            Dim tsm_button As New TaskBarButton(key, new_form)
            tsm_button.Image = icon
            tsm_button.ImageAlign = ContentAlignment.MiddleLeft
            tsm_button.AutoSize = True
            tsm_button.Padding = New Padding(10, 0, 10, 0)
            tsm_button.Margin = New Padding(3, 0, 3, 0)
            tsm_button.BackColor = Color.LightGray
            tsm_button.Text = text

            AddHandler tsm_button.Click, AddressOf ButtonClick
            AddHandler new_form.FormClosed, AddressOf TaskBarCloseFormEvent
            AddHandler new_form.Resize, AddressOf TaskBarResizeFormEvent
            TaskBarButtonDictionary.Add(key, tsm_button)
            Main_tsm.Items.Add(tsm_button)
            new_form.Show()
        End If
    End Sub


    Private Property TaskBarButtonDictionary As New Dictionary(Of String, TaskBarButton)
    Private Class TaskBarButton
        Inherits ToolStripButton
        Public Sub New(key As String, form As Form)
            Me.Key = key
            Me.Form = form
        End Sub
        Public Property Form As Form
        Public Property Key As String
    End Class

    Private Sub OpenDeltaReporter(area As String, icon As Image, text As String, Optional mdi_parent As Boolean = True)
        GF.ReleaseMemory()
        Dim key As String = "DeltaReporter_" & CurrentDate.ToString("yyMMddHHmmss")
        Dim new_form As New DeltaReporter
        new_form.Area = area
        new_form.Tag = key
        If mdi_parent Then
            new_form.MdiParent = Me
        End If
        Dim tsm_button As New TaskBarButton(key, new_form)
        tsm_button.Image = icon
        tsm_button.ImageAlign = ContentAlignment.MiddleLeft
        tsm_button.AutoSize = True
        tsm_button.Padding = New Padding(10, 0, 10, 0)
        tsm_button.Margin = New Padding(3, 0, 3, 0)
        tsm_button.BackColor = Color.LightGray
        tsm_button.Text = text


        AddHandler tsm_button.Click, AddressOf ButtonClick
        AddHandler new_form.FormClosed, AddressOf TaskBarCloseFormEvent
        AddHandler new_form.Resize, AddressOf TaskBarResizeFormEvent
        TaskBarButtonDictionary.Add(key, tsm_button)
        Main_tsm.Items.Add(tsm_button)
        new_form.Show()
    End Sub

    Private Sub ButtonClick(sender As Object, e As EventArgs)
        MinimizeMaximize(CType(sender, TaskBarButton).Key)
    End Sub

    Private Sub TaskBarResizeFormEvent(sender As Object, e As EventArgs)
        If CType(sender, Form).WindowState = FormWindowState.Minimized AndAlso CType(sender, Form).Visible Then
            CType(sender, Form).Hide()
        End If
    End Sub

    Private Sub TaskBarCloseFormEvent(sender As Object, e As FormClosedEventArgs)
        Dim key As String = CType(sender, Form).Tag.ToString
        Main_tsm.Items.Remove(TaskBarButtonDictionary.Item(key))
        TaskBarButtonDictionary.Remove(key)
    End Sub



    Private Sub MinimizeMaximize(key As String)
        If TaskBarButtonDictionary.Item(key).Form.Visible = False OrElse TaskBarButtonDictionary.Item(key).Form.WindowState = FormWindowState.Minimized Then

            TaskBarButtonDictionary.Item(key).Form.WindowState = FormWindowState.Normal
            TaskBarButtonDictionary.Item(key).Form.Location = New Point(20, 20)
            TaskBarButtonDictionary.Item(key).Form.Show()
        ElseIf TaskBarButtonDictionary.Item(key).Form IsNot Me.ActiveMdiChild Then
            TaskBarButtonDictionary.Item(key).Form.Activate()
        ElseIf TaskBarButtonDictionary.Item(key).Form.WindowState = FormWindowState.Maximized OrElse TaskBarButtonDictionary.Item(key).Form.WindowState = FormWindowState.Normal Then
            TaskBarButtonDictionary.Item(key).Form.Hide()
            TaskBarButtonDictionary.Item(key).Form.WindowState = FormWindowState.Minimized
        End If
    End Sub

    'Private Sub Maximize(key As String)
    '    TaskBarButtonDictionary.Item(key).Form.Show()
    '    TaskBarButtonDictionary.Item(key).Form.BringToFront()
    'End Sub

    Private Sub Main_About_mi_Click(sender As Object, e As EventArgs) Handles Main_About_mi.Click
        AboutBox.ShowDialog()
    End Sub
#End Region

#Region "Leadprep"
    Private Sub Main_Leadprep_Miscellaneous_Labels_mi_Click(sender As Object, e As EventArgs) Handles Main_Leadprep_Miscellaneous_Labels_mi.Click
        OpenForm(BagLabelPrinter, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region

#Region "Ordering"
#Region "Mover"
    Private Sub Main_Ordering_Supermarket_Mover_New_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_New_mi.Click
        OpenForm(Ord_NewMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Cancel_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Cancel_mi.Click
        OpenForm(Ord_CancelMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Print_mi.Click
        OpenForm(Ord_PrintMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Approve_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Approve_mi.Click
        OpenForm(Ord_ApproveMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

#End Region
#Region "Reports"
    Private Sub Main_Ordering_Reports_ABCAnalysis_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_ABCAnalysis_mi.Click
        OpenForm(Ord_ABC, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Ordering_Reports_Forecast_StockVsForecast_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_ForecastVsRealConsumption_mi.Click
        OpenForm(Ord_ForecastVsZapimatinfo, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Ordering_Reports_Forecast_Waterfall_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_Waterfall_mi.Click
        OpenForm(Ord_ForecastWaterfall, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Ordering_Reports_MB51_261vsZ11_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_MB51_261vsZ11_mi.Click
        OpenForm(MB51_261VsZ11, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Database"
    Private Sub Main_Ordering_Database_MRPControllers_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Management_MRPControllers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MRP,Username AS Usuario FROM Ord_MRPControllers ORDER BY Username", {"MRP"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Usuario", SQL.Current.GetDatatable("SELECT Username,FullName FROM Sys_Users WHERE Area IN ('Ordering','Component Readiness') AND Role IN ('MRPController','ORD Supervisor','CR Supervisor') AND ([Active] = 1 OR Username IN (SELECT Username FROM Ord_MRPControllers)) UNION ALL SELECT 'deltaerp','DeltaERP' ORDER BY FullName"), "FullName", "Username"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
    Private Sub Main_Ordering_Receiving_ReportCritical_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Receiving_ReportCritical_mi.Click
        OpenForm(Ord_ReportCriticalToReceiving, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region

#Region "MaterialAnalyst"
    Private Sub Main_MaterialAnalyst_SAP_MB51_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_SAP_MB51_mi.Click
        OpenForm(DownloadMB51, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_MaterialAnalyst_Reports_MB51_261vsZ11_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_MB51_261vsZ11_mi.Click
        OpenForm(MB51_261VsZ11, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region

#Region "Supermarket"
#Region "Components"
    Private Sub Main_Supermarket_Components_Store_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Store_mi.Click
        OpenForm(Smk_StoreSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_Open_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Open_mi.Click
        OpenForm(Smk_OpenSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_Find_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Find_mi.Click
        OpenForm(Smk_FindSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_LocationChange_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_LocationChange_mi.Click
        OpenForm(Smk_ChangeLocation, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_PartialDiscount_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_PartialDiscount_mi.Click
        OpenForm(Smk_PartialDiscount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_DeclareEmpty_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_DeclareEmpty_mi.Click
        OpenForm(Smk_DeclareEmpty, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Management_PostTransfers_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_PostTransfers_mi.Click
        OpenForm(Smk_SAPTransfers, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_ManualAdjustment_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_ManualAdjustment_mi.Click
        OpenForm(Smk_ManualAdjustment, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Components_ReactiveSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_ReactiveSerial_mi.Click
        OpenForm(Smk_ReactiveSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Supermarket_Components_Reports_Audit_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_Audit_mi.Click
        OpenForm(Smk_SimpleAudit, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_Reports_SAPVsDelta_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_SAPVsDelta_mi.Click
        OpenForm(Smk_SAPVsDelta, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Supermarket_Components_Reports_MaterialExpired_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_MaterialExpired_mi.Click
        OpenForm(Smk_TimeSusceptibleMaterial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

#End Region
#Region "Mover"
    Private Sub Main_Supermarket_Mover_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Mover_Print_mi.Click
        OpenForm(Smk_PrintMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Database"
    Private Sub Main_Supermarket_Database_MaterialMaster_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_MaterialMaster_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],[Description] AS [Descripcion],UoM AS [Unidad Base],RoundingValue AS [Std.Pack],UnitCost AS [Costo Unitario],MRP,Container AS Contenedor,MaterialType AS Tipo,ConsumptionType AS [Consumo],Expirable,LabelLegend AS [Leyenda Etiquetado],SupplierPartnumber AS [NP Proveedor],OrderUnit AS [Unidad de Recibo],WeightOnGr AS [Peso Unitario],UnitWeightValidated AS [Peso Validado],IsSensitive AS Sensitivo,MasterLabel AS [Generar Etiqueta Madre],ChildLabelQuantity AS [Cantidad en Etiqueta Hija],RewindToDic AS [Rebobinar para CDD] FROM Sys_RawMaterial WHERE MaterialType <> 'Harness' AND NOT IsRaw = 0", {"No. de Parte"}, False, False, "", True, {"Partnumber", "Description", "UoM", "RoundingValue", "UnitCost", "MRP"}))

        db_table.tables(0).AllowUserToDeleteRows = False
        db_table.tables(0).AllowUserToAddRows = False
        db_table.tables(0).AllowUserToUpdateRows = True
        Dim types As New DataTable
        types.Columns.Add("EN")
        types.Columns.Add("ES")
        types.Rows.Add("Component", "Componente")
        types.Rows.Add("Cable", "Cable")
        types.Rows.Add("Calibre", "Calibre")
        types.Rows.Add("Tube", "Manga")
        types.Rows.Add("Terminal", "Terminal")
        types.Rows.Add("TerminalAssembly", "Terminal de Ensamble")
        types.Rows.Add("Conduit", "Poliducto")
        types.Rows.Add("Tape", "Cinta")
        types.Rows.Add("Chemical", "Quimico")
        types.Rows.Add("Seal", "Sello")
        types.Rows.Add("Label", "Etiqueta")
        types.Rows.Add("Thread", "Hilo")
        types.Rows.Add("Tie", "Corbata")
        types.Rows.Add("Pigtail", "Pigtail")
        types.Rows.Add("Solder", "Soldadura")


        Dim consumption As New DataTable
        consumption.Columns.Add("Type")
        consumption.Columns.Add("EN")
        consumption.Columns.Add("ES")
        consumption.Rows.Add("Total", "Empty", "Directo a Vacio")
        consumption.Rows.Add("Partial", "Partial Discount", "Bajas Parciales")
        consumption.Rows.Add("Mixed", "Mixed", "Directo sin Declarar Vacio")
        consumption.Rows.Add("Service", "Service", "Servicio")
        consumption.Rows.Add("Obsolete", "Obsolete", "Obsoleto")
        consumption.Rows.Add("CAO", "CAO", "CAO")

        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Tipo", types, User.Current.Language, "EN"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Consumo", consumption, User.Current.Language, "Type"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Unidad de Recibo", {"PC", "M", "FT", "KG", "LB", "L"}))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Database_Map_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Map_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],Warehouse AS Estacion,Location AS Local,Minimum AS Minimo,Maximum AS Maximo FROM Smk_Map", {"No. de Parte", "Estacion"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT [Name],Warehouse FROM Smk_Warehouses"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Database_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Operators_mi.Click
        OpenForm(Smk_Operators, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

#End Region



#End Region

#Region "MyAccount"
    Private Sub Main_MyAccount_Profile_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Profile_mi.Click
        OpenForm(Profile, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

#End Region

#Region "ComponentDeliveryRoutes"
    Private Sub Main_ComponentDeliveryRoutes_Checkpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Checkpoint_mi.Click
        If User.Current.IsAdmin OrElse SQL.Current.Exists("CDR_AuthorizedCheckpoints", {"MachineName"}, {Environment.MachineName}) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "CDR_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
            OpenForm(CDR_Checkpoint, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text, False)
        Else
            FlashAlerts.ShowError("Checkpoint no autorizado.")
        End If
    End Sub
#Region "Database"
    Private Sub Main_ComponentDeliveryRoutes_Management_Routes_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Routes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [Route] AS ID,[Description] AS Nombre,[Shift] AS Turno,[Warehouse] AS Estacion,[Operator] AS [Operador],[ContainersLoopGoal] AS [Objetivo Vueltas Diarias],[ContainersDailyGoal] AS [Objetivo Contenedores Diarios],[Loops] AS Vueltas,[PrimaryWalkings] AS [Caminares Primarios],[SecondaryWalkings] AS [Caminares Secundarios],[ExtraPaid] AS [Pago Extra] FROM CDR_Routes", {"ID"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetList("SELECT Shift FROM Sys_Shifts ORDER BY Shift").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Operador", SQL.Current.GetDatatable("SELECT Badge, FullName FROM Smk_Operators WHERE Area = 'CDR' OR Badge IN (SELECT Operator FROM CDR_Routes) ORDER BY FullName"), "FullName", "Badge"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Containerization_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Containerization_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [Partnumber] AS [No. de Parte],[Cnt_1_4],[Cnt_1_2],[Cnt_16s],[Cnt_8s],[Cnt_4s],[Cnt_2s],[Cnt_jt],[Cnt_Stdpack],[Comment] AS Comentario FROM CDR_Containerization", {"No. de Parte"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Engineering_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Engineering_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Board AS Tablero,Kit,Partnumber AS [No. de Parte],Quantity AS Cantidad,Loc AS [Localizacion],Slot,Side AS Lado,Section AS Seccion,Comment AS Comentario FROM CDR_Engineering", {"Tablero", "Kit", "No. de Parte"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_ProductionControl_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_ProductionControl_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Business AS Negocio,Board AS Tablero,Material,Requirement AS Requerimiento FROM CDR_ProductionControl", {"Tablero", "Material"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Business_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Business_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Business AS Negocio,Warehouse AS Estacion FROM CDR_Business", {"Negocio"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Kanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Kanbans_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [ID],[Partnumber] AS [No. de Parte],[Board] AS Tablero,[Description] AS Descripcion,[Kit],[EngLoc] AS [Local],[Slot],[Side] AS Lado,[Section] AS Seccion,[Route] AS Ruta,[Pieces] AS Piezas,[Container] AS Contenedor,[Index] AS Indice,[Business] AS Negocio,[Requirement] AS Requerimiento,[2h],[Quantity] AS Cantidad,[Frequency] AS Frecuencia,[Hrs],[Comment] AS Comentario,[Rack],[Local],[Date] AS Fecha,[Code] AS Codigo,[Generic] AS Generica,[Active] AS Activa FROM CDR_Kanbans", {"ID"}, True, True, "ID", True, {"Code"}))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Management"
    Private Sub Main_ComponenteDeliveryRoutes_Management_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Operators_mi.Click
        OpenForm(CDR_Operators, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Kanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Kanbans_mi.Click
        OpenForm(CDR_Kanbans, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Print_mi.Click
        OpenForm(CDR_KanbanPrint, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Workload_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Workload_mi.Click
        OpenForm(CDR_Workload, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Reportes"
    Private Sub Main_ComponentDeliveryRoutes_Management_EngineeringVsZCS12_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_EngineeringVsZCS12_mi.Click
        OpenForm(CDR_EngineeringVsZCS12, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#End Region

#Region "CustomerService"
    Private Sub Main_CustomerService_Tools_SAP_VA32_mi_Click(sender As Object, e As EventArgs) Handles Main_CustomerService_Tools_SAP_VA32_mi.Click
        OpenForm(VA32_DeliveryCorrection, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region

#Region "Receiving"
#Region "Labels"
    Private Sub Main_Receiving_Labeling_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labeling_mi.Click
        OpenForm(Rec_Labeling, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Receiving_Labels_New_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_New_mi.Click
        OpenForm(Rec_NewSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Receiving_Labels_Reprint_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_Reprint_mi.Click
        OpenForm(Rec_ReprintLabel, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Receiving_Labels_Delete_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_Delete_mi.Click
        OpenForm(Rec_DeleteLabel, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Receiving_Reports_ScanningVsMB51_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_ScanningVsMB51_mi.Click
        OpenForm(Rec_SMSVsMB51, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
    Private Sub Main_Scheduling_Reports_VL10_Waterfall_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Waterfall_mi.Click
        OpenForm(Sch_VL10WaterfallReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#Region "Management"
    Private Sub Main_Receiving_Management_Alerts_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Alerts_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],Message AS Mensaje FROM Rec_ScannerAlert", {"No. de Parte"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_LabelFlags_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_LabelFlags_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],Description AS Descripcion,LabelLegend AS Leyenda FROM Sys_RawMaterial", {"No. de Parte"}, False, False, "", True, {"Partnumber", "Description"}))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_Scanners_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Scanners_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT DeviceID AS ID, Warehouse AS Estacion FROM Smk_ScannerRegister", {"ID"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
#End Region
#End Region

    'Private Sub Main_MyAccount_Language_Spanish_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Language_Spanish_mi.Click
    '    User.Current.Language = "ES"
    '    Main_MyAccount_Language_English_mi.Checked = False
    '    Main_MyAccount_Language_Spanish_mi.Checked = True
    'End Sub

    'Private Sub Main_MyAccount_Language_English_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Language_English_mi.Click
    '    User.Current.Language = "EN"
    '    Main_MyAccount_Language_English_mi.Checked = True
    '    Main_MyAccount_Language_Spanish_mi.Checked = False
    'End Sub

    Private Sub Main_Receiving_Management_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Operators_mi.Click
        OpenForm(REC_Operators, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Quality_Alerts_Add_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_New_mi.Click
        OpenForm(QLY_NewAlert, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Quality_Alerts_Remove_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_Remove_mi.Click
        OpenForm(QLY_RemoveAlert, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Quality_Alerts_UnlockSerialnumber_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_UnlockSerialnumber_mi.Click
        OpenForm(QLY_RemoveSerialAlert, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub


    Private Sub Main_DieCenter_PicklistCheckpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PicklistCheckpoint_mi.Click
        If SQL.Current.Exists("Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
            Dim die_centers As Integer = SQL.Current.GetScalar("COUNT(DieCenter)", "DiC_Centers", "Warehouse", My.Settings.Warehouse)
            If die_centers = 0 Then
                FlashAlerts.ShowError(Language.Sentence(84))
            Else
                Dim selector As New Dic_Selector
                If Not SQL.Current.GetScalar("FullScreen", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, 1) Then
                    selector.MdiParent = Me
                    selector.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Else
                    selector.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                End If
                selector.Show()
            End If
        Else
            FlashAlerts.ShowError(Language.Sentence(85))
        End If
    End Sub

    Private Sub Main_DieCenter_PrintPicklist_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PrintPicklist_mi.Click
        OpenForm(DiC_PrintPicklist, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_DieCenter_Management_Locations_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Locations_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],DieCenter AS [Centro de Dados],Location AS Localizacion FROM DiC_Map", {"No. de Parte", "Centro de Dados", "Localizacion"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Centro de Dados", SQL.Current.GetDatatable("SELECT DieCenter FROM DiC_Centers ORDER BY DieCenter"), "DieCenter", "DieCenter"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_DieCenter_Management_Centers_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Centers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT DieCenter AS [Centro de Dados],Warehouse AS Estacion FROM DiC_Centers", {"Centro de Dados", "Estacion"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub


    Private Sub Main_Ordering_Management_ImportForecast_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Management_ImportForecast_mi.Click
        OpenForm(Ord_ImportForecast, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MachineName AS [PC],Warehouse AS Estacion FROM CDR_AuthorizedCheckpoints", {"PC"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_DieCenter_Management_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MachineName AS [PC], Warehouse AS Estacion,FullScreen AS [Pantalla Completa] FROM DiC_AuthorizedCheckpoints", {"PC"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Alerts_timer_Tick(sender As Object, e As EventArgs) Handles Alerts_timer.Tick
        RefreshAlertsButton()
    End Sub

    Private Sub RefreshAlertsButton()
        If SQL.Current.Available Then
            Dim alerts As Integer = SQL.Current.GetScalar("COUNT(ID)", "Sys_UserAlerts", {"[To]", "Active"}, {User.Current.Username, 1})
            If alerts > 0 Then
                Alerts_nicon.Visible = True
                Alerts_btn.BackColor = Color.Gold
                Alerts_btn.Text = String.Format(Language.Sentence(81), alerts)
                Alerts_btn.Visible = True
                Alerts_nicon.ShowBalloonTip(10, Language.Sentence(82), String.Format(Language.Sentence(81), alerts), ToolTipIcon.Info)
            Else
                Alerts_btn.Visible = False
                Alerts_btn.BackColor = Control.DefaultBackColor
                Alerts_btn.Text = Language.Sentence(83)
            End If
            'REVISAR SI NO SE HA HECHO EL BKF DE SERIES DE PT EN LA ULTIMA HORA
            If User.Current.HasPermission("Main_FinishGoodRoutes_Management_Backflush_mi") Then
                Dim serials_counter As Integer = SQL.Current.GetScalar("SELECT COUNT(Serialnumber) FROM FGR_SerialMovements WHERE Posted = 0 AND Active = 1 AND DATEDIFF(MINUTE,[Date],GETDATE()) >= 50")
                If serials_counter > 0 Then
                    Alerts_nicon.ShowBalloonTip(15, "BKF Pendiente", String.Format("Existen {0} series pendientes de hacer backflush.", serials_counter), ToolTipIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub Alerts_nicon_BalloonTipClicked(sender As Object, e As EventArgs) Handles Alerts_nicon.BalloonTipClicked
        ShowAlerts()
        Alerts_nicon.Visible = False
    End Sub

    Private Sub ShowAlerts()
        Dim form As AlertsReport = Nothing
        For Each f As Form In Application.OpenForms
            If f.GetType() Is AlertsReport.GetType() Then
                form = f
                Exit For
            End If
        Next
        If IsNothing(form) Then
            form = New AlertsReport
            form.MdiParent = Me
            form.Show()
        Else
            form.RefreshAlerts()
            If form.WindowState = FormWindowState.Minimized Then form.WindowState = FormWindowState.Normal
            form.BringToFront()
            If form.CanFocus() Then form.Focus()
        End If
    End Sub

    Private Sub Main_Supermarket_Mover_PickUp_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Mover_PickUp_mi.Click
        OpenForm(Smk_PickUpMoverManual, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub


    Private Sub Main_Ordering_Reports_Forecast_ForecastVsRealConsumptionAccumulated_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_ForecastVsRealConsumptionAccumulated_mi.Click
        OpenForm(Ord_ConsumptionHistory, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Supermarket_MinMaxAlerts_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_MinMaxAlerts_mi.Click
        OpenForm(Ord_MixMaxAlerts, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_RackOwners_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_RackOwners_mi.Click
        OpenForm(Smk_RackOwners, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Alerts_nicon_Click(sender As Object, e As EventArgs) Handles Alerts_nicon.Click
        ShowAlerts()
        Alerts_nicon.Visible = False
    End Sub

    Private Sub Main_Receiving_Reports_ScanningVsStored_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_ScanningVsStored_mi.Click
        OpenForm(Rec_LabeledVsPaid, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MyAccount_Password_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Password_mi.Click

    End Sub

    Private Sub Main_Administrator_Users_Crypt_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Crypt_mi.Click
        Dim nb As New EnterBox
        nb.Title = "Encriptar:"
        nb.ShowDialog()
        Clipboard.SetText(W3D.EncryptData(nb.Answer))
        FlashAlerts.ShowConfirm("Copiado a clipboard.")
        nb.Dispose()
    End Sub

    Private Sub Main_Supermarket_Reports_MovementHistory_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_MovementHistory_mi.Click
        OpenForm(Smk_MovementHistory, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_FixAuditory_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_FixAuditory_mi.Click
        OpenForm(Smk_Audit, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Quality_Reports_LockedSerialnumbers_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Reports_LockedSerialnumbers_mi.Click
        LoadingScreen.Show()
        Dim srv As New SingleReportViewer
        srv.MdiParent = Me
        srv.Title = "Series Bloqueadas"
        srv.DataSource = SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],SerialNumber AS Serie,CurrentQuantity AS Cantidad,UoM AS Unidad,Location AS [Local],StatusDescription AS Estatus,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE Status NOT IN ('D','E') AND RedTag = 1 ORDER BY Partnumber,Warehouse,Location")
        srv.Show()
        LoadingScreen.Hide()
    End Sub

    Private Sub Main_Receiving_Reports_SerialsOnTracker_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_SerialsOnTracker_mi.Click
        LoadingScreen.Show()
        Dim srv As New SingleReportViewer
        srv.MdiParent = Me
        srv.Title = "Series en Tracker"
        srv.DataSource = SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],SerialNumber AS Serie,OriginalQuantity AS StdPack, CurrentQuantity AS [Cantidad Actual],OriginalQuantity - CurrentQuantity AS [Cantidad Entregada], UoM AS Unidad,TruckNumber AS [No. de Troca],[Date] AS [Fecha Etiquetado],Location AS [Local],StatusDescription AS Estatus, WarehouseName AS Estacion FROM vw_Smk_Serials WHERE Status NOT IN ('D','E') AND InvoiceTrouble = 1 ORDER BY Partnumber,[Date]")
        srv.Show()
        LoadingScreen.Hide()
    End Sub

    Private Sub Main_Quality_Reports_History_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Reports_History_mi.Click
        OpenForm(Qly_AlertsHistory, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_ToQuality_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_ToQuality_mi.Click
        OpenForm(Rec_ToQuality, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_ToTracker_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_ToTracker_mi.Click
        OpenForm(Rec_ToTracker, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Ordering_ReportMissing_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Ordering_ReportMissing_mi.Click
        OpenForm(Smk_AlertMissing, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Quality_Alerts_RejectSerialnumber_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_RejectSerialnumber_mi.Click
        OpenForm(QLY_RejectSerialnumber, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_FixSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_FixSerial_mi.Click
        OpenForm(Smk_FixSerialnumber, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_TrackerPartialDiscount_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_PartialDiscount_mi.Click
        OpenForm(Rec_TrackerPartialDiscount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_ChooseWarehouse_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_ChooseWarehouse_mi.Click
        OpenForm(Smk_ChooseWarehouse, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Alerts_btn2_Click(sender As Object, e As EventArgs) Handles Alerts_btn.Click
        ShowAlerts()
        Alerts_btn.Visible = False
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_GenericKanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_GenericKanbans_mi.Click
        'Dim db_table As New DatabaseEditor
        'db_table.SetConnectionString(SQL.Current.ConnectionString)
        'db_table.MdiParent = Me
        'db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID,Partnumber AS [No. de Parte],Board AS Tablero,Description AS Descripcion,Kit,Business AS Negocio,Comment AS Comentario,Rack,Local AS [Localizacion] FROM CDR_Kanbans WHERE ID > 505420 AND [engLoc]  IS NULL AND slot IS NULL", {""}, True, True, "ID"))
        'db_table.tables(0).InvisibleColumns = New ArrayList({"ID"})
        'OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
        OpenForm(CDR_GenericKanbans, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Mover_Ship_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Mover_Ship_mi.Click
        OpenForm(Shi_ShipMover, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_DieCenter_PicklistManual_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PicklistManual_mi.Click
        OpenForm(DiC_AskManual, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_RawMaterial_UpdateList_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_UpdateList_mi.Click
        Try
            Dim ld As New ListDialog
            ld.Title = "Nos. de Parte"
            ld.AcceptDuplicates = False
            If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If ld.Items.Count > 0 Then
                    Dim sap As New SAP
                    If sap.Available Then
                        Dim filename As String = GF.TempTXTPath
                        Dim plants As New ArrayList
                        Dim eb As New EnterBox
                        eb.Title = "Plantas"
                        eb.Question = "Buscar numero de parte en las siguientes plantas:"
                        eb.Answer = Parameter("SYS_PlantCode")
                        eb.ShowDialog()
                        plants.AddRange(eb.Answer.Split(vbCrLf))
                        eb.Dispose()
                        LoadingScreen.Show()
                        If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(plants, ld.Items, filename) Then
                            Dim txt = CSV.Datatable(filename, vbTab, True, False)
                            If txt IsNot Nothing Then
                                'txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L' AND (PROC_TYPE = 'F' OR (PROC_TYPE = 'E' AND [DESCRIPTION] LIKE '%TERM%'))))"
                                txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                                txt.Columns.Add("DBL_RV", GetType(Double), "Convert([ROUNDING_VALUE],'System.Double')")
                                txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")

                                Dim all_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER", "PROC_TYPE")
                                Dim bulk_data As New DataTable
                                bulk_data.Columns.Add("RT_MATERIAL")
                                bulk_data.Columns.Add("DESCRIPTION")
                                bulk_data.Columns.Add("BUM")
                                bulk_data.Columns.Add("DBL_RV", GetType(Double))
                                bulk_data.Columns.Add("UNIT_PRICE", GetType(Decimal))
                                bulk_data.Columns.Add("MRP_CONTROLLER")
                                bulk_data.Columns.Add("ISRAW", GetType(Boolean))

                                bulk_data.Merge(all_data.DefaultView.ToTable(True, "RT_MATERIAL"))
                                For Each row As DataRow In bulk_data.Rows
                                    Dim rows = all_data.Select(String.Format("RT_MATERIAL = '{0}'", row.Item("RT_MATERIAL")))
                                    row.Item("DESCRIPTION") = rows(0).Item("DESCRIPTION")
                                    row.Item("BUM") = rows(0).Item("BUM")
                                    row.Item("DBL_RV") = rows(0).Item("DBL_RV")
                                    row.Item("UNIT_PRICE") = rows(0).Item("UNIT_PRICE")
                                    row.Item("MRP_CONTROLLER") = rows(0).Item("MRP_CONTROLLER")
                                    row.Item("ISRAW") = IIf(rows(0).Item("PROC_TYPE") = "F", True, False)
                                Next

                                Dim mrps As DataTable = bulk_data.DefaultView.ToTable(True, "MRP_CONTROLLER")
                                SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Ord_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")

                                If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](150) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[UnitCost] [decimal](10, 7) NOT NULL,[MRP] [varchar](5), IsRaw [bit] NOT NULL)", "MERGE Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Description] = source.[Description],RoundingValue = source.RoundingValue,UnitCost = source.UnitCost,target.MRP = source.MRP, target.UoM = source.UoM, target.IsRaw = source.IsRaw WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],UoM,RoundingValue,UnitCost,MRP,OrderUnit,IsRaw,SupplierPartnumber) VALUES (source.Partnumber,source.[Description],source.UoM,source.RoundingValue,source.UnitCost,source.MRP,source.UoM,source.IsRaw,source.Partnumber);") Then
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowConfirm("¡Hecho!")
                                Else
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowError("Error en el bulk de datos.")
                                End If
                            Else
                                LoadingScreen.Hide()
                                FlashAlerts.ShowError("Error al leer el archivo.")
                            End If
                            TryDelete(filename)
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al descargar la información.")
                        End If
                    Else
                        FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
                    End If
                End If
            End If
            ld.Dispose()
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Receiving_TrackerToService_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_ToService_mi.Click
        OpenForm(Rec_TrackerToService, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Kiosk_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Kiosk_mi.Click
        If User.Current.IsAdmin OrElse SQL.Current.Exists("Smk_AuthorizedCheckpoints", {"MachineName", "Kiosk"}, {Environment.MachineName, 1}) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "Smk_AuthorizedCheckpoints", {"MachineName", "Kiosk"}, {Environment.MachineName, 1}, My.Settings.Warehouse)
            OpenForm(Smk_Kiosk, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
        Else
            FlashAlerts.ShowError("Checkpoint no autorizado.")
        End If
    End Sub

    Private Sub Main_MaterialAnalyst_Reports_InVsOut_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_InVsOut_mi.Click
        OpenForm(MAn_ConsumptionHistory, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Reports_ForecastVs261Cost_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Reports_ForecastVs261Cost_mi.Click
        OpenForm(CR_ForecastVs261, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Reports_Reporter_mi.Click
        OpenDeltaReporter("CR", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-CR")
    End Sub

    Private Sub Main_Supermarket_Management_NewSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_NewSerial_mi.Click
        OpenForm(Smk_NewSerial, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_Reporter_mi.Click
        OpenDeltaReporter("SMK", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-SMK")
    End Sub

    Private Sub Main_Ordering_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Reporter_mi.Click
        OpenDeltaReporter("ORD", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-ORD")
    End Sub

    Private Sub Main_Receiving_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_Reporter_mi.Click
        OpenDeltaReporter("REC", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-REC")
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_Reporter_mi.Click
        OpenDeltaReporter("CDR", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-CDR")
    End Sub

    Private Sub Main_Administrator_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Reports_Reporter_mi.Click
        OpenDeltaReporter("ADM", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-ADM")
    End Sub

    Private Sub Main_Administrator_Users_Permissions_Management_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Permissions_Management_mi.Click
        OpenForm(UserRights, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Reports_Reporter_mi.Click
        OpenDeltaReporter("SHI", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-SHI")
    End Sub

    Private Sub Main_ComponentReadiness_ComponentPlan_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_ComponentPlan_mi.Click
        OpenForm(CR_ComponentPlan, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Management_UpdateBOM_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Management_UpdateBOM_mi.Click
        CR.GetMaterialListBOM()
    End Sub

    Private Sub Main_FinishGoodRoutes_Checkpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Checkpoint_mi.Click
        If SQL.Current.Exists("FGR_AuthorizedCheckpoints", "MachineName", Environment.MachineName) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "FGR_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
            Dim checkpoint As New FGR_Checkpoint
            If Not SQL.Current.GetScalar("FullScreen", "FGR_AuthorizedCheckpoints", "MachineName", Environment.MachineName, 1) Then
                checkpoint.MdiParent = Me
                checkpoint.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Else
                checkpoint.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            End If
            checkpoint.Show()
        Else
            FlashAlerts.ShowError(Language.Sentence(85))
        End If
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MachineName AS PC, Warehouse AS Estacion, FullScreen AS [Pantalla Completa] FROM FGR_AuthorizedCheckpoints", {"PC"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Operators_mi.Click
        OpenForm(FGR_Operators, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Routes_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Routes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Route AS ID, Description AS Nombre, Shift AS Turno, Warehouse AS Estacion, Active AS Activa FROM FGR_Routes", {"ID"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetList("SELECT Shift FROM Sys_Shifts ORDER BY Shift").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Reports_Reporter_mi.Click
        OpenDeltaReporter("FGR", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-FGR")
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Backflush_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Backflush_mi.Click
        OpenForm(FGR_Backflush, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_RawMaterial_ConversionFactors_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_ConversionFactors_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25SYSTQV000696_AS_UNITOFMEAS(Parameter("SYS_PlantCode"), filename) Then
                    Dim txt = CSV.Datatable(filename, vbTab, True, True, 2)
                    If txt IsNot Nothing Then
                        txt.DefaultView.RowFilter = "LEN(Material) <= 8 AND AUn <> BUn AND NOT (AUn = 'G' AND BUn = 'KG') AND NOT (AUn = 'KG' AND BUn = 'G') AND NOT (AUn = 'MM' AND BUn = 'M') AND NOT (AUn = 'M' AND BUn = 'MM') AND NOT (AUn = 'FT' AND BUn = 'M') AND NOT (AUn = 'M' AND BUn = 'FT') AND NOT (AUn = 'ML' AND BUn = 'L') AND NOT (AUn = 'LB' AND BUn = 'KG') AND NOT (AUn = 'KG' AND BUn = 'LB')"
                        txt.Columns.Add("DENOMINADOR", GetType(Decimal), "CONVERT([Denom.],'System.Decimal')")
                        txt.Columns.Add("NUMERADOR", GetType(Decimal), "CONVERT([Numer.],'System.Decimal')")
                        txt.Columns.Add("FACTOR", GetType(Decimal), "NUMERADOR/DENOMINADOR")
                        Dim bulk_data = txt.DefaultView.ToTable(True, "Material", "AUn", "FACTOR", "BUn")

                        'VALIDAR FACTORES. HAY VALORES YA CONOCIDO QUE EN SAP ESTAN REDONDEADOS Y AL FINAL LOS DESCUENTOS NO SON EXACTOS
                        For Each row As DataRow In bulk_data.Rows
                            If (row.Item("BUn") = "ROL" OrElse row.Item("BUn") = "PC") AndAlso row.Item("AUn") = "M" AndAlso row.Item("FACTOR") = 30.5 Then
                                row.Item("FACTOR") = 30.48
                            Else

                            End If
                        Next

                        If SQL.Current.Upsert(bulk_data, "uoms", "CREATE TABLE #uoms ([Partnumber] [char](8) NOT NULL,[BuM] [varchar](3) NOT NULL,[Quantity] [decimal](17, 9) NOT NULL,[AuM] [varchar](3) NOT NULL)", "MERGE Sys_ConversionUnits AS target USING #uoms AS source ON target.Partnumber = source.Partnumber AND target.BuM = source.BuM AND target.AuM = source.AuM WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Partnumber,BuM,Quantity,AuM) VALUES (source.Partnumber,source.BuM,source.Quantity,source.AuM);") Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Actualizado correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al actualizar.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                    TryDelete(filename)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al obtener la información.")
                End If
            Else
                FlashAlerts.ShowError(Language.Sentence(267))
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Administrator_Database_RawMaterial_SupplierDocuments_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_SupplierDocuments_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_SRC_SUP(Parameter("SYS_PlantCode"), filename, "*", "F", "X", "2") Then
                    Dim txt = CSV.Datatable(filename, vbTab, True, True, 2)
                    If txt IsNot Nothing Then
                        txt.DefaultView.RowFilter = String.Format("#{0} 00:00:00# >= Convert([SRC VALID FROM],'System.DateTime') AND #{0} 23:59:59# <= CONVERT([SRC VALID TO],'System.DateTime')", Now.ToShortDateString)
                        Dim bulk_data = txt.DefaultView.ToTable(True, "MATERIAL", "DESCRIPTION", "BUM", "ROUNDING VALUE", "MRP CONTROLLER", "VENDOR NUM", "VENDORNUM NAME", "GRT", "PLAN_TIME_FENCE", "PLANNING_CALENDAR", "MIN_LOT_SIZE", "CPROF", "DOCUMENT", "DOCUMENT ITEM", "OUN")
                        ' Dim bulk_suppliers = bulk_data.DefaultView.ToTable(True, "VENDOR NUM", "VENDOR NAME", "GRT")
                        If SQL.Current.Upsert(bulk_data, "srclist", "CREATE TABLE #srclist ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](50) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[MRP] [varchar](5) NOT NULL,[SupplierNumber] [varchar](12) NULL,[SupplierName] [varchar](50) NULL,[GRT] [smallint] NULL,[PTF] [varchar](5) NULL,[PC] [varchar](5) NULL,[MOQ] [decimal](10, 3) NULL,[CP] [varchar](4) NULL,[Document] [char](9) NULL,[DocumentItem] [char](5) NULL,[OUn] [varchar](3))", _
                                              "MERGE Sys_RawMaterial AS target USING #srclist AS source ON target.Partnumber = RIGHT('000000' + source.Partnumber,8) WHEN MATCHED THEN UPDATE SET [Description] = source.[Description], [UoM] = source.UoM, [RoundingValue] = source.RoundingValue, [MRP] = source.MRP, [SupplierNumber] = source.SupplierNumber, [SupplierName] = source.SupplierName, [GRT] = source.GRT, [PTF] = source.PTF, [PC] = source.PC, [MOQ] = source.MOQ, [CP] = source.CP, [Fixed] = 1, [MRP2] = 1, [Document] = source.[Document], [DocumentItem] = source.DocumentItem WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],[UoM],[RoundingValue],[MRP],[SupplierNumber],[SupplierName],[GRT],[PTF],[PC],[MOQ],[CP],[Fixed],[MRP2],[Document],[DocumentItem],OrderUnit) VALUES (RIGHT('000000' + source.Partnumber,8),source.[Description],source.[UoM],source.[RoundingValue],source.[MRP],source.[SupplierNumber],source.[SupplierName],source.[GRT],source.[PTF],source.[PC],source.[MOQ],source.[CP],1,1,source.[Document],source.[DocumentItem],source.OUn); UPDATE Sys_RawMaterial SET SupplierNumber = NULL, SupplierName = NULL, Document = NULL,DocumentItem = NULL, Fixed = 0, MRP2 = 0, GRT = NULL, PTF = NULL, PC = NULL, CP = NULL WHERE Partnumber NOT IN (SELECT RIGHT('000000' + Partnumber,8) FROM #srclist);") Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Actualizado correctamente.")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al actualizar.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                    TryDelete(filename)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al obtener la información.")
                End If
            Else
                FlashAlerts.ShowError(Language.Sentence(267))
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_CancelMovements_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_CancelMovements_mi.Click
        OpenForm(FGR_CancelSerialMovements, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_MaterialMover_PostingSamples_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_MaterialMover_PostingSamples_mi.Click
        OpenForm(MAn_SamplesMaterialMovers_mi, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_CableCheckpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_CableCheckpoint_mi.Click
        If User.Current.IsAdmin OrElse SQL.Current.Exists("Smk_AuthorizedCheckpoints", {"MachineName", "Cable"}, {Environment.MachineName, 1}) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "Smk_AuthorizedCheckpoints", {"MachineName", "Cable"}, {Environment.MachineName, 1}, My.Settings.Warehouse)
            OpenForm(Smk_CableCheckpoint, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
        Else
            FlashAlerts.ShowError("Checkpoint no autorizado.")
        End If
    End Sub

    Private Sub Main_Receiving_Management_Containers_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Containers_mi.Click
        OpenForm(REC_Containers, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub


    Private Sub Main_ComponentDeliveryRoutes_UsagePoints_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_UsagePoints_mi.Click
        OpenForm(CDR_FindManufacturing, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT MachineName AS [PC],Cable AS [Bascula de Cable], Kiosk AS [Kiosko de Componentes],Warehouse AS Estacion FROM Smk_AuthorizedCheckpoints", {"PC"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_VL10_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_VL10_mi.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Text File (*.txt)|*.txt"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim download_date = CDate(InputBox("", "Fecha", Now.ToString))
                SCH.ImportVL10(ofd.FileName, download_date)
            End If
            ofd.Dispose()
        Catch ex As Exception
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Scheduling_Reports_Compatibility_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_Compatibility_mi.Click
        OpenForm(Sch_CompatibilityReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_AMR_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_AMR_mi.Click
        OpenForm(CR_AMRReport, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_Harnesses_Update_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_Harnesses_Update_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(Parameter("SYS_PlantCode"), filename, "E", "*") Then
                    Dim txt = CSV.Datatable(filename, vbTab, True, False)
                    If txt IsNot Nothing Then
                        'txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L' AND (PROC_TYPE = 'F' OR (PROC_TYPE = 'E' AND [DESCRIPTION] LIKE '%TERM%'))))"
                        txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                        txt.Columns.Add("DBL_RV", GetType(String), "Convert([ROUNDING_VALUE],'System.Double')")
                        txt.Columns.Add("DBL_STD_PRICE", GetType(String), "Convert([STD_PRICE],'System.Double')")
                        Dim mrps As DataTable = txt.DefaultView.ToTable(True, "MRP_CONTROLLER")
                        SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Sch_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")
                        Dim bulk_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "DBL_RV", "MRP_CONTROLLER", "SPEC_PROC_TYPE", "BACKFLUSH_IND", "ISSUE_SLOC", "SLOC_EXT_PROC", "STOCK_DET_GROUP", "DBL_STD_PRICE")
                        If SQL.Current.Upsert(bulk_data, "tmpMaterial", "CREATE TABLE #tmpMaterial ([Material] [char](8) NOT NULL,[Description] [varchar](200) NOT NULL,[StdPack] [smallint] NOT NULL, [MRP] [char](3) NULL,[SpecialProc] [varchar](3) NOT NULL,[BackflushInd] [varchar](3) NOT NULL,[IssueLoc] [varchar](5) NOT NULL,[ExternalProc] [varchar](5) NOT NULL,[StockDet] [varchar](5) NOT NULL,[Cost] [decimal] (10,3))", _
                                              "MERGE Sch_Materials AS target USING #tmpMaterial AS source ON target.Material = source.Material WHEN MATCHED THEN UPDATE SET [Description] = source.[Description], MRP = source.MRP, StdPack = source.StdPack, SpecialProcurement = source.SpecialProc, Backflush = CASE WHEN source.BackflushInd = '1' THEN 1 ELSE 0 END, ProductStorageLocation = source.IssueLoc, StorageLocationForEP = source.ExternalProc, StockDetGRP = source.StockDet, UnitCost = (ISNULL(source.Cost,0) / 1000) WHEN NOT MATCHED THEN INSERT (Material, CustomerPN, [Description], StdPack, Business, StartProduction, EndProduction, Class, MRP, IsHarn,[SpecialProcurement],[Backflush],[ProductStorageLocation],[StorageLocationForEP],[StockDetGRP],UnitCost) VALUES (source.Material, source.Material, source.[Description], source.StdPack, 'Unclassified', '1900-01-01', '2099-12-31', 'NO CLASS', source.MRP, 1, source.SpecialProc, CASE WHEN source.BackflushInd = '1' THEN 1 ELSE 0 END, source.IssueLoc, source.ExternalProc, source.StockDet,ISNULL(source.Cost,0)/1000);") Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("¡Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error en el bulk de datos.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al descargar la información.")
                End If
            Else
                FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Administrator_Database_Harnesses_UpdateList_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_Harnesses_UpdateList_mi.Click

    End Sub

    Private Sub Main_Scheduling_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_Reporter_mi.Click
        OpenDeltaReporter("SCH", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-SCH")
    End Sub

    Private Sub Main_Supermarket_Components_ReturnToRandom_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_ReturnToRandom_mi.Click
        OpenForm(Smk_ReturnToRandom, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_ProductionPlan_Import_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ProductionPlan_Import_mi.Click
        OpenForm(Sch_ImportProductionPlan, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Receiving_ControlledMaterial_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Receiving_ControlledMaterial_mi.Click
        OpenForm(Ord_ControlledPartnumbers, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_Printer_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Printer_mi.Click
        OpenForm(ZPLPrinterSettings, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Printer_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Printer_mi.Click
        OpenForm(ZPLPrinterSettings, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Printer_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Printer_mi.Click
        OpenForm(ZPLPrinterSettings, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Operators_HeadcountTargets_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Operators_HeadcountTargets_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT RoleID AS Puesto, Shift AS Turno, Target AS Objetivo FROM Smk_RoleTargets WHERE RoleID IN (SELECT ID FROM Smk_OperatorRoles WHERE Area = 'SMK');", {"Puesto", "Turno"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Puesto", SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'SMK' ORDER BY Role"), "Role", "ID"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Operators_Roles_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Operators_Roles_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID, Area, Role AS Puesto FROM Smk_OperatorRoles WHERE Area = 'SMK'", {"Puesto"}, True, True, "ID"))
        db_table.tables(0).InvisibleColumns.Add("ID")
        db_table.tables(0).InvisibleColumns.Add("Area")
        db_table.tables(0).DefaultColumns.Add(New DatabaseEditor.Table.DefaultColumn("Area", "SMK"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Reports_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_Headcount_mi.Click
        OpenForm(Smk_Headcount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Cable_NoReturn_mi_Click(sender As Object, e As EventArgs)
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [Numero de Parte] FROM Smk_CableNoReturn", {"Numero de Parte"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Cable_SemiReturn_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Cable_SemiReturn_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [Numero de Parte], CutterID AS Cortadora FROM Smk_CableSemiReturn", {"Numero de Parte", "Cortadora"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Cortadora", SQL.Current.GetDatatable("SELECT ID, Name FROM PE_Cutters ORDER BY Name"), "Name", "ID"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Reports_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Reports_Headcount_mi.Click
        OpenForm(FGR_Headcount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_Headcount_mi.Click
        OpenForm(CDR_Headcount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Reports_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_Headcount_mi.Click
        OpenForm(Rec_Headcount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Operators_Roles_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Operators_Roles_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID, Area, Role AS Puesto FROM Smk_OperatorRoles WHERE Area = 'FGR'", {"Puesto"}, True, True, "ID"))
        db_table.tables(0).InvisibleColumns.Add("ID")
        db_table.tables(0).InvisibleColumns.Add("Area")
        db_table.tables(0).DefaultColumns.Add(New DatabaseEditor.Table.DefaultColumn("Area", "FGR"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Operators_HeadcountTargets_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Operators_HeadcountTargets_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT RoleID AS Puesto, Shift AS Turno, Target AS Objetivo FROM Smk_RoleTargets WHERE RoleID IN (SELECT ID FROM Smk_OperatorRoles WHERE Area = 'FGR');", {"Puesto", "Turno"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Puesto", SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'FGR' ORDER BY Role"), "Role", "ID"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Operators_Roles_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Operators_Roles_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID, Area, Role AS Puesto FROM Smk_OperatorRoles WHERE Area = 'CDR'", {"Puesto"}, True, True, "ID"))
        db_table.tables(0).InvisibleColumns.Add("ID")
        db_table.tables(0).InvisibleColumns.Add("Area")
        db_table.tables(0).DefaultColumns.Add(New DatabaseEditor.Table.DefaultColumn("Area", "CDR"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Operators_HeadcountTargets_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Operators_HeadcountTargets_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT RoleID AS Puesto, Shift AS Turno, Target AS Objetivo FROM Smk_RoleTargets WHERE RoleID IN (SELECT ID FROM Smk_OperatorRoles WHERE Area = 'CDR');", {"Puesto", "Turno"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Puesto", SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'CDR' ORDER BY Role"), "Role", "ID"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_Operators_Roles_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Operators_Roles_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID, Area, Role AS Puesto FROM Smk_OperatorRoles WHERE Area = 'REC'", {"Puesto"}, True, True, "ID"))
        db_table.tables(0).InvisibleColumns.Add("ID")
        db_table.tables(0).InvisibleColumns.Add("Area")
        db_table.tables(0).DefaultColumns.Add(New DatabaseEditor.Table.DefaultColumn("Area", "REC"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_Operators_HeadcountTargets_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Operators_HeadcountTargets_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT RoleID AS Puesto, Shift AS Turno, Target AS Objetivo FROM Smk_RoleTargets WHERE RoleID IN (SELECT ID FROM Smk_OperatorRoles WHERE Area = 'REC');", {"Puesto", "Turno"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Puesto", SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'REC' ORDER BY Role"), "Role", "ID"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_ValidateLevelSchedule_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ValidateLevelSchedule_mi.Click
        OpenForm(Sch_LevelScheduleValidation, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_RawMaterial_SupplierInfo_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_SupplierInfo_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.ZMINMAX_Vendor(Parameter("SYS_PlantCode"), "*", filename) Then
                    Dim txt = CSV.Datatable(filename, vbTab, True, True, 1)
                    If txt IsNot Nothing Then
                        Dim vendors As DataTable = txt.DefaultView.ToTable(True, "Vendor", "Trucks per week", "Transit time", "Premium transit time", "Deliveries per week", "Supplier Response Time", "Ratio", "Coverage Profile")
                        Dim vendors_table As New DataTable
                        vendors_table.Columns.Add("Supplier", GetType(String))
                        vendors_table.Columns.Add("TrucksPerWeek", GetType(Integer))
                        vendors_table.Columns.Add("TransitTime", GetType(Integer))
                        vendors_table.Columns.Add("PremiumTransit", GetType(Integer))
                        vendors_table.Columns.Add("DeliveriesPerWeek", GetType(Integer))
                        vendors_table.Columns.Add("ResponseTime", GetType(Integer))
                        vendors_table.Columns.Add("Ratio", GetType(Decimal))
                        vendors_table.Columns.Add("CoverageProfile", GetType(Decimal))
                        For Each row As DataRow In vendors.Rows
                            vendors_table.Rows.Add(row.Item(0), CInt(row.Item(1)), CInt(row.Item(2)), CInt(row.Item(3)), CInt(row.Item(4)), CInt(row.Item(5)), CDec(row.Item(6)), CDec(row.Item(7)))
                        Next

                        If SQL.Current.Upsert(vendors_table, "tmpVendors", "CREATE TABLE #tmpVendors([Supplier] [char](7) NULL,[TrucksPerWeek] [int] NULL,[TransitTime] [int] NULL,[PremiumTransit] [int] NULL,[DeliveriesPerWeek] [int] NULL,[ResponseTime] [int] NULL,[Ratio] [decimal](5, 2) NULL,[CoverageProfile] [decimal](5, 2) NULL)", "MERGE Ord_Suppliers AS target USING #tmpVendors AS source ON target.Supplier = source.Supplier WHEN MATCHED THEN UPDATE SET TrucksPerWeek = source.TrucksPerWeek, TransitTime = source.TransitTime, PremiumTransit = source.PremiumTransit, DeliveriesPerWeek = source.DeliveriesPerWeek, ResponseTime = source.ResponseTime, Ratio = source.Ratio, CoverageProfile = source.CoverageProfile WHEN NOT MATCHED THEN INSERT (Supplier,Name,TrucksPerWeek,TransitTime, PremiumTransit, DeliveriesPerWeek, ResponseTime, Ratio, CoverageProfile) VALUES (source.Supplier,'',source.TrucksPerWeek,source.TransitTime, source.PremiumTransit, source.DeliveriesPerWeek, source.ResponseTime, source.Ratio, source.CoverageProfile); UPDATE Ord_Suppliers SET Name = SupplierName FROM (SELECT DISTINCT SupplierNumber,SupplierName FROM Sys_RawMaterial) AS R WHERE Supplier = SupplierNumber;") Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("¡Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al actualizar la información.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                    TryDelete(filename)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al obtener la información.")
                End If
            Else
                FlashAlerts.ShowError(Language.Sentence(267))
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_FinishGoodRoutes_Management_Backflush_UpdateMaterial_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Management_Backflush_UpdateMaterial_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim new_date As Date = SQL.Current.GetDate("SELECT CONVERT(DATETIME,Value) AS D FROM Sys_Parameters WHERE Parameter = 'SYS_BKFSerials_LastRunning'").AddDays(-1) 'UN DIA MENOS PARA ASEGURAR QUE TODO LO DEL DIA ANTERIOR SE REGISTRO
                While new_date.Date <= Now.Date
                    Dim running_date As Date = Now
                    Dim filename As String = GF.TempTXTPath
                    If sap.AQ25SYSTQV000696_AS_TBL_ZMDEHS(Parameter("SYS_PlantCode"), new_date, filename, , , "BKF") Then
                        If IO.File.Exists(filename) Then
                            Dim serials As DataTable = CSV.Datatable(filename, vbTab, True, False, 2)
                            If serials IsNot Nothing Then
                                serials.DefaultView.RowFilter = "[LM Serial] IS NOT NULL"
                                If serials.DefaultView.Count = 0 Then
                                    If new_date.Date = Now.Date Then
                                        SQL.Current.Update("Sys_Parameters", "Value", running_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                                    Else
                                        SQL.Current.Update("Sys_Parameters", "Value", new_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                                    End If
                                Else
                                    Dim serials_table = serials.DefaultView.ToTable(False, "LM Serial", "Material", "Quantity", "Container", "Created on", "Time")
                                    If SQL.Current.Upsert(serials_table, "tmpBKF", "CREATE TABLE #tmpBKF (Serialnumber CHAR(10), Material CHAR(8), Quantity DECIMAL(10,3), Container CHAR(8),[Date] VARCHAR(12),[Time] VARCHAR(12))", String.Format("MERGE FGR_SerialMovements AS target USING #tmpBKF AS source ON target.Serialnumber = source.Serialnumber AND target.Movement = 'BKF' WHEN MATCHED THEN UPDATE SET Material = source.Material, Container = source.Container, Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Serialnumber,Movement,[Date],Posted,Badge,[Route],Active,Material,Container,Quantity) VALUES (source.Serialnumber,'BKF',{0},1,'DeltaERP',0,0,source.Material,source.Container,source.Quantity);", "DATEADD(HH,-2,DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))))")) Then
                                        If new_date.Date = Now.Date Then
                                            SQL.Current.Update("Sys_Parameters", "Value", running_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                                        Else
                                            SQL.Current.Update("Sys_Parameters", "Value", new_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                                        End If
                                    Else
                                        FlashAlerts.ShowError("Error al actualizar los numeros de parte.")
                                        Exit While
                                    End If
                                End If
                            Else
                                Exit While
                            End If
                            TryDelete(filename)
                        Else
                            If new_date.Date = Now.Date Then
                                SQL.Current.Update("Sys_Parameters", "Value", running_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                            Else
                                SQL.Current.Update("Sys_Parameters", "Value", new_date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SYS_BKFSerials_LastRunning")
                            End If
                        End If
                    Else
                        Exit While
                    End If
                    new_date = new_date.AddDays(1)
                End While
                Dim pending_serials As ArrayList = SQL.Current.GetList("SELECT Serialnumber FROM FGR_SerialMovements WHERE Material IS NULL")
                For Each s In pending_serials
                    Dim serial_data = sap.ZMDESNR(Parameter("SYS_PlantCode"), s)
                    If serial_data IsNot Nothing Then
                        SQL.Current.Update("FGR_SerialMovements", {"Material", "Quantity", "Container"}, {serial_data.Item("MATNR"), CInt(serial_data.Item("MENGE")), serial_data.Item("CONTAINER")}, "Serialnumber", s)
                    End If
                Next
                Dim new_material = SQL.Current.GetList("SELECT DISTINCT Material FROM FGR_SerialMovements WHERE Material NOT IN (SELECT Material FROM Sch_Materials) AND Material <> '' AND Material IS NOT NULL")
                If new_material.Count > 0 Then
                    '=====AGREGAR ARNESES
                    Dim filename_b As String = GF.TempTXTPath
                    If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(Parameter("SYS_PlantCode"), new_material, filename_b) Then
                        Dim txt = CSV.Datatable(filename_b, vbTab, True, False)
                        If txt IsNot Nothing Then
                            'txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L' AND (PROC_TYPE = 'F' OR (PROC_TYPE = 'E' AND [DESCRIPTION] LIKE '%TERM%'))))"
                            txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                            txt.Columns.Add("DBL_RV", GetType(String), "Convert([ROUNDING_VALUE],'System.Double')")
                            Dim mrps As DataTable = txt.DefaultView.ToTable(True, "MRP_CONTROLLER")
                            SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Sch_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")
                            Dim bulk_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "DBL_RV", "MRP_CONTROLLER")
                            SQL.Current.Upsert(bulk_data, "tmpMaterial", "CREATE TABLE #tmpMaterial ([Material] [char](8) NOT NULL,[Description] [varchar](200) NOT NULL,[StdPack] [smallint] NOT NULL, [MRP] [char](3) NULL)", _
                                                 "MERGE Sch_Materials AS target USING #tmpMaterial AS source ON target.Material = source.Material WHEN MATCHED THEN UPDATE SET [Description] = source.[Description], MRP = source.MRP, StdPack = source.StdPack WHEN NOT MATCHED THEN INSERT (Material, CustomerPN, [Description], StdPack, Business, StartProduction, EndProduction, Class, MRP, IsHarn) VALUES (source.Material, source.Material, source.[Description], source.StdPack, 'Unclassified', '1900-01-01', '2099-12-31', 'NO CLASS', source.MRP, 1);")
                        End If
                        TryDelete(filename_b)
                    End If
                End If
                sap.CloseSession()
                Dim missing As Integer = SQL.Current.GetScalar("SELECT COUNT(Serialnumber) FROM FGR_SerialMovements WHERE Material IS NULL")
                LoadingScreen.Hide()
                If missing > 0 Then
                    FlashAlerts.ShowInformation(String.Format("Existen {0} serie(s) sin actualizar el número de parte.", missing))
                End If
            Else
                FlashAlerts.ShowError("Sesión de SAP no encontrada.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_FinishGoodRoutes_Reports_BackflushHours_mi_Click(sender As Object, e As EventArgs) Handles Main_FinishGoodRoutes_Reports_BackflushHours_mi.Click
        OpenForm(FGR_BackflushHours, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Users_Permissions_FingerprintRegister_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Permissions_FingerprintRegister_mi.Click
        OpenForm(Enrollment, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Management_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Management_Operators_mi.Click
        OpenForm(Shi_Operators, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Management_Operators_Roles_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Management_Operators_Roles_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID, Area, Role AS Puesto FROM Smk_OperatorRoles WHERE Area = 'SHI'", {"Puesto"}, True, True, "ID"))
        db_table.tables(0).InvisibleColumns.Add("ID")
        db_table.tables(0).InvisibleColumns.Add("Area")
        db_table.tables(0).DefaultColumns.Add(New DatabaseEditor.Table.DefaultColumn("Area", "SHI"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Management_Operators_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Management_Operators_Headcount_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT RoleID AS Puesto, Shift AS Turno, Target AS Objetivo FROM Smk_RoleTargets WHERE RoleID IN (SELECT ID FROM Smk_OperatorRoles WHERE Area = 'SHI');", {"Puesto", "Turno"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Puesto", SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'SHI' ORDER BY Role"), "Role", "ID"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Turno", SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Shipping_Reports_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Reports_Headcount_mi.Click
        OpenForm(Shi_Headcount, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_FingerprintRegistryMfg_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_FingerprintRegistryMfg_mi.Click
        OpenForm(NewOperatorEnrollment, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_ComponentPlan_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_ComponentPlan_mi.Click
        OpenForm(CR_ComponentPlan, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Management_ScheduledEngineeringChanges_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Management_ScheduledEngineeringChanges_mi.Click

    End Sub

    Private Sub Main_Quality_Alerts_AlertSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_AlertSerial_mi.Click
        OpenForm(QLY_ServiceToQuality, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_SAP_SE16N_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_SE16N_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim last_update As Date = CDate(Parameter("SCH_SE16N_LastUpdating", Delta.CurrentDate.Date, True))
                While last_update <= Delta.CurrentDate
                    Dim filename As String = GF.TempTXTPath
                    If sap.SE16N(Parameter("SYS_PlantCode"), last_update, last_update, filename) Then
                        If IO.File.Exists(filename) Then
                            Dim csv_dt As DataTable = CSV.Datatable(filename, vbTab, True, True, 0)
                            TryDelete(filename)
                            If csv_dt.Rows.Count > 0 Then
                                Dim serials As New ArrayList

                                Dim bulk_dt As New DataTable
                                bulk_dt.Columns.Add("Serial")
                                bulk_dt.Columns.Add("Material")
                                bulk_dt.Columns.Add("Quantity", GetType(Integer))
                                bulk_dt.Columns.Add("Date", GetType(Date))
                                For Each row As DataRow In csv_dt.Rows
                                    If Not serials.Contains(If(row.Item("LM Serial#").ToString.Trim = "", row.Item("Doc number"), row.Item("LM Serial#"))) Then
                                        bulk_dt.Rows.Add(If(row.Item("LM Serial#").ToString.Trim = "", row.Item("Doc number"), row.Item("LM Serial#")), row.Item("Material"), CInt(row.Item("Quantity")), CDate(row.Item("Entry Date") & " " & row.Item("Time")))
                                        serials.Add(If(row.Item("LM Serial#").ToString.Trim = "", row.Item("Doc number"), row.Item("LM Serial#")))
                                    End If
                                Next
                                If SQL.Current.Upsert(bulk_dt, "tmp_bkf", "CREATE TABLE #tmp_bkf (serial varchar(12),material char(8),quantity int,[date] datetime)", "MERGE FGR_SerialMovements AS target USING #tmp_bkf AS source ON target.Serialnumber = source.serial AND target.Movement = 'BKF' WHEN MATCHED THEN UPDATE SET target.Material = source.Material, target.[PostedDate] = source.[Date], target.[Active] = 0, target.[Posted] = 1,target.Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Serialnumber,Movement,[Date],Posted,Badge,Route,Active,Material,Container,Quantity,PostedDate) VALUES (source.serial,'BKF',DATEADD(HOUR,-2,source.[date]),1,'DeltaERP',0,0,source.material,'',source.quantity,source.[date]);") Then
                                    If last_update.Date = Delta.CurrentDate.Date Then
                                        SQL.Current.Update("Sys_Parameters", "Value", Delta.CurrentDate.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SCH_SE16N_LastUpdating")
                                        LoadingScreen.Hide()
                                        FlashAlerts.ShowConfirm("¡Hecho!")
                                    Else
                                        SQL.Current.Update("Sys_Parameters", "Value", last_update.Date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SCH_SE16N_LastUpdating")
                                    End If
                                Else
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowError("Error al actualizar los movimientos BKF.")
                                    Exit While
                                End If
                            End If
                        Else
                            If last_update.Date = Delta.CurrentDate.Date Then
                                SQL.Current.Update("Sys_Parameters", "Value", Delta.CurrentDate.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SCH_SE16N_LastUpdating")
                                LoadingScreen.Hide()
                                FlashAlerts.ShowConfirm("¡Hecho!")
                            Else
                                SQL.Current.Update("Sys_Parameters", "Value", last_update.Date.ToString("yyyy-MM-dd HH:mm"), "Parameter", "SCH_SE16N_LastUpdating")
                            End If
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al descargar los movimientos BKF.")
                        Exit Sub
                    End If
                    last_update = last_update.AddDays(1)
                End While
            Else
                FlashAlerts.ShowError("Sesión de SAP no encontrada.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_ComponentReadiness_Management_ScheduledEngineeringChanges_Business_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Management_ScheduledEngineeringChanges_Business_mi.Click
        OpenForm(CR_BusinessScheduledChanges, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Management_ScheduledEngineeringChanges_Material_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Management_ScheduledEngineeringChanges_Material_mi.Click
        OpenForm(CR_MaterialScheduledChanges, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_WeeklyWorkload_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_WeeklyWorkload.Click
        OpenForm(CDR_WeeklyScanningHistory, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_Discrepancy_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Discrepancy_mi.Click
        OpenForm(Smk_DeclareEmptyDiscrepancy, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_ZMF47_mi.Click
        'OpenForm(MAn_ZMF47, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_EngineeringPermits_New_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_EngineeringPermits_New_mi.Click
        OpenForm(MAn_InsertPermit, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_EngineeringPermits_Run309_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_EngineeringPermits_Run309_mi.Click
        OpenForm(MAn_Process309, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_EngineeringPermits_PermitsVsBOM_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_EngineeringPermits_PermitsVsBOM_mi.Click
        OpenForm(MAn_MandatoryPermitsVsBOM, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Scheduling_Database_ShippingPoints_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_ShippingPoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Material,[Month] AS Mes,[Year] AS Año,[Points] AS Puntos FROM Sch_ShippingPoints WHERE [Year] = DATEPART(Year,GETDATE());", {"Material", "Mes", "Año"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Ordering_Supermarket_SetMfgConsumption_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_SetMfgConsumption_mi.Click
        OpenForm(Ord_SetMfgConsumption, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub



    Private Sub Main_MaterialAnalyst_ZMF47_Force_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_ZMF47_Force_mi.Click
        Dim sap As New SAP
        If sap.Available Then
            LoadingScreen.Show()
            If sap.ZMF47v1(Parameter("SYS_PlantCode")) Then 'ENTRAR A LA ZMF47 Y FORZAR EL BACKFLUSH
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("¡Hecho!")
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Error al ejecutar la transacción.")
            End If
        Else
            FlashAlerts.ShowError("Sesión de SAP no encontrada.")
        End If
    End Sub

    Private Sub Main_MaterialAnalyst_ZMF47_Report_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_ZMF47_Report_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25SYSTQV000492RPT_ZMF47(Parameter("SYS_PlantCode"), filename) Then 'DESCARGAR START_REPORT DE ZMF47
                    Dim zmf47 As DataTable = CSV.Datatable(filename, vbTab, True, True, 2)
                    TryDelete(filename)
                    filename = GF.TempTXTPath
                    If sap.ZAPI_MATINFO(Parameter("SYS_PlantCode"), filename, {"0002"}) Then 'DESCARGAR INVENTARIO DEL SLOC 0002

                        Dim zapi As DataTable = CSV.Datatable(filename, vbTab, True, True, 4) 'VACIAR INVENTARIO EN DATATABLE
                        Dim zapimatinfo As New DataTable
                        zapimatinfo.Columns.Add("Partnumber")
                        zapimatinfo.Columns.Add("Quantity", GetType(Decimal))
                        zapimatinfo.Columns.Add("UoM")
                        zapimatinfo.PrimaryKey = {zapimatinfo.Columns("Partnumber")}
                        For Each row As DataRow In zapi.DefaultView.ToTable(False, "Material", "Material description", "Unrestricted stock", "Base UOM").Rows
                            zapimatinfo.Rows.Add(RawMaterial.Format(row.Item("Material").ToString.Trim), CDec(row.Item("Unrestricted stock")), row.Item("Base UOM"))
                        Next

                        Dim requeriment As New DataTable("ZMF47")
                        requeriment.Columns.Add("Material")
                        requeriment.Columns.Add("Partnumber")
                        requeriment.Columns.Add("Quantity", GetType(Decimal))
                        requeriment.Columns.Add("UoM")
                        requeriment.Columns.Add("Reqmt Date", GetType(Date))


                        Dim not_enough As New DataTable("Comparativo")
                        not_enough.Columns.Add("No. de Parte")
                        not_enough.Columns.Add("Descripcion")
                        not_enough.Columns.Add("MRP")
                        not_enough.Columns.Add("UoM")
                        not_enough.Columns.Add("Costo Unitario", GetType(Decimal))
                        not_enough.Columns.Add("Comentario")
                        not_enough.Columns.Add("Errores ZMF47", GetType(Integer))
                        not_enough.Columns.Add("Requerimiento ZMF47", GetType(Decimal))
                        not_enough.Columns.Add("Sloc 0002", GetType(Decimal))
                        not_enough.Columns.Add("Transferencias Pendientes", GetType(Decimal))
                        not_enough.Columns.Add("Tracker de Problemas", GetType(Decimal))
                        not_enough.Columns.Add("Movimientos 309", GetType(Decimal))
                        not_enough.Columns.Add("Faltante", GetType(Decimal), "IIF([Sloc 0002] + [Transferencias Pendientes] + [Movimientos 309] - [Requerimiento ZMF47] < 0,[Sloc 0002] + [Transferencias Pendientes] + [Movimientos 309] - [Requerimiento ZMF47],0)")
                        not_enough.Columns.Add("Faltante Costo", GetType(Decimal), "IIF(Faltante < 0,[Costo Unitario] * Faltante,0)")


                        Dim transfers As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,SUM(Quantity) AS Quantity FROM vw_Smk_PendingTransfers WHERE ToSloc = '0002' OR FromSloc = '0002' GROUP BY Partnumber")
                        transfers.PrimaryKey = {transfers.Columns("Partnumber")}

                        Dim tracker As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,SUM(OriginalQuantityInBuM-CurrentQuantityInBuM) AS Quantity FROM vw_Smk_Serials WHERE InvoiceTrouble = 1 AND [Status] = 'T' GROUP BY Partnumber")
                        tracker.PrimaryKey = {tracker.Columns("Partnumber")}

                        Dim raw As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,UoM,Description,MRP,UnitCost,MAnalystComment FROM Sys_RawMaterial")
                        raw.PrimaryKey = {raw.Columns("Partnumber")}

                        For Each row As DataRow In zmf47.Rows
                            requeriment.Rows.Add(row.Item("Material"), RawMaterial.Format(row.Item("Material_1").ToString.Trim), CDec(row.Item("Reqmt Qty")), row.Item("BUn"), row.Item("Reqmt Date"))
                        Next
                        Dim requeriment_total As DataTable = DatatablePivoter.Get(requeriment, {"Partnumber", "UoM"}, {}, {"Quantity", "Material"}, {AggregateFunction.Sum, AggregateFunction.Count})
                        requeriment_total.DefaultView.Sort = "[Conteo de Material] DESC"

                        For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                            Dim stock As DataRow = zapimatinfo.Rows.Find(row.Item("Partnumber"))
                            Dim pending As DataRow = transfers.Rows.Find(row.Item("Partnumber"))
                            Dim ontracker As DataRow = tracker.Rows.Find(row.Item("Partnumber"))
                            Dim compo As DataRow = raw.Rows.Find(row.Item("Partnumber"))
                            Dim s, p, t, uc As Decimal
                            Dim description, uom, mrp, comment As String
                            If stock IsNot Nothing Then
                                s = stock.Item("Quantity")
                            Else
                                s = 0
                            End If

                            If pending IsNot Nothing Then
                                p = pending.Item("Quantity")
                            Else
                                p = 0
                            End If

                            If ontracker IsNot Nothing Then
                                t = ontracker.Item("Quantity")
                            Else
                                t = 0
                            End If
                            If compo IsNot Nothing Then
                                uc = compo.Item("UnitCost")
                                description = compo.Item("Description")
                                uom = compo.Item("UoM")
                                mrp = compo.Item("MRP")
                                comment = NullReplace(compo.Item("MAnalystComment"), "")
                            Else
                                uc = 0
                                description = SQL.Current.GetString("Description", "Sch_Materials", "Material", row.Item("Partnumber"), "")
                                uom = "PC"
                                mrp = SQL.Current.GetString("MRP", "Sch_Materials", "Material", row.Item("Partnumber"), "")
                                comment = SQL.Current.GetString("MAnalystComment", "Sch_Materials", "Material", row.Item("Partnumber"), "")
                            End If
                            not_enough.Rows.Add(row.Item("Partnumber"), description, mrp, uom, uc, comment, row.Item("Conteo de Material"), row.Item("Suma de Quantity"), s, p, t, SQL.Current.GetScalar(String.Format("SELECT SUM(S.Quantity*B.Quantity) AS Cantidad FROM MAn_EngineeringPermits AS P INNER JOIN FGR_SerialMovements AS S ON P.Material = S.Material AND S.PostedDate BETWEEN P.LastAdjustment AND P.ExpirationDate LEFT OUTER JOIN MAn_309Movements AS M ON S.Serialnumber = M.Serialnumber AND P.ID = M.PermitID INNER JOIN Sys_CurrentBOM AS B ON P.Material = B.Material AND P.OldPartnumber = B.Partnumber INNER JOIN Sys_RawMaterial AS R ON P.NewPartnumber =  R.Partnumber WHERE P.[Type] = 'S' AND P.[Active] = 1 AND S.Movement = 'BKF' AND M.PermitID IS NULL AND OldPartnumber = '{0}'", row.Item("Partnumber"))))
                        Next
                        not_enough.DefaultView.Sort = "[Errores ZMF47] DESC"

                        TryDelete(filename)

                        If MyExcel.SaveAs({requeriment, not_enough.DefaultView.ToTable}) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("¡Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("Cancelado.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al descargar el inventario de Sloc 0002.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowConfirm("Error al ejecutar la transacción.")
                End If
            Else
                FlashAlerts.ShowError("Sesión de SAP no encontrada.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Supermarket_Management_WeightSamples_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_WeightSamples_mi.Click
        OpenForm(Smk_SamplesWeight, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Database_RawMaterial_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Database_RawMaterial_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Partnumber AS [No. de Parte],MAnalystComment AS Comentario FROM Sys_RawMaterial ORDER BY Partnumber", {"No. de Parte"}, False, False, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Database_Material_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Database_Material_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Material,MAnalystComment AS Comentario FROM Sch_Materials ORDER BY Material", {"Material"}, False, False, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Database_Permits_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Database_Permits_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [ID],[Number] AS Permiso,[Material],[OldPartnumber] AS [NP Anterior],[NewPartnumber] AS [NP Nuevo],[NewQuantity] AS [Nueva Cantidad],[Platform] AS Plataforma,[Originator] AS Originador,[Description] AS Descripcion,[Type] AS Tipo,[IssueDate] AS [Fecha de Creacion],[ExpirationDate] AS [Fecha de Expiracion],[LastAdjustment] AS [Fecha de Ajustes],[Active] AS Activo,[Comment] AS Comentario FROM MAn_EngineeringPermits ORDER BY Number,OldPartnumber,NewPartnumber,Material", {"Permiso", "Material", "NP Anterior"}, True, True, "ID"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Reports_FGStock_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_Stock_mi.Click
        Try
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_WHR_DATA(Parameter("SCH_WarehouseNumber"), Parameter("SYS_PlantCode"), filename) Then
                    Dim whr_data As DataTable = CSV.Datatable(filename, vbTab, True, True, 2)
                    whr_data.Columns.Add("TOTALSTOCK_INT", GetType(Integer), "Convert(TOTALSTOCK,'System.Decimal')")
                    Dim whr_data_pivot As DataTable = DatatablePivoter.Get(whr_data, {"MATERIAL"}, {"STY"}, {"TOTALSTOCK_INT"}, {AggregateFunction.Sum}, "[STY] IN ('916','QAL','SKD') AND [STORAGEBIN] <> 'BLOCK BIN'")
                    TryDelete(filename)
                    filename = GF.TempTXTPath
                    If sap.MB52(Parameter("SYS_PlantCode"), "", "", filename) Then
                        Dim mb52 As DataTable = CSV.Datatable(filename, vbTab, True, True, 0) 'VACIAR INVENTARIO EN DATATABLE
                        mb52.Columns.Add("Partnumber", GetType(String), "SUBSTRING('00000000' + [Material Number],LEN('00000000' + [Material Number]) - 7,8)")
                        mb52.Columns.Add("Inventario", GetType(Decimal), "Convert(IIF([Unrestricted] <> '', [Unrestricted], 0),'System.Decimal')")
                        mb52.Columns.Add("Bloqueado", GetType(Decimal), "Convert(IIF([Blocked] <> '', [Blocked], 0),'System.Decimal')")
                        mb52.Columns.Add("Transito", GetType(Decimal), "Convert(IIF([Transit/Transf.] <> '', [Transit/Transf.], 0),'System.Decimal')")
                        mb52.Columns.Add("Total", GetType(Decimal), "Inventario + Bloqueado")

                        'SQL.Current.Execute("DELETE FROM Sys_CurrentMB52;") PARA EL IFA
                        'SQL.Current.Bulk(zapi.DefaultView.ToTable(False, "Partnumber", "Total", "SLoc"), "Sys_CurrentMB52") 'PARA EL IFA

                        Dim slocs As DataTable = mb52.DefaultView.ToTable(True, "SLoc")
                        Dim sum_exp As String = ""
                        Dim mb52_pivot As DataTable = DatatablePivoter.Get(mb52, {"Partnumber"}, {"SLoc"}, {"Inventario"}, {AggregateFunction.Sum}, "SLoc <> ''")
                        Dim blocked_pivot As DataTable = DatatablePivoter.Get(mb52, {"Partnumber"}, {}, {"Bloqueado"}, {AggregateFunction.Sum}, "SLoc <> '' AND Bloqueado <> 0")
                        Dim transit_pivot As DataTable = DatatablePivoter.Get(mb52, {"Partnumber"}, {}, {"Transito"}, {AggregateFunction.Sum}, "SLoc = '' AND Transito <> 0")

                        mb52_pivot.Columns.Add("Descripcion")
                        mb52_pivot.Columns.Add("Unidad")
                        mb52_pivot.Columns.Add("Costo Unitario", GetType(Decimal))
                        mb52_pivot.Columns.Add("Clase")
                        mb52_pivot.Columns.Add("Negocio")
                        mb52_pivot.Columns.Add("Plataforma")
                        mb52_pivot.Columns.Add("Bloqueado", GetType(Decimal))
                        mb52_pivot.Columns.Add("Bloqueado $", GetType(Decimal), "Bloqueado * [Costo Unitario]")
                        mb52_pivot.Columns.Add("Transito", GetType(Decimal))
                        mb52_pivot.Columns.Add("Transito $", GetType(Decimal), "Transito * [Costo Unitario]")

                        Dim j = (mb52_pivot.Columns.Count - 11) * 2 - 1
                        For i = 1 To j Step 2
                            Dim col As DataColumn = mb52_pivot.Columns(i)
                            If col.ColumnName.Contains("Suma de Inventario") Then
                                col.ColumnName = "SLoc " & col.ColumnName.Replace("Suma de Inventario", "").Trim
                                col.DefaultValue = 0
                                mb52_pivot.Columns.Add(col.ColumnName & " $", GetType(Decimal), String.Format("[{0}] * [Costo Unitario]", col.ColumnName))
                                mb52_pivot.Columns(col.ColumnName & " $").SetOrdinal(col.Ordinal + 1)
                                sum_exp &= String.Format("ISNULL([{0}],0)+", col.ColumnName)
                                mb52_pivot.AcceptChanges()
                            End If
                        Next

                        

                        mb52_pivot.Columns.Add("Total", GetType(Decimal), sum_exp & "ISNULL(Transito,0) + ISNULL(Bloqueado,0)")
                        mb52_pivot.Columns.Add("Total $", GetType(Decimal), "Total * [Costo Unitario]")
                        mb52_pivot.Columns.Add("916", GetType(Decimal))
                        mb52_pivot.Columns.Add("916 $", GetType(Decimal), "[916] * [Costo Unitario]")
                        mb52_pivot.Columns.Add("QAL", GetType(Decimal))
                        mb52_pivot.Columns.Add("QAL $", GetType(Decimal), "QAL * [Costo Unitario]")
                        mb52_pivot.Columns.Add("SKD", GetType(Decimal))
                        mb52_pivot.Columns.Add("SKD $", GetType(Decimal), "SKD * [Costo Unitario]")
                        mb52_pivot.Columns("Descripcion").SetOrdinal(1)
                        mb52_pivot.Columns("Unidad").SetOrdinal(2)
                        mb52_pivot.Columns("Costo Unitario").SetOrdinal(3)
                        mb52_pivot.Columns("Clase").SetOrdinal(4)
                        mb52_pivot.Columns("Negocio").SetOrdinal(5)
                        mb52_pivot.Columns("Plataforma").SetOrdinal(6)
                        mb52_pivot.Columns("Transito").DefaultValue = 0
                        mb52_pivot.Columns("Bloqueado").DefaultValue = 0
                        mb52_pivot.Columns("916").DefaultValue = 0
                        mb52_pivot.Columns("QAL").DefaultValue = 0
                        mb52_pivot.Columns("SKD").DefaultValue = 0
                        mb52_pivot.PrimaryKey = {mb52_pivot.Columns("Partnumber")}
                        Dim key_class As DataTable = SQL.Current.GetDatatable("SELECT K.Partnumber,Key_Class,M.Business,B.Family,CASE WHEN Key_Class <> 'RAW' THEN ISNULL(M.UnitCost,R.UnitCost) ELSE ISNULL(R.UnitCost,M.UnitCost) END AS UnitCost,ISNULL(R.UoM,'PC') AS UoM,ISNULL(R.[Description],M.[Description]) AS [Description] FROM MAn_KeyClassPartnumbers AS K LEFT OUTER JOIN Sch_Materials AS M ON K.Partnumber = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sys_Rawmaterial AS R ON K.Partnumber = R.Partnumber")
                        key_class.PrimaryKey = {key_class.Columns("Partnumber")}

                        For Each z_row As DataRow In mb52_pivot.Rows
                            Dim k_row As DataRow = key_class.Rows.Find(z_row.Item("Partnumber"))
                            If k_row IsNot Nothing Then
                                z_row.Item("Descripcion") = k_row.Item("Description")
                                z_row.Item("Unidad") = k_row.Item("UoM")
                                z_row.Item("Negocio") = If(k_row("Key_Class") <> "RAW", k_row.Item("Family"), "")
                                z_row.Item("Plataforma") = If(k_row("Key_Class") <> "RAW", k_row.Item("Business"), "")
                                z_row.Item("Costo Unitario") = k_row("UnitCost")
                                z_row.Item("Clase") = k_row("Key_Class")
                            Else
                                z_row.Item("Costo Unitario") = 0
                                z_row.Item("Clase") = "N/A"
                            End If
                        Next
                        For Each part As DataRow In whr_data_pivot.Rows
                            Dim z_row As DataRow = mb52_pivot.Rows.Find(part.Item("MATERIAL"))
                            If z_row IsNot Nothing Then
                                z_row.Item("916") = If(whr_data_pivot.Columns.Contains("916 Suma de TOTALSTOCK_INT"), part.Item("916 Suma de TOTALSTOCK_INT"), 0)
                                z_row.Item("QAL") = If(whr_data_pivot.Columns.Contains("QAL Suma de TOTALSTOCK_INT"), part.Item("QAL Suma de TOTALSTOCK_INT"), 0)
                                z_row.Item("SKD") = If(whr_data_pivot.Columns.Contains("SKD Suma de TOTALSTOCK_INT"), part.Item("SKD Suma de TOTALSTOCK_INT"), 0)
                            Else
                                z_row = mb52_pivot.NewRow
                                z_row.Item("Partnumber") = part.Item("MATERIAL")
                                z_row.Item("916") = If(whr_data_pivot.Columns.Contains("916 Suma de TOTALSTOCK_INT"), part.Item("916 Suma de TOTALSTOCK_INT"), 0)
                                z_row.Item("QAL") = If(whr_data_pivot.Columns.Contains("QAL Suma de TOTALSTOCK_INT"), part.Item("QAL Suma de TOTALSTOCK_INT"), 0)
                                z_row.Item("SKD") = If(whr_data_pivot.Columns.Contains("SKD Suma de TOTALSTOCK_INT"), part.Item("SKD Suma de TOTALSTOCK_INT"), 0)

                                Dim k_row As DataRow = key_class.Rows.Find(part.Item("MATERIAL"))
                                If k_row IsNot Nothing Then
                                    z_row.Item("Descripcion") = k_row.Item("Description")
                                    z_row.Item("Unidad") = k_row.Item("UoM")
                                    z_row.Item("Negocio") = If(k_row("Key_Class") <> "RAW", k_row.Item("Family"), "")
                                    z_row.Item("Plataforma") = If(k_row("Key_Class") <> "RAW", k_row.Item("Business"), "")
                                    z_row.Item("Costo Unitario") = k_row("UnitCost")
                                    z_row.Item("Clase") = k_row("Key_Class")
                                Else
                                    z_row.Item("Costo Unitario") = 0
                                    z_row.Item("Clase") = "N/A"
                                End If
                                mb52_pivot.Rows.Add(z_row)
                            End If
                        Next

                        For Each part As DataRow In blocked_pivot.Rows
                            Dim z_row As DataRow = mb52_pivot.Rows.Find(part.Item("Partnumber"))
                            If z_row IsNot Nothing Then
                                z_row.Item("Bloqueado") = part.Item(1)
                            Else
                                z_row = mb52_pivot.NewRow
                                z_row.Item("Partnumber") = part.Item("Partnumber")
                                z_row.Item("Bloqueado") = part.Item(1)
                                Dim k_row As DataRow = key_class.Rows.Find(part.Item("Partnumber"))
                                If k_row IsNot Nothing Then
                                    z_row.Item("Descripcion") = k_row.Item("Description")
                                    z_row.Item("Unidad") = k_row.Item("UoM")
                                    z_row.Item("Negocio") = If(k_row("Key_Class") <> "RAW", k_row.Item("Family"), "")
                                    z_row.Item("Plataforma") = If(k_row("Key_Class") <> "RAW", k_row.Item("Business"), "")
                                    z_row.Item("Costo Unitario") = k_row("UnitCost")
                                    z_row.Item("Clase") = k_row("Key_Class")
                                Else
                                    z_row.Item("Costo Unitario") = 0
                                    z_row.Item("Clase") = "N/A"
                                End If
                                mb52_pivot.Rows.Add(z_row)
                            End If
                        Next

                        For Each part As DataRow In transit_pivot.Rows
                            Dim z_row As DataRow = mb52_pivot.Rows.Find(part.Item("Partnumber"))
                            If z_row IsNot Nothing Then
                                z_row.Item("Transito") = part.Item(1)
                            Else
                                z_row = mb52_pivot.NewRow
                                z_row.Item("Partnumber") = part.Item("Partnumber")
                                z_row.Item("Transito") = part.Item(1)

                                Dim k_row As DataRow = key_class.Rows.Find(part.Item("Partnumber"))
                                If k_row IsNot Nothing Then
                                    z_row.Item("Descripcion") = k_row.Item("Description")
                                    z_row.Item("Unidad") = k_row.Item("UoM")
                                    z_row.Item("Negocio") = If(k_row("Key_Class") <> "RAW", k_row.Item("Family"), "")
                                    z_row.Item("Plataforma") = If(k_row("Key_Class") <> "RAW", k_row.Item("Business"), "")
                                    z_row.Item("Costo Unitario") = k_row("UnitCost")
                                    z_row.Item("Clase") = k_row("Key_Class")
                                Else
                                    z_row.Item("Costo Unitario") = 0
                                    z_row.Item("Clase") = "N/A"
                                End If
                                mb52_pivot.Rows.Add(z_row)
                            End If
                        Next

                        mb52_pivot.TableName = "Inventario Detallado"

                        Dim sum_sloc As New DataTable("Inventario por Sloc")
                        sum_sloc.Columns.Add("Sloc")
                        sum_sloc.Columns.Add("Inventario", GetType(Decimal))
                        sum_sloc.Rows.Add("Transito", mb52_pivot.Compute("SUM([Transito $])", ""))
                        sum_sloc.Rows.Add("Bloqueado", mb52_pivot.Compute("SUM([Bloqueado $])", ""))
                        For Each sloc As DataRow In slocs.Rows
                            If sloc.Item("SLoc") <> "" Then sum_sloc.Rows.Add(sloc.Item("SLoc"), mb52_pivot.Compute(String.Format("SUM([SLoc {0} $])", sloc.Item("SLoc")), ""))
                        Next
                        sum_sloc.Rows.Add("Total", mb52_pivot.Compute("SUM([Total $])", ""))

                        Dim sum_class As New DataTable("Inventario por Clase")
                        sum_class.Columns.Add("Clase")
                        sum_class.Columns.Add("Inventario", GetType(Decimal))
                        sum_class.Rows.Add("RAW", mb52_pivot.Compute("SUM([Total $]) - SUM([SLoc 0002 $])", "Clase <> 'FG'"))
                        sum_class.Rows.Add("WIP", mb52_pivot.Compute("SUM([SLoc 0002 $])", "Clase <> 'FG'"))
                        sum_class.Rows.Add("FG", mb52_pivot.Compute("SUM([Total $])", "Clase = 'FG'"))
                        sum_class.Rows.Add("Total", mb52_pivot.Compute("SUM([Total $])", ""))

                        Dim fg_sum As DataTable = DatatablePivoter.Get(mb52_pivot, {"Negocio"}, {}, {"Total $", "SKD $", "916 $", "QAL $"}, {AggregateFunction.Sum, AggregateFunction.Sum, AggregateFunction.Sum, AggregateFunction.Sum}, "Clase = 'FG'", True, False)
                        fg_sum.TableName = "Inventario de PT"

                        TryDelete(filename)

                        If MyExcel.SaveAs({mb52_pivot, fg_sum, sum_sloc, sum_class}, False) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("¡Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("Cancelado.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al ejecutar la transacción.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al ejecutar la transacción.")
                End If
            Else
                FlashAlerts.ShowError("Sesión de SAP no encontrada.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Surgio un error al ejecutar la operación.")
        End Try
    End Sub

    Private Sub Main_Leadprep_Database_Leadcodes_mi_Click(sender As Object, e As EventArgs) Handles Main_Leadprep_Database_Leadcodes_mi.Click
        OpenForm(PEng_Leadcodes, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_mi.Click

    End Sub

    Private Sub Main_ComponentReadiness_Picklist_Add_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Picklist_Add_mi.Click
        OpenForm(CR_Picklist, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Picklist_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Picklist_Print_mi.Click
        OpenForm(CR_PrintPicklist, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentReadiness_Picklist_Delete_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Picklist_Delete_mi.Click

    End Sub

    Private Sub Main_ComponentDeliveryRoutes_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_mi.Click
      
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_CheckpointDecoupled_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_CheckpointDecoupled_mi.Click
        If User.Current.IsAdmin OrElse SQL.Current.Exists("CDR_AuthorizedCheckpoints", {"MachineName"}, {Environment.MachineName}) Then
            My.Settings.Warehouse = SQL.Current.GetString("Warehouse", "CDR_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
            OpenForm(DDR_Checkpoint, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text, False)
        Else
            FlashAlerts.ShowError("Checkpoint no autorizado.")
        End If
    End Sub

    Private Sub Main_Supermarket_Management_LinkLabels_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_LinkLabels_mi.Click

    End Sub

    Private Sub Main_Supermarket_Management_LinkLabels_New_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_LinkLabels_New_mi.Click
        OpenForm(Smk_LinkLabels, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Supermarket_Management_LinkLabels_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_LinkLabels_Print_mi.Click
        OpenForm(Smk_PrintLinkLabels, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Carts_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Carts_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT ID AS Placa, [Description] AS Nombre,Warehouse AS Estacion, Active AS Activo FROM DDR_Carts", {"Placa"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_Reporter_mi.Click
        OpenDeltaReporter("MAN", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-MAN")
    End Sub

    Private Sub Main_Quality_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Reports_Reporter_mi.Click
        OpenDeltaReporter("QLY", CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text & "-QLY")
    End Sub

    Private Sub Main_Administrator_API_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_API_Print_mi.Click
        OpenForm(Smk_APIPrint, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_API_Tickets_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_API_Tickets_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT * FROM Smk_APITickets", {"Ticket"}, True, True, ""))
        db_table.tables.Add(New DatabaseEditor.Table("Series Escaneadas", "SELECT * FROM Smk_APITicketSerials", {"SerialID"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Sloc", SQL.Current.GetDatatable("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs UNION SELECT DISTINCT DullSloc AS Sloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc"), "Sloc", "Sloc"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Administrator_Database_Reports_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_Reports_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Reportes", "SELECT [Name] AS Reporte,[Alias],[Area],[Command] AS [Select],[Filter] AS [Where],[Sort] AS [Order By],[Group],[Having] FROM Sys_Reports", {"Reporte"}, True, True, ""))
        db_table.tables.Add(New DatabaseEditor.Table("Parametros", "SELECT [ReportName] AS Reporte,[Parameter] AS Parametro,[Alias],[DataType] AS Tipo,[DefaultCondition] AS [Condicional Predeterminada],[DefaultValue] AS [Valor Predeterminado],[OrdinalPosition] AS Posicion,[DefaultStatus] AS [Estatus Predeterminado] FROM Sys_ReportParameters", {"Reporte", "Parametro", "Alias"}, True, True, ""))

        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Area", False, {"SMK", "REC", "SHI", "QLY", "ORD", "SCH", "CR", "CDR", "FGR", "MAN", "ADM", "LDP", "SEC", "IGP", "MET", "MTO", "PR"}))
        db_table.tables(1).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Tipo", False, {"Boolean", "Date", "Decimal", "Integer", "String"}))
        db_table.tables(1).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Condicional Predeterminada", False, {"Equal", "NotEqual", "GreaterThan", "GreaterOrEqualThan", "MinorThan", "MinorOrEqualThan", "In", "NotIn"}))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MaterialAnalyst_Reports_InitialWeightAnalysis_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_InitialWeightAnalysis_mi.Click
        OpenForm(MAn_InitialWeightAnalysis, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Container_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Container_mi.Click
        OpenForm(DDR_Containerization, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_MethodsEngineering_Database_Conduits_mi_Click(sender As Object, e As EventArgs) Handles Main_MethodsEngineering_Database_Conduits_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT [Board] AS Tablero,[Material] AS Arnes,MSpec,[Length] AS Longitud,[Pieces] AS [Veces Por],[Rack],[Location] AS [Local] FROM ME_ConduitLengths", {"Tablero", "Arnes", "MSpec", "Longitud", "Rack", "Local"}, True, True, ""))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub Main_Receiving_Management_DownloadLanes_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_DownloadLanes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(SQL.Current.ConnectionString)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table(CType(sender, ToolStripMenuItem).Text, "SELECT Warehouse AS Estacion,Lane AS Linea FROM Rec_DownloadLanes", {"Estacion", "Linea"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Estacion", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        OpenFormByRef(db_table, CType(sender, ToolStripMenuItem).Name, CType(sender, ToolStripMenuItem).Image, CType(sender, ToolStripMenuItem).Text)
    End Sub
End Class
