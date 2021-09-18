Public Class Ord_MoverHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub Ord_MoverHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = SQL.Current.GetDatatable("SELECT [FullName],U.Username FROM Sys_Users AS U INNER JOIN (SELECT DISTINCT Username FROM Ord_Movers) AS M ON U.Username = M.Username ")
        users.Rows.Add("Todos", "*")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        Username_cbo.SelectedValue = "*"
        From_dtp.Value = CurrentDate.AddDays(-30)
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim partnumber_filter As String = ""
        Dim partnumber_filter_nodetails As String = ""
        Dim user_filter As String = If(Username_cbo.SelectedValue = "*", "", String.Format("AND M.Username = '{0}'", Username_cbo.SelectedValue))
        Dim date_filter As String = String.Format("WHERE (CONVERT(DATE,M.[Date]) BETWEEN '{0}' AND '{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd"))
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND P.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
            partnumber_filter_nodetails = String.Format("WHERE Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND P.Partnumber = '{0}'", Partnumber_txt.Text.Trim)
            partnumber_filter_nodetails = String.Format("WHERE Partnumber = '{0}'", Partnumber_txt.Text.Trim)
        End If
        If Details_chk.Checked Then
            report = SQL.Current.GetDatatable(String.Format("SELECT M.ID,U.FullName AS [Creado por],MT.[Description] AS Tipo,M.[Date] AS Fecha,Requisitor,Reason AS Motivo,Customer AS Cliente,Locality AS Localidad,M.Comment AS Comentario,SD.[Description] AS Estatus,AP.Fullname AS [Aprobado por],PU.Fullname AS [Surtido por],PickedUpDate AS [Fecha de Surtido],P.Partnumber AS [No. de Parte],P.Quantity,P.UoM AS Unidad,TSA FROM Ord_Movers AS M INNER JOIN Ord_MoverTypes AS MT ON M.Type = MT.Type INNER JOIN Sys_TableStatusDescriptions AS SD ON M.[Status] = SD.[Status] AND SD.[Table] = 'Ord_Movers' INNER JOIN Ord_MoverPartnumbers AS P ON M.ID = P.MoverID INNER JOIN Sys_Users AS U ON M.Username = U.Username LEFT OUTER JOIN Sys_Users AS AP ON M.ApprovalUsername = AP.Username LEFT OUTER JOIN Sys_Users AS PU ON M.PickedUpUsername = PU.Username {0} {1} {2} ORDER BY M.ID,P.ID", date_filter, partnumber_filter, user_filter))
        Else
            report = SQL.Current.GetDatatable(String.Format("SELECT M.ID,U.FullName AS [Creado por],MT.[Description] AS Tipo,M.[Date] AS Fecha,Requisitor,Reason AS Motivo,Customer AS Cliente,Locality AS Localidad,M.Comment AS Comentario,SD.[Description] AS Estatus,AP.Fullname AS [Aprobado por],PU.Fullname AS [Surtido por],PickedUpDate AS [Fecha de Surtido],PC.[Count] AS [Nos. de Parte] FROM Ord_Movers AS M INNER JOIN Ord_MoverTypes AS MT ON M.Type = MT.Type INNER JOIN Sys_TableStatusDescriptions AS SD ON M.[Status] = SD.[Status] AND SD.[Table] = 'Ord_Movers' INNER JOIN (SELECT MoverID,COUNT(ID) AS [Count] FROM Ord_MoverPartnumbers GROUP BY MoverID) AS PC ON M.ID = PC.MoverID INNER JOIN (SELECT DISTINCT MoverID FROM Ord_MoverPartnumbers {1}) AS PM ON M.ID = PM.MoverID INNER JOIN Sys_Users AS U ON M.Username = U.Username LEFT OUTER JOIN Sys_Users AS AP ON M.ApprovalUsername = AP.Username LEFT OUTER JOIN Sys_Users AS PU ON M.PickedUpUsername = PU.Username {0} {2} ORDER BY M.ID", date_filter, partnumber_filter_nodetails, user_filter))
        End If
        Report_dgv.DataSource = report
        LoadingScreen.Hide()
    End Sub


    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(report.DefaultView, Title_lbl.Text)
    End Sub

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(RawMaterial.Format(p)) Then
                    selected_partnumbers.Add(RawMaterial.Format(p))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Ord_MoverHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class