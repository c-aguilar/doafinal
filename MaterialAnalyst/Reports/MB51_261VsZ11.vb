Public Class MB51_261VsZ11
    Private Partnumber_Detailed As String
    Private From As Date
    Private [To] As Date
    Private Sub MB51_261VsZ11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chrtMain.Series.Clear()
        dtpTo.Value = LastMonday()
        dtpFrom.Value = LastMonday(CurrentDate.AddDays(-15))
        'GF.FillCombobox(cboPartnumber, SQL.Current.GetDatatable("SELECT DISTINCT Partnumber FROM Smk_MB51 ORDER BY Partnumber"))
        'cboPartnumber.Items.Add("*")
        'cboPartnumber.SelectedItem = "*"
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If Not dtpFrom.Value <= dtpTo.Value Then
            MsgBox("Date range incorrect.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LoadingScreen.Show()
        From = dtpFrom.Value
        [To] = dtpTo.Value
        If rbDailyDifference.Checked Then
            Dim data As DataTable
            If Partnumber_txt.Text = "*" Then
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS [Date],Partnumber,SUM(Quantity) AS Difference FROM Smk_MB51 WHERE Movement IN ('261','Z11') AND Sloc = '0002' AND CONVERT(DATE,[Date]) BETWEEN '{0}' AND '{1}' GROUP BY [Date],[Partnumber] ORDER BY CONVERT(DATE,[Date])", From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd")))
            Else
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS [Date],Partnumber,SUM(Quantity) AS Difference FROM Smk_MB51 WHERE Partnumber = '{0}' AND Movement IN ('261','Z11') AND Sloc = '0002' AND CONVERT(DATE,[Date]) BETWEEN '{1}' AND '{2}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", Partnumber_txt.Text, From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd")))
            End If
            Dim pivoter As New PivotTable(data)
            Dim pivot = pivoter.PivotDates("Partnumber", "Difference", AggregateFunction.Sum, "Date", "System.Double")
            dgvReport.DataSource = pivot
        ElseIf rbAccumulated.Checked Then
            Dim data As DataTable
            If Partnumber_txt.Text = "*" Then
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS [Date],Partnumber,SUM(Quantity) AS Difference FROM Smk_MB51 WHERE Movement IN ('261','Z11') AND Sloc = '0002' AND CONVERT(DATE,[Date]) BETWEEN '{0}' AND '{1}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd")))
            Else
                data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS [Date],Partnumber,SUM(Quantity) AS Difference FROM Smk_MB51 WHERE Partnumber = '{0}' AND Movement IN ('261','Z11') AND Sloc = '0002' AND CONVERT(DATE,[Date]) BETWEEN '{1}' AND '{2}' GROUP BY CONVERT(DATE,[Date]),[Partnumber] ORDER BY CONVERT(DATE,[Date])", Partnumber_txt.Text, From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd")))
            End If
            Dim pivoter As New PivotTable(data)
            Dim pivot = pivoter.PivotDates("Partnumber", "Difference", AggregateFunction.Sum, "Date", "System.Double")
            Dim balance = pivot.Clone()
            For Each row As DataRow In pivot.Rows
                Dim new_row = balance.NewRow
                new_row.Item("Partnumber") = row.Item("Partnumber")
                new_row.Item(1) = row.Item(1)
                For i = 2 To pivot.Columns.Count - 1
                    new_row.Item(i) = new_row.Item(i - 1) + row(i)
                Next
                balance.Rows.Add(new_row)
            Next
            dgvReport.DataSource = balance
        End If
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

    Private Sub dgvReport_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvReport.RowsAdded
        dgvReport.Rows(e.RowIndex).ContextMenuStrip = cmsReports
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If dgvReport.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            If MyExcel.SaveAs(dgvReport.DataSource, "261VsZ11", False) Then
                LoadingScreen.Hide()
                MsgBox("Done!", MsgBoxStyle.Information)
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        Dim details As New MB51_261VsZ11_Details
        details.Partnumber = Partnumber_Detailed
        Dim data = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(DATE,[Date]) AS [Date],SUM(CASE WHEN Movement = 'Z11'  THEN Quantity ELSE 0 END) AS Z11,SUM(CASE WHEN Movement = '261'  THEN Quantity ELSE 0 END) AS [261] FROM Smk_MB51 WHERE Partnumber = '{0}' AND Movement IN ('261','Z11') AND Sloc = '0002' AND CONVERT(DATE,[Date]) BETWEEN '{1}' AND '{2}' GROUP BY CONVERT(DATE,[Date]) ORDER BY CONVERT(DATE,[Date])", Partnumber_Detailed, From.ToString("yyyy-MM-dd"), [To].ToString("yyyy-MM-dd")))
        data.Columns.Add("Balance", GetType(Double))
        Dim balance As Double = 0
        For Each row As DataRow In data.Rows
            balance = balance + row.Item("Z11") + row.Item("261")
            row.Item("Balance") = balance
        Next
        details.DataSource = data
        details.Show(Me)
    End Sub

    Private Sub dgvReport_RowContextMenuStripNeeded(sender As Object, e As DataGridViewRowContextMenuStripNeededEventArgs) Handles dgvReport.RowContextMenuStripNeeded
        Partnumber_Detailed = dgvReport.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub MB51_261VsZ11_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class