<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_MovementHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_MovementHistory))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Serial_rb = New System.Windows.Forms.RadioButton()
        Me.Partnumber_rb = New System.Windows.Forms.RadioButton()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Movements_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.To_dtp = New System.Windows.Forms.DateTimePicker()
        Me.From_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        CType(Me.Movements_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Serial_rb
        '
        Me.Serial_rb.AutoSize = True
        Me.Serial_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_rb.Location = New System.Drawing.Point(521, 37)
        Me.Serial_rb.Name = "Serial_rb"
        Me.Serial_rb.Size = New System.Drawing.Size(52, 17)
        Me.Serial_rb.TabIndex = 94
        Me.Serial_rb.Text = "Serie:"
        Me.Serial_rb.UseVisualStyleBackColor = True
        '
        'Partnumber_rb
        '
        Me.Partnumber_rb.AutoSize = True
        Me.Partnumber_rb.Checked = True
        Me.Partnumber_rb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_rb.Location = New System.Drawing.Point(6, 37)
        Me.Partnumber_rb.Name = "Partnumber_rb"
        Me.Partnumber_rb.Size = New System.Drawing.Size(107, 17)
        Me.Partnumber_rb.TabIndex = 95
        Me.Partnumber_rb.TabStop = True
        Me.Partnumber_rb.Text = "Numero de parte:"
        Me.Partnumber_rb.UseVisualStyleBackColor = True
        '
        'Find_btn
        '
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(752, 33)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(100, 25)
        Me.Find_btn.TabIndex = 96
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Movements_dgv
        '
        Me.Movements_dgv.AllowColumnHiding = True
        Me.Movements_dgv.AllowUserToAddRows = False
        Me.Movements_dgv.AllowUserToDeleteRows = False
        Me.Movements_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Movements_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Movements_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Movements_dgv.Location = New System.Drawing.Point(6, 62)
        Me.Movements_dgv.Name = "Movements_dgv"
        Me.Movements_dgv.ReadOnly = True
        Me.Movements_dgv.ShowRowNumber = True
        Me.Movements_dgv.Size = New System.Drawing.Size(987, 301)
        Me.Movements_dgv.TabIndex = 97
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(999, 29)
        Me.ToolStripMain.TabIndex = 102
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Export_btn
        '
        Me.Export_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Export_btn.Image = CType(resources.GetObject("Export_btn.Image"), System.Drawing.Image)
        Me.Export_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Export_btn.Name = "Export_btn"
        Me.Export_btn.Size = New System.Drawing.Size(23, 26)
        Me.Export_btn.Text = "&Exportar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(206, 26)
        Me.Title_lbl.Text = "Historial de Movimientos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(219, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Desde:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(367, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "hasta:"
        '
        'To_dtp
        '
        Me.To_dtp.CustomFormat = ""
        Me.To_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.To_dtp.Location = New System.Drawing.Point(405, 35)
        Me.To_dtp.Name = "To_dtp"
        Me.To_dtp.Size = New System.Drawing.Size(100, 20)
        Me.To_dtp.TabIndex = 116
        '
        'From_dtp
        '
        Me.From_dtp.CustomFormat = ""
        Me.From_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_dtp.Location = New System.Drawing.Point(263, 35)
        Me.From_dtp.Name = "From_dtp"
        Me.From_dtp.Size = New System.Drawing.Size(100, 20)
        Me.From_dtp.TabIndex = 114
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(576, 35)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(170, 20)
        Me.Serial_txt.TabIndex = 118
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(111, 35)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(101, 20)
        Me.Partnumber_txt.TabIndex = 119
        '
        'Smk_MovementHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 369)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.To_dtp)
        Me.Controls.Add(Me.From_dtp)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Movements_dgv)
        Me.Controls.Add(Me.Find_btn)
        Me.Controls.Add(Me.Partnumber_rb)
        Me.Controls.Add(Me.Serial_rb)
        Me.Name = "Smk_MovementHistory"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.Movements_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Serial_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Partnumber_rb As System.Windows.Forms.RadioButton
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Movements_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents To_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents From_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
End Class
