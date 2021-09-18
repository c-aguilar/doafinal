Public Class QLY_NewAlert

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Partnumber_txt.MaskCompleted Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                If Reason_txt.Text <> "" Then
                    'If SQL.Current.Exists("Qly_PartnumberAlerts", {"Partnumber", "Active"}, {Partnumber_txt.Text, 1}) Then
                    '    FlashAlerts.ShowInformation("Existe una alerta activa del numero de parte.")
                    'Else
                    If SQL.Current.Insert("Qly_PartnumberAlerts", {"Partnumber", "Reason", "Username"}, {Partnumber_txt.Text, Reason_txt.Text, User.Current.Username}) Then
                        Partnumber_txt.Clear()
                        Reason_txt.Clear()
                        FlashAlerts.ShowConfirm("Alerta creada.")
                    Else
                        FlashAlerts.ShowError("Error al crear la alerta.")
                    End If
                    'End If
                Else
                    Reason_txt.Focus()
                    FlashAlerts.ShowInformation("Debes ingresar un motivo.")
                End If
            Else
                FlashAlerts.ShowError("No existe el numero de parte.")
            End If
        Else
            Partnumber_txt.Focus()
            FlashAlerts.ShowInformation("El numero de parte debe contener 8 caracteres.")
        End If
    End Sub

    Private Sub Cross_btn_Click(sender As Object, e As EventArgs) Handles Cross_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Numero de parte de proveedor:"
        If eb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If SQL.Current.Exists("Sys_RawMaterial", "SupplierPartnumber", eb.Answer) Then
                Partnumber_txt.Text = SQL.Current.GetString("Partnumber", "Sys_RawMaterial", "SupplierPartnumber", eb.Answer, "")
                Reason_txt.Focus()
            Else
                FlashAlerts.ShowError("Numero de parte no encontrado.")
            End If
        End If
        eb.Dispose()
    End Sub

    Private Sub QLY_NewAlert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class