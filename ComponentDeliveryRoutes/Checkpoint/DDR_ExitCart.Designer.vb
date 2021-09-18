<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_ExitCart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDR_ExitCart))
        Me.Kanbans_dgv = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kanban = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icon_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.result = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountIn_lbl = New System.Windows.Forms.Label()
        Me.Progress_pb = New System.Windows.Forms.ProgressBar()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Kanban_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Kanbans_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.kanban, Me.icon_img, Me.result, Me.status})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Kanbans_dgv.Location = New System.Drawing.Point(44, 48)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        Me.Kanbans_dgv.ReadOnly = True
        Me.Kanbans_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Kanbans_dgv.RowHeadersVisible = False
        Me.Kanbans_dgv.RowTemplate.Height = 30
        Me.Kanbans_dgv.Size = New System.Drawing.Size(320, 535)
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
        'icon_img
        '
        Me.icon_img.HeaderText = "Icon"
        Me.icon_img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.icon_img.Name = "icon_img"
        Me.icon_img.ReadOnly = True
        Me.icon_img.Width = 50
        '
        'result
        '
        Me.result.DataPropertyName = "Result"
        Me.result.HeaderText = "Result"
        Me.result.Name = "result"
        Me.result.ReadOnly = True
        Me.result.Visible = False
        '
        'status
        '
        Me.status.DataPropertyName = "Status"
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Visible = False
        '
        'CountIn_lbl
        '
        Me.CountIn_lbl.BackColor = System.Drawing.Color.Transparent
        Me.CountIn_lbl.Font = New System.Drawing.Font("DS-Digital", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountIn_lbl.ForeColor = System.Drawing.Color.White
        Me.CountIn_lbl.Location = New System.Drawing.Point(320, 586)
        Me.CountIn_lbl.Name = "CountIn_lbl"
        Me.CountIn_lbl.Size = New System.Drawing.Size(116, 23)
        Me.CountIn_lbl.TabIndex = 49
        Me.CountIn_lbl.Text = "50/100"
        Me.CountIn_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Progress_pb
        '
        Me.Progress_pb.Location = New System.Drawing.Point(95, 589)
        Me.Progress_pb.Name = "Progress_pb"
        Me.Progress_pb.Size = New System.Drawing.Size(219, 21)
        Me.Progress_pb.TabIndex = 141
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_btn.BackColor = System.Drawing.Color.White
        Me.Cancel_btn.BackgroundImage = CType(resources.GetObject("Cancel_btn.BackgroundImage"), System.Drawing.Image)
        Me.Cancel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cancel_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.Location = New System.Drawing.Point(95, 616)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(219, 84)
        Me.Cancel_btn.TabIndex = 142
        Me.Cancel_btn.Text = "SALIDA SIN ESCANEO"
        Me.Cancel_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(413, 25)
        Me.lblTitle.TabIndex = 143
        Me.lblTitle.Text = "Escaneo de Bins Surtidos"
        '
        'Kanban_txt
        '
        Me.Kanban_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanban_txt.BackColor = System.Drawing.Color.White
        Me.Kanban_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Kanban_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kanban_txt.ForeColor = System.Drawing.Color.Black
        Me.Kanban_txt.Location = New System.Drawing.Point(78, 6)
        Me.Kanban_txt.Name = "Kanban_txt"
        Me.Kanban_txt.Size = New System.Drawing.Size(252, 35)
        Me.Kanban_txt.TabIndex = 1
        Me.Kanban_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kanban_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Kanban_txt.WaterMarkText = "Escanea el bin..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Kanban_txt)
        Me.Panel1.Controls.Add(Me.Kanbans_dgv)
        Me.Panel1.Controls.Add(Me.Progress_pb)
        Me.Panel1.Controls.Add(Me.Cancel_btn)
        Me.Panel1.Controls.Add(Me.CountIn_lbl)
        Me.Panel1.Location = New System.Drawing.Point(2, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 703)
        Me.Panel1.TabIndex = 144
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Delta_ERP.My.Resources.Resources.ddr_scanning_out
        Me.PictureBox1.Location = New System.Drawing.Point(10, 617)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 148
        Me.PictureBox1.TabStop = False
        '
        'DDR_ExitCart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(413, 732)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DDR_ExitCart"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Routes Components"
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents Kanbans_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents CountIn_lbl As System.Windows.Forms.Label
    Friend WithEvents Progress_pb As System.Windows.Forms.ProgressBar
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Kanban_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kanban As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icon_img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents result As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
