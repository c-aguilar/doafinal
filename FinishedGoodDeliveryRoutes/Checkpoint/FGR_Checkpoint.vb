Public Class FGR_Checkpoint

    Private Sub FGR_Checkpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Option_txt_TextChanged(sender As Object, e As EventArgs) Handles Option_txt.TextChanged
        Dim option_scan As String = Option_txt.Text.ToUpper.Trim
        Select option_scan
            Case "IN"
                Dim fadeback As New FadeBackground(FGR_SerialScan)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
        End Select
    End Sub
End Class