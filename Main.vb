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
        If User.Current.OnDomain Then
            Me.ControlBox = False
            AD_bwkr.RunWorkerAsync()
        Else
            Me.ControlBox = True
        End If
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
        Main_Engineering_Reports_Errors_mi.Text = Language.Sentence(120)
        Main_Engineering_Reports_Workload_mi.Text = Language.Sentence(121)
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
        If DateDiff(DateInterval.Minute, SQL.Current.LastUse, Now) >= 30 Then
            Session_timer.Stop()
            MessageBox.Show(Language.Sentence(86), Language.Sentence(87), MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
    Private Sub bwAD_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles AD_bwkr.DoWork
        UserToolStripStatusLabel.Text = User.Current.Properties("name")
        Me.ControlBox = True
    End Sub

    Private Sub bwAD_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles AD_bwkr.RunWorkerCompleted

    End Sub

#End Region
#Region "Functions"
    Private Sub EnableMenu()
        For Each item As ToolStripMenuItem In CType(MenuStripMain.Items("DeltaStartButton"), ToolStripDropDownButton).DropDownItems
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
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("MRP Controllers", "SELECT * FROM Sch_MRPControllers ORDER BY MRP", {"MRP"}, User.Current.HasPermission("Database_Sch_MRPControllers_Add"), User.Current.HasPermission("Database_Sch_MRPControllers_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Username", SQL.Current.GetDatatable("SELECT Username,FullName FROM Sys_Users WHERE Area IN ('Scheduling','Program Readiness') AND Role = 'Scheduler' ORDER BY FullName"), "FullName", "Username"))
        db_table.Show()
    End Sub
    Private Sub FamiliesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Families_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Families", "SELECT * FROM Sch_Families ORDER BY Family", {"Family"}, User.Current.HasPermission("Database_Sch_Families_Add"), User.Current.HasPermission("Database_Sch_Families_Delete")))
        db_table.Show()
    End Sub
    Private Sub BusinessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Business_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Business", "SELECT * FROM Sch_Business ORDER BY Business,Family", {"Business", "Family"}, User.Current.HasPermission("Database_Sch_Business_Add"), User.Current.HasPermission("Database_Sch_Business_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Family", SQL.Current.GetList("SELECT Family FROM Sch_Families ORDER BY Family").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("MRP", SQL.Current.GetList("SELECT MRP FROM Sch_MRPControllers ORDER BY MRP").ToArray))
        db_table.Show()
    End Sub
    Private Sub MaterialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_MaterialNumbers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Material Numbers", "SELECT * FROM Sch_Materials ORDER BY Material", {"Material"}, User.Current.HasPermission("Database_Sch_Materials_Add"), User.Current.HasPermission("Database_Sch_Materials_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("ProductionPlanMode", "D", "W"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Business", SQL.Current.GetList("SELECT Business FROM Sch_Business ORDER BY Business").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Class", SQL.Current.GetList("SELECT Class FROM Sch_MaterialClasses ORDER BY Class").ToArray))
        db_table.tables(0).OnlyDateFormatColumns.AddRange({"StartProduction", "EndProduction"})
        db_table.Show()
    End Sub
    Private Sub BoardsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Boards_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Boards", "SELECT * FROM Mfg_Boards ORDER BY Board", {"Board"}, User.Current.HasPermission("Database_Mfg_Boards_Add"), User.Current.HasPermission("Database_Mfg_Boards_Delete")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Class", SQL.Current.GetList("SELECT Class FROM Mfg_BoardClasses ORDER BY Class").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Volume", SQL.Current.GetList("SELECT Volume FROM Mfg_Volumes ORDER BY Volume").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("ShiftCombination", SQL.Current.GetList("SELECT Combination FROM Sys_ShiftCombination ORDER BY Combination").ToArray))
        db_table.Show()
    End Sub
    Private Sub MaterialBoardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_MaterialBoard_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Material-Board", "SELECT * FROM Sch_MaterialBoards ORDER BY Material,Board", {"Material", "Board"}, User.Current.HasPermission("Database_Sch_MaterialBoards_Add"), User.Current.HasPermission("Database_Sch_MaterialBoards_Delete")))
        db_table.Show()
    End Sub
    Private Sub ControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_1719Controls_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("17/19 Controls", "SELECT * FROM Eng_1719Controls ORDER BY Material", {"Material"}, User.Current.HasPermission("Database_Eng_1719Controls_Add"), User.Current.HasPermission("Database_Eng_1719Controls_Delete")))
        db_table.Show()
    End Sub
    Private Sub HeadcountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_Headcount_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Headcount", "SELECT * FROM Mfg_Headcount ORDER BY Family,Shift", {"Family", "Shift"}, User.Current.HasPermission("Database_Mfg_Headcount_Add"), User.Current.HasPermission("Database_Mfg_Headcount_Add")))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Family", SQL.Current.GetList("SELECT Family FROM Sch_Families ORDER BY Family").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Shift", SQL.Current.GetList("SELECT Shift FROM Sys_Shifts ORDER BY Shift").ToArray))
        db_table.Show()
    End Sub
    Private Sub Main_Scheduling_Database_ContractedCapacity_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_ContractedCapacity_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Contracted Capacity", "SELECT * FROM Sch_ContractedCapacity_tmp ORDER BY BoardCode,Material", {"BoardCode", "Material"}, User.Current.HasPermission("Database_Sch_ContractedCapacity_tmp_Add"), User.Current.HasPermission("Database_Sch_ContractedCapacity_tmp_Delete")))
        db_table.Show()
    End Sub

    Private Sub Main_Scheduling_Database_ShippingDays_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Database_ShippingDays_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Shipping Days", "SELECT * FROM Sch_ShippingDays ORDER BY Family", {"Family"}, User.Current.HasPermission("Database_Sch_ShippingDays_Add"), User.Current.HasPermission("Database_Sch_ShippingDays_Delete")))
        db_table.Show()
    End Sub
