Public Class UserAdministration
    Dim rowCount As Integer

    Private Sub ExecuteMenu_Click(sender As Object, e As EventArgs) Handles ExecuteMenu.Click
        SQL.Current.FillDataGrid(userDGV, "SELECT [Username],[FirstName] ,[LastName] ,[Email] ,[Role],[Area] ,[Badge] ,[IsAdministrator] ,
                                            [OnDomain] ,[Active] ,[Language] FROM dbo.Sys_Users", True, False, False)
        rowCount = userDGV.RowCount
        FillComboBoxColumn()
    End Sub

    Private Sub SaveMenu_Click(sender As Object, e As EventArgs) Handles SaveMenu.Click
        Me.Cursor = Cursors.WaitCursor
        If userDGV.RowCount > rowCount Then
            If userDGV.RowCount = 2 Then
                For i As Integer = rowCount To userDGV.RowCount - 1
                    If userDGV.Rows(i).Cells(0).Value = Nothing Or userDGV.Rows(i).Cells(1).Value = Nothing Or userDGV.Rows(i).Cells(2).Value = Nothing Or userDGV.Rows(i).Cells(11).Value = Nothing Or userDGV.Rows(i).Cells(12).Value = Nothing Then
                        MessageBox.Show("There are pending fields to fill")
                        Exit Sub
                    Else
                        If userDGV.Rows(i).Cells(7).Value = Nothing Then
                            userDGV.Rows(i).Cells(7).Value = False
                        End If
                        If userDGV.Rows(i).Cells(8).Value = Nothing Then
                            userDGV.Rows(i).Cells(8).Value = False
                        End If
                        If userDGV.Rows(i).Cells(9).Value = Nothing Then
                            userDGV.Rows(i).Cells(9).Value = False
                        End If
                        If userDGV.Rows(i).Cells(3).Value = Nothing Then
                            userDGV.Rows(i).Cells(3).Value = ""
                        End If
                        If userDGV.Rows(i).Cells(6).Value = Nothing Then
                            userDGV.Rows(i).Cells(6).Value = ""
                        End If
                        If SQL.Current.Insert("dbo.Sys_Users", {"Username", "FirstName", "LastName", "Email", "Role", "Area", "Badge", "IsAdministrator", "OnDomain", "Active", "Language"},
                                          {userDGV.Rows(i).Cells(0).Value, userDGV.Rows(i).Cells(1).Value, userDGV.Rows(i).Cells(2).Value, userDGV.Rows(i).Cells(3).Value,
                                          userDGV.Rows(i).Cells(11).Value, userDGV.Rows(i).Cells(12).Value, userDGV.Rows(i).Cells(6).Value, userDGV.Rows(i).Cells(7).Value,
                                          userDGV.Rows(i).Cells(8).Value, userDGV.Rows(i).Cells(9).Value, userDGV.Rows(i).Cells(10).Value}) Then
                        Else
                            MessageBox.Show("New user was not correctly saved." + vbLf + "Please check the lenght of the fields:" + vbLf + "Username: 9" + vbLf + "First name and last name: 12" + vbLf + "Badge: 9" + vbLf + "Languaje: 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        'SQL.Current.Execute(String.Format("INSERT INTO [Sys_Users] ([Username],[FirstName],[LastName],[Email],[Role],[Area],[Badge],[Password],[IsAdministrator]
                        '                                    ,[OnDomain],[Active],[Language]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", userDGV.Rows(i).Cells(0).Value, userDGV.Rows(i).Cells(1).Value, userDGV.Rows(i).Cells(2).Value, userDGV.Rows(i).Cells(3).Value, userDGV.Rows(i).Cells(13).Value, userDGV.Rows(i).Cells(14).Value, userDGV.Rows(i).Cells(6).Value, userDGV.Rows(i).Cells(7).Value, userDGV.Rows(i).Cells(8).Value, userDGV.Rows(i).Cells(9).Value, userDGV.Rows(i).Cells(10).Value, userDGV.Rows(i).Cells(11).Value))
                    End If
                Next
                For j As Integer = 0 To rowCount - 1
                    SQL.Current.Execute(String.Format("UPDATE dbo.Sys_Users SET Username = '{0}', FirstName = '{1}', LastName = '{2}', Email = '{3}', [Role] = '{4}', Area = '{5}', Badge = '{6}',
                                IsAdministrator = '{7}', OnDomain = '{8}', Active = '{9}', Language = '{10}' WHERE Username = '{0}'",
                                              userDGV.Rows(j).Cells(0).Value, userDGV.Rows(j).Cells(1).Value, userDGV.Rows(j).Cells(2).Value, userDGV.Rows(j).Cells(3).Value,
                                              userDGV.Rows(j).Cells(11).Value, userDGV.Rows(j).Cells(12).Value, userDGV.Rows(j).Cells(6).Value, userDGV.Rows(j).Cells(7).Value,
                                              userDGV.Rows(j).Cells(8).Value, userDGV.Rows(j).Cells(9).Value, userDGV.Rows(j).Cells(10).Value))
                Next
                rowCount = userDGV.RowCount
                Me.Cursor = Nothing
                MessageBox.Show("Changes saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                For i As Integer = rowCount - 1 To userDGV.RowCount - 2
                    'If SQL.Current.Execute(String.Format("SELECT Username FROM dbo.Sys_Users WHERE Username = '{0}'", userDGV.Rows(i).Cells(0).Value)) Then
                    If SQL.Current.GetString(String.Format("SELECT Username FROM dbo.Sys_Users WHERE Username = '{0}'", userDGV.Rows(i).Cells(0).Value)) IsNot "" Then
                        MessageBox.Show("The user is already in the database")
                        Exit Sub
                    Else
                        If userDGV.Rows(i).Cells(0).Value = Nothing Or userDGV.Rows(i).Cells(1).Value = Nothing Or userDGV.Rows(i).Cells(2).Value = Nothing Or userDGV.Rows(i).Cells(11).Value = Nothing Or userDGV.Rows(i).Cells(12).Value = Nothing Then
                            MessageBox.Show("There are pending fields to fill")
                            Exit Sub
                        Else
                            If userDGV.Rows(i).Cells(7).Value = Nothing Then
                                userDGV.Rows(i).Cells(7).Value = False
                            End If
                            If userDGV.Rows(i).Cells(8).Value = Nothing Then
                                userDGV.Rows(i).Cells(8).Value = False
                            End If
                            If userDGV.Rows(i).Cells(9).Value = Nothing Then
                                userDGV.Rows(i).Cells(9).Value = False
                            End If
                            If userDGV.Rows(i).Cells(3).Value = Nothing Then
                                userDGV.Rows(i).Cells(3).Value = ""
                            End If
                            If userDGV.Rows(i).Cells(6).Value = Nothing Then
                                userDGV.Rows(i).Cells(6).Value = ""
                            End If
                            If SQL.Current.Insert("dbo.Sys_Users", {"Username", "FirstName", "LastName", "Email", "Role", "Area", "Badge", "IsAdministrator", "OnDomain", "Active", "Language"},
                                                      {userDGV.Rows(i).Cells(0).Value, userDGV.Rows(i).Cells(1).Value, userDGV.Rows(i).Cells(2).Value, userDGV.Rows(i).Cells(3).Value,
                                                      userDGV.Rows(i).Cells(11).Value, userDGV.Rows(i).Cells(12).Value, userDGV.Rows(i).Cells(6).Value, userDGV.Rows(i).Cells(7).Value,
                                                      userDGV.Rows(i).Cells(8).Value, userDGV.Rows(i).Cells(9).Value, userDGV.Rows(i).Cells(10).Value}) Then
                            Else
                                MessageBox.Show("New user was not correctly saved." + vbLf + "Please check the lenght of the fields:" + vbLf + "Username: 9" + vbLf + "First name and last name: 12" + vbLf + "Badge: 9" + vbLf + "Languaje: 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            'SQL.Current.Execute(String.Format("INSERT INTO [Sys_Users] ([Username],[FirstName],[LastName],[Email],[Role],[Area],[Badge],[Password],[IsAdministrator]
                            '                                    ,[OnDomain],[Active],[Language]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", userDGV.Rows(i).Cells(0).Value, userDGV.Rows(i).Cells(1).Value, userDGV.Rows(i).Cells(2).Value, userDGV.Rows(i).Cells(3).Value, userDGV.Rows(i).Cells(13).Value, userDGV.Rows(i).Cells(14).Value, userDGV.Rows(i).Cells(6).Value, userDGV.Rows(i).Cells(7).Value, userDGV.Rows(i).Cells(8).Value, userDGV.Rows(i).Cells(9).Value, userDGV.Rows(i).Cells(10).Value, userDGV.Rows(i).Cells(11).Value))
                        End If
                    End If
                Next
                For j As Integer = 0 To rowCount - 1
                    SQL.Current.Execute(String.Format("UPDATE dbo.Sys_Users SET Username = '{0}', FirstName = '{1}', LastName = '{2}', Email = '{3}', [Role] = '{4}', Area = '{5}', Badge = '{6}',
                                IsAdministrator = '{7}', OnDomain = '{8}', Active = '{9}', Language = '{10}' WHERE Username = '{0}'",
                                                      userDGV.Rows(j).Cells(0).Value, userDGV.Rows(j).Cells(1).Value, userDGV.Rows(j).Cells(2).Value, userDGV.Rows(j).Cells(3).Value,
                                                      userDGV.Rows(j).Cells(11).Value, userDGV.Rows(j).Cells(12).Value, userDGV.Rows(j).Cells(6).Value, userDGV.Rows(j).Cells(7).Value,
                                                      userDGV.Rows(j).Cells(8).Value, userDGV.Rows(j).Cells(9).Value, userDGV.Rows(j).Cells(10).Value))
                Next
                rowCount = userDGV.RowCount
                Me.Cursor = Nothing
                MessageBox.Show("Changes saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SQL.Current.FillDataGrid(userDGV, String.Format("SELECT [Username],[FirstName] ,[LastName] ,[Email] ,[Role],[Area] ,[Badge] ,[IsAdministrator] ,
                                            [OnDomain] ,[Active] ,[Language] FROM dbo.Sys_Users WHERE Username Like '%'+'{0}'+'%' OR FullName LIKE '%'+'{0}'+'%'", searchTB.Text), True, False, False)
        FillComboBoxColumn()
        userDGV.BackgroundColor = Color.Gainsboro
    End Sub

    Private Sub FillComboBoxColumn()
        Dim comboBoxRole As DataGridViewComboBoxCell = New DataGridViewComboBoxCell()
        comboBoxRole.Items.AddRange(SQL.Current.GetList("SELECT [Role] FROM dbo.Sys_UserRoles").ToArray())
        Dim comboRole As DataGridViewColumn = New DataGridViewColumn(comboBoxRole)
        userDGV.Columns.Add(comboRole)
        userDGV.Columns(11).HeaderText = userDGV.Columns(4).HeaderText
        For i As Integer = 0 To userDGV.RowCount - 1
            userDGV.Rows(i).Cells(11).Value = userDGV.Rows(i).Cells(4).Value
        Next
        userDGV.Columns(4).Visible = False

        Dim comboBoxArea As DataGridViewComboBoxCell = New DataGridViewComboBoxCell()
        comboBoxArea.Items.AddRange(SQL.Current.GetList("SELECT [Area] FROM dbo.Sys_UserAreas").ToArray())
        Dim comboArea As DataGridViewColumn = New DataGridViewColumn(comboBoxArea)
        userDGV.Columns.Add(comboArea)
        userDGV.Columns(12).HeaderText = userDGV.Columns(5).HeaderText
        For i As Integer = 0 To userDGV.RowCount - 1
            userDGV.Rows(i).Cells(12).Value = userDGV.Rows(i).Cells(5).Value
        Next
        userDGV.Columns(5).Visible = False
    End Sub
End Class