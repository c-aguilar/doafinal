<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_VL10VsCapacityReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_VL10VsCapacityReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFamily = New System.Windows.Forms.ComboBox()
        Me.dgvContracted = New CAguilar.DataGridViewWithFilters()
        Me.cmsReports = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvInstalled = New CAguilar.DataGridViewWithFilters()
        CType(Me.dgvContracted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsReports.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvInstalled, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(339, 6)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 20
        '
        'btnRun
        '
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(448, 29)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(91, 27)
        Me.btnRun.TabIndex = 19
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Week:"
        '
        'cboBusiness
        '
        Me.cboBusiness.FormattingEnabled = True
        Me.cboBusiness.Location = New System.Drawing.Point(67, 33)
        Me.cboBusiness.Name = "cboBusiness"
        Me.cboBusiness.Size = New System.Drawing.Size(198, 21)
        Me.cboBusiness.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Business"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Family:"
        '
        'cboFamily
        '
        Me.cboFamily.FormattingEnabled = True
        Me.cboFamily.Location = New System.Drawing.Point(67, 6)
        Me.cboFamily.Name = "cboFamily"
        Me.cboFamily.Size = New System.Drawing.Size(198, 21)
        Me.cboFamily.TabIndex = 14
        '
        'dgvContracted
        '
        Me.dgvContracted.AllowColumnHiding = True
        Me.dgvContracted.AllowUserToAddRows = False
        Me.dgvContracted.AllowUserToDeleteRows = False
        Me.dgvContracted.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvContracted.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContracted.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvContracted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContracted.ContextMenuStrip = Me.cmsReports
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvContracted.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvContracted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContracted.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvContracted.GridColor = System.Drawing.Color.DimGray
        Me.dgvContracted.Location = New System.Drawing.Point(3, 3)
        Me.dgvContracted.Name = "dgvContracted"
        Me.dgvContracted.ShowRowNumber = True
        Me.dgvContracted.Size = New System.Drawing.Size(988, 320)
        Me.dgvContracted.TabIndex = 21
        '
        'cmsReports
        '
        Me.cmsReports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToolStripMenuItem})
        Me.cmsReports.Name = "cmsReports"
        Me.cmsReports.Size = New System.Drawing.Size(117, 26)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExportToolStripMenuItem.Text = "Export..."
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 60)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1002, 352)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvContracted)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(994, 326)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Contracted"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvInstalled)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(994, 326)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Installed"
        '
        'dgvInstalled
        '
        Me.dgvInstalled.AllowColumnHiding = True
        Me.dgvInstalled.AllowUserToAddRows = False
        Me.dgvInstalled.AllowUserToDeleteRows = False
        Me.dgvInstalled.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvInstalled.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInstalled.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInstalled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInstalled.ContextMenuStrip = Me.cmsReports
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInstalled.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInstalled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInstalled.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvInstalled.GridColor = System.Drawing.Color.DimGray
        Me.dgvInstalled.Location = New System.Drawing.Point(3, 3)
        Me.dgvInstalled.Name = "dgvInstalled"
        Me.dgvInstalled.ShowRowNumber = True
        Me.dgvInstalled.Size = New System.Drawing.Size(988, 320)
        Me.dgvInstalled.TabIndex = 22
        '
        'Sch_VL10VsCapacityReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 424)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboBusiness)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFamily)
        Me.Name = "Sch_VL10VsCapacityReport"
        Me.ShowIcon = False
        Me.Text = "Scheduling"
        CType(Me.dgvContracted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsReports.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvInstalled, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBusiness As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFamily As System.Windows.Forms.ComboBox
    Friend WithEvents dgvContracted As CAguilar.DataGridViewWithFilters
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInstalled As CAguilar.DataGridViewWithFilters
    Friend WithEvents cmsReports As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
