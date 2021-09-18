Public Class Rec_ToTracker

    Dim pictures As New List(Of PictureBox)
    Dim selected_serials As New List(Of String)
    Dim serial_list As New List(Of Serialnumber)
    Dim some_error As Boolean = False
    Dim local As String = ""
    Dim selected_pb As PictureBox
    Private Sub Rec_ToTracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Reason_cbo, SQL.Current.GetDatatable("SELECT Reason, [Description] FROM Rec_TrackerReasons ORDER BY [Description]"), "Description", "Reason")
        Clean()
        RefreshTracker()
    End Sub

    Private Sub RefreshTracker()
        NewSerials_dgv.DataBindings.Clear()
        Tracker_dgv.DataBindings.Clear()
        NewSerials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber,Partnumber,OriginalQuantity,UoM,CurrentQuantity,[Date],TruckNumber FROM vw_Smk_Serials WHERE InvoiceTrouble = 0 AND [Status] IN ('P','N','T') AND Serialnumber NOT IN ('{0}') ORDER BY [Date]", String.Join("','", selected_serials)))
        Tracker_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT Serialnumber,Partnumber,OriginalQuantity,UoM,CurrentQuantity,[Date],TruckNumber FROM vw_Smk_Serials WHERE Serialnumber IN ('{0}') ORDER BY [Date]", String.Join("','", selected_serials)))
    End Sub

    Private Sub RefreshPictures()
        Pictures_flp.Controls.Clear()
        For Each pb As PictureBox In pictures
            Pictures_flp.Controls.Add(pb)
        Next
    End Sub

    Private Sub SendMail(serial_list As List(Of Serialnumber), attachments As List(Of String))
        Dim email_list As New List(Of String)
        email_list.AddRange(Delta.Parameter("REC_TrackerNotificationEmails").Split(";"))
        Dim mrp_emails = SQL.Current.GetList(String.Format("SELECT DISTINCT U.Email FROM Ord_MRPControllers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE M.MRP IN ('{0}');", String.Join("','", serial_list.Select(Function(x) x.MRP).Distinct())))
        For Each email In mrp_emails
            email_list.Add(email.ToString)
        Next

        Dim html_body As String = My.Resources.REC_TrackerEmailTemplate
        html_body = html_body.Replace("@username", User.Current.FullName)
        html_body = html_body.Replace("@reason", Reason_cbo.GetItemText(Reason_cbo.SelectedItem))
        html_body = html_body.Replace("@comment", Comment_txt.Text)
        html_body = html_body.Replace("@delivery", Delivery_txt.Text)

        Dim parts_html As String = ""
        For Each serial As Serialnumber In serial_list
            parts_html &= String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td></tr>", serial.SerialNumber, serial.Partnumber, RawMaterial.GetDescription(serial.Partnumber), serial.Quantity, serial.UoM, serial.TruckNumber, serial.Date, serial.MRP)
        Next

        html_body = html_body.Replace("@partnumbers", parts_html)
        If Mail.OutlookMail("Tracker de Pendientes de Procesar", html_body, String.Join(";", email_list.ToArray), "", attachments) Then
            FlashAlerts.ShowConfirm("Correo de notificación enviado.")
        Else
            FlashAlerts.ShowInformation("No fue posible enviar el correo de notificación.", 3)
        End If
    End Sub



    Private Sub SendToTracker(serial As Serialnumber, issue_id As Integer)
        If serial.Exists Then 'SIEMPRE DEBERIA DE EXISTIR
            If (serial.Status = Serialnumber.SerialStatus.Quality OrElse serial.Status = Serialnumber.SerialStatus.ServiceOnQuality) AndAlso serial.RedTag Then
                'La serie se encuentra en Calidad.
            ElseIf serial.Status = Serialnumber.SerialStatus.Tracker AndAlso serial.InvoiceTrouble Then
                'La serie ya se encuentra en tracker
            Else
                Select Case serial.Status
                    Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Presupermarket
                        If serial.ToTracker(local, issue_id) Then
                            serial_list.Add(serial)
                        Else
                            'Error al registrar la serie."
                            some_error = True
                        End If
                    Case Serialnumber.SerialStatus.Empty
                        'La serie ya fue declarada vacia.
                End Select
            End If
        End If
    End Sub

    Public Function SaveIssuePhoto(issue_id As Integer, picture As Image, path As String) As Boolean
        Try
            Dim streamMini = New System.IO.MemoryStream()
            Dim pic_mini = ResizeImage(picture, New Size(800, 600), True)
            pic_mini.Save(streamMini, System.Drawing.Imaging.ImageFormat.Png)
            pic_mini.Save(path, System.Drawing.Imaging.ImageFormat.Png)
            streamMini.Position = 0
            Dim mini() As Byte = streamMini.GetBuffer
            SQL.Current.Insert("Rec_TrackerIssuePictures", {"IssueID", "Picture"}, {issue_id, mini})
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If selected_serials.Count > 0 AndAlso Location_txt.MaskCompleted AndAlso Reason_cbo.SelectedIndex > -1 Then
            Dim issue_id As Integer = 0 'Reason_cbo.SelectedValue, Delivery_txt.Text, Comment_txt.Text
            If SQL.Current.Insert("Rec_TrackerIssues", {"Reason", "Delivery", "Comment", "Badge"}, {Reason_cbo.SelectedValue, Delivery_txt.Text, Comment_txt.Text, User.Current.Badge}) Then
                issue_id = SQL.Current.GetScalar("MAX(ID)", "Rec_TrackerIssues", {"Reason", "Badge"}, {Reason_cbo.SelectedValue, User.Current.Badge})
                local = Location_txt.Text
                For Each s As String In selected_serials
                    If SMK.IsMasterSerialFormat(s) Then
                        Dim master As New Masternumber(s)
                        If master.Exists Then 'SIEMPRE DEBERIA DE EXISTIR
                            For Each serial As Serialnumber In master.Serials
                                SendToTracker(serial, issue_id)
                            Next
                        End If
                    Else
                        Dim serial As New Serialnumber(s)
                        SendToTracker(serial, issue_id)
                    End If
                Next
                If serial_list.Count > 0 Then
                    Dim attachments As New List(Of String)
                    For Each pb As PictureBox In pictures
                        Dim path As String = GF.TempPath("png")
                        If SaveIssuePhoto(issue_id, pb.Image, path) Then
                            attachments.Add(path)
                        End If
                    Next
                    SendMail(serial_list, attachments)
                    Clean()
                    If some_error Then
                        FlashAlerts.ShowInformation("Surgio un error al mandar a tracker alguna de las series.")
                    Else
                        FlashAlerts.ShowConfirm("Series enviadas a tracker correctamente.")
                    End If
                Else
                    If some_error Then
                        FlashAlerts.ShowError("Surgió un error al mandar a tracker la(s) serie(s).")
                    Else
                        FlashAlerts.ShowInformation("Nada seleccionado para enviar a tracker.")
                    End If
                End If
            Else
                FlashAlerts.ShowError("Surgio un error al mandar a tracker la(s) serie(s).")
            End If
        Else
            FlashAlerts.ShowInformation("Completa todos los campos.")
        End If
    End Sub

    Private Sub Clean()
        pictures.Clear()
        Pictures_flp.Controls.Clear()
        selected_pb = Nothing
        Dim pb As New PictureBox
        pb.Image = My.Resources.No_image_available
        pb.Size = New Size(250, 170)
        pb.SizeMode = PictureBoxSizeMode.Zoom
        pb.BackColor = Color.White
        Pictures_flp.Controls.Add(pb)
        some_error = False
        selected_serials.Clear()
        serial_list.Clear()
        local = ""
        Reason_cbo.SelectedIndex = -1
        Location_txt.Clear()
        Comment_txt.Clear()
        Delivery_txt.Clear()
        RefreshTracker()
    End Sub

    Private Sub Smk_StoreSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    'Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs)
    '    If SMK.IsSerialFormat(Serial_txt.Text) Then
    '        Location_txt.Focus()
    '    ElseIf SMK.IsMasterSerialFormat(Serial_txt.Text) Then
    '        Location_txt.Focus()
    '    End If
    'End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If NewSerials_dgv.SelectedRows.Count > 0 Then
            For Each s As DataGridViewRow In NewSerials_dgv.SelectedRows
                selected_serials.Add(s.Cells("SerialNew").Value)
            Next
            RefreshTracker()
        End If
    End Sub

    Private Sub Remove_btn_Click(sender As Object, e As EventArgs) Handles Remove_btn.Click
        If Tracker_dgv.SelectedRows.Count > 0 Then
            For Each s As DataGridViewRow In Tracker_dgv.SelectedRows
                selected_serials.Remove(s.Cells("Serial").Value)
            Next
            RefreshTracker()
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Dim eb As New EnterBox
        eb.Question = "Número de serie:"
        eb.AcceptByEnter = True
        If eb.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SMK.IsSerialFormat(eb.Answer.Trim) Then
                Dim serial As New Serialnumber(eb.Answer.Trim)
                If serial.Exists Then
                    If (serial.Status = Serialnumber.SerialStatus.Quality OrElse serial.Status = Serialnumber.SerialStatus.ServiceOnQuality) AndAlso serial.RedTag Then
                        FlashAlerts.ShowError("La serie se encuentra en Calidad.")
                    ElseIf serial.Status = Serialnumber.SerialStatus.Tracker AndAlso serial.InvoiceTrouble Then
                        FlashAlerts.ShowInformation("La serie ya se encuentra en tracker.")
                    Else
                        Select Case serial.Status
                            Case Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Stored, Serialnumber.SerialStatus.OnCutter, Serialnumber.SerialStatus.Open, Serialnumber.SerialStatus.Tracker, Serialnumber.SerialStatus.Quality, Serialnumber.SerialStatus.ServiceOnQuality, Serialnumber.SerialStatus.Presupermarket
                                selected_serials.Add(serial.SerialNumber)
                            Case Serialnumber.SerialStatus.Empty
                                FlashAlerts.ShowError("La serie ya fue declarada vacia.")
                        End Select
                    End If
                    RefreshTracker()
                Else
                    FlashAlerts.ShowError("El número de serie no existe.")
                End If
            ElseIf SMK.IsMasterSerialFormat(eb.Answer.Trim) Then
                Dim master As New Masternumber(eb.Answer.Trim)
                If master.Exists Then
                    If master.GeneralStatus = Masternumber.MasterStatus.Quality AndAlso master.Serials.Exists(Function(w) w.RedTag = True) Then
                        FlashAlerts.ShowInformation("La serie se encuentra en Calidad.")
                    ElseIf master.GeneralStatus = Masternumber.MasterStatus.Tracker AndAlso master.Serials.Exists(Function(w) w.InvoiceTrouble = True) Then
                        FlashAlerts.ShowInformation("La serie ya se encuentra en Tracker de Problemas.")
                    Else
                        If master.GeneralStatus = Masternumber.MasterStatus.Mixed Then
                            FlashAlerts.ShowError("El estatus de alguna serie hija ya fue cambiado.")
                        Else
                            For Each serial As Serialnumber In master.Serials
                                selected_serials.Add(serial.SerialNumber)
                            Next
                        End If
                    End If
                Else
                    FlashAlerts.ShowError("El número de serie no existe.")
                End If
                master = Nothing
            Else
                FlashAlerts.ShowError("Número de serie incorrecto.")
            End If
        End If
        eb.Dispose()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Clean()
    End Sub

    Private Sub AddPic_btn_Click(sender As Object, e As EventArgs) Handles AddPic_btn.Click
        Try
            Dim dialog As OpenFileDialog = New OpenFileDialog()
            dialog.Multiselect = True
            dialog.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each file In dialog.FileNames
                    Dim img As Image = Image.FromFile(file)
                    Dim pb As New PictureBox
                    pb.Size = New Size(250, 170)
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    pb.BackColor = Color.Black
                    pb.Image = img
                    pb.ContextMenuStrip = Image_cms
                    AddHandler pb.MouseDown, AddressOf PictureBox_MouseDown
                    pictures.Add(pb)
                Next
                RefreshPictures()
            End If
        Catch ex As Exception
            FlashAlerts.ShowError("Error al cargar la imagen.")
        End Try
    End Sub

    Private Sub Delete_cmsi_Click(sender As Object, e As EventArgs) Handles Delete_cmsi.Click
        pictures.Remove(selected_pb)
        RefreshPictures()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshTracker()
    End Sub

    Private Sub Image_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Image_cms.Opening

    End Sub

    Private Sub Image_cms_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles Image_cms.ItemClicked

    End Sub

    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs)
        selected_pb = sender
    End Sub
End Class