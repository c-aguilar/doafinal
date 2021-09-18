Public Class MB51_261VsZ11_Details

    Private Sub MB51_261VsZ11_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvReport.DataSource = Me.DataSource
        lblTitle.Text = "Daily Movements: " & Me.Partnumber
    End Sub

    Public Property DataSource As DataTable
    Public Property Partnumber As String

    Private Sub MB51_261VsZ11_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class