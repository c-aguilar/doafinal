<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConditionSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConditionSelector))
        Me.Equal_btn = New System.Windows.Forms.Button()
        Me.Equal_lbl = New System.Windows.Forms.Label()
        Me.NotEqual_lbl = New System.Windows.Forms.Label()
        Me.NotEqual_btn = New System.Windows.Forms.Button()
        Me.Greater_lbl = New System.Windows.Forms.Label()
        Me.Greater_btn = New System.Windows.Forms.Button()
        Me.GreaterEqual_lbl = New System.Windows.Forms.Label()
        Me.GreaterEqual_btn = New System.Windows.Forms.Button()
        Me.Minor_lbl = New System.Windows.Forms.Label()
        Me.Minor_btn = New System.Windows.Forms.Button()
        Me.MinorEqual_lbl = New System.Windows.Forms.Label()
        Me.MinorEqual_btn = New System.Windows.Forms.Button()
        Me.In_lbl = New System.Windows.Forms.Label()
        Me.In_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Equal_btn
        '
        Me.Equal_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Equal_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Equal_btn.FlatAppearance.BorderSize = 0
        Me.Equal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Equal_btn.Image = CType(resources.GetObject("Equal_btn.Image"), System.Drawing.Image)
        Me.Equal_btn.Location = New System.Drawing.Point(6, 6)
        Me.Equal_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Equal_btn.Name = "Equal_btn"
        Me.Equal_btn.Size = New System.Drawing.Size(21, 21)
        Me.Equal_btn.TabIndex = 13
        Me.Equal_btn.UseVisualStyleBackColor = True
        '
        'Equal_lbl
        '
        Me.Equal_lbl.AutoSize = True
        Me.Equal_lbl.Location = New System.Drawing.Point(33, 10)
        Me.Equal_lbl.Name = "Equal_lbl"
        Me.Equal_lbl.Size = New System.Drawing.Size(30, 13)
        Me.Equal_lbl.TabIndex = 14
        Me.Equal_lbl.Text = "Igual"
        '
        'NotEqual_lbl
        '
        Me.NotEqual_lbl.AutoSize = True
        Me.NotEqual_lbl.Location = New System.Drawing.Point(33, 37)
        Me.NotEqual_lbl.Name = "NotEqual_lbl"
        Me.NotEqual_lbl.Size = New System.Drawing.Size(50, 13)
        Me.NotEqual_lbl.TabIndex = 16
        Me.NotEqual_lbl.Text = "Diferente"
        '
        'NotEqual_btn
        '
        Me.NotEqual_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NotEqual_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NotEqual_btn.FlatAppearance.BorderSize = 0
        Me.NotEqual_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NotEqual_btn.Image = CType(resources.GetObject("NotEqual_btn.Image"), System.Drawing.Image)
        Me.NotEqual_btn.Location = New System.Drawing.Point(6, 33)
        Me.NotEqual_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.NotEqual_btn.Name = "NotEqual_btn"
        Me.NotEqual_btn.Size = New System.Drawing.Size(21, 21)
        Me.NotEqual_btn.TabIndex = 15
        Me.NotEqual_btn.UseVisualStyleBackColor = True
        '
        'Greater_lbl
        '
        Me.Greater_lbl.AutoSize = True
        Me.Greater_lbl.Location = New System.Drawing.Point(33, 64)
        Me.Greater_lbl.Name = "Greater_lbl"
        Me.Greater_lbl.Size = New System.Drawing.Size(57, 13)
        Me.Greater_lbl.TabIndex = 18
        Me.Greater_lbl.Text = "Mayor que"
        '
        'Greater_btn
        '
        Me.Greater_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Greater_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Greater_btn.FlatAppearance.BorderSize = 0
        Me.Greater_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Greater_btn.Image = CType(resources.GetObject("Greater_btn.Image"), System.Drawing.Image)
        Me.Greater_btn.Location = New System.Drawing.Point(6, 60)
        Me.Greater_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Greater_btn.Name = "Greater_btn"
        Me.Greater_btn.Size = New System.Drawing.Size(21, 21)
        Me.Greater_btn.TabIndex = 17
        Me.Greater_btn.UseVisualStyleBackColor = True
        '
        'GreaterEqual_lbl
        '
        Me.GreaterEqual_lbl.AutoSize = True
        Me.GreaterEqual_lbl.Location = New System.Drawing.Point(33, 91)
        Me.GreaterEqual_lbl.Name = "GreaterEqual_lbl"
        Me.GreaterEqual_lbl.Size = New System.Drawing.Size(91, 13)
        Me.GreaterEqual_lbl.TabIndex = 20
        Me.GreaterEqual_lbl.Text = "Mayor o igual que" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GreaterEqual_btn
        '
        Me.GreaterEqual_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GreaterEqual_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GreaterEqual_btn.FlatAppearance.BorderSize = 0
        Me.GreaterEqual_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GreaterEqual_btn.Image = CType(resources.GetObject("GreaterEqual_btn.Image"), System.Drawing.Image)
        Me.GreaterEqual_btn.Location = New System.Drawing.Point(6, 87)
        Me.GreaterEqual_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.GreaterEqual_btn.Name = "GreaterEqual_btn"
        Me.GreaterEqual_btn.Size = New System.Drawing.Size(21, 21)
        Me.GreaterEqual_btn.TabIndex = 19
        Me.GreaterEqual_btn.UseVisualStyleBackColor = True
        '
        'Minor_lbl
        '
        Me.Minor_lbl.AutoSize = True
        Me.Minor_lbl.Location = New System.Drawing.Point(33, 118)
        Me.Minor_lbl.Name = "Minor_lbl"
        Me.Minor_lbl.Size = New System.Drawing.Size(58, 13)
        Me.Minor_lbl.TabIndex = 22
        Me.Minor_lbl.Text = "Menor que"
        '
        'Minor_btn
        '
        Me.Minor_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Minor_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Minor_btn.FlatAppearance.BorderSize = 0
        Me.Minor_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Minor_btn.Image = CType(resources.GetObject("Minor_btn.Image"), System.Drawing.Image)
        Me.Minor_btn.Location = New System.Drawing.Point(6, 114)
        Me.Minor_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Minor_btn.Name = "Minor_btn"
        Me.Minor_btn.Size = New System.Drawing.Size(21, 21)
        Me.Minor_btn.TabIndex = 21
        Me.Minor_btn.UseVisualStyleBackColor = True
        '
        'MinorEqual_lbl
        '
        Me.MinorEqual_lbl.AutoSize = True
        Me.MinorEqual_lbl.Location = New System.Drawing.Point(33, 145)
        Me.MinorEqual_lbl.Name = "MinorEqual_lbl"
        Me.MinorEqual_lbl.Size = New System.Drawing.Size(92, 13)
        Me.MinorEqual_lbl.TabIndex = 24
        Me.MinorEqual_lbl.Text = "Menor o igual que"
        '
        'MinorEqual_btn
        '
        Me.MinorEqual_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MinorEqual_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MinorEqual_btn.FlatAppearance.BorderSize = 0
        Me.MinorEqual_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MinorEqual_btn.Image = CType(resources.GetObject("MinorEqual_btn.Image"), System.Drawing.Image)
        Me.MinorEqual_btn.Location = New System.Drawing.Point(6, 141)
        Me.MinorEqual_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.MinorEqual_btn.Name = "MinorEqual_btn"
        Me.MinorEqual_btn.Size = New System.Drawing.Size(21, 21)
        Me.MinorEqual_btn.TabIndex = 23
        Me.MinorEqual_btn.UseVisualStyleBackColor = True
        '
        'In_lbl
        '
        Me.In_lbl.AutoSize = True
        Me.In_lbl.Location = New System.Drawing.Point(33, 172)
        Me.In_lbl.Name = "In_lbl"
        Me.In_lbl.Size = New System.Drawing.Size(63, 13)
        Me.In_lbl.TabIndex = 26
        Me.In_lbl.Text = "Dentro de..."
        '
        'In_btn
        '
        Me.In_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.In_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.In_btn.FlatAppearance.BorderSize = 0
        Me.In_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.In_btn.Image = CType(resources.GetObject("In_btn.Image"), System.Drawing.Image)
        Me.In_btn.Location = New System.Drawing.Point(6, 168)
        Me.In_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.In_btn.Name = "In_btn"
        Me.In_btn.Size = New System.Drawing.Size(21, 21)
        Me.In_btn.TabIndex = 25
        Me.In_btn.UseVisualStyleBackColor = True
        '
        'ConditionSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(130, 197)
        Me.Controls.Add(Me.In_lbl)
        Me.Controls.Add(Me.In_btn)
        Me.Controls.Add(Me.MinorEqual_lbl)
        Me.Controls.Add(Me.MinorEqual_btn)
        Me.Controls.Add(Me.Minor_lbl)
        Me.Controls.Add(Me.Minor_btn)
        Me.Controls.Add(Me.GreaterEqual_lbl)
        Me.Controls.Add(Me.GreaterEqual_btn)
        Me.Controls.Add(Me.Greater_lbl)
        Me.Controls.Add(Me.Greater_btn)
        Me.Controls.Add(Me.NotEqual_lbl)
        Me.Controls.Add(Me.NotEqual_btn)
        Me.Controls.Add(Me.Equal_lbl)
        Me.Controls.Add(Me.Equal_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConditionSelector"
        Me.Text = "Condicion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Equal_btn As System.Windows.Forms.Button
    Friend WithEvents Equal_lbl As System.Windows.Forms.Label
    Friend WithEvents NotEqual_lbl As System.Windows.Forms.Label
    Friend WithEvents NotEqual_btn As System.Windows.Forms.Button
    Friend WithEvents Greater_lbl As System.Windows.Forms.Label
    Friend WithEvents Greater_btn As System.Windows.Forms.Button
    Friend WithEvents GreaterEqual_lbl As System.Windows.Forms.Label
    Friend WithEvents GreaterEqual_btn As System.Windows.Forms.Button
    Friend WithEvents Minor_lbl As System.Windows.Forms.Label
    Friend WithEvents Minor_btn As System.Windows.Forms.Button
    Friend WithEvents MinorEqual_lbl As System.Windows.Forms.Label
    Friend WithEvents MinorEqual_btn As System.Windows.Forms.Button
    Friend WithEvents In_lbl As System.Windows.Forms.Label
    Friend WithEvents In_btn As System.Windows.Forms.Button
End Class
