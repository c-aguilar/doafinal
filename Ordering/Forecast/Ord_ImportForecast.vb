Public Class Ord_ImportForecast
    Dim data As DataTable
    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            ofd.Title = "Abrir Archivo Forecast..."
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Filename_txt.Text = ofd.FileName
                LoadingScreen.Show()
                Dim sheet = SheetSelector.Get(ofd.FileName)
                Dim new_file = GF.TempTXTPath
                If MyExcel.ToTXT(ofd.FileName, new_file, sheet.Trim("'").Trim("$")) Then
                    data = CSV.Datatable(new_file, vbTab, True, True, 0)
                    Save_btn.Enabled = False
                    If data IsNot Nothing Then
                        Forecast_dgv.DataSource = data
                        Save_btn.Enabled = True
                    Else
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                    IO.File.Delete(new_file)
                Else
                    FlashAlerts.ShowError("Error al leer el archivo.")
                End If
            End If
            LoadingScreen.Hide()
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Error al leer el archivo.")
        End Try
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If data IsNot Nothing Then
            LoadingScreen.Show()
            Try
                If data.Columns.Contains("Past Due") AndAlso data.Columns.Contains("Part") Then
                    Dim forecast As New DataTable
                    forecast.Columns.Add("Partnumber")
                    forecast.Columns.Add("Date", GetType(Date))
                    forecast.Columns.Add("Week", GetType(Date))
                    forecast.Columns.Add("Quantity", GetType(Double))

                    Dim first_date As Date = Date.MinValue
                    For i = 1 To data.Columns.Count - 1
                        Dim col_date As Date
                        If Date.TryParse(data.Columns(i).ColumnName, col_date) Then
                            first_date = col_date
                            Exit For
                        End If
                    Next
                    If Not first_date = Date.MinValue Then
                        For i = 1 To data.Columns.Count - 1
                            Dim col_date As Date
                            If Date.TryParse(data.Columns(i).ColumnName, col_date) Then
                                For Each row As DataRow In data.Rows
                                    forecast.Rows.Add(RawMaterial.Format(row.Item("Part")), first_date, col_date, row.Item(i))
                                Next
                            ElseIf data.Columns(i).ColumnName.ToLower = "past due" Then
                                For Each row As DataRow In data.Rows
                                    forecast.Rows.Add(RawMaterial.Format(row.Item("Part")), first_date, first_date.AddDays(-7), row.Item(i))
                                Next
                            End If
                        Next
                        If SQL.Current.Upsert(forecast, "tmpForecast", "CREATE TABLE #tmpForecast ([Partnumber] [char](8) NOT NULL,[Date] [date] NOT NULL,[Week] [date] NOT NULL,[Quantity] [float] NOT NULL)", "MERGE Ord_Forecast AS target USING #tmpForecast AS source ON target.Partnumber = source.Partnumber AND target.[Date] = source.[Date] AND target.[Week] = source.[Week] WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Partnumber,[Date],[Week],Quantity) VALUES (source.Partnumber,source.[Date],source.[Week],source.[Quantity]);") Then
                            LoadingScreen.Hide()
                            Save_btn.Enabled = False
                            FlashAlerts.ShowConfirm("¡Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al guardar.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Estructura del archivo invalida.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Estructura del archivo invalida.")
                End If
            Catch ex As Exception
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al guardar.")
            End Try
        End If
    End Sub

    Private Sub Ord_ImportForecast_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class