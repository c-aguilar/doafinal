Public Class CR_MaterialScheduledChanges

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Material_txt.MaskCompleted AndAlso Partnumber_txt.MaskCompleted AndAlso NewPartnumber_txt.MaskCompleted Then
            If Not SQL.Current.Exists("CR_MaterialScheduledChanges", {"Material", "OldPartnumber", "Active"}, {Material_txt.Text, Partnumber_txt.Text, 1}) Then
                If SQL.Current.Insert("CR_MaterialScheduledChanges", {"Material", "OldPartnumber", "NewPartnumber", "EffectiveDate", "Username"}, {Material_txt.Text, Partnumber_txt.Text, NewPartnumber_txt.Text, Date_dtp.Value.ToString("yyyy-MM-dd"), User.Current.Username}) Then
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

    Private Sub CR_MaterialScheduledChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Actives_dgv.Columns("Change_Cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.critical_16
        Date_dtp.MinDate = Delta.CurrentDate.Date
    End Sub

    Private Sub GetChanges()
        Actives_dgv.DataSource = SQL.Current.GetDatatable("SELECT ID,Material,OldPartnumber,NewPartnumber,EffectiveDate,FullName,C.Username FROM CR_MaterialScheduledChanges AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [EffectiveDate];")
        For Each r As DataGridViewRow In Actives_dgv.Rows
            If r.Cells("Change_Username_col").Value.ToString.ToLower.Trim = User.Current.Username Then
                CType(r.Cells("Change_Cancel_btn"), DataGridViewImprovedButtonCell).Enabled = True
            Else
                CType(r.Cells("Change_Cancel_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End If
        Next
    End Sub

    Private Sub Actives_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Actives_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Actives_dgv.Columns("Change_Cancel_btn").Index AndAlso CType(Actives_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled Then
            SQL.Current.Update("CR_MaterialScheduledChanges", "Active", 0, "ID", Actives_dgv.Rows(e.RowIndex).Cells("Changes_ID_col").Value)
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

    Private Sub Material_txt_TextChanged(sender As Object, e As EventArgs) Handles Material_txt.TextChanged
        If Material_txt.MaskCompleted Then
            If Harn.Exist(Material_txt.Text) Then
                Partnumber_txt.Focus()
            Else
                Material_txt.Clear()
                Material_txt.Focus()
                FlashAlerts.ShowError("El número de material no existe.")
            End If
        End If
    End Sub
End Class