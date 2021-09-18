Public Class CR_AMRReport
    Dim materials As DataTable
    Dim report As DataTable
    Dim all_bom As DataTable
    Private Sub CR_AMRReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Delta.SetDataGridViewDeltaStyle(Material_dgv)
        Delta.SetDataGridViewDeltaStyle(Result_dgv)
        materials = New DataTable
        materials.Columns.Add("Material")
        materials.Columns.Add("Fase 1", GetType(Integer))
        materials.Columns("Fase 1").DefaultValue = 0
        materials.Columns("Fase 1").AllowDBNull = False
        materials.Columns("Material").AllowDBNull = False
        materials.PrimaryKey = {materials.Columns("Material")}
        Material_dgv.DataSource = materials
    End Sub

    Private Sub Stage_nud_ValueChanged(sender As Object, e As EventArgs) Handles Stage_nud.ValueChanged
        If materials IsNot Nothing Then
            If materials.Columns.Count > Stage_nud.Value + 1 Then
                While materials.Columns.Count > Stage_nud.Value + 1
                    materials.Columns.RemoveAt(materials.Columns.Count - 1)
                End While
            ElseIf materials.Columns.Count < Stage_nud.Value + 1 Then
                For i = materials.Columns.Count To Stage_nud.Value
                    materials.Columns.Add(String.Format("Fase {0}", i), GetType(Integer))
                    materials.Columns(String.Format("Fase {0}", i)).DefaultValue = 0
                    For Each row As DataRow In materials.Rows
                        row.Item(String.Format("Fase {0}", i)) = 0
                    Next
                    materials.Columns(String.Format("Fase {0}", i)).AllowDBNull = False
                Next
            End If
        End If
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        If materials.Rows.Count > 0 Then
            LoadingScreen.Show()
            Dim material_list As New ArrayList
            For Each m As DataRow In materials.Rows
                material_list.Add(m.Item(0).ToString.Trim)
            Next

            Dim validate_list As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT Material FROM Sys_BOM WHERE Material IN ('{0}');", String.Join("','", material_list.ToArray)))
            Dim list_to_download As New ArrayList
            For Each m In material_list
                If Not validate_list.Contains(m) Then list_to_download.Add(m)
            Next
            If list_to_download.Count > 0 Then
                LoadingScreen.Hide()
                If MessageBox.Show("Existen arneses sin BOM, es necesario conectarse a SAP para obtenerlo. Presiona OK cuando estes listo...", "Conexion a SAP", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                    LoadingScreen.Show()
                    Dim bom As DataTable = CR.GetBOM(list_to_download)
                    Select Case CR.UpdateBOM(bom)
                        Case CR.BOMResult.OK
                            FlashAlerts.ShowConfirm("BOM actualizado correctamente.")
                        Case CR.BOMResult.OKWithMissings
                            FlashAlerts.ShowInformation("BOM actualizado correctamente pero existen componentes nuevos que no pudieron ser cargados.", 10)
                        Case CR.BOMResult.ErrorOnSave
                            FlashAlerts.ShowError("Error al guardar el BOM.")
                        Case CR.BOMResult.ErroOnDownload
                            FlashAlerts.ShowError("Error al descargar la información del BOM.")
                    End Select
                End If
            End If

            'DESCARGAR BOM
            all_bom = SQL.Current.GetDatatable(String.Format("SELECT R.MRP, B.Material, B.Partnumber, B.Quantity AS Uso, R.UoM FROM vw_Sys_BOM_Stg3 AS B INNER JOIN Sys_RawMaterial AS R ON B.Partnumber = R.partnumber WHERE Material IN ('{0}');", String.Join("','", material_list.ToArray)), "BOM")

            report = New DataTable("AMR")
            report.Columns.Add("No. de Parte")
            report.PrimaryKey = {report.Columns("No. de Parte")}

            Dim partnumbers As New ArrayList
            For Each row As DataRow In all_bom.DefaultView.ToTable(True, "Partnumber").Rows
                partnumbers.Add(row.Item("Partnumber"))
            Next
            'DESCARGAR LA INFO DE LOS NPS Y UNIRLA
            Dim info_data As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte],[Description] AS Descripcion,MRP,UoM,RoundingValue AS StdPack,UnitCost AS [Costo Unitario],SupplierNumber AS [No. de Proveedor],SupplierName AS Proveedor,GRT,PTF,PC,MOQ,CP,Fixed,MRP2,Document FROM Sys_RawMaterial WHERE Partnumber IN ('{0}');", String.Join("','", partnumbers.ToArray)))
            report.Merge(info_data)

            'AGREGAR COLUMNAS DE LAS FASES Y TOTAL
            Dim sum_expression As String = ""
            For i = 1 To materials.Columns.Count - 1
                sum_expression &= String.Format("ISNULL([Fase {0}],0)+", i)
                report.Columns.Add(String.Format("Fase {0}", i), GetType(Decimal))
                report.Columns(String.Format("Fase {0}", i)).DefaultValue = 0
                all_bom.Columns.Add(String.Format("Fase {0}", i), GetType(Decimal))
            Next
            report.Columns.Add("Total", GetType(Decimal), sum_expression.Trim("+"))
            'DESCARGAR INVENTARIO ACTUAL Y UNIRLO
            Dim stock As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Partnumber AS [No. de Parte], SUM(CurrentQuantityInBuM) AS Inventario FROM vw_Smk_Serials WHERE [Status] NOT IN ('D','E') AND Partnumber IN ('{0}') GROUP BY Partnumber;", String.Join("','", partnumbers.ToArray)))
            report.Merge(stock)
            report.Columns.Add("Faltante", GetType(Decimal), "IIF(ISNULL(Inventario,0) >= Total, 0, Total-ISNULL(Inventario,0))")

            'SUMAR LOS REQUERIMIENTOS POR FASE
            For Each m As DataRow In all_bom.Rows
                Dim material = materials.Rows.Find(m.Item("Material"))
                If material IsNot Nothing Then
                    Dim partnumber = report.Rows.Find(m.Item("Partnumber"))
                    If partnumber Is Nothing Then
                        partnumber = report.NewRow
                        partnumber.Item("No. de Parte") = m.Item("Partnumber")
                        report.Rows.Add(partnumber)
                    End If
                    For i = 1 To materials.Columns.Count - 1
                        partnumber.Item(String.Format("Fase {0}", i)) = Delta.NullReplace(partnumber.Item(String.Format("Fase {0}", i)), 0) + material.Item(String.Format("Fase {0}", i)) * m.Item("Uso")
                        m.Item(String.Format("Fase {0}", i)) = material.Item(String.Format("Fase {0}", i)) * m.Item("Uso")
                    Next
                End If
            Next

            Result_dgv.DataSource = report
            For i = 1 To materials.Columns.Count - 1
                Result_dgv.Columns(String.Format("Fase {0}", i)).DefaultCellStyle.Format = "N3"
            Next
            Result_dgv.Columns("Total").DefaultCellStyle.Format = "N3"
            Result_dgv.Columns("Inventario").DefaultCellStyle.Format = "N3"
            Result_dgv.Columns("Faltante").DefaultCellStyle.Format = "N3"
            Result_dgv.Columns("No. de Parte").Frozen = True
            LoadingScreen.Hide()
        Else
            FlashAlerts.ShowInformation("Captura al menos un numero de material.")
        End If
    End Sub

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim clipboard = DTable.clipboardExcelToDataTable(False)
        If clipboard Is Nothing Then
            clipboard = DTable.FromClipboard()
        End If
        If clipboard IsNot Nothing Then
            If clipboard.Columns.Count >= 2 Then
                For Each m As DataRow In clipboard.Rows
                    Dim material_row = materials.Rows.Find(m.Item(0))
                    If material_row Is Nothing Then
                        material_row = materials.NewRow
                        material_row.Item(0) = m.Item(0)
                        materials.Rows.Add(material_row)
                    End If
                    For i = 1 To clipboard.Columns.Count - 1
                        If i < materials.Columns.Count Then
                            material_row.Item(i) = NullReplace(m.Item(i), 0)
                        End If
                    Next
                Next
            Else
                FlashAlerts.ShowError("No fue posible pegar la información.")
            End If
        Else
            FlashAlerts.ShowError("No se encontró nada para pegar.")
        End If
    End Sub

    Private Sub Material_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Material_dgv.DataError
        e.Cancel = True
    End Sub

    Private Sub Stock_btn_Click(sender As Object, e As EventArgs) Handles Stock_btn.Click
        If report IsNot Nothing AndAlso report.Rows.Count > 0 Then
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim zapimatinfo As New DataTable
                Dim partnumbers As New ArrayList
                Dim plants As New ArrayList
                plants.AddRange(Parameter("CR_AMRReport_Plants").Split(","))

                For i = 0 To report.Rows.Count - 1
                    partnumbers.Add(report.Rows(i).Item("No. de Parte"))
                    Dim slocs As New ArrayList
                    slocs.AddRange(Parameter("CR_AMRReport_Slocs").Split(","))
                    If partnumbers.Count = 500 OrElse i = report.Rows.Count - 1 Then
                        Dim filename As String = GF.TempTXTPath
                        If sap.ZAPI_MATINFO(plants, partnumbers, slocs, filename) AndAlso IO.File.Exists(filename) Then
                            Dim txt As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                            txt.Columns.Add("No. de Parte", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")
                            zapimatinfo.Merge(txt.DefaultView.ToTable(False, "Plant", "No. de Parte", "Unrestricted stock", "Storage Loc"))
                            TryDelete(filename)
                            partnumbers.Clear()
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al descargar los inventarios.")
                            Exit Sub
                        End If
                    End If
                Next

                Dim pivoter As New PivotTable(zapimatinfo)
                Dim pivot = pivoter.PivotData("No. de Parte", "Unrestricted stock", AggregateFunction.Sum, {"Plant"}, "System.Decimal")
                pivot.PrimaryKey = {pivot.Columns("No. de Parte")}
                report.Merge(pivot)


                Dim plants_columns As New ArrayList
                plants_columns.AddRange(Parameter("CR_AMRReport_Preferences").Split(","))
                plants_columns.AddRange(plants)

                Dim mover_expression As String = "IIF([Faltante]>0,{0},NULL)"
                For Each plant In plants_columns
                    If pivot.Columns.Contains(plant) Then
                        mover_expression = String.Format(mover_expression, String.Format("IIF([{0}] > Faltante,'{0}',{1})", plant, "{0}"))
                    End If
                Next
                report.Columns.Add("Mover de", GetType(String), String.Format(mover_expression, "'X'"))
                LoadingScreen.Hide()
            Else
                FlashAlerts.ShowError(Language.Sentence(0))
            End If
        End If
    End Sub

    Private Sub Result_dgv_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles Result_dgv.ColumnAdded
        e.Column.Width = 65
    End Sub

    Private Sub Material_dgv_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles Material_dgv.ColumnAdded
        e.Column.Width = 65
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If report IsNot Nothing Then
            LoadingScreen.Show()
            Dim colors As New List(Of MyExcel.ColorRange)
            Dim i As Integer = 2
            For Each row As DataRow In report.Rows
                colors.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(i, 1), WhatColorIs(row)))
                For Each column As DataColumn In report.Columns
                    If column.ColumnName.StartsWith("Fase") Then
                        colors.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(i, column.Ordinal + 1), StatusColor(row, column.ColumnName)))
                    End If
                Next
                i += 1
            Next
            If MyExcel.SaveAs({all_bom, report}, False, , {Nothing, colors}) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub Result_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Result_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso Result_dgv.Columns(e.ColumnIndex).Name = "No. de Parte" Then
            e.CellStyle.BackColor = WhatColorIs(e.RowIndex)
        ElseIf e.RowIndex >= 0 AndAlso Result_dgv.Columns(e.ColumnIndex).Name.StartsWith("Fase") Then
            e.CellStyle.BackColor = StatusColor(e.RowIndex, e.ColumnIndex)
        End If
    End Sub

    Private Function WhatColorIs(rowIndex As Integer) As Color
        If Result_dgv.Rows(rowIndex).Cells("Faltante").Value = 0 Then
            Return Color.LightGreen
        ElseIf report.Columns.Contains("Mover de") AndAlso Result_dgv.Rows(rowIndex).Cells("Mover de").Value <> "X" Then
            Return Color.LightBlue
        Else
            Return Color.LightCoral
        End If
    End Function

    Private Function WhatColorIs(row As DataRow) As Color
        If row.Item("Faltante") = 0 Then
            Return Color.LightGreen
        ElseIf report.Columns.Contains("Mover de") AndAlso row.Item("Mover de") <> "X" Then
            Return Color.LightBlue
        Else
            Return Color.LightCoral
        End If
    End Function

    Private Function StatusColor(rowIndex As Integer, columnIndex As Integer) As Color
        Dim stock As Decimal = NullReplace(Result_dgv.Rows(rowIndex).Cells("Inventario").Value, 0)
        For Each column As DataGridViewColumn In Result_dgv.Columns
            If column.Name.StartsWith("Fase") Then
                stock -= NullReplace(Result_dgv.Rows(rowIndex).Cells(column.Name).Value, 0)
                If column.Index = columnIndex Then
                    Exit For
                End If
            End If
        Next
        If stock < 0 Then
            Return Color.LightCoral
        Else
            Return Color.LightGreen
        End If
    End Function

    Private Function StatusColor(row As DataRow, stage As String) As Color
        Dim stock As Decimal = NullReplace(row.Item("Inventario"), 0)
        For Each column As DataColumn In report.Columns
            If column.ColumnName.StartsWith("Fase") Then
                stock -= NullReplace(row.Item(column.ColumnName), 0)
                If column.ColumnName = stage Then
                    Exit For
                End If
            End If
        Next
        If stock < 0 Then
            Return Color.LightCoral
        Else
            Return Color.LightGreen
        End If
    End Function
End Class