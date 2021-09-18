Public Class Smk_ChangeLocationKiosk
    Public Property Badge As String
    Public serial As Serialnumber
    Dim RemainTime As Integer = 30
    Private Sub Smk_ChangeLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Cambio de Local | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
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

    Private Sub Change()
        RemainTime = 15
        If serial IsNot Nothing Then
            If serial.Exist Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality
                        If Not serial.RedTag AndAlso serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Tracker)
                        ElseIf Not serial.RedTag AndAlso Not serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        If serial.ChangeLocation(Location_txt.Text, Me.Badge) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.")
                        Else
                            FlashAlerts.ShowError("No fue posible cambiar el local.")
                        End If
                    Case Serialnumber.SerialStatus.Tracker
                        If Not serial.InvoiceTrouble AndAlso serial.RedTag Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Quality)
                        ElseIf Not serial.InvoiceTrouble AndAlso Not serial.RedTag Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        If serial.ChangeLocation(Location_txt.Text, Me.Badge) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.")
                        Else
                            FlashAlerts.ShowError("No fue posible cambiar el local.")
                        End If
                    Case Serialnumber.SerialStatus.Stored
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text, Me.Badge) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.")
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferRandom(Location_txt.Text, My.Settings.Warehouse, Me.Badge) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.")
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text, Me.Badge) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.")
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferService(Location_txt.Text, My.Settings.Warehouse, Me.Badge) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.")
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Empty
                        If serial.Type = RawMaterial.MaterialType.Cable Then
                            serial.ChangeLocation(Location_txt.Text, Me.Badge)
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.")
                        Else
                            Clean()
                            FlashAlerts.ShowError("La serie se encuentrada declarada vacia.")
                        End If
                    Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                        Clean()
                        FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                End Select
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
        OldLocation_txt.Clear()
        Warehouse_txt.Clear()
        Serial_txt.Clear()
        Serial_txt.Focus()
        serial = Nothing
    End Sub

    Private Sub Smk_ChangeLocation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Location_txt.Focus()
            ReadSerial()
        ElseIf Serial_txt.Text.ToUpper.Trim = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub Smk_ChangeLocation_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub ReadSerial()
        RemainTime = 30
        serial = New Serialnumber(Serial_txt.Text)
        If serial.Exist Then
            Select Case serial.Status
                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                    Clean()
                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                    OldLocation_txt.Text = serial.RandomLocation
                    Warehouse_txt.Text = serial.WarehouseName
                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality
                    OldLocation_txt.Text = serial.ServiceLocation
                    Warehouse_txt.Text = serial.WarehouseName
                Case Serialnumber.SerialStatus.Empty
                    If serial.Type = RawMaterial.MaterialType.Cable Then
                        Dim sms As New SQL(Parameter("SMK_SMSBarrelsStringConn2"))
                        OldLocation_txt.Text = sms.GetString(String.Format("SELECT CASE WHEN serial_status IN ('SMK','ON CUTTER') THEN serial_serviceLocal ELSE serial_randomLocal END FROM tblSerials WHERE Serial_number = '{0}';", serial.SerialNumber))
                        Warehouse_txt.Text = "Barriles"
                    Else
                        Clean()
                        FlashAlerts.ShowError("Serie declarada vacia.")
                    End If
            End Select
        Else
            Clean()
            FlashAlerts.ShowError("La serie no existe.")
        End If
    End Sub

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub Serial_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ReadSerial()
        End If
    End Sub

    Private Sub Location_txt_TextChanged(sender As Object, e As EventArgs) Handles Location_txt.TextChanged
        If Location_txt.MaskCompleted Then
            Change()
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class