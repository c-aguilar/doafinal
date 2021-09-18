<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_NewSerial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_NewSerial))
        Me.Containers_nud = New System.Windows.Forms.NumericUpDown()
        Me.UoM_cbo = New System.Windows.Forms.ComboBox()
        Me.NoExpiraton_chk = New System.Windows.Forms.CheckBox()
        Me.ExpirationDate_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Lot_txt = New System.Windows.Forms.TextBox()
        Me.Quantity_txt = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Clean_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UoM_lbl = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lot_lbl = New System.Windows.Forms.Label()
        Me.Expiration_lbl = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Container_lbl = New System.Windows.Forms.Label()
        Me.Container_cbo = New System.Windows.Forms.ComboBox()
        CType(Me.Containers_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Containers_nud
        '
        Me.Containers_nud.BackColor = System.Drawing.Color.Ivory
        Me.Containers_nud.Location = New System.Drawing.Point(252, 66)
        Me.Containers_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Containers_nud.Name = "Containers_nud"
        Me.Containers_nud.Size = New System.Drawing.Size(102, 20)
        Me.Containers_nud.TabIndex = 5
        Me.Containers_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Containers_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'UoM_cbo
        '
        Me.UoM_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UoM_cbo.FormattingEnabled = True
        Me.UoM_cbo.Items.AddRange(New Object() {"PC", "M", "FT", "KG", "LB", "L"})
        Me.UoM_cbo.Location = New System.Drawing.Point(360, 65)
        Me.UoM_cbo.Name = "UoM_cbo"
        Me.UoM_cbo.Size = New System.Drawing.Size(84, 21)
        Me.UoM_cbo.TabIndex = 6
        '
        'NoExpiraton_chk
        '
        Me.NoExpiraton_chk.AutoSize = True
        Me.NoExpiraton_chk.Location = New System.Drawing.Point(313, 126)
        Me.NoExpiraton_chk.Name = "NoExpiraton_chk"
        Me.NoExpiraton_chk.Size = New System.Drawing.Size(146, 17)
        Me.NoExpiraton_chk.TabIndex = 9
        Me.NoExpiraton_chk.Text = "Sin fecha de vencimiento"
        Me.NoExpiraton_chk.UseVisualStyleBackColor = True
        Me.NoExpiraton_chk.Visible = False
        '
        'ExpirationDate_dtp
        '
        Me.ExpirationDate_dtp.Location = New System.Drawing.Point(107, 124)
        Me.ExpirationDate_dtp.Name = "ExpirationDate_dtp"
        Me.ExpirationDate_dtp.Size = New System.Drawing.Size(200, 20)
        Me.ExpirationDate_dtp.TabIndex = 8
        Me.ExpirationDate_dtp.Visible = False
        '
        'Lot_txt
        '
        Me.Lot_txt.BackColor = System.Drawing.Color.Ivory
        Me.Lot_txt.Location = New System.Drawing.Point(15, 124)
        Me.Lot_txt.MaxLength = 20
        Me.Lot_txt.Name = "Lot_txt"
        Me.Lot_txt.Size = New System.Drawing.Size(87, 20)
        Me.Lot_txt.TabIndex = 7
        Me.Lot_txt.Visible = False
        '
        'Quantity_txt
        '
        Me.Quantity_txt.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_txt.Location = New System.Drawing.Point(146, 66)
        Me.Quantity_txt.Name = "Quantity_txt"
        Me.Quantity_txt.Size = New System.Drawing.Size(100, 20)
        Me.Quantity_txt.TabIndex = 4
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(182, 164)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(130, 40)
        Me.Save_btn.TabIndex = 10
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Clean_btn
        '
        Me.Clean_btn.Image = CType(resources.GetObject("Clean_btn.Image"), System.Drawing.Image)
        Me.Clean_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Clean_btn.Location = New System.Drawing.Point(314, 164)
        Me.Clean_btn.Name = "Clean_btn"
        Me.Clean_btn.Size = New System.Drawing.Size(130, 40)
        Me.Clean_btn.TabIndex = 11
        Me.Clean_btn.Text = "Limpiar"
        Me.Clean_btn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 18)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Numero de Parte"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(143, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(249, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 18)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Contenedores"
        '
        'UoM_lbl
        '
        Me.UoM_lbl.AutoSize = True
        Me.UoM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UoM_lbl.Location = New System.Drawing.Point(357, 44)
        Me.UoM_lbl.Name = "UoM_lbl"
        Me.UoM_lbl.Size = New System.Drawing.Size(54, 18)
        Me.UoM_lbl.TabIndex = 85
        Me.UoM_lbl.Text = "Unidad"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(631, 25)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Reetiquetado de Material"
        '
        'Lot_lbl
        '
        Me.Lot_lbl.AutoSize = True
        Me.Lot_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lot_lbl.Location = New System.Drawing.Point(12, 103)
        Me.Lot_lbl.Name = "Lot_lbl"
        Me.Lot_lbl.Size = New System.Drawing.Size(37, 18)
        Me.Lot_lbl.TabIndex = 87
        Me.Lot_lbl.Text = "Lote"
        Me.Lot_lbl.Visible = False
        '
        'Expiration_lbl
        '
        Me.Expiration_lbl.AutoSize = True
        Me.Expiration_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Expiration_lbl.Location = New System.Drawing.Point(104, 103)
        Me.Expiration_lbl.Name = "Expiration_lbl"
        Me.Expiration_lbl.Size = New System.Drawing.Size(142, 18)
        Me.Expiration_lbl.TabIndex = 88
        Me.Expiration_lbl.Text = "Fecha de Expiracion"
        Me.Expiration_lbl.Visible = False
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(15, 66)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(118, 20)
        Me.Partnumber_txt.TabIndex = 3
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Container_lbl
        '
        Me.Container_lbl.AutoSize = True
        Me.Container_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Container_lbl.Location = New System.Drawing.Point(446, 44)
        Me.Container_lbl.Name = "Container_lbl"
        Me.Container_lbl.Size = New System.Drawing.Size(72, 18)
        Me.Container_lbl.TabIndex = 92
        Me.Container_lbl.Text = "Container"
        Me.Container_lbl.Visible = False
        '
        'Container_cbo
        '
        Me.Container_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Container_cbo.FormattingEnabled = True
        Me.Container_cbo.Items.AddRange(New Object() {"PC", "M", "FT", "KG", "LB", "L"})
        Me.Container_cbo.Location = New System.Drawing.Point(449, 65)
        Me.Container_cbo.Name = "Container_cbo"
        Me.Container_cbo.Size = New System.Drawing.Size(175, 21)
        Me.Container_cbo.TabIndex = 91
        Me.Container_cbo.Visible = False
        '
        'Smk_NewSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 216)
        Me.Controls.Add(Me.Container_lbl)
        Me.Controls.Add(Me.Container_cbo)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Expiration_lbl)
        Me.Controls.Add(Me.Lot_lbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UoM_lbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Clean_btn)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Containers_nud)
        Me.Controls.Add(Me.UoM_cbo)
        Me.Controls.Add(Me.NoExpiraton_chk)
        Me.Controls.Add(Me.ExpirationDate_dtp)
        Me.Controls.Add(Me.Lot_txt)
        Me.Controls.Add(Me.Quantity_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Smk_NewSerial"
        Me.Text = "Supermarket"
        CType(Me.Containers_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Containers_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents UoM_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents NoExpiraton_chk As System.Windows.Forms.CheckBox
    Friend WithEvents ExpirationDate_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lot_txt As System.Windows.Forms.TextBox
    Friend WithEvents Quantity_txt As System.Windows.Forms.TextBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Clean_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UoM_lbl As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Lot_lbl As System.Windows.Forms.Label
    Friend WithEvents Expiration_lbl As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Container_lbl As System.Windows.Forms.Label
    Friend WithEvents Container_cbo As System.Windows.Forms.ComboBox
End Class
