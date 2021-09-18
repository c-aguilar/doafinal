<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_Audit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_Audit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl10 = New System.Windows.Forms.Label()
        Me.Sloc_cbo = New System.Windows.Forms.ComboBox()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.Print_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Items_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._partnumberserial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.open_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.partial_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.empty_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Result_dgv = New CAguilar.DataGridViewWithFilters()
        Me.partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.difference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.button = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.All_rb = New System.Windows.Forms.RadioButton()
        Me.IgnoreMSpec_rb = New System.Windows.Forms.RadioButton()
        Me.OnlyMspec_rb = New System.Windows.Forms.RadioButton()
        Me.IgnoreZero_chk = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LocationA_txt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LocationB_txt = New System.Windows.Forms.TextBox()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl10
        '
        Me.lbl10.AutoSize = True
        Me.lbl10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl10.Location = New System.Drawing.Point(468, 37)
        Me.lbl10.Name = "lbl10"
        Me.lbl10.Size = New System.Drawing.Size(35, 13)
        Me.lbl10.TabIndex = 114
        Me.lbl10.Text = "SLoc:"
        '
        'Sloc_cbo
        '
        Me.Sloc_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Sloc_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sloc_cbo.FormattingEnabled = True
        Me.Sloc_cbo.Location = New System.Drawing.Point(509, 32)
        Me.Sloc_cbo.Name = "Sloc_cbo"
        Me.Sloc_cbo.Size = New System.Drawing.Size(87, 21)
        Me.Sloc_cbo.TabIndex = 113
        '
        'Run_btn
        '
        Me.Run_btn.BackColor = System.Drawing.Color.Transparent
        Me.Run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(707, 29)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 112
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = False
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.Print_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1093, 29)
        Me.ToolStripMain.TabIndex = 115
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Export_btn
        '
        Me.Export_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Export_btn.Image = CType(resources.GetObject("Export_btn.Image"), System.Drawing.Image)
        Me.Export_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Export_btn.Name = "Export_btn"
        Me.Export_btn.Size = New System.Drawing.Size(23, 26)
        Me.Export_btn.Text = "&Exportar"
        '
        'Print_btn
        '
        Me.Print_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Print_btn.Image = CType(resources.GetObject("Print_btn.Image"), System.Drawing.Image)
        Me.Print_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(23, 26)
        Me.Print_btn.Text = "Im&primir"
        Me.Print_btn.ToolTipText = "Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(226, 26)
        Me.Title_lbl.Text = "Auditoria de Supermercado"
        '
        'Items_btn
        '
        Me.Items_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Items_btn.Image = CType(resources.GetObject("Items_btn.Image"), System.Drawing.Image)
        Me.Items_btn.Location = New System.Drawing.Point(200, 32)
        Me.Items_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Items_btn.Name = "Items_btn"
        Me.Items_btn.Size = New System.Drawing.Size(23, 23)
        Me.Items_btn.TabIndex = 116
        Me.Items_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Items_btn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Numero de Parte:"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(100, 33)
        Me.Partnumber_txt.MaxLength = 12
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(100, 20)
        Me.Partnumber_txt.TabIndex = 117
        Me.Partnumber_txt.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(472, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Numeros de serie:"
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowColumnHiding = True
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        Me.Serials_dgv.AllowUserToResizeColumns = False
        Me.Serials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Serials_dgv.ColumnHeadersHeight = 34
        Me.Serials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serialnumber, Me._partnumberserial, Me.quantity, Me.uom, Me.status, Me.local, Me.warehouse, Me.open_btn, Me.partial_btn, Me.empty_btn})
        Me.Serials_dgv.Location = New System.Drawing.Point(471, 90)
        Me.Serials_dgv.Name = "Serials_dgv"
        Me.Serials_dgv.ReadOnly = True
        Me.Serials_dgv.RowHeadersVisible = False
        Me.Serials_dgv.ShowRowNumber = True
        Me.Serials_dgv.Size = New System.Drawing.Size(616, 547)
        Me.Serials_dgv.TabIndex = 120
        '
        'serialnumber
        '
        Me.serialnumber.DataPropertyName = "Serie"
        Me.serialnumber.HeaderText = "Serie"
        Me.serialnumber.Name = "serialnumber"
        Me.serialnumber.ReadOnly = True
        '
        '_partnumberserial
        '
        Me._partnumberserial.DataPropertyName = "Numero de Parte"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me._partnumberserial.DefaultCellStyle = DataGridViewCellStyle2
        Me._partnumberserial.HeaderText = "Numero de Parte"
        Me._partnumberserial.Name = "_partnumberserial"
        Me._partnumberserial.ReadOnly = True
        Me._partnumberserial.Width = 80
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "Cantidad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.quantity.DefaultCellStyle = DataGridViewCellStyle3
        Me.quantity.HeaderText = "Cantidad"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        Me.quantity.Width = 60
        '
        'uom
        '
        Me.uom.DataPropertyName = "Unidad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.uom.DefaultCellStyle = DataGridViewCellStyle4
        Me.uom.HeaderText = "Unidad"
        Me.uom.Name = "uom"
        Me.uom.ReadOnly = True
        Me.uom.Width = 60
        '
        'status
        '
        Me.status.DataPropertyName = "Estatus"
        Me.status.HeaderText = "Estatus"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 80
        '
        'local
        '
        Me.local.DataPropertyName = "Localizacion"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.local.DefaultCellStyle = DataGridViewCellStyle5
        Me.local.HeaderText = "Localizacion"
        Me.local.Name = "local"
        Me.local.ReadOnly = True
        Me.local.Width = 70
        '
        'warehouse
        '
        Me.warehouse.DataPropertyName = "Estacion"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.warehouse.DefaultCellStyle = DataGridViewCellStyle6
        Me.warehouse.HeaderText = "Estacion"
        Me.warehouse.Name = "warehouse"
        Me.warehouse.ReadOnly = True
        Me.warehouse.Width = 70
        '
        'open_btn
        '
        Me.open_btn.HeaderText = ""
        Me.open_btn.Name = "open_btn"
        Me.open_btn.ReadOnly = True
        Me.open_btn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.open_btn.ToolTipText = "Abrir"
        Me.open_btn.Width = 25
        '
        'partial_btn
        '
        Me.partial_btn.HeaderText = ""
        Me.partial_btn.Name = "partial_btn"
        Me.partial_btn.ReadOnly = True
        Me.partial_btn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.partial_btn.ToolTipText = "Descuento Parcial"
        Me.partial_btn.Width = 25
        '
        'empty_btn
        '
        Me.empty_btn.HeaderText = ""
        Me.empty_btn.Name = "empty_btn"
        Me.empty_btn.ReadOnly = True
        Me.empty_btn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.empty_btn.ToolTipText = "Vacio"
        Me.empty_btn.Width = 25
        '
        'Result_dgv
        '
        Me.Result_dgv.AllowColumnHiding = True
        Me.Result_dgv.AllowUserToAddRows = False
        Me.Result_dgv.AllowUserToDeleteRows = False
        Me.Result_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Result_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Result_dgv.ColumnHeadersHeight = 34
        Me.Result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Result_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.partnumber, Me.delta, Me.pending, Me.sap, Me.difference, Me.button})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Result_dgv.DefaultCellStyle = DataGridViewCellStyle13
        Me.Result_dgv.Location = New System.Drawing.Point(6, 59)
        Me.Result_dgv.Name = "Result_dgv"
        Me.Result_dgv.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Result_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.Result_dgv.ShowRowNumber = True
        Me.Result_dgv.Size = New System.Drawing.Size(460, 578)
        Me.Result_dgv.TabIndex = 119
        '
        'partnumber
        '
        Me.partnumber.DataPropertyName = "No. de Parte"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumber.DefaultCellStyle = DataGridViewCellStyle8
        Me.partnumber.HeaderText = "Numero de Parte"
        Me.partnumber.Name = "partnumber"
        Me.partnumber.ReadOnly = True
        Me.partnumber.Width = 80
        '
        'delta
        '
        Me.delta.DataPropertyName = "Cantidad en Delta"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "N3"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.delta.DefaultCellStyle = DataGridViewCellStyle9
        Me.delta.HeaderText = "Cantidad en Delta"
        Me.delta.Name = "delta"
        Me.delta.ReadOnly = True
        Me.delta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.delta.Width = 70
        '
        'pending
        '
        Me.pending.DataPropertyName = "Pendiente por Transferir"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "N3"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.pending.DefaultCellStyle = DataGridViewCellStyle10
        Me.pending.HeaderText = "Pendiente por Transferir"
        Me.pending.Name = "pending"
        Me.pending.ReadOnly = True
        Me.pending.Width = 80
        '
        'sap
        '
        Me.sap.DataPropertyName = "Cantidad en SAP"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Format = "N3"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.sap.DefaultCellStyle = DataGridViewCellStyle11
        Me.sap.HeaderText = "Cantidad en SAP"
        Me.sap.Name = "sap"
        Me.sap.ReadOnly = True
        Me.sap.Width = 70
        '
        'difference
        '
        Me.difference.DataPropertyName = "Diferencia"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "N3"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.difference.DefaultCellStyle = DataGridViewCellStyle12
        Me.difference.HeaderText = "Diferencia"
        Me.difference.Name = "difference"
        Me.difference.ReadOnly = True
        Me.difference.Width = 70
        '
        'button
        '
        Me.button.HeaderText = ""
        Me.button.Name = "button"
        Me.button.ReadOnly = True
        Me.button.Width = 25
        '
        'All_rb
        '
        Me.All_rb.AutoSize = True
        Me.All_rb.Enabled = False
        Me.All_rb.Location = New System.Drawing.Point(824, 33)
        Me.All_rb.Name = "All_rb"
        Me.All_rb.Size = New System.Drawing.Size(50, 17)
        Me.All_rb.TabIndex = 130
        Me.All_rb.Text = "Todo"
        Me.All_rb.UseVisualStyleBackColor = True
        Me.All_rb.Visible = False
        '
        'IgnoreMSpec_rb
        '
        Me.IgnoreMSpec_rb.AutoSize = True
        Me.IgnoreMSpec_rb.Checked = True
        Me.IgnoreMSpec_rb.Enabled = False
        Me.IgnoreMSpec_rb.Location = New System.Drawing.Point(880, 33)
        Me.IgnoreMSpec_rb.Name = "IgnoreMSpec_rb"
        Me.IgnoreMSpec_rb.Size = New System.Drawing.Size(91, 17)
        Me.IgnoreMSpec_rb.TabIndex = 129
        Me.IgnoreMSpec_rb.TabStop = True
        Me.IgnoreMSpec_rb.Text = "Omitir M-Spec"
        Me.IgnoreMSpec_rb.UseVisualStyleBackColor = True
        Me.IgnoreMSpec_rb.Visible = False
        '
        'OnlyMspec_rb
        '
        Me.OnlyMspec_rb.AutoSize = True
        Me.OnlyMspec_rb.Enabled = False
        Me.OnlyMspec_rb.Location = New System.Drawing.Point(977, 33)
        Me.OnlyMspec_rb.Name = "OnlyMspec_rb"
        Me.OnlyMspec_rb.Size = New System.Drawing.Size(86, 17)
        Me.OnlyMspec_rb.TabIndex = 128
        Me.OnlyMspec_rb.Text = "Solo M-Spec"
        Me.OnlyMspec_rb.UseVisualStyleBackColor = True
        Me.OnlyMspec_rb.Visible = False
        '
        'IgnoreZero_chk
        '
        Me.IgnoreZero_chk.AutoSize = True
        Me.IgnoreZero_chk.Location = New System.Drawing.Point(608, 34)
        Me.IgnoreZero_chk.Name = "IgnoreZero_chk"
        Me.IgnoreZero_chk.Size = New System.Drawing.Size(82, 17)
        Me.IgnoreZero_chk.TabIndex = 127
        Me.IgnoreZero_chk.Text = "Omitir Ceros"
        Me.IgnoreZero_chk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(250, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Local:"
        '
        'LocationA_txt
        '
        Me.LocationA_txt.Location = New System.Drawing.Point(289, 35)
        Me.LocationA_txt.MaxLength = 8
        Me.LocationA_txt.Name = "LocationA_txt"
        Me.LocationA_txt.Size = New System.Drawing.Size(64, 20)
        Me.LocationA_txt.TabIndex = 131
        Me.LocationA_txt.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(355, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "al:"
        '
        'LocationB_txt
        '
        Me.LocationB_txt.Location = New System.Drawing.Point(376, 34)
        Me.LocationB_txt.MaxLength = 8
        Me.LocationB_txt.Name = "LocationB_txt"
        Me.LocationB_txt.Size = New System.Drawing.Size(64, 20)
        Me.LocationB_txt.TabIndex = 133
        Me.LocationB_txt.Text = "*"
        '
        'Smk_Audit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 643)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LocationB_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LocationA_txt)
        Me.Controls.Add(Me.All_rb)
        Me.Controls.Add(Me.IgnoreMSpec_rb)
        Me.Controls.Add(Me.OnlyMspec_rb)
        Me.Controls.Add(Me.IgnoreZero_chk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Result_dgv)
        Me.Controls.Add(Me.Items_btn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.lbl10)
        Me.Controls.Add(Me.Sloc_cbo)
        Me.Controls.Add(Me.Run_btn)
        Me.Name = "Smk_Audit"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl10 As System.Windows.Forms.Label
    Friend WithEvents Sloc_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Items_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Result_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _partnumberserial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_open As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents btn_partial As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents btn_empty As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents open_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents partial_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents empty_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents All_rb As System.Windows.Forms.RadioButton
    Friend WithEvents IgnoreMSpec_rb As System.Windows.Forms.RadioButton
    Friend WithEvents OnlyMspec_rb As System.Windows.Forms.RadioButton
    Friend WithEvents IgnoreZero_chk As System.Windows.Forms.CheckBox
    Friend WithEvents partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pending As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents difference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents button As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LocationA_txt As System.Windows.Forms.TextBox
    Friend WithEvents Print_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LocationB_txt As System.Windows.Forms.TextBox
End Class
