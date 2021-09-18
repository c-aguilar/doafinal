<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_DeleteLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_DeleteLabel))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Delete_btn = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Serialnumber_rb = New System.Windows.Forms.RadioButton()
        Me.DateRange_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Range_rb = New System.Windows.Forms.RadioButton()
        Me.RangeA_txt = New System.Windows.Forms.TextBox()
        Me.Range2_txt = New System.Windows.Forms.TextBox()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(880, 25)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Eliminar Etiqueta"
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(17, 51)
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(191, 24)
        Me.Serial_txt.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(412, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Desde:"
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.From_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.From_dtp.Location = New System.Drawing.Point(459, 47)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(125, 21)
        Me.From_dtp.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(412, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Hasta:"
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.To_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.To_dtp.Location = New System.Drawing.Point(459, 69)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(125, 21)
        Me.To_dtp.TabIndex = 90
        '
        'Delete_btn
        '
        Me.Delete_btn.Image = CType(resources.GetObject("Delete_btn.Image"), System.Drawing.Image)
        Me.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete_btn.Location = New System.Drawing.Point(644, 87)
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.Size = New System.Drawing.Size(100, 25)
        Me.Delete_btn.TabIndex = 95
        Me.Delete_btn.Text = "Eliminar"
        Me.Delete_btn.UseVisualStyleBackColor = True
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(598, 51)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(156, 24)
        Me.Partnumber_txt.TabIndex = 94
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(768, 45)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(100, 25)
        Me.Find_btn.TabIndex = 96
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowColumnHiding = True
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        Me.Serials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serials_dgv.Location = New System.Drawing.Point(7, 115)
        Me.Serials_dgv.Name = "Serials_dgv"
        Me.Serials_dgv.ShowRowNumber = True
        Me.Serials_dgv.Size = New System.Drawing.Size(866, 357)
        Me.Serials_dgv.TabIndex = 99
        '
        'Serialnumber_rb
        '
        Me.Serialnumber_rb.AutoSize = True
        Me.Serialnumber_rb.Checked = True
        Me.Serialnumber_rb.Location = New System.Drawing.Point(17, 28)
        Me.Serialnumber_rb.Name = "Serialnumber_rb"
        Me.Serialnumber_rb.Size = New System.Drawing.Size(154, 17)
        Me.Serialnumber_rb.TabIndex = 100
        Me.Serialnumber_rb.TabStop = True
        Me.Serialnumber_rb.Text = "Buscar por numero de serie"
        Me.Serialnumber_rb.UseVisualStyleBackColor = True
        '
        'DateRange_rb
        '
        Me.DateRange_rb.AutoSize = True
        Me.DateRange_rb.Location = New System.Drawing.Point(415, 28)
        Me.DateRange_rb.Name = "DateRange_rb"
        Me.DateRange_rb.Size = New System.Drawing.Size(156, 17)
        Me.DateRange_rb.TabIndex = 101
        Me.DateRange_rb.Text = "Buscar por rango de fechas"
        Me.DateRange_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Location = New System.Drawing.Point(598, 28)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(156, 17)
        Me.Partnumber_rb.TabIndex = 102
        Me.Partnumber_rb.Text = "Buscar por numero de parte"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(750, 92)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 103
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Range_rb
        '
        Me.Range_rb.AutoSize = True
        Me.Range_rb.Location = New System.Drawing.Point(222, 28)
        Me.Range_rb.Name = "Range_rb"
        Me.Range_rb.Size = New System.Drawing.Size(106, 17)
        Me.Range_rb.TabIndex = 105
        Me.Range_rb.Text = "Buscar por rango"
        Me.Range_rb.UseVisualStyleBackColor = True
        '
        'RangeA_txt
        '
        Me.RangeA_txt.BackColor = System.Drawing.Color.LightYellow
        Me.RangeA_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeA_txt.Location = New System.Drawing.Point(222, 51)
        Me.RangeA_txt.Name = "RangeA_txt"
        Me.RangeA_txt.Size = New System.Drawing.Size(86, 24)
        Me.RangeA_txt.TabIndex = 104
        '
        'Range2_txt
        '
        Me.Range2_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Range2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Range2_txt.Location = New System.Drawing.Point(314, 51)
        Me.Range2_txt.Name = "Range2_txt"
        Me.Range2_txt.Size = New System.Drawing.Size(86, 24)
        Me.Range2_txt.TabIndex = 106
        '
        'Rec_DeleteLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 480)
        Me.Controls.Add(Me.Range2_txt)
        Me.Controls.Add(Me.Range_rb)
        Me.Controls.Add(Me.RangeA_txt)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Partnumber_rb)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.DateRange_rb)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.Serialnumber_rb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.Serials_dgv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Delete_btn)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Rec_DeleteLabel"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Delete_btn As System.Windows.Forms.Button
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Serialnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents DateRange_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Range_rb As System.Windows.Forms.RadioButton
    Friend WithEvents RangeA_txt As System.Windows.Forms.TextBox
    Friend WithEvents Range2_txt As System.Windows.Forms.TextBox
End Class
