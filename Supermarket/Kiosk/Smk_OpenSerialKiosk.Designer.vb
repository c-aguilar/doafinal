<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_OpenSerialKiosk
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_OpenSerialKiosk))
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.CountDown_lbl = New System.Windows.Forms.Label()
        Me.CountDown_timer = New System.Windows.Forms.Timer(Me.components)
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
        Me.Title_lbl.Size = New System.Drawing.Size(363, 25)
        Me.Title_lbl.TabIndex = 88
        Me.Title_lbl.Text = "Abrir Contenedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Serie:"
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(74, 83)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(215, 31)
        Me.Serial_txt.TabIndex = 1
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.BackColor = System.Drawing.Color.White
        Me.Close_btn.BackgroundImage = CType(resources.GetObject("Close_btn.BackgroundImage"), System.Drawing.Image)
        Me.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Close_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.Location = New System.Drawing.Point(80, 157)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(202, 86)
        Me.Close_btn.TabIndex = 106
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'CountDown_lbl
        '
        Me.CountDown_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountDown_lbl.BackColor = System.Drawing.Color.Transparent
        Me.CountDown_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountDown_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.CountDown_lbl.Location = New System.Drawing.Point(28, 34)
        Me.CountDown_lbl.Name = "CountDown_lbl"
        Me.CountDown_lbl.Size = New System.Drawing.Size(326, 26)
        Me.CountDown_lbl.TabIndex = 105
        Me.CountDown_lbl.Text = "Tiempo restante: 30"
        Me.CountDown_lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'CountDown_timer
        '
        Me.CountDown_timer.Interval = 1000
        '
        'Smk_OpenSerialKiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 255)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.CountDown_lbl)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Title_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_OpenSerialKiosk"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents CountDown_lbl As System.Windows.Forms.Label
    Friend WithEvents CountDown_timer As System.Windows.Forms.Timer
End Class
