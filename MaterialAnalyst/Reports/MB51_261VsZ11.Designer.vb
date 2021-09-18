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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MB51_261VsZ11))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.chrtMain = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvReport = New CAguilar.DataGridViewWithFilters()
        Me.rbAccumulated = New System.Windows.Forms.RadioButton()
        Me.rbDailyDifference = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Sloc_cbo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        CType(Me.chrtMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(520, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Hasta:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(398, 35)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(121, 20)
        Me.dtpFrom.TabIndex = 22
        '
        'btnRun
        '
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(879, 33)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(100, 25)
        Me.btnRun.TabIndex = 21
        Me.btnRun.Text = "Ejecutar"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Desde:"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(559, 35)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(121, 20)
        Me.dtpTo.TabIndex = 18
        '
        'chrtMain
        '
        Me.chrtMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.Name = "ChartArea1"
        Me.chrtMain.ChartAreas.Add(ChartArea1)
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.chrtMain.Legends.Add(Legend1)
        Me.chrtMain.Location = New System.Drawing.Point(9, 72)
        Me.chrtMain.Name = "chrtMain"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chrtMain.Series.Add(Series1)
        Me.chrtMain.Size = New System.Drawing.Size(1123, 260)
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
        Me.dgvReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
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
        Me.dgvReport.DefaultRowFilter = Nothing
        Me.dgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvReport.EnableHeadersVisualStyles = False
        Me.dgvReport.GridColor = System.Drawing.Color.DimGray
        Me.dgvReport.Location = New System.Drawing.Point(9, 338)
        Me.dgvReport.MultiSelect = False
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.ShowRowNumber = True
        Me.dgvReport.Size = New System.Drawing.Size(1123, 234)
        Me.dgvReport.TabIndex = 25
        '
        'rbAccumulated
        '
        Me.rbAccumulated.AutoSize = True
        Me.rbAccumulated.Checked = True
        Me.rbAccumulated.Location = New System.Drawing.Point(688, 37)
        Me.rbAccumulated.Name = "rbAccumulated"
        Me.rbAccumulated.Size = New System.Drawing.Size(78, 17)
        Me.rbAccumulated.TabIndex = 26
        Me.rbAccumulated.TabStop = True
        Me.rbAccumulated.Text = "Acumulado"
        Me.rbAccumulated.UseVisualStyleBackColor = True
        '
        'rbDailyDifference
        '
        Me.rbDailyDifference.AutoSize = True
        Me.rbDailyDifference.Location = New System.Drawing.Point(767, 38)
        Me.rbDailyDifference.Name = "rbDailyDifference"
        Me.rbDailyDifference.Size = New System.Drawing.Size(103, 17)
        Me.rbDailyDifference.TabIndex = 27
        Me.rbDailyDifference.Text = "Diferencia Diaria"
        Me.rbDailyDifference.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Numero de parte:"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(104, 35)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(118, 20)
        Me.Partnumber_txt.TabIndex = 32
        Me.Partnumber_txt.Text = "*"
        '
        'Sloc_cbo
        '
        Me.Sloc_cbo.FormattingEnabled = True
        Me.Sloc_cbo.Items.AddRange(New Object() {"0001", "0002", "0004", "0006", "0007", "0008", "0009", "SQPI", "SRCI"})
        Me.Sloc_cbo.Location = New System.Drawing.Point(259, 35)
        Me.Sloc_cbo.Name = "Sloc_cbo"
        Me.Sloc_cbo.Size = New System.Drawing.Size(96, 21)
        Me.Sloc_cbo.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "SLoc:"
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
        Me.Title_lbl.Size = New System.Drawing.Size(263, 26)
        Me.Title_lbl.Text = "Analisis  de Movimientos en SAP"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1140, 29)
        Me.ToolStripMain.TabIndex = 60
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'MB51_261VsZ11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 575)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Sloc_cbo)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chrtMain)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.rbDailyDifference)
        Me.Controls.Add(Me.rbAccumulated)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpTo)
        Me.Name = "MB51_261VsZ11"
        Me.ShowIcon = False
        Me.Text = "Material Analyst"
        CType(Me.chrtMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chrtMain As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvReport As CAguilar.DataGridViewWithFilters
    Friend WithEvents rbAccumulated As System.Windows.Forms.RadioButton
    Friend WithEvents rbDailyDifference As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Sloc_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
End Class
