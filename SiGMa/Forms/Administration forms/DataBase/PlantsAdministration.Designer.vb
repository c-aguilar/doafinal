<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantsAdministration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlantsAdministration))
        Me.Menu = New System.Windows.Forms.MenuStrip()
        Me.SaveMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.plantsDGV = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.plantTb = New System.Windows.Forms.TextBox()
        Me.Menu.SuspendLayout()
        CType(Me.plantsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.MidnightBlue
        Me.Menu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveMenu, Me.ExecuteMenu})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(596, 32)
        Me.Menu.TabIndex = 1
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
        'plantsDGV
        '
        Me.plantsDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.plantsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.plantsDGV.Location = New System.Drawing.Point(14, 86)
        Me.plantsDGV.Name = "plantsDGV"
        Me.plantsDGV.Size = New System.Drawing.Size(570, 451)
        Me.plantsDGV.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(402, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search:"
        '
        'plantTb
        '
        Me.plantTb.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plantTb.ForeColor = System.Drawing.Color.MidnightBlue
        Me.plantTb.Location = New System.Drawing.Point(463, 46)
        Me.plantTb.Name = "plantTb"
        Me.plantTb.Size = New System.Drawing.Size(120, 31)
        Me.plantTb.TabIndex = 4
        '
        'PlantsAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(596, 549)
        Me.Controls.Add(Me.plantTb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.plantsDGV)
        Me.Controls.Add(Me.Menu)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PlantsAdministration"
        Me.Text = "Plants administration"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.plantsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Menu As MenuStrip
    Friend WithEvents SaveMenu As ToolStripMenuItem
    Friend WithEvents ExecuteMenu As ToolStripMenuItem
    Friend WithEvents plantsDGV As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents plantTb As TextBox
End Class
