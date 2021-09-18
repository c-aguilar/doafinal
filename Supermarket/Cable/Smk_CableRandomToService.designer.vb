<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableRandomToService
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableRandomToService))
        Me.Command_txt = New CAguilar.WaterMarkTextBox()
        Me.tmScale = New System.Windows.Forms.Timer(Me.components)
        Me.pbStatusCommand = New System.Windows.Forms.PictureBox()
        Me.Container_pb = New System.Windows.Forms.PictureBox()
        Me.Dolly_pb = New System.Windows.Forms.PictureBox()
        Me.lblTaraWeight = New System.Windows.Forms.Label()
        Me.Serial_txt = New CAguilar.WaterMarkTextBox()
        Me.pbStatusSerie = New System.Windows.Forms.PictureBox()
        Me.Confirm_btn = New System.Windows.Forms.Button()
        Me.Change_btn = New System.Windows.Forms.Button()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Weight_txt = New System.Windows.Forms.TextBox()
        Me.Title_lbl = New System.Windows.Forms.Label()
        CType(Me.pbStatusCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dolly_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command_txt
        '
        Me.Command_txt.BackColor = System.Drawing.Color.Ivory
        Me.Command_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command_txt.Location = New System.Drawing.Point(277, 258)
        Me.Command_txt.Name = "Command_txt"
        Me.Command_txt.Size = New System.Drawing.Size(300, 40)
        Me.Command_txt.TabIndex = 2
        Me.Command_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Command_txt.WaterMarkText = "Espere..."
        '
        'tmScale
        '
        Me.tmScale.Enabled = True
        Me.tmScale.Interval = 200
        '
        'pbStatusCommand
        '
        Me.pbStatusCommand.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusCommand.Image = Global.Delta_ERP.My.Resources.Resources.ajax_loader_gray_512
        Me.pbStatusCommand.Location = New System.Drawing.Point(579, 258)
        Me.pbStatusCommand.Name = "pbStatusCommand"
        Me.pbStatusCommand.Size = New System.Drawing.Size(40, 40)
        Me.pbStatusCommand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbStatusCommand.TabIndex = 11
        Me.pbStatusCommand.TabStop = False
        '
        'Container_pb
        '
        Me.Container_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Container_pb.Location = New System.Drawing.Point(12, 63)
        Me.Container_pb.Name = "Container_pb"
        Me.Container_pb.Size = New System.Drawing.Size(100, 120)
        Me.Container_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Container_pb.TabIndex = 23
        Me.Container_pb.TabStop = False
        '
        'Dolly_pb
        '
        Me.Dolly_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dolly_pb.Location = New System.Drawing.Point(118, 63)
        Me.Dolly_pb.Name = "Dolly_pb"
        Me.Dolly_pb.Size = New System.Drawing.Size(100, 120)
        Me.Dolly_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Dolly_pb.TabIndex = 24
        Me.Dolly_pb.TabStop = False
        '
        'lblTaraWeight
        '
        Me.lblTaraWeight.AutoSize = True
        Me.lblTaraWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaraWeight.ForeColor = System.Drawing.Color.Black
        Me.lblTaraWeight.Location = New System.Drawing.Point(8, 186)
        Me.lblTaraWeight.Name = "lblTaraWeight"
        Me.lblTaraWeight.Size = New System.Drawing.Size(95, 20)
        Me.lblTaraWeight.TabIndex = 27
        Me.lblTaraWeight.Text = "Peso total:"
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(277, 215)
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(300, 40)
        Me.Serial_txt.TabIndex = 1
        Me.Serial_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Serial_txt.WaterMarkText = "Escanee la serie..."
        '
        'pbStatusSerie
        '
        Me.pbStatusSerie.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusSerie.Image = Global.Delta_ERP.My.Resources.Resources.ajax_loader_gray_512
        Me.pbStatusSerie.Location = New System.Drawing.Point(579, 215)
        Me.pbStatusSerie.Name = "pbStatusSerie"
        Me.pbStatusSerie.Size = New System.Drawing.Size(40, 40)
        Me.pbStatusSerie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbStatusSerie.TabIndex = 33
        Me.pbStatusSerie.TabStop = False
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
        Me.Confirm_btn.Location = New System.Drawing.Point(343, 441)
        Me.Confirm_btn.Margin = New System.Windows.Forms.Padding(10)
        Me.Confirm_btn.Name = "Confirm_btn"
        Me.Confirm_btn.Size = New System.Drawing.Size(215, 90)
        Me.Confirm_btn.TabIndex = 121
        Me.Confirm_btn.Text = "CONFIRMAR"
        Me.Confirm_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Confirm_btn.UseVisualStyleBackColor = False
        '
        'Change_btn
        '
        Me.Change_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Change_btn.BackColor = System.Drawing.Color.White
        Me.Change_btn.BackgroundImage = CType(resources.GetObject("Change_btn.BackgroundImage"), System.Drawing.Image)
        Me.Change_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Change_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Change_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Change_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Change_btn.ForeColor = System.Drawing.Color.Black
        Me.Change_btn.Location = New System.Drawing.Point(19, 441)
        Me.Change_btn.Margin = New System.Windows.Forms.Padding(10)
        Me.Change_btn.Name = "Change_btn"
        Me.Change_btn.Size = New System.Drawing.Size(215, 90)
        Me.Change_btn.TabIndex = 119
        Me.Change_btn.Text = "CAMBIAR TARA"
        Me.Change_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Change_btn.UseVisualStyleBackColor = False
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
        Me.Close_btn.TabIndex = 120
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Weight_txt
        '
        Me.Weight_txt.BackColor = System.Drawing.Color.Maroon
        Me.Weight_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Weight_txt.Font = New System.Drawing.Font("DS-Digital", 90.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_txt.ForeColor = System.Drawing.Color.White
        Me.Weight_txt.Location = New System.Drawing.Point(250, 63)
        Me.Weight_txt.Name = "Weight_txt"
        Me.Weight_txt.Size = New System.Drawing.Size(400, 127)
        Me.Weight_txt.TabIndex = 122
        Me.Weight_txt.Text = "0.0"
        Me.Weight_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Title_lbl.Size = New System.Drawing.Size(878, 43)
        Me.Title_lbl.TabIndex = 124
        Me.Title_lbl.Text = "Random a Servicio"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Smk_CableRandomToService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(900, 550)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Command_txt)
        Me.Controls.Add(Me.Weight_txt)
        Me.Controls.Add(Me.Confirm_btn)
        Me.Controls.Add(Me.Change_btn)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.pbStatusSerie)
        Me.Controls.Add(Me.lblTaraWeight)
        Me.Controls.Add(Me.Dolly_pb)
        Me.Controls.Add(Me.Container_pb)
        Me.Controls.Add(Me.pbStatusCommand)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 2000)
        Me.MinimizeBox = False
        Me.Name = "Smk_CableRandomToService"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Random a Servicio"
        CType(Me.pbStatusCommand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dolly_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Command_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents pbStatusCommand As System.Windows.Forms.PictureBox
    Friend WithEvents tmScale As System.Windows.Forms.Timer
    Friend WithEvents Container_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Dolly_pb As System.Windows.Forms.PictureBox
    Friend WithEvents lblTaraWeight As System.Windows.Forms.Label
    Friend WithEvents Serial_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents pbStatusSerie As System.Windows.Forms.PictureBox
    Friend WithEvents Confirm_btn As System.Windows.Forms.Button
    Friend WithEvents Change_btn As System.Windows.Forms.Button
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Weight_txt As System.Windows.Forms.TextBox
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
End Class
