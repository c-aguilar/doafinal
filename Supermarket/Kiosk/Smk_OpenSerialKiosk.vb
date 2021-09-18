Public Class Smk_OpenSerialKiosk
    Public Property Badge As String
    Dim RemainTime As Integer = 30
    Private Sub Smk_OpenSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Abrir Contenedor | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        Serial_txt.Text = ""
        Serial_txt.SelectionStart = Serial_txt.TextLength
        Serial_txt.Focus()
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

    Private Sub Open()
        RemainTime = 15
        If SMK.IsSerial(Serial_txt.Text) Then
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exist Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por Calidad.")
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowError("Serie se encuentra en Tracker de Problemas.")
                    Log(serial.SerialNumber, "Smk_TryOpenSerialOnTracker", Me.Badge)
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                            Clean()
                            FlashAlerts.ShowError("Serie no ha sido dada de alta.")
                        Case Serialnumber.SerialStatus.Stored
                            'VALIDAR FIFO
                            If Parameter("SMK_ForceFIFO", False) AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) Then
                                Clean()
                                FlashAlerts.ShowError("FIFO incorrecto.")
                            Else
                                If serial.Consumption = RawMaterial.ConsumptionType.Total Then
                                    If serial.Open(serial.RandomLocation, Me.Badge) Then
                                        serial.Empty(Me.Badge)
                                        Clean()
                                        FlashAlerts.ShowConfirm("Contenedor abierto correctamente.")
                                    Else
                                        FlashAlerts.ShowError("Error al abrir el contenedor.")
                                    End If
                                Else
                                    If My.Settings.Warehouse = serial.Warehouse Then
                                        If serial.Open(serial.RandomLocation, Me.Badge) Then
                                            Clean()
                                            FlashAlerts.ShowConfirm("Contenedor abierto correctamente.")
                                        Else
                                            FlashAlerts.ShowError("Error al abrir el contenedor.")
                                        End If
                                    ElseIf serial.TransferRandomToService(serial.RandomLocation, My.Settings.Warehouse, Me.Badge) Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Contenedor abierto correctamente.")
                                    Else
                                        FlashAlerts.ShowError("Error al abrir el contenedor.")
                                    End If
                                End If
                            End If
                        Case Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                            Clean()
                            FlashAlerts.ShowInformation("El contenedor fue abierto previamente.")
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
        Else
            FlashAlerts.ShowInformation("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_OpenSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Open()
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
End Class