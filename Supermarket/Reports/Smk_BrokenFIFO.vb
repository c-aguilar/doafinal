Public Class Smk_BrokenFIFO

    Private Sub Smk_BrokenFIFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Badge_txt_Enter(sender As Object, e As EventArgs) Handles Badge_txt.Enter
        Badge_rb.Checked = True
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        If Partnumber_rb.Checked Then
            If Partnumber_txt.MaskCompleted Then
                Report_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,B.TakenSerialnumber AS [Serie tomada],B.NextSerialnumber AS [Serie correcta],B.[Date] AS Fecha,U.FullName AS Usuario FROM Smk_BrokenFIFO AS B INNER JOIN Smk_Serials AS S ON B.NextSerialnumber = S.Serialnumber INNER JOIN Sys_Users AS U ON B.Badge = U.Badge WHERE S.Partnumber = '{0}' AND CONVERT(DATE,B.[Date]) BETWEEN '{1}' AND '{2}'; ", Partnumber_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "FIFO Quebrado")
            ElseIf Partnumber_txt.Text = "" Then
                Report_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,B.TakenSerialnumber AS [Serie tomada],B.NextSerialnumber AS [Serie correcta],B.[Date] AS Fecha,U.FullName AS Usuario FROM Smk_BrokenFIFO AS B INNER JOIN Smk_Serials AS S ON B.NextSerialnumber = S.Serialnumber INNER JOIN Sys_Users AS U ON B.Badge = U.Badge WHERE CONVERT(DATE,B.[Date]) BETWEEN '{0}' AND '{1}'; ", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "FIFO Quebrado")
            Else
                FlashAlerts.ShowInformation("Captura el numero de parte completo.")
            End If
        ElseIf Badge_rb.Checked Then
            If Badge_txt.MaskCompleted Then
                Report_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,B.TakenSerialnumber AS [Serie tomada],B.NextSerialnumber AS [Serie correcta],B.[Date] AS Fecha,U.FullName AS Usuario FROM Smk_BrokenFIFO AS B INNER JOIN Smk_Serials AS S ON B.NextSerialnumber = S.Serialnumber INNER JOIN Sys_Users AS U ON B.Badge = U.Badge WHERE B.Badge = '{0}' AND CONVERT(DATE,B.[Date]) BETWEEN '{1}' AND '{2}'; ", Badge_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "FIFO Quebrado")
            Else
                FlashAlerts.ShowInformation("Captura el numero de gafete completo.")
            End If
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Report_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Report_dgv.DataSource, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Report_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Report_dgv.DataSource
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

    Private Sub Smk_BrokenFIFO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class