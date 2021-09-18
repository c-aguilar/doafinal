Public Class SingleReportViewer
    Dim sb As SearchBox
    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.dgvData)

        dgvData.DataSource = Me.DataSource
        Title_lbl.Text = Me.Title
    End Sub

    Public Property DataSource As DataTable
    Public Property Title As String

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If Not IsNothing(Me.DataSource) AndAlso MyExcel.Print(Me.DataSource.DefaultView.ToTable, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
            FlashAlerts.ShowConfirm("¡Hecho!")
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(Me.DataSource) Then
            dgvData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Clipboard.SetDataObject(dgvData.GetClipboardContent())
            dgvData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Status("Copiado")
        End If
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = text
    End Sub

    Private Sub ReportViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Delta.Export(Me.DataSource, Me.DataSource.TableName.Replace("*", "").Replace("?", "").Replace(":", "").Replace("\", "").Replace("/", ""))
    End Sub

    Private Sub Pivot_btn_Click(sender As Object, e As EventArgs) Handles Pivot_btn.Click
        If Me.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            Dim pivoter As New DeltaPivoter
            pivoter.Title = Me.Title
            pivoter.MdiParent = Me.MdiParent
            pivoter.DataSource = Me.DataSource.DefaultView.ToTable
            pivoter.Show()
            LoadingScreen.Hide()
        End If
    End Sub
End Class