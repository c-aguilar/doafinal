Public Class Smk_OpenSerial
    Public Property PreloadSerialnumber As Serialnumber

    Private Sub Smk_OpenSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Abrir Contenedor | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
        End If
        If User.Current.HasPermission("SMK_MasiveEmptyDeclaration") Then
            List_btn.Enabled = True
        End If
    End Sub

    Private Sub OpenSerial()
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Dim serial As Serialnumber
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exists Then
                If serial.Type = RawMaterial.MaterialType.Cable Then
                    Clean()
                    FlashAlerts.ShowError("Opcion no disponible para este numero de parte.", , Not IsNothing(PreloadSerialnumber))
                Else
                    If serial.RedTag Then
                        Clean()
                        FlashAlerts.ShowError("Serie bloqueada por Calidad.", , Not IsNothing(PreloadSerialnumber))
                    ElseIf serial.InvoiceTrouble Then
                        Log(serial.SerialNumber, "Smk_TryOpenSerialOnTracker")
                        Clean()
                        FlashAlerts.ShowError("Serie se encuentra en Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                    Else
                        Select Case serial.Status
                            Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                Clean()
                                FlashAlerts.ShowError("Serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                            Case Serialnumber.SerialStatus.Stored
                                'VALIDAR FIFO
                                If Parameter("SMK_ForceFIFO", False) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) Then
                                    Clean()
                                    FlashAlerts.ShowError("FIFO incorrecto.", , Not IsNothing(PreloadSerialnumber))
                                Else
                                    If serial.Consumption = RawMaterial.ConsumptionType.Total Then
                                        If serial.Open(serial.Location) Then
                                            serial.Empty()
                                            Clean()
                                            FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , Not IsNothing(PreloadSerialnumber))
                                        Else
                                            FlashAlerts.ShowError("Error al abrir el contenedor.")
                                        End If
                                    Else
                                        If My.Settings.Warehouse = serial.Warehouse Then
                                            If serial.Open(serial.Location) Then
                                                Clean()
                                                FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , Not IsNothing(PreloadSerialnumber))
                                            Else
                                                FlashAlerts.ShowError("Error al abrir el contenedor.")
                                            End If
                                        ElseIf serial.TransferRandomToService(serial.Location, My.Settings.Warehouse) Then
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

    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles List_btn.Click
        Dim ld As New ListDialog
        ld.Title = "Numeros de Serie"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each serie In ld.Items
                If SMK.IsSerialFormat(serie) Then
                    Dim serial As New Serialnumber(serie)
                    If serial.Exists Then
                        If serial.RedTag Then
                            FlashAlerts.ShowInformation("La serie bloqueada por Calidad.", , False)
                        ElseIf serial.InvoiceTrouble Then
                            Log(serial.SerialNumber, "Smk_TryOpenSerialOnTracker")
                            FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.", , False)
                        Else
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Empty
                                    FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.", , False)
                                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.", , False)
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE SERVICIO
                                    FlashAlerts.ShowInformation("El contenedor fue abierto previamente.", , False)
                                Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker 'TODOS ESTAN EN SLOC DE RESERVA
                                    'VALIDAR FIFO
                                    If Parameter("SMK_ForceFIFO", False) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) Then
                                        FlashAlerts.ShowError("FIFO incorrecto.", , False)
                                    Else
                                        If serial.Consumption = RawMaterial.ConsumptionType.Total Then
                                            If serial.Open(serial.Location) Then
                                                serial.Empty()
                                                FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , False)
                                            Else
                                                FlashAlerts.ShowError("Error al abrir el contenedor.")
                                            End If
                                        Else
                                            If My.Settings.Warehouse = serial.Warehouse Then
                                                If serial.Open(serial.Location) Then
                                                    FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , False)
                                                Else
                                                    FlashAlerts.ShowError("Error al abrir el contenedor.")
                                                End If
                                            ElseIf serial.TransferRandomToService(serial.Location, My.Settings.Warehouse) Then
                                                FlashAlerts.ShowConfirm("Contenedor abierto correctamente.", , False)
                                            Else
                                                FlashAlerts.ShowError("Error al abrir el contenedor.")
                                            End If
                                        End If
                                    End If
                            End Select
                        End If
                    Else
                        FlashAlerts.ShowError("La serie no existe.", , False)
                    End If
                End If
            Next
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

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            OpenSerial()
        End If
    End Sub
End Class