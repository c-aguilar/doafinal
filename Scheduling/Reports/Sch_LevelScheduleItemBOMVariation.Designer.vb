<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_LevelScheduleItemBOMVariation
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_LevelScheduleItemBOMVariation))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Differences_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Copy_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Partnumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DifferenceBOM_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Containers_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Differences_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Differences_dgv
        '
        Me.Differences_dgv.AllowColumnHiding = True
        Me.Differences_dgv.AllowUserToAddRows = False
        Me.Differences_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Differences_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Differences_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Differences_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Differences_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Differences_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Differences_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partnumber_col, Me.DifferenceBOM_col, Me.Cost_col, Me.Containers_col})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Differences_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Differences_dgv.DefaultRowFilter = Nothing
        Me.Differences_dgv.EnableHeadersVisualStyles = False
        Me.Differences_dgv.Location = New System.Drawing.Point(1, 30)
        Me.Differences_dgv.Name = "Differences_dgv"
        Me.Differences_dgv.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Differences_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Differences_dgv.RowHeadersVisible = False
        Me.Differences_dgv.ShowRowNumber = True
        Me.Differences_dgv.Size = New System.Drawing.Size(272, 416)
        Me.Differences_dgv.TabIndex = 0
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.BackColor = System.Drawing.Color.Red
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.Location = New System.Drawing.Point(273, 1)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(23, 23)
        Me.Close_btn.TabIndex = 1
        Me.Close_btn.Text = "X"
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripMain.AutoSize = False
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Copy_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(1, 1)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.ToolStripMain.Size = New System.Drawing.Size(271, 29)
        Me.ToolStripMain.TabIndex = 129
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Copy_btn
        '
        Me.Copy_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Copy_btn.Image = CType(resources.GetObject("Copy_btn.Image"), System.Drawing.Image)
        Me.Copy_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Copy_btn.Name = "Copy_btn"
        Me.Copy_btn.Size = New System.Drawing.Size(23, 26)
        Me.Copy_btn.Text = "Copiar"
        Me.Copy_btn.ToolTipText = "Copiar Todo"
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
        Me.Title_lbl.Size = New System.Drawing.Size(45, 26)
        Me.Title_lbl.Text = "Title"
        '
        'Partnumber_col
        '
        Me.Partnumber_col.DataPropertyName = "Partnumber"
        Me.Partnumber_col.HeaderText = "No. de Parte"
        Me.Partnumber_col.Name = "Partnumber_col"
        Me.Partnumber_col.ReadOnly = True
        Me.Partnumber_col.Width = 70
        '
        'DifferenceBOM_col
        '
        Me.DifferenceBOM_col.DataPropertyName = "Usage"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N1"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DifferenceBOM_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.DifferenceBOM_col.HeaderText = "Variacion (Uso)"
        Me.DifferenceBOM_col.Name = "DifferenceBOM_col"
        Me.DifferenceBOM_col.ReadOnly = True
        Me.DifferenceBOM_col.Width = 60
        '
        'Cost_col
        '
        Me.Cost_col.DataPropertyName = "Cost"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C1"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Cost_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cost_col.HeaderText = "Variacion (Costo)"
        Me.Cost_col.Name = "Cost_col"
        Me.Cost_col.ReadOnly = True
        Me.Cost_col.Width = 60
        '
        'Containers_col
        '
        Me.Containers_col.DataPropertyName = "Containers"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Containers_col.DefaultCellStyle = DataGridViewCellStyle5
        Me.Containers_col.HeaderText = "Variacion (Contdrs)"
        Me.Containers_col.Name = "Containers_col"
        Me.Containers_col.ReadOnly = True
        Me.Containers_col.Width = 60
        '
        'Sch_LevelScheduleItemBOMVariation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GreenYellow
        Me.ClientSize = New System.Drawing.Size(297, 447)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Differences_dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Sch_LevelScheduleItemBOMVariation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Scheduling"
        Me.TransparencyKey = System.Drawing.Color.GreenYellow
        CType(Me.Differences_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Differences_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Copy_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Partnumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DifferenceBOM_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Containers_col As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
