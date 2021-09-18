<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SQAValidation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SQAValidation))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.materialScannedDGV = New System.Windows.Forms.DataGridView()
        Me.routeCB = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.scanAsnTB = New System.Windows.Forms.TextBox()
        Me.scannedDeskAsnDGV = New System.Windows.Forms.DataGridView()
        Me.download = New System.Windows.Forms.Button()
        Me.SapDownloadedInfoDGV = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.percentageLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.finishBtn = New System.Windows.Forms.Button()
        Me.ASNscannedMHDGV = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TimerRefreshMaterialHandler = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStripSQA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItemSQA = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripSAP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItemSAP = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MatWOasnDGV = New System.Windows.Forms.DataGridView()
        Me.asnWOmatDGV = New System.Windows.Forms.DataGridView()
        Me.exportDiscrepanciesBtn = New System.Windows.Forms.Button()
        CType(Me.materialScannedDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scannedDeskAsnDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SapDownloadedInfoDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ASNscannedMHDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStripSQA.SuspendLayout()
        Me.ContextMenuStripSAP.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.MatWOasnDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.asnWOmatDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Route:"
        '
        'materialScannedDGV
        '
        Me.materialScannedDGV.AllowUserToAddRows = False
        Me.materialScannedDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.materialScannedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.materialScannedDGV.Location = New System.Drawing.Point(20, 30)
        Me.materialScannedDGV.Name = "materialScannedDGV"
        Me.materialScannedDGV.Size = New System.Drawing.Size(482, 470)
        Me.materialScannedDGV.TabIndex = 2
        '
        'routeCB
        '
        Me.routeCB.FormattingEnabled = True
        Me.routeCB.Location = New System.Drawing.Point(92, 16)
        Me.routeCB.Name = "routeCB"
        Me.routeCB.Size = New System.Drawing.Size(121, 25)
        Me.routeCB.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Scan ASN:"
        '
        'scanAsnTB
        '
        Me.scanAsnTB.Location = New System.Drawing.Point(133, 39)
        Me.scanAsnTB.Name = "scanAsnTB"
        Me.scanAsnTB.Size = New System.Drawing.Size(144, 23)
        Me.scanAsnTB.TabIndex = 7
        '
        'scannedDeskAsnDGV
        '
        Me.scannedDeskAsnDGV.AllowUserToAddRows = False
        Me.scannedDeskAsnDGV.AllowUserToResizeRows = False
        Me.scannedDeskAsnDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.scannedDeskAsnDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.scannedDeskAsnDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.scannedDeskAsnDGV.Location = New System.Drawing.Point(133, 85)
        Me.scannedDeskAsnDGV.Name = "scannedDeskAsnDGV"
        Me.scannedDeskAsnDGV.Size = New System.Drawing.Size(144, 126)
        Me.scannedDeskAsnDGV.TabIndex = 8
        '
        'download
        '
        Me.download.BackColor = System.Drawing.Color.MidnightBlue
        Me.download.ForeColor = System.Drawing.Color.Lavender
        Me.download.Image = CType(resources.GetObject("download.Image"), System.Drawing.Image)
        Me.download.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.download.Location = New System.Drawing.Point(194, 217)
        Me.download.Name = "download"
        Me.download.Size = New System.Drawing.Size(211, 35)
        Me.download.TabIndex = 9
        Me.download.Text = "Download SAP information"
        Me.download.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.download.UseCompatibleTextRendering = True
        Me.download.UseVisualStyleBackColor = False
        '
        'SapDownloadedInfoDGV
        '
        Me.SapDownloadedInfoDGV.AllowUserToAddRows = False
        Me.SapDownloadedInfoDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.SapDownloadedInfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SapDownloadedInfoDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.SapDownloadedInfoDGV.Location = New System.Drawing.Point(21, 333)
        Me.SapDownloadedInfoDGV.Name = "SapDownloadedInfoDGV"
        Me.SapDownloadedInfoDGV.Size = New System.Drawing.Size(573, 209)
        Me.SapDownloadedInfoDGV.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.percentageLbl)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.materialScannedDGV)
        Me.GroupBox1.Controls.Add(Me.finishBtn)
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(17, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 556)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material scanned"
        '
        'percentageLbl
        '
        Me.percentageLbl.AutoSize = True
        Me.percentageLbl.Location = New System.Drawing.Point(259, 520)
        Me.percentageLbl.Name = "percentageLbl"
        Me.percentageLbl.Size = New System.Drawing.Size(12, 17)
        Me.percentageLbl.TabIndex = 18
        Me.percentageLbl.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 520)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Assignation percentage:"
        '
        'finishBtn
        '
        Me.finishBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.finishBtn.ForeColor = System.Drawing.Color.White
        Me.finishBtn.Image = CType(resources.GetObject("finishBtn.Image"), System.Drawing.Image)
        Me.finishBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.finishBtn.Location = New System.Drawing.Point(394, 513)
        Me.finishBtn.Name = "finishBtn"
        Me.finishBtn.Size = New System.Drawing.Size(108, 36)
        Me.finishBtn.TabIndex = 14
        Me.finishBtn.Text = "Finish Route"
        Me.finishBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.finishBtn.UseVisualStyleBackColor = False
        '
        'ASNscannedMHDGV
        '
        Me.ASNscannedMHDGV.AllowUserToAddRows = False
        Me.ASNscannedMHDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.ASNscannedMHDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ASNscannedMHDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ASNscannedMHDGV.Location = New System.Drawing.Point(339, 85)
        Me.ASNscannedMHDGV.Name = "ASNscannedMHDGV"
        Me.ASNscannedMHDGV.RowTemplate.Height = 28
        Me.ASNscannedMHDGV.Size = New System.Drawing.Size(144, 126)
        Me.ASNscannedMHDGV.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.SapDownloadedInfoDGV)
        Me.GroupBox3.Controls.Add(Me.ASNscannedMHDGV)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.scanAsnTB)
        Me.GroupBox3.Controls.Add(Me.download)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.scannedDeskAsnDGV)
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox3.Location = New System.Drawing.Point(540, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(618, 555)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SQA validation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "ASNs downloaded from SAP:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(335, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(239, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Scanned ASNs by Material Handling:"
        '
        'TimerRefreshMaterialHandler
        '
        Me.TimerRefreshMaterialHandler.Enabled = True
        Me.TimerRefreshMaterialHandler.Interval = 150000
        '
        'ContextMenuStripSQA
        '
        Me.ContextMenuStripSQA.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStripSQA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItemSQA})
        Me.ContextMenuStripSQA.Name = "ContextMenuStrip1"
        Me.ContextMenuStripSQA.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItemSQA
        '
        Me.DeleteToolStripMenuItemSQA.Name = "DeleteToolStripMenuItemSQA"
        Me.DeleteToolStripMenuItemSQA.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItemSQA.Text = "Delete"
        '
        'ContextMenuStripSAP
        '
        Me.ContextMenuStripSAP.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStripSAP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItemSAP})
        Me.ContextMenuStripSAP.Name = "ContextMenuStripSAP"
        Me.ContextMenuStripSAP.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItemSAP
        '
        Me.DeleteToolStripMenuItemSAP.Name = "DeleteToolStripMenuItemSAP"
        Me.DeleteToolStripMenuItemSAP.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItemSAP.Text = "Delete"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.MatWOasnDGV)
        Me.GroupBox2.Controls.Add(Me.asnWOmatDGV)
        Me.GroupBox2.Controls.Add(Me.exportDiscrepanciesBtn)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(18, 633)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1140, 323)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Possible Discrepancies"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Material Without ASN:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(539, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Incomplete ASNs:"
        '
        'MatWOasnDGV
        '
        Me.MatWOasnDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.MatWOasnDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MatWOasnDGV.Location = New System.Drawing.Point(19, 65)
        Me.MatWOasnDGV.Name = "MatWOasnDGV"
        Me.MatWOasnDGV.RowTemplate.Height = 28
        Me.MatWOasnDGV.Size = New System.Drawing.Size(482, 235)
        Me.MatWOasnDGV.TabIndex = 7
        '
        'asnWOmatDGV
        '
        Me.asnWOmatDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.asnWOmatDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.asnWOmatDGV.Location = New System.Drawing.Point(543, 65)
        Me.asnWOmatDGV.Name = "asnWOmatDGV"
        Me.asnWOmatDGV.RowTemplate.Height = 28
        Me.asnWOmatDGV.Size = New System.Drawing.Size(384, 235)
        Me.asnWOmatDGV.TabIndex = 6
        '
        'exportDiscrepanciesBtn
        '
        Me.exportDiscrepanciesBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.exportDiscrepanciesBtn.ForeColor = System.Drawing.Color.Lavender
        Me.exportDiscrepanciesBtn.Image = CType(resources.GetObject("exportDiscrepanciesBtn.Image"), System.Drawing.Image)
        Me.exportDiscrepanciesBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.exportDiscrepanciesBtn.Location = New System.Drawing.Point(1004, 237)
        Me.exportDiscrepanciesBtn.Name = "exportDiscrepanciesBtn"
        Me.exportDiscrepanciesBtn.Size = New System.Drawing.Size(112, 63)
        Me.exportDiscrepanciesBtn.TabIndex = 5
        Me.exportDiscrepanciesBtn.Text = "Export discrepancies"
        Me.exportDiscrepanciesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.exportDiscrepanciesBtn.UseVisualStyleBackColor = False
        '
        'SQAValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1177, 970)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.routeCB)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SQAValidation"
        Me.Text = "SQA validation"
        CType(Me.materialScannedDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.scannedDeskAsnDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SapDownloadedInfoDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ASNscannedMHDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ContextMenuStripSQA.ResumeLayout(False)
        Me.ContextMenuStripSAP.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.MatWOasnDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.asnWOmatDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents materialScannedDGV As DataGridView
    Friend WithEvents routeCB As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents scanAsnTB As TextBox
    Friend WithEvents scannedDeskAsnDGV As DataGridView
    Friend WithEvents download As Button
    Friend WithEvents SapDownloadedInfoDGV As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ASNscannedMHDGV As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TimerRefreshMaterialHandler As Timer
    Friend WithEvents finishBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ContextMenuStripSQA As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItemSQA As ToolStripMenuItem
    Friend WithEvents ContextMenuStripSAP As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItemSAP As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents percentageLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents MatWOasnDGV As DataGridView
    Friend WithEvents asnWOmatDGV As DataGridView
    Friend WithEvents exportDiscrepanciesBtn As Button
End Class
