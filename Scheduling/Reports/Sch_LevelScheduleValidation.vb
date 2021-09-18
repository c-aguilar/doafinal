Public Class Sch_LevelScheduleValidation
    Private Property LastLevel As DataTable
    Private Property NewLevel As DataTable
    Private Property HarnList As New ArrayList
    Private Property SelectedDateLastLevel As Date
    Private Property SelectecDateNewLevel As Date

    Dim search_box As SearchBox
    Dim raw_dictionary As Dictionary(Of String, RawMaterial) 'GLOBAL PARA EVITAR VOLVER A CARGAR
    Dim mrp_dictionary As Dictionary(Of String, String)
    Dim raw_comparative_list As Dictionary(Of String, ComparativeRawItem)
    Dim top_comparative_list As Dictionary(Of String, ComparativeTopRawItem)
    Dim comparative_list As Dictionary(Of String, ComparativeMaterialItem)
    Dim board_list As Dictionary(Of String, String)

    Private Sub Sch_LevelScheduleValidation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HarnList = SQL.Current.GetList("Material", "Sch_Materials", {}, {}) 'CARGAR LA LISTA DE ARNESES VALIDOS
        SelectedWeekNewLevel_dtp.Value = LastMonday().Date
        SelectedWeekLastLevel_dtp.Value = LastMonday(Now.AddDays(-7)).Date
        SelectecDateNewLevel = SelectedWeekNewLevel_dtp.Value.Date
        SelectedDateLastLevel = SelectedWeekLastLevel_dtp.Value.Date
        search_box = New SearchBox
        search_box.MdiParent = Me.MdiParent
        search_box.SetNewDataGridView(Me.NewLevel_dgv)
    End Sub

    Private Sub GetLastUpload(week As Date) 'OBTENER LEVEL SCHEDULE ANTERIOR DESDE LA BASE DE DATOS
        LoadingScreen.Show()
        Me.LastLevel = SQL.Current.GetDatatable(String.Format("SELECT  [Material],[Week] AS Semana,[Day1] AS [Dia 1],[Day2] AS [Dia 2],[Day3] AS [Dia 3],[Day4] AS [Dia 4],[Day5] AS [Dia 5],[Day6] AS [Dia 6],[Day7] AS [Dia 7],[Day8] AS [Dia 8],[Day9] AS [Dia 9],[Day10] AS [Dia 10],[Day11] AS [Dia 11],[Day12] AS [Dia 12],[Day13] AS [Dia 13],[Day14] AS [Dia 14],[Week3] AS [Semana 3],[Week4] AS [Semana 4],[Week5] AS [Semana 5],[Week6] AS [Semana 6],[Week7] AS [Semana 7],[Week8] AS [Semana 8],[Week9] AS [Semana 9],[Week10] AS [Semana 10],[Week11] AS [Semana 11],[Week12] AS [Semana 12],[Week13] AS [Semana 13],[Week14] AS [Semana 14],[Week15] AS [Semana 15],[Week16] AS [Semana 16] FROM Sch_SAP_ProductionPlan WHERE [Week] = '{0}'", SelectedWeekLastLevel_dtp.Value), "Level Sch Anterior")
        LastLevel_dgv.DataSource = Nothing
        LastLevel_dgv.DataSource = Me.LastLevel
        LastLevel_dgv.Columns("Material").Frozen = True
        SelectedDateLastLevel = week.Date
        LoadingScreen.Hide()
    End Sub

    Private Sub GetLast_btn_Click(sender As Object, e As EventArgs) Handles GetLast_btn.Click
        GetLastUpload(SelectedWeekLastLevel_dtp.Value)
        CompareLevel(True, True, True) 'LANZAR PROCESO DE COMPARACION DESDE CERO
    End Sub

    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "CSV (*.csv)|*.csv"
        ofd.Title = "Abrir Level Schedule..."
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Filename_txt.Text = ofd.FileName
            LoadingScreen.Show()
            Try
                SelectecDateNewLevel = SelectedWeekNewLevel_dtp.Value.Date 'GUARDAR LA FECHA SELECCIONADA DEL LEVEL NUEVO
                Dim csv_dt As DataTable = CSV.Datatable(ofd.FileName, ",", False, True) 'LEER EL CSV
                NewLevel = New DataTable("Level Sch Nuevo")
                For i = 0 To csv_dt.Columns.Count - 1 'RENOMBRAR COLUMNAS DE CSV_DT DE ACUERDO AL DIA O SEMANA, Y CREAR COLUMNAS PARA LA NUEVA INSTANCIA DEL DT NEWLEVEL
                    Select Case i
                        Case 0
                            csv_dt.Columns(i).ColumnName = "Material"
                            csv_dt.Columns("Material").ReadOnly = True
                            NewLevel.Columns.Add("Material", GetType(String))
                            NewLevel.Columns("Material").ReadOnly = True
                            NewLevel.PrimaryKey = {NewLevel.Columns("Material")}
                        Case 1
                            csv_dt.Columns(i).ColumnName = "Planta"
                            csv_dt.Columns("Planta").ReadOnly = True
                            NewLevel.Columns.Add("Planta", GetType(String))
                            NewLevel.Columns("Planta").ReadOnly = True
                        Case 2
                            csv_dt.Columns(i).ColumnName = "Version"
                            csv_dt.Columns("Version").ReadOnly = True
                            NewLevel.Columns.Add("Version", GetType(Integer))
                            NewLevel.Columns("Version").ReadOnly = True
                        Case 3
                            csv_dt.Columns(i).ColumnName = "Semana"
                            csv_dt.Columns("Semana").ReadOnly = True
                            NewLevel.Columns.Add("Semana", GetType(Date))
                            NewLevel.Columns("Semana").ReadOnly = True
                        Case 4 To 17
                            csv_dt.Columns(i).ColumnName = "Dia " & i - 3
                            NewLevel.Columns.Add("Dia " & i - 3, GetType(Integer))
                        Case Is > 17
                            csv_dt.Columns(i).ColumnName = "Semana " & i - 15
                            NewLevel.Columns.Add("Semana " & i - 15, GetType(Integer))
                    End Select
                Next
                csv_dt.Columns.Add("Validacion", GetType(Boolean)) 'AGREGAR UNA COLUMNA EXTRA PARA INDICAR SI TODO ESTA CORRECTO EN EL RENGLON

                Dim wrong_material As Integer = 0
                Dim wrong_plant As Integer = 0
                Dim wrong_version As Integer = 0
                Dim wrong_week As Integer = 0
                Dim wrong_quantity As Integer = 0

                For Each row As DataRow In csv_dt.Rows 'VALIDAR CADA RENGLON DE CSV_DT
                    Dim new_row As DataRow = NewLevel.NewRow
                    new_row.Item("Semana") = SelectecDateNewLevel.Date
                    new_row.Item("Planta") = Parameter("Sys_PlantCode").ToUpper
                    new_row.Item("Version") = 1

                    row.Item("Validacion") = True
                    If Not row.Item("Planta").ToString.ToUpper = Parameter("Sys_PlantCode").ToUpper Then
                        wrong_plant += 1
                        row.Item("Validacion") = False
                    End If
                    If Not row.Item("Version").ToString = "1" Then
                        wrong_version += 1
                        row.Item("Validacion") = False
                    End If
                    If Not CDate(row.Item("Semana")).Date = SelectecDateNewLevel.Date Then
                        wrong_week += 1
                        row.Item("Validacion") = False
                    End If
                    For i = 4 To csv_dt.Columns.Count - 2
                        If Not IsNumeric(row.Item(i)) OrElse CInt(row.Item(i)) <> CDec(row.Item(i)) Then
                            wrong_quantity += 1
                            row.Item("Validacion") = False
                            new_row.Item(i) = 0
                        Else
                            new_row.Item(i) = row.Item(i)
                        End If
                    Next
                    If Not HarnList.Contains(row.Item("Material")) Then
                        wrong_material += 1
                        row.Item("Validacion") = False
                    Else
                        new_row.Item("Material") = row.Item("Material")
                        NewLevel.Rows.Add(new_row) ' EN NEWLEVEL SOLO SE INSERTAN ARNESES QUE EXISTAN
                    End If
                Next

                NewLevel_dgv.DataSource = csv_dt
                NewLevel_dgv.Columns("Material").Frozen = True
                AddHandler csv_dt.ColumnChanged, New DataColumnChangeEventHandler(AddressOf NewLevel_Changed) 'AGREGAR EL EVENTO DATACOLUMNCHANGE A CSV_DT, ESTO ES PARA QUE CUANDO EL USUARIO MODIFIQUE ALGO EN EL DATAGRIDVIEW SE LANCE EL EVENTO Y SE VUELVA A RECALCULAR LA VARIACION
                LoadingScreen.Hide()
                Dim result As New Sch_LevelScheduleNewLevelResult
                result.TotalRows = csv_dt.Rows.Count
                result.TotalColumns = csv_dt.Columns.Count - 1
                result.WrongHarn = wrong_material
                result.WrongPlant = wrong_plant
                result.WrongVersion = wrong_version
                result.WrongWeek = wrong_week
                result.WrongQuantity = wrong_quantity
                result.ShowDialog() 'MOSTRAR RESULTADO DE LA VALIDACION AL USUARIO
                CompareLevel(True, True, True) 'LANZAR PROCESO DE COMPARACION DESDE CERO
            Catch ex As Exception
                LoadingScreen.Hide()
                NewLevel = Nothing
                If ex.Message.Contains("Column 'Material' is constrained to be unique.") Then
                    FlashAlerts.ShowError("Existen numeros de parte duplicados.", 2)
                Else
                    FlashAlerts.ShowError(ex.Message)
                End If
            End Try
        End If
    End Sub

    Private Sub NewLevel_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles NewLevel_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Select Case NewLevel_dgv.Columns(e.ColumnIndex).Name
                Case "Material"
                    If Not HarnList.Contains(e.Value) Then
                        e.CellStyle.BackColor = Color.LightCoral
                    End If
                Case "Planta"
                    If Not e.Value.ToString.ToUpper = Parameter("Sys_PlantCode").ToUpper Then
                        e.CellStyle.BackColor = Color.LightCoral
                    End If
                Case "Version"
                    If e.Value.ToString <> "1" Then
                        e.CellStyle.BackColor = Color.LightCoral
                    End If
                Case "Semana"
                    If Not IsDate(e.Value) OrElse CDate(e.Value).Date <> SelectecDateNewLevel.Date Then
                        e.CellStyle.BackColor = Color.LightCoral
                    End If
                Case "Validacion"

                Case Else
                    If Not IsNumeric(e.Value) OrElse CInt(e.Value) <> CDec(e.Value) Then
                        e.CellStyle.BackColor = Color.LightCoral
                    End If
            End Select
        End If
    End Sub

    'Private Sub SelectedWeekNewLevel_dtp_ValueChanged(sender As Object, e As EventArgs) Handles SelectedWeekNewLevel_dtp.ValueChanged
    '    SelectedWeekNewLevel_dtp.Value = LastMonday(SelectedWeekNewLevel_dtp.Value) 'ELEGIR SIEMPRE EL LUNES DE LA SEMANA SELECCIONADA, POR LO TANTO EL SISTEMA FORZA A QUE EL UPLOAD DEBIO SER CARGADO EL LUNES
    'End Sub

    'Private Sub SelectedWeekLastLevel_dtp_ValueChanged(sender As Object, e As EventArgs) Handles SelectedWeekLastLevel_dtp.ValueChanged
    '    SelectedWeekLastLevel_dtp.Value = LastMonday(SelectedWeekLastLevel_dtp.Value)
    'End Sub

    Private Sub CompareLevel(is_new As Boolean, calculate_raw As Boolean, validate_bom As Boolean)
        If NewLevel IsNot Nothing AndAlso LastLevel IsNot Nothing Then
            If SelectecDateNewLevel >= SelectedDateLastLevel Then
                LoadingScreen.Show()
                'SACAR LOS DISTINCTOS ARNESES DE AMBOS LEVELS
                Dim distinct_material As New List(Of String)
                For Each row As DataRow In NewLevel.Rows
                    distinct_material.Add(row.Item("Material"))
                Next
                For Each row As DataRow In LastLevel.Rows
                    distinct_material.Add(row.Item("Material"))
                Next
                distinct_material = distinct_material.Distinct().ToList

                'VALIDAR QUE EXISTA EL BOM DE TODOS LOS ARNESES
                If validate_bom Then
                    Dim validate_list As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT Material FROM Sys_BOM WHERE Material IN ('{0}');", String.Join("','", distinct_material)))
                    Dim list_to_download As New ArrayList
                    For Each m In distinct_material
                        If Not validate_list.Contains(m) Then list_to_download.Add(m)
                    Next
                    If list_to_download.Count > 0 Then
                        LoadingScreen.Hide()
                        If MessageBox.Show("Existen arneses sin BOM, es necesario conectarse a SAP para obtenerlo. Presiona OK cuando estes listo...", "Conexión a SAP", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                            LoadingScreen.Show()
                            Dim new_bom As DataTable = CR.GetBOM(list_to_download)
                            Select Case CR.UpdateBOM(new_bom)
                                Case CR.BOMResult.OK
                                    FlashAlerts.ShowConfirm("BOM actualizado correctamente.")
                                Case CR.BOMResult.OKWithMissings
                                    FlashAlerts.ShowInformation("BOM actualizado correctamente pero existen componentes nuevos que no pudieron ser cargados.", 10)
                                Case CR.BOMResult.ErrorOnSave
                                    FlashAlerts.ShowError("Error al guardar el BOM.")
                                Case CR.BOMResult.ErroOnDownload
                                    FlashAlerts.ShowError("Error al descargar la información del BOM.")
                            End Select
                        Else
                            LoadingScreen.Show()
                        End If
                    End If
                End If

                If board_list Is Nothing Then
                    board_list = New Dictionary(Of String, String)
                    Dim boards As DataTable = SQL.Current.GetDatatable("SELECT [Material],MAX([Board]) AS Board FROM Sch_MaterialBoards WHERE Active = 1 GROUP BY Material;")
                    For Each row As DataRow In boards.Rows
                        board_list.Add(row.Item("Material"), row.Item("Board"))
                    Next
                End If

                ' CREAR DICCIONARIOS DE ARNESES, BOM, RAWMATERIAL Y UNA LISTA DE COMPARACION
                If is_new Then
                    comparative_list = New Dictionary(Of String, ComparativeMaterialItem)
                    Dim harn_list As New Dictionary(Of String, Harn)
                    Dim bom_list As New Dictionary(Of String, BOM)
                    
                    Dim harns As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sch_Materials WHERE Material IN ('{0}');", String.Join("','", distinct_material)))
                    Dim bom As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Material, Partnumber, Quantity FROM vw_Sys_BOM_Stg3 WHERE Material IN ('{0}') ORDER BY Material, Partnumber;", String.Join("','", distinct_material)))
                    For Each row As DataRow In bom.Rows 'LA TABLA BOM ESTA SORTEADA POR MATERIAL Y COMPONENTE
                        If Not bom_list.ContainsKey(row.Item("Material")) Then
                            bom_list.Add(row.Item("Material"), New BOM(row.Item("Material")))
                        End If
                        bom_list.Item(row.Item("Material")).Items.Add(row.Item("Partnumber"), New BOMItem(row.Item("Partnumber"), row.Item("Quantity")))
                    Next
                    For Each row As DataRow In harns.Rows
                        If bom_list.ContainsKey(row.Item("Material")) Then
                            harn_list.Add(row.Item("Material"), New Harn(row.Item("Material"), row.Item("CustomerPN"), row.Item("Description"), row.Item("StdPack"), New Business(row.Item("Business"), ""), row.Item("Class"), Delta.NullReplace(row.Item("MRP"), ""), bom_list.Item(row.Item("Material"))))
                        End If
                    Next
                    For Each row As DataRow In NewLevel.Rows
                        If harn_list.ContainsKey(row.Item("Material")) Then
                            comparative_list.Add(row.Item("Material"), New ComparativeMaterialItem(harn_list.Item(row.Item("Material")), If(board_list.ContainsKey(row.Item("Material")), board_list.Item(row.Item("Material")), "")))
                            comparative_list.Item(row.Item("Material")).Dates.Add(SelectecDateNewLevel.Date, New ComparativeItemDate(SelectecDateNewLevel.Date, row.Item("Dia 1") + row.Item("Dia 2") + row.Item("Dia 3") + row.Item("Dia 4") + row.Item("Dia 5") + row.Item("Dia 6") + row.Item("Dia 7"), 0))
                            comparative_list.Item(row.Item("Material")).Dates.Add(SelectecDateNewLevel.AddDays(7).Date, New ComparativeItemDate(SelectecDateNewLevel.AddDays(7).Date, row.Item("Dia 8") + row.Item("Dia 9") + row.Item("Dia 10") + row.Item("Dia 11") + row.Item("Dia 12") + row.Item("Dia 13") + row.Item("Dia 14"), 0))
                            For i = 18 To NewLevel.Columns.Count - 1
                                comparative_list.Item(row.Item("Material")).Dates.Add(SelectecDateNewLevel.AddDays(7 * (i - 16)).Date, New ComparativeItemDate(SelectecDateNewLevel.AddDays(7 * (i - 16)).Date, row.Item(i), 0))
                            Next
                        End If
                    Next

                    For Each row As DataRow In LastLevel.Rows
                        If harn_list.ContainsKey(row.Item("Material")) Then
                            If Not comparative_list.ContainsKey(row.Item("Material")) Then
                                comparative_list.Add(row.Item("Material"), New ComparativeMaterialItem(harn_list.Item(row.Item("Material")), If(board_list.ContainsKey(row.Item("Material")), board_list.Item(row.Item("Material")), "")))
                            End If
                            If Not comparative_list.Item(row.Item("Material")).Dates.ContainsKey(SelectedDateLastLevel.Date) Then
                                comparative_list.Item(row.Item("Material")).Dates.Add(SelectedDateLastLevel.Date, New ComparativeItemDate(SelectedDateLastLevel.Date, 0, row.Item("Dia 1") + row.Item("Dia 2") + row.Item("Dia 3") + row.Item("Dia 4") + row.Item("Dia 5") + row.Item("Dia 6") + row.Item("Dia 7")))
                            Else
                                comparative_list.Item(row.Item("Material")).Dates.Item(SelectedDateLastLevel.Date).OldQuantity = row.Item("Dia 1") + row.Item("Dia 2") + row.Item("Dia 3") + row.Item("Dia 4") + row.Item("Dia 5") + row.Item("Dia 6") + row.Item("Dia 7")
                            End If
                            If Not comparative_list.Item(row.Item("Material")).Dates.ContainsKey(SelectedDateLastLevel.AddDays(7).Date) Then
                                comparative_list.Item(row.Item("Material")).Dates.Add(SelectedDateLastLevel.AddDays(7).Date, New ComparativeItemDate(SelectedDateLastLevel.AddDays(7).Date, 0, row.Item("Dia 8") + row.Item("Dia 9") + row.Item("Dia 10") + row.Item("Dia 11") + row.Item("Dia 12") + row.Item("Dia 13") + row.Item("Dia 14")))
                            Else
                                comparative_list.Item(row.Item("Material")).Dates.Item(SelectedDateLastLevel.AddDays(7).Date).OldQuantity = row.Item("Dia 8") + row.Item("Dia 9") + row.Item("Dia 10") + row.Item("Dia 11") + row.Item("Dia 12") + row.Item("Dia 13") + row.Item("Dia 14")
                            End If
                            For i = 16 To LastLevel.Columns.Count - 1
                                If Not comparative_list.Item(row.Item("Material")).Dates.ContainsKey(SelectedDateLastLevel.AddDays(7 * (i - 14)).Date) Then
                                    comparative_list.Item(row.Item("Material")).Dates.Add(SelectedDateLastLevel.AddDays(7 * (i - 14)).Date, New ComparativeItemDate(SelectedDateLastLevel.AddDays(7 * (i - 14)).Date, 0, row.Item(i)))
                                Else
                                    comparative_list.Item(row.Item("Material")).Dates.Item(SelectedDateLastLevel.AddDays(7 * (i - 14)).Date).OldQuantity = row.Item(i)
                                End If
                            Next
                        End If
                    Next
                End If


                'CALCULAR DESFASE ENTRE LEVELS Y CREAR UN NUEVO DT CON FECHAS COMO HEADERS
                Dim gap_weeks As Integer = DateDiff(DateInterval.Day, SelectedDateLastLevel, SelectecDateNewLevel) / 7
                Dim material_comparative As New DataTable("Variacion por Arnes")
                material_comparative.Columns.Add("Material", GetType(String))
                material_comparative.Columns.Add("Tablero", GetType(String))
                material_comparative.Columns.Add("Negocio", GetType(String))

                Dim columns(16 - gap_weeks) As String
                Dim aggregates(16 - gap_weeks) As AggregateFunction
                For i = 0 To columns.Length - 1
                    aggregates(i) = AggregateFunction.Sum
                    columns(i) = SelectecDateNewLevel.AddDays(i * 7).ToShortDateString
                    material_comparative.Columns.Add(columns(i), GetType(Integer))
                Next

                'VACIAR RESULTADO DEL DICCIONARIO AL DT PARA PODER PONERLO EN EL DGV
                For Each material In comparative_list
                    Dim new_row As DataRow = material_comparative.NewRow
                    new_row.Item("Material") = material.Value.Material.Material
                    new_row.Item("Tablero") = material.Value.Board
                    new_row.Item("Negocio") = material.Value.Material.Business.Name

                    For i = 0 To columns.Length - 1
                        If material.Value.Dates.ContainsKey(SelectecDateNewLevel.AddDays(i * 7).Date) Then
                            With material.Value.Dates.Item(SelectecDateNewLevel.AddDays(i * 7).Date)
                                new_row.Item(columns(i)) = .NewQuantity - .OldQuantity
                            End With
                        Else
                            new_row.Item(columns(i)) = 0
                        End If
                    Next
                    material_comparative.Rows.Add(new_row)
                Next
                ResultMaterial_dgv.DataSource = Nothing

                'PIVOTEAR RESULTADO DE ACUERDO AL REPORTE SELECCIONADO POR EL USUARIO
                If Business_rb.Checked Then
                    Dim business_dt = DatatablePivoter.Get(material_comparative, {"Negocio"}, {}, columns, aggregates)
                    business_dt.TableName = "Variacion por Negocio"
                    ResultMaterial_dgv.DataSource = business_dt
                    ResultMaterial_dgv.Columns("Negocio").Frozen = True
                ElseIf Board_rb.Checked Then
                    Dim board_dt = DatatablePivoter.Get(material_comparative, {"Tablero"}, {}, columns, aggregates)
                    board_dt.TableName = "Variacion por Tablero"
                    ResultMaterial_dgv.DataSource = board_dt
                    ResultMaterial_dgv.Columns("Tablero").Frozen = True
                Else
                    ResultMaterial_dgv.DataSource = material_comparative
                    ResultMaterial_dgv.Columns("Material").Frozen = True
                End If

                'FORMATEAR EL DATAGRIDVIEW
                For Each column As DataGridViewColumn In ResultMaterial_dgv.Columns
                    If {"Material", "Tablero", "Negocio"}.Contains(column.Name) Then
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Else
                        column.DefaultCellStyle.Format = "N0"
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                Next

                Main_tcl.SelectTab("MaterialComparative_tab")
                LoadingScreen.Hide()
                If calculate_raw Then
                    RawComparative(True)
                    TopComparative()
                End If

            Else
                FlashAlerts.ShowError("La semana seleccionada del Level Schedule nuevo no puede ser menor o igual a la seleccionada del Level Schedule anterior.")
            End If
        End If
    End Sub

    Private Sub TopComparative()
        LoadingScreen.Show()
        Dim gap_weeks As Integer = DateDiff(DateInterval.Day, SelectedDateLastLevel, SelectecDateNewLevel) / 7

        top_comparative_list = New Dictionary(Of String, ComparativeTopRawItem) 'CREAR NUEVO DICCIONARIO DE TOPS
        For i = 0 To 16 - gap_weeks
            With SelectecDateNewLevel.AddDays(i * 7)
                If raw_comparative_list.Any(Function(x) x.Value.Dates.ContainsKey(.Date)) Then
                    If TopContainers_rb.Checked Then
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderBy(Function(x) x.Value.Dates(.Date).Difference / raw_dictionary.Item(x.Value.Partnumber.Partnumber).OrderStdPack).Take(10) 'MENOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderBy(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(x) x.Value.Dates(.Date).Difference / raw_dictionary.Item(x.Value.Partnumber.Partnumber).OrderStdPack).Take(10) 'MAYOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                    ElseIf TopCost_rb.Checked Then
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderBy(Function(x) x.Value.Dates(.Date).Difference * raw_dictionary.Item(x.Value.Partnumber.Partnumber).UnitCost).Take(10) 'MENOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderBy(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(x) x.Value.Dates(.Date).Difference * raw_dictionary.Item(x.Value.Partnumber.Partnumber).UnitCost).Take(10) 'MAYOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                    Else
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderBy(Function(x) x.Value.Dates(.Date).Difference).Take(10) 'MENOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderBy(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                        For Each r In raw_comparative_list.Where(Function(x) x.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(x) x.Value.Dates(.Date).Difference).Take(10) 'MAYOR USO
                            Dim top = comparative_list.Where(Function(w) w.Value.Material.BOM.Items.ContainsKey(r.Value.Partnumber.Partnumber) And w.Value.Dates.ContainsKey(.Date)).OrderByDescending(Function(o) o.Value.Dates.Item(.Date).Difference).First()
                            If Not top_comparative_list.ContainsKey(r.Value.Partnumber.Partnumber) Then top_comparative_list.Add(r.Value.Partnumber.Partnumber, New ComparativeTopRawItem(r.Value.Partnumber.Partnumber))
                            If Not top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.ContainsKey(.Date) Then top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Add(.Date, New ComparativeTopRawItemDate)
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Quantity = top.Value.Dates.Item(.Date).Difference * top.Value.Material.BOM.Items.Item(r.Value.Partnumber.Partnumber).Usage
                            top_comparative_list.Item(r.Value.Partnumber.Partnumber).Dates.Item(.Date).Material = top.Value.Material.Material
                        Next
                    End If
                End If
            End With
        Next

        Dim top_comparative As New DataTable("TOP 20 Variacion Componentes")
        top_comparative.Columns.Add("No. de Parte", GetType(String))

        For i = 0 To 16 - gap_weeks
            top_comparative.Columns.Add(SelectecDateNewLevel.AddDays(i * 7).ToShortDateString & " Material", GetType(String))
            If TopContainers_rb.Checked Then
                top_comparative.Columns.Add(SelectecDateNewLevel.AddDays(i * 7).ToShortDateString & " Contenedores", GetType(Decimal))
            ElseIf TopCost_rb.Checked Then
                top_comparative.Columns.Add(SelectecDateNewLevel.AddDays(i * 7).ToShortDateString & " Costo", GetType(Decimal))
            Else
                top_comparative.Columns.Add(SelectecDateNewLevel.AddDays(i * 7).ToShortDateString & " Cantidad", GetType(Decimal))
            End If
        Next

        For Each partnumber In top_comparative_list
            Dim new_row As DataRow = top_comparative.NewRow
            new_row.Item("No. de Parte") = partnumber.Value.Partnumber
            For i = 0 To 16 - gap_weeks
                With SelectecDateNewLevel.AddDays(i * 7)
                    If partnumber.Value.Dates.ContainsKey(.Date) Then
                        new_row.Item(.Date.ToShortDateString & " Material") = partnumber.Value.Dates(.Date).Material
                        If TopContainers_rb.Checked Then
                            new_row.Item(.Date.ToShortDateString & " Contenedores") = partnumber.Value.Dates(.Date).Quantity
                        ElseIf TopCost_rb.Checked Then
                            new_row.Item(.Date.ToShortDateString & " Costo") = partnumber.Value.Dates(.Date).Quantity
                        Else
                            new_row.Item(.Date.ToShortDateString & " Cantidad") = partnumber.Value.Dates(.Date).Quantity
                        End If
                    End If
                End With
            Next
            top_comparative.Rows.Add(new_row)
        Next

        Top20_dgv.DataSource = Nothing
        Top20_dgv.DataSource = top_comparative

        For Each column As DataGridViewColumn In Top20_dgv.Columns
            If column.Name = "No. de Parte" OrElse column.Name.Contains("Material") Then
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf TopCost_rb.Checked Then
                column.DefaultCellStyle.Format = "C1"
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                column.DefaultCellStyle.Format = "N1"
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Top20_dgv.Columns("No. de Parte").Frozen = True
        LoadingScreen.Hide()
    End Sub

    Private Sub RawComparative(is_new As Boolean)
        LoadingScreen.Show()
        If mrp_dictionary Is Nothing Then 'CARGAR DICCIONARIO DE MRP CONTROLLERS
            mrp_dictionary = New Dictionary(Of String, String)
            Dim mrps As DataTable = SQL.Current.GetDatatable("SELECT M.MRP, U.FullName FROM Ord_MRPControllers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username;")
            For Each row As DataRow In mrps.Rows
                mrp_dictionary.Add(row.Item("MRP").ToString.ToUpper, row.Item("FullName"))
            Next
        End If

        If raw_dictionary Is Nothing Then 'CARGAR DIRECCIONARIO DE COMPONENTES
            raw_dictionary = New Dictionary(Of String, RawMaterial)
            Dim raw_material As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sys_RawMaterial WHERE IsRaw=1;"), "RawMaterial")
            For Each row As DataRow In raw_material.Rows
                raw_dictionary.Add(row.Item("Partnumber"), New RawMaterial(row.Item("Partnumber"), Delta.NullReplace(row.Item("Description"), ""), row.Item("UoM"), row.Item("RoundingValue"), row.Item("UnitCost"), row.Item("MRP"), Delta.NullReplace(row.Item("SupplierPartnumber"), ""), Delta.NullReplace(row.Item("SupplierNumber"), ""), Delta.NullReplace(row.Item("SupplierName"), ""), Delta.NullReplace(row.Item("Container"), ""), row.Item("MaterialType"), row.Item("ConsumptionType"), Delta.NullReplace(row.Item("LabelLegend"), ""), row.Item("Expirable"), Delta.NullReplace(row.Item("GRT"), 0), Delta.NullReplace(row.Item("PTF"), 0), Delta.NullReplace(row.Item("PC"), ""), Delta.NullReplace(row.Item("MOQ"), 1), Delta.NullReplace(row.Item("CP"), ""), row.Item("Fixed"), row.Item("MRP2"), Delta.NullReplace(row.Item("Document"), ""), Delta.NullReplace(row.Item("DocumentItem"), ""), row.Item("OrderUnit"), row.Item("WeightOnGr"), row.Item("IsSensitive"), NullReplace(row.Item("OrderingComment"), ""), row.Item("BOMIssueFactor"), row.Item("MfgConsumptionControl"), row.Item("MasterLabel"), row.Item("ChildLabelQuantity"), row.Item("UnitWeightValidated")))
            Next
        End If

        Dim gap_weeks As Integer = DateDiff(DateInterval.Day, SelectedDateLastLevel, SelectecDateNewLevel) / 7

        If is_new Then 'ENTRAR SI ES NECESARIO VOLVER A CALCULAR TODO
            raw_comparative_list = New Dictionary(Of String, ComparativeRawItem) 'CREAR NUEVO DICCIONARIO DE COMPARATIVERAW

            For Each material In comparative_list 'RECORRER CADA ARNES
                For Each [date] In material.Value.Dates 'RECORRER CADA FECHA DE REQUERIMIENTOS DEL ARNES PARA VER LA VARIACION QUE HA TENIDO
                    If [date].Value.NewQuantity <> [date].Value.OldQuantity Then 'ENTRAR SOLO SI HAY VARIACION
                        For Each partnumber In material.Value.Material.BOM.Items 'RECORRER CADA COMPONENTE DEL BOM DEL ARNES
                            'AGREGAR LA VARIACION A NIVEL COMPONENTE
                            If raw_comparative_list.ContainsKey(partnumber.Value.Partnumber) Then
                                If raw_comparative_list.Item(partnumber.Value.Partnumber).Dates.ContainsKey([date].Value.Date) Then
                                    raw_comparative_list.Item(partnumber.Value.Partnumber).Dates.Item([date].Value.Date).NewQuantity += [date].Value.NewQuantity * partnumber.Value.Usage
                                    raw_comparative_list.Item(partnumber.Value.Partnumber).Dates.Item([date].Value.Date).OldQuantity += [date].Value.OldQuantity * partnumber.Value.Usage
                                Else
                                    raw_comparative_list.Item(partnumber.Value.Partnumber).Dates.Add([date].Value.Date, New ComparativeItemDate([date].Value.Date, [date].Value.NewQuantity * partnumber.Value.Usage, [date].Value.OldQuantity * partnumber.Value.Usage))
                                End If
                            Else
                                raw_comparative_list.Add(partnumber.Value.Partnumber, New ComparativeRawItem(raw_dictionary.Item(partnumber.Value.Partnumber)))
                                raw_comparative_list.Item(partnumber.Value.Partnumber).Dates.Add([date].Value.Date, New ComparativeItemDate([date].Value.Date, [date].Value.NewQuantity * partnumber.Value.Usage, [date].Value.OldQuantity * partnumber.Value.Usage))
                            End If
                        Next
                    End If
                Next
            Next
        End If

        'CALCULAR DESFASE ENTRE LEVELS Y CREAR UN NUEVO DT CON FECHAS COMO HEADERS

        Dim material_comparative As New DataTable("Variacion Componentes")
        material_comparative.Columns.Add("No. de Parte", GetType(String))
        material_comparative.Columns.Add("Descripcion", GetType(String))
        material_comparative.Columns.Add("Std. Pack", GetType(Decimal))
        material_comparative.Columns.Add("Costo", GetType(Decimal))
        material_comparative.Columns.Add("MRP", GetType(String))
        material_comparative.Columns.Add("Dueño", GetType(String))

        For i = 0 To 16 - gap_weeks
            material_comparative.Columns.Add(SelectecDateNewLevel.AddDays(i * 7).ToShortDateString, GetType(Decimal))
        Next

        For Each partnumber In raw_comparative_list 'RECORRER EL DICCIONARIO DE COMPARATIVERAW PARA CONVERTIRLO EN TABLA
            Dim new_row As DataRow = material_comparative.NewRow
            new_row.Item("No. de Parte") = partnumber.Value.Partnumber.Partnumber
            new_row.Item("Descripcion") = partnumber.Value.Partnumber.Description
            new_row.Item("Std. Pack") = partnumber.Value.Partnumber.OrderStdPack
            new_row.Item("Costo") = partnumber.Value.Partnumber.UnitCost
            new_row.Item("MRP") = partnumber.Value.Partnumber.MRP
            new_row.Item("Dueño") = mrp_dictionary.Item(partnumber.Value.Partnumber.MRP.ToUpper)

            For i = 0 To 16 - gap_weeks
                With SelectecDateNewLevel.AddDays(i * 7)
                    If partnumber.Value.Dates.ContainsKey(.Date) Then
                        If Cost_rb.Checked Then
                            new_row.Item(.Date.ToShortDateString) = (partnumber.Value.Dates.Item(.Date).NewQuantity - partnumber.Value.Dates.Item(.Date).OldQuantity) * partnumber.Value.Partnumber.UnitCost
                        ElseIf StdPack_rb.Checked Then
                            new_row.Item(.Date.ToShortDateString) = (partnumber.Value.Dates.Item(.Date).NewQuantity - partnumber.Value.Dates.Item(.Date).OldQuantity) / partnumber.Value.Partnumber.OrderStdPack
                        Else
                            new_row.Item(.Date.ToShortDateString) = (partnumber.Value.Dates.Item(.Date).NewQuantity - partnumber.Value.Dates.Item(.Date).OldQuantity)
                        End If
                    Else
                        new_row.Item(.Date.ToShortDateString) = 0
                    End If
                End With
            Next
            material_comparative.Rows.Add(new_row)
        Next

        ResultRaw_dgv.DataSource = Nothing
        ResultRaw_dgv.DataSource = material_comparative

        For Each column As DataGridViewColumn In ResultRaw_dgv.Columns
            If {"No. de Parte", "Descripcion", "MRP", "Dueño"}.Contains(column.Name) Then
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf column.Name = "Costo" Then
                column.DefaultCellStyle.Format = "C6"
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf column.Name = "Std. Pack" Then
                column.DefaultCellStyle.Format = "N1"
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                column.DefaultCellStyle.Format = If(Cost_rb.Checked, "C1", "N1")
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        ResultRaw_dgv.Columns("No. de Parte").Frozen = True
        LoadingScreen.Hide()
    End Sub

    Public Class ComparativeTopRawItem
        Public Sub New(partnumber As String)
            Me.Partnumber = partnumber
        End Sub
        Public Property Partnumber As String
        Public Property Dates As New Dictionary(Of Date, ComparativeTopRawItemDate)
    End Class

    Public Class ComparativeTopRawItemDate
        Public Property Material As String = ""
        Public Property Quantity As Decimal = 0
    End Class


    Public Class ComparativeRawItem
        Public Sub New(partnumber As RawMaterial)
            Me.Partnumber = partnumber
        End Sub
        Public Property Partnumber As RawMaterial
        Public Property Dates As New Dictionary(Of Date, ComparativeItemDate)
    End Class
    Public Class ComparativeMaterialItem
        Public Sub New(material As Harn, board As String)
            Me.Material = material
            Me.Board = board
        End Sub
        Public Property Material As Harn
        Public Property Board As String
        Public Property Dates As New Dictionary(Of Date, ComparativeItemDate)
    End Class
    Public Class ComparativeItemDate
        Public Sub New([date] As Date, new_quantity As Decimal, old_quantity As Decimal)
            Me.Date = [date]
            Me.NewQuantity = new_quantity
            Me.OldQuantity = old_quantity
        End Sub
        Public Property [Date] As Date
        Public Property NewQuantity As Decimal
        Public Property OldQuantity As Decimal
        Public ReadOnly Property Difference As Decimal
            Get
                Return Me.NewQuantity - Me.OldQuantity
            End Get
        End Property
    End Class


    Private Sub NewLevel_dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles NewLevel_dgv.DataBindingComplete, LastLevel_dgv.DataBindingComplete, ResultMaterial_dgv.DataBindingComplete, ResultRaw_dgv.DataBindingComplete
        For Each column As DataGridViewColumn In CType(sender, DataGridViewWithFilters).Columns
            column.Width = 80
        Next
    End Sub

    Private Sub ResultMaterial_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles ResultMaterial_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Not {"Material", "Tablero", "Negocio"}.Contains(ResultMaterial_dgv.Columns(e.ColumnIndex).Name) Then
                If e.Value > 0 Then
                    e.CellStyle.BackColor = Color.LightCoral
                ElseIf e.Value < 0 Then
                    e.CellStyle.BackColor = Color.LightBlue
                End If
            End If
        End If
    End Sub

    Private Sub ResultRaw_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles ResultRaw_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Not {"No. de Parte", "Descripcion", "Std. Pack", "Costo", "MRP", "Dueño"}.Contains(ResultRaw_dgv.Columns(e.ColumnIndex).Name) Then
                If e.Value > 0 Then
                    e.CellStyle.BackColor = Color.LightCoral
                ElseIf e.Value < 0 Then
                    e.CellStyle.BackColor = Color.LightBlue
                End If
            End If
        End If
    End Sub

    Private Sub Quantity_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Quantity_rb.CheckedChanged
        If comparative_list IsNot Nothing AndAlso Quantity_rb.Checked Then RawComparative(False)
    End Sub

    Private Sub Cost_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Cost_rb.CheckedChanged
        If comparative_list IsNot Nothing AndAlso Cost_rb.Checked Then RawComparative(False)
    End Sub

    Private Sub StdPack_rb_CheckedChanged(sender As Object, e As EventArgs) Handles StdPack_rb.CheckedChanged
        If comparative_list IsNot Nothing AndAlso StdPack_rb.Checked Then RawComparative(False)
    End Sub

    Private Sub Material_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Material_rb.CheckedChanged
        If Material_rb.Checked Then CompareLevel(False, False, False)
    End Sub

    Private Sub Board_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Board_rb.CheckedChanged
        If Board_rb.Checked Then CompareLevel(False, False, False)
    End Sub

    Private Sub Business_rb_CheckedChanged(sender As Object, e As EventArgs) Handles Business_rb.CheckedChanged
        If Business_rb.Checked Then CompareLevel(False, False, False)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If NewLevel IsNot Nothing AndAlso LastLevel IsNot Nothing AndAlso ResultMaterial_dgv.DataSource IsNot Nothing AndAlso ResultRaw_dgv.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            If MyExcel.SaveAs({LastLevel, NewLevel, Top20_dgv.DataSource, ResultRaw_dgv.DataSource, ResultMaterial_dgv.DataSource}, False, , {}) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Exportado.")
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub

    Private Sub ResultRaw_dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ResultRaw_dgv.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                If Not {"No. de Parte", "Descripcion", "Std. Pack", "Costo", "MRP", "Dueño"}.Contains(ResultRaw_dgv.Columns(e.ColumnIndex).Name) Then
                    Dim selected_date As Date = CDate(ResultRaw_dgv.Columns(e.ColumnIndex).Name).Date
                    Dim part_number As String = ResultRaw_dgv.Rows(e.RowIndex).Cells("No. de Parte").Value
                    Dim query = From i In comparative_list
                            Where i.Value.Dates.ContainsKey(selected_date) And i.Value.Material.BOM.Items.ContainsKey(part_number)

                    Dim differences As New DataTable
                    differences.Columns.Add("Material")
                    differences.Columns.Add("Board")
                    differences.Columns.Add("Business")
                    differences.Columns.Add("Quantity", GetType(Integer))
                    differences.Columns.Add("Usage", GetType(Decimal))
                    differences.Columns.Add("Cost", GetType(Decimal))
                    differences.Columns.Add("Containers", GetType(Decimal))

                    For Each i In query
                        With i.Value
                            If .Dates.Item(selected_date).Difference <> 0 Then
                                differences.Rows.Add(.Material.Material, .Board, .Material.Business.Name, .Dates.Item(selected_date).Difference, .Dates.Item(selected_date).Difference * .Material.BOM.Items(part_number).Usage, .Dates.Item(selected_date).Difference * .Material.BOM.Items(part_number).Usage * raw_dictionary.Item(part_number).UnitCost, (.Dates.Item(selected_date).Difference * .Material.BOM.Items(part_number).Usage) / raw_dictionary.Item(part_number).OrderStdPack)
                            End If
                        End With
                    Next
                    differences.DefaultView.Sort = "Usage DESC"

                    Dim cell_rec = ResultRaw_dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                    Dim dgv_point = ResultRaw_dgv.PointToScreen(System.Drawing.Point.Empty)
                    Dim variation As New Sch_LevelScheduleBOMVariation
                    variation.Title = String.Format("{0} | {1}", part_number, selected_date.ToShortDateString)
                    variation.Datasource = differences
                    variation.DefaultLocation = New Drawing.Point(cell_rec.X + dgv_point.X, cell_rec.Y + dgv_point.Y)
                    variation.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NewLevel_Changed(sender As Object, e As DataColumnChangeEventArgs)
        Dim selected_material As String = e.Row.Item("Material")
        Dim new_level_row As DataRow = NewLevel.Rows.Find(selected_material)
        If new_level_row IsNot Nothing Then
            new_level_row.Item(e.Column.ColumnName) = e.ProposedValue
            If comparative_list IsNot Nothing Then
                Dim selected_date As Date
                Dim new_value As Integer
                Select Case e.Column.ColumnName
                    Case "Dia 1"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 3") + e.Row.Item("Dia 4") + e.Row.Item("Dia 5") + e.Row.Item("Dia 6") + e.Row.Item("Dia 7")
                    Case "Dia 2"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 1") + e.Row.Item("Dia 3") + e.Row.Item("Dia 4") + e.Row.Item("Dia 5") + e.Row.Item("Dia 6") + e.Row.Item("Dia 7")
                    Case "Dia 3"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 1") + e.Row.Item("Dia 4") + e.Row.Item("Dia 5") + e.Row.Item("Dia 6") + e.Row.Item("Dia 7")
                    Case "Dia 4"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 3") + e.Row.Item("Dia 1") + e.Row.Item("Dia 5") + e.Row.Item("Dia 6") + e.Row.Item("Dia 7")
                    Case "Dia 5"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 3") + e.Row.Item("Dia 4") + e.Row.Item("Dia 1") + e.Row.Item("Dia 6") + e.Row.Item("Dia 7")
                    Case "Dia 6"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 3") + e.Row.Item("Dia 4") + e.Row.Item("Dia 5") + e.Row.Item("Dia 1") + e.Row.Item("Dia 7")
                    Case "Dia 7"
                        selected_date = SelectecDateNewLevel
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 2") + e.Row.Item("Dia 3") + e.Row.Item("Dia 4") + e.Row.Item("Dia 5") + e.Row.Item("Dia 6") + e.Row.Item("Dia 1")
                    Case "Dia 8"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 10") + e.Row.Item("Dia 11") + e.Row.Item("Dia 12") + e.Row.Item("Dia 13") + e.Row.Item("Dia 14")
                    Case "Dia 9"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 8") + e.Row.Item("Dia 10") + e.Row.Item("Dia 11") + e.Row.Item("Dia 12") + e.Row.Item("Dia 13") + e.Row.Item("Dia 14")
                    Case "Dia 10"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 8") + e.Row.Item("Dia 11") + e.Row.Item("Dia 12") + e.Row.Item("Dia 13") + e.Row.Item("Dia 14")
                    Case "Dia 11"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 10") + e.Row.Item("Dia 8") + e.Row.Item("Dia 12") + e.Row.Item("Dia 13") + e.Row.Item("Dia 14")
                    Case "Dia 12"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 10") + e.Row.Item("Dia 11") + e.Row.Item("Dia 8") + e.Row.Item("Dia 13") + e.Row.Item("Dia 14")
                    Case "Dia 13"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 10") + e.Row.Item("Dia 11") + e.Row.Item("Dia 12") + e.Row.Item("Dia 8") + e.Row.Item("Dia 14")
                    Case "Dia 14"
                        selected_date = SelectecDateNewLevel.AddDays(7)
                        new_value = CInt(e.ProposedValue) + e.Row.Item("Dia 9") + e.Row.Item("Dia 10") + e.Row.Item("Dia 11") + e.Row.Item("Dia 12") + e.Row.Item("Dia 13") + e.Row.Item("Dia 8")
                    Case Else
                        selected_date = SelectecDateNewLevel.AddDays(7 * CInt(e.Column.ColumnName.Replace("Semana", "").Trim))
                        new_value = e.ProposedValue
                End Select
                comparative_list.Item(selected_material).Dates.Item(selected_date).NewQuantity = new_value
                RawComparative(True)
            End If
        End If
    End Sub

    Private Sub Sch_LevelScheduleValidation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        search_box.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Main_tcl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Main_tcl.SelectedIndexChanged
        Select Case Main_tcl.SelectedTab.Name
            Case "NewLevel_tab"
                search_box.SetNewDataGridView(NewLevel_dgv)
            Case "LastLevel_tab"
                search_box.SetNewDataGridView(LastLevel_dgv)
            Case "MaterialComparative_tab"
                search_box.SetNewDataGridView(ResultMaterial_dgv)
            Case "RawComparative_tab"
                search_box.SetNewDataGridView(ResultRaw_dgv)
        End Select
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Try
            search_box.Show()
        Catch ex As Exception
            Select Case Main_tcl.SelectedTab.Name
                Case "NewLevel_tab"
                    search_box = New SearchBox
                    search_box.SetNewDataGridView(Me.NewLevel_dgv)
                    search_box.MdiParent = Me.MdiParent
                Case "LastLevel_tab"
                    search_box = New SearchBox
                    search_box.SetNewDataGridView(Me.LastLevel_dgv)
                    search_box.MdiParent = Me.MdiParent
                Case "MaterialComparative_tab"
                    search_box = New SearchBox
                    search_box.SetNewDataGridView(Me.ResultMaterial_dgv)
                    search_box.MdiParent = Me.MdiParent
                Case "RawComparative_tab"
                    search_box = New SearchBox
                    search_box.SetNewDataGridView(Me.ResultRaw_dgv)
                    search_box.MdiParent = Me.MdiParent
            End Select
            search_box.Show()
        End Try
    End Sub

    Private Sub ResultMaterial_dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ResultMaterial_dgv.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                If Not {"Material", "Tablero", "Negocio"}.Contains(ResultMaterial_dgv.Columns(e.ColumnIndex).Name) Then
                    If Material_rb.Checked Then
                        Dim selected_date As Date = CDate(ResultMaterial_dgv.Columns(e.ColumnIndex).Name.Replace("Suma de", "").Trim).Date
                        Dim selected_material As String = ResultMaterial_dgv.Rows(e.RowIndex).Cells("Material").Value
                        Dim differences As New DataTable
                        differences.Columns.Add("Partnumber")
                        differences.Columns.Add("Usage", GetType(Decimal))
                        differences.Columns.Add("Cost", GetType(Decimal))
                        differences.Columns.Add("Containers", GetType(Decimal))

                        If comparative_list.ContainsKey(selected_material) AndAlso comparative_list.Item(selected_material).Dates.ContainsKey(selected_date) Then
                            With comparative_list.Item(selected_material).Dates.Item(selected_date)
                                For Each partnumber In comparative_list.Item(selected_material).Material.BOM.Items
                                    differences.Rows.Add(partnumber.Value.Partnumber, .Difference * partnumber.Value.Usage, .Difference * partnumber.Value.Usage * raw_dictionary.Item(partnumber.Value.Partnumber).UnitCost, (.Difference * partnumber.Value.Usage) / raw_dictionary.Item(partnumber.Value.Partnumber).OrderStdPack)
                                Next
                            End With
                        End If
                        differences.DefaultView.Sort = "Partnumber ASC"
                        Dim cell_rec = ResultMaterial_dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                        Dim dgv_point = ResultMaterial_dgv.PointToScreen(System.Drawing.Point.Empty)
                        Dim variation As New Sch_LevelScheduleItemBOMVariation
                        variation.Title = String.Format("{0} | {1}", selected_material, selected_date.ToShortDateString)
                        variation.Datasource = differences
                        variation.DefaultLocation = New Drawing.Point(cell_rec.X + dgv_point.X, cell_rec.Y + dgv_point.Y)
                        variation.Show()
                    ElseIf Board_rb.Checked Then
                        Dim selected_date As Date = CDate(ResultMaterial_dgv.Columns(e.ColumnIndex).Name.Replace("Suma de", "").Trim).Date
                        Dim selected_board As String = ResultMaterial_dgv.Rows(e.RowIndex).Cells("Tablero").Value
                        Dim differences As New DataTable
                        differences.Columns.Add("Partnumber")
                        differences.Columns.Add("Usage", GetType(Decimal))
                        differences.Columns.Add("Cost", GetType(Decimal))
                        differences.Columns.Add("Containers", GetType(Decimal))

                        Dim query = From i In comparative_list
                                    Where i.Value.Board = selected_board And i.Value.Dates.ContainsKey(selected_date)

                        For Each item In query
                            With item.Value.Dates.Item(selected_date)
                                For Each partnumber In item.Value.Material.BOM.Items
                                    differences.Rows.Add(partnumber.Value.Partnumber, .Difference * partnumber.Value.Usage, .Difference * partnumber.Value.Usage * raw_dictionary.Item(partnumber.Value.Partnumber).UnitCost, (.Difference * partnumber.Value.Usage) / raw_dictionary.Item(partnumber.Value.Partnumber).OrderStdPack)
                                Next
                            End With
                        Next

                        differences = DatatablePivoter.Get(differences, {"Partnumber"}, {}, {"Usage", "Cost", "Containers"}, {AggregateFunction.Sum, AggregateFunction.Sum, AggregateFunction.Sum})
                        differences.Columns("Suma de Usage").ColumnName = "Usage"
                        differences.Columns("Suma de Cost").ColumnName = "Cost"
                        differences.Columns("Suma de Containers").ColumnName = "Containers"

                        differences.DefaultView.Sort = "Partnumber ASC"
                        Dim cell_rec = ResultMaterial_dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                        Dim dgv_point = ResultMaterial_dgv.PointToScreen(System.Drawing.Point.Empty)
                        Dim variation As New Sch_LevelScheduleItemBOMVariation
                        variation.Title = String.Format("{0} | {1}", selected_board, selected_date.ToShortDateString)
                        variation.Datasource = differences
                        variation.DefaultLocation = New Drawing.Point(cell_rec.X + dgv_point.X, cell_rec.Y + dgv_point.Y)
                        variation.Show()
                    ElseIf Business_rb.Checked Then
                        Dim selected_date As Date = CDate(ResultMaterial_dgv.Columns(e.ColumnIndex).Name.Replace("Suma de", "").Trim).Date
                        Dim selected_business As String = ResultMaterial_dgv.Rows(e.RowIndex).Cells("Negocio").Value
                        Dim differences As New DataTable
                        differences.Columns.Add("Partnumber")
                        differences.Columns.Add("Usage", GetType(Decimal))
                        differences.Columns.Add("Cost", GetType(Decimal))
                        differences.Columns.Add("Containers", GetType(Decimal))

                        Dim query = From i In comparative_list
                                    Where i.Value.Material.Business.Name = selected_business And i.Value.Dates.ContainsKey(selected_date)

                        For Each item In query
                            With item.Value.Dates.Item(selected_date)
                                For Each partnumber In item.Value.Material.BOM.Items
                                    differences.Rows.Add(partnumber.Value.Partnumber, .Difference * partnumber.Value.Usage, .Difference * partnumber.Value.Usage * raw_dictionary.Item(partnumber.Value.Partnumber).UnitCost, (.Difference * partnumber.Value.Usage) / raw_dictionary.Item(partnumber.Value.Partnumber).OrderStdPack)
                                Next
                            End With
                        Next
                        differences = DatatablePivoter.Get(differences, {"Partnumber"}, {}, {"Usage", "Cost", "Containers"}, {AggregateFunction.Sum, AggregateFunction.Sum, AggregateFunction.Sum})
                        differences.Columns("Suma de Usage").ColumnName = "Usage"
                        differences.Columns("Suma de Cost").ColumnName = "Cost"
                        differences.Columns("Suma de Containers").ColumnName = "Cotnainers"

                        differences.DefaultView.Sort = "Partnumber ASC"
                        Dim cell_rec = ResultMaterial_dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                        Dim dgv_point = ResultMaterial_dgv.PointToScreen(System.Drawing.Point.Empty)
                        Dim variation As New Sch_LevelScheduleItemBOMVariation
                        variation.Title = String.Format("{0} | {1}", selected_business, selected_date.ToShortDateString)
                        variation.Datasource = differences
                        variation.DefaultLocation = New Drawing.Point(cell_rec.X + dgv_point.X, cell_rec.Y + dgv_point.Y)
                        variation.Show()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyHarns_btn_Click(sender As Object, e As EventArgs) Handles CopyHarns_btn.Click
        ResultMaterial_dgv.SelectAll()
        ResultMaterial_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = ResultMaterial_dgv.GetClipboardContent()
        ResultMaterial_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub

    Private Sub CopyRaw_btn_Click(sender As Object, e As EventArgs) Handles CopyRaw_btn.Click
        ResultRaw_dgv.SelectAll()
        ResultRaw_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = ResultRaw_dgv.GetClipboardContent()
        ResultRaw_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub

    Private Sub CopyTop_btn_Click(sender As Object, e As EventArgs) Handles CopyTop_btn.Click
        Top20_dgv.SelectAll()
        Top20_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = Top20_dgv.GetClipboardContent()
        Top20_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub

    Private Sub Top20_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Top20_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If Top20_dgv.Columns(e.ColumnIndex).Name <> "No. de Parte" AndAlso Not Top20_dgv.Columns(e.ColumnIndex).Name.Contains("Material") AndAlso Not IsDBNull(e.Value) Then
                If e.Value > 0 Then
                    e.CellStyle.BackColor = Color.LightCoral
                ElseIf e.Value < 0 Then
                    e.CellStyle.BackColor = Color.LightBlue
                End If
            End If
        End If
    End Sub

    Private Sub TopQuantity_rb_CheckedChanged(sender As Object, e As EventArgs) Handles TopQuantity_rb.CheckedChanged, TopCost_rb.CheckedChanged, TopContainers_rb.CheckedChanged
        If comparative_list IsNot Nothing AndAlso CType(sender, RadioButton).Checked Then
            TopComparative()
        End If
    End Sub
End Class