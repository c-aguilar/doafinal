Imports System.IO.Ports
Imports System.Threading
Public Class Smk_CableRandomToCutter
    Public Serial As Serialnumber
    Dim ContainerWeight As Double
    Dim ContainerID As String
    Dim DollyWeight As Double
    Dim DollyID As String
    Dim _scale As New Scale
    Private Sub Smk_CableRandomToCutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Serial_lbl.Text = Serial.SerialNumber
        Partnumber_lbl.Text = Serial.Partnumber
        SelectContainer(True)
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        _scale.StartReading()
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.LimeGreen
            Cutter_txt.WaterMarkText = "Seleccione la cortadora..."
        ElseIf _scale.IsReading Then
            Weight_txt.Text = _scale.NewValue
            Weight_txt.ForeColor = Color.White
            Weight_txt.BackColor = Color.Maroon
            Cutter_txt.WaterMarkText = "Espere..."
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
    End Sub

    Private Sub frmToCutter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Cutter_txt.Focus()
    End Sub

    Private Sub ReadCutter()
        If _scale.IsStable Then
            Dim newWeight As Decimal = _scale.NewValue - ContainerWeight - DollyWeight
            If newWeight > 0 Then
                If SQL.Current.Exists("PE_Cutters", "ID", Cutter_txt.Text) Then
                    If Not SupermarketCable.ReturnBadge(Cutter_txt.Text) Then
                        FlashAlerts.ShowError("Debes escanear tu gafete.")
                    Else
                        If SQL.Current.Exists("Smk_CableSemiReturn", {"Partnumber", "CutterID"}, {Serial.Partnumber, Cutter_txt.Text}) Then ' Verificar que sea Semifijo
                            'BARRILES QUE SE VAN EN AUTOMATICO AL SLOC 2 EN CIERTAS MAQUINAS
                            If Serial.RandomToCutter(newWeight, Cutter_txt.Text, SupermarketCable.CurrentBadge, ContainerID) Then
                                Serial.Empty(SupermarketCable.CurrentBadge)
                                SupermarketCable.PrintEmptylLabel(Serial.SerialNumber)
                                FlashAlerts.ShowConfirm("Semifijo: Serie declarada vacia.")
                                Me.Close()
                            Else
                                FlashAlerts.ShowError("Error al registrar la salida.")
                            End If
                        ElseIf SQL.Current.Exists("Smk_CableNoReturn", "Partnumber", Serial.Partnumber) Then ' Verificar que sea barriles sin regreso
                            'BARRILES QUE SE VAN EN AUTOMATICO AL SLOC 2
                            If Serial.RandomToCutter(newWeight, Cutter_txt.Text, SupermarketCable.CurrentBadge, ContainerID) Then
                                Serial.Empty(SupermarketCable.CurrentBadge)
                                SupermarketCable.PrintEmptylLabel(Serial.SerialNumber)
                                FlashAlerts.ShowConfirm("Numero de parte directo: Serie declarada vacia.")
                                Me.Close()
                            Else
                                FlashAlerts.ShowError("Error al registrar la salida.")
                            End If
                        Else 'Barril parcial
                            If Serial.RandomToCutter(newWeight, Cutter_txt.Text, SupermarketCable.CurrentBadge, ContainerID) Then
                                FlashAlerts.ShowConfirm("Salida registrada.")
                                Me.Close()
                            Else
                                FlashAlerts.ShowError("Error al registrar la salida.")
                            End If
                        End If
                    End If
                Else
                    FlashAlerts.ShowError("La cortadora no existe.")
                End If
            Else
                FlashAlerts.ShowError(String.Format("El peso del barril no puede ser menor o igual a cero.{0}Comprueba el funcionamiento de la bascula.", vbCrLf), 5)
            End If
        Else
            FlashAlerts.ShowInformation("Espera a que se estabilice la bascula...")
        End If
    End Sub

    Private Sub frmRandomToCutter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Cutter_txt_TextChanged(sender As Object, e As EventArgs) Handles Cutter_txt.TextChanged
        If Delta.IsValidID(Cutter_txt.Text, 8) Then
            ReadCutter()
        ElseIf Cutter_txt.Text.ToUpper = "CHANGE" Then
            SelectContainer(False)
            Cutter_txt.Clear()
            Cutter_txt.Focus()
        ElseIf Cutter_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub

    Private Sub Cutter_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Cutter_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Cutter_txt.Text <> "" Then
            ReadCutter()
        End If
    End Sub

    Private Sub Change_btn_Click(sender As Object, e As EventArgs) Handles Change_btn.Click
        SelectContainer(False)
        Cutter_txt.Clear()
        Cutter_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_CableRandomToCutter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class