Public Class Ord_AnswerMixMax
    Public Property ID As Integer
    Public Property Partnumber As String
    Public Property Type As String
    Public Property Answer As String
    Public Property HasPromise As Boolean
    Public Property PromiseDate As Date = CurrentDate().Date
    Private Sub Ord_AnswerMixMax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Type.ToLower.StartsWith("max") Then
            NoPromiseDate_chk.Checked = True
            PromiseDate_dtp.Visible = False
            NoPromiseDate_chk.Visible = False
        Else
            NoPromiseDate_chk.Checked = False
            PromiseDate_dtp.Visible = True
            NoPromiseDate_chk.Visible = True
        End If
        PromiseDate_dtp.Value = Me.PromiseDate
        SelectedPartnumber_txt.Text = Partnumber
        Type_txt.Text = Type
        Answer_txt.Text = Answer
        Answer_txt.Focus()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Answer_txt.Text.Trim <> "" Then
            LoadingScreen.Show()
            If NoPromiseDate_chk.Checked Then
                SQL.Current.Update("Ord_RawMaterialAlerts", {"Answer", "AnswerDate", "AnswerUsername", "PromiseDate"}, {Answer_txt.Text, SQL.Current.MyDateTime(CurrentDate), User.Current.Username, DBNull.Value}, "ID", ID)
            ElseIf PromiseDate_dtp.Value < CurrentDate() Then
                LoadingScreen.Hide()
                FlashAlerts.ShowInformation("La fecha promesa no puede ser menor a la fecha y hora actual.")
                Exit Sub
            Else
                SQL.Current.Update("Ord_RawMaterialAlerts", {"Answer", "AnswerDate", "AnswerUsername", "PromiseDate"}, {Answer_txt.Text, SQL.Current.MyDateTime(CurrentDate), User.Current.Username, SQL.Current.MyDateTime(PromiseDate_dtp.Value)}, "ID", ID)
            End If
            SQL.Current.Execute("UPDATE Ord_RawMaterialAlerts SET Answer = B.Answer, AnswerUsername = B.AnswerUsername, AnswerDate = B.AnswerDate, PromiseDate = B.PromiseDate FROM Ord_RawMaterialAlerts AS B WHERE Ord_RawMaterialAlerts.Partnumber = B.Partnumber AND Ord_RawMaterialAlerts.[Type] = B.[Type] AND Ord_RawMaterialAlerts.ID <> B.ID AND Ord_RawMaterialAlerts.Answer IS NULL AND Ord_RawMaterialAlerts.ID = " & ID)
            Me.PromiseDate = PromiseDate_dtp.Value
            Me.Answer = Answer_txt.Text
            Me.HasPromise = Not NoPromiseDate_chk.Checked
            LoadingScreen.Hide()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            FlashAlerts.ShowInformation("Ingresa una respuesta.")
        End If
    End Sub

    Private Sub NoPromiseDate_chk_CheckedChanged(sender As Object, e As EventArgs) Handles NoPromiseDate_chk.CheckedChanged
        If NoPromiseDate_chk.Checked Then
            PromiseDate_dtp.Enabled = False
        Else
            PromiseDate_dtp.Enabled = True
        End If
    End Sub
End Class