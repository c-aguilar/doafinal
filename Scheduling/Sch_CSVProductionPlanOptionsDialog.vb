Public Class Sch_CSVProductionPlanOptionsDialog
    Public Property From As Date
    Public Property Weeks As Integer
    Private Sub CSVProductionPlanOptionsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.From = NextMonday()
        Me.Weeks = 16
        txtFrom.Text = Me.From.ToShortDateString
        nudWeeks.Value = Me.Weeks
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        LoadingScreen.Show()
        Me.Weeks = nudWeeks.Value
        Dim plant_code As String = Parameter("SYS_PlantCode")
        Dim pp_table_daily As DataTable = SQL.Current.GetDatatable(String.Format(My.Resources.PP_Daily_Plant, Me.From.ToString("yyyy-MM-dd"), Me.From.AddDays(13).ToString("yyyy-MM-dd"), "D"))
        Dim pp_pivoter As New PivotTable(pp_table_daily)
        Dim pp_pivot = pp_pivoter.PivotDates("Material", "Quantity", AggregateFunction.First, "Date", "System.UInt32")
        pp_pivot.PrimaryKey = {pp_pivot.Columns("Material")}
        pp_pivot.TableName = "ProductionPlan"
        Dim pp_table_weekly As DataTable = SQL.Current.GetDatatable(String.Format(My.Resources.PP_Weekly_Plant, Me.From.AddDays(14).ToString("yyyy-MM-dd"), Me.From.AddDays((Me.Weeks * 7) - 1).ToString("yyyy-MM-dd"), "D"))
        Dim pp_pivoter_wk As New PivotTable(pp_table_weekly)
        Dim pp_pivot_wk = pp_pivoter_wk.PivotData("Material", "Quantity", AggregateFunction.First, {"Week"}, "System.UInt32", " ")
        pp_pivot_wk.PrimaryKey = {pp_pivot_wk.Columns("Material")}
        pp_pivot.Merge(pp_pivot_wk)
        pp_pivot.Columns.Add("Plant", GetType(String), String.Format("'{0}'", plant_code))
        pp_pivot.Columns.Add("Rev", GetType(Integer), "1")
        pp_pivot.Columns.Add("Date", GetType(String), String.Format("'{0}'", Me.From.ToString("MM/dd/yyyy")))
        pp_pivot.Columns("Plant").SetOrdinal(1)
        pp_pivot.Columns("Rev").SetOrdinal(2)
        pp_pivot.Columns("Date").SetOrdinal(3)
        LoadingScreen.Close()
        If CSV.SaveAs(pp_pivot, False) Then
            MsgBox("Sucessfully done!", MsgBoxStyle.Information, APP)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub btnChangeDate_Click(sender As Object, e As EventArgs) Handles btnChangeDate.Click
        Dim calendar As New Calendar
        calendar.SelectedDate = Me.From
        If calendar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.From = calendar.SelectedDate
            txtFrom.Text = Me.From.ToShortDateString
        End If
        calendar.Dispose()
    End Sub

    Private Sub Sch_CSVProductionPlanOptionsDialog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class