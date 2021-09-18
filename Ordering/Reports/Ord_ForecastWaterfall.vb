Public Class Ord_ForecastWaterfall
    Dim selected_partnumbers As New ArrayList
    Dim sb As SearchBox
    Private Sub OrderingForecastWaterfall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Me.Waterfall_dgv)
        From_dtp.Value = LastMonday()
        To_dtp.Value = LastMonday(CurrentDate.AddDays(16 * 7))
        Partnumber_txt.Text = "*"
    End Sub

#Region "Generic Controls"
    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Waterfall_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Waterfall_dgv.DataSource, "Cascada", True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Waterfall_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Waterfall_dgv.DataSource
                        pdf.Title = Title_lbl.Text
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
        If Not IsNothing(Waterfall_dgv.DataSource) Then
            Clipboard.SetDataObject(Waterfall_dgv.GetClipboardContent())
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
    End Sub
#End Region

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Waterfall_dgv.DataSource = Nothing
        LoadingScreen.Show()
        Dim partnumber As String = ""
        If selected_partnumbers.Count > 0 Then
            partnumber = String.Join("','", selected_partnumbers.ToArray)
        Else
            partnumber = Partnumber_txt.Text.Trim
        End If
        Dim forecast As DataTable
        If partnumber = "*" OrElse partnumber = "" Then
            forecast = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],[Date] AS Fecha,[Week] AS Semana,Quantity AS Cantidad FROM Ord_Forecast WHERE [Week] BETWEEN '{0}' AND '{1}' ORDER BY [Date]", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        Else
            forecast = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],[Date] AS Fecha,[Week] AS Semana,Quantity AS Cantidad FROM Ord_Forecast WHERE Partnumber IN ('{0}') AND [Week] BETWEEN '{1}' AND '{2}' ORDER BY [Date]", partnumber, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        End If
        If forecast IsNot Nothing Then
            Dim pivoter As New PivotTable(forecast)
            Dim pivot = pivoter.PivotDates("No. de Parte", "Fecha", "Cantidad", AggregateFunction.First, "Semana", "System.Double")
            pivot.Columns.Add("Past Due", GetType(Double))
            pivot.Columns("Past Due").SetOrdinal(2)
            For Each row As DataRow In pivot.Rows
                For i = 3 To pivot.Columns.Count - 1
                    If CDate(pivot.Columns(i).ColumnName) < CDate(row.Item("Fecha")) AndAlso Not IsDBNull(row.Item(i)) Then
                        row.Item("Past Due") = row.Item(i)
                        row.Item(i) = DBNull.Value
                        Exit For
                    End If
                Next
            Next
            pivot.DefaultView.Sort = "[No. de Parte],Fecha"
            Waterfall_dgv.DataSource = pivot.DefaultView.ToTable
            For Each col As DataGridViewColumn In Waterfall_dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub Waterfall_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Waterfall_dgv.CellFormatting
        If IsDBNull(e.Value) Then
            e.CellStyle.BackColor = Color.LightGray
        End If
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

    Private Sub Ord_ForecastWaterfall_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class