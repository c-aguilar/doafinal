<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAn_InsertPermit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAn_InsertPermit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Number_txt = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OldPartnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewPartnumber_txt = New System.Windows.Forms.TextBox()
        Me.Issue_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Expiration_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Description_txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Mandatory_rb = New System.Windows.Forms.RadioButton()
        Me.Standar_rb = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Originator_txt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Material_txt = New System.Windows.Forms.TextBox()
        Me.Load_btn = New System.Windows.Forms.Button()
        Me.Partnumbers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Last_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Platform_txt = New System.Windows.Forms.TextBox()
        Me.Main_wb = New System.Windows.Forms.WebBrowser()
        Me.Errors_rtb = New System.Windows.Forms.RichTextBox()
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1077, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Capturar Permiso de Ingeniería"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "No. de Permiso:"
        '
        'Number_txt
        '
        Me.Number_txt.BackColor = System.Drawing.Color.Ivory
        Me.Number_txt.Location = New System.Drawing.Point(111, 39)
        Me.Number_txt.Name = "Number_txt"
        Me.Number_txt.Size = New System.Drawing.Size(100, 20)
        Me.Number_txt.TabIndex = 19
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(485, 672)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 21
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 304)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Comp. Anterior:"
        '
        'OldPartnumber_txt
        '
        Me.OldPartnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.OldPartnumber_txt.Location = New System.Drawing.Point(197, 320)
        Me.OldPartnumber_txt.Name = "OldPartnumber_txt"
        Me.OldPartnumber_txt.Size = New System.Drawing.Size(80, 20)
        Me.OldPartnumber_txt.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Comp. Nuevo:"
        '
        'NewPartnumber_txt
        '
        Me.NewPartnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.NewPartnumber_txt.Location = New System.Drawing.Point(283, 320)
        Me.NewPartnumber_txt.Name = "NewPartnumber_txt"
        Me.NewPartnumber_txt.Size = New System.Drawing.Size(80, 20)
        Me.NewPartnumber_txt.TabIndex = 24
        '
        'Issue_dtp
        '
        Me.Issue_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Issue_dtp.Location = New System.Drawing.Point(111, 91)
        Me.Issue_dtp.Name = "Issue_dtp"
        Me.Issue_dtp.Size = New System.Drawing.Size(100, 20)
        Me.Issue_dtp.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Fecha de Creación:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Fecha de Expiración:"
        '
        'Expiration_dtp
        '
        Me.Expiration_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Expiration_dtp.Location = New System.Drawing.Point(327, 94)
        Me.Expiration_dtp.Name = "Expiration_dtp"
        Me.Expiration_dtp.Size = New System.Drawing.Size(100, 20)
        Me.Expiration_dtp.TabIndex = 28
        '
        'Description_txt
        '
        Me.Description_txt.BackColor = System.Drawing.Color.Ivory
        Me.Description_txt.Location = New System.Drawing.Point(111, 143)
        Me.Description_txt.MaxLength = 5000
        Me.Description_txt.Multiline = True
        Me.Description_txt.Name = "Description_txt"
        Me.Description_txt.Size = New System.Drawing.Size(474, 158)
        Me.Description_txt.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Detalle:"
        '
        'Mandatory_rb
        '
        Me.Mandatory_rb.AutoSize = True
        Me.Mandatory_rb.Location = New System.Drawing.Point(336, 66)
        Me.Mandatory_rb.Name = "Mandatory_rb"
        Me.Mandatory_rb.Size = New System.Drawing.Size(78, 17)
        Me.Mandatory_rb.TabIndex = 32
        Me.Mandatory_rb.Text = "Mandatorio"
        Me.Mandatory_rb.UseVisualStyleBackColor = True
        '
        'Standar_rb
        '
        Me.Standar_rb.AutoSize = True
        Me.Standar_rb.Checked = True
        Me.Standar_rb.Location = New System.Drawing.Point(263, 66)
        Me.Standar_rb.Name = "Standar_rb"
        Me.Standar_rb.Size = New System.Drawing.Size(67, 17)
        Me.Standar_rb.TabIndex = 33
        Me.Standar_rb.TabStop = True
        Me.Standar_rb.Text = "Estandar"
        Me.Standar_rb.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Originador:"
        '
        'Originator_txt
        '
        Me.Originator_txt.BackColor = System.Drawing.Color.Ivory
        Me.Originator_txt.Location = New System.Drawing.Point(111, 65)
        Me.Originator_txt.MaxLength = 50
        Me.Originator_txt.Name = "Originator_txt"
        Me.Originator_txt.Size = New System.Drawing.Size(146, 20)
        Me.Originator_txt.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(108, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Material:"
        '
        'Material_txt
        '
        Me.Material_txt.BackColor = System.Drawing.Color.Ivory
        Me.Material_txt.Location = New System.Drawing.Point(111, 320)
        Me.Material_txt.Name = "Material_txt"
        Me.Material_txt.Size = New System.Drawing.Size(80, 20)
        Me.Material_txt.TabIndex = 36
        '
        'Load_btn
        '
        Me.Load_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Load_btn.Image = CType(resources.GetObject("Load_btn.Image"), System.Drawing.Image)
        Me.Load_btn.Location = New System.Drawing.Point(210, 38)
        Me.Load_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Load_btn.Name = "Load_btn"
        Me.Load_btn.Size = New System.Drawing.Size(23, 23)
        Me.Load_btn.TabIndex = 118
        Me.Load_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Load_btn.UseVisualStyleBackColor = False
        '
        'Partnumbers_dgv
        '
        Me.Partnumbers_dgv.AllowColumnHiding = True
        Me.Partnumbers_dgv.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Partnumbers_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Partnumbers_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Partnumbers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Partnumbers_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Partnumbers_dgv.DefaultRowFilter = Nothing
        Me.Partnumbers_dgv.EnableHeadersVisualStyles = False
        Me.Partnumbers_dgv.Location = New System.Drawing.Point(111, 346)
        Me.Partnumbers_dgv.Name = "Partnumbers_dgv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Partnumbers_dgv.ShowRowNumber = True
        Me.Partnumbers_dgv.Size = New System.Drawing.Size(474, 253)
        Me.Partnumbers_dgv.TabIndex = 119
        '
        'Add_btn
        '
        Me.Add_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Add_btn.Image = CType(resources.GetObject("Add_btn.Image"), System.Drawing.Image)
        Me.Add_btn.Location = New System.Drawing.Point(429, 318)
        Me.Add_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(23, 23)
        Me.Add_btn.TabIndex = 120
        Me.Add_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Add_btn.UseVisualStyleBackColor = False
        '
        'Quantity_nud
        '
        Me.Quantity_nud.Location = New System.Drawing.Point(369, 319)
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(58, 20)
        Me.Quantity_nud.TabIndex = 121
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(366, 303)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 122
        Me.Label10.Text = "Cantidad:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 605)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "Ultimo Ajuste:"
        '
        'Last_dtp
        '
        Me.Last_dtp.CustomFormat = "M/d/yyyy HH:mm"
        Me.Last_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Last_dtp.Location = New System.Drawing.Point(111, 605)
        Me.Last_dtp.Name = "Last_dtp"
        Me.Last_dtp.Size = New System.Drawing.Size(131, 20)
        Me.Last_dtp.TabIndex = 123
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(42, 634)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Comentario:"
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.Ivory
        Me.Comment_txt.Location = New System.Drawing.Point(111, 631)
        Me.Comment_txt.MaxLength = 100
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(474, 35)
        Me.Comment_txt.TabIndex = 125
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(45, 120)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(60, 13)
        Me.Label100.TabIndex = 128
        Me.Label100.Text = "Plataforma:"
        '
        'Platform_txt
        '
        Me.Platform_txt.BackColor = System.Drawing.Color.Ivory
        Me.Platform_txt.Location = New System.Drawing.Point(111, 117)
        Me.Platform_txt.MaxLength = 30
        Me.Platform_txt.Name = "Platform_txt"
        Me.Platform_txt.Size = New System.Drawing.Size(146, 20)
        Me.Platform_txt.TabIndex = 127
        '
        'Main_wb
        '
        Me.Main_wb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_wb.Location = New System.Drawing.Point(591, 38)
        Me.Main_wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Main_wb.Name = "Main_wb"
        Me.Main_wb.Size = New System.Drawing.Size(474, 712)
        Me.Main_wb.TabIndex = 129
        '
        'Errors_rtb
        '
        Me.Errors_rtb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Errors_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Errors_rtb.Location = New System.Drawing.Point(111, 672)
        Me.Errors_rtb.Name = "Errors_rtb"
        Me.Errors_rtb.ReadOnly = True
        Me.Errors_rtb.Size = New System.Drawing.Size(368, 78)
        Me.Errors_rtb.TabIndex = 130
        Me.Errors_rtb.Text = ""
        '
        'MAn_InsertPermit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1077, 742)
        Me.Controls.Add(Me.Errors_rtb)
        Me.Controls.Add(Me.Main_wb)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.Platform_txt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Last_dtp)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Partnumbers_dgv)
        Me.Controls.Add(Me.Load_btn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Material_txt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Originator_txt)
        Me.Controls.Add(Me.Standar_rb)
        Me.Controls.Add(Me.Mandatory_rb)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Description_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Expiration_dtp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Issue_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NewPartnumber_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OldPartnumber_txt)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Number_txt)
        Me.Controls.Add(Me.Label4)
        Me.Name = "MAn_InsertPermit"
        Me.ShowIcon = False
        Me.Text = "Material Analyst"
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Number_txt As System.Windows.Forms.TextBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OldPartnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewPartnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Issue_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Expiration_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Description_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Mandatory_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Standar_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Originator_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Material_txt As System.Windows.Forms.TextBox
    Friend WithEvents Load_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumbers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Last_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Platform_txt As System.Windows.Forms.TextBox
    Friend WithEvents Main_wb As System.Windows.Forms.WebBrowser
    Friend WithEvents Errors_rtb As System.Windows.Forms.RichTextBox
End Class
