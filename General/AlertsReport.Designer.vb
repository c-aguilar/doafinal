<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertsReport
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Alerts_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desactive_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Alerts_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Alerts_dgv
        '
        Me.Alerts_dgv.AllowColumnHiding = True
        Me.Alerts_dgv.AllowUserToAddRows = False
        Me.Alerts_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Alerts_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Alerts_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Alerts_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Alerts_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Alerts_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alerts_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.Alerts_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Alerts_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Alerts_dgv.ColumnHeadersHeight = 33
        Me.Alerts_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.FullName, Me.Date_, Me.Description, Me.desactive_btn})
        Me.Alerts_dgv.EnableHeadersVisualStyles = False
        Me.Alerts_dgv.Location = New System.Drawing.Point(1, 30)
        Me.Alerts_dgv.Name = "Alerts_dgv"
        Me.Alerts_dgv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Alerts_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Alerts_dgv.RowHeadersVisible = False
        Me.Alerts_dgv.ShowRowNumber = True
        Me.Alerts_dgv.Size = New System.Drawing.Size(570, 283)
        Me.Alerts_dgv.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'FullName
        '
        Me.FullName.DataPropertyName = "FullName"
        Me.FullName.HeaderText = "Por Usuario"
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        Me.FullName.Width = 120
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 140
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Descripcion"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 245
        '
        'desactive_btn
        '
        Me.desactive_btn.DefaultImage = Nothing
        Me.desactive_btn.DefaultText = ""
        Me.desactive_btn.HeaderText = ""
        Me.desactive_btn.Name = "desactive_btn"
        Me.desactive_btn.ReadOnly = True
        Me.desactive_btn.Width = 40
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(498, 0)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 121
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(570, 29)
        Me.ToolStripMain.TabIndex = 122
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(66, 26)
        Me.Title_lbl.Text = "Alertas"
        '
        'AlertsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 310)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Alerts_dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "AlertsReport"
        Me.ShowIcon = False
        Me.Text = "Alertas - Delta ERP"
        CType(Me.Alerts_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Alerts_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desactive_btn As CAguilar.DataGridViewImprovedButtonColumn
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
End Class
