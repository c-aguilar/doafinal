<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_TrackerToService
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_TrackerToService))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Deliver_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Tracker_dgv = New CAguilar.DataGridViewWithFilters()
        Me.NoTransfer_chk = New System.Windows.Forms.CheckBox()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TruckNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentQuantity_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierPartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Tracker_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(620, 32)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 108
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Deliver_btn
        '
        Me.Deliver_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Deliver_btn.Image = CType(resources.GetObject("Deliver_btn.Image"), System.Drawing.Image)
        Me.Deliver_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Deliver_btn.Location = New System.Drawing.Point(514, 27)
        Me.Deliver_btn.Name = "Deliver_btn"
        Me.Deliver_btn.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Deliver_btn.Size = New System.Drawing.Size(100, 25)
        Me.Deliver_btn.TabIndex = 107
        Me.Deliver_btn.Text = "Liberar"
        Me.Deliver_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.Export_btn, Me.Find_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(755, 29)
        Me.ToolStripMain.TabIndex = 106
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
        'Find_btn
        '
        Me.Find_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(23, 26)
        Me.Find_btn.Text = "&Buscar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(203, 26)
        Me.Title_lbl.Text = "Liberar Series de Tracker"
        '
        'Tracker_dgv
        '
        Me.Tracker_dgv.AllowColumnHiding = True
        Me.Tracker_dgv.AllowUserToAddRows = False
        Me.Tracker_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Tracker_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Tracker_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tracker_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tracker_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Tracker_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tracker_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serial, Me.Partnumber, Me.SupplierPartnumber, Me.UoM, Me.CurrentQuantity_col, Me.TruckNumber, Me.Date_, Me.check})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tracker_dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.Tracker_dgv.DefaultRowFilter = Nothing
        Me.Tracker_dgv.EnableHeadersVisualStyles = False
        Me.Tracker_dgv.Location = New System.Drawing.Point(4, 55)
        Me.Tracker_dgv.Name = "Tracker_dgv"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tracker_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Tracker_dgv.ShowRowNumber = True
        Me.Tracker_dgv.Size = New System.Drawing.Size(747, 362)
        Me.Tracker_dgv.TabIndex = 109
        '
        'NoTransfer_chk
        '
        Me.NoTransfer_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NoTransfer_chk.ForeColor = System.Drawing.Color.Red
        Me.NoTransfer_chk.Location = New System.Drawing.Point(327, 32)
        Me.NoTransfer_chk.Name = "NoTransfer_chk"
        Me.NoTransfer_chk.Size = New System.Drawing.Size(181, 17)
        Me.NoTransfer_chk.TabIndex = 110
        Me.NoTransfer_chk.Text = "Liberar sin transferir a SLoc 0002"
        Me.NoTransfer_chk.UseVisualStyleBackColor = True
        '
        'check
        '
        Me.check.DataPropertyName = "Check"
        Me.check.HeaderText = ""
        Me.check.Name = "check"
        Me.check.Width = 30
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        Me.Date_.HeaderText = "Fecha de Etiquetado"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 110
        '
        'TruckNumber
        '
        Me.TruckNumber.DataPropertyName = "TruckNumber"
        Me.TruckNumber.HeaderText = "Troca"
        Me.TruckNumber.Name = "TruckNumber"
        Me.TruckNumber.ReadOnly = True
        Me.TruckNumber.Width = 120
        '
        'CurrentQuantity_col
        '
        Me.CurrentQuantity_col.DataPropertyName = "CurrentQuantity"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CurrentQuantity_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.CurrentQuantity_col.HeaderText = "Cantidad Actual"
        Me.CurrentQuantity_col.Name = "CurrentQuantity_col"
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.ReadOnly = True
        Me.UoM.Width = 60
        '
        'SupplierPartnumber
        '
        Me.SupplierPartnumber.DataPropertyName = "OriginalQuantity"
        Me.SupplierPartnumber.HeaderText = "Cantidad"
        Me.SupplierPartnumber.Name = "SupplierPartnumber"
        Me.SupplierPartnumber.ReadOnly = True
        Me.SupplierPartnumber.Width = 70
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 90
        '
        'Serial
        '
        Me.Serial.DataPropertyName = "Serialnumber"
        Me.Serial.HeaderText = "Serie"
        Me.Serial.Name = "Serial"
        Me.Serial.ReadOnly = True
        '
        'Rec_TrackerToService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 421)
        Me.Controls.Add(Me.NoTransfer_chk)
        Me.Controls.Add(Me.Tracker_dgv)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Deliver_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "Rec_TrackerToService"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Tracker_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Deliver_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Tracker_dgv As DataGridViewWithFilters
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents NoTransfer_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierPartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentQuantity_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TruckNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
