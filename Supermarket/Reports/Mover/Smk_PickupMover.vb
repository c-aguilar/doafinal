Public Class Smk_PickupMover
    Dim MoverID As Integer
    Dim Partnumbers As DataTable
    Dim types As DataTable
    Private Sub Smk_PickupMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        types = SQL.Current.GetDatatable("SELECT * FROM Ord_MoverTypes")
        types.PrimaryKey = {types.Columns("Type")}
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        If ID_txt.Text <> "" Then
            If SQL.Current.Exists("Ord_Movers", "ID", ID_txt.Text) Then
                Select Case SQL.Current.GetString("[Status]", "Ord_Movers", "ID", ID_txt.Text, "")
                    Case "N"
                        ID_txt.Clear()
                        ID_txt.Focus()
                        FlashAlerts.ShowError("El mover no ha sido aprobado.")
                    Case "P"
                        ID_txt.Clear()
                        ID_txt.Focus()
                        FlashAlerts.ShowInformation("El mover ya fue surtido.")
                    Case "S"
                        ID_txt.Clear()
                        ID_txt.Focus()
                        FlashAlerts.ShowInformation("El mover ya fue embarcado.")
                    Case "C"
                        ID_txt.Clear()
                        ID_txt.Focus()
                        FlashAlerts.ShowError("El mover fue cancelado.")
                    Case "A"
                        Find_btn.Enabled = False
                        ID_txt.Enabled = False
                        MoverID = ID_txt.Text
                        Partnumbers = SQL.Current.GetDatatable(String.Format("SELECT ID,Partnumber,UoM,Quantity,Quantity AS RealQuantity FROM Ord_MoverPartnumbers WHERE MoverID = {0};", ID_txt.Text))
                        Parts_dgv.DataSource = Partnumbers
                End Select
            Else
                ID_txt.Clear()
                ID_txt.Focus()
                FlashAlerts.ShowError("El mover no existe.")
            End If
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If MoverID > 0 Then
            If MessageBox.Show("¿Continuar con el ajuste de material?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim type_row As DataRow = types.Rows.Find(SQL.Current.GetString("[Type]", "Ord_Movers", "ID", MoverID, ""))
                Dim missing_tranferences As New DataTable
                missing_tranferences.Columns.Add("Mover ID")
                missing_tranferences.Columns.Add("No.de Parte")
                missing_tranferences.Columns.Add("Cantidad", GetType(Decimal))
                missing_tranferences.Columns.Add("Unidad")
                missing_tranferences.Columns.Add("SLoc")

                For Each p As DataRow In Partnumbers.Rows
                    Dim part As New RawMaterial(p.Item("Partnumber"))
                    If part.Exist Then 'NO DEBERIA HABER NUMEROS QUE NO EXISTAN PORQUE YA SE VALIDO EN LA PARTE EN EL FORM DE NEW MOVER
                        Dim discount_qty As Decimal = p.Item("RealQuantity")
                        Dim discount_uom As String = p.Item("UoM")
                        If part.Consumption = RawMaterial.ConsumptionType.Partial OrElse part.Consumption = RawMaterial.ConsumptionType.Mixed Then
                            Dim current_serial As String = SMK.CurrentSerial(part.Partnumber)
                            If current_serial = "" Then
                                'REGISTRAR LA CANTIDAD NO DESCONTADA
                                Log(String.Format("{0}|{1}|{2}|{3}|{4}", MoverID, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_MissingStock")
                                missing_tranferences.Rows.Add(MoverID, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc"))
                            Else
                                'DESCONTAR MATERIAL HASTA QUE ESTE COMPLETA LA CANTIDAD O NO EXISTA NINGUNA SERIE EN SERVICIO
                                While discount_qty > 0 AndAlso current_serial <> ""
                                    Dim serial As New Serialnumber(current_serial)
                                    If Convert(serial.CurrentQuantity, serial.UoM.ToString, discount_uom) >= discount_qty Then
                                        'VERIFICAR SI EL TIPO DE MOVER DEBE TRANSFERIR EL STOCK A OTRO SLOC
                                        If type_row.Item("TransferStock") Then
                                            'DESCONTAR Y TRANSFERIR
                                            If serial.MoverPartialDiscount(Convert(discount_qty, discount_uom, serial.UoM.ToString), type_row("TransferToSloc")) Then
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverTransference_Done")
                                            Else
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverTransference_Error")
                                            End If
                                        Else
                                            'SOLO DESCONTAR
                                            If serial.MoverPartialDiscount(Convert(discount_qty, discount_uom, serial.UoM.ToString)) Then
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_Done")
                                            Else
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_Error")
                                            End If
                                        End If
                                        current_serial = ""
                                    Else
                                        Dim serial_qty As Decimal = serial.CurrentQuantity
                                        discount_qty -= Convert(serial_qty, serial.UoM.ToString, discount_uom)
                                        If type_row.Item("TransferStock") Then
                                            'DESCONTAR Y TRANSFERIR
                                            If serial.MoverPartialDiscount(serial_qty, type_row("TransferToSloc")) Then
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, Convert(serial_qty, serial.UoM.ToString, discount_uom), discount_uom, type_row("TransferToSloc")), "Smk_MoverTransference_Done")
                                            Else
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, Convert(serial_qty, serial.UoM.ToString, discount_uom), discount_uom, type_row("TransferToSloc")), "Smk_MoverTransference_Error")
                                            End If
                                        Else
                                            'SOLO DESCONTAR
                                            If serial.MoverPartialDiscount(serial_qty) Then
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, Convert(serial_qty, serial.UoM.ToString, discount_uom), discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_Done")
                                            Else
                                                missing_tranferences.Rows.Add(MoverID, part.Partnumber, serial_qty, "", type_row("TransferToSloc"))
                                                Log(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", MoverID, serial.SerialNumber, part.Partnumber, Convert(serial_qty, serial.UoM.ToString, discount_uom), discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_Error")
                                            End If
                                        End If
                                        current_serial = SMK.CurrentSerial(part.Partnumber)
                                        If current_serial = "" Then
                                            'REGISTRAR LA CANTIDAD RESTANTE NO DESCONTADA
                                            Log(String.Format("{0}|{1}|{2}|{3}|{4}", MoverID, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc")), "Smk_MoverDiscount_MissingStock")
                                            missing_tranferences.Rows.Add(MoverID, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc"))
                                        End If
                                    End If
                                    serial = Nothing
                                End While
                            End If
                        Else
                            missing_tranferences.Rows.Add(MoverID, part.Partnumber, discount_qty, discount_uom, type_row("TransferToSloc"))
                        End If
                    End If
                Next
                Delta.Alert(SQL.Current.GetString("Username", "Ord_Movers", "ID", MoverID, ""), String.Format("Mover ID {0} surtido.", MoverID))
                SQL.Current.Execute(String.Format("UPDATE Ord_Movers SET Status = 'P', PickedUpDate= GETDATE(), PickedUpUsername = '{0}' WHERE ID = {1};", User.Current.Username, MoverID))
                Partnumbers.Clear()
                MoverID = 0
                ID_txt.Clear()
                ID_txt.Enabled = True
                ID_txt.Focus()

                If missing_tranferences.Rows.Count > 0 Then
                    FlashAlerts.ShowError("Algunos numeros de parte del mover no pudieron ser transferidos. Guarde el siguiente documento para transferirlos manualmente.", 3, True)
                    While Not MyExcel.SaveAs(missing_tranferences, "Transferencias No Realizadas", False)

                    End While
                Else
                    FlashAlerts.ShowConfirm("Mover surtido correctamente.")
                End If
            End If
        End If
    End Sub

    Private Function Convert(quantity As Decimal, from_uom As String, to_uom As String) As Decimal
        If from_uom = to_uom Then
            Return quantity
        ElseIf from_uom = "M" AndAlso to_uom = "FT" Then
            Return quantity / 0.3048
        ElseIf from_uom = "FT" AndAlso to_uom = "M" Then
            Return quantity * 0.3048
        ElseIf from_uom = "KG" AndAlso to_uom = "LB" Then
            Return quantity / 0.453592
        ElseIf from_uom = "LB" AndAlso to_uom = "KG" Then
            Return quantity * 0.453592
        Else
            'LAS UNIDADES NO SON DEL MISMO TIPO
            Return 0
        End If
    End Function

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Find_btn.Enabled = True
        MoverID = 0
        If Partnumbers IsNot Nothing Then Partnumbers.Clear()

        ID_txt.Clear()
        ID_txt.Enabled = True
        ID_txt.Focus()
    End Sub

    Private Sub Parts_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Parts_dgv.DataError
        e.Cancel = True
    End Sub
End Class