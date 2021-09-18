Public Class Smk_ChangeLocation
    Public Property PreloadSerialnumber As Serialnumber
    Public serial As Serialnumber
    Public masternumber As Masternumber
    Private Sub Smk_ChangeLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Cambio de Local | Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        If PreloadSerialnumber Is Nothing Then
            Clean()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
            OldLocation_txt.Text = PreloadSerialnumber.Location
            Warehouse_txt.Text = PreloadSerialnumber.WarehouseName
            Location_txt.Focus()
        End If
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        If SMK.IsSerialFormat(Serial_txt.Text) AndAlso Location_txt.MaskCompleted Then
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exists Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality
                        If Not serial.RedTag AndAlso serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Tracker)
                        ElseIf Not serial.RedTag AndAlso Not serial.InvoiceTrouble Then
                            serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        If serial.ChangeLocation(Location_txt.Text) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
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
                            FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            FlashAlerts.ShowError("No fue posible cambiar el local.")
                        End If
                    Case Serialnumber.SerialStatus.Stored
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferRandom(Location_txt.Text, My.Settings.Warehouse) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                        If serial.Warehouse = My.Settings.Warehouse Then
                            If serial.ChangeLocation(Location_txt.Text) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        Else
                            If serial.TransferService(Location_txt.Text, My.Settings.Warehouse) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Localización actualizada.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("No fue posible cambiar el local.")
                            End If
                        End If
                    Case Serialnumber.SerialStatus.Empty
                        Clean()
                        FlashAlerts.ShowError("La serie se encuentrada declarada vacía.", , Not IsNothing(PreloadSerialnumber))
                    Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                        Clean()
                        FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                End Select
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.", , Not IsNothing(PreloadSerialnumber))
            End If
            serial = Nothing
        ElseIf masternumber IsNot Nothing AndAlso Location_txt.MaskCompleted Then
            For Each m_serial As Serialnumber In masternumber.Serials
                Select Case m_serial.Status
                    Case Serialnumber.SerialStatus.Quality
                        If Not m_serial.RedTag AndAlso m_serial.InvoiceTrouble Then
                            m_serial.UpdateStatus(Serialnumber.SerialStatus.Tracker)
                        ElseIf Not m_serial.RedTag AndAlso Not m_serial.InvoiceTrouble Then
                            m_serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        m_serial.ChangeLocation(Location_txt.Text)
                    Case Serialnumber.SerialStatus.Tracker
                        If Not m_serial.InvoiceTrouble AndAlso m_serial.RedTag Then
                            m_serial.UpdateStatus(Serialnumber.SerialStatus.Quality)
                        ElseIf Not m_serial.InvoiceTrouble AndAlso Not m_serial.RedTag Then
                            m_serial.UpdateStatus(Serialnumber.SerialStatus.Stored)
                        End If
                        m_serial.ChangeLocation(Location_txt.Text)
                    Case Serialnumber.SerialStatus.Stored
                        If m_serial.Warehouse = My.Settings.Warehouse Then
                            m_serial.ChangeLocation(Location_txt.Text)
                        Else
                            m_serial.TransferRandom(Location_txt.Text, My.Settings.Warehouse)
                        End If
                End Select
            Next
            If masternumber.GeneralLocation = Location_txt.Text Then
                Clean()
                FlashAlerts.ShowConfirm("Localización actualizada.")
            Else
                FlashAlerts.ShowError("No fue posible cambiar el local.")
            End If
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
            masternumber = Nothing
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_ChangeLocation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Location_txt.Focus()
            ReadSerial()
        ElseIf SMK.IsMasterSerialFormat(Serial_txt.Text) Then
            Location_txt.Focus()
            ReadMaster()
        End If
    End Sub

    Private Sub Smk_ChangeLocation_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub ReadSerial()
        serial = New Serialnumber(Serial_txt.Text)
        If serial.Exists Then
            Select Case serial.Status
                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                    Clean()
                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                    OldLocation_txt.Text = serial.Location
                    Warehouse_txt.Text = serial.WarehouseName
                Case Serialnumber.SerialStatus.Empty
                    Clean()
                    FlashAlerts.ShowError("Serie declarada vacía.")
            End Select
        Else
            Clean()
            FlashAlerts.ShowError("La serie no existe.")
        End If
    End Sub
    Private Sub ReadMaster()
        masternumber = New Masternumber(Serial_txt.Text)
        If masternumber.Exists Then
            Select Case masternumber.GeneralStatus
                Case Delta_ERP.Masternumber.MasterStatus.Pending
                    Clean()
                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                Case Delta_ERP.Masternumber.MasterStatus.Stored, Delta_ERP.Masternumber.MasterStatus.Quality, Delta_ERP.Masternumber.MasterStatus.Tracker
                    OldLocation_txt.Text = masternumber.Serials.Item(0).Location
                    Warehouse_txt.Text = masternumber.Serials.Item(0).WarehouseName
                Case Else
                    Clean()
                    FlashAlerts.ShowError("El estatus de alguna serie hija ya fue cambiado.")
            End Select
        Else
            Clean()
            FlashAlerts.ShowError("La serie no existe.")
        End If
    End Sub
End Class