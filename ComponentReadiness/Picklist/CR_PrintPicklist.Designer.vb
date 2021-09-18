<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_PrintPicklist
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_PrintPicklist))
        Me.News_chk = New System.Windows.Forms.CheckBox()
        Me.PickedUp_chk = New System.Windows.Forms.CheckBox()
        Me.Shipped_chk = New System.Windows.Forms.CheckBox()
        Me.Picklists_dgv = New CAguilar.DataGridViewWithFilters()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManufacturingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.print_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Username_cbo = New System.Windows.Forms.ComboBox()
        Me.ID_txt = New System.Windows.Forms.TextBox()
        Me.Username_rb = New System.Windows.Forms.RadioButton()
        Me.ID_rb = New System.Windows.Forms.RadioButton()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Picklists_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'News_chk
        '
        Me.News_chk.AutoSize = True
        Me.News_chk.Checked = True
        Me.News_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.News_chk.Enabled = False
        Me.News_chk.Location = New System.Drawing.Point(231, 64)
        Me.News_chk.Name = "News_chk"
        Me.News_chk.Size = New System.Drawing.Size(63, 17)
        Me.News_chk.TabIndex = 90
        Me.News_chk.Text = "Nuevos"
        Me.News_chk.UseVisualStyleBackColor = True
        '
        'PickedUp_chk
        '
        Me.PickedUp_chk.AutoSize = True
        Me.PickedUp_chk.Location = New System.Drawing.Point(309, 64)
        Me.PickedUp_chk.Name = "PickedUp_chk"
        Me.PickedUp_chk.Size = New System.Drawing.Size(64, 17)
        Me.PickedUp_chk.TabIndex = 91
        Me.PickedUp_chk.Text = "Surtidos"
        Me.PickedUp_chk.UseVisualStyleBackColor = True
        '
        'Shipped_chk
        '
        Me.Shipped_chk.AutoSize = True
        Me.Shipped_chk.Location = New System.Drawing.Point(377, 64)
        Me.Shipped_chk.Name = "Shipped_chk"
        Me.Shipped_chk.Size = New System.Drawing.Size(85, 17)
        Me.Shipped_chk.TabIndex = 92
        Me.Shipped_chk.Text = "Embarcados"
        Me.Shipped_chk.UseVisualStyleBackColor = True
        '
        'Picklists_dgv
        '
        Me.Picklists_dgv.AllowColumnHiding = True
        Me.Picklists_dgv.AllowUserToAddRows = False
        Me.Picklists_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Picklists_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Picklists_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picklists_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Picklists_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Picklists_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Picklists_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Username, Me._date, Me.Material_col, Me.Quantity_col, Me.partnumbers, Me.ManufacturingDate_col, Me.ShippingDate_col, Me.print_btn})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Picklists_dgv.DefaultCellStyle = DataGridViewCellStyle15
        Me.Picklists_dgv.DefaultRowFilter = Nothing
        Me.Picklists_dgv.EnableHeadersVisualStyles = False
        Me.Picklists_dgv.Location = New System.Drawing.Point(4, 87)
        Me.Picklists_dgv.Name = "Picklists_dgv"
        Me.Picklists_dgv.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Picklists_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Picklists_dgv.ShowRowNumber = True
        Me.Picklists_dgv.Size = New System.Drawing.Size(966, 369)
        Me.Picklists_dgv.TabIndex = 89
        '
        'id
        '
        Me.id.DataPropertyName = "ID"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle11
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "g"
        DataGridViewCellStyle12.NullValue = Nothing
        Me._date.DefaultCellStyle = DataGridViewCellStyle12
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
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumbers.DefaultCellStyle = DataGridViewCellStyle13
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
        DataGridViewCellStyle14.Format = "d"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.ShippingDate_col.DefaultCellStyle = DataGridViewCellStyle14
        Me.ShippingDate_col.HeaderText = "Fecha Embarque"
        Me.ShippingDate_col.Name = "ShippingDate_col"
        Me.ShippingDate_col.ReadOnly = True
        '
        'print_btn
        '
        Me.print_btn.DefaultImage = Nothing
        Me.print_btn.DefaultText = ""
        Me.print_btn.HeaderText = ""
        Me.print_btn.Name = "print_btn"
        Me.print_btn.ReadOnly = True
        Me.print_btn.Width = 40
        '
        'Username_cbo
        '
        Me.Username_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Username_cbo.FormattingEnabled = True
        Me.Username_cbo.Location = New System.Drawing.Point(231, 37)
        Me.Username_cbo.Name = "Username_cbo"
        Me.Username_cbo.Size = New System.Drawing.Size(231, 21)
        Me.Username_cbo.TabIndex = 140
        '
        'ID_txt
        '
        Me.ID_txt.BackColor = System.Drawing.Color.Ivory
        Me.ID_txt.Location = New System.Drawing.Point(55, 38)
        Me.ID_txt.Name = "ID_txt"
        Me.ID_txt.Size = New System.Drawing.Size(100, 20)
        Me.ID_txt.TabIndex = 145
        '
        'Username_rb
        '
        Me.Username_rb.AutoSize = True
        Me.Username_rb.Location = New System.Drawing.Point(161, 39)
        Me.Username_rb.Name = "Username_rb"
        Me.Username_rb.Size = New System.Drawing.Size(64, 17)
        Me.Username_rb.TabIndex = 146
        Me.Username_rb.Text = "Usuario:"
        Me.Username_rb.UseVisualStyleBackColor = True
        '
        'ID_rb
        '
        Me.ID_rb.AutoSize = True
        Me.ID_rb.Checked = True
        Me.ID_rb.Location = New System.Drawing.Point(10, 39)
        Me.ID_rb.Name = "ID_rb"
        Me.ID_rb.Size = New System.Drawing.Size(39, 17)
        Me.ID_rb.TabIndex = 147
        Me.ID_rb.TabStop = True
        Me.ID_rb.Text = "ID:"
        Me.ID_rb.UseVisualStyleBackColor = True
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(488, 35)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(100, 25)
        Me.Find_btn.TabIndex = 148
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(974, 29)
        Me.ToolStripMain.TabIndex = 149
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
        Me.Title_lbl.Size = New System.Drawing.Size(233, 26)
        Me.Title_lbl.Text = "Imprimir Picklist de Material"
        '
        'CR_PrintPicklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 461)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.ID_rb)
        Me.Controls.Add(Me.Username_rb)
        Me.Controls.Add(Me.ID_txt)
        Me.Controls.Add(Me.Username_cbo)
        Me.Controls.Add(Me.Shipped_chk)
        Me.Controls.Add(Me.PickedUp_chk)
        Me.Controls.Add(Me.News_chk)
        Me.Controls.Add(Me.Picklists_dgv)
        Me.Name = "CR_PrintPicklist"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        CType(Me.Picklists_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Picklists_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents News_chk As System.Windows.Forms.CheckBox
    Friend WithEvents PickedUp_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Shipped_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Username_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents ID_txt As System.Windows.Forms.TextBox
    Friend WithEvents Username_rb As System.Windows.Forms.RadioButton
    Friend WithEvents ID_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Material_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManufacturingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents print_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
End Class
