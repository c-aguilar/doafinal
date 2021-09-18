<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZPLPrinterSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZPLPrinterSettings))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Resolution_cbo = New System.Windows.Forms.ComboBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Printer_txt = New System.Windows.Forms.TextBox()
        Me.Printer_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Resolución de impresora:"
        '
        'Resolution_cbo
        '
        Me.Resolution_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Resolution_cbo.FormattingEnabled = True
        Me.Resolution_cbo.Items.AddRange(New Object() {"300", "200"})
        Me.Resolution_cbo.Location = New System.Drawing.Point(157, 43)
        Me.Resolution_cbo.Name = "Resolution_cbo"
        Me.Resolution_cbo.Size = New System.Drawing.Size(102, 21)
        Me.Resolution_cbo.TabIndex = 36
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(163, 70)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(96, 23)
        Me.Save_btn.TabIndex = 39
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(31, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Impresora:"
        '
        'Printer_txt
        '
        Me.Printer_txt.Location = New System.Drawing.Point(93, 17)
        Me.Printer_txt.Name = "Printer_txt"
        Me.Printer_txt.Size = New System.Drawing.Size(136, 20)
        Me.Printer_txt.TabIndex = 41
        '
        'Printer_btn
        '
        Me.Printer_btn.Image = CType(resources.GetObject("Printer_btn.Image"), System.Drawing.Image)
        Me.Printer_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Printer_btn.Location = New System.Drawing.Point(235, 15)
        Me.Printer_btn.Name = "Printer_btn"
        Me.Printer_btn.Size = New System.Drawing.Size(24, 23)
        Me.Printer_btn.TabIndex = 42
        Me.Printer_btn.UseVisualStyleBackColor = True
        '
        'ZPLPrinterSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 106)
        Me.Controls.Add(Me.Printer_btn)
        Me.Controls.Add(Me.Printer_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Resolution_cbo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ZPLPrinterSettings"
        Me.ShowIcon = False
        Me.Text = "Configuración de Impresora ZPL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Resolution_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Printer_txt As System.Windows.Forms.TextBox
    Friend WithEvents Printer_btn As System.Windows.Forms.Button
End Class
