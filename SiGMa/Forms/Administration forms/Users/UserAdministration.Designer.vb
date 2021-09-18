<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAdministration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserAdministration))
        Me.Menu = New System.Windows.Forms.MenuStrip()
        Me.SaveMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.userDGV = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.searchTB = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Menu.SuspendLayout()
        CType(Me.userDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.DarkBlue
        Me.Menu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveMenu, Me.ExecuteMenu})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(1246, 32)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "MenuStrip1"
        '
        'SaveMenu
        '
        Me.SaveMenu.ForeColor = System.Drawing.Color.DarkGray
        Me.SaveMenu.Image = CType(resources.GetObject("SaveMenu.Image"), System.Drawing.Image)
        Me.SaveMenu.Name = "SaveMenu"
        Me.SaveMenu.Size = New System.Drawing.Size(96, 28)
        Me.SaveMenu.Text = "Save"
        '
        'ExecuteMenu
        '
        Me.ExecuteMenu.ForeColor = System.Drawing.Color.DarkGray
        Me.ExecuteMenu.Image = CType(resources.GetObject("ExecuteMenu.Image"), System.Drawing.Image)
        Me.ExecuteMenu.Name = "ExecuteMenu"
        Me.ExecuteMenu.Size = New System.Drawing.Size(125, 28)
        Me.ExecuteMenu.Text = "Execute"
        '
        'userDGV
        '
        Me.userDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.userDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.userDGV.Location = New System.Drawing.Point(12, 114)
        Me.userDGV.Name = "userDGV"
        Me.userDGV.Size = New System.Drawing.Size(1222, 426)
        Me.userDGV.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(30, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search:"
        '
        'searchTB
        '
        Me.searchTB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.searchTB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.searchTB.Location = New System.Drawing.Point(91, 25)
        Me.searchTB.Name = "searchTB"
        Me.searchTB.Size = New System.Drawing.Size(165, 31)
        Me.searchTB.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.searchTB)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(827, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 63)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search user"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(304, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Search"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'UserAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1246, 553)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.userDGV)
        Me.Controls.Add(Me.Menu)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.Menu
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UserAdministration"
        Me.Text = "User administration"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.userDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Menu As MenuStrip
    Friend WithEvents SaveMenu As ToolStripMenuItem
    Friend WithEvents ExecuteMenu As ToolStripMenuItem
    Friend WithEvents userDGV As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents searchTB As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
End Class
