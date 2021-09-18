Imports CAguilar
Public Class Smk_CablePendingNextSerials

    Private Sub frmPendingSerials_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CType(Results_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
    End Sub

    Private Sub dgvResults_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Results_dgv.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = Results_dgv.Columns("print_btn").Index Then
            REC.PrintLabel(Results_dgv("Serialnumber", e.RowIndex).Value)
            FlashAlerts.ShowConfirm("Impresion enviada.")
        End If
    End Sub

    Private Sub RefreshSerials()
        Results_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT P.Serialnumber, S.Partnumber,S.StatusDescription,S.Location,S.WarehouseName,O.Fullname,P.[Date] FROM Smk_CableNextSerials AS P INNER JOIN vw_Smk_Serials AS S ON P.Serialnumber = S.Serialnumber INNER JOIN Smk_Operators AS O ON P.Badge = O.Badge WHERE P.Warehouse = '{0}'", My.Settings.Warehouse))
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CablePendingNextSerials_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshSerials()
    End Sub
End Class