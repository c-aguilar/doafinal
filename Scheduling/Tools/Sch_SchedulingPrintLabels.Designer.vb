<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_SchedulingPrintLabels
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_SchedulingPrintLabels))
        Me.Materials_dgv = New CAguilar.DataGridViewWithFilters()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Print_btn = New System.Windows.Forms.Button()
        Me.Paste_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.ShipTo_btn = New System.Windows.Forms.Button()
        Me.Document_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Materials_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Materials_dgv
        '
        Me.Materials_dgv.AllowColumnHiding = False
        Me.Materials_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Materials_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Materials_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.status, Me.status_img})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Materials_dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.Materials_dgv.Location = New System.Drawing.Point(6, 61)
        Me.Materials_dgv.Name = "Materials_dgv"
        Me.Materials_dgv.ShowRowNumber = True
        Me.Materials_dgv.Size = New System.Drawing.Size(774, 415)
        Me.Materials_dgv.TabIndex = 0
        '
        'status
        '
        Me.status.DataPropertyName = "Status"
        Me.status.HeaderText = ""
        Me.status.Name = "status"
        Me.status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.status.Visible = False
        '
        'status_img
        '
        Me.status_img.HeaderText = ""
        Me.status_img.Name = "status_img"
        Me.status_img.Width = 30
        '
        'Print_btn
        '
        Me.Print_btn.Image = CType(resources.GetObject("Print_btn.Image"), System.Drawing.Image)
        Me.Print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Print_btn.Location = New System.Drawing.Point(324, 31)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(100, 25)
        Me.Print_btn.TabIndex = 1
        Me.Print_btn.Text = "Print"
        Me.Print_btn.UseVisualStyleBackColor = True
        '
        'Paste_btn
        '
        Me.Paste_btn.Image = CType(resources.GetObject("Paste_btn.Image"), System.Drawing.Image)
        Me.Paste_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Paste_btn.Location = New System.Drawing.Point(6, 31)
        Me.Paste_btn.Name = "Paste_btn"
        Me.Paste_btn.Size = New System.Drawing.Size(100, 25)
        Me.Paste_btn.TabIndex = 2
        Me.Paste_btn.Text = "Paste"
        Me.Paste_btn.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(787, 25)
        Me.lblTitle.TabIndex = 8
        Me.lblTitle.Text = "Print Labels"
        '
        'ShipTo_btn
        '
        Me.ShipTo_btn.Image = CType(resources.GetObject("ShipTo_btn.Image"), System.Drawing.Image)
        Me.ShipTo_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ShipTo_btn.Location = New System.Drawing.Point(112, 31)
        Me.ShipTo_btn.Name = "ShipTo_btn"
        Me.ShipTo_btn.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ShipTo_btn.Size = New System.Drawing.Size(100, 25)
        Me.ShipTo_btn.TabIndex = 9
        Me.ShipTo_btn.Text = "Get Ship To"
        Me.ShipTo_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShipTo_btn.UseVisualStyleBackColor = True
        '
        'Document_btn
        '
        Me.Document_btn.Image = CType(resources.GetObject("Document_btn.Image"), System.Drawing.Image)
        Me.Document_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Document_btn.Location = New System.Drawing.Point(218, 31)
        Me.Document_btn.Name = "Document_btn"
        Me.Document_btn.Size = New System.Drawing.Size(100, 25)
        Me.Document_btn.TabIndex = 10
        Me.Document_btn.Text = "Get Document"
        Me.Document_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Document_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(430, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "**Ship To, Container && Document are optional"
        '
        'Sch_SchedulingPrintLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 482)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Document_btn)
        Me.Controls.Add(Me.ShipTo_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Paste_btn)
        Me.Controls.Add(Me.Print_btn)
        Me.Controls.Add(Me.Materials_dgv)
        Me.Name = "Sch_SchedulingPrintLabels"
        Me.ShowIcon = False
        Me.Text = "Scheduling"
        CType(Me.Materials_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Materials_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Print_btn As System.Windows.Forms.Button
    Friend WithEvents Paste_btn As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ShipTo_btn As System.Windows.Forms.Button
    Friend WithEvents Document_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
