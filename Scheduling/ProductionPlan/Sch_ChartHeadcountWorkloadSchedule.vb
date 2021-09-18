Imports System.Runtime.InteropServices
Public Class Sch_ChartHeadcountWorkloadSchedule
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, pnlMain.MouseDown, lblCapacityUsage.MouseDown, lblScheduledHours.MouseDown, lblTotalHoursOnDay.MouseDown, chartAnalysis.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
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