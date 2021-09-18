Public Class CDR_KanbanScan
    Public Property Route As CDR.Route
    Dim thread_A As Threading.Thread
    Private Sub CDR_KanbanScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CleanKanbanInfo()
        UpdateCounter()
        OperatorName_lbl.Text = Route.OperatorName
        Route_lbl.Text = Route.Name
        Picture_pb.Image = Delta.GetUserPhoto(Route.Badge)
        Kanbans_dgv.DataSource = Route.ScannedKanbans
    End Sub

    Private Sub CDR_KanbanScan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
    End Sub

    Private Sub CleanKanbanInfo()
        Partnumber_lbl.Text = ""
        Description_lbl.Text = ""
        Quantity_lbl.Text = ""
        Uom_lbl.Text = ""
        Container_lbl.Text = ""
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadKanban)
            thread_A.Start()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Kanban_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadKanban)
            thread_A.Start()
        End If
    End Sub

    Delegate Sub ReadIt()

    Private Sub ReadKanban()
        If Kanban_txt.InvokeRequired Then
            Dim dgt As New ReadIt(AddressOf ReadKanban)
            Invoke(dgt)
        ElseIf CDR.IsKanban(Kanban_txt.Text) Then
            Dim kanban_id As Integer = CDR.KanbanID(Kanban_txt.Text)
            Kanban_txt.Clear()
            If Route.Status = CDR.Status.OUT Then 'SI LA RUTA SE ENCUENTRA FUERA; REGISTRAR LA VUELTA A LA PRIMERA KANBAN ESCANEADA 
                Route.GoIn()
            End If
            If Not Route.ScannedKanbans.Exists(Function(w) w.KanbanID = kanban_id) Then
                Dim kanban As Hashtable = SQL.Current.GetRecord({"Partnumber", "Pieces", "Container"}, "CDR_Kanbans", "ID", kanban_id)
                If kanban.Count > 0 Then
                    If Route.RegisterScannedKanban(kanban_id, True) Then
                        Dim part As New RawMaterial(kanban("partnumber"))
                        Partnumber_lbl.Text = part.Partnumber
                        Description_lbl.Text = part.Description
                        Quantity_lbl.Text = kanban("pieces")
                        Uom_lbl.Text = part.UoM.ToString
                        Container_lbl.Text = kanban("container")
                    Else
                        Partnumber_lbl.Text = "Error"
                        Description_lbl.Text = "Error"
                        Quantity_lbl.Text = "Error"
                        Uom_lbl.Text = "Error"
                        Container_lbl.Text = "Error"
                    End If

                Else
                    If Route.RegisterScannedKanban(kanban_id, False) Then
                        CleanKanbanInfo()
                        Partnumber_lbl.Text = "Desconocido"
                    Else
                        Partnumber_lbl.Text = "Error"
                        Description_lbl.Text = "Error"
                        Quantity_lbl.Text = "Error"
                        Uom_lbl.Text = "Error"
                        Container_lbl.Text = "Error"
                    End If
                End If
                kanban = Nothing
                UpdateCounter()
            Else
                FlashAlerts.ShowInformation("Kanban duplicada.", 1, True)
                CleanKanbanInfo()
            End If
            Kanban_txt.Focus()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "CLOSE" Then
            Kanban_txt.Clear()
            Me.Close()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "PRINT" Then
            Kanban_txt.Clear()
            Dim fb As New FadeBackground(CDR_PrintKanban)
            fb.ShowDialog()
            Kanban_txt.Focus()
        Else
            FlashAlerts.ShowError("Kanban incorrecta.", 1, True)
            CleanKanbanInfo()
            Kanban_txt.Clear()
            Kanban_txt.Focus()
        End If
    End Sub

    Private Sub UpdateCounter()
        Count_lbl.Text = Route.ScannedKanbans.Count
        Unknow_lbl.Text = Route.ScannedKanbans.Where(Function(w) w.Result = False).Count()
        Percent_lbl.Text = FormatPercent(Route.ScannedKanbans.Count / Route.ContainersDailyGoal, 1)
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        Dim fb As New FadeBackground(CDR_PrintKanban)
        fb.ShowDialog()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub CDR_KanbanScan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Kanbans_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Kanbans_dgv.Columns("icon_img").Index Then
            If Kanbans_dgv.Rows(e.RowIndex).Cells("result").Value Then
                e.Value = My.Resources.tick_32
            Else
                e.Value = My.Resources.tick_light_blue_32
            End If
        End If
    End Sub

    Private Sub Kanbans_dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        Kanbans_dgv.FirstDisplayedScrollingRowIndex = e.RowIndex
    End Sub
End Class