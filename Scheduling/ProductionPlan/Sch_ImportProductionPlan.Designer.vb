<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_ImportProductionPlan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sch_ImportProductionPlan))
        Me.Open_btn = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Filename_txt = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProductionPlan_dgv = New CAguilar.DataGridViewWithFilters()
        Me.ColumnHeader_rb = New System.Windows.Forms.RadioButton()
        Me.List_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.ProductionPlan_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Open_btn
        '
        Me.Open_btn.Image = CType(resources.GetObject("Open_btn.Image"), System.Drawing.Image)
        Me.Open_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Open_btn.Location = New System.Drawing.Point(343, 37)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(100, 25)
        Me.Open_btn.TabIndex = 26
        Me.Open_btn.Text = "Open..."
        Me.Open_btn.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 43)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(26, 13)
        Me.label1.TabIndex = 25
        Me.label1.Text = "File:"
        '
        'Filename_txt
        '
        Me.Filename_txt.Location = New System.Drawing.Point(42, 40)
        Me.Filename_txt.Name = "Filename_txt"
        Me.Filename_txt.ReadOnly = True
        Me.Filename_txt.Size = New System.Drawing.Size(295, 20)
        Me.Filename_txt.TabIndex = 24
        '
        'Save_btn
        '
        Me.Save_btn.Enabled = False
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(655, 37)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 23
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(880, 25)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Import Production Plan"
        '
        'ProductionPlan_dgv
        '
        Me.ProductionPlan_dgv.AllowColumnHiding = True
        Me.ProductionPlan_dgv.AllowUserToAddRows = False
        Me.ProductionPlan_dgv.AllowUserToDeleteRows = False
        Me.ProductionPlan_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductionPlan_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ProductionPlan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductionPlan_dgv.Location = New System.Drawing.Point(5, 72)
        Me.ProductionPlan_dgv.Name = "ProductionPlan_dgv"
        Me.ProductionPlan_dgv.ReadOnly = True
        Me.ProductionPlan_dgv.ShowRowNumber = True
        Me.ProductionPlan_dgv.Size = New System.Drawing.Size(870, 235)
        Me.ProductionPlan_dgv.TabIndex = 27
        '
        'ColumnHeader_rb
        '
        Me.ColumnHeader_rb.AutoSize = True
        Me.ColumnHeader_rb.Location = New System.Drawing.Point(55, 13)
        Me.ColumnHeader_rb.Name = "ColumnHeader_rb"
        Me.ColumnHeader_rb.Size = New System.Drawing.Size(139, 17)
        Me.ColumnHeader_rb.TabIndex = 28
        Me.ColumnHeader_rb.Text = "Column Header As Date"
        Me.ColumnHeader_rb.UseVisualStyleBackColor = True
        '
        'List_rb
        '
        Me.List_rb.AutoSize = True
        Me.List_rb.Checked = True
        Me.List_rb.Location = New System.Drawing.Point(8, 13)
        Me.List_rb.Name = "List_rb"
        Me.List_rb.Size = New System.Drawing.Size(41, 17)
        Me.List_rb.TabIndex = 29
        Me.List_rb.TabStop = True
        Me.List_rb.Text = "List"
        Me.List_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ColumnHeader_rb)
        Me.GroupBox1.Controls.Add(Me.List_rb)
        Me.GroupBox1.Location = New System.Drawing.Point(449, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 38)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Layout"
        '
        'Sch_ImportProductionPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 311)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProductionPlan_dgv)
        Me.Controls.Add(Me.Open_btn)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.Filename_txt)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label4)
        Me.Name = "Sch_ImportProductionPlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scheduling"
        CType(Me.ProductionPlan_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Filename_txt As System.Windows.Forms.TextBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProductionPlan_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents ColumnHeader_rb As System.Windows.Forms.RadioButton
    Friend WithEvents List_rb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
