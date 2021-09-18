Public Class Smk_NewSerial
    Dim partnumber As RawMaterial
    Dim IsCritical As Boolean = False
    Dim HasQualityAlert As Boolean = False
    Public DefaultWarehouse As String
    Private Sub Rec_NewSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultWarehouse = SQL.Current.GetString("SELECT TOP 1 Warehouse FROM Smk_Warehouses")
    End Sub

    Private Sub Partnumber_txt_Validated(sender As Object, e As EventArgs) Handles Partnumber_txt.Validated
        If Partnumber_txt.Text.Trim <> "" Then
            Dim scan As String = Partnumber_txt.Text.ToUpper
            If scan.StartsWith(".") Then
                scan = scan.TrimStart(".")
            ElseIf scan.StartsWith("P") AndAlso Not scan.StartsWith("PE") Then
                scan = scan.TrimStart("P")
            ElseIf scan.StartsWith("1P") Then
                scan = scan.TrimStart("1").TrimStart("P")
            End If


            partnumber = New RawMaterial(scan)
            If Not partnumber.Exist Then
                partnumber = New RawMaterial(scan, True)
                If Not partnumber.Exist Then
                    scan = Strings.right("0000000" & scan, 8)
                    partnumber = New RawMaterial(scan)
                    If Not partnumber.Exist Then
                        Clean()
                        FlashAlerts.ShowError("No existe el numero de parte.")
                        Exit Sub
                    End If
                End If
            End If

            If Not SQL.Current.Exists("Smk_Map", "Partnumber", partnumber.Partnumber) Then
                Clean()
                FlashAlerts.ShowError("Numero de parte sin local.")
                Exit Sub
            End If

            Select Case partnumber.Type
                Case RawMaterial.MaterialType.Cable
                    UoM_lbl.Text = "Tipo de Contenedor"
                    UoM_cbo.Items.Clear()
                    UoM_cbo.Items.AddRange(Split(",BP | FT,BP | M,NPS | FT,NPS | M,CARTON | FT,CARTON | M,S-NPS | FT,S-NPS | M,S-CARTON | FT,S-CARTON | M,WOOD | FT,WOOD | M,PLASTIC | FT,PLASTIC | M,DONUT | FT,DONUT | M", ","))
                Case Else
                    UoM_cbo.Items.Clear()
                    UoM_cbo.Items.AddRange(Split("PC,M,FT,KG,LB,L", ","))
                    UoM_lbl.Text = "Unidad"
                    UoM_cbo.SelectedItem = partnumber.OrderUnit.ToString
            End Select


            HasQualityAlert = SQL.Current.Exists(String.Format("SELECT ID FROM Qly_PartnumberAlerts WHERE Partnumber = '{0}' AND Active = 1;", partnumber.Partnumber))
            IsCritical = SQL.Current.Exists(String.Format("SELECT Partnumber FROM Rec_CriticalPartnumbers WHERE Partnumber = '{0}' AND Active = 1", partnumber.Partnumber))

            If partnumber.Expirable Then
                Lot_txt.Visible = True
                ExpirationDate_dtp.Visible = True
                NoExpiraton_chk.Visible = True
            Else
                Lot_txt.Visible = False
                ExpirationDate_dtp.Visible = False
                NoExpiraton_chk.Visible = False
            End If

            Dim alert As String = SQL.Current.GetString("Message", "Rec_ScannerAlert", "Partnumber", partnumber.Partnumber, "")
            If alert <> "" Then
                FlashAlerts.ShowInformation(alert, 3)
            End If
        End If
    End Sub

    Private Sub Quantity_txt_Validated(sender As Object, e As EventArgs) Handles Quantity_txt.Validated
        If Quantity_txt.Text.ToUpper.StartsWith("Q") Then
            Quantity_txt.Text = Quantity_txt.Text.ToUpper.TrimStart("Q")
        ElseIf Quantity_txt.Text.ToUpper.StartsWith("P") Then
            Quantity_txt.Text = Quantity_txt.Text.ToUpper.TrimStart("P")
        ElseIf Quantity_txt.Text.ToUpper.StartsWith("1P") Then
            Quantity_txt.Text = Quantity_txt.Text.ToUpper.TrimStart("1").TrimStart("P")
        End If
    End Sub

    Private Sub Clean_btn_Click(sender As Object, e As EventArgs) Handles Clean_btn.Click
        Clean()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If partnumber IsNot Nothing Then
            If IsNumeric(Quantity_txt.Text) AndAlso UoM_cbo.SelectedIndex >= 0 Then
                Dim Container As String = ""
                Dim UoM As String
                If partnumber.Type = RawMaterial.MaterialType.Cable Then
                    Container = Trim(Split(UoM_cbo.SelectedItem, "|").GetValue(0))
                    UoM = Trim(Split(UoM_cbo.SelectedItem, "|").GetValue(1))
                Else
                    UoM = UoM_cbo.SelectedItem
                End If

                Dim warehouses As DataTable = GetWarehouse(partnumber.Partnumber, Containers_nud.Value)
                Dim serials As New DataTable
                serials.Columns.Add("Partnumber")
                serials.Columns.Add("Quantity", GetType(Decimal))
                serials.Columns.Add("UoM")
                serials.Columns.Add("Warehouse")
                serials.Columns.Add("Container")
                serials.Columns.Add("TruckNumber")
                serials.Columns.Add("RedTag", GetType(Boolean))
                serials.Columns.Add("Critical", GetType(Boolean))
                serials.Columns.Add("Scanner", GetType(Integer))
                serials.Columns.Add("ServiceLocation")
                serials.Columns.Add("ExpirationDate")
                serials.Columns.Add("Lot")
                serials.Columns.Add("Badge")
                serials.Columns.Add("New", GetType(Boolean))

                Dim column_mapping(13) As SqlClient.SqlBulkCopyColumnMapping
                column_mapping(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                column_mapping(1) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
                column_mapping(2) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
                column_mapping(3) = New SqlClient.SqlBulkCopyColumnMapping("Warehouse", "Warehouse")
                column_mapping(4) = New SqlClient.SqlBulkCopyColumnMapping("Container", "Container")
                column_mapping(5) = New SqlClient.SqlBulkCopyColumnMapping("TruckNumber", "TruckNumber")
                column_mapping(6) = New SqlClient.SqlBulkCopyColumnMapping("RedTag", "RedTag")
                column_mapping(7) = New SqlClient.SqlBulkCopyColumnMapping("Critical", "Critical")
                column_mapping(8) = New SqlClient.SqlBulkCopyColumnMapping("Scanner", "Scanner")
                column_mapping(9) = New SqlClient.SqlBulkCopyColumnMapping("ServiceLocation", "ServiceLocation")
                column_mapping(10) = New SqlClient.SqlBulkCopyColumnMapping("ExpirationDate", "ExpirationDate")
                column_mapping(11) = New SqlClient.SqlBulkCopyColumnMapping("Lot", "Lot")
                column_mapping(12) = New SqlClient.SqlBulkCopyColumnMapping("Badge", "Badge")
                column_mapping(13) = New SqlClient.SqlBulkCopyColumnMapping("New", "New")

                If Not partnumber.Expirable Then
                    For i = 1 To Containers_nud.Value
                        serials.Rows.Add(partnumber.Partnumber, Quantity_txt.Text, UoM, warehouses.Rows(i - 1).Item("Warehouse"), Container, "Smk", HasQualityAlert, IsCritical, 0, warehouses.Rows(i - 1).Item("Location"), DBNull.Value, DBNull.Value, User.Current.Badge, False)
                    Next
                ElseIf ((Not NoExpiraton_chk.Checked AndAlso ExpirationDate_dtp.Value.Date > CurrentDate.Date) OrElse NoExpiraton_chk.Checked) AndAlso Lot_txt.Text <> "" Then
                    For i = 1 To Containers_nud.Value
                        serials.Rows.Add(partnumber.Partnumber, Quantity_txt.Text, UoM, warehouses.Rows(i - 1).Item("Warehouse"), Container, "Smk", HasQualityAlert, IsCritical, 0, warehouses.Rows(i - 1).Item("Location"), IIf(NoExpiraton_chk.Checked, "2050-12-31", ExpirationDate_dtp.Value.ToString("yyyy-MM-dd")), Lot_txt.Text, User.Current.Badge, False)
                    Next
                Else
                    FlashAlerts.ShowInformation("Debe seleccionar una fecha de expiracion valida y lote.")
                    Exit Sub
                End If
                If SQL.Current.Bulk(serials, "Smk_Serials", column_mapping) Then
                    FlashAlerts.ShowConfirm("Series generadas correctamente.")
                    Clean()
                Else
                    FlashAlerts.ShowError("Error al registrar la nueva serie.")
                End If
                warehouses.Dispose()
            Else
                FlashAlerts.ShowInformation("Falta informacion por llenar.")
            End If
        End If
    End Sub

    Private Function GetWarehouse(partnumber As String, qty_labels As Integer) As DataTable  'REGRESA EL WAREHOUSE Y EL LOCAL PARA AHORRAR RECURSOS
        Dim serial_warehouses As New DataTable
        serial_warehouses.Columns.Add("Warehouse")
        serial_warehouses.Columns.Add("Location")

        Dim warehouses As New DataTable
        warehouses.Columns.Add("Warehouse")
        warehouses.Columns.Add("Minimum", GetType(Integer))
        warehouses.Columns.Add("Maximum", GetType(Integer))
        warehouses.Columns.Add("Location", GetType(String))
        warehouses.Columns.Add("Current", GetType(Integer))
        warehouses.Columns.Add("MissToMin", GetType(Integer), "Minimum - Current")
        warehouses.Columns.Add("MissToMax", GetType(Integer), "Maximum - Current")
        warehouses.Columns("Current").DefaultValue = 0
        warehouses.PrimaryKey = {warehouses.Columns("Warehouse")}

        For Each w As DataRow In SQL.Current.GetDatatable(String.Format("SELECT Warehouse,Minimum,Maximum,Location FROM Smk_Map WHERE Partnumber = '{0}';", partnumber)).Rows
            warehouses.Rows.Add(w.Item(0), w.Item(1), w.Item(2), w.Item(3))
        Next

        If warehouses.Rows.Count = 0 Then
            For i = 1 To qty_labels
                serial_warehouses.Rows.Add(DefaultWarehouse, "")
            Next
            Return serial_warehouses 'SINO ESTA CARGADO EL NUMERO DE PARTE EN EL MAPA SE VA AL WAREHOUSE DEFAULT
        ElseIf warehouses.Rows.Count = 1 Then 'REGRESAR EL UNICO WAREHOUSE DECLARADO
            For i = 1 To qty_labels
                serial_warehouses.Rows.Add(warehouses.Rows(0).Item("Warehouse"), warehouses.Rows(0).Item("Location"))
            Next
            Return serial_warehouses
        End If

        warehouses.Merge(SQL.Current.GetDatatable(String.Format("SELECT Warehouse,COUNT(*) AS [Current] FROM Smk_Serials WHERE [Status] IN ('N','P','S','O','C') AND Partnumber = '{0}' GROUP BY Warehouse;", partnumber)))
        For i = 0 To qty_labels - 1
            Select Case Parameter("REC_NewContainersDistribution", "Equitable").ToLower
                Case "equitable"
                    If warehouses.Compute("COUNT(Warehouse)", "MissToMin > 0") > 0 OrElse warehouses.Compute("COUNT(Warehouse)", "MissToMax > 0") > 0 Then
                        warehouses.DefaultView.Sort = "MissToMin DESC, MissToMax DESC, Current DESC, Maximum DESC, Warehouse ASC"
                    Else
                        warehouses.DefaultView.Sort = "Current ASC, Maximum DESC, Warehouse ASC"
                    End If
                Case "maximumgreater"
                    If warehouses.Compute("COUNT(Warehouse)", "MissToMin > 0") > 0 OrElse warehouses.Compute("COUNT(Warehouse)", "MissToMax > 0") > 0 Then
                        warehouses.DefaultView.Sort = "MissToMin DESC, MissToMax DESC, Current DESC, Maximum DESC, Warehouse ASC"
                    Else
                        warehouses.DefaultView.Sort = "Maximum DESC, Current ASC, Warehouse ASC"
                    End If
            End Select
            serial_warehouses.Rows.Add(warehouses.DefaultView.Item(0).Item("Warehouse"), warehouses.DefaultView.Item(0).Item("Location"))
            warehouses.DefaultView.Item(0).Item("Current") += 1
        Next
        serial_warehouses.DefaultView.Sort = "Warehouse"
        Return serial_warehouses.DefaultView.ToTable
    End Function

    Private Sub Clean()
        partnumber = Nothing
        Partnumber_txt.Text = ""
        Quantity_txt.Text = ""
        Lot_txt.Text = ""
        Containers_nud.Value = 1
        Lot_lbl.Visible = False
        Lot_txt.Visible = False
        ExpirationDate_dtp.Value = Now
        ExpirationDate_dtp.Visible = False
        Expiration_lbl.Visible = False
        NoExpiraton_chk.Visible = False
        NoExpiraton_chk.Checked = False
        UoM_cbo.Items.Clear()
        UoM_lbl.Text = "Unidad"
        IsCritical = False
        HasQualityAlert = False
    End Sub

    Private Sub Rec_NewSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub NoExpiraton_chk_CheckedChanged(sender As Object, e As EventArgs) Handles NoExpiraton_chk.CheckedChanged

    End Sub
End Class