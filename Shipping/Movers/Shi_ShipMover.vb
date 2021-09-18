Public Class Shi_ShipMover

    Private Sub Shi_ShipMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("ship_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.ok_16
        CType(Movers_dgv.Columns("export_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.excel_exports_16
        LoadMovers()
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.Status = 'P' AND T.MustShip = 1;"))
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("ship_btn").Index Then
            If MessageBox.Show("¿Confirmar que el mover se ha embarcado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim MoverID As Integer = Movers_dgv.Rows(e.RowIndex).Cells("ID").Value
                SQL.Current.Execute(String.Format("UPDATE Ord_Movers SET Status = 'S', ShippedUsername = '{0}', ShippedDate = GETDATE() WHERE ID = {1};", User.Current.Username, MoverID))
                Delta.Alert(SQL.Current.GetString("Username", "Ord_Movers", "ID", MoverID, ""), String.Format("Mover ID {0} embarcado.", MoverID))
                LoadMovers()
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("export_btn").Index Then
            LoadingScreen.Show()
            Dim MoverID As Integer = Movers_dgv.Rows(e.RowIndex).Cells("ID").Value
            Dim mover As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],Quantity AS Cantidad,UoM AS Unidad,TSA FROM Ord_MoverPartnumbers AS P WHERE MoverID = {0};", MoverID))
            If MyExcel.SaveAs(mover, "Mover " & MoverID, False) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs)
        LoadMovers()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadMovers()
    End Sub

    Private Sub Shi_ShipMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Shi_ShipMover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadMovers()
    End Sub
End Class