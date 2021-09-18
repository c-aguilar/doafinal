Public Class Rec_SMSVsMB51
    Dim selected_partnumbers As New List(Of String)
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
            'Dim last_run = SQL.Current.GetDate("SELECT CONVERT(DATETIME,Value) AS D FROM Sys_Parameters WHERE Parameter = 'SYS_MB51Job_LastRunning'")
            'If SAPTo_dtp.Value >= last_run.AddHours(2) Then
            Dim sap As New SAP
            If Not sap.Available Then
                LoadingScreen.Hide()
                MessageBox.Show("Imposible conectar a SAP, valida que tengas la sesion abierta.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ' Exit Sub
            End If
            Dim filename As String = GF.TempTXTPath
            Dim movements As New List(Of String)
            movements.Add("101")
            movements.Add("102")
            movements.Add("934")
            movements.Add("702")

            Dim partnumbers As New List(Of String)
            If selected_partnumbers.Count = 0 Then
                partnumbers.Add(If(Partnumber_txt.Text = "", "*", Partnumber_txt.Text))
            Else
                partnumbers.AddRange(selected_partnumbers)
            End If

            If sap.AQ25ZPACK_INSTR_MM_MSEG(Parameter("SYS_PlantCode"), partnumbers.ToArray, movements.ToArray, SAPFrom_dtp.Value.Date, SAPTo_dtp.Value.Date, filename) Then

                If IO.File.Exists(filename) Then
                    Dim mb51_txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 0)
                    If mb51_txt IsNot Nothing Then
                        Dim mb51dt = mb51_txt.DefaultView.ToTable(False, "MATERIAL", "MOV_TYPE", "SLOC", "BUn", "Quantity", "Entry dte", "Time", "Pstg date", "DOCUMENT_MATERIAL", "User name", "Order", "DEBIT_CREDIT")
                        mb51dt.Columns.Add("Quantity_Dbl", GetType(Decimal), "Convert(Quantity,'System.Double') * IIF(BUn = 'FT',0.3048,IIF(BUn = 'LB',0.453592,1)) * IIF(DEBIT_CREDIT='H',-1.0,1.0)")


                        If Not SQL.Current.Upsert(mb51dt.DefaultView.ToTable(False, "MATERIAL", "MOV_TYPE", "SLOC", "Quantity_Dbl", "Entry dte", "Time", "Pstg date", "DOCUMENT_MATERIAL", "User name", "Order"), "tmpMB51", "CREATE TABLE #tmpMB51 ([Partnumber] [varchar](20),[Movement] [char](3),[Sloc] [varchar](5),[Quantity] [decimal](12,3),[Date] [varchar](10),[Time] [varchar](10),[PstngDate] varchar(10),Document char(10),Username varchar(10), OrderNo varchar(12))", "MERGE Smk_MB51 AS target USING (SELECT RIGHT('00000000' + Partnumber,8) AS Partnumber,Movement,Sloc,SUM(Quantity) AS Quantity,[Date],[Time],PstngDate,Document,Username,OrderNo FROM #tmpMB51 GROUP BY RIGHT('00000000' + Partnumber,8),Movement,Sloc,[Date],[Time],PstngDate,Document,Username,OrderNo) AS source " & _
                                                  "ON target.Partnumber = source.Partnumber AND target.Sloc = source.Sloc AND target.Movement = source.Movement AND target.Document = source.Document AND target.[Date] = DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))) " & _
                                                  "WHEN MATCHED THEN UPDATE SET Quantity = ROUND(source.Quantity,3),Username = source.Username, OrderNo = source.OrderNo WHEN NOT MATCHED THEN INSERT (Partnumber,Movement,Sloc,Quantity,[Date],PstngDate,[Document],Username,OrderNo) VALUES (source.Partnumber,source.Movement,source.Sloc,ROUND(source.Quantity,3),DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))),CONVERT(DATE,source.PstngDate),source.Document,source.Username,source.OrderNo);") Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("No fue posible actualizar la información de SAP.")
                        End If

                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                    End If
                    TryDelete(filename)
                End If
                'Dim mb51_txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 0)
                'If mb51_txt IsNot Nothing Then
                '    If mb51_txt.Columns.Contains("Material") Then
                '        mb51_txt.DefaultView.RowFilter = "Material NOT IN ('','List contains no data','*') AND TRIM(Material) <> '' AND Material IS NOT NULL"
                '        If Not mb51_txt.DefaultView.Count = 0 Then
                '            Dim mb51_sap = mb51_txt.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "BUn", "Quantity", "Entry Date", "Time", "Pstng Date", "Mat. Doc.")
                '            mb51_sap.Columns.Add("Quantity_Dbl", GetType(Double), "Convert(Quantity,'System.Double') * IIF(BUn = 'FT',0.3048,IIF(BUn = 'LB',0.453592,1))")
                '            If SQL.Current.Upsert(mb51_sap.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "Quantity_Dbl", "Entry Date", "Time", "Pstng Date", "Mat. Doc."), "tmpMB51", "CREATE TABLE #tmpMB51 ([Partnumber] [varchar](16),[Movement] [char](3),[Sloc] [varchar](5),[Quantity] [decimal](12,3),[Date] [varchar](10),[Time] [varchar](10),[PstngDate] varchar(10),Document char(10))", "MERGE Smk_MB51 AS target USING (SELECT RIGHT('00000000' + Partnumber,8) AS Partnumber,Movement,Sloc,SUM(Quantity) AS Quantity,[Date],[Time],PstngDate,Document FROM #tmpMB51 GROUP BY RIGHT('00000000' + Partnumber,8),Movement,Sloc,[Date],[Time],PstngDate,Document) AS source " & _
                '                                  "ON target.Partnumber = source.Partnumber AND target.Sloc = source.Sloc AND target.Movement = source.Movement AND target.Document = source.Document AND target.[Date] = DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))) " & _
                '                                  "WHEN MATCHED THEN UPDATE SET Quantity = ROUND(source.Quantity,3) WHEN NOT MATCHED THEN INSERT (Partnumber,Movement,Sloc,Quantity,[Date],PstngDate,[Document]) VALUES (source.Partnumber,source.Movement,source.Sloc,ROUND(source.Quantity,3),DATEADD(S,DATEPART(S,CONVERT(TIME,source.[Time])),DATEADD(MI,DATEPART(MI,CONVERT(TIME,source.[Time])),DATEADD(HH,DATEPART(HH,CONVERT(TIME,source.[Time])),CONVERT(DATETIME,source.[Date])))),CONVERT(DATE,source.PstngDate),source.Document);") Then

                '            Else
                '                LoadingScreen.Hide()
                '                FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                '                'CSV.SaveAs(mb51_sap.DefaultView.ToTable(False, "Material", "MvT", "SLoc", "Quantity_Dbl", "Entry Date", "Time", "Pstng Date", "Mat. Doc."), True)
                '                Exit Sub
                '            End If
                '        End If
                '    End If
                'Else
                '    LoadingScreen.Hide()
                '    FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                '    Exit Sub
                'End If
                'TryDelete(filename)
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("No fue posible descargar la información de SAP.")
                ' Exit Sub
            End If
            'End If

            Dim sum_etiquetados As DataTable
            Dim mb51 As DataTable
            Dim tracker As DataTable
            Dim unit_costs As DataTable
            If selected_partnumbers.Count > 0 Then
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],R.Description AS Descripcion,SUM(Quantity) AS Cantidad,UoM AS Unidad FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE M.Partnumber IN ('{4}') AND (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}') GROUP BY M.Partnumber,R.UoM,R.Description;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento,Sloc,M.Document AS Documento,Fullname AS Usuario FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber LEFT OUTER JOIN Sys_Users AS U ON M.Username = U.Username WHERE (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND M.Partnumber IN ('{4}') AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}');", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd"), String.Join("','", selected_partnumbers.ToArray)), "MB51")
                'mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento,M102.Sloc FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE  Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE  M101.Partnumber IN ('{2}') AND M101.[Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,R.Description,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM  FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND S.Partnumber IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM,R.Description;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)))
                series = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,Serialnumber AS Serie,OriginalQuantity AS StdPack,UoM,OriginalQuantityInBuM AS Cantidad,BuM,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND Partnumber IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), String.Join("','", selected_partnumbers.ToArray)), "Series")
                tracker = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(OriginalQuantityInBuM) AS Quantity,BuM FROM vw_Smk_Serials WHERE Partnumber IN ('{0}') AND InvoiceTrouble = 1 AND Status <> 'D' GROUP BY Partnumber,BuM;", String.Join("','", selected_partnumbers.ToArray)))
                unit_costs = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,UnitCost FROM Sys_RawMaterial WHERE Partnumber IN ('{0}');", String.Join("','", selected_partnumbers.ToArray)))
            ElseIf Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "" Then
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],R.Description AS Descripcion,SUM(Quantity) AS Cantidad,UoM AS Unidad FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERe (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}') GROUP BY M.Partnumber,R.UoM,R.Description;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd")), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento,Sloc,M.Document AS Documento,Fullname AS Usuario FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber LEFT OUTER JOIN Sys_Users AS U ON M.Username = U.Username WHERE  (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}');", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd")), "MB51")
                'mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento,M102.Sloc FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE  Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity,Movement ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE  Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE  M101.[Date] BETWEEN '{0}' AND '{1}';", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,R.Description,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM,R.Description;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")))
                series = SQL.Current.GetDatatable(String.Format("SELECT PartNumber,SerialNumber AS Serie,OriginalQuantity AS StdPack,UoM,OriginalQuantityInBuM AS Cantidad,BuM,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "Series")
                tracker = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(OriginalQuantityInBuM) AS Quantity,BuM FROM vw_Smk_Serials WHERE InvoiceTrouble = 1 AND Status <> 'D' GROUP BY Partnumber,BuM;"))
                unit_costs = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,UnitCost FROM Sys_RawMaterial;"))
            Else
                mb51 = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],R.Description AS Descripcion,SUM(Quantity) AS Cantidad,UoM AS Unidad FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE M.Partnumber = '{4}' AND (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}') GROUP BY M.Partnumber,R.UoM,R.Description;", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim), "MB51")
                mb51_details = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,Movement AS Movimiento,Sloc,M.Document AS Documento,Fullname AS Usuario FROM Smk_MB51 AS M INNER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber LEFT OUTER JOIN Sys_Users AS U ON M.Username = U.Username WHERE  (Movement IN ('101','102','934') OR (Movement = '702' AND Sloc = 'SRCI')) AND M.Partnumber = '{4}' AND ([Date] BETWEEN '{0}' AND '{1}') AND (PstngDate BETWEEN '{2}' AND '{3}')", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPFrom_dtp.Value.ToString("yyyy-MM-dd"), SAPTo_dtp.Value.ToString("yyyy-MM-dd"), Partnumber_txt.Text.Trim), "MB51")
                'mb51_details.Merge(SQL.Current.GetDatatable(String.Format("SELECT M102.Partnumber,M102.Quantity AS Cantidad,UoM AS Unidad,M102.[Date] AS Fecha,M102.Movement AS Movimiento,M102.Sloc FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE  Movement = '101') AS M101 INNER JOIN (SELECT *,ROW_NUMBER() OVER(PARTITION BY Partnumber,PstngDate,Quantity ORDER BY [Date] ASC) AS row FROM Smk_MB51 WHERE  Movement = '102') AS M102 ON M101.Partnumber = M102.Partnumber AND M101.Movement = '101' AND M101.PstngDate = M102.PstngDate AND M101.Quantity = ABS(M102.Quantity) AND M101.row = M102.row INNER JOIN Sys_RawMaterial AS R ON M101.Partnumber = R.Partnumber WHERE  M101.Partnumber = '{2}' AND M101.[Date] BETWEEN '{0}' AND '{1}'", SAPFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), SAPTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text.Trim), "MB51"))
                sum_etiquetados = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,R.Description,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) AS Quantity,R.UoM FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND S.Partnumber = '{2}' AND [Date] BETWEEN '{0}' AND '{1}' GROUP BY S.Partnumber,R.UoM,R.Description;", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text.Trim))
                series = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,Serialnumber AS Serie,OriginalQuantity AS StdPack,UoM,OriginalQuantityInBuM AS Cantidad,BuM,StatusDescription AS Estatus,[Date] AS Fecha,TruckNumber AS Troca,Container AS Contenedor,WarehouseName AS Estacion FROM vw_Smk_Serials WHERE [New] = 1 AND Status <> 'D' AND InvoiceTrouble = 0 AND Partnumber = '{2}' AND [Date] BETWEEN '{0}' AND '{1}';", DeltaFrom_dtp.Value.ToString("yyyy-MM-dd HH:mm"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd HH:mm"), Partnumber_txt.Text.Trim), "Series")
                tracker = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,SUM(OriginalQuantityInBuM) AS Quantity,BuM FROM vw_Smk_Serials WHERE Partnumber IN ('{0}') AND InvoiceTrouble = 1 AND Status <> 'D' GROUP BY Partnumber,BuM;", Partnumber_txt.Text.Trim))
                unit_costs = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,UnitCost FROM Sys_RawMaterial WHERE Partnumber = '{0}';", Partnumber_txt.Text.Trim))
            End If
            mb51_details.DefaultView.Sort = "Fecha"
            series.DefaultView.Sort = "Fecha"
            unit_costs.PrimaryKey = {unit_costs.Columns("Partnumber")}

            Dim dt As New DataTable
            dt.Columns.Add("No. de Parte")
            dt.Columns.Add("Descripcion")
            dt.Columns.Add("C.U", GetType(Decimal))
            dt.Columns.Add("Pagado", GetType(Decimal))
            dt.Columns.Add("Etiquetado", GetType(Decimal))
            dt.Columns.Add("Diferencia", GetType(Decimal), "Pagado - Etiquetado")
            dt.Columns.Add("Diferencia $$", GetType(Decimal), "Diferencia * [C.U]")
            dt.Columns.Add("Tracker", GetType(Decimal))
            dt.Columns.Add("UOM")
            dt.PrimaryKey = {dt.Columns("No. de Parte")}


            For Each m As DataRow In mb51.Rows
                Dim cu As DataRow = unit_costs.Rows.Find(m.Item("No. de Parte"))
                If cu IsNot Nothing Then
                    dt.Rows.Add(m.Item("No. de Parte"), m.Item("Descripcion"), cu.Item("UnitCost"), m.Item("Cantidad"), 0, 0, 0, 0, m.Item("Unidad"))
                Else
                    dt.Rows.Add(m.Item("No. de Parte"), m.Item("Descripcion"), 0, m.Item("Cantidad"), 0, 0, 0, 0, m.Item("Unidad"))
                End If
            Next
            For Each etiquetado As DataRow In sum_etiquetados.Rows
                Dim pagado = dt.Rows.Find(etiquetado.Item("Partnumber"))
                If pagado Is Nothing Then
                    Dim cu As DataRow = unit_costs.Rows.Find(etiquetado.Item("Partnumber"))
                    If cu IsNot Nothing Then
                        dt.Rows.Add(etiquetado.Item("PartNumber"), etiquetado.Item("Description"), cu.Item("UnitCost"), 0, etiquetado.Item("Quantity"), 0, 0, 0, etiquetado.Item("UOM"))
                    Else
                        dt.Rows.Add(etiquetado.Item("PartNumber"), etiquetado.Item("Description"), 0, 0, etiquetado.Item("Quantity"), 0, 0, 0, etiquetado.Item("UOM"))
                    End If
                Else
                    pagado.Item("Etiquetado") = etiquetado.Item("Quantity")
                End If
            Next
            For Each tkr As DataRow In tracker.Rows
                Dim row = dt.Rows.Find(tkr.Item("Partnumber"))
                If row IsNot Nothing Then
                    row.Item("Tracker") = tkr.Item("Quantity")
                    'Else
                    '    dt.Rows.Add(tkr.Item("Partnumber"), "", 0, 0, 0, tkr.Item("Quantity"), tkr.Item("BuM"))
                End If
            Next
            dt.TableName = "Comparativo"
            Result_dgv.DataSource = dt
            Paid_dgv.DataSource = Nothing
            Labeled_dgv.DataSource = Nothing
            ByDate_dgv.DataSource = Nothing
            Tracker_dgv.DataSource = Nothing
            Partnumber_lbl.Text = ""
            lblPaid.Text = ""
            lblLabeled.Text = ""
            lblUOM.Text = ""
            Difference_lbl.Text = ""
            Tracker_lbl.Text = ""
            Result_dgv.Columns("C.U").DefaultCellStyle.Format = "C5"
            Result_dgv.Columns("Diferencia $$").DefaultCellStyle.Format = "C2"
            Result_dgv.Columns("details_btn").DisplayIndex = 9
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
            Partnumber_lbl.Text = Result_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value
            Description_txt.Text = Result_dgv.Rows(e.RowIndex).Cells("Descripcion").Value
            lblPaid.Text = Result_dgv.Rows(e.RowIndex).Cells("Pagado").Value
            lblLabeled.Text = Result_dgv.Rows(e.RowIndex).Cells("Etiquetado").Value
            lblUOM.Text = Result_dgv.Rows(e.RowIndex).Cells("UOM").Value
            Difference_lbl.Text = Result_dgv.Rows(e.RowIndex).Cells("Diferencia").Value
            mb51_details.DefaultView.RowFilter = String.Format("[No. de Parte] = '{0}'", Result_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value)
            series.DefaultView.RowFilter = String.Format("Partnumber = '{0}'", Result_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value)
            Paid_dgv.DataSource = mb51_details.DefaultView.ToTable(False, "Fecha", "Movimiento", "Sloc", "Cantidad", "Unidad", "Documento", "Usuario")
            Labeled_dgv.DataSource = series.DefaultView.ToTable(False, "Fecha", "Serie", "Cantidad", "BuM", "Estatus", "Troca", "StdPack", "UoM")
            Tracker_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber AS Serie, OriginalQuantityInBuM AS Cantidad,BuM,[Date] AS Fecha,TruckNumber AS Troca FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND InvoiceTrouble = 1 AND Status <> 'D';", Result_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value))
            Tracker_lbl.Text = SQL.Current.GetScalar(String.Format("SELECT SUM(OriginalQuantityInBuM) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND InvoiceTrouble = 1 AND Status <> 'D';", Result_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value))
            Dim dates As New DataTable
            dates.Columns.Add("Fecha", GetType(Date))
            dates.Columns.Add("Diferencia", GetType(Decimal))
            dates.PrimaryKey = {dates.Columns("Fecha")}
            For Each row As DataRowView In mb51_details.DefaultView
                Dim date_row As DataRow = dates.Rows.Find(CDate(row.Item("Fecha")).Date)
                If date_row IsNot Nothing Then
                    date_row.Item("Diferencia") += row.Item("Cantidad")
                Else
                    dates.Rows.Add(CDate(row.Item("Fecha")).Date, row.Item("Cantidad"))
                End If
            Next
            For Each row As DataRowView In series.DefaultView
                Dim date_row As DataRow = dates.Rows.Find(CDate(row.Item("Fecha")).Date)
                If date_row IsNot Nothing Then
                    date_row.Item("Diferencia") -= row.Item("Cantidad")
                Else
                    dates.Rows.Add(CDate(row.Item("Fecha")).Date, -row.Item("Cantidad"))
                End If
            Next
            dates.DefaultView.Sort = "Fecha"
            ByDate_dgv.DataSource = dates.DefaultView
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
End Class