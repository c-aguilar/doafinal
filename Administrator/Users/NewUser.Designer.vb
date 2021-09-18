<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewUser
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
        Me.UsernameTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstnameTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LastnameTextbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.EmailTextbox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'UsernameTextbox
        '
        Me.UsernameTextbox.Location = New System.Drawing.Point(76, 30)
        Me.UsernameTextbox.Name = "UsernameTextbox"
        Me.UsernameTextbox.Size = New System.Drawing.Size(166, 20)
        Me.UsernameTextbox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "First name:"
        '
        'FirstnameTextbox
        '
        Me.FirstnameTextbox.Location = New System.Drawing.Point(76, 56)
        Me.FirstnameTextbox.Name = "FirstnameTextbox"
        Me.FirstnameTextbox.Size = New System.Drawing.Size(166, 20)
        Me.FirstnameTextbox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Last name:"
        '
        'LastnameTextbox
        '
        Me.LastnameTextbox.Location = New System.Drawing.Point(76, 82)
        Me.LastnameTextbox.Name = "LastnameTextbox"
        Me.LastnameTextbox.Size = New System.Drawing.Size(166, 20)
        Me.LastnameTextbox.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email:"
        '
        'EmailTextbox
        '
        Me.EmailTextbox.Location = New System.Drawing.Point(76, 108)
        Me.EmailTextbox.Name = "EmailTextbox"
        Me.EmailTextbox.Size = New System.Drawing.Size(166, 20)
        Me.EmailTextbox.TabIndex = 6
        '
        'NewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.EmailTextbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LastnameTextbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FirstnameTextbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UsernameTextbox)
        Me.Name = "NewUser"
        Me.Text = "NewUser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsernameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FirstnameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LastnameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EmailTextbox As System.Windows.Forms.TextBox
End Class
