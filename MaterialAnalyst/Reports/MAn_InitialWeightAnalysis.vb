Public Class MAn_InitialWeightAnalysis
    Dim data As DataTable
    Dim info As DataTable
    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Try
            LoadingScreen.Show()
            If SMK.IsRawMaterialFormat(Partnumber_txt.Text.Trim) Then
                info.Rows.Clear()

                Dim pn As String = RawMaterial.Format(Partnumber_txt.Text.Trim)
                Dim description As String = RawMaterial.GetDescription(pn)
                Dim supplierno As String = RawMaterial.GetSupplierNumber(pn)
                Dim supppliername As String = RawMaterial.GetSupplierName(pn)
                Dim unitweight As String = RawMaterial.GetWeight(pn)

                info.Rows.Add("No. de Parte", pn)
                info.Rows.Add("Descripcion", description)
                info.Rows.Add("No.Proveedor", supplierno)
                info.Rows.Add("Nombre Proveedor", supppliername)
                info.Rows.Add("Peso Unitario", unitweight)

                data = SQL.Current.GetDatatable(String.Format("SELECT L.ID,S.SerialNumber,S.Partnumber,dbo.Sys_UnitConversion(R.Partnumber,S.UoM,S.Quantity,R.UoM) AS Quantity,R.UoM AS BuM,S.[Date],L.[Date] AS WeightDate,C.ID AS ContainerID,C.Name AS ContainerName,C.[Weight] AS ContainerWeight,CONVERT(DECIMAL(10,3),SUBSTRING(L.[Description],17,LEN(L.[Description])-22)) AS InitialWeight,CONVERT(DECIMAL(10,3),SUBSTRING(L.[Description],17,LEN(L.[Description])-22))/dbo.Sys_UnitConversion(R.Partnumber,S.UoM,S.Quantity,R.UoM)*1000 AS CalculatedUnitWeight FROM Sys_Log AS L INNER JOIN Smk_Serials AS S ON LEFT(L.[Description],15) = S.SerialNumber INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber INNER JOIN Smk_Containers AS C ON RIGHT(L.[Description],5) = C.ID WHERE KeyWord IN ('Smk_CableInitialWeight','Smk_SerialInitialWeight') AND S.New = 1 AND S.Partnumber = '{0}' AND L.[Date] BETWEEN '{1}' AND '{2}'", Partnumber_txt.Text.Trim, DeltaFrom_dtp.Value.ToString("yyyy-MM-dd"), DeltaTo_dtp.Value.ToString("yyyy-MM-dd")), "Historial de Pesaje")
                Data_dgv.DataSource = data
                Weight_chart.DataSource = data
                Weight_chart.ChartAreas(0).CursorY.Position = unitweight
                Weight_chart.ChartAreas(0).CursorY.LineWidth = 2
                Weight_chart.ChartAreas(0).CursorY.LineColor = Color.DarkGreen

                Data_txt.Text = String.Join(vbCrLf, "No. de Parte:", pn, description, vbCrLf, "Proveedor:", supplierno, supppliername, vbCrLf, "Peso Unitario:", unitweight)
                LoadingScreen.Hide()
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowInformation("Escribe el número de parte correctamente.")
            End If
        Catch ex As Exception
            FlashAlerts.ShowError("Surgió un error con la información.")
        End Try
    End Sub

    Private Sub MAn_InitialWeightAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Data_dgv.Columns("cancel_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.cross_16
        info = New DataTable("Informacion de NP")
        info.Columns.Add("Dato")
        info.Columns.Add("Valor")
        DeltaFrom_dtp.Value = DateAdd(DateInterval.Day, -30, Delta.CurrentDate)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If data IsNot Nothing Then
            LoadingScreen.Show()
            If MyExcel.SaveAs({data, info}, True) Then
                FlashAlerts.ShowConfirm("Exportado.")
            End If
            LoadingScreen.Hide()
        End If
    End Sub
End Class