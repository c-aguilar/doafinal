Public Class Rec_ToQuality

    Private Sub Rec_ToQuality_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clean()
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        If SMK.IsSerialFormat(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            Dim local As String = Location_txt.Text
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If (serial.Status = Serialnumber.SerialStatus.Quality OrElse serial.Status = Serialnumber.SerialStatus.ServiceOnQuality) AndAlso serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie ya se encuentra en Calidad.")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Presupermarket
                            If Not serial.RedTag Then
                                If MessageBox.Show("Serie no alertada: La serie se bloqueara y enviara a Calidad. ¿Continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    If serial.ToQuality(local) Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie entregada a Calidad correctamente.")
                                    Else
                                        FlashAlerts.ShowError("Error al entregar la serie.")
                                    End If
                                Else
                                    Clean()
                                    FlashAlerts.ShowInformation("Cancelado.")
                                    Exit Sub
                                End If
                            ElseIf serial.ToQuality(local) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Serie entregada a Calidad correctamente.")
                            Else
                                FlashAlerts.ShowError("Error al entregar la serie.")
                            End If
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
            serial = Nothing
        ElseIf SMK.IsMasterSerialFormat(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            Dim local As String = Location_txt.Text
            Dim master As New Masternumber(Serial_txt.Text)
            If master.Exists Then
                If master.GeneralStatus = Masternumber.MasterStatus.Quality AndAlso master.Serials.Exists(Function(w) w.RedTag = True) Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie ya se encuentra en Calidad.")
                Else
                    If master.GeneralStatus = Masternumber.MasterStatus.Mixed Then
                        Clean()
                        FlashAlerts.ShowError("El estatus de alguna serie hija ya fue cambiado.")
                    Else
                        If master.Serials.Exists(Function(w) w.RedTag = False) Then
                            If MessageBox.Show("Serie no alertada: La serie se bloqueara y enviara a Calidad. ¿Continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                For Each serial As Serialnumber In master.Serials
                                    serial.ToQuality(local)
                                Next
                                If master.GeneralStatus = Masternumber.MasterStatus.Quality Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie entregada a Calidad correctamente.")
                                Else
                                    FlashAlerts.ShowError("Error al entregar la serie.")
                                End If
                            Else
                                Clean()
                                FlashAlerts.ShowInformation("Cancelado.")
                                Exit Sub
                            End If
                        Else
                            For Each serial As Serialnumber In master.Serials
                                serial.ToQuality(local)
                            Next
                            If master.GeneralStatus = Masternumber.MasterStatus.Quality Then
                                Clean()
                                FlashAlerts.ShowConfirm("Serie entregada a Calidad correctamente.")
                            Else
                                FlashAlerts.ShowError("Error al entregar la serie.")
                            End If
                        End If
                    End If
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
            master = Nothing
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
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Location_txt.Focus()
        ElseIf SMK.IsMasterSerialFormat(Serial_txt.Text) Then
            Location_txt.Focus()
        End If
    End Sub
End Class