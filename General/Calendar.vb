Public Class Calendar
    Public Property MinDate As Date = New Date(1900, 1, 1)
    Public Property MaxDate As Date = New Date(2100, 12, 31)
    Public Property SelectedDate As Date = Delta.CurrentDate.Date
    Public Property MaxSelectionCount As Integer = 1
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Me.SelectedDate = mcFrom.SelectionRange.Start
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mcFrom.MaxSelectionCount = Me.MaxSelectionCount
        mcFrom.MaxDate = Me.MaxDate.Date
        mcFrom.MinDate = Me.MinDate.Date
        mcFrom.SelectionRange = New SelectionRange(Me.SelectedDate.Date, Me.SelectedDate.Date)
    End Sub
End Class