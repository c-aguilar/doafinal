<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_UploadDateRangeSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_UploadDateRangeSelector))
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpWeek = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnShowDates = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.Image = CType(resources.GetObject("btnDownload.Image"), System.Drawing.Image)
        Me.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDownload.Location = New System.Drawing.Point(46, 92)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(160, 25)
        Me.btnDownload.TabIndex = 28
        Me.btnDownload.Text = "Download from SAP"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "SAP To:"
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = ""
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(97, 40)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(109, 20)
        Me.dtpTo.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(13, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Real Week:"
        '
        'dtpWeek
        '
        Me.dtpWeek.CustomFormat = ""
        Me.dtpWeek.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWeek.Location = New System.Drawing.Point(97, 66)
        Me.dtpWeek.Name = "dtpWeek"
        Me.dtpWeek.Size = New System.Drawing.Size(109, 20)
        Me.dtpWeek.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "SAP From:"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = ""
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(97, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(109, 20)
        Me.dtpFrom.TabIndex = 21
        '
        'btnShowDates
        '
        Me.btnShowDates.Image = CType(resources.GetObject("btnShowDates.Image"), System.Drawing.Image)
        Me.btnShowDates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowDates.Location = New System.Drawing.Point(46, 123)
        Me.btnShowDates.Name = "btnShowDates"
        Me.btnShowDates.Size = New System.Drawing.Size(160, 25)
        Me.btnShowDates.TabIndex = 29
        Me.btnShowDates.Text = "Downloaded Weeks"
        Me.btnShowDates.UseVisualStyleBackColor = True
        '
        'Sch_UploadDateRangeSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(217, 155)
        Me.Controls.Add(Me.btnShowDates)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpWeek)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Sch_UploadDateRangeSelector"
        Me.ShowIcon = False
        Me.Text = "Import Scheduling Upload"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpWeek As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnShowDates As System.Windows.Forms.Button
End Class
