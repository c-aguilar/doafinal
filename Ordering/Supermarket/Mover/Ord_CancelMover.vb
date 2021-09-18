Public Class Ord_CancelMover
    Private Sub Ord_CancelMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.cross_16
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable
        If User.Current.IsAdmin Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] WHERE M.Status IN ('N','A','P');"))
        Else
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] WHERE Username = '{0}' AND M.Status IN ('N','A');", User.Current.Username))
        End If
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("cancel_btn").Index Then
            If SQL.Current.Update("Ord_Movers", "Status", "C", "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value) Then
                LoadMovers()
                FlashAlerts.ShowConfirm("Mover cancelado.")
            Else
                FlashAlerts.ShowError("Error al cancelar el mover.")
            End If
        End If
    End Sub

    Private Sub Ord_CancelMover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadMovers()
    End Sub

    Private Sub Ord_CancelMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class