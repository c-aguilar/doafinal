Public Class Qly_AlertsHistory
    Dim report As DataTable

    Private Sub Rec_ReprintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        If Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text.Trim = "" Then
            report = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],Reason AS Motivo,U.Fullname AS Usuario,A.[Date] AS Fecha,A.Active AS Activa,DateInactive AS [Fecha Desactivacion] FROM Qly_PartnumberAlerts AS A INNER JOIN Sys_Users AS U ON A.Username = U.Username WHERE CONVERT(DATE,A.[Date]) BETWEEN '{0}' AND '{1}' ORDER BY A.[Date];", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        Else
            report = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],Reason AS Motivo,U.Fullname AS Usuario,A.[Date] AS Fecha,A.Active AS Activa,DateInactive AS [Fecha Desactivacion] FROM Qly_PartnumberAlerts AS A INNER JOIN Sys_Users AS U ON A.Username = U.Username WHERE A.Partnumber = '{0}' AND CONVERT(DATE,A.[Date]) BETWEEN '{1}' AND '{2}' ORDER BY A.[Date];", Partnumber_txt.Text, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        End If
        Report_dgv.DataSource = report
    End Sub

    Private Sub Rec_ReprintLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(report, Title_lbl.Text)
    End Sub
End Class