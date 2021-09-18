Public Class Rec_TrackerToService
    Dim tracker As DataTable
    Dim sb As SearchBox
    Private Sub Rec_TrackerToService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Me.Tracker_dgv)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If tracker IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(tracker, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(tracker, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = tracker
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

    Private Sub RefreshTracker()
        Tracker_dgv.DataBindings.Clear()
        tracker = SQL.Current.GetDatatable("SELECT Serialnumber,Partnumber,Quantity,UoM,[Date],Container,TruckNumber,0 AS [Check] FROM Smk_Serials WHERE InvoiceTrouble = 1 ORDER BY [Date]")
        Tracker_dgv.DataSource = tracker
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshTracker()
    End Sub

    Private Sub Rec_TrackerToService_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshTracker()
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If tracker IsNot Nothing Then
            For Each s As DataRow In tracker.Rows
                s.Item("Check") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub Deliver_btn_Click(sender As Object, e As EventArgs) Handles Deliver_btn.Click
        If tracker IsNot Nothing AndAlso tracker.Compute("COUNT([Serialnumber])", "Check = 1") > 0 Then
            If MessageBox.Show("¿Seguro de liberar las series del tracker?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each s As DataRow In tracker.Rows
                    If s.Item("Check") Then
                        If SQL.Current.Execute(String.Format("UPDATE Smk_Serials SET [Date] = GETDATE(), InvoiceTrouble = 0 WHERE Serialnumber = '{0}' AND InvoiceTrouble = 1;", s.Item("Serialnumber"))) Then 'LE CAMBIA TAMBIEN LA FECHA PARA QUE EL COMPARATIVO DE LA MB51 SALGA CORRECTO
                            Log(String.Format("{0}|{1}", s.Item("Serialnumber"), s.Item("Date")), "Rec_ReleaseFromTracker")
                        End If
                    End If
                Next
                RefreshTracker()
                FlashAlerts.ShowConfirm("Serie(s) liberada(s).")
            End If
        End If
    End Sub

    Private Sub Rec_TrackerToService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
    End Sub
End Class