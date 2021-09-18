Public Class CDR_PrintKanban
    Private Sub CDR_PrintKanban_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CDR_PrintKanban_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Kanban_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub ReadKanban()
        If CDR.IsKanban(Kanban_txt.Text) Then
            SQL.Current.Execute(String.Format("UPDATE CDR_Kanbans SET Rack = LEFT(M.Location,2),[Local] = M.Location FROM Delta.dbo.Smk_Map AS M WHERE CDR_Kanbans.Partnumber = M.Partnumber AND Warehouse = '{0}' AND M.Location <> '00000000' AND CDR_Kanbans.ID = {1};", My.Settings.Warehouse, CDR.KanbanID(Kanban_txt.Text)))
            CDR.Print(CDR.KanbanID(Kanban_txt.Text))
            Kanban_txt.Clear()
            Kanban_txt.Focus()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "CLOSE" Then
            Kanban_txt.Clear()
            Me.Close()
        Else
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            FlashAlerts.ShowError("Kanban incorrecta.")
        End If
    End Sub

    Private Sub CDR_PrintKanban_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class