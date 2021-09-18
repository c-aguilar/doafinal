<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_TerminalCutterToService
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_TerminalCutterToService))
        Me.Command_txt = New CAguilar.WaterMarkTextBox()
        Me.tmScale = New System.Windows.Forms.Timer(Me.components)
        Me.Serial_lbl = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Confirm_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Command_txt
        '
        Me.Command_txt.BackColor = System.Drawing.Color.Ivory
        Me.Command_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command_txt.Location = New System.Drawing.Point(318, 138)
        Me.Command_txt.Name = "Command_txt"
        Me.Command_txt.Size = New System.Drawing.Size(300, 40)
        Me.Command_txt.TabIndex = 10
        Me.Command_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Command_txt.WaterMarkText = "Espere..."
        '
        'tmScale
        '
        Me.tmScale.Enabled = True
        Me.tmScale.Interval = 200
        '
        'Serial_lbl
        '
        Me.Serial_lbl.AutoSize = True
        Me.Serial_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Serial_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_lbl.ForeColor = System.Drawing.Color.Black
        Me.Serial_lbl.Location = New System.Drawing.Point(319, 68)
        Me.Serial_lbl.Name = "Serial_lbl"
        Me.Serial_lbl.Size = New System.Drawing.Size(287, 37)
        Me.Serial_lbl.TabIndex = 33
        Me.Serial_lbl.Text = "0FV38900123456"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.AutoSize = True
        Me.Partnumber_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.Partnumber_lbl.Location = New System.Drawing.Point(389, 105)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(159, 33)
        Me.Partnumber_lbl.TabIndex = 34
        Me.Partnumber_lbl.Text = "M1234567"
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
        Me.Close_btn.ForeColor = System.Drawing.Color.Black
        Me.Close_btn.Location = New System.Drawing.Point(666, 441)
        Me.Close_btn.Margin = New System.Windows.Forms.Padding(10)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(215, 90)
        Me.Close_btn.TabIndex = 114
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
        Me.Title_lbl.Location = New System.Drawing.Point(10, 9)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(878, 43)
        Me.Title_lbl.TabIndex = 115
        Me.Title_lbl.Text = "Regreso a Supermercado - Terminal"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Confirm_btn
        '
        Me.Confirm_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Confirm_btn.BackColor = System.Drawing.Color.White
        Me.Confirm_btn.BackgroundImage = CType(resources.GetObject("Confirm_btn.BackgroundImage"), System.Drawing.Image)
        Me.Confirm_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Confirm_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Confirm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Confirm_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Confirm_btn.ForeColor = System.Drawing.Color.Black
        Me.Confirm_btn.Location = New System.Drawing.Point(343, 230)
        Me.Confirm_btn.Margin = New System.Windows.Forms.Padding(10)
        Me.Confirm_btn.Name = "Confirm_btn"
        Me.Confirm_btn.Size = New System.Drawing.Size(215, 90)
        Me.Confirm_btn.TabIndex = 118
        Me.Confirm_btn.Text = "CONFIRMAR"
        Me.Confirm_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Confirm_btn.UseVisualStyleBackColor = False
        '
        'Smk_TerminalCutterToService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(900, 550)
        Me.Controls.Add(Me.Confirm_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Serial_lbl)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Command_txt)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 2000)
        Me.MinimizeBox = False
        Me.Name = "Smk_TerminalCutterToService"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cortadora a Servicio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Command_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents tmScale As System.Windows.Forms.Timer
    Friend WithEvents Serial_lbl As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Confirm_btn As System.Windows.Forms.Button
End Class
