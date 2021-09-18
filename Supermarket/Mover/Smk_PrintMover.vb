Public Class Smk_PrintMover
    Private Sub Smk_PrintMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
        CType(Movers_dgv.Columns("labels_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.tag_blue_16
        CType(Movers_dgv.Columns("export_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.excel_exports_16
        LoadMovers()
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, [Date], Requisitor, Customer, Partnumbers, T.[Description], Locality, ShippingDate FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.Status IN ('{0}','{1}','{2}');", If(Approved_chk.Checked, "A", ""), If(PickedUp_chk.Checked, "P", ""), If(Shipped_chk.Checked, "S", "")))
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("print_btn").Index Then
            Mover.Print(Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("labels_btn").Index Then
            Mover.PrintLabels(Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("export_btn").Index Then
            Mover.Export(Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Shipped_chk.CheckedChanged, PickedUp_chk.CheckedChanged, Approved_chk.CheckedChanged
        LoadMovers()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadMovers()
    End Sub

    Private Sub Smk_PrintMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Smk_PrintMover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadMovers()
    End Sub
End Class