Public Class DiC_PrintPicklist

    Private Sub DiC_PrintPicklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ZPL_chk.Checked = My.Settings.DiC_Picklist_ZPL
        GF.FillCombobox(Warehouse_cbo, SQL.Current.GetDatatable("SELECT Name,Warehouse FROM Smk_Warehouses ORDER BY Name;"), "Name", "Warehouse")
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If Warehouse_cbo.SelectedIndex >= 0 Then
            If ZPL_chk.Checked Then
                Dim zpl_label As String = ""
                Dim diecenters = SQL.Current.GetList(String.Format("SELECT DieCenter FROM DiC_Centers WHERE Warehouse = '{0}' AND Active = 1;", Warehouse_cbo.SelectedValue))
                Dim picklists As New List(Of DataTable)
                For Each dc In diecenters
                    Dim pick_list As DataTable = GetPicklist(dc.ToString)
                    pick_list.DefaultView.Sort = "[Local Serie]"
                    If pick_list.Rows.Count > 0 Then picklists.Add(pick_list)
                Next

                If picklists.Count = 0 Then
                    FlashAlerts.ShowInformation("Nada para imprimir.")
                    Exit Sub
                End If

                For Each pick_list As DataTable In picklists
                    For i = 0 To pick_list.Rows.Count - 1 Step 5
                        zpl_label &= ZPL.TryChangeResolution(My.Resources.ZPL_DicPicklist_6Cols_Vertical, 300, My.Settings.PrinterResolution)
                        Dim row As String = ""
                        For j = 0 To 4
                            If pick_list.Rows.Count > (i + j) Then
                                row &= ZPL.TryChangeResolution(My.Resources.ZPL_DicPicklist_6Cols_Row_Vertical.Replace("@item", j + 1), 300, My.Settings.PrinterResolution).Replace("@cdd", NullReplace(pick_list.Rows(i + j).Item("CDD"), "")).Replace("@smk", NullReplace(pick_list.Rows(i + j).Item("Local Supermercado"), "")).Replace("@local", NullReplace(pick_list.Rows(i + j).Item("Local Serie"), "")).Replace("@status", NullReplace(pick_list.Rows(i + j).Item("Estatus"), "")).Replace("@serial", NullReplace(pick_list.Rows(i + j).Item("Serie"), "")).Replace("@np", NullReplace(pick_list.Rows(i + j).Item("No.Parte"), ""))
                            End If
                        Next
                        zpl_label = zpl_label.Replace("@row", row)
                    Next
                Next

                ZPL.PrintTo(zpl_label, My.Settings.Printer)
                While MessageBox.Show("Impresión enviada ¿Reimprimir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
                    ZPL.PrintTo(zpl_label, My.Settings.Printer)
                End While
                FlashAlerts.ShowConfirm("Picklist impreso.")
            Else
                Dim filename As String = GF.TempPDFPath
                Dim pdf As New PDF
                pdf.Title = String.Format("Picklist de Terminales | {0}", Warehouse_cbo.SelectedItem.ToString)
                pdf.TitleFontSize = 14
                pdf.Subtitle = Delta.CurrentDate.ToString("MM/dd/yyyy HH:mm")
                pdf.Footer = String.Format("Picklist de Terminales | {0} | Planta {1}", Warehouse_cbo.SelectedValue, Parameter("SYS_PlantCode"))
                pdf.PageNumber = True
                pdf.Logo = New PDF.Logotype()
                pdf.Logo.Image = My.Resources.APTIV
                pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
                pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
                Dim diecenters = SQL.Current.GetList(String.Format("SELECT DieCenter FROM DiC_Centers WHERE Warehouse = '{0}' AND Active = 1;", Warehouse_cbo.SelectedValue))
                Dim picklist As New DataTable
                For Each dc In diecenters
                    picklist.Merge(GetPicklist(dc.ToString))
                Next
                picklist.DefaultView.Sort = "[Local Serie]"
                pdf.DataSource = picklist.DefaultView.ToTable
                pdf.HeaderFontSize = 10
                pdf.CellFontSize = 11

                If picklist.Columns.Count = 7 Then
                    pdf.ColumnsWidths = {10, 18, 10, 13, 20, 15, 15}
                ElseIf picklist.Columns.Count = 6 Then
                    pdf.ColumnsWidths = {10, 18, 10, 13, 20, 15}
                End If


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


        End If
    End Sub

    Private Function GetPicklist(diecenter As String) As DataTable
        Dim withinterminals As Boolean = SQL.Current.Exists("DiC_Centers", {"WithinTerminals", "DieCenter"}, {1, diecenter})
        If Parameter("DiC_FitScanVsSpaces") AndAlso withinterminals Then
            Dim noprintedDate = DateAdd(DateInterval.Minute, -1, Delta.CurrentDate)
            'GET IDs WHERE NO LOCATION IS AVAILABLE
            Dim rsNo As DataTable = SQL.Current.GetDatatable(String.Format("SELECT P.ID FROM (SELECT ID,Partnumber,DieCenter,ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist WHERE Printed = 0) AS P LEFT OUTER JOIN (SELECT Partnumber,DieCenter,SUM([Spaces]) AS cnt FROM DiC_Map GROUP BY DieCenter,Partnumber) AS D ON P.Partnumber = D.Partnumber AND P.DieCenter = D.DieCenter WHERE P.DieCenter = '{0}' AND P.row > ISNULL(D.cnt,0);", diecenter))
            For Each row As DataRow In rsNo.Rows
                SQL.Current.Update("DiC_Picklist", {"Printed", "PrintedDate", "PrintedSerialnumber"}, {1, noprintedDate, -1}, {"ID"}, {row.Item("ID")})
            Next
        End If

        Dim picklist As DataTable
        If withinterminals Then
            If Parameter("DiC_PrintOnlyAvailable") Then
                picklist = SQL.Current.GetDatatable(String.Format("SELECT P.DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],ISNULL(S.Location,S2.Location) [Local Serie],ISNULL(S.StatusDescription,S2.StatusDescription) AS [Estatus],ISNULL(S.Serialnumber,S2.Serialnumber) AS Serie,P.Partnumber + CASE WHEN F.RewindToDiC = 1 THEN ' (Voltear)' ELSE '' END AS [No.Parte],dbo.DiC_Locations(P.Partnumber,P.DieCenter) AS [Local CDD],P.ID,ISNULL(S.ID,S2.ID) AS SerialID FROM " & _
                                                  "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                                  "WHERE Printed = 0) AS P INNER JOIN DiC_Centers AS C ON P.DieCenter = C.DieCenter LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber, Warehouse ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S ON " & _
                                                  "P.Partnumber = S.Partnumber AND P.row = S.row AND C.Warehouse = S.Warehouse " & _
                                                  "LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S2 ON " & _
                                                  "P.Partnumber = S2.Partnumber AND P.row = S2.row " & _
                                                  "LEFT OUTER JOIN Sys_RawMaterial AS F ON P.Partnumber = F.Partnumber " & _
                                                  "WHERE ISNULL(S.Serialnumber,S2.Serialnumber) IS NOT NULL AND P.DieCenter = '{0}' ORDER BY ISNULL(S.Location,S2.Location)", diecenter))
            Else
                picklist = SQL.Current.GetDatatable(String.Format("SELECT P.DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],ISNULL(S.Location,S2.Location) [Local Serie],ISNULL(S.StatusDescription,S2.StatusDescription) AS [Estatus],ISNULL(S.Serialnumber,S2.Serialnumber) AS Serie,P.Partnumber + CASE WHEN F.RewindToDic = 1 THEN ' (Voltear)' ELSE '' END AS [No.Parte],dbo.DiC_Locations(P.Partnumber,P.DieCenter) AS [Local CDD],P.ID,ISNULL(S.ID,S2.ID) AS SerialID FROM " & _
                                                  "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                                  "WHERE Printed = 0) AS P INNER JOIN DiC_Centers AS C ON P.DieCenter = C.DieCenter LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber, Warehouse ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S ON " & _
                                                  "P.Partnumber = S.Partnumber AND P.row = S.row AND C.Warehouse = S.Warehouse " & _
                                                  "LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S2 ON " & _
                                                  "P.Partnumber = S2.Partnumber AND P.row = S2.row " & _
                                                  "LEFT OUTER JOIN Sys_RawMaterial AS F ON P.Partnumber = F.Partnumber " & _
                                                  "WHERE P.DieCenter = '{0}' ORDER BY ISNULL(S.Location,S2.Location)", diecenter))
            End If
        Else 'CENTRO DE DADOS NO TIENE TERMINALES DENTRO
            If Parameter("DiC_PrintOnlyAvailable") Then
                picklist = SQL.Current.GetDatatable(String.Format("SELECT P.DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],ISNULL(S.Location,S2.Location) [Local Serie],ISNULL(S.StatusDescription,S2.StatusDescription) AS [Estatus],ISNULL(S.Serialnumber,S2.Serialnumber) AS Serie,P.Partnumber + CASE WHEN F.RewindToDiC = 1 THEN ' (Voltear)' ELSE '' END AS [No.Parte],P.ID,ISNULL(S.ID,S2.ID) AS SerialID FROM " & _
                                                  "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                                  "WHERE Printed = 0) AS P INNER JOIN DiC_Centers AS C ON P.DieCenter = C.DieCenter LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber, Warehouse ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S ON " & _
                                                  "P.Partnumber = S.Partnumber AND P.row = S.row AND C.Warehouse = S.Warehouse " & _
                                                  "LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S2 ON " & _
                                                  "P.Partnumber = S2.Partnumber AND P.row = S2.row " & _
                                                  "LEFT OUTER JOIN Sys_RawMaterial AS F ON P.Partnumber = F.Partnumber " & _
                                                  "WHERE ISNULL(S.Serialnumber,S2.Serialnumber) IS NOT NULL AND P.DieCenter = '{0}' ORDER BY ISNULL(S.Location,S2.Location)", diecenter))
            Else
                picklist = SQL.Current.GetDatatable(String.Format("SELECT P.DieCenter AS [CDD],dbo.Smk_Locations(P.Partnumber) AS [Local Supermercado],ISNULL(S.Location,S2.Location) [Local Serie],ISNULL(S.StatusDescription,S2.StatusDescription) AS [Estatus],ISNULL(S.Serialnumber,S2.Serialnumber) AS Serie,P.Partnumber + CASE WHEN F.RewindToDic = 1 THEN ' (Voltear)' ELSE '' END AS [No.Parte],P.ID,ISNULL(S.ID,S2.ID) AS SerialID FROM " & _
                                                  "(SELECT ID, Partnumber, DieCenter, ROW_NUMBER() OVER(PARTITION BY Partnumber,DieCenter ORDER BY [Date] ASC) AS row FROM DiC_Picklist " & _
                                                  "WHERE Printed = 0) AS P INNER JOIN DiC_Centers AS C ON P.DieCenter = C.DieCenter LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber, Warehouse ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S ON " & _
                                                  "P.Partnumber = S.Partnumber AND P.row = S.row AND C.Warehouse = S.Warehouse " & _
                                                  "LEFT OUTER JOIN (SELECT ID, Partnumber, Serialnumber, Location, Status, StatusDescription, Warehouse, ROW_NUMBER() OVER(PARTITION BY PartNumber ORDER BY ID ASC) AS row " & _
                                                  "FROM vw_Smk_Serials WHERE [Status] IN ('S','O','N','P')) AS S2 ON " & _
                                                  "P.Partnumber = S2.Partnumber AND P.row = S2.row " & _
                                                  "LEFT OUTER JOIN Sys_RawMaterial AS F ON P.Partnumber = F.Partnumber " & _
                                                  "WHERE P.DieCenter = '{0}' ORDER BY ISNULL(S.Location,S2.Location)", diecenter))
            End If
        End If

        Dim printedDate = Delta.CurrentDate
        If Parameter("DiC_EmptyAfterPrint") Then
            For Each row As DataRow In picklist.Rows
                SQL.Current.Update("DiC_Picklist", {"Printed", "PrintedDate", "PrintedSerialnumber"}, {1, printedDate, IIf(IsDBNull(row.Item("SerialID")), 0, row.Item("SerialID"))}, {"ID"}, {row.Item("ID")})
            Next
        End If
        If withinterminals Then
            Return picklist.DefaultView.ToTable(False, "CDD", "Local Supermercado", "Local Serie", "Estatus", "Serie", "No.Parte", "Local CDD")
        Else
            Return picklist.DefaultView.ToTable(False, "CDD", "Local Supermercado", "Local Serie", "Estatus", "Serie", "No.Parte")
        End If
    End Function

    Private Sub DiC_PrintPicklist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ZPL_chk_CheckedChanged(sender As Object, e As EventArgs) Handles ZPL_chk.CheckedChanged
        My.Settings.DiC_Picklist_ZPL = ZPL_chk.Checked
        My.Settings.Save()
    End Sub
End Class