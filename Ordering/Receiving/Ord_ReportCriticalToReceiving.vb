Public Class Ord_ReportCriticalToReceiving

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Partnumber_txt.MaskCompleted Then
            If Not SQL.Current.Exists("Rec_CriticalPartnumbers", {"Partnumber", "Active"}, {Partnumber_txt.Text, 1}) Then
                If 1 = 1 Then
                    If Not Area_txt.Text.Trim = "" AndAlso Not Delivery_txt.Text.Trim = "" AndAlso Not Plates_txt.Text.Trim = "" AndAlso Not Transporter_txt.Text.Trim = "" AndAlso Not Comment_txt.Text.Trim = "" Then
                        If QuantityStop_chk.Checked Then
                            If Quantity_nud.Value = 0 Then
                                FlashAlerts.ShowInformation("Ingresa la cantidad a recibir.")
                            Else
                                If SQL.Current.Insert("Rec_CriticalPartnumbers", {"Partnumber", "Area", "Comment", "Username", "Plates", "Delivery", "Transporter", "Quantity"}, {Partnumber_txt.Text, Area_txt.Text, Comment_txt.Text, User.Current.Username, Plates_txt.Text, Delivery_txt.Text, Transporter_txt.Text, Quantity_nud.Value}) Then
                                    Partnumber_txt.Clear()
                                    Comment_txt.Clear()
                                    Area_txt.Clear()
                                    Plates_txt.Clear()
                                    Delivery_txt.Clear()
                                    Transporter_txt.Clear()
                                    Quantity_nud.Value = 0
                                    QuantityStop_chk.Checked = False
                                    UoM_lbl.Text = ""
                                    GetCriticals()
                                    FlashAlerts.ShowConfirm("Numero de parte reportado.")
                                Else
                                    FlashAlerts.ShowError("Error al reportar el numero de parte.")
                                End If
                            End If
                        Else
                            If SQL.Current.Insert("Rec_CriticalPartnumbers", {"Partnumber", "Area", "Comment", "Username", "Plates", "Delivery", "Transporter"}, {Partnumber_txt.Text, Area_txt.Text, Comment_txt.Text, User.Current.Username, Plates_txt.Text, Delivery_txt.Text, Transporter_txt.Text}) Then
                                Partnumber_txt.Clear()
                                Comment_txt.Clear()
                                Area_txt.Clear()
                                Plates_txt.Clear()
                                Delivery_txt.Clear()
                                Transporter_txt.Clear()
                                Quantity_nud.Value = 0
                                QuantityStop_chk.Checked = False
                                UoM_lbl.Text = ""
                                GetCriticals()
                                FlashAlerts.ShowConfirm("Número de parte reportado.")
                            Else
                                FlashAlerts.ShowError("Error al reportar el número de parte.")
                            End If
                        End If
                    Else
                        FlashAlerts.ShowInformation("Todos los campos son obligatorios.")
                    End If
                Else
                    FlashAlerts.ShowError("No se puede reportar el número, el inventario es mas de 1 DOH.")
                End If
            Else
                FlashAlerts.ShowInformation("El número de parte ya se encuentra registrado.")
            End If
        Else
            FlashAlerts.ShowInformation("El número de parte debe contener 8 caracteres.")
        End If
    End Sub

    Private Sub Ord_ReportCriticalToReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Actives_dgv.Columns("cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.critical_16
    End Sub

    Private Sub GetCriticals()
        Actives_dgv.DataSource = SQL.Current.GetDatatable("SELECT ID,Partnumber,C.Area,Plates,Transporter,Delivery,Comment,Quantity,[Date],FullName,C.Username FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [Date];")
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

    Private Sub QuantityStop_chk_CheckedChanged(sender As Object, e As EventArgs) Handles QuantityStop_chk.CheckedChanged
        If QuantityStop_chk.Checked Then
            Quantity_nud.Enabled = True
        Else
            Quantity_nud.Enabled = False
        End If
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.MaskCompleted Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                UoM_lbl.Text = RawMaterial.GetUoM(Partnumber_txt.Text).ToString
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Actives_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Actives_dgv.DataBindingComplete
        For Each r As DataGridViewRow In Actives_dgv.Rows
            If r.Cells("Username").Value.ToString.ToLower.Trim = User.Current.Username OrElse User.Current.IsAdmin OrElse User.Current.Role = "ORD Supervisor" OrElse User.Current.Role = "CR Supervisor" Then
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = True
            Else
                CType(r.Cells("cancel_btn"), DataGridViewImprovedButtonCell).Enabled = False
            End If
        Next
    End Sub
End Class