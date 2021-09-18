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
        Me.Plant_cbo = New System.Windows.Forms.ComboBox()
        Me.ByFingerprint_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DeltaLabel = New System.Windows.Forms.Label()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(82, 21)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(88, 87)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'Username_lbl
        '
        Me.Username_lbl.AutoSize = True
        Me.Username_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.Username_lbl.Location = New System.Drawing.Point(5, 183)
        Me.Username_lbl.Name = "Username_lbl"
        Me.Username_lbl.Size = New System.Drawing.Size(46, 13)
        Me.Username_lbl.TabIndex = 0
        Me.Username_lbl.Text = "Usuario:"
        Me.Username_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Password_lbl
        '
        Me.Password_lbl.AutoSize = True
        Me.Password_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.Password_lbl.Location = New System.Drawing.Point(5, 218)
        Me.Password_lbl.Name = "Password_lbl"
        Me.Password_lbl.Size = New System.Drawing.Size(64, 13)
        Me.Password_lbl.TabIndex = 2
        Me.Password_lbl.Text = "Contraseña:"
        Me.Password_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.Ivory
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Location = New System.Drawing.Point(8, 197)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(238, 20)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.Ivory
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Location = New System.Drawing.Point(8, 234)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(239, 20)
        Me.PasswordTextBox.TabIndex = 3
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'OK_btn
        '
        Me.OK_btn.BackColor = System.Drawing.SystemColors.Control
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(40, 265)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.OK_btn.Size = New System.Drawing.Size(207, 25)
        Me.OK_btn.TabIndex = 4
        Me.OK_btn.Text = "&Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = False
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.FlatAppearance.BorderSize = 0
        Me.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_btn.ForeColor = System.Drawing.Color.DarkRed
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(229, 3)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(20, 20)
        Me.Cancel_btn.TabIndex = 5
        Me.Cancel_btn.Text = "X"
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'Plant_cbo
        '
        Me.Plant_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Plant_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Plant_cbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Plant_cbo.FormattingEnabled = True
        Me.Plant_cbo.Items.AddRange(New Object() {"FV38", "FV37", "FV50", "SBox"})
        Me.Plant_cbo.Location = New System.Drawing.Point(8, 159)
        Me.Plant_cbo.Name = "Plant_cbo"
        Me.Plant_cbo.Size = New System.Drawing.Size(239, 21)
        Me.Plant_cbo.TabIndex = 6
        '
        'ByFingerprint_btn
        '
        Me.ByFingerprint_btn.BackColor = System.Drawing.SystemColors.Control
        Me.ByFingerprint_btn.Image = CType(resources.GetObject("ByFingerprint_btn.Image"), System.Drawing.Image)
        Me.ByFingerprint_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ByFingerprint_btn.Location = New System.Drawing.Point(8, 265)
        Me.ByFingerprint_btn.Name = "ByFingerprint_btn"
        Me.ByFingerprint_btn.Size = New System.Drawing.Size(26, 25)
        Me.ByFingerprint_btn.TabIndex = 7
        Me.ByFingerprint_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(5, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Planta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.SystemColors.Control
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.DeltaLabel)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LogoPictureBox)
        Me.PanelMain.Controls.Add(Me.ByFingerprint_btn)
        Me.PanelMain.Controls.Add(Me.Username_lbl)
        Me.PanelMain.Controls.Add(Me.Plant_cbo)
        Me.PanelMain.Controls.Add(Me.Password_lbl)
        Me.PanelMain.Controls.Add(Me.Cancel_btn)
        Me.PanelMain.Controls.Add(Me.UsernameTextBox)
        Me.PanelMain.Controls.Add(Me.OK_btn)
        Me.PanelMain.Controls.Add(Me.PasswordTextBox)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(255, 303)
        Me.PanelMain.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(15, 136)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(222, 1)
        Me.Panel1.TabIndex = 11
        '
        'DeltaLabel
        '
        Me.DeltaLabel.AutoSize = True
        Me.DeltaLabel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaLabel.ForeColor = System.Drawing.Color.Black
        Me.DeltaLabel.Location = New System.Drawing.Point(90, 111)
        Me.DeltaLabel.Name = "DeltaLabel"
        Me.DeltaLabel.Size = New System.Drawing.Size(73, 19)
        Me.DeltaLabel.TabIndex = 9
        Me.DeltaLabel.Text = "Delta ERP"
        '
        'LoginForm
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(255, 303)
        Me.Controls.Add(Me.PanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.Opacity = 0.95R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoginForm1"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Plant_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents ByFingerprint_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents DeltaLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
