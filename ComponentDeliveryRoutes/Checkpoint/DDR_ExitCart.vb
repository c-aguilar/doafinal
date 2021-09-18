Public Class DDR_ExitCart
    Public Property Badge As String
    Public Property Cart As CDR.Cart
    Public Property VerifiedKanbans As New List(Of CDR.ScannedKanban)
    Dim thread_A As Threading.Thread
    Private Sub CDR_KanbanScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each k In Cart.ScannedKanbans
            VerifiedKanbans.Add(New CDR.ScannedKanban(k.KanbanID, k.Partnumber, False))
        Next
        Progress_pb.Maximum = VerifiedKanbans.Count
        Progress_pb.Value = 0
        Kanbans_dgv.DataSource = VerifiedKanbans
        Cart.StartOut(Me.Badge)
        UpdateCounter()
    End Sub

    Private Sub CDR_KanbanScan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
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
        ElseIf Kanban_txt.Text.ToUpper = "CRITICAL" Then
            Dim background As New FadeBackground()
            background.Show()
            Dim critical As New DDR_DiscountCritical
            critical.Badge = Me.Badge
            critical.ShowDialog()
            critical.Dispose()
            background.Close()
            background.Dispose()
            Kanban_txt.Focus()
        ElseIf Kanban_txt.Text.ToUpper = "CANCEL" Then
            If CBool(Parameter("DDR_AllowIncompletedOut", "False")) Then
                Cart.EndOut()
                Me.Close()
            Else
                Dim newAdmin As New Sys_Authentication
                If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If newAdmin.User.HasPermission("DDR_User_AllowIncompletedOut_flag") Then
                        Cart.EndOut()
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
                    End If
                Else
                    FlashAlerts.ShowError("Acción cancelada.")
                End If
            End If
        ElseIf CDR.IsKanban(Kanban_txt.Text) Then
            Dim kanban_id As Integer = CDR.KanbanID(Kanban_txt.Text)
            Kanban_txt.Clear()
            If VerifiedKanbans.Exists(Function(w) w.KanbanID = kanban_id) Then
                VerifiedKanbans.FindLast(Function(w) w.KanbanID = kanban_id).Result = True
                UpdateCounter()
                If Not VerifiedKanbans.Exists(Function(w) w.Result = False) Then 'SE HAN ESCANEADO TODAS LAS KANBANS QUE ENTRARON
                    Cart.EndOut()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                FlashAlerts.ShowError("Kanban no encontrada en el carrito.", 1, True)
            End If
            Kanban_txt.Focus()
        Else
            FlashAlerts.ShowError("Kanban incorrecta.", 1, True)
            Kanban_txt.Clear()
            Kanban_txt.Focus()
        End If
    End Sub

    Private Sub UpdateCounter()
        CountIn_lbl.Text = String.Format("{0}/{1}", VerifiedKanbans.Where(Function(w) w.Result = True).Count, VerifiedKanbans.Count)
        Progress_pb.Value = VerifiedKanbans.Where(Function(w) w.Result = True).Count
        Kanbans_dgv.Refresh()
    End Sub

    Private Sub CDR_KanbanScan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Kanbans_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Kanbans_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Kanbans_dgv.Columns("icon_img").Index Then
            If Kanbans_dgv.Rows(e.RowIndex).Cells("result").Value Then
                e.Value = My.Resources.tick_32
            Else
                e.Value = My.Resources.bullet_white_32
            End If
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        If CBool(Parameter("DDR_AllowIncompletedOut", "False")) Then
            Cart.EndOut()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Dim newAdmin As New Sys_Authentication
            If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
                If newAdmin.User.HasPermission("DDR_User_AllowIncompletedOut_flag") Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Cart.EndOut()
                    Me.Close()
                Else
                    FlashAlerts.ShowError("No tienes autorización para realizar esta accion.")
                End If
            Else
                FlashAlerts.ShowError("Acción cancelada.")
            End If
        End If
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub
End Class