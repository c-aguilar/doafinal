<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FGR_CancelSerialMovements
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FGR_CancelSerialMovements))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SelectAll_chk = New System.Windows.Forms.CheckBox()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Serial_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Route = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Movement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cancel_chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Serial_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectAll_chk
        '
        Me.SelectAll_chk.AutoSize = True
        Me.SelectAll_chk.Location = New System.Drawing.Point(650, 37)
        Me.SelectAll_chk.Name = "SelectAll_chk"
        Me.SelectAll_chk.Size = New System.Drawing.Size(123, 17)
        Me.SelectAll_chk.TabIndex = 108
        Me.SelectAll_chk.Text = "De/seleccionar todo"
        Me.SelectAll_chk.UseVisualStyleBackColor = True
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(544, 32)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 107
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.Export_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(778, 29)
        Me.ToolStripMain.TabIndex = 106
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "&Refresh"
        Me.Refresh_btn.ToolTipText = "Actualizar"
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
        Me.Title_lbl.Size = New System.Drawing.Size(262, 26)
        Me.Title_lbl.Text = "Cancelar Movimientos de Series"
        '
        'Serial_dgv
        '
        Me.Serial_dgv.AllowColumnHiding = True
        Me.Serial_dgv.AllowUserToAddRows = False
        Me.Serial_dgv.AllowUserToDeleteRows = False
        Me.Serial_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serial_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serial_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serial, Me.Route, Me.Date_, Me.Movement, Me.Cancel_chk})
        Me.Serial_dgv.Location = New System.Drawing.Point(5, 63)
        Me.Serial_dgv.Name = "Serial_dgv"
        Me.Serial_dgv.ShowRowNumber = True
        Me.Serial_dgv.Size = New System.Drawing.Size(769, 384)
        Me.Serial_dgv.TabIndex = 0
        '
        'Serial
        '
        Me.Serial.DataPropertyName = "Serialnumber"
        Me.Serial.HeaderText = "No. de Serie"
        Me.Serial.Name = "Serial"
        Me.Serial.ReadOnly = True
        Me.Serial.Width = 110
        '
        'Route
        '
        Me.Route.DataPropertyName = "Ruta"
        Me.Route.HeaderText = "Ruta"
        Me.Route.Name = "Route"
        Me.Route.ReadOnly = True
        Me.Route.Width = 110
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Fecha"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "g"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Date_.DefaultCellStyle = DataGridViewCellStyle1
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 110
        '
        'Movement
        '
        Me.Movement.DataPropertyName = "Movimiento"
        Me.Movement.HeaderText = "Movimiento"
        Me.Movement.Name = "Movement"
        Me.Movement.ReadOnly = True
        Me.Movement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Movement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Movement.Width = 70
        '
        'Cancel_chk
        '
        Me.Cancel_chk.DataPropertyName = "Canceling"
        Me.Cancel_chk.HeaderText = "Cancelar"
        Me.Cancel_chk.Name = "Cancel_chk"
        Me.Cancel_chk.Width = 60
        '
        'FGR_CancelSerialMovements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 451)
        Me.Controls.Add(Me.SelectAll_chk)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Serial_dgv)
        Me.Name = "FGR_CancelSerialMovements"
        Me.ShowIcon = False
        Me.Text = "Finish Good Delivery Routes"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Serial_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectAll_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Serial_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Route As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Movement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel_chk As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
