Public Class PlantsAdministration
    Dim rowCount As Integer

    Private Sub ExecuteMenu_Click(sender As Object, e As EventArgs) Handles ExecuteMenu.Click
        SQL.Current.FillDataGrid(plantsDGV, "SELECT * FROM dbo.Sys_Plants", True, False, False)
        rowCount = plantsDGV.RowCount
    End Sub

    Private Sub SaveMenu_Click(sender As Object, e As EventArgs) Handles SaveMenu.Click
        If plantsDGV.RowCount > rowCount Then
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = rowCount - 1 To plantsDGV.RowCount - 2
                If SQL.Current.GetString(String.Format("SELECT Plant FROM dbo.Sys_Plants WHERE Plant = '{0}'", plantsDGV.Rows(i).Cells(0).Value)) IsNot "" Then
                    MessageBox.Show("The plant is already in the database")
                    Exit Sub
                Else
                    If plantsDGV.Rows(i).Cells(2).Value = Nothing Then
                        plantsDGV.Rows(i).Cells(1).Value = False
                    End If
                    If plantsDGV.Rows(i).Cells(0).Value = Nothing Or plantsDGV.Rows(i).Cells(1).Value = Nothing Then
                        MessageBox.Show("There are pending fields to fill")
                        Exit Sub
                    Else
                        SQL.Current.Insert("dbo.Sys_Plants", {"Plant", "BusinessName", "Active"}, {plantsDGV.Rows(i).Cells(0).Value, plantsDGV.Rows(i).Cells(1).Value, plantsDGV.Rows(i).Cells(2).Value})
                    End If
                End If
            Next
        End If
        For i As Integer = 0 To plantsDGV.RowCount - 1
            SQL.Current.Execute(String.Format("UPDATE dbo.Sys_Plants SET Plant = '{0}', BusinessName = '{1}', Active = '{2}' WHERE Plant = '{0}'", plantsDGV.Rows(i).Cells(0).Value, plantsDGV.Rows(i).Cells(1).Value, plantsDGV.Rows(i).Cells(2).Value))
        Next
        Me.Cursor = Nothing
        MessageBox.Show("Successful")
    End Sub

    Private Sub plantTb_TextChanged(sender As Object, e As EventArgs) Handles plantTb.TextChanged
        If plantTb.Text IsNot "" Then
            SQL.Current.FillDataGrid(plantsDGV, String.Format("SELECT * FROM dbo.Sys_Plants WHERE Plant LIKE '%'+'{0}'+'%' OR BusinessName LIKE '%'+'{0}'+'%'", plantTb.Text), True, False, False)
        End If
    End Sub
End Class