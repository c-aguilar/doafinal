Public Class Smk_AlertMissing
    Dim sb As SearchBox
    Private Sub Smk_AlertMissing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Report_dgv)
        RefreshAlerts()
    End Sub

    Private Sub RefreshAlerts()
        Report_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT A.[Partnumber] AS [No. de Parte],M.MRP,U.FullName AS [Dueño],[Type] AS [Tipo de Alerta],O.FullName AS [Reportado por],A.[Date] AS Fecha,[Comment] AS Comentario,AU.FullName AS [Respondido por],[AnswerDate] AS [Fecha Respuesta],[Answer] AS Respuesta,[PromiseDate] AS [Fecha Promesa] FROM Ord_RawMaterialAlerts AS A INNER JOIN Sys_RawMaterial AS R ON A.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS AU ON A.AnswerUsername = AU.Username WHERE (A.[Type] IN ('Minimo','Critico') AND (PromiseDate IS NULL OR CONVERT(DATE,PromiseDate) >= CONVERT(DATE,GETDATE()))) OR (A.[Type] = 'Maximo' AND Answer IS NULL) ORDER BY A.[Date];"))
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshAlerts()
    End Sub

    Private Sub Report_btn_Click(sender As Object, e As EventArgs) Handles Report_btn.Click
        If Partnumber_txt.Text <> "" Then
            Dim partnumber As New RawMaterial(Partnumber_txt.Text.Trim)
            If partnumber.Exist Then
                Dim current_alert As Hashtable
                Dim alert As String
                Dim available As Integer = SQL.Current.GetScalar(String.Format("SELECT COUNT(Serialnumber) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND ([Status] IN ('S','O','C','T','Q','U') OR ([Status] IN ('N','P') AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()))) AND CurrentQuantity > 0;", partnumber.Partnumber))
                If available = 0 Then
                    alert = "Critico"
                    current_alert = SQL.Current.GetRecord(String.Format("SELECT O.Fullname AS [Operator],A.[Date],Answer,PromiseDate,U.Fullname AS AnswerBy FROM Ord_RawMaterialAlerts AS A LEFT OUTER JOIN Sys_Users AS U ON A.AnswerUsername = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge WHERE A.Partnumber = '{0}' AND A.[Type] = '{1}' AND A.PromiseDate >= GETDATE()", partnumber.Partnumber, alert))
                    If current_alert IsNot Nothing AndAlso current_alert.Count > 0 Then
                        MessageBox.Show(String.Format("Material con fecha promesa disponible:{0}{0}Respuesta: {1}{0}Fecha promesa: {2}{0}Por: {3}", vbCrLf, current_alert.Item("answer"), current_alert.Item("promisedate"), current_alert.Item("answerby")), "Fecha Promesa Vigente")
                    Else
                        SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {partnumber.Partnumber, Comment_txt.Text, alert, User.Current.Badge})
                        FlashAlerts.ShowConfirm("Hecho!")
                        Partnumber_txt.Clear()
                        Comment_txt.Clear()
                        RefreshAlerts()
                    End If
                ElseIf Critical_rb.Checked AndAlso available > 0 Then
                    Partnumber_txt.Clear()
                    Comment_txt.Clear()
                    FlashAlerts.ShowError("Aun existen contenedores disponibles en planta.")
                ElseIf Minimum_rb.Checked AndAlso available >= SQL.Current.GetScalar("SUM([Minimum])", "Smk_Map", "Partnumber", partnumber.Partnumber, 1) Then
                    Partnumber_txt.Clear()
                    Comment_txt.Clear()
                    FlashAlerts.ShowError("Aun existen suficientes contenedores disponibles en planta.")
                ElseIf Minimum_rb.Checked Then
                    alert = "Minimo"
                    current_alert = SQL.Current.GetRecord(String.Format("SELECT O.Fullname AS [Operator],A.[Date],Answer,PromiseDate,U.Fullname AS AnswerBy FROM Ord_RawMaterialAlerts AS A LEFT OUTER JOIN Sys_Users AS U ON A.AnswerUsername = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge WHERE A.Partnumber = '{0}' AND A.[Type] = '{1}' AND A.PromiseDate >= GETDATE()", partnumber.Partnumber, alert))
                    If current_alert IsNot Nothing AndAlso current_alert.Count > 0 Then
                        MessageBox.Show(String.Format("Material con fecha promesa disponible:{0}{0}Respuesta: {1}{0}Fecha promesa: {2}{0}Por: {3}", vbCrLf, current_alert.Item("answer"), current_alert.Item("promisedate"), current_alert.Item("answerby")), "Fecha Promesa Vigente")
                    Else
                        SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {partnumber.Partnumber, Comment_txt.Text, alert, User.Current.Badge})
                        FlashAlerts.ShowConfirm("Hecho!")
                        Partnumber_txt.Clear()
                        Comment_txt.Clear()
                        RefreshAlerts()
                    End If
                ElseIf Maximum_rb.Checked AndAlso available <= SQL.Current.GetScalar("SUM([Maximum])", "Smk_Map", "Partnumber", partnumber.Partnumber, 1) Then
                    Partnumber_txt.Clear()
                    Comment_txt.Clear()
                    FlashAlerts.ShowError("Aun no se ha sobrepasado el maximo en planta.")
                ElseIf Maximum_rb.Checked Then
                    alert = "Maximo"
                    current_alert = SQL.Current.GetRecord(String.Format("SELECT O.Fullname AS [Operator],A.[Date],Answer,PromiseDate,U.Fullname AS AnswerBy FROM Ord_RawMaterialAlerts AS A LEFT OUTER JOIN Sys_Users AS U ON A.AnswerUsername = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge WHERE A.Partnumber = '{0}' AND A.[Type] = '{1}' AND CONVERT(DATE, A.Date) = CONVERT(DATE, GETDATE());", partnumber.Partnumber, alert))
                    If current_alert IsNot Nothing AndAlso current_alert.Count > 0 Then
                        MsgBox("El numero de parte ya fue reportado el dia de hoy.", MsgBoxStyle.OkOnly, "Alerta duplicada")
                    Else
                        SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {partnumber.Partnumber, Comment_txt.Text, alert, User.Current.Badge})
                        FlashAlerts.ShowConfirm("Hecho!")
                        Partnumber_txt.Clear()
                        Comment_txt.Clear()
                        RefreshAlerts()
                    End If
                End If
            Else
                FlashAlerts.ShowError("El numero de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Smk_AlertMissing_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
    End Sub
End Class