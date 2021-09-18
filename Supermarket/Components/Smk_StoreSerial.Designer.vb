<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_StoreSerial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_StoreSerial))
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Store_btn = New System.Windows.Forms.Button()
        Me.Location_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Title_lbl
        '
        Me.Title_lbl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Title_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(304, 25)
        Me.Title_lbl.TabIndex = 88
        Me.Title_lbl.Text = "Alta de Series"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Local de reserva:"
        '
        'Store_btn
        '
        Me.Store_btn.Image = CType(resources.GetObject("Store_btn.Image"), System.Drawing.Image)
        Me.Store_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Store_btn.Location = New System.Drawing.Point(102, 125)
        Me.Store_btn.Name = "Store_btn"
        Me.Store_btn.Size = New System.Drawing.Size(100, 25)
        Me.Store_btn.TabIndex = 3
        Me.Store_btn.Text = "Aceptar"
        Me.Store_btn.UseVisualStyleBackColor = True
        '
        'Location_txt
        '
        Me.Location_txt.BackColor = System.Drawing.Color.Ivory
        Me.Location_txt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Location_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location_txt.Location = New System.Drawing.Point(157, 78)
        Me.Location_txt.Mask = "00-00-00-00"
        Me.Location_txt.Name = "Location_txt"
        Me.Location_txt.Size = New System.Drawing.Size(109, 26)
        Me.Location_txt.TabIndex = 2
        Me.Location_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Location_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(111, 46)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(155, 26)
        Me.Serial_txt.TabIndex = 1
        '
        'Smk_StoreSerial
        '
        Me.AcceptButton = Me.Store_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 162)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Location_txt)
        Me.Controls.Add(Me.Store_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Title_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_StoreSerial"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Store_btn As System.Windows.Forms.Button
    Friend WithEvents Location_txt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
End Class
