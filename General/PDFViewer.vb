Public Class PDFViewer
    Public Property Filename As String
    Public Property DeleteAfterClosing As Boolean = False
    Public Property DisposeAfterClosing As Boolean = False
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


    Private Sub PDFViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DeleteAfterClosing Then
            TryDelete(Filename)
        End If
        If DisposeAfterClosing Then
            Me.Dispose()
        End If
    End Sub
End Class