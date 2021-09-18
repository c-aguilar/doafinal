Imports System.IO.Ports
Imports System.Threading
Imports System.Text.RegularExpressions
Public Class Smk_PartialDiscount
    Public Property PreloadSerialnumber As Serialnumber
    Dim serial As Serialnumber

    Dim _scale As New Scale
    Dim part_weight As Decimal = 0
    Dim old_qty As Decimal = 0
    Private Sub Smk_PartialDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
            Serial_txt.ReadOnly = True
            Quantity_nud.Focus()
        End If
        _scale.StopReading()
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        Scale_chk.Checked = My.Settings.SupermarketComponentScale
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If serial IsNot Nothing AndAlso part_weight > 0 Then
            If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                Quantity_nud.Value = Math.Round((_scale.NewValue * My.Settings.SupermarketComponentScaleFactor * 1000) / part_weight, 0)
            Else
                Quantity_nud.Value = Math.Round((_scale.NewValue * My.Settings.SupermarketComponentScaleFactor * 1000) / part_weight, 3)
            End If
            Weight_lbl.Text = String.Format("{0} Kg", (_scale.NewValue * My.Settings.SupermarketComponentScaleFactor))
        End If
        If _scale.IsReading AndAlso _scale.IsStable Then
            Quantity_nud.BackColor = Color.LimeGreen
            Quantity_nud.ForeColor = Color.White
            Partial_btn.Enabled = True
        ElseIf _scale.IsReading Then
            Quantity_nud.BackColor = Color.Maroon
            Quantity_nud.ForeColor = Color.White
            Partial_btn.Enabled = False
        Else
            Quantity_nud.BackColor = Color.DimGray
            Quantity_nud.ForeColor = Color.White
            Partial_btn.Enabled = False
        End If
        Application.DoEvents()
    End Sub

    Private Sub Partial_btn_Click(sender As Object, e As EventArgs) Handles Partial_btn.Click
        If serial IsNot Nothing Then
            If Quantity_nud.Value > 0 Then
                If (Scale_chk.Checked AndAlso _scale.IsReading AndAlso _scale.IsStable) OrElse Not Scale_chk.Checked Then
                    Dim qty_discount As Decimal = RawMaterial.ConvertUoM(serial.Partnumber, UoM_cbo.SelectedItem, Quantity_nud.Value, serial.UoM.ToString) 'CONVERSION DE LA CANTIDAD A LA MISMA UNIDAD DE LA SERIE
                    Dim consumption_control = RawMaterial.GetMfgConsumptionControlType(serial.Partnumber)
                    If consumption_control <> RawMaterial.MfgConsumptionControlType.None Then
                        Dim qty_bum As Decimal = RawMaterial.ConvertUoM(serial.Partnumber, UoM_cbo.SelectedItem, Quantity_nud.Value, RawMaterial.GetUoM(serial.Partnumber).ToString) 'CONVERSION DE LA CANTIDAD A UNIDAD BASE
                        Dim qty_consumed As Decimal = 0
                        Dim qty_consumption As Decimal = RawMaterial.GetMfgConsumptionQty(serial.Partnumber)
                        Select Case consumption_control 'OBTENER EL TOTAL DE DESCUENTOS EN EL DIA, SEMANA O MES
                            Case RawMaterial.MfgConsumptionControlType.Daily
                                qty_consumed = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,M.Quantity,R.UoM)) AS Total FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Partnumber = '{0}' AND Movement in ('DER','DEY','PDR','PDT','TPD','TSE') AND M.Quantity < 0 AND CONVERT(DATE,M.[Date]) = CONVERT(DATE,GETDATE())", serial.Partnumber))
                            Case RawMaterial.MfgConsumptionControlType.Weekly
                                qty_consumed = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,M.Quantity,R.UoM)) AS Total FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Partnumber = '{0}' AND Movement in ('DER','DEY','PDR','PDT','TPD','TSE') AND M.Quantity < 0 AND DATEPART(WEEK,M.[Date]) = DATEPART(WEEK,GETDATE()) = AND DATEPART(YEAR,M.[Date]) = DATEPART(YEAR,GETDATE())", serial.Partnumber))
                            Case RawMaterial.MfgConsumptionControlType.Monthly
                                qty_consumed = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,M.Quantity,R.UoM)) AS Total FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE S.Partnumber = '{0}' AND Movement in ('DER','DEY','PDR','PDT','TPD','TSE') AND M.Quantity < 0 AND DATEPART(MONTH,M.[Date]) = DATEPART(MONTH,GETDATE()) = AND DATEPART(YEAR,M.[Date]) = DATEPART(YEAR,GETDATE())", serial.Partnumber))
                        End Select

                        If Math.Abs(qty_consumed) + qty_bum > qty_consumption Then 'COMPARAR SI YA SE PASO DEL LIMITE DIARIO, SEMANAL O MENSUAL
                            Dim new_qty_consumption As Decimal = 0
                            Select Case consumption_control
                                Case RawMaterial.MfgConsumptionControlType.Daily
                                    'BUSCAR SI HAY UN PERMISO POR PARTE DEL MRPCONTROLLER PARA USAR MAS
                                    new_qty_consumption = SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()) ORDER BY [Date] DESC", serial.Partnumber))
                                    If Math.Abs(qty_consumed) + qty_bum > new_qty_consumption Then
                                        FlashAlerts.ShowError(String.Format("La cantidad excede el consumo permitido por día.{2}Restante para hoy: {0} {1}", Math.Max(0, Math.Max(qty_consumption, new_qty_consumption) + qty_consumed), RawMaterial.GetUoM(serial.Partnumber).ToString, vbCrLf), 3, True)
                                        Exit Sub
                                    End If
                                Case RawMaterial.MfgConsumptionControlType.Weekly
                                    'BUSCAR SI HAY UN PERMISO POR PARTE DEL MRPCONTROLLER PARA USAR MAS
                                    new_qty_consumption = SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND DATEPART(WEEK,[Date]) = DATEPART(WEEK,GETDATE()) AND DATEPART(YEAR,[Date]) = DATEPART(YEAR,GETDATE()) ORDER BY [Date] DESC", serial.Partnumber))
                                    If Math.Abs(qty_consumed) + qty_bum > new_qty_consumption Then
                                        FlashAlerts.ShowError(String.Format("La cantidad excede el consumo permitido por semana.{2}Restante para esta semana: {0} {1}", Math.Max(0, Math.Max(qty_consumption, new_qty_consumption) + qty_consumed), RawMaterial.GetUoM(serial.Partnumber).ToString, vbCrLf), 3, True)
                                        Exit Sub
                                    End If
                                Case RawMaterial.MfgConsumptionControlType.Monthly
                                    'BUSCAR SI HAY UN PERMISO POR PARTE DEL MRPCONTROLLER PARA USAR MAS
                                    new_qty_consumption = SQL.Current.GetScalar(String.Format("SELECT TOP 1 NewQuantity FROM Ord_MfgConsumptionIncrease WHERE Partnumber = '{0}' AND DATEPART(MONTH,[Date]) = DATEPART(MONTH,GETDATE()) AND DATEPART(YEAR,[Date]) = DATEPART(YEAR,GETDATE()) ORDER BY [Date] DESC", serial.Partnumber))
                                    If Math.Abs(qty_consumed) + qty_bum > new_qty_consumption Then
                                        FlashAlerts.ShowError(String.Format("La cantidad excede el consumo permitido por mes.{2}Restante para este mes: {0} {1}", Math.Max(0, Math.Max(qty_consumption, new_qty_consumption) + qty_consumed), RawMaterial.GetUoM(serial.Partnumber).ToString, vbCrLf), 3, True)
                                        Exit Sub
                                    End If
                            End Select
                        End If
                    End If

                    If qty_discount < serial.CurrentQuantity Then
                        If UoM_cbo.SelectedItem = "PC" OrElse UoM_cbo.SelectedItem = "ROL" Then
                            If Math.Truncate(Quantity_nud.Value) = Quantity_nud.Value Then
                                'VALIDACION PARA QUITAR DECIMALES RESTANTES POR CUESTION DEL FACTOR DE CONVERSION
                                If UoM_cbo.SelectedItem <> serial.UoM.ToString AndAlso serial.CurrentQuantity - qty_discount < 1 Then 'SE TERMINO EL CONTENEDOR
                                    If serial.Empty() Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Cantidad descontada correctamente. Se declaro vacio el contenedor.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al descontar la cantidad.")
                                    End If
                                Else
                                    If serial.PartialDiscount(qty_discount) Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Cantidad descontada correctamente.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al descontar la cantidad.")
                                    End If
                                End If
                            Else
                                FlashAlerts.ShowError("Cantidad incorrecta. Especifique cantidades enteras.")
                            End If
                        Else
                            If serial.PartialDiscount(qty_discount) Then
                                Clean()
                                FlashAlerts.ShowConfirm("Cantidad descontada correctamente.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                FlashAlerts.ShowError("Error al descontar la cantidad.")
                            End If
                        End If
                    ElseIf qty_discount = serial.CurrentQuantity OrElse (qty_discount > serial.CurrentQuantity AndAlso UoM_cbo.SelectedItem <> serial.UoM.ToString AndAlso qty_discount - serial.CurrentQuantity < 1) Then 'ES LO RESTANTE DEL CONTENEDOR O SE PASA DECIMALES POR CUESTION DEL FACTOR DE CONVERSION
                        If serial.Empty() Then
                            Clean()
                            FlashAlerts.ShowConfirm("Cantidad descontada correctamente. Se declaro vacio el contenedor.", , Not IsNothing(PreloadSerialnumber))
                        Else
                            FlashAlerts.ShowError("Error al descontar la cantidad.")
                        End If
                    Else
                        If UoM_cbo.SelectedItem <> serial.UoM.ToString Then
                            FlashAlerts.ShowError(String.Format("El descuento debe ser menor a la cantidad actual.{0}{1} {2} corresponden a {3} {4}.", vbCrLf, Quantity_nud.Value, UoM_cbo.SelectedItem, qty_discount, serial.UoM.ToString), 2)
                        Else
                            FlashAlerts.ShowError(String.Format("El descuento debe ser menor a la cantidad actual.{0}La serie contiene {1} {2}.", vbCrLf, serial.CurrentQuantity, serial.UoM.ToString), 2)
                        End If
                    End If
                Else
                    FlashAlerts.ShowError("Espera a que la bascula se estabilice.")
                End If
            End If
        End If
    End Sub

    Private Sub ReadSerialnumber()
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            Dim serial_str As String = Serial_txt.Text
            If SMK.IsLinkSerialFormat(serial_str) Then
                serial_str = SQL.Current.GetString("Serialnumber", "vw_Smk_Serials", "Linklabel", serial_str, "")
                If serial_str = "" Then
                    Clean()
                    FlashAlerts.ShowError("La arteza no esta enlazada a ninguna serie.")
                    Exit Sub
                End If
            End If

            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(serial_str)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exists Then
                If serial.Type = RawMaterial.MaterialType.Cable Then
                    Clean()
                    FlashAlerts.ShowError("Opción no disponible para este número de parte.")
                Else
                    If serial.RedTag Then
                        Clean()
                        FlashAlerts.ShowError("Serie bloqueada por calidad.", , Not IsNothing(PreloadSerialnumber))
                    ElseIf serial.InvoiceTrouble Then
                        Log(serial.SerialNumber, "Smk_TryPartialDiscountSerialOnTracker")
                        Clean()
                        FlashAlerts.ShowError("La serie se encuentra en el Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                    Else
                        If serial.Consumption = RawMaterial.ConsumptionType.Partial OrElse serial.Consumption = RawMaterial.ConsumptionType.Mixed OrElse serial.Consumption = RawMaterial.ConsumptionType.Service OrElse serial.Consumption = RawMaterial.ConsumptionType.Obsolete OrElse serial.Consumption = RawMaterial.ConsumptionType.CAO Then
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality
                                    CurrentQuantity_lbl.Text = String.Format("{0} {1}", serial.CurrentQuantity, serial.UoM)
                                    If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                        UoM_cbo.Items.Clear()
                                        UoM_cbo.Items.Add(serial.UoM.ToString)
                                    Else
                                        Dim uoms As ArrayList = RawMaterial.GetUoMOptions(serial.Partnumber)
                                        If Not uoms.Contains(serial.UoM.ToString) Then uoms.Add(serial.UoM.ToString)
                                        UoM_cbo.Items.Clear()
                                        UoM_cbo.Items.AddRange(uoms.ToArray)
                                    End If

                                    Partnumber_lbl.Text = serial.Partnumber
                                    Description_lbl.Text = RawMaterial.GetDescription(serial.Partnumber)
                                    Quantity_nud.Focus()
                                    part_weight = RawMaterial.GetWeight(serial.Partnumber)
                                    If Scale_chk.Checked Then
                                        UoM_cbo.Enabled = False
                                        UoM_cbo.SelectedItem = RawMaterial.GetStrUoM(serial.Partnumber)
                                        _scale.StartReading()
                                    Else
                                        UoM_cbo.Enabled = True
                                        UoM_cbo.SelectedItem = serial.UoM.ToString
                                    End If
                                Case Serialnumber.SerialStatus.Stored
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido abierta.", , Not IsNothing(PreloadSerialnumber))
                                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Presupermarket
                                    Clean()
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                                Case Serialnumber.SerialStatus.Empty
                                    Clean()
                                    FlashAlerts.ShowError("La serie se encuentra declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                            End Select
                        Else
                            FlashAlerts.ShowError("El número de parte no es de consumo parcial.")
                        End If
                    End If
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.")
            End If
        Else
            Clean()
            FlashAlerts.ShowError("Serie incorrecta.", , Not IsNothing(PreloadSerialnumber))
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            serial = Nothing
            CurrentQuantity_lbl.Text = "-"
            Quantity_nud.Value = 1
            Serial_txt.Clear()
            Serial_txt.Focus()
            Partnumber_lbl.Text = "-"
            Description_lbl.Text = "-"
            Weight_lbl.Text = ""
            part_weight = 0
            UoM_cbo.Enabled = True
            Quantity_nud.BackColor = Color.Ivory
            Quantity_nud.ForeColor = Color.Black
            Partial_btn.Enabled = True
            NoWeight_lbl.Visible = False
            _scale.StopReading()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_PartialDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        serial = Nothing
        CurrentQuantity_lbl.Text = "-"
        Quantity_nud.Value = 1
        Partnumber_lbl.Text = "-"
        Description_lbl.Text = "-"
        Weight_lbl.Text = ""
        part_weight = 0
        NoWeight_lbl.Visible = False
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            ReadSerialnumber()
            If serial IsNot Nothing AndAlso part_weight = 0 Then NoWeight_lbl.Visible = True
        End If
    End Sub

    Private Sub Scale_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Scale_chk.CheckedChanged
        If Scale_chk.Checked AndAlso serial IsNot Nothing Then
            _scale.StartReading()
            If part_weight = 0 Then NoWeight_lbl.Visible = True Else NoWeight_lbl.Visible = False
        ElseIf Not Scale_chk.Checked Then
            _scale.StopReading()
            UoM_cbo.Enabled = True
            Quantity_nud.BackColor = Color.Ivory
            Quantity_nud.ForeColor = Color.Black
            Partial_btn.Enabled = True
            NoWeight_lbl.Visible = False
        End If
        My.Settings.SupermarketComponentScale = Scale_chk.Checked
        My.Settings.Save()
        Quantity_nud.Enabled = Not Scale_chk.Checked
    End Sub

    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles Settings_btn.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("Supermarket_CableScaleSettings_Change_flag") Then
                Clean()
                Dim settings As New Smk_SmkSettings
                settings.ShowDialog()
                settings.Dispose()
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub

    Private Sub Sample_btn_Click(sender As Object, e As EventArgs) Handles Sample_btn.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("Supermarket_SamplesWeight_Edit_flag") Then
                Clean()
                Dim new_sample As New Smk_SamplesWeight
                new_sample.ShowDialog()
                new_sample.Dispose()
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub

    Private Sub Smk_PartialDiscount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Quantity_nud_ValueChanged(sender As Object, e As EventArgs) Handles Quantity_nud.ValueChanged

    End Sub

End Class