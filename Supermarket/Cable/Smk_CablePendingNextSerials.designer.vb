<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CablePendingNextSerials
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CablePendingNextSerials))
        Me.Results_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.print_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        CType(Me.Results_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Results_dgv
        '
        Me.Results_dgv.AllowColumnHiding = True
        Me.Results_dgv.AllowUserToAddRows = False
        Me.Results_dgv.AllowUserToDeleteRows = False
        Me.Results_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Results_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Results_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serialnumber, Me.Partnumber, Me.Status, Me.Local, Me.Warehouse, Me.Fullname, Me.Date_, Me.print_btn})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Results_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Results_dgv.Location = New System.Drawing.Point(12, 63)
        Me.Results_dgv.Name = "Results_dgv"
        Me.Results_dgv.ReadOnly = True
        Me.Results_dgv.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Results_dgv.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.Results_dgv.ShowRowNumber = True
        Me.Results_dgv.Size = New System.Drawing.Size(829, 425)
        Me.Results_dgv.TabIndex = 0
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 9)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(829, 43)
        Me.Title_lbl.TabIndex = 120
        Me.Title_lbl.Text = "Series Pendientes de Surtir"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(770, 8)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 121
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Serialnumber
        '
        Me.Serialnumber.DataPropertyName = "Serialnumber"
        Me.Serialnumber.HeaderText = "No. de Serie"
        Me.Serialnumber.Name = "Serialnumber"
        Me.Serialnumber.ReadOnly = True
        Me.Serialnumber.Width = 150
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle1
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 90
        '
        'Status
        '
        Me.Status.DataPropertyName = "StatusDescription"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Status.DefaultCellStyle = DataGridViewCellStyle2
        Me.Status.HeaderText = "Estatus"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 90
        '
        'Local
        '
        Me.Local.DataPropertyName = "Location"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Local.DefaultCellStyle = DataGridViewCellStyle3
        Me.Local.HeaderText = "Localizacion"
        Me.Local.Name = "Local"
        Me.Local.ReadOnly = True
        Me.Local.Width = 80
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "WarehouseName"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Warehouse.DefaultCellStyle = DataGridViewCellStyle4
        Me.Warehouse.HeaderText = "Estacion"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        Me.Warehouse.Width = 90
        '
        'Fullname
        '
        Me.Fullname.DataPropertyName = "Fullname"
        Me.Fullname.HeaderText = "Operador"
        Me.Fullname.Name = "Fullname"
        Me.Fullname.ReadOnly = True
        Me.Fullname.Width = 120
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle5
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 150
        '
        'print_btn
        '
        Me.print_btn.DefaultImage = Nothing
        Me.print_btn.DefaultText = ""
        Me.print_btn.HeaderText = ""
        Me.print_btn.Name = "print_btn"
        Me.print_btn.ReadOnly = True
        Me.print_btn.Width = 50
        '
        'Smk_CablePendingNextSerials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(850, 500)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Results_dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CablePendingNextSerials"
        Me.ShowIcon = False
        Me.Text = "Pendientes de surtir"
        CType(Me.Results_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Results_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents print_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
