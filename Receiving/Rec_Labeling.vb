Public Class Rec_Labeling

    Private Sub Rec_Labeling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateAll()
    End Sub

    Private Sub Main_tmr_Tick(sender As Object, e As EventArgs) Handles Main_tmr.Tick
        UpdateAll()
    End Sub

    Public Function ColorCode() As Color
        Dim record = SQL.Current.GetRecord("SELECT R,G,B FROM Rec_ColorCodes WHERE Month = DATEPART(Month,GETDATE())")
        If record IsNot Nothing AndAlso record.Count > 0 Then
            Return Color.FromArgb(CInt(record.Item("r")), CInt(record.Item("g")), CInt(record.Item("b")))
        Else
            Return Color.White
        End If
    End Function

    Private Sub UpdateAll()
        Month_lbl.Text = StrConv(Delta.CurrentDate.ToString("MMMM", Globalization.CultureInfo.CreateSpecificCulture("es-ES")), VbStrConv.ProperCase)
        Color_pnl.BackColor = ColorCode()
        UpdateScanners()
        UpdateScanning()
        UpdateCriticalPartnumbers()
        UpdateDashboard()
    End Sub

    Private Sub UpdateDashboard()
        If SQL.Current.Available Then
            Dim counter As Integer = SQL.Current.GetScalar("COUNT(ID)", "Smk_Serials", {"[Status]", "InvoiceTrouble"}, {"T", 0})
            PendingToReleaseCounter_lbl.Text = counter
            If counter = 0 Then
                PendingToReleaseCounter_lbl.ForeColor = Color.YellowGreen
            Else
                PendingToReleaseCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Smk_Serials WHERE Status IN ('N','P') AND DATEDIFF(HOUR,[Date],GETDATE()) >= 6")
            MoreThan6HoursCounter_lbl.Text = counter
            If counter = 0 Then
                MoreThan6HoursCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MoreThan6HoursCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(DISTINCT Partnumber) FROM Smk_Serials WHERE Critical = 1  GROUP BY Partnumber,CONVERT(DATE,[Date]) HAVING SUM(CASE WHEN [Status] IN ('N','P') THEN 1 ELSE 0 END) = COUNT(ID)")
            MissingCriticalCounter_lbl.Text = counter
            If counter = 0 Then
                MissingCriticalCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MissingCriticalCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Smk_Serials WHERE [Status] IN ('N','P') AND RedTag = 1")
            MissingQualityCounter_lbl.Text = counter
            If counter = 0 Then
                MissingQualityCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MissingQualityCounter_lbl.ForeColor = Color.Firebrick
            End If
        End If
    End Sub

    Private Sub UpdateScanners()
        If SQL.Current.Available Then
            Pending_dgv.DataSource = SQL.Current.GetDatatable("SELECT DISTINCT Scanner AS Escaner FROM Smk_Serials WHERE Status = 'N' ORDER BY Scanner")
        End If
    End Sub

    Private Sub UpdateScanning()
        If SQL.Current.Available Then
            News_dgv.DataSource = SQL.Current.GetDatatable("SELECT SerialNumber,S.Partnumber,Quantity,UoM,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,Critical,RedTag,Scanner,TruckNumber FROM Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber WHERE S.Status = 'N' ORDER BY S.Scanner,S.[Date] DESC")
        End If
    End Sub

    Private Sub UpdateCriticalPartnumbers()
        If SQL.Current.Available Then
            CriticalPartnumbers_dgv.DataSource = SQL.Current.GetDatatable("SELECT Partnumber AS [No. de Parte],C.Area,Comment AS Comentario,Plates AS [Placas/Troca],Transporter AS Transportista,Delivery,[Date] AS Fecha,FullName AS Usuario,CASE WHEN C.Quantity IS NOT NULL THEN CONVERT(VARCHAR(10),C.Quantity) + ' / ' + CONVERT(VARCHAR(10),ISNULL((SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber, S.UoM, S.Quantity, R.UoM)) FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Partnumber = C.Partnumber AND S.[Date] >= C.[Date] AND S.[New] = 1 GROUP BY S.Partnumber),0)) + (SELECT UoM FROM Sys_RawMaterial AS R WHERE R.Partnumber = C.Partnumber)  ELSE NULL END AS Cantidad FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [Date]")
        End If
    End Sub

    

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Número de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            REC.PrintLabels(SQL.Current.GetDatatable("vw_Smk_Serials", {"Status", "Scanner"}, {"N", eb.Answer}, {"[Date]"}), True)
        End If
        eb.Dispose()
    End Sub

    Private Sub Report_btn_Click(sender As Object, e As EventArgs) Handles Report_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Número de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            LoadingScreen.Show()
            Dim series = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [Numero de Parte],Quantity AS Cantidad,UoM AS Unidad,Date AS Fecha,Warehouse AS Estacion,TruckNumber AS Troca,RedTag AS [Alerta de Calidad],Critical AS Critico,MasterLabel AS Master FROM Smk_Serials WHERE Status = 'N' AND Scanner = {0} ORDER BY [Date] DESC", eb.Answer), "Series")
            Dim resumen = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [Numero de Parte],SUM(Quantity) AS Cantidad,UoM AS Unidad FROM Smk_Serials WHERE Status = 'N' AND Scanner = {0} GROUP BY Partnumber,UoM ORDER BY Partnumber", eb.Answer), "Resumen")
            If MyExcel.SaveAs({series, resumen}, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape, ) Then
                LoadingScreen.Hide()
                MsgBox("¡Hecho!", MsgBoxStyle.Information, APP)
            Else
                LoadingScreen.Hide()
            End If
        End If
        eb.Dispose()
    End Sub

    Private Sub Clean_btn_Click(sender As Object, e As EventArgs) Handles Clean_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Número de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            Dim critical_alerted As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM Rec_CriticalPartnumbers WHERE Active = 1 AND Partnumber IN (SELECT Partnumber FROM Smk_Serials WHERE [Status] = 'N' AND Scanner = {0})", eb.Answer))
            If SQL.Current.Execute(String.Format("UPDATE Rec_CriticalPartnumbers SET Active = 0, LabelingDate = GETDATE(), LabelingUsername = '{0}' WHERE Active = 1 AND Quantity IS NULL AND Partnumber IN (SELECT Partnumber FROM Smk_Serials WHERE [Status] = 'N' AND Scanner = {1})", User.Current.Username, eb.Answer)) AndAlso SQL.Current.Update("Smk_Serials", {"Status"}, {"P"}, {"Status", "Scanner"}, {"N", eb.Answer}) Then
                SQL.Current.Execute(String.Format("UPDATE Rec_CriticalPartnumbers SET Active = 0, LabelingDate = GETDATE(), LabelingUsername = '{0}' FROM  WHERE Active = 1 AND Quantity IS NOT NULL", User.Current.Username, eb.Answer))
                Dim quantity_alerts = SQL.Current.GetDatatable("SELECT ID,Quantity,ISNULL((SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,S.Quantity,R.UoM)) FROM Smk_Serials AS S INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Partnumber = C.Partnumber AND S.[Date] >= C.[Date] AND S.[New] = 1 GROUP BY S.Partnumber),0) AS Labeled FROM Rec_CriticalPartnumbers AS C WHERE Active = 1 AND Quantity IS NOT NULL")
                For Each qa As DataRow In quantity_alerts.Rows
                    If qa.Item("Labeled") >= qa.Item("Quantity") Then
                        SQL.Current.Execute(String.Format("UPDATE Rec_CriticalPartnumbers SET Active = 0, LabelingDate = GETDATE(), LabelingUsername = '{0}' WHERE ID = {1};", User.Current.Username, qa.Item("ID")))
                    End If
                Next
                For Each critical As DataRow In critical_alerted.Rows
                    Delta.Alert("DeltaERP", critical.Item("Username"), String.Format("El número de parte {0} reportado como crítico ha sido etiquetado en recibos.", critical.Item("Partnumber")))
                Next
                If critical_alerted.Rows.Count > 0 Then
                    FlashAlerts.ShowInformation("¡Hecho! Entrega los números de parte críticos.", 2)
                Else
                    FlashAlerts.ShowConfirm("¡Hecho!")
                End If
                UpdateAll()
            Else
                FlashAlerts.ShowError("Error al actualizar.")
            End If
        End If
        eb.Dispose()
    End Sub

    Private Sub Rec_Labeling_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub News_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles News_dgv.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = News_dgv.Columns("Critical").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.flag_flyaway_red, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = News_dgv.Columns("RedTag").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.shield, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = News_dgv.Columns("Controlled").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.battery_low, rect)
            e.Handled = True
        End If

        If e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("Controlled").Index Then
            If CBool(News_dgv.Rows(e.RowIndex).Cells("Controlled").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.battery_low, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("Critical").Index Then
            If CBool(News_dgv.Rows(e.RowIndex).Cells("Critical").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.flag_flyaway_red, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("RedTag").Index Then
            If CBool(News_dgv.Rows(e.RowIndex).Cells("RedTag").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.shield, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub News_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles News_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("Critical").Index AndAlso CBool(News_dgv.Rows(e.RowIndex).Cells("Critical").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(231, 76, 60)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("RedTag").Index AndAlso CBool(News_dgv.Rows(e.RowIndex).Cells("RedTag").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(120, 69, 103)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = News_dgv.Columns("Controlled").Index AndAlso CBool(News_dgv.Rows(e.RowIndex).Cells("Controlled").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(247, 220, 111)
        End If
    End Sub

    Private Sub PendingToReleaseCounter_lbl_DoubleClick(sender As Object, e As EventArgs) Handles PendingToReleaseCounter_lbl.DoubleClick
        ShowPopup(SQL.Current.GetDatatable("SELECT Serialnumber AS [No. de Serie],Partnumber AS [No. de Parte],[Description] AS Descripcion, OriginalQuantity AS StdPack, CurrentQuantity AS [Cantidad Actual], UoM AS Unidad,[Date] AS Fecha,[Location] AS Localizacion FROM vw_Smk_Serials WHERE [Status] = 'T' AND InvoiceTrouble = 0;"), "Material Liberado de Tracker sin Entregar", 900, 300, ScannerPendingPrint_lbl.PointToScreen(Point.Empty))
    End Sub

    Private Sub MoreThan6HoursCounter_lbl_DoubleClick(sender As Object, e As EventArgs) Handles MoreThan6HoursCounter_lbl.DoubleClick
        ShowPopup(SQL.Current.GetDatatable("SELECT Serialnumber AS [No. de Serie],Partnumber AS [No. de Parte], [Description] AS Descripcion, CurrentQuantity AS [Cantidad], UoM AS Unidad,[Date] AS Fecha, TruckNumber AS [No. de Troca],MaterialType AS [Tipo de Material] FROM vw_Smk_Serials WHERE [Status] IN ('N','P') AND DATEDIFF(HOUR,[Date],GETDATE()) >= 6;"), "Series en Rampas mas de 6 Horas", 900, 300, ScannerPendingPrint_lbl.PointToScreen(Point.Empty))
    End Sub

    Private Sub MissingCriticalCounter_lbl_DoubleClick(sender As Object, e As EventArgs) Handles MissingCriticalCounter_lbl.DoubleClick
        ShowPopup(SQL.Current.GetDatatable("SELECT Serialnumber AS [No. de Serie],Partnumber AS [No. de Parte], [Description] AS Descripcion, CurrentQuantity AS [Cantidad], UoM AS Unidad,[Date] AS Fecha, TruckNumber AS [No. de Troca] FROM vw_Smk_Serials WHERE Critical = 1 AND [Status] IN ('N','P') AND Partnumber IN (SELECT Partnumber FROM Smk_Serials WHERE Critical = 1  GROUP BY Partnumber,CONVERT(DATE,[Date]) HAVING SUM(CASE WHEN [Status] IN ('N','P') THEN 1 ELSE 0 END) = COUNT(ID))"), "Material Etiquetado Critico sin Entregar", 900, 300, ScannerPendingPrint_lbl.PointToScreen(Point.Empty))
    End Sub

    Private Sub MissingQualityCounter_lbl_DoubleClick(sender As Object, e As EventArgs) Handles MissingQualityCounter_lbl.DoubleClick
        ShowPopup(SQL.Current.GetDatatable("SELECT Serialnumber AS [No. de Serie],Partnumber AS [No. de Parte],[Description] AS Descripcion, OriginalQuantity AS StdPack, CurrentQuantity AS [Cantidad Actual], UoM AS Unidad,[Date] AS Fecha,dbo.Qly_AlertReasons(Partnumber,[Date]) AS Motivo FROM vw_Smk_Serials WHERE [Status] IN ('N','P') AND RedTag = 1;"), "Material Alertado sin Entregar a Calidad", 900, 300, ScannerPendingPrint_lbl.PointToScreen(Point.Empty))
    End Sub
End Class