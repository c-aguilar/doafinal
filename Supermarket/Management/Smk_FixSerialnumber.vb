Public Class Smk_FixSerialnumber
    Dim serial As Serialnumber
    Private Sub Smk_FixSerialnumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            Serial_txt.ReadOnly = True
            If serial.Exist Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Empty
                        Clean()
                        FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                    Case Serialnumber.SerialStatus.Quality
                        Partnumber_txt.Text = serial.Partnumber
                        Quantity_nud.Value = serial.CurrentQuantity
                        UoM_cbo.SelectedItem = serial.UoM.ToString
                        OK_btn.Enabled = True
                        FlashAlerts.ShowInformation("La serie se encuentra en Calidad.")
                    Case Serialnumber.SerialStatus.Tracker
                        Partnumber_txt.Text = serial.Partnumber
                        Quantity_nud.Value = serial.CurrentQuantity
                        UoM_cbo.SelectedItem = serial.UoM.ToString
                        OK_btn.Enabled = True
                        FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.")
                    Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                        Partnumber_txt.Text = serial.Partnumber
                        Quantity_nud.Value = serial.CurrentQuantity
                        UoM_cbo.SelectedItem = serial.UoM.ToString
                        OK_btn.Enabled = True
                    Case Else
                        Clean()
                End Select
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        End If
    End Sub

    Private Sub Clean()
        serial = Nothing
        Serial_txt.Clear()
        Partnumber_txt.Clear()
        Quantity_nud.Value = 0
        UoM_cbo.SelectedIndex = -1
        OK_btn.Enabled = False
        Serial_txt.ReadOnly = False
        Serial_txt.Focus()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Clean()
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If serial IsNot Nothing Then
            If Quantity_nud.Value <> serial.CurrentQuantity Then
                serial.ManualAdjust(Quantity_nud.Value)
            End If
            If UoM_cbo.SelectedItem <> serial.UoM.ToString Then
                SQL.Current.Update("Smk_Serials", {"UoM"}, {UoM_cbo.SelectedItem}, "ID", serial.ID)
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.UoM, UoM_cbo.SelectedItem), "Smk_SerialUoMChanged")
            End If
            Clean()
            FlashAlerts.ShowConfirm("Hecho!")
        End If
    End Sub

    Private Sub Smk_FixSerialnumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class