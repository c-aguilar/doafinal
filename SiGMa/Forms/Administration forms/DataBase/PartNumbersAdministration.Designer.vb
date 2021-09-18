<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartNumbersAdministration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartNumbersAdministration))
        Me.loadPNBtn = New System.Windows.Forms.Button()
        Me.partNumbersDGV = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.plantCB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.searchTB = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.searchBtn = New System.Windows.Forms.Button()
        CType(Me.partNumbersDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'loadPNBtn
        '
        Me.loadPNBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.loadPNBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.loadPNBtn.Image = CType(resources.GetObject("loadPNBtn.Image"), System.Drawing.Image)
        Me.loadPNBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.loadPNBtn.Location = New System.Drawing.Point(306, 28)
        Me.loadPNBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.loadPNBtn.Name = "loadPNBtn"
        Me.loadPNBtn.Size = New System.Drawing.Size(71, 36)
        Me.loadPNBtn.TabIndex = 0
        Me.loadPNBtn.Text = "Load"
        Me.loadPNBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.loadPNBtn.UseVisualStyleBackColor = False
        '
        'partNumbersDGV
        '
        Me.partNumbersDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.partNumbersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.partNumbersDGV.Location = New System.Drawing.Point(16, 97)
        Me.partNumbersDGV.Margin = New System.Windows.Forms.Padding(4)
        Me.partNumbersDGV.Name = "partNumbersDGV"
        Me.partNumbersDGV.Size = New System.Drawing.Size(911, 438)
        Me.partNumbersDGV.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(42, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select plant:"
        '
        'plantCB
        '
        Me.plantCB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plantCB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.plantCB.FormattingEnabled = True
        Me.plantCB.Location = New System.Drawing.Point(136, 32)
        Me.plantCB.Name = "plantCB"
        Me.plantCB.Size = New System.Drawing.Size(121, 31)
        Me.plantCB.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Search:"
        '
        'searchTB
        '
        Me.searchTB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.searchTB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.searchTB.Location = New System.Drawing.Point(170, 32)
        Me.searchTB.Name = "searchTB"
        Me.searchTB.Size = New System.Drawing.Size(141, 31)
        Me.searchTB.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.loadPNBtn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.plantCB)
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 78)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load new part numbers"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.searchBtn)
        Me.GroupBox2.Controls.Add(Me.searchTB)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(447, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 78)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search by part number"
        '
        'searchBtn
        '
        Me.searchBtn.BackColor = System.Drawing.Color.DarkBlue
        Me.searchBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.searchBtn.Image = CType(resources.GetObject("searchBtn.Image"), System.Drawing.Image)
        Me.searchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.searchBtn.Location = New System.Drawing.Point(367, 29)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 35)
        Me.searchBtn.TabIndex = 6
        Me.searchBtn.Text = "Search"
        Me.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.searchBtn.UseVisualStyleBackColor = False
        '
        'PartNumbersAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(943, 549)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.partNumbersDGV)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PartNumbersAdministration"
        Me.Text = "Part numbers administration"
        CType(Me.partNumbersDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents loadPNBtn As Button
    Friend WithEvents partNumbersDGV As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents plantCB As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents searchTB As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents searchBtn As Button
End Class
