<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Username_lbl As System.Windows.Forms.Label
    Friend WithEvents Password_lbl As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Username_lbl = New System.Windows.Forms.Label()
        Me.Password_lbl = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.SystemColors.Control
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(5, 17)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(88, 109)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'Username_lbl
        '
        Me.Username_lbl.Location = New System.Drawing.Point(94, 7)
        Me.Username_lbl.Name = "Username_lbl"
        Me.Username_lbl.Size = New System.Drawing.Size(220, 23)
        Me.Username_lbl.TabIndex = 0
        Me.Username_lbl.Text = "Usuario:"
        Me.Username_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Password_lbl
        '
        Me.Password_lbl.Location = New System.Drawing.Point(94, 64)
        Me.Password_lbl.Name = "Password_lbl"
        Me.Password_lbl.Size = New System.Drawing.Size(220, 23)
        Me.Password_lbl.TabIndex = 2
        Me.Password_lbl.Text = "Contraseña:"
        Me.Password_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Location = New System.Drawing.Point(96, 27)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(220, 20)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(96, 84)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(220, 20)
        Me.PasswordTextBox.TabIndex = 3
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'OK_btn
        '
        Me.OK_btn.BackColor = System.Drawing.SystemColors.Control
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(111, 110)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 4
        Me.OK_btn.Text = "&Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = False
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(214, 110)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 5
        Me.Cancel_btn.Text = "&Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'LoginForm
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(325, 143)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.Password_lbl)
        Me.Controls.Add(Me.Username_lbl)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoginForm1"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
