Public Class CR
    Public Shared Sub GetMaterialListBOM()
        Dim ld As New ListDialog
        ld.Title = "Nos. de Material"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If ld.Items.Count > 0 Then
                LoadingScreen.Show()
                Dim bom = CR.GetBOM(ld.Items)
                Select Case CR.UpdateBOM(bom)
                    Case CR.BOMResult.OK
                        FlashAlerts.ShowConfirm("BOM actualizado correctamente.")
                    Case CR.BOMResult.OKWithMissings
                        FlashAlerts.ShowInformation("BOM actualizado correctamente pero existen componentes nuevos que no pudieron ser cargados.", 10)
                    Case CR.BOMResult.ErrorOnSave
                        FlashAlerts.ShowError("Error al guardar el BOM.")
                    Case CR.BOMResult.ErroOnDownload
                        FlashAlerts.ShowError("Error al descargar la información del BOM.")
                End Select
                LoadingScreen.Hide()
            End If
        End If
        ld.Dispose()
    End Sub

    Public Shared Function GetBOM(materials As ArrayList) As DataTable
        Dim filename As String = GF.TempTXTPath
        Dim sap As New SAP
        If sap.Available Then
            If sap.ZCS12(Parameter("SYS_PlantCode"), materials, filename) Then 'DESCARGAR BOM
                Dim txt = CSV.Datatable(filename, vbTab, True, True, 1)
                If txt IsNot Nothing Then
                    txt.DefaultView.RowFilter = "[Column2] = '.1'"
                    Dim components = txt.DefaultView.ToTable(False, "Material", "Component", "Qty (BUn)", "BUn")
                    For Each row As DataRow In components.Rows 'LAS TINTAS Y SOLDADURA ESTABAN SALIENDO CON CANTIDAD EN 0 EN ALGUNAS OCASIONES DEBIDO A LA CANTIDAD TAN PEQUEñA DECLARA EN SAP
                        If CDec(row.Item("Qty (BUn)")) = 0 AndAlso (row.Item("BUn") = "KG" OrElse row.Item("BUn") = "L") Then
                            row.Item("Qty (BUn)") = 0.001
                        End If
                    Next
                    Dim e99 = txt.Select("MRPCn = 'E99'")
                    If e99.Length > 0 Then
                        Dim e99_list As New ArrayList
                        For Each e As DataRow In e99
                            If Not e99_list.Contains(e.Item("Component")) AndAlso components.Compute("COUNT(Material)", String.Format("Material = '{0}'", e.Item("Component"))) = 0 Then
                                e99_list.Add(e.Item("Component"))
                            End If
                        Next
                        If e99_list.Count > 0 Then
                            Dim e99_bom = GetBOM(e99_list)
                            If e99_bom IsNot Nothing Then
                                components.Merge(e99_bom)
                                Return components
                            Else
                                Return Nothing
                            End If
                        Else
                            Return components
                        End If
                    Else
                        Return components
                    End If
                Else
                    Return Nothing
                End If
                TryDelete(filename)
            Else
                Return Nothing
            End If
        Else
            FlashAlerts.ShowError("Ninguna sesion de SAP encontrada.")
            Return Nothing
        End If
    End Function

    Public Shared Function UpdateMaterialListBOM(material_list As ArrayList) As BOMResult
        Dim bom = CR.GetBOM(material_list)
        Return CR.UpdateBOM(bom)
    End Function
    Public Shared Function UpdateBOM(BOM As DataTable) As BOMResult
        If BOM IsNot Nothing Then 'DESCARGAR BOM
            If SQL.Current.Upsert(BOM, "tmpBOM", "CREATE TABLE #tmpBOM ([Material] [varchar](8) NOT NULL,[Partnumber] [varchar](8) NOT NULL,[Quantity] [decimal](9, 3) NOT NULL,[UoM] [varchar](2) NOT NULL)", "INSERT INTO Sys_BOM (Material,Partnumber,Quantity) SELECT B.Material,RIGHT('0000' + B.Partnumber,8) AS PN,B.Quantity FROM #tmpBOM AS B WHERE B.Material NOT IN (SELECT DISTINCT Material FROM Sys_BOM); INSERT INTO Sys_BOMChanges (Material,Partnumber,Quantity) SELECT N.Material,RIGHT('0000' + N.Partnumber,8),N.Quantity FROM #tmpBOM AS N LEFT OUTER JOIN Sys_BOM AS B ON N.Material = B.Material AND RIGHT('0000' + N.Partnumber,8) = B.Partnumber WHERE B.Material IS NULL; INSERT INTO Sys_BOM (Material,Partnumber,Quantity) SELECT N.Material,RIGHT('0000' + N.Partnumber,8) AS NP,0 FROM #tmpBOM AS N LEFT OUTER JOIN Sys_BOM AS B ON N.Material = B.Material AND RIGHT('0000' + N.Partnumber,8) = B.Partnumber WHERE B.Material IS NULL; INSERT INTO Sys_BOMChanges (Material,Partnumber,Quantity) SELECT N.Material,RIGHT('0000' + N.Partnumber,8),N.Quantity - B.Quantity FROM #tmpBOM AS N INNER JOIN vw_Sys_BOM_Stg0 AS B ON N.Material = B.Material AND RIGHT('0000' + N.Partnumber,8) = B.Partnumber WHERE N.Quantity <> B.Quantity; INSERT INTO Sys_BOMChanges (Material,Partnumber,Quantity) SELECT B.Material,B.Partnumber,-B.Quantity FROM vw_Sys_BOM_Stg0 AS B LEFT OUTER JOIN #tmpBOM AS N ON N.Material = B.Material AND RIGHT('0000' + N.Partnumber,8) = B.Partnumber WHERE N.Material IS NULL AND B.Quantity > 0 AND B.Material IN (SELECT DISTINCT Material FROM #tmpBOM);") Then
                'VALIDAR SI HAY COMPONENTES NUEVOS QUE NO ESTEN EN LA TABLA SYS_RAWMATERIAL
                Dim new_partnumbers = SQL.Current.GetList("SELECT DISTINCT B.Partnumber FROM vw_Sys_BOM_Stg2 AS B LEFT OUTER JOIN Sys_RawMaterial AS R ON B.Partnumber = R.Partnumber WHERE R.Partnumber IS NULL")
                Dim plants As New ArrayList
                plants.Add(Parameter("SYS_PlantCode"))
                If new_partnumbers.Count > 0 Then 'HAY COMPONENTES NUEVOS
                    Dim filename As String = GF.TempTXTPath
                    Dim sap As New SAP
                    If sap.Available AndAlso sap.AQ25ZPACK_INSTR_MM_MARC_ALL(plants, new_partnumbers, filename) Then 'DESCARGAR Y ACTUALIZAR
                        Dim txt = CSV.Datatable(filename, vbTab, True, False)
                        If txt IsNot Nothing Then
                            txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                            txt.Columns.Add("DBL_RV", GetType(Double), "Convert([ROUNDING_VALUE],'System.Double')")
                            txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")

                            Dim all_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER")
                            Dim bulk_data As New DataTable
                            bulk_data.Columns.Add("RT_MATERIAL")
                            bulk_data.Columns.Add("DESCRIPTION")
                            bulk_data.Columns.Add("BUM")
                            bulk_data.Columns.Add("DBL_RV", GetType(Double))
                            bulk_data.Columns.Add("UNIT_PRICE", GetType(Decimal))
                            bulk_data.Columns.Add("MRP_CONTROLLER")

                            bulk_data.Merge(all_data.DefaultView.ToTable(True, "RT_MATERIAL"))
                            For Each row As DataRow In bulk_data.Rows
                                Dim rows = all_data.Select(String.Format("RT_MATERIAL = '{0}'", row.Item("RT_MATERIAL")))
                                row.Item("DESCRIPTION") = rows(0).Item("DESCRIPTION")
                                row.Item("BUM") = rows(0).Item("BUM")
                                row.Item("DBL_RV") = rows(0).Item("DBL_RV")
                                row.Item("UNIT_PRICE") = rows(0).Item("UNIT_PRICE")
                                row.Item("MRP_CONTROLLER") = rows(0).Item("MRP_CONTROLLER")
                            Next

                            Dim mrps As DataTable = bulk_data.DefaultView.ToTable(True, "MRP_CONTROLLER")
                            SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Ord_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")

                            If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial ([Partnumber] [varchar](8) NOT NULL,[Description] [varchar](150) NULL,[UoM] [varchar](2) NOT NULL,[RoundingValue] [float] NOT NULL,[UnitCost] [decimal](10, 7) NOT NULL,[MRP] [varchar](5))", "MERGE Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.Partnumber = source.Partnumber WHEN MATCHED THEN UPDATE SET [Description] = source.[Description],RoundingValue = source.RoundingValue,UnitCost = source.UnitCost,target.MRP = source.MRP, target.UoM = source.UoM WHEN NOT MATCHED THEN INSERT (Partnumber,[Description],UoM,RoundingValue,UnitCost,MRP,OrderUnit) VALUES (source.Partnumber,source.[Description],source.UoM,source.RoundingValue,source.UnitCost,source.MRP,source.UoM);") Then
                                Return BOMResult.OK
                            Else
                                Return BOMResult.OKWithMissings
                            End If
                        Else
                            Return BOMResult.OKWithMissings
                        End If
                        Delta.TryDelete(filename)
                    Else
                        Return BOMResult.OKWithMissings
                    End If
                Else
                    Return BOMResult.OK
                End If
            Else
                Return BOMResult.ErrorOnSave
            End If
        Else
            Return BOMResult.ErroOnDownload
        End If
    End Function
    Public Enum BOMResult
        OK
        OKWithMissings
        ErroOnDownload
        ErrorOnSave
    End Enum

End Class
