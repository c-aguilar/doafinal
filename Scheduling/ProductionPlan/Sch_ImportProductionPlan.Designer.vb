<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_ImportProductionPlan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_ImportProductionPlan))
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Open_btn = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Filename_txt = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProductionPlan_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ColumnHeader_rb = New System.Windows.Forms.RadioButton()
        Me.List_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NewMaterials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdPack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Business = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.StartProduction = New CAguilar.CalendarColumnOnlyDate()
        Me.EndProduction = New CAguilar.CalendarColumnOnlyDate()
        Me.Class_Material = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MRP = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NewBoards_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Board = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Class_Board = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Volume = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ShiftCombination = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.InstalledCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RealCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BusinessBoard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAP_btn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Materials_tab = New System.Windows.Forms.TabPage()
        Me.Boards_tab = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.ProductionPlan_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NewMaterials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewBoards_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Materials_tab.SuspendLayout()
        Me.Boards_tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Open_btn
        '
        Me.Open_btn.Image = CType(resources.GetObject("Open_btn.Image"), System.Drawing.Image)
        Me.Open_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Open_btn.Location = New System.Drawing.Point(343, 37)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(100, 25)
        Me.Open_btn.TabIndex = 26
        Me.Open_btn.Text = "Abrir..."
        Me.Open_btn.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 43)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(46, 13)
        Me.label1.TabIndex = 25
        Me.label1.Text = "Archivo:"
        '
        'Filename_txt
        '
        Me.Filename_txt.Location = New System.Drawing.Point(59, 40)
        Me.Filename_txt.Name = "Filename_txt"
        Me.Filename_txt.ReadOnly = True
        Me.Filename_txt.Size = New System.Drawing.Size(278, 20)
        Me.Filename_txt.TabIndex = 24
        '
        'Save_btn
        '
        Me.Save_btn.Enabled = False
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(606, 37)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 23
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1184, 25)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Importar Plan de Producción"
        '
        'ProductionPlan_dgv
        '
        Me.ProductionPlan_dgv.AllowColumnHiding = True
        Me.ProductionPlan_dgv.AllowUserToAddRows = False
        Me.ProductionPlan_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ProductionPlan_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ProductionPlan_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductionPlan_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductionPlan_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ProductionPlan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductionPlan_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProductionPlan_dgv.DefaultRowFilter = Nothing
        Me.ProductionPlan_dgv.EnableHeadersVisualStyles = False
        Me.ProductionPlan_dgv.Location = New System.Drawing.Point(5, 85)
        Me.ProductionPlan_dgv.Name = "ProductionPlan_dgv"
        Me.ProductionPlan_dgv.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductionPlan_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ProductionPlan_dgv.ShowRowNumber = True
        Me.ProductionPlan_dgv.Size = New System.Drawing.Size(1174, 387)
        Me.ProductionPlan_dgv.TabIndex = 27
        '
        'ColumnHeader_rb
        '
        Me.ColumnHeader_rb.AutoSize = True
        Me.ColumnHeader_rb.Checked = True
        Me.ColumnHeader_rb.Location = New System.Drawing.Point(74, 13)
        Me.ColumnHeader_rb.Name = "ColumnHeader_rb"
        Me.ColumnHeader_rb.Size = New System.Drawing.Size(72, 17)
        Me.ColumnHeader_rb.TabIndex = 28
        Me.ColumnHeader_rb.TabStop = True
        Me.ColumnHeader_rb.Text = "Horizontal"
        Me.ColumnHeader_rb.UseVisualStyleBackColor = True
        '
        'List_rb
        '
        Me.List_rb.AutoSize = True
        Me.List_rb.Location = New System.Drawing.Point(8, 13)
        Me.List_rb.Name = "List_rb"
        Me.List_rb.Size = New System.Drawing.Size(60, 17)
        Me.List_rb.TabIndex = 29
        Me.List_rb.Text = "Vertical"
        Me.List_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ColumnHeader_rb)
        Me.GroupBox1.Controls.Add(Me.List_rb)
        Me.GroupBox1.Location = New System.Drawing.Point(449, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 38)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Formato"
        '
        'NewMaterials_dgv
        '
        Me.NewMaterials_dgv.AllowColumnHiding = True
        Me.NewMaterials_dgv.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NewMaterials_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.NewMaterials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewMaterials_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewMaterials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.NewMaterials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NewMaterials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material, Me.CustomerPN, Me.Description, Me.StdPack, Me.Business, Me.StartProduction, Me.EndProduction, Me.Class_Material, Me.MRP})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NewMaterials_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.NewMaterials_dgv.DefaultRowFilter = Nothing
        Me.NewMaterials_dgv.EnableHeadersVisualStyles = False
        Me.NewMaterials_dgv.Location = New System.Drawing.Point(3, 3)
        Me.NewMaterials_dgv.Name = "NewMaterials_dgv"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewMaterials_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.NewMaterials_dgv.ShowRowNumber = True
        Me.NewMaterials_dgv.Size = New System.Drawing.Size(1160, 212)
        Me.NewMaterials_dgv.TabIndex = 31
        '
        'Material
        '
        Me.Material.DataPropertyName = "Material"
        Me.Material.HeaderText = "Material"
        Me.Material.Name = "Material"
        Me.Material.ReadOnly = True
        Me.Material.Width = 90
        '
        'CustomerPN
        '
        Me.CustomerPN.DataPropertyName = "CustomerPN"
        Me.CustomerPN.HeaderText = "NP. de Cliente"
        Me.CustomerPN.Name = "CustomerPN"
        Me.CustomerPN.Width = 110
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Descripcion"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 200
        '
        'StdPack
        '
        Me.StdPack.DataPropertyName = "StdPack"
        Me.StdPack.HeaderText = "StdPack"
        Me.StdPack.Name = "StdPack"
        Me.StdPack.Width = 60
        '
        'Business
        '
        Me.Business.DataPropertyName = "Business"
        Me.Business.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Business.HeaderText = "Negocio"
        Me.Business.Name = "Business"
        Me.Business.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Business.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Business.Width = 250
        '
        'StartProduction
        '
        Me.StartProduction.DataPropertyName = "StartProduction"
        Me.StartProduction.HeaderText = "Inicio de Producción"
        Me.StartProduction.Name = "StartProduction"
        Me.StartProduction.Width = 90
        '
        'EndProduction
        '
        Me.EndProduction.DataPropertyName = "EndProduction"
        Me.EndProduction.HeaderText = "Fin de Producción"
        Me.EndProduction.Name = "EndProduction"
        Me.EndProduction.Width = 90
        '
        'Class_Material
        '
        Me.Class_Material.DataPropertyName = "Class"
        Me.Class_Material.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Class_Material.HeaderText = "Clase"
        Me.Class_Material.Name = "Class_Material"
        '
        'MRP
        '
        Me.MRP.DataPropertyName = "MRP"
        Me.MRP.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.MRP.HeaderText = "MRP"
        Me.MRP.Name = "MRP"
        Me.MRP.Width = 50
        '
        'NewBoards_dgv
        '
        Me.NewBoards_dgv.AllowColumnHiding = True
        Me.NewBoards_dgv.AllowUserToAddRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NewBoards_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.NewBoards_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewBoards_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewBoards_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.NewBoards_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NewBoards_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Board, Me.Class_Board, Me.Volume, Me.ShiftCombination, Me.InstalledCapacity, Me.RealCapacity, Me.BusinessBoard})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NewBoards_dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.NewBoards_dgv.DefaultRowFilter = Nothing
        Me.NewBoards_dgv.EnableHeadersVisualStyles = False
        Me.NewBoards_dgv.Location = New System.Drawing.Point(3, 3)
        Me.NewBoards_dgv.Name = "NewBoards_dgv"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewBoards_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.NewBoards_dgv.ShowRowNumber = True
        Me.NewBoards_dgv.Size = New System.Drawing.Size(1160, 246)
        Me.NewBoards_dgv.TabIndex = 33
        '
        'Board
        '
        Me.Board.DataPropertyName = "Board"
        Me.Board.HeaderText = "Tablero"
        Me.Board.Name = "Board"
        Me.Board.Width = 200
        '
        'Class_Board
        '
        Me.Class_Board.DataPropertyName = "Class"
        Me.Class_Board.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Class_Board.HeaderText = "Clase"
        Me.Class_Board.Name = "Class_Board"
        Me.Class_Board.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Class_Board.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Class_Board.Width = 60
        '
        'Volume
        '
        Me.Volume.DataPropertyName = "Volume"
        Me.Volume.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Volume.HeaderText = "Volumen"
        Me.Volume.Name = "Volume"
        Me.Volume.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Volume.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Volume.Width = 60
        '
        'ShiftCombination
        '
        Me.ShiftCombination.DataPropertyName = "ShiftCombination"
        Me.ShiftCombination.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ShiftCombination.HeaderText = "Turno"
        Me.ShiftCombination.Name = "ShiftCombination"
        Me.ShiftCombination.Width = 60
        '
        'InstalledCapacity
        '
        Me.InstalledCapacity.DataPropertyName = "InstalledCapacity"
        Me.InstalledCapacity.HeaderText = "Capacidad Instalada"
        Me.InstalledCapacity.Name = "InstalledCapacity"
        Me.InstalledCapacity.Width = 70
        '
        'RealCapacity
        '
        Me.RealCapacity.DataPropertyName = "RealCapacity"
        Me.RealCapacity.HeaderText = "Capacidad Real"
        Me.RealCapacity.Name = "RealCapacity"
        Me.RealCapacity.Width = 70
        '
        'BusinessBoard
        '
        Me.BusinessBoard.DataPropertyName = "Business"
        Me.BusinessBoard.HeaderText = "Negocio"
        Me.BusinessBoard.Name = "BusinessBoard"
        Me.BusinessBoard.ReadOnly = True
        Me.BusinessBoard.Width = 250
        '
        'SAP_btn
        '
        Me.SAP_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAP_btn.Enabled = False
        Me.SAP_btn.Image = CType(resources.GetObject("SAP_btn.Image"), System.Drawing.Image)
        Me.SAP_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAP_btn.Location = New System.Drawing.Point(1007, 221)
        Me.SAP_btn.Name = "SAP_btn"
        Me.SAP_btn.Size = New System.Drawing.Size(153, 25)
        Me.SAP_btn.TabIndex = 36
        Me.SAP_btn.Text = "Descargar desde SAP"
        Me.SAP_btn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Plan de Producción:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.Materials_tab)
        Me.TabControl1.Controls.Add(Me.Boards_tab)
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(5, 478)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1174, 279)
        Me.TabControl1.TabIndex = 38
        '
        'Materials_tab
        '
        Me.Materials_tab.Controls.Add(Me.NewMaterials_dgv)
        Me.Materials_tab.Controls.Add(Me.SAP_btn)
        Me.Materials_tab.ImageKey = "car.png"
        Me.Materials_tab.Location = New System.Drawing.Point(4, 23)
        Me.Materials_tab.Name = "Materials_tab"
        Me.Materials_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Materials_tab.Size = New System.Drawing.Size(1166, 252)
        Me.Materials_tab.TabIndex = 0
        Me.Materials_tab.Text = "Arneses Nuevos"
        Me.Materials_tab.UseVisualStyleBackColor = True
        '
        'Boards_tab
        '
        Me.Boards_tab.Controls.Add(Me.NewBoards_dgv)
        Me.Boards_tab.ImageKey = "billboard_empty.png"
        Me.Boards_tab.Location = New System.Drawing.Point(4, 23)
        Me.Boards_tab.Name = "Boards_tab"
        Me.Boards_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Boards_tab.Size = New System.Drawing.Size(1166, 252)
        Me.Boards_tab.TabIndex = 1
        Me.Boards_tab.Text = "Tableros Nuevos"
        Me.Boards_tab.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "car.png")
        Me.ImageList1.Images.SetKeyName(1, "billboard_empty.png")
        '
        'Sch_ImportProductionPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 762)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProductionPlan_dgv)
        Me.Controls.Add(Me.Open_btn)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.Filename_txt)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label4)
        Me.Name = "Sch_ImportProductionPlan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scheduling"
        CType(Me.ProductionPlan_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NewMaterials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewBoards_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Materials_tab.ResumeLayout(False)
        Me.Boards_tab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Filename_txt As System.Windows.Forms.TextBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProductionPlan_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ColumnHeader_rb As System.Windows.Forms.RadioButton
    Friend WithEvents List_rb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NewMaterials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents NewBoards_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents SAP_btn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Materials_tab As System.Windows.Forms.TabPage
    Friend WithEvents Boards_tab As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Material As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdPack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Business As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents StartProduction As CAguilar.CalendarColumnOnlyDate
    Friend WithEvents EndProduction As CAguilar.CalendarColumnOnlyDate
    Friend WithEvents Class_Material As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MRP As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Board As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Class_Board As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Volume As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ShiftCombination As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents InstalledCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RealCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BusinessBoard As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
