<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_FindManufacturing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_FindManufacturing))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Kanban_txt = New CAguilar.WaterMarkTextBox()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Kanbans_dgv = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Local_lbl = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(988, 25)
        Me.lblTitle.TabIndex = 35
        Me.lblTitle.Text = "Buscar en Manufactura"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(386, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 20)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Presiona ENTER para buscar"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.Kanban_txt)
        Me.Panel4.Location = New System.Drawing.Point(348, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(293, 41)
        Me.Panel4.TabIndex = 144
        '
        'Kanban_txt
        '
        Me.Kanban_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanban_txt.BackColor = System.Drawing.Color.White
        Me.Kanban_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kanban_txt.ForeColor = System.Drawing.Color.Black
        Me.Kanban_txt.Location = New System.Drawing.Point(3, 3)
        Me.Kanban_txt.Name = "Kanban_txt"
        Me.Kanban_txt.Size = New System.Drawing.Size(287, 35)
        Me.Kanban_txt.TabIndex = 1
        Me.Kanban_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kanban_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Kanban_txt.WaterMarkText = "Kanban o NP..."
        '
        'Close_btn
        '
        Me.Close_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_btn.BackColor = System.Drawing.Color.White
        Me.Close_btn.BackgroundImage = CType(resources.GetObject("Close_btn.BackgroundImage"), System.Drawing.Image)
        Me.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Close_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.Location = New System.Drawing.Point(747, 595)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(229, 93)
        Me.Close_btn.TabIndex = 143
        Me.Close_btn.Text = "CERRAR"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Kanbans_dgv
        '
        Me.Kanbans_dgv.AllowUserToAddRows = False
        Me.Kanbans_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.Kanbans_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Kanbans_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Kanbans_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Kanbans_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Kanbans_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.Kanbans_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.Kanbans_dgv.Location = New System.Drawing.Point(12, 103)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        Me.Kanbans_dgv.ReadOnly = True
        Me.Kanbans_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Kanbans_dgv.RowHeadersVisible = False
        Me.Kanbans_dgv.RowTemplate.Height = 30
        Me.Kanbans_dgv.Size = New System.Drawing.Size(964, 486)
        Me.Kanbans_dgv.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 592)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 26)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Local de servicio:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Local_lbl
        '
        Me.Local_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Local_lbl.Location = New System.Drawing.Point(13, 618)
        Me.Local_lbl.Name = "Local_lbl"
        Me.Local_lbl.Size = New System.Drawing.Size(531, 70)
        Me.Local_lbl.TabIndex = 148
        Me.Local_lbl.Text = "01020304"
        '
        'CDR_FindManufacturing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 700)
        Me.Controls.Add(Me.Local_lbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Kanbans_dgv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CDR_FindManufacturing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Routes Components"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Kanban_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Kanbans_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Local_lbl As System.Windows.Forms.Label
End Class
