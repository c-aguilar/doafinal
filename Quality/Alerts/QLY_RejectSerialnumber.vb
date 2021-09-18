Public Class QLY_RejectSerialnumber
    Dim alerts As DataTable
    Dim sb As SearchBox
    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub QLY_RejectSerialnumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Alerts_dgv)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(alerts, Title_lbl.Text)
    End Sub

    Private Sub RefreshAlerts()
        alerts = SQL.Current.GetDatatable("SELECT S.Serialnumber,S.Partnumber,R.SupplierPartnumber,R.SupplierName,dbo.Qly_AlertReasons(S.Partnumber, S.[Date]) AS Reason,S.[Date],~RedTag AS [Check] FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.RedTag = 1 AND S.[Status] <> 'D';")
        Alerts_dgv.DataSource = alerts
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshAlerts()
    End Sub

    Private Sub QLY_RemoveAlert_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshAlerts()
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If alerts IsNot Nothing Then
            For Each s As DataRowView In alerts.DefaultView
                s.Item("Check") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If alerts IsNot Nothing AndAlso alerts.DefaultView.ToTable.Compute("COUNT([Serialnumber])", "Check = 1") > 0 Then
            If MessageBox.Show("Las series seleccionadas se eliminaran completamente. ¿Seguro de rechazarlas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each s As DataRowView In alerts.DefaultView
                    If s.Item("Check") Then
                        If SQL.Current.Update("Smk_Serials", "Status", "D", "Serialnumber", s.Item("Serialnumber")) Then
                            Log(s.Item("Serialnumber"), "Qly_SerialRejected")
                        End If
                    End If
                Next
                RefreshAlerts()
                FlashAlerts.ShowConfirm("Series rechazadas.")
            End If
        End If
    End Sub

    Private Sub QLY_RejectSerialnumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class