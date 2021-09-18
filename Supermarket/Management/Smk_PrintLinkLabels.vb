Public Class Smk_PrintLinkLabels

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            Print()
            Serial_txt.Clear()
            Serial_txt.Focus()
        End If
    End Sub

    Private Sub Smk_LinkLabels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Focus()
    End Sub

    Private Sub Print()
        Dim linklabels As String = ""
         Dim serial As Hashtable = SQL.Current.GetRecord(String.Format("SELECT TOP 1 L.Partnumber, L.Linklabel, R.[Description] FROM Smk_LinkLabels AS L INNER JOIN Sys_RawMaterial AS R ON L.Partnumber = R.Partnumber WHERE L.Linklabel = '{0}' ORDER BY L.ID DESC", Serial_txt.Text))
        linklabels &= SMK.FormatLinkLabel(serial.Item("partnumber"), serial.Item("description"), serial.Item("linklabel"))
        If linklabels <> "" Then
            ZPL.PrintTo(linklabels, My.Settings.Printer)
            FlashAlerts.ShowConfirm("Etiqueta impresa.")
        End If
    End Sub
End Class