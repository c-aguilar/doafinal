Public Class Smk_DeclareEmptyDiscrepancy
    Public Property PreloadSerialnumber As Serialnumber
    Private Sub Smk_DeclareEmpty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Clean()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
        End If
    End Sub

    Private Sub EmptySerial()
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Dim serial As Serialnumber
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exists Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie bloqueada por Calidad.", , Not IsNothing(PreloadSerialnumber))
                ElseIf serial.InvoiceTrouble Then
                    Log(serial.SerialNumber, "Smk_TryEmptySerialOnTracker")
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE RESERVA
                            If serial.EmptyByDiscrepancy() Then
                                Clean()
                                FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("Error al declarar vacia la serie.")
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
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            EmptySerial()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub
End Class