<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_Workload
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_Workload))
        Me.cboRoutes = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ctWorkload = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.route = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.business = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.boards = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.walkings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.frequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.workload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvActual = New System.Windows.Forms.DataGridView()
        Me.a_business = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.a_board = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAll = New System.Windows.Forms.DataGridView()
        Me.all_Business = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.all_board = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ctWorkload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboRoutes
        '
        Me.cboRoutes.FormattingEnabled = True
        Me.cboRoutes.Location = New System.Drawing.Point(54, 11)
        Me.cboRoutes.Name = "cboRoutes"
        Me.cboRoutes.Size = New System.Drawing.Size(142, 21)
        Me.cboRoutes.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Ruta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Tableros relacionados:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(270, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Universo de tableros:"
        '
        'ctWorkload
        '
        ChartArea1.Area3DStyle.Inclination = 5
        ChartArea1.Area3DStyle.Rotation = 2
        ChartArea1.Area3DStyle.WallWidth = 2
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisY.LineWidth = 0
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.Name = "ChartArea1"
        Me.ctWorkload.ChartAreas.Add(ChartArea1)
        Me.ctWorkload.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ctWorkload.Location = New System.Drawing.Point(0, 383)
        Me.ctWorkload.Name = "ctWorkload"
        Me.ctWorkload.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series1.ChartArea = "ChartArea1"
        Series1.IsValueShownAsLabel = True
        Series1.LabelFormat = "{#'%'}"
        Series1.Name = "Series1"
        Series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Me.ctWorkload.Series.Add(Series1)
        Me.ctWorkload.Size = New System.Drawing.Size(670, 322)
        Me.ctWorkload.TabIndex = 20
        Me.ctWorkload.Text = "Chart1"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.route, Me.business, Me.boards, Me.containers, Me.walkings, Me.frequency, Me.workload})
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.Location = New System.Drawing.Point(0, 0)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.RowHeadersVisible = False
        Me.dgvResult.Size = New System.Drawing.Size(670, 383)
        Me.dgvResult.TabIndex = 21
        '
        'route
        '
        Me.route.DataPropertyName = "route"
        Me.route.HeaderText = "Ruta"
        Me.route.Name = "route"
        Me.route.ReadOnly = True
        Me.route.Width = 80
        '
        'business
        '
        Me.business.DataPropertyName = "business"
        Me.business.HeaderText = "Negocios"
        Me.business.Name = "business"
        Me.business.ReadOnly = True
        Me.business.Width = 75
        '
        'boards
        '
        Me.boards.DataPropertyName = "boards"
        Me.boards.HeaderText = "Tableros"
        Me.boards.Name = "boards"
        Me.boards.ReadOnly = True
        Me.boards.Width = 75
        '
        'containers
        '
        Me.containers.DataPropertyName = "containers"
        Me.containers.HeaderText = "Total Contenedores"
        Me.containers.Name = "containers"
        Me.containers.ReadOnly = True
        Me.containers.Width = 75
        '
        'walkings
        '
        Me.walkings.DataPropertyName = "walkings"
        Me.walkings.HeaderText = "Total Caminares"
        Me.walkings.Name = "walkings"
        Me.walkings.ReadOnly = True
        Me.walkings.Width = 75
        '
        'frequency
        '
        Me.frequency.DataPropertyName = "frequency"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.frequency.DefaultCellStyle = DataGridViewCellStyle1
        Me.frequency.HeaderText = "Frecuencia Promedio"
        Me.frequency.Name = "frequency"
        Me.frequency.ReadOnly = True
        Me.frequency.Width = 75
        '
        'workload
        '
        Me.workload.DataPropertyName = "workload"
        DataGridViewCellStyle2.Format = "#.##%"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.workload.DefaultCellStyle = DataGridViewCellStyle2
        Me.workload.HeaderText = "Carga de Trabajo"
        Me.workload.Name = "workload"
        Me.workload.ReadOnly = True
        Me.workload.Width = 75
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(221, 200)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(45, 45)
        Me.btnAdd.TabIndex = 22
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(221, 251)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(45, 45)
        Me.btnDelete.TabIndex = 23
        '
        'dgvActual
        '
        Me.dgvActual.AllowUserToAddRows = False
        Me.dgvActual.AllowUserToDeleteRows = False
        Me.dgvActual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvActual.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.dgvActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActual.ColumnHeadersVisible = False
        Me.dgvActual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.a_business, Me.a_board})
        Me.dgvActual.Location = New System.Drawing.Point(15, 61)
        Me.dgvActual.MultiSelect = False
        Me.dgvActual.Name = "dgvActual"
        Me.dgvActual.ReadOnly = True
        Me.dgvActual.RowHeadersVisible = False
        Me.dgvActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvActual.Size = New System.Drawing.Size(200, 632)
        Me.dgvActual.TabIndex = 24
        '
        'a_business
        '
        Me.a_business.FillWeight = 98.47717!
        Me.a_business.HeaderText = "Negocio"
        Me.a_business.Name = "a_business"
        Me.a_business.ReadOnly = True
        Me.a_business.Width = 120
        '
        'a_board
        '
        Me.a_board.FillWeight = 101.5228!
        Me.a_board.HeaderText = "Tablero"
        Me.a_board.Name = "a_board"
        Me.a_board.ReadOnly = True
        Me.a_board.Width = 70
        '
        'dgvAll
        '
        Me.dgvAll.AllowUserToAddRows = False
        Me.dgvAll.AllowUserToDeleteRows = False
        Me.dgvAll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvAll.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAll.ColumnHeadersVisible = False
        Me.dgvAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.all_Business, Me.all_board})
        Me.dgvAll.Location = New System.Drawing.Point(273, 61)
        Me.dgvAll.MultiSelect = False
        Me.dgvAll.Name = "dgvAll"
        Me.dgvAll.ReadOnly = True
        Me.dgvAll.RowHeadersVisible = False
        Me.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAll.Size = New System.Drawing.Size(200, 632)
        Me.dgvAll.TabIndex = 25
        '
        'all_Business
        '
        Me.all_Business.FillWeight = 98.47717!
        Me.all_Business.HeaderText = "Negocio"
        Me.all_Business.Name = "all_Business"
        Me.all_Business.ReadOnly = True
        Me.all_Business.Width = 120
        '
        'all_board
        '
        Me.all_board.FillWeight = 101.5228!
        Me.all_board.HeaderText = "Tablero"
        Me.all_board.Name = "all_board"
        Me.all_board.ReadOnly = True
        Me.all_board.Width = 70
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboRoutes)
        Me.Panel1.Controls.Add(Me.dgvAll)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dgvActual)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(483, 705)
        Me.Panel1.TabIndex = 26
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvResult)
        Me.Panel2.Controls.Add(Me.ctWorkload)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(483, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(670, 705)
        Me.Panel2.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1153, 25)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Carga de Trabajo"
        '
        'CDR_Workload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1153, 730)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CDR_Workload"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        CType(Me.ctWorkload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboRoutes As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ctWorkload As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dgvActual As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAll As System.Windows.Forms.DataGridView
    Friend WithEvents a_business As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents a_board As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents all_Business As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents all_board As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents route As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents business As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents boards As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents containers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents walkings As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents frequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents workload As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
