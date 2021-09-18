<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QLY_NewAlert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QLY_NewAlert))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Reason_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Cross_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(378, 25)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Nueva Alerta"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(107, 34)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 26)
        Me.Partnumber_txt.TabIndex = 93
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "No. Parte Aptiv:"
        '
        'Reason_txt
        '
        Me.Reason_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Reason_txt.Location = New System.Drawing.Point(107, 66)
        Me.Reason_txt.MaxLength = 200
        Me.Reason_txt.Multiline = True
        Me.Reason_txt.Name = "Reason_txt"
        Me.Reason_txt.Size = New System.Drawing.Size(260, 158)
        Me.Reason_txt.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Motivo:"
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(266, 230)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 97
        Me.Save_btn.Text = "Crear"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Cross_btn
        '
        Me.Cross_btn.Image = CType(resources.GetObject("Cross_btn.Image"), System.Drawing.Image)
        Me.Cross_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cross_btn.Location = New System.Drawing.Point(214, 34)
        Me.Cross_btn.Name = "Cross_btn"
        Me.Cross_btn.Size = New System.Drawing.Size(66, 25)
        Me.Cross_btn.TabIndex = 98
        Me.Cross_btn.Text = "Buscar"
        Me.Cross_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cross_btn.UseVisualStyleBackColor = True
        '
        'QLY_NewAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 264)
        Me.Controls.Add(Me.Cross_btn)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Reason_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label7)
        Me.Name = "QLY_NewAlert"
        Me.ShowIcon = False
        Me.Text = "Quality"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Reason_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Cross_btn As System.Windows.Forms.Button
End Class
