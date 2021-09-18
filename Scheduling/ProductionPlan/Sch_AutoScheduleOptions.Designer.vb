<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_AutoScheduleOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_AutoScheduleOptions))
        Me.chkReplace = New System.Windows.Forms.CheckBox()
        Me.chkAvg = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mcDates = New System.Windows.Forms.MonthCalendar()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.chkRound = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AverageWeeksNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.chkAllowPositive = New System.Windows.Forms.CheckBox()
        CType(Me.AverageWeeksNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkReplace
        '
        Me.chkReplace.AutoSize = True
        Me.chkReplace.Location = New System.Drawing.Point(12, 192)
        Me.chkReplace.Name = "chkReplace"
        Me.chkReplace.Size = New System.Drawing.Size(138, 17)
        Me.chkReplace.TabIndex = 0
        Me.chkReplace.Text = "Replace existing values"
        Me.chkReplace.UseVisualStyleBackColor = True
        '
        'chkAvg
        '
        Me.chkAvg.AutoSize = True
        Me.chkAvg.Checked = True
        Me.chkAvg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAvg.Location = New System.Drawing.Point(12, 215)
        Me.chkAvg.Name = "chkAvg"
        Me.chkAvg.Size = New System.Drawing.Size(167, 17)
        Me.chkAvg.TabIndex = 1
        Me.chkAvg.Text = "Weekly average requirements"
        Me.chkAvg.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date range:"
        '
        'mcDates
        '
        Me.mcDates.CalendarDimensions = New System.Drawing.Size(2, 1)
        Me.mcDates.Location = New System.Drawing.Point(7, 31)
        Me.mcDates.MaxSelectionCount = 90
        Me.mcDates.Name = "mcDates"
        Me.mcDates.ShowToday = False
        Me.mcDates.ShowTodayCircle = False
        Me.mcDates.ShowWeekNumbers = True
        Me.mcDates.TabIndex = 6
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(411, 238)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 8
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.Location = New System.Drawing.Point(308, 238)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 7
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'chkRound
        '
        Me.chkRound.AutoSize = True
        Me.chkRound.Checked = True
        Me.chkRound.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRound.Location = New System.Drawing.Point(12, 238)
        Me.chkRound.Name = "chkRound"
        Me.chkRound.Size = New System.Drawing.Size(137, 17)
        Me.chkRound.TabIndex = 11
        Me.chkRound.Text = "Round by standar pack"
        Me.chkRound.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(499, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "_________________________________________________________________________________" & _
    "_"
        '
        'AverageWeeksNumericUpDown
        '
        Me.AverageWeeksNumericUpDown.Location = New System.Drawing.Point(185, 214)
        Me.AverageWeeksNumericUpDown.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.AverageWeeksNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.AverageWeeksNumericUpDown.Name = "AverageWeeksNumericUpDown"
        Me.AverageWeeksNumericUpDown.Size = New System.Drawing.Size(43, 20)
        Me.AverageWeeksNumericUpDown.TabIndex = 14
        Me.AverageWeeksNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAllowPositive
        '
        Me.chkAllowPositive.AutoSize = True
        Me.chkAllowPositive.Checked = True
        Me.chkAllowPositive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllowPositive.Location = New System.Drawing.Point(264, 192)
        Me.chkAllowPositive.Name = "chkAllowPositive"
        Me.chkAllowPositive.Size = New System.Drawing.Size(119, 17)
        Me.chkAllowPositive.TabIndex = 15
        Me.chkAllowPositive.Text = "Allow positive stock"
        Me.chkAllowPositive.UseVisualStyleBackColor = True
        '
        'AutoScheduleOptions
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(517, 268)
        Me.Controls.Add(Me.chkAllowPositive)
        Me.Controls.Add(Me.AverageWeeksNumericUpDown)
        Me.Controls.Add(Me.chkRound)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.mcDates)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkAvg)
        Me.Controls.Add(Me.chkReplace)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoScheduleOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auto Scheduling Options"
        CType(Me.AverageWeeksNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkReplace As System.Windows.Forms.CheckBox
    Friend WithEvents chkAvg As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mcDates As System.Windows.Forms.MonthCalendar
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents chkRound As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AverageWeeksNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAllowPositive As System.Windows.Forms.CheckBox
End Class
