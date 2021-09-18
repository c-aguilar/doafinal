Public Class DDR_CartStatus

    Private Sub DDR_CartStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub
    Public Property StatusTime As Date
    Public Property OperatorName As String = "Operador"
    Public Property Cart As String = "Carro"
    Public Property Status As CDR.Status = CDR.Status.WaitingIn
    Public Property Containers As Integer = 0
    Public Property PickedupContainers As Integer = 0
    Public Sub RefreshData()
        Select Case Me.Status
            Case CDR.Status.WaitingIn
                Status_pb.Image = My.Resources.ddr_inside_wait
                Status_lbl.Text = "Entrada" & vbCrLf & "Vacio"
                Status_lbl.ForeColor = Color.Gold
                Operator_lbl.ForeColor = Color.Gold
            Case CDR.Status.In
                Status_pb.Image = My.Resources.ddr_scanning_in
                Status_lbl.Text = "Escaneado" & vbCrLf & "Vacio"
                Status_lbl.ForeColor = Color.LightSkyBlue
                Operator_lbl.ForeColor = Color.LightSkyBlue
            Case CDR.Status.Picking
                Status_pb.Image = My.Resources.ddr_inside
                Status_lbl.Text = String.Format("Surtiendo {0}/{1}", PickedupContainers, Containers)
                Status_lbl.ForeColor = Color.LightGreen
                Operator_lbl.ForeColor = Color.LightGreen
            Case CDR.Status.WaitingDelivery
                Status_pb.Image = My.Resources.ddr_outside_wait
                Status_lbl.Text = "Escaneado" & vbCrLf & "Surtido"
                Status_lbl.ForeColor = Color.SlateBlue
                Operator_lbl.ForeColor = Color.SlateBlue
            Case CDR.Status.Delivering
                Status_pb.Image = My.Resources.ddr_outside
                Status_lbl.Text = "Manufactura"
                Status_lbl.ForeColor = Color.SteelBlue
                Operator_lbl.ForeColor = Color.SteelBlue
            Case Else
                Status_pb.Image = My.Resources.ddr_not_started
                Status_lbl.Text = "Sin" & vbCrLf & "movimiento"
                Status_lbl.ForeColor = Color.Gray
                Operator_lbl.ForeColor = Color.Gray
        End Select
        Count_lbl.Text = Me.Containers
        Operator_lbl.Text = Me.OperatorName
        Cart_lbl.Text = Me.Cart
        RefreshCrono()
    End Sub
    Public Sub RefreshCrono()
        If Me.Status <> CDR.Status.Out Then
            Dim seconds As Integer = DateDiff(DateInterval.Second, Me.StatusTime, Delta.CurrentDate)
            Dim minutes As Integer = Math.Floor(seconds / 60)
            seconds -= minutes * 60
            Crono_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))
            If minutes >= CInt(Parameter("DDR_IMS_ActivityMaximumMinutes", 30)) Then
                Crono_lbl.BackColor = Color.Red
            Else
                Crono_lbl.BackColor = Color.Black
            End If
        Else
            Crono_lbl.Text = "-"
        End If
    End Sub
End Class

