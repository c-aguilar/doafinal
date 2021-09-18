<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Indentification
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
        Me.Fingerprint_pb = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Message_lbl = New System.Windows.Forms.Label()
        Me.Alter_link = New System.Windows.Forms.LinkLabel()
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fingerprint_pb
        '
        Me.Fingerprint_pb.BackColor = System.Drawing.Color.White
        Me.Fingerprint_pb.Location = New System.Drawing.Point(9, 52)
        Me.Fingerprint_pb.Name = "Fingerprint_pb"
        Me.Fingerprint_pb.Size = New System.Drawing.Size(197, 227)
        Me.Fingerprint_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Fingerprint_pb.TabIndex = 41
        Me.Fingerprint_pb.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(216, 25)
        Me.lblTitle.TabIndex = 42
        Me.lblTitle.Text = "Identificación por Huella"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.critical_16
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(113, 284)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(93, 23)
        Me.Cancel_btn.TabIndex = 43
        Me.Cancel_btn.Text = "Cancelar"
        '
        'Message_lbl
        '
        Me.Message_lbl.AutoSize = True
        Me.Message_lbl.Location = New System.Drawing.Point(12, 36)
        Me.Message_lbl.Name = "Message_lbl"
        Me.Message_lbl.Size = New System.Drawing.Size(148, 13)
        Me.Message_lbl.TabIndex = 44
        Me.Message_lbl.Text = "Coloque el dedo en el lector..."
        '
        'Alter_link
        '
        Me.Alter_link.AutoSize = True
        Me.Alter_link.Location = New System.Drawing.Point(6, 285)
        Me.Alter_link.Name = "Alter_link"
        Me.Alter_link.Size = New System.Drawing.Size(105, 26)
        Me.Alter_link.TabIndex = 45
        Me.Alter_link.TabStop = True
        Me.Alter_link.Text = "Identificación por" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "usuario y contraseña"
        '
        'Indentification
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(216, 320)
        Me.Controls.Add(Me.Alter_link)
        Me.Controls.Add(Me.Message_lbl)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Fingerprint_pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Indentification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Identification"
        CType(Me.Fingerprint_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fingerprint_pb As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents Message_lbl As System.Windows.Forms.Label
    Friend WithEvents Alter_link As System.Windows.Forms.LinkLabel
End Class
