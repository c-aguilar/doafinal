
Public Class Smk_CableSerialsOnCutters
    Private Sub frmOnCutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboCutters, SQL.Current.GetDatatable(String.Format("SELECT ID,Name FROM PE_Cutters WHERE Warehouse = '{0}' ORDER BY Name;", My.Settings.Warehouse)), "Name", "ID")
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub cboCutters_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCutters.SelectionChangeCommitted
        dgvResults.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber AS Serie,Partnumber AS [No. de Parte],CurrentQuantity AS Cantidad,UoM AS Unidad,DATEDIFF(HOUR,ISNULL(dbo.Smk_SerialLastMovementDate(ID,'STC'),dbo.Smk_SerialLastMovementDate(ID,'RTC')),GETDATE()) AS Horas FROM vw_Smk_Serials WHERE Status = 'C' AND dbo.Smk_SerialLastCutterID(ID) = '{0}' ORDER BY Partnumber;", cboCutters.SelectedValue))
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub


End Class