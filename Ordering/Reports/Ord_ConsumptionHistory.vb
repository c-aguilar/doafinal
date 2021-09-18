Public Class Ord_ConsumptionHistory
    Dim selected_partnumbers As New ArrayList
    Dim data As DataTable
    Dim sb As SearchBox
    Dim report As DataTable
    Private Sub Ord_ConsumptionHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Report_dgv)

        From_dtp.Value = CurrentDate.AddDays(-30)
        From_dtp.MaxDate = CurrentDate()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(report.DefaultView, Title_lbl.Text)
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        If Not IsNothing(data) Then
            Clipboard.SetDataObject(Report_dgv.GetClipboardContent())
            FlashAlerts.ShowInformation("Copiado!")
        End If
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Report_dgv.DataSource = Nothing
        Dim partnumber_filter As String = ""
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND RIGHT('0000' + Partnumber,8) IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND RIGHT('0000' + Partnumber,8) = '{0}'", Partnumber_txt.Text.Trim)
        End If

        Dim consumption As DataTable = SQL.Current.GetDatatable(String.Format("SELECT C.[Date],Partnumber,ISNULL(Consumption,0) AS Consumption FROM " & _
                                                                              "Sys_Calendar AS C LEFT OUTER JOIN (SELECT Partnumber,CONVERT(DATE,[Date]) AS [Date],SUM(Quantity) AS Consumption " & _
                                                                              "FROM Smk_MB51 WHERE Movement IN ('Z11','311') AND Sloc = '0002' GROUP BY Partnumber,CONVERT(DATE,[Date])) AS MB51 ON C.Date = MB51.[Date] " & _
                                                                              "WHERE C.[Date] >= '{0}' {1} ORDER BY Partnumber,C.[Date];", From_dtp.Value.ToString("yyyy-MM-dd"), partnumber_filter))

        Dim forecast As DataTable = SQL.Current.GetDatatable(String.Format("SELECT C.[Date],Partnumber,CASE WHEN DATEPART(WEEKDAY,C.[Date]) IN (1,7) THEN 0 ELSE ISNULL(F.Quantity,0) END AS Forecast FROM Sys_Calendar AS C INNER JOIN " & _
                                                                           "(SELECT Partnumber,[Week],CEILING(AVG(Quantity/5)) AS Quantity " & _
                                                                           "FROM Ord_Forecast WHERE [Week] >= '{1}' AND [Date] BETWEEN DATEADD(DAY,-7*{0},[Week]) AND DATEADD(DAY,-7,[Week]) GROUP BY Partnumber,[Week]) AS F " & _
                                                                           "ON C.WeekStart = F.[Week] WHERE C.[Date] >= '{2}' {3} ORDER BY Partnumber,C.[Date];", Weeks_nud.Value, SQL.Current.GetDate(String.Format("SELECT WeekStart FROM Sys_Calendar WHERE [Date] = '{0}';", From_dtp.Value.ToString("yyyy-MM-dd"))).ToString("yyyy-MM-dd"), From_dtp.Value.ToString("yyyy-MM-dd"), partnumber_filter))

        report = New DataTable
        report.Columns.Add("No. de Parte")
        report.Columns.Add("Clase")


        Dim dates As DataTable = consumption.DefaultView.ToTable(True, "Date")
        dates.Merge(forecast.DefaultView.ToTable(True, "Date"))
        dates.DefaultView.Sort = "Date ASC"
        Dim distinct_dates = dates.DefaultView.ToTable(True, "Date")
        For Each d As DataRow In distinct_dates.Rows
            report.Columns.Add(CDate(d.Item("Date")).ToShortDateString, GetType(Decimal))
            report.Columns.Item(CDate(d.Item("Date"))).DefaultValue = 0
        Next
        report.PrimaryKey = {report.Columns("No. de Parte"), report.Columns("Clase")}

        For Each row As DataRow In consumption.Rows
            If Not IsDBNull(row.Item("Partnumber")) Then

                Dim forecast_row = report.Rows.Find({row.Item("Partnumber"), "2.Pronostico"})
                If forecast_row Is Nothing Then
                    report.Rows.Add(row.Item("Partnumber"), "2.Pronostico")
                End If

                Dim variations_row = report.Rows.Find({row.Item("Partnumber"), "3.Variacion"})
                If variations_row Is Nothing Then
                    report.Rows.Add(row.Item("Partnumber"), "3.Variacion")
                End If

                Dim consumption_row = report.Rows.Find({row.Item("Partnumber"), "1.Consumo"})
                If consumption_row IsNot Nothing Then
                    consumption_row.Item(CDate(row.Item("Date")).ToShortDateString) = Math.Round(CDec(row.Item("Consumption")), 1)
                Else
                    Dim nr = report.NewRow
                    nr.Item("No. de Parte") = row.Item("Partnumber")
                    nr.Item("Clase") = "1.Consumo"
                    nr.Item(CDate(row.Item("Date")).ToShortDateString) = Math.Round(CDec(row.Item("Consumption")), 1)
                    report.Rows.Add(nr)
                End If
            End If
        Next

        For Each row As DataRow In forecast.Rows
            Dim forecast_row = report.Rows.Find({row.Item("Partnumber"), "2.Pronostico"})
            If forecast_row IsNot Nothing Then
                forecast_row.Item(CDate(row.Item("Date")).ToShortDateString) = Math.Round(CDec(row.Item("Forecast")), 1)
            Else
                Dim nr = report.NewRow
                nr.Item("No. de Parte") = row.Item("Partnumber")
                nr.Item("Clase") = "2.Pronostico"
                nr.Item(CDate(row.Item("Date")).ToShortDateString) = Math.Round(CDec(row.Item("Forecast")), 1)
                report.Rows.Add(nr)
                report.Rows.Add(row.Item("Partnumber"), "1.Consumo")
                report.Rows.Add(row.Item("Partnumber"), "3.Variacion")
            End If

            Dim consumption_row = report.Rows.Find({row.Item("Partnumber"), "1.Consumo"})
            Dim variations_row = report.Rows.Find({row.Item("Partnumber"), "3.Variacion"})
            variations_row.Item(CDate(row.Item("Date")).ToShortDateString) = Math.Round(CDec(consumption_row.Item(CDate(row.Item("Date")).ToShortDateString)) - CDec(row.Item("Forecast")), 1)
        Next


        Dim bajas_rows = report.Select("Clase = '1.Consumo'")
        For Each consumption_row As DataRow In bajas_rows
            Dim accum As Decimal = 0
            Dim accum_doh As Decimal = 0
            Dim forecast_row = report.Rows.Find({consumption_row.Item("No. de Parte"), "2.Pronostico"})
            Dim variation_row = report.Rows.Find({consumption_row.Item("No. de Parte"), "3.Variacion"})

            Dim nr_accumulated = report.NewRow
            nr_accumulated.Item("No. de Parte") = consumption_row.Item("No. de Parte")
            nr_accumulated.Item("Clase") = "4.Acumulado"

            Dim nr_dohconsumption = report.NewRow
            nr_dohconsumption.Item("No. de Parte") = consumption_row.Item("No. de Parte")
            nr_dohconsumption.Item("Clase") = "5.DOH Consumo"

            Dim nr_dohvariation = report.NewRow
            nr_dohvariation.Item("No. de Parte") = consumption_row.Item("No. de Parte")
            nr_dohvariation.Item("Clase") = "6.DOH Variacion"

            Dim nr_dohaccumulated = report.NewRow
            nr_dohaccumulated.Item("No. de Parte") = consumption_row.Item("No. de Parte")
            nr_dohaccumulated.Item("Clase") = "7.DOH Acumulado"

            For i = 2 To report.Columns.Count - 1
                accum += variation_row.Item(i)
                accum_doh += Math.Round(If(CDec(forecast_row.Item(i)) > 0, variation_row.Item(i) / forecast_row.Item(i), 0), 1)
                nr_accumulated.Item(i) = accum
                nr_dohvariation.Item(i) = Math.Round(If(CDec(forecast_row.Item(i)) > 0, CDec(variation_row.Item(i)) / CDec(forecast_row.Item(i)), 0), 1)
                nr_dohconsumption(i) = Math.Round(If(CDec(forecast_row.Item(i)) > 0, CDec(consumption_row.Item(i)) / CDec(forecast_row.Item(i)), 0), 1)
                nr_dohaccumulated(i) = accum_doh
            Next
            report.Rows.Add(nr_accumulated)
            report.Rows.Add(nr_dohvariation)
            report.Rows.Add(nr_dohconsumption)
            report.Rows.Add(nr_dohaccumulated)
        Next
        report.DefaultView.Sort = "[No. de Parte],Clase"

        Report_dgv.DataSource = report.DefaultView


            LoadingScreen.Hide()
    End Sub

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(RawMaterial.Format(p)) Then
                    selected_partnumbers.Add(RawMaterial.Format(p))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Report_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Report_dgv.CellFormatting
        'If e.RowIndex >= 0 Then
        '    Select Case Report_dgv.Rows(e.RowIndex).Cells("Clase").Value
        '        Case "1.Consumo"
        '            e.CellStyle.BackColor = Color.FromArgb(195, 225, 255)
        '        Case "2.Pronostico"
        '            e.CellStyle.BackColor = Color.FromArgb(205, 230, 255)
        '        Case "3.Variacion"
        '            e.CellStyle.BackColor = Color.FromArgb(215, 235, 255)
        '        Case "4.Acumulado"
        '            e.CellStyle.BackColor = Color.FromArgb(225, 240, 255)
        '        Case "5.DOH Consumo"
        '            e.CellStyle.BackColor = Color.FromArgb(235, 245, 255)
        '        Case "6.DOH Variacion"
        '            e.CellStyle.BackColor = Color.FromArgb(245, 250, 255)
        '        Case "7.DOH Acumulado"
        '            e.CellStyle.BackColor = Color.FromArgb(255, 255, 255)
        '    End Select
        'End If
    End Sub

    Private Sub Ord_ConsumptionHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class