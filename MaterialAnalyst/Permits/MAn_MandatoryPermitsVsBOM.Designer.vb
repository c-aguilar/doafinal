<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAn_MandatoryPermitsVsBOM
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAn_MandatoryPermitsVsBOM))
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Report_dgv.DefaultRowFilter = Nothing
        Me.Report_dgv.EnableHeadersVisualStyles = False
        Me.Report_dgv.Location = New System.Drawing.Point(4, 32)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(606, 278)
        Me.Report_dgv.TabIndex = 10
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(615, 29)
        Me.ToolStripMain.TabIndex = 104
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "ToolStripButton1"
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
        Me.Title_lbl.Size = New System.Drawing.Size(251, 26)
        Me.Title_lbl.Text = "Permisos Mandatorios Vs BOM"
        '
        'MAn_MandatoryPermitsVsBOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 314)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Report_dgv)
        Me.Name = "MAn_MandatoryPermitsVsBOM"
        Me.ShowIcon = False
        Me.Text = "Material Analyst"
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
End Class
