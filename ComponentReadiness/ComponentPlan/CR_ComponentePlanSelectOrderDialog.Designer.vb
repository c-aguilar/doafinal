<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ComponentePlanSelectOrderDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ComponentePlanSelectOrderDialog))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Orders_dgv = New System.Windows.Forms.DataGridView()
        Me.Order_ID_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_SupplierNumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_SupplierName_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_Quantity_Col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_UoM_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_ShipDate_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Orders_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(400, 147)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 103
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'OK_btn
        '
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(294, 147)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 102
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Orders_dgv
        '
        Me.Orders_dgv.AllowUserToAddRows = False
        Me.Orders_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Orders_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Orders_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Orders_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Orders_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Orders_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Orders_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Orders_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Orders_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Order_ID_col, Me.Order_SupplierNumber_col, Me.Order_SupplierName_col, Me.Order_Quantity_Col, Me.Order_UoM_col, Me.Order_ShipDate_col})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Orders_dgv.DefaultCellStyle = DataGridViewCellStyle8
        Me.Orders_dgv.EnableHeadersVisualStyles = False
        Me.Orders_dgv.Location = New System.Drawing.Point(3, 2)
        Me.Orders_dgv.MultiSelect = False
        Me.Orders_dgv.Name = "Orders_dgv"
        Me.Orders_dgv.ReadOnly = True
        Me.Orders_dgv.RowHeadersVisible = False
        Me.Orders_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Orders_dgv.Size = New System.Drawing.Size(498, 144)
        Me.Orders_dgv.TabIndex = 104
        '
        'Order_ID_col
        '
        Me.Order_ID_col.DataPropertyName = "ID"
        Me.Order_ID_col.HeaderText = "ID"
        Me.Order_ID_col.Name = "Order_ID_col"
        Me.Order_ID_col.ReadOnly = True
        Me.Order_ID_col.Visible = False
        '
        'Order_SupplierNumber_col
        '
        Me.Order_SupplierNumber_col.DataPropertyName = "SupplierNumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Order_SupplierNumber_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.Order_SupplierNumber_col.HeaderText = "No. de Proveedor"
        Me.Order_SupplierNumber_col.Name = "Order_SupplierNumber_col"
        Me.Order_SupplierNumber_col.ReadOnly = True
        Me.Order_SupplierNumber_col.Width = 70
        '
        'Order_SupplierName_col
        '
        Me.Order_SupplierName_col.DataPropertyName = "SupplierName"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Order_SupplierName_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Order_SupplierName_col.HeaderText = "Nombre"
        Me.Order_SupplierName_col.Name = "Order_SupplierName_col"
        Me.Order_SupplierName_col.ReadOnly = True
        Me.Order_SupplierName_col.Width = 170
        '
        'Order_Quantity_Col
        '
        Me.Order_Quantity_Col.DataPropertyName = "Quantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Order_Quantity_Col.DefaultCellStyle = DataGridViewCellStyle5
        Me.Order_Quantity_Col.HeaderText = "Cantidad"
        Me.Order_Quantity_Col.Name = "Order_Quantity_Col"
        Me.Order_Quantity_Col.ReadOnly = True
        Me.Order_Quantity_Col.Width = 80
        '
        'Order_UoM_col
        '
        Me.Order_UoM_col.DataPropertyName = "UoM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Order_UoM_col.DefaultCellStyle = DataGridViewCellStyle6
        Me.Order_UoM_col.HeaderText = "Unidad"
        Me.Order_UoM_col.Name = "Order_UoM_col"
        Me.Order_UoM_col.ReadOnly = True
        Me.Order_UoM_col.Width = 50
        '
        'Order_ShipDate_col
        '
        Me.Order_ShipDate_col.DataPropertyName = "ShipDate"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Order_ShipDate_col.DefaultCellStyle = DataGridViewCellStyle7
        Me.Order_ShipDate_col.HeaderText = "Fecha de PickUp"
        Me.Order_ShipDate_col.Name = "Order_ShipDate_col"
        Me.Order_ShipDate_col.ReadOnly = True
        Me.Order_ShipDate_col.Width = 110
        '
        'CR_ComponentePlanSelectOrderDialog
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(505, 177)
        Me.Controls.Add(Me.Orders_dgv)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CR_ComponentePlanSelectOrderDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar orden:"
        CType(Me.Orders_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Orders_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Order_ID_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_SupplierNumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_SupplierName_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_Quantity_Col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_UoM_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_ShipDate_col As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
