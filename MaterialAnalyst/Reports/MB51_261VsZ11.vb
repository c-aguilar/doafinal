Public Class MB51_261VsZ11
    Private Partnumber_Detailed As String
    Private From As Date
    Private [To] As Date
    Private report As DataTable
    Private Sub MB51_261VsZ11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chrtMain.Series.Clear()
        dtpTo.Value = LastMonday()
        dtpFrom.Value = LastMonday(CurrentDate.AddDays(-15))
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        LoadingScreen.Show()
        From = dtpFrom.Value
        [To] = dtpTo.Value
        dgvReport.DataSource = Nothing
        If rbDailyDifference.Checked Then
            Dim data As DataTable
            If Partnumber_txt.Text = "*" Then
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS Fecha,Partnumber AS [No. de Parte],SUM(Quantity) AS Total FROM Smk_MB51 WHERE Sloc = '{2}' AND CONVERT(DATE,[Date]) BETWEEN '{0}' AND '{1}' GROUP BY [Date],[Partnumber] ORDER BY CONVERT(DATE,[Date])", From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd"), Sloc_cbo.SelectedItem))
            Else
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS Fecha,Partnumber AS [No. de Parte],SUM(Quantity) AS Total FROM Smk_MB51 WHERE Partnumber = '{0}' AND Sloc = '{3}' AND CONVERT(DATE,[Date]) BETWEEN '{1}' AND '{2}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", Partnumber_txt.Text, From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd"), Sloc_cbo.SelectedItem))
            End If
            Dim pivoter As New PivotTable(Data)
            report = pivoter.PivotDates("No. de Parte", "Total", AggregateFunction.Sum, "Fecha", "System.Decimal")
        ElseIf rbAccumulated.Checked Then
            Dim data As DataTable
            If Partnumber_txt.Text = "*" Then
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS Fecha,Partnumber AS [No. de Parte],SUM(Quantity) AS Total FROM Smk_MB51 WHERE Sloc = '{2}' AND CONVERT(DATE,[Date]) BETWEEN '{0}' AND '{1}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd"), Sloc_cbo.SelectedItem))
            Else
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS Fecha,Partnumber AS [No. de Parte],SUM(Quantity) AS Total FROM Smk_MB51 WHERE Partnumber = '{0}' AND Sloc = '{3}' AND CONVERT(DATE,[Date]) BETWEEN '{1}' AND '{2}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", Partnumber_txt.Text, From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd"), Sloc_cbo.SelectedItem))
            End If
            Dim pivoter As New PivotTable(data)
            Dim pivot = pivoter.PivotDates("No. de Parte", "Total", AggregateFunction.Sum, "Fecha", "System.Decimal")
            Dim balance = pivot.Clone()
            For Each row As DataRow In pivot.Rows
                Dim new_row = balance.NewRow
                new_row.Item("No. de Parte") = row.Item("No. de Parte")
                new_row.Item(1) = row.Item(1)
                For i = 2 To pivot.Columns.Count - 1
                    new_row.Item(i) = new_row.Item(i - 1) + row(i)
                Next
                balance.Rows.Add(new_row)
            Next
            report = balance
        End If
        dgvReport.DataSource = report
        LoadingScreen.Hide()
    End Sub

    Private Sub dgvReport_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvReport.ColumnAdded
        If e.Column.Index > 0 Then
            e.Column.DefaultCellStyle.Format = "N3"
        End If
    End Sub

    Private Sub dgvReport_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvReport.RowStateChanged
        chrtMain.Series.Clear()
        If e.StateChanged = DataGridViewElementStates.Selected Then
            chrtMain.Series.Add(e.Row.Cells(0).Value)
            chrtMain.Series(chrtMain.Series.Count - 1).XValueType = DataVisualization.Charting.ChartValueType.Date
            chrtMain.Series(chrtMain.Series.Count - 1).YValueType = DataVisualization.Charting.ChartValueType.Double
            chrtMain.Series(chrtMain.Series.Count - 1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            For i = 1 To dgvReport.Columns.Count - 1
                chrtMain.Series(chrtMain.Series.Count - 1).Points.AddXY(dgvReport.Columns(i).Name, e.Row.Cells(i).Value)
                chrtMain.Series(chrtMain.Series.Count - 1).Points(chrtMain.Series(chrtMain.Series.Count - 1).Points.Count - 1).MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                chrtMain.Series(chrtMain.Series.Count - 1).Points(chrtMain.Series(chrtMain.Series.Count - 1).Points.Count - 1).MarkerSize = 6
                chrtMain.Series(chrtMain.Series.Count - 1).BorderWidth = 2
            Next
        End If
    End Sub

    Private Sub dgvReport_RowContextMenuStripNeeded(sender As Object, e As DataGridViewRowContextMenuStripNeededEventArgs) Handles dgvReport.RowContextMenuStripNeeded
        Partnumber_Detailed = dgvReport.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub MB51_261VsZ11_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If report IsNot Nothing Then
            Export(report, "SAP Movs")
        End If
    End Sub
End Class