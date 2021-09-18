Public Class Smk_APITicketSelector

    Private Sub Smk_APITicketSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Ticket_cbo, SQL.Current.GetDatatable("SELECT Ticket FROM Smk_APITickets WHERE Status = '0' ORDER BY Ticket"), "Ticket", "Ticket")
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.Close()
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If Ticket_cbo.SelectedIndex > -1 Then
            Dim api As New Smk_CableAPI
            api.Ticket = Ticket_cbo.SelectedValue
            api.ShowDialog()
            api.Dispose()

            GF.FillCombobox(Ticket_cbo, SQL.Current.GetDatatable("SELECT Ticket FROM Smk_APITickets WHERE Status = '0' ORDER BY Ticket"), "Ticket", "Ticket")
        End If
    End Sub

End Class