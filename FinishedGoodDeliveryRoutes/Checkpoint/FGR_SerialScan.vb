Public Class FGR_SerialScan
    Public Property Route As Integer
    Public Property Badge As String
    Public ScannedSerials As DataTable
    Dim RemainTime As Integer = 120
    Dim thread_A As Threading.Thread
    Private Sub FGR_SerialScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AskBadge()
        If Me.Badge <> "" Then
            Route_lbl.Text = SQL.Current.GetString("Description", "FGR_Routes", "Route", Me.Route, "")
            OperatorName_lbl.Text = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.Badge, "")
            Picture_pb.Image = Delta.GetUserPhoto(Me.Badge)
            ScannedSerials = New DataTable
            ScannedSerials.Columns.Add("Serial")
            ScannedSerials.PrimaryKey = {ScannedSerials.Columns("Serial")}
            Kanbans_dgv.DataSource = ScannedSerials
        End If
    End Sub

    Private Sub AskBadge()
        Dim badge As New FGR_Badge
        If badge.ShowDialog = Windows.Forms.DialogResult.OK Then
            CountDown_timer.Enabled = True
            CountDown_timer.Start()
            Me.Badge = badge.SelectedBadge
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Serial_txt.Validated
        If Serial_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadSerial)
            thread_A.Start()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Serial_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadSerial)
            thread_A.Start()
        End If
    End Sub

    Delegate Sub ReadIt()

    Private Sub ReadSerial()
        If Serial_txt.InvokeRequired Then
            Dim dgt As New ReadIt(AddressOf ReadSerial)
            Invoke(dgt)
        ElseIf Serial_txt.Text.ToUpper.Trim = "CLOSE" Then
            Me.Close()
        ElseIf IsSerial(Serial_txt.Text.Trim) Then
            If Not AlreadyScanned(Serial_txt.Text.Trim) AndAlso Not SQL.Current.Exists("FGR_SerialMovements", {"Serialnumber", "Movement"}, {FormatSerial(Serial_txt.Text.Trim), "BKF"}) Then
                SQL.Current.Insert("FGR_SerialMovements", {"Serialnumber", "Movement", "Badge", "Route"}, {FormatSerial(Serial_txt.Text.Trim), "BKF", Me.Badge, Me.Route})
                ScannedSerials.Rows.Add(Serial_txt.Text.Trim)
                Count_lbl.Text = ScannedSerials.Rows.Count
                FlashAlerts.ShowConfirm("Serie registrada.", , True)
                Serial_txt.Clear()
                Serial_txt.Focus()
            Else
                FlashAlerts.ShowInformation("Serie duplicada.", , True)
                Serial_txt.Clear()
                Serial_txt.Focus()
            End If
        Else
            FlashAlerts.ShowError("Serie incorrecta.", , True)
            Serial_txt.Clear()
            Serial_txt.Focus()
        End If
        RemainTime = 120
    End Sub

    Private Function AlreadyScanned(serial As String) As Boolean
        If ScannedSerials.Rows.Find(serial) IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsSerial(serial As String)
        If serial <> "" AndAlso ((serial.Length = 11 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2))) _
              OrElse (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1))) _
             OrElse (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("M") AndAlso IsNumeric(serial.Remove(0, 1))) _
         OrElse (serial.Length = 11 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1))) _
         OrElse (serial.Length = 12 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2).Remove(9, 1)) AndAlso Not IsNumeric(serial.Remove(0, 11)))) Then
            Return True
        Else
            Return False
        End If
        'OrElse (serial.Length = 18 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2))) _
    End Function

    Private Function FormatSerial(serial As String) As String
        If serial.Length = 11 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2)) AndAlso Not serial.Contains(".") AndAlso Not serial.Contains(",") Then
            Return "0" & serial.Remove(0, 2)
        ElseIf (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1)) AndAlso Not serial.Contains(".") AndAlso Not serial.Contains(",")) OrElse (serial.Length = 10 AndAlso serial.ToUpper.StartsWith("M") AndAlso IsNumeric(serial.Remove(0, 1)) AndAlso Not serial.Contains(".") AndAlso Not serial.Contains(",")) Then
            Return "0" & serial.Remove(0, 1)
        ElseIf serial.Length = 11 AndAlso serial.ToUpper.StartsWith("S") AndAlso IsNumeric(serial.Remove(0, 1)) AndAlso Not serial.Contains(".") AndAlso Not serial.Contains(",") Then
            Return serial.Remove(0, 1)
        ElseIf serial.Length = 12 AndAlso serial.Substring(1, 1).ToUpper = "S" AndAlso IsNumeric(serial.Remove(0, 2).Remove(9, 1)) AndAlso Not IsNumeric(serial.Remove(0, 11)) AndAlso Not serial.Contains(".") AndAlso Not serial.Contains(",") Then
            Return "0" & serial.Remove(0, 2).Remove(9, 1)
        Else
            Return serial
        End If
    End Function

    Private Sub CountDown_timer_Tick(sender As Object, e As EventArgs) Handles CountDown_timer.Tick
        RemainTime -= 1
        CountDown_lbl.Text = "Tiempo restante: " & RemainTime
        If RemainTime = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub FGR_SerialScan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serial_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class