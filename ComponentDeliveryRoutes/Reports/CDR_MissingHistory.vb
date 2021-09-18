Public Class CDR_MissingHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub CDR_MissingHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_dtp.Value = CurrentDate.AddDays(-30)
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim partnumber_filter As String = ""
        Dim partnumber_filter_nodetails As String = ""
        Dim date_filter As String = String.Format("WHERE (CONVERT(DATE,M.[Date]) BETWEEN '{0}' AND '{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd"))
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND M.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND M.Partnumber = '{0}'", Partnumber_txt.Text.Trim)
        End If
        report = SQL.Current.GetDatatable(String.Format("SELECT M.Partnumber AS [No. de Parte],W.Name AS Estacion,[Date] AS Fecha,O.FullName AS [Reportado por],~M.Active AS [Surtido],O2.FullName AS [Surtido por] FROM Smk_MissingAlerts AS M INNER JOIN Smk_Warehouses AS W ON M.Warehouse = W.Warehouse INNER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Smk_Operators AS O2 ON M.AnswerBy = O2.Badge {0} {1} ORDER BY M.[Date];", date_filter, partnumber_filter))
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

    Private Sub CDR_MissingHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class