Public Class Rec_ToTracker

    Private Sub Rec_ToTracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clean()
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        If SMK.IsSerial(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            Dim local As String = Location_txt.Text
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exist Then
                If (serial.Status = Serialnumber.SerialStatus.Quality OrElse serial.Status = Serialnumber.SerialStatus.ServiceOnQuality) AndAlso serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Calidad.")
                ElseIf serial.Status = Serialnumber.SerialStatus.Tracker AndAlso serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie ya se encuentra en Tracker de Problemas.")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality
                            If serial.ToTracker(local) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Serie enviada a Tracker correctamente.")
                            Else
                                FlashAlerts.ShowError("Error al registrar la serie.")
                            End If
                        Case Serialnumber.SerialStatus.Empty
                            If serial.Type = RawMaterial.MaterialType.Cable Then
                                Clean()
                                FlashAlerts.ShowInformation("La serie ya fue dada de alta en Barriles.")
                            Else
                                Clean()
                                FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                            End If
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
            serial = Nothing
        Else
            FlashAlerts.ShowInformation("Completa todos los campos.")
        End If
    End Sub

    Private Sub Clean()
        Location_txt.Clear()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_StoreSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Location_txt.Focus()
        End If
    End Sub
End Class