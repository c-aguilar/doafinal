<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VA32_DeliveryCorrection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VA32_DeliveryCorrection))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvMaterials = New System.Windows.Forms.DataGridView()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPaste = New System.Windows.Forms.Button()
        Me.txtShipTo = New System.Windows.Forms.TextBox()
        Me.txtDelivery = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvMaterials, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(496, 25)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "VA32 - Delivery Quantity Correction"
        '
        'dgvMaterials
        '
        Me.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaterials.Location = New System.Drawing.Point(12, 28)
        Me.dgvMaterials.Name = "dgvMaterials"
        Me.dgvMaterials.Size = New System.Drawing.Size(344, 471)
        Me.dgvMaterials.TabIndex = 22
        '
        'btnRun
        '
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(362, 182)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(100, 25)
        Me.btnRun.TabIndex = 23
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(365, 72)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpDate.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Correction Date:"
        '
        'btnPaste
        '
        Me.btnPaste.Image = CType(resources.GetObject("btnPaste.Image"), System.Drawing.Image)
        Me.btnPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPaste.Location = New System.Drawing.Point(362, 28)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(100, 25)
        Me.btnPaste.TabIndex = 26
        Me.btnPaste.Text = "Paste"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'txtShipTo
        '
        Me.txtShipTo.Location = New System.Drawing.Point(365, 117)
        Me.txtShipTo.Name = "txtShipTo"
        Me.txtShipTo.Size = New System.Drawing.Size(121, 20)
        Me.txtShipTo.TabIndex = 27
        '
        'txtDelivery
        '
        Me.txtDelivery.Location = New System.Drawing.Point(365, 156)
        Me.txtDelivery.Name = "txtDelivery"
        Me.txtDelivery.Size = New System.Drawing.Size(121, 20)
        Me.txtDelivery.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(362, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Ship-To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(362, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Delivery:"
        '
        'VA32_DeliveryCorrection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 511)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDelivery)
        Me.Controls.Add(Me.txtShipTo)
        Me.Controls.Add(Me.btnPaste)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.dgvMaterials)
        Me.Controls.Add(Me.Label4)
        Me.Name = "VA32_DeliveryCorrection"
        Me.ShowIcon = False
        Me.Text = "Customer Service"
        CType(Me.dgvMaterials, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvMaterials As System.Windows.Forms.DataGridView
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents txtShipTo As System.Windows.Forms.TextBox
    Friend WithEvents txtDelivery As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
