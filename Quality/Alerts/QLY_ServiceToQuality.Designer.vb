<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QLY_ServiceToQuality
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QLY_ServiceToQuality))
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
        Me.Alert_btn = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TruckNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alert = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.Label7.Text = "Alertar Series en Supermercado"
        '
        'Alert_btn
        '
        Me.Alert_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Alert_btn.Image = CType(resources.GetObject("Alert_btn.Image"), System.Drawing.Image)
        Me.Alert_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Alert_btn.Location = New System.Drawing.Point(643, 29)
        Me.Alert_btn.Name = "Alert_btn"
        Me.Alert_btn.Size = New System.Drawing.Size(100, 25)
        Me.Alert_btn.TabIndex = 95
        Me.Alert_btn.Text = "Alertar"
        Me.Alert_btn.UseVisualStyleBackColor = True
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(84, 28)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(156, 24)
        Me.Partnumber_txt.TabIndex = 94
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(246, 28)
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
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serialnumber, Me.Partnumber, Me.Quantity, Me.UoM, Me.Warehouse, Me.TruckNumber, Me.Date_, Me.Alert})
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
        Me.Serials_dgv.Location = New System.Drawing.Point(7, 59)
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
        Me.Serials_dgv.Size = New System.Drawing.Size(866, 413)
        Me.Serials_dgv.TabIndex = 99
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(749, 34)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 103
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "No. de Parte:"
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
        Me.Quantity.DataPropertyName = "CurrentQuantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.Quantity.HeaderText = "Cantidad Actual"
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
        Me.Date_.HeaderText = "Fecha de Llegada"
        Me.Date_.Name = "Date_"
        '
        'Alert
        '
        Me.Alert.DataPropertyName = "Alert"
        Me.Alert.HeaderText = "Alertar"
        Me.Alert.Name = "Alert"
        Me.Alert.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Alert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Alert.Width = 60
        '
        'QLY_ServiceToQuality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 480)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Alert_btn)
        Me.Controls.Add(Me.Label7)
        Me.Name = "QLY_ServiceToQuality"
        Me.ShowIcon = False
        Me.Text = "Quality"
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Alert_btn As System.Windows.Forms.Button
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TruckNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alert As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
