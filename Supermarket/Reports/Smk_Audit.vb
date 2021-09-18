
Public Class Smk_Audit
    Dim selected_partnumbers As New ArrayList
    Dim selected_sloc As String
    Dim serialnumbers As List(Of Serialnumber)
    Dim report As DataTable
    Dim audit_report As DataTable
    Private Sub Smk_Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Sloc_cbo, SQL.Current.GetDatatable("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc"), "Sloc", "Sloc")


        CType(Result_dgv.Columns("button"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.arrow_right_16
        CType(Serials_dgv.Columns("open_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.box_front_open_16
        CType(Serials_dgv.Columns("partial_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.box_front_open_hand
        CType(Serials_dgv.Columns("empty_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.box_open_16
    End Sub

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
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

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        If Sloc_cbo.SelectedIndex >= 0 Then
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Serials_dgv.Rows.Clear()
                serialnumbers = New List(Of Serialnumber)
                For i = 0 To selected_partnumbers.Count - 1
                    selected_partnumbers.Item(i) = Strings.right("00000000" & selected_partnumbers(i), 8)
                Next
                Dim filename As String = GF.TempTXTPath
                Dim zapimatinfo As DataTable
                Dim transfer_pending As DataTable
                Dim mspec_serials_filter, mspec_zapi_filter, location_serial_filter As String
                If IgnoreMSpec_rb.Checked Then
                    mspec_serials_filter = "MaterialType <> 'Cable' AND"
                    mspec_zapi_filter = "[Material description] NOT LIKE '%CABL%'"
                ElseIf OnlyMspec_rb.Checked Then
                    mspec_serials_filter = "MaterialType = 'Cable' AND"
                    mspec_zapi_filter = "[Material description] LIKE '%CABL%'"
                Else
                    mspec_serials_filter = ""
                    mspec_zapi_filter = ""
                End If
                If LocationA_txt.Text.Trim <> "" AndAlso LocationA_txt.Text.Trim <> "*" Then
                    If Integer.TryParse(LocationA_txt.Text, Nothing) Then
                        If LocationB_txt.Text <> "" Then
                            If Integer.TryParse(LocationB_txt.Text, Nothing) Then
                                location_serial_filter = String.Format("(([Partnumber] IN (SELECT Partnumber FROM Smk_Map WHERE CONVERT(INTEGER,[Location]) BETWEEN {0} AND {1}))) AND", Strings.Left(LocationA_txt.Text.Trim & "00000000", 8), Strings.Left(LocationB_txt.Text.Trim & "00000000", 8))
                            Else
                                FlashAlerts.ShowError("Rango de locales incorrecto.")
                                Exit Sub
                            End If
                        Else
                            location_serial_filter = String.Format("(([Partnumber] IN (SELECT Partnumber FROM Smk_Map WHERE [Location] LIKE '{0}%'))) AND", LocationA_txt.Text.Trim)
                        End If
                    Else
                        FlashAlerts.ShowError("Local incorrecto.")
                        Exit Sub
                    End If
                Else
                    location_serial_filter = ""
                End If
                selected_sloc = Sloc_cbo.SelectedValue
                If selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "") AndAlso sap.ZAPI_MATINFO(Parameter("SYS_PlantCode"), filename, "*", selected_sloc) Then
                    Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                    txt.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")
                    txt.DefaultView.RowFilter = mspec_zapi_filter
                    zapimatinfo = txt.DefaultView.ToTable(False, "New_Material", "Material description", "Storage Loc", "Unrestricted stock")
                    Dim serial_list As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE {0} {1} ({2});", mspec_serials_filter, location_serial_filter, String.Format(" Sloc = '{0}'", selected_sloc)))
                    For Each s As DataRow In serial_list.Rows
                        serialnumbers.Add(New Serialnumber(s("Serialnumber"), s("Partnumber"), s("OriginalQuantity"), s("CurrentQuantity"), s("CurrentQuantityInBuM"), s("UoM"), s("Date"), s("Warehouse"), s("WarehouseName"), If(IsDBNull(s("Container")), "", s("Container")), s("ConsumptionType"), s("Sloc"), s("Status"), s("StatusDescription"), If(IsDBNull(s("RandomLocation")), "", s("RandomLocation")), If(IsDBNull(s("ServiceLocation")), "", s("ServiceLocation")), s("Weight"), s("CurrentWeight"), If(IsDBNull(s("TruckNumber")), "", s("TruckNumber")), s("RedTag"), s("InvoiceTrouble"), s("Critical"), s("MasterLabel"), s("Scanner"), If(IsDBNull(s("ExpirationDate")), New Date(2100, 12, 31), s("ExpirationDate")), If(IsDBNull(s("Lot")), "", s("Lot")), s("ID"), s("MaterialType"), s("RandomSloc"), s("ServiceSloc"), s("DullSloc"), s("MRP")))
                    Next

                    'PENDIENTE HASTA LIGAR SMSBARRELS CON DELTA
                    'If All_rb.Checked OrElse OnlyMspec_rb.Checked Then
                    '    Dim sms As New CAguilar.SQL("")
                    '    Dim mspec_serial_list As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Serie,PartNumber,StdPack,UoM,[Status],Serial.[Local],Estacion,[Stock Mt-Kg],[Stock Ft-Lb] FROM (SELECT serial_warehouse Estacion,serial_number AS Serie,serial_partNumber AS PartNumber,serial_stdPack StdPack,serial_uom AS UoM," & _
                    '                "CASE WHEN serial_status ='RANDOM' THEN 'RANDOM' ELSE 'SERVICE' END [Status],CASE WHEN serial_status = 'RANDOM' THEN serial_randomLocal ELSE serial_serviceLocal END AS [Local]," & _
                    '                "CASE WHEN serial_uom='FT' THEN serial_lenghtQuantity*0.3048 ELSE CASE WHEN serial_uom = 'LB' THEN serial_lenghtQuantity*0.45359237 ELSE serial_lenghtQuantity END END AS [Stock Mt-Kg]," & _
                    '                "serial_warehouse FROM tblSerials WHERE serial_status IN ('RANDOM','SMK','ON CUTTER')) AS Serial INNER JOIN (SELECT ware_name,'SERVICE' [Local] FROM catWarehouse WHERE ware_serviceSloc='{0}' UNION ALL SELECT ware_name,'RANDOM' [Local] FROM catWarehouse WHERE ware_randomSloc='{0}') AS Ware " & _
                    '                "ON serial_warehouse = ware_name AND Serial.Status = Ware.Local) AS SMS ON part_number = PartNumber"))
                    '    For Each s As DataRow In mspec_serial_list.Rows

                    '    Next
                    'End If
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue))
                ElseIf selected_partnumbers.Count = 0 AndAlso sap.ZAPI_MATINFO(Parameter("SYS_PlantCode"), filename, Partnumber_txt.Text, selected_sloc) Then
                    Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                    txt.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")
                    zapimatinfo = txt.DefaultView.ToTable(False, "New_Material", "Material description", "Storage Loc", "Unrestricted stock")
                    Dim serial_list As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE ({0}) AND {1} Partnumber = '{2}';", String.Format(" Sloc = '{0}'", selected_sloc), location_serial_filter, Partnumber_txt.Text))
                    For Each s As DataRow In serial_list.Rows
                        serialnumbers.Add(New Serialnumber(s("Serialnumber"), s("Partnumber"), s("OriginalQuantity"), s("CurrentQuantity"), s("CurrentQuantityInBuM"), s("UoM"), s("Date"), s("Warehouse"), s("WarehouseName"), If(IsDBNull(s("Container")), "", s("Container")), s("ConsumptionType"), s("Sloc"), s("Status"), s("StatusDescription"), If(IsDBNull(s("RandomLocation")), "", s("RandomLocation")), If(IsDBNull(s("ServiceLocation")), "", s("ServiceLocation")), s("Weight"), s("CurrentWeight"), If(IsDBNull(s("TruckNumber")), "", s("TruckNumber")), s("RedTag"), s("InvoiceTrouble"), s("Critical"), s("MasterLabel"), s("Scanner"), If(IsDBNull(s("ExpirationDate")), New Date(2100, 12, 31), s("ExpirationDate")), If(IsDBNull(s("Lot")), "", s("Lot")), s("ID"), s("MaterialType"), s("RandomSloc"), s("ServiceSloc"), s("DullSloc"), s("MRP")))
                    Next
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND S.Partnumber = '{1}' AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue, Strings.right("00000000" & Partnumber_txt.Text, 8)))
                ElseIf selected_partnumbers.Count > 0 AndAlso sap.ZAPI_MATINFO(Parameter("SYS_PlantCode"), selected_partnumbers, selected_sloc, filename) Then
                    Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                    txt.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")
                    zapimatinfo = txt.DefaultView.ToTable(False, "New_Material", "Material description", "Storage Loc", "Unrestricted stock")
                    Dim serial_list As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE ({0}) AND {1} Partnumber IN ('{2}');", String.Format(" Sloc = '{0}'", selected_sloc), location_serial_filter, String.Join("','", selected_partnumbers.ToArray)))
                    For Each s As DataRow In serial_list.Rows
                        serialnumbers.Add(New Serialnumber(s("Serialnumber"), s("Partnumber"), s("OriginalQuantity"), s("CurrentQuantity"), s("CurrentQuantityInBuM"), s("UoM"), s("Date"), s("Warehouse"), s("WarehouseName"), If(IsDBNull(s("Container")), "", s("Container")), s("ConsumptionType"), s("Sloc"), s("Status"), s("StatusDescription"), If(IsDBNull(s("RandomLocation")), "", s("RandomLocation")), If(IsDBNull(s("ServiceLocation")), "", s("ServiceLocation")), s("Weight"), s("CurrentWeight"), If(IsDBNull(s("TruckNumber")), "", s("TruckNumber")), s("RedTag"), s("InvoiceTrouble"), s("Critical"), s("MasterLabel"), s("Scanner"), If(IsDBNull(s("ExpirationDate")), New Date(2100, 12, 31), s("ExpirationDate")), If(IsDBNull(s("Lot")), "", s("Lot")), s("ID"), s("MaterialType"), s("RandomSloc"), s("ServiceSloc"), s("DullSloc"), s("MRP")))
                    Next
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND S.Partnumber IN ('{1}') AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue, String.Join("','", selected_partnumbers.ToArray)))
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al obtener el inventario de SAP.", MsgBoxStyle.Critical, APP)
                    Exit Sub
                End If

                report = New DataTable("Comparativo")
                report.Columns.Add("No. de Parte")
                report.Columns.Add("Cantidad en Delta", GetType(Decimal))
                report.Columns.Add("Pendiente por Transferir", GetType(Decimal))
                report.Columns.Add("Cantidad en SAP", GetType(Decimal))
                report.Columns.Add("Diferencia", GetType(Decimal), "[Cantidad en Delta] + [Pendiente por Transferir] - [Cantidad en SAP]")
                report.PrimaryKey = {report.Columns("No. de Parte")}
                report.Columns("Cantidad en Delta").DefaultValue = 0

                If LocationA_txt.Text <> "" AndAlso LocationA_txt.Text <> "*" Then
                    For Each s As Serialnumber In serialnumbers
                        Dim row = report.Rows.Find(s.Partnumber)
                        If row Is Nothing Then
                            report.Rows.Add(s.Partnumber, s.CurrentQuantityInBum, 0, 0)
                        Else
                            row.Item("Cantidad en Delta") = row.Item("Cantidad en Delta") + s.CurrentQuantityInBum
                        End If
                    Next
                    For Each p As DataRow In zapimatinfo.Rows
                        Dim row = report.Rows.Find(p.Item("New_Material"))
                        If row IsNot Nothing Then
                            row.Item("Cantidad en SAP") = p.Item("Unrestricted stock")
                        End If
                    Next
                Else
                    For Each p As DataRow In zapimatinfo.Rows
                        report.Rows.Add(p.Item("New_Material"), 0, 0, p.Item("Unrestricted stock"))
                    Next
                    For Each s As Serialnumber In serialnumbers
                        Dim row = report.Rows.Find(s.Partnumber)
                        If row Is Nothing Then
                            report.Rows.Add(s.Partnumber, s.CurrentQuantityInBum, 0, 0)
                        Else
                            row.Item("Cantidad en Delta") = row.Item("Cantidad en Delta") + s.CurrentQuantityInBum
                        End If
                    Next
                End If
                For Each p As DataRow In transfer_pending.Rows
                    Dim row = report.Rows.Find(p.Item("Partnumber"))
                    If row IsNot Nothing Then
                        'report.Rows.Add(p.Item("Partnumber"), 0, p.Item("Quantity"), 0)
                        'Else
                        row.Item("Pendiente por Transferir") = p.Item("Quantity")
                    End If
                Next
                If selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "") AndAlso IgnoreZero_chk.Checked Then
                    report.DefaultView.RowFilter = "Diferencia <> 0"
                End If
                Result_dgv.DataSource = report.DefaultView

                'GENERAR REPORTE DE AUDITORIA
                audit_report = New DataTable
                audit_report.Columns.Add("No. de Parte")
                audit_report.Columns.Add("Cantidad en SAP")
                audit_report.Columns.Add("Cantidad en Delta")
                audit_report.Columns.Add("Diferencia")
                audit_report.Columns.Add("Estacion")
                audit_report.Columns.Add("Estatus")
                audit_report.Columns.Add("Localizacion")
                audit_report.Columns.Add("Serie")
                audit_report.Columns.Add("Cantidad")
                audit_report.Columns.Add("Unidad")

                Dim is_first As Boolean = True
                For Each part As DataRowView In report.DefaultView
                    Dim serials = serialnumbers.Where(Function(f) f.Partnumber = part.Item("No. de Parte")).OrderBy(Function(f) f.Warehouse).ThenBy(Function(f) f.CurrentLocation)
                    If serials IsNot Nothing AndAlso serials.Count > 0 Then
                        For Each serial In serials
                            If is_first Then
                                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                    audit_report.Rows.Add(part.Item("No. de Parte"), CInt(part.Item("Cantidad en SAP")), CInt(part.Item("Cantidad en Delta") + part.Item("Pendiente por Transferir")), CInt(part.Item("Diferencia")), serial.WarehouseName, serial.StatusName, serial.CurrentLocation, serial.SerialNumber, CInt(serial.CurrentQuantity), serial.UoM)
                                Else
                                    audit_report.Rows.Add(part.Item("No. de Parte"), Math.Round(CDec(part.Item("Cantidad en SAP")), 2), Math.Round(CDec(part.Item("Cantidad en Delta")) + CDec(part.Item("Pendiente por Transferir")), 2), Math.Round(CDec(part.Item("Diferencia")), 2), serial.WarehouseName, serial.StatusName, serial.CurrentLocation, serial.SerialNumber, Math.Round(serial.CurrentQuantity, 2), serial.UoM)
                                End If
                                is_first = False
                            Else
                                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                    audit_report.Rows.Add(serial.Partnumber, "", "", "", serial.WarehouseName, serial.StatusName, serial.CurrentLocation, serial.SerialNumber, CInt(serial.CurrentQuantity), serial.UoM)
                                Else
                                    audit_report.Rows.Add(serial.Partnumber, "", "", "", serial.WarehouseName, serial.StatusName, serial.CurrentLocation, serial.SerialNumber, Math.Round(serial.CurrentQuantity, 2), serial.UoM)
                                End If
                            End If
                        Next
                    Else
                        audit_report.Rows.Add(part.Item("No. de Parte"), Math.Round(CDec(part.Item("Cantidad en SAP")), 1), Math.Round(CDec(part.Item("Cantidad en Delta")) + CDec(part.Item("Pendiente por Transferir")), 1), Math.Round(CDec(part.Item("Diferencia")), 1), "", "", "", "", "", "")
                    End If
                    is_first = True
                Next

                IO.File.Delete(filename)
                LoadingScreen.Hide()
                Me.Activate()
            Else
                MsgBox("Sesion de SAP no encontrada.", MsgBoxStyle.Critical, APP)
            End If
        Else
            FlashAlerts.ShowInformation("Selecciona el SLoc.")
        End If
    End Sub

    Private Sub Result_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Result_dgv.CellFormatting
        If Result_dgv.Rows(e.RowIndex).Cells("Difference").Value = 0 Then
            e.CellStyle.BackColor = Color.LightGreen
        ElseIf Result_dgv.Rows(e.RowIndex).Cells("Difference").Value > 0 Then
            e.CellStyle.BackColor = Color.LightBlue
        ElseIf Result_dgv.Rows(e.RowIndex).Cells("Difference").Value < 0 Then
            e.CellStyle.BackColor = Color.LightCoral
        End If
    End Sub

    Private Sub Result_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Result_dgv.CellContentClick
        If e.ColumnIndex = Result_dgv.Columns("button").Index Then
            FillSerials(Result_dgv.Rows(e.RowIndex).Cells("Partnumber").Value, selected_sloc)
        End If
    End Sub

    Private Sub Serials_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Serials_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("open_btn").Index AndAlso CType(Serials_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled AndAlso serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value).Status = Delta_ERP.Serialnumber.SerialStatus.Stored Then
            Dim os As New Smk_OpenSerial
            os.PreloadSerialnumber = serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value)
            os.ShowDialog()
            If Not os.PreloadSerialnumber.Status = Delta_ERP.Serialnumber.SerialStatus.Stored Then 'HUBO CAMBIOS EN LA SERIE
                Dim part_report = report.Rows.Find(os.PreloadSerialnumber.Partnumber)
                part_report.Item("Cantidad en Delta") = (From s In serialnumbers Where s.Partnumber = os.PreloadSerialnumber.Partnumber And s.Sloc = selected_sloc Select s.CurrentQuantity).Sum()
                part_report.Item("Pendiente por Transferir") = SQL.Current.GetScalar(String.Format("SELECT SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND S.Partnumber = '{1}' AND Posted = 0 GROUP BY S.Partnumber", selected_sloc, os.PreloadSerialnumber.Partnumber))

                FillSerials(os.PreloadSerialnumber.Partnumber, selected_sloc)
                FlashAlerts.ShowConfirm("Ajustes realizados.")
            End If
            os.Dispose()
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("partial_btn").Index AndAlso CType(Serials_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled AndAlso serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value).Status = Delta_ERP.Serialnumber.SerialStatus.Open Then
            Dim pd As New Smk_PartialDiscount
            pd.PreloadSerialnumber = serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value)
            Dim current_qty As Decimal = pd.PreloadSerialnumber.CurrentQuantity
            pd.ShowDialog()
            If Not pd.PreloadSerialnumber.CurrentQuantity = current_qty Then 'HUBO CAMBIOS EN LA SERIE
                Dim part_report = report.Rows.Find(pd.PreloadSerialnumber.Partnumber)
                part_report.Item("Cantidad en Delta") = (From s In serialnumbers Where s.Partnumber = pd.PreloadSerialnumber.Partnumber And s.Sloc = selected_sloc Select s.CurrentQuantity).Sum()
                part_report.Item("Pendiente por Transferir") = SQL.Current.GetScalar(String.Format("SELECT SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND S.Partnumber = '{1}' AND Posted = 0 GROUP BY S.Partnumber", selected_sloc, pd.PreloadSerialnumber.Partnumber))

                FillSerials(pd.PreloadSerialnumber.Partnumber, selected_sloc)
                FlashAlerts.ShowConfirm("Ajustes realizados.")
            End If
            pd.Dispose()
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("empty_btn").Index AndAlso CType(Serials_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled AndAlso serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value).Status = Delta_ERP.Serialnumber.SerialStatus.Open Then
            Dim de As New Smk_DeclareEmpty
            de.PreloadSerialnumber = serialnumbers.First(Function(x) x.SerialNumber = Serials_dgv.Rows(e.RowIndex).Cells("serialnumber").Value)
            de.ShowDialog()
            If de.PreloadSerialnumber.Status = Delta_ERP.Serialnumber.SerialStatus.Empty Then 'HUBO CAMBIOS EN LA SERIE
                Dim part_report = report.Rows.Find(de.PreloadSerialnumber.Partnumber)
                part_report.Item("Cantidad en Delta") = (From s In serialnumbers Where s.Partnumber = de.PreloadSerialnumber.Partnumber And s.Sloc = selected_sloc Select s.CurrentQuantity).Sum()
                part_report.Item("Pendiente por Transferir") = SQL.Current.GetScalar(String.Format("SELECT SUM(CASE WHEN UoM = 'FT' THEN T.Quantity * 0.3048 ELSE CASE WHEN UoM = 'FT' THEN T.Quantity * 0.453592 ELSE T.Quantity END END) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID WHERE FromSloc= '{0}' AND S.Partnumber = '{1}' AND Posted = 0 GROUP BY S.Partnumber", selected_sloc, de.PreloadSerialnumber.Partnumber))

                FillSerials(de.PreloadSerialnumber.Partnumber, selected_sloc)
                FlashAlerts.ShowConfirm("Ajustes realizados.")
            End If
            de.Dispose()
        End If
    End Sub

    Private Sub FillSerials(partnumber As String, sloc As String)
        Serials_dgv.Rows.Clear()
        Dim query = From s In serialnumbers
                    Where s.Partnumber = partnumber And s.Sloc = sloc
        For Each s In query
            Dim i = Serials_dgv.Rows.Count
            Serials_dgv.Rows.Add(s.SerialNumber, s.Partnumber, s.CurrentQuantity, s.UoM.ToString, s.StatusName, If(s.Status = Delta_ERP.Serialnumber.SerialStatus.Stored, s.RandomLocation, s.ServiceLocation), s.WarehouseName)
            Select Case s.Status
                Case Delta_ERP.Serialnumber.SerialStatus.Stored
                    CType(Serials_dgv.Rows(i).Cells("partial_btn"), DataGridViewImprovedButtonCell).Enabled = False
                    CType(Serials_dgv.Rows(i).Cells("empty_btn"), DataGridViewImprovedButtonCell).Enabled = False
                Case Delta_ERP.Serialnumber.SerialStatus.Open, Delta_ERP.Serialnumber.SerialStatus.OnCutter, Delta_ERP.Serialnumber.SerialStatus.ServiceOnQuality
                    CType(Serials_dgv.Rows(i).Cells("open_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End Select
        Next
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If audit_report IsNot Nothing Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempPDFPath
            Dim pdf As New PDF
            pdf.Title = String.Format("DEEDS Operaciones de Mexico.{0}Auditoria Diaria de Confiabilidad de Inventario.", vbCrLf)
            pdf.TitleFontSize = 14
            pdf.Subtitle = "Fecha: " & CurrentDate.ToString("MM/dd/yyyy HH:mm")
            pdf.Footer = String.Format("Auditado por: _______________ {0}Corregido por: _______________", vbCrLf)
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = audit_report
            pdf.Orientation = CAguilar.PDF.Orientations.Landscape
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 12
            pdf.ColumnsWidths = {9, 9, 9, 9, 8, 14, 11, 15, 9, 7}
            If pdf.Save(filename) Then
                LoadingScreen.Hide()
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al imprimir la auditoria.")
            End If
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If audit_report IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(audit_report, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(audit_report, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = audit_report
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub ToolStripMain_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripMain.ItemClicked

    End Sub

    Private Sub Smk_Audit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class