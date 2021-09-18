<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_BusinessScheduledChanges
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Actives_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Change_ID_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Business_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Partnumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_NewPartnumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Date_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Fullname_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Username_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Change_Cancel_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Business_cbo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewPartnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Date_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(95, 58)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 21)
        Me.Partnumber_txt.TabIndex = 2
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "No. de Parte:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(653, 25)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Cambios Programados por Negocio"
        '
        'Actives_dgv
        '
        Me.Actives_dgv.AllowColumnHiding = True
        Me.Actives_dgv.AllowUserToAddRows = False
        Me.Actives_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Actives_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Actives_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Actives_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Actives_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Actives_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Change_ID_col, Me.Change_Business_col, Me.Change_Partnumber_col, Me.Change_NewPartnumber_col, Me.Change_Date_col, Me.Change_Fullname_col, Me.Change_Username_col, Me.Change_Cancel_btn})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Actives_dgv.DefaultCellStyle = DataGridViewCellStyle5
        Me.Actives_dgv.DefaultRowFilter = Nothing
        Me.Actives_dgv.EnableHeadersVisualStyles = False
        Me.Actives_dgv.Location = New System.Drawing.Point(4, 88)
        Me.Actives_dgv.Name = "Actives_dgv"
        Me.Actives_dgv.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Actives_dgv.ShowRowNumber = True
        Me.Actives_dgv.Size = New System.Drawing.Size(645, 448)
        Me.Actives_dgv.TabIndex = 8
        '
        'Change_ID_col
        '
        Me.Change_ID_col.DataPropertyName = "ID"
        Me.Change_ID_col.HeaderText = "ID"
        Me.Change_ID_col.Name = "Change_ID_col"
        Me.Change_ID_col.ReadOnly = True
        Me.Change_ID_col.Visible = False
        '
        'Change_Business_col
        '
        Me.Change_Business_col.DataPropertyName = "Business"
        Me.Change_Business_col.HeaderText = "Negocio"
        Me.Change_Business_col.Name = "Change_Business_col"
        Me.Change_Business_col.ReadOnly = True
        '
        'Change_Partnumber_col
        '
        Me.Change_Partnumber_col.DataPropertyName = "OldPartnumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Change_Partnumber_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.Change_Partnumber_col.HeaderText = "No. de Parte"
        Me.Change_Partnumber_col.Name = "Change_Partnumber_col"
        Me.Change_Partnumber_col.ReadOnly = True
        Me.Change_Partnumber_col.Width = 80
        '
        'Change_NewPartnumber_col
        '
        Me.Change_NewPartnumber_col.DataPropertyName = "NewPartnumber"
        Me.Change_NewPartnumber_col.HeaderText = "Cambio por"
        Me.Change_NewPartnumber_col.Name = "Change_NewPartnumber_col"
        Me.Change_NewPartnumber_col.ReadOnly = True
        '
        'Change_Date_col
        '
        Me.Change_Date_col.DataPropertyName = "EffectiveDate"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Change_Date_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Change_Date_col.HeaderText = "Fecha Efectiva"
        Me.Change_Date_col.Name = "Change_Date_col"
        Me.Change_Date_col.ReadOnly = True
        Me.Change_Date_col.Width = 90
        '
        'Change_Fullname_col
        '
        Me.Change_Fullname_col.DataPropertyName = "Fullname"
        Me.Change_Fullname_col.HeaderText = "Agregado por"
        Me.Change_Fullname_col.Name = "Change_Fullname_col"
        Me.Change_Fullname_col.ReadOnly = True
        '
        'Change_Username_col
        '
        Me.Change_Username_col.DataPropertyName = "Username"
        Me.Change_Username_col.HeaderText = "Username"
        Me.Change_Username_col.Name = "Change_Username_col"
        Me.Change_Username_col.ReadOnly = True
        Me.Change_Username_col.Visible = False
        '
        'Change_Cancel_btn
        '
        Me.Change_Cancel_btn.DefaultImage = Nothing
        Me.Change_Cancel_btn.DefaultText = ""
        Me.Change_Cancel_btn.HeaderText = ""
        Me.Change_Cancel_btn.Name = "Change_Cancel_btn"
        Me.Change_Cancel_btn.ReadOnly = True
        Me.Change_Cancel_btn.Width = 40
        '
        'Add_btn
        '
        Me.Add_btn.Image = Global.Delta_ERP.My.Resources.Resources.add_16
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(477, 57)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(101, 25)
        Me.Add_btn.TabIndex = 5
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Business_cbo
        '
        Me.Business_cbo.BackColor = System.Drawing.Color.Ivory
        Me.Business_cbo.FormattingEnabled = True
        Me.Business_cbo.Location = New System.Drawing.Point(95, 33)
        Me.Business_cbo.Name = "Business_cbo"
        Me.Business_cbo.Size = New System.Drawing.Size(287, 21)
        Me.Business_cbo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "cambia por:"
        '
        'NewPartnumber_txt
        '
        Me.NewPartnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.NewPartnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewPartnumber_txt.Location = New System.Drawing.Point(281, 58)
        Me.NewPartnumber_txt.Mask = "AAAAAAAA"
        Me.NewPartnumber_txt.Name = "NewPartnumber_txt"
        Me.NewPartnumber_txt.Size = New System.Drawing.Size(101, 21)
        Me.NewPartnumber_txt.TabIndex = 3
        Me.NewPartnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NewPartnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Negocio:"
        '
        'Date_dtp
        '
        Me.Date_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_dtp.Location = New System.Drawing.Point(477, 34)
        Me.Date_dtp.Name = "Date_dtp"
        Me.Date_dtp.Size = New System.Drawing.Size(101, 20)
        Me.Date_dtp.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(390, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Fecha efectiva:"
        '
        'CR_BusinessScheduledChanges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 540)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Date_dtp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NewPartnumber_txt)
        Me.Controls.Add(Me.Business_cbo)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Actives_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Name = "CR_BusinessScheduledChanges"
        Me.ShowIcon = False
        Me.Text = "Component Readiness"
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Actives_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Business_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewPartnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Change_ID_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Business_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Partnumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_NewPartnumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Date_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Fullname_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Username_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Change_Cancel_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
