<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_CompatibilityReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_CompatibilityReport))
        Me.MaterialVersus_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Material_txt = New System.Windows.Forms.TextBox()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaterialVersus_txt = New System.Windows.Forms.TextBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComponentIgnore_txt = New System.Windows.Forms.TextBox()
        Me.ComponentIgnore_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComponentPenalize_txt = New System.Windows.Forms.TextBox()
        Me.ComponentPenalize_btn = New System.Windows.Forms.Button()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MaterialVersus_btn
        '
        Me.MaterialVersus_btn.BackColor = System.Drawing.SystemColors.Control
        Me.MaterialVersus_btn.Image = CType(resources.GetObject("MaterialVersus_btn.Image"), System.Drawing.Image)
        Me.MaterialVersus_btn.Location = New System.Drawing.Point(314, 32)
        Me.MaterialVersus_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialVersus_btn.Name = "MaterialVersus_btn"
        Me.MaterialVersus_btn.Size = New System.Drawing.Size(23, 23)
        Me.MaterialVersus_btn.TabIndex = 119
        Me.MaterialVersus_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.MaterialVersus_btn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Material:"
        '
        'Material_txt
        '
        Me.Material_txt.BackColor = System.Drawing.Color.Ivory
        Me.Material_txt.Location = New System.Drawing.Point(61, 34)
        Me.Material_txt.MaxLength = 12
        Me.Material_txt.Name = "Material_txt"
        Me.Material_txt.Size = New System.Drawing.Size(100, 20)
        Me.Material_txt.TabIndex = 120
        '
        'Run_btn
        '
        Me.Run_btn.BackColor = System.Drawing.Color.Transparent
        Me.Run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(931, 29)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 122
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = False
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
        Me.Report_dgv.Location = New System.Drawing.Point(12, 60)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(1019, 489)
        Me.Report_dgv.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(167, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Versus:"
        '
        'MaterialVersus_txt
        '
        Me.MaterialVersus_txt.BackColor = System.Drawing.Color.Ivory
        Me.MaterialVersus_txt.Location = New System.Drawing.Point(215, 34)
        Me.MaterialVersus_txt.MaxLength = 12
        Me.MaterialVersus_txt.Name = "MaterialVersus_txt"
        Me.MaterialVersus_txt.Size = New System.Drawing.Size(100, 20)
        Me.MaterialVersus_txt.TabIndex = 124
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1042, 29)
        Me.ToolStripMain.TabIndex = 126
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
        Me.Title_lbl.Size = New System.Drawing.Size(199, 26)
        Me.Title_lbl.Text = "Compatibilidad de BOM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(366, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Componentes a ignorar:"
        '
        'ComponentIgnore_txt
        '
        Me.ComponentIgnore_txt.BackColor = System.Drawing.Color.Ivory
        Me.ComponentIgnore_txt.Location = New System.Drawing.Point(491, 33)
        Me.ComponentIgnore_txt.MaxLength = 12
        Me.ComponentIgnore_txt.Name = "ComponentIgnore_txt"
        Me.ComponentIgnore_txt.Size = New System.Drawing.Size(100, 20)
        Me.ComponentIgnore_txt.TabIndex = 128
        '
        'ComponentIgnore_btn
        '
        Me.ComponentIgnore_btn.BackColor = System.Drawing.SystemColors.Control
        Me.ComponentIgnore_btn.Image = CType(resources.GetObject("ComponentIgnore_btn.Image"), System.Drawing.Image)
        Me.ComponentIgnore_btn.Location = New System.Drawing.Point(590, 31)
        Me.ComponentIgnore_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.ComponentIgnore_btn.Name = "ComponentIgnore_btn"
        Me.ComponentIgnore_btn.Size = New System.Drawing.Size(23, 23)
        Me.ComponentIgnore_btn.TabIndex = 127
        Me.ComponentIgnore_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ComponentIgnore_btn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(616, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Componentes a penalizar:"
        '
        'ComponentPenalize_txt
        '
        Me.ComponentPenalize_txt.BackColor = System.Drawing.Color.Ivory
        Me.ComponentPenalize_txt.Location = New System.Drawing.Point(751, 32)
        Me.ComponentPenalize_txt.MaxLength = 12
        Me.ComponentPenalize_txt.Name = "ComponentPenalize_txt"
        Me.ComponentPenalize_txt.Size = New System.Drawing.Size(100, 20)
        Me.ComponentPenalize_txt.TabIndex = 131
        '
        'ComponentPenalize_btn
        '
        Me.ComponentPenalize_btn.BackColor = System.Drawing.SystemColors.Control
        Me.ComponentPenalize_btn.Image = CType(resources.GetObject("ComponentPenalize_btn.Image"), System.Drawing.Image)
        Me.ComponentPenalize_btn.Location = New System.Drawing.Point(850, 30)
        Me.ComponentPenalize_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.ComponentPenalize_btn.Name = "ComponentPenalize_btn"
        Me.ComponentPenalize_btn.Size = New System.Drawing.Size(23, 23)
        Me.ComponentPenalize_btn.TabIndex = 130
        Me.ComponentPenalize_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ComponentPenalize_btn.UseVisualStyleBackColor = False
        '
        'Sch_CompatibilityReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 561)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComponentPenalize_txt)
        Me.Controls.Add(Me.ComponentPenalize_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComponentIgnore_txt)
        Me.Controls.Add(Me.ComponentIgnore_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaterialVersus_txt)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.MaterialVersus_btn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Material_txt)
        Me.Name = "Sch_CompatibilityReport"
        Me.ShowIcon = False
        Me.Text = "Scheduling"
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MaterialVersus_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Material_txt As System.Windows.Forms.TextBox
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MaterialVersus_txt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComponentIgnore_txt As System.Windows.Forms.TextBox
    Friend WithEvents ComponentIgnore_btn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComponentPenalize_txt As System.Windows.Forms.TextBox
    Friend WithEvents ComponentPenalize_btn As System.Windows.Forms.Button
End Class
