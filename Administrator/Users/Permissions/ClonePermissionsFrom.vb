Public Class ClonePermissionsFrom

    Private Sub ClonePermissionsFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(CloneFrom_FromUsername_cbo, SQL.Current.GetDatatable("SELECT FirstName + ' ' + LastName AS FullName,Username FROM Sys_Users ORDER BY FirstName + ' ' + LastName"), "FullName", "Username")
        GF.FillCombobox(CloneFrom_ToUsername_cbo, SQL.Current.GetDatatable("SELECT FirstName + ' ' + LastName AS FullName,Username FROM Sys_Users ORDER BY FirstName + ' ' + LastName"), "FullName", "Username")
    End Sub

    Private Sub CloneFrom_Save_btn_Click(sender As Object, e As EventArgs) Handles CloneFrom_Save_btn.Click
        If CloneFrom_FromUsername_cbo.SelectedIndex > -1 AndAlso CloneFrom_ToUsername_cbo.SelectedIndex > -1 Then
            If CloneFrom_AddMissings_rbn.Checked Then
                If SQL.Current.Execute(String.Format("MERGE Sys_UserPermissions AS Target USING (SELECT '{1}' AS Username,[Option],[Enabled] FROM Sys_UserPermissions " & _
                                       "WHERE Username = '{0}' AND [Enabled] = 1) AS Source ON Target.Username = Source.Username AND Target.[Option] = Source.[Option] " & _
                                       "WHEN MATCHED THEN UPDATE SET [Enabled] = Source.[Enabled] WHEN NOT MATCHED THEN " & _
                                       "INSERT (Username,[Option],[Enabled]) VALUES (Source.Username,Source.[Option],Source.[Enabled]);", CloneFrom_FromUsername_cbo.SelectedValue, CloneFrom_ToUsername_cbo.SelectedValue)) Then
                    FlashAlerts.ShowConfirm("Hecho!")
                Else
                    FlashAlerts.ShowError("Error al clonar.")
                End If
            ElseIf CloneFrom_Clone_rbn.Checked Then
                If SQL.Current.Execute(String.Format("MERGE Sys_UserPermissions AS Target USING (SELECT '{1}' AS Username,[Option],[Enabled] FROM Sys_UserPermissions " & _
                                       "WHERE Username = '{0}') AS Source ON Target.Username = Source.Username AND Target.[Option] = Source.[Option] " & _
                                       "WHEN MATCHED THEN UPDATE SET [Enabled] = Source.[Enabled] WHEN NOT MATCHED THEN " & _
                                       "INSERT (Username,[Option],[Enabled]) VALUES (Source.Username,Source.[Option],Source.[Enabled]);", CloneFrom_FromUsername_cbo.SelectedValue, CloneFrom_ToUsername_cbo.SelectedValue)) Then
                    FlashAlerts.ShowConfirm("Hecho!")
                Else
                    FlashAlerts.ShowError("Error al clonar.")
                End If
            End If
        End If
    End Sub

    Private Sub UsernameComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CloneFrom_FromUsername_cbo.SelectionChangeCommitted
        dgvData.DataSource = SQL.Current.GetDatatable("Sys_UserPermissions", "Username", CloneFrom_FromUsername_cbo.SelectedValue)
    End Sub

    Private Sub ClonePermissionsFrom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class