#End Region
#Region "SAP"
    Private Sub Main_Scheduling_SAP_ZVT11_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ZMDESNR_mi.Click
        'DownloadZVT11()
        DownloadZMDESNR()
    End Sub
    Private Sub Main_Scheduling_SAP_VL10_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_VL10_mi.Click
        DownloadVL10()
    End Sub
    Private Sub Main_Scheduling_SAP_Inventory_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_Inventory_mi.Click
        DownloadCurrentInventory()
    End Sub
    Private Sub Main_Scheduling_SAP_ProductionPlan_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ProductionPlanExport_mi.Click
        OpenForm(Sch_CSVProductionPlanOptionsDialog)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Scheduling_Reports_VL10_Variations_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Variations_mi.Click
        OpenForm(Sch_VL10Variations)
    End Sub

    Private Sub Main_Scheduling_Reports_VL10_Capacity_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Capacity_mi.Click
        OpenForm(Sch_VL10VsCapacityReport)
    End Sub

    Private Sub Main_Scheduling_Reports_VL10_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Headcount_mi.Click
        OpenForm(Sch_VL10HeadcountReport)
    End Sub

    Private Sub Main_Scheduling_Reports_ProductionPlan_Headcount_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_ProductionPlan_Headcount_mi.Click
        OpenForm(Sch_ProductionPlanHeadcountReport)
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
        OpenForm(Sch_UploadWaterfallReport)
    End Sub
#End Region
#Region "ProductionPlan"
    Private Sub Main_Scheduling_ProductionPlan_Low_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ProductionPlan_Low_mi.Click
        OpenForm(Sch_ProductionPlanDailyLow)
    End Sub
    Private Sub Main_Scheduling_ProductionPlan_High_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_ProductionPlan_High_mi.Click
        OpenForm(Sch_ProductionPlanDailyHighVolume)
    End Sub
