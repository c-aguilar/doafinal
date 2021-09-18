<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MB51_261VsZ11_Details
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgvReport = New CAguilar.DataGridViewWithFilters()
        Me._Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Z11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._261 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(313, 25)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Daily Movements:"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._Date, Me.Z11, Me._261, Me.Balance})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvReport.GridColor = System.Drawing.Color.DimGray
        Me.dgvReport.Location = New System.Drawing.Point(0, 25)
        Me.dgvReport.MultiSelect = False
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(313, 637)
        Me.dgvReport.TabIndex = 26
        '
        '_Date
        '
        Me._Date.DataPropertyName = "Date"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me._Date.DefaultCellStyle = DataGridViewCellStyle3
        Me._Date.HeaderText = "Date"
        Me._Date.Name = "_Date"
        Me._Date.ReadOnly = True
        Me._Date.Width = 70
        '
        'Z11
        '
        Me.Z11.DataPropertyName = "Z11"
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Z11.DefaultCellStyle = DataGridViewCellStyle4
        Me.Z11.HeaderText = "Z11"
        Me.Z11.Name = "Z11"
        Me.Z11.ReadOnly = True
        Me.Z11.Width = 60
        '
        '_261
        '
        Me._261.DataPropertyName = "261"
        DataGridViewCellStyle5.Format = "N3"
        Me._261.DefaultCellStyle = DataGridViewCellStyle5
        Me._261.HeaderText = "261"
        Me._261.Name = "_261"
        Me._261.ReadOnly = True
        Me._261.Width = 60
        '
        'Balance
        '
        Me.Balance.DataPropertyName = "Balance"
        DataGridViewCellStyle6.Format = "N3"
        Me.Balance.DefaultCellStyle = DataGridViewCellStyle6
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        Me.Balance.Width = 60
        '
        'MB51_261VsZ11_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 662)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MB51_261VsZ11_Details"
        Me.ShowIcon = False
        Me.Text = "Details"
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgvReport As CAguilar.DataGridViewWithFilters
    Friend WithEvents _Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Z11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _261 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
