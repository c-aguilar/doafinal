Public Class QLY_RemoveSerialAlert
    Dim alerts As DataTable
    Private Sub QLY_RemoveAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If alerts IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(alerts, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(alerts, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = alerts
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

    Private Sub RefreshAlerts()
        alerts = SQL.Current.GetDatatable("SELECT S.Serialnumber,S.Partnumber,R.SupplierPartnumber,R.SupplierName,A.Reason,S.[Date],~RedTag AS [Check] FROM Smk_Serials AS S LEFT OUTER JOIN Qly_PartnumberAlerts AS A ON dbo.QLY_AlertID(S.Partnumber,S.[Date]) = A.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.RedTag = 1;")
        Alerts_dgv.DataSource = alerts
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshAlerts()
    End Sub

    Private Sub QLY_RemoveAlert_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshAlerts()
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If alerts IsNot Nothing Then
            For Each s As DataRow In alerts.Rows
                s.Item("Check") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If alerts IsNot Nothing AndAlso alerts.Compute("COUNT([Serialnumber])", "Check = 1") > 0 Then
            If MessageBox.Show("¿Seguro de desbloquear las series seleccionadas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each s As DataRow In alerts.Rows
                    If s.Item("Check") Then
                        If SQL.Current.Update("Smk_Serials", "RedTag", 0, "Serialnumber", s.Item("Serialnumber")) Then
                            Log(s.Item("Serialnumber"), "Qly_SerialUnlock")
                        End If
                    End If
                Next
                RefreshAlerts()
                FlashAlerts.ShowConfirm("Series desbloqueadas.")
            End If
        End If
    End Sub

    Private Sub QLY_RemoveSerialAlert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class