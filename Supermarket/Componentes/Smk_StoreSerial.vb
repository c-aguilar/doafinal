Public Class Smk_StoreSerial
    Dim serial As Serialnumber
    Private Sub Smk_StoreSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = String.Format("Alta de Contenedor | Estacion {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        Clean()
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        If serial IsNot Nothing Then
            Dim local As String = Location_txt.Text
            Select Case serial.Status
                Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                    If serial.Store(local) Then
                        If Not serial.Type = RawMaterial.MaterialType.Cable AndAlso My.Settings.Warehouse <> serial.Warehouse Then
                            serial.TransferRandom(local, My.Settings.Warehouse)
                        End If
                        Clean()
                        FlashAlerts.ShowConfirm("Serie dada de alta correctamente.")
                    Else
                        FlashAlerts.ShowError("Error al tratar dar de alta la serie.")
                    End If
                Case Serialnumber.SerialStatus.ServiceOnQuality
                    serial.UpdateStatus(Serialnumber.SerialStatus.Open)
                    If My.Settings.Warehouse = serial.Warehouse Then
                        If serial.ChangeLocation(local) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cambio de local realizado.")
                        Else
                            FlashAlerts.ShowError("Error al hacer cambio de local.")
                        End If
                    Else
                        If serial.TransferService(local, My.Settings.Warehouse) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cambio de local realizado.")
                        Else
                            FlashAlerts.ShowError("Error al hacer cambio de local.")
                        End If
                    End If
                Case Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open
                    If local <> serial.ServiceLocation Then
                        If MessageBox.Show("La serie se encuentra en servicio. ¿Deseas cambiarla de local?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If My.Settings.Warehouse = serial.Warehouse Then
                                If serial.ChangeLocation(local) Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Cambio de local realizado.")
                                Else
                                    FlashAlerts.ShowError("Error al hacer cambio de local.")
                                End If
                            Else
                                If serial.TransferService(local, My.Settings.Warehouse) Then
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
        If SMK.IsSerial(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub

    Private Sub ReadSerial()
        If SMK.IsSerial(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            If serial.Exist Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por calidad.")
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.")
                    Log(serial.SerialNumber, "Smk_TryStoreSerialOnTracker")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Stored
                            Location_txt.Focus()
                        Case Serialnumber.SerialStatus.Empty
                            If serial.Type = RawMaterial.MaterialType.Cable Then
                                Clean()
                                FlashAlerts.ShowInformation("La serie ya fue dada de alta previamente en Barriles.")
                            Else
                                Clean()
                                FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                            End If
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