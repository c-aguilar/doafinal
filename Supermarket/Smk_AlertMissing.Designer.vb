<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_AlertMissing
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_AlertMissing))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Critical_rb = New System.Windows.Forms.RadioButton()
        Me.Minimum_rb = New System.Windows.Forms.RadioButton()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Report_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Maximum_rb = New System.Windows.Forms.RadioButton()
        Me.Obsolete_lbl = New System.Windows.Forms.Label()
        Me.CriticalPartnumbers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.CriticalPartnumbers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(83, 32)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(123, 26)
        Me.Partnumber_txt.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "No. de Parte:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Comentario:"
        '
        'Comment_txt
        '
        Me.Comment_txt.BackColor = System.Drawing.Color.Ivory
        Me.Comment_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment_txt.Location = New System.Drawing.Point(83, 64)
        Me.Comment_txt.MaxLength = 50
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(359, 46)
        Me.Comment_txt.TabIndex = 113
        '
        'Critical_rb
        '
        Me.Critical_rb.AutoSize = True
        Me.Critical_rb.Checked = True
        Me.Critical_rb.Location = New System.Drawing.Point(212, 36)
        Me.Critical_rb.Name = "Critical_rb"
        Me.Critical_rb.Size = New System.Drawing.Size(56, 17)
        Me.Critical_rb.TabIndex = 115
        Me.Critical_rb.TabStop = True
        Me.Critical_rb.Text = "Crítico"
        Me.Critical_rb.UseVisualStyleBackColor = True
        '
        'Minimum_rb
        '
        Me.Minimum_rb.AutoSize = True
        Me.Minimum_rb.Location = New System.Drawing.Point(272, 36)
        Me.Minimum_rb.Name = "Minimum_rb"
        Me.Minimum_rb.Size = New System.Drawing.Size(60, 17)
        Me.Minimum_rb.TabIndex = 116
        Me.Minimum_rb.Text = "Mínimo"
        Me.Minimum_rb.UseVisualStyleBackColor = True
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Report_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.NullValue = Nothing
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.Report_dgv.DefaultRowFilter = Nothing
        Me.Report_dgv.EnableHeadersVisualStyles = False
        Me.Report_dgv.Location = New System.Drawing.Point(4, 116)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(1219, 307)
        Me.Report_dgv.TabIndex = 125
        '
        'Report_btn
        '
        Me.Report_btn.Image = CType(resources.GetObject("Report_btn.Image"), System.Drawing.Image)
        Me.Report_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Report_btn.Location = New System.Drawing.Point(448, 85)
        Me.Report_btn.Name = "Report_btn"
        Me.Report_btn.Size = New System.Drawing.Size(100, 25)
        Me.Report_btn.TabIndex = 126
        Me.Report_btn.Text = "Reportar"
        Me.Report_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.Find_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1228, 29)
        Me.ToolStripMain.TabIndex = 127
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "&Actualizar"
        '
        'Find_btn
        '
        Me.Find_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(23, 26)
        Me.Find_btn.Text = "&Buscar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(352, 26)
        Me.Title_lbl.Text = "Reportar Numeros de Parte a Ordenamiento"
        '
        'Maximum_rb
        '
        Me.Maximum_rb.AutoSize = True
        Me.Maximum_rb.Location = New System.Drawing.Point(336, 36)
        Me.Maximum_rb.Name = "Maximum_rb"
        Me.Maximum_rb.Size = New System.Drawing.Size(61, 17)
        Me.Maximum_rb.TabIndex = 117
        Me.Maximum_rb.Text = "Máximo"
        Me.Maximum_rb.UseVisualStyleBackColor = True
        '
        'Obsolete_lbl
        '
        Me.Obsolete_lbl.AutoSize = True
        Me.Obsolete_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Obsolete_lbl.ForeColor = System.Drawing.Color.Red
        Me.Obsolete_lbl.Location = New System.Drawing.Point(445, 38)
        Me.Obsolete_lbl.Name = "Obsolete_lbl"
        Me.Obsolete_lbl.Size = New System.Drawing.Size(294, 16)
        Me.Obsolete_lbl.TabIndex = 128
        Me.Obsolete_lbl.Text = "Obsoleto: ingresa el nombre de quien lo solicitó."
        Me.Obsolete_lbl.Visible = False
        '
        'CriticalPartnumbers_dgv
        '
        Me.CriticalPartnumbers_dgv.AllowColumnHiding = True
        Me.CriticalPartnumbers_dgv.AllowUserToAddRows = False
        Me.CriticalPartnumbers_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CriticalPartnumbers_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.CriticalPartnumbers_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CriticalPartnumbers_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.CriticalPartnumbers_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CriticalPartnumbers_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.CriticalPartnumbers_dgv.ColumnHeadersHeight = 33
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CriticalPartnumbers_dgv.DefaultCellStyle = DataGridViewCellStyle15
        Me.CriticalPartnumbers_dgv.DefaultRowFilter = Nothing
        Me.CriticalPartnumbers_dgv.EnableHeadersVisualStyles = False
        Me.CriticalPartnumbers_dgv.Location = New System.Drawing.Point(4, 442)
        Me.CriticalPartnumbers_dgv.Name = "CriticalPartnumbers_dgv"
        Me.CriticalPartnumbers_dgv.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CriticalPartnumbers_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.CriticalPartnumbers_dgv.ShowRowNumber = True
        Me.CriticalPartnumbers_dgv.Size = New System.Drawing.Size(1219, 245)
        Me.CriticalPartnumbers_dgv.TabIndex = 129
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 426)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Recibos"
        '
        'Smk_AlertMissing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 691)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CriticalPartnumbers_dgv)
        Me.Controls.Add(Me.Obsolete_lbl)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Report_btn)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.Maximum_rb)
        Me.Controls.Add(Me.Minimum_rb)
        Me.Controls.Add(Me.Critical_rb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Name = "Smk_AlertMissing"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.CriticalPartnumbers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Critical_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Minimum_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Report_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Maximum_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Obsolete_lbl As System.Windows.Forms.Label
    Friend WithEvents CriticalPartnumbers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
