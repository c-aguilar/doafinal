<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableSearchRandom
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableSearchRandom))
        Me.Item_txt = New CAguilar.WaterMarkTextBox()
        Me.Serial_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvResults = New CAguilar.DataGridViewWithFilters()
        Me.NextSerial_btn = New System.Windows.Forms.Button()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Controlled_lbl = New System.Windows.Forms.Label()
        Me.Controlled_pb = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Controlled_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Item_txt
        '
        Me.Item_txt.BackColor = System.Drawing.Color.Ivory
        Me.Item_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Item_txt.Location = New System.Drawing.Point(293, 102)
        Me.Item_txt.Name = "Item_txt"
        Me.Item_txt.Size = New System.Drawing.Size(422, 40)
        Me.Item_txt.TabIndex = 10
        Me.Item_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Item_txt.WaterMarkText = "Escriba el numero de parte..."
        '
        'Serial_rb
        '
        Me.Serial_rb.AutoSize = True
        Me.Serial_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_rb.ForeColor = System.Drawing.Color.Black
        Me.Serial_rb.Location = New System.Drawing.Point(11, 59)
        Me.Serial_rb.Name = "Serial_rb"
        Me.Serial_rb.Size = New System.Drawing.Size(72, 28)
        Me.Serial_rb.TabIndex = 15
        Me.Serial_rb.Text = "Serie"
        Me.Serial_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Checked = True
        Me.Partnumber_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_rb.ForeColor = System.Drawing.Color.Black
        Me.Partnumber_rb.Location = New System.Drawing.Point(11, 25)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(171, 28)
        Me.Partnumber_rb.TabIndex = 16
        Me.Partnumber_rb.TabStop = True
        Me.Partnumber_rb.Text = "Numero de parte"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Partnumber_rb)
        Me.GroupBox1.Controls.Add(Me.Serial_rb)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por"
        '
        'dgvResults
        '
        Me.dgvResults.AllowColumnHiding = True
        Me.dgvResults.AllowUserToAddRows = False
        Me.dgvResults.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResults.EnableHeadersVisualStyles = False
        Me.dgvResults.Location = New System.Drawing.Point(12, 161)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResults.ShowRowNumber = True
        Me.dgvResults.Size = New System.Drawing.Size(976, 467)
        Me.dgvResults.TabIndex = 18
        '
        'NextSerial_btn
        '
        Me.NextSerial_btn.AutoSize = True
        Me.NextSerial_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextSerial_btn.Image = CType(resources.GetObject("NextSerial_btn.Image"), System.Drawing.Image)
        Me.NextSerial_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.NextSerial_btn.Location = New System.Drawing.Point(763, 641)
        Me.NextSerial_btn.Name = "NextSerial_btn"
        Me.NextSerial_btn.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.NextSerial_btn.Size = New System.Drawing.Size(225, 38)
        Me.NextSerial_btn.TabIndex = 20
        Me.NextSerial_btn.Text = "Generar siguiente serie"
        Me.NextSerial_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NextSerial_btn.UseVisualStyleBackColor = True
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 9)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(976, 43)
        Me.Title_lbl.TabIndex = 118
        Me.Title_lbl.Text = "Buscar en Reserva"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Close_btn.ForeColor = System.Drawing.Color.Black
        Me.Close_btn.Location = New System.Drawing.Point(409, 641)
        Me.Close_btn.Margin = New System.Windows.Forms.Padding(10)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(207, 90)
        Me.Close_btn.TabIndex = 121
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Controlled_lbl
        '
        Me.Controlled_lbl.AutoSize = True
        Me.Controlled_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controlled_lbl.Location = New System.Drawing.Point(840, 93)
        Me.Controlled_lbl.Name = "Controlled_lbl"
        Me.Controlled_lbl.Size = New System.Drawing.Size(115, 15)
        Me.Controlled_lbl.TabIndex = 154
        Me.Controlled_lbl.Text = "Material Controlado"
        Me.Controlled_lbl.Visible = False
        '
        'Controlled_pb
        '
        Me.Controlled_pb.Image = Global.Delta_ERP.My.Resources.Resources.battery_low_32
        Me.Controlled_pb.Location = New System.Drawing.Point(802, 93)
        Me.Controlled_pb.Name = "Controlled_pb"
        Me.Controlled_pb.Size = New System.Drawing.Size(32, 32)
        Me.Controlled_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Controlled_pb.TabIndex = 153
        Me.Controlled_pb.TabStop = False
        Me.Controlled_pb.Visible = False
        '
        'Smk_CableSearchRandom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1000, 750)
        Me.Controls.Add(Me.Controlled_lbl)
        Me.Controls.Add(Me.Controlled_pb)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.NextSerial_btn)
        Me.Controls.Add(Me.dgvResults)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Item_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableSearchRandom"
        Me.ShowIcon = False
        Me.Text = "Busqueda en Reserva"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Controlled_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Item_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Serial_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvResults As CAguilar.DataGridViewWithFilters
    Friend WithEvents NextSerial_btn As System.Windows.Forms.Button
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Controlled_lbl As System.Windows.Forms.Label
    Friend WithEvents Controlled_pb As System.Windows.Forms.PictureBox
End Class
