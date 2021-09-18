Public Class Calendar
    Public Property MinDate As Date = New Date(1900, 1, 1)
    Public Property MaxDate As Date = New Date(2100, 12, 31)
    Public Property SelectedDate As Date = Now
    Public Property MaxSelectionCount As Integer = 1
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.SelectedDate = mcFrom.SelectionRange.Start
        Me.Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mcFrom.MaxSelectionCount = Me.MaxSelectionCount
        mcFrom.MaxDate = Me.MaxDate
        mcFrom.MinDate = Me.MinDate
        mcFrom.SelectionRange = New SelectionRange(Me.SelectedDate, Me.SelectedDate)
    End Sub
End Class