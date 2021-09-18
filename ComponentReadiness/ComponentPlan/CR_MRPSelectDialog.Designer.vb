<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_MRPSelectDialog
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
        Me.MRP_tree = New System.Windows.Forms.TreeView()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Horizon_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.All_chk = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'MRP_tree
        '
        Me.MRP_tree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MRP_tree.BackColor = System.Drawing.Color.White
        Me.MRP_tree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MRP_tree.CheckBoxes = True
        Me.MRP_tree.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRP_tree.ForeColor = System.Drawing.Color.Black
        Me.MRP_tree.Indent = 15
        Me.MRP_tree.ItemHeight = 25
        Me.MRP_tree.Location = New System.Drawing.Point(8, 7)
        Me.MRP_tree.Name = "MRP_tree"
        Me.MRP_tree.Size = New System.Drawing.Size(202, 339)
        Me.MRP_tree.TabIndex = 6
        '
        'OK_btn
        '
        Me.OK_btn.Image = Global.Delta_ERP.My.Resources.Resources.ok_16
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(34, 393)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(85, 23)
        Me.OK_btn.TabIndex = 7
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.critical_16
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(125, 394)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(85, 23)
        Me.Cancel_btn.TabIndex = 8
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'Horizon_dtp
        '
        Me.Horizon_dtp.Location = New System.Drawing.Point(8, 368)
        Me.Horizon_dtp.Name = "Horizon_dtp"
        Me.Horizon_dtp.Size = New System.Drawing.Size(200, 20)
        Me.Horizon_dtp.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 349)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Horizonte:"
        '
        'All_chk
        '
        Me.All_chk.AutoSize = True
        Me.All_chk.Location = New System.Drawing.Point(8, 398)
        Me.All_chk.Name = "All_chk"
        Me.All_chk.Size = New System.Drawing.Size(15, 14)
        Me.All_chk.TabIndex = 12
        Me.All_chk.UseVisualStyleBackColor = True
        '
        'CR_MRPSelectDialog
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(217, 424)
        Me.Controls.Add(Me.All_chk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Horizon_dtp)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.MRP_tree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CR_MRPSelectDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CR_MRPSelectDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MRP_tree As System.Windows.Forms.TreeView
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents Horizon_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents All_chk As System.Windows.Forms.CheckBox
End Class
