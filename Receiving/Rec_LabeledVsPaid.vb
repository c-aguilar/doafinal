'SOLO PARA RBE V
Public Class Rec_LabeledVsPaid
    Dim series As DataTable
    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Dim np As String = "*"
        If Partnumber_txt.Text <> "" AndAlso Partnumber_txt.Text <> "*" Then
            np = Partnumber_txt.Text
        End If
        If np = "*" Then
            series = SQL.Current.GetDatatable(String.Format("SELECT R.PartNumber AS [Numero de Parte],SerialNumber AS Serie,Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,CONVERT(BIT,CASE WHEN Status IN ('S','O','C','Q','E') THEN 1 ELSE 0 END) AS [En Supermercado],CASE WHEN LEN(ISNULL(serial_randomLocal,ISNULL(RandomLocation,M.Location))) = 8 AND LEFT(ISNULL(serial_randomLocal,ISNULL(RandomLocation,M.Location)),2) IN ('11','12','13','14','15','16','17') THEN 'Sur' ELSE 'Norte' END AS Estacion FROM Smk_Serials AS R LEFT OUTER JOIN Smk_Map AS M ON R.Partnumber = M.Partnumber AND R.Warehouse = M.Warehouse LEFT OUTER JOIN SMSBarrels.dbo.tblSerials AS B ON R.SerialNumber = B.serial_number WHERE R.Status <> 'D' AND R.[Date] BETWEEN CONVERT(DATETIME,'{0}') AND CONVERT(DATETIME,'{1}')", From_dtp.Value.ToString("yyyy-MM-dd HH:mm"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "Series")
        Else
            series = SQL.Current.GetDatatable(String.Format("SELECT R.PartNumber AS [Numero de Parte],SerialNumber AS Serie,Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha,CONVERT(BIT,CASE WHEN Status IN ('S','O','C','Q','E') THEN 1 ELSE 0 END) AS [En Supermercado],CASE WHEN LEN(ISNULL(serial_randomLocal,ISNULL(RandomLocation,M.Location))) = 8 AND LEFT(ISNULL(serial_randomLocal,ISNULL(RandomLocation,M.Location)),2) IN ('11','12','13','14','15','16','17') THEN 'Sur' ELSE 'Norte' END AS Estacion FROM Smk_Serials AS R LEFT OUTER JOIN Smk_Map AS M ON R.Partnumber = M.Partnumber AND R.Warehouse = M.Warehouse LEFT OUTER JOIN SMSBarrels.dbo.tblSerials AS B ON R.SerialNumber = B.serial_number WHERE R.Status <> 'D' AND R.Partnumber = '{0}' AND R.[Date] BETWEEN CONVERT(DATETIME,'{1}') AND CONVERT(DATETIME,'{2}')", np, From_dtp.Value.ToString("yyyy-MM-dd HH:mm"), To_dtp.Value.ToString("yyyy-MM-dd HH:mm")), "Series")
        End If
        Result_dgv.DataSource = series
        chrPercentNorte.Series(0).Points.Clear()
        chrPercentNorte.Series(0).Points.AddXY("Localizados", series.Compute("COUNT(Serie)", "[En Supermercado] = 1 AND Estacion = 'NORTE'"))
        chrPercentNorte.Series(0).Points.AddXY("No Localizados", series.Compute("COUNT(Serie)", "[En Supermercado] = 0 AND Estacion = 'NORTE'"))
        lblNorte.Text = String.Format("Norte: {0} series.", series.Compute("COUNT(Serie)", "Estacion = 'NORTE'"))
        chrPercentSur.Series(0).Points.Clear()
        chrPercentSur.Series(0).Points.AddXY("Localizados", series.Compute("COUNT(Serie)", "[En Supermercado] = 1 AND Estacion = 'SUR'"))
        chrPercentSur.Series(0).Points.AddXY("No Localizados", series.Compute("COUNT(Serie)", "[En Supermercado] = 0 AND Estacion = 'SUR'"))
        lblSur.Text = String.Format("Sur: {0} series.", series.Compute("COUNT(Serie)", "Estacion = 'SUR'"))
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Result_dgv.DataSource IsNot Nothing Then
            If MyExcel.SaveAs(Result_dgv.DataSource, False) Then
                MsgBox("Hecho!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Rec_LabeledVsPaid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Rec_LabeledVsPaid_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class