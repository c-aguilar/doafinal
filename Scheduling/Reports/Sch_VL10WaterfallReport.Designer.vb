<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_VL10WaterfallReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_VL10WaterfallReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Material_txt = New System.Windows.Forms.TextBox()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Waterfall_dgv = New CAguilar.DataGridViewWithFilters()
        Me.OnlyMaterial_rb = New System.Windows.Forms.RadioButton()
        Me.MaterialAndShipTo_rb = New System.Windows.Forms.RadioButton()
        Me.Weekly_rb = New System.Windows.Forms.RadioButton()
        Me.Daily_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Copy_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_btn = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Waterfall_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Material:"
        '
        'Material_txt
        '
        Me.Material_txt.Location = New System.Drawing.Point(58, 40)
        Me.Material_txt.MaxLength = 12
        Me.Material_txt.Name = "Material_txt"
        Me.Material_txt.Size = New System.Drawing.Size(100, 20)
        Me.Material_txt.TabIndex = 18
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = ""
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_dtp.Location = New System.Drawing.Point(224, 40)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(100, 20)
        Me.From_dtp.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(185, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "From:"
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = ""
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.To_dtp.Location = New System.Drawing.Point(359, 40)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(100, 20)
        Me.To_dtp.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(330, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "To:"
        '
        'btnItems
        '
        Me.btnItems.BackColor = System.Drawing.SystemColors.Control
        Me.btnItems.Image = CType(resources.GetObject("btnItems.Image"), System.Drawing.Image)
        Me.btnItems.Location = New System.Drawing.Point(158, 38)
        Me.btnItems.Margin = New System.Windows.Forms.Padding(0)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(23, 23)
        Me.btnItems.TabIndex = 16
        Me.btnItems.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip.SetToolTip(Me.btnItems, "Material list")
        Me.btnItems.UseVisualStyleBackColor = False
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(861, 36)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 25
        Me.Run_btn.Text = "Run"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Waterfall_dgv
        '
        Me.Waterfall_dgv.AllowColumnHiding = True
        Me.Waterfall_dgv.AllowUserToAddRows = False
        Me.Waterfall_dgv.AllowUserToDeleteRows = False
        Me.Waterfall_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Waterfall_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Waterfall_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Waterfall_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Waterfall_dgv.Location = New System.Drawing.Point(6, 70)
        Me.Waterfall_dgv.Name = "Waterfall_dgv"
        Me.Waterfall_dgv.ReadOnly = True
        Me.Waterfall_dgv.ShowRowNumber = True
        Me.Waterfall_dgv.Size = New System.Drawing.Size(1146, 316)
        Me.Waterfall_dgv.TabIndex = 27
        '
        'OnlyMaterial_rb
        '
        Me.OnlyMaterial_rb.AutoSize = True
        Me.OnlyMaterial_rb.Checked = True
        Me.OnlyMaterial_rb.Location = New System.Drawing.Point(6, 12)
        Me.OnlyMaterial_rb.Name = "OnlyMaterial_rb"
        Me.OnlyMaterial_rb.Size = New System.Drawing.Size(126, 17)
        Me.OnlyMaterial_rb.TabIndex = 28
        Me.OnlyMaterial_rb.TabStop = True
        Me.OnlyMaterial_rb.Text = "Only Material Number"
        Me.OnlyMaterial_rb.UseVisualStyleBackColor = True
        '
        'MaterialAndShipTo_rb
        '
        Me.MaterialAndShipTo_rb.AutoSize = True
        Me.MaterialAndShipTo_rb.Location = New System.Drawing.Point(138, 12)
        Me.MaterialAndShipTo_rb.Name = "MaterialAndShipTo_rb"
        Me.MaterialAndShipTo_rb.Size = New System.Drawing.Size(111, 17)
        Me.MaterialAndShipTo_rb.TabIndex = 29
        Me.MaterialAndShipTo_rb.Text = "Material && Ship-To"
        Me.MaterialAndShipTo_rb.UseVisualStyleBackColor = True
        '
        'Weekly_rb
        '
        Me.Weekly_rb.AutoSize = True
        Me.Weekly_rb.Location = New System.Drawing.Point(60, 12)
        Me.Weekly_rb.Name = "Weekly_rb"
        Me.Weekly_rb.Size = New System.Drawing.Size(61, 17)
        Me.Weekly_rb.TabIndex = 31
        Me.Weekly_rb.Text = "Weekly"
        Me.Weekly_rb.UseVisualStyleBackColor = True
        '
        'Daily_rb
        '
        Me.Daily_rb.AutoSize = True
        Me.Daily_rb.Checked = True
        Me.Daily_rb.Location = New System.Drawing.Point(6, 12)
        Me.Daily_rb.Name = "Daily_rb"
        Me.Daily_rb.Size = New System.Drawing.Size(48, 17)
        Me.Daily_rb.TabIndex = 30
        Me.Daily_rb.TabStop = True
        Me.Daily_rb.Text = "Daily"
        Me.Daily_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OnlyMaterial_rb)
        Me.GroupBox1.Controls.Add(Me.MaterialAndShipTo_rb)
        Me.GroupBox1.Location = New System.Drawing.Point(464, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 35)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group By"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Daily_rb)
        Me.GroupBox2.Controls.Add(Me.Weekly_rb)
        Me.GroupBox2.Location = New System.Drawing.Point(729, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 35)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sumarize By"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Copy_btn, Me.Find_btn, Me.toolStripSeparator1, Me.Title_btn})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1158, 29)
        Me.ToolStripMain.TabIndex = 39
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
        'Title_btn
        '
        Me.Title_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_btn.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_btn.Name = "Title_btn"
        Me.Title_btn.Size = New System.Drawing.Size(240, 26)
        Me.Title_btn.Text = "VL10 Requirements Waterfall"
        '
        'Sch_VL10WaterfallReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1158, 392)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Waterfall_dgv)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.btnItems)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Material_txt)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.From_dtp)
        Me.Name = "Sch_VL10WaterfallReport"
        Me.ShowIcon = False
        Me.Text = "Scheduling"
        CType(Me.Waterfall_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Material_txt As System.Windows.Forms.TextBox
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnItems As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Waterfall_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents OnlyMaterial_rb As System.Windows.Forms.RadioButton
    Friend WithEvents MaterialAndShipTo_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Weekly_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Daily_rb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copy_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_btn As System.Windows.Forms.ToolStripLabel

End Class
