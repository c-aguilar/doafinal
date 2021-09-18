Public Class Ord_ABC
    Dim selected_partnumbers As New ArrayList
    Dim data As DataTable
    Dim sb As SearchBox
    Private Sub Ord_ABC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Me.Report_dgv)
        From_dtp.MaxDate = Now()
        For Each sloc In SQL.Current.GetList("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs UNION SELECT DISTINCT DullSloc AS Sloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc")
            Slocs_clb.Items.Add(sloc, True)
        Next
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
                        If MyExcel.SaveAs(Report_dgv.DataSource, "Analisis ABC", True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Report_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Report_dgv.DataSource
                        pdf.Title = "Analisis ABC"
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

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Report_dgv.DataSource = Nothing
        LoadingScreen.Show()
        Dim partnumber As String = ""
        If selected_partnumbers.Count > 0 Then
            partnumber = String.Join("','", selected_partnumbers.ToArray)
        Else
            partnumber = Partnumber_txt.Text.Trim
        End If

        Dim checked_slocs As New ArrayList
        For Each s In Slocs_clb.CheckedItems
            checked_slocs.Add(s.ToString)
        Next
        Dim sloc_filter As String = String.Format("Sloc IN ('{0}') AND", String.Join("','", checked_slocs.ToArray))

        Dim slocs As DataTable
        Dim partnumbers As DataTable
        If partnumber = "*" OrElse partnumber = "" Then
            slocs = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],SUM(Quantity) AS Cantidad,Sloc FROM Smk_MB51 WHERE {0} [Date] <= '{1} 08:00' GROUP BY Partnumber,Sloc ORDER BY Partnumber;", sloc_filter, From_dtp.Value.ToString("yyyy-MM-dd")))
            partnumbers = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sys_RawMaterial WHERE Partnumber IN ({0});", String.Format("SELECT DISTINCT Partnumber FROM Smk_MB51 WHERE [Date] <= '{0} 08:00'", From_dtp.Value.ToString("yyyy-MM-dd"))))
        Else
            slocs = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],SUM(Quantity) AS Cantidad,Sloc FROM Smk_MB51 WHERE {0} [Date] <= '{1} 08:00' AND Partnumber IN ('{2}') GROUP BY Partnumber,Sloc ORDER BY Partnumber;", sloc_filter, From_dtp.Value.ToString("yyyy-MM-dd"), partnumber))
            partnumbers = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sys_RawMaterial WHERE Partnumber IN ({0});", String.Format("SELECT DISTINCT Partnumber FROM Smk_MB51 WHERE [Date] <= '{0} 08:00' AND Partnumber IN ('{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), partnumber)))
        End If
        partnumbers.PrimaryKey = {partnumbers.Columns("Partnumber")}
        Dim pivoter As New PivotTable(slocs)
        Dim pivot_sloc As DataTable = pivoter.PivotData("No. de Parte", "Cantidad", AggregateFunction.First, {"Sloc"}, "System.Double")
        Dim expression As String = ""
        For i = 1 To pivot_sloc.Columns.Count - 1
            expression &= String.Format("[{0}]+", pivot_sloc.Columns(i).ColumnName)
        Next
        pivot_sloc.Columns.Add("Total", GetType(Double), expression.Trim("+"))
        pivot_sloc.Columns.Add("Descripcion")
        pivot_sloc.Columns.Add("MRP")
        pivot_sloc.Columns.Add("Costo Unitario", GetType(Decimal))
        pivot_sloc.Columns.Add("StdPack", GetType(Double))
        pivot_sloc.Columns.Add("Unidad")
        pivot_sloc.Columns.Add("Total Costo", GetType(Decimal), "Total * [Costo Unitario]")
        pivot_sloc.Columns.Add("Contenedores", GetType(Decimal), "Total / StdPack")
        pivot_sloc.Columns("Descripcion").SetOrdinal(1)
        pivot_sloc.Columns("MRP").SetOrdinal(2)
        pivot_sloc.Columns("Costo Unitario").SetOrdinal(3)
        pivot_sloc.Columns("StdPack").SetOrdinal(4)
        pivot_sloc.Columns("Unidad").SetOrdinal(5)

        For Each p As DataRow In pivot_sloc.Rows
            Dim part = partnumbers.Rows.Find(p.Item("No. de Parte"))
            If part IsNot Nothing Then
                p.Item("Descripcion") = part.Item("Description")
                p.Item("MRP") = part.Item("MRP")
                p.Item("Costo Unitario") = part.Item("UnitCost")
                p.Item("StdPack") = If(part.Item("RoundingValue") = 0, 1, part.Item("RoundingValue"))
                p.Item("Unidad") = part.Item("UoM")
            End If
        Next
        Report_dgv.DataSource = pivot_sloc

        Report_dgv.Columns("No. de Parte").Frozen = True
        Report_dgv.Columns("Costo Unitario").DefaultCellStyle.Format = "\$0.000000"
        Report_dgv.Columns("Contenedores").DefaultCellStyle.Format = "N1"
        Report_dgv.Columns("Total").DefaultCellStyle.Format = "N1"
        Report_dgv.Columns("Total Costo").DefaultCellStyle.Format = "\$0.00"

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
                If Not selected_partnumbers.Contains(Strings.right("00000000" & p.ToString, 8)) Then
                    selected_partnumbers.Add(Strings.right("00000000" & p.ToString, 8))
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
    End Sub

    Private Sub Ord_ABC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub From_dtp_ValueChanged(sender As Object, e As EventArgs) Handles From_dtp.ValueChanged

    End Sub
End Class