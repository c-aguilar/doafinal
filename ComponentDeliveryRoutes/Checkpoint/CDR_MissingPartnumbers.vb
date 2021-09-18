Public Class CDR_MissingPartnumbers
    Dim Route As CDR.Route
    Dim dt_kanbans As DataTable

    Private Sub CDR_EmptyContainers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_kanbans = New DataTable
        dt_kanbans.Columns.Add("ID")
        dt_kanbans.Columns.Add("Result")
        dt_kanbans.Columns.Add("Kanban", GetType(String), "'S' + SUBSTRING('0000000000' + CONVERT(ID,'System.String'),LEN(CONVERT(ID,'System.String')) + 1,10)")
        dt_kanbans.PrimaryKey = {dt_kanbans.Columns("ID")}
        Kanbans_dgv.DataSource = dt_kanbans
    End Sub

    Private Sub CDR_MissingPartnumbers_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Route_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text.Trim <> "" AndAlso Route IsNot Nothing Then
            ReadKanban()
        End If
    End Sub

    Private Sub Kanban_txtKeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If Kanban_txt.Text.Trim <> "" AndAlso e.KeyCode = Keys.Enter AndAlso Route IsNot Nothing Then
            ReadKanban()
        End If
    End Sub

    Private Sub ReadKanban()
        If Kanban_txt.Text = "CLOSE" Then
            Me.Close()
        ElseIf CDR.IsKanban(Kanban_txt.Text) Then
            If dt_kanbans.Rows.Find(CDR.KanbanID(Kanban_txt.Text)) Is Nothing Then
                Dim partnumber = SQL.Current.GetString("Partnumber", "CDR_Kanbans", "ID", CDR.KanbanID(Kanban_txt.Text), "")
                If partnumber <> "" Then
                    dt_kanbans.Rows.Add(CDR.KanbanID(Kanban_txt.Text), "OK")
                    If Not SQL.Current.Exists("Smk_MissingAlerts", {"Partnumber", "Badge", "Active"}, {partnumber, Route.Badge, 1}) Then
                        SQL.Current.Insert("Smk_MissingAlerts", {"Partnumber", "Warehouse", "Badge"}, {partnumber, Route.Warehouse, Route.Badge})
                    End If
                Else
                    dt_kanbans.Rows.Add(CDR.KanbanID(Kanban_txt.Text), "UNKNOW")
                End If
                Kanban_txt.Clear()
                Kanban_txt.Focus()
            Else
                Kanban_txt.Clear()
                Kanban_txt.Focus()
                FlashAlerts.ShowInformation("Numero ya reportado.")
            End If
            Count_lbl.Text = dt_kanbans.Rows.Count
        Else
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            FlashAlerts.ShowError("Kanban incorrecta.")
        End If
    End Sub

    Private Sub Route_txt_Validated(sender As Object, e As EventArgs) Handles Route_txt.Validated
        If Route_txt.Text <> "" Then
            ValidateRoute()
        End If
    End Sub

    Private Sub Route_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Route_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Route_txt.Text.Trim <> "" Then
            ValidateRoute()
        End If
    End Sub

    Private Sub ValidateRoute()
        If Route_txt.Text.ToUpper.Trim = "CLOSE" Then
            Me.Close()
        ElseIf CDR.Routes.Exists(Function(f) f.Name.ToLower = Route_txt.Text.Trim.ToLower) Then
            Route = CDR.Routes.Find(Function(f) f.Name.ToLower = Route_txt.Text.Trim.ToLower)
            Route_txt.Enabled = False
            Kanban_txt.Focus()
        Else
            Route_txt.Clear()
            Route_txt.Focus()
            FlashAlerts.ShowError("No existe la ruta.")
        End If
    End Sub

    Private Sub Kanbans_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Kanbans_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso Kanbans_dgv.Columns("icon_img").Index = e.ColumnIndex Then
            Select Case Kanbans_dgv.Rows(e.RowIndex).Cells("Result").Value
                Case "OK"
                    e.Value = My.Resources.tick_32
                Case "UNKNOW"
                    e.Value = My.Resources.tick_light_blue_32
            End Select
        End If
    End Sub

    Private Sub Kanbans_dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Kanbans_dgv.RowsAdded
        Kanbans_dgv.FirstDisplayedScrollingRowIndex = e.RowIndex
    End Sub
End Class