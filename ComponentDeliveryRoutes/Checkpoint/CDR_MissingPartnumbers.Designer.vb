<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_MissingPartnumbers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_MissingPartnumbers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Kanban_txt = New CAguilar.WaterMarkTextBox()
        Me.Kanbans_dgv = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kanban = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icon_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Count_lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Route_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Close_btn.Location = New System.Drawing.Point(9, 452)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(238, 93)
        Me.Close_btn.TabIndex = 3
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(407, 25)
        Me.lblTitle.TabIndex = 34
        Me.lblTitle.Text = "Material Faltante"
        '
        'Kanban_txt
        '
        Me.Kanban_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanban_txt.BackColor = System.Drawing.Color.White
        Me.Kanban_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kanban_txt.ForeColor = System.Drawing.Color.Black
        Me.Kanban_txt.Location = New System.Drawing.Point(3, 3)
        Me.Kanban_txt.Name = "Kanban_txt"
        Me.Kanban_txt.Size = New System.Drawing.Size(269, 35)
        Me.Kanban_txt.TabIndex = 2
        Me.Kanban_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kanban_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Kanban_txt.WaterMarkText = "Escanea la kanban..."
        '
        'Kanbans_dgv
        '
        Me.Kanbans_dgv.AllowUserToAddRows = False
        Me.Kanbans_dgv.AllowUserToDeleteRows = False
        Me.Kanbans_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Kanbans_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Kanbans_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Kanbans_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Kanbans_dgv.ColumnHeadersVisible = False
        Me.Kanbans_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.kanban, Me.result, Me.icon_img})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Kanbans_dgv.Location = New System.Drawing.Point(21, 110)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        Me.Kanbans_dgv.ReadOnly = True
        Me.Kanbans_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Kanbans_dgv.RowHeadersVisible = False
        Me.Kanbans_dgv.RowTemplate.Height = 30
        Me.Kanbans_dgv.Size = New System.Drawing.Size(370, 338)
        Me.Kanbans_dgv.TabIndex = 37
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'kanban
        '
        Me.kanban.DataPropertyName = "Kanban"
        Me.kanban.HeaderText = "Serie"
        Me.kanban.Name = "kanban"
        Me.kanban.ReadOnly = True
        Me.kanban.Width = 270
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
        'Count_lbl
        '
        Me.Count_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Count_lbl.Location = New System.Drawing.Point(3, 4)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(134, 58)
        Me.Count_lbl.TabIndex = 38
        Me.Count_lbl.Text = "0"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 25)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "CONTEO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Count_lbl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(253, 452)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 93)
        Me.Panel1.TabIndex = 40
        '
        'Route_txt
        '
        Me.Route_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Route_txt.BackColor = System.Drawing.Color.White
        Me.Route_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Route_txt.ForeColor = System.Drawing.Color.Black
        Me.Route_txt.Location = New System.Drawing.Point(3, 3)
        Me.Route_txt.Name = "Route_txt"
        Me.Route_txt.Size = New System.Drawing.Size(269, 35)
        Me.Route_txt.TabIndex = 1
        Me.Route_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Route_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Route_txt.WaterMarkText = "Escanea la ruta..."
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.Route_txt)
        Me.Panel4.Location = New System.Drawing.Point(66, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 41)
        Me.Panel4.TabIndex = 142
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.Kanban_txt)
        Me.Panel2.Location = New System.Drawing.Point(66, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(275, 41)
        Me.Panel2.TabIndex = 143
        '
        'CDR_MissingPartnumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(407, 554)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Kanbans_dgv)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CDR_MissingPartnumbers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "CANCEL"
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Kanban_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Kanbans_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Count_lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Route_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kanban As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icon_img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
