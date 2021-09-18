Public Class ZPLPrinterSettings

    Private Sub PrinterSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Resolution_cbo.Items.Contains(My.Settings.PrinterResolution.ToString) Then
            Resolution_cbo.SelectedItem = My.Settings.PrinterResolution.ToString
        End If
        Printer_txt.Text = My.Settings.Printer
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Resolution_cbo.SelectedIndex > -1 Then
            My.Settings.PrinterResolution = CInt(Resolution_cbo.SelectedItem)
            My.Settings.Printer = Printer_txt.Text
            My.Settings.Save()
            FlashAlerts.ShowConfirm("Configuración guardada.")
        Else
            FlashAlerts.ShowError("Selecciona una resolución valida.")
        End If
    End Sub

    Private Sub Printer_btn_Click(sender As Object, e As EventArgs) Handles Printer_btn.Click
        Dim pdialog As New PrintDialog()
        Dim result As DialogResult = pdialog.ShowDialog
        If result = DialogResult.OK Then
            Printer_txt.Text = pdialog.PrinterSettings.PrinterName
        End If
    End Sub
End Class