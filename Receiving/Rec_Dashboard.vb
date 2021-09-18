Public Class Rec_Dashboard

    Private Sub Rec_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateDashboard()
    End Sub


    Private Sub UpdateDashboard()
        If SQL.Current.Available Then
            Dim counter As Integer = SQL.Current.GetScalar("COUNT(ID)", "Smk_Serials", {"[Status]", "InvoiceTrouble"}, {"T", 0})
            PendingToReleaseCounter_lbl.Text = counter
            If counter = 0 Then
                PendingToReleaseCounter_lbl.ForeColor = Color.YellowGreen
            Else
                PendingToReleaseCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Smk_Serials WHERE Status IN ('N','P') AND DATEDIFF(HOUR,[Date],GETDATE()) >= 6")
            MoreThan6HoursCounter_lbl.Text = counter
            If counter = 0 Then
                MoreThan6HoursCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MoreThan6HoursCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(DISTINCT Partnumber) FROM Smk_Serials WHERE Critical = 1  GROUP BY Partnumber,CONVERT(DATE,[Date]) HAVING SUM(CASE WHEN [Status] IN ('N','P') THEN 1 ELSE 0 END) = COUNT(ID)")
            MissingCriticalCounter_lbl.Text = counter
            If counter = 0 Then
                MissingCriticalCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MissingCriticalCounter_lbl.ForeColor = Color.Firebrick
            End If

            counter = SQL.Current.GetScalar("SELECT COUNT(ID) FROM Smk_Serials WHERE [Status] IN ('N','P') AND RedTag = 1")
            MissingQualityCounter_lbl.Text = counter
            If counter = 0 Then
                MissingQualityCounter_lbl.ForeColor = Color.YellowGreen
            Else
                MissingQualityCounter_lbl.ForeColor = Color.Firebrick
            End If
        End If
    End Sub

    Private Sub Main_tmr_Tick(sender As Object, e As EventArgs) Handles Main_tmr.Tick
        UpdateDashboard()
    End Sub
End Class