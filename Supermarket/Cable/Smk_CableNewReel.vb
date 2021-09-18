Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CableNewReel
    Dim Serial As Serialnumber
    Dim Partnumber As RawMaterial
    Dim ContainerWeight As Double
    Dim ContainerID As String
    Dim DollyWeight As Double
    Dim DollyID As String
    Dim _scale As New Scale
    Private Sub frmRandomToServ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectContainer(True)
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        _scale.StartReading()
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.LimeGreen
            If Partnumber IsNot Nothing AndAlso Partnumber.WeightOnGr > 0 Then
                txtQty.Text = String.Format("{0} M", Math.Round((_scale.NewValue - DollyWeight - ContainerWeight) / (Partnumber.WeightOnGr / 1000), 2))
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
                    txtQty.Text = String.Format("{0} M", Math.Round((_scale.NewValue - DollyWeight - ContainerWeight) / (Partnumber.WeightOnGr / 1000), 2))
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
        new_tara.ContainerClass = "containers"
        background.Show()
        If new_tara.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ContainerID = new_tara.ContainerID
            ContainerWeight = new_tara.ContainerWeight
            DollyID = new_tara.DollyID
            DollyWeight = new_tara.DollyWeight
            new_tara.Dispose()
            Dolly_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", DollyID, My.Resources.No_image_available)
            Container_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", ContainerID, My.Resources.No_image_available)
            lblTaraWeight.Text = "Peso total: " & ContainerWeight + DollyWeight & " Kg."
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
        Serialnumber_txt.Focus()
    End Sub

    Private Sub ReadCommand()
        If Serial IsNot Nothing Then
            If _scale.IsStable Then
                Dim newWeight As Decimal = _scale.NewValue - ContainerWeight - DollyWeight
                Dim qty As Double = Math.Round(newWeight / (Partnumber.WeightOnGr / 1000), 3)
                If qty > 0 Then
                    If SupermarketCable.ReturnBadge() Then
                        If Serial.UoM = RawMaterial.UnitOfMeasure.FT OrElse Serial.UoM = RawMaterial.UnitOfMeasure.M Then
                            If Serial.UoM = RawMaterial.UnitOfMeasure.FT Then qty = qty / 0.3048
                            If qty >= Serial.CurrentQuantity Then
                                If MessageBox.Show("La cantidad del carrete es mayor a la del barril. ¿Deseas declarar el barril como vacio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    If SQL.Current.Insert("Smk_Serials", {"Partnumber", "Quantity", "UoM", "ContainerID", "RedTag", "Critical", "Scanner", "Location", "Warehouse", "Badge", "New", "Status", "Weight"}, {Serial.Partnumber, Serial.CurrentQuantity, Serial.UoM.ToString, ContainerID, 0, 0, 0, RawMaterial.GetServiceLocation(Serial.Partnumber, Serial.Warehouse), Serial.Warehouse, SupermarketCable.CurrentBadge, 0, "O", newWeight}) Then
                                        Serial.DiscountByRewind(Serial.CurrentQuantity, SupermarketCable.CurrentBadge)
                                        Serial.Empty(SupermarketCable.CurrentBadge)
                                        REC.PrintLabel(SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "UoM", "Warehouse", "ContainerID", "RedTag", "Critical", "Scanner", "New", "Status"}, {Serial.Partnumber, Serial.UoM.ToString, Serial.Warehouse, ContainerID, 0, 0, 0, 0, "O"}, "ID DESC", ""))
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie generada correctamente.")
                                    Else
                                        FlashAlerts.ShowError("Error al intentar generar al serie.")
                                    End If
                                Else
                                    Clean()
                                    FlashAlerts.ShowError("Operación cancelada.")
                                End If
                            Else
                                If SQL.Current.Insert("Smk_Serials", {"Partnumber", "Quantity", "UoM", "ContainerID", "RedTag", "Critical", "Scanner", "Location", "Warehouse", "Badge", "New", "Status", "Weight"}, {Serial.Partnumber, qty, Serial.UoM.ToString, ContainerID, 0, 0, 0, RawMaterial.GetServiceLocation(Serial.Partnumber, Serial.Warehouse), Serial.Warehouse, SupermarketCable.CurrentBadge, 0, "O", newWeight}) Then
                                    Serial.DiscountByRewind(qty, SupermarketCable.CurrentBadge)
                                    REC.PrintLabel(SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "UoM", "Warehouse", "ContainerID", "RedTag", "Critical", "Scanner", "New", "Status"}, {Serial.Partnumber, Serial.UoM.ToString, Serial.Warehouse, ContainerID, 0, 0, 0, 0, "O"}, "ID DESC", ""))
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie generada correctamente.")
                                Else
                                    FlashAlerts.ShowError("Error al intentar generar al serie.")
                                End If
                            End If
                        ElseIf Serial.UoM = RawMaterial.UnitOfMeasure.KG OrElse Serial.UoM = RawMaterial.UnitOfMeasure.LB Then
                            If Serial.UoM = RawMaterial.UnitOfMeasure.LB Then newWeight = newWeight / 0.453592
                            If newWeight >= Serial.CurrentQuantity Then
                                If MessageBox.Show("La cantidad del carrete es mayor a la del barril. ¿Deseas declarar el barril como vacio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    If SQL.Current.Insert("Smk_Serials", {"Partnumber", "Quantity", "UoM", "ContainerID", "RedTag", "Critical", "Scanner", "Location", "Badge", "New", "Status", "Weight"}, {Serial.Partnumber, Serial.CurrentQuantity, Serial.UoM.ToString, ContainerID, 0, 0, 0, RawMaterial.GetServiceLocation(Serial.Partnumber, Serial.Warehouse), SupermarketCable.CurrentBadge, 0, "O", If(Serial.UoM = RawMaterial.UnitOfMeasure.M, Serial.CurrentQuantity, Serial.CurrentQuantity * 0.453592)}) Then
                                        Serial.DiscountByRewind(Serial.CurrentQuantity, SupermarketCable.CurrentBadge)
                                        Serial.Empty(SupermarketCable.CurrentBadge)
                                        REC.PrintLabel(SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "UoM", "Warehouse", "ContainerID", "RedTag", "Critical", "Scanner", "New", "Status"}, {Serial.Partnumber, Serial.UoM.ToString, Serial.Warehouse, ContainerID, 0, 0, 0, 0, "O"}, "ID DESC", ""))
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie generada correctamente.")
                                    Else
                                        FlashAlerts.ShowError("Error al intentar generar al serie.")
                                    End If
                                Else
                                    Clean()
                                    FlashAlerts.ShowError("Operación cancelada.")
                                End If
                            Else
                                If SQL.Current.Insert("Smk_Serials", {"Partnumber", "Quantity", "UoM", "ContainerID", "RedTag", "Critical", "Scanner", "Location", "Badge", "New", "Status", "Weight"}, {Serial.Partnumber, newWeight, Serial.UoM.ToString, ContainerID, 0, 0, 0, RawMaterial.GetServiceLocation(Serial.Partnumber, Serial.Warehouse), SupermarketCable.CurrentBadge, 0, "O", If(Serial.UoM = RawMaterial.UnitOfMeasure.M, newWeight, newWeight * 0.453592)}) Then
                                    Serial.DiscountByRewind(newWeight, SupermarketCable.CurrentBadge)
                                    REC.PrintLabel(SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "UoM", "Warehouse", "ContainerID", "RedTag", "Critical", "Scanner", "New", "Status"}, {Serial.Partnumber, Serial.UoM.ToString, Serial.Warehouse, ContainerID, 0, 0, 0, 0, "O"}, "ID DESC", ""))
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie generada correctamente.")
                                Else
                                    FlashAlerts.ShowError("Error al intentar generar al serie.")
                                End If
                            End If
                        End If
                    Else
                        FlashAlerts.ShowError("Debes escanear tu gafete.")
                    End If
                Else
                    FlashAlerts.ShowError("La cantidad pesada debe ser mayor a 0 metros.")
                End If
            Else
                FlashAlerts.ShowInformation("Espere a que estabilice la bascula...")
            End If
        Else
            Command_txt.Clear()
            Serialnumber_txt.Clear()
            Serialnumber_txt.Focus()
            FlashAlerts.ShowError("Número de parte no encontrado.")
        End If
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Serialnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Serialnumber_txt.TextChanged
        If Serialnumber_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Serialnumber_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            If Serial IsNot Nothing Then
                Serialnumber_txt.Text = Serial.SerialNumber
                Command_txt.Clear()
                Command_txt.Focus()
            Else
                Serialnumber_txt.Clear()
                Serialnumber_txt.Focus()
            End If
        ElseIf SMK.IsSerialFormat(Serialnumber_txt.Text) Then
            If Serial IsNot Nothing AndAlso Serialnumber_txt.Text = Serial.SerialNumber Then
                Command_txt.Clear()
                Command_txt.Focus()
            Else
                ReadSerial()
            End If
        End If
    End Sub

    Private Sub ReadSerial()
        Serial = New Serialnumber(Serialnumber_txt.Text)
        If Serial.Exists Then
            If Serial.Type = RawMaterial.MaterialType.Cable Then
                If Serial.InvoiceTrouble Then
                    Clean()
                    FlashAlerts.ShowError("Serie en Tracker de Problemas")
                ElseIf Serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por Calidad.")
                Else
                    Select Case Serial.Status
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowError("Serie declarada vacia.")
                        Case Serialnumber.SerialStatus.Stored
                            Select Case Serial.UoM
                                Case RawMaterial.UnitOfMeasure.M, RawMaterial.UnitOfMeasure.FT
                                    Partnumber = New RawMaterial(Serial.Partnumber)
                                    If Partnumber.WeightOnGr > 0 Then
                                        Partnumber_pb.Image = My.Resources.tick_32
                                        CurrentQty_lbl.Text = String.Format("{0} {1}", Serial.CurrentQuantityInBum, Partnumber.UoM)
                                        Command_txt.Clear()
                                        Command_txt.Focus()
                                    Else
                                        Clean()
                                        FlashAlerts.ShowError("El factor de conversion del numero de parte debe ser mayor a cero.")
                                    End If
                                Case RawMaterial.UnitOfMeasure.KG, RawMaterial.UnitOfMeasure.LB
                                    Partnumber = New RawMaterial(Serial.Partnumber)
                                    Partnumber_pb.Image = My.Resources.tick_32
                                    CurrentQty_lbl.Text = String.Format("{0} {1}", Serial.CurrentQuantityInBum, Partnumber.UoM)
                                    Command_txt.Clear()
                                    Command_txt.Focus()
                                Case Else
                                    Clean()
                                    FlashAlerts.ShowError("La unidad de medida del barril no es compatible con esta opcion.")
                            End Select
                        Case Serialnumber.SerialStatus.Open
                            Select Case Serial.UoM
                                Case RawMaterial.UnitOfMeasure.M, RawMaterial.UnitOfMeasure.FT
                                    Partnumber = New RawMaterial(Serial.Partnumber)
                                    If Partnumber.WeightOnGr > 0 Then
                                        Partnumber_pb.Image = My.Resources.tick_32
                                        CurrentQty_lbl.Text = String.Format("{0} {1}", Serial.CurrentQuantityInBum, Partnumber.UoM)
                                        Command_txt.Clear()
                                        Command_txt.Focus()
                                    Else
                                        Clean()
                                        FlashAlerts.ShowError("El factor de conversion del numero de parte debe ser mayor a cero.")
                                    End If
                                Case RawMaterial.UnitOfMeasure.KG, RawMaterial.UnitOfMeasure.LB
                                    Partnumber = New RawMaterial(Serial.Partnumber)
                                    Partnumber_pb.Image = My.Resources.tick_32
                                    CurrentQty_lbl.Text = String.Format("{0} {1}", Serial.CurrentQuantityInBum, Partnumber.UoM)
                                    Command_txt.Clear()
                                    Command_txt.Focus()
                                Case Else
                                    Clean()
                                    FlashAlerts.ShowError("La unidad de medida del barril no es compatible con esta opcion.")
                            End Select
                        Case Serialnumber.SerialStatus.OnCutter
                            Clean()
                            FlashAlerts.ShowError("El barril se encuentra en una cortadora.")
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                        Case Else
                            Clean()
                            FlashAlerts.ShowError("El estatus actual de la serie no permite realizar esta operacion.")
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("El numero de parte no pertenece a Cable.")
            End If
        Else
            Clean()
            FlashAlerts.ShowError("La serie no existe.")
        End If
    End Sub

    Private Sub Command_txt_TextChanged(sender As Object, e As EventArgs) Handles Command_txt.TextChanged
        If Command_txt.Text = "CLOSE" Then
            Me.Close()
        ElseIf Command_txt.Text = "CHANGE" Then
            SelectContainer(False)
            If Serial IsNot Nothing Then
                Serialnumber_txt.Text = Serial.SerialNumber
                Command_txt.Clear()
                Command_txt.Focus()
            Else
                Serialnumber_txt.Clear()
                Serialnumber_txt.Focus()
            End If
        ElseIf Command_txt.Text = "-OK-" Then
            Command_txt.Clear()
            Command_txt.Focus()
            ReadCommand()
        End If
    End Sub

    Private Sub Clean()
        Serial = Nothing
        Partnumber = Nothing
        CurrentQty_lbl.Text = ""
        Partnumber_pb.Image = My.Resources.ajax_loader_gray_512
        Command_txt.Clear()
        Serialnumber_txt.Clear()
        Serialnumber_txt.Focus()
    End Sub

    Private Sub Change_btn_Click(sender As Object, e As EventArgs) Handles Change_btn.Click
        SelectContainer(False)
        If Serial IsNot Nothing Then
            Serialnumber_txt.Text = Serial.SerialNumber
            Command_txt.Clear()
            Command_txt.Focus()
        Else
            Serialnumber_txt.Clear()
            Serialnumber_txt.Focus()
        End If
    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ReadCommand()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CableNewReel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serialnumber_txt_Validated(sender As Object, e As EventArgs) Handles Serialnumber_txt.Validated
        If SMK.IsSerialFormat(Serialnumber_txt.Text) Then
            If Serial IsNot Nothing AndAlso Serial.SerialNumber <> Serialnumber_txt.Text Then
                ReadSerial()
            Else
                Command_txt.Clear()
            End If
        Else
            If Serial IsNot Nothing Then
                Serialnumber_txt.Text = Serial.SerialNumber
            Else
                Serialnumber_txt.Clear()
            End If
        End If
    End Sub

End Class