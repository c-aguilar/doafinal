Public Class CR_MRPSelectDialog
    Public Property SelectedMRPs As New ArrayList
    Public Property SelectedDate As Date
    Public Property MRPCs As Dictionary(Of String, MRPC)
    Private Sub CR_MRPSelectDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each i In MRPCs
            Dim node = MRP_tree.Nodes.Find(i.Value.Username, False)
            If node.Length = 0 Then
                MRP_tree.Nodes.Add(i.Value.Username, i.Value.Name)
                MRP_tree.Nodes(i.Value.Username.ToString).Nodes.Add(i.Value.MRP, i.Value.MRP)
                If SelectedMRPs.Contains(i.Value.MRP) Then
                    MRP_tree.Nodes(i.Value.Username).Nodes(i.Value.MRP.ToString.ToUpper).Checked = True
                End If
            Else
                node(0).Nodes.Add(i.Value.MRP, i.Value.MRP)
                If SelectedMRPs.Contains(i.Value.MRP) Then
                    node(0).Nodes(i.Value.MRP).Checked = True
                End If
            End If
        Next
        For Each node As TreeNode In MRP_tree.Nodes
            If node.Level = 0 Then
                Dim total_node As Integer = node.GetNodeCount(True)
                Dim total_selected As Integer = 0
                For Each subnode As TreeNode In node.Nodes
                    If subnode.Checked Then total_selected += 1
                Next
                If total_node = total_selected Then
                    node.Checked = True
                End If
            End If
        Next
        Horizon_dtp.MinDate = Delta.CurrentDate
        Horizon_dtp.Value = Me.SelectedDate
    End Sub

    Private Sub MRP_tree_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles MRP_tree.AfterCheck
        For Each n As TreeNode In e.Node.Nodes
            n.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        Me.SelectedMRPs.Clear()
        For Each node As TreeNode In MRP_tree.Nodes
            If node.Level = 0 Then
                For Each subnode As TreeNode In node.Nodes
                    If subnode.Checked Then Me.SelectedMRPs.Add(subnode.Text.ToUpper)
                Next
            End If
        Next
        Me.SelectedDate = Horizon_dtp.Value.Date
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub All_chk_CheckedChanged(sender As Object, e As EventArgs) Handles All_chk.CheckedChanged
        For Each node As TreeNode In MRP_tree.Nodes
            If node.Level = 0 Then
                node.Checked = All_chk.Checked
            End If
        Next
    End Sub
End Class