#End Region
#Region "Functions"
    Private Sub DownloadVL10()
        If Not SQL.Current.Exists("SELECT TOP 1 ID FROM Sch_VL10 WHERE DATEPART(WK, DownloadDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY, DownloadDate) = DATEPART(YY,GETDATE())") Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath

                If sap_session.VL10(Parameter("SCH_ShippingPoint"), CurrentDate.AddDays(16 * 7), filename) Then
                    Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False)
                    TryDelete(filename)
                    If txt IsNot Nothing Then
                        txt.DefaultView.RowFilter = String.Format("[Plnt] = '{0}'", Parameter("SYS_PlantCode"))
                        txt.Columns.Add("New_DD", GetType(Date), "Convert(IIF([Deliv.Date] = '',[Deliv.Date_1],[Deliv.Date]),'System.DateTime')")
                        txt.Columns.Add("New_OQ", GetType(Integer), "IIF(Convert([Dlv.qty],'System.Double') = 0, Convert([Open qty],'System.Double'), Convert([Dlv.qty],'System.Double'))")
                        Dim vl10 = txt.DefaultView.ToTable(False, "Material", "Cust.material", "OriginDoc.", "Document", "Description", "Name 1", "Ship-to", "New_DD", "New_OQ")
                        If SQL.Current.Bulk(vl10, "Sch_VL10") Then
                            SQL.Current.Execute("INSERT INTO Sch_Business (Family,Business,MRP) Select DISTINCT 'Unclassified',V.BusinessName,'None' " & _
                                                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL")
                            SQL.Current.Execute("INSERT INTO Sch_Materials (Material,CustomerPN,[Description],Business,StdPack,StartProduction,EndProduction,Class) " & _
                                                "SELECT V.Material,MIN(V.CustomerMaterial),MIN(V.[Description]),MIN(V.BusinessName),1,'1900-01-01','2099-12-31','NO CLASS' " & _
                                                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL " & _
                                                "GROUP BY V.Material")
                            LoadingScreen.Hide()
                            MsgBox("VL10 actualizada correctamente!", MsgBoxStyle.Information, APP)
                        Else
                            LoadingScreen.Hide()
                            MsgBox("Error en bulk de VL10.", MsgBoxStyle.Critical, APP)
                        End If
                    Else
                        LoadingScreen.Hide()
                        MsgBox("Error al leer el archivo.", MsgBoxStyle.Critical, APP)
                    End If
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar la VL10.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Sesion de SAP no encontrada.", MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("VL10 ya se encuentra actualizada.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub DownloadCurrentInventory()
        If Not SQL.Current.Exists("SELECT TOP 1 Material FROM Sch_CurrentInventory WHERE DATEPART(WK, UpdatedDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY, UpdatedDate) = DATEPART(YY,GETDATE())") Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim plncd As String = Parameter("SYS_PlantCode")
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_WHR_DATA(Parameter("SCH_WarehouseNumber"), plncd, filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 2)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.Columns.Add("TOTALSTOCK_INT", GetType(Integer), "Convert([TOTALSTOCK],'System.Double')")
                            txt.DefaultView.RowFilter = String.Format("[PLNT] = '{0}'", plncd)
                            Dim inventory = txt.DefaultView.ToTable(False, "MATERIAL", "TOTALSTOCK_INT", "STY", "STORAGEBIN")
                            If SQL.Current.Bulk(inventory, "Sch_CurrentInventory") Then
                                SQL.Current.Execute("DELETE FROM Sch_CurrentInventory WHERE UpdatedDate < (SELECT MAX(UpdatedDate) FROM Sch_CurrentInventory)")
                                LoadingScreen.Hide()
                                MsgBox("Inventory actualizado correctamente.", MsgBoxStyle.Information, APP)
                            Else
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        Else
                            LoadingScreen.Hide()
                            MsgBox("Error al leer el archivo.", MsgBoxStyle.Critical, APP)
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar el Inventario.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar el Inventario.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Sesion de SAP no encontrada.", MsgBoxStyle.Critical, APP)
            End If
        Else
            MsgBox("Inventario ya se encuentra actualizado.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub DownloadZVT11()
        If Not SQL.Current.Exists("SELECT TOP 1 Material FROM Sch_ZVT11 WHERE DATEPART(WK, [Date]) = DATEPART(WK,DATEADD(DD,-7,GETDATE())) AND DATEPART(YY, [Date]) = DATEPART(YY,DATEADD(DD,-7,GETDATE()))") Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap_session.ZVT11(Parameter("SCH_ShippingPoint"), LastMonday.AddDays(-7), LastMonday.AddDays(-1), filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 7)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.DefaultView.RowFilter = String.Format("[Plnt] = '{0}'", Parameter("SYS_PlantCode"))
                            txt.Columns.Add("Quantity_Int", GetType(Integer), "Convert([Quantity],'System.Double')")
                            txt.Columns.Add("Monday", GetType(Date), String.Format("Convert('{0}','System.DateTime')", LastMonday.AddDays(-7).ToShortDateString))
                            Dim ZVT11 = txt.DefaultView.ToTable(False, "Material", "Customer", "Quantity_Int", "Sold-to", "Delivery", "Monday")
                            If SQL.Current.Bulk(ZVT11, "Sch_ZVT11") Then
                                LoadingScreen.Hide()
                                MsgBox("ZVT11 actualizada correctamente!", MsgBoxStyle.Information, APP)
                            Else
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar ZTV11.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar ZTV11.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Sesion de SAP no encontrada.", MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("ZTV11 ya se encuentrada actualizada.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub DownloadZMDESNR()
        Dim lastday As Date = SQL.Current.GetDate("SELECT MAX([Date]) FROM Sch_ZMDESNR")
        If lastday.AddDays(1).Date < CurrentDate.Date Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap_session.ZMDESNR(Parameter("SYS_PlantCode"), "SHP", lastday.AddDays(1), CurrentDate.AddDays(-1), filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 5)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.DefaultView.RowFilter = "[MvT] = 'Z11'"
                            Dim zmdesnr_ph1 = txt.DefaultView.ToTable(False, "Material", "Quantity", "LM Serial", "Delivery", "Ship-to", "Created on")
                            zmdesnr_ph1.Columns.Add("Quantity_Int", GetType(Integer), "Convert(Convert([Quantity],'System.Double'),'System.Int32')")
                            If SQL.Current.Bulk(zmdesnr_ph1.DefaultView.ToTable(False, "Material", "Quantity_Int", "LM Serial", "Delivery", "Ship-to", "Created on"), "Sch_ZMDESNR") Then
                                LoadingScreen.Hide()
                                MsgBox("ZMDESNR actualizada correctamente!", MsgBoxStyle.Information, APP)
                            Else
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar ZMDESNR.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar ZMDESNR.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Sesion de SAP no encontrada.", MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("ZMDESNR ya se encuentra actualizada.")
        End If
    End Sub
    Private Sub Main_Scheduling_SAP_PrintLabels_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_PrintLabels_mi.Click
        OpenForm(Sch_SchedulingPrintLabels)
    End Sub
    Private Sub Main_Scheduling_SAP_ProductionPlanImport_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_SAP_ProductionPlanImport_mi.Click
        OpenForm(Sch_UploadDateRangeSelector)
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
        db_bom.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_bom.MdiParent = Me
        db_bom.tables.Add(New DatabaseEditor.Table("Material Leadcodes", "SELECT * FROM PE_MaterialLeadcodes ORDER BY Material,Leadcode", {"Material", "Leadcode"}, True, True, ""))
        db_bom.Show()
    End Sub
    Private Sub Main_Engineering_Database_Leadcodes_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Leadcodes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode Locations", "SELECT * FROM PE_LeadcodeLocations ORDER BY Leadcode,Rack,Level,Rail", {"Leadcode", "Rack", "Level", "Rail"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode Master", "SELECT * FROM PE_Leadcodes ORDER BY Leadcode", {"Leadcode"}, True, True))
        db_table.Show()
    End Sub
    Private Sub Main_Engineering_Database_Cutters_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Cutters_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Cutters Master", "SELECT * FROM PE_Cutters ORDER BY ID", {"ID"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Leadcode-Cutter Relation", "SELECT * FROM PE_LeadcodeCutters ORDER BY Leadcode,CutterID", {"Leadcode", "CutterID"}, True, True))
        db_table.Show()
    End Sub
    Private Sub Main_Engineering_Database_RawMaterial_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_RawMaterial_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("MSpecs Master", "SELECT * FROM PE_MSpecs ORDER BY MSpec", {"MSpec"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Terminals Master", "SELECT * FROM PE_Terminals ORDER BY Terminal,Gage", {"Terminal", "Gage"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Seals Master", "SELECT * FROM PE_Seals ORDER BY Seal", {"Seal"}, True, True))
        db_table.Show()
    End Sub
    Private Sub Main_Engineering_Database_Others_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Database_Others_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Colors", "SELECT * FROM PE_Colors ORDER BY Name", {"TW_ShortName"}, True, True))
        db_table.tables.Add(New DatabaseEditor.Table("Setup Times", "SELECT * FROM PE_Setups ORDER BY Type", {"Type"}, True, True))
        db_table.Show()
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Engineering_Reports_Errors_mi_Click(sender As Object, e As EventArgs) Handles Main_Engineering_Reports_Errors_mi.Click
        OpenForm(ErrorReportViewer)
    End Sub
#End Region
#End Region

