Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CableRandomToService
    Public Property Serial As Serialnumber
    Dim Weight As Decimal = 0.0
    Dim ContainerWeight As Decimal
    Dim ContainerID As String
    Dim DollyWeight As Decimal
    Dim DollyID As String
    Dim _scale As New Scale

    Private Sub Smk_CableRandomToService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectContainer(True)
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        _scale.StartReading()
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.LimeGreen
            Command_txt.WaterMarkText = "Confirme el peso..."
        ElseIf _scale.IsReading Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.Maroon
            Command_txt.WaterMarkText = "Espere..."
        ElseIf _scale.IsError Then
            If IsNumeric(Weight_txt.Text) Then
                _scale.NewValue = CDec(Weight_txt.Text) 'PARA PERMITIR QUE EL USUARIO ESCRIBA EL PESO CUANDO LA BASCULA NO FUNCIONE
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.LimeGreen
            Else
                _scale.NewValue = 0
                Weight_txt.ForeColor = Color.White
                Weight_txt.BackColor = Color.Maroon
            End If
        Else
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.DimGray
            Weight_txt.BackColor = Color.Maroon
        End If
        Application.DoEvents()
    End Sub

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
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
        End If
    End Sub

    Private Sub ReadCommand()
        If _scale.IsStable AndAlso Serial IsNot Nothing Then
            Dim newWeight As Decimal = _scale.NewValue - ContainerWeight - DollyWeight
            If newWeight > 0 Then
                If Not SupermarketCable.ReturnBadge() Then
                    FlashAlerts.ShowError("Debes escanear tu gafete.")
                Else
                    If Serial.Warehouse <> My.Settings.Warehouse Then
                        Serial.TransferRandom(RawMaterial.GetServiceLocation(Serial.Partnumber, My.Settings.Warehouse), My.Settings.Warehouse, SupermarketCable.CurrentBadge)
                    End If
                    If Serial.RandomToService(newWeight, SupermarketCable.CurrentBadge, ContainerID) Then
                        FlashAlerts.ShowConfirm("Entrada registrada.")
                        Me.Close()
                    Else
                        FlashAlerts.ShowError("Error al registrar la entrada.")
                    End If
                End If
            Else
                FlashAlerts.ShowError(String.Format("El peso del barril no puede ser menor o igual a cero.{0}Comprueba el funcionamiento de la bascula.", vbCrLf))
            End If
        Else
            FlashAlerts.ShowInformation("Espere a que estabilice la bascula...")
        End If
    End Sub

    Private Sub Smk_CableRandomToService_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub


    Private Sub Serial_txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Serial_txt.Validated
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

    Private Sub Clean()
        Serial = Nothing
        Serial_txt.Clear()
        Serial_txt.Focus()
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If Serial_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Serial_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            If Serial IsNot Nothing Then
                Serial_txt.Text = Serial.SerialNumber
                Command_txt.Focus()
            Else
                Clean()
            End If
        ElseIf SMK.IsSerialFormat(Serial_txt.Text) Then
            ReadSerial()
        End If
    End Sub

    Public Sub ReadSerial()
        If Serial_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Serial_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            If Serial IsNot Nothing Then
                Serial_txt.Text = Serial.SerialNumber
                Command_txt.Focus()
            Else
                Clean()
            End If
        ElseIf Serial_txt.Text <> "" Then
            Serial = New Serialnumber(Serial_txt.Text)
            If Serial.Exists Then
                If Serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowError("Serie bloqueada por Calidad.")
                ElseIf Serial.InvoiceTrouble Then
                    Log(Serial.SerialNumber, "Smk_TryOpenSerialOnTracker", "DeltaERP")
                    Clean()
                    FlashAlerts.ShowError("Serie se encuentra en Tracker de Problemas.")
                ElseIf Serial.Status = Serialnumber.SerialStatus.Stored Then
                    If SQL.Current.Exists("Smk_CableNoReturn", "Partnumber", Serial.Partnumber) Then
                        Clean()
                        FlashAlerts.ShowError("Opción no disponible para este número de parte.")
                    Else
                        pbStatusSerie.Image = My.Resources.tick_32
                        Command_txt.Focus()
                    End If
                Else
                    Clean()
                    FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                End If
            Else
                Clean()
                FlashAlerts.ShowError("Serie no encontrada.")
            End If
        End If
    End Sub

    Private Sub Serial_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Serial_txt.Text <> "" Then
            ReadSerial()
        End If
    End Sub

    Private Sub Command_txt_TextChanged(sender As Object, e As EventArgs) Handles Command_txt.TextChanged
        If Command_txt.Text = "CLOSE" Then
            Clean()
            Me.Close()
        ElseIf Command_txt.Text = "CHANGE" Then
            Command_txt.Clear()
            Command_txt.Focus()
            SelectContainer(False)
        ElseIf Command_txt.Text = "-OK-" Then
            Command_txt.Clear()
            Command_txt.Focus()
            ReadCommand()
        End If
    End Sub


    Private Sub Command_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Command_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Command_txt.Text <> "" Then
            Command_txt.Clear()
            Command_txt.Focus()
            ReadCommand()
        End If
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

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ReadCommand()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CableRandomToService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class