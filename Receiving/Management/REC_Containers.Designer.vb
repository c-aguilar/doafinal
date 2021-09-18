<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REC_Containers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(REC_Containers))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.ID_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Class_cbo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Picture_pb = New System.Windows.Forms.PictureBox()
        Me.Picture_btn = New System.Windows.Forms.Button()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.ID_cbo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Delete_btn = New System.Windows.Forms.Button()
        Me.Weight_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Weight_nud, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Text = "Administracion de Dollies y Contenedores"
        '
        'Name_txt
        '
        Me.Name_txt.BackColor = System.Drawing.Color.Ivory
        Me.Name_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_txt.Location = New System.Drawing.Point(6, 77)
        Me.Name_txt.MaxLength = 20
        Me.Name_txt.Name = "Name_txt"
        Me.Name_txt.Size = New System.Drawing.Size(170, 24)
        Me.Name_txt.TabIndex = 3
        '
        'ID_txt
        '
        Me.ID_txt.BackColor = System.Drawing.Color.Ivory
        Me.ID_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID_txt.Location = New System.Drawing.Point(6, 32)
        Me.ID_txt.Mask = "AAAAA"
        Me.ID_txt.Name = "ID_txt"
        Me.ID_txt.Size = New System.Drawing.Size(109, 26)
        Me.ID_txt.TabIndex = 2
        Me.ID_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ID_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Class_cbo
        '
        Me.Class_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Class_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Class_cbo.FormattingEnabled = True
        Me.Class_cbo.Items.AddRange(New Object() {"Cable-Container", "Cable-Dolly", "Component-Container"})
        Me.Class_cbo.Location = New System.Drawing.Point(9, 163)
        Me.Class_cbo.Name = "Class_cbo"
        Me.Class_cbo.Size = New System.Drawing.Size(170, 26)
        Me.Class_cbo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "ID:"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Tipo:"
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
        Me.Save_btn.Location = New System.Drawing.Point(262, 231)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 23)
        Me.Save_btn.TabIndex = 7
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'ID_cbo
        '
        Me.ID_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ID_cbo.FormattingEnabled = True
        Me.ID_cbo.Location = New System.Drawing.Point(12, 54)
        Me.ID_cbo.Name = "ID_cbo"
        Me.ID_cbo.Size = New System.Drawing.Size(199, 21)
        Me.ID_cbo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Contenedor seleccionado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Weight_nud)
        Me.GroupBox1.Controls.Add(Me.Delete_btn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Name_txt)
        Me.GroupBox1.Controls.Add(Me.ID_txt)
        Me.GroupBox1.Controls.Add(Me.Save_btn)
        Me.GroupBox1.Controls.Add(Me.Picture_btn)
        Me.GroupBox1.Controls.Add(Me.Class_cbo)
        Me.GroupBox1.Controls.Add(Me.Picture_pb)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 263)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'Delete_btn
        '
        Me.Delete_btn.Image = CType(resources.GetObject("Delete_btn.Image"), System.Drawing.Image)
        Me.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete_btn.Location = New System.Drawing.Point(156, 231)
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.Size = New System.Drawing.Size(100, 23)
        Me.Delete_btn.TabIndex = 8
        Me.Delete_btn.Text = "Eliminar"
        Me.Delete_btn.UseVisualStyleBackColor = True
        '
        'Weight_nud
        '
        Me.Weight_nud.BackColor = System.Drawing.Color.Ivory
        Me.Weight_nud.DecimalPlaces = 3
        Me.Weight_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_nud.Location = New System.Drawing.Point(9, 120)
        Me.Weight_nud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 196608})
        Me.Weight_nud.Name = "Weight_nud"
        Me.Weight_nud.Size = New System.Drawing.Size(86, 24)
        Me.Weight_nud.TabIndex = 46
        Me.Weight_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Peso (Kg):"
        '
        'REC_Containers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 354)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ID_cbo)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "REC_Containers"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Weight_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Name_txt As System.Windows.Forms.TextBox
    Friend WithEvents ID_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Class_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Picture_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_btn As System.Windows.Forms.Button
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents ID_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Delete_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Weight_nud As System.Windows.Forms.NumericUpDown
End Class
