<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ABC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_ABC))
        Me.btnItems = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Copy_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Slocs_clb = New System.Windows.Forms.CheckedListBox()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnItems
        '
        Me.btnItems.BackColor = System.Drawing.SystemColors.Control
        Me.btnItems.Image = CType(resources.GetObject("btnItems.Image"), System.Drawing.Image)
        Me.btnItems.Location = New System.Drawing.Point(203, 30)
        Me.btnItems.Margin = New System.Windows.Forms.Padding(0)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(23, 23)
        Me.btnItems.TabIndex = 52
        Me.btnItems.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnItems.UseVisualStyleBackColor = False
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Location = New System.Drawing.Point(86, 32)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.Partnumber_txt.TabIndex = 51
        Me.Partnumber_txt.Text = "*"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Copy_btn, Me.Find_btn, Me.toolStripSeparator1, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 29)
        Me.ToolStripMain.TabIndex = 48
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
        Me.Title_lbl.Size = New System.Drawing.Size(109, 26)
        Me.Title_lbl.Text = "Analisis ABC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "No. de Parte:"
        '
        'From_dtp
        '
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_dtp.Location = New System.Drawing.Point(288, 32)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(100, 20)
        Me.From_dtp.TabIndex = 46
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(545, 32)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 45
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(236, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Fecha:"
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
        Me.Report_dgv.Location = New System.Drawing.Point(6, 72)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(972, 435)
        Me.Report_dgv.TabIndex = 53
        '
        'Slocs_clb
        '
        Me.Slocs_clb.ColumnWidth = 70
        Me.Slocs_clb.FormattingEnabled = True
        Me.Slocs_clb.Location = New System.Drawing.Point(394, 32)
        Me.Slocs_clb.MultiColumn = True
        Me.Slocs_clb.Name = "Slocs_clb"
        Me.Slocs_clb.Size = New System.Drawing.Size(145, 34)
        Me.Slocs_clb.TabIndex = 54
        '
        'Ord_ABC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 512)
        Me.Controls.Add(Me.Slocs_clb)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.btnItems)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Ord_ABC"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnItems As System.Windows.Forms.Button
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copy_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Slocs_clb As System.Windows.Forms.CheckedListBox
End Class
