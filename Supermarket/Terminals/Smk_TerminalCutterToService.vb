Imports System.IO.Ports
Imports System.Threading
Public Class Smk_TerminalCutterToService
    Public Property Serial As Serialnumber
    Private Sub Smk_CableCutterToService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Serial_lbl.Text = Serial.SerialNumber
        Partnumber_lbl.Text = Serial.Partnumber
    End Sub

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Command_txt.Focus()
    End Sub

    Private Sub ReadCommmad()
        Dim current_cutter As String = SQL.Current.GetString(String.Format("SELECT dbo.Smk_SerialLastCutterID({0});", Serial.ID))
        If Not SupermarketCable.ReturnBadge(current_cutter) Then
            Command_txt.Clear()
            Command_txt.Focus()
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
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
       
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