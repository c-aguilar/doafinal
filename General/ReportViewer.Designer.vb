<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportViewer))
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CSVToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ExportToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PDFToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboTable = New System.Windows.Forms.ToolStripComboBox()
        Me.btnGet = New System.Windows.Forms.ToolStripButton()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvData = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.CSVToolStripButton, Me.ExportToolStripButton, Me.PDFToolStripButton, Me.toolStripSeparator, Me.CopyToolStripButton, Me.FindToolStripButton, Me.toolStripSeparator1, Me.ToolStripLabel1, Me.cboTable, Me.btnGet})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 25)
        Me.ToolStripMain.TabIndex = 3
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "Im&primir"
        Me.PrintToolStripButton.ToolTipText = "Imprimir"
        '
        'CSVToolStripButton
        '
        Me.CSVToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CSVToolStripButton.Image = CType(resources.GetObject("CSVToolStripButton.Image"), System.Drawing.Image)
        Me.CSVToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CSVToolStripButton.Name = "CSVToolStripButton"
        Me.CSVToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CSVToolStripButton.Text = "Expor&t CSV"
        '
        'ExportToolStripButton
        '
        Me.ExportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExportToolStripButton.Image = CType(resources.GetObject("ExportToolStripButton.Image"), System.Drawing.Image)
        Me.ExportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportToolStripButton.Name = "ExportToolStripButton"
        Me.ExportToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ExportToolStripButton.Text = "&Exportar Excel"
        '
        'PDFToolStripButton
        '
        Me.PDFToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PDFToolStripButton.Image = CType(resources.GetObject("PDFToolStripButton.Image"), System.Drawing.Image)
        Me.PDFToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PDFToolStripButton.Name = "PDFToolStripButton"
        Me.PDFToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PDFToolStripButton.Text = "Export P&DF"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        Me.CopyToolStripButton.ToolTipText = "Copiar"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FindToolStripButton.Text = "&Find"
        Me.FindToolStripButton.ToolTipText = "Buscar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripLabel1.Text = "Report:"
        '
        'cboTable
        '
        Me.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Size = New System.Drawing.Size(300, 25)
        Me.cboTable.ToolTipText = "T&able"
        '
        'btnGet
        '
        Me.btnGet.Image = CType(resources.GetObject("btnGet.Image"), System.Drawing.Image)
        Me.btnGet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(48, 22)
        Me.btnGet.Text = "&Run"
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
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(6, 27)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ShowRowNumber = True
        Me.dgvData.Size = New System.Drawing.Size(972, 609)
        Me.dgvData.TabIndex = 6
        '
        'ReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "ReportViewer"
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
    Friend WithEvents CSVToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExportToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PDFToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboTable As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnGet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvData As CAguilar.DataGridViewWithFilters
End Class
