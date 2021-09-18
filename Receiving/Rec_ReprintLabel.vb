Public Class Rec_ReprintLabel
    Dim serials As DataTable
    Dim selected_serials As New List(Of String)
    Private Sub Rec_ReprintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintSerial_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If serials IsNot Nothing AndAlso serials.DefaultView.ToTable.Compute("COUNT([Serialnumber])", "Print = 1") > 0 Then
            REC.PrintLabels(serials.DefaultView.ToTable.Select("Print = 1"))
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Find()
    End Sub

    Private Sub Find()
        LoadingScreen.Show()
        If Serialnumber_rb.Checked Then
            If selected_serials.Count > 0 Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,Location,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE SerialNumber IN ('{0}') ORDER BY SerialNumber DESC", String.Join("','", selected_serials)))
            Else
                If Serial_txt.Text <> "" Then
                    serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,Location,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE SerialNumber LIKE '%{0}' ORDER BY SerialNumber DESC", Serial_txt.Text))
                End If
            End If

        ElseIf DateRange_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,Location,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY SerialNumber DESC", From_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss")))
        ElseIf Partnumber_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,Location,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE Partnumber LIKE '%{0}%' ORDER BY SerialNumber DESC", Partnumber_txt.Text))
        ElseIf Range_rb.Checked Then
            If IsNumeric(RangeA_txt.Text) AndAlso IsNumeric(Range2_txt.Text) Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,OriginalQuantity,UoM,WarehouseName,Location,TruckNumber,[Date],CONVERT(BIT,1) AS [Print] FROM vw_Smk_Serials WHERE ID BETWEEN {0} AND {1} ORDER BY SerialNumber DESC", CInt(RangeA_txt.Text), CInt(Range2_txt.Text)))
            Else
                FlashAlerts.ShowError("Rango incorrecto.")
            End If

        End If
        Serials_dgv.DataSource = serials
        LoadingScreen.Hide()
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRowView In serials.DefaultView
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

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            Find()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) Then
            Find()
        End If
    End Sub

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_serials)
        ld.Title = "Nos. de Serie"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_serials.Clear()
            For Each p In ld.Items
                If SMK.IsSerialFormat(p) AndAlso Not selected_serials.Contains(p) Then
                    selected_serials.Add(p)
                End If
            Next
            If selected_serials.Count > 0 Then
                Serial_txt.Text = String.Join(",", selected_serials.ToArray)
                Serial_txt.Enabled = False
            Else
                Serial_txt.Clear()
                Serial_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub
End Class