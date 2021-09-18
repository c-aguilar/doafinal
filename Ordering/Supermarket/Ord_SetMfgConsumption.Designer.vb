<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_SetMfgConsumption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_SetMfgConsumption))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NewQuantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CurrentNone_rb = New System.Windows.Forms.RadioButton()
        Me.CurrentDaily_rb = New System.Windows.Forms.RadioButton()
        Me.CurrentWeekly_rb = New System.Windows.Forms.RadioButton()
        Me.CurrentMonthly_rb = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Save_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.UoM_lbl = New System.Windows.Forms.Label()
        Me.PermanentChange_chk = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Plan_dgv = New CAguilar.DataGridViewWithFilters()
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Plan_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Location = New System.Drawing.Point(124, 50)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(96, 20)
        Me.Partnumber_txt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No. de Parte:"
        '
        'NewQuantity_nud
        '
        Me.NewQuantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.NewQuantity_nud.DecimalPlaces = 3
        Me.NewQuantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewQuantity_nud.Location = New System.Drawing.Point(124, 106)
        Me.NewQuantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NewQuantity_nud.Name = "NewQuantity_nud"
        Me.NewQuantity_nud.Size = New System.Drawing.Size(96, 20)
        Me.NewQuantity_nud.TabIndex = 9
        Me.NewQuantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Cantidad:"
        '
        'CurrentNone_rb
        '
        Me.CurrentNone_rb.AutoSize = True
        Me.CurrentNone_rb.Location = New System.Drawing.Point(124, 79)
        Me.CurrentNone_rb.Name = "CurrentNone_rb"
        Me.CurrentNone_rb.Size = New System.Drawing.Size(65, 17)
        Me.CurrentNone_rb.TabIndex = 11
        Me.CurrentNone_rb.TabStop = True
        Me.CurrentNone_rb.Text = "Ninguno"
        Me.CurrentNone_rb.UseVisualStyleBackColor = True
        '
        'CurrentDaily_rb
        '
        Me.CurrentDaily_rb.AutoSize = True
        Me.CurrentDaily_rb.Location = New System.Drawing.Point(195, 79)
        Me.CurrentDaily_rb.Name = "CurrentDaily_rb"
        Me.CurrentDaily_rb.Size = New System.Drawing.Size(52, 17)
        Me.CurrentDaily_rb.TabIndex = 12
        Me.CurrentDaily_rb.TabStop = True
        Me.CurrentDaily_rb.Text = "Diario"
        Me.CurrentDaily_rb.UseVisualStyleBackColor = True
        '
        'CurrentWeekly_rb
        '
        Me.CurrentWeekly_rb.AutoSize = True
        Me.CurrentWeekly_rb.Location = New System.Drawing.Point(255, 79)
        Me.CurrentWeekly_rb.Name = "CurrentWeekly_rb"
        Me.CurrentWeekly_rb.Size = New System.Drawing.Size(66, 17)
        Me.CurrentWeekly_rb.TabIndex = 13
        Me.CurrentWeekly_rb.TabStop = True
        Me.CurrentWeekly_rb.Text = "Semanal"
        Me.CurrentWeekly_rb.UseVisualStyleBackColor = True
        '
        'CurrentMonthly_rb
        '
        Me.CurrentMonthly_rb.AutoSize = True
        Me.CurrentMonthly_rb.Location = New System.Drawing.Point(327, 79)
        Me.CurrentMonthly_rb.Name = "CurrentMonthly_rb"
        Me.CurrentMonthly_rb.Size = New System.Drawing.Size(65, 17)
        Me.CurrentMonthly_rb.TabIndex = 14
        Me.CurrentMonthly_rb.TabStop = True
        Me.CurrentMonthly_rb.Text = "Mensual"
        Me.CurrentMonthly_rb.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Limite:"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Save_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(500, 29)
        Me.ToolStripMain.TabIndex = 118
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Save_btn
        '
        Me.Save_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(23, 26)
        Me.Save_btn.Text = "&Configuracion"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(373, 26)
        Me.Title_lbl.Text = "Modificar Consumo Permitido de Manufactura"
        '
        'UoM_lbl
        '
        Me.UoM_lbl.AutoSize = True
        Me.UoM_lbl.Location = New System.Drawing.Point(226, 110)
        Me.UoM_lbl.Name = "UoM_lbl"
        Me.UoM_lbl.Size = New System.Drawing.Size(16, 13)
        Me.UoM_lbl.TabIndex = 119
        Me.UoM_lbl.Text = "   "
        '
        'PermanentChange_chk
        '
        Me.PermanentChange_chk.AutoSize = True
        Me.PermanentChange_chk.Location = New System.Drawing.Point(124, 137)
        Me.PermanentChange_chk.Name = "PermanentChange_chk"
        Me.PermanentChange_chk.Size = New System.Drawing.Size(157, 17)
        Me.PermanentChange_chk.TabIndex = 120
        Me.PermanentChange_chk.Text = "Modificar permanentemente"
        Me.PermanentChange_chk.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Plan de Componentes:"
        '
        'Plan_dgv
        '
        Me.Plan_dgv.AllowColumnHiding = True
        Me.Plan_dgv.AllowUserToAddRows = False
        Me.Plan_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Plan_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Plan_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Plan_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Plan_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Plan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Plan_dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Plan_dgv.DefaultRowFilter = Nothing
        Me.Plan_dgv.EnableHeadersVisualStyles = False
        Me.Plan_dgv.Location = New System.Drawing.Point(14, 176)
        Me.Plan_dgv.Name = "Plan_dgv"
        Me.Plan_dgv.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Plan_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Plan_dgv.RowHeadersVisible = False
        Me.Plan_dgv.ShowRowNumber = True
        Me.Plan_dgv.Size = New System.Drawing.Size(473, 90)
        Me.Plan_dgv.TabIndex = 122
        '
        'Ord_SetMfgConsumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 272)
        Me.Controls.Add(Me.Plan_dgv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PermanentChange_chk)
        Me.Controls.Add(Me.UoM_lbl)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CurrentMonthly_rb)
        Me.Controls.Add(Me.CurrentWeekly_rb)
        Me.Controls.Add(Me.CurrentDaily_rb)
        Me.Controls.Add(Me.CurrentNone_rb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NewQuantity_nud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Ord_SetMfgConsumption"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Plan_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NewQuantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CurrentNone_rb As System.Windows.Forms.RadioButton
    Friend WithEvents CurrentDaily_rb As System.Windows.Forms.RadioButton
    Friend WithEvents CurrentWeekly_rb As System.Windows.Forms.RadioButton
    Friend WithEvents CurrentMonthly_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Save_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UoM_lbl As System.Windows.Forms.Label
    Friend WithEvents PermanentChange_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Plan_dgv As CAguilar.DataGridViewWithFilters
End Class
