Public Class Smk_ReactiveSerial

    Private Sub Smk_ReactiveSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clean()
    End Sub

    Private Sub Reactive_btn_Click(sender As Object, e As EventArgs) Handles Reactive_btn.Click
        If SMK.IsSerial(Serial_txt.Text) Then
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exist Then
                If serial.Status = Serialnumber.SerialStatus.Empty Then
                    If serial.ReturnFromEmpty Then
                        Clean()
                        FlashAlerts.ShowConfirm("Serie reactivada.")
                    Else
                        FlashAlerts.ShowError("Error al reactivar la serie.")
                    End If
                Else
                    Clean()
                    FlashAlerts.ShowError("La serie aun esta activa.")
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
            serial = Nothing
        Else
            FlashAlerts.ShowInformation("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_ReactiveSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class