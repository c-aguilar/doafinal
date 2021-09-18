Public Class Smk_FindSerialKiosk

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        Dim status As New ArrayList
        If Receiving_chk.Checked Then status.AddRange({"N", "P"})
        If Random_chk.Checked Then status.Add("S")
        If Service_chk.Checked Then status.AddRange({"O", "C"})
        If Quality_chk.Checked Then status.AddRange({"Q", "U"})
        If Tracker_chk.Checked Then status.Add("T")

        Dim serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,RedTag,Location,WarehouseName,[Date] FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}') ORDER BY ID", Partnumber_txt.Text, String.Join("','", status.ToArray)), "Series")
        Serials_dgv.DataSource = serials
        Dim partnumber As New RawMaterial(Partnumber_txt.Text)
        If partnumber.Exist Then
            Partnumber_lbl.Text = partnumber.Partnumber
            Description_lbl.Text = partnumber.Description
            Type_lbl.Text = partnumber.Type.ToString
            Supplier_lbl.Text = partnumber.SupplierPartnumber
            Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
            UoM_lbl.Text = partnumber.UoM.ToString
            Select Case partnumber.Consumption
                Case RawMaterial.ConsumptionType.Total
                    Consumption_lbl.Text = "Directo"
                Case RawMaterial.ConsumptionType.Partial
                    Consumption_lbl.Text = "Parcial"
                Case RawMaterial.ConsumptionType.Mixed
                    Consumption_lbl.Text = "Mixto"
            End Select
            Total_lbl.Text = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(Partnumber,UoM,CurrentQuantity,'{2}')) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}')", Partnumber_txt.Text, String.Join("','", status.ToArray), partnumber.UoM.ToString))
            LoadingScreen.Hide()
        Else
            Partnumber_lbl.Text = "-"
            Description_lbl.Text = "-"
            Type_lbl.Text = "-"
            Supplier_lbl.Text = "-"
            Location_lbl.Text = "-"
            Consumption_lbl.Text = "-"
            LoadingScreen.Hide()
            FlashAlerts.ShowError("No existe el numero de parte.")
        End If

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

    Private Sub Smk_FindSerialKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Smk_FindSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.TextLength = 8 Then
            Find_btn.PerformClick()
            Partnumber_txt.Clear()
            Partnumber_txt.Focus()
        ElseIf Partnumber_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub


    Private Sub Smk_FindSerialKiosk_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Partnumber_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class
