Public Class DiC_Picklist
    Public Property DieCenter As String
    Public Property AutoCloseForm As Boolean = False
    Dim Picklist As DataTable
    Dim RemainTime As Integer = 30
    Dim Counter As Integer = 0
    Private Sub DiC_Picklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DieCenter = "" Then
            Dim warehouse As String = SQL.Current.GetString("Warehouse", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
            Me.DieCenter = SQL.Current.GetString("DieCenter", "DiC_Centers", "Warehouse", warehouse, "")
        End If

        DieCenter_lbl.Text = "Picklist " & Me.DieCenter
        If Parameter("DiC_Picklist").ToUpper = "SERIALNUMBER" Then
            Option_txt.WaterMarkText = "ESCANEA LA SERIE..."
        ElseIf Parameter("DiC_Picklist").ToUpper = "PARTNUMBER" Then
            Option_txt.WaterMarkText = "ESCANEA EL NO DE PARTE..."
        ElseIf Parameter("DiC_Picklist").ToUpper = "DIENUMBER" Then
            Option_txt.WaterMarkText = "ESCANEA EL NO DE DADO..."
        End If
        If AutoCloseForm Then
            CountDown_timer.Enabled = True
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        Else
            Close_btn.Visible = False
            CountDown_lbl.Visible = False
            Me.WindowState = FormWindowState.Maximized
        End If
        LoadPicklist()
        Option_txt.Focus()
    End Sub

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            If AutoCloseForm Then
                Me.Close()
            Else
                Counter = 0
                Count_lbl.Text = 0
            End If
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
        Select Case Option_txt.Text.ToUpper
            Case "CLOSE"
                If AutoCloseForm Then
                    Me.Close()
                Else
                    Option_txt.Clear()
                    Option_txt.Focus()
                End If
            Case Else
                If Parameter("DiC_Picklist").ToUpper = "SERIALNUMBER" Then
                    If Parameter("DiC_OnlyOnCenter") Then
                        Dim serial As New Serialnumber(Option_txt.Text)
                        Option_txt.Clear()
                        Option_txt.Focus()
                        If serial.Exists Then
                            If Not serial.RedTag Then
                                If SQL.Current.Exists("DiC_Map", {"Partnumber", "DieCenter"}, {serial.Partnumber, Me.DieCenter}) Then
                                    If Not SQL.Current.Exists("DiC_Picklist", "ScannedSerialnumber", serial.ID) Then
                                        If Parameter("DiC_FixSerialStatus") Then
                                            Select Case serial.Status
                                                Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                                                    Log(serial.SerialNumber, "DiC_AskNoStoredSerial")
                                                    serial.Store("00000000")
                                                    serial.Empty()
                                                Case Serialnumber.SerialStatus.Tracker
                                                    Log(serial.SerialNumber, "DiC_AskTrackerSerial")
                                                Case Serialnumber.SerialStatus.Quality
                                                    Log(serial.SerialNumber, "DiC_AskQualitySerial")
                                                    serial.Empty()
                                                Case Serialnumber.SerialStatus.Stored
                                                    Log(serial.SerialNumber, "DiC_AskNoEmptySerial")
                                                    serial.Empty()
                                                Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                                                    Log(serial.SerialNumber, "DiC_AskNoEmptySerial")
                                                    serial.Empty()
                                            End Select
                                        End If
                                        SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter", "ScannedSerialnumber"}, {serial.Partnumber, Me.DieCenter, serial.ID})
                                        Counter += 1
                                        LoadPicklist()
                                        FlashAlerts.ShowConfirm("Numero registrado.")
                                    Else
                                        FlashAlerts.ShowError("Numero de serie duplicado.")
                                    End If
                                Else
                                    FlashAlerts.ShowError("El numero no pertenece a " & Me.DieCenter)
                                End If
                            Else
                                Log(serial.SerialNumber, "DiC_AskQlyRedTag")
                                FlashAlerts.ShowError("Serie bloqueada por calidad.")
                            End If
                        Else
                            FlashAlerts.ShowError("Serie incorrecta.")
                        End If
                        serial = Nothing
                    Else
                        Dim serial As New Serialnumber(Option_txt.Text)
                        Option_txt.Clear()
                        Option_txt.Focus()
                        If serial.Exists Then
                            If Not serial.RedTag Then
                                If Not SQL.Current.Exists("DiC_Picklist", "ScannedSerialnumber", serial.ID) Then
                                    If Parameter("DiC_FixSerialStatus") Then
                                        Select Case serial.Status
                                            Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                                                Log(serial.SerialNumber, "DiC_AskNoStoredSerial")
                                                serial.Store("00000000")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Tracker
                                                Log(serial.SerialNumber, "DiC_AskTrackerSerial")
                                            Case Serialnumber.SerialStatus.Quality
                                                Log(serial.SerialNumber, "DiC_AskQualitySerial")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Stored
                                                Log(serial.SerialNumber, "DiC_AskNoEmptySerial")
                                                serial.Empty()
                                            Case Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.OnCutter
                                                Log(serial.SerialNumber, "DiC_AskNoEmptySerial")
                                                serial.Empty()
                                        End Select
                                    End If
                                    SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter", "ScannedSerialnumber"}, {serial.Partnumber, Me.DieCenter, serial.ID})
                                    Counter += 1
                                    LoadPicklist()
                                    FlashAlerts.ShowConfirm("Numero registrado.")
                                Else
                                    FlashAlerts.ShowError("Numero de serie duplicado.")
                                End If
                            Else
                                Log(serial.SerialNumber, "DiC_AskQlyRedTag")
                                FlashAlerts.ShowError("Serie bloqueada por calidad.")
                            End If
                        Else
                            FlashAlerts.ShowError("Serie incorrecta.")
                        End If
                        serial = Nothing
                    End If
                ElseIf Parameter("DiC_Picklist").ToUpper = "PARTNUMBER" Then
                    If RawMaterial.Exists(Option_txt.Text) Then
                        If Parameter("DiC_OnlyOnCenter") Then
                            If SQL.Current.Exists("DiC_Map", {"Partnumber", "DieCenter"}, {Option_txt.Text, Me.DieCenter}) Then
                                SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter"}, {Option_txt.Text, Me.DieCenter})
                                Option_txt.Clear()
                                Option_txt.Focus()
                                Counter += 1
                                LoadPicklist()
                                FlashAlerts.ShowConfirm("Numero registrado.")
                            Else
                                Option_txt.Clear()
                                Option_txt.Focus()
                                FlashAlerts.ShowError("El numero no pertenece a " & Me.DieCenter)
                            End If
                        Else
                            SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter"}, {Option_txt.Text, Me.DieCenter})
                            Option_txt.Clear()
                            Option_txt.Focus()
                            Counter += 1
                            LoadPicklist()
                            FlashAlerts.ShowConfirm("Numero registrado.")
                        End If
                    Else
                        Option_txt.Clear()
                        Option_txt.Focus()
                        FlashAlerts.ShowError("Numero de parte incorrecto.")
                    End If
                ElseIf Parameter("DiC_Picklist").ToUpper = "DIENUMBER" Then
                    Dim die_partnumber As String = SQL.Current.GetString("Partnumber", "DiC_DiePartnumbers", "DieNumber", Option_txt.Text, "")
                    If die_partnumber <> "" Then
                        If RawMaterial.Exists(die_partnumber) Then
                            SQL.Current.Insert("DiC_Picklist", {"Partnumber", "DieCenter", "DieNumber"}, {die_partnumber, Me.DieCenter, Option_txt.Text})
                            Option_txt.Clear()
                            Option_txt.Focus()
                            Counter += 1
                            LoadPicklist()
                            FlashAlerts.ShowConfirm("Número registrado.")
                        Else
                            Option_txt.Clear()
                            Option_txt.Focus()
                            FlashAlerts.ShowError("Número de parte incorrecto.")
                        End If
                    Else
                        Option_txt.Clear()
                        Option_txt.Focus()
                        FlashAlerts.ShowError("Número de dado incorrecto.")
                    End If
                End If
        End Select
    End Sub

    Private Sub LoadPicklist()
        Picklist_dgv.DataSource = Nothing
        Picklist = SQL.Current.GetDatatable(String.Format("SELECT P.Partnumber AS [No.Parte],dbo.Dic_Locations(P.Partnumber,'{0}') AS CDD,dbo.Smk_Locations(P.Partnumber) AS Supermercado,ISNULL(CASE WHEN Cnt > spaces Then spaces ELSE Cnt END,0) AS Cantidad,Fecha " & _
                                       "FROM (SELECT Partnumber,Count(*) AS Cnt,MIN([Date]) AS Fecha FROM DiC_Picklist WHERE Printed = 0 AND DieCenter = '{0}' GROUP BY Partnumber) AS P " & _
                                       "LEFT OUTER JOIN (SELECT Partnumber,SUM(Spaces) AS spaces FROM DiC_Map WHERE DieCenter = '{0}' GROUP BY Partnumber) AS D ON P.Partnumber = D.Partnumber", Me.DieCenter))
        Picklist_dgv.DataSource = Picklist
        Count_lbl.Text = Counter
    End Sub

    Private Sub DiC_Picklist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class