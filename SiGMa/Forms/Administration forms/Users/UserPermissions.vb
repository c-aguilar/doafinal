Public Class UserPermissions
    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Me.Cursor = Cursors.WaitCursor
        For i As Integer = 0 To permissionsDGV.RowCount - 1
            If permissionsDGV.Rows(i).Cells(1).Value = Nothing Then
                permissionsDGV.Rows(i).Cells(1).Value = False
            End If
            SQL.Current.Insert("dbo.Sys_UserPermissions", {"Username", "[Option]", "[Enabled]"}, {SQL.Current.GetString(String.Format("SELECT Username FROM dbo.Sys_Users WHERE FullName = '{0}'", userCB.Text)), permissionsDGV.Rows(i).Cells(0).Value, permissionsDGV.Rows(i).Cells(1).Value})
        Next
        For i As Integer = 0 To permissionsDGV.RowCount - 1
            SQL.Current.Execute(String.Format("UPDATE dbo.Sys_UserPermissions SET [Enabled] = '{0}' FROM dbo.Sys_UserPermissions UP RIGHT JOIN dbo.Sys_Users U ON UP.Username = U.Username
                                                WHERE U.FullName = '{1}' AND [Option] = '{2}'", permissionsDGV.Rows(i).Cells(1).Value, userCB.Text, permissionsDGV.Rows(i).Cells(0).Value))
        Next
        'MessageBox.Show("Successful")
        Me.Cursor = Nothing
        MessageBox.Show("User permissions updated", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UserPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users As ArrayList = SQL.Current.GetList("SELECT FullName FROM dbo.Sys_Users")
        For Each item As String In users
            userCB.Items.Add(item)
        Next
    End Sub

    Private Sub userCB_SelectedValueChanged(sender As Object, e As EventArgs) Handles userCB.SelectedValueChanged
        SQL.Current.FillDataGrid(permissionsDGV, String.Format("WITH UserOptions AS (
	                                                                SELECT [Option], [Enabled] FROM dbo.Sys_UserPermissions UP
	                                                                LEFT JOIN dbo.Sys_Users U ON U.Username = UP.Username 
	                                                                WHERE U.FullName = '{0}'
                                                                ), ModuleOptions AS(
	                                                                SELECT * FROM dbo.Sys_ModuleOptions
                                                                )
                                                                SELECT 
	                                                                MO.[Option],
	                                                                UO.[Enabled]
                                                                FROM UserOptions UO
                                                                RIGHT JOIN ModuleOptions MO ON MO.[Option] = UO.[Option]", userCB.Text), True, False, False)
        If permissionsDGV.RowCount = 1 Then
            SQL.Current.FillDataGrid(permissionsDGV, String.Format("SELECT [Option] FROM dbo.Sys_ModuleOptions"), True, False, False)
            Dim AddColumn As New DataGridViewCheckBoxColumn
            With AddColumn
                .HeaderText = "Enabled"
                .Name = "Enabled"
                .Width = 60
            End With
            permissionsDGV.Columns.Insert(1, AddColumn)
        End If
        Dim active As String
        active = SQL.Current.GetString("Active", "dbo.Sys_Users", "FullName", userCB.Text, "")
        If active = "True" Then
            isActiveChB.Checked = True
        Else
            isActiveChB.Checked = False
        End If
    End Sub
End Class