#Region "Administrator"
#Region "Users"

    Private Sub Main_Administrator_Users_Management_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Management_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Usuarios", "SELECT [Username],[FirstName],[LastName],[Email],[Role],[Area],[Badge],[Password],[IsAdministrator],[OnDomain],[Active],[Language] FROM Sys_Users ORDER BY Firstname,Lastname", {"Username"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Area", {"Customer Service", "Management", "Material Analyst", "Ordering", "Process Engineering", "Program Readiness", "Public", "Scheduling", "Systems", "Supermarket", "Receiving", "ComponentDeliveryRoutes"}))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Role", SQL.Current.GetList("SELECT Role FROM Sys_UserRoles ORDER BY Role").ToArray))
        db_table.Show()
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
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Working Dates", "SELECT * FROM Sys_Calendar WHERE Date >= DATEADD(D,-7,GETDATE()) ORDER BY Date", {"Date"}, True, True))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("WorkingShifts", SQL.Current.GetList("SELECT Combination FROM Sys_ShiftCombination").ToArray))
        db_table.tables(0).OnlyDateFormatColumns.Add("Date")
        db_table.Show()
    End Sub
    Private Sub ParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_Parameters_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Parameters", "SELECT * FROM Sys_Parameters ORDER BY [Parameter]", {"Parameter"}, True, True, ""))
        db_table.Show()
    End Sub
    Private Sub Main_Administrator_Database_RawMaterial_Update_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_Update_mi.Click
        Dim sap As New SAP
        If sap.Available Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempTXTPath
            If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(Parameter("SYS_PlantCode"), filename, "*", "*") Then
                Dim txt = CSV.Datatable(filename, vbTab, True, False)
                If txt IsNot Nothing Then
                    txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L' AND (PROC_TYPE = 'F' OR (PROC_TYPE = 'E' AND [DESCRIPTION] LIKE '%TERM%'))))"
                    txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                    txt.Columns.Add("DBL_RV", GetType(String), "Convert([ROUNDING_VALUE],'System.Double')")
                    txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")
                    Dim mrps As DataTable = txt.DefaultView.ToTable(True, "MRP_CONTROLLER")
                    SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Ord_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'public');")
                    Dim bulk_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER")
                    If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](150) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[UnitCost] [decimal](10, 7) NOT NULL,[MRP] [varchar](5))", "MERGE Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Description] = source.[Description],RoundingValue = source.RoundingValue,UnitCost = source.UnitCost,target.MRP = source.MRP, target.UoM = source.UoM WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],UoM,RoundingValue,UnitCost,MRP,OrderUnit) VALUES (source.Partnumber,source.[Description],source.UoM,source.RoundingValue,source.UnitCost,source.MRP,source.UoM);") Then
                        LoadingScreen.Hide()
                        FlashAlerts.ShowConfirm("Hecho!")
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
                FlashAlerts.ShowError("Error al descargar la informacion.")
            End If
        Else
            FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
        End If
    End Sub
    Private Sub Main_Administrator_Users_Permissions_Clone_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Permissions_Clone_mi.Click
        OpenForm(ClonePermissionsFrom)
    End Sub
#End Region

#Region "General"
    Private Sub OpenForm(new_form As Object, Optional mdi_parent As Boolean = True)
        Dim form As Form = Nothing
        For Each f As Form In Application.OpenForms
            If f.GetType() Is new_form.GetType() Then
                form = f
                Exit For
            End If
        Next
        If IsNothing(form) Then
            form = Activator.CreateInstance(new_form.GetType)
            If mdi_parent Then
                form.MdiParent = Me
            End If
            form.Show()
        Else
            If form.WindowState = FormWindowState.Minimized Then form.WindowState = FormWindowState.Normal
            form.BringToFront()
            If form.CanFocus() Then form.Focus()
        End If
    End Sub
    Private Sub Main_About_mi_Click(sender As Object, e As EventArgs) Handles Main_About_mi.Click
        AboutBox.ShowDialog()
    End Sub
#End Region

#Region "Leadprep"
    Private Sub Main_Leadprep_Miscellaneous_Labels_mi_Click(sender As Object, e As EventArgs) Handles Main_Leadprep_Miscellaneous_Labels_mi.Click
        OpenForm(BagLabelPrinter)
    End Sub
#End Region

#Region "Ordering"
#Region "Mover"
    Private Sub Main_Ordering_Supermarket_Mover_New_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_New_mi.Click
        OpenForm(Ord_NewMover)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Cancel_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Cancel_mi.Click
        OpenForm(Ord_CancelMover)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Print_mi.Click
        OpenForm(Ord_PrintMover)
    End Sub

    Private Sub Main_Ordering_Supermarket_Mover_Approve_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_Mover_Approve_mi.Click
        OpenForm(Ord_ApproveMover)
    End Sub

#End Region
#Region "Reports"
    Private Sub Main_Ordering_Reports_ABCAnalysis_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_ABCAnalysis_mi.Click
        OpenForm(Ord_ABC)
    End Sub
    Private Sub Main_Ordering_Reports_Forecast_StockVsForecast_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_ForecastVsRealConsumption_mi.Click
        OpenForm(Ord_ForecastVsZapimatinfo)
    End Sub
    Private Sub Main_Ordering_Reports_Forecast_Waterfall_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_Waterfall_mi.Click
        OpenForm(Ord_ForecastWaterfall)
    End Sub
    Private Sub Main_Ordering_Reports_MB51_261vsZ11_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_MB51_261vsZ11_mi.Click
        OpenForm(MB51_261VsZ11)
    End Sub
