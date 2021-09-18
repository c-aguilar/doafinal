<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ImportPhysicalInventory
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ImportPhysicalInventory))
        Me.Inventory_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Inventory_Partnumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inventory_Quantity_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inventory_UoM_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inventory_ValidPartnumber_col = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Inventory_ValidUoM_col = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Paste_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.OK_btn = New System.Windows.Forms.Button()
        CType(Me.Inventory_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Inventory_dgv
        '
        Me.Inventory_dgv.AllowColumnHiding = False
        Me.Inventory_dgv.AllowUserToAddRows = False
        Me.Inventory_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Inventory_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Inventory_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Inventory_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Inventory_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Inventory_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Inventory_Partnumber_col, Me.Inventory_Quantity_col, Me.Inventory_UoM_col, Me.Inventory_ValidPartnumber_col, Me.Inventory_ValidUoM_col})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Inventory_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Inventory_dgv.DefaultRowFilter = Nothing
        Me.Inventory_dgv.EnableHeadersVisualStyles = False
        Me.Inventory_dgv.Location = New System.Drawing.Point(3, 29)
        Me.Inventory_dgv.Name = "Inventory_dgv"
        Me.Inventory_dgv.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Inventory_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Inventory_dgv.ShowRowNumber = True
        Me.Inventory_dgv.Size = New System.Drawing.Size(279, 564)
        Me.Inventory_dgv.TabIndex = 24
        '
        'Inventory_Partnumber_col
        '
        Me.Inventory_Partnumber_col.DataPropertyName = "Partnumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Inventory_Partnumber_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.Inventory_Partnumber_col.HeaderText = "No. de Parte"
        Me.Inventory_Partnumber_col.Name = "Inventory_Partnumber_col"
        Me.Inventory_Partnumber_col.ReadOnly = True
        Me.Inventory_Partnumber_col.Width = 90
        '
        'Inventory_Quantity_col
        '
        Me.Inventory_Quantity_col.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Inventory_Quantity_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Inventory_Quantity_col.HeaderText = "Cantidad"
        Me.Inventory_Quantity_col.Name = "Inventory_Quantity_col"
        Me.Inventory_Quantity_col.ReadOnly = True
        Me.Inventory_Quantity_col.Width = 80
        '
        'Inventory_UoM_col
        '
        Me.Inventory_UoM_col.DataPropertyName = "UoM"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Inventory_UoM_col.DefaultCellStyle = DataGridViewCellStyle5
        Me.Inventory_UoM_col.HeaderText = "Unidad"
        Me.Inventory_UoM_col.Name = "Inventory_UoM_col"
        Me.Inventory_UoM_col.ReadOnly = True
        Me.Inventory_UoM_col.Width = 50
        '
        'Inventory_ValidPartnumber_col
        '
        Me.Inventory_ValidPartnumber_col.DataPropertyName = "ValidPartnumber"
        Me.Inventory_ValidPartnumber_col.HeaderText = "ValidPartnumber"
        Me.Inventory_ValidPartnumber_col.Name = "Inventory_ValidPartnumber_col"
        Me.Inventory_ValidPartnumber_col.ReadOnly = True
        Me.Inventory_ValidPartnumber_col.Visible = False
        Me.Inventory_ValidPartnumber_col.Width = 50
        '
        'Inventory_ValidUoM_col
        '
        Me.Inventory_ValidUoM_col.DataPropertyName = "ValidUoM"
        Me.Inventory_ValidUoM_col.HeaderText = "ValidUoM"
        Me.Inventory_ValidUoM_col.Name = "Inventory_ValidUoM_col"
        Me.Inventory_ValidUoM_col.ReadOnly = True
        Me.Inventory_ValidUoM_col.Visible = False
        Me.Inventory_ValidUoM_col.Width = 50
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Paste_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(280, 29)
        Me.ToolStripMain.TabIndex = 128
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Paste_btn
        '
        Me.Paste_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Paste_btn.Image = CType(resources.GetObject("Paste_btn.Image"), System.Drawing.Image)
        Me.Paste_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Paste_btn.Name = "Paste_btn"
        Me.Paste_btn.Size = New System.Drawing.Size(23, 26)
        Me.Paste_btn.Text = "&Exportar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(197, 26)
        Me.Title_lbl.Text = "Importar Inventario WIP"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(179, 596)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 130
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'OK_btn
        '
        Me.OK_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(73, 596)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 129
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'CR_ImportPhysicalInventory
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(280, 621)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Inventory_dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CR_ImportPhysicalInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Component Readiness"
        CType(Me.Inventory_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Inventory_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Paste_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Inventory_Partnumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inventory_Quantity_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inventory_UoM_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inventory_ValidPartnumber_col As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Inventory_ValidUoM_col As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
