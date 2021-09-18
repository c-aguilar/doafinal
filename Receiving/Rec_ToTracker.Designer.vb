<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_ToTracker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_ToTracker))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Location_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Reason_cbo = New System.Windows.Forms.ComboBox()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Delivery_txt = New System.Windows.Forms.TextBox()
        Me.Tracker_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierPartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TruckNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewSerials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.SerialNew = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remove_btn = New System.Windows.Forms.Button()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pictures_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.AddPic_btn = New System.Windows.Forms.Button()
        Me.Image_cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Delete_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Cancel_btn = New System.Windows.Forms.ToolStripButton()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Find_btn = New System.Windows.Forms.Button()
        CType(Me.Tracker_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewSerials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pictures_flp.SuspendLayout()
        Me.Image_cms.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Local:"
        '
        'OK_btn
        '
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(242, 517)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 5
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Location_txt
        '
        Me.Location_txt.BackColor = System.Drawing.Color.Ivory
        Me.Location_txt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Location_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location_txt.Location = New System.Drawing.Point(91, 312)
        Me.Location_txt.Mask = "00-00-00-00"
        Me.Location_txt.Name = "Location_txt"
        Me.Location_txt.Size = New System.Drawing.Size(109, 26)
        Me.Location_txt.TabIndex = 2
        Me.Location_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Location_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Motivo:"
        '
        'Reason_cbo
        '
        Me.Reason_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Reason_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reason_cbo.FormattingEnabled = True
        Me.Reason_cbo.Location = New System.Drawing.Point(91, 344)
        Me.Reason_cbo.Name = "Reason_cbo"
        Me.Reason_cbo.Size = New System.Drawing.Size(251, 28)
        Me.Reason_cbo.TabIndex = 3
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.Ivory
        Me.Comment_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment_txt.Location = New System.Drawing.Point(91, 378)
        Me.Comment_txt.MaxLength = 100
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(251, 101)
        Me.Comment_txt.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 381)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Comentario:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 479)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 32)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Factura" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "o Delivery:"
        '
        'Delivery_txt
        '
        Me.Delivery_txt.BackColor = System.Drawing.Color.Ivory
        Me.Delivery_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delivery_txt.Location = New System.Drawing.Point(91, 485)
        Me.Delivery_txt.MaxLength = 30
        Me.Delivery_txt.Name = "Delivery_txt"
        Me.Delivery_txt.Size = New System.Drawing.Size(251, 26)
        Me.Delivery_txt.TabIndex = 100
        '
        'Tracker_dgv
        '
        Me.Tracker_dgv.AllowColumnHiding = True
        Me.Tracker_dgv.AllowUserToAddRows = False
        Me.Tracker_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Tracker_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Tracker_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tracker_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Tracker_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tracker_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serial, Me.Partnumber, Me.SupplierPartnumber, Me.UoM, Me.TruckNumber, Me.Date_})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tracker_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tracker_dgv.DefaultRowFilter = Nothing
        Me.Tracker_dgv.EnableHeadersVisualStyles = False
        Me.Tracker_dgv.Location = New System.Drawing.Point(8, 53)
        Me.Tracker_dgv.Name = "Tracker_dgv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tracker_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Tracker_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Tracker_dgv.ShowRowNumber = True
        Me.Tracker_dgv.Size = New System.Drawing.Size(594, 248)
        Me.Tracker_dgv.TabIndex = 110
        '
        'Serial
        '
        Me.Serial.DataPropertyName = "Serialnumber"
        Me.Serial.HeaderText = "Serie"
        Me.Serial.Name = "Serial"
        Me.Serial.ReadOnly = True
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 90
        '
        'SupplierPartnumber
        '
        Me.SupplierPartnumber.DataPropertyName = "OriginalQuantity"
        Me.SupplierPartnumber.HeaderText = "Cantidad"
        Me.SupplierPartnumber.Name = "SupplierPartnumber"
        Me.SupplierPartnumber.ReadOnly = True
        Me.SupplierPartnumber.Width = 70
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.ReadOnly = True
        Me.UoM.Width = 60
        '
        'TruckNumber
        '
        Me.TruckNumber.DataPropertyName = "TruckNumber"
        Me.TruckNumber.HeaderText = "Troca"
        Me.TruckNumber.Name = "TruckNumber"
        Me.TruckNumber.ReadOnly = True
        Me.TruckNumber.Width = 120
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        Me.Date_.HeaderText = "Fecha de Etiquetado"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 110
        '
        'NewSerials_dgv
        '
        Me.NewSerials_dgv.AllowColumnHiding = True
        Me.NewSerials_dgv.AllowUserToAddRows = False
        Me.NewSerials_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray
        Me.NewSerials_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.NewSerials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewSerials_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewSerials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.NewSerials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NewSerials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNew, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NewSerials_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.NewSerials_dgv.DefaultRowFilter = Nothing
        Me.NewSerials_dgv.EnableHeadersVisualStyles = False
        Me.NewSerials_dgv.Location = New System.Drawing.Point(656, 53)
        Me.NewSerials_dgv.Name = "NewSerials_dgv"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewSerials_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.NewSerials_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.NewSerials_dgv.ShowRowNumber = True
        Me.NewSerials_dgv.Size = New System.Drawing.Size(516, 696)
        Me.NewSerials_dgv.TabIndex = 111
        '
        'SerialNew
        '
        Me.SerialNew.DataPropertyName = "Serialnumber"
        Me.SerialNew.HeaderText = "Serie"
        Me.SerialNew.Name = "SerialNew"
        Me.SerialNew.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Partnumber"
        Me.DataGridViewTextBoxColumn2.HeaderText = "No. de Parte"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "OriginalQuantity"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "UoM"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "TruckNumber"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Troca"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Date"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fecha de Etiquetado"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 110
        '
        'Remove_btn
        '
        Me.Remove_btn.Image = CType(resources.GetObject("Remove_btn.Image"), System.Drawing.Image)
        Me.Remove_btn.Location = New System.Drawing.Point(608, 121)
        Me.Remove_btn.Name = "Remove_btn"
        Me.Remove_btn.Size = New System.Drawing.Size(42, 29)
        Me.Remove_btn.TabIndex = 112
        Me.Remove_btn.UseVisualStyleBackColor = True
        '
        'Add_btn
        '
        Me.Add_btn.Image = CType(resources.GetObject("Add_btn.Image"), System.Drawing.Image)
        Me.Add_btn.Location = New System.Drawing.Point(608, 86)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(42, 29)
        Me.Add_btn.TabIndex = 113
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 16)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Series seleccionadas:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(653, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 16)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Series en Rampas:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 170)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 116
        Me.PictureBox1.TabStop = False
        '
        'Pictures_flp
        '
        Me.Pictures_flp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pictures_flp.AutoScroll = True
        Me.Pictures_flp.Controls.Add(Me.PictureBox1)
        Me.Pictures_flp.Location = New System.Drawing.Point(348, 338)
        Me.Pictures_flp.Name = "Pictures_flp"
        Me.Pictures_flp.Size = New System.Drawing.Size(281, 411)
        Me.Pictures_flp.TabIndex = 117
        '
        'AddPic_btn
        '
        Me.AddPic_btn.Image = CType(resources.GetObject("AddPic_btn.Image"), System.Drawing.Image)
        Me.AddPic_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddPic_btn.Location = New System.Drawing.Point(474, 307)
        Me.AddPic_btn.Name = "AddPic_btn"
        Me.AddPic_btn.Size = New System.Drawing.Size(128, 25)
        Me.AddPic_btn.TabIndex = 118
        Me.AddPic_btn.Text = "Importar imagenes..."
        Me.AddPic_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddPic_btn.UseVisualStyleBackColor = True
        '
        'Image_cms
        '
        Me.Image_cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Delete_cmsi})
        Me.Image_cms.Name = "Image_cms"
        Me.Image_cms.Size = New System.Drawing.Size(118, 26)
        '
        'Delete_cmsi
        '
        Me.Delete_cmsi.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Delete_cmsi.Name = "Delete_cmsi"
        Me.Delete_cmsi.Size = New System.Drawing.Size(117, 22)
        Me.Delete_cmsi.Text = "Eliminar"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cancel_btn, Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1184, 29)
        Me.ToolStripMain.TabIndex = 121
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(23, 26)
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "ToolStripButton1"
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
        Me.Title_lbl.Size = New System.Drawing.Size(246, 26)
        Me.Title_lbl.Text = "Enviar a Tracker de Problemas"
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.Location = New System.Drawing.Point(608, 156)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(42, 29)
        Me.Find_btn.TabIndex = 122
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Rec_ToTracker
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.AddPic_btn)
        Me.Controls.Add(Me.Pictures_flp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Remove_btn)
        Me.Controls.Add(Me.NewSerials_dgv)
        Me.Controls.Add(Me.Tracker_dgv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Delivery_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Reason_cbo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Location_txt)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Rec_ToTracker"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receiving"
        CType(Me.Tracker_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewSerials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pictures_flp.ResumeLayout(False)
        Me.Image_cms.ResumeLayout(False)
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Location_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Reason_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Delivery_txt As System.Windows.Forms.TextBox
    Friend WithEvents Tracker_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents NewSerials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Remove_btn As System.Windows.Forms.Button
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Pictures_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents AddPic_btn As System.Windows.Forms.Button
    Friend WithEvents Image_cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Delete_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierPartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TruckNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNew As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel_btn As System.Windows.Forms.ToolStripButton
End Class
