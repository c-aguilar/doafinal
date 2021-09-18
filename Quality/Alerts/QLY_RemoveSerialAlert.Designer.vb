<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QLY_RemoveSerialAlert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QLY_RemoveSerialAlert))
        Me.Alerts_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Delete_btn = New System.Windows.Forms.Button()
        Me.Serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierPartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Master_Col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.Alerts_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Alerts_dgv
        '
        Me.Alerts_dgv.AllowColumnHiding = True
        Me.Alerts_dgv.AllowUserToAddRows = False
        Me.Alerts_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Alerts_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Alerts_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Alerts_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Alerts_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Alerts_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Alerts_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serial, Me.Partnumber, Me.SupplierPartnumber, Me.SupplierName, Me.Reason, Me.Date_, Me.Master_Col, Me.check})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Alerts_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Alerts_dgv.DefaultRowFilter = Nothing
        Me.Alerts_dgv.EnableHeadersVisualStyles = False
        Me.Alerts_dgv.Location = New System.Drawing.Point(4, 62)
        Me.Alerts_dgv.Name = "Alerts_dgv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Alerts_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Alerts_dgv.ShowRowNumber = True
        Me.Alerts_dgv.Size = New System.Drawing.Size(946, 342)
        Me.Alerts_dgv.TabIndex = 91
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.Export_btn, Me.FindToolStripButton, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(955, 29)
        Me.ToolStripMain.TabIndex = 103
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "&Refresh"
        Me.Refresh_btn.ToolTipText = "Actualizar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(241, 26)
        Me.Title_lbl.Text = "Desbloquear Series Alertadas"
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(820, 39)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 105
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Delete_btn
        '
        Me.Delete_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Delete_btn.Image = CType(resources.GetObject("Delete_btn.Image"), System.Drawing.Image)
        Me.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete_btn.Location = New System.Drawing.Point(714, 34)
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Delete_btn.Size = New System.Drawing.Size(100, 25)
        Me.Delete_btn.TabIndex = 104
        Me.Delete_btn.Text = "Desbloquear"
        Me.Delete_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Delete_btn.UseVisualStyleBackColor = True
        '
        'Serial
        '
        Me.Serial.DataPropertyName = "Serialnumber"
        Me.Serial.HeaderText = "Serie"
        Me.Serial.Name = "Serial"
        Me.Serial.ReadOnly = True
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 90
        '
        'SupplierPartnumber
        '
        Me.SupplierPartnumber.DataPropertyName = "SupplierPartnumber"
        Me.SupplierPartnumber.HeaderText = "No. de Proveedor"
        Me.SupplierPartnumber.Name = "SupplierPartnumber"
        Me.SupplierPartnumber.ReadOnly = True
        Me.SupplierPartnumber.Width = 120
        '
        'SupplierName
        '
        Me.SupplierName.DataPropertyName = "SupplierName"
        Me.SupplierName.HeaderText = "Proveedor"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        '
        'Reason
        '
        Me.Reason.DataPropertyName = "Reason"
        Me.Reason.HeaderText = "Motivo"
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = True
        Me.Reason.Width = 250
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        Me.Date_.HeaderText = "Fecha de Etiquetado"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 90
        '
        'Master_Col
        '
        Me.Master_Col.DataPropertyName = "Masternumber"
        Me.Master_Col.HeaderText = "Etiqueta Master"
        Me.Master_Col.Name = "Master_Col"
        Me.Master_Col.ReadOnly = True
        '
        'check
        '
        Me.check.DataPropertyName = "Check"
        Me.check.HeaderText = ""
        Me.check.Name = "check"
        Me.check.Width = 30
        '
        'QLY_RemoveSerialAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 409)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Delete_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Alerts_dgv)
        Me.Name = "QLY_RemoveSerialAlert"
        Me.ShowIcon = False
        Me.Text = "Quality"
        CType(Me.Alerts_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Alerts_dgv As DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Delete_btn As System.Windows.Forms.Button
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierPartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Master_Col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
