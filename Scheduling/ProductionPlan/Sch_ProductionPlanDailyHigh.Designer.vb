<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_ProductionPlanDailyHigh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_ProductionPlanDailyHigh))
        Me.pnlLog = New System.Windows.Forms.Panel()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.cmsLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.pnlInformation = New System.Windows.Forms.Panel()
        Me.lblEPS = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBoardClass = New System.Windows.Forms.Label()
        Me.lblAvgRequirements = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRequirements = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblBusiness = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblStdPack = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPastdue = New System.Windows.Forms.Label()
        Me.lblCapacity = New System.Windows.Forms.Label()
        Me.lblSchedule = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblBoard = New System.Windows.Forms.Label()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.dgvProductionPlan = New CAguilar.DataGridViewWithFilters()
        Me.cmsCellOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CapacityChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HighVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsPP = New System.Windows.Forms.ToolStrip()
        Me.ctrOptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.InitialDateButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnPrev = New System.Windows.Forms.ToolStripButton()
        Me.tstbWeeksToDisplay = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbtnNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ShowCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelSumarize = New System.Windows.Forms.ToolStripLabel()
        Me.SumarizeByCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.PastDueCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ChangeBusinessButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlLog.SuspendLayout()
        Me.cmsLog.SuspendLayout()
        Me.pnlInformation.SuspendLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCellOptions.SuspendLayout()
        Me.tsPP.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLog
        '
        Me.pnlLog.Controls.Add(Me.rtbLog)
        Me.pnlLog.Controls.Add(Me.lblSelection)
        Me.pnlLog.Controls.Add(Me.pnlInformation)
        Me.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLog.Location = New System.Drawing.Point(0, 0)
        Me.pnlLog.Name = "pnlLog"
        Me.pnlLog.Size = New System.Drawing.Size(212, 740)
        Me.pnlLog.TabIndex = 3
        '
        'rtbLog
        '
        Me.rtbLog.BackColor = System.Drawing.SystemColors.Control
        Me.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbLog.ContextMenuStrip = Me.cmsLog
        Me.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbLog.Font = New System.Drawing.Font("Arial monospaced for SAP", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLog.Location = New System.Drawing.Point(0, 467)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.ReadOnly = True
        Me.rtbLog.Size = New System.Drawing.Size(212, 252)
        Me.rtbLog.TabIndex = 0
        Me.rtbLog.Text = ""
        '
        'cmsLog
        '
        Me.cmsLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.CopyToolStripMenuItem, Me.SaveAsToolStripMenuItem})
        Me.cmsLog.Name = "cmsLog"
        Me.cmsLog.Size = New System.Drawing.Size(123, 70)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save as..."
        '
        'lblSelection
        '
        Me.lblSelection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSelection.Location = New System.Drawing.Point(0, 719)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(212, 21)
        Me.lblSelection.TabIndex = 2
        Me.lblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlInformation
        '
        Me.pnlInformation.BackColor = System.Drawing.SystemColors.Control
        Me.pnlInformation.Controls.Add(Me.lblEPS)
        Me.pnlInformation.Controls.Add(Me.Label17)
        Me.pnlInformation.Controls.Add(Me.lblShift)
        Me.pnlInformation.Controls.Add(Me.Label16)
        Me.pnlInformation.Controls.Add(Me.lblVolume)
        Me.pnlInformation.Controls.Add(Me.Label1)
        Me.pnlInformation.Controls.Add(Me.lblBoardClass)
        Me.pnlInformation.Controls.Add(Me.lblAvgRequirements)
        Me.pnlInformation.Controls.Add(Me.Label15)
        Me.pnlInformation.Controls.Add(Me.lblRequirements)
        Me.pnlInformation.Controls.Add(Me.Label2)
        Me.pnlInformation.Controls.Add(Me.Label12)
        Me.pnlInformation.Controls.Add(Me.lblBusiness)
        Me.pnlInformation.Controls.Add(Me.Label9)
        Me.pnlInformation.Controls.Add(Me.lblTo)
        Me.pnlInformation.Controls.Add(Me.Label13)
        Me.pnlInformation.Controls.Add(Me.lblFrom)
        Me.pnlInformation.Controls.Add(Me.Label11)
        Me.pnlInformation.Controls.Add(Me.lblStdPack)
        Me.pnlInformation.Controls.Add(Me.Label10)
        Me.pnlInformation.Controls.Add(Me.lblPastdue)
        Me.pnlInformation.Controls.Add(Me.lblCapacity)
        Me.pnlInformation.Controls.Add(Me.lblSchedule)
        Me.pnlInformation.Controls.Add(Me.Label8)
        Me.pnlInformation.Controls.Add(Me.Label7)
        Me.pnlInformation.Controls.Add(Me.Label6)
        Me.pnlInformation.Controls.Add(Me.lblCustomer)
        Me.pnlInformation.Controls.Add(Me.Label5)
        Me.pnlInformation.Controls.Add(Me.Label4)
        Me.pnlInformation.Controls.Add(Me.Label3)
        Me.pnlInformation.Controls.Add(Me.lblDescription)
        Me.pnlInformation.Controls.Add(Me.lblBoard)
        Me.pnlInformation.Controls.Add(Me.lblMaterial)
        Me.pnlInformation.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInformation.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformation.Name = "pnlInformation"
        Me.pnlInformation.Size = New System.Drawing.Size(212, 467)
        Me.pnlInformation.TabIndex = 1
        '
        'lblEPS
        '
        Me.lblEPS.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEPS.ForeColor = System.Drawing.Color.White
        Me.lblEPS.Location = New System.Drawing.Point(88, 387)
        Me.lblEPS.Name = "lblEPS"
        Me.lblEPS.Size = New System.Drawing.Size(120, 17)
        Me.lblEPS.TabIndex = 35
        Me.lblEPS.Text = "-"
        Me.lblEPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 389)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "EPS Qty:"
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.White
        Me.lblShift.Location = New System.Drawing.Point(88, 105)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(120, 17)
        Me.lblShift.TabIndex = 33
        Me.lblShift.Text = "-"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(54, 107)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Shift:"
        '
        'lblVolume
        '
        Me.lblVolume.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolume.ForeColor = System.Drawing.Color.White
        Me.lblVolume.Location = New System.Drawing.Point(88, 85)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(120, 17)
        Me.lblVolume.TabIndex = 31
        Me.lblVolume.Text = "-"
        Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Volume:"
        '
        'lblBoardClass
        '
        Me.lblBoardClass.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblBoardClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoardClass.ForeColor = System.Drawing.Color.White
        Me.lblBoardClass.Location = New System.Drawing.Point(88, 65)
        Me.lblBoardClass.Name = "lblBoardClass"
        Me.lblBoardClass.Size = New System.Drawing.Size(120, 17)
        Me.lblBoardClass.TabIndex = 29
        Me.lblBoardClass.Text = "-"
        Me.lblBoardClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAvgRequirements
        '
        Me.lblAvgRequirements.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblAvgRequirements.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgRequirements.ForeColor = System.Drawing.Color.White
        Me.lblAvgRequirements.Location = New System.Drawing.Point(88, 427)
        Me.lblAvgRequirements.Name = "lblAvgRequirements"
        Me.lblAvgRequirements.Size = New System.Drawing.Size(120, 17)
        Me.lblAvgRequirements.TabIndex = 28
        Me.lblAvgRequirements.Text = "-"
        Me.lblAvgRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(28, 429)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Avg Reqs:"
        '
        'lblRequirements
        '
        Me.lblRequirements.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblRequirements.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequirements.ForeColor = System.Drawing.Color.White
        Me.lblRequirements.Location = New System.Drawing.Point(88, 367)
        Me.lblRequirements.Name = "lblRequirements"
        Me.lblRequirements.Size = New System.Drawing.Size(120, 17)
        Me.lblRequirements.TabIndex = 26
        Me.lblRequirements.Text = "-"
        Me.lblRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 369)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Requirement:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 238)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Business:"
        '
        'lblBusiness
        '
        Me.lblBusiness.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusiness.ForeColor = System.Drawing.Color.White
        Me.lblBusiness.Location = New System.Drawing.Point(88, 236)
        Me.lblBusiness.Name = "lblBusiness"
        Me.lblBusiness.Size = New System.Drawing.Size(120, 17)
        Me.lblBusiness.TabIndex = 23
        Me.lblBusiness.Text = "-"
        Me.lblBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Description:"
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.White
        Me.lblTo.Location = New System.Drawing.Point(88, 296)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(120, 17)
        Me.lblTo.TabIndex = 20
        Me.lblTo.Text = "-"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 300)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "End production:"
        '
        'lblFrom
        '
        Me.lblFrom.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.ForeColor = System.Drawing.Color.White
        Me.lblFrom.Location = New System.Drawing.Point(88, 276)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(120, 17)
        Me.lblFrom.TabIndex = 18
        Me.lblFrom.Text = "-"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(0, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Start production:"
        '
        'lblStdPack
        '
        Me.lblStdPack.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblStdPack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStdPack.ForeColor = System.Drawing.Color.White
        Me.lblStdPack.Location = New System.Drawing.Point(88, 256)
        Me.lblStdPack.Name = "lblStdPack"
        Me.lblStdPack.Size = New System.Drawing.Size(120, 17)
        Me.lblStdPack.TabIndex = 16
        Me.lblStdPack.Text = "-"
        Me.lblStdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Std. Pack:"
        '
        'lblPastdue
        '
        Me.lblPastdue.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblPastdue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPastdue.ForeColor = System.Drawing.Color.White
        Me.lblPastdue.Location = New System.Drawing.Point(88, 447)
        Me.lblPastdue.Name = "lblPastdue"
        Me.lblPastdue.Size = New System.Drawing.Size(120, 17)
        Me.lblPastdue.TabIndex = 14
        Me.lblPastdue.Text = "-"
        Me.lblPastdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCapacity
        '
        Me.lblCapacity.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity.ForeColor = System.Drawing.Color.White
        Me.lblCapacity.Location = New System.Drawing.Point(88, 316)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(120, 17)
        Me.lblCapacity.TabIndex = 13
        Me.lblCapacity.Text = "-"
        Me.lblCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSchedule
        '
        Me.lblSchedule.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSchedule.ForeColor = System.Drawing.Color.White
        Me.lblSchedule.Location = New System.Drawing.Point(88, 347)
        Me.lblSchedule.Name = "lblSchedule"
        Me.lblSchedule.Size = New System.Drawing.Size(120, 17)
        Me.lblSchedule.TabIndex = 12
        Me.lblSchedule.Text = "-"
        Me.lblSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Board:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Customer P.N:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "DPN:"
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.White
        Me.lblCustomer.Location = New System.Drawing.Point(88, 216)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(120, 17)
        Me.lblCustomer.TabIndex = 8
        Me.lblCustomer.Text = "-"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 318)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Capacity:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 449)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Past due:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Schedule:"
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(88, 138)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(120, 75)
        Me.lblDescription.TabIndex = 21
        Me.lblDescription.Text = "-"
        '
        'lblBoard
        '
        Me.lblBoard.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoard.ForeColor = System.Drawing.Color.White
        Me.lblBoard.Location = New System.Drawing.Point(88, 45)
        Me.lblBoard.Name = "lblBoard"
        Me.lblBoard.Size = New System.Drawing.Size(120, 17)
        Me.lblBoard.TabIndex = 7
        Me.lblBoard.Text = "-"
        Me.lblBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaterial
        '
        Me.lblMaterial.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.ForeColor = System.Drawing.Color.White
        Me.lblMaterial.Location = New System.Drawing.Point(88, 25)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(120, 17)
        Me.lblMaterial.TabIndex = 6
        Me.lblMaterial.Text = "-"
        Me.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.dgvProductionPlan)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.tsPP)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.pnlLog)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1128, 742)
        Me.SplitContainerMain.SplitterDistance = 910
        Me.SplitContainerMain.TabIndex = 4
        '
        'dgvProductionPlan
        '
        Me.dgvProductionPlan.AllowColumnHiding = True
        Me.dgvProductionPlan.AllowUserToAddRows = False
        Me.dgvProductionPlan.AllowUserToDeleteRows = False
        Me.dgvProductionPlan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvProductionPlan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductionPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductionPlan.ContextMenuStrip = Me.cmsCellOptions
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlan.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductionPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductionPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductionPlan.GridColor = System.Drawing.Color.DimGray
        Me.dgvProductionPlan.Location = New System.Drawing.Point(0, 27)
        Me.dgvProductionPlan.Name = "dgvProductionPlan"
        Me.dgvProductionPlan.ShowRowNumber = True
        Me.dgvProductionPlan.Size = New System.Drawing.Size(908, 713)
        Me.dgvProductionPlan.TabIndex = 6
        '
        'cmsCellOptions
        '
        Me.cmsCellOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CapacityChartToolStripMenuItem})
        Me.cmsCellOptions.Name = "cmsCellOptions"
        Me.cmsCellOptions.Size = New System.Drawing.Size(167, 26)
        '
        'CapacityChartToolStripMenuItem
        '
        Me.CapacityChartToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LowVolumeToolStripMenuItem, Me.HighVolumeToolStripMenuItem})
        Me.CapacityChartToolStripMenuItem.Name = "CapacityChartToolStripMenuItem"
        Me.CapacityChartToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CapacityChartToolStripMenuItem.Text = "Capacity Analysis"
        '
        'LowVolumeToolStripMenuItem
        '
        Me.LowVolumeToolStripMenuItem.Name = "LowVolumeToolStripMenuItem"
        Me.LowVolumeToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.LowVolumeToolStripMenuItem.Text = "Low Volume"
        '
        'HighVolumeToolStripMenuItem
        '
        Me.HighVolumeToolStripMenuItem.Name = "HighVolumeToolStripMenuItem"
        Me.HighVolumeToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.HighVolumeToolStripMenuItem.Text = "High Volume"
        '
        'tsPP
        '
        Me.tsPP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctrOptions, Me.SaveToolStripButton, Me.ToolStripSeparator4, Me.CopyToolStripButton, Me.FindToolStripButton, Me.ToolStripSeparator3, Me.InitialDateButton, Me.ToolStripSeparator2, Me.tsbtnPrev, Me.tstbWeeksToDisplay, Me.tsbtnNext, Me.ToolStripSeparator6, Me.ToolStripLabel2, Me.ShowCombo, Me.ToolStripSeparator7, Me.ToolStripLabelSumarize, Me.SumarizeByCombo, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.PastDueCombo, Me.ChangeBusinessButton, Me.ToolStripSeparator5})
        Me.tsPP.Location = New System.Drawing.Point(0, 0)
        Me.tsPP.Name = "tsPP"
        Me.tsPP.Size = New System.Drawing.Size(908, 27)
        Me.tsPP.TabIndex = 7
        Me.tsPP.Text = "ToolStrip1"
        '
        'ctrOptions
        '
        Me.ctrOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrint, Me.btnExport, Me.btnImport, Me.AutoScheduleToolStripMenuItem})
        Me.ctrOptions.Image = CType(resources.GetObject("ctrOptions.Image"), System.Drawing.Image)
        Me.ctrOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ctrOptions.Name = "ctrOptions"
        Me.ctrOptions.Size = New System.Drawing.Size(78, 24)
        Me.ctrOptions.Text = "Options"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(162, 22)
        Me.btnPrint.Text = "Print"
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(162, 22)
        Me.btnExport.Text = "Export"
        '
        'btnImport
        '
        Me.btnImport.Enabled = False
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(162, 22)
        Me.btnImport.Text = "Import"
        '
        'AutoScheduleToolStripMenuItem
        '
        Me.AutoScheduleToolStripMenuItem.Image = CType(resources.GetObject("AutoScheduleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AutoScheduleToolStripMenuItem.Name = "AutoScheduleToolStripMenuItem"
        Me.AutoScheduleToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AutoScheduleToolStripMenuItem.Text = "Auto Scheduling"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(69, 24)
        Me.SaveToolStripButton.Text = "&Guardar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.FindToolStripButton.Text = "&Find"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'InitialDateButton
        '
        Me.InitialDateButton.Image = CType(resources.GetObject("InitialDateButton.Image"), System.Drawing.Image)
        Me.InitialDateButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InitialDateButton.Name = "InitialDateButton"
        Me.InitialDateButton.Size = New System.Drawing.Size(73, 24)
        Me.InitialDateButton.Text = "7/3/2017"
        Me.InitialDateButton.ToolTipText = "From..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'tsbtnPrev
        '
        Me.tsbtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnPrev.Image = CType(resources.GetObject("tsbtnPrev.Image"), System.Drawing.Image)
        Me.tsbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrev.Name = "tsbtnPrev"
        Me.tsbtnPrev.Size = New System.Drawing.Size(23, 24)
        Me.tsbtnPrev.ToolTipText = "Back"
        '
        'tstbWeeksToDisplay
        '
        Me.tstbWeeksToDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tstbWeeksToDisplay.Name = "tstbWeeksToDisplay"
        Me.tstbWeeksToDisplay.Size = New System.Drawing.Size(30, 27)
        Me.tstbWeeksToDisplay.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tstbWeeksToDisplay.ToolTipText = "Weeks to display"
        '
        'tsbtnNext
        '
        Me.tsbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnNext.Image = CType(resources.GetObject("tsbtnNext.Image"), System.Drawing.Image)
        Me.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnNext.Name = "tsbtnNext"
        Me.tsbtnNext.Size = New System.Drawing.Size(23, 24)
        Me.tsbtnNext.ToolTipText = "Forward"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(39, 24)
        Me.ToolStripLabel2.Text = "Show:"
        '
        'ShowCombo
        '
        Me.ShowCombo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ShowCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ShowCombo.Items.AddRange(New Object() {"Only Requirements", "All"})
        Me.ShowCombo.Name = "ShowCombo"
        Me.ShowCombo.Size = New System.Drawing.Size(121, 27)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabelSumarize
        '
        Me.ToolStripLabelSumarize.Name = "ToolStripLabelSumarize"
        Me.ToolStripLabelSumarize.Size = New System.Drawing.Size(74, 24)
        Me.ToolStripLabelSumarize.Text = "Sumarize by:"
        '
        'SumarizeByCombo
        '
        Me.SumarizeByCombo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SumarizeByCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SumarizeByCombo.DropDownWidth = 80
        Me.SumarizeByCombo.Items.AddRange(New Object() {"None", "Class", "Day", "Week", "Material", "Capacity", "Class,Capacity", "Class,Week", "Day,Week", "Day,Material", "Day,Week,Material"})
        Me.SumarizeByCombo.Name = "SumarizeByCombo"
        Me.SumarizeByCombo.Size = New System.Drawing.Size(120, 27)
        Me.SumarizeByCombo.ToolTipText = "Sumarize"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(87, 24)
        Me.ToolStripLabel1.Text = "Show past due:"
        '
        'PastDueCombo
        '
        Me.PastDueCombo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PastDueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PastDueCombo.Items.AddRange(New Object() {"None", "Daily", "Weekly"})
        Me.PastDueCombo.Name = "PastDueCombo"
        Me.PastDueCombo.Size = New System.Drawing.Size(90, 23)
        Me.PastDueCombo.ToolTipText = "Past Due"
        '
        'ChangeBusinessButton
        '
        Me.ChangeBusinessButton.Image = CType(resources.GetObject("ChangeBusinessButton.Image"), System.Drawing.Image)
        Me.ChangeBusinessButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ChangeBusinessButton.Name = "ChangeBusinessButton"
        Me.ChangeBusinessButton.Size = New System.Drawing.Size(23, 20)
        Me.ChangeBusinessButton.ToolTipText = "Change Business"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Sch_ProductionPlanDailyHigh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 742)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sch_ProductionPlanDailyHigh"
        Me.ShowIcon = False
        Me.Text = "Daily Production Plan - High Volume"
        Me.pnlLog.ResumeLayout(False)
        Me.cmsLog.ResumeLayout(False)
        Me.pnlInformation.ResumeLayout(False)
        Me.pnlInformation.PerformLayout()
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.PerformLayout()
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCellOptions.ResumeLayout(False)
        Me.tsPP.ResumeLayout(False)
        Me.tsPP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLog As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents cmsLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvProductionPlan As CAguilar.DataGridViewWithFilters
    Friend WithEvents tsPP As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelSumarize As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SumarizeByCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tstbWeeksToDisplay As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlInformation As System.Windows.Forms.Panel
    Friend WithEvents lblPastdue As System.Windows.Forms.Label
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents lblSchedule As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblBoard As System.Windows.Forms.Label
    Friend WithEvents lblMaterial As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PastDueCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InitialDateButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStdPack As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblBusiness As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents ChangeBusinessButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblAvgRequirements As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRequirements As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ctrOptions As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBoardClass As System.Windows.Forms.Label
    Friend WithEvents lblVolume As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents cmsCellOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CapacityChartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LowVolumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HighVolumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ShowCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AutoScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblEPS As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
