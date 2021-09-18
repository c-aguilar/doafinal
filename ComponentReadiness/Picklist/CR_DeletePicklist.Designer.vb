<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_DeletePicklist
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_DeletePicklist))
        Me.Picklists_dgv = New CAguilar.DataGridViewWithFilters()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManufacturingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delete_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Picklists_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Picklists_dgv
        '
        Me.Picklists_dgv.AllowColumnHiding = True
        Me.Picklists_dgv.AllowUserToAddRows = False
        Me.Picklists_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Picklists_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Picklists_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picklists_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Picklists_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Picklists_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Picklists_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Username, Me._date, Me.Material_col, Me.Quantity_col, Me.partnumbers, Me.ManufacturingDate_col, Me.ShippingDate_col, Me.delete_btn})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Picklists_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Picklists_dgv.DefaultRowFilter = Nothing
        Me.Picklists_dgv.EnableHeadersVisualStyles = False
        Me.Picklists_dgv.Location = New System.Drawing.Point(4, 28)
        Me.Picklists_dgv.Name = "Picklists_dgv"
        Me.Picklists_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Picklists_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Picklists_dgv.ShowRowNumber = True
        Me.Picklists_dgv.Size = New System.Drawing.Size(966, 428)
        Me.Picklists_dgv.TabIndex = 89
        '
        'id
        '
        Me.id.DataPropertyName = "ID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle3
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 70
        '
        'Username
        '
        Me.Username.DataPropertyName = "Fullname"
        Me.Username.HeaderText = "Usuario"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        '
        '_date
        '
        Me._date.DataPropertyName = "Date"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "g"
        DataGridViewCellStyle4.NullValue = Nothing
        Me._date.DefaultCellStyle = DataGridViewCellStyle4
        Me._date.HeaderText = "Fecha"
        Me._date.Name = "_date"
        Me._date.ReadOnly = True
        '
        'Material_col
        '
        Me.Material_col.DataPropertyName = "Material"
        Me.Material_col.HeaderText = "Material"
        Me.Material_col.Name = "Material_col"
        Me.Material_col.ReadOnly = True
        '
        'Quantity_col
        '
        Me.Quantity_col.DataPropertyName = "Quantity"
        Me.Quantity_col.HeaderText = "Cantidad"
        Me.Quantity_col.Name = "Quantity_col"
        Me.Quantity_col.ReadOnly = True
        '
        'partnumbers
        '
        Me.partnumbers.DataPropertyName = "Partnumbers"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumbers.DefaultCellStyle = DataGridViewCellStyle5
        Me.partnumbers.HeaderText = "Nos. de Parte"
        Me.partnumbers.Name = "partnumbers"
        Me.partnumbers.ReadOnly = True
        Me.partnumbers.Width = 80
        '
        'ManufacturingDate_col
        '
        Me.ManufacturingDate_col.DataPropertyName = "ManufacturingDate"
        Me.ManufacturingDate_col.HeaderText = "Fecha Manufactura"
        Me.ManufacturingDate_col.Name = "ManufacturingDate_col"
        Me.ManufacturingDate_col.ReadOnly = True
        '
        'ShippingDate_col
        '
        Me.ShippingDate_col.DataPropertyName = "ShippingDate"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ShippingDate_col.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShippingDate_col.HeaderText = "Fecha Embarque"
        Me.ShippingDate_col.Name = "ShippingDate_col"
        Me.ShippingDate_col.ReadOnly = True
        '
        'delete_btn
        '
        Me.delete_btn.DefaultImage = Nothing
        Me.delete_btn.DefaultText = ""
        Me.delete_btn.HeaderText = ""
        Me.delete_btn.Name = "delete_btn"
        Me.delete_btn.ReadOnly = True
        Me.delete_btn.Width = 40
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(974, 29)
        Me.ToolStripMain.TabIndex = 150
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "Actualizar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(232, 26)
        Me.Title_lbl.Text = "Eliminar Picklist de Material"
        '
        'CR_DeletePicklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 461)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Picklists_dgv)
        Me.Name = "CR_DeletePicklist"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        CType(Me.Picklists_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Picklists_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Material_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManufacturingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delete_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
End Class
