<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableSerialsOnCutters
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableSerialsOnCutters))
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.cboCutters = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Title_lbl = New System.Windows.Forms.Label()
        Me.Close_btn = New System.Windows.Forms.Button()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResults
        '
        Me.dgvResults.AllowUserToAddRows = False
        Me.dgvResults.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResults.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResults.Location = New System.Drawing.Point(7, 93)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.ReadOnly = True
        Me.dgvResults.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvResults.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResults.Size = New System.Drawing.Size(535, 645)
        Me.dgvResults.TabIndex = 0
        '
        'cboCutters
        '
        Me.cboCutters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCutters.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCutters.FormattingEnabled = True
        Me.cboCutters.Location = New System.Drawing.Point(139, 56)
        Me.cboCutters.Name = "cboCutters"
        Me.cboCutters.Size = New System.Drawing.Size(272, 32)
        Me.cboCutters.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cortadora:"
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 9)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(530, 43)
        Me.Title_lbl.TabIndex = 117
        Me.Title_lbl.Text = "Series en Cortadoras"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(471, 8)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 118
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Smk_CableSerialsOnCutters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(550, 750)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Title_lbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCutters)
        Me.Controls.Add(Me.dgvResults)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableSerialsOnCutters"
        Me.Text = "En Cortadora"
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents cboCutters As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
    Friend WithEvents Close_btn As System.Windows.Forms.Button
End Class
