Public Class Smk_SmkSettings

    Private Sub Smk_CableSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            COM_cbo.Items.Add(sp)
        Next
        If COM_cbo.Items.Contains(My.Settings.COM) Then
            COM_cbo.SelectedItem = My.Settings.COM
        End If

        If Scale_cbo.Items.Contains(My.Settings.ScaleModel) Then
            Scale_cbo.SelectedItem = My.Settings.ScaleModel
        End If

        If Resolution_cbo.Items.Contains(My.Settings.PrinterResolution.ToString) Then
            Resolution_cbo.SelectedItem = My.Settings.PrinterResolution.ToString
        End If
        ScaleFactor_nud.Value = My.Settings.SupermarketComponentScaleFactor
        Printer_txt.Text = My.Settings.Printer
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If COM_cbo.SelectedIndex > -1 AndAlso Resolution_cbo.SelectedIndex > -1 Then
            My.Settings.COM = COM_cbo.SelectedItem
            My.Settings.PrinterResolution = CInt(Resolution_cbo.SelectedItem)
            My.Settings.Printer = Printer_txt.Text
            My.Settings.SupermarketComponentScaleFactor = ScaleFactor_nud.Value
            My.Settings.ScaleModel = Scale_cbo.SelectedItem
            My.Settings.Save()
            FlashAlerts.ShowConfirm("Configuración guardada.")
        Else
            FlashAlerts.ShowError("Selecciona un puerto COM y resolución validos.")
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