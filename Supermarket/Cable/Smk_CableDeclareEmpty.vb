Public Class Smk_CableDeclareEmpty
    Public Property Badge As String
    Dim RemainTime As Integer = 30
    Private Sub Smk_DeclareEmptyKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AskBadge()
    End Sub

    Private Sub AskBadge()
        Dim badge As New Smk_BadgeKiosk
        If badge.ShowDialog = Windows.Forms.DialogResult.OK Then
            CountDown_timer.Enabled = True
            CountDown_timer.Start()
            Me.Badge = badge.SelectedBadge
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Empty()
        RemainTime = 30
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If serial.Type <> RawMaterial.MaterialType.Cable AndAlso serial.Type <> RawMaterial.MaterialType.Calibre AndAlso serial.Type <> RawMaterial.MaterialType.Terminal Then
                    Clean()
                    FlashAlerts.ShowError("Opcion no disponible para el numero de parte.")
                Else
                    If serial.RedTag Then
                        Clean()
                        FlashAlerts.ShowInformation("La serie bloqueada por Calidad.")
                    ElseIf serial.InvoiceTrouble Then
                        Log(serial.SerialNumber, "Smk_TryEmptySerialOnTracker", Me.Badge)
                        Clean()
                        FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.")
                    Else
                        Select Case serial.Status
                            Case Serialnumber.SerialStatus.Empty
                                Clean()
                                FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.")
                            Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                                Clean()
                                FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                            Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE SERVICIO
                                If serial.Empty(Me.Badge) Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie declarada vacia.")
                                Else
                                    FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                End If
                            Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker 'TODOS ESTAN EN SLOC DE RESERVA
                                If serial.Consumption = RawMaterial.ConsumptionType.Total OrElse SQL.Current.Exists("Smk_CableNoReturn", "Partnumber", serial.Partnumber) Then
                                    If serial.Empty(Me.Badge) Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie declarada vacia.")
                                    Else
                                        FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                    End If
                                Else
                                    Clean()
                                    FlashAlerts.ShowError("El barril no ha sido pesado.")
                                End If
                        End Select
                    End If
                End If

            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        Else
            Clean()
            FlashAlerts.ShowInformation("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_DeclareEmpty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Empty()
        ElseIf Serial_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Serial_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Empty()
        End If
    End Sub

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            Me.Close()
        End If
    End Sub
End Class