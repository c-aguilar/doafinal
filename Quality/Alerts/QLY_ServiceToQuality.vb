Public Class QLY_ServiceToQuality
    Dim serials As DataTable

    Private Sub QLY_ServiceToQuality_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintSerial_btn_Click(sender As Object, e As EventArgs) Handles Alert_btn.Click
        If serials IsNot Nothing AndAlso serials.DefaultView.ToTable.Compute("COUNT([Serialnumber])", "Alert = 1") > 0 AndAlso MessageBox.Show("¿Continuar con la alerta de las series seleccionadas?", "Confirmar Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim alerted As Integer = 0
            For Each row As DataRow In serials.DefaultView.ToTable.Select("Alert = 1")
                Dim serial As New Serialnumber(row.Item("SerialNumber"))
                If serial.LockQuality() Then
                    alerted += 1
                End If
            Next
            Find()
            FlashAlerts.ShowInformation(String.Format("{0} series alertadas.", alerted))
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Find()
    End Sub

    Private Sub Find()
        serials = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,Partnumber,CurrentQuantity,UoM,WarehouseName,TruckNumber,[Date],CONVERT(BIT,0) AS [Alert] FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND RedTag = 0 AND Status NOT IN ('E','D') ORDER BY SerialNumber DESC", Partnumber_txt.Text))
        Serials_dgv.DataSource = serials
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRowView In serials.DefaultView
                s.Item("Alert") = SelectAll_chk.Checked
            Next
        End If
    End Sub

    Private Sub Rec_ReprintLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

  
    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            Find()
        End If
    End Sub
End Class