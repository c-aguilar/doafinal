<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableCheckpoint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableCheckpoint))
        Me.mnsMain = New System.Windows.Forms.MenuStrip()
        Me.Registry_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialOnCutter_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPending_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.Reprint_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeCutter_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindRandom_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindService_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.Settings_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewReel_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.Inventory_tsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.plBaja = New System.Windows.Forms.Panel()
        Me.Rewind_btn = New System.Windows.Forms.Button()
        Me.Option_txt = New CAguilar.WaterMarkTextBox()
        Me.Open_btn = New System.Windows.Forms.Button()
        Me.Empty_btn = New System.Windows.Forms.Button()
        Me.timerClean = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TerminalsOnCutters_lbl = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CableOnCutter_lbl = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MoreThan6_lbl = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Pendings_lbl = New System.Windows.Forms.Label()
        Me.timerWork = New System.Windows.Forms.Timer(Me.components)
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Warehouse_lbl = New System.Windows.Forms.Label()
        Me.mnsMain.SuspendLayout()
        Me.plBaja.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnsMain
        '
        Me.mnsMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.mnsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Registry_tsm, Me.SerialOnCutter_tsm, Me.SerialPending_tsm, Me.Reprint_tsm, Me.ChangeCutter_tsm, Me.FindRandom_tsm, Me.FindService_tsm, Me.Settings_tsm, Me.NewReel_tsm, Me.Inventory_tsm})
        Me.mnsMain.Location = New System.Drawing.Point(0, 0)
        Me.mnsMain.Name = "mnsMain"
        Me.mnsMain.ShowItemToolTips = True
        Me.mnsMain.Size = New System.Drawing.Size(1362, 55)
        Me.mnsMain.TabIndex = 2
        Me.mnsMain.Text = "MenuStrip1"
        '
        'Registry_tsm
        '
        Me.Registry_tsm.AutoSize = False
        Me.Registry_tsm.Image = CType(resources.GetObject("Registry_tsm.Image"), System.Drawing.Image)
        Me.Registry_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Registry_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Registry_tsm.Name = "Registry_tsm"
        Me.Registry_tsm.Size = New System.Drawing.Size(140, 50)
        Me.Registry_tsm.Text = "Registro"
        Me.Registry_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SerialOnCutter_tsm
        '
        Me.SerialOnCutter_tsm.AutoSize = False
        Me.SerialOnCutter_tsm.Image = CType(resources.GetObject("SerialOnCutter_tsm.Image"), System.Drawing.Image)
        Me.SerialOnCutter_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SerialOnCutter_tsm.Name = "SerialOnCutter_tsm"
        Me.SerialOnCutter_tsm.ShortcutKeyDisplayString = "F1"
        Me.SerialOnCutter_tsm.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.SerialOnCutter_tsm.Size = New System.Drawing.Size(140, 50)
        Me.SerialOnCutter_tsm.Text = "F1 Series en Cortadoras"
        Me.SerialOnCutter_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SerialOnCutter_tsm.ToolTipText = " Muestra los barriles en cada cortadora"
        '
        'SerialPending_tsm
        '
        Me.SerialPending_tsm.AutoSize = False
        Me.SerialPending_tsm.Image = CType(resources.GetObject("SerialPending_tsm.Image"), System.Drawing.Image)
        Me.SerialPending_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.SerialPending_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SerialPending_tsm.Name = "SerialPending_tsm"
        Me.SerialPending_tsm.ShortcutKeyDisplayString = "F2"
        Me.SerialPending_tsm.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SerialPending_tsm.Size = New System.Drawing.Size(140, 50)
        Me.SerialPending_tsm.Text = "F2 Pendientes de Surtir"
        Me.SerialPending_tsm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.SerialPending_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SerialPending_tsm.ToolTipText = "Muestra las series pendientes por surtir a servicio"
        '
        'Reprint_tsm
        '
        Me.Reprint_tsm.AutoSize = False
        Me.Reprint_tsm.Image = CType(resources.GetObject("Reprint_tsm.Image"), System.Drawing.Image)
        Me.Reprint_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Reprint_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Reprint_tsm.Name = "Reprint_tsm"
        Me.Reprint_tsm.ShortcutKeyDisplayString = "F3"
        Me.Reprint_tsm.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.Reprint_tsm.Size = New System.Drawing.Size(130, 50)
        Me.Reprint_tsm.Text = "F3 Reimprimir"
        Me.Reprint_tsm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Reprint_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Reprint_tsm.ToolTipText = "Permite reimprimir una etiqueta kanban"
        '
        'ChangeCutter_tsm
        '
        Me.ChangeCutter_tsm.AutoSize = False
        Me.ChangeCutter_tsm.Image = CType(resources.GetObject("ChangeCutter_tsm.Image"), System.Drawing.Image)
        Me.ChangeCutter_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ChangeCutter_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChangeCutter_tsm.Name = "ChangeCutter_tsm"
        Me.ChangeCutter_tsm.ShortcutKeyDisplayString = "F4"
        Me.ChangeCutter_tsm.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.ChangeCutter_tsm.Size = New System.Drawing.Size(140, 50)
        Me.ChangeCutter_tsm.Text = "F4 Cambio de Cortadora"
        Me.ChangeCutter_tsm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChangeCutter_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ChangeCutter_tsm.ToolTipText = "Cambio de barril de una cortadora a otra"
        '
        'FindRandom_tsm
        '
        Me.FindRandom_tsm.AutoSize = False
        Me.FindRandom_tsm.Image = CType(resources.GetObject("FindRandom_tsm.Image"), System.Drawing.Image)
        Me.FindRandom_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindRandom_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FindRandom_tsm.Name = "FindRandom_tsm"
        Me.FindRandom_tsm.ShortcutKeyDisplayString = "F5"
        Me.FindRandom_tsm.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.FindRandom_tsm.Size = New System.Drawing.Size(130, 50)
        Me.FindRandom_tsm.Text = "F5 Buscar en Reserva"
        Me.FindRandom_tsm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindRandom_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.FindRandom_tsm.ToolTipText = "Busqueda de barriles en localizacion random"
        '
        'FindService_tsm
        '
        Me.FindService_tsm.AutoSize = False
        Me.FindService_tsm.Image = CType(resources.GetObject("FindService_tsm.Image"), System.Drawing.Image)
        Me.FindService_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindService_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FindService_tsm.Name = "FindService_tsm"
        Me.FindService_tsm.ShortcutKeyDisplayString = "F6"
        Me.FindService_tsm.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.FindService_tsm.Size = New System.Drawing.Size(130, 50)
        Me.FindService_tsm.Text = "F6 Buscar en Servicio"
        Me.FindService_tsm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindService_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.FindService_tsm.ToolTipText = "Busqueda de barriles en servicio"
        '
        'Settings_tsm
        '
        Me.Settings_tsm.Image = CType(resources.GetObject("Settings_tsm.Image"), System.Drawing.Image)
        Me.Settings_tsm.Name = "Settings_tsm"
        Me.Settings_tsm.Size = New System.Drawing.Size(95, 51)
        Me.Settings_tsm.Text = "Configuración"
        Me.Settings_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'NewReel_tsm
        '
        Me.NewReel_tsm.AutoSize = False
        Me.NewReel_tsm.Image = CType(resources.GetObject("NewReel_tsm.Image"), System.Drawing.Image)
        Me.NewReel_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.NewReel_tsm.Name = "NewReel_tsm"
        Me.NewReel_tsm.ShortcutKeyDisplayString = "F7"
        Me.NewReel_tsm.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.NewReel_tsm.Size = New System.Drawing.Size(100, 50)
        Me.NewReel_tsm.Text = "F7 Rebobinado"
        Me.NewReel_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.NewReel_tsm.Visible = False
        '
        'Inventory_tsm
        '
        Me.Inventory_tsm.AutoSize = False
        Me.Inventory_tsm.Image = CType(resources.GetObject("Inventory_tsm.Image"), System.Drawing.Image)
        Me.Inventory_tsm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Inventory_tsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Inventory_tsm.Name = "Inventory_tsm"
        Me.Inventory_tsm.Size = New System.Drawing.Size(100, 50)
        Me.Inventory_tsm.Text = "Inventario"
        Me.Inventory_tsm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Inventory_tsm.Visible = False
        '
        'plBaja
        '
        Me.plBaja.BackColor = System.Drawing.Color.Transparent
        Me.plBaja.Controls.Add(Me.Rewind_btn)
        Me.plBaja.Controls.Add(Me.Option_txt)
        Me.plBaja.Controls.Add(Me.Open_btn)
        Me.plBaja.Controls.Add(Me.Empty_btn)
        Me.plBaja.Location = New System.Drawing.Point(434, 3)
        Me.plBaja.Name = "plBaja"
        Me.plBaja.Size = New System.Drawing.Size(494, 621)
        Me.plBaja.TabIndex = 12
        '
        'Rewind_btn
        '
        Me.Rewind_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rewind_btn.BackColor = System.Drawing.Color.White
        Me.Rewind_btn.BackgroundImage = CType(resources.GetObject("Rewind_btn.BackgroundImage"), System.Drawing.Image)
        Me.Rewind_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Rewind_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Rewind_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Rewind_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rewind_btn.Location = New System.Drawing.Point(140, 523)
        Me.Rewind_btn.Name = "Rewind_btn"
        Me.Rewind_btn.Size = New System.Drawing.Size(215, 90)
        Me.Rewind_btn.TabIndex = 43
        Me.Rewind_btn.Text = "REBOBINAR"
        Me.Rewind_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Rewind_btn.UseVisualStyleBackColor = False
        Me.Rewind_btn.Visible = False
        '
        'Option_txt
        '
        Me.Option_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Option_txt.BackColor = System.Drawing.Color.Ivory
        Me.Option_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option_txt.ForeColor = System.Drawing.Color.Black
        Me.Option_txt.Location = New System.Drawing.Point(97, 27)
        Me.Option_txt.Name = "Option_txt"
        Me.Option_txt.Size = New System.Drawing.Size(300, 40)
        Me.Option_txt.TabIndex = 24
        Me.Option_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Option_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Option_txt.WaterMarkText = "Escanea una opcion..."
        '
        'Open_btn
        '
        Me.Open_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Open_btn.BackColor = System.Drawing.Color.White
        Me.Open_btn.BackgroundImage = CType(resources.GetObject("Open_btn.BackgroundImage"), System.Drawing.Image)
        Me.Open_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Open_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Open_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Open_btn.Location = New System.Drawing.Point(140, 129)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(215, 90)
        Me.Open_btn.TabIndex = 42
        Me.Open_btn.Text = "RANDOM A SERVICIO"
        Me.Open_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Open_btn.UseVisualStyleBackColor = False
        '
        'Empty_btn
        '
        Me.Empty_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Empty_btn.BackColor = System.Drawing.Color.White
        Me.Empty_btn.BackgroundImage = CType(resources.GetObject("Empty_btn.BackgroundImage"), System.Drawing.Image)
        Me.Empty_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Empty_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Empty_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Empty_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Empty_btn.Location = New System.Drawing.Point(140, 326)
        Me.Empty_btn.Name = "Empty_btn"
        Me.Empty_btn.Size = New System.Drawing.Size(215, 90)
        Me.Empty_btn.TabIndex = 39
        Me.Empty_btn.Text = "DECLARAR VACIO"
        Me.Empty_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Empty_btn.UseVisualStyleBackColor = False
        '
        'timerClean
        '
        Me.timerClean.Interval = 30000
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.plBaja, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 103)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1362, 627)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(934, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 621)
        Me.Panel1.TabIndex = 16
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel8, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(225, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 621)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Controls.Add(Me.TableLayoutPanel6)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 468)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(194, 150)
        Me.Panel8.TabIndex = 15
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(194, 150)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label1)
        Me.Panel9.Controls.Add(Me.TerminalsOnCutters_lbl)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(188, 144)
        Me.Panel9.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Terminales en Cortadoras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TerminalsOnCutters_lbl
        '
        Me.TerminalsOnCutters_lbl.BackColor = System.Drawing.Color.Black
        Me.TerminalsOnCutters_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.TerminalsOnCutters_lbl.Font = New System.Drawing.Font("Impact", 56.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TerminalsOnCutters_lbl.ForeColor = System.Drawing.Color.White
        Me.TerminalsOnCutters_lbl.Location = New System.Drawing.Point(0, 0)
        Me.TerminalsOnCutters_lbl.Name = "TerminalsOnCutters_lbl"
        Me.TerminalsOnCutters_lbl.Size = New System.Drawing.Size(188, 99)
        Me.TerminalsOnCutters_lbl.TabIndex = 0
        Me.TerminalsOnCutters_lbl.Text = "0"
        Me.TerminalsOnCutters_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 313)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(194, 149)
        Me.Panel6.TabIndex = 14
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(194, 149)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.CableOnCutter_lbl)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(188, 144)
        Me.Panel7.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(188, 45)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Barriles en Cortadoras"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CableOnCutter_lbl
        '
        Me.CableOnCutter_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.CableOnCutter_lbl.Font = New System.Drawing.Font("Impact", 56.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CableOnCutter_lbl.ForeColor = System.Drawing.Color.White
        Me.CableOnCutter_lbl.Location = New System.Drawing.Point(0, 0)
        Me.CableOnCutter_lbl.Name = "CableOnCutter_lbl"
        Me.CableOnCutter_lbl.Size = New System.Drawing.Size(188, 99)
        Me.CableOnCutter_lbl.TabIndex = 0
        Me.CableOnCutter_lbl.Text = "0"
        Me.CableOnCutter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Maroon
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 158)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(194, 149)
        Me.Panel3.TabIndex = 13
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(194, 149)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.MoreThan6_lbl)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(188, 144)
        Me.Panel5.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(188, 45)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "+ de 6 Horas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MoreThan6_lbl
        '
        Me.MoreThan6_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MoreThan6_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.MoreThan6_lbl.Font = New System.Drawing.Font("Impact", 56.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoreThan6_lbl.ForeColor = System.Drawing.Color.White
        Me.MoreThan6_lbl.Location = New System.Drawing.Point(0, 0)
        Me.MoreThan6_lbl.Name = "MoreThan6_lbl"
        Me.MoreThan6_lbl.Size = New System.Drawing.Size(188, 99)
        Me.MoreThan6_lbl.TabIndex = 0
        Me.MoreThan6_lbl.Text = "0"
        Me.MoreThan6_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 149)
        Me.Panel2.TabIndex = 12
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(194, 149)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Pendings_lbl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(188, 144)
        Me.Panel4.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 45)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Pendientes de Surtir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pendings_lbl
        '
        Me.Pendings_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pendings_lbl.Font = New System.Drawing.Font("Impact", 56.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pendings_lbl.ForeColor = System.Drawing.Color.White
        Me.Pendings_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Pendings_lbl.Name = "Pendings_lbl"
        Me.Pendings_lbl.Size = New System.Drawing.Size(188, 99)
        Me.Pendings_lbl.TabIndex = 0
        Me.Pendings_lbl.Text = "0"
        Me.Pendings_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerWork
        '
        Me.timerWork.Enabled = True
        Me.timerWork.Interval = 120000
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(6, 55)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(1347, 45)
        Me.Title_lbl.TabIndex = 30
        Me.Title_lbl.Text = "Checkpoint de Barriles && Terminales"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Warehouse_lbl
        '
        Me.Warehouse_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Warehouse_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Warehouse_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Warehouse_lbl.ForeColor = System.Drawing.Color.White
        Me.Warehouse_lbl.Location = New System.Drawing.Point(1113, 62)
        Me.Warehouse_lbl.Name = "Warehouse_lbl"
        Me.Warehouse_lbl.Size = New System.Drawing.Size(232, 23)
        Me.Warehouse_lbl.TabIndex = 14
        Me.Warehouse_lbl.Text = "Warehouse"
        Me.Warehouse_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Smk_CableCheckpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1362, 730)
        Me.Controls.Add(Me.Warehouse_lbl)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.mnsMain)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Smk_CableCheckpoint"
        Me.Text = "Supermarket"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnsMain.ResumeLayout(False)
        Me.mnsMain.PerformLayout()
        Me.plBaja.ResumeLayout(False)
        Me.plBaja.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnsMain As System.Windows.Forms.MenuStrip
    Friend WithEvents Reprint_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeCutter_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindRandom_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindService_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialPending_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialOnCutter_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Registry_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerClean As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Pendings_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CableOnCutter_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MoreThan6_lbl As System.Windows.Forms.Label
    Friend WithEvents timerWork As System.Windows.Forms.Timer
    Friend WithEvents NewReel_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Inventory_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents plBaja As System.Windows.Forms.Panel
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents Empty_btn As System.Windows.Forms.Button
    Friend WithEvents Option_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Rewind_btn As System.Windows.Forms.Button
    Friend WithEvents Settings_tsm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Warehouse_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TerminalsOnCutters_lbl As System.Windows.Forms.Label

End Class
