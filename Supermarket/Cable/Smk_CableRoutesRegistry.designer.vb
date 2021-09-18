<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableRoutesRegistry
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableRoutesRegistry))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRoutes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Badge_txt = New CAguilar.WaterMarkTextBox()
        Me.Registry_dgv = New System.Windows.Forms.DataGridView()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delete_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Close_btn = New System.Windows.Forms.Button()
        CType(Me.Registry_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(101, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta:"
        '
        'cboRoutes
        '
        Me.cboRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoutes.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoutes.FormattingEnabled = True
        Me.cboRoutes.Location = New System.Drawing.Point(155, 57)
        Me.cboRoutes.Name = "cboRoutes"
        Me.cboRoutes.Size = New System.Drawing.Size(329, 37)
        Me.cboRoutes.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(69, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Operador:"
        '
        'Badge_txt
        '
        Me.Badge_txt.BackColor = System.Drawing.Color.Ivory
        Me.Badge_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Badge_txt.Location = New System.Drawing.Point(155, 98)
        Me.Badge_txt.Name = "Badge_txt"
        Me.Badge_txt.Size = New System.Drawing.Size(329, 40)
        Me.Badge_txt.TabIndex = 27
        Me.Badge_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Badge_txt.WaterMarkText = "Escanea tu gafete..."
        '
        'Registry_dgv
        '
        Me.Registry_dgv.AllowUserToAddRows = False
        Me.Registry_dgv.AllowUserToDeleteRows = False
        Me.Registry_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Registry_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.RouteName, Me.OperatorName, Me.Date_, Me.delete_btn})
        Me.Registry_dgv.Location = New System.Drawing.Point(12, 149)
        Me.Registry_dgv.Name = "Registry_dgv"
        Me.Registry_dgv.ReadOnly = True
        Me.Registry_dgv.Size = New System.Drawing.Size(610, 205)
        Me.Registry_dgv.TabIndex = 32
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 6)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(610, 43)
        Me.Title_lbl.TabIndex = 118
        Me.Title_lbl.Text = "Registro en Rutas"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'RouteName
        '
        Me.RouteName.DataPropertyName = "Name"
        Me.RouteName.HeaderText = "Ruta"
        Me.RouteName.Name = "RouteName"
        Me.RouteName.ReadOnly = True
        Me.RouteName.Width = 150
        '
        'OperatorName
        '
        Me.OperatorName.DataPropertyName = "Fullname"
        Me.OperatorName.HeaderText = "Operador"
        Me.OperatorName.Name = "OperatorName"
        Me.OperatorName.ReadOnly = True
        Me.OperatorName.Width = 200
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle1.Format = "g"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle1
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 120
        '
        'delete_btn
        '
        Me.delete_btn.DefaultImage = Nothing
        Me.delete_btn.DefaultText = ""
        Me.delete_btn.HeaderText = ""
        Me.delete_btn.Name = "delete_btn"
        Me.delete_btn.ReadOnly = True
        Me.delete_btn.Width = 50
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(551, 5)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 119
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Smk_CableRoutesRegistry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(634, 362)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Registry_dgv)
        Me.Controls.Add(Me.Badge_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboRoutes)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableRoutesRegistry"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Registry_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRoutes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Badge_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Registry_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delete_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents Close_btn As System.Windows.Forms.Button
End Class
