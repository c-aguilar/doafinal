<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ActiveRawMaterialSerials
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ActiveRawMaterialSerials))
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
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Serials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Serialnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdPack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UoM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RedTag = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InvoiceTrouble = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Controlled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(757, 29)
        Me.ToolStripMain.TabIndex = 103
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
        Me.Title_lbl.Size = New System.Drawing.Size(104, 26)
        Me.Title_lbl.Text = "Partnumber"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Close_btn)
        Me.Panel1.Controls.Add(Me.Serials_dgv)
        Me.Panel1.Controls.Add(Me.ToolStripMain)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 315)
        Me.Panel1.TabIndex = 105
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatAppearance.BorderSize = 0
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.DarkRed
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(734, 3)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(20, 20)
        Me.Close_btn.TabIndex = 123
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Serials_dgv
        '
        Me.Serials_dgv.AllowColumnHiding = True
        Me.Serials_dgv.AllowUserToAddRows = False
        Me.Serials_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Serials_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Serials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serials_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Serials_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Serials_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serials_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Serials_dgv.ColumnHeadersHeight = 33
        Me.Serials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serialnumber, Me.StdPack, Me.CurrentQuantity, Me.UoM, Me.Status, Me.Location_, Me.Warehouse, Me.Date_, Me.RedTag, Me.InvoiceTrouble, Me.Controlled})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Serials_dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.Serials_dgv.DefaultRowFilter = Nothing
        Me.Serials_dgv.EnableHeadersVisualStyles = False
        Me.Serials_dgv.Location = New System.Drawing.Point(3, 32)
        Me.Serials_dgv.Name = "Serials_dgv"
        Me.Serials_dgv.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serials_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Serials_dgv.ShowRowNumber = True
        Me.Serials_dgv.Size = New System.Drawing.Size(751, 278)
        Me.Serials_dgv.TabIndex = 122
        '
        'Serialnumber
        '
        Me.Serialnumber.DataPropertyName = "SerialNumber"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Serialnumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.Serialnumber.HeaderText = "No. de Serie"
        Me.Serialnumber.Name = "Serialnumber"
        Me.Serialnumber.ReadOnly = True
        Me.Serialnumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serialnumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Serialnumber.Width = 110
        '
        'StdPack
        '
        Me.StdPack.DataPropertyName = "OriginalQuantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.StdPack.DefaultCellStyle = DataGridViewCellStyle4
        Me.StdPack.HeaderText = "StdPack"
        Me.StdPack.Name = "StdPack"
        Me.StdPack.ReadOnly = True
        Me.StdPack.Width = 70
        '
        'CurrentQuantity
        '
        Me.CurrentQuantity.DataPropertyName = "CurrentQuantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CurrentQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.CurrentQuantity.HeaderText = "Cantidad Actual"
        Me.CurrentQuantity.Name = "CurrentQuantity"
        Me.CurrentQuantity.ReadOnly = True
        Me.CurrentQuantity.Width = 70
        '
        'UoM
        '
        Me.UoM.DataPropertyName = "UoM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.UoM.DefaultCellStyle = DataGridViewCellStyle6
        Me.UoM.HeaderText = "Unidad"
        Me.UoM.Name = "UoM"
        Me.UoM.ReadOnly = True
        Me.UoM.Width = 50
        '
        'Status
        '
        Me.Status.DataPropertyName = "StatusDescription"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Status.DefaultCellStyle = DataGridViewCellStyle7
        Me.Status.HeaderText = "Estatus"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 60
        '
        'Location_
        '
        Me.Location_.DataPropertyName = "Location"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Location_.DefaultCellStyle = DataGridViewCellStyle8
        Me.Location_.HeaderText = "Localizacion"
        Me.Location_.Name = "Location_"
        Me.Location_.ReadOnly = True
        Me.Location_.Width = 80
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "WarehouseName"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Warehouse.DefaultCellStyle = DataGridViewCellStyle9
        Me.Warehouse.HeaderText = "Estacion"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        Me.Warehouse.Width = 60
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle10.Format = "g"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle10
        Me.Date_.HeaderText = "Fecha de Etiquetado"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        '
        'RedTag
        '
        Me.RedTag.DataPropertyName = "RedTag"
        Me.RedTag.HeaderText = "Bloqueado por Calidad"
        Me.RedTag.Name = "RedTag"
        Me.RedTag.ReadOnly = True
        Me.RedTag.Width = 30
        '
        'InvoiceTrouble
        '
        Me.InvoiceTrouble.DataPropertyName = "InvoiceTrouble"
        Me.InvoiceTrouble.HeaderText = "Tracker de Problemas"
        Me.InvoiceTrouble.Name = "InvoiceTrouble"
        Me.InvoiceTrouble.ReadOnly = True
        Me.InvoiceTrouble.Width = 30
        '
        'Controlled
        '
        Me.Controlled.DataPropertyName = "Controlled"
        Me.Controlled.HeaderText = "Material Controlado"
        Me.Controlled.Name = "Controlled"
        Me.Controlled.ReadOnly = True
        Me.Controlled.Width = 30
        '
        'CR_ActiveRawMaterialSerials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 315)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CR_ActiveRawMaterialSerials"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supermarket"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Serials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Serials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Serialnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdPack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RedTag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InvoiceTrouble As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Controlled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Close_btn As System.Windows.Forms.Button
End Class
