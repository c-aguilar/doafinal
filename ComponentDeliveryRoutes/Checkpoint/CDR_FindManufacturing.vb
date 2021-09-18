Public Class CDR_FindManufacturing

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text <> "" Then
            Find()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Kanban_txt.Text <> "" Then
            Find()
        End If
    End Sub

    Private Sub Find()
        Dim partnumber As String
        If Kanban_txt.Text = "CLOSE" Then
            Me.Close()
        ElseIf CDR.IsKanban(Kanban_txt.Text) Then
            partnumber = SQL.Current.GetString("Partnumber", "CDR_Kanbans", "ID", CDR.KanbanID(Kanban_txt.Text), "")
            If partnumber = "" Then
                FlashAlerts.ShowError("Kanban desconocida. Escribe el numero de parte.")
                Kanbans_dgv.DataSource = Nothing
                Local_lbl.Text = ""
            Else
                Kanbans_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte], Business AS Negocio, Board AS Tablero, Kit, EngLoc AS Localizacion, Slot, Side AS Lado, Section AS Seccion FROM CDR_Kanbans WHERE Partnumber = '{0}' GROUP BY Partnumber, Business, Board, Kit, EngLoc, Slot, Side, Section ORDER BY Business,Board", partnumber))
                Local_lbl.Text = SQL.Current.GetString(String.Format("SELECT dbo.Smk_Locations('{0}');", partnumber))
            End If
        Else
            partnumber = RawMaterial.Format(Kanban_txt.Text)
            Kanbans_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte], Business AS Negocio, Board AS Tablero, Kit, EngLoc AS Localizacion, Slot, Side AS Lado, Section AS Seccion FROM CDR_Kanbans WHERE Partnumber = '{0}' GROUP BY Partnumber, Business, Board, Kit, EngLoc, Slot, Side, Section ORDER BY Business,Board", partnumber))
            Local_lbl.Text = SQL.Current.GetString(String.Format("SELECT dbo.Smk_Locations('{0}');", partnumber))
        End If
        Kanban_txt.Clear()
        Kanban_txt.Focus()
    End Sub

    Private Sub CDR_CheckpointTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Local_lbl.Text = ""
    End Sub

    Private Sub CDR_FindManufacturing_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub CDR_FindManufacturing_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class