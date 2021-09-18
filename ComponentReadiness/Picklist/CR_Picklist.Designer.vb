<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_Picklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_Picklist))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Save_btn = New System.Windows.Forms.ToolStripButton()
        Me.Paste_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Material_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Material_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.MfgDate_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShipDate_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Material_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MfgDate_col = New CAguilar.CalendarColumnOnlyDate()
        Me.ShipDate_col = New CAguilar.CalendarColumnOnlyDate()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Material_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Save_btn, Me.Paste_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(508, 29)
        Me.ToolStripMain.TabIndex = 121
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Save_btn
        '
        Me.Save_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(23, 26)
        Me.Save_btn.ToolTipText = "Guardar"
        '
        'Paste_btn
        '
        Me.Paste_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Paste_btn.Image = CType(resources.GetObject("Paste_btn.Image"), System.Drawing.Image)
        Me.Paste_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Paste_btn.Name = "Paste_btn"
        Me.Paste_btn.Size = New System.Drawing.Size(23, 26)
        Me.Paste_btn.ToolTipText = "Pegar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(215, 26)
        Me.Title_lbl.Text = "Nuevo Picklist de Material"
        '
        'Material_dgv
        '
        Me.Material_dgv.AllowColumnHiding = True
        Me.Material_dgv.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Material_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Material_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Material_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Material_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Material_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Material_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material_col, Me.Quantity_col, Me.MfgDate_col, Me.ShipDate_col})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Material_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Material_dgv.DefaultRowFilter = Nothing
        Me.Material_dgv.EnableHeadersVisualStyles = False
        Me.Material_dgv.Location = New System.Drawing.Point(5, 83)
        Me.Material_dgv.Name = "Material_dgv"
        Me.Material_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Material_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Material_dgv.ShowRowNumber = True
        Me.Material_dgv.Size = New System.Drawing.Size(499, 629)
        Me.Material_dgv.TabIndex = 124
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Material:"
        '
        'Material_txt
        '
        Me.Material_txt.BackColor = System.Drawing.Color.Ivory
        Me.Material_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Material_txt.Location = New System.Drawing.Point(15, 56)
        Me.Material_txt.Mask = "AAAAAAAA"
        Me.Material_txt.Name = "Material_txt"
        Me.Material_txt.Size = New System.Drawing.Size(80, 20)
        Me.Material_txt.TabIndex = 125
        Me.Material_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Material_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.Location = New System.Drawing.Point(101, 56)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Quantity_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(82, 20)
        Me.Quantity_nud.TabIndex = 126
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MfgDate_dtp
        '
        Me.MfgDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MfgDate_dtp.Location = New System.Drawing.Point(189, 56)
        Me.MfgDate_dtp.Name = "MfgDate_dtp"
        Me.MfgDate_dtp.Size = New System.Drawing.Size(100, 20)
        Me.MfgDate_dtp.TabIndex = 129
        '
        'Add_btn
        '
        Me.Add_btn.Image = Global.Delta_ERP.My.Resources.Resources.add_16
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(401, 52)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(100, 25)
        Me.Add_btn.TabIndex = 127
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Cantidad:"
        '
        'ShipDate_dtp
        '
        Me.ShipDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ShipDate_dtp.Location = New System.Drawing.Point(295, 56)
        Me.ShipDate_dtp.Name = "ShipDate_dtp"
        Me.ShipDate_dtp.Size = New System.Drawing.Size(100, 20)
        Me.ShipDate_dtp.TabIndex = 131
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Fecha de Mfa:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Fecha de Embarque:"
        '
        'Material_col
        '
        Me.Material_col.DataPropertyName = "Material"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Material_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.Material_col.HeaderText = "Material"
        Me.Material_col.Name = "Material_col"
        Me.Material_col.ReadOnly = True
        Me.Material_col.Width = 80
        '
        'Quantity_col
        '
        Me.Quantity_col.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Quantity_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Quantity_col.HeaderText = "Cantidad"
        Me.Quantity_col.Name = "Quantity_col"
        Me.Quantity_col.ReadOnly = True
        Me.Quantity_col.Width = 60
        '
        'MfgDate_col
        '
        Me.MfgDate_col.DataPropertyName = "ManufacturingDate"
        DataGridViewCellStyle5.Format = "d"
        Me.MfgDate_col.DefaultCellStyle = DataGridViewCellStyle5
        Me.MfgDate_col.HeaderText = "Fecha de Manufactura"
        Me.MfgDate_col.Name = "MfgDate_col"
        Me.MfgDate_col.ReadOnly = True
        Me.MfgDate_col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MfgDate_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MfgDate_col.Width = 90
        '
        'ShipDate_col
        '
        Me.ShipDate_col.DataPropertyName = "ShippingDate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "d"
        Me.ShipDate_col.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShipDate_col.HeaderText = "Fecha de Embarque"
        Me.ShipDate_col.Name = "ShipDate_col"
        Me.ShipDate_col.ReadOnly = True
        Me.ShipDate_col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ShipDate_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ShipDate_col.Width = 90
        '
        'CR_Picklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 716)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ShipDate_dtp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Material_txt)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.MfgDate_dtp)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Material_dgv)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "CR_Picklist"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Material_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Save_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Paste_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Material_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Material_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents MfgDate_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShipDate_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Material_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MfgDate_col As CAguilar.CalendarColumnOnlyDate
    Friend WithEvents ShipDate_col As CAguilar.CalendarColumnOnlyDate
End Class
