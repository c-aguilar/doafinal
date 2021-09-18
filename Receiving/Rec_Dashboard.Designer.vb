<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_Dashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_Dashboard))
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.MissingQualityCounter_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.MissingCriticalCounter_lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MoreThan6HoursCounter_lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Critical_pnl = New System.Windows.Forms.Panel()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PendingToReleaseCounter_lbl = New System.Windows.Forms.Label()
        Me.Critical_lbl = New System.Windows.Forms.Label()
        Me.Main_tmr = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMain.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Critical_pnl.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(980, 29)
        Me.ToolStripMain.TabIndex = 149
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(187, 26)
        Me.Title_lbl.Text = "Dashboard de Recibos"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.MissingQualityCounter_lbl)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.ForeColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(533, 67)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(157, 97)
        Me.Panel3.TabIndex = 153
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(104, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'MissingQualityCounter_lbl
        '
        Me.MissingQualityCounter_lbl.AutoSize = True
        Me.MissingQualityCounter_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MissingQualityCounter_lbl.Font = New System.Drawing.Font("Calibri", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MissingQualityCounter_lbl.ForeColor = System.Drawing.Color.Firebrick
        Me.MissingQualityCounter_lbl.Location = New System.Drawing.Point(7, 7)
        Me.MissingQualityCounter_lbl.Name = "MissingQualityCounter_lbl"
        Me.MissingQualityCounter_lbl.Size = New System.Drawing.Size(67, 53)
        Me.MissingQualityCounter_lbl.TabIndex = 1
        Me.MissingQualityCounter_lbl.Text = "00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 28)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Calidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alertados sin Entregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.MissingCriticalCounter_lbl)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(370, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(157, 97)
        Me.Panel2.TabIndex = 152
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(104, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'MissingCriticalCounter_lbl
        '
        Me.MissingCriticalCounter_lbl.AutoSize = True
        Me.MissingCriticalCounter_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MissingCriticalCounter_lbl.Font = New System.Drawing.Font("Calibri", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MissingCriticalCounter_lbl.ForeColor = System.Drawing.Color.Firebrick
        Me.MissingCriticalCounter_lbl.Location = New System.Drawing.Point(7, 7)
        Me.MissingCriticalCounter_lbl.Name = "MissingCriticalCounter_lbl"
        Me.MissingCriticalCounter_lbl.Size = New System.Drawing.Size(67, 53)
        Me.MissingCriticalCounter_lbl.TabIndex = 1
        Me.MissingCriticalCounter_lbl.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Criticos sin Entregar"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.MoreThan6HoursCounter_lbl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(207, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 97)
        Me.Panel1.TabIndex = 151
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(104, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'MoreThan6HoursCounter_lbl
        '
        Me.MoreThan6HoursCounter_lbl.AutoSize = True
        Me.MoreThan6HoursCounter_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MoreThan6HoursCounter_lbl.Font = New System.Drawing.Font("Calibri", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoreThan6HoursCounter_lbl.ForeColor = System.Drawing.Color.Firebrick
        Me.MoreThan6HoursCounter_lbl.Location = New System.Drawing.Point(7, 7)
        Me.MoreThan6HoursCounter_lbl.Name = "MoreThan6HoursCounter_lbl"
        Me.MoreThan6HoursCounter_lbl.Size = New System.Drawing.Size(67, 53)
        Me.MoreThan6HoursCounter_lbl.TabIndex = 1
        Me.MoreThan6HoursCounter_lbl.Text = "00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 28)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "+6 Horas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Series en Rampas"
        '
        'Critical_pnl
        '
        Me.Critical_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Critical_pnl.BackColor = System.Drawing.Color.White
        Me.Critical_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Critical_pnl.Controls.Add(Me.PictureBox11)
        Me.Critical_pnl.Controls.Add(Me.PendingToReleaseCounter_lbl)
        Me.Critical_pnl.Controls.Add(Me.Critical_lbl)
        Me.Critical_pnl.ForeColor = System.Drawing.Color.Black
        Me.Critical_pnl.Location = New System.Drawing.Point(44, 67)
        Me.Critical_pnl.Name = "Critical_pnl"
        Me.Critical_pnl.Size = New System.Drawing.Size(157, 97)
        Me.Critical_pnl.TabIndex = 150
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(104, 2)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox11.TabIndex = 2
        Me.PictureBox11.TabStop = False
        '
        'PendingToReleaseCounter_lbl
        '
        Me.PendingToReleaseCounter_lbl.AutoSize = True
        Me.PendingToReleaseCounter_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PendingToReleaseCounter_lbl.Font = New System.Drawing.Font("Calibri", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PendingToReleaseCounter_lbl.ForeColor = System.Drawing.Color.Firebrick
        Me.PendingToReleaseCounter_lbl.Location = New System.Drawing.Point(7, 7)
        Me.PendingToReleaseCounter_lbl.Name = "PendingToReleaseCounter_lbl"
        Me.PendingToReleaseCounter_lbl.Size = New System.Drawing.Size(67, 53)
        Me.PendingToReleaseCounter_lbl.TabIndex = 1
        Me.PendingToReleaseCounter_lbl.Text = "00"
        '
        'Critical_lbl
        '
        Me.Critical_lbl.AutoSize = True
        Me.Critical_lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Critical_lbl.ForeColor = System.Drawing.Color.Black
        Me.Critical_lbl.Location = New System.Drawing.Point(6, 62)
        Me.Critical_lbl.Name = "Critical_lbl"
        Me.Critical_lbl.Size = New System.Drawing.Size(116, 28)
        Me.Critical_lbl.TabIndex = 0
        Me.Critical_lbl.Text = "Tracker" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Liberados sin Entregar"
        '
        'Main_tmr
        '
        Me.Main_tmr.Enabled = True
        Me.Main_tmr.Interval = 120000
        '
        'Rec_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 690)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Critical_pnl)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "Rec_Dashboard"
        Me.ShowIcon = False
        Me.Text = "Rec_Dashboard"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Critical_pnl.ResumeLayout(False)
        Me.Critical_pnl.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents MissingQualityCounter_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MissingCriticalCounter_lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MoreThan6HoursCounter_lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Critical_pnl As System.Windows.Forms.Panel
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PendingToReleaseCounter_lbl As System.Windows.Forms.Label
    Friend WithEvents Critical_lbl As System.Windows.Forms.Label
    Friend WithEvents Main_tmr As System.Windows.Forms.Timer
End Class
