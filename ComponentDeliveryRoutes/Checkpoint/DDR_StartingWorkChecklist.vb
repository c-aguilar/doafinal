Public Class DDR_StartingWorkChecklist
    Public Property Cart As String
    Private Badge As String
    Private Sub CDR_StartingWorkChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Badge = CDR.Carts.Find(Function(f) f.ID = Cart).ScannigInBadge
        For Each a In SQL.Current.GetList("SELECT Activity FROM CDR_MaintenanceActivities ORDER BY Activity")
            Activities_clb.Items.Add(a, True)
        Next
        Picture_pb.Image = Delta.GetUserPhoto(Badge)
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If SQL.Current.Insert("CDR_StartingWorkRegister", {"Badge", "Cart", "Comment"}, {Badge, Cart, Comment_txt.Text}) Then
            Dim id = SQL.Current.GetScalar("MAX(ID)", "CDR_StartingWorkRegister", {"Badge", "Cart"}, {Badge, Cart})
            For i = 0 To Activities_clb.Items.Count - 1
                If Activities_clb.GetItemCheckState(i) Then
                    SQL.Current.Insert("CDR_StartingWorkChecklist", {"checkID", "Activity", "Status"}, {id, Activities_clb.GetItemText(i), 1})
                Else
                    SQL.Current.Insert("CDR_StartingWorkChecklist", {"checkID", "Activity", "Status"}, {id, Activities_clb.GetItemText(i), 0})
                End If
            Next
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CDR_StartingWorkChecklist_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Comment_txt.Focus()
    End Sub
End Class