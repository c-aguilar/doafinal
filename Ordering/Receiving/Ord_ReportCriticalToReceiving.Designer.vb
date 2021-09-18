<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ReportCriticalToReceiving
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
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Actives_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transporter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delivery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cancel_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Area_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Plates_txt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Delivery_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Transporter_txt = New System.Windows.Forms.TextBox()
        Me.QuantityStop_chk = New System.Windows.Forms.CheckBox()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.UoM_lbl = New System.Windows.Forms.Label()
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(91, 31)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 21)
        Me.Partnumber_txt.TabIndex = 1
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "No. de Parte:"
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.Ivory
        Me.Comment_txt.Location = New System.Drawing.Point(91, 110)
        Me.Comment_txt.MaxLength = 150
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(419, 38)
        Me.Comment_txt.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Comentario:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1014, 25)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Reportar Numero de Parte Critico"
        '
        'Actives_dgv
        '
        Me.Actives_dgv.AllowColumnHiding = True
        Me.Actives_dgv.AllowUserToAddRows = False
        Me.Actives_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Actives_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Actives_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Actives_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Actives_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Actives_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Partnumber, Me.Area, Me.Plates, Me.Transporter, Me.Delivery, Me.Comment, Me.Quantity, Me.Date_, Me.Fullname, Me.Username, Me.cancel_btn})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Actives_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Actives_dgv.DefaultRowFilter = Nothing
        Me.Actives_dgv.EnableHeadersVisualStyles = False
        Me.Actives_dgv.Location = New System.Drawing.Point(4, 154)
        Me.Actives_dgv.Name = "Actives_dgv"
        Me.Actives_dgv.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Actives_dgv.ShowRowNumber = True
        Me.Actives_dgv.Size = New System.Drawing.Size(1006, 378)
        Me.Actives_dgv.TabIndex = 8
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 80
        '
        'Area
        '
        Me.Area.DataPropertyName = "Area"
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        Me.Area.Width = 110
        '
        'Plates
        '
        Me.Plates.DataPropertyName = "Plates"
        Me.Plates.HeaderText = "Placas/Troca"
        Me.Plates.Name = "Plates"
        Me.Plates.ReadOnly = True
        Me.Plates.Width = 90
        '
        'Transporter
        '
        Me.Transporter.DataPropertyName = "Transporter"
        Me.Transporter.HeaderText = "Transportista"
        Me.Transporter.Name = "Transporter"
        Me.Transporter.ReadOnly = True
        Me.Transporter.Width = 90
        '
        'Delivery
        '
        Me.Delivery.DataPropertyName = "Delivery"
        Me.Delivery.HeaderText = "Delivery"
        Me.Delivery.Name = "Delivery"
        Me.Delivery.ReadOnly = True
        Me.Delivery.Width = 90
        '
        'Comment
        '
        Me.Comment.DataPropertyName = "Comment"
        Me.Comment.HeaderText = "Comentario"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        Me.Comment.Width = 150
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.Quantity.HeaderText = "Cantidad"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle5
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 90
        '
        'Fullname
        '
        Me.Fullname.DataPropertyName = "Fullname"
        Me.Fullname.HeaderText = "Reportado por"
        Me.Fullname.Name = "Fullname"
        Me.Fullname.ReadOnly = True
        '
        'Username
        '
        Me.Username.DataPropertyName = "Username"
        Me.Username.HeaderText = "Username"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        Me.Username.Visible = False
        '
        'cancel_btn
        '
        Me.cancel_btn.DefaultImage = Nothing
        Me.cancel_btn.DefaultText = ""
        Me.cancel_btn.HeaderText = ""
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.ReadOnly = True
        Me.cancel_btn.Width = 40
        '
        'Add_btn
        '
        Me.Add_btn.Image = Global.Delta_ERP.My.Resources.Resources.add_16
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(516, 123)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(100, 25)
        Me.Add_btn.TabIndex = 7
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Area_txt
        '
        Me.Area_txt.BackColor = System.Drawing.Color.Ivory
        Me.Area_txt.Location = New System.Drawing.Point(342, 83)
        Me.Area_txt.MaxLength = 20
        Me.Area_txt.Name = "Area_txt"
        Me.Area_txt.Size = New System.Drawing.Size(168, 20)
        Me.Area_txt.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(304, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Area:"
        '
        'Plates_txt
        '
        Me.Plates_txt.BackColor = System.Drawing.Color.Ivory
        Me.Plates_txt.Location = New System.Drawing.Point(91, 58)
        Me.Plates_txt.MaxLength = 20
        Me.Plates_txt.Name = "Plates_txt"
        Me.Plates_txt.Size = New System.Drawing.Size(168, 20)
        Me.Plates_txt.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Placas/Troca:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Delivery:"
        '
        'Delivery_txt
        '
        Me.Delivery_txt.BackColor = System.Drawing.Color.Ivory
        Me.Delivery_txt.Location = New System.Drawing.Point(91, 84)
        Me.Delivery_txt.MaxLength = 20
        Me.Delivery_txt.Name = "Delivery_txt"
        Me.Delivery_txt.Size = New System.Drawing.Size(168, 20)
        Me.Delivery_txt.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Transportista:"
        '
        'Transporter_txt
        '
        Me.Transporter_txt.BackColor = System.Drawing.Color.Ivory
        Me.Transporter_txt.Location = New System.Drawing.Point(342, 58)
        Me.Transporter_txt.MaxLength = 20
        Me.Transporter_txt.Name = "Transporter_txt"
        Me.Transporter_txt.Size = New System.Drawing.Size(168, 20)
        Me.Transporter_txt.TabIndex = 3
        '
        'QuantityStop_chk
        '
        Me.QuantityStop_chk.AutoSize = True
        Me.QuantityStop_chk.Location = New System.Drawing.Point(268, 35)
        Me.QuantityStop_chk.Name = "QuantityStop_chk"
        Me.QuantityStop_chk.Size = New System.Drawing.Size(118, 17)
        Me.QuantityStop_chk.TabIndex = 108
        Me.QuantityStop_chk.Text = "Critico hasta recibir:"
        Me.QuantityStop_chk.UseVisualStyleBackColor = True
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.DecimalPlaces = 3
        Me.Quantity_nud.Enabled = False
        Me.Quantity_nud.Location = New System.Drawing.Point(388, 34)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(94, 20)
        Me.Quantity_nud.TabIndex = 109
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UoM_lbl
        '
        Me.UoM_lbl.AutoSize = True
        Me.UoM_lbl.Location = New System.Drawing.Point(488, 37)
        Me.UoM_lbl.Name = "UoM_lbl"
        Me.UoM_lbl.Size = New System.Drawing.Size(22, 13)
        Me.UoM_lbl.TabIndex = 110
        Me.UoM_lbl.Text = "     "
        '
        'Ord_ReportCriticalToReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 536)
        Me.Controls.Add(Me.UoM_lbl)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.QuantityStop_chk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Transporter_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Delivery_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Plates_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Area_txt)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Actives_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Name = "Ord_ReportCriticalToReceiving"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Actives_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Area_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Plates_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Delivery_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Transporter_txt As System.Windows.Forms.TextBox
    Friend WithEvents QuantityStop_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents UoM_lbl As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plates As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transporter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cancel_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
