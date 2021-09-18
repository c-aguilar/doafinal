<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_TimeSusceptibleMaterial
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_TimeSusceptibleMaterial))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumbers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Items_btn = New System.Windows.Forms.Button()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.print_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Partnumbers_dgv
        '
        Me.Partnumbers_dgv.AllowColumnHiding = True
        Me.Partnumbers_dgv.AllowUserToAddRows = False
        Me.Partnumbers_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Partnumbers_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Partnumbers_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Partnumbers_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Partnumbers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Partnumbers_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partnumber, Me.MaterialType, Me.print_btn})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Partnumbers_dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.Partnumbers_dgv.DefaultRowFilter = Nothing
        Me.Partnumbers_dgv.EnableHeadersVisualStyles = False
        Me.Partnumbers_dgv.Location = New System.Drawing.Point(4, 59)
        Me.Partnumbers_dgv.Name = "Partnumbers_dgv"
        Me.Partnumbers_dgv.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Partnumbers_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Partnumbers_dgv.ShowRowNumber = True
        Me.Partnumbers_dgv.Size = New System.Drawing.Size(959, 397)
        Me.Partnumbers_dgv.TabIndex = 89
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(967, 29)
        Me.ToolStripMain.TabIndex = 116
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(339, 26)
        Me.Title_lbl.Text = "Control de Material Susceptible al Tiempo"
        '
        'Items_btn
        '
        Me.Items_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Items_btn.Image = CType(resources.GetObject("Items_btn.Image"), System.Drawing.Image)
        Me.Items_btn.Location = New System.Drawing.Point(208, 31)
        Me.Items_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Items_btn.Name = "Items_btn"
        Me.Items_btn.Size = New System.Drawing.Size(23, 23)
        Me.Items_btn.TabIndex = 124
        Me.Items_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Items_btn.UseVisualStyleBackColor = False
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Location = New System.Drawing.Point(88, 32)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.Partnumber_txt.TabIndex = 123
        Me.Partnumber_txt.Text = "*"
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(591, 31)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 122
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "No. de Parte:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Desde:"
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.From_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_dtp.Location = New System.Drawing.Point(307, 33)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(115, 20)
        Me.From_dtp.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(428, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "hasta:"
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.To_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.To_dtp.Location = New System.Drawing.Point(470, 33)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(115, 20)
        Me.To_dtp.TabIndex = 119
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Partnumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 80
        '
        'MaterialType
        '
        Me.MaterialType.DataPropertyName = "MaterialType"
        Me.MaterialType.HeaderText = "Tipo"
        Me.MaterialType.Name = "MaterialType"
        Me.MaterialType.ReadOnly = True
        Me.MaterialType.Width = 80
        '
        'print_btn
        '
        Me.print_btn.DefaultImage = Nothing
        Me.print_btn.DefaultText = ""
        Me.print_btn.HeaderText = ""
        Me.print_btn.Name = "print_btn"
        Me.print_btn.ReadOnly = True
        Me.print_btn.Width = 30
        '
        'Smk_TimeSusceptibleMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 461)
        Me.Controls.Add(Me.Items_btn)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Partnumbers_dgv)
        Me.Name = "Smk_TimeSusceptibleMaterial"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Partnumbers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumbers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Items_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents print_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
