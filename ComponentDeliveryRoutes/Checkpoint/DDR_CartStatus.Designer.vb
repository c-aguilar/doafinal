<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_CartStatus
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
        Me.Status_lbl = New System.Windows.Forms.Label()
        Me.Status_pb = New System.Windows.Forms.PictureBox()
        Me.Crono_lbl = New System.Windows.Forms.Label()
        Me.Cart_lbl = New System.Windows.Forms.Label()
        Me.Operator_lbl = New System.Windows.Forms.Label()
        Me.Count_lbl = New System.Windows.Forms.Label()
        CType(Me.Status_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Status_lbl
        '
        Me.Status_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Status_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Status_lbl.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_lbl.ForeColor = System.Drawing.Color.LightGreen
        Me.Status_lbl.Location = New System.Drawing.Point(75, 56)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.Size = New System.Drawing.Size(104, 39)
        Me.Status_lbl.TabIndex = 31
        Me.Status_lbl.Text = "Surtiendo"
        '
        'Status_pb
        '
        Me.Status_pb.Image = Global.Delta_ERP.My.Resources.Resources.ddr_inside
        Me.Status_pb.Location = New System.Drawing.Point(2, 12)
        Me.Status_pb.Name = "Status_pb"
        Me.Status_pb.Size = New System.Drawing.Size(70, 70)
        Me.Status_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Status_pb.TabIndex = 30
        Me.Status_pb.TabStop = False
        '
        'Crono_lbl
        '
        Me.Crono_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Crono_lbl.BackColor = System.Drawing.Color.Black
        Me.Crono_lbl.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Crono_lbl.ForeColor = System.Drawing.Color.White
        Me.Crono_lbl.Location = New System.Drawing.Point(187, 64)
        Me.Crono_lbl.Name = "Crono_lbl"
        Me.Crono_lbl.Size = New System.Drawing.Size(70, 25)
        Me.Crono_lbl.TabIndex = 29
        Me.Crono_lbl.Text = "04:51"
        Me.Crono_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cart_lbl
        '
        Me.Cart_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cart_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Cart_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cart_lbl.ForeColor = System.Drawing.Color.LightGray
        Me.Cart_lbl.Location = New System.Drawing.Point(75, 33)
        Me.Cart_lbl.Name = "Cart_lbl"
        Me.Cart_lbl.Size = New System.Drawing.Size(104, 26)
        Me.Cart_lbl.TabIndex = 28
        Me.Cart_lbl.Text = "Carro 1"
        '
        'Operator_lbl
        '
        Me.Operator_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Operator_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Operator_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Operator_lbl.ForeColor = System.Drawing.Color.LightGreen
        Me.Operator_lbl.Location = New System.Drawing.Point(73, 6)
        Me.Operator_lbl.Name = "Operator_lbl"
        Me.Operator_lbl.Size = New System.Drawing.Size(184, 30)
        Me.Operator_lbl.TabIndex = 27
        Me.Operator_lbl.Text = "Carlos Aguilar"
        '
        'Count_lbl
        '
        Me.Count_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Count_lbl.BackColor = System.Drawing.Color.DimGray
        Me.Count_lbl.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Count_lbl.ForeColor = System.Drawing.Color.White
        Me.Count_lbl.Location = New System.Drawing.Point(187, 36)
        Me.Count_lbl.Name = "Count_lbl"
        Me.Count_lbl.Size = New System.Drawing.Size(70, 25)
        Me.Count_lbl.TabIndex = 32
        Me.Count_lbl.Text = "50"
        Me.Count_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DDR_CartStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Controls.Add(Me.Operator_lbl)
        Me.Controls.Add(Me.Count_lbl)
        Me.Controls.Add(Me.Status_lbl)
        Me.Controls.Add(Me.Status_pb)
        Me.Controls.Add(Me.Crono_lbl)
        Me.Controls.Add(Me.Cart_lbl)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "DDR_CartStatus"
        Me.Size = New System.Drawing.Size(260, 95)
        CType(Me.Status_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Status_lbl As System.Windows.Forms.Label
    Friend WithEvents Status_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Crono_lbl As System.Windows.Forms.Label
    Friend WithEvents Cart_lbl As System.Windows.Forms.Label
    Friend WithEvents Operator_lbl As System.Windows.Forms.Label
    Friend WithEvents Count_lbl As System.Windows.Forms.Label

End Class
