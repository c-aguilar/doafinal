Public Class Smk_DeclareEmpty
    Public Property PreloadSerialnumber As Serialnumber
    Private Sub Smk_DeclareEmpty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreloadSerialnumber Is Nothing Then
            Clean()
        Else
            Serial_txt.Text = PreloadSerialnumber.SerialNumber
        End If
        If User.Current.HasPermission("SMK_MasiveEmptyDeclaration") Then
            List_btn.Enabled = True
        End If
    End Sub

    Private Sub EmptySerial()
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            Dim serial_str As String = Serial_txt.Text
            Dim is_linkedserial As Boolean = False

            If SMK.IsLinkSerialFormat(serial_str) Then
                serial_str = SQL.Current.GetString("Serialnumber", "vw_Smk_Serials", "Linklabel", serial_str, "")
                If serial_str = "" Then
                    Clean()
                    FlashAlerts.ShowError("La arteza no esta enlazada a ninguna serie.")
                    Exit Sub
                Else
                    is_linkedserial = True
                End If
            End If

            Dim serial As Serialnumber
            If PreloadSerialnumber Is Nothing Then
                serial = New Serialnumber(serial_str)
            Else
                serial = PreloadSerialnumber
            End If
            If serial.Exists Then
                If serial.RedTag Then
                    Clean()
                    FlashAlerts.ShowInformation("La serie bloqueada por Calidad.", , Not IsNothing(PreloadSerialnumber))
                ElseIf serial.InvoiceTrouble Then
                    Log(serial.SerialNumber, "Smk_TryEmptySerialOnTracker")
                    Clean()
                    FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.", , Not IsNothing(PreloadSerialnumber))
                Else
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Empty
                            Clean()
                            FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                            Clean()
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.", , Not IsNothing(PreloadSerialnumber))
                        Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE SERVICIO
                            If serial.Linklabel <> "" Then 'SERIE ENLAZADA
                                If is_linkedserial Then 'SE ESCANEO LA ARTEZA
                                    If serial.Empty() Then
                                        Clean()
                                        FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                                    Else
                                        FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                    End If
                                Else 'SE ESCANEO LA CAJA
                                    Dim linklabel_location As String = SQL.Current().GetString("Location", "Smk_Map", {"Partnumber", "Warehouse"}, {serial.Partnumber, serial.Warehouse}, "")
                                    MessageBox.Show("La serie esta enlazada, debes usar la arteza para declarar vacio." & vbCrLf & serial.Linklabel & vbCrLf & linklabel_location, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else 'NO ESTA ENLAZADA
                                If serial.Empty() Then
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                                Else
                                    FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                End If
                            End If
                        Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker 'TODOS ESTAN EN SLOC DE RESERVA
                            'VALIDAR FIFO
                            If Parameter("SMK_ForceFIFO", False) AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") Then
                                Clean()
                                FlashAlerts.ShowError("FIFO incorrecto.", , Not IsNothing(PreloadSerialnumber))
                            Else
                                If serial.Open(serial.Location) Then
                                    serial.Empty()
                                    Clean()
                                    FlashAlerts.ShowConfirm("Serie declarada vacia.", , Not IsNothing(PreloadSerialnumber))
                                Else
                                    FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                End If
                            End If
                    End Select
                End If
            Else
                Clean()
                FlashAlerts.ShowError("La serie no existe.", , Not IsNothing(PreloadSerialnumber))
            End If
        Else
            Clean()
            FlashAlerts.ShowInformation("Serie incorrecta.", , Not IsNothing(PreloadSerialnumber))
        End If
    End Sub

    Private Sub Clean()
        If PreloadSerialnumber Is Nothing Then
            Serial_txt.Clear()
            Serial_txt.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PreloadSerialnumber Is Nothing Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            EmptySerial()
        End If
    End Sub

    Private Sub Smk_DeclareEmpty_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub


    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles List_btn.Click
        Dim ld As New ListDialog
        ld.Title = "Numeros de Serie"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each serie In ld.Items
                If SMK.IsSerialFormat(serie) Then
                    Dim serial As New Serialnumber(serie)
                    If serial.Exists Then
                        If serial.RedTag Then
                            FlashAlerts.ShowInformation("La serie bloqueada por Calidad.", , False)
                        ElseIf serial.InvoiceTrouble Then
                            Log(serial.SerialNumber, "Smk_TryEmptySerialOnTracker")
                            FlashAlerts.ShowInformation("La serie se encuentra en Tracker de Problemas.", , False)
                        Else
                            Select Case serial.Status
                                Case Serialnumber.SerialStatus.Empty
                                    FlashAlerts.ShowInformation("La serie ya se encuentra declarada vacia.", , False)
                                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                                    FlashAlerts.ShowError("La serie no ha sido dada de alta.", , False)
                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.ServiceOnQuality 'TODOS ESTAN EN SLOC DE SERVICIO
                                    If serial.Empty() Then
                                        FlashAlerts.ShowConfirm("Serie declarada vacia.", , False)
                                    Else
                                        FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                    End If
                                Case Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.Tracker 'TODOS ESTAN EN SLOC DE RESERVA
                                    'VALIDAR FIFO
                                    If Parameter("SMK_ForceFIFO", False) AndAlso Not User.Current.HasPermission("Supermarket_SerialFIFO_Brake_flag") AndAlso Not (serial.SerialNumber = SMK.NextFIFO(serial.Partnumber, My.Settings.Warehouse) OrElse serial.SerialNumber = SMK.NextFIFO(serial.Partnumber)) Then
                                        FlashAlerts.ShowError("FIFO incorrecto.", , False)
                                    Else
                                        If serial.Open(serial.Location) Then
                                            serial.Empty()
                                            FlashAlerts.ShowConfirm("Serie declarada vacia.", , False)
                                        Else
                                            FlashAlerts.ShowError("Error al declarar vacia la serie.")
                                        End If
                                    End If
                            End Select
                        End If
                    Else
                        FlashAlerts.ShowError("La serie no existe.", , False)
                    End If
                End If
            Next
        End If
    End Sub
End Class