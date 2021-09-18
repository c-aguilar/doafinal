Public Class Smk_ChooseWarehouse

    Private Sub Smk_ChooseWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Warehouse_cbo, SQL.Current.GetDatatable("SELECT Name,Warehouse FROM Smk_Warehouses ORDER BY Name;"), "Name", "Warehouse")
        Warehouse_cbo.SelectedValue = My.Settings.Warehouse
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If My.Settings.Warehouse <> Warehouse_cbo.SelectedValue Then
            If MessageBox.Show("Este cambio influye directamente en altas de material, cambios de local, entre otras opciones dentro del sistema. ¿Seguro de continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                My.Settings.Warehouse = Warehouse_cbo.SelectedValue
                My.Settings.Save()
                FlashAlerts.ShowConfirm("Cambio realizado.")
            End If
        Else
            FlashAlerts.ShowInformation("Sin cambios detectados.")
        End If
    End Sub

    Private Sub Smk_ChooseWarehouse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class