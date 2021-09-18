Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CableAPI
    Public Property Ticket As String
    Dim partnumber As RawMaterial
    Dim Serial As Serialnumber
    Dim ContainerWeight As Double
    Dim ContainerID As String
    Dim _scale As New Scale
    Dim initial_folio As Integer = 0
    Private Sub frmRandomToServ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        initial_folio = SQL.Current.GetScalar("InitialFolio", "Smk_APITickets", "Ticket", Ticket, 1)
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.LimeGreen
            If Partnumber IsNot Nothing AndAlso Partnumber.WeightOnGr > 0 Then
                txtQty.Text = String.Format("{0} M", Math.Round((_scale.NewValue - ContainerWeight) / (partnumber.WeightOnGr / 1000), 2))
            Else
                txtQty.Text = "indefinido"
            End If
            Command_txt.WaterMarkText = "Confirme el peso..."
        ElseIf _scale.IsReading Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.Maroon
            Command_txt.WaterMarkText = "Espere..."
            txtQty.Text = String.Format("{0} M", 0)
        ElseIf _scale.IsError Then
            If IsNumeric(Weight_txt.Text) Then
                _scale.NewValue = CDec(Weight_txt.Text) 'PARA PERMITIR QUE EL USUARIO ESCRIBA EL PESO CUANDO LA BASCULA NO FUNCIONE
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.LimeGreen
                If Partnumber IsNot Nothing AndAlso Partnumber.WeightOnGr > 0 Then
                    txtQty.Text = String.Format("{0} M", Math.Round((_scale.NewValue - ContainerWeight) / (partnumber.WeightOnGr / 1000), 2))
                Else
                    txtQty.Text = "indefinido"
                End If
            Else
                _scale.NewValue = 0
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.Maroon
                txtQty.Text = String.Format("{0} M", 0)
            End If
        Else
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.DimGray
            Weight_txt.BackColor = Color.Maroon
            txtQty.Text = String.Format("{0} M", 0)
        End If
        Application.DoEvents()
    End Sub

    Private Sub SelectContainer(close_if_cancel As Boolean)
        Dim background As New FadeBackground()
        Dim new_tara As New Smk_CableSelectTara
        new_tara.Width = Screen.PrimaryScreen.Bounds.Width - 50
        new_tara.Height = Screen.PrimaryScreen.Bounds.Height - 50
        new_tara.ContainerClass = "api-containers"
        background.Show()
        If new_tara.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ContainerID = new_tara.ContainerID
            ContainerWeight = new_tara.ContainerWeight
            new_tara.Dispose()
            Container_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", ContainerID, My.Resources.No_image_available)
            TaraName_lbl.Text = SQL.Current.GetString("Name", "Smk_Containers", "ID", ContainerID, "")
            lblTaraWeight.Text = "Peso total: " & ContainerWeight & " Kg."
            background.Close()
            background.Dispose()
        ElseIf close_if_cancel Then
            _scale.StopReading()
            new_tara.Dispose()
            background.Close()
            background.Dispose()
            Me.Close()
        Else
            new_tara.Dispose()
            background.Close()
            background.Dispose()
        End If
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub ReadCommand()
        If Partnumber IsNot Nothing AndAlso Partnumber.WeightOnGr > 0 Then
            If _scale.IsStable Then
                Dim newWeight As Decimal = _scale.NewValue - ContainerWeight
                Dim qty As Decimal = Math.Round(newWeight / (partnumber.WeightOnGr / 1000), 3)
                If newWeight > 0 Then
                    If qty > 0 Then
                        If Serial.UoM = RawMaterial.UnitOfMeasure.FT Then
                            If Serial.APIAdjust(qty / 0.3048, newWeight, ContainerID) Then
                                InsertFolio()
                            Else
                                FlashAlerts.ShowError("Error al registrar la información.")
                            End If
                        ElseIf Serial.UoM = RawMaterial.UnitOfMeasure.M Then
                            If Serial.APIAdjust(qty, newWeight, ContainerID) Then
                                InsertFolio()
                            Else
                                FlashAlerts.ShowError("Error al registrar la información.")
                            End If
                        ElseIf Serial.UoM = RawMaterial.UnitOfMeasure.KG Then
                            If Serial.APIAdjust(newWeight, newWeight, ContainerID) Then
                                InsertFolio()
                            Else
                                FlashAlerts.ShowError("Error al registrar la información.")
                            End If
                        ElseIf Serial.UoM = RawMaterial.UnitOfMeasure.LB Then
                            If Serial.APIAdjust(newWeight / 0.453592, newWeight, ContainerID) Then
                                InsertFolio()
                            Else
                                FlashAlerts.ShowError("Error al registrar la información.")
                            End If
                        Else
                            FlashAlerts.ShowError("Unidad de medida no especificada en la Serie.")
                        End If
                    Else
                        FlashAlerts.ShowError("La cantidad pesada debe ser mayor a 0 metros.")
                    End If
                Else
                    FlashAlerts.ShowError(String.Format("El peso del barril no puede ser menor o igual a cero.{0}Comprueba el funcionamiento de la bascula.", vbCrLf), 4)
                End If
            Else
                FlashAlerts.ShowInformation("Espere a que estabilice la bascula...")
            End If
        Else
            Command_txt.Clear()
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowError("Número de serie incorrecto.")
        End If
    End Sub

    Private Sub InsertFolio()
        Dim folio As Integer = 0
        If SQL.Current.Exists("Smk_APITicketSerials", {"Ticket", "SerialID"}, {Ticket, Serial.ID}) Then
            folio = SQL.Current.GetScalar("Consecutive", "Smk_APITicketSerials", "SerialID", Serial.ID)
            PrintLabel(folio)
            partnumber = Nothing
            Serial = Nothing
            Command_txt.Clear()
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowInformation("Folio corregido.")
        Else
            folio = SQL.Current.GetScalar("MAX(Consecutive)", "Smk_APITicketSerials", "Ticket", Ticket, 0)
            If folio = 0 Then
                folio = initial_folio
            Else
                folio += 1
            End If

            If SQL.Current.Insert("Smk_APITicketSerials", {"Ticket", "SerialID", "Consecutive"}, {Ticket, Serial.ID, folio}) Then
                PrintLabel(folio)
                partnumber = Nothing
                Serial = Nothing
                Command_txt.Clear()
                Serial_txt.Clear()
                Serial_txt.Focus()
                FlashAlerts.ShowConfirm("Folio generado.")
            Else
                FlashAlerts.ShowError("Error al registrar el folio.")
            End If
        End If

    End Sub

    Public Sub all()

        'For Each s As DataRow In SQL.Current.GetDatatable("SELECT t.[Ticket],SerialNumber,[Consecutive] FROM [Smk_APITicketSerials] as t inner join Smk_Serials as s on t.SerialID = s.ID WHERE SerialID IN (1917892,1952796) ORDER BY Consecutive ").Rows
        '    Serial = New Serialnumber(s.Item("serialnumber"))
        '    partnumber = New RawMaterial(Serial.Partnumber)
        '    PrintLabel(s.Item("consecutive"))
        '    Ticket = s.Item("ticket")
        'Next
    End Sub

    Private Sub PrintLabel(folio As String)
        _scale.StopReading()
        Dim zpl_label As String = ZPL.TryChangeResolution(My.Resources.ZPL_APILabel, 300, My.Settings.PrinterResolution)
        zpl_label = zpl_label.Replace("@serieS", Serial.SerialNumber.Substring(Serial.SerialNumber.Length - 6, 6))
        zpl_label = zpl_label.Replace("@serieO", Serial.SerialNumber.Substring(0, Serial.SerialNumber.Length - 6))
        zpl_label = zpl_label.Replace("@serie", Serial.SerialNumber)

        zpl_label = zpl_label.Replace("@qr", Alphanumeric.ToAlphanumeric(Strings.Right(Serial.SerialNumber, 10)))

        zpl_label = zpl_label.Replace("@partnumber", Serial.Partnumber)
        zpl_label = zpl_label.Replace("@date", Delta.CurrentDate.ToString("dd-MM-yy"))
        zpl_label = zpl_label.Replace("@hour", Delta.CurrentDate.ToString("HH:mm"))
        zpl_label = zpl_label.Replace("@qty", Math.Round(Serial.CurrentQuantity, 3))

        zpl_label = zpl_label.Replace("@uom", Serial.UoM.ToString)
        If Serial.Location.ToString.Length = 8 Then
            zpl_label = zpl_label.Replace("@service", String.Format("{0}-{1}-{2}-{3}", Serial.Location.Substring(0, 2), Serial.Location.Substring(2, 2), Serial.Location.Substring(4, 2), Serial.Location.Substring(6, 2)))
        Else
            zpl_label = zpl_label.Replace("@service", Serial.Location)
        End If
        zpl_label = zpl_label.Replace("@warehouse", Serial.WarehouseName)
        zpl_label = zpl_label.Replace("@description", partnumber.Description)
        zpl_label = zpl_label.Replace("@api", Parameter("SYS_APIName"))
        zpl_label = zpl_label.Replace("@ticket", Ticket)
        zpl_label = zpl_label.Replace("@folio", folio)
        zpl_label = zpl_label.Replace("@weight", Math.Round(Serial.Weight, 3) & " KG")
        ZPL.PrintTo(zpl_label, My.Settings.Printer)
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If Serial_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Serial_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            If Serial IsNot Nothing Then
                Serial_txt.Text = Serial.SerialNumber
            Else
                Serial_txt.Clear()
                Serial_txt.Focus()
            End If
        ElseIf SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub

    Private Sub ReadSerial()
        Serial = New Serialnumber(Serial_txt.Text)
        If Serial.Exists Then
            _scale.StartReading()
            partnumber = New RawMaterial(Serial.Partnumber)
            If partnumber.Type = RawMaterial.MaterialType.Cable OrElse partnumber.Type = RawMaterial.MaterialType.Calibre Then

                ContainerID = Serial.ContainerID
                ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", Serial.ContainerID)
                Container_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", ContainerID, My.Resources.No_image_available)
                TaraName_lbl.Text = SQL.Current.GetString("Name", "Smk_Containers", "ID", ContainerID, "")
                lblTaraWeight.Text = "Peso tara: " & ContainerWeight & " Kg."

                Partnumber_pb.Image = My.Resources.tick_32
                Command_txt.Focus()
            Else
                _scale.StopReading()
                Partnumber_pb.Image = My.Resources.ajax_loader_gray_512
                Serial_txt.Clear()
                Serial_txt.Focus()
                FlashAlerts.ShowError("El número de parte no es cable.")
                Serial = Nothing
            End If
        Else
            _scale.StopReading()
            Partnumber_pb.Image = My.Resources.ajax_loader_gray_512
            Serial_txt.Clear()
            Serial_txt.Focus()
            FlashAlerts.ShowError("El número de serie no existe.")
            Serial = Nothing
        End If
    End Sub

    Private Sub Command_txt_TextChanged(sender As Object, e As EventArgs) Handles Command_txt.TextChanged
        If Command_txt.Text = "CLOSE" Then
            Me.Close()
        ElseIf Command_txt.Text = "CHANGE" Then
            SelectContainer(False)
            Command_txt.Clear()
            Command_txt.Focus()
        ElseIf Command_txt.Text = "-OK-" Then
            Command_txt.Clear()
            Command_txt.Focus()
            ReadCommand()
        End If
    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ReadCommand()
    End Sub

    Private Sub Change_btn_Click(sender As Object, e As EventArgs) Handles Change_btn.Click
        SelectContainer(False)
        If Serial Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Command_txt.Clear()
            Command_txt.Focus()
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CablePhysicalInventory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serial_txt_Validated(sender As Object, e As EventArgs) Handles Serial_txt.Validated
        If Serial_txt.Text <> "" AndAlso SMK.IsSerialFormat(Serial_txt.Text) Then
            If Serial IsNot Nothing AndAlso Serial.SerialNumber <> Serial_txt.Text Then
                ReadSerial()
            Else
                Command_txt.Clear()
            End If
        Else
            If Serial IsNot Nothing Then
                Serial_txt.Text = Serial.SerialNumber
            Else
                Serial_txt.Clear()
            End If
        End If
    End Sub

    Private Sub FinalizeTicket_btn_Click(sender As Object, e As EventArgs) Handles FinalizeTicket_btn.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("SMK_User_FinalizeAPITicket_flag") Then
                SQL.Current.Update("Smk_APITickets", "Status", "1", "Ticket", Ticket)
                Me.Close()
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta accion.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub
End Class