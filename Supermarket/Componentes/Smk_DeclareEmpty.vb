Public Class Smk_DeclareEmpty
    Public Property PreloadSerialnumber As Serialnumber
    Private Sub Smk_DeclareEmpty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Clean()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
        End If
    End Sub

    Private Sub Empty_btn_Click(sender As Object, e As EventArgs) Handles Empty_btn.Click
        If SMK.IsSerial(Serial_txt.Text) Then
            Dim serial As Serialnumber
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exist Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie bloqueada por Calidad.", , Not IsNothing(PreloadSerialnumber))
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                    Log(serial.SerialNumber, "Smk_TryEmptySerialOnTracker")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE SERVICIO
                            If serial.Empty() Then
                                Clean()
                                FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("Error al declarar vacia la serie.")
                            End If
                        Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker 'TODOS ESTAN EN SLOC DE RESERVA
                            'VALIDAR FIFO
                            If Parameter("SMK_ForceFIFO", False) AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") Then
                                Clean()
                                FlashAlerts.ShowError("FIFO incorrecto.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                'PRIMERO ABRIRA LA SERIE
                                If serial.Open(SQL.Current.GetString("Location", "Smk_Map", {"Partnumber", "Warehouse"}, {serial.Partnumber, serial.Warehouse}, "00000000")) Then
                                    If serial.Empty() Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                    End If
                                Else
                                    FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                End If
                            End If
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.", , Not IsNothing(PreloadSerialnumber))
            End If
        Else
            Clean()
            FlashAlerts.ShowInformation("Serie incorrecta.", , Not IsNothing(PreloadSerialnumber))
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Empty_btn.PerformClick()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub
End Class