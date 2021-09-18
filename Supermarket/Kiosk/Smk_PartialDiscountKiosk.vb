Public Class Smk_PartialDiscountKiosk
    Public Property Badge As String
    Dim serial As Serialnumber
    Dim RemainTime As Integer = 30
    Private Sub Smk_PartialDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Clear()
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

    Private Sub Partial_btn_Click(sender As Object, e As EventArgs) Handles Partial_btn.Click
        RemainTime = 15
        If serial IsNot Nothing Then
            If Quantity_nud.Value < serial.CurrentQuantity Then
                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                    If Math.Truncate(Quantity_nud.Value) = Quantity_nud.Value Then
                        If serial.PartialDiscount(Quantity_nud.Value, Me.Badge) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cantidad descontada correctamente.")
                        Else
                            FlashAlerts.ShowError("Error al descontar la cantidad.")
                        End If
                    Else
                        FlashAlerts.ShowError("Cantidad incorrecta. Especifique las piezas correctamente.")
                    End If
                Else
                    If serial.PartialDiscount(Quantity_nud.Value, Me.Badge) Then
                        Clean()
                        FlashAlerts.ShowConfirm("Cantidad descontada correctamente.")
                    Else
                        FlashAlerts.ShowError("Error al descontar la cantidad.")
                    End If
                End If
            ElseIf Quantity_nud.Value = serial.CurrentQuantity Then
                If serial.Empty(Me.Badge) Then
                    Clean()
                    FlashAlerts.ShowConfirm("Cantidad descontada correctamente. Se declaro vacio el contenedor.")
                Else
                    FlashAlerts.ShowError("Error al descontar la cantidad.")
                End If
            Else
                FlashAlerts.ShowError(String.Format("El descuento debe ser menor a la cantidad actual.{0}La serie contiene {1} {2}.", vbCrLf, serial.CurrentQuantity, serial.UoM.ToString))
            End If
        End If
    End Sub

    Private Sub ReadSerial()
        RemainTime = 30
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If serial.Type = RawMaterial.MaterialType.Cable Then
                    Clean()
                    FlashAlerts.ShowError("Opcion no disponible para este numero de parte.")
                Else
                    If serial.RedTag Then
                        Clean()
                        FlashAlerts.ShowError("Serie bloqueada por calidad.")
                    ElseIf serial.InvoiceTrouble Then
                        Log(serial.SerialNumber, "Smk_TryPartialDiscountSerialOnTracker")
                        Clean()
                        FlashAlerts.ShowError("La serie se encuentra en el Tracker de Problemas.")
                    Else
                        If serial.Consumption = RawMaterial.ConsumptionType.Partial OrElse serial.Consumption = RawMaterial.ConsumptionType.Mixed OrElse serial.Consumption = RawMaterial.ConsumptionType.Service OrElse serial.Consumption = RawMaterial.ConsumptionType.Obsolete OrElse serial.Consumption = RawMaterial.ConsumptionType.CAO Then
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality
                                    CurrentQuantity_lbl.Text = String.Format("{0} {1}", serial.CurrentQuantity, serial.UoM)
                                    Quantity_nud.Focus()
                                Case Serialnumber.SerialStatus.Stored
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido abierta.")
                                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                                Case Serialnumber.SerialStatus.Empty
                                    Clean()
                                    FlashAlerts.ShowError("La serie se encuentra declarada vacia.")
                            End Select
                        Else
                            FlashAlerts.ShowError("El numero de parte no es de consumo parcial.")
                        End If
                    End If
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

    Private Sub Clean()
        serial = Nothing
        CurrentQuantity_lbl.Text = "-"
        Quantity_nud.Value = 1
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Smk_PartialDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        ElseIf Serial_txt.Text = "CLOSE" Then
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

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class