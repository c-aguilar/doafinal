Public Class MAn_Process309
    Dim movements As DataTable
    Dim check As Boolean = False
    Dim zapimatinfo As DataTable
    Private Sub MAn_Process309_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        If movements IsNot Nothing Then
            LoadingScreen.Show()
            Dim sap As New SAP
            For Each row As DataRowView In movements.DefaultView
                Dim row_zapi = zapimatinfo.Rows.Find(row.Item("Componente Nuevo"))
                If row.Item("Seleccionar") AndAlso sap.Available AndAlso row_zapi IsNot Nothing AndAlso row_zapi.Item("Quantity") >= row.Item("Cantidad") Then
                    Dim document As String = sap.MB1B_309(Parameter("Sys_PlantCode"), row.Item("Permiso"), "0002", row.Item("Componente Anterior"), row.Item("Componente Nuevo"), row.Item("Cantidad"), row.Item("Unidad"))
                    If document.ToUpper.Contains("DOCUMENT") AndAlso document.ToUpper.Contains("POSTED") AndAlso document <> "" Then
                        SQL.Current.Insert("MAn_309Movements", {"PermitID", "Serialnumber", "SAPDocument"}, {row.Item("ID"), row.Item("Serie PT"), document.ToUpper.Replace("DOCUMENT", "").Replace("POSTED", "").Trim})
                        row_zapi.Item("Quantity") -= row.Item("Cantidad")
                        row.Delete()
                    End If
                End If
            Next
            'RefreshData()
            LoadingScreen.Hide()
            FlashAlerts.ShowConfirm("¡Hecho!")
        End If
    End Sub

    Private Sub RefreshData()
        Dim sap As New SAP
        If sap.Available Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempTXTPath
            If sap.AQ25SYSTQV000492RPT_ZMF47("FV38", filename) Then
                Dim zmf47 As DataTable = CSV.Datatable(filename, vbTab, True, True, 2)
                filename = GF.TempTXTPath
                If sap.ZAPI_MATINFO("FV38", filename, {"0002"}) Then
                    Dim zapi As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                    'zapi.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")

                    zapimatinfo = New DataTable
                    zapimatinfo.Columns.Add("Partnumber")
                    zapimatinfo.Columns.Add("Quantity", GetType(Decimal))
                    zapimatinfo.Columns.Add("UoM")
                    zapimatinfo.PrimaryKey = {zapimatinfo.Columns("Partnumber")}
                    For Each row As DataRow In zapi.DefaultView.ToTable(False, "Material", "Material description", "Unrestricted stock", "Base UOM").Rows
                        zapimatinfo.Rows.Add(RawMaterial.Format(row.Item("Material")), CDec(row.Item("Unrestricted stock")), row.Item("Base UOM"))
                    Next

                    Dim requeriment As New DataTable("Requeriment")
                    requeriment.Columns.Add("Material")
                    requeriment.Columns.Add("Partnumber")
                    requeriment.Columns.Add("Quantity", GetType(Decimal))
                    requeriment.Columns.Add("UoM")

                    Dim pending_transfers As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,SUM(Quantity) AS Quantity FROM vw_Smk_PendingTransfers WHERE ToSloc = '0002' GROUP BY Partnumber")
                    pending_transfers.PrimaryKey = {pending_transfers.Columns.Item("Partnumber")}

                    Dim not_enough As New DataTable("Comparativo")
                    not_enough.Columns.Add("Partnumber")
                    not_enough.Columns.Add("Errores", GetType(Integer))
                    not_enough.Columns.Add("Requerimiento", GetType(Decimal))
                    not_enough.Columns.Add("Stock", GetType(Decimal))
                    not_enough.Columns.Add("Diff", GetType(Decimal), "Stock - Requerimiento")
                    not_enough.PrimaryKey = {not_enough.Columns("Partnumber")}

                    For Each row As DataRow In zmf47.Rows
                        requeriment.Rows.Add(Harn.Format(row.Item("Material")), RawMaterial.Format(row.Item("Material_1")), CDec(row.Item("Reqmt Qty")), row.Item("BUn"))
                    Next
                    Dim requeriment_total As DataTable = DatatablePivoter.Get(requeriment, {"Partnumber", "UoM"}, {}, {"Quantity", "Material"}, {AggregateFunction.Sum, AggregateFunction.Count})
                    requeriment_total.DefaultView.Sort = "[Conteo de Material] DESC"

                    For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                        Dim stock As DataRow = zapimatinfo.Rows.Find(row.Item("Partnumber"))
                        Dim pending As DataRow = pending_transfers.Rows.Find(row.Item("Partnumber"))
                        Dim stock_dec, pending_dec As Decimal
                        If stock IsNot Nothing Then
                            stock_dec = stock.Item("Quantity")
                        Else
                            stock_dec = 0
                        End If
                        If pending IsNot Nothing Then
                            pending_dec = pending.Item("Quantity")
                        Else
                            pending_dec = 0
                        End If
                        not_enough.Rows.Add(row.Item("Partnumber"), row.Item("Conteo de Material"), row.Item("Suma de Quantity"), stock_dec + pending_dec)
                    Next

                    movements = SQL.Current.GetDatatable("SELECT P.ID, P.Number AS Permiso,P.Material,P.OldPartnumber AS [Componente Anterior],P.NewPartnumber AS [Componente Nuevo],S.Serialnumber AS [Serie PT],S.[PostedDate] AS Fecha, S.Quantity*B.Quantity AS Cantidad,R.UoM AS Unidad,0 AS [Negativo ZMF47],CONVERT(BIT,1) AS Seleccionar FROM MAn_EngineeringPermits AS P INNER JOIN FGR_SerialMovements AS S ON P.Material = S.Material AND S.PostedDate BETWEEN P.LastAdjustment AND P.ExpirationDate LEFT OUTER JOIN MAn_309Movements AS M ON S.Serialnumber = M.Serialnumber AND P.ID = M.PermitID INNER JOIN Sys_CurrentBOM AS B ON P.Material = B.Material AND P.OldPartnumber = B.Partnumber INNER JOIN Sys_RawMaterial AS R ON P.NewPartnumber =  R.Partnumber WHERE P.[Type] = 'S' AND P.[Active] = 1 AND S.Movement = 'BKF' AND M.PermitID IS NULL")
                    For Each row As DataRow In movements.Rows
                        Dim negative As DataRow = not_enough.Rows.Find(row.Item("Componente Anterior"))
                        If negative IsNot Nothing AndAlso negative.Item("Diff") < 0 Then
                            row.Item("Negativo ZMF47") = negative.Item("Diff")
                        End If
                    Next
                    Movements_dgv.DataSource = movements
                    LoadingScreen.Hide()
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Error al descargar el inventario de SAP.")
                End If
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al descargar los errores en SAP.")
            End If

        Else
            FlashAlerts.ShowError("Sesión de SAP no encontrada.")
        End If
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshData()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If movements IsNot Nothing Then
            Delta.Export(movements, Title_lbl.Text)
        End If
    End Sub

    Private Sub Select_btn_Click(sender As Object, e As EventArgs) Handles Select_btn.Click
        If Movements_dgv.DataSource IsNot Nothing Then
            For Each row As DataRowView In CType(Movements_dgv.DataSource, DataTable).DefaultView
                row.Item("Seleccionar") = check
            Next
            check = Not check
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        If Movements_dgv.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            For Each row As DataRowView In CType(Movements_dgv.DataSource, DataTable).DefaultView
                If row.Item("Seleccionar") Then
                    SQL.Current.Insert("MAn_309Movements", {"Serialnumber", "PermitID"}, {row.Item("Serie PT"), row.Item("ID")})
                    row.Delete()
                End If
            Next
            LoadingScreen.Hide()
            FlashAlerts.ShowConfirm("Movimientos cancelados.")
        End If
    End Sub
End Class