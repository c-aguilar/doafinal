<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_SAPTransfers
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_SAPTransfers))
        Me.Transfers_dgv = New System.Windows.Forms.DataGridView()
        Me.partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sap_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.show_btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lbl10 = New System.Windows.Forms.Label()
        Me.Sloc_cbo = New System.Windows.Forms.ComboBox()
        Me.Incidents_dgv = New System.Windows.Forms.DataGridView()
        Me.Partials_dgv = New System.Windows.Forms.DataGridView()
        Me.serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fromsloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tosloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.base_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adjust_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flag_transfer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.cmsNoSAP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelContextMenuStrimItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.Transfers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Incidents_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Partials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsNoSAP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Transfers_dgv
        '
        Me.Transfers_dgv.AllowUserToAddRows = False
        Me.Transfers_dgv.AllowUserToDeleteRows = False
        Me.Transfers_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Transfers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Transfers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Transfers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.partnumber, Me.sap_quantity, Me.transfer_quantity, Me.show_btn})
        Me.Transfers_dgv.Location = New System.Drawing.Point(5, 59)
        Me.Transfers_dgv.MultiSelect = False
        Me.Transfers_dgv.Name = "Transfers_dgv"
        Me.Transfers_dgv.ReadOnly = True
        Me.Transfers_dgv.RowHeadersVisible = False
        Me.Transfers_dgv.Size = New System.Drawing.Size(359, 558)
        Me.Transfers_dgv.TabIndex = 106
        '
        'partnumber
        '
        Me.partnumber.DataPropertyName = "t_Partnumber"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.partnumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.partnumber.HeaderText = "Numero de Parte"
        Me.partnumber.Name = "partnumber"
        Me.partnumber.ReadOnly = True
        '
        'sap_quantity
        '
        Me.sap_quantity.DataPropertyName = "z_quantity"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.sap_quantity.DefaultCellStyle = DataGridViewCellStyle3
        Me.sap_quantity.HeaderText = "Cantidad en SAP"
        Me.sap_quantity.Name = "sap_quantity"
        Me.sap_quantity.ReadOnly = True
        Me.sap_quantity.Width = 80
        '
        'transfer_quantity
        '
        Me.transfer_quantity.DataPropertyName = "sum_transfers"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.transfer_quantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.transfer_quantity.HeaderText = "Cantidad a Transferir"
        Me.transfer_quantity.Name = "transfer_quantity"
        Me.transfer_quantity.ReadOnly = True
        Me.transfer_quantity.Width = 80
        '
        'show_btn
        '
        Me.show_btn.HeaderText = ""
        Me.show_btn.Name = "show_btn"
        Me.show_btn.ReadOnly = True
        Me.show_btn.Text = "Detalle..."
        Me.show_btn.UseColumnTextForButtonValue = True
        Me.show_btn.Width = 70
        '
        'lbl10
        '
        Me.lbl10.AutoSize = True
        Me.lbl10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl10.Location = New System.Drawing.Point(2, 35)
        Me.lbl10.Name = "lbl10"
        Me.lbl10.Size = New System.Drawing.Size(35, 13)
        Me.lbl10.TabIndex = 111
        Me.lbl10.Text = "SLoc:"
        '
        'Sloc_cbo
        '
        Me.Sloc_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Sloc_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sloc_cbo.FormattingEnabled = True
        Me.Sloc_cbo.Location = New System.Drawing.Point(43, 32)
        Me.Sloc_cbo.Name = "Sloc_cbo"
        Me.Sloc_cbo.Size = New System.Drawing.Size(87, 21)
        Me.Sloc_cbo.TabIndex = 110
        '
        'Incidents_dgv
        '
        Me.Incidents_dgv.AllowUserToAddRows = False
        Me.Incidents_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Incidents_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Incidents_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Incidents_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Incidents_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Incidents_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Incidents_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Incidents_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Incidents_dgv.Location = New System.Drawing.Point(739, 30)
        Me.Incidents_dgv.Name = "Incidents_dgv"
        Me.Incidents_dgv.ReadOnly = True
        Me.Incidents_dgv.RowHeadersVisible = False
        Me.Incidents_dgv.Size = New System.Drawing.Size(194, 72)
        Me.Incidents_dgv.TabIndex = 109
        '
        'Partials_dgv
        '
        Me.Partials_dgv.AllowUserToAddRows = False
        Me.Partials_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue
        Me.Partials_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Partials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Partials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Partials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serialnumber, Me.fromsloc, Me.tosloc, Me.quantity, Me.uom, Me.base_quantity, Me.adjust_quantity, Me.flag_transfer, Me.id})
        Me.Partials_dgv.Location = New System.Drawing.Point(374, 108)
        Me.Partials_dgv.MultiSelect = False
        Me.Partials_dgv.Name = "Partials_dgv"
        Me.Partials_dgv.RowHeadersVisible = False
        Me.Partials_dgv.Size = New System.Drawing.Size(559, 509)
        Me.Partials_dgv.TabIndex = 108
        '
        'serialnumber
        '
        Me.serialnumber.DataPropertyName = "t_Serialnumber"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serialnumber.DefaultCellStyle = DataGridViewCellStyle10
        Me.serialnumber.HeaderText = "Serie"
        Me.serialnumber.Name = "serialnumber"
        Me.serialnumber.ReadOnly = True
        '
        'fromsloc
        '
        Me.fromsloc.DataPropertyName = "t_FromSloc"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.fromsloc.DefaultCellStyle = DataGridViewCellStyle11
        Me.fromsloc.HeaderText = "Del SLoc"
        Me.fromsloc.Name = "fromsloc"
        Me.fromsloc.ReadOnly = True
        Me.fromsloc.Width = 60
        '
        'tosloc
        '
        Me.tosloc.DataPropertyName = "t_ToSloc"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tosloc.DefaultCellStyle = DataGridViewCellStyle12
        Me.tosloc.HeaderText = "Al SLoc"
        Me.tosloc.Name = "tosloc"
        Me.tosloc.ReadOnly = True
        Me.tosloc.Width = 60
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "t_Quantity"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "N3"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.quantity.DefaultCellStyle = DataGridViewCellStyle13
        Me.quantity.HeaderText = "Cantidad"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        Me.quantity.Width = 70
        '
        'uom
        '
        Me.uom.DataPropertyName = "t_UoM"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.uom.DefaultCellStyle = DataGridViewCellStyle14
        Me.uom.HeaderText = "Unidad"
        Me.uom.Name = "uom"
        Me.uom.ReadOnly = True
        Me.uom.Width = 50
        '
        'base_quantity
        '
        Me.base_quantity.DataPropertyName = "base_quantity"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "N3"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.base_quantity.DefaultCellStyle = DataGridViewCellStyle15
        Me.base_quantity.HeaderText = "Cantidad Base"
        Me.base_quantity.Name = "base_quantity"
        Me.base_quantity.ReadOnly = True
        Me.base_quantity.Width = 70
        '
        'adjust_quantity
        '
        Me.adjust_quantity.DataPropertyName = "t_NewQuantity"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Format = "N3"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.adjust_quantity.DefaultCellStyle = DataGridViewCellStyle16
        Me.adjust_quantity.HeaderText = "Cantidad Ajustada"
        Me.adjust_quantity.Name = "adjust_quantity"
        Me.adjust_quantity.Width = 70
        '
        'flag_transfer
        '
        Me.flag_transfer.DataPropertyName = "t_FlagTransfer"
        Me.flag_transfer.HeaderText = "Transferir"
        Me.flag_transfer.Name = "flag_transfer"
        Me.flag_transfer.Width = 60
        '
        'id
        '
        Me.id.DataPropertyName = "t_TransferID"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'Run_btn
        '
        Me.Run_btn.BackColor = System.Drawing.Color.Transparent
        Me.Run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(136, 30)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(150, 25)
        Me.Run_btn.TabIndex = 107
        Me.Run_btn.Text = "Actualizar Inventario"
        Me.Run_btn.UseVisualStyleBackColor = False
        '
        'cmsNoSAP
        '
        Me.cmsNoSAP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelContextMenuStrimItem})
        Me.cmsNoSAP.Name = "cmsCopy"
        Me.cmsNoSAP.Size = New System.Drawing.Size(195, 26)
        '
        'CancelContextMenuStrimItem
        '
        Me.CancelContextMenuStrimItem.Name = "CancelContextMenuStrimItem"
        Me.CancelContextMenuStrimItem.Size = New System.Drawing.Size(194, 22)
        Me.CancelContextMenuStrimItem.Text = "Cancelar Transferencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(371, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Detalle:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(939, 25)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Transferencia a SAP - MB1B"
        '
        'Smk_SAPTransfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 624)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Transfers_dgv)
        Me.Controls.Add(Me.lbl10)
        Me.Controls.Add(Me.Sloc_cbo)
        Me.Controls.Add(Me.Incidents_dgv)
        Me.Controls.Add(Me.Partials_dgv)
        Me.Controls.Add(Me.Run_btn)
        Me.Name = "Smk_SAPTransfers"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Transfers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Incidents_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Partials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsNoSAP.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Transfers_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lbl10 As System.Windows.Forms.Label
    Friend WithEvents Sloc_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Incidents_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Partials_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents cmsNoSAP As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelContextMenuStrimItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fromsloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tosloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adjust_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents flag_transfer As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sap_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents transfer_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents show_btn As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
