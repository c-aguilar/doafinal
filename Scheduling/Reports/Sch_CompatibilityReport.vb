Public Class Sch_CompatibilityReport
    Dim versus_material As New ArrayList
    Dim component_ignore As New ArrayList
    Dim component_penalize As New ArrayList
    Dim result As DataTable
    Private Sub MaterialVersus_btn_Click(sender As Object, e As EventArgs) Handles MaterialVersus_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(versus_material)
        ld.Title = "Material Versus"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            versus_material.Clear()
            For Each p In ld.Items
                If Not versus_material.Contains(Harn.Format(p)) AndAlso SCH.IsMaterialFormat(Harn.Format(p)) Then
                    versus_material.Add(Harn.Format(p))
                End If
            Next
            If versus_material.Count > 0 Then
                MaterialVersus_txt.Text = String.Join(",", versus_material.ToArray)
                MaterialVersus_txt.Enabled = False
            Else
                MaterialVersus_txt.Clear()
                MaterialVersus_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub ComponentIgnore_btn_Click(sender As Object, e As EventArgs) Handles ComponentIgnore_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(component_ignore)
        ld.Title = "Componentes a Ignorar"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            component_ignore.Clear()
            For Each p In ld.Items
                If Not component_ignore.Contains(RawMaterial.Format(p)) AndAlso SMK.IsRawMaterialFormat(RawMaterial.Format(p)) Then
                    component_ignore.Add(RawMaterial.Format(p))
                End If
            Next
            If component_ignore.Count > 0 Then
                ComponentIgnore_txt.Text = String.Join(",", component_ignore.ToArray)
                ComponentIgnore_txt.Enabled = False
            Else
                ComponentIgnore_txt.Clear()
                ComponentIgnore_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub ComponentPenalize_btn_Click(sender As Object, e As EventArgs) Handles ComponentPenalize_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(component_penalize)
        ld.Title = "Componentes Penalizados"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            component_penalize.Clear()
            For Each p In ld.Items
                If Not component_penalize.Contains(RawMaterial.Format(p)) AndAlso SMK.IsRawMaterialFormat(RawMaterial.Format(p)) Then
                    component_penalize.Add(RawMaterial.Format(p))
                End If
            Next
            If component_penalize.Count > 0 Then
                ComponentPenalize_txt.Text = String.Join(",", component_penalize.ToArray)
                ComponentPenalize_txt.Enabled = False
            Else
                ComponentPenalize_txt.Clear()
                ComponentPenalize_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        If SCH.IsMaterialFormat(Material_txt.Text) Then
            If versus_material.Count > 0 OrElse SCH.IsMaterialFormat(MaterialVersus_txt.Text) Then
                LoadingScreen.Show()
                Dim validate_list As ArrayList
                If versus_material.Count > 0 Then
                    validate_list = SQL.Current.GetList(String.Format("SELECT DISTINCT Material FROM Sys_BOM WHERE Material IN ('{0}','{1}');", Material_txt.Text, String.Join("','", versus_material.ToArray)))
                Else
                    validate_list = SQL.Current.GetList(String.Format("SELECT DISTINCT Material FROM Sys_BOM WHERE Material IN ('{0}','{1}');", Material_txt.Text, MaterialVersus_txt.Text))
                End If
                Dim list_to_download As New ArrayList
                If Not validate_list.Contains(Material_txt.Text) Then list_to_download.Add(Material_txt.Text)
                For Each m In versus_material
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
                Dim all_bom As DataTable
                If versus_material.Count > 0 Then
                    all_bom = SQL.Current.GetDatatable(String.Format("SELECT Material, B.Partnumber AS [No. de Parte], Quantity, R.[Description], R.MRP, R.UoM FROM vw_Sys_BOM_Stg0 AS B INNER JOIN Sys_RawMaterial AS R ON B.Partnumber = R.Partnumber WHERE Material IN ('{0}','{1}');", Material_txt.Text, String.Join("','", versus_material.ToArray)))
                Else
                    all_bom = SQL.Current.GetDatatable(String.Format("SELECT Material, B.Partnumber AS [No. de Parte], Quantity, R.[Description], R.MRP, R.UoM  FROM vw_Sys_BOM_Stg0 AS B INNER JOIN Sys_RawMaterial AS R ON B.Partnumber = R.Partnumber WHERE Material IN ('{0}','{1}');", Material_txt.Text, MaterialVersus_txt.Text))
                End If
                If all_bom IsNot Nothing AndAlso all_bom.Compute("COUNT(Material)", String.Format("Material = '{0}'", Material_txt.Text)) > 0 Then
                    Dim pivoter As New PivotTable(all_bom)
                    result = pivoter.PivotData("No. de Parte", "Description", "MRP", "Quantity", AggregateFunction.Sum, {"Material"}, "System.Decimal")
                    result.Columns(Material_txt.Text).SetOrdinal(3)
                    Dim total_row As DataRow = result.NewRow
                    total_row.Item(0) = "Compatibilidad"

                    For i = 4 To result.Columns.Count - 1
                        Dim avg As Decimal = 0
                        For Each row As DataRow In result.Rows
                            If component_penalize.Count > 0 AndAlso component_penalize.Contains(row.Item(0)) AndAlso row.Item(i) > 0 Then

                            ElseIf component_penalize.Count = 0 AndAlso ComponentPenalize_txt.Text.ToUpper = row.Item(0).ToString.ToUpper AndAlso row.Item(i) > 0 Then

                            ElseIf component_ignore.Count > 0 AndAlso component_ignore.Contains(row.Item(0)) Then
                                avg += 1
                            ElseIf component_ignore.Count = 0 AndAlso ComponentIgnore_txt.Text.ToUpper = row.Item(0).ToString.ToUpper Then
                                avg += 1
                            Else
                                If row.Item(3) >= row.Item(i) Then
                                    avg += 1
                                ElseIf row.Item(3) > 0 AndAlso row.Item(i) / row.Item(3) < 2 AndAlso row.Item(i) / row.Item(3) > 1 Then
                                    avg += 2 - (row.Item(i) / row.Item(3))
                                ElseIf row.Item(3) > 0 AndAlso row.Item(i) / row.Item(3) <= 2 Then
                                    avg += row.Item(i) / row.Item(3)
                                End If
                            End If
                        Next
                        total_row.Item(i) = (avg / result.Rows.Count) * 100
                    Next
                    result.Rows.Add(total_row)
                    Report_dgv.DataSource = Nothing
                    Report_dgv.DataSource = result
                    For Each col As DataGridViewColumn In Report_dgv.Columns
                        col.Width = 80
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        If col.Name = "No. de Parte" Then
                            col.DefaultCellStyle.Font = New Font(Report_dgv.DefaultCellStyle.Font.FontFamily, Report_dgv.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Else
                            col.DefaultCellStyle.Format = "N3"
                        End If
                    Next
                    LoadingScreen.Hide()
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("No existe BOM del arnes seleccionado.")
                End If
            Else
                FlashAlerts.ShowInformation("Capturar los arneses a comparar.")
            End If
        Else
            FlashAlerts.ShowInformation("Captura el material.")
        End If
    End Sub

    Private Sub Report_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Report_dgv.CellFormatting
        e.CellStyle.BackColor = WhatColorIs(e.RowIndex, e.ColumnIndex, e.Value)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If result IsNot Nothing Then
            Dim cl As New List(Of MyExcel.ColorRange)
            Dim lastColor As Color
            Dim actualCR As New MyExcel.ColorRange
            Dim firstCell As Integer
            Dim rowIndex As Integer = 0
            For Each row As DataRowView In result.DefaultView
                lastColor = WhatColorIs(row, 0, row.Item(0))
                firstCell = 0
                For Each col As DataColumn In Report_dgv.DataSource.Columns
                    If Not lastColor = WhatColorIs(row, col.Ordinal, row.Item(col.Ordinal)) Then
                        actualCR.Color = lastColor
                        If col.Ordinal = firstCell + 1 Then
                            actualCR.Range = MyExcel.ExcelCellReference(rowIndex + 2, firstCell + 1)
                        Else
                            actualCR.Range = MyExcel.ExcelCellReference(rowIndex + 2, firstCell + 1) & ":" & MyExcel.ExcelCellReference(rowIndex + 2, col.Ordinal)
                        End If
                        If Not (actualCR.Color.A = 0 AndAlso actualCR.Color.R = 0 AndAlso actualCR.Color.G = 0 AndAlso actualCR.Color.B = 0) AndAlso Not (actualCR.Color.A = 255 AndAlso actualCR.Color.R = 255 AndAlso actualCR.Color.G = 255 AndAlso actualCR.Color.B = 255) Then cl.Add(actualCR)
                        actualCR = New MyExcel.ColorRange
                        lastColor = WhatColorIs(row, col.Ordinal, row.Item(col.Ordinal))
                        firstCell = col.Ordinal
                    End If
                Next
                actualCR.Color = lastColor
                If Report_dgv.ColumnCount = firstCell + 1 Then
                    actualCR.Range = MyExcel.ExcelCellReference(rowIndex + 2, firstCell + 1)
                Else
                    actualCR.Range = MyExcel.ExcelCellReference(rowIndex + 2, firstCell + 1) & ":" & MyExcel.ExcelCellReference(rowIndex + 2, Report_dgv.DataSource.Columns.Count)
                End If
                If Not (actualCR.Color.A = 0 AndAlso actualCR.Color.R = 0 AndAlso actualCR.Color.G = 0 AndAlso actualCR.Color.B = 0) AndAlso Not (actualCR.Color.A = 255 AndAlso actualCR.Color.R = 255 AndAlso actualCR.Color.G = 255 AndAlso actualCR.Color.B = 255) Then cl.Add(actualCR)
                actualCR = New MyExcel.ColorRange
                rowIndex += 1
            Next
            Delta.Export(result.DefaultView, Title_lbl.Text, cl)
        End If
    End Sub

    Private Function WhatColorIs(RowIndex As Integer, ColumnIndex As Integer, Value As Object) As Color
        If RowIndex >= 0 AndAlso ColumnIndex > 3 AndAlso Report_dgv.Rows(RowIndex).Cells("No. de Parte").Value <> "Compatibilidad" Then
            If component_penalize.Count > 0 AndAlso component_penalize.Contains(Report_dgv.Rows(RowIndex).Cells("No. de Parte").Value) AndAlso Value > 0 Then
                Return Color.LightCoral
            ElseIf component_penalize.Count = 0 AndAlso ComponentPenalize_txt.Text.ToUpper = Report_dgv.Rows(RowIndex).Cells("No. de Parte").Value.ToString.ToUpper AndAlso Value > 0 Then
                Return Color.LightCoral
            ElseIf component_ignore.Count > 0 AndAlso component_ignore.Contains(Report_dgv.Rows(RowIndex).Cells("No. de Parte").Value) Then
                Return Color.LightGreen
            ElseIf component_ignore.Count = 0 AndAlso ComponentIgnore_txt.Text.ToUpper = Report_dgv.Rows(RowIndex).Cells("No. de Parte").Value.ToString.ToUpper AndAlso Value > 0 Then
                Return Color.LightGreen
            Else
                If Report_dgv.Rows(RowIndex).Cells(3).Value >= Value Then
                    Return Color.LightGreen
                ElseIf Report_dgv.Rows(RowIndex).Cells(3).Value = 0 And Value > 0 Then
                    Return Color.LightCoral
                Else
                    Return Color.LightBlue
                End If
            End If
        ElseIf RowIndex >= 0 AndAlso ColumnIndex = 3 Then
            Return Color.LightGray
        Else
            Return Color.White
        End If
    End Function

    Private Function WhatColorIs(row As DataRowView, ColumnIndex As Integer, Value As Object) As Color
        If ColumnIndex > 3 AndAlso row.Item("No. de Parte") <> "Compatibilidad" Then
            If component_penalize.Count > 0 AndAlso component_penalize.Contains(row.Item("No. de Parte")) AndAlso Value > 0 Then
                Return Color.LightCoral
            ElseIf component_penalize.Count = 0 AndAlso ComponentPenalize_txt.Text.ToUpper = row.Item("No. de Parte").ToString.ToUpper AndAlso Value > 0 Then
                Return Color.LightCoral
            ElseIf component_ignore.Count > 0 AndAlso component_ignore.Contains(row.Item("No. de Parte")) Then
                Return Color.LightGreen
            ElseIf component_ignore.Count = 0 AndAlso ComponentIgnore_txt.Text.ToUpper = row.Item("No. de Parte").ToString.ToUpper AndAlso Value > 0 Then
                Return Color.LightGreen
            Else
                If row.Item(3) >= Value Then
                    Return Color.LightGreen
                ElseIf row.Item(3) = 0 And Value > 0 Then
                    Return Color.LightCoral
                Else
                    Return Color.LightBlue
                End If
            End If
        ElseIf ColumnIndex = 3 Then
            Return Color.LightGray
        Else
            Return Color.White
        End If
    End Function

End Class