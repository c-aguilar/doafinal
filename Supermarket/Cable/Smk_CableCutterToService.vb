Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CableCutterToService
    Public Property Serial As Serialnumber
    Public Property ContainerWeight As Decimal
    Dim DollyWeight As Decimal
    Dim DollyID As String
    Dim _scale As New Scale
    Private Sub Smk_CableCutterToService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", Serial.ContainerID, 0)
        Serial_lbl.Text = Serial.SerialNumber
        Partnumber_lbl.Text = Serial.Partnumber
        SelectDolly(True)
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        _scale.StartReading()
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.LimeGreen
            Command_txt.WaterMarkText = "Confirme el peso..."
        ElseIf _scale.IsReading Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.Maroon
            Command_txt.WaterMarkText = "Espere..."
        ElseIf _scale.IsError Then
            If IsNumeric(Weight_txt.Text) Then
                _scale.NewValue = CDec(Weight_txt.Text)
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.LimeGreen
            Else
                _scale.NewValue = 0
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.Maroon
            End If
        Else
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.DimGray
            Weight_txt.BackColor = Color.Maroon
        End If
        Application.DoEvents()
    End Sub

    Private Sub SelectDolly(close_if_cancel As Boolean)
        Dim background As New FadeBackground()
        Dim new_tara As New Smk_CableSelectTara
        new_tara.Width = Screen.PrimaryScreen.Bounds.Width - 50
        new_tara.Height = Screen.PrimaryScreen.Bounds.Height - 50
        new_tara.ContainerClass = "dollys"
        background.Show()
        If new_tara.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DollyID = new_tara.DollyID
            DollyWeight = new_tara.DollyWeight
            new_tara.Dispose()
            Dolly_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", DollyID, My.Resources.No_image_available)
            lblTaraWeight.Text = "Peso total: " & ContainerWeight + DollyWeight & " Kg."
            background.Close()
            background.Dispose()
        ElseIf close_if_cancel Then
            new_tara.Dispose()
            background.Close()
            background.Dispose()
            Me.Close()
        Else
            new_tara.Dispose()
            background.Close()
            background.Dispose()
        End If
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Command_txt.Focus()
    End Sub

    Private Sub ReadCommmad()
        If _scale.IsStable Then
            Dim newWeight As Decimal = _scale.NewValue - ContainerWeight - DollyWeight 'bascula - contenedor - dolly
            Dim current_cutter As String = SQL.Current.GetString(String.Format("SELECT dbo.Smk_SerialLastCutterID({0});", Serial.ID))
            If (newWeight - 2) > Serial.Weight Then 'Fuera de la tolerancia de 2 Kg, no realiza descuentos
                If Not SupermarketCable.ReturnBadge(current_cutter) Then
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    MessageBox.Show(String.Format("El peso actual del barril es mayor al ultimo peso registrado. {0}Posibles causas:{0}" & _
                                                                 "1. Bascula mal colocada o calibrada.{0}" & _
                                                                 "2. Tara incorrecta.{0}" & _
                                                                 "3. Diferencias minimas en el peso de las taras.{0}" & _
                                                                 "Notifique al supervisor para darle entrada.", vbCrLf),
                                                                   "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim newAdmin As New Sys_Authentication
                    If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If newAdmin.User.HasPermission("Supermarket_OverweightBarrel_Enter_flag") Then
                            If My.Settings.Warehouse <> Serial.Warehouse Then
                                If Serial.CutterToService(Serial.CurrentQuantity, Serial.Weight, SupermarketCable.CurrentBadge) AndAlso Serial.TransferService(RawMaterial.GetServiceLocation(Serial.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, SupermarketCable.CurrentBadge) Then
                                    FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                                    Me.Close()
                                Else
                                    FlashAlerts.ShowError("Error al registrar la entrada.")
                                End If
                            Else
                                If Serial.CutterToService(Serial.CurrentQuantity, Serial.Weight, SupermarketCable.CurrentBadge) Then
                                    FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                                    Me.Close()
                                Else
                                    FlashAlerts.ShowError("Error al registrar la entrada.")
                                End If
                            End If
                        Else
                            FlashAlerts.ShowError("No tienes autorización para realizar esta accion.")
                        End If
                    Else
                        FlashAlerts.ShowError("Accion cancelada.")
                    End If
                    newAdmin.Dispose()
                End If
            ElseIf newWeight > Serial.Weight Then 'Dentro de la tolerancia de 2 Kg, no realiza descuentos ni manda alertas
                If Not SupermarketCable.ReturnBadge(current_cutter) Then
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    If My.Settings.Warehouse <> Serial.Warehouse Then
                        If Serial.CutterToService(Serial.CurrentQuantity, Serial.Weight, SupermarketCable.CurrentBadge) AndAlso Serial.TransferService(RawMaterial.GetServiceLocation(Serial.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, SupermarketCable.CurrentBadge) Then
                            FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                            Me.Close()
                        Else
                            FlashAlerts.ShowError("Error al registrar la entrada.")
                        End If
                    Else
                        If Serial.CutterToService(Serial.CurrentQuantity, Serial.Weight, SupermarketCable.CurrentBadge) Then
                            FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                            Me.Close()
                        Else
                            FlashAlerts.ShowError("Error al registrar la entrada.")
                        End If
                    End If
                End If
            ElseIf newWeight <= 0 Then 'Peso del barril igual o menor a cero
                FlashAlerts.ShowError(String.Format("El peso del barril no puede ser menor o igual a cero.{0}Comprueba el funcionamiento de la bascula.", vbCrLf))
            Else 'Peso del barril correcto
                Dim newQty As Decimal = newWeight * (Serial.CurrentQuantity / Serial.Weight)
                If Not SupermarketCable.ReturnBadge(current_cutter) Then
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    If My.Settings.Warehouse <> Serial.Warehouse Then
                        If Serial.CutterToService(newQty, newWeight, SupermarketCable.CurrentBadge) AndAlso Serial.TransferService(RawMaterial.GetServiceLocation(Serial.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, SupermarketCable.CurrentBadge) Then
                            FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                            Me.Close()
                        Else
                            FlashAlerts.ShowError("Error al registrar la entrada.")
                        End If
                    Else
                        If Serial.CutterToService(newQty, newWeight, SupermarketCable.CurrentBadge) Then
                            FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                            Me.Close()
                        Else
                            FlashAlerts.ShowError("Error al registrar la entrada.")
                        End If
                    End If
                End If
            End If
        Else
            FlashAlerts.ShowInformation("Espere a que estabilice la bascula...")
        End If
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Change_btn_Click(sender As Object, e As EventArgs) Handles Change_btn.Click
        SelectDolly(False)
        Command_txt.Clear()
        Command_txt.Focus()
    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ReadCommmad()
    End Sub

    Private Sub Command_txt_TextChanged(sender As Object, e As EventArgs) Handles Command_txt.TextChanged
        Select Case Command_txt.Text.ToUpper
            Case "CLOSE"
                Me.Close()
            Case "CHANGE"
                SelectDolly(False)
                Command_txt.Clear()
                Command_txt.Focus()
            Case "-OK-"
                Command_txt.Clear()
                Command_txt.Focus()
                ReadCommmad()
        End Select
    End Sub

    Private Sub Smk_CableCutterToService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class