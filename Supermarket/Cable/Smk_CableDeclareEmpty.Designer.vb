<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableDeclareEmpty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableDeclareEmpty))
        Me.Serial_txt = New CAguilar.WaterMarkTextBox()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.CountDown_timer = New System.Windows.Forms.Timer(Me.components)
        Me.CountDown_lbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(108, 83)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(300, 40)
        Me.Serial_txt.TabIndex = 1
        Me.Serial_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Serial_txt.WaterMarkText = "Escanee la serie..."
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
        Me.Close_btn.Location = New System.Drawing.Point(151, 147)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(215, 90)
        Me.Close_btn.TabIndex = 91
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 9)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(498, 43)
        Me.Title_lbl.TabIndex = 116
        Me.Title_lbl.Text = "Declarar Vacio"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CountDown_timer
        '
        Me.CountDown_timer.Interval = 1000
        '
        'CountDown_lbl
        '
        Me.CountDown_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountDown_lbl.BackColor = System.Drawing.Color.Transparent
        Me.CountDown_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountDown_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.CountDown_lbl.Location = New System.Drawing.Point(260, 54)
        Me.CountDown_lbl.Name = "CountDown_lbl"
        Me.CountDown_lbl.Size = New System.Drawing.Size(250, 26)
        Me.CountDown_lbl.TabIndex = 117
        Me.CountDown_lbl.Text = "Tiempo restante: 30"
        Me.CountDown_lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Smk_CableDeclareEmpty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 249)
        Me.Controls.Add(Me.CountDown_lbl)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Serial_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableDeclareEmpty"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supermarket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Serial_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents CountDown_timer As System.Windows.Forms.Timer
    Friend WithEvents CountDown_lbl As System.Windows.Forms.Label
End Class
