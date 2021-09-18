<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_Containerization
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDR_Containerization))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C14_nud = New System.Windows.Forms.NumericUpDown()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.Settings_btn = New System.Windows.Forms.ToolStripButton()
        Me.Sample_btn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.CurrentWeight_lbl = New System.Windows.Forms.Label()
        Me.Icon_pb = New System.Windows.Forms.PictureBox()
        Me.UoM_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.C12_nud = New System.Windows.Forms.NumericUpDown()
        Me.C16s_nud = New System.Windows.Forms.NumericUpDown()
        Me.C8s_nud = New System.Windows.Forms.NumericUpDown()
        Me.C4s_nud = New System.Windows.Forms.NumericUpDown()
        Me.C2s_nud = New System.Windows.Forms.NumericUpDown()
        Me.CJT_nud = New System.Windows.Forms.NumericUpDown()
        Me.Weight_lbl = New System.Windows.Forms.Label()
        Me.Scale_chk = New System.Windows.Forms.CheckBox()
        Me.Partnumber_txt = New System.Windows.Forms.TextBox()
        Me.Description_lbl = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.StdPack_txt = New System.Windows.Forms.TextBox()
        Me.Send14_btn = New System.Windows.Forms.Button()
        Me.SendJT_btn = New System.Windows.Forms.Button()
        Me.Send12_btn = New System.Windows.Forms.Button()
        Me.Send16_btn = New System.Windows.Forms.Button()
        Me.Send8_btn = New System.Windows.Forms.Button()
        Me.Send4_btn = New System.Windows.Forms.Button()
        Me.Send2_btn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Qty14_lbl = New System.Windows.Forms.Label()
        Me.Qty12_lbl = New System.Windows.Forms.Label()
        Me.Qty16_lbl = New System.Windows.Forms.Label()
        Me.Qty8_lbl = New System.Windows.Forms.Label()
        Me.Qty4_lbl = New System.Windows.Forms.Label()
        Me.Qty2_lbl = New System.Windows.Forms.Label()
        Me.QtyJT_lbl = New System.Windows.Forms.Label()
        CType(Me.C14_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.Icon_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C12_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C16s_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C8s_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C4s_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C2s_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CJT_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(273, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 24)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "No. de Parte:"
        '
        'C14_nud
        '
        Me.C14_nud.BackColor = System.Drawing.Color.Ivory
        Me.C14_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C14_nud.Location = New System.Drawing.Point(23, 335)
        Me.C14_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C14_nud.Name = "C14_nud"
        Me.C14_nud.Size = New System.Drawing.Size(100, 31)
        Me.C14_nud.TabIndex = 147
        Me.C14_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Settings_btn, Me.Sample_btn, Me.toolStripSeparator, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(784, 29)
        Me.ToolStripMain.TabIndex = 148
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
        Me.Sample_btn.Text = "Corregir Peso"
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
        Me.Title_lbl.Size = New System.Drawing.Size(139, 26)
        Me.Title_lbl.Text = "Contenerización"
        '
        'CurrentWeight_lbl
        '
        Me.CurrentWeight_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentWeight_lbl.Location = New System.Drawing.Point(12, 19)
        Me.CurrentWeight_lbl.Name = "CurrentWeight_lbl"
        Me.CurrentWeight_lbl.Size = New System.Drawing.Size(110, 29)
        Me.CurrentWeight_lbl.TabIndex = 150
        Me.CurrentWeight_lbl.Text = "26.000"
        Me.CurrentWeight_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Icon_pb
        '
        Me.Icon_pb.Image = Global.Delta_ERP.My.Resources.Resources.tick_32
        Me.Icon_pb.Location = New System.Drawing.Point(185, 17)
        Me.Icon_pb.Name = "Icon_pb"
        Me.Icon_pb.Size = New System.Drawing.Size(33, 34)
        Me.Icon_pb.TabIndex = 151
        Me.Icon_pb.TabStop = False
        '
        'UoM_lbl
        '
        Me.UoM_lbl.AutoSize = True
        Me.UoM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UoM_lbl.Location = New System.Drawing.Point(128, 24)
        Me.UoM_lbl.Name = "UoM_lbl"
        Me.UoM_lbl.Size = New System.Drawing.Size(51, 24)
        Me.UoM_lbl.TabIndex = 152
        Me.UoM_lbl.Text = "g/PC"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CurrentWeight_lbl)
        Me.GroupBox1.Controls.Add(Me.Icon_pb)
        Me.GroupBox1.Controls.Add(Me.UoM_lbl)
        Me.GroupBox1.Location = New System.Drawing.Point(271, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 63)
        Me.GroupBox1.TabIndex = 153
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Peso Unitario"
        '
        'C12_nud
        '
        Me.C12_nud.BackColor = System.Drawing.Color.Ivory
        Me.C12_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C12_nud.Location = New System.Drawing.Point(129, 335)
        Me.C12_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C12_nud.Name = "C12_nud"
        Me.C12_nud.Size = New System.Drawing.Size(100, 31)
        Me.C12_nud.TabIndex = 162
        Me.C12_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'C16s_nud
        '
        Me.C16s_nud.BackColor = System.Drawing.Color.Ivory
        Me.C16s_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C16s_nud.Location = New System.Drawing.Point(235, 335)
        Me.C16s_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C16s_nud.Name = "C16s_nud"
        Me.C16s_nud.Size = New System.Drawing.Size(100, 31)
        Me.C16s_nud.TabIndex = 163
        Me.C16s_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'C8s_nud
        '
        Me.C8s_nud.BackColor = System.Drawing.Color.Ivory
        Me.C8s_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C8s_nud.Location = New System.Drawing.Point(341, 335)
        Me.C8s_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C8s_nud.Name = "C8s_nud"
        Me.C8s_nud.Size = New System.Drawing.Size(100, 31)
        Me.C8s_nud.TabIndex = 164
        Me.C8s_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'C4s_nud
        '
        Me.C4s_nud.BackColor = System.Drawing.Color.Ivory
        Me.C4s_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C4s_nud.Location = New System.Drawing.Point(447, 335)
        Me.C4s_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C4s_nud.Name = "C4s_nud"
        Me.C4s_nud.Size = New System.Drawing.Size(100, 31)
        Me.C4s_nud.TabIndex = 165
        Me.C4s_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'C2s_nud
        '
        Me.C2s_nud.BackColor = System.Drawing.Color.Ivory
        Me.C2s_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C2s_nud.Location = New System.Drawing.Point(555, 335)
        Me.C2s_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.C2s_nud.Name = "C2s_nud"
        Me.C2s_nud.Size = New System.Drawing.Size(100, 31)
        Me.C2s_nud.TabIndex = 166
        Me.C2s_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CJT_nud
        '
        Me.CJT_nud.BackColor = System.Drawing.Color.Ivory
        Me.CJT_nud.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CJT_nud.Location = New System.Drawing.Point(661, 335)
        Me.CJT_nud.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.CJT_nud.Name = "CJT_nud"
        Me.CJT_nud.Size = New System.Drawing.Size(100, 31)
        Me.CJT_nud.TabIndex = 167
        Me.CJT_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CJT_nud.ThousandsSeparator = True
        '
        'Weight_lbl
        '
        Me.Weight_lbl.BackColor = System.Drawing.Color.LimeGreen
        Me.Weight_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Weight_lbl.Font = New System.Drawing.Font("DS-Digital", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Weight_lbl.ForeColor = System.Drawing.Color.White
        Me.Weight_lbl.Location = New System.Drawing.Point(311, 177)
        Me.Weight_lbl.Name = "Weight_lbl"
        Me.Weight_lbl.Size = New System.Drawing.Size(162, 43)
        Me.Weight_lbl.TabIndex = 170
        Me.Weight_lbl.Text = "0.0"
        Me.Weight_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Scale_chk
        '
        Me.Scale_chk.Image = CType(resources.GetObject("Scale_chk.Image"), System.Drawing.Image)
        Me.Scale_chk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Scale_chk.Location = New System.Drawing.Point(479, 181)
        Me.Scale_chk.Name = "Scale_chk"
        Me.Scale_chk.Size = New System.Drawing.Size(111, 39)
        Me.Scale_chk.TabIndex = 169
        Me.Scale_chk.Text = "Bascula"
        Me.Scale_chk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Scale_chk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Scale_chk.UseVisualStyleBackColor = True
        '
        'Partnumber_txt
        '
        Me.Partnumber_txt.BackColor = System.Drawing.Color.Ivory
        Me.Partnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partnumber_txt.Location = New System.Drawing.Point(393, 31)
        Me.Partnumber_txt.Name = "Partnumber_txt"
        Me.Partnumber_txt.Size = New System.Drawing.Size(118, 29)
        Me.Partnumber_txt.TabIndex = 171
        Me.Partnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Description_lbl
        '
        Me.Description_lbl.AutoSize = True
        Me.Description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_lbl.Location = New System.Drawing.Point(204, 70)
        Me.Description_lbl.Name = "Description_lbl"
        Me.Description_lbl.Size = New System.Drawing.Size(377, 18)
        Me.Description_lbl.TabIndex = 172
        Me.Description_lbl.Text = "CABL SGX 19.000 BLK   XLPE REGULAR  ANNE"
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(327, 462)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(130, 40)
        Me.Save_btn.TabIndex = 173
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(23, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 22)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "1/4"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label3.Location = New System.Drawing.Point(129, 312)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "1/2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Location = New System.Drawing.Point(235, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 22)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "16s"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label5.Location = New System.Drawing.Point(341, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 22)
        Me.Label5.TabIndex = 187
        Me.Label5.Text = "8s"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label6.Location = New System.Drawing.Point(447, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 22)
        Me.Label6.TabIndex = 188
        Me.Label6.Text = "4s"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(555, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 22)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "2s"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label8.Location = New System.Drawing.Point(661, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 22)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "JT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StdPack_txt
        '
        Me.StdPack_txt.BackColor = System.Drawing.Color.Ivory
        Me.StdPack_txt.Font = New System.Drawing.Font("DS-Digital", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdPack_txt.Location = New System.Drawing.Point(341, 399)
        Me.StdPack_txt.Name = "StdPack_txt"
        Me.StdPack_txt.ReadOnly = True
        Me.StdPack_txt.Size = New System.Drawing.Size(100, 31)
        Me.StdPack_txt.TabIndex = 192
        Me.StdPack_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Send14_btn
        '
        Me.Send14_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send14_btn.Enabled = False
        Me.Send14_btn.FlatAppearance.BorderSize = 0
        Me.Send14_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send14_btn.Image = CType(resources.GetObject("Send14_btn.Image"), System.Drawing.Image)
        Me.Send14_btn.Location = New System.Drawing.Point(54, 271)
        Me.Send14_btn.Name = "Send14_btn"
        Me.Send14_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send14_btn.TabIndex = 198
        Me.Send14_btn.UseVisualStyleBackColor = True
        '
        'SendJT_btn
        '
        Me.SendJT_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SendJT_btn.Enabled = False
        Me.SendJT_btn.FlatAppearance.BorderSize = 0
        Me.SendJT_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SendJT_btn.Image = CType(resources.GetObject("SendJT_btn.Image"), System.Drawing.Image)
        Me.SendJT_btn.Location = New System.Drawing.Point(690, 271)
        Me.SendJT_btn.Name = "SendJT_btn"
        Me.SendJT_btn.Size = New System.Drawing.Size(35, 35)
        Me.SendJT_btn.TabIndex = 199
        Me.SendJT_btn.UseVisualStyleBackColor = True
        '
        'Send12_btn
        '
        Me.Send12_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send12_btn.Enabled = False
        Me.Send12_btn.FlatAppearance.BorderSize = 0
        Me.Send12_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send12_btn.Image = CType(resources.GetObject("Send12_btn.Image"), System.Drawing.Image)
        Me.Send12_btn.Location = New System.Drawing.Point(160, 271)
        Me.Send12_btn.Name = "Send12_btn"
        Me.Send12_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send12_btn.TabIndex = 200
        Me.Send12_btn.UseVisualStyleBackColor = True
        '
        'Send16_btn
        '
        Me.Send16_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send16_btn.Enabled = False
        Me.Send16_btn.FlatAppearance.BorderSize = 0
        Me.Send16_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send16_btn.Image = CType(resources.GetObject("Send16_btn.Image"), System.Drawing.Image)
        Me.Send16_btn.Location = New System.Drawing.Point(266, 271)
        Me.Send16_btn.Name = "Send16_btn"
        Me.Send16_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send16_btn.TabIndex = 201
        Me.Send16_btn.UseVisualStyleBackColor = True
        '
        'Send8_btn
        '
        Me.Send8_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send8_btn.Enabled = False
        Me.Send8_btn.FlatAppearance.BorderSize = 0
        Me.Send8_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send8_btn.Image = CType(resources.GetObject("Send8_btn.Image"), System.Drawing.Image)
        Me.Send8_btn.Location = New System.Drawing.Point(372, 271)
        Me.Send8_btn.Name = "Send8_btn"
        Me.Send8_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send8_btn.TabIndex = 202
        Me.Send8_btn.UseVisualStyleBackColor = True
        '
        'Send4_btn
        '
        Me.Send4_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send4_btn.Enabled = False
        Me.Send4_btn.FlatAppearance.BorderSize = 0
        Me.Send4_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send4_btn.Image = CType(resources.GetObject("Send4_btn.Image"), System.Drawing.Image)
        Me.Send4_btn.Location = New System.Drawing.Point(478, 271)
        Me.Send4_btn.Name = "Send4_btn"
        Me.Send4_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send4_btn.TabIndex = 203
        Me.Send4_btn.UseVisualStyleBackColor = True
        '
        'Send2_btn
        '
        Me.Send2_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Send2_btn.Enabled = False
        Me.Send2_btn.FlatAppearance.BorderSize = 0
        Me.Send2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send2_btn.Image = CType(resources.GetObject("Send2_btn.Image"), System.Drawing.Image)
        Me.Send2_btn.Location = New System.Drawing.Point(584, 271)
        Me.Send2_btn.Name = "Send2_btn"
        Me.Send2_btn.Size = New System.Drawing.Size(35, 35)
        Me.Send2_btn.TabIndex = 204
        Me.Send2_btn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label10.Location = New System.Drawing.Point(341, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 22)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Std Pack"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty14_lbl
        '
        Me.Qty14_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty14_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty14_lbl.Location = New System.Drawing.Point(23, 239)
        Me.Qty14_lbl.Name = "Qty14_lbl"
        Me.Qty14_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty14_lbl.TabIndex = 153
        Me.Qty14_lbl.Text = "0"
        Me.Qty14_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty12_lbl
        '
        Me.Qty12_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty12_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty12_lbl.Location = New System.Drawing.Point(129, 239)
        Me.Qty12_lbl.Name = "Qty12_lbl"
        Me.Qty12_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty12_lbl.TabIndex = 206
        Me.Qty12_lbl.Text = "0"
        Me.Qty12_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty16_lbl
        '
        Me.Qty16_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty16_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty16_lbl.Location = New System.Drawing.Point(235, 239)
        Me.Qty16_lbl.Name = "Qty16_lbl"
        Me.Qty16_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty16_lbl.TabIndex = 207
        Me.Qty16_lbl.Text = "0"
        Me.Qty16_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty8_lbl
        '
        Me.Qty8_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty8_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty8_lbl.Location = New System.Drawing.Point(341, 239)
        Me.Qty8_lbl.Name = "Qty8_lbl"
        Me.Qty8_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty8_lbl.TabIndex = 208
        Me.Qty8_lbl.Text = "0"
        Me.Qty8_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty4_lbl
        '
        Me.Qty4_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty4_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty4_lbl.Location = New System.Drawing.Point(447, 239)
        Me.Qty4_lbl.Name = "Qty4_lbl"
        Me.Qty4_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty4_lbl.TabIndex = 209
        Me.Qty4_lbl.Text = "0"
        Me.Qty4_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Qty2_lbl
        '
        Me.Qty2_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty2_lbl.ForeColor = System.Drawing.Color.Silver
        Me.Qty2_lbl.Location = New System.Drawing.Point(555, 239)
        Me.Qty2_lbl.Name = "Qty2_lbl"
        Me.Qty2_lbl.Size = New System.Drawing.Size(100, 29)
        Me.Qty2_lbl.TabIndex = 210
        Me.Qty2_lbl.Text = "0"
        Me.Qty2_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QtyJT_lbl
        '
        Me.QtyJT_lbl.Font = New System.Drawing.Font("DS-Digital", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QtyJT_lbl.ForeColor = System.Drawing.Color.Silver
        Me.QtyJT_lbl.Location = New System.Drawing.Point(661, 239)
        Me.QtyJT_lbl.Name = "QtyJT_lbl"
        Me.QtyJT_lbl.Size = New System.Drawing.Size(100, 29)
        Me.QtyJT_lbl.TabIndex = 211
        Me.QtyJT_lbl.Text = "0"
        Me.QtyJT_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DDR_Containerization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 534)
        Me.Controls.Add(Me.QtyJT_lbl)
        Me.Controls.Add(Me.Qty2_lbl)
        Me.Controls.Add(Me.Qty4_lbl)
        Me.Controls.Add(Me.Qty8_lbl)
        Me.Controls.Add(Me.Qty16_lbl)
        Me.Controls.Add(Me.Qty12_lbl)
        Me.Controls.Add(Me.Qty14_lbl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Send2_btn)
        Me.Controls.Add(Me.Send4_btn)
        Me.Controls.Add(Me.Send8_btn)
        Me.Controls.Add(Me.Send16_btn)
        Me.Controls.Add(Me.Send12_btn)
        Me.Controls.Add(Me.SendJT_btn)
        Me.Controls.Add(Me.Send14_btn)
        Me.Controls.Add(Me.StdPack_txt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Description_lbl)
        Me.Controls.Add(Me.Partnumber_txt)
        Me.Controls.Add(Me.Weight_lbl)
        Me.Controls.Add(Me.Scale_chk)
        Me.Controls.Add(Me.CJT_nud)
        Me.Controls.Add(Me.C2s_nud)
        Me.Controls.Add(Me.C4s_nud)
        Me.Controls.Add(Me.C8s_nud)
        Me.Controls.Add(Me.C16s_nud)
        Me.Controls.Add(Me.C12_nud)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.C14_nud)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DDR_Containerization"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        CType(Me.C14_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.Icon_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.C12_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C16s_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C8s_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C4s_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C2s_nud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CJT_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C14_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents Settings_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CurrentWeight_lbl As System.Windows.Forms.Label
    Friend WithEvents Icon_pb As System.Windows.Forms.PictureBox
    Friend WithEvents UoM_lbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C12_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents C16s_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents C8s_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents C4s_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents C2s_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents CJT_nud As System.Windows.Forms.NumericUpDown
    Friend WithEvents Weight_lbl As System.Windows.Forms.Label
    Friend WithEvents Scale_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Partnumber_txt As System.Windows.Forms.TextBox
    Friend WithEvents Description_lbl As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Sample_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents StdPack_txt As System.Windows.Forms.TextBox
    Friend WithEvents Send14_btn As System.Windows.Forms.Button
    Friend WithEvents SendJT_btn As System.Windows.Forms.Button
    Friend WithEvents Send12_btn As System.Windows.Forms.Button
    Friend WithEvents Send16_btn As System.Windows.Forms.Button
    Friend WithEvents Send8_btn As System.Windows.Forms.Button
    Friend WithEvents Send4_btn As System.Windows.Forms.Button
    Friend WithEvents Send2_btn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Qty14_lbl As System.Windows.Forms.Label
    Friend WithEvents Qty12_lbl As System.Windows.Forms.Label
    Friend WithEvents Qty16_lbl As System.Windows.Forms.Label
    Friend WithEvents Qty8_lbl As System.Windows.Forms.Label
    Friend WithEvents Qty4_lbl As System.Windows.Forms.Label
    Friend WithEvents Qty2_lbl As System.Windows.Forms.Label
    Friend WithEvents QtyJT_lbl As System.Windows.Forms.Label
End Class
