Public Class Ord_MixMaxAlerts
    Dim report As DataTable
    Dim sb As SearchBox
    Private Sub Ord_MixMaxAlerts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Report_dgv)

        Dim users = SQL.Current.GetDatatable("SELECT DISTINCT [FullName],U.Username FROM Sys_Users AS U INNER JOIN Ord_MRPControllers AS M ON U.Username = M.Username ")
        users.Rows.Add("Todos", "*")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        If users.Compute("COUNT(Username)", String.Format("Username = '{0}'", User.Current.Username)) > 0 Then
            Username_cbo.SelectedValue = User.Current.Username
        Else
            Username_cbo.SelectedValue = "*"
        End If
        RefreshAlerts()
    End Sub

    Private Sub RefreshAlerts()
        Dim user_filter As String = If(Username_cbo.SelectedValue = "*", "", String.Format("AND U.Username = '{0}'", Username_cbo.SelectedValue))
        report = SQL.Current.GetDatatable(String.Format("SELECT A.ID, A.[Partnumber], R.Description, M.MRP,U.FullName AS [Owner],dbo.Smk_Locations(A.Partnumber) AS [Location], [Type], O.FullName AS ReportedBy, A.[Date], [Comment],ISNULL(dbo.Ord_ForecastAvg(A.[Partnumber],A.[Date],2),0) AS Forecast,dbo.Ord_NextTransit(A.Partnumber) AS Transit, R.SupplierName, AU.Fullname AS AnswerBy, [AnswerDate], [Answer],[PromiseDate] FROM Ord_RawMaterialAlerts AS A INNER JOIN Sys_RawMaterial AS R ON A.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS AU ON A.AnswerUsername = AU.Username WHERE ((LEFT(A.[Type],3) IN ('Min','Cri') AND (A.PromiseDate IS NULL Or A.PromiseDate >= GETDATE())) OR (LEFT(A.[Type],3) = 'Max' AND A.Answer IS NULL)) {0} ORDER BY A.[Type],A.Partnumber;", user_filter))
        Report_dgv.DataSource = report
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        RefreshAlerts()
        LoadingScreen.Hide()
    End Sub


    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(report.DefaultView, Title_lbl.Text)
    End Sub

    Private Sub Ord_MixMaxAlerts_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Report_dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Report_dgv.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim answer As New Ord_AnswerMixMax
            answer.ID = Report_dgv.Rows(e.RowIndex).Cells("ID").Value
            answer.Partnumber = Report_dgv.Rows(e.RowIndex).Cells("Partnumber").Value
            answer.Type = Report_dgv.Rows(e.RowIndex).Cells("AlertType").Value
            answer.Answer = IIf(Not IsDBNull(Report_dgv.Rows(e.RowIndex).Cells("Answer").Value) AndAlso Not IsNothing(Report_dgv.Rows(e.RowIndex).Cells("Answer").Value), Report_dgv.Rows(e.RowIndex).Cells("Answer").Value.ToString, "")
            answer.PromiseDate = IIf(Not IsDBNull(Report_dgv.Rows(e.RowIndex).Cells("PromiseDate").Value), Report_dgv.Rows(e.RowIndex).Cells("PromiseDate").Value, answer.PromiseDate)
            If answer.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim dbi As DataRowView = Report_dgv.Rows(e.RowIndex).DataBoundItem
                dbi.Item("Answer") = answer.Answer
                dbi.Item("AnswerBy") = User.Current.FullName
                dbi.Item("AnswerDate") = CurrentDate()
                If Not answer.Type.ToLower.StartsWith("max") AndAlso answer.HasPromise Then
                    dbi.Item("PromiseDate") = answer.PromiseDate
                Else
                    dbi.Item("PromiseDate") = DBNull.Value
                End If
                Report_dgv.InvalidateRow(e.RowIndex)
                FlashAlerts.ShowConfirm("¡Hecho!")
            End If
            answer.Dispose()
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
        sb.BringToFront()
    End Sub
End Class