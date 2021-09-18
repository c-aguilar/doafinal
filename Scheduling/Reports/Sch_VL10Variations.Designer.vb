<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_VL10Variations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_VL10Variations))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboFamily = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvVariations = New CAguilar.DataGridViewWithFilters()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvLastWeek = New CAguilar.DataGridViewWithFilters()
        Me.cmsReports = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvCurrentWeek = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_btn = New System.Windows.Forms.ToolStripLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvVariations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvLastWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsReports.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvCurrentWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboFamily
        '
        Me.cboFamily.FormattingEnabled = True
        Me.cboFamily.Location = New System.Drawing.Point(67, 36)
        Me.cboFamily.Name = "cboFamily"
        Me.cboFamily.Size = New System.Drawing.Size(198, 21)
        Me.cboFamily.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Familia:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Negocio:"
        '
        'cboBusiness
        '
        Me.cboBusiness.FormattingEnabled = True
        Me.cboBusiness.Location = New System.Drawing.Point(67, 63)
        Me.cboBusiness.Name = "cboBusiness"
        Me.cboBusiness.Size = New System.Drawing.Size(198, 21)
        Me.cboBusiness.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(284, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Semana:"
        '
        'btnRun
        '
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(439, 66)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(100, 25)
        Me.btnRun.TabIndex = 12
        Me.btnRun.Text = "Ejecutar"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(339, 36)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 13
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 90)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1082, 294)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvVariations)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1074, 268)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Variaciones"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvVariations
        '
        Me.dgvVariations.AllowColumnHiding = True
        Me.dgvVariations.AllowUserToAddRows = False
        Me.dgvVariations.AllowUserToDeleteRows = False
        Me.dgvVariations.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvVariations.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVariations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVariations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVariations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVariations.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVariations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVariations.GridColor = System.Drawing.Color.DimGray
        Me.dgvVariations.Location = New System.Drawing.Point(6, 6)
        Me.dgvVariations.Name = "dgvVariations"
        Me.dgvVariations.ShowRowNumber = True
        Me.dgvVariations.Size = New System.Drawing.Size(1062, 256)
        Me.dgvVariations.TabIndex = 7
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvLastWeek)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1074, 268)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Semana Anterior"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvLastWeek
        '
        Me.dgvLastWeek.AllowColumnHiding = True
        Me.dgvLastWeek.AllowUserToAddRows = False
        Me.dgvLastWeek.AllowUserToDeleteRows = False
        Me.dgvLastWeek.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvLastWeek.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLastWeek.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLastWeek.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLastWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLastWeek.ContextMenuStrip = Me.cmsReports
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLastWeek.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvLastWeek.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvLastWeek.GridColor = System.Drawing.Color.DimGray
        Me.dgvLastWeek.Location = New System.Drawing.Point(6, 6)
        Me.dgvLastWeek.Name = "dgvLastWeek"
        Me.dgvLastWeek.ShowRowNumber = True
        Me.dgvLastWeek.Size = New System.Drawing.Size(1062, 256)
        Me.dgvLastWeek.TabIndex = 8
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
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvCurrentWeek)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1074, 268)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Semana Seleccionada"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvCurrentWeek
        '
        Me.dgvCurrentWeek.AllowColumnHiding = True
        Me.dgvCurrentWeek.AllowUserToAddRows = False
        Me.dgvCurrentWeek.AllowUserToDeleteRows = False
        Me.dgvCurrentWeek.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvCurrentWeek.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCurrentWeek.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCurrentWeek.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCurrentWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCurrentWeek.ContextMenuStrip = Me.cmsReports
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.NullValue = Nothing
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCurrentWeek.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCurrentWeek.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCurrentWeek.GridColor = System.Drawing.Color.DimGray
        Me.dgvCurrentWeek.Location = New System.Drawing.Point(6, 6)
        Me.dgvCurrentWeek.Name = "dgvCurrentWeek"
        Me.dgvCurrentWeek.ShowRowNumber = True
        Me.dgvCurrentWeek.Size = New System.Drawing.Size(1062, 256)
        Me.dgvCurrentWeek.TabIndex = 8
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_btn})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1106, 29)
        Me.ToolStripMain.TabIndex = 40
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
        'Title_btn
        '
        Me.Title_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_btn.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_btn.Name = "Title_btn"
        Me.Title_btn.Size = New System.Drawing.Size(172, 26)
        Me.Title_btn.Text = "Variaciones de VL10"
        '
        'Sch_VL10Variations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 396)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboBusiness)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFamily)
        Me.Name = "Sch_VL10Variations"
        Me.ShowIcon = False
        Me.Text = "Scheduling"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvVariations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvLastWeek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsReports.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvCurrentWeek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFamily As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBusiness As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvVariations As CAguilar.DataGridViewWithFilters
    Friend WithEvents dgvLastWeek As CAguilar.DataGridViewWithFilters
    Friend WithEvents dgvCurrentWeek As CAguilar.DataGridViewWithFilters
    Friend WithEvents cmsReports As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_btn As System.Windows.Forms.ToolStripLabel
End Class
