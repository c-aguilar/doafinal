Public Class SingleReportViewer
    Dim sb As SearchBox
    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox(Me.dgvData)
        dgvData.DataSource = Me.DataSource
        lblTitle.Text = Me.Title
    End Sub

    Public Property DataSource As DataTable
    Public Property Title As String

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If Not IsNothing(Me.DataSource) AndAlso MyExcel.Print(Me.DataSource.DefaultView.ToTable, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
            FlashAlerts.ShowConfirm("Hecho!")
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(Me.DataSource) Then
            Clipboard.SetDataObject(dgvData.GetClipboardContent())
            Status("Copiado")
        End If
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = text
    End Sub

    Private Sub ReportViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim ed As New ExportDialog
        If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case ed.ChoosenFormat
                Case ExportDialog.Format.Excel
                    If MyExcel.SaveAs(Me.DataSource.DefaultView.ToTable, Me.DataSource.TableName.Replace("*", "").Replace("?", "").Replace(":", "").Replace("\", "").Replace("/", ""), True) Then
                        FlashAlerts.ShowConfirm(Language.Sentence(43))
                    End If
                Case ExportDialog.Format.CSV
                    If CSV.SaveAs(Me.DataSource.DefaultView.ToTable, True) Then
                        FlashAlerts.ShowConfirm(Language.Sentence(43))
                    End If
                Case ExportDialog.Format.PDF
                    Dim pdf As New PDF
                    pdf.DataSource = Me.DataSource.DefaultView.ToTable
                    pdf.Title = Me.Title
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
    End Sub
End Class