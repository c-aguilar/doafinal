<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_MixMaxAlerts
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_MixMaxAlerts))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Username_cbo = New System.Windows.Forms.ComboBox()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.Find_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.Tops_cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Top10BajasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Top10AltasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MRP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Owner_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlertType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Forecast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnswerBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Answer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PromiseDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnswerDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tops_cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Dueño:"
        '
        'Username_cbo
        '
        Me.Username_cbo.FormattingEnabled = True
        Me.Username_cbo.Location = New System.Drawing.Point(56, 32)
        Me.Username_cbo.Name = "Username_cbo"
        Me.Username_cbo.Size = New System.Drawing.Size(231, 21)
        Me.Username_cbo.TabIndex = 137
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.Find_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1415, 29)
        Me.ToolStripMain.TabIndex = 139
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
        Me.Title_lbl.Size = New System.Drawing.Size(253, 26)
        Me.Title_lbl.Text = "Alertas de Minimos && Maximos"
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Report_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Partnumber, Me.Description, Me.MRP, Me.Owner_, Me.AlertType, Me.ReportedBy, Me.Date_, Me.Comment, Me.Location_, Me.Forecast, Me.Transit, Me.SupplierName_col, Me.AnswerBy, Me.Answer, Me.PromiseDate, Me.AnswerDate})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.NullValue = Nothing
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.Report_dgv.DefaultRowFilter = Nothing
        Me.Report_dgv.EnableHeadersVisualStyles = False
        Me.Report_dgv.Location = New System.Drawing.Point(6, 60)
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
        Me.Report_dgv.RowTemplate.Height = 30
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(1403, 497)
        Me.Report_dgv.TabIndex = 140
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(293, 29)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 130
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'Tops_cms
        '
        Me.Tops_cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Top10BajasToolStripMenuItem, Me.Top10AltasToolStripMenuItem})
        Me.Tops_cms.Name = "Tops_cms"
        Me.Tops_cms.Size = New System.Drawing.Size(141, 48)
        '
        'Top10BajasToolStripMenuItem
        '
        Me.Top10BajasToolStripMenuItem.Name = "Top10BajasToolStripMenuItem"
        Me.Top10BajasToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.Top10BajasToolStripMenuItem.Text = "Top 10 Bajas"
        '
        'Top10AltasToolStripMenuItem
        '
        Me.Top10AltasToolStripMenuItem.Name = "Top10AltasToolStripMenuItem"
        Me.Top10AltasToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.Top10AltasToolStripMenuItem.Text = "Top 10 Altas"
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 43
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        Me.Partnumber.Frozen = True
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 70
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Description.DefaultCellStyle = DataGridViewCellStyle3
        Me.Description.HeaderText = "Descripcion"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 150
        '
        'MRP
        '
        Me.MRP.DataPropertyName = "MRP"
        Me.MRP.HeaderText = "MRP"
        Me.MRP.Name = "MRP"
        Me.MRP.ReadOnly = True
        Me.MRP.Width = 50
        '
        'Owner_
        '
        Me.Owner_.DataPropertyName = "Owner"
        Me.Owner_.HeaderText = "Dueño"
        Me.Owner_.Name = "Owner_"
        Me.Owner_.ReadOnly = True
        Me.Owner_.Width = 90
        '
        'AlertType
        '
        Me.AlertType.DataPropertyName = "Type"
        Me.AlertType.HeaderText = "Tipo de Alerta"
        Me.AlertType.Name = "AlertType"
        Me.AlertType.ReadOnly = True
        Me.AlertType.Width = 70
        '
        'ReportedBy
        '
        Me.ReportedBy.DataPropertyName = "ReportedBy"
        Me.ReportedBy.HeaderText = "Reportado por"
        Me.ReportedBy.Name = "ReportedBy"
        Me.ReportedBy.ReadOnly = True
        Me.ReportedBy.Width = 90
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle4.Format = "MMMM dd HH:mm"
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle4
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        '
        'Comment
        '
        Me.Comment.DataPropertyName = "Comment"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Comment.DefaultCellStyle = DataGridViewCellStyle5
        Me.Comment.HeaderText = "Comentario"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        Me.Comment.Width = 180
        '
        'Location_
        '
        Me.Location_.DataPropertyName = "Location"
        Me.Location_.HeaderText = "Localizacion"
        Me.Location_.Name = "Location_"
        Me.Location_.ReadOnly = True
        Me.Location_.Visible = False
        Me.Location_.Width = 80
        '
        'Forecast
        '
        Me.Forecast.DataPropertyName = "Forecast"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N1"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Forecast.DefaultCellStyle = DataGridViewCellStyle6
        Me.Forecast.HeaderText = "Requerimiento Semanal"
        Me.Forecast.Name = "Forecast"
        Me.Forecast.ReadOnly = True
        Me.Forecast.Width = 80
        '
        'Transit
        '
        Me.Transit.DataPropertyName = "Transit"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Transit.DefaultCellStyle = DataGridViewCellStyle7
        Me.Transit.HeaderText = "Transito"
        Me.Transit.Name = "Transit"
        Me.Transit.ReadOnly = True
        Me.Transit.Width = 80
        '
        'SupplierName_col
        '
        Me.SupplierName_col.DataPropertyName = "SupplierName"
        Me.SupplierName_col.HeaderText = "Proveedor"
        Me.SupplierName_col.Name = "SupplierName_col"
        Me.SupplierName_col.ReadOnly = True
        '
        'AnswerBy
        '
        Me.AnswerBy.DataPropertyName = "AnswerBy"
        Me.AnswerBy.HeaderText = "Respondido por"
        Me.AnswerBy.Name = "AnswerBy"
        Me.AnswerBy.ReadOnly = True
        Me.AnswerBy.Width = 90
        '
        'Answer
        '
        Me.Answer.DataPropertyName = "Answer"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Answer.DefaultCellStyle = DataGridViewCellStyle8
        Me.Answer.HeaderText = "Respuesta"
        Me.Answer.Name = "Answer"
        Me.Answer.ReadOnly = True
        Me.Answer.Width = 180
        '
        'PromiseDate
        '
        Me.PromiseDate.DataPropertyName = "PromiseDate"
        DataGridViewCellStyle9.Format = "MMMM dd HH:mm"
        Me.PromiseDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.PromiseDate.HeaderText = "Fecha Promesa"
        Me.PromiseDate.Name = "PromiseDate"
        Me.PromiseDate.ReadOnly = True
        Me.PromiseDate.Width = 90
        '
        'AnswerDate
        '
        Me.AnswerDate.DataPropertyName = "AnswerDate"
        DataGridViewCellStyle10.Format = "MMMM dd HH:mm"
        Me.AnswerDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.AnswerDate.HeaderText = "Fecha Respuesta"
        Me.AnswerDate.Name = "AnswerDate"
        Me.AnswerDate.ReadOnly = True
        Me.AnswerDate.Width = 90
        '
        'Ord_MixMaxAlerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1415, 562)
        Me.Controls.Add(Me.Report_dgv)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Username_cbo)
        Me.Controls.Add(Me.Run_btn)
        Me.Name = "Ord_MixMaxAlerts"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tops_cms.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Username_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents Tops_cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Top10BajasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Top10AltasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Find_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MRP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Owner_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlertType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Forecast As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierName_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnswerBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Answer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PromiseDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnswerDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
