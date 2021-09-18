<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_ExitRoute
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_ExitRoute))
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Route_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_btn.BackColor = System.Drawing.Color.White
        Me.Cancel_btn.BackgroundImage = CType(resources.GetObject("Cancel_btn.BackgroundImage"), System.Drawing.Image)
        Me.Cancel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cancel_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.Location = New System.Drawing.Point(62, 102)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(227, 83)
        Me.Cancel_btn.TabIndex = 32
        Me.Cancel_btn.Text = "CANCELAR"
        Me.Cancel_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(350, 25)
        Me.lblTitle.TabIndex = 31
        Me.lblTitle.Text = "Salida de Supermercado"
        '
        'Route_txt
        '
        Me.Route_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Route_txt.BackColor = System.Drawing.Color.White
        Me.Route_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Route_txt.ForeColor = System.Drawing.Color.Black
        Me.Route_txt.Location = New System.Drawing.Point(4, 3)
        Me.Route_txt.Name = "Route_txt"
        Me.Route_txt.Size = New System.Drawing.Size(268, 35)
        Me.Route_txt.TabIndex = 1
        Me.Route_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Route_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Route_txt.WaterMarkText = "Escanea la ruta..."
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.Route_txt)
        Me.Panel4.Location = New System.Drawing.Point(38, 40)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 41)
        Me.Panel4.TabIndex = 143
        '
        'CDR_ExitRoute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(350, 197)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CDR_ExitRoute"
        Me.Opacity = 0.85R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Component Delivery Routes"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Route_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
