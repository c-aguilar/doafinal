<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_LabeledVsPaid
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_LabeledVsPaid))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Result_dgv = New CAguilar.DataGridViewWithFilters()
        Me.chrPercentSur = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSur = New System.Windows.Forms.Label()
        Me.chrPercentNorte = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblNorte = New System.Windows.Forms.Label()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrPercentSur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.chrPercentNorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Partnumber:"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(106, 32)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(142, 22)
        Me.Partnumber_txt.TabIndex = 20
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.To_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.To_dtp.Location = New System.Drawing.Point(106, 86)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(142, 22)
        Me.To_dtp.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Hasta:"
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.From_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.From_dtp.Location = New System.Drawing.Point(106, 60)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(142, 22)
        Me.From_dtp.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Desde:"
        '
        'Result_dgv
        '
        Me.Result_dgv.AllowColumnHiding = True
        Me.Result_dgv.AllowUserToAddRows = False
        Me.Result_dgv.AllowUserToDeleteRows = False
        Me.Result_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Result_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Result_dgv.Location = New System.Drawing.Point(6, 114)
        Me.Result_dgv.Name = "Result_dgv"
        Me.Result_dgv.ReadOnly = True
        Me.Result_dgv.ShowRowNumber = True
        Me.Result_dgv.Size = New System.Drawing.Size(650, 277)
        Me.Result_dgv.TabIndex = 23
        '
        'chrPercentSur
        '
        Me.chrPercentSur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea3.Name = "ChartArea1"
        Me.chrPercentSur.ChartAreas.Add(ChartArea3)
        Legend3.Alignment = System.Drawing.StringAlignment.Center
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend3.Name = "Legend1"
        Me.chrPercentSur.Legends.Add(Legend3)
        Me.chrPercentSur.Location = New System.Drawing.Point(246, 33)
        Me.chrPercentSur.Name = "chrPercentSur"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.IsValueShownAsLabel = True
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chrPercentSur.Series.Add(Series3)
        Me.chrPercentSur.Size = New System.Drawing.Size(238, 320)
        Me.chrPercentSur.TabIndex = 26
        Me.chrPercentSur.Text = "Chart1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblSur, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chrPercentNorte, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNorte, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chrPercentSur, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(662, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(487, 356)
        Me.TableLayoutPanel1.TabIndex = 27
        '
        'lblSur
        '
        Me.lblSur.AutoSize = True
        Me.lblSur.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSur.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSur.Location = New System.Drawing.Point(246, 6)
        Me.lblSur.Name = "lblSur"
        Me.lblSur.Size = New System.Drawing.Size(238, 24)
        Me.lblSur.TabIndex = 27
        Me.lblSur.Text = "Sur"
        Me.lblSur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chrPercentNorte
        '
        Me.chrPercentNorte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea4.Name = "ChartArea1"
        Me.chrPercentNorte.ChartAreas.Add(ChartArea4)
        Legend4.Alignment = System.Drawing.StringAlignment.Center
        Legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend4.Name = "Legend1"
        Me.chrPercentNorte.Legends.Add(Legend4)
        Me.chrPercentNorte.Location = New System.Drawing.Point(3, 33)
        Me.chrPercentNorte.Name = "chrPercentNorte"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series4.IsValueShownAsLabel = True
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.chrPercentNorte.Series.Add(Series4)
        Me.chrPercentNorte.Size = New System.Drawing.Size(237, 320)
        Me.chrPercentNorte.TabIndex = 24
        Me.chrPercentNorte.Text = "Chart1"
        '
        'lblNorte
        '
        Me.lblNorte.AutoSize = True
        Me.lblNorte.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNorte.Location = New System.Drawing.Point(3, 6)
        Me.lblNorte.Name = "lblNorte"
        Me.lblNorte.Size = New System.Drawing.Size(237, 24)
        Me.lblNorte.TabIndex = 28
        Me.lblNorte.Text = "Norte"
        Me.lblNorte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(254, 31)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 28
        Me.Run_btn.Text = "Run"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.ToolStripLabel1})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1151, 29)
        Me.ToolStripMain.TabIndex = 40
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(222, 26)
        Me.ToolStripLabel1.Text = "Etiquetado Vs Almacenado"
        '
        'Rec_LabeledVsPaid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1151, 396)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Result_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Rec_LabeledVsPaid"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chrPercentSur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.chrPercentNorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Result_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents chrPercentSur As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSur As System.Windows.Forms.Label
    Friend WithEvents chrPercentNorte As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblNorte As System.Windows.Forms.Label
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
