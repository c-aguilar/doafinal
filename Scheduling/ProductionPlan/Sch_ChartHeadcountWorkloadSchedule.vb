Public Class Sch_ChartHeadcountWorkloadSchedule
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub MyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, pnlMain.MouseDown, lblCapacityUsage.MouseDown, lblScheduledHours.MouseDown, lblTotalHoursOnDay.MouseDown, chartAnalysis.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
        Cursor.Current = Cursors.SizeAll
    End Sub
    Private Sub MyMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, pnlMain.MouseMove, lblCapacityUsage.MouseMove, lblScheduledHours.MouseMove, lblTotalHoursOnDay.MouseMove, chartAnalysis.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub MyMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, pnlMain.MouseUp, lblCapacityUsage.MouseUp, lblScheduledHours.MouseUp, lblTotalHoursOnDay.MouseUp, chartAnalysis.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ChartHeadcountWorkloadSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Title
        lblColumn.Text = Me.Title
        chartAnalysis.DataSource = Me.Datasource
        chartAnalysis.Series(0)("PieLabelStyle") = "Disabled"
        dgvProductionPlan.DataSource = Me.Datasource
        dgvShifts.DataSource = Me.Shifts
        lblTotalHoursOnDay.Text = String.Format("Available man/seconds: {0}", FormatNumber(Me.Shifts.AsEnumerable().Sum(Function(row) row.Field(Of Integer)("ManufacturingSeconds") * row.Field(Of Int16)("Operators"))))
        lblScheduledHours.Text = String.Format("Scheduled man/seconds: {0}", FormatNumber(Me.TotalManSeconds))
        lblCapacityUsage.Text = String.Format("Capacity usage: {0}", FormatPercent(Me.TotalManSeconds / Me.Shifts.AsEnumerable().Sum(Function(row) row.Field(Of Integer)("ManufacturingSeconds") * row.Field(Of Int16)("Operators"))))
    End Sub

    Public Property TotalManSeconds As Integer
    Public Property Shifts As DataTable
    Public Property Datasource As DataTable
    Public Property Title As String
    Private Sub ChartHeadcountWorkloadSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ChartHeadcountWorkloadSchedule_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub

    Private Sub ChartHeadcountWorkloadSchedule_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        chartAnalysis.Focus()
    End Sub
End Class