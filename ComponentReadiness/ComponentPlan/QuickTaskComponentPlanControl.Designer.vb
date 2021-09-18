<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickTaskComponentPlanControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Icon_pb = New System.Windows.Forms.PictureBox()
        CType(Me.Icon_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.FlatAppearance.BorderSize = 0
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.Location = New System.Drawing.Point(183, 3)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(18, 18)
        Me.Close_btn.TabIndex = 0
        Me.Close_btn.Text = "X"
        Me.Close_btn.UseVisualStyleBackColor = True
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.AutoSize = True
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.ForeColor = System.Drawing.Color.Black
        Me.Partnumber_lbl.Location = New System.Drawing.Point(5, 4)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(95, 18)
        Me.Partnumber_lbl.TabIndex = 1
        Me.Partnumber_lbl.Text = "PARTNUMBER"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 38)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Quick task description"
        '
        'Icon_pb
        '
        Me.Icon_pb.Image = Global.Delta_ERP.My.Resources.Resources.purple_warning_16
        Me.Icon_pb.Location = New System.Drawing.Point(106, 6)
        Me.Icon_pb.Name = "Icon_pb"
        Me.Icon_pb.Size = New System.Drawing.Size(16, 16)
        Me.Icon_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Icon_pb.TabIndex = 3
        Me.Icon_pb.TabStop = False
        '
        'QuickTaskComponentPlanControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Icon_pb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Close_btn)
        Me.Name = "QuickTaskComponentPlanControl"
        Me.Size = New System.Drawing.Size(206, 68)
        CType(Me.Icon_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Icon_pb As System.Windows.Forms.PictureBox

End Class
