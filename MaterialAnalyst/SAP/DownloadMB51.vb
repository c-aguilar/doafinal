Public Class DownloadMB51

    Private Sub DownloadMB51_Run_btn_Click(sender As Object, e As EventArgs) Handles DownloadMB51_Run_btn.Click
        If DownloadMB51_Sloc_cbo.SelectedIndex > -1 AndAlso DownloadMB51_MovType_cbo.SelectedIndex > -1 Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap.MB51(Parameter("SYS_PlantCode"), Partnumber_txt.Text, DownloadMB51_Sloc_cbo.SelectedItem, DownloadMB51_From_dtp.Value, DownloadMB51_To_dtp.Value, DownloadMB51_MovType_cbo.SelectedItem, filename, "/A-ULI2") Then
                    Dim mb51_txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 0)
                    TryDelete(filename)
                    If mb51_txt IsNot Nothing Then
                        mb51_txt.DefaultView.RowFilter = "Material <> '' AND Material IS NOT NULL"
                        Dim mb51 = mb51_txt.DefaultView.ToTable(False, "Material", "MvT", "OUn", "Quantity", "Pstng Date", "Time")
                        mb51.Columns.Add("Quantity_Dbl", GetType(Double), "Convert(Quantity,'System.Double') * IIF(OUn = 'FT',0.3048,IIF(OUn = 'LB',0.453592,1))")
                        If SQL.Current.Upsert(mb51.DefaultView.ToTable(False, "Partnumber", "MvT", "Quantity_Dbl", "Pstng Date", "Time"), "tmpMB51", "CREATE TABLE #tmpMB51 ([Material] [char](8),[Movement] [char](3),[Quantity] [decimal](10, 3),[Date] [varchar](10),[Time] [varchar](10))", String.Format("MERGE Smk_MB51 AS target USING (SELECT Partnumber,Movement,SUM(Quantity) AS Quantity,[Date],[Time] FROM #tmpMB51 GROUP BY Partnumber,Movement,[Date],[Time]) AS source " & _
                                              "ON target.Partnumber = source.Partnumber AND target.Sloc = '{0}' AND target.Movement = source.Movement AND target.[Date] = DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))) " & _
                                              "WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Partnumber,Sloc,Movement,Quantity,[Date]) VALUES (source.Partnumber,'{0}',source.Movement,source.Quantity,DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))));", DownloadMB51_Sloc_cbo.SelectedItem)) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Hecho!")
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error en bulk de datos.")
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al leer el archivo.")
                    End If
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al correr la transaccion.")
                End If
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Sesion de SAP no encontrada.")
            End If
        Else
            FlashAlerts.ShowInformation("Tipo de movimiento y sloc son requeridos.")
        End If
    End Sub

    Private Sub DownloadMB51_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DownloadMB51_To_dtp_ValueChanged(sender As Object, e As EventArgs) Handles DownloadMB51_To_dtp.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DownloadMB51_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class