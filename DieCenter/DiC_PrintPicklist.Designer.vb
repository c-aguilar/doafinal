<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiC_PrintPicklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiC_PrintPicklist))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Print_btn = New System.Windows.Forms.Button()
        Me.Warehouse_cbo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.lblTitle.Size = New System.Drawing.Size(268, 25)
        Me.lblTitle.TabIndex = 36
        Me.lblTitle.Text = "Imprimir Picklist"
        '
        'Print_btn
        '
        Me.Print_btn.Image = CType(resources.GetObject("Print_btn.Image"), System.Drawing.Image)
        Me.Print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Print_btn.Location = New System.Drawing.Point(83, 98)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(100, 25)
        Me.Print_btn.TabIndex = 37
        Me.Print_btn.Text = "Imprimir"
        Me.Print_btn.UseVisualStyleBackColor = True
        '
        'Warehouse_cbo
        '
        Me.Warehouse_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Warehouse_cbo.FormattingEnabled = True
        Me.Warehouse_cbo.Location = New System.Drawing.Point(27, 55)
        Me.Warehouse_cbo.Name = "Warehouse_cbo"
        Me.Warehouse_cbo.Size = New System.Drawing.Size(215, 21)
        Me.Warehouse_cbo.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Centro de dados:"
        '
        'DiC_PrintPicklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 135)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Warehouse_cbo)
        Me.Controls.Add(Me.Print_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DiC_PrintPicklist"
        Me.ShowIcon = False
        Me.Text = "Die Center"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Print_btn As System.Windows.Forms.Button
    Friend WithEvents Warehouse_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
