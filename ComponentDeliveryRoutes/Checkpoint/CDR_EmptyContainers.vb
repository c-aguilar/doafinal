Public Class CDR_EmptyContainers
    Dim Route As CDR.Route
    Dim dt_serialnumber As DataTable
    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Route_txt_Validated(sender As Object, e As EventArgs) Handles Route_txt.Validated
        If Route_txt.Text.Trim <> "" Then
            ValidateRoute()
        End If
    End Sub

    Private Sub Route_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Route_txt.KeyDown
        If Route_txt.Text.Trim <> "" AndAlso e.KeyCode = Keys.Enter Then
            ValidateRoute()
        End If
    End Sub

    Private Sub ValidateRoute()
        If CDR.Routes.Exists(Function(f) f.Name.ToLower = Route_txt.Text.Trim.ToLower) Then
            Route = CDR.Routes.Find(Function(f) f.Name.ToLower = Route_txt.Text.Trim.ToLower)
            Route_txt.Enabled = False
            Serialnumber_txt.Focus()
        Else
            Route_txt.Clear()
            Route_txt.Focus()
            FlashAlerts.ShowError("No existe la ruta.")
        End If
    End Sub

    Private Sub Serialnumber_txt_Validated(sender As Object, e As EventArgs) Handles Serialnumber_txt.Validated
        If Serialnumber_txt.Text.Trim <> "" AndAlso Route IsNot Nothing Then
            ReadSerial()
        ElseIf Route Is Nothing Then
            Serialnumber_txt.Focus()
        End If
    End Sub

    Private Sub Serialnumber_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Serialnumber_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Serialnumber_txt.Text.Trim <> "" AndAlso Route IsNot Nothing Then
            ReadSerial()
        End If
    End Sub

    Private Sub ReadSerial()
        Dim serial As New Serialnumber(Serialnumber_txt.Text)
        If serial.Exist Then
            If serial.RedTag Then
                Log(serial.SerialNumber, "CDR_EmptyRedTagSerial")
            End If
            Dim s = dt_serialnumber.Rows.Find(serial.SerialNumber)
            If s Is Nothing Then
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Quality
                        serial.TrackerPartialDiscount(serial.CurrentQuantity, Route.Badge)
                        Log(serial.SerialNumber, "CDR_EmptyQualtitySerial")
                    Case Serialnumber.SerialStatus.Tracker
                        serial.TrackerPartialDiscount(serial.CurrentQuantity, Route.Badge)
                        Log(serial.SerialNumber, "CDR_EmptyTrackerSerial")
                    Case Delta_ERP.Serialnumber.SerialStatus.New, Delta_ERP.Serialnumber.SerialStatus.Pending
                        dt_serialnumber.Rows.Add(serial.SerialNumber, "Error")
                    Case Delta_ERP.Serialnumber.SerialStatus.Stored
                        If serial.Open("00000000") AndAlso serial.EmptyByRoute(Route.Badge) Then
                            dt_serialnumber.Rows.Add(serial.SerialNumber, "OK")
                        Else
                            dt_serialnumber.Rows.Add(serial.SerialNumber, "Error")
                        End If
                    Case Delta_ERP.Serialnumber.SerialStatus.Open, Delta_ERP.Serialnumber.SerialStatus.OnCutter
                        If serial.EmptyByRoute(Route.Badge) Then
                            dt_serialnumber.Rows.Add(serial.SerialNumber, "OK")
                        Else
                            dt_serialnumber.Rows.Add(serial.SerialNumber, "Error")
                        End If
                    Case Delta_ERP.Serialnumber.SerialStatus.Empty
                        dt_serialnumber.Rows.Add(serial.SerialNumber, "Empty")
                End Select
            Else
                dt_serialnumber.Rows.Add(serial.SerialNumber, "Duplicated")
            End If
            Count_lbl.Text = dt_serialnumber.Compute("COUNT(Serialnumber)", "Result IN ('OK','Error','Empty')")
            Serialnumber_txt.Clear()
            Serialnumber_txt.Focus()
        Else
            Serialnumber_txt.Clear()
            Serialnumber_txt.Focus()
            FlashAlerts.ShowError("Serie incorrecta.")
        End If
        serial = Nothing
    End Sub

    Private Sub CDR_EmptyContainers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_serialnumber = New DataTable
        dt_serialnumber.Columns.Add("Serialnumber")
        dt_serialnumber.Columns.Add("Result")
        dt_serialnumber.PrimaryKey = {dt_serialnumber.Columns("Serialnumber")}
        Serials_dgv.DataSource = dt_serialnumber
    End Sub

    Private Sub Serials_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Serials_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("icon_img").Index Then
            Select Case Serials_dgv.Rows(e.RowIndex).Cells("result").Value
                Case "OK"
                    e.Value = My.Resources.tick_32
                Case "Duplicated"
                    e.Value = My.Resources.tick_light_blue_32
                Case "Empty"
                    e.Value = My.Resources.tick_red_32
                Case "Error"
                    e.Value = My.Resources.cross_32
            End Select
        End If
    End Sub

    Private Sub Serials_dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Serials_dgv.RowsAdded
        Serials_dgv.FirstDisplayedScrollingRowIndex = e.RowIndex
    End Sub

    Private Sub CDR_EmptyContainers_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Route_txt.Focus()
    End Sub
End Class