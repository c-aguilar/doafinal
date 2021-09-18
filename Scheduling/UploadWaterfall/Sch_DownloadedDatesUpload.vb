Public Class Sch_DownloadedDatesUpload

    Private Sub frmDates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvResult.DataSource = SQL.Current.GetDatatable("SELECT W.[Date],CASE WHEN [Week] IS NULL THEN 'Not downloaded' ELSE 'Downloaded' END AS [Status] FROM Sch_UploadWeeks AS W LEFT OUTER JOIN (SELECT DISTINCT [Week] FROM Sch_SAP_ProductionPlan) AS D ON W.[Date] = [Week] WHERE W.[Date] <= CONVERT(DATE,GETDATE()) ORDER BY W.[Date] DESC")
    End Sub

    Private Sub dgvResult_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvResult.CellFormatting
        If dgvResult.Rows(e.RowIndex).Cells("Status").Value = "Downloaded" Then
            e.CellStyle.BackColor = Color.LightGreen
        Else
            e.CellStyle.BackColor = Color.LightGray
        End If
    End Sub
End Class