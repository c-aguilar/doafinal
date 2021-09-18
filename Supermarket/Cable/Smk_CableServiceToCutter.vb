Public Class Smk_CableServiceToCutter
    Public Property serial As Serialnumber

    Private Sub Smk_CableServiceToCutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Serial_lbl.Text = serial.SerialNumber
        Partnumber_lbl.Text = serial.Partnumber
    End Sub
    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Cutter_txt.Focus()
    End Sub

    Private Sub ReadCutter()
        If SQL.Current.Exists("PE_Cutters", "ID", Cutter_txt.Text) Then
            If Not SupermarketCable.ReturnBadge(Cutter_txt.Text) Then
                Cutter_txt.Clear()
                Cutter_txt.Focus()
                FlashAlerts.ShowError("Debes escanear tu gafete.")
            Else
                If SQL.Current.Exists("Smk_CableSemiReturn", {"Partnumber", "CutterID"}, {serial.Partnumber, Cutter_txt.Text}) Then ' Verificar que sea Semifijo
                    'BARRILES QUE SE VAN EN AUTOMATICO AL SLOC 2 EN CIERTAS MAQUINAS
                    If serial.ServiceToCutter(Cutter_txt.Text, SupermarketCable.CurrentBadge) Then
                        serial.Empty(SupermarketCable.CurrentBadge)
                        SupermarketCable.PrintEmptylLabel(serial.SerialNumber)
                        FlashAlerts.ShowConfirm("Semifijo: Serie declarada vacia.", , True)
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la salida.")
                    End If
                ElseIf SQL.Current.Exists("Smk_CableNoReturn", "Partnumber", serial.Partnumber) Then ' Verificar que sea barriles sin regreso
                    'BARRILES QUE SE VAN EN AUTOMATICO AL SLOC 2
                    If serial.ServiceToCutter(Cutter_txt.Text, SupermarketCable.CurrentBadge) Then
                        serial.Empty(SupermarketCable.CurrentBadge)
                        SupermarketCable.PrintEmptylLabel(serial.SerialNumber)
                        FlashAlerts.ShowConfirm("Numero de parte directo: Serie declarada vacia.", , True)
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la salida.")
                    End If
                Else 'Barril parcial
                    If serial.ServiceToCutter(Cutter_txt.Text, SupermarketCable.CurrentBadge) Then

                        'If serial.Type = RawMaterial.MaterialType.Terminal And My.Settings.Warehouse = "C" Then 'TEMPORAL
                        '    If serial.CurrentQuantity > 0 Then serial.PartialDiscount(serial.CurrentQuantity, SupermarketCable.CurrentBadge)
                        '    SQL.Current.Update("Smk_Serials", "Location", SQL.Current.GetString("Location", "Smk_Map", {"Warehouse", "Partnumber"}, {My.Settings.Warehouse, serial.Partnumber}, "22000000"), "ID", serial.ID)
                        'End If

                        FlashAlerts.ShowConfirm("Salida registrada.", , True)
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la salida.")
                    End If
                End If
            End If
        Else
            Cutter_txt.Clear()
            Cutter_txt.Focus()
            FlashAlerts.ShowError("La cortadora no existe.")
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Cutter_txt_TextChanged(sender As Object, e As EventArgs) Handles Cutter_txt.TextChanged
        If SMK.IsRawMaterialFormat(Cutter_txt.Text) Then
            ReadCutter()
        ElseIf Cutter_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub Smk_CableServiceToCutter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class