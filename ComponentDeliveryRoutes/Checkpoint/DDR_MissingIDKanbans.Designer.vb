<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_MissingIDKanbans
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Missings_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Kanban_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        CType(Me.Missings_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(934, 25)
        Me.lblTitle.TabIndex = 145
        Me.lblTitle.Text = "Pesado de Bins no Actualizados"
        '
        'Missings_dgv
        '
        Me.Missings_dgv.AllowColumnHiding = True
        Me.Missings_dgv.AllowUserToAddRows = False
        Me.Missings_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Missings_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Missings_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Missings_dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Missings_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Missings_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Missings_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Missings_dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.Missings_dgv.DefaultRowFilter = Nothing
        Me.Missings_dgv.EnableHeadersVisualStyles = False
        Me.Missings_dgv.Location = New System.Drawing.Point(8, 63)
        Me.Missings_dgv.Name = "Missings_dgv"
        Me.Missings_dgv.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Missings_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Missings_dgv.ShowRowNumber = True
        Me.Missings_dgv.Size = New System.Drawing.Size(910, 258)
        Me.Missings_dgv.TabIndex = 146
        '
        'Kanban_txt
        '
        Me.Kanban_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanban_txt.BackColor = System.Drawing.Color.White
        Me.Kanban_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Kanban_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kanban_txt.ForeColor = System.Drawing.Color.Black
        Me.Kanban_txt.Location = New System.Drawing.Point(325, 12)
        Me.Kanban_txt.Name = "Kanban_txt"
        Me.Kanban_txt.Size = New System.Drawing.Size(280, 35)
        Me.Kanban_txt.TabIndex = 147
        Me.Kanban_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kanban_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Kanban_txt.WaterMarkText = "Escanea el bin a pesar..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Cancel_btn)
        Me.Panel1.Controls.Add(Me.Missings_dgv)
        Me.Panel1.Controls.Add(Me.Kanban_txt)
        Me.Panel1.Location = New System.Drawing.Point(4, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 401)
        Me.Panel1.TabIndex = 148
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Cancel_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!)
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.cross_32
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cancel_btn.Location = New System.Drawing.Point(385, 328)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(156, 64)
        Me.Cancel_btn.TabIndex = 148
        Me.Cancel_btn.Text = "CANCELAR"
        Me.Cancel_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'DDR_MissingIDKanbans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 434)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DDR_MissingIDKanbans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DDR_MissingIDKanbans"
        CType(Me.Missings_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Missings_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Kanban_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
End Class
