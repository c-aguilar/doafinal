<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_PartialDiscountKiosk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_PartialDiscountKiosk))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Partial_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.CurrentQuantity_lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CountDown_lbl = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.CountDown_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label7.Size = New System.Drawing.Size(380, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Descuento Parcial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Serie:"
        '
        'Partial_btn
        '
        Me.Partial_btn.Image = CType(resources.GetObject("Partial_btn.Image"), System.Drawing.Image)
        Me.Partial_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Partial_btn.Location = New System.Drawing.Point(115, 293)
        Me.Partial_btn.Name = "Partial_btn"
        Me.Partial_btn.Size = New System.Drawing.Size(150, 50)
        Me.Partial_btn.TabIndex = 3
        Me.Partial_btn.Text = "Aceptar"
        Me.Partial_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Descuento:"
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.DecimalPlaces = 3
        Me.Quantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity_nud.Location = New System.Drawing.Point(185, 237)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Quantity_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(137, 31)
        Me.Quantity_nud.TabIndex = 2
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(107, 83)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(215, 31)
        Me.Serial_txt.TabIndex = 1
        '
        'CurrentQuantity_lbl
        '
        Me.CurrentQuantity_lbl.AutoSize = True
        Me.CurrentQuantity_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentQuantity_lbl.Location = New System.Drawing.Point(197, 209)
        Me.CurrentQuantity_lbl.Name = "CurrentQuantity_lbl"
        Me.CurrentQuantity_lbl.Size = New System.Drawing.Size(19, 25)
        Me.CurrentQuantity_lbl.TabIndex = 100
        Me.CurrentQuantity_lbl.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Cantidad actual:"
        '
        'CountDown_lbl
        '
        Me.CountDown_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountDown_lbl.BackColor = System.Drawing.Color.Transparent
        Me.CountDown_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountDown_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.CountDown_lbl.Location = New System.Drawing.Point(47, 32)
        Me.CountDown_lbl.Name = "CountDown_lbl"
        Me.CountDown_lbl.Size = New System.Drawing.Size(326, 26)
        Me.CountDown_lbl.TabIndex = 103
        Me.CountDown_lbl.Text = "Tiempo restante: 30"
        Me.CountDown_lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
        Me.Close_btn.Location = New System.Drawing.Point(89, 380)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(202, 86)
        Me.Close_btn.TabIndex = 104
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'CountDown_timer
        '
        Me.CountDown_timer.Interval = 1000
        '
        'Description_lbl
        '
        Me.Description_lbl.AutoSize = True
        Me.Description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.Location = New System.Drawing.Point(107, 157)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(14, 20)
        Me.Description_lbl.TabIndex = 112
        Me.Description_lbl.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Descripcion:"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.AutoSize = True
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.Location = New System.Drawing.Point(107, 126)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(16, 24)
        Me.Partnumber_lbl.TabIndex = 110
        Me.Partnumber_lbl.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(71, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 16)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "NP:"
        '
        'Smk_PartialDiscountKiosk
        '
        Me.AcceptButton = Me.Partial_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 479)
        Me.Controls.Add(Me.Description_lbl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.CountDown_lbl)
        Me.Controls.Add(Me.CurrentQuantity_lbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.Partial_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_PartialDiscountKiosk"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Partial_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents CurrentQuantity_lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CountDown_lbl As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents CountDown_timer As System.Windows.Forms.Timer
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
