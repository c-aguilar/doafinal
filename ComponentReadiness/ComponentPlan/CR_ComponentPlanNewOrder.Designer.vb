<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ComponentPlanNewOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ComponentPlanNewOrder))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Date_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.NewQuantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TSA_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Item_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Title_lbl = New System.Windows.Forms.Label()
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Fecha de pickup:"
        '
        'Date_dtp
        '
        Me.Date_dtp.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_dtp.CalendarMonthBackground = System.Drawing.Color.Ivory
        Me.Date_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_dtp.Location = New System.Drawing.Point(105, 82)
        Me.Date_dtp.Name = "Date_dtp"
        Me.Date_dtp.Size = New System.Drawing.Size(120, 20)
        Me.Date_dtp.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Cantidad:"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(223, 178)
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
        Me.NewQuantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewQuantity_nud.Location = New System.Drawing.Point(105, 56)
        Me.NewQuantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NewQuantity_nud.Name = "NewQuantity_nud"
        Me.NewQuantity_nud.Size = New System.Drawing.Size(120, 20)
        Me.NewQuantity_nud.TabIndex = 99
        Me.NewQuantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OK_btn
        '
        Me.OK_btn.Image = CType(resources.GetObject("OK_btn.Image"), System.Drawing.Image)
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(117, 178)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(100, 25)
        Me.OK_btn.TabIndex = 100
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "(T)SA:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Item:"
        '
        'TSA_txt
        '
        Me.TSA_txt.BackColor = System.Drawing.Color.Ivory
        Me.TSA_txt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.TSA_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSA_txt.Location = New System.Drawing.Point(105, 108)
        Me.TSA_txt.Mask = "000000000"
        Me.TSA_txt.Name = "TSA_txt"
        Me.TSA_txt.Size = New System.Drawing.Size(109, 20)
        Me.TSA_txt.TabIndex = 115
        Me.TSA_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TSA_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Item_txt
        '
        Me.Item_txt.BackColor = System.Drawing.Color.Ivory
        Me.Item_txt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Item_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Item_txt.Location = New System.Drawing.Point(105, 134)
        Me.Item_txt.Mask = "00000"
        Me.Item_txt.Name = "Item_txt"
        Me.Item_txt.Size = New System.Drawing.Size(109, 20)
        Me.Item_txt.TabIndex = 116
        Me.Item_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Item_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Title_lbl
        '
        Me.Title_lbl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Title_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(330, 25)
        Me.Title_lbl.TabIndex = 117
        Me.Title_lbl.Text = "Title"
        '
        'CR_ComponentPlanNewOrder
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(330, 210)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Item_txt)
        Me.Controls.Add(Me.TSA_txt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.NewQuantity_nud)
        Me.Controls.Add(Me.OK_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CR_ComponentPlanNewOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TSA_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Item_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
End Class
