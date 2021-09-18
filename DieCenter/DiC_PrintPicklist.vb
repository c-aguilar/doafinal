Public Class DiC_PrintPicklist

    Private Sub DiC_PrintPicklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GF.FillCombobox(Warehouse_cbo, SQL.Current.GetDatatable("SELECT Name,Warehouse FROM Smk_Warehouses ORDER BY Name;"), "Name", "Warehouse")
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If Warehouse_cbo.SelectedIndex >= 0 Then
            Dim filename As String = GF.TempPDFPath
            Dim pdf As New PDF
            pdf.Title = String.Format("Picklist de Terminales | {0}", Warehouse_cbo.SelectedValue)
            pdf.TitleFontSize = 14
            pdf.Subtitle = Delta.CurrentDate.ToString("MM/dd/yyyy HH:mm")
            pdf.Footer = String.Format("Picklist de Terminales | {0} | Planta {1}", Warehouse_cbo.SelectedValue, Parameter("SYS_PlantCode"))
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            Dim diecenters = SQL.Current.GetList(String.Format("SELECT DieCenter FROM DiC_Centers WHERE Warehouse = '{0}';", Warehouse_cbo.SelectedValue))
            Dim picklist As New DataTable
            For Each dc In diecenters
                picklist.Merge(GetPicklist(dc.ToString))
            Next
            picklist.DefaultView.Sort = "[Local Serie]"
            pdf.DataSource = picklist.DefaultView.ToTable
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 11
            pdf.ColumnsWidths = {10, 18, 10, 13, 20, 15, 15}
            If pdf.Save(filename) Then
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                FlashAlerts.ShowError("Error al imprimir mover.")
            End If
        End If
    End Sub

    Private Function GetPicklist(diecenter As String) As DataTable
        If Parameter("DiC_FitScanVsSpaces") Then
            Dim noprintedDate = DateAdd(DateInterval.Minute, -1, Delta.CurrentDate)
            'GET IDs WHERE NO LOCATION IS AVAILABLE
            Dim rsNo As DataTable = SQL.Current.GetDatatable(String.Format("SELECT P.ID FROM (SELECT ID,Partnumber,DieCenter,ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist WHERE Printed = 0) AS P LEFT OUTER JOIN (SELECT Partnumber,DieCenter,SUM([Spaces]) AS cnt FROM DiC_Map GROUP BY DieCenter,Partnumber) AS D ON P.Partnumber = D.Partnumber AND P.DieCenter = D.DieCenter WHERE P.DieCenter = '{0}' AND P.row > ISNULL(D.cnt,0);", diecenter))
            For Each row As DataRow In rsNo.Rows
                SQL.Current.Update("DiC_Picklist", {"Printed", "PrintedDate", "PrintedSerialnumber"}, {1, noprintedDate, -1}, {"ID"}, {row.Item("ID")})
            Next
        End If

        Dim picklist As DataTable
        If Parameter("DiC_PrintOnlyAvailable") Then
            picklist = SQL.Current.GetDatatable(String.Format("SELECT DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],CASE WHEN S.Status IN ('O','C') THEN S.ServiceLocation ELSE S.RandomLocation END [Local Serie],S.StatusDescription AS [Estatus],Serialnumber AS Serie,P.Partnumber AS [No.Parte],dbo.DiC_Locations(P.Partnumber,P.DieCenter) AS [Local CDD],P.ID,S.ID AS SerialID FROM " & _
                                              "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                              "WHERE Printed = 0) AS P LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, RandomLocation, ServiceLocation, Status, StatusDescription, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                              "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','C','N','P')) AS S ON " & _
                                              "P.Partnumber = S.Partnumber AND P.row = S.row WHERE Serialnumber IS NOT NULL AND P.DieCenter = '{0}' ORDER BY CASE WHEN S.Status IN ('O','C') THEN S.ServiceLocation ELSE S.RandomLocation END", diecenter))
        Else
            picklist = SQL.Current.GetDatatable(String.Format("SELECT DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],CASE WHEN S.Status IN ('O','C') THEN S.ServiceLocation ELSE S.RandomLocation END [Local Serie],S.StatusDescription AS [Estatus],Serialnumber AS Serie,P.Partnumber AS [No.Parte],dbo.DiC_Locations(P.Partnumber,P.DieCenter) AS [Local CDD],P.ID,S.ID AS SerialID FROM " & _
                                              "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                              "WHERE Printed = 0) AS P LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, RandomLocation, ServiceLocation, Status, StatusDescription, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                              "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','C','N','P')) AS S ON " & _
                                              "P.Partnumber = S.Partnumber AND P.row = S.row WHERE P.DieCenter = '{0}' ORDER BY CASE WHEN S.Status IN ('O','C') THEN S.ServiceLocation ELSE S.RandomLocation END", diecenter))
        End If

        Dim printedDate = Delta.CurrentDate
        If Parameter("DiC_EmptyAfterPrint") Then
            For Each row As DataRow In picklist.Rows
                SQL.Current.Update("DiC_Picklist", {"Printed", "PrintedDate", "PrintedSerialnumber"}, {1, printedDate, IIf(IsDBNull(row.Item("SerialID")), 0, row.Item("SerialID"))}, {"ID"}, {row.Item("ID")})
            Next
        End If
        Return picklist.DefaultView.ToTable(False, "CDD", "Local Supermercado", "Local Serie", "Estatus", "Serie", "No.Parte", "Local CDD")
    End Function

    Private Sub DiC_PrintPicklist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class