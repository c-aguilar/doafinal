
Public Class Smk_TerminalRandomToCutter
    Public Serial As Serialnumber
    Delegate Sub Scale_Value(ByVal value As String)
    Private Sub Smk_CableRandomToCutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Serial_lbl.Text = Serial.SerialNumber
        Partnumber_lbl.Text = Serial.Partnumber
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
                If Serial.RandomToCutter(0, Cutter_txt.Text, Cutter_txt.Text, SupermarketCable.CurrentBadge) Then
                    Serial.PartialDiscount(Serial.CurrentQuantity, SupermarketCable.CurrentBadge) 'ENVIAR LA CANTIDAD A WIP, ESTO HASTA QUE NO SE IMPLEMENTEN PARCILES DE TERMINALES
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
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
       
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