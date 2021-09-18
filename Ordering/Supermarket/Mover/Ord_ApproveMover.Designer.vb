<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ApproveMover
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Movers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._user = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partnumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.show_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.approve_btn = New CAguilar.DataGridViewImprovedButtonColumn()
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
        Me.Label7.Size = New System.Drawing.Size(1239, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Aprobar Movers de Material"
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
        Me.Movers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me._user, Me.requisitor, Me.reason, Me.customer, Me.partnumbers, Me.Cost, Me.type, Me.locality, Me._date, Me.comments, Me.show_btn, Me.approve_btn})
        Me.Movers_dgv.Location = New System.Drawing.Point(4, 28)
        Me.Movers_dgv.Name = "Movers_dgv"
        Me.Movers_dgv.ReadOnly = True
        Me.Movers_dgv.ShowRowNumber = True
        Me.Movers_dgv.Size = New System.Drawing.Size(1231, 329)
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
        '_user
        '
        Me._user.DataPropertyName = "FullName"
        Me._user.HeaderText = "Usuario"
        Me._user.Name = "_user"
        Me._user.ReadOnly = True
        Me._user.Width = 120
        '
        'requisitor
        '
        Me.requisitor.DataPropertyName = "Requisitor"
        Me.requisitor.HeaderText = "Requisitor"
        Me.requisitor.Name = "requisitor"
        Me.requisitor.ReadOnly = True
        Me.requisitor.Width = 120
        '
        'reason
        '
        Me.reason.DataPropertyName = "reason"
        Me.reason.HeaderText = "Razon"
        Me.reason.Name = "reason"
        Me.reason.ReadOnly = True
        Me.reason.Width = 120
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
        'Cost
        '
        Me.Cost.DataPropertyName = "Cost"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "C1"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cost.HeaderText = "Costo"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        Me.Cost.Width = 70
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        Me._date.DefaultCellStyle = DataGridViewCellStyle5
        Me._date.HeaderText = "Fecha"
        Me._date.Name = "_date"
        Me._date.ReadOnly = True
        '
        'comments
        '
        Me.comments.DataPropertyName = "comments"
        Me.comments.HeaderText = "Comentarios"
        Me.comments.Name = "comments"
        Me.comments.ReadOnly = True
        Me.comments.Width = 150
        '
        'show_btn
        '
        Me.show_btn.DefaultImage = Nothing
        Me.show_btn.DefaultText = ""
        Me.show_btn.HeaderText = ""
        Me.show_btn.Name = "show_btn"
        Me.show_btn.ReadOnly = True
        Me.show_btn.Width = 30
        '
        'approve_btn
        '
        Me.approve_btn.DefaultImage = Nothing
        Me.approve_btn.DefaultText = ""
        Me.approve_btn.HeaderText = ""
        Me.approve_btn.Name = "approve_btn"
        Me.approve_btn.ReadOnly = True
        Me.approve_btn.Width = 30
        '
        'Ord_ApproveMover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 362)
        Me.Controls.Add(Me.Movers_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Ord_ApproveMover"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Movers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Movers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _user As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents show_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents approve_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
