Public Class Smk_RackOwners

    Private Sub Smk_RackOwners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Badge_cbo, SQL.Current.GetDatatable("SELECT Badge, FullName FROM Smk_Operators WHERE Area = 'SMK' AND Active = 1 ORDER BY FullName"), "FullName", "Badge")
        GF.FillCombobox(Warehouse_cbo, SQL.Current.GetDatatable("SELECT Warehouse,Name FROM Smk_Warehouses ORDER BY Name"), "Name", "Warehouse")
    End Sub

    Private Sub Badge_cbo_SelectedValueChanged(sender As Object, e As EventArgs) Handles Badge_cbo.SelectedValueChanged
        RefreshRacks()
    End Sub

    Private Sub RefreshRacks()
        Racks_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Rack,W.Name,R.Warehouse FROM Smk_RackOwners AS R INNER JOIN Smk_Warehouses AS W ON R.Warehouse = W.Warehouse WHERE Badge = '{0}' ORDER BY Rack;", Badge_cbo.SelectedValue))
    End Sub

    Private Sub Racks_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Racks_dgv.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Racks_dgv.Columns("Delete_btn").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Left + (e.CellBounds.Width / 2) - 8, e.CellBounds.Top + (e.CellBounds.Height / 2) - 8, 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.cross_16, rect)
            e.Handled = True
        End If
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Badge_cbo.SelectedValue IsNot Nothing Then
            If Rack_txt.MaskCompleted Then
                If Warehouse_cbo.SelectedValue IsNot Nothing Then
                    If Not SQL.Current.Exists("Smk_RackOwners", {"Badge", "Rack", "Warehouse"}, {Badge_cbo.SelectedValue, Rack_txt.Text, Warehouse_cbo.SelectedValue}) Then
                        SQL.Current.Insert("Smk_RackOwners", {"Badge", "Rack", "Warehouse"}, {Badge_cbo.SelectedValue, Rack_txt.Text, Warehouse_cbo.SelectedValue})
                        RefreshRacks()
                        Rack_txt.Clear()
                        FlashAlerts.ShowConfirm("¡Hecho!")
                    Else
                        FlashAlerts.ShowInformation("Rack ya registrado para el operador.")
                    End If
                Else
                    FlashAlerts.ShowInformation("Selecciona la estacion.")
                End If
            Else
                FlashAlerts.ShowInformation("El rack debe contener 2 digitos.")
            End If
        End If
    End Sub

    Private Sub Racks_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Racks_dgv.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Racks_dgv.Columns("Delete_btn").Index Then
            If SQL.Current.Delete("Smk_RackOwners", {"Badge", "Rack", "Warehouse"}, {Badge_cbo.SelectedValue, Racks_dgv.Rows(e.RowIndex).Cells("Rack").Value, Racks_dgv.Rows(e.RowIndex).Cells("Warehouse").Value}) Then
                RefreshRacks()
                FlashAlerts.ShowConfirm("Rack eliminado.")
            Else
                FlashAlerts.ShowError("Error al eliminar el rack.")
            End If
        End If
    End Sub

    Private Sub Badge_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Badge_cbo.SelectionChangeCommitted

    End Sub

    Private Sub Smk_RackOwners_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class