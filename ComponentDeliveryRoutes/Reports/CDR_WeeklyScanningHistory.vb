Public Class CDR_WeeklyScanningHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub CDR_ScanningHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Shift_cbo, SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift")
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Report_dgv.DataSource = Nothing
        Dim date_filter As String = String.Format("DATEPART(WEEK,L.InDate) = {0} AND DATEPART(YEAR,L.InDate) = {1} AND dbo.Sys_Shift(L.InDate) = '{2}'", DatePart(DateInterval.WeekOfYear, From_dtp.Value), From_dtp.Value.Year, Shift_cbo.SelectedValue)
        Dim data As DataTable = SQL.Current.GetDatatable(String.Format("SELECT O.FullName AS [Surtidor], L.Badge AS Gafete, CONVERT(DATE,L.InDate) AS Fecha,CONVERT(VARCHAR(2),DATEPART(HOUR,L.InDate)) + ':00' AS Hora,COUNT(DISTINCT L.ID) AS [Loops],COUNT(S.ID) AS Contenedores FROM CDR_Routes AS R INNER JOIN CDR_RoutesLoopRegister AS L ON R.Route = L.Route INNER JOIN CDR_RoutesLoopKanbans AS S ON S.LoopID = L.ID INNER JOIN Smk_Operators AS O ON L.Badge = O.Badge WHERE {0} GROUP BY O.FullName, L.Badge, CONVERT(DATE,L.InDate), CONVERT(VARCHAR(2),DATEPART(HOUR,L.InDate)) + ':00' ORDER BY L.Badge, CONVERT(DATE,L.InDate);", date_filter))
        'Dim pivot As DataTable
        'data.DefaultView.Sort = "Fecha ASC"
        'For Each row As DataRow In data.DefaultView.ToTable("Fecha").Rows 'RECORRER LAS DISTINTAS FECHAS
        '    If pivot IsNot Nothing Then

        '    Else
        '        Dim pivot_week As DataTable = DatatablePivoter.Get(data, {"Surtidor", "Gafete"}, {"Fecha", "Hora"}, {"Contenedores"}, {AggregateFunction.Sum}, String.Format("Fecha = #{0}#", row.Item("Fecha")), True, True)
        '        pivot_week.Columns("").ColumnName = ""
        '    End If
        'Next
        Dim pivots As DataTable = DatatablePivoter.Get(data, {"Surtidor", "Gafete"}, {"Fecha", "Hora"}, {"Contenedores"}, {AggregateFunction.Sum}, , True, True)
        Dim last_date As String = Strings.Split(pivots.Columns(2).ColumnName).GetValue(0)
        Dim sum_week As String = String.Format("[{0}]", pivots.Columns(2).ColumnName)
        Dim i As Integer = 3
        While i < pivots.Columns.Count - 1
            If pivots.Columns(i).ColumnName.StartsWith(last_date) Then
                sum_week &= String.Format("+[{0}]", pivots.Columns(i).ColumnName)
            Else
                pivots.Columns.Add("Total " & last_date, GetType(Integer), sum_week)
                pivots.Columns("Total " & last_date).SetOrdinal(i)
                i += 1
                sum_week = String.Format("[{0}]", pivots.Columns(i).ColumnName)
                last_date = Strings.Split(pivots.Columns(i).ColumnName).GetValue(0)
            End If
            i += 1
        End While
        pivots.Columns.Add("Total " & last_date, GetType(Integer), sum_week)
        pivots.Columns("Total " & last_date).SetOrdinal(i)

        Report_dgv.DataSource = pivots
        LoadingScreen.Hide()
    End Sub


    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(report.DefaultView, Title_lbl.Text)
    End Sub

    Private Sub CDR_ScanningHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class