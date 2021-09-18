Public Class Rec_TrackerPartialDiscount
    Dim serial As Serialnumber
    Private Sub Smk_PartialDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Partial_btn_Click(sender As Object, e As EventArgs) Handles Partial_btn.Click
        If serial IsNot Nothing Then
            If Quantity_nud.Value <= serial.CurrentQuantity Then
                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                    If Math.Truncate(Quantity_nud.Value) = Quantity_nud.Value Then
                        If serial.TrackerPartialDiscount(Quantity_nud.Value) Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cantidad descontada correctamente.")
                        Else
                            FlashAlerts.ShowError("Error al descontar la cantidad.")
                        End If
                    Else
                        FlashAlerts.ShowError("Cantidad incorrecta. Especifique las piezas correctamente.")
                    End If
                Else
                    If serial.TrackerPartialDiscount(Quantity_nud.Value) Then
                        Clean()
                        FlashAlerts.ShowConfirm("Cantidad descontada correctamente.")
                    Else
                        FlashAlerts.ShowError("Error al descontar la cantidad.")
                    End If
                End If
            Else
                FlashAlerts.ShowError(String.Format("El descuento debe ser menor o igual a la cantidad actual.{0}La serie contiene {1} {2}.", vbCrLf, serial.CurrentQuantity, serial.UoM.ToString))
            End If
        End If
    End Sub

    Private Sub ReadSerial()
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por calidad.")
                Else
                    If serial.InvoiceTrouble Then
                        CurrentQuantity_lbl.Text = String.Format("{0} {1}", serial.CurrentQuantity, serial.UoM)
                        Quantity_nud.Focus()
                    ElseIf serial.Status = Serialnumber.SerialStatus.Empty Then
                        Clean()
                        FlashAlerts.ShowError("La serie se encuentra declarada vacia.")
                    Else
                        Clean()
                        FlashAlerts.ShowError("La serie no se encuentra en el Tracker de Problemas.")
                    End If
                End If
            Else
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
        End If
    End Sub
End Class