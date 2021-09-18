<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FGR_SerialScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FGR_SerialScan))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Serial_txt = New CAguilar.WaterMarkTextBox()
        Me.Route_lbl = New System.Windows.Forms.Label()
        Me.OperatorName_lbl = New System.Windows.Forms.Label()
        Me.Picture_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Count_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Kanbans_dgv = New System.Windows.Forms.DataGridView()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountDown_timer = New System.Windows.Forms.Timer(Me.components)
        Me.CountDown_lbl = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.Serial_txt)
        Me.Panel4.Location = New System.Drawing.Point(298, 43)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(245, 41)
        Me.Panel4.TabIndex = 151
        '
        'Serial_txt
        '
        Me.Serial_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serial_txt.BackColor = System.Drawing.Color.White
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.ForeColor = System.Drawing.Color.Black
        Me.Serial_txt.Location = New System.Drawing.Point(3, 3)
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(239, 35)
        Me.Serial_txt.TabIndex = 1
        Me.Serial_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Serial_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Serial_txt.WaterMarkText = "Escanea la serie..."
        '
        'Route_lbl
        '
        Me.Route_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Route_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Route_lbl.ForeColor = System.Drawing.Color.Black
        Me.Route_lbl.Location = New System.Drawing.Point(83, 43)
        Me.Route_lbl.Name = "Route_lbl"
        Me.Route_lbl.Size = New System.Drawing.Size(209, 35)
        Me.Route_lbl.TabIndex = 150
        Me.Route_lbl.Text = "RUTA 1"
        '
        'OperatorName_lbl
        '
        Me.OperatorName_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OperatorName_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.OperatorName_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperatorName_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.OperatorName_lbl.Location = New System.Drawing.Point(83, 84)
        Me.OperatorName_lbl.Name = "OperatorName_lbl"
        Me.OperatorName_lbl.Size = New System.Drawing.Size(365, 36)
        Me.OperatorName_lbl.TabIndex = 149
        Me.OperatorName_lbl.Text = "Nombre del Operador"
        Me.OperatorName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Picture_pb
        '
        Me.Picture_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_pb.Image = CType(resources.GetObject("Picture_pb.Image"), System.Drawing.Image)
        Me.Picture_pb.Location = New System.Drawing.Point(7, 38)
        Me.Picture_pb.Name = "Picture_pb"
        Me.Picture_pb.Size = New System.Drawing.Size(70, 82)
        Me.Picture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture_pb.TabIndex = 148
        Me.Picture_pb.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Count_lbl)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(620, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(182, 100)
        Me.Panel1.TabIndex = 144
        '
        'Count_lbl
        '
        Me.Count_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 42.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Count_lbl.Location = New System.Drawing.Point(5, 5)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(170, 55)
        Me.Count_lbl.TabIndex = 49
        Me.Count_lbl.Text = "0"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 28)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "CONTEO TOTAL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.Close_btn.Location = New System.Drawing.Point(607, 541)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(218, 93)
        Me.Close_btn.TabIndex = 142
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Kanbans_dgv
        '
        Me.Kanbans_dgv.AllowUserToAddRows = False
        Me.Kanbans_dgv.AllowUserToDeleteRows = False
        Me.Kanbans_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Kanbans_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Kanbans_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Kanbans_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Kanbans_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Kanbans_dgv.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.Kanbans_dgv.Location = New System.Drawing.Point(264, 122)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        Me.Kanbans_dgv.ReadOnly = True
        Me.Kanbans_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Kanbans_dgv.RowHeadersVisible = False
        Me.Kanbans_dgv.RowTemplate.Height = 30
        Me.Kanbans_dgv.Size = New System.Drawing.Size(312, 512)
        Me.Kanbans_dgv.TabIndex = 141
        '
        'Title_lbl
        '
        Me.Title_lbl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Title_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(841, 25)
        Me.Title_lbl.TabIndex = 152
        Me.Title_lbl.Text = "Escaneo de Contenedores de PT"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Kanban"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Kanban"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Result"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Result"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'CountDown_timer
        '
        Me.CountDown_timer.Interval = 1000
        '
        'CountDown_lbl
        '
        Me.CountDown_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountDown_lbl.BackColor = System.Drawing.Color.Transparent
        Me.CountDown_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountDown_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.CountDown_lbl.Location = New System.Drawing.Point(607, 512)
        Me.CountDown_lbl.Name = "CountDown_lbl"
        Me.CountDown_lbl.Size = New System.Drawing.Size(218, 26)
        Me.CountDown_lbl.TabIndex = 153
        Me.CountDown_lbl.Text = "Tiempo restante: 30"
        Me.CountDown_lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'FGR_SerialScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 646)
        Me.Controls.Add(Me.CountDown_lbl)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Route_lbl)
        Me.Controls.Add(Me.OperatorName_lbl)
        Me.Controls.Add(Me.Picture_pb)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Kanbans_dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FGR_SerialScan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Finished Good Delivery Routes"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Serial_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Route_lbl As System.Windows.Forms.Label
    Friend WithEvents OperatorName_lbl As System.Windows.Forms.Label
    Friend WithEvents Picture_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Count_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Kanbans_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountDown_timer As System.Windows.Forms.Timer
    Friend WithEvents CountDown_lbl As System.Windows.Forms.Label
End Class
