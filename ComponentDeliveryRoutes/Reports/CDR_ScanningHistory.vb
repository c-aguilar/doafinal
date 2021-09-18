Public Class CDR_ScanningHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub CDR_ScanningHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_dtp.Value = CurrentDate.AddDays(-30)
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim partnumber_filter As String = ""
        Dim partnumber_filter_nodetails As String = ""
        Dim date_filter As String = String.Format("WHERE (CONVERT(DATE,L.InDate) BETWEEN '{0}' AND '{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd"))
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND K.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND K.Partnumber = '{0}'", Partnumber_txt.Text.Trim)
        End If
        report = SQL.Current.GetDatatable(String.Format("SELECT R.[Description] AS [Ruta],R.Shift AS Turno, L.ID AS [ID Vuelta],L.InDate AS Fecha,S.Kanban AS Kanban,K.Partnumber,O.FullName AS [Escaneado por],L.Badge AS Gafete FROM CDR_Routes AS R INNER JOIN CDR_RoutesLoopRegister AS L ON R.Route = L.Route INNER JOIN CDR_RoutesLoopKanbans AS S ON S.LoopID = L.ID INNER JOIN Smk_Operators AS O ON L.Badge = O.Badge LEFT OUTER JOIN CDR_Kanbans AS K ON S.Kanban = K.ID {0} {1} ORDER BY L.[InDate],S.ID;", date_filter, partnumber_filter))
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

    Private Sub CDR_ScanningHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class