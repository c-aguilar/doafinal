Public Class FadeBackground
    Private Property FrontForm As Object
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(front_form As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FrontForm = front_form

    End Sub

    Private Sub OpenForm(new_form As Object)
        Dim form As Form = Activator.CreateInstance(new_form.GetType)
        form.Opacity = 100
        'form.TopMost = True
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog()
        If Not form.IsDisposed Then
            form.Dispose()
        End If
        Me.Close()
    End Sub

    Private Sub FadeBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FrontForm IsNot Nothing Then OpenForm(FrontForm)
    End Sub

    Private Sub FadeBackground_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class