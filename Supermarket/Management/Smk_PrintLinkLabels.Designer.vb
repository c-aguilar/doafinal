<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_PrintLinkLabels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_PrintLinkLabels))
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(72, 53)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(118, 20)
        Me.Partnumber_txt.TabIndex = 83
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 18)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Numero de Serie"
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(77, 86)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(130, 40)
        Me.Save_btn.TabIndex = 84
        Me.Save_btn.Text = "Imprimir"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(284, 25)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Reimprimir Etiqueta de Enlace"
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(65, 59)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(155, 20)
        Me.Serial_txt.TabIndex = 88
        '
        'Smk_PrintLinkLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 138)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Save_btn)
        Me.Name = "Smk_PrintLinkLabels"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
End Class
