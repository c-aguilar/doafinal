<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewOperatorEnrollment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewOperatorEnrollment))
        Me.txtEnroll = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Fingerprint_pb = New System.Windows.Forms.PictureBox()
        Me.Fingerprint_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Firstname_txt = New System.Windows.Forms.TextBox()
        Me.Badge_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Lastname_txt = New System.Windows.Forms.TextBox()
        Me.Shift_cbo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Department_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Result_pb = New System.Windows.Forms.PictureBox()
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Result_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEnroll
        '
        Me.txtEnroll.Location = New System.Drawing.Point(12, 215)
        Me.txtEnroll.Multiline = True
        Me.txtEnroll.Name = "txtEnroll"
        Me.txtEnroll.Size = New System.Drawing.Size(235, 194)
        Me.txtEnroll.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(358, 25)
        Me.lblTitle.TabIndex = 39
        Me.lblTitle.Text = "Registro de Operador"
        '
        'Fingerprint_pb
        '
        Me.Fingerprint_pb.Location = New System.Drawing.Point(250, 215)
        Me.Fingerprint_pb.Name = "Fingerprint_pb"
        Me.Fingerprint_pb.Size = New System.Drawing.Size(104, 122)
        Me.Fingerprint_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Fingerprint_pb.TabIndex = 40
        Me.Fingerprint_pb.TabStop = False
        '
        'Fingerprint_btn
        '
        Me.Fingerprint_btn.Image = CType(resources.GetObject("Fingerprint_btn.Image"), System.Drawing.Image)
        Me.Fingerprint_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Fingerprint_btn.Location = New System.Drawing.Point(250, 415)
        Me.Fingerprint_btn.Name = "Fingerprint_btn"
        Me.Fingerprint_btn.Size = New System.Drawing.Size(104, 23)
        Me.Fingerprint_btn.TabIndex = 41
        Me.Fingerprint_btn.Text = "Tomar huella"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Gafete:"
        '
        'Firstname_txt
        '
        Me.Firstname_txt.BackColor = System.Drawing.Color.Ivory
        Me.Firstname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Firstname_txt.Location = New System.Drawing.Point(12, 92)
        Me.Firstname_txt.MaxLength = 20
        Me.Firstname_txt.Name = "Firstname_txt"
        Me.Firstname_txt.Size = New System.Drawing.Size(170, 24)
        Me.Firstname_txt.TabIndex = 53
        '
        'Badge_txt
        '
        Me.Badge_txt.BackColor = System.Drawing.Color.Ivory
        Me.Badge_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Badge_txt.Location = New System.Drawing.Point(12, 47)
        Me.Badge_txt.Name = "Badge_txt"
        Me.Badge_txt.Size = New System.Drawing.Size(109, 26)
        Me.Badge_txt.TabIndex = 52
        Me.Badge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Badge_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Lastname_txt
        '
        Me.Lastname_txt.BackColor = System.Drawing.Color.Ivory
        Me.Lastname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lastname_txt.Location = New System.Drawing.Point(12, 135)
        Me.Lastname_txt.MaxLength = 20
        Me.Lastname_txt.Name = "Lastname_txt"
        Me.Lastname_txt.Size = New System.Drawing.Size(170, 24)
        Me.Lastname_txt.TabIndex = 54
        '
        'Shift_cbo
        '
        Me.Shift_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Shift_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Shift_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shift_cbo.FormattingEnabled = True
        Me.Shift_cbo.Location = New System.Drawing.Point(95, 183)
        Me.Shift_cbo.Name = "Shift_cbo"
        Me.Shift_cbo.Size = New System.Drawing.Size(65, 26)
        Me.Shift_cbo.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(94, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Turno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Apellido:"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.critical_16
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(143, 415)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(104, 23)
        Me.Cancel_btn.TabIndex = 61
        Me.Cancel_btn.Text = "Cancelar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 167)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Departamento:"
        '
        'Department_txt
        '
        Me.Department_txt.BackColor = System.Drawing.Color.Ivory
        Me.Department_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Department_txt.Location = New System.Drawing.Point(12, 183)
        Me.Department_txt.Mask = "0000"
        Me.Department_txt.Name = "Department_txt"
        Me.Department_txt.Size = New System.Drawing.Size(62, 26)
        Me.Department_txt.TabIndex = 62
        Me.Department_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Department_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Result_pb
        '
        Me.Result_pb.Location = New System.Drawing.Point(287, 360)
        Me.Result_pb.Name = "Result_pb"
        Me.Result_pb.Size = New System.Drawing.Size(32, 32)
        Me.Result_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Result_pb.TabIndex = 64
        Me.Result_pb.TabStop = False
        '
        'NewOperatorEnrollment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(358, 444)
        Me.Controls.Add(Me.Result_pb)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Department_txt)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Firstname_txt)
        Me.Controls.Add(Me.Badge_txt)
        Me.Controls.Add(Me.Lastname_txt)
        Me.Controls.Add(Me.Shift_cbo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Fingerprint_btn)
        Me.Controls.Add(Me.Fingerprint_pb)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtEnroll)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewOperatorEnrollment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sensitive"
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Result_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEnroll As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Fingerprint_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Fingerprint_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Firstname_txt As System.Windows.Forms.TextBox
    Friend WithEvents Badge_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Lastname_txt As System.Windows.Forms.TextBox
    Friend WithEvents Shift_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Department_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Result_pb As System.Windows.Forms.PictureBox
End Class
