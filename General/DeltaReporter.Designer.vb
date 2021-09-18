<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeltaReporter
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeltaReporter))
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Controls_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Report_cbo = New System.Windows.Forms.ComboBox()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Pivot_btn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Area_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.ssStatus.SuspendLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.ssStatus.Location = New System.Drawing.Point(0, 728)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(1184, 22)
        Me.ssStatus.TabIndex = 5
        Me.ssStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(34, 17)
        Me.lblStatus.Text = "         "
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Report_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Report_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Report_dgv.DefaultRowFilter = Nothing
        Me.Report_dgv.EnableHeadersVisualStyles = False
        Me.Report_dgv.Location = New System.Drawing.Point(229, 31)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(951, 694)
        Me.Report_dgv.TabIndex = 6
        '
        'Controls_flp
        '
        Me.Controls_flp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Controls_flp.AutoScroll = True
        Me.Controls_flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.Controls_flp.Location = New System.Drawing.Point(5, 58)
        Me.Controls_flp.Name = "Controls_flp"
        Me.Controls_flp.Padding = New System.Windows.Forms.Padding(5)
        Me.Controls_flp.Size = New System.Drawing.Size(218, 667)
        Me.Controls_flp.TabIndex = 8
        '
        'Report_cbo
        '
        Me.Report_cbo.FormattingEnabled = True
        Me.Report_cbo.Location = New System.Drawing.Point(5, 32)
        Me.Report_cbo.Name = "Report_cbo"
        Me.Report_cbo.Size = New System.Drawing.Size(198, 21)
        Me.Report_cbo.TabIndex = 9
        '
        'Run_btn
        '
        Me.Run_btn.BackgroundImage = CType(resources.GetObject("Run_btn.BackgroundImage"), System.Drawing.Image)
        Me.Run_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Run_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Run_btn.FlatAppearance.BorderSize = 0
        Me.Run_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Run_btn.Location = New System.Drawing.Point(206, 32)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(20, 20)
        Me.Run_btn.TabIndex = 11
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(23, 26)
        Me.btnExport.Text = "&Exportar"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.PrintToolStripButton.Text = "&Imprimir"
        Me.PrintToolStripButton.ToolTipText = "Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.CopyToolStripButton.Text = "&Copiar"
        Me.CopyToolStripButton.ToolTipText = "Copiar"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.FindToolStripButton.Text = "&Buscar"
        Me.FindToolStripButton.ToolTipText = "Buscar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExport, Me.PrintToolStripButton, Me.toolStripSeparator, Me.CopyToolStripButton, Me.FindToolStripButton, Me.toolStripSeparator1, Me.Pivot_btn, Me.ToolStripSeparator2, Me.Area_lbl, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1184, 29)
        Me.ToolStripMain.TabIndex = 3
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Pivot_btn
        '
        Me.Pivot_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Pivot_btn.Image = CType(resources.GetObject("Pivot_btn.Image"), System.Drawing.Image)
        Me.Pivot_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Pivot_btn.Name = "Pivot_btn"
        Me.Pivot_btn.Size = New System.Drawing.Size(23, 26)
        Me.Pivot_btn.Text = "&Tabla Pivote"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'Area_lbl
        '
        Me.Area_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Area_lbl.ForeColor = System.Drawing.Color.Black
        Me.Area_lbl.Name = "Area_lbl"
        Me.Area_lbl.Size = New System.Drawing.Size(45, 26)
        Me.Area_lbl.Text = "Title"
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(45, 26)
        Me.Title_lbl.Text = "Title"
        '
        'DeltaReporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 750)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Report_cbo)
        Me.Controls.Add(Me.Controls_flp)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "DeltaReporter"
        Me.ShowIcon = False
        Me.Text = "Delta ERP Reporter"
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Controls_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Report_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Area_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Pivot_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
