<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_LevelScheduleNewLevelResult
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Harns_pb = New System.Windows.Forms.PictureBox()
        Me.Plant_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.HarnTotal_lbl = New System.Windows.Forms.Label()
        Me.HarnWrong_lbl = New System.Windows.Forms.Label()
        Me.HarnOK_lbl = New System.Windows.Forms.Label()
        Me.PlantTotal_lbl = New System.Windows.Forms.Label()
        Me.PlantWrong_lbl = New System.Windows.Forms.Label()
        Me.PlantOK_lbl = New System.Windows.Forms.Label()
        Me.VersionTotal_lbl = New System.Windows.Forms.Label()
        Me.VersionWrong_lbl = New System.Windows.Forms.Label()
        Me.VersionOK_lbl = New System.Windows.Forms.Label()
        Me.WeekTotal_lbl = New System.Windows.Forms.Label()
        Me.WeekWrong_lbl = New System.Windows.Forms.Label()
        Me.WeekOK_lbl = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.QuantityTotal_lbl = New System.Windows.Forms.Label()
        Me.QuantityWrong_lbl = New System.Windows.Forms.Label()
        Me.QuantityOK_lbl = New System.Windows.Forms.Label()
        Me.Version_pb = New System.Windows.Forms.PictureBox()
        Me.Week_pb = New System.Windows.Forms.PictureBox()
        Me.Quantity_pb = New System.Windows.Forms.PictureBox()
        Me.Accept_btn = New System.Windows.Forms.Button()
        CType(Me.Harns_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Plant_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Version_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Week_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quantity_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Arneses:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(101, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(172, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Incorrectos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(265, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Correctos"
        '
        'Harns_pb
        '
        Me.Harns_pb.Image = Global.Delta_ERP.My.Resources.Resources.tick_16
        Me.Harns_pb.Location = New System.Drawing.Point(342, 37)
        Me.Harns_pb.Name = "Harns_pb"
        Me.Harns_pb.Size = New System.Drawing.Size(16, 16)
        Me.Harns_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Harns_pb.TabIndex = 4
        Me.Harns_pb.TabStop = False
        '
        'Plant_pb
        '
        Me.Plant_pb.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Plant_pb.Location = New System.Drawing.Point(342, 62)
        Me.Plant_pb.Name = "Plant_pb"
        Me.Plant_pb.Size = New System.Drawing.Size(16, 16)
        Me.Plant_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Plant_pb.TabIndex = 5
        Me.Plant_pb.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.QuantityOK_lbl)
        Me.Panel1.Controls.Add(Me.WeekOK_lbl)
        Me.Panel1.Controls.Add(Me.VersionOK_lbl)
        Me.Panel1.Controls.Add(Me.PlantOK_lbl)
        Me.Panel1.Controls.Add(Me.HarnOK_lbl)
        Me.Panel1.Location = New System.Drawing.Point(254, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(82, 132)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.QuantityWrong_lbl)
        Me.Panel2.Controls.Add(Me.WeekWrong_lbl)
        Me.Panel2.Controls.Add(Me.VersionWrong_lbl)
        Me.Panel2.Controls.Add(Me.PlantWrong_lbl)
        Me.Panel2.Controls.Add(Me.HarnWrong_lbl)
        Me.Panel2.Location = New System.Drawing.Point(166, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(82, 132)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.QuantityTotal_lbl)
        Me.Panel3.Controls.Add(Me.WeekTotal_lbl)
        Me.Panel3.Controls.Add(Me.VersionTotal_lbl)
        Me.Panel3.Controls.Add(Me.PlantTotal_lbl)
        Me.Panel3.Controls.Add(Me.HarnTotal_lbl)
        Me.Panel3.Location = New System.Drawing.Point(78, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(82, 132)
        Me.Panel3.TabIndex = 10
        '
        'HarnTotal_lbl
        '
        Me.HarnTotal_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HarnTotal_lbl.Location = New System.Drawing.Point(3, 4)
        Me.HarnTotal_lbl.Name = "HarnTotal_lbl"
        Me.HarnTotal_lbl.Size = New System.Drawing.Size(74, 22)
        Me.HarnTotal_lbl.TabIndex = 11
        Me.HarnTotal_lbl.Text = "0"
        Me.HarnTotal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HarnWrong_lbl
        '
        Me.HarnWrong_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HarnWrong_lbl.Location = New System.Drawing.Point(3, 4)
        Me.HarnWrong_lbl.Name = "HarnWrong_lbl"
        Me.HarnWrong_lbl.Size = New System.Drawing.Size(74, 22)
        Me.HarnWrong_lbl.TabIndex = 12
        Me.HarnWrong_lbl.Text = "0"
        Me.HarnWrong_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HarnOK_lbl
        '
        Me.HarnOK_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HarnOK_lbl.Location = New System.Drawing.Point(3, 4)
        Me.HarnOK_lbl.Name = "HarnOK_lbl"
        Me.HarnOK_lbl.Size = New System.Drawing.Size(74, 22)
        Me.HarnOK_lbl.TabIndex = 13
        Me.HarnOK_lbl.Text = "0"
        Me.HarnOK_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlantTotal_lbl
        '
        Me.PlantTotal_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PlantTotal_lbl.Location = New System.Drawing.Point(3, 29)
        Me.PlantTotal_lbl.Name = "PlantTotal_lbl"
        Me.PlantTotal_lbl.Size = New System.Drawing.Size(74, 22)
        Me.PlantTotal_lbl.TabIndex = 12
        Me.PlantTotal_lbl.Text = "0"
        Me.PlantTotal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlantWrong_lbl
        '
        Me.PlantWrong_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PlantWrong_lbl.Location = New System.Drawing.Point(3, 29)
        Me.PlantWrong_lbl.Name = "PlantWrong_lbl"
        Me.PlantWrong_lbl.Size = New System.Drawing.Size(74, 22)
        Me.PlantWrong_lbl.TabIndex = 13
        Me.PlantWrong_lbl.Text = "0"
        Me.PlantWrong_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlantOK_lbl
        '
        Me.PlantOK_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PlantOK_lbl.Location = New System.Drawing.Point(3, 29)
        Me.PlantOK_lbl.Name = "PlantOK_lbl"
        Me.PlantOK_lbl.Size = New System.Drawing.Size(74, 22)
        Me.PlantOK_lbl.TabIndex = 14
        Me.PlantOK_lbl.Text = "0"
        Me.PlantOK_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VersionTotal_lbl
        '
        Me.VersionTotal_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.VersionTotal_lbl.Location = New System.Drawing.Point(3, 54)
        Me.VersionTotal_lbl.Name = "VersionTotal_lbl"
        Me.VersionTotal_lbl.Size = New System.Drawing.Size(74, 22)
        Me.VersionTotal_lbl.TabIndex = 13
        Me.VersionTotal_lbl.Text = "0"
        Me.VersionTotal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VersionWrong_lbl
        '
        Me.VersionWrong_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.VersionWrong_lbl.Location = New System.Drawing.Point(3, 54)
        Me.VersionWrong_lbl.Name = "VersionWrong_lbl"
        Me.VersionWrong_lbl.Size = New System.Drawing.Size(74, 22)
        Me.VersionWrong_lbl.TabIndex = 14
        Me.VersionWrong_lbl.Text = "0"
        Me.VersionWrong_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VersionOK_lbl
        '
        Me.VersionOK_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.VersionOK_lbl.Location = New System.Drawing.Point(3, 54)
        Me.VersionOK_lbl.Name = "VersionOK_lbl"
        Me.VersionOK_lbl.Size = New System.Drawing.Size(74, 22)
        Me.VersionOK_lbl.TabIndex = 15
        Me.VersionOK_lbl.Text = "0"
        Me.VersionOK_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WeekTotal_lbl
        '
        Me.WeekTotal_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.WeekTotal_lbl.Location = New System.Drawing.Point(3, 79)
        Me.WeekTotal_lbl.Name = "WeekTotal_lbl"
        Me.WeekTotal_lbl.Size = New System.Drawing.Size(74, 22)
        Me.WeekTotal_lbl.TabIndex = 14
        Me.WeekTotal_lbl.Text = "0"
        Me.WeekTotal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WeekWrong_lbl
        '
        Me.WeekWrong_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.WeekWrong_lbl.Location = New System.Drawing.Point(3, 79)
        Me.WeekWrong_lbl.Name = "WeekWrong_lbl"
        Me.WeekWrong_lbl.Size = New System.Drawing.Size(74, 22)
        Me.WeekWrong_lbl.TabIndex = 15
        Me.WeekWrong_lbl.Text = "0"
        Me.WeekWrong_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WeekOK_lbl
        '
        Me.WeekOK_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.WeekOK_lbl.Location = New System.Drawing.Point(3, 79)
        Me.WeekOK_lbl.Name = "WeekOK_lbl"
        Me.WeekOK_lbl.Size = New System.Drawing.Size(74, 22)
        Me.WeekOK_lbl.TabIndex = 16
        Me.WeekOK_lbl.Text = "0"
        Me.WeekOK_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(26, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Planta:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Version:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(17, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Semana:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 139)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Cantidades:"
        '
        'QuantityTotal_lbl
        '
        Me.QuantityTotal_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.QuantityTotal_lbl.Location = New System.Drawing.Point(3, 104)
        Me.QuantityTotal_lbl.Name = "QuantityTotal_lbl"
        Me.QuantityTotal_lbl.Size = New System.Drawing.Size(74, 22)
        Me.QuantityTotal_lbl.TabIndex = 15
        Me.QuantityTotal_lbl.Text = "0"
        Me.QuantityTotal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QuantityWrong_lbl
        '
        Me.QuantityWrong_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.QuantityWrong_lbl.Location = New System.Drawing.Point(3, 104)
        Me.QuantityWrong_lbl.Name = "QuantityWrong_lbl"
        Me.QuantityWrong_lbl.Size = New System.Drawing.Size(74, 22)
        Me.QuantityWrong_lbl.TabIndex = 16
        Me.QuantityWrong_lbl.Text = "0"
        Me.QuantityWrong_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QuantityOK_lbl
        '
        Me.QuantityOK_lbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.QuantityOK_lbl.Location = New System.Drawing.Point(3, 104)
        Me.QuantityOK_lbl.Name = "QuantityOK_lbl"
        Me.QuantityOK_lbl.Size = New System.Drawing.Size(74, 22)
        Me.QuantityOK_lbl.TabIndex = 17
        Me.QuantityOK_lbl.Text = "0"
        Me.QuantityOK_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Version_pb
        '
        Me.Version_pb.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Version_pb.Location = New System.Drawing.Point(342, 87)
        Me.Version_pb.Name = "Version_pb"
        Me.Version_pb.Size = New System.Drawing.Size(16, 16)
        Me.Version_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Version_pb.TabIndex = 15
        Me.Version_pb.TabStop = False
        '
        'Week_pb
        '
        Me.Week_pb.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Week_pb.Location = New System.Drawing.Point(342, 112)
        Me.Week_pb.Name = "Week_pb"
        Me.Week_pb.Size = New System.Drawing.Size(16, 16)
        Me.Week_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Week_pb.TabIndex = 16
        Me.Week_pb.TabStop = False
        '
        'Quantity_pb
        '
        Me.Quantity_pb.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Quantity_pb.Location = New System.Drawing.Point(342, 137)
        Me.Quantity_pb.Name = "Quantity_pb"
        Me.Quantity_pb.Size = New System.Drawing.Size(16, 16)
        Me.Quantity_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Quantity_pb.TabIndex = 17
        Me.Quantity_pb.TabStop = False
        '
        'Accept_btn
        '
        Me.Accept_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Accept_btn.Location = New System.Drawing.Point(254, 168)
        Me.Accept_btn.Name = "Accept_btn"
        Me.Accept_btn.Size = New System.Drawing.Size(82, 23)
        Me.Accept_btn.TabIndex = 18
        Me.Accept_btn.Text = "Aceptar"
        Me.Accept_btn.UseVisualStyleBackColor = True
        '
        'Sch_LevelScheduleNewLevelResult
        '
        Me.AcceptButton = Me.Accept_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Accept_btn
        Me.ClientSize = New System.Drawing.Size(381, 198)
        Me.Controls.Add(Me.Accept_btn)
        Me.Controls.Add(Me.Quantity_pb)
        Me.Controls.Add(Me.Week_pb)
        Me.Controls.Add(Me.Version_pb)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Plant_pb)
        Me.Controls.Add(Me.Harns_pb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Sch_LevelScheduleNewLevelResult"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scheduling"
        CType(Me.Harns_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Plant_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Version_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Week_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quantity_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Harns_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Plant_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents QuantityOK_lbl As System.Windows.Forms.Label
    Friend WithEvents WeekOK_lbl As System.Windows.Forms.Label
    Friend WithEvents VersionOK_lbl As System.Windows.Forms.Label
    Friend WithEvents PlantOK_lbl As System.Windows.Forms.Label
    Friend WithEvents HarnOK_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents QuantityWrong_lbl As System.Windows.Forms.Label
    Friend WithEvents WeekWrong_lbl As System.Windows.Forms.Label
    Friend WithEvents VersionWrong_lbl As System.Windows.Forms.Label
    Friend WithEvents PlantWrong_lbl As System.Windows.Forms.Label
    Friend WithEvents HarnWrong_lbl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents QuantityTotal_lbl As System.Windows.Forms.Label
    Friend WithEvents WeekTotal_lbl As System.Windows.Forms.Label
    Friend WithEvents VersionTotal_lbl As System.Windows.Forms.Label
    Friend WithEvents PlantTotal_lbl As System.Windows.Forms.Label
    Friend WithEvents HarnTotal_lbl As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Version_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Week_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Quantity_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Accept_btn As System.Windows.Forms.Button
End Class
