Public Class Smk_CableCutterChange

    Private Sub frmCutterChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshCutters()
    End Sub

    Private Sub RefreshCutters()
        Cutter_txt.Clear()
        Serial_txt.Clear()
        Serial_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber AS Serie,Partnumber As [No. de Parte],C.ID AS CutterID, C.Name AS Cortadora FROM Smk_Serials AS S INNER JOIN PE_Cutters AS C ON dbo.Smk_SerialLastCutterID(S.ID) = C.ID WHERE S.Status ='C' AND S.Warehouse = '{0}' ORDER BY C.Name,S.ID", My.Settings.Warehouse))
        Cutters_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT ID, Name AS Nombre FROM PE_Cutters WHERE Warehouse = '{0}' ORDER BY Name;", My.Settings.Warehouse))
    End Sub

    Private Sub dgvSerials_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Serial_dgv.CellClick
        If e.RowIndex > -1 Then
            Serial_dgv.Rows(e.RowIndex).Selected = True
            Serial_txt.Text = Serial_dgv.Rows(e.RowIndex).Cells("Serie").Value
        End If
    End Sub

    Private Sub dgvCutters_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Cutters_dgv.CellClick
        If e.RowIndex > -1 Then
            Cutters_dgv.Rows(e.RowIndex).Selected = True
            Cutter_txt.Text = Cutters_dgv.Rows(e.RowIndex).Cells("ID").Value
        End If
    End Sub

    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Transfer_btn.Click
        If Serial_txt.Text <> "" And Cutter_txt.Text <> "" Then
            Dim serial As New Serialnumber(Serial_txt.Text)
            If serial.Exists Then
                If serial.Status = Serialnumber.SerialStatus.OnCutter Then
                    If SupermarketCable.ReturnBadge(Cutter_txt.Text) Then
                        If serial.ChangeCutter(Cutter_txt.Text, SupermarketCable.CurrentBadge) Then
                            RefreshCutters()
                            FlashAlerts.ShowConfirm("Cambio de cortadora realizado.")
                        Else
                            FlashAlerts.ShowError("No fue posible hacer el cambio de cortadora.")
                        End If
                    Else
                        FlashAlerts.ShowError("Debes escanear tu gafete.")
                    End If
                Else
                    FlashAlerts.ShowError("La serie seleccionada ya no se encuentra en cortadoras.")
                End If
            Else
                FlashAlerts.ShowError("Ocurrio un error con la serie seleccionada.")
            End If
        End If
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Filter_txt_TextChanged(sender As Object, e As EventArgs) Handles Filter_txt.TextChanged
        If SMK.IsRawMaterialFormat(Filter_txt.Text) Then
            Serial_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber AS Serie,Partnumber As [No. de Parte],C.ID AS CutterID, C.Name AS Cortadora FROM Smk_Serials AS S INNER JOIN PE_Cutters AS C ON dbo.Smk_SerialLastCutterID(S.ID) = C.ID WHERE S.Status ='C' AND S.Warehouse = '{0}' AND S.Partnumber = '{1}' ORDER BY C.Name,S.ID", My.Settings.Warehouse, Filter_txt.Text))
        End If
    End Sub

    Private Sub Close_btn_Click_1(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Filter_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Filter_txt.KeyDown
        If Filter_txt.Text = "" Then
            Serial_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber AS Serie,Partnumber As [No. de Parte],C.ID AS CutterID, C.Name AS Cortadora FROM Smk_Serials AS S INNER JOIN PE_Cutters AS C ON dbo.Smk_SerialLastCutterID(S.ID) = C.ID WHERE S.Status ='C' AND S.Warehouse = '{0}' ORDER BY C.Name,S.ID", My.Settings.Warehouse))
        End If
    End Sub
End Class