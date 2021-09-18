<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_CableCutterChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_CableCutterChange))
        Me.Serial_dgv = New System.Windows.Forms.DataGridView()
        Me.Cutters_dgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Filter_txt = New System.Windows.Forms.TextBox()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cutter_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Transfer_btn = New System.Windows.Forms.Button()
        Me.Close_btn = New System.Windows.Forms.Button()
        Me.Title_lbl = New System.Windows.Forms.Label()
        CType(Me.Serial_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cutters_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Serial_dgv
        '
        Me.Serial_dgv.AllowUserToAddRows = False
        Me.Serial_dgv.AllowUserToDeleteRows = False
        Me.Serial_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Serial_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Serial_dgv.Location = New System.Drawing.Point(12, 124)
        Me.Serial_dgv.MultiSelect = False
        Me.Serial_dgv.Name = "Serial_dgv"
        Me.Serial_dgv.ReadOnly = True
        Me.Serial_dgv.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_dgv.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Serial_dgv.Size = New System.Drawing.Size(582, 594)
        Me.Serial_dgv.TabIndex = 0
        '
        'Cutters_dgv
        '
        Me.Cutters_dgv.AllowUserToAddRows = False
        Me.Cutters_dgv.AllowUserToDeleteRows = False
        Me.Cutters_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Cutters_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cutters_dgv.Location = New System.Drawing.Point(600, 124)
        Me.Cutters_dgv.MultiSelect = False
        Me.Cutters_dgv.Name = "Cutters_dgv"
        Me.Cutters_dgv.ReadOnly = True
        Me.Cutters_dgv.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cutters_dgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Cutters_dgv.Size = New System.Drawing.Size(396, 594)
        Me.Cutters_dgv.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Buscar por numero de parte:"
        '
        'Filter_txt
        '
        Me.Filter_txt.BackColor = System.Drawing.Color.Ivory
        Me.Filter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Filter_txt.Location = New System.Drawing.Point(16, 87)
        Me.Filter_txt.Name = "Filter_txt"
        Me.Filter_txt.Size = New System.Drawing.Size(207, 29)
        Me.Filter_txt.TabIndex = 3
        '
        'Serial_txt
        '
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(267, 83)
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.ReadOnly = True
        Me.Serial_txt.Size = New System.Drawing.Size(250, 35)
        Me.Serial_txt.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(263, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Serie seleccionada:"
        '
        'Cutter_txt
        '
        Me.Cutter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cutter_txt.Location = New System.Drawing.Point(604, 83)
        Me.Cutter_txt.Name = "Cutter_txt"
        Me.Cutter_txt.ReadOnly = True
        Me.Cutter_txt.Size = New System.Drawing.Size(195, 35)
        Me.Cutter_txt.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(600, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cortadora destino:"
        '
        'Transfer_btn
        '
        Me.Transfer_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Transfer_btn.ForeColor = System.Drawing.Color.Black
        Me.Transfer_btn.Image = CType(resources.GetObject("Transfer_btn.Image"), System.Drawing.Image)
        Me.Transfer_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Transfer_btn.Location = New System.Drawing.Point(523, 63)
        Me.Transfer_btn.Name = "Transfer_btn"
        Me.Transfer_btn.Size = New System.Drawing.Size(75, 58)
        Me.Transfer_btn.TabIndex = 8
        Me.Transfer_btn.Text = "Transferir"
        Me.Transfer_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Transfer_btn.UseVisualStyleBackColor = True
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.Color.DarkRed
        Me.Close_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_btn.ForeColor = System.Drawing.Color.White
        Me.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Close_btn.Location = New System.Drawing.Point(925, 6)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(72, 21)
        Me.Close_btn.TabIndex = 119
        Me.Close_btn.Text = "X"
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Close_btn.UseVisualStyleBackColor = False
        '
        'Title_lbl
        '
        Me.Title_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.White
        Me.Title_lbl.Location = New System.Drawing.Point(12, 7)
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(984, 43)
        Me.Title_lbl.TabIndex = 120
        Me.Title_lbl.Text = "Cambio de Cortadora"
        Me.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Smk_CableCutterChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.Close_btn)
        Me.Controls.Add(Me.Transfer_btn)
        Me.Controls.Add(Me.Cutter_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Filter_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cutters_dgv)
        Me.Controls.Add(Me.Serial_dgv)
        Me.Controls.Add(Me.Title_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_CableCutterChange"
        Me.ShowIcon = False
        Me.Text = "Cambio de cortadora"
        CType(Me.Serial_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cutters_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Serial_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Cutters_dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Filter_txt As System.Windows.Forms.TextBox
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cutter_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Transfer_btn As System.Windows.Forms.Button
    Friend WithEvents Close_btn As System.Windows.Forms.Button
    Friend WithEvents Title_lbl As System.Windows.Forms.Label
End Class
