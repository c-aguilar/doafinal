﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableAPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableAPI))
        Me.tmScale = New System.Windows.Forms.Timer(Me.components)
        Me.Container_pb = New System.Windows.Forms.PictureBox()
        Me.lblTaraWeight = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Weight_txt = New System.Windows.Forms.TextBox()
        Me.Serial_txt = New CAguilar.WaterMarkTextBox()
        Me.Command_txt = New CAguilar.WaterMarkTextBox()
        Me.Confirm_btn = New System.Windows.Forms.Button()
        Me.Change_btn = New System.Windows.Forms.Button()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Partnumber_pb = New System.Windows.Forms.PictureBox()
        Me.Command_pb = New System.Windows.Forms.PictureBox()
        Me.FinalizeTicket_btn = New System.Windows.Forms.Button()
        Me.TaraName_lbl = New System.Windows.Forms.Label()
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Partnumber_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Command_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmScale
        '
        Me.tmScale.Enabled = True
        Me.tmScale.Interval = 200
        '
        'Container_pb
        '
        Me.Container_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Container_pb.Location = New System.Drawing.Point(12, 62)
        Me.Container_pb.Name = "Container_pb"
        Me.Container_pb.Size = New System.Drawing.Size(100, 120)
        Me.Container_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Container_pb.TabIndex = 23
        Me.Container_pb.TabStop = False
        '
        'lblTaraWeight
        '
        Me.lblTaraWeight.AutoSize = True
        Me.lblTaraWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaraWeight.ForeColor = System.Drawing.Color.Black
        Me.lblTaraWeight.Location = New System.Drawing.Point(12, 208)
        Me.lblTaraWeight.Name = "lblTaraWeight"
        Me.lblTaraWeight.Size = New System.Drawing.Size(95, 20)
        Me.lblTaraWeight.TabIndex = 27
        Me.lblTaraWeight.Text = "Peso total:"
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.Black
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("DS-Digital", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.ForeColor = System.Drawing.Color.White
        Me.txtQty.Location = New System.Drawing.Point(280, 190)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(340, 55)
        Me.txtQty.TabIndex = 0
        Me.txtQty.Text = "indefinido"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Title_lbl.TabIndex = 125
        Me.Title_lbl.Text = "Inventario Fisico"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Weight_txt
        '
        Me.Weight_txt.BackColor = System.Drawing.Color.Maroon
        Me.Weight_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Weight_txt.Font = New System.Drawing.Font("DS-Digital", 90.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_txt.ForeColor = System.Drawing.Color.White
        Me.Weight_txt.Location = New System.Drawing.Point(280, 63)
        Me.Weight_txt.Name = "Weight_txt"
        Me.Weight_txt.Size = New System.Drawing.Size(340, 127)
        Me.Weight_txt.TabIndex = 126
        Me.Weight_txt.Text = "0.0"
        Me.Weight_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(277, 281)
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(300, 40)
        Me.Serial_txt.TabIndex = 127
        Me.Serial_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Serial_txt.WaterMarkText = "Escanee la serie..."
        '
        'Command_txt
        '
        Me.Command_txt.BackColor = System.Drawing.Color.Ivory
        Me.Command_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command_txt.Location = New System.Drawing.Point(277, 324)
        Me.Command_txt.Name = "Command_txt"
        Me.Command_txt.Size = New System.Drawing.Size(300, 40)
        Me.Command_txt.TabIndex = 128
        Me.Command_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Command_txt.WaterMarkText = "Espere..."
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
        Me.Confirm_btn.TabIndex = 133
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
        Me.Change_btn.TabIndex = 131
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
        Me.Close_btn.TabIndex = 132
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Partnumber_pb
        '
        Me.Partnumber_pb.BackColor = System.Drawing.Color.Transparent
        Me.Partnumber_pb.Image = Global.Delta_ERP.My.Resources.Resources.ajax_loader_gray_512
        Me.Partnumber_pb.Location = New System.Drawing.Point(583, 281)
        Me.Partnumber_pb.Name = "Partnumber_pb"
        Me.Partnumber_pb.Size = New System.Drawing.Size(40, 40)
        Me.Partnumber_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Partnumber_pb.TabIndex = 130
        Me.Partnumber_pb.TabStop = False
        '
        'Command_pb
        '
        Me.Command_pb.BackColor = System.Drawing.Color.Transparent
        Me.Command_pb.Image = Global.Delta_ERP.My.Resources.Resources.ajax_loader_gray_512
        Me.Command_pb.Location = New System.Drawing.Point(583, 324)
        Me.Command_pb.Name = "Command_pb"
        Me.Command_pb.Size = New System.Drawing.Size(40, 40)
        Me.Command_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Command_pb.TabIndex = 129
        Me.Command_pb.TabStop = False
        '
        'FinalizeTicket_btn
        '
        Me.FinalizeTicket_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalizeTicket_btn.ForeColor = System.Drawing.Color.Black
        Me.FinalizeTicket_btn.Image = CType(resources.GetObject("FinalizeTicket_btn.Image"), System.Drawing.Image)
        Me.FinalizeTicket_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FinalizeTicket_btn.Location = New System.Drawing.Point(666, 62)
        Me.FinalizeTicket_btn.Name = "FinalizeTicket_btn"
        Me.FinalizeTicket_btn.Size = New System.Drawing.Size(222, 43)
        Me.FinalizeTicket_btn.TabIndex = 134
        Me.FinalizeTicket_btn.Text = "Finalizar Ticket"
        Me.FinalizeTicket_btn.UseVisualStyleBackColor = True
        '
        'TaraName_lbl
        '
        Me.TaraName_lbl.AutoSize = True
        Me.TaraName_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaraName_lbl.ForeColor = System.Drawing.Color.Black
        Me.TaraName_lbl.Location = New System.Drawing.Point(12, 185)
        Me.TaraName_lbl.Name = "TaraName_lbl"
        Me.TaraName_lbl.Size = New System.Drawing.Size(50, 20)
        Me.TaraName_lbl.TabIndex = 135
        Me.TaraName_lbl.Text = "Tara:"
        '
        'Smk_CableAPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(900, 550)
        Me.Controls.Add(Me.TaraName_lbl)
        Me.Controls.Add(Me.FinalizeTicket_btn)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Command_txt)
        Me.Controls.Add(Me.Confirm_btn)
        Me.Controls.Add(Me.Change_btn)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Partnumber_pb)
        Me.Controls.Add(Me.Command_pb)
        Me.Controls.Add(Me.Weight_txt)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.lblTaraWeight)
        Me.Controls.Add(Me.Container_pb)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1200, 1200)
        Me.MinimizeBox = False
        Me.Name = "Smk_CableAPI"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supermarket"
        CType(Me.Container_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Partnumber_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Command_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmScale As System.Windows.Forms.Timer
    Friend WithEvents Container_pb As System.Windows.Forms.PictureBox
    Friend WithEvents lblTaraWeight As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Weight_txt As System.Windows.Forms.TextBox
    Friend WithEvents Serial_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Command_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Confirm_btn As System.Windows.Forms.Button
    Friend WithEvents Change_btn As System.Windows.Forms.Button
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumber_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Command_pb As System.Windows.Forms.PictureBox
    Friend WithEvents FinalizeTicket_btn As System.Windows.Forms.Button
    Friend WithEvents TaraName_lbl As System.Windows.Forms.Label
End Class