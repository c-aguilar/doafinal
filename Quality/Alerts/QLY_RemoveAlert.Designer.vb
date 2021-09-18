<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QLY_RemoveAlert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QLY_RemoveAlert))
        Me.Alerts_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierPartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remove_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
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
        Me.Alerts_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Alerts_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Alerts_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Partnumber, Me.SupplierPartnumber, Me.Reason, Me.Date_, Me.User, Me.remove_btn})
        Me.Alerts_dgv.Location = New System.Drawing.Point(4, 28)
        Me.Alerts_dgv.Name = "Alerts_dgv"
        Me.Alerts_dgv.ShowRowNumber = True
        Me.Alerts_dgv.Size = New System.Drawing.Size(805, 363)
        Me.Alerts_dgv.TabIndex = 91
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Partnumber
        '
        Me.Partnumber.DataPropertyName = "Partnumber"
        Me.Partnumber.HeaderText = "No. de Parte"
        Me.Partnumber.Name = "Partnumber"
        Me.Partnumber.ReadOnly = True
        Me.Partnumber.Width = 90
        '
        'SupplierPartnumber
        '
        Me.SupplierPartnumber.DataPropertyName = "SupplierPartnumber"
        Me.SupplierPartnumber.HeaderText = "No. de Proveedor"
        Me.SupplierPartnumber.Name = "SupplierPartnumber"
        Me.SupplierPartnumber.ReadOnly = True
        Me.SupplierPartnumber.Width = 120
        '
        'Reason
        '
        Me.Reason.DataPropertyName = "Reason"
        Me.Reason.HeaderText = "Motivo"
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = True
        Me.Reason.Width = 250
        '
        'Date_
        '
        Me.Date_.DataPropertyName = "Date"
        Me.Date_.HeaderText = "Fecha"
        Me.Date_.Name = "Date_"
        Me.Date_.ReadOnly = True
        Me.Date_.Width = 90
        '
        'User
        '
        Me.User.DataPropertyName = "FullName"
        Me.User.HeaderText = "Creado por"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        Me.User.Width = 120
        '
        'remove_btn
        '
        Me.remove_btn.HeaderText = "Desactivar"
        Me.remove_btn.Name = "remove_btn"
        Me.remove_btn.ReadOnly = True
        Me.remove_btn.Text = ""
        Me.remove_btn.Width = 70
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refresh_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(814, 29)
        Me.ToolStripMain.TabIndex = 103
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
        Me.Title_lbl.Size = New System.Drawing.Size(153, 26)
        Me.Title_lbl.Text = "Desactivar Alertas"
        '
        'QLY_RemoveAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 396)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Alerts_dgv)
        Me.Name = "QLY_RemoveAlert"
        Me.ShowIcon = False
        Me.Text = "Quality"
        CType(Me.Alerts_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Alerts_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierPartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remove_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
