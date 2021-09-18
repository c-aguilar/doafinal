<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_AnswerMixMax
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_AnswerMixMax))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NoPromiseDate_chk = New System.Windows.Forms.CheckBox()
        Me.PromiseDate_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Answer_txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Type_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SelectedPartnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "Fecha promesa:"
        '
        'NoPromiseDate_chk
        '
        Me.NoPromiseDate_chk.AutoSize = True
        Me.NoPromiseDate_chk.Location = New System.Drawing.Point(101, 222)
        Me.NoPromiseDate_chk.Name = "NoPromiseDate_chk"
        Me.NoPromiseDate_chk.Size = New System.Drawing.Size(84, 17)
        Me.NoPromiseDate_chk.TabIndex = 159
        Me.NoPromiseDate_chk.Text = "Sin promesa"
        Me.NoPromiseDate_chk.UseVisualStyleBackColor = True
        '
        'PromiseDate_dtp
        '
        Me.PromiseDate_dtp.CustomFormat = "M/dd/yy HH:mm"
        Me.PromiseDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PromiseDate_dtp.Location = New System.Drawing.Point(101, 196)
        Me.PromiseDate_dtp.Name = "PromiseDate_dtp"
        Me.PromiseDate_dtp.Size = New System.Drawing.Size(117, 20)
        Me.PromiseDate_dtp.TabIndex = 158
        '
        'Answer_txt
        '
        Me.Answer_txt.Location = New System.Drawing.Point(101, 58)
        Me.Answer_txt.MaxLength = 160
        Me.Answer_txt.Multiline = True
        Me.Answer_txt.Name = "Answer_txt"
        Me.Answer_txt.Size = New System.Drawing.Size(209, 132)
        Me.Answer_txt.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "Respuesta:"
        '
        'Type_txt
        '
        Me.Type_txt.Location = New System.Drawing.Point(101, 32)
        Me.Type_txt.Name = "Type_txt"
        Me.Type_txt.ReadOnly = True
        Me.Type_txt.Size = New System.Drawing.Size(117, 20)
        Me.Type_txt.TabIndex = 155
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "Tipo de Alerta:"
        '
        'SelectedPartnumber_txt
        '
        Me.SelectedPartnumber_txt.Location = New System.Drawing.Point(101, 9)
        Me.SelectedPartnumber_txt.Name = "SelectedPartnumber_txt"
        Me.SelectedPartnumber_txt.ReadOnly = True
        Me.SelectedPartnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.SelectedPartnumber_txt.TabIndex = 153
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "No. de Parte:"
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(101, 245)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 151
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Ord_AnswerMixMax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 283)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NoPromiseDate_chk)
        Me.Controls.Add(Me.PromiseDate_dtp)
        Me.Controls.Add(Me.Answer_txt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Type_txt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SelectedPartnumber_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Save_btn)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Ord_AnswerMixMax"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ordering"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NoPromiseDate_chk As System.Windows.Forms.CheckBox
    Friend WithEvents PromiseDate_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Answer_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Type_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SelectedPartnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
End Class
