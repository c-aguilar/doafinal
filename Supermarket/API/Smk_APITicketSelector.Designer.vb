<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_APITicketSelector
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ticket_cbo = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.OK_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(377, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selecciona el ticket a generar:"
        '
        'Ticket_cbo
        '
        Me.Ticket_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ticket_cbo.FormattingEnabled = True
        Me.Ticket_cbo.Location = New System.Drawing.Point(12, 77)
        Me.Ticket_cbo.Name = "Ticket_cbo"
        Me.Ticket_cbo.Size = New System.Drawing.Size(610, 39)
        Me.Ticket_cbo.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(634, 25)
        Me.lblTitle.TabIndex = 146
        Me.lblTitle.Text = "Tickets de Inventario"
        '
        'OK_btn
        '
        Me.OK_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_btn.Image = Global.Delta_ERP.My.Resources.Resources.tick_32
        Me.OK_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_btn.Location = New System.Drawing.Point(436, 122)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(186, 45)
        Me.OK_btn.TabIndex = 147
        Me.OK_btn.Text = "Aceptar"
        Me.OK_btn.UseVisualStyleBackColor = True
        '
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.Image = Global.Delta_ERP.My.Resources.Resources.cross_32
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_btn.Location = New System.Drawing.Point(244, 122)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(186, 45)
        Me.Cancel_btn.TabIndex = 148
        Me.Cancel_btn.Text = "Cancelar"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'Smk_APITicketSelector
        '
        Me.AcceptButton = Me.OK_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_btn
        Me.ClientSize = New System.Drawing.Size(634, 179)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Ticket_cbo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Smk_APITicketSelector"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supermarket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Ticket_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents OK_btn As System.Windows.Forms.Button
    Friend WithEvents Cancel_btn As System.Windows.Forms.Button
End Class