#End Region
#Region "Database"
    Private Sub Main_Ordering_Database_MRPControllers_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Management_MRPControllers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("MRP Controllers", "SELECT MRP,Username AS Usuario FROM Ord_MRPControllers ORDER BY Username", {"MRP"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Usuario", SQL.Current.GetDatatable("SELECT Username,FullName FROM Sys_Users WHERE Area IN ('Ordering','Component Readiness') AND Role = 'MRPController' UNION ALL SELECT 'deltaerp','DeltaERP' ORDER BY FullName"), "FullName", "Username"))
        db_table.Show()
    End Sub
#End Region
    Private Sub Main_Ordering_Receiving_ReportCritical_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Receiving_ReportCritical_mi.Click
        OpenForm(Ord_ReportCriticalToReceiving)
    End Sub
#End Region

#Region "MaterialAnalyst"
    Private Sub Main_MaterialAnalyst_SAP_MB51_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_SAP_MB51_mi.Click
        OpenForm(DownloadMB51)
    End Sub
    Private Sub Main_MaterialAnalyst_Reports_MB51_261vsZ11_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_MB51_261vsZ11_mi.Click
        OpenForm(MB51_261VsZ11)
    End Sub
#End Region

#Region "Supermarket"
#Region "Components"
    Private Sub Main_Supermarket_Components_Store_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Store_mi.Click
        OpenForm(Smk_StoreSerial)
    End Sub
    Private Sub Main_Supermarket_Components_Open_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Open_mi.Click
        OpenForm(Smk_OpenSerial)
    End Sub
    Private Sub Main_Supermarket_Components_Find_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_Find_mi.Click
        OpenForm(Smk_FindSerial)
    End Sub
    Private Sub Main_Supermarket_Components_LocationChange_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_LocationChange_mi.Click
        OpenForm(Smk_ChangeLocation)
    End Sub
    Private Sub Main_Supermarket_Components_PartialDiscount_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_PartialDiscount_mi.Click
        OpenForm(Smk_PartialDiscount)
    End Sub
    Private Sub Main_Supermarket_Components_DeclareEmpty_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_DeclareEmpty_mi.Click
        OpenForm(Smk_DeclareEmpty)
    End Sub
    Private Sub Main_Supermarket_Management_PostTransfers_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_PostTransfers_mi.Click
        OpenForm(Smk_SAPTransfers)
    End Sub
    Private Sub Main_Supermarket_Components_ManualAdjustment_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_ManualAdjustment_mi.Click
        OpenForm(Smk_ManualAdjustment)
    End Sub

    Private Sub Main_Supermarket_Components_ReactiveSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Components_ReactiveSerial_mi.Click
        OpenForm(Smk_ReactiveSerial)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Supermarket_Components_Reports_BrokenFIFO_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Smk_BrokenFIFO)
    End Sub
    Private Sub Main_Supermarket_Components_Reports_Audit_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_Audit_mi.Click
        OpenForm(Smk_SimpleAudit)
    End Sub
    Private Sub Main_Supermarket_Components_Reports_SAPVsDelta_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_SAPVsDelta_mi.Click
        OpenForm(Smk_SAPVsDelta)
    End Sub
    Private Sub Main_Supermarket_Components_Reports_MaterialExpired_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_MaterialExpired_mi.Click
        LoadingScreen.Show()
        Dim srv As New SingleReportViewer
        srv.MdiParent = Me
        srv.DataSource = SQL.Current.GetDatatable("SELECT Serialnumber AS Serie,Partnumber AS [Numero de Parte],CurrentQuantity AS Cantidad,UoM AS Unidad,StatusDescription AS Estatus,Location AS Localizacion,WarehouseName AS Estacion,ExpirationDate AS [Fecha de Expiracion],DATEDIFF(DAY,GETDATE(),ExpirationDate) AS [Dias Restantes],CASE WHEN DATEDIFF(DAY,GETDATE(),ExpirationDate) <= 0 THEN 'Expirado' ELSE 'Vigente' END AS Estado FROM vw_Smk_Serials WHERE ExpirationDate IS NOT NULL AND [Status] IN ('S','O','C') ORDER BY DATEDIFF(DAY,GETDATE(),ExpirationDate)", "Material Expirable")
        srv.Title = "Material con Fecha de Expiracion"
        srv.Show()
        LoadingScreen.Hide()
    End Sub

#End Region
#Region "Mover"
    Private Sub Main_Supermarket_Mover_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Mover_Print_mi.Click
        OpenForm(Smk_PrintMover)
    End Sub
#End Region
#Region "Database"
    Private Sub Main_Supermarket_Database_MaterialMaster_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_MaterialMaster_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Partnumbers", "SELECT * FROM Sys_RawMaterial WHERE MaterialType <> 'Harness'", {"Partnumber"}, False, False, ""))
        db_table.tables(0).ReadOnlyColumns.Add("Partnumber")
        db_table.tables(0).ReadOnlyColumns.Add("Description")
        db_table.tables(0).ReadOnlyColumns.Add("UoM")
        db_table.tables(0).ReadOnlyColumns.Add("RoundingValue")
        db_table.tables(0).ReadOnlyColumns.Add("UnitCost")
        db_table.tables(0).ReadOnlyColumns.Add("MRP")
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("MaterialType", {"Component", "Cable", "Tube", "Terminal", "Conduit", "Tape"}))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("ConsumptionType", {"Total", "Partial", "Mixed"}))
        db_table.Show()
    End Sub

    Private Sub Main_Supermarket_Database_Map_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Map_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Map", "SELECT * FROM Smk_Map", {"Partnumber", "Warehouse"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT [Name],Warehouse FROM Smk_Warehouses"), "Name", "Warehouse"))
        db_table.Show()
    End Sub

    Private Sub Main_Supermarket_Database_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_Operators_mi.Click
        OpenForm(SMK_Operators)
    End Sub

#End Region



#End Region

#Region "MyAccount"
    Private Sub Main_MyAccount_Profile_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Profile_mi.Click
        OpenForm(Profile)
    End Sub

#End Region

#Region "ComponentDeliveryRoutes"
    Private Sub Main_ComponentDeliveryRoutes_Checkpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Checkpoint_mi.Click
        If User.Current.IsAdmin OrElse SQL.Current.Exists("CDR_AuthorizedCheckpoints", {"MachineName"}, {Environment.MachineName}) Then
            OpenForm(CDR_Checkpoint, False)
        Else
            FlashAlerts.ShowError("Checkpoint no autorizado.")
        End If
    End Sub
