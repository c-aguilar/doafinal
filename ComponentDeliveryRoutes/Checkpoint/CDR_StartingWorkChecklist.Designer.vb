<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_StartingWorkChecklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_StartingWorkChecklist))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Activities_clb = New System.Windows.Forms.CheckedListBox()
        Me.Picture_pb = New System.Windows.Forms.PictureBox()
        Me.Comment_txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(700, 25)
        Me.lblTitle.TabIndex = 35
        Me.lblTitle.Text = "Checklist de Inicio de Jornada"
        '
        'Activities_clb
        '
        Me.Activities_clb.BackColor = System.Drawing.SystemColors.Control
        Me.Activities_clb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Activities_clb.CheckOnClick = True
        Me.Activities_clb.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Activities_clb.FormattingEnabled = True
        Me.Activities_clb.Location = New System.Drawing.Point(12, 28)
        Me.Activities_clb.Name = "Activities_clb"
        Me.Activities_clb.Size = New System.Drawing.Size(676, 468)
        Me.Activities_clb.TabIndex = 36
        '
        'Picture_pb
        '
        Me.Picture_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_pb.Image = CType(resources.GetObject("Picture_pb.Image"), System.Drawing.Image)
        Me.Picture_pb.Location = New System.Drawing.Point(12, 521)
        Me.Picture_pb.Name = "Picture_pb"
        Me.Picture_pb.Size = New System.Drawing.Size(137, 164)
        Me.Picture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture_pb.TabIndex = 37
        Me.Picture_pb.TabStop = False
        '
        'Comment_txt
        '
        Me.Comment_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Comment_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment_txt.Location = New System.Drawing.Point(155, 550)
        Me.Comment_txt.MaxLength = 200
        Me.Comment_txt.Multiline = True
        Me.Comment_txt.Name = "Comment_txt"
        Me.Comment_txt.Size = New System.Drawing.Size(533, 102)
        Me.Comment_txt.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(155, 521)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(533, 26)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Comentario"
        '
        'Save_btn
        '
        Me.Save_btn.Image = Global.Delta_ERP.My.Resources.Resources.tick_32
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(562, 658)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(126, 35)
        Me.Save_btn.TabIndex = 40
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(155, 658)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(100, 25)
        Me.Cancel_btn.TabIndex = 41
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'CDR_StartingWorkChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 700)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Comment_txt)
        Me.Controls.Add(Me.Picture_pb)
        Me.Controls.Add(Me.Activities_clb)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CDR_StartingWorkChecklist"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Routes Components"
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Activities_clb As System.Windows.Forms.CheckedListBox
    Friend WithEvents Picture_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Comment_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
End Class
