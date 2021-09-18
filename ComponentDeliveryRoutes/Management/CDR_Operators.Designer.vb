<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_Operators
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_Operators))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Firstname_txt = New System.Windows.Forms.TextBox()
        Me.Badge_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Lastname_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Picture_pb = New System.Windows.Forms.PictureBox()
        Me.Picture_btn = New System.Windows.Forms.Button()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Badge_cbo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Role_cbo = New System.Windows.Forms.ComboBox()
        Me.Shift_cbo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Activity_txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Department_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Delete_btn = New System.Windows.Forms.Button()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(391, 25)
        Me.lblTitle.TabIndex = 35
        Me.lblTitle.Text = "Operadores de Rutas de Componentes"
        '
        'Firstname_txt
        '
        Me.Firstname_txt.BackColor = System.Drawing.Color.Ivory
        Me.Firstname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Firstname_txt.Location = New System.Drawing.Point(6, 77)
        Me.Firstname_txt.MaxLength = 20
        Me.Firstname_txt.Name = "Firstname_txt"
        Me.Firstname_txt.Size = New System.Drawing.Size(170, 24)
        Me.Firstname_txt.TabIndex = 3
        '
        'Badge_txt
        '
        Me.Badge_txt.BackColor = System.Drawing.Color.Ivory
        Me.Badge_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Badge_txt.Location = New System.Drawing.Point(6, 32)
        Me.Badge_txt.Name = "Badge_txt"
        Me.Badge_txt.Size = New System.Drawing.Size(109, 26)
        Me.Badge_txt.TabIndex = 2
        Me.Badge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Badge_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Lastname_txt
        '
        Me.Lastname_txt.BackColor = System.Drawing.Color.Ivory
        Me.Lastname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lastname_txt.Location = New System.Drawing.Point(6, 120)
        Me.Lastname_txt.MaxLength = 20
        Me.Lastname_txt.Name = "Lastname_txt"
        Me.Lastname_txt.Size = New System.Drawing.Size(170, 24)
        Me.Lastname_txt.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Gafete:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Apellido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Turno:"
        '
        'Picture_pb
        '
        Me.Picture_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_pb.Image = CType(resources.GetObject("Picture_pb.Image"), System.Drawing.Image)
        Me.Picture_pb.Location = New System.Drawing.Point(225, 16)
        Me.Picture_pb.Name = "Picture_pb"
        Me.Picture_pb.Size = New System.Drawing.Size(137, 164)
        Me.Picture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture_pb.TabIndex = 45
        Me.Picture_pb.TabStop = False
        '
        'Picture_btn
        '
        Me.Picture_btn.Image = CType(resources.GetObject("Picture_btn.Image"), System.Drawing.Image)
        Me.Picture_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Picture_btn.Location = New System.Drawing.Point(225, 180)
        Me.Picture_btn.Name = "Picture_btn"
        Me.Picture_btn.Size = New System.Drawing.Size(137, 23)
        Me.Picture_btn.TabIndex = 6
        Me.Picture_btn.Text = "Cambiar..."
        Me.Picture_btn.UseVisualStyleBackColor = True
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(262, 367)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 23)
        Me.Save_btn.TabIndex = 7
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Badge_cbo
        '
        Me.Badge_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Badge_cbo.FormattingEnabled = True
        Me.Badge_cbo.Location = New System.Drawing.Point(12, 54)
        Me.Badge_cbo.Name = "Badge_cbo"
        Me.Badge_cbo.Size = New System.Drawing.Size(199, 21)
        Me.Badge_cbo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Operador seleccionado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Role_cbo)
        Me.GroupBox1.Controls.Add(Me.Shift_cbo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Activity_txt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Department_txt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Delete_btn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Firstname_txt)
        Me.GroupBox1.Controls.Add(Me.Badge_txt)
        Me.GroupBox1.Controls.Add(Me.Save_btn)
        Me.GroupBox1.Controls.Add(Me.Lastname_txt)
        Me.GroupBox1.Controls.Add(Me.Picture_btn)
        Me.GroupBox1.Controls.Add(Me.Picture_pb)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 396)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'Role_cbo
        '
        Me.Role_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Role_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Role_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Role_cbo.FormattingEnabled = True
        Me.Role_cbo.Location = New System.Drawing.Point(7, 253)
        Me.Role_cbo.Name = "Role_cbo"
        Me.Role_cbo.Size = New System.Drawing.Size(300, 26)
        Me.Role_cbo.TabIndex = 73
        '
        'Shift_cbo
        '
        Me.Shift_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Shift_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Shift_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shift_cbo.FormattingEnabled = True
        Me.Shift_cbo.Location = New System.Drawing.Point(7, 163)
        Me.Shift_cbo.Name = "Shift_cbo"
        Me.Shift_cbo.Size = New System.Drawing.Size(65, 26)
        Me.Shift_cbo.TabIndex = 71
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 323)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Departamento:"
        '
        'Activity_txt
        '
        Me.Activity_txt.BackColor = System.Drawing.Color.Ivory
        Me.Activity_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Activity_txt.Location = New System.Drawing.Point(7, 296)
        Me.Activity_txt.MaxLength = 70
        Me.Activity_txt.Name = "Activity_txt"
        Me.Activity_txt.Size = New System.Drawing.Size(249, 24)
        Me.Activity_txt.TabIndex = 69
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Actividad:"
        '
        'Department_txt
        '
        Me.Department_txt.BackColor = System.Drawing.Color.Ivory
        Me.Department_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Department_txt.Location = New System.Drawing.Point(7, 339)
        Me.Department_txt.Mask = "0000"
        Me.Department_txt.Name = "Department_txt"
        Me.Department_txt.Size = New System.Drawing.Size(62, 26)
        Me.Department_txt.TabIndex = 66
        Me.Department_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Department_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Puesto:"
        '
        'Delete_btn
        '
        Me.Delete_btn.Image = CType(resources.GetObject("Delete_btn.Image"), System.Drawing.Image)
        Me.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete_btn.Location = New System.Drawing.Point(156, 367)
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.Size = New System.Drawing.Size(100, 23)
        Me.Delete_btn.TabIndex = 8
        Me.Delete_btn.Text = "Eliminar"
        Me.Delete_btn.UseVisualStyleBackColor = True
        '
        'CDR_Operators
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 489)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Badge_cbo)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "CDR_Operators"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Firstname_txt As System.Windows.Forms.TextBox
    Friend WithEvents Badge_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Lastname_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Picture_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_btn As System.Windows.Forms.Button
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Badge_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Delete_btn As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Activity_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Department_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Role_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Shift_cbo As System.Windows.Forms.ComboBox
End Class
