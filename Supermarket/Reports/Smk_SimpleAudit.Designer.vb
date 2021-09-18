<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_SimpleAudit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_SimpleAudit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.Print_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LocationB_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LocationA_txt = New System.Windows.Forms.TextBox()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.All_rb = New System.Windows.Forms.RadioButton()
        Me.IgnoreMSpec_rb = New System.Windows.Forms.RadioButton()
        Me.OnlyMspec_rb = New System.Windows.Forms.RadioButton()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.Print_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(807, 29)
        Me.ToolStripMain.TabIndex = 103
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
        Me.Title_lbl.Size = New System.Drawing.Size(143, 26)
        Me.Title_lbl.Text = "Auditoria Simple"
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Report_dgv.Location = New System.Drawing.Point(6, 58)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(795, 286)
        Me.Report_dgv.TabIndex = 104
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(111, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "al:"
        '
        'LocationB_txt
        '
        Me.LocationB_txt.BackColor = System.Drawing.Color.Ivory
        Me.LocationB_txt.Location = New System.Drawing.Point(132, 31)
        Me.LocationB_txt.MaxLength = 8
        Me.LocationB_txt.Name = "LocationB_txt"
        Me.LocationB_txt.Size = New System.Drawing.Size(64, 20)
        Me.LocationB_txt.TabIndex = 137
        Me.LocationB_txt.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Local:"
        '
        'LocationA_txt
        '
        Me.LocationA_txt.BackColor = System.Drawing.Color.Ivory
        Me.LocationA_txt.Location = New System.Drawing.Point(45, 32)
        Me.LocationA_txt.MaxLength = 8
        Me.LocationA_txt.Name = "LocationA_txt"
        Me.LocationA_txt.Size = New System.Drawing.Size(64, 20)
        Me.LocationA_txt.TabIndex = 135
        Me.LocationA_txt.Text = "*"
        '
        'Run_btn
        '
        Me.Run_btn.BackColor = System.Drawing.Color.Transparent
        Me.Run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(434, 29)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 139
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = False
        '
        'All_rb
        '
        Me.All_rb.AutoSize = True
        Me.All_rb.Location = New System.Drawing.Point(209, 32)
        Me.All_rb.Name = "All_rb"
        Me.All_rb.Size = New System.Drawing.Size(50, 17)
        Me.All_rb.TabIndex = 142
        Me.All_rb.Text = "Todo"
        Me.All_rb.UseVisualStyleBackColor = True
        '
        'IgnoreMSpec_rb
        '
        Me.IgnoreMSpec_rb.AutoSize = True
        Me.IgnoreMSpec_rb.Checked = True
        Me.IgnoreMSpec_rb.Location = New System.Drawing.Point(265, 32)
        Me.IgnoreMSpec_rb.Name = "IgnoreMSpec_rb"
        Me.IgnoreMSpec_rb.Size = New System.Drawing.Size(81, 17)
        Me.IgnoreMSpec_rb.TabIndex = 141
        Me.IgnoreMSpec_rb.TabStop = True
        Me.IgnoreMSpec_rb.Text = "Omitir Cable"
        Me.IgnoreMSpec_rb.UseVisualStyleBackColor = True
        '
        'OnlyMspec_rb
        '
        Me.OnlyMspec_rb.AutoSize = True
        Me.OnlyMspec_rb.Location = New System.Drawing.Point(352, 32)
        Me.OnlyMspec_rb.Name = "OnlyMspec_rb"
        Me.OnlyMspec_rb.Size = New System.Drawing.Size(76, 17)
        Me.OnlyMspec_rb.TabIndex = 140
        Me.OnlyMspec_rb.Text = "Solo Cable"
        Me.OnlyMspec_rb.UseVisualStyleBackColor = True
        '
        'Smk_SimpleAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 350)
        Me.Controls.Add(Me.All_rb)
        Me.Controls.Add(Me.IgnoreMSpec_rb)
        Me.Controls.Add(Me.OnlyMspec_rb)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LocationB_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LocationA_txt)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "Smk_SimpleAudit"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LocationB_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LocationA_txt As System.Windows.Forms.TextBox
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Print_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents All_rb As System.Windows.Forms.RadioButton
    Friend WithEvents IgnoreMSpec_rb As System.Windows.Forms.RadioButton
    Friend WithEvents OnlyMspec_rb As System.Windows.Forms.RadioButton
End Class
