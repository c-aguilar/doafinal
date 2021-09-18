Public Class EnterBox
    Public Property Question As String
    Public Property Answer As String
    Public Property Title As String
    Public Property AcceptByEnter As Boolean = False
    Private Sub EnterBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If AcceptByEnter Then
            Me.AcceptButton = OK_btn
        End If
        Question_lbl.Text = Me.Question
        Answer_txt.Text = Me.Answer
        Me.Text = Me.Title
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        Me.Answer = Answer_txt.Text.Trim
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class