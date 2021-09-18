Public Class Rec_SerialHistory
    Dim serials As DataTable
    Private Sub Rec_ReprintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        If Serialnumber_rb.Checked Then
            If Serial_txt.Text <> "" Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],Description AS Descripcion,OriginalQuantity AS StdPack,CurrentQuantity AS [Cantidad Actual],UoM AS Unidad,StatusDescription AS [Estatus],Location AS Localizacion,WarehouseName AS Estacion,TruckNumber AS Troca,Container AS Contenedor,RedTag AS [Bloqueado por Calidad],InvoiceTrouble AS [Problema de Pago],[Date] AS [Fecha] FROM vw_Smk_Serials WHERE SerialNumber LIKE '%{0}' ORDER BY SerialNumber DESC", Serial_txt.Text))
            End If
        ElseIf Partnumber_rb.Checked Then
            If Partnumber_txt.Text = "" AndAlso Partnumber_txt.Text = "*" Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],Description AS Descripcion,OriginalQuantity AS StdPack,CurrentQuantity AS [Cantidad Actual],UoM AS Unidad,StatusDescription AS [Estatus],Location AS Localizacion,WarehouseName AS Estacion,TruckNumber AS Troca,Container AS Contenedor,RedTag AS [Bloqueado por Calidad],InvoiceTrouble AS [Problema de Pago],[Date] AS [Fecha] FROM vw_Smk_Serials WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY SerialNumber DESC", From_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss")))
            Else
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],Description AS Descripcion,OriginalQuantity AS StdPack,CurrentQuantity AS [Cantidad Actual],UoM AS Unidad,StatusDescription AS [Estatus],Location AS Localizacion,WarehouseName AS Estacion,TruckNumber AS Troca,Container AS Contenedor,RedTag AS [Bloqueado por Calidad],InvoiceTrouble AS [Problema de Pago],[Date] AS [Fecha] FROM vw_Smk_Serials WHERE Partnumber LIKE '%{0}%' AND [Date] BETWEEN '{1}' AND '{2}' ORDER BY SerialNumber DESC", Partnumber_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss")))
            End If
        End If
        Serials_dgv.DataSource = serials
        LoadingScreen.Hide()
    End Sub

    Private Sub From_dtp_ValueChanged(sender As Object, e As EventArgs) Handles From_dtp.ValueChanged, To_dtp.ValueChanged
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Serial_txt_Enter(sender As Object, e As EventArgs) Handles Serial_txt.Enter
        Serialnumber_rb.Checked = True
    End Sub

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Rec_ReprintLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If serials IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(serials, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(serials, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = serials
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
End Class