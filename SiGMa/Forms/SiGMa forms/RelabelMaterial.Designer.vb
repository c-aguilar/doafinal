<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RelabelMaterial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RelabelMaterial))
        Me.printBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.asnTb = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.supplierTB = New System.Windows.Forms.TextBox()
        Me.plantCB = New System.Windows.Forms.ComboBox()
        Me.quantityTB = New System.Windows.Forms.TextBox()
        Me.partNumberTB = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'printBtn
        '
        Me.printBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.printBtn.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.printBtn.Image = CType(resources.GetObject("printBtn.Image"), System.Drawing.Image)
        Me.printBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.printBtn.Location = New System.Drawing.Point(258, 270)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(64, 28)
        Me.printBtn.TabIndex = 0
        Me.printBtn.Text = "Print"
        Me.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.printBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Quantity:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Plant:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(46, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Supplier:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.asnTb)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.supplierTB)
        Me.GroupBox1.Controls.Add(Me.plantCB)
        Me.GroupBox1.Controls.Add(Me.quantityTB)
        Me.GroupBox1.Controls.Add(Me.partNumberTB)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.printBtn)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 304)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Capture container information"
        '
        'asnTb
        '
        Me.asnTb.BackColor = System.Drawing.Color.WhiteSmoke
        Me.asnTb.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asnTb.ForeColor = System.Drawing.Color.MidnightBlue
        Me.asnTb.Location = New System.Drawing.Point(144, 200)
        Me.asnTb.Name = "asnTb"
        Me.asnTb.Size = New System.Drawing.Size(143, 31)
        Me.asnTb.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "ASN:"
        '
        'supplierTB
        '
        Me.supplierTB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.supplierTB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.supplierTB.Location = New System.Drawing.Point(144, 162)
        Me.supplierTB.Name = "supplierTB"
        Me.supplierTB.Size = New System.Drawing.Size(143, 31)
        Me.supplierTB.TabIndex = 8
        '
        'plantCB
        '
        Me.plantCB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plantCB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plantCB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.plantCB.FormattingEnabled = True
        Me.plantCB.Location = New System.Drawing.Point(144, 119)
        Me.plantCB.Name = "plantCB"
        Me.plantCB.Size = New System.Drawing.Size(143, 31)
        Me.plantCB.TabIndex = 7
        '
        'quantityTB
        '
        Me.quantityTB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.quantityTB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityTB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.quantityTB.Location = New System.Drawing.Point(144, 76)
        Me.quantityTB.Name = "quantityTB"
        Me.quantityTB.Size = New System.Drawing.Size(143, 31)
        Me.quantityTB.TabIndex = 6
        '
        'partNumberTB
        '
        Me.partNumberTB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.partNumberTB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.partNumberTB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.partNumberTB.Location = New System.Drawing.Point(144, 36)
        Me.partNumberTB.Name = "partNumberTB"
        Me.partNumberTB.Size = New System.Drawing.Size(143, 31)
        Me.partNumberTB.TabIndex = 5
        '
        'RelabelMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(363, 326)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RelabelMaterial"
        Me.Text = "Relabel material"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents printBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents supplierTB As TextBox
    Friend WithEvents plantCB As ComboBox
    Friend WithEvents quantityTB As TextBox
    Friend WithEvents partNumberTB As TextBox
    Friend WithEvents asnTb As TextBox
    Friend WithEvents Label5 As Label
End Class
