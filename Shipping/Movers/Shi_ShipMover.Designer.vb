<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shi_ShipMover
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shi_ShipMover))
        Me.Movers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.export_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.ship_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Movers_dgv
        '
        Me.Movers_dgv.AllowColumnHiding = True
        Me.Movers_dgv.AllowUserToAddRows = False
        Me.Movers_dgv.AllowUserToDeleteRows = False
        Me.Movers_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Movers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Movers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Username, Me.requisitor, Me.customer, Me.partnumbers, Me.type, Me.locality, Me._date, Me.export_btn, Me.ship_btn})
        Me.Movers_dgv.Location = New System.Drawing.Point(4, 32)
        Me.Movers_dgv.Name = "Movers_dgv"
        Me.Movers_dgv.ReadOnly = True
        Me.Movers_dgv.ShowRowNumber = True
        Me.Movers_dgv.Size = New System.Drawing.Size(866, 424)
        Me.Movers_dgv.TabIndex = 89
        '
        'id
        '
        Me.id.DataPropertyName = "ID"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 70
        '
        'Username
        '
        Me.Username.DataPropertyName = "Fullname"
        Me.Username.HeaderText = "Creado por"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumbers.DefaultCellStyle = DataGridViewCellStyle3
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
        'export_btn
        '
        Me.export_btn.HeaderText = ""
        Me.export_btn.Name = "export_btn"
        Me.export_btn.ReadOnly = True
        Me.export_btn.Width = 30
        '
        'ship_btn
        '
        Me.ship_btn.HeaderText = ""
        Me.ship_btn.Name = "ship_btn"
        Me.ship_btn.ReadOnly = True
        Me.ship_btn.Width = 30
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(874, 29)
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
        Me.Title_lbl.Size = New System.Drawing.Size(262, 26)
        Me.Title_lbl.Text = "Marcar Mover como Embarcado"
        '
        'Shi_ShipMover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 461)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Movers_dgv)
        Me.Name = "Shi_ShipMover"
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
    Friend WithEvents requisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents export_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents ship_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
