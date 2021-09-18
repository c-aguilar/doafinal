<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_CSVProductionPlanOptionsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_CSVProductionPlanOptionsDialog))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChangeDate = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudWeeks = New System.Windows.Forms.NumericUpDown()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        CType(Me.nudWeeks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From:"
        '
        'btnChangeDate
        '
        Me.btnChangeDate.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChangeDate.Image = CType(resources.GetObject("btnChangeDate.Image"), System.Drawing.Image)
        Me.btnChangeDate.Location = New System.Drawing.Point(204, 23)
        Me.btnChangeDate.Name = "btnChangeDate"
        Me.btnChangeDate.Size = New System.Drawing.Size(25, 23)
        Me.btnChangeDate.TabIndex = 1
        Me.btnChangeDate.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(178, 94)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 13
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.Location = New System.Drawing.Point(75, 94)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 12
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Weeks:"
        '
        'nudWeeks
        '
        Me.nudWeeks.Location = New System.Drawing.Point(82, 51)
        Me.nudWeeks.Maximum = New Decimal(New Integer() {21, 0, 0, 0})
        Me.nudWeeks.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudWeeks.Name = "nudWeeks"
        Me.nudWeeks.Size = New System.Drawing.Size(120, 20)
        Me.nudWeeks.TabIndex = 15
        Me.nudWeeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWeeks.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(82, 25)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.ReadOnly = True
        Me.txtFrom.Size = New System.Drawing.Size(120, 20)
        Me.txtFrom.TabIndex = 16
        '
        'Sch_CSVProductionPlanOptionsDialog
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(284, 130)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.nudWeeks)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.btnChangeDate)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Sch_CSVProductionPlanOptionsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Production Plan"
        CType(Me.nudWeeks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChangeDate As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudWeeks As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
End Class
