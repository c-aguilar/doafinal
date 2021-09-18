<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_GenericKanbans
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_GenericKanbans))
        Me.Generic_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Paste_btn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.Generic_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Generic_dgv
        '
        Me.Generic_dgv.AllowColumnHiding = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Generic_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Generic_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Generic_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Generic_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Generic_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Generic_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Generic_dgv.DefaultRowFilter = Nothing
        Me.Generic_dgv.EnableHeadersVisualStyles = False
        Me.Generic_dgv.Location = New System.Drawing.Point(12, 28)
        Me.Generic_dgv.Name = "Generic_dgv"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Generic_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Generic_dgv.ShowRowNumber = True
        Me.Generic_dgv.Size = New System.Drawing.Size(673, 535)
        Me.Generic_dgv.TabIndex = 0
        '
        'Paste_btn
        '
        Me.Paste_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Paste_btn.Image = CType(resources.GetObject("Paste_btn.Image"), System.Drawing.Image)
        Me.Paste_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Paste_btn.Location = New System.Drawing.Point(689, 28)
        Me.Paste_btn.Name = "Paste_btn"
        Me.Paste_btn.Size = New System.Drawing.Size(75, 23)
        Me.Paste_btn.TabIndex = 1
        Me.Paste_btn.Text = "Pegar"
        Me.Paste_btn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(776, 25)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Kanbans Genericas"
        '
        'CDR_GenericKanbans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 575)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Paste_btn)
        Me.Controls.Add(Me.Generic_dgv)
        Me.Name = "CDR_GenericKanbans"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Componente Delivery Routes"
        CType(Me.Generic_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Generic_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Paste_btn As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
