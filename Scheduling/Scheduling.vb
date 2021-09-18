Public Class SCH
    Public Shared Sub DownloadVL10()
        If Not SQL.Current.Exists("SELECT TOP 1 ID FROM Sch_VL10 WHERE DATEPART(WK, DownloadDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY, DownloadDate) = DATEPART(YY,GETDATE())") Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath

                If sap_session.VL10({Parameter("SCH_ShippingPoint"), Parameter("SYS_PlantCode")}, CurrentDate.AddDays(16 * 7), filename) Then
                    Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False)
                    TryDelete(filename)
                    If txt IsNot Nothing Then
                        txt.DefaultView.RowFilter = String.Format("[Plnt] = '{0}'", Parameter("SYS_PlantCode"))
                        txt.Columns.Add("New_DD", GetType(Date), "Convert(IIF([Deliv.Date] = '',[Deliv.Date_1],[Deliv.Date]),'System.DateTime')")
                        txt.Columns.Add("New_OQ", GetType(Integer), "IIF(Convert([Dlv.qty],'System.Double') = 0, Convert([Open qty],'System.Double'), Convert([Dlv.qty],'System.Double'))")
                        Dim vl10 = txt.DefaultView.ToTable(False, "Material", "Cust.mat.", "OriginDoc.", "SD Doc.", "Description", "Name 1", "Ship-to", "New_DD", "New_OQ")
                        If SQL.Current.Bulk(vl10, "Sch_VL10") Then
                            SQL.Current.Execute("INSERT INTO Sch_Business (Family,Business,MRP) Select DISTINCT 'Unclassified',V.BusinessName,'None' " & _
                                                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL")
                            SQL.Current.Execute("INSERT INTO Sch_Materials (Material,CustomerPN,[Description],Business,StdPack,StartProduction,EndProduction,Class) " & _
                                                "SELECT V.Material,MIN(V.CustomerMaterial),MIN(V.[Description]),MIN(V.BusinessName),1,'1900-01-01','2099-12-31','NO CLASS' " & _
                                                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL " & _
                                                "GROUP BY V.Material")
                            LoadingScreen.Hide()
                            MsgBox("VL10 actualizada correctamente!", MsgBoxStyle.Information, APP)
                        Else
                            LoadingScreen.Hide()
                            MsgBox("Error en bulk de VL10.", MsgBoxStyle.Critical, APP)
                        End If
                    Else
                        LoadingScreen.Hide()
                        MsgBox("Error al leer el archivo.", MsgBoxStyle.Critical, APP)
                    End If
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar la VL10.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("VL10 ya se encuentra actualizada.", MsgBoxStyle.Information)
        End If
    End Sub


    Public Shared Sub ImportVL10(filename As String, download_date As Date)
        LoadingScreen.Show()
        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False)
        If txt IsNot Nothing Then
            'txt.DefaultView.RowFilter = String.Format("[Plnt] = '{0}'", Parameter("SYS_PlantCode"))
            Dim cust_mat_col As String = "Cust.material"
            If txt.Columns.Contains("Cust.mat.") Then cust_mat_col = "Cust.mat."
            txt.DefaultView.RowFilter = "Material <> ''"
            txt.Columns.Add("New_DD", GetType(Date), "Convert(IIF([Deliv.Date] = '',[Deliv.Date_1],[Deliv.Date]),'System.DateTime')")
            txt.Columns.Add("New_OQ", GetType(Integer), "IIF(Convert([Dlv.qty],'System.Double') = 0, Convert([Open qty],'System.Double'), Convert([Dlv.qty],'System.Double'))")
            txt.Columns.Add("DownloadDate", GetType(Date), String.Format("#{0}#", download_date.ToString))
            Dim vl10 = txt.DefaultView.ToTable(False, "Material", cust_mat_col, "OriginDoc.", "SD Doc.", "Description", "Name 1", "Ship-to", "New_DD", "New_OQ", "DownloadDate")
            If SQL.Current.Bulk(vl10, "Sch_VL10") Then
                SQL.Current.Execute("INSERT INTO Sch_Business (Family,Business,MRP) Select DISTINCT 'Unclassified',V.BusinessName,'None' " & _
                                    "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL")
                SQL.Current.Execute("INSERT INTO Sch_Materials (Material,CustomerPN,[Description],Business,StdPack,StartProduction,EndProduction,Class) " & _
                                    "SELECT V.Material,MIN(V.CustomerMaterial),MIN(V.[Description]),MIN(V.BusinessName),1,'1900-01-01','2099-12-31','NO CLASS' " & _
                                    "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material WHERE M.Material IS NULL AND V.BusinessName IS NOT NULL " & _
                                    "GROUP BY V.Material")
                LoadingScreen.Hide()
                MsgBox("VL10 actualizada correctamente!", MsgBoxStyle.Information, APP)
            Else
                LoadingScreen.Hide()
                MsgBox("Error en bulk de VL10.", MsgBoxStyle.Critical, APP)
            End If
        Else
            LoadingScreen.Hide()
            MsgBox("Error al leer el archivo.", MsgBoxStyle.Critical, APP)
        End If
    End Sub

    Public Shared Sub DownloadCurrentInventory()
        If Not SQL.Current.Exists("SELECT TOP 1 Material FROM Sch_CurrentInventory WHERE DATEPART(WK, UpdatedDate) = DATEPART(WK,GETDATE()) AND DATEPART(YY, UpdatedDate) = DATEPART(YY,GETDATE())") Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim plncd As String = Parameter("SYS_PlantCode")
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_WHR_DATA(Parameter("SCH_WarehouseNumber"), plncd, filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 2)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.Columns.Add("TOTALSTOCK_INT", GetType(Integer), "Convert([TOTALSTOCK],'System.Double')")
                            txt.DefaultView.RowFilter = String.Format("[PLNT] = '{0}'", plncd)
                            Dim inventory = txt.DefaultView.ToTable(False, "MATERIAL", "TOTALSTOCK_INT", "STY", "STORAGEBIN")
                            If SQL.Current.Bulk(inventory, "Sch_CurrentInventory") Then
                                SQL.Current.Execute("DELETE FROM Sch_CurrentInventory WHERE UpdatedDate < (SELECT MAX(UpdatedDate) FROM Sch_CurrentInventory)")
                                LoadingScreen.Hide()
                                MsgBox("Inventory actualizado correctamente.", MsgBoxStyle.Information, APP)
                            Else
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        Else
                            LoadingScreen.Hide()
                            MsgBox("Error al leer el archivo.", MsgBoxStyle.Critical, APP)
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar el Inventario.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar el Inventario.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
            End If
        Else
            MsgBox("Inventario ya se encuentra actualizado.", MsgBoxStyle.Information)
        End If
    End Sub
    Public Shared Sub DownloadZVT11()
        If Not SQL.Current.Exists("SELECT TOP 1 Material FROM Sch_ZVT11 WHERE DATEPART(WK, [Date]) = DATEPART(WK,DATEADD(DD,-7,GETDATE())) AND DATEPART(YY, [Date]) = DATEPART(YY,DATEADD(DD,-7,GETDATE()))") Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap_session.ZVT11(Parameter("SCH_ShippingPoint"), LastMonday.AddDays(-7), LastMonday.AddDays(-1), filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 7)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.DefaultView.RowFilter = String.Format("[Plnt] = '{0}'", Parameter("SYS_PlantCode"))
                            txt.Columns.Add("Quantity_Int", GetType(Integer), "Convert([Quantity],'System.Double')")
                            txt.Columns.Add("Monday", GetType(Date), String.Format("Convert('{0}','System.DateTime')", LastMonday.AddDays(-7).ToShortDateString))
                            Dim ZVT11 = txt.DefaultView.ToTable(False, "Material", "Customer", "Quantity_Int", "Sold-to", "Delivery", "Monday")
                            If SQL.Current.Bulk(ZVT11, "Sch_ZVT11") Then
                                LoadingScreen.Hide()
                                MsgBox("ZVT11 actualizada correctamente!", MsgBoxStyle.Information, APP)
                            Else
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar ZTV11.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar ZTV11.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("ZTV11 ya se encuentrada actualizada.", MsgBoxStyle.Information)
        End If
    End Sub
    Public Shared Sub DownloadZMDESNR()
        Dim lastday As Date = SQL.Current.GetDate("SELECT MAX([Date]) FROM Sch_ZMDESNR")
        If lastday.AddDays(1).Date < CurrentDate.Date Then
            LoadingScreen.Show()
            Dim sap_session As New SAP
            If sap_session.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap_session.ZMDESNR(Parameter("SYS_PlantCode"), "SHP", lastday.AddDays(1), CurrentDate.AddDays(-1), filename) Then
                    Try
                        Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, False, 5)
                        TryDelete(filename)
                        If txt IsNot Nothing Then
                            txt.DefaultView.RowFilter = "[MvT] = 'Z11'"
                            Dim zmdesnr_ph1 = txt.DefaultView.ToTable(False, "Material", "Quantity", "LM Serial", "Delivery", "Ship-to", "Created on")
                            zmdesnr_ph1.Columns.Add("Quantity_Int", GetType(Integer), "Convert(Convert([Quantity],'System.Double'),'System.Int32')")
                            If SQL.Current.Bulk(zmdesnr_ph1.DefaultView.ToTable(False, "Material", "Quantity_Int", "LM Serial", "Delivery", "Ship-to", "Created on"), "Sch_ZMDESNR") Then
                                LoadingScreen.Hide()
                                MsgBox("ZMDESNR actualizada correctamente!", MsgBoxStyle.Information, APP)
                            Else
                                'CSV.SaveAs(zmdesnr_ph1.DefaultView.ToTable(False, "Material", "Quantity_Int", "LM Serial", "Delivery", "Ship-to", "Created on"), True)
                                LoadingScreen.Hide()
                                MsgBox("Error en bulk de archivo.", MsgBoxStyle.Critical, APP)
                            End If
                        End If
                    Catch ex As Exception
                        LoadingScreen.Hide()
                        MsgBox("Error al guardar ZMDESNR.", MsgBoxStyle.Critical, APP)
                    End Try
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al descargar ZMDESNR.", MsgBoxStyle.Critical, APP)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
            End If
            sap_session = Nothing
        Else
            MsgBox("ZMDESNR ya se encuentra actualizada.")
        End If
    End Sub
    

    Public Shared Function IsMaterialFormat(material As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(material, "^[A-Za-z0-9]{8}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
End Class
