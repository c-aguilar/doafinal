Public Class Ord_ControlledPartnumbers

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Partnumber_txt.MaskCompleted Then
            If Not SQL.Current.Exists("Rec_ControlledPartnumbers", {"Partnumber", "Active"}, {Partnumber_txt.Text, 1}) Then
                If SQL.Current.Insert("Rec_ControlledPartnumbers", {"Partnumber", "Username"}, {Partnumber_txt.Text, User.Current.Username}) Then
                    Partnumber_txt.Clear()
                    Partnumber_txt.Focus()
                    GetControlled()
                    FlashAlerts.ShowConfirm("Numero de parte agregado.")
                Else
                    FlashAlerts.ShowError("Error al agregar el numero de parte.")
                End If
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowInformation("El numero de parte ya se encuentra agregado.")
            End If
        Else
            FlashAlerts.ShowInformation("El numero de parte debe contener 8 caracteres.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Actives_dgv.Columns("cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.critical_16
    End Sub

    Private Sub GetControlled()
        Actives_dgv.DataSource = SQL.Current.GetDatatable("SELECT ID,Partnumber,[Date],FullName,C.Username FROM Rec_ControlledPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [Date];")
        
    End Sub

    Private Sub Actives_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Actives_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Actives_dgv.Columns("cancel_btn").Index AndAlso CType(Actives_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled Then
            SQL.Current.Delete("Rec_ControlledPartnumbers", "ID", Actives_dgv.Rows(e.RowIndex).Cells("ID").Value)
            GetControlled()
            FlashAlerts.ShowConfirm("Alerta eliminada.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GetControlled()
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.MaskCompleted Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                Add_btn.Focus()
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowError("El numero de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Actives_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Actives_dgv.DataBindingComplete
        For Each r As DataGridViewRow In Actives_dgv.Rows
            If r.Cells("Username").Value.ToString.ToLower.Trim = User.Current.Username Then
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = True
            Else
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End If
        Next
    End Sub
End Class