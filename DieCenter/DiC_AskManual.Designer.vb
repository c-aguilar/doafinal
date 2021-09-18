<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiC_AskManual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiC_AskManual))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DieCenter_cbo = New System.Windows.Forms.ComboBox()
        Me.Pick_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Centro de dados:"
        '
        'DieCenter_cbo
        '
        Me.DieCenter_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DieCenter_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DieCenter_cbo.FormattingEnabled = True
        Me.DieCenter_cbo.Location = New System.Drawing.Point(110, 72)
        Me.DieCenter_cbo.Name = "DieCenter_cbo"
        Me.DieCenter_cbo.Size = New System.Drawing.Size(158, 26)
        Me.DieCenter_cbo.TabIndex = 42
        '
        'Pick_btn
        '
        Me.Pick_btn.Image = CType(resources.GetObject("Pick_btn.Image"), System.Drawing.Image)
        Me.Pick_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Pick_btn.Location = New System.Drawing.Point(92, 140)
        Me.Pick_btn.Name = "Pick_btn"
        Me.Pick_btn.Size = New System.Drawing.Size(100, 25)
        Me.Pick_btn.TabIndex = 41
        Me.Pick_btn.Text = "Capturar"
        Me.Pick_btn.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(284, 25)
        Me.lblTitle.TabIndex = 40
        Me.lblTitle.Text = "Captura Manual de Picklist"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(110, 40)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 26)
        Me.Partnumber_txt.TabIndex = 93
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "No. de Parte:"
        '
        'DiC_AskManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 177)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DieCenter_cbo)
        Me.Controls.Add(Me.Pick_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "DiC_AskManual"
        Me.ShowIcon = False
        Me.Text = "Die Center"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DieCenter_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Pick_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
