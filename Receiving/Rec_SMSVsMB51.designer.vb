<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_SMSVsMB51
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_SMSVsMB51))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SAPTo_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SAPFrom_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DeltaTo_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DeltaFrom_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Result_dgv = New CAguilar.DataGridViewWithFilters()
        Me.details_btn = New CAguilar.DataGridViewImprovedButtonColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblUOM = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLabeled = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPartnumber = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Labeled_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Paid_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Run_btn = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Export_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Items_btn = New System.Windows.Forms.Button()
        Me.tcMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Labeled_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Paid_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "No. de Parte:"
        '
        'SAPTo_dtp
        '
        Me.SAPTo_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.SAPTo_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAPTo_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.SAPTo_dtp.Location = New System.Drawing.Point(481, 58)
        Me.SAPTo_dtp.Name = "SAPTo_dtp"
        Me.SAPTo_dtp.Size = New System.Drawing.Size(115, 20)
        Me.SAPTo_dtp.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(439, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "hasta:"
        '
        'SAPFrom_dtp
        '
        Me.SAPFrom_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.SAPFrom_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAPFrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.SAPFrom_dtp.Location = New System.Drawing.Point(318, 58)
        Me.SAPFrom_dtp.Name = "SAPFrom_dtp"
        Me.SAPFrom_dtp.Size = New System.Drawing.Size(115, 20)
        Me.SAPFrom_dtp.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SAP desde:"
        '
        'DeltaTo_dtp
        '
        Me.DeltaTo_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.DeltaTo_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaTo_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DeltaTo_dtp.Location = New System.Drawing.Point(481, 32)
        Me.DeltaTo_dtp.Name = "DeltaTo_dtp"
        Me.DeltaTo_dtp.Size = New System.Drawing.Size(115, 20)
        Me.DeltaTo_dtp.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(439, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "hasta:"
        '
        'DeltaFrom_dtp
        '
        Me.DeltaFrom_dtp.CustomFormat = "dd-MM-yy HH:mm"
        Me.DeltaFrom_dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeltaFrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DeltaFrom_dtp.Location = New System.Drawing.Point(318, 32)
        Me.DeltaFrom_dtp.Name = "DeltaFrom_dtp"
        Me.DeltaFrom_dtp.Size = New System.Drawing.Size(115, 20)
        Me.DeltaFrom_dtp.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(245, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Delta desde:"
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Controls.Add(Me.TabPage1)
        Me.tcMain.Controls.Add(Me.TabPage2)
        Me.tcMain.Location = New System.Drawing.Point(7, 84)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(921, 472)
        Me.tcMain.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Result_dgv)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(913, 446)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Comparativo"
        '
        'Result_dgv
        '
        Me.Result_dgv.AllowColumnHiding = True
        Me.Result_dgv.AllowUserToAddRows = False
        Me.Result_dgv.AllowUserToDeleteRows = False
        Me.Result_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Result_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.details_btn})
        Me.Result_dgv.Location = New System.Drawing.Point(6, 6)
        Me.Result_dgv.Name = "Result_dgv"
        Me.Result_dgv.ReadOnly = True
        Me.Result_dgv.ShowRowNumber = True
        Me.Result_dgv.Size = New System.Drawing.Size(901, 434)
        Me.Result_dgv.TabIndex = 6
        '
        'details_btn
        '
        Me.details_btn.DefaultImage = Nothing
        Me.details_btn.DefaultText = ""
        Me.details_btn.HeaderText = "Detalles"
        Me.details_btn.Name = "details_btn"
        Me.details_btn.ReadOnly = True
        Me.details_btn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.details_btn.Width = 50
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.lblUOM)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.lblLabeled)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.lblPaid)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.lblPartnumber)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Labeled_dgv)
        Me.TabPage2.Controls.Add(Me.Paid_dgv)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(913, 446)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        '
        'lblUOM
        '
        Me.lblUOM.AutoSize = True
        Me.lblUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOM.Location = New System.Drawing.Point(238, 17)
        Me.lblUOM.Name = "lblUOM"
        Me.lblUOM.Size = New System.Drawing.Size(79, 13)
        Me.lblUOM.TabIndex = 16
        Me.lblUOM.Text = "                  "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(188, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Unidad:"
        '
        'lblLabeled
        '
        Me.lblLabeled.AutoSize = True
        Me.lblLabeled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabeled.Location = New System.Drawing.Point(534, 46)
        Me.lblLabeled.Name = "lblLabeled"
        Me.lblLabeled.Size = New System.Drawing.Size(71, 13)
        Me.lblLabeled.TabIndex = 14
        Me.lblLabeled.Text = "                "
        Me.lblLabeled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(467, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Etiquetado:"
        '
        'lblPaid
        '
        Me.lblPaid.AutoSize = True
        Me.lblPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaid.Location = New System.Drawing.Point(62, 44)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(59, 13)
        Me.lblPaid.TabIndex = 12
        Me.lblPaid.Text = "             "
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Pagado:"
        '
        'lblPartnumber
        '
        Me.lblPartnumber.AutoSize = True
        Me.lblPartnumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartnumber.Location = New System.Drawing.Point(85, 17)
        Me.lblPartnumber.Name = "lblPartnumber"
        Me.lblPartnumber.Size = New System.Drawing.Size(71, 13)
        Me.lblPartnumber.TabIndex = 10
        Me.lblPartnumber.Text = "                "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "No. de Parte:"
        '
        'Labeled_dgv
        '
        Me.Labeled_dgv.AllowColumnHiding = True
        Me.Labeled_dgv.AllowUserToAddRows = False
        Me.Labeled_dgv.AllowUserToDeleteRows = False
        Me.Labeled_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Labeled_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Labeled_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Labeled_dgv.Location = New System.Drawing.Point(470, 65)
        Me.Labeled_dgv.Name = "Labeled_dgv"
        Me.Labeled_dgv.ReadOnly = True
        Me.Labeled_dgv.ShowRowNumber = True
        Me.Labeled_dgv.Size = New System.Drawing.Size(437, 375)
        Me.Labeled_dgv.TabIndex = 8
        '
        'Paid_dgv
        '
        Me.Paid_dgv.AllowColumnHiding = True
        Me.Paid_dgv.AllowUserToAddRows = False
        Me.Paid_dgv.AllowUserToDeleteRows = False
        Me.Paid_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Paid_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Paid_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Paid_dgv.Location = New System.Drawing.Point(6, 65)
        Me.Paid_dgv.Name = "Paid_dgv"
        Me.Paid_dgv.ReadOnly = True
        Me.Paid_dgv.ShowRowNumber = True
        Me.Paid_dgv.Size = New System.Drawing.Size(458, 375)
        Me.Paid_dgv.TabIndex = 7
        '
        'Run_btn
        '
        Me.Run_btn.Image = CType(resources.GetObject("Run_btn.Image"), System.Drawing.Image)
        Me.Run_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Run_btn.Location = New System.Drawing.Point(602, 30)
        Me.Run_btn.Name = "Run_btn"
        Me.Run_btn.Size = New System.Drawing.Size(100, 25)
        Me.Run_btn.TabIndex = 22
        Me.Run_btn.Text = "Ejecutar"
        Me.Run_btn.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export_btn, Me.toolStripSeparator, Me.ToolStripLabel1})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(934, 29)
        Me.ToolStripMain.TabIndex = 39
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'Export_btn
        '
        Me.Export_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Export_btn.Image = CType(resources.GetObject("Export_btn.Image"), System.Drawing.Image)
        Me.Export_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Export_btn.Name = "Export_btn"
        Me.Export_btn.Size = New System.Drawing.Size(23, 26)
        Me.Export_btn.Text = "&Exportar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(183, 26)
        Me.ToolStripLabel1.Text = "Etiquetado Vs Pagado"
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.LightYellow
        Me.Partnumber_txt.Location = New System.Drawing.Point(82, 32)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(117, 20)
        Me.Partnumber_txt.TabIndex = 61
        Me.Partnumber_txt.Text = "*"
        '
        'Items_btn
        '
        Me.Items_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Items_btn.Image = CType(resources.GetObject("Items_btn.Image"), System.Drawing.Image)
        Me.Items_btn.Location = New System.Drawing.Point(202, 31)
        Me.Items_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.Items_btn.Name = "Items_btn"
        Me.Items_btn.Size = New System.Drawing.Size(23, 23)
        Me.Items_btn.TabIndex = 62
        Me.Items_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Items_btn.UseVisualStyleBackColor = False
        '
        'Rec_SMSVsMB51
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 561)
        Me.Controls.Add(Me.Items_btn)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Run_btn)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DeltaFrom_dtp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DeltaTo_dtp)
        Me.Controls.Add(Me.SAPTo_dtp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SAPFrom_dtp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Rec_SMSVsMB51"
        Me.Text = "Receiving"
        Me.tcMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Result_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.Labeled_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Paid_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SAPTo_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SAPFrom_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DeltaTo_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DeltaFrom_dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Result_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Paid_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Labeled_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents lblLabeled As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblPaid As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPartnumber As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblUOM As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Run_btn As System.Windows.Forms.Button
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Export_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Items_btn As System.Windows.Forms.Button
    Friend WithEvents details_btn As CAguilar.DataGridViewImprovedButtonColumn
End Class
