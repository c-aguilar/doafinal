Public Class CR_Picklist
    Dim picklist_dt As New DataTable
    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If picklist_dt.Rows.Count > 0 Then
            Try
                LoadingScreen.Show()
                Dim list_to_download As New ArrayList
                For Each row As DataRow In picklist_dt.Rows
                    list_to_download.Add(row.Item("Material"))
                Next
                If list_to_download.Count > 0 Then
                    Dim bom As DataTable = CR.GetBOM(list_to_download)
                    Dim column_mapping(2) As SqlClient.SqlBulkCopyColumnMapping
                    column_mapping(0) = New SqlClient.SqlBulkCopyColumnMapping("ID", "PicklistID")
                    column_mapping(1) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
                    column_mapping(2) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")

                    Dim mat_bom As New DataTable
                    mat_bom.Columns.Add("ID", GetType(Integer))
                    mat_bom.Columns.Add("Partnumber", GetType(String))
                    mat_bom.Columns.Add("Quantity", GetType(Decimal))

                    Select Case CR.UpdateBOM(bom)
                        Case CR.BOMResult.OK
                            Dim all_bom As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Material, Partnumber, Quantity FROM vw_Sys_BOM_Stg3 WHERE Material IN ('{0}');", String.Join("','", list_to_download.ToArray)), "BOM")
                            Dim good_id As New List(Of Picklist)

                            For Each row As DataRow In picklist_dt.Rows
                                mat_bom.Clear()
                                If all_bom.Compute("COUNT(Partnumber)", String.Format("Material = '{0}'", row.Item("Material"))) > 0 Then
                                    If SQL.Current.Insert("CR_Picklist", {"Username", "Material", "Quantity", "ManufacturingDate", "ShippingDate"}, {User.Current.Username, row.Item("Material"), row.Item("Quantity"), row.Item("ManufacturingDate"), row.Item("ShippingDate")}) Then
                                        Dim id As Integer = SQL.Current.GetScalar("MAX(ID)", "CR_Picklist", {"Username", "Material", "Quantity", "Status"}, {User.Current.Username, row.Item("Material"), row.Item("Quantity"), "N"})
                                        For Each part As DataRow In all_bom.Select(String.Format("Material = '{0}'", row.Item("Material")))
                                            mat_bom.Rows.Add(id, part.Item("Partnumber"), part.Item("Quantity") * row.Item("Quantity"))
                                        Next
                                        If SQL.Current.Bulk(mat_bom, "CR_PicklistPartnumbers", column_mapping) Then
                                            good_id.Add(New Picklist(id, row.Item("Material"), row.Item("Quantity"), row.Item("ManufacturingDate"), row.Item("ShippingDate")))
                                        End If
                                    End If
                                End If
                            Next
                            LoadingScreen.Hide()
                            If good_id.Count > 0 Then
                                If MessageBox.Show("¿Imprimir picklist?", "Delta ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    For Each p As Picklist In good_id
                                        p.Print()
                                    Next
                                End If
                                picklist_dt.Clear()
                                FlashAlerts.ShowConfirm("¡Picklist generados!")
                            Else
                                FlashAlerts.ShowError("No fue posible generar ningún picklist.")
                            End If
                        Case CR.BOMResult.OKWithMissings
                            LoadingScreen.Hide()
                            FlashAlerts.ShowInformation("BOM actualizado correctamente pero existen componentes nuevos que no pudieron ser cargados.", 10)
                        Case CR.BOMResult.ErrorOnSave
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al guardar el BOM.")
                        Case CR.BOMResult.ErroOnDownload
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al descargar la información del BOM.")
                    End Select
                End If
            Catch ex As Exception
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al generar el picklist.")
            End Try
        End If
    End Sub

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim clipboard As DataTable = DTable.FromClipboard()
        If clipboard.Columns.Count >= 4 Then
            For Each c As DataRow In clipboard.Rows
                For i = 0 To 3 'quitar espacios
                    c.Item(i) = c.Item(i).ToString.Trim
                Next
                Try
                    picklist_dt.Rows.Add(c.Item(0), c.Item(1), CDate(c.Item(2)), CDate(c.Item(3)))
                Catch ex As Exception
                    FlashAlerts.ShowError("Error con la información ingresada.")
                End Try
            Next
        Else
            FlashAlerts.ShowError("No hay nada en el portapapeles.")
        End If
    End Sub

    Private Sub CR_Picklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picklist_dt.Columns.Add("Material")
        picklist_dt.Columns.Add("Quantity", GetType(Integer))
        picklist_dt.Columns.Add("ManufacturingDate", GetType(Date))
        picklist_dt.Columns.Add("ShippingDate", GetType(Date))
        Material_dgv.DataSource = picklist_dt
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If SCH.IsMaterialFormat(Material_txt.Text) Then
            picklist_dt.Rows.Add(Material_txt.Text, Quantity_nud.Value, MfgDate_dtp.Value.Date, ShipDate_dtp.Value.Date)
            Material_txt.Clear()
            Quantity_nud.Value = 1
        End If
    End Sub
End Class