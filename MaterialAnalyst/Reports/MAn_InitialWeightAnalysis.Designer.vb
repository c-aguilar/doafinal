<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAn_InitialWeightAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAn_InitialWeightAnalysis))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Data_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Weight_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DeltaFrom_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DeltaTo_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Data_txt = New System.Windows.Forms.RichTextBox()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeightDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containerid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Container = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContainerWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InitialWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalculatedUnitWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cancel_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Data_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Weight_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(88, 35)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.Partnumber_txt.TabIndex = 64
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1184, 29)
        Me.ToolStripMain.TabIndex = 63
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
        Me.Title_lbl.Size = New System.Drawing.Size(215, 26)
        Me.Title_lbl.Text = "Análisis de Pesos Iniciales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "No. de Parte:"
        '
        'Data_dgv
        '
        Me.Data_dgv.AllowColumnHiding = True
        Me.Data_dgv.AllowUserToAddRows = False
        Me.Data_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Data_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Data_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Data_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Data_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Data_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.serialnumber, Me.partnumber, Me.quantity, Me.uom, Me._date, Me.WeightDate, Me.containerid, Me.Container, Me.ContainerWeight, Me.InitialWeight, Me.CalculatedUnitWeight, Me.cancel_btn})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Data_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Data_dgv.DefaultRowFilter = Nothing
        Me.Data_dgv.EnableHeadersVisualStyles = False
        Me.Data_dgv.Location = New System.Drawing.Point(12, 430)
        Me.Data_dgv.Name = "Data_dgv"
        Me.Data_dgv.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Data_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Data_dgv.ShowRowNumber = True
        Me.Data_dgv.Size = New System.Drawing.Size(1160, 319)
        Me.Data_dgv.TabIndex = 90
        '
        'Weight_chart
        '
        Me.Weight_chart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.LabelAutoFitStyle = CType(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea1.Name = "ChartArea1"
        Me.Weight_chart.ChartAreas.Add(ChartArea1)
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.Weight_chart.Legends.Add(Legend1)
        Me.Weight_chart.Location = New System.Drawing.Point(12, 61)
        Me.Weight_chart.Name = "Weight_chart"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series1.Legend = "Legend1"
        Series1.MarkerColor = System.Drawing.Color.DodgerBlue
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Peso Calculado"
        Series1.XValueMember = "Serialnumber"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series1.YValueMembers = "CalculatedUnitWeight"
        Series1.YValuesPerPoint = 2
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.Weight_chart.Series.Add(Series1)
        Me.Weight_chart.Size = New System.Drawing.Size(1021, 363)
        Me.Weight_chart.TabIndex = 91
        Me.Weight_chart.Text = "Chart1"
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(568, 33)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 96
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(211, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Delta desde:"
        '
        'DeltaFrom_dtp
        '
        Me.DeltaFrom_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.DeltaFrom_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaFrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DeltaFrom_dtp.Location = New System.Drawing.Point(284, 35)
        Me.DeltaFrom_dtp.Name = "DeltaFrom_dtp"
        Me.DeltaFrom_dtp.Size = New System.Drawing.Size(115, 20)
        Me.DeltaFrom_dtp.TabIndex = 92
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "hasta:"
        '
        'DeltaTo_dtp
        '
        Me.DeltaTo_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.DeltaTo_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaTo_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DeltaTo_dtp.Location = New System.Drawing.Point(447, 35)
        Me.DeltaTo_dtp.Name = "DeltaTo_dtp"
        Me.DeltaTo_dtp.Size = New System.Drawing.Size(115, 20)
        Me.DeltaTo_dtp.TabIndex = 94
        '
        'Data_txt
        '
        Me.Data_txt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Data_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Data_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Data_txt.Location = New System.Drawing.Point(1039, 61)
        Me.Data_txt.Name = "Data_txt"
        Me.Data_txt.Size = New System.Drawing.Size(133, 235)
        Me.Data_txt.TabIndex = 97
        Me.Data_txt.Text = "No. de Parte:" & Global.Microsoft.VisualBasic.ChrW(10) & "M1234565" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Proveedor:" & Global.Microsoft.VisualBasic.ChrW(10) & "10499829" & Global.Microsoft.VisualBasic.ChrW(10) & "aptiv services" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Peso Unitario:" & Global.Microsoft.VisualBasic.ChrW(10) & "0.0988" & _
    "9"
        '
        'id
        '
        Me.id.DataPropertyName = "ID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle3
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 70
        '
        'serialnumber
        '
        Me.serialnumber.DataPropertyName = "Serialnumber"
        Me.serialnumber.HeaderText = "No. de Serie"
        Me.serialnumber.Name = "serialnumber"
        Me.serialnumber.ReadOnly = True
        Me.serialnumber.Width = 120
        '
        'partnumber
        '
        Me.partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.partnumber.HeaderText = "No. de Parte"
        Me.partnumber.Name = "partnumber"
        Me.partnumber.ReadOnly = True
        Me.partnumber.Width = 80
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "Quantity"
        Me.quantity.HeaderText = "Cantidad"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'uom
        '
        Me.uom.DataPropertyName = "BuM"
        Me.uom.HeaderText = "Unidad"
        Me.uom.Name = "uom"
        Me.uom.ReadOnly = True
        Me.uom.Width = 80
        '
        '_date
        '
        Me._date.DataPropertyName = "Date"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        Me._date.DefaultCellStyle = DataGridViewCellStyle5
        Me._date.HeaderText = "Fecha Llegada"
        Me._date.Name = "_date"
        Me._date.ReadOnly = True
        '
        'WeightDate
        '
        Me.WeightDate.DataPropertyName = "WeightDate"
        Me.WeightDate.HeaderText = "Fecha de Pesaje"
        Me.WeightDate.Name = "WeightDate"
        Me.WeightDate.ReadOnly = True
        '
        'containerid
        '
        Me.containerid.DataPropertyName = "ContainerID"
        Me.containerid.HeaderText = "ID Contenedor"
        Me.containerid.Name = "containerid"
        Me.containerid.ReadOnly = True
        '
        'Container
        '
        Me.Container.DataPropertyName = "ContainerName"
        Me.Container.HeaderText = "Contenedor"
        Me.Container.Name = "Container"
        Me.Container.ReadOnly = True
        '
        'ContainerWeight
        '
        Me.ContainerWeight.DataPropertyName = "ContainerWeight"
        Me.ContainerWeight.HeaderText = "Peso Contenedor"
        Me.ContainerWeight.Name = "ContainerWeight"
        Me.ContainerWeight.ReadOnly = True
        '
        'InitialWeight
        '
        Me.InitialWeight.DataPropertyName = "InitialWeight"
        Me.InitialWeight.HeaderText = "Peso Inicial"
        Me.InitialWeight.Name = "InitialWeight"
        Me.InitialWeight.ReadOnly = True
        '
        'CalculatedUnitWeight
        '
        Me.CalculatedUnitWeight.DataPropertyName = "CalculatedUnitWeight"
        Me.CalculatedUnitWeight.HeaderText = "P.Unitario Calculado"
        Me.CalculatedUnitWeight.Name = "CalculatedUnitWeight"
        Me.CalculatedUnitWeight.ReadOnly = True
        '
        'cancel_btn
        '
        Me.cancel_btn.DefaultImage = Nothing
        Me.cancel_btn.DefaultText = ""
        Me.cancel_btn.HeaderText = ""
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.ReadOnly = True
        Me.cancel_btn.Visible = False
        Me.cancel_btn.Width = 40
        '
        'MAn_InitialWeightAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.Data_txt)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DeltaFrom_dtp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DeltaTo_dtp)
        Me.Controls.Add(Me.Weight_chart)
        Me.Controls.Add(Me.Data_dgv)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MAn_InitialWeightAnalysis"
        Me.ShowIcon = False
        Me.Text = "Material Analyst"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Data_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Weight_chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Data_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Weight_chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DeltaFrom_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DeltaTo_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Data_txt As System.Windows.Forms.RichTextBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents containerid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InitialWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalculatedUnitWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cancel_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
