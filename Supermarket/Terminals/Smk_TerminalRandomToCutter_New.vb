Imports System.IO.Ports
Imports System.Threading
Public Class Smk_TerminalRandomToCutter_New
    Public Serial As Serialnumber
    Dim _scale As New Scale

    Private Sub Smk_TerminalRandomToCutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ElseIf _scale.IsReading Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.Maroon
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
        Cutter_txt.Focus()
    End Sub

    Private Sub ReadCutter()
        If _scale.IsStable Then
            Dim scale_value As Decimal = _scale.NewValue
            Dim newWeight As Decimal
            Select Case Serial.UoM
                Case RawMaterial.UnitOfMeasure.PC
                    newWeight = scale_value - (Serial.CurrentQuantity * RawMaterial.GetWeight(Serial.Partnumber) / 1000)
                Case RawMaterial.UnitOfMeasure.M
                    newWeight = scale_value - (Serial.CurrentQuantity * RawMaterial.GetWeight(Serial.Partnumber) / 1000)
                Case RawMaterial.UnitOfMeasure.FT
                    newWeight = scale_value - ((Serial.CurrentQuantity * 0.3048) * RawMaterial.GetWeight(Serial.Partnumber) / 1000)
                Case RawMaterial.UnitOfMeasure.KG
                    newWeight = scale_value - Serial.CurrentQuantity
                Case RawMaterial.UnitOfMeasure.LB
                    newWeight = scale_value - (Serial.CurrentQuantity * 0.453592)
                Case Else
                    newWeight = scale_value - (Serial.CurrentQuantity * RawMaterial.GetWeight(Serial.Partnumber) / 1000)
            End Select

            If newWeight > 0 Then
                If SQL.Current.Exists("PE_Cutters", "ID", Cutter_txt.Text) Then
                    If Not SupermarketCable.ReturnBadge(Cutter_txt.Text) Then
                        Cutter_txt.Clear()
                        Cutter_txt.Focus()
                        FlashAlerts.ShowError("Debes escanear tu gafete.")
                    Else
                        If Serial.RandomToCutter(newWeight, Cutter_txt.Text, SupermarketCable.CurrentBadge) Then
                            If Serial.Type = RawMaterial.MaterialType.Calibre Then
                                Log(String.Format("{0}|{1}|{2}|{3}", Serial.SerialNumber, Serial.CurrentQuantity, scale_value, newWeight), "Smk_CalibreInitialWeight")
                            Else
                                Log(String.Format("{0}|{1}|{2}|{3}", Serial.SerialNumber, Serial.CurrentQuantity, scale_value, newWeight), "Smk_TerminalInitialWeight")
                            End If
                            FlashAlerts.ShowConfirm("Salida registrada.")
                            Me.Close()
                        Else
                            Cutter_txt.Clear()
                            Cutter_txt.Focus()
                            FlashAlerts.ShowError("Error al registrar la salida.")
                        End If
                    End If
                Else
                    Cutter_txt.Clear()
                    Cutter_txt.Focus()
                    FlashAlerts.ShowError("La cortadora no existe.")
                End If
            Else
                Cutter_txt.Clear()
                Cutter_txt.Focus()
                FlashAlerts.ShowError(String.Format("El peso del carrete es menor o igual a cero.{0}Comprueba el funcionamiento de la bascula o avisa al ingeniero de materiales.", vbCrLf), 5)
            End If
        Else
            Cutter_txt.Clear()
            Cutter_txt.Focus()
            FlashAlerts.ShowInformation("Espera a que se estabilice la bascula...")
        End If
    End Sub

    Private Sub Smk_TerminalRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Cutter_txt_TextChanged(sender As Object, e As EventArgs) Handles Cutter_txt.TextChanged
        If Delta.IsValidID(Cutter_txt.Text, 8) Then
            ReadCutter()
        ElseIf Cutter_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub Cutter_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Cutter_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Cutter_txt.Text <> "" Then
            ReadCutter()
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CableRandomToCutter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class