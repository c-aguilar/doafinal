<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_SmkSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_SmkSettings))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Resolution_cbo = New System.Windows.Forms.ComboBox()
        Me.COM_cbo = New System.Windows.Forms.ComboBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Printer_txt = New System.Windows.Forms.TextBox()
        Me.Printer_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ScaleFactor_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Scale_cbo = New System.Windows.Forms.ComboBox()
        CType(Me.ScaleFactor_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Resolución de impresora:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(31, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Puerto COM Bascula:"
        '
        'Resolution_cbo
        '
        Me.Resolution_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Resolution_cbo.FormattingEnabled = True
        Me.Resolution_cbo.Items.AddRange(New Object() {"300", "200"})
        Me.Resolution_cbo.Location = New System.Drawing.Point(157, 158)
        Me.Resolution_cbo.Name = "Resolution_cbo"
        Me.Resolution_cbo.Size = New System.Drawing.Size(102, 21)
        Me.Resolution_cbo.TabIndex = 36
        '
        'COM_cbo
        '
        Me.COM_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.COM_cbo.FormattingEnabled = True
        Me.COM_cbo.Location = New System.Drawing.Point(157, 49)
        Me.COM_cbo.Name = "COM_cbo"
        Me.COM_cbo.Size = New System.Drawing.Size(102, 21)
        Me.COM_cbo.TabIndex = 35
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(163, 186)
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
        Me.Label3.Location = New System.Drawing.Point(31, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Impresora:"
        '
        'Printer_txt
        '
        Me.Printer_txt.Location = New System.Drawing.Point(93, 132)
        Me.Printer_txt.Name = "Printer_txt"
        Me.Printer_txt.Size = New System.Drawing.Size(136, 20)
        Me.Printer_txt.TabIndex = 41
        '
        'Printer_btn
        '
        Me.Printer_btn.Image = CType(resources.GetObject("Printer_btn.Image"), System.Drawing.Image)
        Me.Printer_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Printer_btn.Location = New System.Drawing.Point(235, 129)
        Me.Printer_btn.Name = "Printer_btn"
        Me.Printer_btn.Size = New System.Drawing.Size(24, 23)
        Me.Printer_btn.TabIndex = 42
        Me.Printer_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(31, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Factor de Conversion:"
        '
        'ScaleFactor_nud
        '
        Me.ScaleFactor_nud.DecimalPlaces = 4
        Me.ScaleFactor_nud.Location = New System.Drawing.Point(157, 76)
        Me.ScaleFactor_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.ScaleFactor_nud.Name = "ScaleFactor_nud"
        Me.ScaleFactor_nud.Size = New System.Drawing.Size(102, 20)
        Me.ScaleFactor_nud.TabIndex = 44
        Me.ScaleFactor_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(31, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Modelo de bascula:"
        '
        'Scale_cbo
        '
        Me.Scale_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Scale_cbo.FormattingEnabled = True
        Me.Scale_cbo.Items.AddRange(New Object() {"Ohaus 3000 Series", "Ohaus Defender 3000", "Ohaus Ranger Count 3000", "Avery Weigh-Tronix ZK840"})
        Me.Scale_cbo.Location = New System.Drawing.Point(157, 22)
        Me.Scale_cbo.Name = "Scale_cbo"
        Me.Scale_cbo.Size = New System.Drawing.Size(102, 21)
        Me.Scale_cbo.TabIndex = 45
        '
        'Smk_SmkSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 225)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Scale_cbo)
        Me.Controls.Add(Me.ScaleFactor_nud)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Printer_btn)
        Me.Controls.Add(Me.Printer_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Resolution_cbo)
        Me.Controls.Add(Me.COM_cbo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Smk_SmkSettings"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.ScaleFactor_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Resolution_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents COM_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Printer_txt As System.Windows.Forms.TextBox
    Friend WithEvents Printer_btn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ScaleFactor_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Scale_cbo As System.Windows.Forms.ComboBox
End Class
