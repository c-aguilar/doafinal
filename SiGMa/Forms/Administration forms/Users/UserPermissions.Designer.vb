<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserPermissions))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.userCB = New System.Windows.Forms.ComboBox()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.permissionsDGV = New System.Windows.Forms.DataGridView()
        Me.isActiveChB = New System.Windows.Forms.CheckBox()
        CType(Me.permissionsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Logon ID:"
        '
        'userCB
        '
        Me.userCB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.userCB.FormattingEnabled = True
        Me.userCB.Location = New System.Drawing.Point(94, 15)
        Me.userCB.Margin = New System.Windows.Forms.Padding(4)
        Me.userCB.Name = "userCB"
        Me.userCB.Size = New System.Drawing.Size(237, 31)
        Me.userCB.TabIndex = 1
        '
        'saveBtn
        '
        Me.saveBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.saveBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.saveBtn.Location = New System.Drawing.Point(491, 15)
        Me.saveBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(65, 33)
        Me.saveBtn.TabIndex = 3
        Me.saveBtn.Text = "Save"
        Me.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.saveBtn.UseVisualStyleBackColor = False
        '
        'permissionsDGV
        '
        Me.permissionsDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.permissionsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.permissionsDGV.Location = New System.Drawing.Point(12, 61)
        Me.permissionsDGV.Name = "permissionsDGV"
        Me.permissionsDGV.Size = New System.Drawing.Size(577, 387)
        Me.permissionsDGV.TabIndex = 4
        '
        'isActiveChB
        '
        Me.isActiveChB.AutoSize = True
        Me.isActiveChB.Location = New System.Drawing.Point(373, 18)
        Me.isActiveChB.Margin = New System.Windows.Forms.Padding(4)
        Me.isActiveChB.Name = "isActiveChB"
        Me.isActiveChB.Size = New System.Drawing.Size(100, 27)
        Me.isActiveChB.TabIndex = 2
        Me.isActiveChB.Text = "Active"
        Me.isActiveChB.UseVisualStyleBackColor = True
        '
        'UserPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(601, 458)
        Me.Controls.Add(Me.permissionsDGV)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.isActiveChB)
        Me.Controls.Add(Me.userCB)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UserPermissions"
        Me.Text = "User permissions"
        CType(Me.permissionsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents userCB As ComboBox
    Friend WithEvents saveBtn As Button
    Friend WithEvents permissionsDGV As DataGridView
    Friend WithEvents isActiveChB As CheckBox
End Class
