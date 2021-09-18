Public Class CalendarRange
    Public Property MinDate As Date = New Date(1900, 1, 1)
    Public Property MaxDate As Date = New Date(2100, 12, 31)
    Public Property [From] As Date
    Public Property [To] As Date
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        If dtpTo.Value >= dtpFrom.Value Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.From = dtpFrom.Value
            Me.To = dtpTo.Value
            Me.Close()
        Else
            MsgBox("Incorrect period.", MsgBoxStyle.Exclamation, APP)
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.MaxDate = Me.MaxDate
        dtpFrom.MinDate = Me.MinDate
        dtpTo.MaxDate = Me.MaxDate
        dtpTo.MinDate = Me.MinDate
        dtpFrom.Value = Me.[From]
        dtpTo.Value = Me.[To]
    End Sub
End Class