<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_PartialDiscount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_PartialDiscount))
        Me.Label0 = New System.Windows.Forms.Label()
        Me.Partial_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Quantity_nud = New System.Windows.Forms.NumericUpDown()
        Me.Serial_txt = New System.Windows.Forms.TextBox()
        Me.CurrentQuantity_lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UoM_cbo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Scale_chk = New System.Windows.Forms.CheckBox()
        Me.Weight_lbl = New System.Windows.Forms.Label()
        Me.Partnumber_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Settings_btn = New System.Windows.Forms.ToolStripButton()
        Me.Sample_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.NoWeight_lbl = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label0
        '
        Me.Label0.AutoSize = True
        Me.Label0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0.Location = New System.Drawing.Point(144, 60)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(43, 16)
        Me.Label0.TabIndex = 89
        Me.Label0.Text = "Serie:"
        '
        'Partial_btn
        '
        Me.Partial_btn.Image = Global.Delta_ERP.My.Resources.Resources.box_front_open_hand
        Me.Partial_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Partial_btn.Location = New System.Drawing.Point(229, 280)
        Me.Partial_btn.Name = "Partial_btn"
        Me.Partial_btn.Size = New System.Drawing.Size(109, 35)
        Me.Partial_btn.TabIndex = 3
        Me.Partial_btn.Text = "Aceptar"
        Me.Partial_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Cantidad de Descuento:"
        '
        'Quantity_nud
        '
        Me.Quantity_nud.BackColor = System.Drawing.Color.Ivory
        Me.Quantity_nud.DecimalPlaces = 3
        Me.Quantity_nud.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity_nud.Location = New System.Drawing.Point(198, 175)
        Me.Quantity_nud.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Quantity_nud.Name = "Quantity_nud"
        Me.Quantity_nud.Size = New System.Drawing.Size(217, 38)
        Me.Quantity_nud.TabIndex = 2
        Me.Quantity_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Quantity_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Serial_txt
        '
        Me.Serial_txt.BackColor = System.Drawing.Color.Ivory
        Me.Serial_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_txt.Location = New System.Drawing.Point(198, 52)
        Me.Serial_txt.MaxLength = 16
        Me.Serial_txt.Name = "Serial_txt"
        Me.Serial_txt.Size = New System.Drawing.Size(170, 26)
        Me.Serial_txt.TabIndex = 1
        '
        'CurrentQuantity_lbl
        '
        Me.CurrentQuantity_lbl.AutoSize = True
        Me.CurrentQuantity_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentQuantity_lbl.Location = New System.Drawing.Point(194, 145)
        Me.CurrentQuantity_lbl.Name = "CurrentQuantity_lbl"
        Me.CurrentQuantity_lbl.Size = New System.Drawing.Size(16, 24)
        Me.CurrentQuantity_lbl.TabIndex = 100
        Me.CurrentQuantity_lbl.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(84, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Cantidad actual:"
        '
        'UoM_cbo
        '
        Me.UoM_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UoM_cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UoM_cbo.FormattingEnabled = True
        Me.UoM_cbo.Items.AddRange(New Object() {"PC", "M", "FT", "KG", "LB", "L"})
        Me.UoM_cbo.Location = New System.Drawing.Point(198, 219)
        Me.UoM_cbo.Name = "UoM_cbo"
        Me.UoM_cbo.Size = New System.Drawing.Size(84, 32)
        Me.UoM_cbo.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 16)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Unidad de Descuento:"
        '
        'Scale_chk
        '
        Me.Scale_chk.Image = CType(resources.GetObject("Scale_chk.Image"), System.Drawing.Image)
        Me.Scale_chk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Scale_chk.Location = New System.Drawing.Point(421, 174)
        Me.Scale_chk.Name = "Scale_chk"
        Me.Scale_chk.Size = New System.Drawing.Size(111, 39)
        Me.Scale_chk.TabIndex = 103
        Me.Scale_chk.Text = "Bascula"
        Me.Scale_chk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Scale_chk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Scale_chk.UseVisualStyleBackColor = True
        '
        'Weight_lbl
        '
        Me.Weight_lbl.AutoSize = True
        Me.Weight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_lbl.Location = New System.Drawing.Point(471, 203)
        Me.Weight_lbl.Name = "Weight_lbl"
        Me.Weight_lbl.Size = New System.Drawing.Size(25, 16)
        Me.Weight_lbl.TabIndex = 104
        Me.Weight_lbl.Text = "0.0"
        '
        'Partnumber_lbl
        '
        Me.Partnumber_lbl.AutoSize = True
        Me.Partnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_lbl.Location = New System.Drawing.Point(194, 83)
        Me.Partnumber_lbl.Name = "Partnumber_lbl"
        Me.Partnumber_lbl.Size = New System.Drawing.Size(16, 24)
        Me.Partnumber_lbl.TabIndex = 106
        Me.Partnumber_lbl.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(158, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "NP:"
        '
        'Description_lbl
        '
        Me.Description_lbl.AutoSize = True
        Me.Description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.Location = New System.Drawing.Point(194, 116)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(14, 20)
        Me.Description_lbl.TabIndex = 108
        Me.Description_lbl.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(105, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Descripcion:"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Settings_btn, Me.Sample_btn, Me.toolStripSeparator, Me.Title_lbl})
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
        'Sample_btn
        '
        Me.Sample_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Sample_btn.Image = CType(resources.GetObject("Sample_btn.Image"), System.Drawing.Image)
        Me.Sample_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Sample_btn.Name = "Sample_btn"
        Me.Sample_btn.Size = New System.Drawing.Size(23, 26)
        Me.Sample_btn.Text = "Muestreo"
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
        Me.Title_lbl.Size = New System.Drawing.Size(154, 26)
        Me.Title_lbl.Text = "Descuento Parcial"
        '
        'NoWeight_lbl
        '
        Me.NoWeight_lbl.AutoSize = True
        Me.NoWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoWeight_lbl.ForeColor = System.Drawing.Color.Red
        Me.NoWeight_lbl.Location = New System.Drawing.Point(438, 220)
        Me.NoWeight_lbl.Name = "NoWeight_lbl"
        Me.NoWeight_lbl.Size = New System.Drawing.Size(108, 32)
        Me.NoWeight_lbl.TabIndex = 118
        Me.NoWeight_lbl.Text = "Componente sin " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "peso unitario"
        Me.NoWeight_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.NoWeight_lbl.Visible = False
        '
        'Timer1
        '
        '
        'Smk_PartialDiscount
        '
        Me.AcceptButton = Me.Partial_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 327)
        Me.Controls.Add(Me.NoWeight_lbl)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Description_lbl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Partnumber_lbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Weight_lbl)
        Me.Controls.Add(Me.Scale_chk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UoM_cbo)
        Me.Controls.Add(Me.CurrentQuantity_lbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Serial_txt)
        Me.Controls.Add(Me.Quantity_nud)
        Me.Controls.Add(Me.Partial_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smk_PartialDiscount"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supermarket"
        CType(Me.Quantity_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label0 As System.Windows.Forms.Label
    Friend WithEvents Partial_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Quantity_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Serial_txt As System.Windows.Forms.TextBox
    Friend WithEvents CurrentQuantity_lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UoM_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Scale_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Weight_lbl As System.Windows.Forms.Label
    Friend WithEvents Partnumber_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Settings_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Sample_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents NoWeight_lbl As System.Windows.Forms.Label
    Friend WithEvents Timer1 As Timer
End Class
