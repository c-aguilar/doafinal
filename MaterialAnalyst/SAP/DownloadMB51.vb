Public Class DownloadMB51

    Private Sub DownloadMB51_Run_btn_Click(sender As Object, e As EventArgs) Handles DownloadMB51_Run_btn.Click
        If DownloadMB51_Sloc_cbo.SelectedIndex > -1 AndAlso DownloadMB51_MovType_cbo.SelectedIndex > -1 Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim filename As String = GF.TempTXTPath





                If sap.MB51(Parameter("SYS_PlantCode"), Partnumber_txt.Text, DownloadMB51_Sloc_cbo.SelectedItem, DownloadMB51_From_dtp.Value, DownloadMB51_To_dtp.Value, DownloadMB51_MovType_cbo.SelectedItem, filename, "COMPARATIVO") Then
                    Dim mb51_txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 0)
                    If mb51_txt IsNot Nothing Then
                        If mb51_txt.Columns.Contains("Material") Then
                            mb51_txt.DefaultView.RowFilter = "Material NOT IN ('','List contains no data','*') AND TRIM(Material) <> '' AND Material IS NOT NULL"
                            If Not mb51_txt.DefaultView.Count = 0 Then
                                Dim mb51_sap = mb51_txt.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "BUn", "Quantity", "Entry Date", "Time", "Pstng Date", "Mat. Doc.")
                                mb51_sap.Columns.Add("Quantity_Dbl", GetType(Double), "Convert(Quantity,'System.Double') * IIF(BUn = 'FT',0.3048,IIF(BUn = 'LB',0.453592,1))")
                                If SQL.Current.Upsert(mb51_sap.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "Quantity_Dbl", "Entry Date", "Time", "Pstng Date", "Mat. Doc."), "tmpMB51", "CREATE TABLE #tmpMB51 ([Partnumber] [varchar](16),[Movement] [char](3),[Sloc] [varchar](5),[Quantity] [decimal](12,3),[Date] [varchar](10),[Time] [varchar](10),[PstngDate] varchar(10),Document char(10))", "MERGE Smk_MB51 AS target USING (SELECT RIGHT('00000000' + Partnumber,8) AS Partnumber,Movement,Sloc,SUM(Quantity) AS Quantity,[Date],[Time],PstngDate,Document FROM #tmpMB51 GROUP BY RIGHT('00000000' + Partnumber,8),Movement,Sloc,[Date],[Time],PstngDate,Document) AS source " & _
                                                      "ON target.Partnumber = source.Partnumber AND target.Sloc = source.Sloc AND target.Movement = source.Movement AND target.Document = source.Document AND target.[Date] = DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))) " & _
                                                      "WHEN MATCHED THEN UPDATE SET Quantity = ROUND(source.Quantity,3) WHEN NOT MATCHED THEN INSERT (Partnumber,Movement,Sloc,Quantity,[Date],PstngDate,[Document]) VALUES (source.Partnumber,source.Movement,source.Sloc,ROUND(source.Quantity,3),DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))),CONVERT(DATE,source.PstngDate),source.Document);") Then
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowConfirm("¡Hecho!")
                                Else
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                        Exit Sub
                    End If
                    TryDelete(filename)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al correr la transaccion.")
                End If
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError(Language.Sentence(267))
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