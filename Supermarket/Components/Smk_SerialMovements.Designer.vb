<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_SerialMovements
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_SerialMovements))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Movements_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Posted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TransferQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromSloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToSloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Movements_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(931, 29)
        Me.ToolStripMain.TabIndex = 103
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
        Me.Title_lbl.Size = New System.Drawing.Size(52, 26)
        Me.Title_lbl.Text = "Serie"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Close_btn)
        Me.Panel1.Controls.Add(Me.Movements_dgv)
        Me.Panel1.Controls.Add(Me.ToolStripMain)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(933, 385)
        Me.Panel1.TabIndex = 105
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(859, 0)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 120
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Movements_dgv
        '
        Me.Movements_dgv.AllowColumnHiding = True
        Me.Movements_dgv.AllowUserToAddRows = False
        Me.Movements_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Movements_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Movements_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Movements_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movements_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Movements_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Movements_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Description, Me.Location_, Me.Quantity, Me.UoM, Me.Fullname, Me.Date_, Me.Posted, Me.TransferQuantity, Me.FromSloc, Me.ToSloc, Me.DocumentNumber, Me.TransferUser})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Movements_dgv.DefaultCellStyle = DataGridViewCellStyle10
        Me.Movements_dgv.DefaultRowFilter = Nothing
        Me.Movements_dgv.EnableHeadersVisualStyles = False
        Me.Movements_dgv.Location = New System.Drawing.Point(3, 30)
        Me.Movements_dgv.Name = "Movements_dgv"
        Me.Movements_dgv.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movements_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Movements_dgv.RowHeadersWidth = 30
        Me.Movements_dgv.ShowRowNumber = True
        Me.Movements_dgv.Size = New System.Drawing.Size(925, 350)
        Me.Movements_dgv.TabIndex = 104
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Description.DefaultCellStyle = DataGridViewCellStyle3
        Me.Description.HeaderText = "Movimiento"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 90
        '
        'Location_
        '
        Me.Location_.DataPropertyName = "Location"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Location_.DefaultCellStyle = DataGridViewCellStyle4
        Me.Location_.HeaderText = "Localizacion"
        Me.Location_.Name = "Location_"
        Me.Location_.ReadOnly = True
        Me.Location_.Width = 75
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.Quantity.HeaderText = "Descuento"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 70
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.UoM.DefaultCellStyle = DataGridViewCellStyle6
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.ReadOnly = True
        Me.UoM.Width = 50
        '
        'Fullname
        '
        Me.Fullname.DataPropertyName = "FullName"
        Me.Fullname.HeaderText = "Realizado por"
        Me.Fullname.Name = "Fullname"
        Me.Fullname.ReadOnly = True
        Me.Fullname.Width = 90
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle7.Format = "g"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle7
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 90
        '
        'Posted
        '
        Me.Posted.DataPropertyName = "Posted"
        Me.Posted.HeaderText = "Transferido"
        Me.Posted.Name = "Posted"
        Me.Posted.ReadOnly = True
        Me.Posted.Width = 70
        '
        'TransferQuantity
        '
        Me.TransferQuantity.DataPropertyName = "TransferQuantity"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.Format = "N1"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TransferQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.TransferQuantity.HeaderText = "Cantidad Transferida"
        Me.TransferQuantity.Name = "TransferQuantity"
        Me.TransferQuantity.ReadOnly = True
        Me.TransferQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TransferQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TransferQuantity.Width = 70
        '
        'FromSloc
        '
        Me.FromSloc.DataPropertyName = "FromSloc"
        Me.FromSloc.HeaderText = "Del Sloc"
        Me.FromSloc.Name = "FromSloc"
        Me.FromSloc.ReadOnly = True
        Me.FromSloc.Width = 50
        '
        'ToSloc
        '
        Me.ToSloc.DataPropertyName = "ToSloc"
        Me.ToSloc.HeaderText = "Al Sloc"
        Me.ToSloc.Name = "ToSloc"
        Me.ToSloc.ReadOnly = True
        Me.ToSloc.Width = 50
        '
        'DocumentNumber
        '
        Me.DocumentNumber.DataPropertyName = "DocumentNumber"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.DocumentNumber.DefaultCellStyle = DataGridViewCellStyle9
        Me.DocumentNumber.HeaderText = "Documento"
        Me.DocumentNumber.Name = "DocumentNumber"
        Me.DocumentNumber.ReadOnly = true
        Me.DocumentNumber.Width = 80
        '
        'TransferUser
        '
        Me.TransferUser.DataPropertyName = "TransferUser"
        Me.TransferUser.HeaderText = "Transferido por"
        Me.TransferUser.Name = "TransferUser"
        Me.TransferUser.ReadOnly = true
        Me.TransferUser.Width = 90
        '
        'Smk_SerialMovements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 385)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Smk_SerialMovements"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supermarket"
        Me.ToolStripMain.ResumeLayout(false)
        Me.ToolStripMain.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.Movements_dgv,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Movements_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Posted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TransferQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FromSloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToSloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocumentNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferUser As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
