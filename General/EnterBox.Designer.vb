<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnterBox))
        Me.Answer_txt = New System.Windows.Forms.TextBox()
        Me.Question_lbl = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Answer_txt
        '
        Me.Answer_txt.Location = New System.Drawing.Point(12, 25)
        Me.Answer_txt.Multiline = True
        Me.Answer_txt.Name = "Answer_txt"
        Me.Answer_txt.Size = New System.Drawing.Size(311, 99)
        Me.Answer_txt.TabIndex = 0
        '
        'Question_lbl
        '
        Me.Question_lbl.AutoSize = True
        Me.Question_lbl.Location = New System.Drawing.Point(12, 9)
        Me.Question_lbl.Name = "Question_lbl"
        Me.Question_lbl.Size = New System.Drawing.Size(52, 13)
        Me.Question_lbl.TabIndex = 1
        Me.Question_lbl.Text = "Question:"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(223, 130)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 13
        Me.Cancel_btn.Text = "&Cancel"
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'OK_btn
        '
        Me.OK_btn.BackColor = System.Drawing.SystemColors.Control
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(120, 130)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 12
        Me.OK_btn.Text = "&OK"
        Me.OK_btn.UseVisualStyleBackColor = False
        '
        'EnterBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 161)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.Question_lbl)
        Me.Controls.Add(Me.Answer_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EnterBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EnterBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Answer_txt As System.Windows.Forms.TextBox
    Friend WithEvents Question_lbl As System.Windows.Forms.Label
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents OK_btn As System.Windows.Forms.Button
End Class
