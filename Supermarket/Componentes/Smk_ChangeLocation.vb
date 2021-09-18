Public Class Smk_ChangeLocation
    Public Property PreloadSerialnumber As Serialnumber
    Public serial As Serialnumber
    Private Sub Smk_ChangeLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Cambio de Local | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        If PreloadSerialnumber Is Nothing Then
            Clean()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
            If PreloadSerialnumber.Status = Serialnumber.SerialStatus.Stored Then
                OldLocation_txt.Text = PreloadSerialnumber.RandomLocation
            Else
                OldLocation_txt.Text = PreloadSerialnumber.ServiceLocation
            End If
            Warehouse_txt.Text = PreloadSerialnumber.WarehouseName
            Location_txt.Focus()
        End If
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        If SMK.IsSerial(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exist Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality
                        If Not serial.RedTag AndAlso serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Tracker)
                        ElseIf Not serial.RedTag AndAlso Not serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        If serial.ChangeLocation(Location_txt.Text) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            FlashAlerts.ShowError("No fue posible cambiar el local.")
                        End If
                    Case Serialnumber.SerialStatus.Tracker
                        If Not serial.InvoiceTrouble AndAlso serial.RedTag Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Quality)
                        ElseIf Not serial.InvoiceTrouble AndAlso Not serial.RedTag Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        If serial.ChangeLocation(Location_txt.Text) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            FlashAlerts.ShowError("No fue posible cambiar el local.")
                        End If
                    Case Serialnumber.SerialStatus.Stored
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferRandom(Location_txt.Text, My.Settings.Warehouse) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferService(Location_txt.Text, My.Settings.Warehouse) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Empty
                        If serial.Type = RawMaterial.MaterialType.Cable Then
                            serial.ChangeLocation(Location_txt.Text)
                            Clean()
                            FlashAlerts.ShowConfirm("Localizacion actualizada.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            Clean()
                            FlashAlerts.ShowError("La serie se encuentrada declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                        End If
                    Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                        Clean()
                        FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                End Select
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.", , Not IsNothing(PreloadSerialnumber))
            End If
            serial = Nothing
        Else
            FlashAlerts.ShowInformation("Completa todos los campos.")
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            Location_txt.Clear()
            OldLocation_txt.Clear()
            Warehouse_txt.Clear()
            Serial_txt.Clear()
            Serial_txt.Focus()
            serial = Nothing
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_ChangeLocation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Location_txt.Focus()
            ReadSerial()
        End If
    End Sub

    Private Sub Smk_ChangeLocation_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub ReadSerial()
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
End Class