<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sch_ChartHeadcountWorkloadSchedule
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dgvProductionPlan = New System.Windows.Forms.DataGridView()
        Me.dgvShifts = New System.Windows.Forms.DataGridView()
        Me.lblTotalHoursOnDay = New System.Windows.Forms.Label()
        Me.lblScheduledHours = New System.Windows.Forms.Label()
        Me.lblCapacityUsage = New System.Windows.Forms.Label()
        Me.chartAnalysis = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblColumn = New System.Windows.Forms.Label()
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartAnalysis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProductionPlan
        '
        Me.dgvProductionPlan.AllowUserToAddRows = False
        Me.dgvProductionPlan.AllowUserToDeleteRows = False
        Me.dgvProductionPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProductionPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductionPlan.Location = New System.Drawing.Point(3, 3)
        Me.dgvProductionPlan.Name = "dgvProductionPlan"
        Me.dgvProductionPlan.ReadOnly = True
        Me.dgvProductionPlan.RowHeadersVisible = False
        Me.dgvProductionPlan.Size = New System.Drawing.Size(549, 404)
        Me.dgvProductionPlan.TabIndex = 0
        '
        'dgvShifts
        '
        Me.dgvShifts.AllowUserToAddRows = False
        Me.dgvShifts.AllowUserToDeleteRows = False
        Me.dgvShifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShifts.Location = New System.Drawing.Point(558, 3)
        Me.dgvShifts.Name = "dgvShifts"
        Me.dgvShifts.ReadOnly = True
        Me.dgvShifts.RowHeadersVisible = False
        Me.dgvShifts.Size = New System.Drawing.Size(306, 127)
        Me.dgvShifts.TabIndex = 1
        '
        'lblTotalHoursOnDay
        '
        Me.lblTotalHoursOnDay.AutoSize = True
        Me.lblTotalHoursOnDay.Location = New System.Drawing.Point(558, 133)
        Me.lblTotalHoursOnDay.Name = "lblTotalHoursOnDay"
        Me.lblTotalHoursOnDay.Size = New System.Drawing.Size(117, 13)
        Me.lblTotalHoursOnDay.TabIndex = 2
        Me.lblTotalHoursOnDay.Text = "Available hours on day:"
        '
        'lblScheduledHours
        '
        Me.lblScheduledHours.AutoSize = True
        Me.lblScheduledHours.Location = New System.Drawing.Point(558, 152)
        Me.lblScheduledHours.Name = "lblScheduledHours"
        Me.lblScheduledHours.Size = New System.Drawing.Size(115, 13)
        Me.lblScheduledHours.TabIndex = 3
        Me.lblScheduledHours.Text = "Total scheduled hours:"
        '
        'lblCapacityUsage
        '
        Me.lblCapacityUsage.AutoSize = True
        Me.lblCapacityUsage.Location = New System.Drawing.Point(558, 171)
        Me.lblCapacityUsage.Name = "lblCapacityUsage"
        Me.lblCapacityUsage.Size = New System.Drawing.Size(41, 13)
        Me.lblCapacityUsage.TabIndex = 4
        Me.lblCapacityUsage.Text = "Usage:"
        '
        'chartAnalysis
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartAnalysis.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartAnalysis.Legends.Add(Legend1)
        Me.chartAnalysis.Location = New System.Drawing.Point(558, 187)
        Me.chartAnalysis.Name = "chartAnalysis"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.SmartLabelStyle.Enabled = False
        Series1.XValueMember = "Material"
        Series1.YValueMembers = "Man-seconds"
        Me.chartAnalysis.Series.Add(Series1)
        Me.chartAnalysis.Size = New System.Drawing.Size(306, 220)
        Me.chartAnalysis.TabIndex = 5
        Me.chartAnalysis.Text = "Chart1"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.lblColumn)
        Me.pnlMain.Controls.Add(Me.dgvProductionPlan)
        Me.pnlMain.Controls.Add(Me.lblTotalHoursOnDay)
        Me.pnlMain.Controls.Add(Me.chartAnalysis)
        Me.pnlMain.Controls.Add(Me.lblCapacityUsage)
        Me.pnlMain.Controls.Add(Me.dgvShifts)
        Me.pnlMain.Controls.Add(Me.lblScheduledHours)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(869, 412)
        Me.pnlMain.TabIndex = 6
        '
        'lblColumn
        '
        Me.lblColumn.ForeColor = System.Drawing.Color.DimGray
        Me.lblColumn.Location = New System.Drawing.Point(693, 394)
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(171, 13)
        Me.lblColumn.TabIndex = 6
        Me.lblColumn.Text = "Usage:"
        Me.lblColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChartHeadcountWorkloadSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(869, 412)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChartHeadcountWorkloadSchedule"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Capacity usage"
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShifts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartAnalysis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProductionPlan As System.Windows.Forms.DataGridView
    Friend WithEvents dgvShifts As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalHoursOnDay As System.Windows.Forms.Label
    Friend WithEvents lblScheduledHours As System.Windows.Forms.Label
    Friend WithEvents lblCapacityUsage As System.Windows.Forms.Label
    Friend WithEvents chartAnalysis As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblColumn As System.Windows.Forms.Label
End Class
