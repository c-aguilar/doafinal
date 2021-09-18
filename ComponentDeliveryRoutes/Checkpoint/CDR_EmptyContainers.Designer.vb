<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_EmptyContainers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_EmptyContainers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Route_txt = New CAguilar.WaterMarkTextBox()
        Me.Serialnumber_txt = New CAguilar.WaterMarkTextBox()
        Me.Serials_dgv = New System.Windows.Forms.DataGridView()
        Me.serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icon_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Count_lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.Close_btn.Location = New System.Drawing.Point(6, 493)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(238, 93)
        Me.Close_btn.TabIndex = 35
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
        Me.lblTitle.Text = "Contenedores Vacios"
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
        'Serialnumber_txt
        '
        Me.Serialnumber_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serialnumber_txt.BackColor = System.Drawing.Color.White
        Me.Serialnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serialnumber_txt.ForeColor = System.Drawing.Color.Black
        Me.Serialnumber_txt.Location = New System.Drawing.Point(3, 3)
        Me.Serialnumber_txt.Name = "Serialnumber_txt"
        Me.Serialnumber_txt.Size = New System.Drawing.Size(269, 35)
        Me.Serialnumber_txt.TabIndex = 2
        Me.Serialnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Serialnumber_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Serialnumber_txt.WaterMarkText = "Escanea la serie..."
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        Me.Serials_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Serials_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Serials_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Serials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serials_dgv.ColumnHeadersVisible = False
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serial, Me.result, Me.icon_img})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Serials_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Serials_dgv.Location = New System.Drawing.Point(18, 122)
        Me.Serials_dgv.Name = "Serials_dgv"
        Me.Serials_dgv.ReadOnly = True
        Me.Serials_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Serials_dgv.RowHeadersVisible = False
        Me.Serials_dgv.RowTemplate.Height = 30
        Me.Serials_dgv.Size = New System.Drawing.Size(370, 367)
        Me.Serials_dgv.TabIndex = 37
        '
        'serial
        '
        Me.serial.DataPropertyName = "Serialnumber"
        Me.serial.HeaderText = "Serie"
        Me.serial.Name = "serial"
        Me.serial.ReadOnly = True
        Me.serial.Width = 270
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
        Me.Count_lbl.Location = New System.Drawing.Point(268, 492)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(100, 53)
        Me.Count_lbl.TabIndex = 38
        Me.Count_lbl.Text = "0"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 527)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 56)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "___________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CONTEO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.Panel4.TabIndex = 143
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Serialnumber_txt)
        Me.Panel1.Location = New System.Drawing.Point(66, 75)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(275, 41)
        Me.Panel1.TabIndex = 144
        '
        'CDR_EmptyContainers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(407, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Count_lbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CDR_EmptyContainers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "CANCEL"
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Route_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Serialnumber_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Serials_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icon_img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Count_lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
