<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enrollment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Enrollment))
        Me.txtEnroll = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Fingerprint_pb = New System.Windows.Forms.PictureBox()
        Me.Start_btn = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Badge_cbo = New System.Windows.Forms.ComboBox()
        Me.Result_pb = New System.Windows.Forms.PictureBox()
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Result_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEnroll
        '
        Me.txtEnroll.Location = New System.Drawing.Point(6, 28)
        Me.txtEnroll.Multiline = True
        Me.txtEnroll.Name = "txtEnroll"
        Me.txtEnroll.Size = New System.Drawing.Size(235, 194)
        Me.txtEnroll.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(358, 25)
        Me.lblTitle.TabIndex = 39
        Me.lblTitle.Text = "Registro de Huella"
        '
        'Fingerprint_pb
        '
        Me.Fingerprint_pb.Location = New System.Drawing.Point(247, 28)
        Me.Fingerprint_pb.Name = "Fingerprint_pb"
        Me.Fingerprint_pb.Size = New System.Drawing.Size(104, 122)
        Me.Fingerprint_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Fingerprint_pb.TabIndex = 40
        Me.Fingerprint_pb.TabStop = False
        '
        'Start_btn
        '
        Me.Start_btn.Image = CType(resources.GetObject("Start_btn.Image"), System.Drawing.Image)
        Me.Start_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Start_btn.Location = New System.Drawing.Point(247, 246)
        Me.Start_btn.Name = "Start_btn"
        Me.Start_btn.Size = New System.Drawing.Size(104, 23)
        Me.Start_btn.TabIndex = 41
        Me.Start_btn.Text = "Comenzar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Operador seleccionado:"
        '
        'Badge_cbo
        '
        Me.Badge_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Badge_cbo.FormattingEnabled = True
        Me.Badge_cbo.Location = New System.Drawing.Point(9, 246)
        Me.Badge_cbo.Name = "Badge_cbo"
        Me.Badge_cbo.Size = New System.Drawing.Size(232, 21)
        Me.Badge_cbo.TabIndex = 50
        '
        'Result_pb
        '
        Me.Result_pb.Location = New System.Drawing.Point(279, 168)
        Me.Result_pb.Name = "Result_pb"
        Me.Result_pb.Size = New System.Drawing.Size(32, 32)
        Me.Result_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Result_pb.TabIndex = 52
        Me.Result_pb.TabStop = False
        '
        'Enrollment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(358, 274)
        Me.Controls.Add(Me.Result_pb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Badge_cbo)
        Me.Controls.Add(Me.Start_btn)
        Me.Controls.Add(Me.Fingerprint_pb)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtEnroll)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(374, 312)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(374, 312)
        Me.Name = "Enrollment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Result_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEnroll As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Fingerprint_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Start_btn As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Badge_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Result_pb As System.Windows.Forms.PictureBox
End Class
