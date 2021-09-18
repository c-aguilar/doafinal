<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SingleReportViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SingleReportViewer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvData = New CAguilar.DataGridViewWithFilters()
        Me.Pivot_btn = New System.Windows.Forms.ToolStripButton()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripMain.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.btnExport, Me.toolStripSeparator, Me.CopyToolStripButton, Me.FindToolStripButton, Me.toolStripSeparator1, Me.Pivot_btn, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 29)
        Me.ToolStripMain.TabIndex = 3
        Me.ToolStripMain.Text = "ToolStrip1"
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
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(23, 26)
        Me.btnExport.Text = "&Exportar"
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
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.ssStatus.Location = New System.Drawing.Point(0, 640)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(984, 22)
        Me.ssStatus.TabIndex = 5
        Me.ssStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(34, 17)
        Me.lblStatus.Text = "         "
        '
        'dgvData
        '
        Me.dgvData.AllowColumnHiding = True
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.DefaultRowFilter = Nothing
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.Location = New System.Drawing.Point(6, 36)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.ShowRowNumber = True
        Me.dgvData.Size = New System.Drawing.Size(972, 601)
        Me.dgvData.TabIndex = 6
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
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline)
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(45, 26)
        Me.Title_lbl.Text = "Title"
        '
        'SingleReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "SingleReportViewer"
        Me.ShowIcon = False
        Me.Text = "Report Viewer"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvData As CAguilar.DataGridViewWithFilters
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Pivot_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
End Class