#Region "Database"
    Private Sub Main_ComponentDeliveryRoutes_Management_Routes_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Routes_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Routes", "SELECT * FROM CDR_Routes", {"Route"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Shift", SQL.Current.GetList("SELECT Shift FROM Sys_Shifts ORDER BY Shift").ToArray))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Operator", SQL.Current.GetDatatable("SELECT Badge, FullName FROM Smk_Operators WHERE Area = 'CDR' ORDER BY FullName"), "FullName", "Badge"))
        db_table.tables(0).LimitedColumns.Add(New DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        db_table.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Containerization_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Containerization_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Containerization", "SELECT * FROM CDR_Containerization", {"Partnumber"}, True, True, ""))
        db_table.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Engineering_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Engineering_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Engineering", "SELECT * FROM CDR_Engineering", {"Board", "Kit", "Partnumber"}, True, True, ""))
        db_table.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_ProductionControl_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_ProductionControl_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Production Control", "SELECT * FROM CDR_ProductionControl", {"Board", "Material"}, True, True, ""))
        db_table.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Business_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Business_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Business", "SELECT * FROM CDR_Business", {"Business"}, True, True, ""))
        db_table.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Database_Kanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Database_Kanbans_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Kanbans", "SELECT * FROM CDR_Kanbans", {"ID"}, True, True, ""))
        db_table.tables(0).ReadOnlyColumns = New ArrayList({"Code"})
        db_table.Show()
    End Sub
#End Region
#Region "Management"
    Private Sub Main_ComponenteDeliveryRoutes_Management_Operators_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Operators_mi.Click
        OpenForm(CDR_Operators)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Kanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Kanbans_mi.Click
        OpenForm(CDR_Kanbans)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Print_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Print_mi.Click
        OpenForm(CDR_KanbanPrint)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_Workload_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Workload_mi.Click
        OpenForm(CDR_Workload)
    End Sub
#End Region
#Region "Reportes"
    Private Sub Main_ComponentDeliveryRoutes_Management_EngineeringVsZCS12_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_EngineeringVsZCS12_mi.Click
        OpenForm(CDR_EngineeringVsZCS12)
    End Sub
#End Region
#End Region

#Region "CustomerService"
    Private Sub Main_CustomerService_Tools_SAP_VA32_mi_Click(sender As Object, e As EventArgs) Handles Main_CustomerService_Tools_SAP_VA32_mi.Click
        OpenForm(VA32_DeliveryCorrection)
    End Sub
#End Region

#Region "Receiving"
#Region "Labels"
    Private Sub Main_Receiving_Labeling_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labeling_mi.Click
        OpenForm(Rec_Labeling)
    End Sub
    Private Sub Main_Receiving_Labels_New_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_New_mi.Click
        OpenForm(Rec_NewSerial)
    End Sub
    Private Sub Main_Receiving_Labels_Reprint_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_Reprint_mi.Click
        OpenForm(Rec_ReprintLabel)
    End Sub
    Private Sub Main_Receiving_Labels_Delete_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Labels_Delete_mi.Click
        OpenForm(Rec_DeleteLabel)
    End Sub
#End Region
#Region "Reports"
    Private Sub Main_Receiving_Reports_History_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Rec_SerialHistory)
    End Sub
    Private Sub Main_Receiving_Reports_ScanningVsMB51_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_ScanningVsMB51_mi.Click
        OpenForm(Rec_SMSVsMB51)
    End Sub
    Private Sub Main_Scheduling_Reports_VL10_Waterfall_mi_Click(sender As Object, e As EventArgs) Handles Main_Scheduling_Reports_VL10_Waterfall_mi.Click
        OpenForm(Sch_VL10WaterfallReport)
    End Sub
