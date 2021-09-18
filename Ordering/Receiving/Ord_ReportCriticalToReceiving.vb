Public Class Ord_ReportCriticalToReceiving

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Partnumber_txt.MaskCompleted Then
            If Not SQL.Current.Exists("Rec_CriticalPartnumbers", {"Partnumber", "Active"}, {Partnumber_txt.Text, 1}) Then
                If Not Area_txt.Text.Trim = "" AndAlso Not Delivery_txt.Text.Trim = "" AndAlso Not Plates_txt.Text.Trim = "" AndAlso Not Transporter_txt.Text.Trim = "" AndAlso Not Comment_txt.Text.Trim = "" Then
                    If SQL.Current.Insert("Rec_CriticalPartnumbers", {"Partnumber", "Area", "Comment", "Username", "Plates", "Delivery", "Transporter"}, {Partnumber_txt.Text, Area_txt.Text, Comment_txt.Text, User.Current.Username, Plates_txt.Text, Delivery_txt.Text, Transporter_txt.Text}) Then
                        Partnumber_txt.Clear()
                        Comment_txt.Clear()
                        Area_txt.Clear()
                        GetCriticals()
                        FlashAlerts.ShowConfirm("Numero de parte reportado.")
                    Else
                        FlashAlerts.ShowError("Error al reportar el numero de parte.")
                    End If
                Else
                    FlashAlerts.ShowInformation("Todos los campos son obligatorios.")
                End If
            Else
                FlashAlerts.ShowInformation("El numero de parte ya se encuentra registrado.")
            End If
        Else
            FlashAlerts.ShowInformation("El numero de parte debe contener 8 caracteres.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Actives_dgv.Columns("cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.critical_16
    End Sub

    Private Sub GetCriticals()
        Actives_dgv.DataSource = SQL.Current.GetDatatable("SELECT ID,Partnumber,C.Area,Comment,[Date],FullName,C.Username FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [Date];")
        For Each r As DataGridViewRow In Actives_dgv.Rows
            If r.Cells("Username").Value.ToString.ToLower = User.Current.Username OrElse User.Current.IsAdmin Then
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = True
            Else
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End If
        Next
    End Sub

    Private Sub Actives_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Actives_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Actives_dgv.Columns("cancel_btn").Index AndAlso CType(Actives_dgv.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImprovedButtonCell).Enabled Then
            SQL.Current.Delete("Rec_CriticalPartnumbers", "ID", Actives_dgv.Rows(e.RowIndex).Cells("ID").Value)
            GetCriticals()
            FlashAlerts.ShowConfirm("Alerta eliminada.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GetCriticals()
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class