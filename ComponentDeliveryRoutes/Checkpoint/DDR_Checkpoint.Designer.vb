<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDR_Checkpoint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDR_Checkpoint))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Warehouse_lbl = New System.Windows.Forms.Label()
        Me.Picture_pb = New System.Windows.Forms.PictureBox()
        Me.Missing_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Carrousel_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Carts_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Operator_cbo = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.OperatorAvgTime_lbl = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.OperatorTotalTime_lbl = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.OperatorContainersCount_lbl = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Loops_flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.Crono_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Bines_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ShiftContainers_lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ShiftCrtitical_lbl = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Carts_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.ShiftCarts_lbl = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.AvgTime_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.ShiftAvgCart_lbl = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.AvgBinesTime_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.ShiftAvgContainer_lbl = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Critical_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Option_txt = New CAguilar.WaterMarkTextBox()
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.Bines_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.Carts_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.AvgTime_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.AvgBinesTime_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Critical_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Warehouse_lbl
        '
        Me.Warehouse_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Warehouse_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Warehouse_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Warehouse_lbl.ForeColor = System.Drawing.Color.White
        Me.Warehouse_lbl.Location = New System.Drawing.Point(781, 16)
        Me.Warehouse_lbl.Name = "Warehouse_lbl"
        Me.Warehouse_lbl.Size = New System.Drawing.Size(232, 23)
        Me.Warehouse_lbl.TabIndex = 53
        Me.Warehouse_lbl.Text = "Warehouse"
        Me.Warehouse_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Picture_pb
        '
        Me.Picture_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_pb.Image = CType(resources.GetObject("Picture_pb.Image"), System.Drawing.Image)
        Me.Picture_pb.Location = New System.Drawing.Point(4, 5)
        Me.Picture_pb.Name = "Picture_pb"
        Me.Picture_pb.Size = New System.Drawing.Size(158, 213)
        Me.Picture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_pb.TabIndex = 0
        Me.Picture_pb.TabStop = False
        '
        'Missing_timer
        '
        Me.Missing_timer.Enabled = True
        Me.Missing_timer.Interval = 610000
        '
        'Carrousel_timer
        '
        Me.Carrousel_timer.Interval = 30000
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(379, 29)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Checkpoint de Rutas Desacopladas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Carts_flp
        '
        Me.Carts_flp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Carts_flp.AutoScroll = True
        Me.Carts_flp.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Carts_flp.Location = New System.Drawing.Point(1, 81)
        Me.Carts_flp.Name = "Carts_flp"
        Me.Carts_flp.Size = New System.Drawing.Size(287, 687)
        Me.Carts_flp.TabIndex = 55
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Operator_cbo)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Loops_flp)
        Me.Panel1.Controls.Add(Me.Picture_pb)
        Me.Panel1.Location = New System.Drawing.Point(292, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 474)
        Me.Panel1.TabIndex = 1
        '
        'Operator_cbo
        '
        Me.Operator_cbo.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Operator_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Operator_cbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Operator_cbo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Operator_cbo.ForeColor = System.Drawing.Color.White
        Me.Operator_cbo.FormattingEnabled = True
        Me.Operator_cbo.Location = New System.Drawing.Point(166, 2)
        Me.Operator_cbo.Name = "Operator_cbo"
        Me.Operator_cbo.Size = New System.Drawing.Size(383, 37)
        Me.Operator_cbo.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel3.Controls.Add(Me.OperatorAvgTime_lbl)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(4, 390)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(158, 77)
        Me.Panel3.TabIndex = 59
        '
        'OperatorAvgTime_lbl
        '
        Me.OperatorAvgTime_lbl.Font = New System.Drawing.Font("DS-Digital", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperatorAvgTime_lbl.ForeColor = System.Drawing.Color.LightYellow
        Me.OperatorAvgTime_lbl.Location = New System.Drawing.Point(54, 25)
        Me.OperatorAvgTime_lbl.Name = "OperatorAvgTime_lbl"
        Me.OperatorAvgTime_lbl.Size = New System.Drawing.Size(103, 34)
        Me.OperatorAvgTime_lbl.TabIndex = 0
        Me.OperatorAvgTime_lbl.Text = "01:50"
        Me.OperatorAvgTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(91, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "mm:ss"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(63, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label6.Size = New System.Drawing.Size(148, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "TIEMPO PROM. X CARRO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel2.Controls.Add(Me.OperatorTotalTime_lbl)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(4, 307)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(158, 77)
        Me.Panel2.TabIndex = 58
        '
        'OperatorTotalTime_lbl
        '
        Me.OperatorTotalTime_lbl.Font = New System.Drawing.Font("DS-Digital", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperatorTotalTime_lbl.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.OperatorTotalTime_lbl.Location = New System.Drawing.Point(53, 25)
        Me.OperatorTotalTime_lbl.Name = "OperatorTotalTime_lbl"
        Me.OperatorTotalTime_lbl.Size = New System.Drawing.Size(103, 37)
        Me.OperatorTotalTime_lbl.TabIndex = 0
        Me.OperatorTotalTime_lbl.Text = "08:00"
        Me.OperatorTotalTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(91, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label9.Size = New System.Drawing.Size(52, 14)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "HH:mm"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label4.Size = New System.Drawing.Size(94, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "TIEMPO TOTAL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel7.Controls.Add(Me.OperatorContainersCount_lbl)
        Me.Panel7.Controls.Add(Me.PictureBox3)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(4, 224)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(158, 77)
        Me.Panel7.TabIndex = 57
        '
        'OperatorContainersCount_lbl
        '
        Me.OperatorContainersCount_lbl.Font = New System.Drawing.Font("DS-Digital", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperatorContainersCount_lbl.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.OperatorContainersCount_lbl.Location = New System.Drawing.Point(53, 25)
        Me.OperatorContainersCount_lbl.Name = "OperatorContainersCount_lbl"
        Me.OperatorContainersCount_lbl.Size = New System.Drawing.Size(103, 38)
        Me.OperatorContainersCount_lbl.TabIndex = 0
        Me.OperatorContainersCount_lbl.Text = "100"
        Me.OperatorContainersCount_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(63, 48)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(3, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label21.Size = New System.Drawing.Size(83, 15)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "TOTAL BINES"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Loops_flp
        '
        Me.Loops_flp.AutoScroll = True
        Me.Loops_flp.BackColor = System.Drawing.Color.Transparent
        Me.Loops_flp.Location = New System.Drawing.Point(165, 42)
        Me.Loops_flp.Name = "Loops_flp"
        Me.Loops_flp.Size = New System.Drawing.Size(384, 427)
        Me.Loops_flp.TabIndex = 56
        '
        'Crono_timer
        '
        Me.Crono_timer.Interval = 1000
        '
        'Panel4
        '
        Me.Panel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Bines_chart)
        Me.Panel4.Controls.Add(Me.PictureBox4)
        Me.Panel4.Controls.Add(Me.ShiftContainers_lbl)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(851, 177)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(170, 90)
        Me.Panel4.TabIndex = 57
        '
        'Bines_chart
        '
        Me.Bines_chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bines_chart.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Bines_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Bines_chart.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.Area3DStyle.Inclination = 5
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.PointDepth = 40
        ChartArea1.Area3DStyle.PointGapDepth = 40
        ChartArea1.Area3DStyle.Rotation = 2
        ChartArea1.Area3DStyle.WallWidth = 0
        ChartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisX.LabelAutoFitMinFontSize = 5
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(81, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.AxisX2.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisX2.LabelAutoFitMinFontSize = 5
        ChartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisY.LabelAutoFitMinFontSize = 5
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY.LineWidth = 0
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.AxisY2.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisY2.LabelAutoFitMinFontSize = 5
        ChartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY2.LineWidth = 0
        ChartArea1.AxisY2.MajorGrid.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Bines_chart.ChartAreas.Add(ChartArea1)
        Me.Bines_chart.Location = New System.Drawing.Point(196, 7)
        Me.Bines_chart.Name = "Bines_chart"
        Me.Bines_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Series1.ChartArea = "ChartArea1"
        Series1.Color = System.Drawing.Color.LightSteelBlue
        Series1.CustomProperties = "MinPixelPointWidth=8, PointWidth=0, LabelStyle=Top, MaxPixelPointWidth=8"
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.IsXValueIndexed = True
        Series1.LabelForeColor = System.Drawing.Color.White
        Series1.Name = "Minutos"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Color = System.Drawing.Color.LimeGreen
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.IsXValueIndexed = True
        Series2.LabelForeColor = System.Drawing.Color.White
        Series2.Name = "Promedio"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.Bines_chart.Series.Add(Series1)
        Me.Bines_chart.Series.Add(Series2)
        Me.Bines_chart.Size = New System.Drawing.Size(0, 76)
        Me.Bines_chart.TabIndex = 63
        Me.Bines_chart.Text = " "
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(10, 25)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'ShiftContainers_lbl
        '
        Me.ShiftContainers_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ShiftContainers_lbl.Font = New System.Drawing.Font("DS-Digital", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShiftContainers_lbl.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.ShiftContainers_lbl.Location = New System.Drawing.Point(57, 30)
        Me.ShiftContainers_lbl.Name = "ShiftContainers_lbl"
        Me.ShiftContainers_lbl.Size = New System.Drawing.Size(110, 45)
        Me.ShiftContainers_lbl.TabIndex = 0
        Me.ShiftContainers_lbl.Text = "2000"
        Me.ShiftContainers_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label5.Size = New System.Drawing.Size(122, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "BINES ESCANEADOS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel5.Controls.Add(Me.PictureBox5)
        Me.Panel5.Controls.Add(Me.ShiftCrtitical_lbl)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(851, 465)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(170, 90)
        Me.Panel5.TabIndex = 58
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(12, 25)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 0
        Me.PictureBox5.TabStop = False
        '
        'ShiftCrtitical_lbl
        '
        Me.ShiftCrtitical_lbl.Font = New System.Drawing.Font("DS-Digital", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShiftCrtitical_lbl.ForeColor = System.Drawing.Color.LightCoral
        Me.ShiftCrtitical_lbl.Location = New System.Drawing.Point(57, 30)
        Me.ShiftCrtitical_lbl.Name = "ShiftCrtitical_lbl"
        Me.ShiftCrtitical_lbl.Size = New System.Drawing.Size(110, 45)
        Me.ShiftCrtitical_lbl.TabIndex = 0
        Me.ShiftCrtitical_lbl.Text = "100"
        Me.ShiftCrtitical_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label8.Size = New System.Drawing.Size(132, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "CRITICOS PENDIENTES"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Carts_chart)
        Me.Panel6.Controls.Add(Me.PictureBox6)
        Me.Panel6.Controls.Add(Me.ShiftCarts_lbl)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(851, 81)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(170, 90)
        Me.Panel6.TabIndex = 59
        '
        'Carts_chart
        '
        Me.Carts_chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Carts_chart.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Carts_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Carts_chart.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.Area3DStyle.Inclination = 5
        ChartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea2.Area3DStyle.PointDepth = 40
        ChartArea2.Area3DStyle.PointGapDepth = 40
        ChartArea2.Area3DStyle.Rotation = 2
        ChartArea2.Area3DStyle.WallWidth = 0
        ChartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea2.AxisX.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(81, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.AxisX2.IsLabelAutoFit = False
        ChartArea2.AxisX2.LabelAutoFitMaxFontSize = 7
        ChartArea2.AxisX2.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea2.AxisY.LabelAutoFitMaxFontSize = 7
        ChartArea2.AxisY.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.AxisY.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisY.LineWidth = 0
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.MajorTickMark.Enabled = False
        ChartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.AxisY2.LabelAutoFitMaxFontSize = 7
        ChartArea2.AxisY2.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.AxisY2.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisY2.LineWidth = 0
        ChartArea2.AxisY2.MajorGrid.Enabled = False
        ChartArea2.AxisY2.MajorTickMark.Enabled = False
        ChartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.Carts_chart.ChartAreas.Add(ChartArea2)
        Me.Carts_chart.Location = New System.Drawing.Point(196, 7)
        Me.Carts_chart.Name = "Carts_chart"
        Me.Carts_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Series3.ChartArea = "ChartArea1"
        Series3.Color = System.Drawing.Color.LightSteelBlue
        Series3.CustomProperties = "MinPixelPointWidth=8, PointWidth=0, LabelStyle=Top, MaxPixelPointWidth=8"
        Series3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.IsValueShownAsLabel = True
        Series3.IsXValueIndexed = True
        Series3.LabelForeColor = System.Drawing.Color.White
        Series3.Name = "Carro"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Carts_chart.Series.Add(Series3)
        Me.Carts_chart.Size = New System.Drawing.Size(0, 76)
        Me.Carts_chart.TabIndex = 64
        Me.Carts_chart.Text = " "
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(10, 25)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'ShiftCarts_lbl
        '
        Me.ShiftCarts_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ShiftCarts_lbl.Font = New System.Drawing.Font("DS-Digital", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShiftCarts_lbl.ForeColor = System.Drawing.Color.LightGreen
        Me.ShiftCarts_lbl.Location = New System.Drawing.Point(57, 30)
        Me.ShiftCarts_lbl.Name = "ShiftCarts_lbl"
        Me.ShiftCarts_lbl.Size = New System.Drawing.Size(110, 45)
        Me.ShiftCarts_lbl.TabIndex = 0
        Me.ShiftCarts_lbl.Text = "100"
        Me.ShiftCarts_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label10.Size = New System.Drawing.Size(115, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "CARROS SURTIDOS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.AvgTime_chart)
        Me.Panel8.Controls.Add(Me.PictureBox7)
        Me.Panel8.Controls.Add(Me.ShiftAvgCart_lbl)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(851, 273)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(170, 90)
        Me.Panel8.TabIndex = 59
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(87, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label15.Size = New System.Drawing.Size(48, 14)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "mm:ss"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AvgTime_chart
        '
        Me.AvgTime_chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AvgTime_chart.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.AvgTime_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AvgTime_chart.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea3.Area3DStyle.Inclination = 5
        ChartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea3.Area3DStyle.PointDepth = 40
        ChartArea3.Area3DStyle.PointGapDepth = 40
        ChartArea3.Area3DStyle.Rotation = 2
        ChartArea3.Area3DStyle.WallWidth = 0
        ChartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea3.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea3.AxisX.LabelAutoFitMinFontSize = 5
        ChartArea3.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(81, Byte), Integer))
        ChartArea3.AxisX.MajorGrid.Enabled = False
        ChartArea3.AxisX.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.AxisX2.IsLabelAutoFit = False
        ChartArea3.AxisX2.LabelAutoFitMaxFontSize = 7
        ChartArea3.AxisX2.LabelAutoFitMinFontSize = 5
        ChartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea3.AxisY.LabelAutoFitMaxFontSize = 7
        ChartArea3.AxisY.LabelAutoFitMinFontSize = 5
        ChartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.AxisY.LineColor = System.Drawing.Color.DarkGray
        ChartArea3.AxisY.LineWidth = 0
        ChartArea3.AxisY.MajorGrid.Enabled = False
        ChartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea3.AxisY.MajorTickMark.Enabled = False
        ChartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea3.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270
        ChartArea3.AxisY.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.AxisY2.LabelAutoFitMaxFontSize = 7
        ChartArea3.AxisY2.LabelAutoFitMinFontSize = 5
        ChartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.AxisY2.LineColor = System.Drawing.Color.DarkGray
        ChartArea3.AxisY2.LineWidth = 0
        ChartArea3.AxisY2.MajorGrid.Enabled = False
        ChartArea3.AxisY2.MajorTickMark.Enabled = False
        ChartArea3.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea3.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea3.BackColor = System.Drawing.Color.Transparent
        ChartArea3.Name = "ChartArea1"
        Me.AvgTime_chart.ChartAreas.Add(ChartArea3)
        Me.AvgTime_chart.Location = New System.Drawing.Point(196, 7)
        Me.AvgTime_chart.Name = "AvgTime_chart"
        Me.AvgTime_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Series4.ChartArea = "ChartArea1"
        Series4.Color = System.Drawing.Color.LightSteelBlue
        Series4.CustomProperties = "MinPixelPointWidth=8, PointWidth=0, LabelStyle=Top, MaxPixelPointWidth=8"
        Series4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series4.IsValueShownAsLabel = True
        Series4.IsXValueIndexed = True
        Series4.LabelForeColor = System.Drawing.Color.White
        Series4.Name = "Minutos"
        Series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Color = System.Drawing.Color.LimeGreen
        Series5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series5.IsXValueIndexed = True
        Series5.LabelForeColor = System.Drawing.Color.White
        Series5.Name = "Promedio"
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.AvgTime_chart.Series.Add(Series4)
        Me.AvgTime_chart.Series.Add(Series5)
        Me.AvgTime_chart.Size = New System.Drawing.Size(0, 76)
        Me.AvgTime_chart.TabIndex = 62
        Me.AvgTime_chart.Text = "Chart2"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(10, 25)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox7.TabIndex = 0
        Me.PictureBox7.TabStop = False
        '
        'ShiftAvgCart_lbl
        '
        Me.ShiftAvgCart_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ShiftAvgCart_lbl.Font = New System.Drawing.Font("DS-Digital", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShiftAvgCart_lbl.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.ShiftAvgCart_lbl.Location = New System.Drawing.Point(57, 30)
        Me.ShiftAvgCart_lbl.Name = "ShiftAvgCart_lbl"
        Me.ShiftAvgCart_lbl.Size = New System.Drawing.Size(110, 45)
        Me.ShiftAvgCart_lbl.TabIndex = 0
        Me.ShiftAvgCart_lbl.Text = "10:00"
        Me.ShiftAvgCart_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label12.Size = New System.Drawing.Size(171, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "TIEMPO PROMEDIO X CARRO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label16)
        Me.Panel9.Controls.Add(Me.AvgBinesTime_chart)
        Me.Panel9.Controls.Add(Me.PictureBox8)
        Me.Panel9.Controls.Add(Me.ShiftAvgContainer_lbl)
        Me.Panel9.Controls.Add(Me.Label14)
        Me.Panel9.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel9.Location = New System.Drawing.Point(851, 369)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(170, 90)
        Me.Panel9.TabIndex = 60
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(87, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label16.Size = New System.Drawing.Size(48, 14)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "mm:ss"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AvgBinesTime_chart
        '
        Me.AvgBinesTime_chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AvgBinesTime_chart.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.AvgBinesTime_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AvgBinesTime_chart.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea4.Area3DStyle.Inclination = 5
        ChartArea4.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea4.Area3DStyle.PointDepth = 40
        ChartArea4.Area3DStyle.PointGapDepth = 40
        ChartArea4.Area3DStyle.Rotation = 2
        ChartArea4.Area3DStyle.WallWidth = 0
        ChartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea4.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea4.AxisX.LabelAutoFitMinFontSize = 5
        ChartArea4.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(81, Byte), Integer))
        ChartArea4.AxisX.MajorGrid.Enabled = False
        ChartArea4.AxisX.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.AxisX2.IsLabelAutoFit = False
        ChartArea4.AxisX2.LabelAutoFitMaxFontSize = 7
        ChartArea4.AxisX2.LabelAutoFitMinFontSize = 5
        ChartArea4.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea4.AxisY.LabelAutoFitMaxFontSize = 7
        ChartArea4.AxisY.LabelAutoFitMinFontSize = 5
        ChartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.AxisY.LineColor = System.Drawing.Color.DarkGray
        ChartArea4.AxisY.LineWidth = 0
        ChartArea4.AxisY.MajorGrid.Enabled = False
        ChartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea4.AxisY.MajorTickMark.Enabled = False
        ChartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea4.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270
        ChartArea4.AxisY.TitleFont = New System.Drawing.Font("Franklin Gothic Medium Cond", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.AxisY2.LabelAutoFitMaxFontSize = 7
        ChartArea4.AxisY2.LabelAutoFitMinFontSize = 5
        ChartArea4.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.AxisY2.LineColor = System.Drawing.Color.DarkGray
        ChartArea4.AxisY2.LineWidth = 0
        ChartArea4.AxisY2.MajorGrid.Enabled = False
        ChartArea4.AxisY2.MajorTickMark.Enabled = False
        ChartArea4.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray
        ChartArea4.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(158, Byte), Integer))
        ChartArea4.BackColor = System.Drawing.Color.Transparent
        ChartArea4.Name = "ChartArea1"
        Me.AvgBinesTime_chart.ChartAreas.Add(ChartArea4)
        Me.AvgBinesTime_chart.Location = New System.Drawing.Point(196, 7)
        Me.AvgBinesTime_chart.Name = "AvgBinesTime_chart"
        Me.AvgBinesTime_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Series6.ChartArea = "ChartArea1"
        Series6.Color = System.Drawing.Color.LightSteelBlue
        Series6.CustomProperties = "MinPixelPointWidth=8, PointWidth=0, LabelStyle=Top, MaxPixelPointWidth=8"
        Series6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series6.IsValueShownAsLabel = True
        Series6.IsXValueIndexed = True
        Series6.LabelForeColor = System.Drawing.Color.White
        Series6.Name = "Minutos"
        Series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series7.Color = System.Drawing.Color.LimeGreen
        Series7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series7.IsXValueIndexed = True
        Series7.LabelForeColor = System.Drawing.Color.White
        Series7.Name = "Promedio"
        Series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.AvgBinesTime_chart.Series.Add(Series6)
        Me.AvgBinesTime_chart.Series.Add(Series7)
        Me.AvgBinesTime_chart.Size = New System.Drawing.Size(0, 76)
        Me.AvgBinesTime_chart.TabIndex = 63
        Me.AvgBinesTime_chart.Text = "Chart2"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(10, 25)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox8.TabIndex = 0
        Me.PictureBox8.TabStop = False
        '
        'ShiftAvgContainer_lbl
        '
        Me.ShiftAvgContainer_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ShiftAvgContainer_lbl.Font = New System.Drawing.Font("DS-Digital", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShiftAvgContainer_lbl.ForeColor = System.Drawing.Color.LightYellow
        Me.ShiftAvgContainer_lbl.Location = New System.Drawing.Point(57, 29)
        Me.ShiftAvgContainer_lbl.Name = "ShiftAvgContainer_lbl"
        Me.ShiftAvgContainer_lbl.Size = New System.Drawing.Size(110, 45)
        Me.ShiftAvgContainer_lbl.TabIndex = 0
        Me.ShiftAvgContainer_lbl.Text = "10:00"
        Me.ShiftAvgContainer_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(3, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label14.Size = New System.Drawing.Size(152, 15)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "TIEMPO PROMEDIO X BIN"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label2.Size = New System.Drawing.Size(185, 19)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "MONITOREO DE CARROS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(288, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label3.Size = New System.Drawing.Size(223, 19)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "MONITOREO DE OPERADORES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(847, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label7.Size = New System.Drawing.Size(179, 19)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "MONITOREO DE TURNO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(292, 558)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.Label13.Size = New System.Drawing.Size(190, 19)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "MONITOREO DE CRITICOS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Critical_dgv
        '
        Me.Critical_dgv.AllowColumnHiding = True
        Me.Critical_dgv.AllowUserToAddRows = False
        Me.Critical_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Critical_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Critical_dgv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Critical_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Critical_dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Critical_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Critical_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Critical_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Critical_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Critical_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.Critical_dgv.DefaultRowFilter = Nothing
        Me.Critical_dgv.EnableHeadersVisualStyles = False
        Me.Critical_dgv.Location = New System.Drawing.Point(292, 580)
        Me.Critical_dgv.Name = "Critical_dgv"
        Me.Critical_dgv.ReadOnly = True
        Me.Critical_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Critical_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Critical_dgv.ShowRowNumber = True
        Me.Critical_dgv.Size = New System.Drawing.Size(729, 188)
        Me.Critical_dgv.TabIndex = 64
        '
        'Option_txt
        '
        Me.Option_txt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Option_txt.BackColor = System.Drawing.Color.White
        Me.Option_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Option_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option_txt.ForeColor = System.Drawing.Color.Black
        Me.Option_txt.Location = New System.Drawing.Point(386, 10)
        Me.Option_txt.Name = "Option_txt"
        Me.Option_txt.Size = New System.Drawing.Size(252, 35)
        Me.Option_txt.TabIndex = 24
        Me.Option_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Option_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Option_txt.WaterMarkText = "Escanea una opcion..."
        '
        'DDR_Checkpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 780)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Critical_dgv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Carts_flp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Option_txt)
        Me.Controls.Add(Me.Warehouse_lbl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DDR_Checkpoint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Component Delivery Routes"
        Me.TransparencyKey = System.Drawing.Color.Lime
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Picture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Bines_chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.Carts_chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.AvgTime_chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.AvgBinesTime_chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Critical_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Picture_pb As System.Windows.Forms.PictureBox
    Friend WithEvents Warehouse_lbl As System.Windows.Forms.Label
    Friend WithEvents Option_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Carts_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Loops_flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents OperatorAvgTime_lbl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OperatorTotalTime_lbl As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents OperatorContainersCount_lbl As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ShiftContainers_lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents ShiftCrtitical_lbl As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents ShiftCarts_lbl As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents ShiftAvgCart_lbl As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents ShiftAvgContainer_lbl As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents AvgTime_chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents AvgBinesTime_chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Bines_chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Carts_chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Missing_timer As System.Windows.Forms.Timer
    Private WithEvents Crono_timer As System.Windows.Forms.Timer
    Private WithEvents Carrousel_timer As System.Windows.Forms.Timer
    Friend WithEvents Critical_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Operator_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
