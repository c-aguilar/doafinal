<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_OutCart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDR_OutCart))
        Me.Cart_txt = New CAguilar.WaterMarkTextBox()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Badge_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cart_txt
        '
        Me.Cart_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cart_txt.BackColor = System.Drawing.Color.White
        Me.Cart_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cart_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cart_txt.ForeColor = System.Drawing.Color.Black
        Me.Cart_txt.Location = New System.Drawing.Point(162, 15)
        Me.Cart_txt.Name = "Cart_txt"
        Me.Cart_txt.Size = New System.Drawing.Size(242, 35)
        Me.Cart_txt.TabIndex = 1
        Me.Cart_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cart_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Cart_txt.WaterMarkText = "Escanea el carro..."
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
        Me.Cancel_btn.Location = New System.Drawing.Point(162, 129)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(242, 83)
        Me.Cancel_btn.TabIndex = 145
        Me.Cancel_btn.Text = "CANCELAR"
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
        Me.lblTitle.Size = New System.Drawing.Size(439, 25)
        Me.lblTitle.TabIndex = 144
        Me.lblTitle.Text = "Salida de Carro Surtido"
        '
        'Badge_txt
        '
        Me.Badge_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Badge_txt.BackColor = System.Drawing.Color.White
        Me.Badge_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Badge_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Badge_txt.ForeColor = System.Drawing.Color.Black
        Me.Badge_txt.Location = New System.Drawing.Point(162, 64)
        Me.Badge_txt.Name = "Badge_txt"
        Me.Badge_txt.Size = New System.Drawing.Size(242, 35)
        Me.Badge_txt.TabIndex = 146
        Me.Badge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Badge_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Badge_txt.WaterMarkText = "Gafete ruta externa..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Cart_txt)
        Me.Panel1.Controls.Add(Me.Cancel_btn)
        Me.Panel1.Controls.Add(Me.Badge_txt)
        Me.Panel1.Location = New System.Drawing.Point(2, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 231)
        Me.Panel1.TabIndex = 147
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Delta_ERP.My.Resources.Resources.ddr_outside
        Me.PictureBox1.Location = New System.Drawing.Point(23, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 109)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 147
        Me.PictureBox1.TabStop = False
        '
        'DDR_OutCart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 262)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DDR_OutCart"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Component Delivery Routes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cart_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Badge_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
