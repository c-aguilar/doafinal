Public Class DiC_AskManual

    Private Sub DiC_AskManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(DieCenter_cbo, SQL.Current.GetDatatable("SELECT DieCenter FROM DiC_Centers"), "DieCenter", "DieCenter")
    End Sub

    Private Sub Pick_btn_Click(sender As Object, e As EventArgs) Handles Pick_btn.Click
        If Partnumber_txt.MaskCompleted Then
            If DieCenter_cbo.SelectedValue IsNot Nothing Then
                If Parameter("DiC_OnlyOnCenter") Then
                    If SQL.Current.Exists("DiC_Map", {"Partnumber", "DieCenter"}, {Partnumber_txt.Text, DieCenter_cbo.SelectedValue}) Then
                        If SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter", "ScannedSerialnumber"}, {Partnumber_txt.Text, DieCenter_cbo.SelectedValue, 0}) Then
                            Partnumber_txt.Clear()
                            Partnumber_txt.Focus()
                            FlashAlerts.ShowConfirm("Hecho!")
                        Else
                            FlashAlerts.ShowInformation("Error al registrar el numero de parte.")
                        End If
                    Else
                        FlashAlerts.ShowInformation("El numero de parte no pertenece a este centro de dados.")
                    End If
                Else
                    If RawMaterial.Exists(Partnumber_txt.Text) Then
                        If SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter", "ScannedSerialnumber"}, {Partnumber_txt.Text, DieCenter_cbo.SelectedValue, 0}) Then
                            Partnumber_txt.Clear()
                            Partnumber_txt.Focus()
                            FlashAlerts.ShowConfirm("Hecho!")
                        Else
                            FlashAlerts.ShowInformation("Error al registrar el numero de parte.")
                        End If
                    Else
                        FlashAlerts.ShowInformation("El numero de parte no existe.")
                    End If
                End If
            Else
                FlashAlerts.ShowInformation("Selecciona un centro de dados.")
            End If
        Else
            FlashAlerts.ShowInformation("Captura el numero de parte.")
        End If
    End Sub

    Private Sub DiC_AskManual_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class