Public Class DDR_LoopIcon
    Public Sub New(count As Integer, cart As String, task As String, status_time As Date, to_time As Date, containers As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Count_lbl.Text = count
        Cart_lbl.Text = cart
        Task_lbl.Text = task
        Containers_lbl.Text = containers
        Dim seconds As Integer = DateDiff(DateInterval.Second, status_time, to_time)
        Dim minutes As Integer = Math.Floor(seconds / 60)
        seconds -= minutes * 60
        Crono_lbl.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"))
    End Sub
End Class
