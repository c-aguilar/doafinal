Public Class Smk_FindSerial

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Serial_txt_Enter(sender As Object, e As EventArgs) Handles Serial_txt.Enter
        Serial_rb.Checked = True
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        If Partnumber_rb.Checked Then
            Dim status As New ArrayList
            If Receiving_chk.Checked Then status.AddRange({"N", "P"})
            If Random_chk.Checked Then status.Add("S")
            If Service_chk.Checked Then status.AddRange({"O", "C"})
            If Empty_chk.Checked Then status.Add("E")
            If Quality_chk.Checked Then status.AddRange({"Q", "U"})
            If Tracker_chk.Checked Then status.Add("T")

            If Partnumber_txt.Text.Trim.Length = 8 Then
                Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,RedTag,InvoiceTrouble,Location,WarehouseName,[Date],CASE WHEN [Status] = 'E' THEN dbo.Smk_SerialEmptyDate(ID) ELSE NULL END AS DateEmpty FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}') ORDER BY ID", Partnumber_txt.Text, String.Join("','", status.ToArray)), "Series")
                Dim partnumber As New RawMaterial(Partnumber_txt.Text)
                If partnumber.Exist Then
                    Partnumber_lbl.Text = partnumber.Partnumber
                    Description_lbl.Text = partnumber.Description
                    UoM_lbl.Text = partnumber.UoM.ToString
                    Supplier_lbl.Text = partnumber.SupplierPartnumber
                    Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
                    Select Case partnumber.Consumption
                        Case RawMaterial.ConsumptionType.Total
                            Consumption_lbl.Text = "Directo"
                        Case RawMaterial.ConsumptionType.Partial
                            Consumption_lbl.Text = "Parcial"
                        Case RawMaterial.ConsumptionType.Mixed
                            Consumption_lbl.Text = "Mixto"
                    End Select
                    Total_lbl.Text = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(Partnumber,UoM,CurrentQuantity,'{2}')) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}')", Partnumber_txt.Text, String.Join("','", status.ToArray), partnumber.UoM.ToString))
                Else
                    Partnumber_lbl.Text = "-"
                    Description_lbl.Text = "-"
                    UoM_lbl.Text = "-"
                    Supplier_lbl.Text = "-"
                    Location_lbl.Text = "-"
                    Consumption_lbl.Text = "-"
                    Total_lbl.Text = "-"
                End If
            ElseIf Partnumber_txt.Text = "" OrElse Partnumber_txt.Text = "*" Then
                Partnumber_lbl.Text = "-"
                Description_lbl.Text = "-"
                UoM_lbl.Text = "-"
                Supplier_lbl.Text = "-"
                Location_lbl.Text = "-"
                Consumption_lbl.Text = "-"
                Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,RedTag,InvoiceTrouble,Location,WarehouseName,[Date],CASE WHEN [Status] = 'E' THEN dbo.Smk_SerialEmptyDate(ID) ELSE NULL END AS DateEmpty FROM vw_Smk_Serials WHERE [Status] IN ('{0}') ORDER BY ID", String.Join("','", status.ToArray)), "Series")
            Else
                FlashAlerts.ShowInformation("Captura el numero de parte completo.")
            End If
        ElseIf Serial_rb.Checked Then
            If SMK.IsSerial(Serial_txt.Text) Then
                Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,RedTag,InvoiceTrouble,Location,WarehouseName,[Date],CASE WHEN Status = 'E' THEN dbo.Smk_SerialEmptyDate(ID) ELSE NULL END AS DateEmpty FROM vw_Smk_Serials WHERE SerialNumber = '{0}'", Serial_txt.Text), "Series")
                Dim partnumber As New RawMaterial(SQL.Current.GetString("Partnumber", "Smk_Serials", "Serialnumber", Serial_txt.Text, ""))
                If partnumber.Exist Then
                    Partnumber_lbl.Text = partnumber.Partnumber
                    Description_lbl.Text = partnumber.Description
                    UoM_lbl.Text = partnumber.UoM.ToString
                    Supplier_lbl.Text = partnumber.SupplierPartnumber
                    Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
                    Select Case partnumber.Consumption
                        Case RawMaterial.ConsumptionType.Total
                            Consumption_lbl.Text = "Directo"
                        Case RawMaterial.ConsumptionType.Partial
                            Consumption_lbl.Text = "Parcial"
                        Case RawMaterial.ConsumptionType.Mixed
                            Consumption_lbl.Text = "Mixto"
                    End Select
                Else
                    Partnumber_lbl.Text = "-"
                    Description_lbl.Text = "-"
                    UoM_lbl.Text = "-"
                    Supplier_lbl.Text = "-"
                    Location_lbl.Text = "-"
                    Consumption_lbl.Text = "-"
                End If
            Else
                FlashAlerts.ShowInformation("Captura el numero de serie completo.")
            End If
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Serials_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Serials_dgv.DataSource, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Serials_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Serials_dgv.DataSource
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

    Private Sub Smk_FindSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Clear()
        Serial_txt.Focus()
        CType(Serials_dgv.Columns("details_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.question_16
    End Sub

    Private Sub Smk_FindSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.TextLength = 8 Then
            Find_btn.PerformClick()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Find_btn.PerformClick()
        End If
    End Sub

    Private Sub Quality_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Quality_chk.CheckedChanged

    End Sub

    Private Sub Serials_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Serials_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("details_btn").Index Then
            Dim sm As New Smk_SerialMovements
            sm.Serialnumber = Serials_dgv.Rows(e.RowIndex).Cells("Serialnumber").Value
            sm.Show()
        End If
    End Sub

    Private Sub Description_lbl_Click(sender As Object, e As EventArgs) Handles Description_lbl.Click

    End Sub
End Class