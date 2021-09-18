Imports System.IO.Ports
Imports System.Threading
Public Class Smk_TerminalCutterToService_New
    Public Property Serial As Serialnumber
    Public Property ContainerWeight As Decimal
    Dim _scale As New Scale
    Private Sub Smk_TerminalCutterToService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", Serial.ContainerID, 0)
        Serial_lbl.Text = Serial.SerialNumber
        Partnumber_lbl.Text = Serial.Partnumber
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

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Command_txt.Focus()
    End Sub

    Private Sub ReadCommmad()
        If _scale.IsStable Then
            Dim newWeight As Decimal = _scale.NewValue - Serial.Weight 'Peso de terminales solamente
            Dim newQty As Decimal

            Select Case Serial.UoM
                Case RawMaterial.UnitOfMeasure.PC
                    newQty = Math.Floor((newWeight * 1000) / RawMaterial.GetWeight(Serial.Partnumber))
                Case RawMaterial.UnitOfMeasure.M
                    newQty = (newWeight * 1000) / RawMaterial.GetWeight(Serial.Partnumber)
                Case RawMaterial.UnitOfMeasure.FT
                    newQty = ((newWeight * 1000) / RawMaterial.GetWeight(Serial.Partnumber)) / 0.3048
                Case RawMaterial.UnitOfMeasure.KG
                    newQty = newWeight
                Case RawMaterial.UnitOfMeasure.LB
                    newQty = newWeight / 0.453592
                Case Else
                    newQty = Math.Round((newWeight * 1000) / RawMaterial.GetWeight(Serial.Partnumber), 3)
            End Select

            Dim current_cutter As String = SQL.Current.GetString(String.Format("SELECT dbo.Smk_SerialLastCutterID({0});", Serial.ID))
            If newWeight <= 0 Then
                Command_txt.Clear()
                Command_txt.Focus()
                If _scale.NewValue > 0 Then
                    If Not SupermarketCable.ReturnBadge(current_cutter) Then
                        Command_txt.Clear()
                        Command_txt.Focus()
                        FlashAlerts.ShowError("Debes escanear tu gafete.")
                    Else
                        If Serial.CutterToService(0, SupermarketCable.CurrentBadge) Then
                            Log(String.Format("{0}|{1}|{2}|{3}", Serial.SerialNumber, Serial.Weight, newWeight, newQty), "Smk_TerminalUnderWeightIn")
                            FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                            Me.Close()
                        Else
                            FlashAlerts.ShowError("Error al registrar la entrada.")
                        End If
                    End If
                Else
                    FlashAlerts.ShowError(String.Format("El peso de las terminales es menor o igual a cero.{0}Comprueba el funcionamiento de la bascula o avisa al ingeniero de materiales.", vbCrLf))
                End If
            ElseIf Serial.CurrentQuantity < newQty Then
                If Not SupermarketCable.ReturnBadge(current_cutter) Then
                    Command_txt.Clear()
                    Command_txt.Focus()
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    If Serial.CutterToService(Serial.CurrentQuantity, SupermarketCable.CurrentBadge) Then
                        Log(String.Format("{0}|{1}|{2}", Serial.SerialNumber, Serial.CurrentQuantity, newQty), "Smk_TerminalOverWeightIn")
                        FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la entrada.")
                    End If
                End If
            Else 'Peso terminales valido
                If Not SupermarketCable.ReturnBadge(current_cutter) Then
                    Command_txt.Clear()
                    Command_txt.Focus()
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    If Serial.CutterToService(newQty, SupermarketCable.CurrentBadge) Then
                        FlashAlerts.ShowConfirm("Entrada a supermercado registrada.", , True)
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la entrada.")
                    End If
                End If
            End If
        Else
            Command_txt.Clear()
            Command_txt.Focus()
            FlashAlerts.ShowInformation("Espere a que estabilice la bascula...")
        End If
    End Sub

    Private Sub Smk_TerminalCutterToService_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ReadCommmad()
    End Sub

    Private Sub Command_txt_TextChanged(sender As Object, e As EventArgs) Handles Command_txt.TextChanged
        Select Case Command_txt.Text.ToUpper
            Case "CLOSE"
                Me.Close()
            Case "-OK-"
                ReadCommmad()
        End Select
    End Sub

    Private Sub Smk_CableCutterToService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class