<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rec_Labeling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rec_Labeling))
        Me.News_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Quality_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Pending_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Print_btn = New System.Windows.Forms.Button()
        Me.Report_btn = New System.Windows.Forms.Button()
        Me.Clean_btn = New System.Windows.Forms.Button()
        Me.Color_pnl = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Critical_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Main_tmr = New System.Windows.Forms.Timer(Me.components)
        Me.CriticalPartnumbers_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.News_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quality_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pending_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Color_pnl.SuspendLayout()
        CType(Me.Critical_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CriticalPartnumbers_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'News_dgv
        '
        Me.News_dgv.AllowColumnHiding = True
        Me.News_dgv.AllowUserToAddRows = False
        Me.News_dgv.AllowUserToDeleteRows = False
        Me.News_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.News_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.News_dgv.Location = New System.Drawing.Point(12, 48)
        Me.News_dgv.Name = "News_dgv"
        Me.News_dgv.ReadOnly = True
        Me.News_dgv.ShowRowNumber = True
        Me.News_dgv.Size = New System.Drawing.Size(629, 290)
        Me.News_dgv.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1217, 25)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Etiquetado de Materia Prima"
        '
        'Quality_dgv
        '
        Me.Quality_dgv.AllowColumnHiding = True
        Me.Quality_dgv.AllowUserToAddRows = False
        Me.Quality_dgv.AllowUserToDeleteRows = False
        Me.Quality_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Quality_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Quality_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Quality_dgv.Location = New System.Drawing.Point(12, 360)
        Me.Quality_dgv.Name = "Quality_dgv"
        Me.Quality_dgv.ReadOnly = True
        Me.Quality_dgv.ShowRowNumber = True
        Me.Quality_dgv.Size = New System.Drawing.Size(430, 241)
        Me.Quality_dgv.TabIndex = 74
        '
        'Pending_dgv
        '
        Me.Pending_dgv.AllowColumnHiding = True
        Me.Pending_dgv.AllowUserToAddRows = False
        Me.Pending_dgv.AllowUserToDeleteRows = False
        Me.Pending_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pending_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Pending_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Pending_dgv.Location = New System.Drawing.Point(919, 360)
        Me.Pending_dgv.Name = "Pending_dgv"
        Me.Pending_dgv.ReadOnly = True
        Me.Pending_dgv.RowHeadersVisible = False
        Me.Pending_dgv.ShowRowNumber = True
        Me.Pending_dgv.Size = New System.Drawing.Size(150, 241)
        Me.Pending_dgv.TabIndex = 75
        '
        'Print_btn
        '
        Me.Print_btn.Image = CType(resources.GetObject("Print_btn.Image"), System.Drawing.Image)
        Me.Print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Print_btn.Location = New System.Drawing.Point(1075, 360)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(130, 40)
        Me.Print_btn.TabIndex = 76
        Me.Print_btn.Text = "Imprimir"
        Me.Print_btn.UseVisualStyleBackColor = True
        '
        'Report_btn
        '
        Me.Report_btn.Image = CType(resources.GetObject("Report_btn.Image"), System.Drawing.Image)
        Me.Report_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Report_btn.Location = New System.Drawing.Point(1075, 406)
        Me.Report_btn.Name = "Report_btn"
        Me.Report_btn.Size = New System.Drawing.Size(130, 40)
        Me.Report_btn.TabIndex = 77
        Me.Report_btn.Text = "Reporte"
        Me.Report_btn.UseVisualStyleBackColor = True
        '
        'Clean_btn
        '
        Me.Clean_btn.Image = CType(resources.GetObject("Clean_btn.Image"), System.Drawing.Image)
        Me.Clean_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Clean_btn.Location = New System.Drawing.Point(1075, 452)
        Me.Clean_btn.Name = "Clean_btn"
        Me.Clean_btn.Size = New System.Drawing.Size(130, 40)
        Me.Clean_btn.TabIndex = 78
        Me.Clean_btn.Text = "Limpiar"
        Me.Clean_btn.UseVisualStyleBackColor = True
        '
        'Color_pnl
        '
        Me.Color_pnl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Color_pnl.BackColor = System.Drawing.Color.Teal
        Me.Color_pnl.Controls.Add(Me.Label2)
        Me.Color_pnl.Location = New System.Drawing.Point(1075, 498)
        Me.Color_pnl.Name = "Color_pnl"
        Me.Color_pnl.Size = New System.Drawing.Size(131, 103)
        Me.Color_pnl.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 21)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Color Mensual"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(916, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 18)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Escaner pendientes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 340)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 18)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Material con alerta de calidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(451, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 18)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Material critico"
        '
        'Critical_dgv
        '
        Me.Critical_dgv.AllowColumnHiding = True
        Me.Critical_dgv.AllowUserToAddRows = False
        Me.Critical_dgv.AllowUserToDeleteRows = False
        Me.Critical_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Critical_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Critical_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Critical_dgv.Location = New System.Drawing.Point(448, 360)
        Me.Critical_dgv.Name = "Critical_dgv"
        Me.Critical_dgv.ReadOnly = True
        Me.Critical_dgv.ShowRowNumber = True
        Me.Critical_dgv.Size = New System.Drawing.Size(430, 241)
        Me.Critical_dgv.TabIndex = 82
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(12, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 18)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Escaneo actual"
        '
        'Main_tmr
        '
        Me.Main_tmr.Enabled = True
        Me.Main_tmr.Interval = 120000
        '
        'CriticalPartnumbers_dgv
        '
        Me.CriticalPartnumbers_dgv.AllowColumnHiding = True
        Me.CriticalPartnumbers_dgv.AllowUserToAddRows = False
        Me.CriticalPartnumbers_dgv.AllowUserToDeleteRows = False
        Me.CriticalPartnumbers_dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CriticalPartnumbers_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.CriticalPartnumbers_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CriticalPartnumbers_dgv.Location = New System.Drawing.Point(647, 48)
        Me.CriticalPartnumbers_dgv.Name = "CriticalPartnumbers_dgv"
        Me.CriticalPartnumbers_dgv.ReadOnly = True
        Me.CriticalPartnumbers_dgv.ShowRowNumber = True
        Me.CriticalPartnumbers_dgv.Size = New System.Drawing.Size(559, 289)
        Me.CriticalPartnumbers_dgv.TabIndex = 85
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(647, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 18)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Nuevo material critico"
        '
        'Rec_Labeling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 613)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CriticalPartnumbers_dgv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Critical_dgv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Color_pnl)
        Me.Controls.Add(Me.Clean_btn)
        Me.Controls.Add(Me.Report_btn)
        Me.Controls.Add(Me.Print_btn)
        Me.Controls.Add(Me.Pending_dgv)
        Me.Controls.Add(Me.Quality_dgv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.News_dgv)
        Me.Name = "Rec_Labeling"
        Me.ShowIcon = False
        Me.Text = "Receiving"
        CType(Me.News_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quality_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pending_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Color_pnl.ResumeLayout(False)
        Me.Color_pnl.PerformLayout()
        CType(Me.Critical_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CriticalPartnumbers_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents News_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Quality_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Pending_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Print_btn As System.Windows.Forms.Button
    Friend WithEvents Report_btn As System.Windows.Forms.Button
    Friend WithEvents Clean_btn As System.Windows.Forms.Button
    Friend WithEvents Color_pnl As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Critical_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Main_tmr As System.Windows.Forms.Timer
    Friend WithEvents CriticalPartnumbers_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
