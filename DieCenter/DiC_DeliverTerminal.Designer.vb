<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiC_DeliverTerminal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiC_DeliverTerminal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Option_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Count_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DieCenter_lbl = New System.Windows.Forms.Label()
        Me.CountDown_lbl = New System.Windows.Forms.Label()
        Me.CountDown_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Option_txt)
        Me.Panel1.Location = New System.Drawing.Point(121, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(297, 41)
        Me.Panel1.TabIndex = 28
        '
        'Option_txt
        '
        Me.Option_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Option_txt.BackColor = System.Drawing.Color.White
        Me.Option_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option_txt.ForeColor = System.Drawing.Color.Black
        Me.Option_txt.Location = New System.Drawing.Point(3, 3)
        Me.Option_txt.Name = "Option_txt"
        Me.Option_txt.Size = New System.Drawing.Size(291, 35)
        Me.Option_txt.TabIndex = 24
        Me.Option_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Option_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Option_txt.WaterMarkText = "Escanea la serie..."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Count_lbl)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(204, 154)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(130, 100)
        Me.Panel2.TabIndex = 50
        '
        'Count_lbl
        '
        Me.Count_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Count_lbl.Location = New System.Drawing.Point(3, 5)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(122, 55)
        Me.Count_lbl.TabIndex = 49
        Me.Count_lbl.Text = "0"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 28)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "CONTEO TOTAL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DieCenter_lbl
        '
        Me.DieCenter_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DieCenter_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.DieCenter_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DieCenter_lbl.ForeColor = System.Drawing.Color.White
        Me.DieCenter_lbl.Location = New System.Drawing.Point(12, 9)
        Me.DieCenter_lbl.Name = "DieCenter_lbl"
        Me.DieCenter_lbl.Size = New System.Drawing.Size(514, 43)
        Me.DieCenter_lbl.TabIndex = 51
        Me.DieCenter_lbl.Text = "Entrega de Terminales"
        Me.DieCenter_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CountDown_lbl
        '
        Me.CountDown_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountDown_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CountDown_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountDown_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CountDown_lbl.Location = New System.Drawing.Point(312, 54)
        Me.CountDown_lbl.Name = "CountDown_lbl"
        Me.CountDown_lbl.Size = New System.Drawing.Size(214, 35)
        Me.CountDown_lbl.TabIndex = 52
        Me.CountDown_lbl.Text = "Tiempo restante: 0"
        Me.CountDown_lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'CountDown_timer
        '
        Me.CountDown_timer.Enabled = True
        Me.CountDown_timer.Interval = 1000
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
        Me.Close_btn.Location = New System.Drawing.Point(150, 304)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(238, 93)
        Me.Close_btn.TabIndex = 54
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'DiC_DeliverTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 409)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.CountDown_lbl)
        Me.Controls.Add(Me.DieCenter_lbl)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DiC_DeliverTerminal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DiC_DeliverTerminal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Option_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Count_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DieCenter_lbl As System.Windows.Forms.Label
    Friend WithEvents CountDown_lbl As System.Windows.Forms.Label
    Friend WithEvents CountDown_timer As System.Windows.Forms.Timer
    Friend WithEvents Close_btn As System.Windows.Forms.Button
End Class
