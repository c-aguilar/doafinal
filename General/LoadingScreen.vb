Public Class LoadingScreen
    Private Delegate Sub CloseDelegate()
    Private Shared ls As LoadingScreen
    Public Overloads Shared Sub Show()
        If ls Is Nothing OrElse ls.IsDisposed Then
            Dim th As New Threading.Thread(New Threading.ThreadStart(AddressOf LoadingScreen.ShowSplash))
            th.IsBackground = True
            th.SetApartmentState(Threading.ApartmentState.STA)
            th.Start()
        End If
    End Sub
    Private Shared Sub ShowSplash()
        ls = New LoadingScreen
        ls.Size = New Size(MainForm.Size.Width, MainForm.Size.Height)
        ls.ShowDialog()
    End Sub
    Public Overloads Shared Sub Hide()
        While ls Is Nothing OrElse Not ls.IsHandleCreated

        End While
        ls.Invoke(New CloseDelegate(AddressOf LoadingScreen.CloseInternal))
    End Sub
    Private Shared Sub CloseInternal()
        ls.Close()
        ls.Dispose()
        ls = Nothing
    End Sub

    Private Sub LoadingScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = String.Format("DELTA ERP{0}Version {1}{0}C.A.", vbCrLf, My.Application.Info.Version.ToString)
        Me.Location = New Point(MainForm.Bounds.X, MainForm.Bounds.Y)
    End Sub
End Class
