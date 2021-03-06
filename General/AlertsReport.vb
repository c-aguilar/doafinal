Public Class AlertsReport

    Private Sub AlertsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshAlerts()
    End Sub

    Public Sub RefreshAlerts()
        Alerts_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT A.ID, U.FullName, [Date], [Description] FROM Sys_UserAlerts AS A INNER JOIN Sys_Users AS U ON A.Username = U.Username WHERE [To] = '{0}' AND A.[Active] = 1", User.Current.Username))
    End Sub

    Private Sub Alerts_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Alerts_dgv.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Alerts_dgv.Columns("desactive_btn").Index Then
            SQL.Current.Update("Sys_UserAlerts", "Active", 0, "ID", Alerts_dgv.Rows(e.RowIndex).Cells("ID").Value)
            RefreshAlerts()
        End If
    End Sub

    Private Sub Alerts_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Alerts_dgv.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Alerts_dgv.Columns("desactive_btn").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Left + (e.CellBounds.Width / 2) - 8, e.CellBounds.Top + (e.CellBounds.Height / 2) - 8, 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.cross_16, rect)
            e.Handled = True
        End If
    End Sub
End Class