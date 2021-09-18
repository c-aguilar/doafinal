<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ReportCriticalToReceiving
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumber_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Actives_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transporter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delivery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cancel_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Add_btn = New System.Windows.Forms.Button()
        Me.Area_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Plates_txt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Delivery_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Transporter_txt = New System.Windows.Forms.TextBox()
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(91, 31)
        Me.Partnumber_txt.Mask = "AAAAAAAA"
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 21)
        Me.Partnumber_txt.TabIndex = 1
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Partnumber_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "No. de Parte:"
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Comment_txt.Location = New System.Drawing.Point(91, 110)
        Me.Comment_txt.MaxLength = 150
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(419, 38)
        Me.Comment_txt.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Comentario:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(909, 25)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Reportar Numero de Parte Critico"
        '
        'Actives_dgv
        '
        Me.Actives_dgv.AllowColumnHiding = True
        Me.Actives_dgv.AllowUserToAddRows = False
        Me.Actives_dgv.AllowUserToDeleteRows = False
        Me.Actives_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Actives_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Actives_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Partnumber, Me.Area, Me.Plates, Me.Transporter, Me.Delivery, Me.Comment, Me.Date_, Me.Fullname, Me.Username, Me.cancel_btn})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Actives_dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.Actives_dgv.Location = New System.Drawing.Point(4, 154)
        Me.Actives_dgv.Name = "Actives_dgv"
        Me.Actives_dgv.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actives_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Actives_dgv.ShowRowNumber = True
        Me.Actives_dgv.Size = New System.Drawing.Size(901, 378)
        Me.Actives_dgv.TabIndex = 8
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 80
        '
        'Area
        '
        Me.Area.DataPropertyName = "Area"
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        Me.Area.Width = 110
        '
        'Plates
        '
        Me.Plates.HeaderText = "Placas/Troca"
        Me.Plates.Name = "Plates"
        Me.Plates.ReadOnly = True
        Me.Plates.Width = 90
        '
        'Transporter
        '
        Me.Transporter.HeaderText = "Transportista"
        Me.Transporter.Name = "Transporter"
        Me.Transporter.ReadOnly = True
        Me.Transporter.Width = 90
        '
        'Delivery
        '
        Me.Delivery.HeaderText = "Delivery"
        Me.Delivery.Name = "Delivery"
        Me.Delivery.ReadOnly = True
        Me.Delivery.Width = 90
        '
        'Comment
        '
        Me.Comment.DataPropertyName = "Comment"
        Me.Comment.HeaderText = "Comentario"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        Me.Comment.Width = 150
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle3.Format = "g"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle3
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 90
        '
        'Fullname
        '
        Me.Fullname.DataPropertyName = "Fullname"
        Me.Fullname.HeaderText = "Reportado por"
        Me.Fullname.Name = "Fullname"
        Me.Fullname.ReadOnly = True
        '
        'Username
        '
        Me.Username.DataPropertyName = "Username"
        Me.Username.HeaderText = "Username"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        Me.Username.Visible = False
        '
        'cancel_btn
        '
        Me.cancel_btn.DefaultImage = Nothing
        Me.cancel_btn.DefaultText = ""
        Me.cancel_btn.HeaderText = ""
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.ReadOnly = True
        Me.cancel_btn.Width = 40
        '
        'Add_btn
        '
        Me.Add_btn.Image = Global.Delta_ERP.My.Resources.Resources.add_16
        Me.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_btn.Location = New System.Drawing.Point(516, 123)
        Me.Add_btn.Name = "Add_btn"
        Me.Add_btn.Size = New System.Drawing.Size(100, 25)
        Me.Add_btn.TabIndex = 7
        Me.Add_btn.Text = "Agregar"
        Me.Add_btn.UseVisualStyleBackColor = True
        '
        'Area_txt
        '
        Me.Area_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Area_txt.Location = New System.Drawing.Point(342, 87)
        Me.Area_txt.MaxLength = 20
        Me.Area_txt.Name = "Area_txt"
        Me.Area_txt.Size = New System.Drawing.Size(168, 20)
        Me.Area_txt.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(304, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Area:"
        '
        'Plates_txt
        '
        Me.Plates_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Plates_txt.Location = New System.Drawing.Point(91, 58)
        Me.Plates_txt.MaxLength = 20
        Me.Plates_txt.Name = "Plates_txt"
        Me.Plates_txt.Size = New System.Drawing.Size(168, 20)
        Me.Plates_txt.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Placas/Troca:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Delivery:"
        '
        'Delivery_txt
        '
        Me.Delivery_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Delivery_txt.Location = New System.Drawing.Point(91, 84)
        Me.Delivery_txt.MaxLength = 20
        Me.Delivery_txt.Name = "Delivery_txt"
        Me.Delivery_txt.Size = New System.Drawing.Size(168, 20)
        Me.Delivery_txt.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Transportista:"
        '
        'Transporter_txt
        '
        Me.Transporter_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Transporter_txt.Location = New System.Drawing.Point(342, 58)
        Me.Transporter_txt.MaxLength = 20
        Me.Transporter_txt.Name = "Transporter_txt"
        Me.Transporter_txt.Size = New System.Drawing.Size(168, 20)
        Me.Transporter_txt.TabIndex = 3
        '
        'Ord_ReportCriticalToReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 536)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Transporter_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Delivery_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Plates_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Area_txt)
        Me.Controls.Add(Me.Add_btn)
        Me.Controls.Add(Me.Actives_dgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Name = "Ord_ReportCriticalToReceiving"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Actives_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Actives_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Add_btn As System.Windows.Forms.Button
    Friend WithEvents Area_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Plates_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Delivery_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Transporter_txt As System.Windows.Forms.TextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plates As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transporter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cancel_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
