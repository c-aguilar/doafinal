Imports CAguilar
Public Class Smk_CableRoutesRegistry

    Private Sub Smk_CableRoutesRegistry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboRoutes, SQL.Current.GetDatatable("SELECT Name, ID FROM Smk_CableRoutes WHERE Shift = dbo.Sys_Shift(GETDATE()) ORDER BY route_name"), "Name", "ID")
        'CORREGIR COLUMN NAMES ^
        If cboRoutes.Items.Count > 0 Then
            cboRoutes.SelectedIndex = 0
        End If
        CType(Registry_dgv.Columns("delete_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.cross_16
        RefreshRegistry()
    End Sub

    Private Sub ReadBadge()
        If Badge_txt.Text.Trim <> "" Then
            If SQL.Current.Exists("Smk_Operators", "Badge", Badge_txt.Text) Then
                If SQL.Current.Exists("Smk_CableOperatorRegistry", {"Badge", "Active"}, {Badge_txt.Text, 1}) Then
                    Badge_txt.Clear()
                    Badge_txt.Focus()
                    FlashAlerts.ShowError("Gafete registrado actualmente en una ruta.")
                Else
                    If SQL.Current.Insert("Smk_CableOperatorRegistry", {"Badge", "RouteID"}, {Badge_txt.Text, cboRoutes.SelectedValue}) Then
                        Badge_txt.Clear()
                        Badge_txt.Focus()
                        RefreshRegistry()
                        FlashAlerts.ShowConfirm("Registrado correctamente.")
                    Else
                        FlashAlerts.ShowError("Error al registrar al operador.")
                    End If
                End If
            Else
                Badge_txt.Clear()
                Badge_txt.Focus()
                FlashAlerts.ShowError("Gafete no existe.")
            End If
        End If
    End Sub

    Private Sub Registry_dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Registry_dgv.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = Registry_dgv.Columns("delete_btn").Index Then
            SQL.Current.Update("Smk_CableOperatorRegistry", "Active", 0, "ID", Registry_dgv("ID", e.RowIndex).Value)
            RefreshRegistry()
        End If
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Badge_txt_TextChanged(sender As Object, e As EventArgs) Handles Badge_txt.TextChanged
        If Badge_txt.TextLength = Parameter("SYS_BadgeLength", 9) Then
            ReadBadge()
        End If
    End Sub

    Private Sub RefreshRegistry()
        Registry_dgv.DataSource = SQL.Current.GetDatatable("SELECT G.ID,R.Name,O.Fullname,G.[Date] FROM Smk_CableOperatorRegistry AS G INNER JOIN Smk_CableRoutes AS R ON G.RouteID = R.ID INNER JOIN Smk_Operators AS O ON G.Badge = O.Badge WHERE G.[Active] = 1 ORDER BY R.Name")
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class