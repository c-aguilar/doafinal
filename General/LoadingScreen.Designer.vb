<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingScreen))
        Me.pbProgress = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Message_lbl = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        CType(Me.pbProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbProgress.Image = CType(resources.GetObject("pbProgress.Image"), System.Drawing.Image)
        Me.pbProgress.Location = New System.Drawing.Point(343, 347)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(114, 94)
        Me.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbProgress.TabIndex = 0
        Me.pbProgress.TabStop = False
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.Controls.Add(Me.pbProgress, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Message_lbl, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.lblVersion, 2, 2)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(800, 788)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'Message_lbl
        '
        Me.Message_lbl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Message_lbl.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Message_lbl.ForeColor = System.Drawing.Color.White
        Me.Message_lbl.Location = New System.Drawing.Point(343, 296)
        Me.Message_lbl.Name = "Message_lbl"
        Me.Message_lbl.Size = New System.Drawing.Size(114, 48)
        Me.Message_lbl.TabIndex = 1
        Me.Message_lbl.Text = "Cargando..."
        Me.Message_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersion
        '
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(463, 707)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.lblVersion.Size = New System.Drawing.Size(334, 81)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "DELTA ERP"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LoadingScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoadingScreen"
        Me.Opacity = 0.5R
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        CType(Me.pbProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbProgress As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Message_lbl As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label

End Class
