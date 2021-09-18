Public Class Smk_ManualAdjustment
    Dim serial As Serialnumber
    Public Property PreloadSerialnumber As Serialnumber
    Private Sub Smk_StoreSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Text = ""
            Serial_txt.SelectionStart = Serial_txt.TextLength
            Serial_txt.Focus()
        Else
            If PreloadSerialnumber.UoM = RawMaterial.UnitOfMeasure.PC Then
                NewQuantity_nud.DecimalPlaces = 0
                CurrentQuantity_lbl.Text = String.Format("{0} {1}", CInt(PreloadSerialnumber.CurrentQuantity), PreloadSerialnumber.UoM.ToString)
            Else
                CurrentQuantity_lbl.Text = String.Format("{0} {1}", PreloadSerialnumber.CurrentQuantity, PreloadSerialnumber.UoM.ToString)
            End If
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True

            NewQuantity_nud.Value = PreloadSerialnumber.CurrentQuantity
        End If
    End Sub

    Private Sub Adjust_btn_Click(sender As Object, e As EventArgs) Handles Adjust_btn.Click
        If serial IsNot Nothing Then
            If NewQuantity_nud.Value <> serial.CurrentQuantity Then
                If MessageBox.Show("¿Continuar con el ajuste?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If NewQuantity_nud.Value = 0 Then
                        serial.ManualAdjust(NewQuantity_nud.Value)
                        serial.Empty()
                        FlashAlerts.ShowConfirm("Serie ajustada y declarada vacia.", , True)
                    Else
                        serial.ManualAdjust(NewQuantity_nud.Value)
                        FlashAlerts.ShowConfirm("Serie ajustada.", , True)
                    End If
                    Clean()
                End If
            Else
                Clean()
                FlashAlerts.ShowInformation("No se realizo ningun ajuste.")
            End If
        ElseIf PreloadSerialnumber IsNot Nothing Then
            If NewQuantity_nud.Value <> serial.CurrentQuantity Then
                If MessageBox.Show("¿Continuar con el ajuste?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If NewQuantity_nud.Value = 0 Then
                        PreloadSerialnumber.ManualAdjust(NewQuantity_nud.Value)
                        PreloadSerialnumber.Empty()
                        FlashAlerts.ShowConfirm("Serie ajustada y declarada vacia.", , True)
                    Else
                        PreloadSerialnumber.ManualAdjust(NewQuantity_nud.Value)
                        FlashAlerts.ShowConfirm("Serie ajustada.", , True)
                    End If
                    Me.Close()
                End If
            Else
                FlashAlerts.ShowInformation("No se realizo ningun ajuste.", , True)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Smk_PartialDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Find()
        If SMK.IsSerial(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            If serial.Exist Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por calidad.")
                ElseIf serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowError("La serie se encuentra en Tracker de Problemas.")
                    Log(serial.SerialNumber, "Smk_TryAdjustSerialOnTracker")
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.ServiceOnQuality
                            If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                NewQuantity_nud.DecimalPlaces = 0
                                CurrentQuantity_lbl.Text = String.Format("{0} {1}", CInt(serial.CurrentQuantity), serial.UoM.ToString)
                            Else
                                CurrentQuantity_lbl.Text = String.Format("{0} {1}", serial.CurrentQuantity, serial.UoM.ToString)
                            End If
                            Serial_txt.ReadOnly = True
                            NewQuantity_nud.Value = serial.CurrentQuantity
                            If serial.Status = Serialnumber.SerialStatus.Stored Then
                                FlashAlerts.ShowInformation("El contenedor esta cerrado.", , True)
                            End If
                            NewQuantity_nud.Focus()
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowError("Serie declarada vacia.")
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Quality
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                        Case Serialnumber.SerialStatus.Stored
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("No existe la serie.")
            End If
        Else
            Clean()
            FlashAlerts.ShowError("Serie incorrecta.")
        End If
    End Sub

    Private Sub Clean()
        serial = Nothing
        Serial_txt.ReadOnly = False
        CurrentQuantity_lbl.Text = "-"
        NewQuantity_nud.Value = 0
        NewQuantity_nud.DecimalPlaces = 3
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        If PreloadSerialnumber IsNot Nothing Then
            Me.Close()
        Else
            Clean()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Find()
        ElseIf serial IsNot Nothing Then
            Clean()
        End If
    End Sub
End Class