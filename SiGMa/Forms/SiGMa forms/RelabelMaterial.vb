Imports System.IO

Public Class RelabelMaterial
    Public Shared regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("APTIV\SiGMa\Settings")
    Private Sub RelabelMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plants As ArrayList = SQL.Current.GetList("SELECT Plant FROM dbo.Sys_Plants")
        For Each item As String In plants
            plantCB.Items.Add(item)
        Next
    End Sub

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        If regKey.GetValue("Printer") Is Nothing OrElse regKey.GetValue("Printer").ToString() = "" And regKey.GetValue("DPI") Is Nothing OrElse regKey.GetValue("DPI").ToString() = "" Then
            MessageBox.Show("Please go to settings and select a printer", "Printer not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ZPLquery As String = SQL.Current.GetString(String.Format("SELECT [Value] FROM [Sys_Parameters] WHERE Parameter like 'RelabelMaterial'+'{0}'+'%'", regKey.GetValue("DPI").ToString()))
            Dim ZPLReplace As String = ZPLquery
            ZPLReplace = ZPLReplace.Replace(".PLANT", plantCB.Text)
            ZPLReplace = ZPLReplace.Replace(".PARTNUMBER", partNumberTB.Text)
            ZPLReplace = ZPLReplace.Replace(".QUANTITY", quantityTB.Text)
            ZPLReplace = ZPLReplace.Replace(".ASN", asnTb.Text)
            ZPLReplace = ZPLReplace.Replace(".SUPPLIER", supplierTB.Text)
            Dim path As String = "c:\temp\zpl.txt"
            If Not File.Exists(path) Then
                Using sw As StreamWriter = File.CreateText(path)
                    sw.WriteLine(ZPLReplace)
                End Using
            Else
                File.Delete(path)
                Using sw As StreamWriter = File.CreateText(path)
                    sw.WriteLine(ZPLReplace)
                End Using
            End If
            ZPL.PrintTo(ZPLReplace, regKey.GetValue("Printer").ToString())
            'File.Copy(path, regKey.GetValue("Printer").ToString())
            clean()
            MessageBox.Show("Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub clean()
        plantCB.Text = ""
        partNumberTB.Text = ""
        quantityTB.Text = ""
        asnTb.Text = ""
        supplierTB.Text = ""
    End Sub
End Class