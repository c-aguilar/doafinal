Public Class Ord_MixMaxHistory
    Dim selected_partnumbers As New ArrayList
    Dim report As DataTable
    Private Sub Ord_MixMaxHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = SQL.Current.GetDatatable("SELECT DISTINCT [FullName],U.Username FROM Sys_Users AS U INNER JOIN Ord_MRPControllers AS M ON U.Username = M.Username ")
        users.Rows.Add("Todos", "*")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        Username_cbo.SelectedValue = "*"
        From_dtp.Value = CurrentDate.AddDays(-30)
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim partnumber_filter As String = ""
        Dim partnumber_filter_nodetails As String = ""
        Dim user_filter As String = If(Username_cbo.SelectedValue = "*", "", String.Format("AND U.Username = '{0}'", Username_cbo.SelectedValue))
        Dim date_filter As String = String.Format("WHERE (CONVERT(DATE,A.[Date]) BETWEEN '{0}' AND '{1}')", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd"))
        If selected_partnumbers.Count > 0 Then
            partnumber_filter = String.Format("AND A.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray))
        ElseIf Partnumber_txt.Text <> "*" AndAlso Partnumber_txt.Text.Trim <> "" Then
            partnumber_filter = String.Format("AND A.Partnumber = '{0}'", Partnumber_txt.Text.Trim)
        End If
        report = SQL.Current.GetDatatable(String.Format("SELECT A.[Partnumber] AS [No. de Parte],M.MRP,U.FullName AS [Dueño],[Type] AS [Tipo de Alerta],O.FullName AS [Reportado por],A.[Date] AS Fecha,[Comment] AS Comentario,AU.FullName AS [Respondido por],[AnswerDate] AS [Fecha Respuesta],[Answer] AS Respuesta,[PromiseDate] AS [Fecha Promesa] FROM Ord_RawMaterialAlerts AS A INNER JOIN Sys_RawMaterial AS R ON A.Partnumber = R.Partnumber INNER JOIN Ord_MRPControllers AS M ON R.MRP = M.MRP INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Smk_Operators AS O ON A.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS AU ON A.AnswerUsername = AU.Username {0} {1} {2};", date_filter, partnumber_filter, user_filter))
        Report_dgv.DataSource = report
        LoadingScreen.Hide()
    End Sub


    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If report IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(report.DefaultView, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(report.DefaultView.ToTable, True) Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = report.DefaultView.ToTable
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm(Language.Sentence(43))
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(Strings.right("00000000" & p.ToString, 8)) Then
                    selected_partnumbers.Add(Strings.right("00000000" & p.ToString, 8))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Text = ""
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Ord_MixMaxHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class