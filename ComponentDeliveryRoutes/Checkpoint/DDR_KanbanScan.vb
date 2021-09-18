Public Class DDR_KanbanScan
    Dim scan_result As Boolean = False
    Public Property Badge As String
    Public Property Cart As CDR.Cart
    Dim thread_A As Threading.Thread
    Private Sub CDR_KanbanScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CleanKanbanInfo()
        UpdateCounter()
        Cart_lbl.Text = Cart.Description
        Kanbans_dgv.DataSource = Cart.ScannedKanbansTable
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
            scan_result = True
            If Cart.Status = CDR.Status.WaitingIn Then
                Cart.GoIn(Me.Badge)
            End If
            Dim kanban_id As Integer = CDR.KanbanID(Kanban_txt.Text)
            Kanban_txt.Clear()
            If Not Cart.ScannedKanbans.Exists(Function(w) w.KanbanID = kanban_id) Then
                Dim kanban As Hashtable = SQL.Current.GetRecord({"Partnumber", "Pieces", "Container"}, "CDR_Kanbans", "ID", kanban_id)
                If kanban.Count > 0 Then
                    If RawMaterial.IsSensitive(kanban("partnumber")) Then
                        FlashAlerts.ShowInformation("Material Sensitivo", 1, True)
                        CleanKanbanInfo()
                    Else
                        If Cart.RegisterScannedKanban(kanban_id, True) Then
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
                    End If
                Else
                    If Cart.RegisterScannedKanban(kanban_id, False) Then
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
            If scan_result Then
                SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET InEndDate = GETDATE() WHERE ID = {0};", Cart.CurrentLoopID)) 'TERMINAR EL SCANEO
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
            Me.Close()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "PRINT" Then
            Kanban_txt.Clear()
            Dim fb As New FadeBackground(CDR_PrintKanban)
            fb.ShowDialog()
            Kanban_txt.Focus()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "CRITICAL" Then
            Dim background As New FadeBackground()
            background.Show()
            Dim critical As New DDR_DiscountCritical
            critical.Badge = Me.Badge
            critical.ShowDialog()
            critical.Dispose()
            background.Close()
            background.Dispose()
            Kanban_txt.Focus()
        Else
            FlashAlerts.ShowError("Kanban incorrecta.", 1, True)
            CleanKanbanInfo()
            Kanban_txt.Clear()
            Kanban_txt.Focus()
        End If
    End Sub

    Private Sub UpdateCounter()
        Count_lbl.Text = Cart.ScannedKanbans.Count
        Unknow_lbl.Text = Cart.ScannedKanbans.Where(Function(w) w.Result = False).Count()
        'Percent_lbl.Text = FormatPercent(Cart.ScannedKanbans.Count / Cart.ContainersDailyGoal, 1)
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        Dim fb As New FadeBackground(CDR_PrintKanban)
        fb.ShowDialog()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        If scan_result Then
            SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET InEndDate = GETDATE() WHERE ID = {0};", Cart.CurrentLoopID)) 'TERMINAR EL SCANEO
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub CDR_KanbanScan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub Kanbans_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Kanbans_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Kanbans_dgv.Columns("icon_img").Index Then
            If Kanbans_dgv.Rows(e.RowIndex).Cells("result").Value Then
                e.Value = My.Resources.tick_32
            Else
                e.Value = My.Resources.tick_light_blue_32
            End If
        End If
    End Sub

    Private Sub Kanbans_dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Kanbans_dgv.RowsAdded
        Kanbans_dgv.FirstDisplayedScrollingRowIndex = e.RowIndex
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub
End Class