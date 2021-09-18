<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CR_ComponentPlanSimulation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CR_ComponentPlanSimulation))
        Me.PartnumberForecast_dgv = New CAguilar.DataGridViewWithFilters()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Orders_cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddOrder_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjustOrder_cmsi = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PartnumberForecast_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Orders_cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'PartnumberForecast_dgv
        '
        Me.PartnumberForecast_dgv.AllowColumnHiding = True
        Me.PartnumberForecast_dgv.AllowUserToAddRows = False
        Me.PartnumberForecast_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.PartnumberForecast_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.PartnumberForecast_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PartnumberForecast_dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.PartnumberForecast_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PartnumberForecast_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.PartnumberForecast_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartnumberForecast_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.PartnumberForecast_dgv.ColumnHeadersHeight = 30
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PartnumberForecast_dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.PartnumberForecast_dgv.DefaultRowFilter = Nothing
        Me.PartnumberForecast_dgv.EnableHeadersVisualStyles = False
        Me.PartnumberForecast_dgv.Location = New System.Drawing.Point(2, 28)
        Me.PartnumberForecast_dgv.Name = "PartnumberForecast_dgv"
        Me.PartnumberForecast_dgv.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartnumberForecast_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.PartnumberForecast_dgv.RowHeadersVisible = False
        Me.PartnumberForecast_dgv.ShowRowNumber = True
        Me.PartnumberForecast_dgv.Size = New System.Drawing.Size(982, 254)
        Me.PartnumberForecast_dgv.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 38
        Me.lblTitle.Text = "Simulación"
        '
        'Orders_cms
        '
        Me.Orders_cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddOrder_cmsi, Me.AdjustOrder_cmsi})
        Me.Orders_cms.Name = "Orders_cms"
        Me.Orders_cms.Size = New System.Drawing.Size(158, 48)
        '
        'AddOrder_cmsi
        '
        Me.AddOrder_cmsi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddOrder_cmsi.Image = CType(resources.GetObject("AddOrder_cmsi.Image"), System.Drawing.Image)
        Me.AddOrder_cmsi.Name = "AddOrder_cmsi"
        Me.AddOrder_cmsi.Size = New System.Drawing.Size(157, 22)
        Me.AddOrder_cmsi.Text = "Agregar Orden"
        Me.AddOrder_cmsi.ToolTipText = "Agregar orden en SAP"
        '
        'AdjustOrder_cmsi
        '
        Me.AdjustOrder_cmsi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdjustOrder_cmsi.Image = CType(resources.GetObject("AdjustOrder_cmsi.Image"), System.Drawing.Image)
        Me.AdjustOrder_cmsi.Name = "AdjustOrder_cmsi"
        Me.AdjustOrder_cmsi.Size = New System.Drawing.Size(157, 22)
        Me.AdjustOrder_cmsi.Text = "Ajustar Orden"
        Me.AdjustOrder_cmsi.ToolTipText = "Cambiar la cantidad de la orden en SAP"
        '
        'CR_ComponentPlanSimulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 282)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PartnumberForecast_dgv)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CR_ComponentPlanSimulation"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Component Readiness"
        CType(Me.PartnumberForecast_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Orders_cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PartnumberForecast_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Orders_cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddOrder_cmsi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustOrder_cmsi As System.Windows.Forms.ToolStripMenuItem
End Class