#End Region
#Region "Management"
    Private Sub Main_Receiving_Management_Alerts_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Alerts_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Alerts", "SELECT Partnumber,Message FROM Rec_ScannerAlert", {"Partnumber"}, True, True, ""))
        db_table.Show()
    End Sub

    Private Sub Main_Receiving_Management_LabelFlags_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_LabelFlags_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Label Flags", "SELECT Partnumber,Description,LabelLegend FROM Sys_RawMaterial", {"Partnumber"}, False, False, ""))
        db_table.tables(0).ReadOnlyColumns.Add("Partnumber")
        db_table.tables(0).ReadOnlyColumns.Add("Description")
        db_table.Show()
    End Sub

    Private Sub Main_Receiving_Management_Scanners_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Management_Scanners_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Scanners", "SELECT DeviceID, Warehouse FROM Smk_ScannerRegister", {"DeviceID"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        db_table.Show()
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
        OpenForm(REC_Operators)
    End Sub

    Private Sub Main_Quality_Alerts_Add_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_New_mi.Click
        OpenForm(QLY_NewAlert)
    End Sub

    Private Sub Main_Quality_Alerts_Remove_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_Remove_mi.Click
        OpenForm(QLY_RemoveAlert)
    End Sub

    Private Sub Main_Quality_Alerts_UnlockSerialnumber_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_UnlockSerialnumber_mi.Click
        OpenForm(QLY_RemoveSerialAlert)
    End Sub


    Private Sub Main_DieCenter_PicklistCheckpoint_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PicklistCheckpoint_mi.Click
        Dim warehouse As String = SQL.Current.GetString("Warehouse", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
        If warehouse <> "" Then
            Dim cnt As Integer = SQL.Current.GetScalar("COUNT(DieCenter)", "DiC_Centers", "Warehouse", warehouse)
            If cnt = 0 Then
                FlashAlerts.ShowError(Language.Sentence(84))
                'ElseIf cnt = 1 Then
                '    OpenForm(Dic_Selector, False)
            Else
                Dim selector As New Dic_Selector
                If Not SQL.Current.GetScalar("FullScreen", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, 1) Then
                    selector.MdiParent = Me
                    selector.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                End If
                'OpenForm(Dic_Selector, Not SQL.Current.GetScalar("FullScreen", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, 1))
                selector.Show()
            End If
        Else
            FlashAlerts.ShowError(Language.Sentence(85))
        End If
    End Sub

    Private Sub Main_DieCenter_PrintPicklist_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PrintPicklist_mi.Click
        OpenForm(DiC_PrintPicklist)
    End Sub

    Private Sub Main_DieCenter_Management_Locations_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Locations_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Die Center Map", "SELECT * FROM DiC_Map", {"Partnumber", "DieCenter", "Location"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("DieCenter", SQL.Current.GetDatatable("SELECT DieCenter FROM DiC_Centers ORDER BY DieCenter"), "DieCenter", "DieCenter"))
        db_table.Show()
    End Sub

    Private Sub Main_DieCenter_Management_Centers_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Centers_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Die Centers", "SELECT * FROM DiC_Centers", {"DieCenter", "Warehouse"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        db_table.Show()
    End Sub


    Private Sub Main_Ordering_Management_ImportForecast_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Management_ImportForecast_mi.Click
        OpenForm(Ord_ImportForecast)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Checkpoints", "SELECT * FROM CDR_AuthorizedCheckpoints", {"MachineName"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        db_table.Show()
    End Sub

    Private Sub Main_DieCenter_Management_Checkpoints_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_Management_Checkpoints_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Checkpoints", "SELECT * FROM DiC_AuthorizedCheckpoints", {"MachineName"}, True, True, ""))
        db_table.tables(0).LimitedColumns.Add(New CAguilar.DatabaseEditor.Table.ComboBoxColumn("Warehouse", SQL.Current.GetDatatable("SELECT Warehouse, Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse"))
        db_table.Show()
    End Sub

    Private Sub Alerts_timer_Tick(sender As Object, e As EventArgs) Handles Alerts_timer.Tick
        RefreshAlertsButton()
    End Sub

    Private Sub RefreshAlertsButton()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        If conn.Available Then
            Dim alerts As Integer = conn.GetScalar("COUNT(ID)", "Sys_UserAlerts", {"[To]", "Active"}, {User.Current.Username, 1})
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
        End If
        conn = Nothing
    End Sub

    Private Sub Alerts_btn_Click(sender As Object, e As EventArgs)

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
        OpenForm(Smk_PickUpMoverManual)
    End Sub


    Private Sub Main_Ordering_Reports_Forecast_ForecastVsRealConsumptionAccumulated_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Forecast_ForecastVsRealConsumptionAccumulated_mi.Click
        OpenForm(Ord_ConsumptionHistory)
    End Sub

    Private Sub Main_Ordering_Reports_Critical_History_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Ord_CriticalHistory)
    End Sub

    Private Sub Main_Ordering_Reports_MinMax_History_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Ord_MixMaxHistory)
    End Sub

    Private Sub Main_Ordering_Reports_Mover_History_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Ord_MoverHistory)
    End Sub

    Private Sub Main_Ordering_Supermarket_MinMaxAlerts_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Supermarket_MinMaxAlerts_mi.Click
        OpenForm(Ord_MixMaxAlerts)
    End Sub

    Private Sub Main_Supermarket_Management_RackOwners_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_RackOwners_mi.Click
        OpenForm(Smk_RackOwners)
    End Sub

    Private Sub Alerts_nicon_Click(sender As Object, e As EventArgs) Handles Alerts_nicon.Click
        ShowAlerts()
        Alerts_nicon.Visible = False
    End Sub

    Private Sub Main_Supermarket_Reports_ActiveSerialnumbers_mi_Click(sender As Object, e As EventArgs)
        LoadingScreen.Show()
        Dim srv As New SingleReportViewer
        srv.MdiParent = Me
        srv.Title = "Series Vivas"
        srv.DataSource = SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],[Description] AS Descripcion,MaterialType AS [Tipo de Material],SerialNumber AS Serie,OriginalQuantity AS StdPack,CurrentQuantity AS [Cantidad Actual],UoM AS Unidad,Location AS [Local],StatusDescription AS Estatus,WarehouseName AS Estacion,[Date] AS [Fecha de Etiquetado],Sloc FROM vw_Smk_Serials WHERE [Status] IN ('S','O','C','Q','T','P','N','U') ORDER BY Partnumber,Warehouse,Location")
        srv.Show()
        LoadingScreen.Hide()
    End Sub

    Private Sub Main_Supermarket_Reports_MinMax_mi_Click(sender As Object, e As EventArgs)
        OpenForm(Ord_MixMaxHistory)
    End Sub

    Private Sub Main_Receiving_Reports_ScanningVsStored_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_ScanningVsStored_mi.Click
        OpenForm(Rec_LabeledVsPaid)
    End Sub

    Private Sub Main_MyAccount_Password_mi_Click(sender As Object, e As EventArgs) Handles Main_MyAccount_Password_mi.Click

    End Sub

    Private Sub Main_Administrator_Users_Crypt_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Crypt_mi.Click
        Dim nb As New EnterBox
        nb.Title = "Encriptar:"
        nb.ShowDialog()
        Clipboard.SetText(W3D.EncryptData(nb.Answer))
        FlashAlerts.ShowConfirm("Copiado a clipboard.")
    End Sub

    Private Sub Main_Supermarket_Reports_MovementHistory_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_MovementHistory_mi.Click
        OpenForm(Smk_MovementHistory)
    End Sub

    Private Sub Main_Supermarket_Management_FixAuditory_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_FixAuditory_mi.Click
        OpenForm(Smk_Audit)
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
        OpenForm(Qly_AlertsHistory)
    End Sub

    Private Sub Main_Receiving_ToQuality_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_ToQuality_mi.Click
        OpenForm(Rec_ToQuality)
    End Sub

    Private Sub Main_Receiving_ToTracker_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_ToTracker_mi.Click
        OpenForm(Rec_ToTracker)
    End Sub

    Private Sub Main_Supermarket_Ordering_ReportMissing_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Ordering_ReportMissing_mi.Click
        OpenForm(Smk_AlertMissing)
    End Sub

    Private Sub Main_Quality_Alerts_RejectSerialnumber_mi_Click(sender As Object, e As EventArgs) Handles Main_Quality_Alerts_RejectSerialnumber_mi.Click
        OpenForm(QLY_RejectSerialnumber)
    End Sub

    Private Sub Main_Supermarket_Management_FixSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_FixSerial_mi.Click
        OpenForm(Smk_FixSerialnumber)
    End Sub

    Private Sub Main_Receiving_TrackerPartialDiscount_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_PartialDiscount_mi.Click
        OpenForm(Rec_TrackerPartialDiscount)
    End Sub

    Private Sub Main_Supermarket_Management_ChooseWarehouse_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_ChooseWarehouse_mi.Click
        OpenForm(Smk_ChooseWarehouse)
    End Sub

    Private Sub Alerts_btn2_Click(sender As Object, e As EventArgs) Handles Alerts_btn.Click
        ShowAlerts()
        Alerts_btn.Visible = False
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Management_GenericKanbans_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Management_GenericKanbans_mi.Click
        Dim db_table As New DatabaseEditor
        db_table.SetConnectionString(My.Settings.DataSource, My.Settings.Database, My.Settings.UID, My.Settings.Password)
        db_table.MdiParent = Me
        db_table.tables.Add(New DatabaseEditor.Table("Kanbans Genericas", "SELECT ID,[partnumber] AS [No. de Parte],[board] AS Tablero,[description] AS Descripcion,Kit,[business] AS Negocio,[comment] AS Comentario,Rack,[local] AS [Localizacion] FROM CDR_Kanbans WHERE ID > 505420 AND [engLoc]  IS NULL AND slot IS NULL", {""}, True, True, ""))
        db_table.tables(0).InvisibleColumns = New ArrayList({"ID"})
        db_table.Show()
    End Sub

    Private Sub Main_Shipping_Mover_Ship_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Mover_Ship_mi.Click
        OpenForm(Shi_ShipMover)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_MissingHistory_mi_Click(sender As Object, e As EventArgs)
        OpenForm(CDR_MissingHistory)
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_ScanningHistory_mi_Click(sender As Object, e As EventArgs)
        OpenForm(CDR_ScanningHistory)
    End Sub

    Private Sub Main_DieCenter_PicklistManual_mi_Click(sender As Object, e As EventArgs) Handles Main_DieCenter_PicklistManual_mi.Click
        OpenForm(DiC_AskManual)
    End Sub

    Private Sub Main_Administrator_Database_RawMaterial_UpdateList_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Database_RawMaterial_UpdateList_mi.Click
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

                            Dim all_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER")
                            Dim bulk_data As New DataTable
                            bulk_data.Columns.Add("RT_MATERIAL")
                            bulk_data.Columns.Add("DESCRIPTION")
                            bulk_data.Columns.Add("BUM")
                            bulk_data.Columns.Add("DBL_RV", GetType(Double))
                            bulk_data.Columns.Add("UNIT_PRICE", GetType(Decimal))
                            bulk_data.Columns.Add("MRP_CONTROLLER")

                            bulk_data.Merge(all_data.DefaultView.ToTable(True, "RT_MATERIAL"))
                            For Each row As DataRow In bulk_data.Rows
                                Dim rows = all_data.Select(String.Format("RT_MATERIAL = '{0}'", row.Item("RT_MATERIAL")))
                                row.Item("DESCRIPTION") = rows(0).Item("DESCRIPTION")
                                row.Item("BUM") = rows(0).Item("BUM")
                                row.Item("DBL_RV") = rows(0).Item("DBL_RV")
                                row.Item("UNIT_PRICE") = rows(0).Item("UNIT_PRICE")
                                row.Item("MRP_CONTROLLER") = rows(0).Item("MRP_CONTROLLER")
                            Next

                            Dim mrps As DataTable = bulk_data.DefaultView.ToTable(True, "MRP_CONTROLLER")
                            SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Ord_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")

                            If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](150) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[UnitCost] [decimal](10, 7) NOT NULL,[MRP] [varchar](5))", "MERGE Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Description] = source.[Description],RoundingValue = source.RoundingValue,UnitCost = source.UnitCost,target.MRP = source.MRP, target.UoM = source.UoM WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],UoM,RoundingValue,UnitCost,MRP) VALUES (source.Partnumber,source.[Description],source.UoM,source.RoundingValue,source.UnitCost,source.MRP);") Then
                                LoadingScreen.Hide()
                                FlashAlerts.ShowConfirm("Hecho!")
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
                        FlashAlerts.ShowError("Error al descargar la informacion.")
                    End If
                Else
                    FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
                End If
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Main_Receiving_TrackerToService_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Tracker_ToService_mi.Click
        OpenForm(Rec_TrackerToService)
    End Sub

    Private Sub Main_Supermarket_Kiosk_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Kiosk_mi.Click
        OpenForm(Smk_Kiosk)
    End Sub

    Private Sub Main_MaterialAnalyst_Reports_InVsOut_mi_Click(sender As Object, e As EventArgs) Handles Main_MaterialAnalyst_Reports_InVsOut_mi.Click
        OpenForm(MAn_ConsumptionHistory)
    End Sub

    Private Sub Main_ComponentReadiness_Reports_ForecastVs261Cost_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Reports_ForecastVs261Cost_mi.Click
        OpenForm(ForecastVs261)
    End Sub

    Private Sub Main_ComponentReadiness_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentReadiness_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "CR"
        reporter.Show()
    End Sub

    Private Sub Main_Supermarket_Management_NewSerial_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Management_NewSerial_mi.Click
        OpenForm(Smk_NewSerial)
    End Sub

    Private Sub Main_Supermarket_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Supermarket_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "SMK"
        reporter.Show()
    End Sub

    Private Sub Main_Ordering_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Ordering_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "ORD"
        reporter.Show()
    End Sub

    Private Sub Main_Receiving_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Receiving_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "REC"
        reporter.Show()
    End Sub

    Private Sub Main_ComponentDeliveryRoutes_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_ComponentDeliveryRoutes_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "CDR"
        reporter.Show()
    End Sub

    Private Sub Main_Administrator_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "ADM"
        reporter.Show()
    End Sub

    Private Sub Main_Administrator_Users_Permissions_Management_mi_Click(sender As Object, e As EventArgs) Handles Main_Administrator_Users_Permissions_Management_mi.Click
        OpenForm(UserRights)
    End Sub

    Private Sub Main_Shipping_Reports_Reporter_mi_Click(sender As Object, e As EventArgs) Handles Main_Shipping_Reports_Reporter_mi.Click
        Dim reporter As New DeltaReporter
        reporter.MdiParent = Me
        reporter.Area = "SHI"
        reporter.Show()
    End Sub
End Class
