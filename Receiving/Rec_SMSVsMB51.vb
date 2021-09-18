Public Class Rec_SMSVsMB51
    Dim selected_partnumbers As New ArrayList
    Dim series As DataTable
    Dim mb51_details As DataTable
    Private Sub F_SMSVsMB51_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Partnumber_txt.Text = "*"
        'SAPTo_dtp.MaxDate = Now.AddHours(2)
        'SAPFrom_dtp.MaxDate = Now.AddHours(2)
        'DeltaFrom_dtp.MaxDate = Now
        'DeltaTo_dtp.MaxDate = Now
        CType(Result_dgv.Columns("details_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.arrow_right_16
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Try
            LoadingScreen.Show()
            If SAPTo_dtp.Value > Now.AddHours(2).AddMinutes(3) Then
                SAPTo_dtp.Value = Now.AddHours(2).AddMinutes(3)
            End If
            If SAPFrom_dtp.Value > Now.AddHours(2).AddMinutes(3) Then
                SAPFrom_dtp.Value = Now.AddHours(2).AddMinutes(3)
            End If
            Dim last_run = SQL.Current.GetDate("SELECT CONVERT(DATETIME,Value) AS D FROM Sys_Parameters WHERE Parameter = 'SYS_MB51Job_LastRunning'")
            If SAPTo_dtp.Value.AddMinutes(-5) > last_run.AddHours(2) Then
                Dim sap As New SAP
                If Not sap.Available Then
                    LoadingScreen.Hide()
                    MessageBox.Show("Imposible conectar a SAP, valida que tengas la sesion abierta.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                Dim filename As String = IO.Path.Combine(IO.Path.GetTempPath, Now.ToString("yymmddhhmmss") & ".txt")
                If sap.MB51(Parameter("SYS_PlantCode"), "*", "0001", last_run, SAPTo_dtp.Value.Date, "*", filename, "COMPARATIVO") Then
                    Dim mb51_txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 0)
                    If mb51_txt IsNot Nothing Then
                        If mb51_txt.Columns.Contains("Material") Then
                            mb51_txt.DefaultView.RowFilter = "Material NOT IN ('','List contains no data') AND Material IS NOT NULL"
                            If Not mb51_txt.DefaultView.Count = 0 Then
                                Dim mb51_sap = mb51_txt.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "BUn", "Quantity", "Entry Date", "Time", "Pstng Date", "Mat. Doc.")
                                mb51_sap.Columns.Add("Quantity_Dbl", GetType(Double), "Convert(Quantity,'System.Double') * IIF(BUn = 'FT',0.3048,IIF(BUn = 'LB',0.453592,1))")
                                If SQL.Current.Upsert(mb51_sap.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "Quantity_Dbl", "Entry Date", "Time", "Pstng Date", "Mat. Doc."), "tmpMB51", "CREATE TABLE #tmpMB51 ([Partnumber] [varchar](8),[Movement] [char](3),[Sloc] [varchar](5),[Quantity] [decimal](12,3),[Date] [varchar](10),[Time] [varchar](10),[PstngDate] varchar(10),Document char(10))", "MERGE Smk_MB51 AS target USING (SELECT RIGHT('00000000' + Partnumber,8) AS Partnumber,Movement,Sloc,SUM(Quantity) AS Quantity,[Date],[Time],PstngDate,Document FROM #tmpMB51 GROUP BY RIGHT('00000000' + Partnumber,8),Movement,Sloc,[Date],[Time],PstngDate,Document) AS source " & _
                                                      "ON target.Partnumber = source.Partnumber AND target.Sloc = source.Sloc AND target.Movement = source.Movement AND target.Document = source.Document AND target.[Date] = DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))) " & _
                                                      "WHEN MATCHED THEN UPDATE SET Quantity = ROUND(source.Quantity,3) WHEN NOT MATCHED THEN INSERT (Partnumber,Movement,Sloc,Quantity,[Date],PstngDate,[Document]) VALUES (source.Partnumber,source.Movement,source.Sloc,ROUND(source.Quantity,3),DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))),CONVERT(DATE,source.PstngDate),source.Document);") Then

                                Else
                                    LoadingScreen.Hide()
                                    FlashAlerts.ShowError("No fue posible descargar la informacion de SAP.")
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible descargar la informacion de SAP.")
                        Exit Sub
                    End If
                    TryDelete(filename)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("No fue posible descargar la informacion de SAP.")
                    Exit Sub
                End If
            End If

            Dim sum_etiquetados As DataTable
            Dim mb51 As DataTable
            If selected_partnumbers.Count > 0 Then
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M101.Partnumber,SUM(M101.Quantity+ISNULL(M102.Quantity,0)) AS Cantidad,UoM AS Unidad FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement IN ('101','701')) AS M101 LEFT OUTER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.Movement IN ('101','701') AND M101.Partnumber IN ('{2}') AND M101.[Date] BETWEEN '{0}' AND '{1}' GROUP BY M101.Partnumber,R.UoM;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber,Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE Sloc = '0001' AND Movement IN ('101','701') AND M.Partnumber IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "MB51")
                mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.Partnumber IN ('{2}') AND M101.[Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM  FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND S.Partnumber IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)))
                series = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,Serialnumber AS Serie,OriginalQuantity AS StdPack,UoM AS Unidad,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND Partnumber IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "Series")
            ElseIf Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "" Then
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M101.Partnumber,SUM(M101.Quantity+ISNULL(M102.Quantity,0)) AS Cantidad,UoM AS Unidad FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement IN ('101','701')) AS M101 LEFT OUTER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.Movement IN ('101','701') AND M101.[Date] BETWEEN '{0}' AND '{1}' GROUP BY M101.Partnumber,R.UoM;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber,Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE Sloc = '0001' AND Movement IN ('101','701') AND [Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "MB51")
                mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity,Movement ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.[Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")))
                series = SQL.Current.GetDatatable(String.Format("SELECT PartNumber,SerialNumber AS Serie,OriginalQuantity AS StdPack,UoM AS Unidad,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "Series")
            Else
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M101.Partnumber,SUM(M101.Quantity+ISNULL(M102.Quantity,0)) AS Cantidad,UoM AS Unidad FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement IN ('101','701')) AS M101 LEFT OUTER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.Movement IN ('101','701') AND M101.Partnumber = '{2}' AND M101.[Date] BETWEEN '{0}' AND '{1}' GROUP BY M101.Partnumber,R.UoM;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber,Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE Sloc = '0001' AND Movement IN ('101','701') AND M.Partnumber = '{2}' AND [Date] BETWEEN '{0}' AND '{1}'", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text), "MB51")
                mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Sloc =  '0001' AND Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE M101.Sloc = '0001' AND M101.Partnumber = '{2}' AND M101.[Date] BETWEEN '{0}' AND '{1}'", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND S.Partnumber = '{2}' AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text))
                series = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,Serialnumber AS Serie,OriginalQuantity AS StdPack,UoM AS Unidad,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND Partnumber = '{2}' AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text), "Series")
            End If

            Dim dt As New DataTable
            dt.Columns.Add("Partnumber")
            dt.Columns.Add("Pagado", GetType(Double))
            dt.Columns.Add("Etiquetado", GetType(Double))
            dt.Columns.Add("Diferencia", GetType(Double), "Pagado - Etiquetado")
            dt.Columns.Add("UOM")
            dt.PrimaryKey = {dt.Columns("Partnumber")}


            For Each m As DataRow In mb51.Rows
                dt.Rows.Add(m.Item("Partnumber"), m.Item("Cantidad"), 0, 0, m.Item("Unidad"))
            Next
            For Each etiquetado As DataRow In sum_etiquetados.Rows
                Dim pagado = dt.Rows.Find(etiquetado.Item("Partnumber"))
                If pagado Is Nothing Then
                    dt.Rows.Add(etiquetado.Item("PartNumber"), 0, etiquetado.Item("Quantity"), 0, etiquetado.Item("UOM"))
                Else
                    pagado.Item("Etiquetado") = etiquetado.Item("Quantity")
                End If
            Next
            dt.TableName = "Comparativo"
            Result_dgv.DataSource = dt
            Paid_dgv.DataSource = Nothing
            Labeled_dgv.DataSource = Nothing
            lblPartnumber.Text = ""
            lblPaid.Text = ""
            lblLabeled.Text = ""
            lblUOM.Text = ""
            Result_dgv.Columns("details_btn").DisplayIndex = 5
            LoadingScreen.Hide()
        Catch ex As Exception
            LoadingScreen.Hide()
            MsgBox("Error inesperado:" & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If MyExcel.SaveAs({Result_dgv.DataSource, mb51_details, series}, True) Then
            FlashAlerts.ShowInformation("Exportado!")
        End If
    End Sub

    Private Sub dgvResult_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Result_dgv.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.RowIndex > -1 AndAlso e.ColumnIndex = Result_dgv.Columns("details_btn").Index Then
            Labeled_dgv.DataSource = Nothing
            Paid_dgv.DataSource = Nothing
            lblPartnumber.Text = Result_dgv.Rows(e.RowIndex).Cells("Partnumber").Value
            lblPaid.Text = Result_dgv.Rows(e.RowIndex).Cells("Pagado").Value
            lblLabeled.Text = Result_dgv.Rows(e.RowIndex).Cells("Etiquetado").Value
            lblUOM.Text = Result_dgv.Rows(e.RowIndex).Cells("UOM").Value
            mb51_details.DefaultView.RowFilter = String.Format("Partnumber = '{0}'", Result_dgv.Rows(e.RowIndex).Cells("Partnumber").Value)
            series.DefaultView.RowFilter = String.Format("Partnumber = '{0}'", Result_dgv.Rows(e.RowIndex).Cells("Partnumber").Value)
            Paid_dgv.DataSource = mb51_details.DefaultView
            Labeled_dgv.DataSource = series.DefaultView
            tcMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub Rec_SMSVsMB51_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
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
    End Sub
End Class