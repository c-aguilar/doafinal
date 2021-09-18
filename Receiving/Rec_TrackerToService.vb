Public Class Rec_TrackerToService
    Dim tracker As DataTable
    Dim sb As SearchBox
    Private Sub Rec_TrackerToService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Tracker_dgv)

    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(tracker, Title_lbl.Text)
    End Sub

    Private Sub RefreshTracker()
        Tracker_dgv.DataBindings.Clear()
        tracker = SQL.Current.GetDatatable("SELECT Serialnumber,Partnumber,OriginalQuantity,UoM,CurrentQuantity,[Date],TruckNumber,0 AS [Check] FROM vw_Smk_Serials WHERE InvoiceTrouble = 1 AND [Status] NOT IN ('D','E') ORDER BY [Date]")
        Tracker_dgv.DataSource = tracker
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshTracker()
    End Sub

    Private Sub Rec_TrackerToService_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RefreshTracker()
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If tracker IsNot Nothing Then
            For Each s As DataRowView In tracker.DefaultView
                s.Item("Check") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub Deliver_btn_Click(sender As Object, e As EventArgs) Handles Deliver_btn.Click
        If tracker IsNot Nothing AndAlso tracker.DefaultView.ToTable.Compute("COUNT([Serialnumber])", "Check = 1") > 0 Then
            If NoTransfer_chk.Checked Then
                If MessageBox.Show("¿Seguro de liberar las series del tracker sin transferir el inventario a sloc 0002?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    For Each s As DataRowView In tracker.DefaultView
                        If s.Item("Check") Then
                            Dim serial As New Serialnumber(s.Item("Serialnumber"))
                            serial.UnlockTracker(False)
                        End If
                    Next
                    RefreshTracker()
                    FlashAlerts.ShowConfirm("Serie(s) liberada(s).")
                End If
            Else
                If MessageBox.Show("¿Seguro de liberar las series del tracker?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each s As DataRowView In tracker.DefaultView
                        If s.Item("Check") Then
                            Dim serial As New Serialnumber(s.Item("Serialnumber"))
                            serial.UnlockTracker()
                        End If
                    Next
                    RefreshTracker()
                    FlashAlerts.ShowConfirm("Serie(s) liberada(s).")
                End If
            End If
        End If
    End Sub

    Private Sub Rec_TrackerToService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
        sb.BringToFront()
    End Sub
End Class