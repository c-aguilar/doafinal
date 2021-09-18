Public Class Ord_ForecastVsZapimatinfo
    Dim data As DataTable
    Dim sb As SearchBox
    Private Sub OrderingForecastWaterfall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Report_dgv)

        From_dtp.Value = LastMonday().AddDays(-7)
        For Each sloc In SQL.Current.GetList("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs UNION SELECT DISTINCT DullSloc AS Sloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc")
            Slocs_clb.Items.Add(sloc, True)
        Next
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Delta.Export(data, Title_lbl.Text)
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(data) Then
            Clipboard.SetDataObject(Report_dgv.GetClipboardContent())
        End If
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Report_dgv.DataSource = Nothing
        LoadingScreen.Show()
        Dim part_filter As String = ""
        If Not Partnumber_txt.Text = "*" AndAlso Not Partnumber_txt.Text = "" Then
            part_filter = String.Format("H.Partnumber = '{0}' AND", RawMaterial.Format(Partnumber_txt.Text))
        End If
        Dim checked_slocs As New ArrayList
        For Each s In Slocs_clb.CheckedItems
            checked_slocs.Add(s.ToString)
        Next
        Dim sloc_filter As String = String.Format("Sloc IN ('{0}') AND", String.Join("','", checked_slocs.ToArray))
        Dim last_zapi As DataTable = SQL.Current.GetDatatable(String.Format("SELECT H.*, R.MRP, R.[Description], R.RoundingValue FROM (SELECT Partnumber,Sloc,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE [Date] <= '{2} 08:00' GROUP BY Partnumber,Sloc) AS H LEFT OUTER JOIN Sys_RawMaterial AS R ON H.Partnumber = R.Partnumber WHERE {0} {1}", part_filter, sloc_filter, From_dtp.Value.ToString("yyyy-MM-dd")))
        Dim new_zapi As DataTable = SQL.Current.GetDatatable(String.Format("SELECT H.*, R.MRP, R.[Description], R.RoundingValue FROM (SELECT Partnumber,Sloc,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE [Date] <= '{2} 08:00' GROUP BY Partnumber,Sloc) AS H LEFT OUTER JOIN Sys_RawMaterial AS R ON H.Partnumber = R.Partnumber WHERE {0} {1}", part_filter, sloc_filter, From_dtp.Value.AddDays(7).ToString("yyyy-MM-dd")))
        If last_zapi.Rows.Count = 0 Then
            MsgBox(String.Format("Reporte ZAPI_MATINFO {0} no fue descargado o el numero de parte no esta en uso.", From_dtp.Value.ToShortDateString), MsgBoxStyle.Exclamation)
        ElseIf new_zapi.Rows.Count = 0 Then
            MsgBox(String.Format("Reporte ZAPI_MATINFO {0} no fue descargado o el numero de parte no esta en uso.", From_dtp.Value.AddDays(7).ToShortDateString), MsgBoxStyle.Exclamation)
        Else
            Dim last_date As Date = last_zapi.Rows(0).Item("Date")
            Dim new_date As Date = new_zapi.Rows(0).Item("Date")
            Dim mov101 As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(Quantity) AS Quantity FROM Smk_MB51 WHERE {0} Sloc = '0001' AND Movement IN ('101','711') AND [Date] BETWEEN '{1}' AND '{2}' GROUP BY Partnumber", part_filter.Replace("H.Partnumber", "Material"), last_date.AddHours(2).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss"), new_date.AddHours(2).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss")))
            If mov101.Rows.Count = 0 And part_filter = "" Then
                LoadingScreen.Hide()
                MsgBox("Movimientos 101 y 701 no han sido descargados", MsgBoxStyle.Exclamation)
                LoadingScreen.Show()
            End If

            Dim usage As DataTable = SQL.Current.GetDatatable(String.Format("SELECT [Partnumber],SUM(Quantity) AS Quantity FROM Ord_Forecast WHERE {0} [Date] = '{1}' AND [Week] <= [Date] GROUP BY Partnumber", part_filter.Replace("H.", ""), From_dtp.Value.ToString("yyyy-MM-dd")))
            If usage.Rows.Count = 0 Then
                LoadingScreen.Hide()
                MsgBox("El pronostico {0} no ha sido cargado o los numeros de parte seleccionados no tienen pronostico.", MsgBoxStyle.Exclamation)
                LoadingScreen.Show()
            End If
            Dim exp_last As String = ""
            Dim exp_new As String = ""
            Dim report As New DataTable
            report.Columns.Add("No. de Parte")
            report.Columns.Add("Descripcion")
            report.Columns.Add("StdPack", GetType(Double))
            report.Columns.Add("MRP")
            For Each s In checked_slocs
                report.Columns.Add("Ultimo " & s.ToString, GetType(Double))
                exp_last &= String.Format("[Ultimo {0}]+", s.ToString)
            Next
            report.Columns.Add("MB51", GetType(Double))
            report.Columns.Add("Ultimo Total", GetType(Double), exp_last & "[MB51]")
            For Each s In checked_slocs
                report.Columns.Add("Nuevo " & s.ToString, GetType(Double))
                exp_new &= String.Format("[Nuevo {0}]+", s.ToString)
            Next
            report.Columns.Add("Nuevo Total", GetType(Double), exp_new.Trim("+"))
            report.Columns.Add("Uso Semanal", GetType(Double))
            report.Columns.Add("Inventario Esperado", GetType(Double), "[Ultimo Total] - [Uso Semanal]")
            report.Columns.Add("Adherencia", GetType(Double), "100 * IIF([Inventario Esperado] = [Nuevo Total],1,IIF([Uso Semanal] = 0 OR [Ultimo Total] = [Nuevo Total], 0, IIF(([Nuevo Total] - [Inventario Esperado]) * IIF([Nuevo Total] - [Inventario Esperado] < 0, -1, 1) > [Uso Semanal],0,(([Nuevo Total] - [Inventario Esperado]) * IIF([Nuevo Total] - [Inventario Esperado] < 0, -1, 1)) / [Uso Semanal])))")
            report.Columns.Add("Comentario", GetType(String), "IIF(Adherencia = 100,'OK',IIF([Nuevo Total] > [Inventario Esperado],'Menor Consumo','Sobreconsumo'))")
            report.Columns.Add("Cantidad", GetType(Double), "([Nuevo Total] - [Inventario Esperado]) * IIF([Nuevo Total] - [Inventario Esperado] < 0,-1,1)")
            report.Columns.Add("Semanas", GetType(Double), "IIF([Uso Semanal] = 0, IIF(Adherencia = 0, 52, 0), Cantidad / [Uso Semanal])")
            report.Columns.Add("Contenedores", GetType(Double), "([Nuevo Total] - [Inventario Esperado]) / IIF([StdPack] = 0, 1, [StdPack])")
            report.PrimaryKey = {report.Columns("No. de Parte")}
            report.Columns("MB51").DefaultValue = 0
            report.Columns("Uso Semanal").DefaultValue = 0
            report.Columns("StdPack").DefaultValue = 0
            For Each s In checked_slocs
                report.Columns("Ultimo " & s.ToString).DefaultValue = 0
                report.Columns("Nuevo " & s.ToString).DefaultValue = 0
            Next
            For Each row As DataRow In last_zapi.Rows
                Dim part = report.Rows.Find(row.Item("Partnumber"))
                If part Is Nothing Then
                    part = report.NewRow()
                    part.Item("No. de Parte") = row.Item("Partnumber")
                    part.Item("Descripcion") = row.Item("Description")
                    part.Item("StdPack") = row.Item("RoundingValue")
                    part.Item("MRP") = row.Item("MRP")
                    part.Item("Ultimo " & row.Item("Sloc")) = row.Item("Quantity")
                    report.Rows.Add(part)
                Else
                    part.Item("Ultimo " & row.Item("Sloc")) = row.Item("Quantity")
                End If
            Next

            For Each row As DataRow In new_zapi.Rows
                Dim part = report.Rows.Find(row.Item("Partnumber"))
                If part Is Nothing Then
                    part = report.NewRow()
                    part.Item("No. de Parte") = row.Item("Partnumber")
                    part.Item("Descripcion") = row.Item("Description")
                    part.Item("StdPack") = row.Item("RoundingValue")
                    part.Item("MRP") = row.Item("MRP")
                    part.Item("Nuevo " & row.Item("Sloc")) = row.Item("Quantity")
                    report.Rows.Add(part)
                Else
                    part.Item("Nuevo " & row.Item("Sloc")) = row.Item("Quantity")
                End If
            Next

            For Each row As DataRow In mov101.Rows
                Dim part = report.Rows.Find(row.Item("Material"))
                If part Is Nothing Then
                    part = report.NewRow()
                    part.Item("No. de Parte") = row.Item("Material")
                    part.Item("MB51") = row.Item("Quantity")
                    report.Rows.Add(part)
                Else
                    part.Item("MB51") = row.Item("Quantity")
                End If
            Next

            For Each row As DataRow In usage.Rows
                Dim part = report.Rows.Find(row.Item("Partnumber"))
                If part Is Nothing Then
                    part = report.NewRow()
                    part.Item("No. de Parte") = row.Item("Partnumber")
                    part.Item("Uso Semanal") = row.Item("Quantity")
                    report.Rows.Add(part)
                Else
                    part.Item("Uso Semanal") = row.Item("Quantity")
                End If
            Next

            data = report
            Report_dgv.DataSource = data
            Report_dgv.Columns("No. de Parte").Frozen = True
            Report_dgv.Columns("Semanas").DefaultCellStyle.Format = "N1"
            Report_dgv.Columns("Contenedores").DefaultCellStyle.Format = "N1"
            Report_dgv.Columns("Cantidad").DefaultCellStyle.Format = "N1"
            Report_dgv.Columns("Adherencia").DefaultCellStyle.Format = "0.00\%"
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub Waterfall_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Report_dgv.CellFormatting
        If IsDBNull(e.Value) Then
            e.CellStyle.BackColor = Color.LightGray
        ElseIf Report_dgv.Columns(e.ColumnIndex).Name = "Ultimo Total" Then
            e.CellStyle.BackColor = Color.Silver
        ElseIf Report_dgv.Columns(e.ColumnIndex).Name = "Nuevo Total" Then
            e.CellStyle.BackColor = Color.Silver
        ElseIf Report_dgv.Columns(e.ColumnIndex).Name = "Inventario Esperado" Then
            e.CellStyle.BackColor = Color.Silver
        ElseIf Report_dgv.Columns(e.ColumnIndex).Name = "Uso Semanal" Then
            e.CellStyle.BackColor = Color.AliceBlue
        ElseIf Report_dgv.Columns(e.ColumnIndex).Name = "Comentario" Then
            If e.Value = "OK" Then
                e.CellStyle.BackColor = Color.LightGreen
            ElseIf e.Value = "Sobreconsumo" Then
                e.CellStyle.BackColor = Color.LightCoral
            ElseIf e.Value = "Menor Consumo" Then
                e.CellStyle.BackColor = Color.LightYellow
            End If
        End If
    End Sub

    Private Sub From_dtp_ValueChanged(sender As Object, e As EventArgs) Handles From_dtp.ValueChanged
        From_dtp.Value = LastMonday(From_dtp.Value)
    End Sub

    Private Sub Ord_ForecastVsZapimatinfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class