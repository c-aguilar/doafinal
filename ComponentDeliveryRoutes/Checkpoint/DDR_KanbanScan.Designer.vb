<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_KanbanScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDR_KanbanScan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Kanbans_dgv = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kanban = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icon_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Kanban_txt = New CAguilar.WaterMarkTextBox()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Kanban_pnl = New System.Windows.Forms.Panel()
        Me.Label = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Uom_lbl = New System.Windows.Forms.Label()
        Me.Container_lbl = New System.Windows.Forms.Label()
        Me.Quantity_lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Count_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Unknow_lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Percent_lbl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Print_btn = New System.Windows.Forms.Button()
        Me.Cart_lbl = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Kanban_pnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(900, 25)
        Me.lblTitle.TabIndex = 35
        Me.lblTitle.Text = "Escaneo de Bins Vacios"
        '
        'Kanbans_dgv
        '
        Me.Kanbans_dgv.AllowUserToAddRows = False
        Me.Kanbans_dgv.AllowUserToDeleteRows = False
        Me.Kanbans_dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Kanbans_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Kanbans_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Kanbans_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Kanbans_dgv.ColumnHeadersVisible = False
        Me.Kanbans_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.kanban, Me.result, Me.icon_img})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Kanbans_dgv.Location = New System.Drawing.Point(579, 103)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        Me.Kanbans_dgv.ReadOnly = True
        Me.Kanbans_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Kanbans_dgv.RowHeadersVisible = False
        Me.Kanbans_dgv.RowTemplate.Height = 30
        Me.Kanbans_dgv.Size = New System.Drawing.Size(312, 502)
        Me.Kanbans_dgv.TabIndex = 39
        '
        'ID
        '
        Me.ID.DataPropertyName = "DeltaID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'kanban
        '
        Me.kanban.DataPropertyName = "KanbanID"
        Me.kanban.HeaderText = "Kanban"
        Me.kanban.Name = "kanban"
        Me.kanban.ReadOnly = True
        Me.kanban.Width = 250
        '
        'result
        '
        Me.result.DataPropertyName = "Result"
        Me.result.HeaderText = "Result"
        Me.result.Name = "result"
        Me.result.ReadOnly = True
        Me.result.Visible = False
        '
        'icon_img
        '
        Me.icon_img.HeaderText = "Icon"
        Me.icon_img.Name = "icon_img"
        Me.icon_img.ReadOnly = True
        Me.icon_img.Width = 50
        '
        'Kanban_txt
        '
        Me.Kanban_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanban_txt.BackColor = System.Drawing.Color.White
        Me.Kanban_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Kanban_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kanban_txt.ForeColor = System.Drawing.Color.Black
        Me.Kanban_txt.Location = New System.Drawing.Point(328, 10)
        Me.Kanban_txt.Name = "Kanban_txt"
        Me.Kanban_txt.Size = New System.Drawing.Size(241, 35)
        Me.Kanban_txt.TabIndex = 1
        Me.Kanban_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kanban_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Kanban_txt.WaterMarkText = "Escanea el bin..."
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.BackColor = System.Drawing.Color.White
        Me.Close_btn.BackgroundImage = CType(resources.GetObject("Close_btn.BackgroundImage"), System.Drawing.Image)
        Me.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Close_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.Location = New System.Drawing.Point(337, 520)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(238, 85)
        Me.Close_btn.TabIndex = 40
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Kanban_pnl
        '
        Me.Kanban_pnl.BackColor = System.Drawing.Color.White
        Me.Kanban_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Kanban_pnl.Controls.Add(Me.Label)
        Me.Kanban_pnl.Controls.Add(Me.Label17)
        Me.Kanban_pnl.Controls.Add(Me.Label16)
        Me.Kanban_pnl.Controls.Add(Me.Description_lbl)
        Me.Kanban_pnl.Controls.Add(Me.Partnumber_lbl)
        Me.Kanban_pnl.Controls.Add(Me.Uom_lbl)
        Me.Kanban_pnl.Controls.Add(Me.Container_lbl)
        Me.Kanban_pnl.Controls.Add(Me.Quantity_lbl)
        Me.Kanban_pnl.Location = New System.Drawing.Point(17, 103)
        Me.Kanban_pnl.Name = "Kanban_pnl"
        Me.Kanban_pnl.Size = New System.Drawing.Size(558, 307)
        Me.Kanban_pnl.TabIndex = 41
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.Transparent
        Me.Label.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.Color.DimGray
        Me.Label.Location = New System.Drawing.Point(58, 194)
        Me.Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(100, 37)
        Me.Label.TabIndex = 142
        Me.Label.Text = "Unidad:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(11, 256)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 37)
        Me.Label17.TabIndex = 136
        Me.Label17.Text = "Contenedor:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(38, 131)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 37)
        Me.Label16.TabIndex = 135
        Me.Label16.Text = "Cantidad:"
        '
        'Description_lbl
        '
        Me.Description_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Description_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.ForeColor = System.Drawing.Color.Maroon
        Me.Description_lbl.Location = New System.Drawing.Point(10, 89)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(536, 38)
        Me.Description_lbl.TabIndex = 138
        Me.Description_lbl.Text = "TERM  F 2.0 MATE-N-LOK SN  LOCKING LANCE"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.BackColor = System.Drawing.Color.SteelBlue
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Franklin Gothic Demi Cond", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.ForeColor = System.Drawing.Color.White
        Me.Partnumber_lbl.Location = New System.Drawing.Point(8, 8)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(542, 78)
        Me.Partnumber_lbl.TabIndex = 137
        Me.Partnumber_lbl.Text = "M3096201"
        '
        'Uom_lbl
        '
        Me.Uom_lbl.AutoSize = True
        Me.Uom_lbl.Font = New System.Drawing.Font("Franklin Gothic Demi Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uom_lbl.ForeColor = System.Drawing.Color.Black
        Me.Uom_lbl.Location = New System.Drawing.Point(153, 181)
        Me.Uom_lbl.Name = "Uom_lbl"
        Me.Uom_lbl.Size = New System.Drawing.Size(78, 61)
        Me.Uom_lbl.TabIndex = 143
        Me.Uom_lbl.Text = "PC"
        '
        'Container_lbl
        '
        Me.Container_lbl.AutoSize = True
        Me.Container_lbl.Font = New System.Drawing.Font("Franklin Gothic Demi Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Container_lbl.ForeColor = System.Drawing.Color.Black
        Me.Container_lbl.Location = New System.Drawing.Point(153, 241)
        Me.Container_lbl.Name = "Container_lbl"
        Me.Container_lbl.Size = New System.Drawing.Size(77, 61)
        Me.Container_lbl.TabIndex = 141
        Me.Container_lbl.Text = "4S"
        '
        'Quantity_lbl
        '
        Me.Quantity_lbl.AutoSize = True
        Me.Quantity_lbl.Font = New System.Drawing.Font("Franklin Gothic Demi Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity_lbl.ForeColor = System.Drawing.Color.Black
        Me.Quantity_lbl.Location = New System.Drawing.Point(153, 120)
        Me.Quantity_lbl.Name = "Quantity_lbl"
        Me.Quantity_lbl.Size = New System.Drawing.Size(202, 61)
        Me.Quantity_lbl.TabIndex = 140
        Me.Quantity_lbl.Text = "9999999"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Count_lbl)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(393, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(182, 100)
        Me.Panel1.TabIndex = 48
        '
        'Count_lbl
        '
        Me.Count_lbl.Font = New System.Drawing.Font("DS-Digital", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Count_lbl.Location = New System.Drawing.Point(3, 5)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(170, 55)
        Me.Count_lbl.TabIndex = 49
        Me.Count_lbl.Text = "0"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 28)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "CONTEO TOTAL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Unknow_lbl)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(205, 416)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(182, 100)
        Me.Panel2.TabIndex = 49
        '
        'Unknow_lbl
        '
        Me.Unknow_lbl.Font = New System.Drawing.Font("DS-Digital", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unknow_lbl.Location = New System.Drawing.Point(3, 5)
        Me.Unknow_lbl.Name = "Unknow_lbl"
        Me.Unknow_lbl.Size = New System.Drawing.Size(170, 55)
        Me.Unknow_lbl.TabIndex = 49
        Me.Unknow_lbl.Text = "0"
        Me.Unknow_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 28)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "DESCONOCIDAS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Percent_lbl)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(17, 416)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(182, 100)
        Me.Panel3.TabIndex = 50
        Me.Panel3.Visible = False
        '
        'Percent_lbl
        '
        Me.Percent_lbl.Font = New System.Drawing.Font("DS-Digital", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Percent_lbl.Location = New System.Drawing.Point(5, 5)
        Me.Percent_lbl.Name = "Percent_lbl"
        Me.Percent_lbl.Size = New System.Drawing.Size(170, 55)
        Me.Percent_lbl.TabIndex = 46
        Me.Percent_lbl.Text = "0%"
        Me.Percent_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 28)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "PORCENTAJE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Print_btn
        '
        Me.Print_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Print_btn.BackColor = System.Drawing.Color.White
        Me.Print_btn.BackgroundImage = CType(resources.GetObject("Print_btn.BackgroundImage"), System.Drawing.Image)
        Me.Print_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Print_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Print_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Print_btn.Location = New System.Drawing.Point(17, 520)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(231, 85)
        Me.Print_btn.TabIndex = 51
        Me.Print_btn.Text = "IMPRIMIR"
        Me.Print_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Print_btn.UseVisualStyleBackColor = False
        '
        'Cart_lbl
        '
        Me.Cart_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cart_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cart_lbl.ForeColor = System.Drawing.Color.White
        Me.Cart_lbl.Location = New System.Drawing.Point(17, 43)
        Me.Cart_lbl.Name = "Cart_lbl"
        Me.Cart_lbl.Size = New System.Drawing.Size(305, 55)
        Me.Cart_lbl.TabIndex = 139
        Me.Cart_lbl.Text = "Carro 1"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.Kanban_txt)
        Me.Panel5.Controls.Add(Me.Cart_lbl)
        Me.Panel5.Controls.Add(Me.Kanbans_dgv)
        Me.Panel5.Controls.Add(Me.Close_btn)
        Me.Panel5.Controls.Add(Me.Print_btn)
        Me.Panel5.Controls.Add(Me.Kanban_pnl)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Controls.Add(Me.Panel1)
        Me.Panel5.Controls.Add(Me.Panel2)
        Me.Panel5.Location = New System.Drawing.Point(2, 27)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(896, 610)
        Me.Panel5.TabIndex = 141
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Delta_ERP.My.Resources.Resources.ddr_scanning_in
        Me.PictureBox1.Location = New System.Drawing.Point(811, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 149
        Me.PictureBox1.TabStop = False
        '
        'DDR_KanbanScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(900, 639)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DDR_KanbanScan"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Routes Components"
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Kanban_pnl.ResumeLayout(False)
        Me.Kanban_pnl.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Kanbans_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Kanban_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Kanban_pnl As System.Windows.Forms.Panel
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Uom_lbl As System.Windows.Forms.Label
    Friend WithEvents Container_lbl As System.Windows.Forms.Label
    Friend WithEvents Quantity_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Percent_lbl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Count_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Unknow_lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Print_btn As System.Windows.Forms.Button
    Friend WithEvents Cart_lbl As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kanban As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icon_img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
