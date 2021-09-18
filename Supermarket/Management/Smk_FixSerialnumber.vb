Public Class Smk_FixSerialnumber
    Dim serial As Serialnumber
    Private Sub Smk_FixSerialnumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            serial = New Serialnumber(Serial_txt.Text)
            Serial_txt.ReadOnly = True
            If serial.Exists Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Empty
                        Clean()
                        FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                    Case Serialnumber.SerialStatus.Quality
                        FillSerial()
                        FlashAlerts.ShowInformation("La serie se encuentra en Calidad.")
                    Case Serialnumber.SerialStatus.Tracker
                        FillSerial()
                        FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.")
                    Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Presupermarket
                        FillSerial()
                    Case Else
                        Clean()
                End Select
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        End If
    End Sub
    Private Sub FillSerial()
        Dim uoms As ArrayList = RawMaterial.GetUoMOptions(serial.Partnumber)
        UoM_cbo.Items.Clear()
        UoM_cbo.Items.AddRange(uoms.ToArray)
        Partnumber_txt.Text = serial.Partnumber
        Quantity_nud.Value = serial.Quantity
        UoM_cbo.SelectedItem = serial.UoM.ToString
        Weight_nud.Value = serial.Weight
        Dim raw As New RawMaterial(serial.Partnumber)
        If raw.Type = RawMaterial.MaterialType.Cable Then
            GF.FillCombobox(Container_cbo, SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Cable-Container'"), "Name", "ID")
        Else
            GF.FillCombobox(Container_cbo, SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Component-Container'"), "Name", "ID")
        End If
        If serial.ContainerID <> "" Then
            Container_cbo.SelectedValue = serial.ContainerID
        End If
        If serial.Type = RawMaterial.MaterialType.Cable OrElse serial.Type = RawMaterial.MaterialType.Terminal Then
            Weight_nud.Visible = True
            Weight_lbl.Visible = True
        End If
        OK_btn.Enabled = True
    End Sub
    Private Sub Clean()
        Weight_lbl.Visible = False
        Weight_nud.Visible = False
        serial = Nothing
        Serial_txt.Clear()
        Partnumber_txt.Clear()
        Quantity_nud.Value = 0
        UoM_cbo.Items.Clear()
        OK_btn.Enabled = False
        Container_cbo.SelectedIndex = -1
        Serial_txt.ReadOnly = False
        Serial_txt.Focus()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Clean()
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If serial IsNot Nothing Then
            If Quantity_nud.Value <> serial.Quantity Then
                SQL.Current.Update("Smk_Serials", "Quantity", Quantity_nud.Value, "ID", serial.ID)
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.Quantity, serial.UoM.ToString), "Smk_SerialQuantityChanged")
            End If
            If serial.Type = RawMaterial.MaterialType.Cable AndAlso serial.Weight <> Weight_nud.Value Then
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.Weight, Weight_nud.Value), "Smk_SerialWeightChanged")
                serial.SetWeight(Weight_nud.Value, serial.ContainerID)
            End If

            If serial.Type = RawMaterial.MaterialType.Terminal AndAlso serial.Weight <> Weight_nud.Value Then
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.Weight, Weight_nud.Value), "Smk_SerialWeightChanged")
                serial.SetWeight(Weight_nud.Value)
            End If

            If UoM_cbo.SelectedItem <> serial.UoM.ToString Then
                SQL.Current.Update("Smk_Serials", {"UoM"}, {UoM_cbo.SelectedItem}, "ID", serial.ID)
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.UoM.ToString, UoM_cbo.SelectedItem), "Smk_SerialUoMChanged")
            End If
            If Container_cbo.SelectedIndex > -1 AndAlso Container_cbo.SelectedValue <> serial.ContainerID Then
                SQL.Current.Update("Smk_Serials", {"ContainerID"}, {Container_cbo.SelectedValue}, "ID", serial.ID)
                Log(String.Format("{0}|{1}|{2}", serial.SerialNumber, serial.UoM.ToString, UoM_cbo.SelectedItem), "Smk_SerialContainerChanged")
            End If
            Clean()
            FlashAlerts.ShowConfirm("¡Hecho!")
        End If
    End Sub

    Private Sub Smk_FixSerialnumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class