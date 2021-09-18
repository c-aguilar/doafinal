Public Class Smk_NewSerial
    Dim partnumber As RawMaterial
    Dim IsCritical As Boolean = False
    Dim HasQualityAlert As Boolean = False
    Public DefaultWarehouse As String
    Private Sub Rec_NewSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultWarehouse = SQL.Current.GetString("SELECT TOP 1 Warehouse FROM Smk_Warehouses")
        GF.FillCombobox(Container_cbo, SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Cable-Container' ORDER BY Name"), "Name", "ID")
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
                Dim UoM As String = UoM_cbo.SelectedItem
                If partnumber.Type = RawMaterial.MaterialType.Cable Then
                    If Container_cbo.SelectedIndex = -1 Then
                        FlashAlerts.ShowError("Debe seleccionar el contenedor.")
                        Exit Sub
                    Else
                        Container = Container_cbo.SelectedValue
                    End If
                End If

                Dim serials As New DataTable
                serials.Columns.Add("Partnumber")
                serials.Columns.Add("Quantity", GetType(Decimal))
                serials.Columns.Add("UoM")
                serials.Columns.Add("ContainerID")
                serials.Columns.Add("TruckNumber")
                serials.Columns.Add("RedTag", GetType(Boolean))
                serials.Columns.Add("Critical", GetType(Boolean))
                serials.Columns.Add("Scanner", GetType(Integer))
                serials.Columns.Add("Location")
                serials.Columns.Add("Warehouse")
                serials.Columns.Add("ExpirationDate")
                serials.Columns.Add("Lot")
                serials.Columns.Add("Badge")
                serials.Columns.Add("New", GetType(Boolean))
                serials.Columns.Add("Status")

                Dim column_mapping(14) As SqlClient.SqlBulkCopyColumnMapping
                column_mapping(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                column_mapping(1) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
                column_mapping(2) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
                column_mapping(3) = New SqlClient.SqlBulkCopyColumnMapping("ContainerID", "ContainerID")
                column_mapping(4) = New SqlClient.SqlBulkCopyColumnMapping("TruckNumber", "TruckNumber")
                column_mapping(5) = New SqlClient.SqlBulkCopyColumnMapping("RedTag", "RedTag")
                column_mapping(6) = New SqlClient.SqlBulkCopyColumnMapping("Critical", "Critical")
                column_mapping(7) = New SqlClient.SqlBulkCopyColumnMapping("Scanner", "Scanner")
                column_mapping(8) = New SqlClient.SqlBulkCopyColumnMapping("Location", "Location")
                column_mapping(9) = New SqlClient.SqlBulkCopyColumnMapping("Warehouse", "Warehouse")
                column_mapping(10) = New SqlClient.SqlBulkCopyColumnMapping("ExpirationDate", "ExpirationDate")
                column_mapping(11) = New SqlClient.SqlBulkCopyColumnMapping("Lot", "Lot")
                column_mapping(12) = New SqlClient.SqlBulkCopyColumnMapping("Badge", "Badge")
                column_mapping(13) = New SqlClient.SqlBulkCopyColumnMapping("New", "New")
                column_mapping(14) = New SqlClient.SqlBulkCopyColumnMapping("Status", "Status")

                If Not partnumber.Expirable Then
                    For i = 1 To Containers_nud.Value
                        serials.Rows.Add(partnumber.Partnumber, Quantity_txt.Text, UoM, Container, "Smk", HasQualityAlert, IsCritical, 0, RawMaterial.GetServiceLocation(partnumber.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, DBNull.Value, DBNull.Value, User.Current.Badge, False, "P")
                    Next
                ElseIf ((Not NoExpiraton_chk.Checked AndAlso ExpirationDate_dtp.Value.Date > CurrentDate.Date) OrElse NoExpiraton_chk.Checked) AndAlso Lot_txt.Text <> "" Then
                    For i = 1 To Containers_nud.Value
                        serials.Rows.Add(partnumber.Partnumber, Quantity_txt.Text, UoM, Container, "Smk", HasQualityAlert, IsCritical, 0, RawMaterial.GetServiceLocation(partnumber.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, IIf(NoExpiraton_chk.Checked, "2050-12-31", ExpirationDate_dtp.Value.ToString("yyyy-MM-dd")), Lot_txt.Text, User.Current.Badge, False, "P")
                    Next
                Else
                    FlashAlerts.ShowInformation("Debe seleccionar una fecha de expiracion valida y lote.")
                    Exit Sub
                End If
                If SQL.Current.Bulk(serials, "Smk_Serials", column_mapping) Then
                    Dim labels = SQL.Current.GetDatatable(String.Format("SELECT TOP {1} serialnumber,partnumber,description,[date],currentquantity,uom,location,warehousename,redtag,critical,supplierpartnumber,suppliername,labellegend,trucknumber FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Scanner = 0 AND [New] = 0 AND TruckNumber = 'Smk' AND [Status] = 'P' ORDER BY ID DESC", partnumber.Partnumber, Containers_nud.Value))
                    REC.PrintLabels(labels, False)
                    FlashAlerts.ShowConfirm("Series generadas correctamente.")
                    Clean()
                Else
                    FlashAlerts.ShowError("Error al registrar la nueva serie.")
                End If
            Else
                FlashAlerts.ShowInformation("Falta información por llenar.")
            End If
        End If
    End Sub

    

    Private Sub Clean()
        partnumber = Nothing
        Partnumber_txt.Clear()
        Quantity_txt.Clear()
        Lot_txt.Clear()
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

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            partnumber = New RawMaterial(Partnumber_txt.Text)
            If Not partnumber.Exist Then
                Clean()
                FlashAlerts.ShowError("No existe el numero de parte.")
                Exit Sub
            End If

            If Not SQL.Current.Exists("Smk_Map", "Partnumber", partnumber.Partnumber) Then
                Clean()
                FlashAlerts.ShowError("Numero de parte sin local.")
                Exit Sub
            End If

            Select Case partnumber.Type
                Case RawMaterial.MaterialType.Cable
                    Container_cbo.Visible = True
                    Container_lbl.Visible = True
                Case Else
                    Container_cbo.Visible = False
                    Container_lbl.Visible = False
            End Select

            UoM_cbo.Items.Clear()
            Dim uoms As ArrayList = RawMaterial.GetUoMOptions(Partnumber_txt.Text)
            If Not uoms.Contains(partnumber.OrderUnit.ToString) Then uoms.Add(partnumber.OrderUnit.ToString)
            UoM_cbo.Items.AddRange(uoms.ToArray)
            UoM_cbo.SelectedItem = partnumber.OrderUnit.ToString

            'SE SUPONE QUE ESTAS NUEVAS ETIQUETAS SON POR REETIQUETADO
            HasQualityAlert = False 'SQL.Current.Exists("Qly_PartnumberAlerts", {"Partnumber", "Active"}, {partnumber.Partnumber, 1})
            IsCritical = False 'SQL.Current.Exists("Rec_CriticalPartnumbers", {"Partnumber", "Active"}, {partnumber.Partnumber, 1})

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
            Quantity_txt.Focus()
        End If
    End Sub
End Class