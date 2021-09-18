Imports CAguilar
Public Class CDR_EngineeringVsZCS12
    Dim board As String
    Dim result As New DataTable

    Private Sub CDR_ZCS12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboBoard, SQL.Current.GetDatatable("SELECT DISTINCT Board FROM CDR_Engineering WHERE Board IS NOT NULL ORDER BY Board"))
        result.Columns.Add("Partnumber", System.Type.GetType("System.String"))
        result.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        result.Columns.Add("Ingenieria", System.Type.GetType("System.Int32"))
        result.Columns.Add("SAP", System.Type.GetType("System.Int32"))
        result.Columns.Add("Diferencia", System.Type.GetType("System.Int32"))
        result.Columns.Add("Corregir", System.Type.GetType("System.Boolean"))
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        board = cboBoard.SelectedItem
        result.Rows.Clear()
        If SQL.Current.Exists("CDR_ProductionControl", "Board", board) Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim file As String = GF.TempTXTPath
                If sap.ZCS12(Parameter("SYS_PlantCode"), SQL.Current.GetList("Material", "CDR_ProductionControl", {"Board"}, {board}), file) Then

                    Dim zcs12 As New DataTable
                    zcs12.Columns.Add("Component", GetType(String))
                    zcs12.Columns.Add("Description", GetType(String))
                    zcs12.Columns.Add("Quantity", GetType(Double))
                    zcs12.PrimaryKey = {zcs12.Columns("Component")}

                    Dim txt = CSV.Datatable(file, vbTab, True, True, 1)
                    For Each r As DataRow In txt.Rows
                        Dim z = zcs12.Rows.Find(r.Item("Component"))
                        If z Is Nothing Then
                            zcs12.Rows.Add(r.Item("Component"), r.Item("Component Description"), If({"MM", "ML", "G"}.Contains(r.Item("Alt.UoM")), 0.001, 1) * r.Item("Comp.Qty(Alt.UoM)"))
                        ElseIf z.Item("Quantity") < If({"MM", "ML", "G"}.Contains(r.Item("Alt.UoM")), 0.001, 1) * r.Item("Comp.Qty(Alt.UoM)") Then
                            z.Item("Quantity") = If({"MM", "ML", "G"}.Contains(r.Item("Alt.UoM")), 0.001, 1) * r.Item("Comp.Qty(Alt.UoM)")
                        End If
                    Next

                    TryDelete(file)

                    Dim engineering As DataTable = SQL.Current.GetDatatable(String.Format("SELECT E.Partnumber,ISNULL(SUM(Quantity),0) AS Quantity,MAX(R.Description) AS Description FROM CDR_Engineering AS E LEFT OUTER JOIN Sys_RawMaterial AS R ON E.Partnumber = R.Partnumber WHERE Board='{0}' GROUP BY E.Partnumber;", board))
                    engineering.PrimaryKey = {engineering.Columns.Item("Partnumber")}

                    For Each row As DataRow In zcs12.Rows
                        Dim eng As DataRow = engineering.Rows.Find(row.Item("Component"))
                        If Not IsNothing(eng) Then
                            If row.Item("Component") > eng.Item("Partnumber") Then
                                result.Rows.Add(row.Item("Component"), row.Item("Description"), eng.Item("Quantity"), row.Item("Quantity"), row.Item("Quantity") - eng.Item("Quantity"), True)
                            Else 'Para los que estan en SAP pero no en CDR_Engineering
                                result.Rows.Add(row.Item("Component"), row.Item("Description"), eng.Item("Quantity"), row.Item("Quantity"), row.Item("Quantity") - eng.Item("Quantity"), False)
                            End If
                        Else
                            result.Rows.Add(row.Item("Component"), row.Item("Description"), 0, row.Item("Quantity"), row.Item("Quantity"), True)
                        End If
                    Next

                    For Each row In engineering.Rows 'Para los que estan en CDR_Engineering pero no en SAP
                        Dim zcs As DataRow = zcs12.Rows.Find(row("Partnumber"))
                        If IsNothing(zcs) Then
                            result.Rows.Add(row.Item("Partnumber"), row.Item("description"), row.Item("Quantity"), 0, -row.Item("Quantity"), False)
                        End If
                    Next

                    dgvResult.DataSource = result
                    LoadingScreen.Hide()
                Else
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Imposible descargar el reporte.")
                End If
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Imposible conectar a SAP.")
            End If
        Else
            FlashAlerts.ShowError("No existe informacion en Control de Produccion del tablero seleccionado.")
        End If
    End Sub

    Private Sub Update_btn_Click(sender As Object, e As EventArgs) Handles Update_btn.Click
        If result.Rows.Count > 0 Then
            Cursor.Current = Cursors.WaitCursor
            Me.Text = "Espere..."
            For Each row As DataRow In result.Rows
                If row("Corregir") Then
                    If SQL.Current.Exists("CDR_Engineering", {"Board", "Partnumber"}, {board, row.Item("Partnumber")}) Then
                        SQL.Current.Execute(String.Format("UPDATE CDR_Engineering SET Quantity={0},Comment=Comment + '[Actualizado por ZCS12]' WHERE Partnumber='{1}' AND Board='{2}';", row.Item("SAP"), row.Item("Partnumber"), board))
                    Else
                        SQL.Current.Insert("CDR_Engineering", {"Partnumber", "Board", "Quantity", "Comment"}, {row.Item("Partnumber"), board, row.Item("SAP"), "[Agregado por ZCS12]"})
                    End If
                End If
            Next
            Cursor.Current = Cursors.Arrow
            Me.Text = "Comparativo SAP vs Ingenieria"
            MsgBox("Hecho!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If result IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(result, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(result, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = result
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub CDR_EngineeringVsZCS12_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class