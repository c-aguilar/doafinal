Public Class Ord_CriticalHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub Ord_CriticalHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = SQL.Current.GetDatatable("SELECT [FullName],U.Username FROM Sys_Users AS U INNER JOIN (SELECT DISTINCT Username FROM Rec_CriticalPartnumbers) AS M ON U.Username = M.Username ")
        users.Rows.Add("Todos", "*")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        Username_cbo.SelectedValue = "*"
        From_dtp.Value = CurrentDate.AddDays(-30)
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim partnumber_filter As String = ""
        Dim partnumber_filter_nodetails As String = ""
        Dim user_filter As String = If(Username_cbo.SelectedValue = "*", "", String.Format("AND C.Username = '{0}'", Username_cbo.SelectedValue))
        Dim date_filter As String = String.Format("WHERE (CONVERT(DATE,C.[Date]) BETWEEN '{0}' AND '{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd"))
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND P.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND C.Partnumber = '{0}'", Partnumber_txt.Text.Trim)
        End If
        report = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],[Date] AS Fecha,U.FullName AS [Reportado por],C.Active AS Activo,C.Area,Comment AS Comentario,LU.FullName AS [Etiquetado por],LabelingDate AS [Fecha Etiquetado] FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username LEFT OUTER JOIN Sys_Users AS LU ON C.LabelingUsername = LU.Username {0} {1} {2};", date_filter, partnumber_filter, user_filter))
        Report_dgv.DataSource = report
        LoadingScreen.Hide()
    End Sub


    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(Report_dgv.DataSource, Title_lbl.Text)
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

    Private Sub Ord_CriticalHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class