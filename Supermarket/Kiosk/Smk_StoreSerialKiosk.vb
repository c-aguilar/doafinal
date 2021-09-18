Public Class Smk_StoreSerialKiosk
    Public Property Badge As String
    Dim RemainTime As Integer = 30
    Dim serial As Serialnumber
    Private Sub Smk_StoreSerialKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Alta de Contenedor | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        Clean()
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

    Private Sub Store()
        RemainTime = 30
        If serial IsNot Nothing Then
            Dim local As String = Location_txt.Text
            Select Case serial.Status
                Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                    If serial.Store(local, Me.Badge) Then
                        If My.Settings.Warehouse <> serial.Warehouse Then
                            serial.TransferRandom(local, My.Settings.Warehouse, Me.Badge)
                        End If
                        Clean()
                        FlashAlerts.ShowConfirm("Serie dada de alta correctamente.")
                    Else
                        FlashAlerts.ShowError("Error al tratar dar de alta la serie.")
                    End If
                Case Serialnumber.SerialStatus.ServiceOnQuality
                    serial.UpdateStatus(Serialnumber.SerialStatus.Open)
                    If My.Settings.Warehouse = serial.Warehouse Then
                        If serial.ChangeLocation(local, Me.Badge) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cambio de local realizado.")
                        Else
                            FlashAlerts.ShowError("Error al hacer cambio de local.")
                        End If
                    Else
                        If serial.TransferService(local, My.Settings.Warehouse, Me.Badge) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cambio de local realizado.")
                        Else
                            FlashAlerts.ShowError("Error al hacer cambio de local.")
                        End If
                    End If
                Case Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open
                    If local <> serial.Location Then
                        If MessageBox.Show("La serie se encuentra en servicio. ¿Deseas cambiarla de local?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If My.Settings.Warehouse = serial.Warehouse Then
                                If serial.ChangeLocation(local, Me.Badge) Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Cambio de local realizado.")
                                Else
                                    FlashAlerts.ShowError("Error al hacer cambio de local.")
                                End If
                            Else
                                If serial.TransferService(local, My.Settings.Warehouse, Me.Badge) Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Cambio de local realizado.")
                                Else
                                    FlashAlerts.ShowError("Error al hacer cambio de local.")
                                End If
                            End If
                        End If
                    Else
                        Clean()
                        FlashAlerts.ShowInformation("La serie ya fue dada de alta previamente.")
                    End If
            End Select
        End If
    End Sub

    Private Sub Clean()
        serial = Nothing
        Location_txt.Clear()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_StoreSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        ElseIf Serial_txt.Text.Trim.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub Location_txt_TextChanged(sender As Object, e As EventArgs) Handles Location_txt.TextChanged
        If Location_txt.MaskCompleted Then
            Store()
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub ReadSerial()
        RemainTime = 30
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por calidad.")
                ElseIf serial.InvoiceTrouble Then
                    Log(serial.SerialNumber, "Smk_TryStoreSerialOnTracker", Me.Badge)
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Presupermarket
                            Location_txt.Focus()
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        Else
            Clean()
            FlashAlerts.ShowError("Serie incorrecta.")
        End If
    End Sub
End Class