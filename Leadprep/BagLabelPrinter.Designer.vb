<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BagLabelPrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BagLabelPrinter))
        Me.BagLabelPrinter_Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.BagLabelPrinter_Print_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.BagLabelPrinter_Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BagLabelPrinter_Quantity_nud
        '
        Me.BagLabelPrinter_Quantity_nud.Location = New System.Drawing.Point(22, 34)
        Me.BagLabelPrinter_Quantity_nud.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.BagLabelPrinter_Quantity_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BagLabelPrinter_Quantity_nud.Name = "BagLabelPrinter_Quantity_nud"
        Me.BagLabelPrinter_Quantity_nud.Size = New System.Drawing.Size(120, 20)
        Me.BagLabelPrinter_Quantity_nud.TabIndex = 0
        Me.BagLabelPrinter_Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BagLabelPrinter_Print_btn
        '
        Me.BagLabelPrinter_Print_btn.Image = CType(resources.GetObject("BagLabelPrinter_Print_btn.Image"), System.Drawing.Image)
        Me.BagLabelPrinter_Print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BagLabelPrinter_Print_btn.Location = New System.Drawing.Point(172, 31)
        Me.BagLabelPrinter_Print_btn.Name = "BagLabelPrinter_Print_btn"
        Me.BagLabelPrinter_Print_btn.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BagLabelPrinter_Print_btn.Size = New System.Drawing.Size(100, 23)
        Me.BagLabelPrinter_Print_btn.TabIndex = 1
        Me.BagLabelPrinter_Print_btn.Text = "Print"
        Me.BagLabelPrinter_Print_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "How many labels?"
        '
        'BagLabelPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 80)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BagLabelPrinter_Print_btn)
        Me.Controls.Add(Me.BagLabelPrinter_Quantity_nud)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BagLabelPrinter"
        Me.ShowIcon = False
        Me.Text = "Print labels..."
        CType(Me.BagLabelPrinter_Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BagLabelPrinter_Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents BagLabelPrinter_Print_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
