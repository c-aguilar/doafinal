Imports System.Drawing.Printing

Public Class Settings
    Public Shared ReadOnly Property InstalledPrinters As System.Drawing.Printing.PrinterSettings.StringCollection
    Public Shared regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("APTIV\SiGMa\Settings")
    Private Sub printerSettingsFn(ByVal Optional isSavedNeed As Boolean = False)
        If isSavedNeed Then
            If printersCB.Text IsNot Nothing AndAlso printersCB.Text <> "" And DPIcb.Text IsNot Nothing AndAlso DPIcb.Text <> "" Then
                regKey.SetValue("Printer", printersCB.Text)
                regKey.SetValue("DPI", DPIcb.Text)
            Else
                MessageBox.Show("Select printer and DPI", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If regKey.GetValue("Printer") Is Nothing OrElse regKey.GetValue("Printer").ToString() = "" And regKey.GetValue("DPI") Is Nothing OrElse regKey.GetValue("DPI").ToString() = "" Then
                MessageBox.Show("Select printer and DPI", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                printersCB.Text = regKey.GetValue("Printer").ToString()
                DPIcb.Text = regKey.GetValue("DPI").ToString()
            End If
        End If
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If shippingPointCB.Text Is Nothing Or shippingPointCB.Text Is "" Then
            MessageBox.Show("Please select Shipping Point", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            printerSettingsFn(True)
            regKey.SetValue("ShippingPoint", shippingPointCB.Text)
            MessageBox.Show("Settings saved", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim userType As Boolean = User.Current.IsAdmin
        Dim shippingP As String
        If Not regKey.GetValue("ShippingPoint") Is Nothing OrElse Not regKey.GetValue("ShippingPoint").ToString() = "" Then
            shippingP = regKey.GetValue("ShippingPoint").ToString()
        End If
        Dim pkInstalledPrinters As String
        For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters(i)
            printersCB.Items.Add(pkInstalledPrinters)
        Next
        If userType Then
            shippingPointCB.Enabled = True
        Else
            shippingPointCB.Enabled = False
        End If
        If Not shippingP Is "" Or Not shippingP Is Nothing Then
            shippingPointCB.Text = shippingP
        End If
        'printerSettingsFn()
    End Sub
End Class