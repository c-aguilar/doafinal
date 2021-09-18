Imports System.Globalization
Public Class MAn_SamplesMaterialMovers_mi

    Private Sub MAn_SamplesMaterialMovers_mi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("show_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.folder_16
        CType(Movers_dgv.Columns("post_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.run_macros_16
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable("SELECT M.ID, U.FullName, Requisitor, M.Reason, Customer, Partnumbers, Cost, T.[Description], Locality, M.[Date], M.Comment FROM Ord_Movers AS M INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(P.Partnumber) AS Partnumbers,SUM(dbo.Sys_UnitConversion(R.Partnumber,P.UoM,P.Quantity,R.UoM) * UnitCost) AS Cost FROM Ord_MoverPartnumbers AS P INNER JOIN Sys_RawMaterial AS R ON P.Partnumber = R.Partnumber GROUP BY MoverID) AS P ON M.ID = P.MoverID INNER JOIN Sys_Users AS U ON M.Username = U.Username WHERE M.Status IN ('A','P','S') AND Document IS NULL AND M.[Type] = 'S';")
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
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("post_btn").Index Then
            Dim sap As New SAP
            If sap.Available Then
                Dim eb_costcenter As New EnterBox
                eb_costcenter.Title = "MB1A"
                eb_costcenter.Question = "Cost Center:"
                eb_costcenter.Answer = Parameter("MAn_MB1A_SamplesCostCenter")
                eb_costcenter.AcceptByEnter = True

                Dim eb_sloc As New EnterBox
                eb_sloc.Title = "MB1A"
                eb_sloc.Question = "Sloc:"
                eb_sloc.Answer = Parameter("MAn_MB1A_SamplesSloc")
                eb_sloc.AcceptByEnter = True

                Dim eb_reason As New EnterBox
                eb_reason.Title = "MB1A"
                eb_reason.Question = "Reason for Mvmt:"
                eb_reason.Answer = "0001"
                eb_reason.AcceptByEnter = True

                Dim eb_text As New EnterBox
                eb_text.Title = "MB1A"
                eb_text.Question = "Text:"
                eb_text.Answer = "Muestras"
                eb_text.AcceptByEnter = True


                If eb_costcenter.ShowDialog = Windows.Forms.DialogResult.OK AndAlso eb_sloc.ShowDialog = Windows.Forms.DialogResult.OK AndAlso eb_reason.ShowDialog = Windows.Forms.DialogResult.OK AndAlso eb_text.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim mover_parts As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber,Quantity,UoM FROM Ord_MoverPartnumbers WHERE MoverID = {0};", Movers_dgv.Rows(e.RowIndex).Cells("id").Value))
                    Dim partnumbers, quantities, uoms As New ArrayList
                    For Each part As DataRow In mover_parts.Rows
                        partnumbers.Add(part.Item("Partnumber"))
                        quantities.Add(String.Format(CultureInfo.InvariantCulture, "{0:0,0.000}", part.Item("Quantity")))
                        uoms.Add(part.Item("UoM"))
                    Next
                    Dim doc As String = sap.MB1A(Parameter("SYS_PlantCode"), "933", eb_sloc.Answer, partnumbers, quantities, uoms, eb_text.Answer, eb_costcenter.Answer, eb_reason.Answer)
                    If doc <> "#error" AndAlso doc.ToLower.Contains("document") Then
                        SQL.Current.Update("Ord_Movers", "Document", CLng(doc.ToLower.Replace("document", "").Replace("posted", "").Trim), "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
                        LoadMovers()
                        FlashAlerts.ShowConfirm("Movimientos 933 realizados.")
                    Else
                        FlashAlerts.ShowError("Error al realizar las transferencias.")
                    End If
                    eb_reason.Dispose()
                    eb_text.Dispose()
                Else
                    FlashAlerts.ShowInformation("Operacion cancelada.")
                End If
            Else
                FlashAlerts.ShowError(Language.Sentence(267))
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