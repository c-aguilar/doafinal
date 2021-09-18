<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MB51_261VsZ11
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MB51_261VsZ11))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.chrtMain = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvReport = New CAguilar.DataGridViewWithFilters()
        Me.rbAccumulated = New System.Windows.Forms.RadioButton()
        Me.rbDailyDifference = New System.Windows.Forms.RadioButton()
        Me.cmsReports = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        CType(Me.chrtMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsReports.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Hasta:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(182, 28)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(121, 20)
        Me.dtpFrom.TabIndex = 22
        '
        'btnRun
        '
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(435, 46)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(100, 25)
        Me.btnRun.TabIndex = 21
        Me.btnRun.Text = "Ejecutar"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1140, 25)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Analisis  de Movimientos 261 Vs Z11"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Desde:"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(182, 54)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(121, 20)
        Me.dtpTo.TabIndex = 18
        '
        'chrtMain
        '
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.Name = "ChartArea1"
        Me.chrtMain.ChartAreas.Add(ChartArea1)
        Me.chrtMain.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.chrtMain.Legends.Add(Legend1)
        Me.chrtMain.Location = New System.Drawing.Point(0, 0)
        Me.chrtMain.Name = "chrtMain"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chrtMain.Series.Add(Series1)
        Me.chrtMain.Size = New System.Drawing.Size(1112, 237)
        Me.chrtMain.TabIndex = 24
        Me.chrtMain.Text = "Chart1"
        '
        'dgvReport
        '
        Me.dgvReport.AllowColumnHiding = True
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvReport.GridColor = System.Drawing.Color.DimGray
        Me.dgvReport.Location = New System.Drawing.Point(0, 0)
        Me.dgvReport.MultiSelect = False
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.ShowRowNumber = True
        Me.dgvReport.Size = New System.Drawing.Size(1112, 234)
        Me.dgvReport.TabIndex = 25
        '
        'rbAccumulated
        '
        Me.rbAccumulated.AutoSize = True
        Me.rbAccumulated.Location = New System.Drawing.Point(309, 33)
        Me.rbAccumulated.Name = "rbAccumulated"
        Me.rbAccumulated.Size = New System.Drawing.Size(78, 17)
        Me.rbAccumulated.TabIndex = 26
        Me.rbAccumulated.Text = "Acumulado"
        Me.rbAccumulated.UseVisualStyleBackColor = True
        '
        'rbDailyDifference
        '
        Me.rbDailyDifference.AutoSize = True
        Me.rbDailyDifference.Checked = True
        Me.rbDailyDifference.Location = New System.Drawing.Point(309, 54)
        Me.rbDailyDifference.Name = "rbDailyDifference"
        Me.rbDailyDifference.Size = New System.Drawing.Size(103, 17)
        Me.rbDailyDifference.TabIndex = 27
        Me.rbDailyDifference.TabStop = True
        Me.rbDailyDifference.Text = "Diferencia Diaria"
        Me.rbDailyDifference.UseVisualStyleBackColor = True
        '
        'cmsReports
        '
        Me.cmsReports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailsToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.cmsReports.Name = "cmsReports"
        Me.cmsReports.Size = New System.Drawing.Size(134, 48)
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ExportToolStripMenuItem.Text = "Export All..."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 80)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chrtMain)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(1116, 483)
        Me.SplitContainer1.SplitterDistance = 241
        Me.SplitContainer1.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Numero de parte:"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(14, 51)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(118, 20)
        Me.Partnumber_txt.TabIndex = 32
        Me.Partnumber_txt.Text = "*"
        '
        'MB51_261VsZ11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 575)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.rbDailyDifference)
        Me.Controls.Add(Me.rbAccumulated)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpTo)
        Me.Name = "MB51_261VsZ11"
        Me.ShowIcon = False
        Me.Text = "Material Analyst"
        CType(Me.chrtMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsReports.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chrtMain As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvReport As CAguilar.DataGridViewWithFilters
    Friend WithEvents rbAccumulated As System.Windows.Forms.RadioButton
    Friend WithEvents rbDailyDifference As System.Windows.Forms.RadioButton
    Friend WithEvents cmsReports As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
End Class
