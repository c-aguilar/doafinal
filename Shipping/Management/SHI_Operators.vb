Public Class Shi_Operators

    Private Sub SHI_Operators_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetOperators()
        GF.FillCombobox(Shift_cbo, SQL.Current.GetDatatable("SELECT Shift FROM Sys_Shifts ORDER BY Shift"), "Shift", "Shift")
        GF.FillCombobox(Role_cbo, SQL.Current.GetDatatable("SELECT ID, Role FROM Smk_OperatorRoles WHERE Area = 'SHI' ORDER BY Role"), "Role", "ID")
        For i = 1 To CInt(Parameter("SYS_BadgeLength", 9))
            Badge_txt.Mask &= "0"
        Next
    End Sub
    Private Sub GetOperators()
        GF.FillCombobox(Badge_cbo, SQL.Current.GetDatatable("SELECT '#########' AS Badge,'(Nuevo)' AS FullName UNION ALL SELECT Badge, FullName FROM Smk_Operators WHERE Area = 'SHI' AND Active = 1 ORDER BY FullName"), "FullName", "Badge")
    End Sub

    Private Sub Badge_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Badge_cbo.SelectionChangeCommitted
        If Badge_cbo.SelectedValue = "#########" Then
            Clean()
        Else
            Badge_txt.ReadOnly = True
            Badge_txt.Text = Badge_cbo.SelectedValue
            Dim operator_info As Hashtable = SQL.Current.GetRecord("Smk_Operators", "Badge", Badge_cbo.SelectedValue)
            Firstname_txt.Text = operator_info.Item("firstname")
            Lastname_txt.Text = operator_info.Item("lastname")
            Shift_cbo.Text = operator_info.Item("shift")
            If operator_info.Item("roleid") = "" Then
                Role_cbo.SelectedIndex = -1
            Else
                Role_cbo.SelectedValue = operator_info.Item("roleid")
            End If
            Activity_txt.Text = operator_info.Item("activity")
            Department_txt.Text = operator_info.Item("department")
            Picture_pb.Image = Delta.GetUserPhoto(Badge_cbo.SelectedValue)
        End If
    End Sub

    Private Sub Clean()
        Badge_cbo.SelectedValue = "#########"
        Picture_pb.Image = Nothing
        Badge_txt.ReadOnly = False
        Badge_txt.Clear()
        Firstname_txt.Clear()
        Lastname_txt.Clear()
        Shift_cbo.SelectedIndex = -1
        Badge_txt.Focus()
        Role_cbo.SelectedIndex = -1
        Activity_txt.Clear()
        Department_txt.Clear()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Badge_cbo.SelectedValue = "#########" Then
            If Badge_txt.MaskCompleted Then
                If Shift_cbo.SelectedIndex > -1 Then
                    If Firstname_txt.Text <> "" AndAlso Lastname_txt.Text <> "" Then
                        If SQL.Current.Exists("Smk_Operators", "Badge", Badge_txt.Text) Then
                            If SQL.Current.Exists("Smk_Operators", {"Badge", "Area"}, {Badge_txt.Text, "SHI"}) Then
                                SQL.Current.Update("Smk_Operators", {"Firstname", "Lastname", "Shift", "Active", "RoleID", "Activity", "Department"}, {Firstname_txt.Text, Lastname_txt.Text, Shift_cbo.SelectedValue, 1, NullReplace(Role_cbo.SelectedValue, DBNull.Value), Activity_txt.Text, Department_txt.Text}, "Badge", Badge_txt.Text)
                                Delta.SaveUserPhoto(Badge_txt.Text, Picture_pb.Image)
                                GetOperators()
                                Clean()
                                FlashAlerts.ShowConfirm("Registrado.")
                            ElseIf SQL.Current.Exists("Smk_Operators", {"Badge", "Active"}, {Badge_txt.Text, 0}) Then
                                SQL.Current.Update("Smk_Operators", {"Firstname", "Lastname", "Shift", "Active", "Area", "RoleID", "Activity", "Department"}, {Firstname_txt.Text, Lastname_txt.Text, Shift_cbo.SelectedValue, 1, "SHI", NullReplace(Role_cbo.SelectedValue, DBNull.Value), Activity_txt.Text, Department_txt.Text}, "Badge", Badge_txt.Text)
                                Delta.SaveUserPhoto(Badge_txt.Text, Picture_pb.Image)
                                GetOperators()
                                Clean()
                                FlashAlerts.ShowConfirm("Registrado.")
                            Else
                                Clean()
                                FlashAlerts.ShowError("El operador se encuentra registrado en otra area.")
                            End If
                        Else
                            If SQL.Current.Insert("Smk_Operators", {"Badge", "Firstname", "Lastname", "Area", "Shift", "RoleID", "Activity", "Department"}, {Badge_txt.Text, Firstname_txt.Text, Lastname_txt.Text, "SHI", Shift_cbo.SelectedValue, NullReplace(Role_cbo.SelectedValue, DBNull.Value), Activity_txt.Text, Department_txt.Text}) Then
                                Delta.SaveUserPhoto(Badge_txt.Text, Picture_pb.Image)
                                GetOperators()
                                Clean()
                                FlashAlerts.ShowConfirm("Registrado.")
                            Else
                                FlashAlerts.ShowError("Error al registrar el operador.")
                            End If
                        End If
                    Else
                        FlashAlerts.ShowInformation("Ingresa el nombre completo del operador.")
                    End If
                Else
                    FlashAlerts.ShowInformation("Selecciona el turno.")
                End If
            Else
                FlashAlerts.ShowInformation(String.Format("El número de gafete debe contener {0} caracteres.", Parameter("SYS_BadgeLength", 9)))
            End If
        Else
            If Shift_cbo.SelectedIndex > -1 Then
                If Firstname_txt.Text <> "" AndAlso Lastname_txt.Text <> "" Then
                    SQL.Current.Update("Smk_Operators", {"Firstname", "Lastname", "Shift", "Active", "Area", "RoleID", "Activity", "Department"}, {Firstname_txt.Text, Lastname_txt.Text, Shift_cbo.SelectedValue, 1, "SHI", NullReplace(Role_cbo.SelectedValue, DBNull.Value), Activity_txt.Text, Department_txt.Text}, "Badge", Badge_cbo.SelectedValue)
                    Delta.SaveUserPhoto(Badge_cbo.SelectedValue, Picture_pb.Image)
                    Clean()
                    FlashAlerts.ShowConfirm("Actualizado.")
                Else
                    FlashAlerts.ShowInformation("Ingresa el nombre completo del operador.")
                End If
            Else
                FlashAlerts.ShowInformation("Selecciona el turno.")
            End If
        End If
    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If Badge_cbo.SelectedValue <> "#########" Then
            If MessageBox.Show("¿Seguro de eliminar este operador?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SQL.Current.Execute(String.Format("UPDATE Smk_Operators SET Active = 0, RoleID = NULL, Activity = NULL WHERE Badge = '{0}';", Badge_cbo.SelectedValue))
                GetOperators()
                Clean()
                FlashAlerts.ShowConfirm("Eliminado.")
            End If
        End If
    End Sub

    Private Sub Picture_btn_Click(sender As Object, e As EventArgs) Handles Picture_btn.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog()
        dialog.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
        If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim img As Image = Image.FromFile(dialog.FileName)
            Picture_pb.Image = img
        End If
    End Sub

    Private Sub SHI_Operators_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class