Public Class CR_PrintPicklist
    Private Sub CR_PrintPicklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = SQL.Current.GetDatatable("SELECT [FullName],U.Username FROM Sys_Users AS U INNER JOIN (SELECT DISTINCT Username FROM CR_Picklist) AS M ON U.Username = M.Username ")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        If users.Compute("COUNT(Username)", String.Format("Username = '{0}'", User.Current.Username)) > 0 Then
            Username_cbo.SelectedValue = User.Current.Username
        Else
            Username_cbo.SelectedValue = "*"
        End If
        CType(Picklists_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
        LoadPicklists()
    End Sub

    Private Sub LoadPicklists()
        Dim movers As DataTable
        If ID_rb.Checked AndAlso IsNumeric(ID_txt.Text) Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, [Date],Material,Quantity, Partnumbers,ManufacturingDate, ShippingDate FROM CR_Picklist AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN (SELECT PicklistID,COUNT(*) AS Partnumbers FROM CR_PicklistPartnumbers GROUP BY PicklistID) AS P ON M.ID = P.PicklistID WHERE M.ID = {0};", ID_txt.Text))
            Picklists_dgv.DataSource = movers
        ElseIf Username_rb.Checked Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, [Date],Material,Quantity, Partnumbers,ManufacturingDate, ShippingDate FROM CR_Picklist AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN (SELECT PicklistID,COUNT(*) AS Partnumbers FROM CR_PicklistPartnumbers GROUP BY PicklistID) AS P ON M.ID = P.PicklistID WHERE M.Status IN ('{0}','{1}','{2}') AND M.Username = '{3}';", If(News_chk.Checked, "N", ""), If(PickedUp_chk.Checked, "P", ""), If(Shipped_chk.Checked, "S", ""), Username_cbo.SelectedValue))
            Picklists_dgv.DataSource = movers
        End If
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Picklists_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Picklists_dgv.Columns("print_btn").Index Then
            Try
                Dim picklist As New Picklist(Picklists_dgv.Rows(e.RowIndex).Cells("id").Value)
                picklist.Print()
            Catch ex As Exception
                FlashAlerts.ShowError("Surgio un error al imprimir el picklist.")
            End Try
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Shipped_chk.CheckedChanged, PickedUp_chk.CheckedChanged, News_chk.CheckedChanged
        LoadPicklists()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadPicklists()
    End Sub

    Private Sub ID_txt_Enter(sender As Object, e As EventArgs) Handles ID_txt.Enter
        ID_rb.Checked = True
    End Sub

    Private Sub Username_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Username_cbo.SelectionChangeCommitted
        Username_rb.Checked = True
    End Sub

    Private Sub Ord_PrintMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadPicklists()
    End Sub
End Class