Public Class Rec_DeleteLabel
    Dim serials As DataTable
    Dim deletables As ArrayList
    Private Sub Rec_ReprintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If User.Current.IsAdmin Then
            deletables = SQL.Current.GetList("SELECT [Description] FROM Smk_SerialStatus WHERE Status IN ('N','P','S','Q','T')")
        Else
            deletables = SQL.Current.GetList("SELECT [Description] FROM Smk_SerialStatus WHERE Status IN ('N','P','T')")
        End If
    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If serials IsNot Nothing AndAlso serials.DefaultView.ToTable.Compute("COUNT([Serie])", String.Format("Eliminar = 1 AND Estatus IN ('{0}')", String.Join("','", deletables.ToArray))) > 0 Then
            If MessageBox.Show(String.Format("¿Seguro de eliminar {0} serie(s) seleccionadas?", serials.DefaultView.ToTable.Compute("COUNT([Serie])", String.Format("Eliminar = 1 AND Estatus IN ('{0}')", String.Join("','", deletables.ToArray)))), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                LoadingScreen.Show()
                For Each r As DataRow In serials.DefaultView.ToTable.Select(String.Format("Eliminar = 1 AND Estatus IN ('{0}')", String.Join("','", deletables.ToArray)))
                    SQL.Current.Update("Smk_Serials", "Status", "D", "SerialNumber", r.Item("Serie"))
                    Log(r.Item("Serie"), "Rec_SerialDeleted")
                Next
                Find()
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Find()
    End Sub

    Private Sub Find()
        If Serialnumber_rb.Checked Then
            If Serial_txt.Text <> "" Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],OriginalQuantity AS Cantidad,UoM AS Unidad,WarehouseName AS Estacion,TruckNumber AS Troca,StatusDescription AS [Estatus],[Date] AS Fecha,CONVERT(BIT,0) AS Eliminar FROM vw_Smk_Serials WHERE SerialNumber LIKE '%{0}' AND Status <> 'D' ORDER BY SerialNumber DESC", Serial_txt.Text))
            End If
        ElseIf DateRange_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],OriginalQuantity AS Cantidad,UoM AS Unidad,WarehouseName AS Estacion,TruckNumber AS Troca,StatusDescription AS [Estatus],[Date] AS Fecha,CONVERT(BIT,0) AS Eliminar FROM vw_Smk_Serials WHERE Status <> 'D' AND [Date] BETWEEN '{0}' AND '{1}' ORDER BY SerialNumber DESC", From_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm:ss")))
        ElseIf Partnumber_rb.Checked Then
            serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],OriginalQuantity AS Cantidad,UoM AS Unidad,WarehouseName AS Estacion,TruckNumber AS Troca,StatusDescription AS [Estatus],[Date] AS Fecha,CONVERT(BIT,0) AS Eliminar FROM vw_Smk_Serials WHERE Status <> 'D' AND Partnumber LIKE '%{0}%' ORDER BY SerialNumber DESC", Partnumber_txt.Text))
        ElseIf Range_rb.Checked Then
            If IsNumeric(RangeA_txt.Text) AndAlso IsNumeric(Range2_txt.Text) Then
                serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [No. de Parte],OriginalQuantity AS Cantidad,UoM AS Unidad,WarehouseName AS Estacion,TruckNumber AS Troca,StatusDescription [Estatus],[Date] AS Fecha,CONVERT(BIT,0) AS Eliminar FROM vw_Smk_Serials WHERE Status <> 'D'  AND ID BETWEEN {0} AND {1} ORDER BY SerialNumber DESC", CInt(RangeA_txt.Text), CInt(Range2_txt.Text)))
            Else
                FlashAlerts.ShowError("Rango incorrecto.")
            End If
        End If
        Serials_dgv.DataSource = serials
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRowView In serials.DefaultView
                If deletables.Contains(s.Item("Estatus")) Then s.Item("Eliminar") = SelectAll_chk.Checked
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

    Private Sub Serials_dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Serials_dgv.RowsAdded
        If e.RowIndex >= 0 Then
            If deletables.Contains(Serials_dgv.Rows(e.RowIndex).Cells("Estatus").Value) Then
                Serials_dgv.Rows(e.RowIndex).ReadOnly = True
                Serials_dgv.Rows(e.RowIndex).Cells("Eliminar").ReadOnly = False
            Else
                Serials_dgv.Rows(e.RowIndex).ReadOnly = True
            End If
        End If
    End Sub

    Private Sub Rec_DeleteLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
End Class