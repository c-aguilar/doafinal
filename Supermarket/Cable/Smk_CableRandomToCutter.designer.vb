﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableRandomToCutter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableRandomToCutter))
        Me.Serial_lbl = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Weight_txt = New System.Windows.Forms.TextBox()
        Me.tmScale = New System.Windows.Forms.Timer(Me.components)
        Me.lblTaraWeight = New System.Windows.Forms.Label()
        Me.Dolly_pb = New System.Windows.Forms.PictureBox()
        Me.Container_pb = New System.Windows.Forms.PictureBox()
        Me.Cutter_txt = New CAguilar.WaterMarkTextBox()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Change_btn = New System.Windows.Forms.Button()
        Me.Close_btn = New System.Windows.Forms.Button()
        CType(Me.Dolly_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Serial_lbl
        '
        Me.Serial_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Serial_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_lbl.ForeColor = System.Drawing.Color.Black
        Me.Serial_lbl.Location = New System.Drawing.Point(259, 210)
        Me.Serial_lbl.Name = "Serial_lbl"
        Me.Serial_lbl.Size = New System.Drawing.Size(383, 49)
        Me.Serial_lbl.TabIndex = 1
        Me.Serial_lbl.Text = "0FV38900123456"
        Me.Serial_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.ForeColor = System.Drawing.Color.DimGray
        Me.Partnumber_lbl.Location = New System.Drawing.Point(339, 249)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(223, 34)
        Me.Partnumber_lbl.TabIndex = 2
        Me.Partnumber_lbl.Text = "M1234567"
        Me.Partnumber_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Weight_txt
        '
        Me.Weight_txt.BackColor = System.Drawing.Color.Maroon
        Me.Weight_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Weight_txt.Font = New System.Drawing.Font("DS-Digital", 90.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_txt.ForeColor = System.Drawing.Color.White
        Me.Weight_txt.Location = New System.Drawing.Point(250, 61)
        Me.Weight_txt.Name = "Weight_txt"
        Me.Weight_txt.Size = New System.Drawing.Size(400, 127)
        Me.Weight_txt.TabIndex = 19
        Me.Weight_txt.Text = "0.0"
        Me.Weight_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tmScale
        '
        Me.tmScale.Enabled = True
        Me.tmScale.Interval = 200
        '
        'lblTaraWeight
        '
        Me.lblTaraWeight.AutoSize = True
        Me.lblTaraWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaraWeight.ForeColor = System.Drawing.Color.Black
        Me.lblTaraWeight.Location = New System.Drawing.Point(8, 184)
        Me.lblTaraWeight.Name = "lblTaraWeight"
        Me.lblTaraWeight.Size = New System.Drawing.Size(95, 20)
        Me.lblTaraWeight.TabIndex = 30
        Me.lblTaraWeight.Text = "Peso total:"
        '
        'Dolly_pb
        '
        Me.Dolly_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Dolly_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dolly_pb.Location = New System.Drawing.Point(118, 61)
        Me.Dolly_pb.Name = "Dolly_pb"
        Me.Dolly_pb.Size = New System.Drawing.Size(100, 120)
        Me.Dolly_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Dolly_pb.TabIndex = 29
        Me.Dolly_pb.TabStop = False
        '
        'Container_pb
        '
        Me.Container_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Container_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Container_pb.Location = New System.Drawing.Point(12, 61)
        Me.Container_pb.Name = "Container_pb"
        Me.Container_pb.Size = New System.Drawing.Size(100, 120)
        Me.Container_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Container_pb.TabIndex = 28
        Me.Container_pb.TabStop = False
        '
        'Cutter_txt
        '
        Me.Cutter_txt.BackColor = System.Drawing.Color.Ivory
        Me.Cutter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cutter_txt.Location = New System.Drawing.Point(270, 286)
        Me.Cutter_txt.Name = "Cutter_txt"
        Me.Cutter_txt.Size = New System.Drawing.Size(360, 40)
        Me.Cutter_txt.TabIndex = 10
        Me.Cutter_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Cutter_txt.WaterMarkText = "Seleccione la cortadora..."
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
        Me.Title_lbl.Size = New System.Drawing.Size(876, 43)
        Me.Title_lbl.TabIndex = 38
        Me.Title_lbl.Text = "Primera Salida a Cortadoras"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Change_btn.TabIndex = 41
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
        Me.Close_btn.TabIndex = 112
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Smk_CableRandomToCutter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(900, 550)
        Me.Controls.Add(Me.Change_btn)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Cutter_txt)
        Me.Controls.Add(Me.Container_pb)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Weight_txt)
        Me.Controls.Add(Me.Dolly_pb)
        Me.Controls.Add(Me.lblTaraWeight)
        Me.Controls.Add(Me.Serial_lbl)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableRandomToCutter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Primera Salida a Cortadora"
        CType(Me.Dolly_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Serial_lbl As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Weight_txt As System.Windows.Forms.TextBox
    Friend WithEvents tmScale As System.Windows.Forms.Timer
    Friend WithEvents lblTaraWeight As System.Windows.Forms.Label
    Friend WithEvents Dolly_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Container_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Cutter_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Change_btn As System.Windows.Forms.Button
    Friend WithEvents Close_btn As System.Windows.Forms.Button
End Class