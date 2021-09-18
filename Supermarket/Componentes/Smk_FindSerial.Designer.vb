<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_FindSerial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_FindSerial))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Serial_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Random_chk = New System.Windows.Forms.CheckBox()
        Me.Service_chk = New System.Windows.Forms.CheckBox()
        Me.Empty_chk = New System.Windows.Forms.CheckBox()
        Me.Receiving_chk = New System.Windows.Forms.CheckBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Total_lbl = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Consumption_lbl = New System.Windows.Forms.Label()
        Me.UoM_lbl = New System.Windows.Forms.Label()
        Me.Location_lbl = New System.Windows.Forms.Label()
        Me.Supplier_lbl = New System.Windows.Forms.Label()
        Me.Quality_chk = New System.Windows.Forms.CheckBox()
        Me.Tracker_chk = New System.Windows.Forms.CheckBox()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdPack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RedTag = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InvoiceTrouble = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Location_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateEmpty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.details_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Serial_rb
        '
        Me.Serial_rb.AutoSize = True
        Me.Serial_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_rb.Location = New System.Drawing.Point(289, 32)
        Me.Serial_rb.Name = "Serial_rb"
        Me.Serial_rb.Size = New System.Drawing.Size(64, 22)
        Me.Serial_rb.TabIndex = 5
        Me.Serial_rb.Text = "Serie:"
        Me.Serial_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Checked = True
        Me.Partnumber_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_rb.Location = New System.Drawing.Point(13, 32)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(141, 22)
        Me.Partnumber_rb.TabIndex = 4
        Me.Partnumber_rb.TabStop = True
        Me.Partnumber_rb.Text = "Numero de parte:"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(536, 30)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(100, 25)
        Me.Find_btn.TabIndex = 3
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowColumnHiding = True
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        Me.Serials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serialnumber, Me.Partnumber, Me.Description, Me.MaterialType, Me.StdPack, Me.CurrentQuantity, Me.UoM, Me.Status, Me.RedTag, Me.InvoiceTrouble, Me.Location_, Me.Warehouse, Me.Date_, Me.DateEmpty, Me.details_btn})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Serials_dgv.DefaultCellStyle = DataGridViewCellStyle12
        Me.Serials_dgv.Location = New System.Drawing.Point(6, 150)
        Me.Serials_dgv.Name = "Serials_dgv"
        Me.Serials_dgv.ReadOnly = True
        Me.Serials_dgv.ShowRowNumber = True
        Me.Serials_dgv.Size = New System.Drawing.Size(997, 406)
        Me.Serials_dgv.TabIndex = 97
        '
        'Random_chk
        '
        Me.Random_chk.AutoSize = True
        Me.Random_chk.Checked = True
        Me.Random_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Random_chk.Location = New System.Drawing.Point(84, 64)
        Me.Random_chk.Name = "Random_chk"
        Me.Random_chk.Size = New System.Drawing.Size(66, 17)
        Me.Random_chk.TabIndex = 7
        Me.Random_chk.Text = "Reserva"
        Me.Random_chk.UseVisualStyleBackColor = True
        '
        'Service_chk
        '
        Me.Service_chk.AutoSize = True
        Me.Service_chk.Checked = True
        Me.Service_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Service_chk.Location = New System.Drawing.Point(156, 64)
        Me.Service_chk.Name = "Service_chk"
        Me.Service_chk.Size = New System.Drawing.Size(64, 17)
        Me.Service_chk.TabIndex = 8
        Me.Service_chk.Text = "Servicio"
        Me.Service_chk.UseVisualStyleBackColor = True
        '
        'Empty_chk
        '
        Me.Empty_chk.AutoSize = True
        Me.Empty_chk.Location = New System.Drawing.Point(226, 64)
        Me.Empty_chk.Name = "Empty_chk"
        Me.Empty_chk.Size = New System.Drawing.Size(53, 17)
        Me.Empty_chk.TabIndex = 9
        Me.Empty_chk.Text = "Vacio"
        Me.Empty_chk.UseVisualStyleBackColor = True
        '
        'Receiving_chk
        '
        Me.Receiving_chk.AutoSize = True
        Me.Receiving_chk.Checked = True
        Me.Receiving_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Receiving_chk.Location = New System.Drawing.Point(13, 64)
        Me.Receiving_chk.Name = "Receiving_chk"
        Me.Receiving_chk.Size = New System.Drawing.Size(65, 17)
        Me.Receiving_chk.TabIndex = 6
        Me.Receiving_chk.Text = "Rampas"
        Me.Receiving_chk.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1009, 29)
        Me.ToolStripMain.TabIndex = 102
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
        Me.Title_lbl.Size = New System.Drawing.Size(183, 26)
        Me.Title_lbl.Text = "Busqueda de Material"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.Location = New System.Drawing.Point(91, 13)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(115, 18)
        Me.Partnumber_lbl.TabIndex = 103
        Me.Partnumber_lbl.Text = "."
        '
        'Description_lbl
        '
        Me.Description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.Location = New System.Drawing.Point(93, 37)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(357, 18)
        Me.Description_lbl.TabIndex = 104
        Me.Description_lbl.Text = "."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Total_lbl)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Consumption_lbl)
        Me.GroupBox1.Controls.Add(Me.UoM_lbl)
        Me.GroupBox1.Controls.Add(Me.Location_lbl)
        Me.GroupBox1.Controls.Add(Me.Partnumber_lbl)
        Me.GroupBox1.Controls.Add(Me.Supplier_lbl)
        Me.GroupBox1.Controls.Add(Me.Description_lbl)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(997, 65)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        '
        'Total_lbl
        '
        Me.Total_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total_lbl.Location = New System.Drawing.Point(837, 13)
        Me.Total_lbl.Name = "Total_lbl"
        Me.Total_lbl.Size = New System.Drawing.Size(89, 18)
        Me.Total_lbl.TabIndex = 116
        Me.Total_lbl.Text = "."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(794, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Total:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(613, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Local:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(456, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Consumo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Descripcion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(794, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Unidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(212, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Np. de Proveedor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "No. de Parte:"
        '
        'Consumption_lbl
        '
        Me.Consumption_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consumption_lbl.Location = New System.Drawing.Point(522, 13)
        Me.Consumption_lbl.Name = "Consumption_lbl"
        Me.Consumption_lbl.Size = New System.Drawing.Size(89, 18)
        Me.Consumption_lbl.TabIndex = 108
        Me.Consumption_lbl.Text = "."
        '
        'UoM_lbl
        '
        Me.UoM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UoM_lbl.Location = New System.Drawing.Point(850, 40)
        Me.UoM_lbl.Name = "UoM_lbl"
        Me.UoM_lbl.Size = New System.Drawing.Size(92, 18)
        Me.UoM_lbl.TabIndex = 107
        Me.UoM_lbl.Text = "."
        '
        'Location_lbl
        '
        Me.Location_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location_lbl.Location = New System.Drawing.Point(613, 28)
        Me.Location_lbl.Name = "Location_lbl"
        Me.Location_lbl.Size = New System.Drawing.Size(175, 33)
        Me.Location_lbl.TabIndex = 106
        Me.Location_lbl.Text = "."
        '
        'Supplier_lbl
        '
        Me.Supplier_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Supplier_lbl.Location = New System.Drawing.Point(323, 13)
        Me.Supplier_lbl.Name = "Supplier_lbl"
        Me.Supplier_lbl.Size = New System.Drawing.Size(127, 18)
        Me.Supplier_lbl.TabIndex = 105
        Me.Supplier_lbl.Text = "."
        '
        'Quality_chk
        '
        Me.Quality_chk.AutoSize = True
        Me.Quality_chk.Location = New System.Drawing.Point(285, 64)
        Me.Quality_chk.Name = "Quality_chk"
        Me.Quality_chk.Size = New System.Drawing.Size(61, 17)
        Me.Quality_chk.TabIndex = 10
        Me.Quality_chk.Text = "Calidad"
        Me.Quality_chk.UseVisualStyleBackColor = True
        '
        'Tracker_chk
        '
        Me.Tracker_chk.AutoSize = True
        Me.Tracker_chk.Location = New System.Drawing.Point(352, 64)
        Me.Tracker_chk.Name = "Tracker_chk"
        Me.Tracker_chk.Size = New System.Drawing.Size(63, 17)
        Me.Tracker_chk.TabIndex = 11
        Me.Tracker_chk.Text = "Tracker"
        Me.Tracker_chk.UseVisualStyleBackColor = True
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(359, 30)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(155, 26)
        Me.Serial_txt.TabIndex = 2
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(160, 30)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(123, 26)
        Me.Partnumber_txt.TabIndex = 1
        '
        'Serialnumber
        '
        Me.Serialnumber.DataPropertyName = "SerialNumber"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Serialnumber.DefaultCellStyle = DataGridViewCellStyle1
        Me.Serialnumber.HeaderText = "Serie"
        Me.Serialnumber.Name = "Serialnumber"
        Me.Serialnumber.ReadOnly = True
        Me.Serialnumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serialnumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Serialnumber.Width = 110
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 70
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Descripcion"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 150
        '
        'MaterialType
        '
        Me.MaterialType.DataPropertyName = "MaterialType"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.MaterialType.DefaultCellStyle = DataGridViewCellStyle3
        Me.MaterialType.HeaderText = "Tipo de Material"
        Me.MaterialType.Name = "MaterialType"
        Me.MaterialType.ReadOnly = True
        Me.MaterialType.Width = 80
        '
        'StdPack
        '
        Me.StdPack.DataPropertyName = "OriginalQuantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.StdPack.DefaultCellStyle = DataGridViewCellStyle4
        Me.StdPack.HeaderText = "StdPack"
        Me.StdPack.Name = "StdPack"
        Me.StdPack.ReadOnly = True
        Me.StdPack.Width = 70
        '
        'CurrentQuantity
        '
        Me.CurrentQuantity.DataPropertyName = "CurrentQuantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CurrentQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.CurrentQuantity.HeaderText = "Cantidad Actual"
        Me.CurrentQuantity.Name = "CurrentQuantity"
        Me.CurrentQuantity.ReadOnly = True
        Me.CurrentQuantity.Width = 70
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.UoM.DefaultCellStyle = DataGridViewCellStyle6
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.ReadOnly = True
        Me.UoM.Width = 50
        '
        'Status
        '
        Me.Status.DataPropertyName = "StatusDescription"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Status.DefaultCellStyle = DataGridViewCellStyle7
        Me.Status.HeaderText = "Estatus"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 60
        '
        'RedTag
        '
        Me.RedTag.DataPropertyName = "RedTag"
        Me.RedTag.HeaderText = "Bloqueado por Calidad"
        Me.RedTag.Name = "RedTag"
        Me.RedTag.ReadOnly = True
        Me.RedTag.Width = 80
        '
        'InvoiceTrouble
        '
        Me.InvoiceTrouble.DataPropertyName = "InvoiceTrouble"
        Me.InvoiceTrouble.HeaderText = "Problema de Pago"
        Me.InvoiceTrouble.Name = "InvoiceTrouble"
        Me.InvoiceTrouble.ReadOnly = True
        Me.InvoiceTrouble.Width = 80
        '
        'Location_
        '
        Me.Location_.DataPropertyName = "Location"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Location_.DefaultCellStyle = DataGridViewCellStyle8
        Me.Location_.HeaderText = "Localizacion"
        Me.Location_.Name = "Location_"
        Me.Location_.ReadOnly = True
        Me.Location_.Width = 80
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "WarehouseName"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Warehouse.DefaultCellStyle = DataGridViewCellStyle9
        Me.Warehouse.HeaderText = "Estacion"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        Me.Warehouse.Width = 60
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle10.Format = "g"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle10
        Me.Date_.HeaderText = "Fecha de Etiquetado"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        '
        'DateEmpty
        '
        Me.DateEmpty.DataPropertyName = "DateEmpty"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle11.Format = "g"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DateEmpty.DefaultCellStyle = DataGridViewCellStyle11
        Me.DateEmpty.HeaderText = "Fecha de Vacio"
        Me.DateEmpty.Name = "DateEmpty"
        Me.DateEmpty.ReadOnly = True
        '
        'details_btn
        '
        Me.details_btn.HeaderText = ""
        Me.details_btn.Name = "details_btn"
        Me.details_btn.ReadOnly = True
        Me.details_btn.Width = 30
        '
        'Smk_FindSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 562)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Tracker_chk)
        Me.Controls.Add(Me.Quality_chk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Receiving_chk)
        Me.Controls.Add(Me.Empty_chk)
        Me.Controls.Add(Me.Service_chk)
        Me.Controls.Add(Me.Random_chk)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.Partnumber_rb)
        Me.Controls.Add(Me.Serial_rb)
        Me.Name = "Smk_FindSerial"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Serial_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Random_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Service_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Empty_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Receiving_chk As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Consumption_lbl As System.Windows.Forms.Label
    Friend WithEvents UoM_lbl As System.Windows.Forms.Label
    Friend WithEvents Location_lbl As System.Windows.Forms.Label
    Friend WithEvents Quality_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Tracker_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Supplier_lbl As System.Windows.Forms.Label
    Friend WithEvents Total_lbl As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdPack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RedTag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InvoiceTrouble As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateEmpty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents details_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
