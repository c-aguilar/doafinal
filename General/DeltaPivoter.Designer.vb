<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeltaPivoter
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeltaPivoter))
        Me.Report_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Refresh_btn = New System.Windows.Forms.ToolStripButton()
        Me.Title_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Fields_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Rows_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Columns_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Values_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Aggregates_cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Sum_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Count_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Average_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Maximum_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Minimum_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.First_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Last_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exists_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TotalColumns_chk = New System.Windows.Forms.CheckBox()
        Me.TotalRow_chk = New System.Windows.Forms.CheckBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMain.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.Aggregates_cms.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Report_dgv
        '
        Me.Report_dgv.AllowColumnHiding = True
        Me.Report_dgv.AllowUserToAddRows = False
        Me.Report_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Report_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Report_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Report_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Report_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Report_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Report_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Report_dgv.DefaultRowFilter = Nothing
        Me.Report_dgv.EnableHeadersVisualStyles = False
        Me.Report_dgv.Location = New System.Drawing.Point(163, 32)
        Me.Report_dgv.Name = "Report_dgv"
        Me.Report_dgv.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Report_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Report_dgv.ShowRowNumber = True
        Me.Report_dgv.Size = New System.Drawing.Size(872, 685)
        Me.Report_dgv.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Renglones"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(5, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Columnas"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(5, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Valores"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExport, Me.PrintToolStripButton, Me.toolStripSeparator, Me.CopyToolStripButton, Me.FindToolStripButton, Me.toolStripSeparator1, Me.Refresh_btn, Me.Title_lbl})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1039, 29)
        Me.ToolStripMain.TabIndex = 13
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(23, 26)
        Me.btnExport.Text = "&Exportar"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.PrintToolStripButton.Text = "&Imprimir"
        Me.PrintToolStripButton.ToolTipText = "Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.CopyToolStripButton.Text = "&Copiar"
        Me.CopyToolStripButton.ToolTipText = "Copiar"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(23, 26)
        Me.FindToolStripButton.Text = "&Buscar"
        Me.FindToolStripButton.ToolTipText = "Buscar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'Refresh_btn
        '
        Me.Refresh_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Size = New System.Drawing.Size(23, 26)
        Me.Refresh_btn.Text = "Actualizar"
        '
        'Title_lbl
        '
        Me.Title_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_lbl.ForeColor = System.Drawing.Color.SteelBlue
        Me.Title_lbl.Name = "Title_lbl"
        Me.Title_lbl.Size = New System.Drawing.Size(45, 26)
        Me.Title_lbl.Text = "Title"
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.ssStatus.Location = New System.Drawing.Point(0, 720)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(1039, 22)
        Me.ssStatus.TabIndex = 14
        Me.ssStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(34, 17)
        Me.lblStatus.Text = "         "
        '
        'Fields_flp
        '
        Me.Fields_flp.AllowDrop = True
        Me.Fields_flp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fields_flp.AutoScroll = True
        Me.Fields_flp.BackColor = System.Drawing.Color.Gainsboro
        Me.Fields_flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Fields_flp.Location = New System.Drawing.Point(5, 27)
        Me.Fields_flp.Name = "Fields_flp"
        Me.Fields_flp.Size = New System.Drawing.Size(150, 211)
        Me.Fields_flp.TabIndex = 19
        '
        'Rows_flp
        '
        Me.Rows_flp.AllowDrop = True
        Me.Rows_flp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rows_flp.BackColor = System.Drawing.Color.Gainsboro
        Me.Rows_flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Rows_flp.Location = New System.Drawing.Point(5, 25)
        Me.Rows_flp.Name = "Rows_flp"
        Me.Rows_flp.Size = New System.Drawing.Size(150, 113)
        Me.Rows_flp.TabIndex = 20
        '
        'Columns_flp
        '
        Me.Columns_flp.AllowDrop = True
        Me.Columns_flp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Columns_flp.BackColor = System.Drawing.Color.Gainsboro
        Me.Columns_flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Columns_flp.Location = New System.Drawing.Point(5, 25)
        Me.Columns_flp.Name = "Columns_flp"
        Me.Columns_flp.Size = New System.Drawing.Size(150, 120)
        Me.Columns_flp.TabIndex = 21
        '
        'Values_flp
        '
        Me.Values_flp.AllowDrop = True
        Me.Values_flp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Values_flp.BackColor = System.Drawing.Color.Gainsboro
        Me.Values_flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Values_flp.Location = New System.Drawing.Point(5, 25)
        Me.Values_flp.Name = "Values_flp"
        Me.Values_flp.Size = New System.Drawing.Size(150, 80)
        Me.Values_flp.TabIndex = 21
        '
        'Aggregates_cms
        '
        Me.Aggregates_cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sum_cmsi, Me.Count_cmsi, Me.Average_cmsi, Me.Maximum_cmsi, Me.Minimum_cmsi, Me.First_cmsi, Me.Last_cmsi, Me.Exists_cmsi})
        Me.Aggregates_cms.Name = "Aggregates_cms"
        Me.Aggregates_cms.ShowItemToolTips = False
        Me.Aggregates_cms.Size = New System.Drawing.Size(127, 180)
        '
        'Sum_cmsi
        '
        Me.Sum_cmsi.Image = CType(resources.GetObject("Sum_cmsi.Image"), System.Drawing.Image)
        Me.Sum_cmsi.Name = "Sum_cmsi"
        Me.Sum_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Sum_cmsi.Text = "Suma"
        '
        'Count_cmsi
        '
        Me.Count_cmsi.Image = CType(resources.GetObject("Count_cmsi.Image"), System.Drawing.Image)
        Me.Count_cmsi.Name = "Count_cmsi"
        Me.Count_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Count_cmsi.Text = "Conteo"
        '
        'Average_cmsi
        '
        Me.Average_cmsi.Image = CType(resources.GetObject("Average_cmsi.Image"), System.Drawing.Image)
        Me.Average_cmsi.Name = "Average_cmsi"
        Me.Average_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Average_cmsi.Text = "Promedio"
        '
        'Maximum_cmsi
        '
        Me.Maximum_cmsi.Image = CType(resources.GetObject("Maximum_cmsi.Image"), System.Drawing.Image)
        Me.Maximum_cmsi.Name = "Maximum_cmsi"
        Me.Maximum_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Maximum_cmsi.Text = "Máximo"
        '
        'Minimum_cmsi
        '
        Me.Minimum_cmsi.Image = CType(resources.GetObject("Minimum_cmsi.Image"), System.Drawing.Image)
        Me.Minimum_cmsi.Name = "Minimum_cmsi"
        Me.Minimum_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Minimum_cmsi.Text = "Mínimo"
        '
        'First_cmsi
        '
        Me.First_cmsi.Image = CType(resources.GetObject("First_cmsi.Image"), System.Drawing.Image)
        Me.First_cmsi.Name = "First_cmsi"
        Me.First_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.First_cmsi.Text = "Primero"
        '
        'Last_cmsi
        '
        Me.Last_cmsi.Image = CType(resources.GetObject("Last_cmsi.Image"), System.Drawing.Image)
        Me.Last_cmsi.Name = "Last_cmsi"
        Me.Last_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Last_cmsi.Text = "Ultimo"
        '
        'Exists_cmsi
        '
        Me.Exists_cmsi.Image = CType(resources.GetObject("Exists_cmsi.Image"), System.Drawing.Image)
        Me.Exists_cmsi.Name = "Exists_cmsi"
        Me.Exists_cmsi.Size = New System.Drawing.Size(126, 22)
        Me.Exists_cmsi.Text = "Existe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Campos"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 23
        Me.PictureBox4.TabStop = False
        '
        'TotalColumns_chk
        '
        Me.TotalColumns_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalColumns_chk.AutoSize = True
        Me.TotalColumns_chk.Location = New System.Drawing.Point(7, 684)
        Me.TotalColumns_chk.Name = "TotalColumns_chk"
        Me.TotalColumns_chk.Size = New System.Drawing.Size(112, 17)
        Me.TotalColumns_chk.TabIndex = 24
        Me.TotalColumns_chk.Text = "Total por Columna"
        Me.TotalColumns_chk.UseVisualStyleBackColor = True
        '
        'TotalRow_chk
        '
        Me.TotalRow_chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalRow_chk.AutoSize = True
        Me.TotalRow_chk.Location = New System.Drawing.Point(7, 702)
        Me.TotalRow_chk.Name = "TotalRow_chk"
        Me.TotalRow_chk.Size = New System.Drawing.Size(111, 17)
        Me.TotalRow_chk.TabIndex = 25
        Me.TotalRow_chk.Text = "Total por Renglon"
        Me.TotalRow_chk.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(161, 650)
        Me.SplitContainer1.SplitterDistance = 386
        Me.SplitContainer1.TabIndex = 26
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Fields_flp)
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBox4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Rows_flp)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Size = New System.Drawing.Size(161, 386)
        Me.SplitContainer2.SplitterDistance = 241
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Columns_flp)
        Me.SplitContainer3.Panel1.Controls.Add(Me.PictureBox2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.PictureBox3)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Values_flp)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Size = New System.Drawing.Size(161, 260)
        Me.SplitContainer3.SplitterDistance = 148
        Me.SplitContainer3.TabIndex = 0
        '
        'DeltaPivoter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 742)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TotalRow_chk)
        Me.Controls.Add(Me.TotalColumns_chk)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.Report_dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DeltaPivoter"
        Me.Text = "Delta Pivoter"
        CType(Me.Report_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.Aggregates_cms.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Report_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Title_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Refresh_btn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Fields_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Rows_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Columns_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Values_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Aggregates_cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Sum_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Count_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Average_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Minimum_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Maximum_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents First_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Last_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Exists_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TotalColumns_chk As System.Windows.Forms.CheckBox
    Friend WithEvents TotalRow_chk As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
End Class
