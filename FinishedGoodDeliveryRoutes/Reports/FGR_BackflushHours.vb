Public Class FGR_BackflushHours

    Private Sub FGR_BackflushHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_dtp.Value = LastMonday(Delta.CurrentDate).Date
        To_dtp.Value = NextSunday(Delta.CurrentDate).Date
    End Sub

    Private Sub LoadReport()
        LoadingScreen.Show()
        Report_dgv.DataSource = Nothing
        Dim data As DataTable = SQL.Current.GetDatatable(String.Format("SELECT B.Family AS Customer,M.Business AS [Value Stream],S.Serialnumber AS [Serie],S.Material,S.Quantity,(S.Quantity * ISNULL(P.Points,0)) / 100 AS [Hours],S.[PostedDate] FROM FGR_SerialMovements AS S INNER JOIN Sch_Materials AS M ON S.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ShippingPoints AS P ON S.Material = P.Material AND P.[Month] = DATEPART(MONTH,S.[PostedDate]) AND P.[Year] = DATEPART(YEAR,S.[PostedDate]) WHERE S.Movement = 'BKF' AND CONVERT(DATE, S.[PostedDate]) BETWEEN '{0}' AND '{1}' ORDER BY B.Family, M.Business, S.[PostedDate];", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")), "Serials")

        Dim pivot = DatatablePivoter.Get(data, {"Customer", "Value Stream"}, {"PostedDate"}, {"Hours"}, {AggregateFunction.Sum}, , True, True)
        For i = 2 To pivot.Columns.Count - 1
            pivot.Columns(i).ColumnName = pivot.Columns(i).ColumnName.Replace(" Suma de Hours", "").Replace("Σ Gran Total Hours", "Σ Gran Total")
        Next
        Report_dgv.DataSource = pivot
        For i = 2 To pivot.Columns.Count - 1
            Report_dgv.Columns(i).DefaultCellStyle.Format = "N2"
            Report_dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        LoadingScreen.Hide()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadReport()
    End Sub

    Private Sub Report_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Report_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Report_dgv.Rows(e.RowIndex).Cells("Customer").Value = "Σ Gran Total" Then
                e.CellStyle.Font = New Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold)
                If e.ColumnIndex = 0 Then e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf Report_dgv.Columns(e.ColumnIndex).HeaderText.Contains("Σ Gran Total") Then
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