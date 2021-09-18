<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_NewMover
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_NewMover))
        Me.Requisitor_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Reason_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Customer_txt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Locality_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Type_cbo = New System.Windows.Forms.ComboBox()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UOM_cbo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TSA_txt = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Description_txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Partnumbers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Save_btn = New System.Windows.Forms.ToolStripButton()
        Me.Paste_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Shipping_lbl = New System.Windows.Forms.Label()
        Me.ShippingDate_dtp = New System.Windows.Forms.DateTimePicker()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Requisitor_txt
        '
        Me.Requisitor_txt.BackColor = System.Drawing.Color.Ivory
        Me.Requisitor_txt.Location = New System.Drawing.Point(72, 35)
        Me.Requisitor_txt.MaxLength = 30
        Me.Requisitor_txt.Name = "Requisitor_txt"
        Me.Requisitor_txt.Size = New System.Drawing.Size(202, 20)
        Me.Requisitor_txt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Requisitor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Razon:"
        '
        'Reason_txt
        '
        Me.Reason_txt.BackColor = System.Drawing.Color.Ivory
        Me.Reason_txt.Location = New System.Drawing.Point(72, 61)
        Me.Reason_txt.MaxLength = 300
        Me.Reason_txt.Multiline = True
        Me.Reason_txt.Name = "Reason_txt"
        Me.Reason_txt.Size = New System.Drawing.Size(202, 49)
        Me.Reason_txt.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(282, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Comentario:"
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.Ivory
        Me.Comment_txt.Location = New System.Drawing.Point(349, 61)
        Me.Comment_txt.MaxLength = 500
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(202, 49)
        Me.Comment_txt.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Cliente:"
        '
        'Customer_txt
        '
        Me.Customer_txt.BackColor = System.Drawing.Color.Ivory
        Me.Customer_txt.Location = New System.Drawing.Point(349, 35)
        Me.Customer_txt.MaxLength = 50
        Me.Customer_txt.Name = "Customer_txt"
        Me.Customer_txt.Size = New System.Drawing.Size(202, 20)
        Me.Customer_txt.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(573, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Tipo:"
        '
        'Locality_txt
        '
        Me.Locality_txt.BackColor = System.Drawing.Color.Ivory
        Me.Locality_txt.Location = New System.Drawing.Point(633, 61)
        Me.Locality_txt.MaxLength = 50
        Me.Locality_txt.Name = "Locality_txt"
        Me.Locality_txt.Size = New System.Drawing.Size(156, 20)
        Me.Locality_txt.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(573, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Localidad:"
        '
        'Type_cbo
        '
        Me.Type_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Type_cbo.FormattingEnabled = True
        Me.Type_cbo.Location = New System.Drawing.Point(633, 35)
        Me.Type_cbo.Name = "Type_cbo"
        Me.Type_cbo.Size = New System.Drawing.Size(156, 21)
        Me.Type_cbo.TabIndex = 3
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(6, 32)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(80, 20)
        Me.Partnumber_txt.TabIndex = 7
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "No. Parte:"
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.Location = New System.Drawing.Point(309, 32)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Quantity_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(82, 20)
        Me.Quantity_nud.TabIndex = 8
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(306, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Cantidad:"
        '
        'UOM_cbo
        '
        Me.UOM_cbo.BackColor = System.Drawing.Color.Ivory
        Me.UOM_cbo.FormattingEnabled = True
        Me.UOM_cbo.Items.AddRange(New Object() {"PC", "M", "FT", "L", "LB", "KG"})
        Me.UOM_cbo.Location = New System.Drawing.Point(397, 31)
        Me.UOM_cbo.Name = "UOM_cbo"
        Me.UOM_cbo.Size = New System.Drawing.Size(88, 21)
        Me.UOM_cbo.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(394, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Unidad:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(488, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "TSA:"
        '
        'TSA_txt
        '
        Me.TSA_txt.BackColor = System.Drawing.Color.Ivory
        Me.TSA_txt.Location = New System.Drawing.Point(491, 31)
        Me.TSA_txt.MaxLength = 25
        Me.TSA_txt.Name = "TSA_txt"
        Me.TSA_txt.Size = New System.Drawing.Size(202, 20)
        Me.TSA_txt.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Description_txt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Add_btn)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TSA_txt)
        Me.GroupBox1.Controls.Add(Me.Partnumber_txt)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Quantity_nud)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.UOM_cbo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(810, 64)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nos. de Parte"
        '
        'Description_txt
        '
        Me.Description_txt.BackColor = System.Drawing.Color.Ivory
        Me.Description_txt.Location = New System.Drawing.Point(92, 31)
        Me.Description_txt.MaxLength = 25
        Me.Description_txt.Name = "Description_txt"
        Me.Description_txt.ReadOnly = True
        Me.Description_txt.Size = New System.Drawing.Size(211, 20)
        Me.Description_txt.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(89, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Descripcion:"
        '
        'Add_btn
        '
        Me.Add_btn.Image = Global.Delta_ERP.My.Resources.Resources.add_16
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(699, 27)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(100, 25)
        Me.Add_btn.TabIndex = 11
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Partnumbers_dgv
        '
        Me.Partnumbers_dgv.AllowColumnHiding = True
        Me.Partnumbers_dgv.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Partnumbers_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Partnumbers_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Partnumbers_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Partnumbers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Partnumbers_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Partnumbers_dgv.DefaultRowFilter = Nothing
        Me.Partnumbers_dgv.EnableHeadersVisualStyles = False
        Me.Partnumbers_dgv.Location = New System.Drawing.Point(6, 186)
        Me.Partnumbers_dgv.Name = "Partnumbers_dgv"
        Me.Partnumbers_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Partnumbers_dgv.ShowRowNumber = True
        Me.Partnumbers_dgv.Size = New System.Drawing.Size(912, 324)
        Me.Partnumbers_dgv.TabIndex = 118
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Save_btn, Me.Paste_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(924, 29)
        Me.ToolStripMain.TabIndex = 120
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
        Me.Title_lbl.Size = New System.Drawing.Size(206, 26)
        Me.Title_lbl.Text = "Nuevo Mover de Material"
        '
        'Shipping_lbl
        '
        Me.Shipping_lbl.AutoSize = True
        Me.Shipping_lbl.Location = New System.Drawing.Point(573, 90)
        Me.Shipping_lbl.Name = "Shipping_lbl"
        Me.Shipping_lbl.Size = New System.Drawing.Size(58, 13)
        Me.Shipping_lbl.TabIndex = 121
        Me.Shipping_lbl.Text = "Embarque:"
        Me.Shipping_lbl.Visible = False
        '
        'ShippingDate_dtp
        '
        Me.ShippingDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ShippingDate_dtp.Location = New System.Drawing.Point(633, 87)
        Me.ShippingDate_dtp.Name = "ShippingDate_dtp"
        Me.ShippingDate_dtp.Size = New System.Drawing.Size(156, 20)
        Me.ShippingDate_dtp.TabIndex = 122
        Me.ShippingDate_dtp.Visible = False
        '
        'Ord_NewMover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 516)
        Me.Controls.Add(Me.ShippingDate_dtp)
        Me.Controls.Add(Me.Shipping_lbl)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Partnumbers_dgv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Type_cbo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Locality_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Customer_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Reason_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Requisitor_txt)
        Me.Name = "Ord_NewMover"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Requisitor_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Reason_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Customer_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Locality_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Type_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UOM_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TSA_txt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumbers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Save_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Paste_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Description_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Shipping_lbl As System.Windows.Forms.Label
    Friend WithEvents ShippingDate_dtp As System.Windows.Forms.DateTimePicker
End Class
