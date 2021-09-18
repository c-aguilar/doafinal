<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAn_ZMF47
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAn_ZMF47))
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.MinKGnud = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MinLnud = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MinMnud = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MinPCnud = New System.Windows.Forms.NumericUpDown()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbForce = New System.Windows.Forms.RadioButton()
        Me.rbAvailable = New System.Windows.Forms.RadioButton()
        Me.MaxKGnud = New System.Windows.Forms.NumericUpDown()
        Me.MaxLnud = New System.Windows.Forms.NumericUpDown()
        Me.MaxMnud = New System.Windows.Forms.NumericUpDown()
        Me.MaxPCnud = New System.Windows.Forms.NumericUpDown()
        Me.rbOnlySave = New System.Windows.Forms.RadioButton()
        Me.Reportrb = New System.Windows.Forms.RadioButton()
        CType(Me.MinKGnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinLnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinMnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinPCnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxKGnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxLnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxMnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxPCnud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Run_btn
        '
        Me.Run_btn.Location = New System.Drawing.Point(220, 144)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(81, 36)
        Me.Run_btn.TabIndex = 9
        Me.Run_btn.Text = "CLEAN"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'MinKGnud
        '
        Me.MinKGnud.Location = New System.Drawing.Point(185, 16)
        Me.MinKGnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MinKGnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinKGnud.Name = "MinKGnud"
        Me.MinKGnud.Size = New System.Drawing.Size(75, 20)
        Me.MinKGnud.TabIndex = 10
        Me.MinKGnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MinKGnud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(137, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Max G:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Max ML:"
        '
        'MinLnud
        '
        Me.MinLnud.Location = New System.Drawing.Point(185, 42)
        Me.MinLnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MinLnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinLnud.Name = "MinLnud"
        Me.MinLnud.Size = New System.Drawing.Size(75, 20)
        Me.MinLnud.TabIndex = 12
        Me.MinLnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MinLnud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(127, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Max MM:"
        '
        'MinMnud
        '
        Me.MinMnud.Location = New System.Drawing.Point(185, 68)
        Me.MinMnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MinMnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinMnud.Name = "MinMnud"
        Me.MinMnud.Size = New System.Drawing.Size(75, 20)
        Me.MinMnud.TabIndex = 14
        Me.MinMnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MinMnud.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(134, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Max PC"
        '
        'MinPCnud
        '
        Me.MinPCnud.Location = New System.Drawing.Point(185, 94)
        Me.MinPCnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MinPCnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinPCnud.Name = "MinPCnud"
        Me.MinPCnud.Size = New System.Drawing.Size(75, 20)
        Me.MinPCnud.TabIndex = 16
        Me.MinPCnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MinPCnud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.Location = New System.Drawing.Point(9, 31)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(81, 20)
        Me.Partnumber_txt.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Partnumber:"
        '
        'rbForce
        '
        Me.rbForce.AutoSize = True
        Me.rbForce.Location = New System.Drawing.Point(9, 80)
        Me.rbForce.Name = "rbForce"
        Me.rbForce.Size = New System.Drawing.Size(54, 17)
        Me.rbForce.TabIndex = 20
        Me.rbForce.Text = "Forzar"
        Me.rbForce.UseVisualStyleBackColor = True
        '
        'rbAvailable
        '
        Me.rbAvailable.AutoSize = True
        Me.rbAvailable.Checked = True
        Me.rbAvailable.Location = New System.Drawing.Point(9, 57)
        Me.rbAvailable.Name = "rbAvailable"
        Me.rbAvailable.Size = New System.Drawing.Size(106, 17)
        Me.rbAvailable.TabIndex = 21
        Me.rbAvailable.TabStop = True
        Me.rbAvailable.Text = "Solo procesables"
        Me.rbAvailable.UseVisualStyleBackColor = True
        '
        'MaxKGnud
        '
        Me.MaxKGnud.Location = New System.Drawing.Point(266, 17)
        Me.MaxKGnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MaxKGnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxKGnud.Name = "MaxKGnud"
        Me.MaxKGnud.Size = New System.Drawing.Size(75, 20)
        Me.MaxKGnud.TabIndex = 22
        Me.MaxKGnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxKGnud.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'MaxLnud
        '
        Me.MaxLnud.Location = New System.Drawing.Point(266, 43)
        Me.MaxLnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MaxLnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxLnud.Name = "MaxLnud"
        Me.MaxLnud.Size = New System.Drawing.Size(75, 20)
        Me.MaxLnud.TabIndex = 23
        Me.MaxLnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxLnud.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'MaxMnud
        '
        Me.MaxMnud.Location = New System.Drawing.Point(266, 69)
        Me.MaxMnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MaxMnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxMnud.Name = "MaxMnud"
        Me.MaxMnud.Size = New System.Drawing.Size(75, 20)
        Me.MaxMnud.TabIndex = 24
        Me.MaxMnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxMnud.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'MaxPCnud
        '
        Me.MaxPCnud.Location = New System.Drawing.Point(266, 95)
        Me.MaxPCnud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.MaxPCnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxPCnud.Name = "MaxPCnud"
        Me.MaxPCnud.Size = New System.Drawing.Size(75, 20)
        Me.MaxPCnud.TabIndex = 25
        Me.MaxPCnud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaxPCnud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbOnlySave
        '
        Me.rbOnlySave.AutoSize = True
        Me.rbOnlySave.Location = New System.Drawing.Point(9, 103)
        Me.rbOnlySave.Name = "rbOnlySave"
        Me.rbOnlySave.Size = New System.Drawing.Size(76, 17)
        Me.rbOnlySave.TabIndex = 26
        Me.rbOnlySave.Text = "Solo Editar"
        Me.rbOnlySave.UseVisualStyleBackColor = True
        '
        'Reportrb
        '
        Me.Reportrb.AutoSize = True
        Me.Reportrb.Location = New System.Drawing.Point(9, 126)
        Me.Reportrb.Name = "Reportrb"
        Me.Reportrb.Size = New System.Drawing.Size(84, 17)
        Me.Reportrb.TabIndex = 27
        Me.Reportrb.Text = "Comparativo"
        Me.Reportrb.UseVisualStyleBackColor = True
        '
        'MAn_ZMF47
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 194)
        Me.Controls.Add(Me.Reportrb)
        Me.Controls.Add(Me.rbOnlySave)
        Me.Controls.Add(Me.MaxPCnud)
        Me.Controls.Add(Me.MaxMnud)
        Me.Controls.Add(Me.MaxLnud)
        Me.Controls.Add(Me.MaxKGnud)
        Me.Controls.Add(Me.rbAvailable)
        Me.Controls.Add(Me.rbForce)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MinPCnud)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MinMnud)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MinLnud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MinKGnud)
        Me.Controls.Add(Me.Run_btn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MAn_ZMF47"
        Me.Text = "ZMF47"
        CType(Me.MinKGnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinLnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinMnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinPCnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxKGnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxLnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxMnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxPCnud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents MinKGnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MinLnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MinMnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MinPCnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbForce As System.Windows.Forms.RadioButton
    Friend WithEvents rbAvailable As System.Windows.Forms.RadioButton
    Friend WithEvents MaxKGnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaxLnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaxMnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaxPCnud As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbOnlySave As System.Windows.Forms.RadioButton
    Friend WithEvents Reportrb As System.Windows.Forms.RadioButton
End Class
