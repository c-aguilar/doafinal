Public Class Smk_LinkLabels

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim selected_partnumbers As New ArrayList
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(RawMaterial.Format(p)) Then
                    selected_partnumbers.Add(RawMaterial.Format(p))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Dim linklabels As String = ""
                For Each part In selected_partnumbers
                    If SQL.Current.Insert("Smk_LinkLabels", "Partnumber", part) Then
                        Dim serial As Hashtable = SQL.Current.GetRecord(String.Format("SELECT TOP 1 L.Partnumber, L.Linklabel, R.[Description] FROM Smk_LinkLabels AS L INNER JOIN Sys_RawMaterial AS R ON L.Partnumber = R.Partnumber WHERE L.Partnumber = '{0}' ORDER BY L.ID DESC", part))
                        linklabels &= SMK.FormatLinkLabel(serial.Item("partnumber"), serial.Item("description"), serial.Item("linklabel"))
                    End If
                Next
                If linklabels <> "" Then
                    ZPL.PrintTo(linklabels, My.Settings.Printer)
                    FlashAlerts.ShowConfirm("Etiquetas generadas.")
                End If
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Smk_LinkLabels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Partnumber_txt.MaskCompleted Then
            Dim linklabels As String = ""
            If SQL.Current.Insert("Smk_LinkLabels", "Partnumber", Partnumber_txt.Text) Then
                Dim serial As Hashtable = SQL.Current.GetRecord(String.Format("SELECT TOP 1 L.Partnumber, L.Linklabel, R.[Description] FROM Smk_LinkLabels AS L INNER JOIN Sys_RawMaterial AS R ON L.Partnumber = R.Partnumber WHERE L.Partnumber = '{0}' ORDER BY L.ID DESC", Partnumber_txt.Text))
                linklabels &= SMK.FormatLinkLabel(serial.Item("partnumber"), serial.Item("description"), serial.Item("linklabel"))
                If linklabels <> "" Then
                    ZPL.PrintTo(linklabels, My.Settings.Printer)
                    FlashAlerts.ShowConfirm("Etiqueta generada.")
                End If
            Else
                FlashAlerts.ShowError("No fue posible imprimir la etiqueta.")
            End If
        End If
    End Sub
End Class