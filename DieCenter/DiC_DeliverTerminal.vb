Public Class DiC_DeliverTerminal
    Public Property Warehouse As String
    Dim DieCenters As ArrayList
    Dim RemainTime As Integer = 30
    Dim Counter As Integer = 0
    Private Sub DiC_DeliverTerminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DieCenters = SQL.Current.GetList("DieCenter", "DiC_Centers", {"Warehouse"}, {Me.Warehouse})
        Option_txt.Focus()
    End Sub

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub Option_txt_Validated(sender As Object, e As EventArgs) Handles Option_txt.Validated
        If Option_txt.Text <> "" Then
            ReadOption()
        End If
    End Sub

    Private Sub Option_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Option_txt.KeyDown
        If Option_txt.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            ReadOption()
        End If
    End Sub

    Private Sub ReadOption()
        RemainTime = 30
        Select Option_txt.Text.ToUpper
            Case "CLOSE"
                Me.Close()
            Case Else
                Dim serial As New Serialnumber(Option_txt.Text)
                Option_txt.Text = ""
                Option_txt.Focus()
                If serial.Exist Then
                    If Not serial.RedTag Then
                        If Not SQL.Current.Exists("DiC_Picklist", "DeliverySerialnumber", serial.ID) Then
                            If Parameter("DiC_OnlyOnCenter") Then
                                If SQL.Current.Exists(String.Format("SELECT DieCenter FROM DiC_Map WHERE Partnumber = '{0}' AND DieCenter IN ('{1}');", serial.Partnumber, String.Join("','", Me.DieCenters.ToArray))) Then
                                    If Parameter("DiC_FixSerialStatus") Then
                                        Select Case serial.Status
                                            Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                                                Log(serial.SerialNumber, "DiC_DeliverNoStoredSerial")
                                                serial.Store("00000000")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Tracker
                                                Log(serial.SerialNumber, "DiC_DeliverTrackerSerial")
                                            Case Serialnumber.SerialStatus.Quality
                                                Log(serial.SerialNumber, "DiC_DeliverQualitySerial")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Stored
                                                Log(serial.SerialNumber, "DiC_DeliverNoEmptySerial")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                                                Log(serial.SerialNumber, "DiC_DeliverNoEmptySerial")
                                                serial.Empty()
                                        End Select
                                    End If
                                    Dim id As Integer = SQL.Current.GetScalar(String.Format("SELECT MIN(ID) FROM DiC_Picklist WHERE Partnumber = '{0}' AND DieCenter IN ('{1}') AND Printed = 0;", serial.Partnumber, String.Join("','", Me.DieCenters.ToArray)), 0)
                                    If id = 0 Then
                                        Log(String.Format("{0} | {1}", serial.SerialNumber, Me.Warehouse), "DiC_NoRequiredSerial")
                                    Else
                                        SQL.Current.Update("DiC_Picklist", {"Printed", "DeliverySerialnumber"}, {1, serial.ID}, "ID", id)
                                    End If
                                    Counter += 1
                                    Count_lbl.Text = Counter
                                    FlashAlerts.ShowConfirm("Entregado.")
                                Else
                                    FlashAlerts.ShowError("El numero no pertenece a " & String.Join(" o ", Me.DieCenters.ToArray))
                                End If
                            Else
                                If Parameter("DiC_FixSerialStatus") Then
                                    Select Case serial.Status
                                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending
                                            Log(serial.SerialNumber, "DiC_DeliverNoStoredSerial")
                                            serial.Store("00000000")
                                            serial.Empty()
                                        Case Serialnumber.SerialStatus.Tracker
                                            Log(serial.SerialNumber, "DiC_DeliverTrackerSerial")
                                        Case Serialnumber.SerialStatus.Quality
                                            Log(serial.SerialNumber, "DiC_DeliverQualitySerial")
                                            serial.Empty()
                                        Case Serialnumber.SerialStatus.Stored
                                            Log(serial.SerialNumber, "DiC_DeliverNoEmptySerial")
                                            serial.Empty()
                                        Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                                            Log(serial.SerialNumber, "DiC_DeliverNoEmptySerial")
                                            serial.Empty()
                                    End Select
                                End If
                                Dim id As Integer = SQL.Current.GetScalar(String.Format("SELECT MIN(ID) FROM DiC_Picklist WHERE Partnumber = '{0}' AND DieCenter IN ('{1}');", serial.Partnumber, String.Join("','", Me.DieCenters.ToArray)), 0)
                                If id = 0 Then
                                    Log(String.Format("{0} | {1}", serial.SerialNumber, Me.Warehouse), "DiC_NoRequiredSerial")
                                Else
                                    SQL.Current.Update("DiC_Picklist", {"Printed", "DeliverySerialnumber"}, {1, serial.ID}, "ID", id)
                                End If
                                Counter += 1
                                Count_lbl.Text = Counter
                                FlashAlerts.ShowConfirm("Entregado.")
                            End If
                        Else
                            FlashAlerts.ShowError("Serie escaneada anteriormente.")
                        End If
                    Else
                        Log(serial.SerialNumber, "DiC_DeliverQlyRedTag")
                        FlashAlerts.ShowError("Serie bloqueada por calidad.")
                    End If
                Else
                    FlashAlerts.ShowError("Serie incorrecta.")
                End If
                serial = Nothing
        End Select
    End Sub

    Private Sub DiC_DeliverTerminal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class