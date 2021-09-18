Public Class CR_BusinessScheduledChanges

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Business_cbo.SelectedIndex >= 0 AndAlso Partnumber_txt.MaskCompleted AndAlso NewPartnumber_txt.MaskCompleted Then
            If Not SQL.Current.Exists("CR_BusinessScheduledChanges", {"Business", "OldPartnumber", "Active"}, {Business_cbo.SelectedValue, Partnumber_txt.Text, 1}) Then
                If SQL.Current.Insert("CR_BusinessScheduledChanges", {"Business", "OldPartnumber", "NewPartnumber", "EffectiveDate", "Username"}, {Business_cbo.SelectedValue, Partnumber_txt.Text, NewPartnumber_txt.Text, Date_dtp.Value.ToString("yyyy-MM-dd"), User.Current.Username}) Then
                    Partnumber_txt.Clear()
                    NewPartnumber_txt.Clear()
                    Partnumber_txt.Focus()
                    GetChanges()
                    FlashAlerts.ShowConfirm("Cambio programado agregado correctamente.")
                Else
                    FlashAlerts.ShowError("Error al agregar el cambio programado.")
                End If
            Else
                Partnumber_txt.Clear()
                NewPartnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowInformation("Ya se encuentra un cambio similar activo.")
            End If
        Else
            FlashAlerts.ShowInformation("Ingresa la información completa.")
        End If
    End Sub

    Private Sub CR_BusinessScheduledChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Actives_dgv.Columns("Change_Cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.critical_16
        GF.FillCombobox(Business_cbo, SQL.Current.GetDatatable("SELECT Business + ' - ' + Family AS Concated, Business FROM Sch_Business ORDER BY Family, Business"), "Concated", "Business")
        Date_dtp.MinDate = Delta.CurrentDate.Date
    End Sub

    Private Sub GetChanges()
        Actives_dgv.DataSource = SQL.Current.GetDatatable("SELECT ID,Business,OldPartnumber,NewPartnumber,EffectiveDate,FullName,C.Username FROM CR_BusinessScheduledChanges AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [EffectiveDate];")
    End Sub

    Private Sub Actives_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Actives_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Actives_dgv.Columns("Change_Cancel_btn").Index AndAlso CType(Actives_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled Then
            SQL.Current.Update("CR_BusinessScheduledChanges", "Active", 0, "ID", Actives_dgv.Rows(e.RowIndex).Cells("Change_ID_col").Value)
            GetChanges()
            FlashAlerts.ShowConfirm("Cambio eliminado.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GetChanges()
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.MaskCompleted Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                NewPartnumber_txt.Focus()
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub NewPartnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles NewPartnumber_txt.TextChanged
        If NewPartnumber_txt.MaskCompleted Then
            If RawMaterial.Exists(NewPartnumber_txt.Text) Then
                Add_btn.Focus()
            Else
                NewPartnumber_txt.Clear()
                NewPartnumber_txt.Focus()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Actives_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Actives_dgv.DataBindingComplete
        For Each r As DataGridViewRow In Actives_dgv.Rows
            If r.Cells("Change_Username_col").Value.ToString.ToLower.Trim = User.Current.Username Then
                CType(r.Cells("Change_Cancel_btn"), DataGridViewImprovedButtonCell).Enabled = True
            Else
                CType(r.Cells("Change_Cancel_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End If
        Next
    End Sub
End Class