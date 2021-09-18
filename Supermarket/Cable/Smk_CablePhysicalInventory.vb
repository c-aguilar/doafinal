Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CablePhysicalInventory
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
        Partnumber_txt.Focus()
    End Sub

    Private Sub ReadCommand()
        If Partnumber IsNot Nothing AndAlso Partnumber.WeightOnGr > 0 Then
            If _scale.IsStable Then
                Dim newWeight As Decimal = _scale.NewValue - ContainerWeight - DollyWeight
                Dim qty As Double = Math.Round(newWeight / (Partnumber.WeightOnGr / 1000), 3)
                If newWeight > 0 Then
                    If qty > 0 Then
                        If SQL.Current.Insert("Smk_Serials", {"Partnumber", "Quantity", "UoM", "ContainerID", "RedTag", "Critical", "Scanner", "Location", "Badge", "New", "Status", "Weight"}, {Partnumber.Partnumber, qty, "M", ContainerID, 0, 0, 0, RawMaterial.GetServiceLocation(Partnumber.Partnumber, My.Settings.Warehouse), User.Current.Badge, 0, "O", newWeight}) Then
                            Dim serial_str As String = SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "UoM", "Warehouse", "Scanner", "ContainerID", "Badge", "New", "Status", "Weight"}, {Partnumber.Partnumber, "M", My.Settings.Warehouse, 0, ContainerID, User.Current.Badge, 0, "O", newWeight}, "ID DESC", "")
                            REC.PrintLabel(serial_str)
                            Partnumber = Nothing
                            Command_txt.Clear()
                            Partnumber_txt.Clear()
                            Partnumber_txt.Focus()
                            FlashAlerts.ShowConfirm("Serie generada correctamente.")
                        Else
                            FlashAlerts.ShowError("Error al intentar generar al serie.")
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
            Partnumber_txt.Clear()
            Partnumber_txt.Focus()
            FlashAlerts.ShowError("Numero de parte no encontrado.")
        End If
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Partnumber_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            If Partnumber IsNot Nothing Then
                Partnumber_txt.Text = Partnumber.Partnumber
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
            End If
        ElseIf SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            ReadPartnumber()
        End If
    End Sub

    Private Sub ReadPartnumber()
        Partnumber = New RawMaterial(Partnumber_txt.Text)
        If Partnumber.Exist Then
            Partnumber_pb.Image = My.Resources.tick_32
            Command_txt.Focus()
        Else
            Partnumber_pb.Image = My.Resources.ajax_loader_gray_512
            Partnumber_txt.Clear()
            Partnumber_txt.Focus()
            FlashAlerts.ShowError("El numero de parte no existe.")
            Partnumber = Nothing
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
        If Partnumber Is Nothing Then
            Partnumber_txt.Clear()
            Partnumber_txt.Focus()
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

    Private Sub Partnumber_txt_Validated(sender As Object, e As EventArgs) Handles Partnumber_txt.Validated
        If Partnumber_txt.Text <> "" AndAlso SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            If Partnumber IsNot Nothing AndAlso Partnumber.Partnumber <> Partnumber_txt.Text Then
                ReadPartnumber()
            Else
                Command_txt.Clear()
            End If
        Else
            If Partnumber IsNot Nothing Then
                Partnumber_txt.Text = Partnumber.Partnumber
            Else
                Partnumber_txt.Clear()
            End If
        End If
    End Sub
End Class