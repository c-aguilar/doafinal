Public Class ErrorReportViewer
    Dim data As DataTable
    Dim report As String
    Dim sb As SearchBox
    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.dgvData)

        GF.FillCombobox(cboTable, SQL.Current.GetDatatable("SELECT Name FROM Sys_ErrorReports"))
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If Not IsNothing(data) AndAlso MyExcel.Print(data, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
            'MsgBox("Done!", MsgBoxStyle.Information, APP)
        End If
    End Sub

    Private Sub CSVToolStripButton_Click(sender As Object, e As EventArgs) Handles CSVToolStripButton.Click
        If Not IsNothing(data) AndAlso CSV.SaveAs(data, True) Then
            MsgBox("Done!", MsgBoxStyle.Information, APP)
        End If
    End Sub

    Private Sub ExportToolStripButton_Click(sender As Object, e As EventArgs) Handles ExportToolStripButton.Click
        If Not IsNothing(data) AndAlso MyExcel.SaveAs(data, cboTable.SelectedItem, True, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
            MsgBox("Done!", MsgBoxStyle.Information, APP)
        End If
    End Sub

    Private Sub PDFToolStripButton_Click(sender As Object, e As EventArgs) Handles PDFToolStripButton.Click
        If Not IsNothing(data) Then
            Dim pdf As New PDF
            pdf.DataSource = data
            pdf.Title = APP
            pdf.Orientation = CAguilar.PDF.Orientations.Landscape
            pdf.PageNumber = True
            pdf.PageNumberPosition = CAguilar.PDF.Page.Position.BottomCenter
            pdf.Subtitle = report
            If pdf.SaveAs() Then
                MsgBox("Done!", MsgBoxStyle.Information, APP)
            End If
            pdf.Dispose()
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(data) Then
            dgvData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Clipboard.SetDataObject(dgvData.GetClipboardContent())
            dgvData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Status("Copiado!")
        End If
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        report = cboTable.SelectedItem
        data = SQL.Current.GetDatatable(SQL.Current.GetString("Query", "Sys_ErrorReports", "Name", cboTable.SelectedItem, ""))
        dgvData.DataSource = Nothing
        dgvData.DataSource = data
        If Not IsNothing(data) Then Status(data.Rows.Count & " records.")
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = text
    End Sub

    Private Sub ReportViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class