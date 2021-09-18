<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClonePermissionsFrom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClonePermissionsFrom))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CloneFrom_Save_btn = New System.Windows.Forms.Button()
        Me.CloneFrom_FromUsername_cbo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CloneFrom_ToUsername_cbo = New System.Windows.Forms.ComboBox()
        Me.dgvData = New CAguilar.DataGridViewWithFilters()
        Me.CloneFrom_Clone_rbn = New System.Windows.Forms.RadioButton()
        Me.CloneFrom_AddMissings_rbn = New System.Windows.Forms.RadioButton()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From logon ID:"
        '
        'CloneFrom_Save_btn
        '
        Me.CloneFrom_Save_btn.Image = CType(resources.GetObject("CloneFrom_Save_btn.Image"), System.Drawing.Image)
        Me.CloneFrom_Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloneFrom_Save_btn.Location = New System.Drawing.Point(301, 12)
        Me.CloneFrom_Save_btn.Name = "CloneFrom_Save_btn"
        Me.CloneFrom_Save_btn.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CloneFrom_Save_btn.Size = New System.Drawing.Size(120, 23)
        Me.CloneFrom_Save_btn.TabIndex = 6
        Me.CloneFrom_Save_btn.Text = "Copy && Save"
        Me.CloneFrom_Save_btn.UseVisualStyleBackColor = True
        '
        'CloneFrom_FromUsername_cbo
        '
        Me.CloneFrom_FromUsername_cbo.FormattingEnabled = True
        Me.CloneFrom_FromUsername_cbo.Location = New System.Drawing.Point(96, 12)
        Me.CloneFrom_FromUsername_cbo.Name = "CloneFrom_FromUsername_cbo"
        Me.CloneFrom_FromUsername_cbo.Size = New System.Drawing.Size(181, 21)
        Me.CloneFrom_FromUsername_cbo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "To logon ID:"
        '
        'CloneFrom_ToUsername_cbo
        '
        Me.CloneFrom_ToUsername_cbo.FormattingEnabled = True
        Me.CloneFrom_ToUsername_cbo.Location = New System.Drawing.Point(96, 39)
        Me.CloneFrom_ToUsername_cbo.Name = "CloneFrom_ToUsername_cbo"
        Me.CloneFrom_ToUsername_cbo.Size = New System.Drawing.Size(181, 21)
        Me.CloneFrom_ToUsername_cbo.TabIndex = 8
        '
        'dgvData
        '
        Me.dgvData.AllowColumnHiding = True
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(17, 90)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.ShowRowNumber = True
        Me.dgvData.Size = New System.Drawing.Size(407, 640)
        Me.dgvData.TabIndex = 10
        '
        'CloneFrom_Clone_rbn
        '
        Me.CloneFrom_Clone_rbn.AutoSize = True
        Me.CloneFrom_Clone_rbn.Location = New System.Drawing.Point(17, 67)
        Me.CloneFrom_Clone_rbn.Name = "CloneFrom_Clone_rbn"
        Me.CloneFrom_Clone_rbn.Size = New System.Drawing.Size(82, 17)
        Me.CloneFrom_Clone_rbn.TabIndex = 11
        Me.CloneFrom_Clone_rbn.Text = "Exact Clone"
        Me.CloneFrom_Clone_rbn.UseVisualStyleBackColor = True
        '
        'CloneFrom_AddMissings_rbn
        '
        Me.CloneFrom_AddMissings_rbn.AutoSize = True
        Me.CloneFrom_AddMissings_rbn.Checked = True
        Me.CloneFrom_AddMissings_rbn.Location = New System.Drawing.Point(105, 66)
        Me.CloneFrom_AddMissings_rbn.Name = "CloneFrom_AddMissings_rbn"
        Me.CloneFrom_AddMissings_rbn.Size = New System.Drawing.Size(87, 17)
        Me.CloneFrom_AddMissings_rbn.TabIndex = 12
        Me.CloneFrom_AddMissings_rbn.TabStop = True
        Me.CloneFrom_AddMissings_rbn.Text = "Add Missings"
        Me.CloneFrom_AddMissings_rbn.UseVisualStyleBackColor = True
        '
        'ClonePermissionsFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 742)
        Me.Controls.Add(Me.CloneFrom_AddMissings_rbn)
        Me.Controls.Add(Me.CloneFrom_Clone_rbn)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CloneFrom_ToUsername_cbo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CloneFrom_Save_btn)
        Me.Controls.Add(Me.CloneFrom_FromUsername_cbo)
        Me.Name = "ClonePermissionsFrom"
        Me.ShowIcon = False
        Me.Text = "Clone From..."
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CloneFrom_Save_btn As System.Windows.Forms.Button
    Friend WithEvents CloneFrom_FromUsername_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CloneFrom_ToUsername_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents dgvData As CAguilar.DataGridViewWithFilters
    Friend WithEvents CloneFrom_Clone_rbn As System.Windows.Forms.RadioButton
    Friend WithEvents CloneFrom_AddMissings_rbn As System.Windows.Forms.RadioButton
End Class
