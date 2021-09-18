Public Class Smk_PrintMover
    Private Sub Smk_PrintMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Movers_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
        CType(Movers_dgv.Columns("labels_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.tag_blue_16
        CType(Movers_dgv.Columns("export_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.excel_exports_16
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.Status IN ('{0}','{1}','{2}');", If(Approved_chk.Checked, "A", ""), If(PickedUp_chk.Checked, "P", ""), If(Shipped_chk.Checked, "S", "")))
        Movers_dgv.DataSource = movers
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("print_btn").Index Then
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
                FlashAlerts.ShowError("Error al imprimir el mover.")
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("labels_btn").Index Then
            Dim partnumbers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT M.ID,M.[Partnumber],ISNULL([Description],'') AS Descripcion,[Quantity], M.[UoM],[TSA] AS TSA,ISNULL(dbo.Smk_Locations(M.[Partnumber]),'') AS [Local] FROM Ord_MoverPartnumbers AS M LEFT OUTER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE MoverID = {0} ORDER BY ISNULL(dbo.Smk_Locations(M.[Partnumber]),'');", Movers_dgv.Rows(e.RowIndex).Cells("id").Value))
            Dim zpl_labels As String = ""
            For Each part As DataRow In partnumbers.Rows
                zpl_labels &= My.Resources.ZPL_MoverLabel.Replace("@moverid", Movers_dgv.Rows(e.RowIndex).Cells("id").Value).Replace("@partnumber", part.Item("Partnumber")).Replace("@quantity", IIf(part.Item("UoM") = "PC", CInt(part.Item("Quantity")), part.Item("Quantity"))).Replace("@uom", part.Item("UoM")).Replace("@local", part.Item("Local")).Replace("@partid", part.Item("ID"))
            Next
            ZPL.PrintTo(zpl_labels)
            FlashAlerts.ShowConfirm("Impresion enviada.")
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("export_btn").Index Then
            LoadingScreen.Show()
            Dim partnumbers As DataTable = SQL.Current.GetDatatable(String.Format("SELECT [Partnumber],[Quantity], [UoM],[TSA] AS TSA FROM Ord_MoverPartnumbers  WHERE MoverID = {0};", Movers_dgv.Rows(e.RowIndex).Cells("id").Value))
            If MyExcel.SaveAs(partnumbers, "Mover " & Movers_dgv.Rows(e.RowIndex).Cells("id").Value, False) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Shipped_chk.CheckedChanged, PickedUp_chk.CheckedChanged, Approved_chk.CheckedChanged
        LoadMovers()
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        LoadMovers()
    End Sub

    Private Sub Smk_PrintMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Smk_PrintMover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadMovers()
    End Sub
End Class