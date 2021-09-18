<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_ManualAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_ManualAdjustment))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Adjust_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewQuantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CurrentQuantity_lbl = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(335, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Ajuste Manual"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Serie:"
        '
        'Adjust_btn
        '
        Me.Adjust_btn.Image = CType(resources.GetObject("Adjust_btn.Image"), System.Drawing.Image)
        Me.Adjust_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Adjust_btn.Location = New System.Drawing.Point(64, 156)
        Me.Adjust_btn.Name = "Adjust_btn"
        Me.Adjust_btn.Size = New System.Drawing.Size(100, 25)
        Me.Adjust_btn.TabIndex = 3
        Me.Adjust_btn.Text = "Ajustar"
        Me.Adjust_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Nueva cantidad:"
        '
        'NewQuantity_nud
        '
        Me.NewQuantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.NewQuantity_nud.DecimalPlaces = 3
        Me.NewQuantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewQuantity_nud.Location = New System.Drawing.Point(163, 109)
        Me.NewQuantity_nud.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NewQuantity_nud.Name = "NewQuantity_nud"
        Me.NewQuantity_nud.Size = New System.Drawing.Size(120, 26)
        Me.NewQuantity_nud.TabIndex = 2
        Me.NewQuantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Cantidad actual:"
        '
        'CurrentQuantity_lbl
        '
        Me.CurrentQuantity_lbl.AutoSize = True
        Me.CurrentQuantity_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentQuantity_lbl.Location = New System.Drawing.Point(154, 78)
        Me.CurrentQuantity_lbl.Name = "CurrentQuantity_lbl"
        Me.CurrentQuantity_lbl.Size = New System.Drawing.Size(16, 24)
        Me.CurrentQuantity_lbl.TabIndex = 100
        Me.CurrentQuantity_lbl.Text = "-"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Image = CType(resources.GetObject("Cancel_btn.Image"), System.Drawing.Image)
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(170, 156)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 4
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(100, 49)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(183, 26)
        Me.Serial_txt.TabIndex = 1
        '
        'Smk_ManualAdjustment
        '
        Me.AcceptButton = Me.Adjust_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 195)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.CurrentQuantity_lbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NewQuantity_nud)
        Me.Controls.Add(Me.Adjust_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_ManualAdjustment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.NewQuantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Adjust_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewQuantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CurrentQuantity_lbl As System.Windows.Forms.Label
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
End Class
