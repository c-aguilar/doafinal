<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_AMRReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_AMRReport))
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Material_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Stage_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Paste_btn = New System.Windows.Forms.Button()
        Me.Stock_btn = New System.Windows.Forms.Button()
        Me.Result_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Material_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Stage_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 29)
        Me.ToolStripMain.TabIndex = 127
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
        Me.Title_lbl.Size = New System.Drawing.Size(48, 26)
        Me.Title_lbl.Text = "AMR"
        '
        'Material_dgv
        '
        Me.Material_dgv.AllowColumnHiding = True
        Me.Material_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Material_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Material_dgv.Location = New System.Drawing.Point(5, 36)
        Me.Material_dgv.Name = "Material_dgv"
        Me.Material_dgv.ShowRowNumber = True
        Me.Material_dgv.Size = New System.Drawing.Size(315, 591)
        Me.Material_dgv.TabIndex = 128
        '
        'Stage_nud
        '
        Me.Stage_nud.Location = New System.Drawing.Point(50, 7)
        Me.Stage_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Stage_nud.Name = "Stage_nud"
        Me.Stage_nud.Size = New System.Drawing.Size(41, 20)
        Me.Stage_nud.TabIndex = 129
        Me.Stage_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Stage_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Fases:"
        '
        'Run_btn
        '
        Me.Run_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Run_btn.BackColor = System.Drawing.Color.Transparent
        Me.Run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(220, 5)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 131
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Paste_btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Run_btn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Material_dgv)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Stage_nud)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Stock_btn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Result_dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(972, 630)
        Me.SplitContainer1.SplitterDistance = 324
        Me.SplitContainer1.TabIndex = 132
        '
        'Paste_btn
        '
        Me.Paste_btn.BackColor = System.Drawing.Color.Transparent
        Me.Paste_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paste_btn.Image = CType(resources.GetObject("Paste_btn.Image"), System.Drawing.Image)
        Me.Paste_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Paste_btn.Location = New System.Drawing.Point(97, 5)
        Me.Paste_btn.Name = "Paste_btn"
        Me.Paste_btn.Size = New System.Drawing.Size(61, 25)
        Me.Paste_btn.TabIndex = 132
        Me.Paste_btn.Text = "Pegar"
        Me.Paste_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Paste_btn.UseVisualStyleBackColor = False
        '
        'Stock_btn
        '
        Me.Stock_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Stock_btn.BackColor = System.Drawing.Color.Transparent
        Me.Stock_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stock_btn.Image = CType(resources.GetObject("Stock_btn.Image"), System.Drawing.Image)
        Me.Stock_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Stock_btn.Location = New System.Drawing.Point(500, 5)
        Me.Stock_btn.Name = "Stock_btn"
        Me.Stock_btn.Size = New System.Drawing.Size(141, 25)
        Me.Stock_btn.TabIndex = 132
        Me.Stock_btn.Text = "Obtener Inventarios"
        Me.Stock_btn.UseVisualStyleBackColor = False
        '
        'Result_dgv
        '
        Me.Result_dgv.AllowColumnHiding = True
        Me.Result_dgv.AllowUserToAddRows = False
        Me.Result_dgv.AllowUserToDeleteRows = False
        Me.Result_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Result_dgv.Location = New System.Drawing.Point(3, 36)
        Me.Result_dgv.Name = "Result_dgv"
        Me.Result_dgv.ReadOnly = True
        Me.Result_dgv.ShowRowNumber = True
        Me.Result_dgv.Size = New System.Drawing.Size(638, 591)
        Me.Result_dgv.TabIndex = 129
        '
        'CR_AMRReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 669)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "CR_AMRReport"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Material_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Stage_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Material_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Stage_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Result_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Paste_btn As System.Windows.Forms.Button
    Friend WithEvents Stock_btn As System.Windows.Forms.Button
End Class
