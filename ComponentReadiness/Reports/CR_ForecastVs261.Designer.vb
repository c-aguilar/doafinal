<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ForecastVs261
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ForecastVs261))
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Items_btn = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Copy_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Pieces_rb = New System.Windows.Forms.RadioButton()
        Me.Cost_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Plant_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Report_dgv.Location = New System.Drawing.Point(6, 77)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(972, 380)
        Me.Report_dgv.TabIndex = 62
        '
        'Items_btn
        '
        Me.Items_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Items_btn.Image = CType(resources.GetObject("Items_btn.Image"), System.Drawing.Image)
        Me.Items_btn.Location = New System.Drawing.Point(291, 11)
        Me.Items_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Items_btn.Name = "Items_btn"
        Me.Items_btn.Size = New System.Drawing.Size(23, 23)
        Me.Items_btn.TabIndex = 61
        Me.Items_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Items_btn.UseVisualStyleBackColor = False
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Location = New System.Drawing.Point(174, 13)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.Partnumber_txt.TabIndex = 60
        Me.Partnumber_txt.Text = "*"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Copy_btn, Me.Find_btn, Me.toolStripSeparator1, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 29)
        Me.ToolStripMain.TabIndex = 59
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
        'Copy_btn
        '
        Me.Copy_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Copy_btn.Image = CType(resources.GetObject("Copy_btn.Image"), System.Drawing.Image)
        Me.Copy_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Copy_btn.Name = "Copy_btn"
        Me.Copy_btn.Size = New System.Drawing.Size(23, 26)
        Me.Copy_btn.Text = "&Copy"
        Me.Copy_btn.ToolTipText = "Copiar"
        '
        'Find_btn
        '
        Me.Find_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(23, 26)
        Me.Find_btn.Text = "&Find"
        Me.Find_btn.ToolTipText = "Buscar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(239, 26)
        Me.Title_lbl.Text = "Pronostico Vs 261 - Semanal"
        '
        'From_dtp
        '
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_dtp.Location = New System.Drawing.Point(338, 48)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(100, 20)
        Me.From_dtp.TabIndex = 57
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(581, 41)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 56
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(335, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Desde:"
        '
        'Pieces_rb
        '
        Me.Pieces_rb.AutoSize = True
        Me.Pieces_rb.Location = New System.Drawing.Point(64, 14)
        Me.Pieces_rb.Name = "Pieces_rb"
        Me.Pieces_rb.Size = New System.Drawing.Size(56, 17)
        Me.Pieces_rb.TabIndex = 63
        Me.Pieces_rb.Text = "Piezas"
        Me.Pieces_rb.UseVisualStyleBackColor = True
        '
        'Cost_rb
        '
        Me.Cost_rb.AutoSize = True
        Me.Cost_rb.Checked = True
        Me.Cost_rb.Location = New System.Drawing.Point(6, 14)
        Me.Cost_rb.Name = "Cost_rb"
        Me.Cost_rb.Size = New System.Drawing.Size(52, 17)
        Me.Cost_rb.TabIndex = 64
        Me.Cost_rb.TabStop = True
        Me.Cost_rb.Text = "Costo"
        Me.Cost_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cost_rb)
        Me.GroupBox1.Controls.Add(Me.Pieces_rb)
        Me.GroupBox1.Location = New System.Drawing.Point(449, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(126, 39)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sumar:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Plant_rb)
        Me.GroupBox2.Controls.Add(Me.Partnumber_rb)
        Me.GroupBox2.Controls.Add(Me.Items_btn)
        Me.GroupBox2.Controls.Add(Me.Partnumber_txt)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 39)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agrupado por:"
        '
        'Plant_rb
        '
        Me.Plant_rb.AutoSize = True
        Me.Plant_rb.Checked = True
        Me.Plant_rb.Location = New System.Drawing.Point(6, 14)
        Me.Plant_rb.Name = "Plant_rb"
        Me.Plant_rb.Size = New System.Drawing.Size(55, 17)
        Me.Plant_rb.TabIndex = 66
        Me.Plant_rb.TabStop = True
        Me.Plant_rb.Text = "Planta"
        Me.Plant_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Location = New System.Drawing.Point(83, 14)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(88, 17)
        Me.Partnumber_rb.TabIndex = 65
        Me.Partnumber_rb.Text = "No. de Parte:"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'ForecastVs261
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 462)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Label3)
        Me.Name = "ForecastVs261"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Items_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copy_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pieces_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Cost_rb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Plant_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
End Class
