Public Class ConditionSelector
    Public Property Condition As DeltaReporter.Condition
    Private Sub Equal_btn_Click(sender As Object, e As EventArgs) Handles Equal_btn.Click
        Condition = DeltaReporter.Condition.Equal
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub NotEqual_btn_Click(sender As Object, e As EventArgs) Handles NotEqual_btn.Click
        Condition = DeltaReporter.Condition.NotEqual
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Greater_btn_Click(sender As Object, e As EventArgs) Handles Greater_btn.Click
        Condition = DeltaReporter.Condition.GreaterThan
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub GreaterEqual_btn_Click(sender As Object, e As EventArgs) Handles GreaterEqual_btn.Click
        Condition = DeltaReporter.Condition.GreaterOrEqualThan
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Minor_btn_Click(sender As Object, e As EventArgs) Handles Minor_btn.Click
        Condition = DeltaReporter.Condition.MinorThan
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub MinorEqual_btn_Click(sender As Object, e As EventArgs) Handles MinorEqual_btn.Click
        Condition = DeltaReporter.Condition.MinorOrEqualThan
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub In_btn_Click(sender As Object, e As EventArgs) Handles In_btn.Click
        Condition = DeltaReporter.Condition.In
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ConditionSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NotIn_btn_Click(sender As Object, e As EventArgs) Handles NotIn_btn.Click
        Condition = DeltaReporter.Condition.NotIn
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class