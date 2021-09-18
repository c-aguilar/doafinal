Public Class Sch_AutoScheduleOptions

    Private Sub AutoScheduleOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mcDates.MinDate = Me.MinDate
        mcDates.MaxDate = Me.MaxDate
        AverageWeeksNumericUpDown.Maximum = Math.Ceiling(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate) / 7)
        If AverageWeeksNumericUpDown.Maximum > 1 Then
            AverageWeeksNumericUpDown.Value = 2
        End If
        mcDates.SelectionRange = New SelectionRange(Me.MinDate, Me.MaxDate)

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Me.ReplaceExisitng = chkReplace.Checked
        Me.AverageRequirements = chkAvg.Checked
        Me.RoundByStandarPack = chkRound.Checked
        Me.AverageWeeks = AverageWeeksNumericUpDown.Value
        Me.AllowPositive = chkAllowPositive.Checked
        mcDates.SelectionRange = New SelectionRange(mcDates.SelectionRange.Start, NextSaturday(mcDates.SelectionRange.End))
        Application.DoEvents()
        Me.From = mcDates.SelectionRange.Start
        Me.To = mcDates.SelectionRange.End
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Property ReplaceExisitng As Boolean
    Public Property AverageRequirements As Boolean
    Public Property AverageWeeks As Integer
    Public Property RoundByStandarPack
    Public Property AllowPositive As Boolean
    Public Property From As Date
    Public Property [To] As Date
    Public Property MinDate As Date
    Public Property MaxDate As Date

    Private Sub mcDates_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcDates.DateChanged

    End Sub

    Private Sub chkAvg_CheckedChanged(sender As Object, e As EventArgs) Handles chkAvg.CheckedChanged
        AverageWeeksNumericUpDown.Enabled = chkAvg.Checked
    End Sub

    Private Sub AutoScheduleOptions_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mcDates.Focus()
    End Sub
End Class