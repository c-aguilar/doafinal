<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Capabilities
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
        Me.lstCaps = New System.Windows.Forms.ListBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.txtReaderSelected = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstCaps
        '
        Me.lstCaps.Location = New System.Drawing.Point(12, 115)
        Me.lstCaps.Name = "lstCaps"
        Me.lstCaps.Size = New System.Drawing.Size(260, 160)
        Me.lstCaps.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.Image = Global.Delta_ERP.My.Resources.Resources.cross_16
        Me.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelect.Location = New System.Drawing.Point(157, 283)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(115, 23)
        Me.btnSelect.TabIndex = 12
        Me.btnSelect.Text = "Cerrar"
        '
        'txtReaderSelected
        '
        Me.txtReaderSelected.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtReaderSelected.Location = New System.Drawing.Point(13, 89)
        Me.txtReaderSelected.Name = "txtReaderSelected"
        Me.txtReaderSelected.Size = New System.Drawing.Size(260, 20)
        Me.txtReaderSelected.TabIndex = 23
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(11, 71)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(236, 15)
        Me.label2.TabIndex = 24
        Me.label2.Text = "Lector seleccionado:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtName.Location = New System.Drawing.Point(14, 47)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(260, 20)
        Me.txtName.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Nombre:"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(288, 25)
        Me.lblTitle.TabIndex = 39
        Me.lblTitle.Text = "Seleccionar Lector"
        '
        'Capabilities
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(288, 315)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtReaderSelected)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lstCaps)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(304, 353)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(304, 333)
        Me.Name = "Capabilities"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCaps As System.Windows.Forms.ListBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents txtReaderSelected As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
End Class


'        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
'        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
'        Me.ClientSize = New System.Drawing.Size(284, 283)
'        Me.Controls.Add(Me.btnSelect)
'        Me.Controls.Add(Me.lstCaps)
'        Me.MaximizeBox = False
'        Me.MinimizeBox = False
'        Me.Name = "Capabilities"
'#If Not WindowsCE Then
'        Me.MaximumSize = New System.Drawing.Size(304, 333)
'        Me.MinimumSize = New System.Drawing.Size(304, 333)
'        Me.ClientSize = New System.Drawing.Size(304, 333)
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
'#End If
'        Me.Text = "Capabilities"
'        Me.ResumeLayout(False)