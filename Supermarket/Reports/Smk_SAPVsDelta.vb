Public Class Smk_SAPVsDelta
    Dim selected_partnumbers As New List(Of String)
    Dim selected_sloc As String
    Dim serialnumbers As List(Of Serialnumber)
    Dim report As DataTable
    Dim audit_report As DataTable
    Private Sub Smk_SAPVsDelta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Sloc_cbo, SQL.Current.GetDatatable("SELECT DISTINCT Sloc FROM (SELECT DISTINCT RandomSloc AS Sloc FROM Smk_SAPSlocs UNION SELECT DISTINCT ServiceSloc FROM Smk_SAPSlocs) AS Slocs ORDER BY Sloc"), "Sloc", "Sloc")
    End Sub

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(RawMaterial.Format(p)) Then
                    selected_partnumbers.Add(RawMaterial.Format(p))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        If Sloc_cbo.SelectedIndex >= 0 Then
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Serials_dgv.Rows.Clear()
                serialnumbers = New List(Of Serialnumber)
                For i = 0 To selected_partnumbers.Count - 1
                    selected_partnumbers.Item(i) = RawMaterial.Format(selected_partnumbers(i))
                Next
                Dim filename As String = GF.TempTXTPath
                Dim mb52_report As DataTable
                Dim transfer_pending As DataTable
                Dim mspec_serials_filter, location_serial_filter As String
                If IgnoreMSpec_rb.Checked Then
                    mspec_serials_filter = "MaterialType NOT IN ('Cable','Calibre') AND"
                ElseIf OnlyMspec_rb.Checked Then
                    mspec_serials_filter = "MaterialType IN ('Cable','Calibre') AND"
                Else
                    mspec_serials_filter = ""
                End If

                If LocationA_txt.Text.Trim <> "" AndAlso LocationA_txt.Text.Trim <> "*" Then
                    If Integer.TryParse(LocationA_txt.Text, Nothing) Then
                        If LocationB_txt.Text <> "" Then
                            If Integer.TryParse(LocationB_txt.Text, Nothing) Then
                                location_serial_filter = String.Format("(([Partnumber] IN (SELECT Partnumber FROM Smk_Map WHERE CONVERT(INTEGER,[Location]) BETWEEN {0} AND {1}))) AND", Strings.Left(LocationA_txt.Text.Trim & "00000000", 8), Strings.Left(LocationB_txt.Text.Trim & "00000000", 8))
                            Else
                                FlashAlerts.ShowError("Rango de locales incorrecto.")
                                Exit Sub
                            End If
                        Else
                            location_serial_filter = String.Format("(([Partnumber] IN (SELECT Partnumber FROM Smk_Map WHERE [Location] LIKE '{0}%'))) AND", LocationA_txt.Text.Trim)
                        End If
                    Else
                        FlashAlerts.ShowError("Local incorrecto.")
                        Exit Sub
                    End If
                Else
                    location_serial_filter = ""
                End If
                selected_sloc = Sloc_cbo.SelectedValue

                Dim serial_list As DataTable
                If selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "") AndAlso sap.MB52(Parameter("SYS_PlantCode"), "*", selected_sloc, filename) Then
                    serial_list = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE {0} {1} ({2});", mspec_serials_filter, location_serial_filter, String.Format(" Sloc = '{0}'", selected_sloc)))
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,CASE WHEN FromSloc = '{0}' THEN T.Quantity ELSE -T.Quantity END,R.UoM)) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE (FromSloc= '{0}' OR ToSloc = '{0}') AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue))
                ElseIf selected_partnumbers.Count = 0 AndAlso sap.MB52(Parameter("SYS_PlantCode"), Partnumber_txt.Text, selected_sloc, filename) Then
                    serial_list = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE ({0}) AND {1} Partnumber = '{2}';", String.Format(" Sloc = '{0}'", selected_sloc), location_serial_filter, Partnumber_txt.Text))
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,CASE WHEN FromSloc = '{0}' THEN T.Quantity ELSE -T.Quantity END,R.UoM)) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE (FromSloc= '{0}' OR ToSloc = '{0}') AND S.Partnumber = '{1}' AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue, RawMaterial.Format(Partnumber_txt.Text)))
                ElseIf selected_partnumbers.Count > 0 AndAlso sap.MB52(Parameter("SYS_PlantCode"), selected_partnumbers.ToArray, selected_sloc, filename) Then
                    serial_list = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_Smk_Serials WHERE ({0}) AND {1} Partnumber IN ('{2}');", String.Format(" Sloc = '{0}'", selected_sloc), location_serial_filter, String.Join("','", selected_partnumbers.ToArray)))
                    transfer_pending = SQL.Current.GetDatatable(String.Format("SELECT S.Partnumber,SUM(dbo.Sys_UnitConversion(S.Partnumber,S.UoM,CASE WHEN FromSloc = '{0}' THEN T.Quantity ELSE -T.Quantity END,R.UoM)) AS Quantity FROM Smk_SAPTransfers AS T INNER JOIN Smk_SerialMovements AS M ON T.MovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID  = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE (FromSloc= '{0}' OR ToSloc = '{0}') AND S.Partnumber IN ('{1}') AND Posted = 0 AND FromSloc <>  ToSloc GROUP BY S.Partnumber", Sloc_cbo.SelectedValue, String.Join("','", selected_partnumbers.ToArray)))
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error al obtener el inventario de SAP.", MsgBoxStyle.Critical, APP)
                    Exit Sub
                End If

                Dim create_query As String = "CREATE TABLE #mb52 (Partnumber [char](8) NOT NULL,UnrestrictedStock [decimal](13,3) NOT NULL)"

                Dim mb52 As DataTable = CSV.Datatable(filename, vbTab, True, True, 0) 'VACIAR INVENTARIO EN DATATABLE
                mb52.Columns.Add("Partnumber", GetType(String), "SUBSTRING('00000000' + [Material Number],LEN('00000000' + [Material Number]) - 7,8)")
                mb52.Columns.Add("Inventario", GetType(Decimal), "Convert(IIF([Unrestricted] <> '', [Unrestricted], 0),'System.Decimal')")
                mb52.Columns.Add("Bloqueado", GetType(Decimal), "Convert(IIF([Blocked] <> '', [Blocked], 0),'System.Decimal')")
                mb52.Columns.Add("Total", GetType(Decimal), "Inventario + Bloqueado")
                mb52_report = mb52.DefaultView.ToTable(False, "Partnumber", "Total")


                Dim filterd_zapi As DataTable
                If selected_partnumbers.Count > 0 Then
                    filterd_zapi = SQL.Current.BulkNSelect(mb52_report, "mb52", create_query, String.Format("SELECT R.Partnumber,ISNULL(Z.UnrestrictedStock,0.000) AS UnrestrictedStock FROM Sys_RawMaterial AS R LEFT OUTER JOIN #mb52 AS Z ON Z.Partnumber = R.Partnumber WHERE R.Partnumber IN ('{0}')", String.Join("','", selected_partnumbers.ToArray)))
                ElseIf Partnumber_txt.Text <> "" AndAlso Partnumber_txt.Text <> "*" Then
                    filterd_zapi = SQL.Current.BulkNSelect(mb52_report, "mb52", create_query, String.Format("SELECT R.Partnumber,ISNULL(Z.UnrestrictedStock,0.000) AS UnrestrictedStock FROM Sys_RawMaterial AS R LEFT OUTER JOIN #mb52 AS Z ON Z.Partnumber = R.Partnumber WHERE R.Partnumber IN ('{0}')", Partnumber_txt.TabIndex))
                Else
                    If IgnoreMSpec_rb.Checked Then
                        filterd_zapi = SQL.Current.BulkNSelect(mb52_report, "mb52", create_query, "SELECT Z.Partnumber,Z.UnrestrictedStock FROM #mb52 AS Z INNER JOIN Sys_RawMaterial AS R ON Z.Partnumber = R.Partnumber WHERE R.MaterialType NOT IN ('Cable','Calibre')")
                    ElseIf OnlyMspec_rb.Checked Then
                        filterd_zapi = SQL.Current.BulkNSelect(mb52_report, "mb52", create_query, "SELECT Z.Partnumber,Z.UnrestrictedStock FROM #mb52 AS Z INNER JOIN Sys_RawMaterial AS R ON Z.Partnumber = R.Partnumber WHERE R.MaterialType IN  ('Cable','Calibre')")
                    Else
                        filterd_zapi = SQL.Current.BulkNSelect(mb52_report, "mb52", create_query, "SELECT Z.Partnumber,Z.UnrestrictedStock FROM #mb52 AS Z INNER JOIN Sys_RawMaterial AS R ON Z.Partnumber = R.Partnumber")
                    End If
                End If




                Dim partnumbers As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,Description,UnitCost,UoM FROM Sys_RawMaterial")
                partnumbers.PrimaryKey = {partnumbers.Columns("Partnumber")}


                For Each s As DataRow In serial_list.Rows
                    serialnumbers.Add(New Serialnumber(s("Serialnumber"), s("Partnumber"), s("OriginalQuantity"), s("CurrentQuantity"), s("CurrentQuantityInBuM"), s("UoM"), s("Date"), s("Warehouse"), s("WarehouseName"), s("ConsumptionType"), s("Sloc"), s("Status"), s("StatusDescription"), NullReplace(s("Location"), ""), s("Weight"), NullReplace(s("ContainerID"), ""), NullReplace(s("TruckNumber"), ""), s("RedTag"), s("InvoiceTrouble"), s("Critical"), s("Scanner"), NullReplace(s("ExpirationDate"), New Date(2100, 12, 31)), NullReplace(s("Lot"), ""), s("ID"), s("MaterialType"), s("RandomSloc"), s("ServiceSloc"), s("DullSloc"), s("MRP"), s("New"), s("OrderingWIPAutoincrement"), s("IsSensitive"), NullReplace(s("Masternumber"), ""), NullReplace(s("Linklabel"), "")))
                Next



                report = New DataTable("Comparativo")
                report.Columns.Add("No. de Parte")
                report.Columns.Add("Cantidad en Delta", GetType(Decimal))
                report.Columns.Add("Pendiente por Transferir", GetType(Decimal))
                report.Columns.Add("Cantidad en SAP", GetType(Decimal))
                report.Columns.Add("Diferencia", GetType(Decimal), "[Cantidad en Delta] + [Pendiente por Transferir] - [Cantidad en SAP]")
                report.Columns.Add("Unidad")
                report.Columns.Add("UC", GetType(Decimal))
                report.Columns.Add("Costo", GetType(Decimal), "Diferencia * UC")
                report.PrimaryKey = {report.Columns("No. de Parte")}
                report.Columns("Cantidad en Delta").DefaultValue = 0
                report.Columns("Cantidad en SAP").DefaultValue = 0


                If LocationA_txt.Text <> "" AndAlso LocationA_txt.Text <> "*" Then
                    For Each s As Serialnumber In serialnumbers
                        Dim row = report.Rows.Find(s.Partnumber)
                        If row Is Nothing Then
                            report.Rows.Add(s.Partnumber, s.CurrentQuantityInBum, 0, 0)
                        Else
                            row.Item("Cantidad en Delta") = row.Item("Cantidad en Delta") + s.CurrentQuantityInBum
                        End If
                    Next
                    For Each p As DataRow In filterd_zapi.Rows
                        Dim row = report.Rows.Find(p.Item("Partnumber"))
                        If row IsNot Nothing Then
                            row.Item("Cantidad en SAP") = p.Item("UnrestrictedStock")
                        End If
                    Next
                Else
                    For Each p As DataRow In filterd_zapi.Rows
                        report.Rows.Add(p.Item("Partnumber"), 0, 0, p.Item("UnrestrictedStock"))
                    Next
                    For Each s As Serialnumber In serialnumbers
                        Dim row = report.Rows.Find(s.Partnumber)
                        If row Is Nothing Then
                            report.Rows.Add(s.Partnumber, s.CurrentQuantityInBum, 0, 0)
                        Else
                            row.Item("Cantidad en Delta") = row.Item("Cantidad en Delta") + s.CurrentQuantityInBum
                        End If
                    Next
                End If
                For Each p As DataRow In transfer_pending.Rows
                    Dim row = report.Rows.Find(p.Item("Partnumber"))
                    If row IsNot Nothing Then
                        row.Item("Pendiente por Transferir") = p.Item("Quantity")
                    End If
                Next
                For Each row As DataRow In report.Rows
                    Dim part As DataRow = partnumbers.Rows.Find(row.Item("No. de Parte"))
                    If part IsNot Nothing Then
                        row.Item("UC") = part.Item("UnitCost")
                        row.Item("Unidad") = part.Item("UoM")
                    End If
                Next

                If selected_partnumbers.Count = 0 AndAlso (Partnumber_txt.Text = "*" OrElse Partnumber_txt.Text = "") AndAlso IgnoreZero_chk.Checked Then
                    report.DefaultView.RowFilter = "Diferencia > 0.5 OR Diferencia < -0.5"
                    report = report.DefaultView.ToTable()
                End If
                Result_dgv.DataSource = report.DefaultView

                'GENERAR REPORTE DE AUDITORIA
                audit_report = New DataTable
                audit_report.Columns.Add("No. de Parte")
                audit_report.Columns.Add("Cantidad en SAP")
                audit_report.Columns.Add("Cantidad en Delta")
                audit_report.Columns.Add("Diferencia")
                audit_report.Columns.Add("Estacion")
                audit_report.Columns.Add("Estatus")
                audit_report.Columns.Add("Localizacion")
                audit_report.Columns.Add("Serie")
                audit_report.Columns.Add("Cantidad")
                audit_report.Columns.Add("Unidad")

                Dim is_first As Boolean = True
                For Each part As DataRowView In report.DefaultView
                    Dim serials = serialnumbers.Where(Function(f) f.Partnumber = part.Item("No. de Parte")).OrderBy(Function(f) f.Warehouse).ThenBy(Function(f) f.Location)
                    If serials IsNot Nothing AndAlso serials.Count > 0 Then
                        For Each serial In serials
                            If is_first Then
                                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                    audit_report.Rows.Add(part.Item("No. de Parte"), CInt(part.Item("Cantidad en SAP")), CInt(part.Item("Cantidad en Delta") + part.Item("Pendiente por Transferir")), CInt(part.Item("Diferencia")), serial.WarehouseName, serial.StatusName, serial.Location, serial.SerialNumber, CInt(serial.CurrentQuantity), serial.UoM)
                                Else
                                    audit_report.Rows.Add(part.Item("No. de Parte"), Math.Round(CDec(part.Item("Cantidad en SAP")), 2), Math.Round(CDec(part.Item("Cantidad en Delta")) + CDec(part.Item("Pendiente por Transferir")), 2), Math.Round(CDec(part.Item("Diferencia")), 2), serial.WarehouseName, serial.StatusName, serial.Location, serial.SerialNumber, Math.Round(serial.CurrentQuantity, 2), serial.UoM)
                                End If
                                is_first = False
                            Else
                                If serial.UoM = RawMaterial.UnitOfMeasure.PC Then
                                    audit_report.Rows.Add(serial.Partnumber, "", "", "", serial.WarehouseName, serial.StatusName, serial.Location, serial.SerialNumber, CInt(serial.CurrentQuantity), serial.UoM)
                                Else
                                    audit_report.Rows.Add(serial.Partnumber, "", "", "", serial.WarehouseName, serial.StatusName, serial.Location, serial.SerialNumber, Math.Round(serial.CurrentQuantity, 2), serial.UoM)
                                End If
                            End If
                        Next
                    Else
                        audit_report.Rows.Add(part.Item("No. de Parte"), Math.Round(CDec(part.Item("Cantidad en SAP")), 1), Math.Round(CDec(part.Item("Cantidad en Delta")) + CDec(part.Item("Pendiente por Transferir")), 1), Math.Round(CDec(part.Item("Diferencia")), 1), "", "", "", "", "", "")
                    End If
                    is_first = True
                Next

                IO.File.Delete(filename)
                LoadingScreen.Hide()
                Me.Activate()
            Else
                MsgBox(Language.Sentence(267), MsgBoxStyle.Critical, APP)
            End If
        Else
            FlashAlerts.ShowInformation("Selecciona el SLoc.")
        End If
    End Sub

    Private Sub Result_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Result_dgv.CellFormatting
        If Result_dgv.Rows(e.RowIndex).Cells("Difference").Value > 0.5 Then
            e.CellStyle.BackColor = Color.LightBlue
        ElseIf Result_dgv.Rows(e.RowIndex).Cells("Difference").Value < -0.5 Then
            e.CellStyle.BackColor = Color.LightCoral
        Else
            e.CellStyle.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub Result_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Result_dgv.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Result_dgv.Columns("button").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Left + (e.CellBounds.Width / 2) - 8, e.CellBounds.Top + (e.CellBounds.Height / 2) - 8, 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.arrow_right_16, rect)
            e.Handled = True
        End If
    End Sub

    Private Sub Result_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Result_dgv.CellContentClick
        If e.ColumnIndex = Result_dgv.Columns("button").Index Then
            FillSerials(Result_dgv.Rows(e.RowIndex).Cells("Partnumber").Value, selected_sloc)
        End If
    End Sub

    Private Sub FillSerials(partnumber As String, sloc As String)
        Serials_dgv.Rows.Clear()
        Dim query = From s In serialnumbers
                    Where s.Partnumber = partnumber And s.Sloc = sloc
        For Each s In query
            Dim i = Serials_dgv.Rows.Count
            Serials_dgv.Rows.Add(s.SerialNumber, s.Partnumber, s.CurrentQuantity, s.UoM.ToString, s.CurrentQuantityInBum, s.StatusName, s.Location, s.WarehouseName, s.Date, Not s.[New])
        Next
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If audit_report IsNot Nothing Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempPDFPath
            Dim pdf As New PDF
            pdf.Title = String.Format("DEEDS Operaciones de Mexico.{0}Auditoria Diaria de Confiabilidad de Inventario.", vbCrLf)
            pdf.TitleFontSize = 14
            pdf.Subtitle = "Fecha: " & CurrentDate.ToString("MM/dd/yyyy HH:mm")
            pdf.Footer = String.Format("Auditado por: _______________ {0}Corregido por: _______________", vbCrLf)
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = audit_report
            pdf.Orientation = CAguilar.PDF.Orientations.Landscape
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 12
            pdf.ColumnsWidths = {9, 9, 9, 9, 8, 14, 11, 15, 9, 7}
            If pdf.Save(filename) Then
                LoadingScreen.Hide()
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al imprimir la auditoria.")
            End If
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If audit_report IsNot Nothing Then
            If MessageBox.Show("¿Incluir numeros de serie?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Delta.Export(audit_report, Title_lbl.Text)
            Else
                Delta.Export(report.DefaultView, Title_lbl.Text)
            End If
        End If
    End Sub

    Private Sub Smk_SAPVsDelta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class