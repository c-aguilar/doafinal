Public Class Smk_OpenSerial
    Public Property PreloadSerialnumber As Serialnumber
    Private Sub Smk_OpenSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Abrir Contenedor | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Text = ""
            Serial_txt.SelectionStart = Serial_txt.TextLength
            Serial_txt.Focus()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
        End If
    End Sub

    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
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
                    FlashAlerts.ShowError("Serie bloqueada por Calidad.", , Not IsNothing(PreloadSerialnumber))
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowError("Serie se encuentra en Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                    Log(serial.SerialNumber, "Smk_TryOpenSerialOnTracker")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                            Clean()
                            FlashAlerts.ShowError("Serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.Stored
                            'VALIDAR FIFO
                            If Parameter("SMK_ForceFIFO", False) AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") Then
                                Clean()
                                FlashAlerts.ShowError("FIFO incorrecto.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                If serial.Consumption = RawMaterial.ConsumptionType.Total Then
                                    If serial.Open(serial.RandomLocation) Then
                                        serial.Empty()
                                        Clean()
                                        FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al abrir el contenedor.")
                                    End If
                                Else
                                    If My.Settings.Warehouse = serial.Warehouse Then
                                        If serial.Open(serial.RandomLocation) Then
                                            Clean()
                                            FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , Not IsNothing(PreloadSerialnumber))
                                        Else
                                            FlashAlerts.ShowError("Error al abrir el contenedor.")
                                        End If
                                    ElseIf serial.TransferRandomToService(serial.RandomLocation, My.Settings.Warehouse) Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al abrir el contenedor.")
                                    End If
                                End If
                            End If
                        Case Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality
                            Clean()
                            FlashAlerts.ShowInformation("El contenedor fue abierto previamente.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowError("La serie ya fue declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                    End Select
                End If
                
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.", , Not IsNothing(PreloadSerialnumber))
            End If
            serial = Nothing
        Else
            FlashAlerts.ShowInformation("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Me.Clean()
        End If
    End Sub

    Private Sub Smk_OpenSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub
End Class