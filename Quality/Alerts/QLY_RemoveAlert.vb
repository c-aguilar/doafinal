Public Class QLY_RemoveAlert
    Dim sb As SearchBox
    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub QLY_RemoveAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Alerts_dgv)
        CType(Alerts_dgv.Columns("remove_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.shield_delete
    End Sub

    Private Sub Alerts_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Alerts_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Alerts_dgv.Columns("remove_btn").Index Then
            If MessageBox.Show("¿Desactivar la alerta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If SQL.Current.Execute(String.Format("UPDATE Qly_PartnumberAlerts SET Active = 0, DateInactive = GETDATE() WHERE ID = {0};", Alerts_dgv.Rows(e.RowIndex).Cells("ID").Value)) Then
                    Log(Alerts_dgv.Rows(e.RowIndex).Cells("ID").Value, "Qly_RemoveAlert")
                    RefreshAlerts()
                    FlashAlerts.ShowConfirm("Alerta desactiva.")
                Else
                    FlashAlerts.ShowError("Error al desactivar la alerta.")
                End If
            End If
        End If
    End Sub

    Private Sub RefreshAlerts()
        Dim alerts As DataTable = SQL.Current.GetDatatable("SELECT A.ID,A.Partnumber,R.SupplierPartnumber,A.Reason,A.[Date],U.FullName FROM Qly_PartnumberAlerts AS A INNER JOIN Sys_RawMaterial AS R ON A.Partnumber = R.Partnumber INNER JOIN Sys_Users AS U ON A.Username = U.Username WHERE A.Active = 1 ORDER BY A.[Date] ASC")
        Alerts_dgv.DataSource = alerts
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshAlerts()
    End Sub

    Private Sub QLY_RemoveAlert_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshAlerts()
    End Sub

    Private Sub QLY_RemoveAlert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class