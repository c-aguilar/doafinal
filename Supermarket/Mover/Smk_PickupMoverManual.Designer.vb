<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_PickUpMoverManual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_PickUpMoverManual))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Movers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pickup_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Movers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Movers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Username, Me._date, Me.requisitor, Me.customer, Me.partnumbers, Me.type, Me.locality, Me.ShippingDate_col, Me.pickup_btn})
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
        Me.Movers_dgv.Location = New System.Drawing.Point(4, 32)
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
        Me.Movers_dgv.Size = New System.Drawing.Size(959, 424)
        Me.Movers_dgv.TabIndex = 89
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(967, 29)
        Me.ToolStripMain.TabIndex = 116
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
        Me.Title_lbl.Size = New System.Drawing.Size(230, 26)
        Me.Title_lbl.Text = "Marcar Mover como Surtido"
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
        'pickup_btn
        '
        Me.pickup_btn.DefaultImage = Nothing
        Me.pickup_btn.DefaultText = ""
        Me.pickup_btn.HeaderText = ""
        Me.pickup_btn.Name = "pickup_btn"
        Me.pickup_btn.ReadOnly = True
        Me.pickup_btn.Width = 30
        '
        'Smk_PickUpMoverManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 461)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Movers_dgv)
        Me.Name = "Smk_PickUpMoverManual"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Movers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pickup_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
