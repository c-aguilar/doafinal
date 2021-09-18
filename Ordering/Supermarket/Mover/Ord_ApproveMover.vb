Public Class Ord_ApproveMover
    Private Sub Ord_ApproveMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("show_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.folder_16
        CType(Movers_dgv.Columns("approve_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.ok_16
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable("SELECT M.ID, U.FullName, Requisitor, M.Reason, Customer, Partnumbers, Cost, T.[Description], Locality, M.[Date], M.Comment FROM Ord_Movers AS M INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(P.Partnumber) AS Partnumbers,SUM(dbo.Sys_UnitConversion(R.Partnumber,P.UoM,P.Quantity,R.UoM) * UnitCost) AS Cost FROM Ord_MoverPartnumbers AS P INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber GROUP BY MoverID) AS P ON M.ID = P.MoverID INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE M.Status = 'N';")
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("show_btn").Index Then
            Dim filename As String = GF.TempPDFPath
            Dim mover As Hashtable = SQL.Current.GetRecord("Ord_Movers", "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
            Dim user_authorization As String = SQL.Current.GetString("FullName", "Sys_Users", "Username", mover("approvalusername"), "")
            Dim type As String = SQL.Current.GetString("[Description]", "Ord_MoverTypes", "[Type]", mover("type"), "")

            Dim pdf As New PDF
            pdf.Title = String.Format("Mover de Material | ID {0}", mover("id"))
            pdf.TitleFontSize = 14
            pdf.Subtitle = String.Format("Planta: {7}{0}Autorizado por: {1}{0}Fecha: {2}{0}Destino: {3}{0}Requisitor: {4}{0}Tipo: {5}{0}Comentario: {6}", vbCrLf, user_authorization, mover("date"), mover("locality"), mover("requisitor"), type, mover("comment"), Parameter("SYS_PlantCode"))
            pdf.Footer = String.Format("Mover de Material | ID {0} | Planta {1}", mover("id"), Parameter("SYS_PlantCode"))
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = SQL.Current.GetDatatable(String.Format("SELECT M.[Partnumber] AS Material,ISNULL([Description],'') AS Descripcion,CASE WHEN M.UoM = 'PC' THEN LEFT(CONVERT(VARCHAR(10),[Quantity]),LEN(CONVERT(VARCHAR(10),[Quantity]))-4) ELSE CONVERT(VARCHAR(10),[Quantity]) END AS Cantidad, M.[UoM] AS Unidad,[TSA] AS TSA,ISNULL(dbo.Smk_Locations(M.[Partnumber]),'') AS [Localizacion] FROM Ord_MoverPartnumbers AS M LEFT OUTER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE MoverID = {0} ORDER BY ISNULL(dbo.Smk_Locations(M.[Partnumber]),'');", mover("id")))
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 11
            pdf.ColumnsWidths = {15, 25, 15, 15, 15, 15}
            If pdf.Save(filename) Then
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                FlashAlerts.ShowError("Error al mostrar mover.")
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("approve_btn").Index Then
            If MessageBox.Show(String.Format("¿Aprobar Mover ID {0}?", Movers_dgv.Rows(e.RowIndex).Cells("id").Value), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If SQL.Current.Update("Ord_Movers", {"Status", "ApprovalUsername"}, {"A", User.Current.Username}, "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value) Then
                    If SQL.Current.GetString("[Type]", "Ord_Movers", "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value, "") = "S" Then 'Samples, Muestras que se requieren hacer movimiento 933
                        If Environment.UserName.ToLower = User.Current.Username Then
                            Dim ma_emails = SQL.Current.GetList("Email", "Sys_Users", {"[Role]", "[Active]"}, {"Material Analyst", 1})
                            Dim html_body As String = My.Resources.ORD_MoverEmailTemplate
                            html_body = html_body.Replace("@id", Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
                            html_body = html_body.Replace("@username", Movers_dgv.Rows(e.RowIndex).Cells("_user").Value)
                            html_body = html_body.Replace("@requisitor", Movers_dgv.Rows(e.RowIndex).Cells("requisitor").Value)
                            html_body = html_body.Replace("@reason", Movers_dgv.Rows(e.RowIndex).Cells("reason").Value)
                            html_body = html_body.Replace("@locality", Movers_dgv.Rows(e.RowIndex).Cells("locality").Value)
                            html_body = html_body.Replace("@comment", Movers_dgv.Rows(e.RowIndex).Cells("comment").Value)
                            Dim parts_html As String = ""
                            Dim partnumbers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT P.Partnumber,R.Description,P.Quantity,P.UoM,dbo.Sys_UnitConversion(R.Partnumber,P.UoM,P.Quantity,R.UoM) * UnitCost AS Cost FROM Ord_MoverPartnumbers AS P INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber WHERE MoverID = {0};", Movers_dgv.Rows(e.RowIndex).Cells("id").Value))
                            For Each part As DataRow In partnumbers.Rows
                                parts_html &= String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", part.Item("Partnumber"), part.Item("Description"), FormatNumber(part.Item("Quantity"), 1), part.Item("UoM"), FormatCurrency(part.Item("Cost"), 1))
                            Next
                            html_body = html_body.Replace("@partnumbers", parts_html)
                            If Mail.OutlookMail("Mover de Muestras Aprobado", html_body, String.Join(";", ma_emails.ToArray), "", "") Then
                                FlashAlerts.ShowConfirm("Analista de Materiales notificado.")
                            Else
                                FlashAlerts.ShowInformation("No fue posible enviar el correo de notificación al analista de materiales.", 3)
                            End If
                        Else
                            FlashAlerts.ShowConfirm(ActiveDirectory.CurrentUser.ToLower)
                            FlashAlerts.ShowInformation("No fue posible enviar el correo de notificación al analista de materiales debido a que se encuentra en otra sesion.", 3)
                        End If
                    End If
                    LoadMovers()
                    FlashAlerts.ShowConfirm("Mover aprobado.")
                Else
                    FlashAlerts.ShowError("Error al aprobar el mover.")
                End If
            End If
        End If
    End Sub

    Private Sub Ord_ApproveMover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadMovers()
    End Sub

    Private Sub Ord_ApproveMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadMovers()
    End Sub
End Class