Imports System.IO
Imports System.Globalization
Public Class Smk_SAPTransfers
    Dim next_process As String = "update"
    Dim selected_sloc As String
    Dim row_index_cancel As Integer = 0
    Dim id_cancel As Int64 = 0
    Dim update_date As Date
    Private Sub frmSAPTransfers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GF.FillCombobox(Sloc_cbo, SQL.Current.GetDatatable("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs UNION SELECT DISTINCT DullSloc AS Sloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc"), "Sloc", "Sloc")
        'If Not (User.Current.IsAdmin OrElse User.Current.HasPermission("SMK_AllowCancelOrChangeSAPTransfers")) Then
        '    For Each col As DataGridViewColumn In Partials_dgv.Columns
        '        col.ReadOnly = True
        '    Next
        'End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Run_btn.Click
        Run_btn.Enabled = False
        If next_process = "update" Then
            Dim sap As New SAP
            If sap.Available Then
                If Partials_dgv.DataSource IsNot Nothing Then CType(Partials_dgv.DataSource, DataTable).Clear()
                If Incidents_dgv.DataSource IsNot Nothing Then CType(Incidents_dgv.DataSource, DataTable).Clear()
                If Transfers_dgv.DataSource IsNot Nothing Then CType(Transfers_dgv.DataSource, DataTable).Clear()
                Sloc_cbo.Enabled = False
                selected_sloc = Sloc_cbo.SelectedValue
                If UpdateStock() Then
                    next_process = "transfer"
                    Run_btn.Text = "Transferir a SAP"
                End If
                Sloc_cbo.Enabled = True
            Else
                MsgBox("Ninguna sesion de SAP encontrada.", MsgBoxStyle.Exclamation)
            End If
        ElseIf next_process = "transfer" Then
            If CBool(Parameter("Smk_SAPTransfers_Enabled", True, True)) OrElse User.Current.IsAdmin Then
                If Not Transfer() Then Me.Close()
            Else
                FlashAlerts.ShowInformation("Las transferencias fueron temporalmente desactivadas.")
            End If
            Run_btn.Text = "Actualizar Inventario"
            next_process = "update"
        End If
        Run_btn.Enabled = True
    End Sub

    Public Function UpdateStock() As Boolean
        LoadingScreen.Show()
        Try
            SQL.Current.Execute("UPDATE Smk_SAPTransfers SET Posted = 1, PostedDate = GetDate(), AdjustmentQuantity = 0, DocumentNumber = 'Delta Validation',PostedUsername = 'DeltaERP' WHERE Posted = 0 AND (FromSloc = ToSloc OR Quantity <= 0)")
            SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_Hostname = '{0}' OR DATEDIFF(MINUTE,t_Date,GETDATE()) > 30 ;", Environment.MachineName))
            SQL.Current.Delete("Smk_tmpZapi", "z_Hostname", Environment.MachineName)

            If SQL.Current.GetScalar(String.Format("SELECT COUNT(*) FROM Smk_SAPTransfers WHERE Posted = 0 AND FromSloc = '{0}' AND FromSloc <> ToSloc", selected_sloc)) = 0 Then
                LoadingScreen.Hide()
                FlashAlerts.ShowInformation(String.Format("No existe nada para transferir del sloc {0}.", selected_sloc))
                Return False
            End If

            If Not SQL.Current.Execute(String.Format("INSERT INTO Smk_tmpSAPTransfers (t_Partnumber,t_FromSloc,t_ToSloc,t_Quantity,t_NewQuantity,t_UoM,t_Serialnumber,t_TransferID,t_FlagTransfer,t_Hostname,t_Date) SELECT S.Partnumber,T.FromSloc,T.ToSloc,T.Quantity, dbo.Sys_UnitConversion(S.Partnumber,S.UoM,T.Quantity,R.UoM),S.UoM,S.Serialnumber,T.ID,1,'{0}',GETDATE() " & _
                      "FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber LEFT OUTER JOIN Smk_tmpSAPTransfers ON T.ID = t_TransferID WHERE t_TransferID IS NULL AND Posted = 0 AND FromSloc = '{1}' AND FromSloc <> ToSloc", Environment.MachineName, selected_sloc)) Then
                If SQL.Current.GetScalar(String.Format("SELECT COUNT(*) FROM Smk_SAPTransfers WHERE Posted = 0 AND FromSloc = '{0}' AND FromSloc <> ToSloc", selected_sloc)) > 0 Then
                    LoadingScreen.Hide()
                    MsgBox("Error al calcular las transferencias.", MsgBoxStyle.Critical, APP)
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowInformation(String.Format("No existe nada para transferir del sloc {0}.", selected_sloc))
                End If
                Return False
            End If

            Incidents_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_FromSloc De,t_ToSloc A,COUNT(DISTINCT t_Partnumber) Transferencias FROM Smk_tmpSAPTransfers WHERE t_FromSloc <> t_ToSloc AND t_Hostname = '{0}' AND t_FromSloc = '{1}' GROUP BY t_FromSloc,t_ToSloc ORDER BY t_FromSloc,t_ToSloc", Environment.MachineName, selected_sloc))

            Dim filename As String = GF.TempTXTPath
            Dim sap As New SAP
            If sap.Available AndAlso sap.ZAPI_MATINFO(Parameter("SYS_PlantCode"), filename, "*", selected_sloc) Then
                Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                txt.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")
                Dim zapimatinfo = txt.DefaultView.ToTable(False, "New_Material", "Material description", "Storage Loc", "Unrestricted stock")
                zapimatinfo.Columns.Add("Hostname", GetType(String), String.Format("'{0}'", Environment.MachineName))
                TryDelete(filename)
                If Not SQL.Current.Bulk(zapimatinfo, "Smk_tmpZapi") Then
                    LoadingScreen.Hide()
                    MsgBox("Error al actualizar el inventario.", MsgBoxStyle.Critical, APP)
                    Return False
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Error al obtener el inventario actual.", MsgBoxStyle.Critical, APP)
                Return False
            End If
            Transfers_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_Partnumber,ISNULL(z_quantity,0) AS z_quantity,sum_transfers FROM (SELECT t_Partnumber,SUM(CASE WHEN t_FlagTransfer = 1 THEN t_NewQuantity ELSE 0 END) AS sum_transfers FROM Smk_tmpSAPTransfers WHERE t_Hostname='{0}' AND t_FromSloc = '{1}' GROUP BY t_Partnumber) AS Transfers LEFT OUTER JOIN Smk_tmpZapi ON z_partNumber = t_Partnumber AND z_Hostname = '{0}' AND z_sloc = '{1}' ORDER BY ISNULL(z_quantity,0) - sum_transfers ASC", Environment.MachineName, selected_sloc))
            LoadingScreen.Hide()
            update_date = Delta.CurrentDate
            Return True
        Catch ex As Exception
            LoadingScreen.Hide()
            SQL.Current.Delete("Smk_tmpSAPTransfers", "t_Hostname", Environment.MachineName)
            SQL.Current.Delete("Smk_tmpZapi", "z_Hostname", Environment.MachineName)
            MessageBox.Show(ex.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function Transfer() As Boolean
        LoadingScreen.Show()
        Dim Partnumbers As New ArrayList()
        Dim Quantities As New ArrayList()
        Dim UoMs As New ArrayList()
        Dim Slocs As New ArrayList()
        Try
            If DateDiff(DateInterval.Minute, update_date, Delta.CurrentDate) >= 29 Then
                SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_Hostname = '{0}';", Environment.MachineName))
                SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpZapi WHERE z_Hostname = '{0}';", Environment.MachineName))
                FlashAlerts.ShowError("El tiempo para transmitir expiró, actualice nuevamente el inventario.")
                Return False
            End If
            'QUITAR BANDERA A NUMEROS SIN SUFICIENTE INVENTARIO
            SQL.Current.Execute(String.Format("UPDATE Smk_tmpSAPTransfers SET t_FlagTransfer = 0 WHERE t_Partnumber IN (SELECT t_Partnumber FROM Smk_tmpZapi INNER JOIN (SELECT t_Partnumber,SUM(t_NewQuantity) AS sum_transfer FROM Smk_tmpSAPTransfers WHERE t_FlagTransfer=1 GROUP BY t_Partnumber HAVING SUM(t_NewQuantity) > 0) AS transfers ON z_partNumber = t_Partnumber AND z_Hostname = t_Hostname WHERE z_quantity < sum_transfer AND t_Hostname = '{0}' AND t_FromSloc = '{1}') AND t_Hostname = '{0}' AND t_FromSloc = '{1}';", Environment.MachineName, selected_sloc))
            Slocs.AddRange(SQL.Current.GetList(String.Format("SELECT DISTINCT t_ToSloc FROM Smk_tmpSAPTransfers WHERE t_FromSloc = '{0}' AND t_FlagTransfer = 1 AND t_Hostname = '{1}';", selected_sloc, Environment.MachineName)))
            Dim sap As New SAP
            If sap.Available Then
                For j = 0 To Slocs.Count - 1
                    For Each row As DataRow In SQL.Current.GetDatatable(String.Format("SELECT t_Partnumber,sum_transfer,UoM FROM Smk_tmpZapi INNER JOIN (SELECT t_Partnumber,SUM(t_NewQuantity) AS sum_transfer,R.UoM FROM Smk_tmpSAPTransfers INNER JOIN Sys_RawMaterial AS R ON t_Partnumber = R.Partnumber WHERE t_FlagTransfer = 1 AND t_ToSloc = '{0}' AND t_Hostname = '{1}' AND t_FromSloc = '{2}' GROUP BY t_Partnumber,R.UoM HAVING SUM(t_NewQuantity) > 0) AS Transfers ON z_partNumber = t_Partnumber WHERE z_Hostname = '{1}' AND z_Quantity - sum_transfer >= 0", Slocs(j), Environment.MachineName, selected_sloc)).Rows
                        Partnumbers.Add(row.Item("t_Partnumber"))
                        Quantities.Add(String.Format(CultureInfo.InvariantCulture, "{0:0,0.000}", row.Item("sum_transfer")))
                        UoMs.Add(row.Item("UoM"))
                    Next
                    Dim doc_number As String = "--"
                    If Partnumbers.Count > 0 Then
                        doc_number = sap.MB1B(Parameter("SYS_PlantCode"), selected_sloc, Slocs(j), Partnumbers, Quantities, UoMs, "Z11")
                        If doc_number.ToUpper.Contains("DOCUMENT") And doc_number.ToUpper.Contains("POSTED") Then
                            If Not SQL.Current.Execute(String.Format("UPDATE Smk_SAPTransfers SET Posted = 1, AdjustmentQuantity=Quantity-dbo.Sys_UnitConversion(t_Partnumber,r_UoM,t_NewQuantity,t_UoM), PostedDate = GetDate(), DocumentNumber = '{0}', PostedUsername = '{4}' FROM (SELECT T.*, R.UoM AS r_UoM FROM Smk_tmpSAPTransfers AS T INNER JOIN Sys_RawMaterial AS R ON T.t_Partnumber = R.Partnumber) AS tmpTransfers WHERE ID = t_TransferID AND t_FlagTransfer = 1 AND ToSloc = '{1}' AND t_Hostname = '{2}' AND FromSloc = '{3}' AND t_Partnumber IN (" & _
                                                                     "SELECT t_Partnumber FROM Smk_tmpZapi INNER JOIN (SELECT t_Partnumber,SUM(t_NewQuantity) AS sum_transfer FROM Smk_tmpSAPTransfers WHERE t_FlagTransfer = 1 AND t_ToSloc = '{1}' AND t_Hostname = '{2}' AND t_FromSloc = '{3}' GROUP BY t_Partnumber HAVING SUM(t_NewQuantity) > 0) AS Transfers ON z_partNumber = t_Partnumber AND z_Hostname = '{2}' WHERE z_quantity-sum_transfer >= 0)", doc_number.ToUpper.Replace("DOCUMENT", "").Replace("POSTED", "").Trim, Slocs(j), Environment.MachineName, selected_sloc, User.Current.Username)) Then
                                LoadingScreen.Hide()
                                Log(doc_number.ToUpper.Replace("DOCUMENT", "").Replace("POSTED", "").Trim, "Smk_TransferFail")
                                MsgBox("No fue posible actualizar las transferencias en Delta. " & vbCrLf & "Notifique al area de sistemas con el siguiente numero de documento: " & doc_number.ToUpper.Replace("DOCUMENT", "").Replace("POSTED", "").Trim, MsgBoxStyle.Critical, APP)
                                Return False
                            End If
                        Else
                            LoadingScreen.Hide()
                            MessageBox.Show("Ha ocurrido un error en SAP, favor de validar." & vbCrLf & "Message: " & doc_number, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    End If
                    If j < Slocs.Count - 1 Then
                        If Not SQL.Current.Execute(String.Format("UPDATE Smk_tmpZapi SET z_quantity=z_quantity-sum_transfer FROM (SELECT t_Partnumber,SUM(t_NewQuantity) AS sum_transfer FROM Smk_tmpSAPTransfers WHERE t_FlagTransfer=1 AND t_ToSloc='{0}' AND t_Hostname='{1}' AND t_FromSloc = '{2}' GROUP BY t_Partnumber) AS Trans WHERE z_Partnumber = t_Partnumber AND z_Sloc = '{2}' AND z_Hostname = '{1}';", Slocs(j), Environment.MachineName, selected_sloc)) Then
                            LoadingScreen.Hide()
                            MsgBox("No fue posible recalcular el inventario despues de la transferencia del " & selected_sloc & " al " & Slocs(j) & ", es necesario volver a descargarlo para continuar con las transferencias del " & selected_sloc & " al " & Slocs(j + 1) & ".", MsgBoxStyle.Exclamation, APP)
                            Return False
                        End If
                        If Not SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_FromSloc = '{0}' AND t_ToSloc = '{1}' AND t_Hostname='{2}'", selected_sloc, Slocs(j), Environment.MachineName)) Then
                            LoadingScreen.Hide()
                            MsgBox("No fue posible eliminar las transferencias ya realizadas del " & selected_sloc & " al " & Slocs(j) & ", es necesario volver a actualizar el inventario para continuar con las transferencias del " & selected_sloc & " al " & Slocs(j + 1) & ".", MsgBoxStyle.Exclamation, APP)
                            Return False
                        End If
                    End If
                    Partnumbers.Clear()
                    Quantities.Clear()
                    UoMs.Clear()
                Next
                If Partials_dgv.DataSource IsNot Nothing Then CType(Partials_dgv.DataSource, DataTable).Clear()
                If Transfers_dgv.DataSource IsNot Nothing Then CType(Transfers_dgv.DataSource, DataTable).Clear()
                SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_Hostname = '{0}';", Environment.MachineName))
                SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpZapi WHERE z_Hostname = '{0}';", Environment.MachineName))
                LoadingScreen.Hide()
                MsgBox("Consumos transferidos a SAP correctamente!", MsgBoxStyle.Information, APP)
                Return True
            Else
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
                Return False
            End If
        Catch ex As Exception
            SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_Hostname = '{0}';", Environment.MachineName))
            SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpZapi WHERE z_Hostname = '{0}';", Environment.MachineName))
            LoadingScreen.Hide()
            MsgBox("Hubo un problema al tratar de transferir la información a SAP." & vbCrLf & ex.Message, MsgBoxStyle.Critical, APP)
            Return False
        End Try
    End Function
    Private Sub cboSloc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sloc_cbo.SelectedIndexChanged
        next_process = "update"
        SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpSAPTransfers WHERE t_Hostname = '{0}';", Environment.MachineName))
        SQL.Current.Execute(String.Format("DELETE FROM Smk_tmpZapi WHERE z_Hostname = '{0}';", Environment.MachineName))
        If Partials_dgv.DataSource IsNot Nothing Then CType(Partials_dgv.DataSource, DataTable).Clear()
        If Incidents_dgv.DataSource IsNot Nothing Then CType(Incidents_dgv.DataSource, DataTable).Clear()
        If Transfers_dgv.DataSource IsNot Nothing Then CType(Transfers_dgv.DataSource, DataTable).Clear()
        Run_btn.Enabled = True
        Run_btn.Text = "Actualizar Inventario"
    End Sub

    Private Sub Partials_dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Partials_dgv.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Partials_dgv.Columns.Item("flag_transfer").Index Then
            lbl10.Focus()
            SQL.Current.Update("Smk_tmpSAPTransfers", {"t_FlagTransfer"}, {IIf(CType(Partials_dgv.Rows(e.RowIndex).Cells("flag_transfer"), DataGridViewCheckBoxCell).Value <> vbTrue, 0, 1)}, "t_TransferID", Partials_dgv("id", e.RowIndex).Value)
            Transfers_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_Partnumber,ISNULL(z_quantity,0) AS z_quantity,sum_transfers FROM (SELECT t_Partnumber,SUM(CASE WHEN t_FlagTransfer = 1 THEN t_NewQuantity ELSE 0 END) AS sum_transfers FROM Smk_tmpSAPTransfers WHERE t_Hostname='{0}' AND t_FromSloc = '{1}' GROUP BY t_Partnumber) AS Transfers LEFT OUTER JOIN Smk_tmpZapi ON z_partNumber = t_Partnumber AND z_Hostname = '{0}' AND z_sloc = '{1}' ORDER BY ISNULL(z_quantity,0) - sum_transfers ASC", Environment.MachineName, selected_sloc))
        End If
    End Sub

    Private Sub Partials_dgv_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Partials_dgv.CellEndEdit
        If e.ColumnIndex = Partials_dgv.Columns("adjust_quantity").Index Then
            SQL.Current.Update("Smk_tmpSAPTransfers", "t_NewQuantity", Partials_dgv(e.ColumnIndex, e.RowIndex).Value, "t_TransferID", Partials_dgv("id", e.RowIndex).Value)
            Transfers_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_Partnumber,ISNULL(z_quantity,0) AS z_quantity,sum_transfers FROM (SELECT t_Partnumber,SUM(CASE WHEN t_FlagTransfer = 1 THEN t_NewQuantity ELSE 0 END) AS sum_transfers FROM Smk_tmpSAPTransfers WHERE t_Hostname='{0}' AND t_FromSloc = '{1}' GROUP BY t_Partnumber) AS Transfers LEFT OUTER JOIN Smk_tmpZapi ON z_partNumber = t_Partnumber AND z_Hostname = '{0}' AND z_sloc = '{1}' ORDER BY ISNULL(z_quantity,0) - sum_transfers ASC", Environment.MachineName, selected_sloc))
        End If
    End Sub

    Private Sub Smk_SAPTransfers_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SQL.Current.Delete("Smk_tmpSAPTransfers", "t_Hostname", Environment.MachineName)
        SQL.Current.Delete("Smk_tmpZapi", "z_Hostname", Environment.MachineName)
    End Sub

    Private Sub CancelContextMenuStrimItem_Click(sender As Object, e As EventArgs) Handles CancelContextMenuStrimItem.Click
        If MessageBox.Show("¿Cancelar definitivamente la transferencia a SAP?" & vbNewLine & "Esta transferencia no volvera a aparecer.", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SQL.Current.Delete("Smk_tmpSAPTransfers", "t_TransferID", id_cancel)
            SQL.Current.Execute(String.Format("UPDATE Smk_SAPTransfers SET Posted = 1, DocumentNumber = 'Canceled by {0}', PostedUsername = '{0}', PostedDate = GETDATE() WHERE ID = {1};", User.Current.Username, id_cancel))
            Partials_dgv.Rows.RemoveAt(row_index_cancel)
            Transfers_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_Partnumber,ISNULL(z_quantity,0) AS z_quantity,sum_transfers FROM (SELECT t_Partnumber,SUM(CASE WHEN t_FlagTransfer = 1 THEN t_NewQuantity ELSE 0 END) AS sum_transfers FROM Smk_tmpSAPTransfers WHERE t_Hostname='{0}' AND t_FromSloc = '{1}' GROUP BY t_Partnumber) AS Transfers LEFT OUTER JOIN Smk_tmpZapi ON z_partNumber = t_Partnumber AND z_Hostname = '{0}' AND z_sloc = '{1}' ORDER BY ISNULL(z_quantity,0) - sum_transfers ASC", Environment.MachineName, selected_sloc))
        End If
    End Sub

    Private Sub Partials_dgv_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Partials_dgv.CellMouseDown
        Partials_dgv.ClearSelection()
        If e.Button = Windows.Forms.MouseButtons.Right Then
            row_index_cancel = e.RowIndex
            id_cancel = Partials_dgv("id", e.RowIndex).Value
        End If
    End Sub

    Private Sub Transfers_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Transfers_dgv.CellFormatting
        If e.RowIndex >= 0 Then
            If Transfers_dgv.Rows(e.RowIndex).Cells("sap_quantity").Value >= Transfers_dgv.Rows(e.RowIndex).Cells("transfer_quantity").Value Then
                e.CellStyle.BackColor = Color.LightGreen
                e.CellStyle.ForeColor = Color.Black
            Else
                e.CellStyle.BackColor = Color.LightCoral
                e.CellStyle.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub Transfers_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Transfers_dgv.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Transfers_dgv.Columns("show_btn").Index Then
            Partials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT t_Serialnumber,t_FromSloc,t_ToSloc,t_Quantity,t_UoM,CASE WHEN t_UoM = 'FT' THEN t_Quantity*0.3048 ELSE CASE WHEN t_UoM='LB' THEN t_Quantity*0.45359237 ELSE t_Quantity END END base_quantity," & _
                        "t_NewQuantity,t_FlagTransfer,t_TransferID FROM Smk_tmpSAPTransfers WHERE t_Partnumber='{0}' AND t_Hostname = '{1}'", Transfers_dgv("partnumber", e.RowIndex).Value, Environment.MachineName))
            For Each row As DataGridViewRow In Partials_dgv.Rows
                row.ContextMenuStrip = cmsNoSAP
            Next
        End If
    End Sub

    Private Sub Partials_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Partials_dgv.DataError
        e.Cancel = True
    End Sub

    Private Sub Smk_SAPTransfers_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class