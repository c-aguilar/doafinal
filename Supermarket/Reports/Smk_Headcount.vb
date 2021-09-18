Public Class Smk_Headcount

    Private Sub Smk_Headcount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()
        Dim data As DataTable = SQL.Current.GetDatatable("SELECT R.ID, R.Area, R.[Role] AS Puesto,'Turno ' + S.Shift AS Shift, T.[Target] AS Objetivo, C.[Count] AS [Real],ISNULL(C.[Count],0)  - ISNULL(T.[Target],0) AS [Diferencia] FROM Smk_OperatorRoles AS R CROSS JOIN Sys_Shifts AS S LEFT OUTER JOIN Smk_RoleTargets AS T ON R.ID = T.RoleID AND S.Shift = T.Shift LEFT OUTER JOIN (SELECT RoleID, Shift, COUNT(Badge) AS [Count] FROM Smk_Operators WHERE Active = 1 GROUP BY RoleID, Shift) AS C ON R.ID = C.RoleID AND S.Shift = C.Shift WHERE R.Area = 'SMK'", "Headcount")
        Report_dgv.DataSource = DatatablePivoter.Get(data, {"Puesto"}, {"Shift"}, {"Objetivo", "Real", "Diferencia"}, {AggregateFunction.Sum, AggregateFunction.Sum, AggregateFunction.Sum}, , True, True)
        For Each column As DataGridViewColumn In Report_dgv.Columns
            If column.Name = "Puesto" Then
                column.Width = 220
            Else
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                column.Width = 80
            End If
        Next
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadReport()
    End Sub

    Private Sub Report_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Report_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Report_dgv.Rows(e.RowIndex).Cells("Puesto").Value = "Σ Gran Total" Then
                e.CellStyle.BackColor = Color.Gold
                e.CellStyle.Font = New Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold)
                If e.ColumnIndex = 0 Then e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf Report_dgv.Columns(e.ColumnIndex).HeaderText.Contains("Diferencia") Then
                e.CellStyle.BackColor = Color.Black
                e.CellStyle.ForeColor = Color.White
                e.CellStyle.Font = New Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(Report_dgv.DataSource, Title_lbl.Text)
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        Report_dgv.SelectAll()
        Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = Report_dgv.GetClipboardContent()
        Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub
End Class