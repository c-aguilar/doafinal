Public Class Smk_ReturnToRandom

    Private Sub Smk_ReturnToRandom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clean()
        If User.Current.HasPermission("SMK_MasiveSerialReturn") Then
            List_btn.Enabled = True
        End If
    End Sub

    Private Sub Reactive_btn_Click(sender As Object, e As EventArgs) Handles Reactive_btn.Click
        If SMK.IsSerialFormat(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                        If serial.ReturnToRandom(Location_txt.Text) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Serie regresada a reserva.")
                        Else
                            FlashAlerts.ShowError("Error al regresar la serie.")
                        End If
                    Case Else
                        Clean()
                        FlashAlerts.ShowError("El estatus de la serie no permite realizar el regreso.")
                End Select
            Else
                Clean()
                FlashAlerts.ShowInformation("La serie no existe.")
            End If
            serial = Nothing
        ElseIf Not Location_txt.MaskCompleted Then
            FlashAlerts.ShowInformation("Captura la localizacion completa.")
        Else
            FlashAlerts.ShowInformation("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        Location_txt.Clear()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_ReactiveSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles List_btn.Click
        Dim ld As New ListDialog
        ld.Title = "Numeros de Serie"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each serie In ld.Items
                If SMK.IsSerialFormat(serie) Then
                    Dim serial As New Serialnumber(serie)
                    If serial.Exists Then
                        Select Case serial.Status
                            Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                                If serial.ReturnToRandom(serial.Location) Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie regresada a reserva.")
                                Else
                                    FlashAlerts.ShowError("Error al regresar la serie.")
                                End If
                            Case Else
                                Clean()
                                FlashAlerts.ShowError("El estatus de la serie no permite realizar el regreso.")
                        End Select
                    Else
                        Clean()
                        FlashAlerts.ShowInformation("La serie no existe.")
                    End If
                    serial = Nothing
                End If
            Next
        End If
    End Sub
End Class