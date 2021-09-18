Public Class FGR_Backflush
    Dim serials As DataTable
    Private Sub Bkf_btn_Click(sender As Object, e As EventArgs) Handles Bkf_btn.Click
        If Parameter("FGR_SAPBackflush_Enabled", True, True) Then
            If serials.Compute("COUNT(Serialnumber)", "Posting = 1 AND Posted = 0") > 0 Then
                Dim sap As New SAP
                If sap.Available Then
                    LoadingScreen.Show()
                    Dim to_posting = serials.Select("Posting = 1 AND Posted = 0")
                    Dim serials_to_posting As New ArrayList
                    For Each s As DataRow In to_posting
                        serials_to_posting.Add(s.Item("Serialnumber"))
                    Next
                    Dim posted = sap.ZMDEBF(serials_to_posting)
                    SQL.Current.Execute(String.Format("UPDATE FGR_SerialMovements SET Posted = 1, Active = 0 WHERE Posted = 0 AND Movement = 'BKF' AND Serialnumber IN ('{0}');", String.Join("','", posted.ToArray)))
                    For Each sp In posted
                        Dim serial = serials.Rows.Find(sp)
                        serial.Item("Posted") = 1
                        serial.Item("Img") = My.Resources.ok_16
                    Next
                    to_posting = serials.Select("Posting = 1 AND Posted = 0")
                    For Each s As DataRow In to_posting
                        s.Item("Posted") = -1
                        s.Item("Img") = My.Resources.critical_16
                    Next
                    Serial_dgv.Refresh()
                    Bkf_btn.Enabled = False
                    LoadingScreen.Hide()
                Else
                    FlashAlerts.ShowError(Language.Sentence(267))
                End If
            End If
        Else
            FlashAlerts.ShowInformation("El proceso de backflush fue desactivado.")
        End If
    End Sub

    Private Sub FGR_Backflush_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshSerials()
    End Sub

    Private Sub RefreshSerials()
        serials = SQL.Current.GetDatatable("SELECT Serialnumber,[Description] AS Ruta,[Date] AS Fecha,CONVERT(BIT,1) AS Posting,0 AS Posted FROM FGR_SerialMovements AS S LEFT OUTER JOIN FGR_Routes AS R ON S.[Route] = R.[Route] WHERE [Movement] = 'BKF' AND Posted = 0 AND S.[Active] = 1")
        serials.Columns.Add("Img", GetType(Bitmap))
        For Each s As DataRow In serials.Rows
            s.Item("Img") = My.Resources.bullet_white_16
        Next
        serials.PrimaryKey = {serials.Columns("Serialnumber")}
        Serial_dgv.DataSource = serials
        Bkf_btn.Enabled = True
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshSerials()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(serials.DefaultView.ToTable(False, "Serialnumber", "Ruta", "Fecha"), Title_lbl.Text)
    End Sub

    Private Sub Serial_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Serial_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Serial_dgv.Rows(e.RowIndex).Cells("Posted").Value = 1 Then
                e.CellStyle.BackColor = Color.LightGreen
            ElseIf Serial_dgv.Rows(e.RowIndex).Cells("Posted").Value = -1 Then
                e.CellStyle.BackColor = Color.LightCoral
            End If
        End If
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRow In serials.Rows
                s.Item("Posting") = SelectAll_chk.Checked
            Next
        End If
    End Sub
End Class