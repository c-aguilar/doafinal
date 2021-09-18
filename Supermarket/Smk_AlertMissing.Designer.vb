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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_AlertMissing))
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
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
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
        Me.Comment_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Comment_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment_txt.Location = New System.Drawing.Point(83, 64)
        Me.Comment_txt.MaxLength = 50
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(237, 83)
        Me.Comment_txt.TabIndex = 113
        '
        'Critical_rb
        '
        Me.Critical_rb.AutoSize = True
        Me.Critical_rb.Checked = True
        Me.Critical_rb.Location = New System.Drawing.Point(326, 70)
        Me.Critical_rb.Name = "Critical_rb"
        Me.Critical_rb.Size = New System.Drawing.Size(54, 17)
        Me.Critical_rb.TabIndex = 115
        Me.Critical_rb.TabStop = True
        Me.Critical_rb.Text = "Critico"
        Me.Critical_rb.UseVisualStyleBackColor = True
        '
        'Minimum_rb
        '
        Me.Minimum_rb.AutoSize = True
        Me.Minimum_rb.Location = New System.Drawing.Point(326, 93)
        Me.Minimum_rb.Name = "Minimum_rb"
        Me.Minimum_rb.Size = New System.Drawing.Size(58, 17)
        Me.Minimum_rb.TabIndex = 116
        Me.Minimum_rb.Text = "Minimo"
        Me.Minimum_rb.UseVisualStyleBackColor = True
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.Report_dgv.Location = New System.Drawing.Point(4, 153)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(975, 405)
        Me.Report_dgv.TabIndex = 125
        '
        'Report_btn
        '
        Me.Report_btn.Image = CType(resources.GetObject("Report_btn.Image"), System.Drawing.Image)
        Me.Report_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Report_btn.Location = New System.Drawing.Point(220, 32)
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
        Me.ToolStripMain.Size = New System.Drawing.Size(984, 29)
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
        Me.Maximum_rb.Location = New System.Drawing.Point(326, 116)
        Me.Maximum_rb.Name = "Maximum_rb"
        Me.Maximum_rb.Size = New System.Drawing.Size(61, 17)
        Me.Maximum_rb.TabIndex = 117
        Me.Maximum_rb.Text = "Maximo"
        Me.Maximum_rb.UseVisualStyleBackColor = True
        '
        'Smk_AlertMissing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
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
End Class
