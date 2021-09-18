<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_ReprintLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_ReprintLabel))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Print_btn = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Serialnumber_rb = New System.Windows.Forms.RadioButton()
        Me.DateRange_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Range2_txt = New System.Windows.Forms.TextBox()
        Me.Range_rb = New System.Windows.Forms.RadioButton()
        Me.RangeA_txt = New System.Windows.Forms.TextBox()
        Me.Items_btn = New System.Windows.Forms.Button()
        Me.Serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TruckNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Print = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label7.Size = New System.Drawing.Size(880, 25)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Reimprimir Etiqueta"
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(17, 51)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(154, 24)
        Me.Serial_txt.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(416, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Desde:"
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.From_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.From_dtp.Location = New System.Drawing.Point(463, 50)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(125, 21)
        Me.From_dtp.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(416, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Hasta:"
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.To_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.To_dtp.Location = New System.Drawing.Point(463, 72)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(125, 21)
        Me.To_dtp.TabIndex = 90
        '
        'Print_btn
        '
        Me.Print_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Print_btn.Image = CType(resources.GetObject("Print_btn.Image"), System.Drawing.Image)
        Me.Print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Print_btn.Location = New System.Drawing.Point(644, 87)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(100, 25)
        Me.Print_btn.TabIndex = 95
        Me.Print_btn.Text = "Imprimir"
        Me.Print_btn.UseVisualStyleBackColor = True
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(612, 50)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(156, 24)
        Me.Partnumber_txt.TabIndex = 94
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(774, 50)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(100, 25)
        Me.Find_btn.TabIndex = 96
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowColumnHiding = True
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Serials_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Serials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serials_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Serials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serialnumber, Me.Partnumber, Me.Quantity, Me.UoM, Me.Warehouse, Me.Location_, Me.TruckNumber, Me.Date_, Me.Print})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Serials_dgv.DefaultCellStyle = DataGridViewCellStyle10
        Me.Serials_dgv.DefaultRowFilter = Nothing
        Me.Serials_dgv.EnableHeadersVisualStyles = False
        Me.Serials_dgv.Location = New System.Drawing.Point(7, 115)
        Me.Serials_dgv.Name = "Serials_dgv"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serials_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Serials_dgv.ShowRowNumber = True
        Me.Serials_dgv.Size = New System.Drawing.Size(866, 357)
        Me.Serials_dgv.TabIndex = 99
        '
        'Serialnumber_rb
        '
        Me.Serialnumber_rb.AutoSize = True
        Me.Serialnumber_rb.Checked = True
        Me.Serialnumber_rb.Location = New System.Drawing.Point(17, 28)
        Me.Serialnumber_rb.Name = "Serialnumber_rb"
        Me.Serialnumber_rb.Size = New System.Drawing.Size(154, 17)
        Me.Serialnumber_rb.TabIndex = 100
        Me.Serialnumber_rb.TabStop = True
        Me.Serialnumber_rb.Text = "Buscar por numero de serie"
        Me.Serialnumber_rb.UseVisualStyleBackColor = True
        '
        'DateRange_rb
        '
        Me.DateRange_rb.AutoSize = True
        Me.DateRange_rb.Location = New System.Drawing.Point(419, 27)
        Me.DateRange_rb.Name = "DateRange_rb"
        Me.DateRange_rb.Size = New System.Drawing.Size(156, 17)
        Me.DateRange_rb.TabIndex = 101
        Me.DateRange_rb.Text = "Buscar por rango de fechas"
        Me.DateRange_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Location = New System.Drawing.Point(612, 27)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(156, 17)
        Me.Partnumber_rb.TabIndex = 102
        Me.Partnumber_rb.Text = "Buscar por numero de parte"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(750, 92)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 103
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Range2_txt
        '
        Me.Range2_txt.BackColor = System.Drawing.Color.Ivory
        Me.Range2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Range2_txt.Location = New System.Drawing.Point(319, 51)
        Me.Range2_txt.MaxLength = 10
        Me.Range2_txt.Name = "Range2_txt"
        Me.Range2_txt.Size = New System.Drawing.Size(86, 24)
        Me.Range2_txt.TabIndex = 109
        '
        'Range_rb
        '
        Me.Range_rb.AutoSize = True
        Me.Range_rb.Location = New System.Drawing.Point(227, 28)
        Me.Range_rb.Name = "Range_rb"
        Me.Range_rb.Size = New System.Drawing.Size(106, 17)
        Me.Range_rb.TabIndex = 108
        Me.Range_rb.Text = "Buscar por rango"
        Me.Range_rb.UseVisualStyleBackColor = True
        '
        'RangeA_txt
        '
        Me.RangeA_txt.BackColor = System.Drawing.Color.Ivory
        Me.RangeA_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeA_txt.Location = New System.Drawing.Point(227, 51)
        Me.RangeA_txt.MaxLength = 10
        Me.RangeA_txt.Name = "RangeA_txt"
        Me.RangeA_txt.Size = New System.Drawing.Size(86, 24)
        Me.RangeA_txt.TabIndex = 107
        '
        'Items_btn
        '
        Me.Items_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Items_btn.Image = CType(resources.GetObject("Items_btn.Image"), System.Drawing.Image)
        Me.Items_btn.Location = New System.Drawing.Point(172, 51)
        Me.Items_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Items_btn.Name = "Items_btn"
        Me.Items_btn.Size = New System.Drawing.Size(23, 23)
        Me.Items_btn.TabIndex = 110
        Me.Items_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Items_btn.UseVisualStyleBackColor = False
        '
        'Serialnumber
        '
        Me.Serialnumber.DataPropertyName = "Serialnumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Serialnumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.Serialnumber.HeaderText = "Serie"
        Me.Serialnumber.Name = "Serialnumber"
        Me.Serialnumber.Width = 110
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.Width = 90
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "OriginalQuantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.Quantity.HeaderText = "Cantidad"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 70
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.UoM.DefaultCellStyle = DataGridViewCellStyle6
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.Width = 50
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "WarehouseName"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Warehouse.DefaultCellStyle = DataGridViewCellStyle7
        Me.Warehouse.HeaderText = "Estacion"
        Me.Warehouse.Name = "Warehouse"
        '
        'Location_
        '
        Me.Location_.DataPropertyName = "Location"
        Me.Location_.HeaderText = "Localizacion"
        Me.Location_.Name = "Location_"
        Me.Location_.ReadOnly = True
        '
        'TruckNumber
        '
        Me.TruckNumber.DataPropertyName = "TruckNumber"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.TruckNumber.DefaultCellStyle = DataGridViewCellStyle8
        Me.TruckNumber.HeaderText = "No. de Troca"
        Me.TruckNumber.Name = "TruckNumber"
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle9.Format = "g"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle9
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        '
        'Print
        '
        Me.Print.DataPropertyName = "Print"
        Me.Print.HeaderText = "Imprimir"
        Me.Print.Name = "Print"
        Me.Print.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Print.Width = 60
        '
        'Rec_ReprintLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 480)
        Me.Controls.Add(Me.Items_btn)
        Me.Controls.Add(Me.Range2_txt)
        Me.Controls.Add(Me.Range_rb)
        Me.Controls.Add(Me.RangeA_txt)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Partnumber_rb)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.DateRange_rb)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.Serialnumber_rb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Print_btn)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Rec_ReprintLabel"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Print_btn As System.Windows.Forms.Button
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Serialnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents DateRange_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Range2_txt As System.Windows.Forms.TextBox
    Friend WithEvents Range_rb As System.Windows.Forms.RadioButton
    Friend WithEvents RangeA_txt As System.Windows.Forms.TextBox
    Friend WithEvents Items_btn As System.Windows.Forms.Button
    Friend WithEvents Serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TruckNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Print As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
