<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ComponentPlanNewOrderFake
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ComponentPlanNewOrderFake))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Date_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.NewQuantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 16)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Fecha de pickup:"
        '
        'Date_dtp
        '
        Me.Date_dtp.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_dtp.CalendarMonthBackground = System.Drawing.Color.Ivory
        Me.Date_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_dtp.Location = New System.Drawing.Point(135, 68)
        Me.Date_dtp.Name = "Date_dtp"
        Me.Date_dtp.Size = New System.Drawing.Size(120, 26)
        Me.Date_dtp.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Cantidad:"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(241, 100)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 101
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'NewQuantity_nud
        '
        Me.NewQuantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.NewQuantity_nud.DecimalPlaces = 3
        Me.NewQuantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewQuantity_nud.Location = New System.Drawing.Point(135, 35)
        Me.NewQuantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NewQuantity_nud.Name = "NewQuantity_nud"
        Me.NewQuantity_nud.Size = New System.Drawing.Size(120, 26)
        Me.NewQuantity_nud.TabIndex = 99
        Me.NewQuantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OK_btn
        '
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(135, 100)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 100
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "No. de Parte:"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.AutoSize = True
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.Location = New System.Drawing.Point(137, 12)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(131, 20)
        Me.Partnumber_lbl.TabIndex = 110
        Me.Partnumber_lbl.Text = "PARTNUMBER"
        '
        'CR_ComponentPlanNewOrderFake
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(353, 134)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.NewQuantity_nud)
        Me.Controls.Add(Me.OK_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CR_ComponentPlanNewOrderFake"
        Me.Text = "Nueva Orden"
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents NewQuantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
End Class
