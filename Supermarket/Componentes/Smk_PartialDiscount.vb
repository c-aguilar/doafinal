Public Class Smk_PartialDiscount
    Public Property PreloadSerialnumber As Serialnumber
    Dim serial As Serialnumber
    Private Sub Smk_PartialDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
            Quantity_nud.Focus()
        End If
    End Sub

    Private Sub Partial_btn_Click(sender As Object, e As EventArgs) Handles Partial_btn.Click
        If serial IsNot Nothing Then
            If Quantity_nud.Value < serial.CurrentQuantity Then
                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                    If Math.Truncate(Quantity_nud.Value) = Quantity_nud.Value Then
                        If serial.PartialDiscount(Quantity_nud.Value) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cantidad descontada correctamente.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            FlashAlerts.ShowError("Error al descontar la cantidad.")
                        End If
                    Else
                        FlashAlerts.ShowError("Cantidad incorrecta. Especifique las piezas correctamente.")
                    End If
                Else
                    If serial.PartialDiscount(Quantity_nud.Value) Then
                        Clean()
                        FlashAlerts.ShowConfirm("Cantidad descontada correctamente.", , Not IsNothing(PreloadSerialnumber))
                    Else
                        FlashAlerts.ShowError("Error al descontar la cantidad.")
                    End If
                End If
            ElseIf Quantity_nud.Value = serial.CurrentQuantity Then
                If serial.Empty() Then
                    Clean()
                    FlashAlerts.ShowConfirm("Cantidad descontada correctamente. Se declaro vacio el contenedor.", , Not IsNothing(PreloadSerialnumber))
                Else
                    FlashAlerts.ShowError("Error al descontar la cantidad.")
                End If
            Else
                FlashAlerts.ShowError(String.Format("El descuento debe ser menor a la cantidad actual.{0}La serie contiene {1} {2}.", vbCrLf, serial.CurrentQuantity, serial.UoM.ToString))
            End If
        End If
    End Sub

    Private Sub ReadSerial()
        If SMK.IsSerial(Serial_txt.Text) Then
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(Serial_txt.Text)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exist Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por calidad.", , Not IsNothing(PreloadSerialnumber))
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowError("La serie se encuentra en el Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                    Log(serial.SerialNumber, "Smk_TryPartialDiscountSerialOnTracker")
                Else
                    If serial.Consumption = RawMaterial.ConsumptionType.Partial OrElse serial.Consumption = RawMaterial.ConsumptionType.Mixed Then
                        Select Case serial.Status
                            Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality
                                CurrentQuantity_lbl.Text = String.Format("{0} {1}", serial.CurrentQuantity, serial.UoM)
                                Quantity_nud.Focus()
                            Case Serialnumber.SerialStatus.Stored
                                Clean()
                                FlashAlerts.ShowError("La serie no ha sido abierta.", , Not IsNothing(PreloadSerialnumber))
                            Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker
                                Clean()
                                FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                            Case Serialnumber.SerialStatus.Empty
                                Clean()
                                FlashAlerts.ShowError("La serie se encuentra declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                        End Select
                    Else
                        FlashAlerts.ShowError("El numero de parte no es de consumo parcial.")
                    End If
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        Else
            Clean()
            FlashAlerts.ShowError("Serie incorrecta.", , Not IsNothing(PreloadSerialnumber))
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            serial = Nothing
            CurrentQuantity_lbl.Text = "-"
            Quantity_nud.Value = 1
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_PartialDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub
End Class