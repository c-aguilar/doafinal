<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calendar))
        Me.mcFrom = New System.Windows.Forms.MonthCalendar()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mcFrom
        '
        Me.mcFrom.CalendarDimensions = New System.Drawing.Size(2, 1)
        Me.mcFrom.Location = New System.Drawing.Point(-5, 0)
        Me.mcFrom.MaxSelectionCount = 1
        Me.mcFrom.Name = "mcFrom"
        Me.mcFrom.ShowWeekNumbers = True
        Me.mcFrom.TabIndex = 0
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(393, 166)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.Location = New System.Drawing.Point(290, 166)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 9
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Calendar
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(491, 194)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.mcFrom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Calendar"
        Me.Text = "Calendario"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mcFrom As System.Windows.Forms.MonthCalendar
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
End Class
