Public Class CR_DeletePicklist
    Private Sub CR_PrintPicklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Picklists_dgv.Columns("delete_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.delete_16
        LoadPicklists()
    End Sub

    Private Sub LoadPicklists()
        Dim movers As DataTable
        If User.Current.IsAdmin OrElse User.Current.Role = "ORD Supervisor" OrElse User.Current.Role = "CR Supervisor" Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, [Date],Material,Quantity, Partnumbers,ManufacturingDate, ShippingDate FROM CR_Picklist AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN (SELECT PicklistID,COUNT(*) AS Partnumbers FROM CR_PicklistPartnumbers GROUP BY PicklistID) AS P ON M.ID = P.PicklistID WHERE M.Status = 'N';"))
        Else
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, [Date],Material,Quantity, Partnumbers,ManufacturingDate, ShippingDate FROM CR_Picklist AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN (SELECT PicklistID,COUNT(*) AS Partnumbers FROM CR_PicklistPartnumbers GROUP BY PicklistID) AS P ON M.ID = P.PicklistID WHERE M.Status = 'N' AND M.Username = '{3}';", User.Current.Username))
        End If
        Picklists_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Picklists_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Picklists_dgv.Columns("delete_btn").Index Then
            Try
                If SQL.Current.Update("CR_Picklist", "Status", "D", "ID", Picklists_dgv.Rows(e.RowIndex).Cells("id").Value) Then
                    LoadPicklists()
                    FlashAlerts.ShowConfirm("Hecho!")
                Else
                    FlashAlerts.ShowError("No fue posible eliminar el picklist.")
                End If
            Catch ex As Exception
                FlashAlerts.ShowError("Surgio un error al eliminar el picklist.")
            End Try
        End If
    End Sub

    Private Sub Ord_PrintMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadPicklists()
    End Sub
End Class