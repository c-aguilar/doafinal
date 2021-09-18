Public Class Smk_PickUpMoverManual

    Private Sub Smk_PickUpMoverManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMovers()
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.Status IN ('A');"))
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Movers_dgv.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("pickup_btn").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Left + (e.CellBounds.Width / 2) - 8, e.CellBounds.Top + (e.CellBounds.Height / 2) - 8, 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.ok_16, rect)
            e.Handled = True
        End If
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("pickup_btn").Index Then
            If MessageBox.Show("¿Confirmar que el mover se ha surtido?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim MoverID As Integer = Movers_dgv.Rows(e.RowIndex).Cells("ID").Value
                SQL.Current.Execute(String.Format("UPDATE Ord_Movers SET Status = 'P',PickedUpUsername = '{0}', PickedUpDate = GETDATE() WHERE  ID = {1};", User.Current.Username, MoverID))
                Alert(SQL.Current.GetString("Username", "Ord_Movers", "ID", MoverID, ""), String.Format("El mover {0} ha sido surtido por supermercado.", MoverID))
                LoadMovers()
            End If
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs)
        LoadMovers()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadMovers()
    End Sub

    Private Sub Smk_PickUpMoverManual_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class