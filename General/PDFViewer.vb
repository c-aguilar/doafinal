Public Class PDFViewer
    Public Property Filename As String
    Private Sub PDFViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wbMain.Navigate(Filename)
    End Sub

    Private Sub PDFViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        wbMain.Navigate("about:blank")
        While wbMain.IsBusy
            Application.DoEvents()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End While
        wbMain.Dispose()
    End Sub
End Class