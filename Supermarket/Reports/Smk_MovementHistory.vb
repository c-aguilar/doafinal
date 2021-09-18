Public Class Smk_MovementHistory


    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Serial_txt_Enter(sender As Object, e As EventArgs) Handles Serial_txt.Enter
        Serial_rb.Checked = True
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        If Partnumber_rb.Checked Then
            If Partnumber_txt.Text.Trim.Length = 8 Then
                Movements_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS Serie,S.Partnumber AS [No. de Parte], D.[Description] AS Movimiento,M.[Location] AS Localizacion,M.Quantity AS Descuento,S.UoM AS Unidad,O.Fullname AS Operador,M.[Date] AS Fecha,T.Posted AS [Trasferido],T.Quantity+AdjustmentQuantity AS [Cantidad Transferida],T.FromSloc AS [De Sloc],T.ToSloc AS [Al Sloc],DocumentNumber AS [Numero de Documento],U.Fullname AS [Transferido por] FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username WHERE S.Partnumber = '{0}' AND CONVERT(DATE,M.[Date]) BETWEEN '{1}' AND '{2}' ORDER BY M.[Date] DESC;", Partnumber_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "Movimientos")
            ElseIf Partnumber_txt.Text.Trim <> "" Then
                FlashAlerts.ShowInformation("Captura el numero de parte completo.")
            Else
                Movements_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS Serie,S.Partnumber AS [No. de Parte], D.[Description] AS Movimiento,M.[Location] AS Localizacion,M.Quantity AS Descuento,S.UoM AS Unidad,O.Fullname AS Operador,M.[Date] AS Fecha,T.Posted AS [Trasferido],T.Quantity+AdjustmentQuantity AS [Cantidad Transferida],T.FromSloc AS [De Sloc],T.ToSloc AS [Al Sloc],DocumentNumber AS [Numero de Documento],U.Fullname AS [Transferido por] FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username WHERE CONVERT(DATE,M.[Date]) BETWEEN '{0}' AND '{1}' ORDER BY M.[Date] DESC;", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "Movimientos")
            End If
        ElseIf Serial_rb.Checked Then
            If SMK.IsSerial(Serial_txt.Text) Then
                Movements_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS Serie,S.Partnumber AS [No. de Parte], D.[Description] AS Movimiento,M.[Location] AS Localizacion,M.Quantity AS Descuento,S.UoM AS Unidad,O.Fullname AS Operador,M.[Date] AS Fecha,T.Posted AS [Trasferido],T.Quantity+AdjustmentQuantity AS [Cantidad Transferida],T.FromSloc AS [De Sloc],T.ToSloc AS [Al Sloc],DocumentNumber AS [Numero de Documento],U.Fullname AS [Transferido por] FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username WHERE S.Serialnumber = '{0}' AND CONVERT(DATE,M.[Date]) BETWEEN '{1}' AND '{2}' ORDER BY M.[Date] DESC;", Serial_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "Movimientos")
            ElseIf Serial_txt.Text.Trim <> "" Then
                FlashAlerts.ShowInformation("Captura el numero de serie completo.")
            Else
                Movements_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber AS Serie,S.Partnumber AS [No. de Parte], D.[Description] AS Movimiento,M.[Location] AS Localizacion,M.Quantity AS Descuento,S.UoM AS Unidad,O.Fullname AS Operador,M.[Date] AS Fecha,T.Posted AS [Trasferido],T.Quantity+AdjustmentQuantity AS [Cantidad Transferida],T.FromSloc AS [De Sloc],T.ToSloc AS [Al Sloc],DocumentNumber AS [Numero de Documento],U.Fullname AS [Transferido por] FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username WHERE CONVERT(DATE,M.[Date]) BETWEEN '{0}' AND '{1}' ORDER BY M.[Date] DESC;", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "Movimientos")
            End If
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Movements_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Movements_dgv.DataSource, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Movements_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Movements_dgv.DataSource
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub Smk_FindSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Clear()
        Serial_txt.Focus()
        From_dtp.Value = CurrentDate.AddMonths(-12)
    End Sub

    Private Sub Smk_FindSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.TextLength = 8 Then
            Find_btn.PerformClick()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerial(Serial_txt.Text) Then
            Find_btn.PerformClick()
        End If
    End Sub
End Class