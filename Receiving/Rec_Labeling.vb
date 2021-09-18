Public Class Rec_Labeling

    Private Sub Rec_Labeling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateAll()
        Color_pnl.BackColor = ColorCode()
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
        UpdateScanners()
        UpdateScanning()
        UpdateQuantity()
        UpdateCritical()
        UpdateCriticalPartnumbers()
    End Sub

    Private Sub UpdateScanners()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        Pending_dgv.DataSource = conn.GetDatatable("SELECT DISTINCT Scanner AS Escaner FROM Smk_Serials WHERE Status = 'N' ORDER BY Scanner")
        conn = Nothing
    End Sub

    Private Sub UpdateScanning()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        News_dgv.DataSource = conn.GetDatatable("SELECT SerialNumber AS Serie,Partnumber AS [Numero de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha FROM Smk_Serials WHERE Status = 'N' ORDER BY [Date] DESC")
        conn = Nothing
    End Sub

    Private Sub UpdateQuantity()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        Quality_dgv.DataSource = conn.GetDatatable("SELECT SerialNumber AS Serie,Partnumber AS [Numero de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha FROM Smk_Serials WHERE Status = 'N' AND RedTag = 1 ORDER BY [Date] DESC")
        conn = Nothing
    End Sub

    Private Sub UpdateCritical()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        Critical_dgv.DataSource = conn.GetDatatable("SELECT SerialNumber AS Serie,Partnumber AS [Numero de Parte],Quantity AS Cantidad,UoM AS Unidad,[Date] AS Fecha FROM Smk_Serials WHERE Status = 'N' AND Critical = 1 ORDER BY [Date] DESC")
        conn = Nothing
    End Sub

    Private Sub UpdateCriticalPartnumbers()
        Dim conn As New SQL(SQL.Current.ConnectionString)
        CriticalPartnumbers_dgv.DataSource = conn.GetDatatable("SELECT Partnumber AS [Numero de Parte],C.Area,Comment AS Comentario,[Date] AS Fecha,FullName AS Usuario,Plates AS [Placas/Troca],Transporter AS Transportista,Delivery FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 ORDER BY [Date]")
        conn = Nothing
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Numero de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            Receiving.PrintLabels(SQL.Current.GetDatatable("vw_Smk_Serials", {"Status", "Scanner"}, {"N", eb.Answer}, {"[Date]"}), True)
        End If
    End Sub

    Private Sub Report_btn_Click(sender As Object, e As EventArgs) Handles Report_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Numero de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            LoadingScreen.Show()
            Dim series = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber AS Serie,Partnumber AS [Numero de Parte],Quantity AS Cantidad,UoM AS Unidad,Date AS Fecha,Warehouse AS Estacion,TruckNumber AS Troca,RedTag AS [Alerta de Calidad],Critical AS Critico,MasterLabel AS Master FROM Smk_Serials WHERE Status = 'N' AND Scanner = {0} ORDER BY [Date] DESC", eb.Answer), "Series")
            Dim resumen = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [Numero de Parte],SUM(Quantity) AS Cantidad,UoM AS Unidad FROM Smk_Serials WHERE Status = 'N' AND Scanner = {0} GROUP BY Partnumber,UoM ORDER BY Partnumber", eb.Answer), "Resumen")
            If MyExcel.SaveAs({series, resumen}, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape, ) Then
                LoadingScreen.Hide()
                MsgBox("Hecho!", MsgBoxStyle.Information, APP)
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub Clean_btn_Click(sender As Object, e As EventArgs) Handles Clean_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Numero de escaner:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK AndAlso IsNumeric(eb.Answer) Then
            Dim critical_alerted As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM Rec_CriticalPartnumbers WHERE Active = 1 AND Partnumber IN (SELECT Partnumber FROM Smk_Serials WHERE [Status] = 'N' AND Scanner = {0})", eb.Answer))
            If SQL.Current.Execute(String.Format("UPDATE Rec_CriticalPartnumbers SET Active = 0, LabelingDate = GETDATE(), LabelingUsername = '{0}' WHERE Active = 1 AND Partnumber IN (SELECT Partnumber FROM Smk_Serials WHERE [Status] = 'N' AND Scanner = {1})", User.Current.Username, eb.Answer)) AndAlso SQL.Current.Update("Smk_Serials", {"Status"}, {"P"}, {"Status", "Scanner"}, {"N", eb.Answer}) Then
                For Each critical As DataRow In critical_alerted.Rows
                    Delta.Alert("DeltaERP", critical.Item("Username"), String.Format("El numero de parte {0} reportado como critico ha sido etiquetado en recibos.", critical.Item("Partnumber")))
                Next
                If critical_alerted.Rows.Count > 0 Then
                    FlashAlerts.ShowInformation("Hecho! Entrega los numeros de parte criticos.", 2)
                Else
                    FlashAlerts.ShowConfirm("Hecho!")
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
End Class