<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_PrintMover
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_PrintMover))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Approved_chk = New System.Windows.Forms.CheckBox()
        Me.PickedUp_chk = New System.Windows.Forms.CheckBox()
        Me.Shipped_chk = New System.Windows.Forms.CheckBox()
        Me.Movers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Username_cbo = New System.Windows.Forms.ComboBox()
        Me.ID_txt = New System.Windows.Forms.TextBox()
        Me.Username_rb = New System.Windows.Forms.RadioButton()
        Me.ID_rb = New System.Windows.Forms.RadioButton()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.print_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(974, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Imprimir Mover de Material"
        '
        'Approved_chk
        '
        Me.Approved_chk.AutoSize = True
        Me.Approved_chk.Checked = True
        Me.Approved_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Approved_chk.Enabled = False
        Me.Approved_chk.Location = New System.Drawing.Point(231, 64)
        Me.Approved_chk.Name = "Approved_chk"
        Me.Approved_chk.Size = New System.Drawing.Size(77, 17)
        Me.Approved_chk.TabIndex = 90
        Me.Approved_chk.Text = "Aprobados"
        Me.Approved_chk.UseVisualStyleBackColor = True
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
        'Movers_dgv
        '
        Me.Movers_dgv.AllowColumnHiding = True
        Me.Movers_dgv.AllowUserToAddRows = False
        Me.Movers_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Movers_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Movers_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Movers_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Movers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Movers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Username, Me._date, Me.requisitor, Me.customer, Me.partnumbers, Me.type, Me.locality, Me.ShippingDate_col, Me.print_btn})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Movers_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Movers_dgv.DefaultRowFilter = Nothing
        Me.Movers_dgv.EnableHeadersVisualStyles = False
        Me.Movers_dgv.Location = New System.Drawing.Point(4, 87)
        Me.Movers_dgv.Name = "Movers_dgv"
        Me.Movers_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movers_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Movers_dgv.ShowRowNumber = True
        Me.Movers_dgv.Size = New System.Drawing.Size(966, 369)
        Me.Movers_dgv.TabIndex = 89
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
        'requisitor
        '
        Me.requisitor.DataPropertyName = "Requisitor"
        Me.requisitor.HeaderText = "Requisitor"
        Me.requisitor.Name = "requisitor"
        Me.requisitor.ReadOnly = True
        Me.requisitor.Width = 120
        '
        'customer
        '
        Me.customer.DataPropertyName = "Customer"
        Me.customer.HeaderText = "Cliente"
        Me.customer.Name = "customer"
        Me.customer.ReadOnly = True
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
        'type
        '
        Me.type.DataPropertyName = "Description"
        Me.type.HeaderText = "Tipo"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Width = 80
        '
        'locality
        '
        Me.locality.DataPropertyName = "Locality"
        Me.locality.HeaderText = "Localidad"
        Me.locality.Name = "locality"
        Me.locality.ReadOnly = True
        '
        'ShippingDate_col
        '
        Me.ShippingDate_col.DataPropertyName = "ShippingDate"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ShippingDate_col.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShippingDate_col.HeaderText = "Fecha Req. Embarque"
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
        'Ord_PrintMover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 461)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.ID_rb)
        Me.Controls.Add(Me.Username_rb)
        Me.Controls.Add(Me.ID_txt)
        Me.Controls.Add(Me.Username_cbo)
        Me.Controls.Add(Me.Shipped_chk)
        Me.Controls.Add(Me.PickedUp_chk)
        Me.Controls.Add(Me.Approved_chk)
        Me.Controls.Add(Me.Movers_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Ord_PrintMover"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Movers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Approved_chk As System.Windows.Forms.CheckBox
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
    Friend WithEvents requisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents print_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
