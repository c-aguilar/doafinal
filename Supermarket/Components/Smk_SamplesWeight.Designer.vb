<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_SamplesWeight
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_SamplesWeight))
        Me.SaveSamples_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.CurrentWeight_lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Scale_chk = New System.Windows.Forms.CheckBox()
        Me.tmScale = New System.Windows.Forms.Timer(Me.components)
        Me.Weight_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Settings_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.NewWeight_nud = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UoM_cbo = New System.Windows.Forms.ComboBox()
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.NewWeight_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveSamples_btn
        '
        Me.SaveSamples_btn.Image = CType(resources.GetObject("SaveSamples_btn.Image"), System.Drawing.Image)
        Me.SaveSamples_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSamples_btn.Location = New System.Drawing.Point(229, 339)
        Me.SaveSamples_btn.Name = "SaveSamples_btn"
        Me.SaveSamples_btn.Size = New System.Drawing.Size(109, 35)
        Me.SaveSamples_btn.TabIndex = 3
        Me.SaveSamples_btn.Text = "Aceptar"
        Me.SaveSamples_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Cantidad de la Muestra:"
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity_nud.Location = New System.Drawing.Point(198, 167)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Quantity_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(170, 38)
        Me.Quantity_nud.TabIndex = 2
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(198, 70)
        Me.Partnumber_txt.MaxLength = 8
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(170, 26)
        Me.Partnumber_txt.TabIndex = 1
        '
        'CurrentWeight_lbl
        '
        Me.CurrentWeight_lbl.AutoSize = True
        Me.CurrentWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentWeight_lbl.Location = New System.Drawing.Point(194, 135)
        Me.CurrentWeight_lbl.Name = "CurrentWeight_lbl"
        Me.CurrentWeight_lbl.Size = New System.Drawing.Size(16, 24)
        Me.CurrentWeight_lbl.TabIndex = 100
        Me.CurrentWeight_lbl.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 16)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Peso Unitario Actual:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 16)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Nuevo Peso Unitario:"
        '
        'Scale_chk
        '
        Me.Scale_chk.Image = CType(resources.GetObject("Scale_chk.Image"), System.Drawing.Image)
        Me.Scale_chk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Scale_chk.Location = New System.Drawing.Point(374, 167)
        Me.Scale_chk.Name = "Scale_chk"
        Me.Scale_chk.Size = New System.Drawing.Size(111, 39)
        Me.Scale_chk.TabIndex = 103
        Me.Scale_chk.Text = "Bascula"
        Me.Scale_chk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Scale_chk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Scale_chk.UseVisualStyleBackColor = True
        '
        'tmScale
        '
        Me.tmScale.Enabled = True
        Me.tmScale.Interval = 200
        '
        'Weight_lbl
        '
        Me.Weight_lbl.AutoSize = True
        Me.Weight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_lbl.Location = New System.Drawing.Point(424, 199)
        Me.Weight_lbl.Name = "Weight_lbl"
        Me.Weight_lbl.Size = New System.Drawing.Size(25, 16)
        Me.Weight_lbl.TabIndex = 104
        Me.Weight_lbl.Text = "0.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(102, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "No. de Parte:"
        '
        'Description_lbl
        '
        Me.Description_lbl.AutoSize = True
        Me.Description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.Location = New System.Drawing.Point(194, 106)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(14, 20)
        Me.Description_lbl.TabIndex = 108
        Me.Description_lbl.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(105, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Descripcion:"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Settings_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(567, 29)
        Me.ToolStripMain.TabIndex = 117
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Settings_btn
        '
        Me.Settings_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Settings_btn.Image = CType(resources.GetObject("Settings_btn.Image"), System.Drawing.Image)
        Me.Settings_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Settings_btn.Name = "Settings_btn"
        Me.Settings_btn.Size = New System.Drawing.Size(23, 26)
        Me.Settings_btn.Text = "&Configuracion"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(243, 26)
        Me.Title_lbl.Text = "Validacion de Pesos Unitarios"
        '
        'NewWeight_nud
        '
        Me.NewWeight_nud.BackColor = System.Drawing.Color.Ivory
        Me.NewWeight_nud.DecimalPlaces = 6
        Me.NewWeight_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewWeight_nud.Location = New System.Drawing.Point(198, 249)
        Me.NewWeight_nud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NewWeight_nud.Name = "NewWeight_nud"
        Me.NewWeight_nud.Size = New System.Drawing.Size(170, 38)
        Me.NewWeight_nud.TabIndex = 119
        Me.NewWeight_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NewWeight_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Unidad de Muestra:"
        '
        'UoM_cbo
        '
        Me.UoM_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UoM_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UoM_cbo.FormattingEnabled = True
        Me.UoM_cbo.Items.AddRange(New Object() {"PC", "M", "FT", "KG", "LB", "L"})
        Me.UoM_cbo.Location = New System.Drawing.Point(198, 211)
        Me.UoM_cbo.Name = "UoM_cbo"
        Me.UoM_cbo.Size = New System.Drawing.Size(84, 32)
        Me.UoM_cbo.TabIndex = 121
        '
        'Smk_SamplesWeight
        '
        Me.AcceptButton = Me.SaveSamples_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 385)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UoM_cbo)
        Me.Controls.Add(Me.NewWeight_nud)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Description_lbl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Weight_lbl)
        Me.Controls.Add(Me.Scale_chk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CurrentWeight_lbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.SaveSamples_btn)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_SamplesWeight"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.NewWeight_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveSamples_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents CurrentWeight_lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Scale_chk As System.Windows.Forms.CheckBox
    Friend WithEvents tmScale As System.Windows.Forms.Timer
    Friend WithEvents Weight_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Settings_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NewWeight_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UoM_cbo As System.Windows.Forms.ComboBox
End Class
