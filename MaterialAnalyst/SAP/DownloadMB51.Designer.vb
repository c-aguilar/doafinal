<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadMB51
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadMB51))
        Me.DownloadMB51_Sloc_cbo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DownloadMB51_MovType_cbo = New System.Windows.Forms.ComboBox()
        Me.DownloadMB51_To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DownloadMB51_Run_btn = New System.Windows.Forms.Button()
        Me.DownloadMB51_From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DownloadMB51_Sloc_cbo
        '
        Me.DownloadMB51_Sloc_cbo.FormattingEnabled = True
        Me.DownloadMB51_Sloc_cbo.Items.AddRange(New Object() {"0001", "0007", "0002", "0009", "0006"})
        Me.DownloadMB51_Sloc_cbo.Location = New System.Drawing.Point(121, 63)
        Me.DownloadMB51_Sloc_cbo.Name = "DownloadMB51_Sloc_cbo"
        Me.DownloadMB51_Sloc_cbo.Size = New System.Drawing.Size(100, 21)
        Me.DownloadMB51_Sloc_cbo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sloc:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo de Movimiento:"
        '
        'DownloadMB51_MovType_cbo
        '
        Me.DownloadMB51_MovType_cbo.FormattingEnabled = True
        Me.DownloadMB51_MovType_cbo.Items.AddRange(New Object() {"Z11", "261", "262", "101", "102", "701", "702", "309", "901", "343", "344", "657", "933", "934", "131", "132", "641", "642", "601", "*"})
        Me.DownloadMB51_MovType_cbo.Location = New System.Drawing.Point(121, 90)
        Me.DownloadMB51_MovType_cbo.Name = "DownloadMB51_MovType_cbo"
        Me.DownloadMB51_MovType_cbo.Size = New System.Drawing.Size(100, 21)
        Me.DownloadMB51_MovType_cbo.TabIndex = 2
        '
        'DownloadMB51_To_dtp
        '
        Me.DownloadMB51_To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DownloadMB51_To_dtp.Location = New System.Drawing.Point(121, 143)
        Me.DownloadMB51_To_dtp.Name = "DownloadMB51_To_dtp"
        Me.DownloadMB51_To_dtp.Size = New System.Drawing.Size(100, 20)
        Me.DownloadMB51_To_dtp.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(342, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descargar Movimientos desde SAP"
        '
        'DownloadMB51_Run_btn
        '
        Me.DownloadMB51_Run_btn.Image = CType(resources.GetObject("DownloadMB51_Run_btn.Image"), System.Drawing.Image)
        Me.DownloadMB51_Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DownloadMB51_Run_btn.Location = New System.Drawing.Point(121, 169)
        Me.DownloadMB51_Run_btn.Name = "DownloadMB51_Run_btn"
        Me.DownloadMB51_Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.DownloadMB51_Run_btn.TabIndex = 13
        Me.DownloadMB51_Run_btn.Text = "Ejecutar"
        Me.DownloadMB51_Run_btn.UseVisualStyleBackColor = True
        '
        'DownloadMB51_From_dtp
        '
        Me.DownloadMB51_From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DownloadMB51_From_dtp.Location = New System.Drawing.Point(121, 117)
        Me.DownloadMB51_From_dtp.Name = "DownloadMB51_From_dtp"
        Me.DownloadMB51_From_dtp.Size = New System.Drawing.Size(100, 20)
        Me.DownloadMB51_From_dtp.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(77, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Hasta:"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(121, 37)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(100, 20)
        Me.Partnumber_txt.TabIndex = 17
        Me.Partnumber_txt.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "No. de Parte:"
        '
        'DownloadMB51
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 203)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DownloadMB51_From_dtp)
        Me.Controls.Add(Me.DownloadMB51_Run_btn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DownloadMB51_To_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DownloadMB51_MovType_cbo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DownloadMB51_Sloc_cbo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DownloadMB51"
        Me.Text = "Material Analyst"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DownloadMB51_Sloc_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DownloadMB51_MovType_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents DownloadMB51_To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DownloadMB51_Run_btn As System.Windows.Forms.Button
    Friend WithEvents DownloadMB51_From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
