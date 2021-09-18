Public Class ForecastVs261
    Dim selected_partnumbers As New ArrayList
    Dim data As DataTable
    Dim sb As SearchBox
    Private Sub ForecastVs261_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Me.Report_dgv)
        From_dtp.MaxDate = Now()
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Try
            Report_dgv.DataSource = Nothing
            LoadingScreen.Show()
            Dim forecast As DataTable
            Dim m261 As DataTable
            If Cost_rb.Checked Then
                If Plant_rb.Checked OrElse (selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "" OrElse Partnumber_txt.Text = "*")) Then
                    forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],F.Partnumber,Quantity * UnitCost AS Quantity FROM Ord_Forecast AS F INNER JOIN Sys_RawMaterial AS R ON F.Partnumber = R.Partnumber  WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}';", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd")))
                    m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],M.Partnumber,SUM(Quantity * UnitCost) AS Quantity FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE [Date] >= '{0}' AND Movement = '261' GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),M.Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd")))
                Else
                    If selected_partnumbers.Count > 0 Then
                        forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],F.Partnumber,Quantity * UnitCost AS Quantity FROM Ord_Forecast AS F INNER JOIN Sys_RawMaterial AS R ON F.Partnumber = R.Partnumber  WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}' AND F.Partnumber IN ('{1}');", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)))
                        m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],M.Partnumber,SUM(Quantity * UnitCost) AS Quantity FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE [Date] >= '{0}' AND Movement = '261' AND M.Partnumber IN ('{1}') GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),M.Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)))
                    Else
                        forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],F.Partnumber,Quantity * UnitCost AS Quantity FROM Ord_Forecast AS F INNER JOIN Sys_RawMaterial AS R ON F.Partnumber = R.Partnumber  WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}' AND F.Partnumber = '{1}';", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim))
                        m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],M.Partnumber,SUM(Quantity * UnitCost) AS Quantity FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE [Date] >= '{0}' AND Movement = '261' AND M.Partnumber  = '{1}' GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),M.Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim))
                    End If
                End If
            Else
                If Plant_rb.Checked OrElse (selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "" OrElse Partnumber_txt.Text = "*")) Then
                    forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,Quantity FROM Ord_Forecast WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}';", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd")))
                    m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE [Date] >= '{0}' AND Movement = '261' GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd")))
                Else
                    If selected_partnumbers.Count > 0 Then
                        forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,Quantity FROM Ord_Forecast WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}' AND Partnumber IN ('{1}');", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)))
                        m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE [Date] >= '{0}' AND Movement = '261' AND Partnumber IN ('{1}') GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)))
                    Else
                        forecast = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,Quantity FROM Ord_Forecast WHERE DATEPART(WK,[Date]) = DATEPART(WK,[Week]) AND DATEPART(YY,[Date]) = DATEPART(YY,[Week]) AND [Date] >= '{0}' AND Partnumber = '{1}';", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim))
                        m261 = SQL.Current.GetDatatable(String.Format("SELECT DATEPART(YY,[Date]) AS [Year], DATEPART(WK,[Date]) AS [Week],Partnumber,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE [Date] >= '{0}' AND Movement = '261' AND Partnumber  = '{1}' GROUP BY DATEPART(YY,[Date]),DATEPART(WK,[Date]),Partnumber", LastMonday(From_dtp.Value).ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim))
                    End If
                End If
            End If
            If forecast IsNot Nothing AndAlso m261 IsNot Nothing Then
                Dim distinct_weeks = forecast.DefaultView.ToTable(True, "Year", "Week")
                distinct_weeks.Merge(m261.DefaultView.ToTable(True, "Year", "Week"))
                distinct_weeks.DefaultView.Sort = "Year,Week"
                distinct_weeks = distinct_weeks.DefaultView.ToTable(True, "Year", "Week")

                Dim report As New DataTable
                report.Columns.Add("No. de Parte")
                report.Columns.Add("Descripcion")
                For Each w As DataRow In distinct_weeks.Rows
                    report.Columns.Add(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year")), GetType(Decimal))
                Next
                If Plant_rb.Checked Then
                    Dim sum_forecast As Decimal = 0
                    Dim sum_m261 As Decimal = 0
                    Dim row_forecast As DataRow = report.NewRow
                    Dim row_m261 As DataRow = report.NewRow
                    Dim row_diff As DataRow = report.NewRow
                    row_forecast.Item("No. de Parte") = "Total"
                    row_forecast.Item("Descripcion") = "Pronostico"
                    row_m261.Item("No. de Parte") = "Total"
                    row_m261.Item("Descripcion") = "Movimiento 261"
                    row_diff.Item("No. de Parte") = "Total"
                    row_diff.Item("Descripcion") = "Diferencia"
                    For Each w As DataRow In distinct_weeks.Rows
                        sum_forecast = NullReplace(forecast.Compute("SUM(Quantity)", String.Format("Year = {0} AND Week = {1}", w.Item("Year"), w.Item("Week"))), 0)
                        sum_m261 = NullReplace(m261.Compute("SUM(Quantity)", String.Format("Year = {0} AND Week = {1}", w.Item("Year"), w.Item("Week"))), 0)
                        row_forecast.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_forecast
                        row_m261.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_m261
                        row_diff.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_forecast + sum_m261
                    Next
                    report.Rows.Add(row_forecast)
                    report.Rows.Add(row_m261)
                    report.Rows.Add(row_diff)
                Else
                    Dim distinct_partnumbers = forecast.DefaultView.ToTable(True, "Partnumber")
                    distinct_partnumbers.Merge(m261.DefaultView.ToTable(True, "Partnumber"))
                    distinct_partnumbers.DefaultView.Sort = "Partnumber"
                    Dim sum_forecast As Decimal = 0
                    Dim sum_m261 As Decimal = 0
                    For Each p As DataRow In distinct_partnumbers.DefaultView.ToTable(True, "Partnumber").Rows
                        Dim row_forecast As DataRow = report.NewRow
                        Dim row_m261 As DataRow = report.NewRow
                        Dim row_diff As DataRow = report.NewRow
                        row_forecast.Item("No. de Parte") = p.Item("Partnumber")
                        row_forecast.Item("Descripcion") = "Pronostico"
                        row_m261.Item("No. de Parte") = p.Item("Partnumber")
                        row_m261.Item("Descripcion") = "Movimiento 261"
                        row_diff.Item("No. de Parte") = p.Item("Partnumber")
                        row_diff.Item("Descripcion") = "Diferencia"
                        For Each w As DataRow In distinct_weeks.Rows
                            sum_forecast = NullReplace(forecast.Compute("SUM(Quantity)", String.Format("Year = {0} AND Week = {1} AND Partnumber = '{2}'", w.Item("Year"), w.Item("Week"), p.Item("Partnumber"))), 0)
                            sum_m261 = NullReplace(m261.Compute("SUM(Quantity)", String.Format("Year = {0} AND Week = {1} AND Partnumber = '{2}'", w.Item("Year"), w.Item("Week"), p.Item("Partnumber"))), 0)
                            row_forecast.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_forecast
                            row_m261.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_m261
                            row_diff.Item(String.Format("{0}/{1}", w.Item("Week"), w.Item("Year"))) = sum_forecast + sum_m261
                        Next
                        report.Rows.Add(row_forecast)
                        report.Rows.Add(row_m261)
                        report.Rows.Add(row_diff)
                    Next
                End If
                data = report
                Report_dgv.DataSource = data
                For Each c As DataGridViewColumn In Report_dgv.Columns
                    If Not {"No. de Parte", "Descripcion"}.Contains(c.Name) Then c.DefaultCellStyle.Format = "N2"
                Next
                LoadingScreen.Hide()
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al obtener la informacion.")
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Error al generar el reporte.")
        End Try
    End Sub


    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Report_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Report_dgv.DataSource, Me.Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Report_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Report_dgv.DataSource
                        pdf.Title = Me.Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        If Not IsNothing(data) Then
            Clipboard.SetDataObject(Report_dgv.GetClipboardContent())
            FlashAlerts.ShowInformation("Copiado!")
        End If
    End Sub

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(Strings.Right("00000000" & p.ToString, 8)) Then
                    selected_partnumbers.Add(Strings.Right("00000000" & p.ToString, 8))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Text = ""
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
        Partnumber_rb.Checked = True
    End Sub

    Private Sub ForecastVs261_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub
End Class