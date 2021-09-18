Public Class Ord_SetMfgConsumption

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            LoadingScreen.Show()
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                Select Case RawMaterial.GetMfgConsumptionControlType(Partnumber_txt.Text)
                    Case RawMaterial.MfgConsumptionControlType.None
                        CurrentNone_rb.Checked = True
                        NewQuantity_nud.Value = 0
                    Case RawMaterial.MfgConsumptionControlType.Daily
                        CurrentDaily_rb.Checked = True
                        NewQuantity_nud.Value = Math.Max(RawMaterial.GetMfgConsumptionQty(Partnumber_txt.Text), SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()) ORDER BY [Date] DESC", Partnumber_txt.Text)))
                    Case RawMaterial.MfgConsumptionControlType.Weekly
                        CurrentWeekly_rb.Checked = True
                        NewQuantity_nud.Value = Math.Max(RawMaterial.GetMfgConsumptionQty(Partnumber_txt.Text), SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND DATEPART(WEEK,[Date]) = DATEPART(WEEK,GETDATE()) AND DATEPART(YEAR,[Date]) = DATEPART(YEAR,GETDATE()) ORDER BY [Date] DESC", Partnumber_txt.Text)))
                    Case RawMaterial.MfgConsumptionControlType.Monthly
                        CurrentMonthly_rb.Checked = True
                        NewQuantity_nud.Value = Math.Max(RawMaterial.GetMfgConsumptionQty(Partnumber_txt.Text), SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND DATEPART(MONTH,[Date]) = DATEPART(MONTH,GETDATE()) AND DATEPART(YEAR,[Date]) = DATEPART(YEAR,GETDATE()) ORDER BY [Date] DESC", Partnumber_txt.Text)))
                End Select
                UoM_lbl.Text = RawMaterial.GetUoM(Partnumber_txt.Text).ToString
                Dim plan As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],'Semana ' + CONVERT(VARCHAR(2),DATEPART(WEEK,[Date])) AS [Semana],SUM(P.Quantity*BOM.Quantity) AS Requerimiento FROM vw_SchPR_DailyProductionPlan AS P INNER JOIN Sys_CurrentBOM AS BOM ON P.Material = BOM.Material WHERE DATEPART(WEEK,[Date]) >= DATEPART(WEEK,GETDATE()) AND DATEPART(YEAR,[Date]) >= DATEPART(YEAR,GETDATE()) AND BOM.Partnumber = '{0}' GROUP BY Partnumber,DATEPART(WEEK,[Date]) ORDER BY Partnumber,DATEPART(WEEK,[Date])", Partnumber_txt.Text))
                Plan_dgv.DataSource = DatatablePivoter.Get(plan, {"No. de Parte"}, {"Semana"}, {"Requerimiento"}, {AggregateFunction.Sum})
                LoadingScreen.Hide()
                NewQuantity_nud.Focus()
            Else
                Clean()
                LoadingScreen.Hide()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If RawMaterial.Exists(Partnumber_txt.Text) Then
            If PermanentChange_chk.Checked Then
                If SQL.Current.Update("Sys_RawMaterial", {"MfgConsumptionControl", "MfgConsumptionQty"}, {If(CurrentNone_rb.Checked, "N", If(CurrentDaily_rb.Checked, "D", If(CurrentWeekly_rb.Checked, "W", "M"))), NewQuantity_nud.Value}, "Partnumber", Partnumber_txt.Text) Then
                    Clean()
                    FlashAlerts.ShowConfirm("¡Hecho!")
                Else
                    FlashAlerts.ShowError("Error al actualizar el número de parte.")
                End If
            Else
                If SQL.Current.Insert("Ord_MfgConsumptionIncrease", {"Partnumber", "NewQuantity", "Username"}, {RawMaterial.Format(Partnumber_txt.Text), NewQuantity_nud.Value, User.Current.Username}) Then
                    Clean()
                    FlashAlerts.ShowConfirm("¡Hecho!")
                Else
                    FlashAlerts.ShowError("Error al actualizar el número de parte.")
                End If
            End If
        End If
    End Sub
    Private Sub Clean()
        Plan_dgv.DataSource = Nothing
        Partnumber_txt.Clear()
        CurrentNone_rb.Checked = True
        PermanentChange_chk.Checked = False
        NewQuantity_nud.Value = 0
        UoM_lbl.Text = ""
    End Sub

    Private Sub Ord_SetMfgConsumption_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class