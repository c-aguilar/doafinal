<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_KanbanPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_KanbanPrint))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBoard = New System.Windows.Forms.ComboBox()
        Me.btnPrintAll = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboKit = New System.Windows.Forms.ComboBox()
        Me.btnPrintID = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkBusinessDouble = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkIDDouble = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkPartnumberDouble = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPartnumber = New System.Windows.Forms.TextBox()
        Me.btnPrintPartnumber = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkComment = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.btnPrintComment = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tablero:"
        '
        'cboBoard
        '
        Me.cboBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBoard.FormattingEnabled = True
        Me.cboBoard.Location = New System.Drawing.Point(14, 68)
        Me.cboBoard.Name = "cboBoard"
        Me.cboBoard.Size = New System.Drawing.Size(231, 24)
        Me.cboBoard.TabIndex = 7
        '
        'btnPrintAll
        '
        Me.btnPrintAll.Image = CType(resources.GetObject("btnPrintAll.Image"), System.Drawing.Image)
        Me.btnPrintAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintAll.Location = New System.Drawing.Point(161, 151)
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Size = New System.Drawing.Size(85, 25)
        Me.btnPrintAll.TabIndex = 9
        Me.btnPrintAll.Text = "Imprimir"
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(14, 28)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(141, 22)
        Me.txtID.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Kit:"
        '
        'cboKit
        '
        Me.cboKit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboKit.FormattingEnabled = True
        Me.cboKit.Location = New System.Drawing.Point(14, 115)
        Me.cboKit.Name = "cboKit"
        Me.cboKit.Size = New System.Drawing.Size(231, 24)
        Me.cboKit.TabIndex = 11
        '
        'btnPrintID
        '
        Me.btnPrintID.Image = CType(resources.GetObject("btnPrintID.Image"), System.Drawing.Image)
        Me.btnPrintID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintID.Location = New System.Drawing.Point(161, 28)
        Me.btnPrintID.Name = "btnPrintID"
        Me.btnPrintID.Size = New System.Drawing.Size(85, 25)
        Me.btnPrintID.TabIndex = 13
        Me.btnPrintID.Text = "Imprimir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "ID:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkBusinessDouble)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboBusiness)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnPrintAll)
        Me.Panel1.Controls.Add(Me.cboBoard)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboKit)
        Me.Panel1.Location = New System.Drawing.Point(11, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 193)
        Me.Panel1.TabIndex = 15
        '
        'chkBusinessDouble
        '
        Me.chkBusinessDouble.AutoSize = True
        Me.chkBusinessDouble.Checked = True
        Me.chkBusinessDouble.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBusinessDouble.ForeColor = System.Drawing.Color.Black
        Me.chkBusinessDouble.Location = New System.Drawing.Point(14, 169)
        Me.chkBusinessDouble.Name = "chkBusinessDouble"
        Me.chkBusinessDouble.Size = New System.Drawing.Size(104, 17)
        Me.chkBusinessDouble.TabIndex = 15
        Me.chkBusinessDouble.Text = "Imprimir 2 copias"
        Me.chkBusinessDouble.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(11, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Negocio:"
        '
        'cboBusiness
        '
        Me.cboBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusiness.FormattingEnabled = True
        Me.cboBusiness.Location = New System.Drawing.Point(14, 21)
        Me.cboBusiness.Name = "cboBusiness"
        Me.cboBusiness.Size = New System.Drawing.Size(231, 24)
        Me.cboBusiness.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkIDDouble)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtID)
        Me.Panel2.Controls.Add(Me.btnPrintID)
        Me.Panel2.Location = New System.Drawing.Point(11, 236)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(259, 82)
        Me.Panel2.TabIndex = 16
        '
        'chkIDDouble
        '
        Me.chkIDDouble.AutoSize = True
        Me.chkIDDouble.Checked = True
        Me.chkIDDouble.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIDDouble.ForeColor = System.Drawing.Color.Black
        Me.chkIDDouble.Location = New System.Drawing.Point(14, 58)
        Me.chkIDDouble.Name = "chkIDDouble"
        Me.chkIDDouble.Size = New System.Drawing.Size(104, 17)
        Me.chkIDDouble.TabIndex = 16
        Me.chkIDDouble.Text = "Imprimir 2 copias"
        Me.chkIDDouble.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkPartnumberDouble)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtPartnumber)
        Me.Panel3.Controls.Add(Me.btnPrintPartnumber)
        Me.Panel3.Location = New System.Drawing.Point(11, 324)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(259, 82)
        Me.Panel3.TabIndex = 17
        '
        'chkPartnumberDouble
        '
        Me.chkPartnumberDouble.AutoSize = True
        Me.chkPartnumberDouble.Checked = True
        Me.chkPartnumberDouble.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPartnumberDouble.ForeColor = System.Drawing.Color.Black
        Me.chkPartnumberDouble.Location = New System.Drawing.Point(14, 58)
        Me.chkPartnumberDouble.Name = "chkPartnumberDouble"
        Me.chkPartnumberDouble.Size = New System.Drawing.Size(104, 17)
        Me.chkPartnumberDouble.TabIndex = 16
        Me.chkPartnumberDouble.Text = "Imprimir 2 copias"
        Me.chkPartnumberDouble.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Partnumber:"
        '
        'txtPartnumber
        '
        Me.txtPartnumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartnumber.Location = New System.Drawing.Point(14, 28)
        Me.txtPartnumber.Name = "txtPartnumber"
        Me.txtPartnumber.Size = New System.Drawing.Size(141, 22)
        Me.txtPartnumber.TabIndex = 10
        '
        'btnPrintPartnumber
        '
        Me.btnPrintPartnumber.Image = CType(resources.GetObject("btnPrintPartnumber.Image"), System.Drawing.Image)
        Me.btnPrintPartnumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintPartnumber.Location = New System.Drawing.Point(161, 28)
        Me.btnPrintPartnumber.Name = "btnPrintPartnumber"
        Me.btnPrintPartnumber.Size = New System.Drawing.Size(85, 25)
        Me.btnPrintPartnumber.TabIndex = 13
        Me.btnPrintPartnumber.Text = "Imprimir"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.chkComment)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.txtComment)
        Me.Panel4.Controls.Add(Me.btnPrintComment)
        Me.Panel4.Location = New System.Drawing.Point(10, 412)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(259, 82)
        Me.Panel4.TabIndex = 18
        '
        'chkComment
        '
        Me.chkComment.AutoSize = True
        Me.chkComment.Checked = True
        Me.chkComment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkComment.ForeColor = System.Drawing.Color.Black
        Me.chkComment.Location = New System.Drawing.Point(14, 58)
        Me.chkComment.Name = "chkComment"
        Me.chkComment.Size = New System.Drawing.Size(104, 17)
        Me.chkComment.TabIndex = 17
        Me.chkComment.Text = "Imprimir 2 copias"
        Me.chkComment.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Comentario:"
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(14, 28)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(141, 22)
        Me.txtComment.TabIndex = 10
        '
        'btnPrintComment
        '
        Me.btnPrintComment.Image = CType(resources.GetObject("btnPrintComment.Image"), System.Drawing.Image)
        Me.btnPrintComment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintComment.Location = New System.Drawing.Point(161, 28)
        Me.btnPrintComment.Name = "btnPrintComment"
        Me.btnPrintComment.Size = New System.Drawing.Size(85, 25)
        Me.btnPrintComment.TabIndex = 13
        Me.btnPrintComment.Text = "Imprimir"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(282, 25)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Impresion de Kanbans"
        '
        'CDR_KanbanPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(282, 528)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CDR_KanbanPrint"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBoard As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrintAll As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboKit As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrintID As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartnumber As System.Windows.Forms.TextBox
    Friend WithEvents btnPrintPartnumber As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBusiness As System.Windows.Forms.ComboBox
    Friend WithEvents chkBusinessDouble As System.Windows.Forms.CheckBox
    Friend WithEvents chkIDDouble As System.Windows.Forms.CheckBox
    Friend WithEvents chkPartnumberDouble As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents btnPrintComment As System.Windows.Forms.Button
    Friend WithEvents chkComment As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
