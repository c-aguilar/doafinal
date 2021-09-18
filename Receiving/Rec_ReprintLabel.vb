Public Class Rec_ReprintLabel
    Dim serials As DataTable

    Private Sub Rec_ReprintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintSerial_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If serials IsNot Nothing AndAlso serials.Compute("COUNT([Serialnumber])", "Print = 1") > 0 Then
            Receiving.PrintLabels(serials.Select("Print = 1"))
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        If Serialnumber_rb.Checked Then
            If Serial_txt.Text <> "" Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE SerialNumber LIKE '%{0}' ORDER BY SerialNumber DESC", Serial_txt.Text))
            End If
        ElseIf DateRange_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY SerialNumber DESC", From_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss")))
        ElseIf Partnumber_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE Partnumber LIKE '%{0}%' ORDER BY SerialNumber DESC", Partnumber_txt.Text))
        ElseIf Range_rb.Checked Then
            If IsNumeric(RangeA_txt.Text) AndAlso IsNumeric(Range2_txt.Text) Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE ID BETWEEN {0} AND {1} ORDER BY SerialNumber DESC", CInt(RangeA_txt.Text), CInt(Range2_txt.Text)))
            Else
                FlashAlerts.ShowError("Rango incorrecto.")
            End If

        End If
        Serials_dgv.DataSource = serials
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRow In serials.Rows
                s.Item("Print") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub From_dtp_ValueChanged(sender As Object, e As EventArgs) Handles From_dtp.ValueChanged, To_dtp.ValueChanged
        DateRange_rb.Checked = True
    End Sub

    Private Sub Serial_txt_Enter(sender As Object, e As EventArgs) Handles Serial_txt.Enter
        Serialnumber_rb.Checked = True
    End Sub

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Rec_ReprintLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub RangeA_txt_Enter(sender As Object, e As EventArgs) Handles RangeA_txt.Enter
        Range_rb.Checked = True
    End Sub

    Private Sub Range2_txt_Enter(sender As Object, e As EventArgs) Handles Range2_txt.Enter
        Range_rb.Checked = True
    End Sub
End Class