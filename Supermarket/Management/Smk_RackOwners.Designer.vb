<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_RackOwners
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_RackOwners))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Badge_cbo = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Racks_dgv = New System.Windows.Forms.DataGridView()
        Me.Rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehousename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delete_btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Warehouse_cbo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Rack_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Add_btn = New System.Windows.Forms.Button()
        CType(Me.Racks_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Operador seleccionado:"
        '
        'Badge_cbo
        '
        Me.Badge_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Badge_cbo.FormattingEnabled = True
        Me.Badge_cbo.Location = New System.Drawing.Point(5, 50)
        Me.Badge_cbo.Name = "Badge_cbo"
        Me.Badge_cbo.Size = New System.Drawing.Size(206, 21)
        Me.Badge_cbo.TabIndex = 50
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(344, 25)
        Me.lblTitle.TabIndex = 51
        Me.lblTitle.Text = "Dueños de Rack"
        '
        'Racks_dgv
        '
        Me.Racks_dgv.AllowUserToAddRows = False
        Me.Racks_dgv.AllowUserToDeleteRows = False
        Me.Racks_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Racks_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Racks_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rack, Me.Warehousename, Me.Warehouse, Me.Delete_btn})
        Me.Racks_dgv.Location = New System.Drawing.Point(5, 77)
        Me.Racks_dgv.Name = "Racks_dgv"
        Me.Racks_dgv.ReadOnly = True
        Me.Racks_dgv.RowHeadersVisible = False
        Me.Racks_dgv.Size = New System.Drawing.Size(206, 378)
        Me.Racks_dgv.TabIndex = 53
        '
        'Rack
        '
        Me.Rack.DataPropertyName = "Rack"
        Me.Rack.HeaderText = "Rack"
        Me.Rack.Name = "Rack"
        Me.Rack.ReadOnly = True
        Me.Rack.Width = 50
        '
        'Warehousename
        '
        Me.Warehousename.DataPropertyName = "Name"
        Me.Warehousename.HeaderText = "Estacion"
        Me.Warehousename.Name = "Warehousename"
        Me.Warehousename.ReadOnly = True
        Me.Warehousename.Width = 80
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "Warehouse"
        Me.Warehouse.HeaderText = "Warehouse"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        Me.Warehouse.Visible = False
        '
        'Delete_btn
        '
        Me.Delete_btn.HeaderText = "Eliminar"
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.ReadOnly = True
        Me.Delete_btn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Delete_btn.Width = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Estacion:"
        '
        'Warehouse_cbo
        '
        Me.Warehouse_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Warehouse_cbo.FormattingEnabled = True
        Me.Warehouse_cbo.Location = New System.Drawing.Point(217, 146)
        Me.Warehouse_cbo.Name = "Warehouse_cbo"
        Me.Warehouse_cbo.Size = New System.Drawing.Size(115, 21)
        Me.Warehouse_cbo.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Rack:"
        '
        'Rack_txt
        '
        Me.Rack_txt.BackColor = System.Drawing.Color.Ivory
        Me.Rack_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rack_txt.Location = New System.Drawing.Point(217, 93)
        Me.Rack_txt.Mask = "00"
        Me.Rack_txt.Name = "Rack_txt"
        Me.Rack_txt.Size = New System.Drawing.Size(42, 26)
        Me.Rack_txt.TabIndex = 56
        Me.Rack_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Rack_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Add_btn
        '
        Me.Add_btn.Image = CType(resources.GetObject("Add_btn.Image"), System.Drawing.Image)
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(217, 186)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(100, 25)
        Me.Add_btn.TabIndex = 58
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Smk_RackOwners
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 460)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Rack_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Warehouse_cbo)
        Me.Controls.Add(Me.Racks_dgv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Badge_cbo)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "Smk_RackOwners"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Racks_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Badge_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Racks_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Warehouse_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rack_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehousename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delete_btn As System.Windows.Forms.DataGridViewButtonColumn
End Class
