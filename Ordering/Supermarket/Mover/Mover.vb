Public Class Mover

    Public Shared Sub Print(ID As Integer)
        Try
            Dim filename As String = GF.TempPDFPath
            Dim mover As Hashtable = SQL.Current.GetRecord("Ord_Movers", "ID", ID)
            Dim user_authorization As String = SQL.Current.GetString("FullName", "Sys_Users", "Username", mover("approvalusername"), "")
            Dim type As String = SQL.Current.GetString("[Description]", "Ord_MoverTypes", "[Type]", mover("type"), "")
            Dim pdf As New PDF
            pdf.Title = String.Format("Mover de Material | ID {0}", ID)
            pdf.TitleFontSize = 14
            pdf.Subtitle = String.Format("Planta: {7}{0}Autorizado por: {1}{0}Fecha: {2}{0}Destino: {3}{0}Requisitor: {4}{0}Tipo: {5}{8}{0}Comentario: {6}", vbCrLf, user_authorization, Mover("date"), Mover("locality"), Mover("requisitor"), Type, Mover("comment"), Parameter("SYS_PlantCode"), If(Mover("shippingdate") = "", "", vbCrLf & "Fecha Requerida de Embarque: " & CDate(Mover("shippingdate")).ToShortDateString))
            pdf.Footer = String.Format("Mover de Material | ID {0} | Planta {1}", ID, Parameter("SYS_PlantCode"))
            pdf.TextAfterTable = String.Format("{0}Surtido por: ________________        Transferido por: ________________        Embarcado por: ________________{0}{0}Fecha:        ________________         No. Documento:________________        Fecha:                ________________ ", vbCrLf)
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = SQL.Current.GetDatatable(String.Format("SELECT M.[Partnumber] AS Material,ISNULL([Description],'') AS Descripcion,CASE WHEN M.UoM = 'PC' THEN LEFT(CONVERT(VARCHAR(10),[Quantity]),LEN(CONVERT(VARCHAR(10),[Quantity]))-4) ELSE CONVERT(VARCHAR(10),[Quantity]) END AS Cantidad, M.[UoM] AS Unidad,[TSA] AS TSA,ISNULL(dbo.Smk_Locations(M.[Partnumber]),'') AS [Localizacion] FROM Ord_MoverPartnumbers AS M LEFT OUTER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE MoverID = {0} ORDER BY ISNULL(dbo.Smk_Locations(M.[Partnumber]),'');", ID))
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
                FlashAlerts.ShowError("Error al imprimir el mover.")
            End If
        Catch ex As Exception
            FlashAlerts.ShowError("Error al imprimir el mover.")
        End Try
    End Sub

    Public Shared Sub PrintLabels(ID As Integer)
        Try
            Dim partnumbers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT M.ID,M.[Partnumber],ISNULL([Description],'') AS Descripcion,[Quantity], M.[UoM],[TSA] AS TSA,ISNULL(dbo.Smk_Locations(M.[Partnumber]),'') AS [Local] FROM Ord_MoverPartnumbers AS M LEFT OUTER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE MoverID = {0} ORDER BY ISNULL(dbo.Smk_Locations(M.[Partnumber]),'');", ID))
            Dim zpl_labels As String = ""
            Dim zpl_template As String = ZPL.TryChangeResolution(My.Resources.ZPL_MoverLabel, 300, My.Settings.PrinterResolution)
            For Each part As DataRow In partnumbers.Rows
                zpl_labels &= zpl_template.Replace("@moverid", ID).Replace("@partnumber", part.Item("Partnumber")).Replace("@quantity", IIf(part.Item("UoM") = "PC", CInt(part.Item("Quantity")), part.Item("Quantity"))).Replace("@uom", part.Item("UoM")).Replace("@local", part.Item("Local")).Replace("@partid", part.Item("ID"))
            Next
            ZPL.PrintTo(zpl_labels)
            FlashAlerts.ShowConfirm("Impresión enviada.")
        Catch ex As Exception
            FlashAlerts.ShowError("Error al imprimir el mover.")
        End Try
    End Sub

    Public Shared Sub Export(ID As Integer)
        Try
            LoadingScreen.Show()
            Dim partnumbers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT [Partnumber],[Quantity], [UoM],[TSA] AS TSA FROM Ord_MoverPartnumbers  WHERE MoverID = {0};", ID))
            If MyExcel.SaveAs(partnumbers, "Mover " & ID, False) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
        End Try
    End Sub
End Class
