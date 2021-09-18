Public Class Sch_ImportProductionPlan
    Dim productionplan As DataTable
    Dim pivot_productionplan As DataTable
    Dim mrps As DataTable

    Dim imported As Boolean = False

    Dim new_material As DataTable
    Dim new_boards As DataTable
    Dim new_materialboards As DataTable

    Dim current_calendar As New Dictionary(Of Date, Boolean)
    Dim existing_harn_list As New Dictionary(Of String, String)
    Dim existing_board_list As New Dictionary(Of String, String)
    Dim existing_materialboard_list As DataTable

    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        ofd.Title = "Abrir Plan de Producción..."
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Filename_txt.Text = ofd.FileName
            Dim sheet = SheetSelector.Get(ofd.FileName)
            LoadingScreen.Show()
            Dim data = DTable.FromFile(ofd.FileName, True, False, String.Format("SELECT * FROM [{0}]", sheet))
            LoadExistingData()
            Convert(data)
        End If
    End Sub

    Public Sub LoadExistingData()
        existing_harn_list.Clear()
        existing_board_list.Clear()
        Dim harns_dt As DataTable = SQL.Current.GetDatatable("SELECT Material, Business FROM Sch_Materials;")
        For Each row As DataRow In harns_dt.Rows
            existing_harn_list.Add(row.Item("Material").ToString.ToUpper, row.Item("Business"))
        Next
        Dim boards_dt As DataTable = SQL.Current.GetDatatable("SELECT Board, Business FROM Mfg_Boards")
        For Each row As DataRow In boards_dt.Rows
            existing_board_list.Add(row.Item("Board").ToString.ToUpper, row.Item("Business"))
        Next
        existing_materialboard_list = SQL.Current.GetDatatable("SELECT Material, Board, Active FROM Sch_MaterialBoards")
        existing_materialboard_list.PrimaryKey = {existing_materialboard_list.Columns("Material"), existing_materialboard_list.Columns("Board")}
    End Sub

    Private Sub Convert(data As DataTable)
        Dim errors As Integer = 0
        ProductionPlan_dgv.DataSource = Nothing
        RemoveHandler new_material.RowDeleting, AddressOf NewMaterialRowChanging
        RemoveHandler new_material.ColumnChanging, AddressOf NewMaterialColumChanging
        RemoveHandler new_boards.ColumnChanging, AddressOf NewBoardColumChanging
        If productionplan IsNot Nothing Then productionplan.Rows.Clear()
        new_material.Rows.Clear()
        new_boards.Rows.Clear()
        new_materialboards.Rows.Clear()
        Dim last_allowed_date As Date = LastMonday(Delta.CurrentDate)
        If data IsNot Nothing Then
            If List_rb.Checked AndAlso data.Columns.Count >= 4 Then
                For Each row As DataRow In data.Rows
                    If IsDate(row.Item(2)) AndAlso CDate(row.Item(2)).Date >= last_allowed_date.Date AndAlso IsNumeric(row.Item(3)) AndAlso Not IsDBNull(row.Item(3)) AndAlso CInt(row.Item(3)) >= 0 Then
                        Try
                            productionplan.Rows.Add(row.Item(0).ToString.Trim, row.Item(1).ToString.Trim, row.Item(2), CInt(row.Item(3)))
                        Catch ex As Exception
                            errors += 1
                        End Try
                    Else
                        errors += 1
                    End If
                Next
            ElseIf ColumnHeader_rb.Checked AndAlso data.Columns.Count >= 3 AndAlso IsDate(data.Columns(2).ColumnName) Then '(Double.TryParse(data.Columns(2).ColumnName, Nothing) AndAlso Date.FromOADate(CDbl(data.Columns(2).ColumnName)))
                For c = 2 To data.Columns.Count - 1
                    If IsDate(data.Columns(c).ColumnName) AndAlso CDate(data.Columns(c).ColumnName).Date >= last_allowed_date.Date Then
                        For Each row As DataRow In data.Rows
                            If IsNumeric(row.Item(2)) AndAlso CInt(row.Item(2)) >= 0 AndAlso Not IsDBNull(row.Item(2)) Then
                                Try
                                    productionplan.Rows.Add(row.Item(0).ToString.Trim, row.Item(1).ToString.Trim, CDate(data.Columns(c).ColumnName), CInt(row.Item(c)))
                                Catch ex As Exception
                                    errors += 1
                                End Try
                            Else
                                errors += 1
                            End If
                        Next
                    Else
                        errors += 1
                    End If
                Next
            ElseIf ColumnHeader_rb.Checked AndAlso data.Columns.Count >= 3 AndAlso Double.TryParse(data.Columns(2).ColumnName, Nothing) Then
                For c = 2 To data.Columns.Count - 1
                    If Double.TryParse(data.Columns(c).ColumnName, Nothing) Then
                        For Each row As DataRow In data.Rows
                            If IsNumeric(row.Item(c)) AndAlso CInt(row.Item(c)) >= 0 AndAlso Date.FromOADate(data.Columns(c).ColumnName).Date >= last_allowed_date.Date Then
                                Try
                                    productionplan.Rows.Add(row.Item(0).ToString.Trim, row.Item(1).ToString.Trim, Date.FromOADate(data.Columns(c).ColumnName), CInt(row.Item(c)))
                                Catch ex As Exception
                                    errors += 1
                                End Try
                            Else
                                errors += 1
                            End If
                        Next
                    Else
                        errors += 1
                    End If
                Next
            Else
                errors = -2
            End If

            'CARGAR EL CALENDARIO PARA IDENTIFICAR DIAS INHABILES
            'EN EL DICCIONARIO, LA COLUMNA DE TIPO BOOLEAN INDICA SI EL DIA ES LABORAL
            current_calendar.Clear()
            Dim min_date As Date = Delta.NullReplace(productionplan.Compute("MIN(Fecha)", ""), Delta.CurrentDate)
            Dim max_date As Date = Delta.NullReplace(productionplan.Compute("MAX(Fecha)", ""), Delta.CurrentDate)
            Dim sys_calendar As DataTable = SQL.Current.GetDatatable(String.Format("SELECT [Date], WorkingShifts FROM Sys_Calendar WHERE [Date] BETWEEN '{0}' AND '{1}';", min_date.ToString("yyyy-MM-dd"), max_date.ToString("yyyy-MM-dd")))
            For Each row As DataRow In sys_calendar.Rows
                current_calendar.Add(CDate(row.Item("Date")).Date, Not IsDBNull(row.Item("WorkingShifts")))
            Next


            Dim pivoter As New PivotTable(productionplan)
            pivot_productionplan = pivoter.PivotDates("Material", "Tablero", "Cantidad", AggregateFunction.Sum, "Fecha", "System.Int32")

            For Each row As DataRow In pivot_productionplan.Rows
                If Not existing_harn_list.ContainsKey(row.Item("Material").ToString.ToUpper) AndAlso new_material.Rows.Find(row.Item("Material")) Is Nothing Then
                    new_material.Rows.Add(row.Item("Material"))
                End If
                If Not existing_board_list.ContainsKey(row.Item("Tablero").ToString.ToUpper) AndAlso new_boards.Rows.Find(row.Item("Tablero")) Is Nothing Then
                    Dim new_row As DataRow = new_boards.NewRow
                    new_row.Item("Board") = row.Item("Tablero")
                    If existing_harn_list.ContainsKey(row.Item("Material")) Then
                        new_row.Item("Business") = existing_harn_list.Item(row.Item("Material"))
                    End If
                    new_boards.Rows.Add(new_row)
                End If
                If existing_materialboard_list.Rows.Find({row.Item("Material"), row.Item("Tablero")}) Is Nothing AndAlso new_materialboards.Rows.Find({row.Item("Material"), row.Item("Tablero")}) Is Nothing Then
                    new_materialboards.Rows.Add(row.Item("Material"), row.Item("Tablero"), True)
                End If

                If Not CBool(Parameter("SCH_AllowMultipleMaterialBoardScheduling", False)) AndAlso Delta.NullReplace(pivot_productionplan.Compute("COUNT(Tablero)", String.Format("Material = '{0}' AND Tablero <> '{1}'", row.Item("Material"), row.Item("Tablero"))), 0) > 0 Then
                    new_material.Rows.Clear()
                    new_boards.Rows.Clear()
                    new_materialboards.Rows.Clear()
                    ProductionPlan_dgv.DataSource = Nothing
                    LoadingScreen.Hide()
                    FlashAlerts.ShowError("Existen numeros de arnes en distintos tableros en el plan de produccion. Imposible continuar.", 2)
                    Exit Sub
                End If
            Next
            Materials_tab.Text = String.Format("Arneses Nuevos ({0})", new_material.Rows.Count)
            Boards_tab.Text = String.Format("Tableros Nuevos ({0})", new_boards.Rows.Count)

            AddHandler new_material.RowDeleting, AddressOf NewMaterialRowChanging
            AddHandler new_material.ColumnChanging, AddressOf NewMaterialColumChanging
            AddHandler new_boards.ColumnChanging, AddressOf NewBoardColumChanging
            ProductionPlan_dgv.DataSource = pivot_productionplan
        Else
            ProductionPlan_dgv.DataSource = Nothing
            errors = -1
        End If
        LoadingScreen.Hide()
        Select Case errors
            Case 0
                Save_btn.Enabled = True
            Case -1
                Save_btn.Enabled = False
                FlashAlerts.ShowError("Error al leer el archivo.")
            Case -2
                Save_btn.Enabled = False
                FlashAlerts.ShowError("Error al convertir el archivo en el formato seleccionado.")
            Case Else
                If productionplan.Rows.Count = 0 Then
                    Save_btn.Enabled = False
                    FlashAlerts.ShowError("Error al convertir el archivo en el formato seleccionado.")
                Else
                    Save_btn.Enabled = True
                    FlashAlerts.ShowError(String.Format("{0} error(es) encontrado(s).", errors))
                End If
        End Select
        If new_material.Rows.Count > 0 Then
            SAP_btn.Enabled = True
        Else
            SAP_btn.Enabled = False
        End If
    End Sub

    Private Sub Sch_ImportProductionPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Delta.SetDataGridViewDeltaStyle(ProductionPlan_dgv)
        Delta.SetDataGridViewDeltaStyle(NewBoards_dgv)
        Delta.SetDataGridViewDeltaStyle(NewMaterials_dgv)

        new_material = New DataTable
        new_material.Columns.Add("Material")
        new_material.Columns.Add("CustomerPN")
        new_material.Columns.Add("Description")
        new_material.Columns.Add("StdPack")
        new_material.Columns.Add("Business")
        new_material.Columns.Add("StartProduction")
        new_material.Columns.Add("EndProduction")
        new_material.Columns.Add("Class")
        new_material.Columns.Add("MRP")
        new_material.PrimaryKey = {new_material.Columns("Material")}
        new_material.Columns("StartProduction").DefaultValue = New Date(1990, 1, 1)
        new_material.Columns("EndProduction").DefaultValue = New Date(2099, 12, 31)
        new_material.Columns("StdPack").DefaultValue = 1

        new_boards = New DataTable
        new_boards.Columns.Add("Board")
        new_boards.Columns.Add("Class")
        new_boards.Columns.Add("Volume")
        new_boards.Columns.Add("ShiftCombination")
        new_boards.Columns.Add("InstalledCapacity", GetType(Integer))
        new_boards.Columns.Add("RealCapacity", GetType(Integer))
        new_boards.Columns.Add("Business")
        new_boards.PrimaryKey = {new_boards.Columns("Board")}
        new_boards.Columns("Class").DefaultValue = "Board"
        new_boards.Columns("Volume").DefaultValue = "High"
        new_boards.Columns("ShiftCombination").DefaultValue = SQL.Current.GetString("SELECT TOP 1 Combination FROM Sys_ShiftCombination ORDER BY LEN(Combination) DESC,Combination")
        new_boards.Columns("InstalledCapacity").DefaultValue = 1
        new_boards.Columns("RealCapacity").DefaultValue = 1

        productionplan = New DataTable
        productionplan.Columns.Add("Material")
        productionplan.Columns.Add("Tablero")
        productionplan.Columns.Add("Fecha", GetType(Date))
        productionplan.Columns.Add("Cantidad", GetType(Integer))
        productionplan.PrimaryKey = {productionplan.Columns("Material"), productionplan.Columns("Tablero"), productionplan.Columns("Fecha")}

        Dim board_classes As New DataTable
        board_classes.Columns.Add("Class")
        board_classes.Columns.Add("Name")
        board_classes.Rows.Add("Board", "Tablero")
        board_classes.Rows.Add("TableTop", "Mesa")

        Dim board_volume As New DataTable
        board_volume.Columns.Add("Volume")
        board_volume.Columns.Add("Name")
        board_volume.Rows.Add("High", "Alto")
        board_volume.Rows.Add("Low", "Bajo")

        With CType(NewBoards_dgv.Columns("Class_Board"), DataGridViewComboBoxColumn)
            .DataSource = board_classes
            .ValueMember = "Class"
            .DisplayMember = "Name"
        End With

        With CType(NewBoards_dgv.Columns("Volume"), DataGridViewComboBoxColumn)
            .DataSource = board_volume
            .ValueMember = "Volume"
            .DisplayMember = "Name"
        End With

        With CType(NewBoards_dgv.Columns("ShiftCombination"), DataGridViewComboBoxColumn)
            .DataSource = SQL.Current.GetDatatable("SELECT Combination FROM Sys_ShiftCombination ORDER BY Combination")
            .ValueMember = "Combination"
            .DisplayMember = "Combination"
        End With

        With CType(NewMaterials_dgv.Columns("Business"), DataGridViewComboBoxColumn)
            .DataSource = SQL.Current.GetDatatable("SELECT Family + ' - ' + Business AS FamBusiness, Business FROM Sch_Business ORDER BY Family,Business")
            .ValueMember = "Business"
            .DisplayMember = "FamBusiness"
        End With

        With CType(NewMaterials_dgv.Columns("Class_Material"), DataGridViewComboBoxColumn)
            .DataSource = SQL.Current.GetDatatable("SELECT Class FROM Sch_MaterialClasses ORDER BY Class")
            .ValueMember = "Class"
            .DisplayMember = "Class"
        End With

        mrps = SQL.Current.GetDatatable("SELECT MRP FROM Sch_MRPControllers ORDER BY MRP")
        mrps.PrimaryKey = {mrps.Columns("MRP")}

        With CType(NewMaterials_dgv.Columns("MRP"), DataGridViewComboBoxColumn)
            .DataSource = mrps
            .ValueMember = "MRP"
            .DisplayMember = "MRP"
        End With

        If new_material.Rows.Count > 0 Then
            SAP_btn.Enabled = True
        Else
            SAP_btn.Enabled = False
        End If

        new_materialboards = New DataTable
        new_materialboards.Columns.Add("Material")
        new_materialboards.Columns.Add("Board")
        new_materialboards.Columns.Add("Active", GetType(Boolean))
        new_materialboards.PrimaryKey = {new_materialboards.Columns("Material"), new_materialboards.Columns("Board")}

        NewMaterials_dgv.DataSource = new_material
        NewBoards_dgv.DataSource = new_boards
        ProductionPlan_dgv.DataSource = productionplan
    End Sub

    Private Sub Sch_ImportProductionPlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If imported Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If ValidateWorkingDates() AndAlso SaveHarns() AndAlso SaveBoards() Then
            If productionplan.Rows.Count > 0 Then
                LoadingScreen.Show()
                If new_materialboards.Rows.Count > 0 AndAlso SQL.Current.Bulk(new_materialboards, "Sch_MaterialBoards") Then
                    new_materialboards.Rows.Clear()
                End If
                If CBool(Parameter("SCH_AllowMultipleMaterialBoardScheduling", False)) Then 'VALIDAR SI EN LA PLANTA SE PUEDE CONSTRUIR UN MISMO ARNES EN VARIOS TABLEROS
                    'ESTE QUERY INSERTA TODOS LOS ITEM NUEVOS EN SCH_DAILYPRODUCTIONPLAN Y LUEGO INSERTA TODOS LOS POSIBLES AJUSTES QUE HAYA HABIDO EN SCH_DAILYPRODUCTIONPLANMOVEMENTS
                    If SQL.Current.Upsert(productionplan, "tmpProductionPlan", "CREATE TABLE #tmpProductionPlan ([Material] [char](8) NOT NULL,[Board] [varchar](15) NOT NULL,[Date] [date] NOT NULL,[Quantity] [smallint] NOT NULL)", String.Format("INSERT INTO Sch_DailyProductionPlan (Material,Board,[Date]) SELECT B.Material, B.Board, B.[Date] FROM Sch_DailyProductionPlan AS A FULL OUTER JOIN #tmpProductionPlan AS B ON A.Material = B.Material AND A.Board = B.Board AND A.[Date] = B.[Date] WHERE A.ID IS NULL; INSERT INTO Sch_DailyProductionPlanMovements (ProductionPlanID, Quantity, [Date], Username) SELECT A.ID, B.Quantity - A.Quantity, GETDATE(), '{0}' AS Username FROM vw_Sch_DailyProductionPlan AS A FULL OUTER JOIN #tmpProductionPlan AS B ON A.Material = B.Material AND A.Board = B.Board AND A.[Date] = B.[Date] WHERE A.Quantity <> B.Quantity;", User.Current.Username)) Then
                        imported = True
                        LoadingScreen.Hide()
                        productionplan.Rows.Clear()
                        ProductionPlan_dgv.DataSource = Nothing
                        FlashAlerts.ShowConfirm("Plan de producción guardado correctamente.")
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al guardar el plan de producción.")
                    End If
                Else
                    'ESTE QUERY ACTUALIZA LOS TABLEROS DE SCH_DAILYPRODUCTIONPLAN PRIMERAMENTE SI ES QUE EL MATERIAL YA PERTENECE OTRO TABLERO E INSERTA TODOS LOS ITEM NUEVOS EN SCH_DAILYPRODUCTIONPLAN Y LUEGO INSERTA TODOS LOS POSIBLES AJUSTES QUE HAYA HABIDO EN SCH_DAILYPRODUCTIONPLANMOVEMENTS
                    If SQL.Current.Upsert(productionplan, "tmpProductionPlan", "CREATE TABLE #tmpProductionPlan ([Material] [char](8) NOT NULL,[Board] [varchar](15) NOT NULL,[Date] [date] NOT NULL,[Quantity] [smallint] NOT NULL)", String.Format("UPDATE Sch_MaterialBoards SET Active = CASE WHEN Sch_MaterialBoards.Board = B.Board THEN 1 ELSE 0 END FROM (SELECT DISTINCT Material, Board FROM #tmpProductionPlan) AS B WHERE Sch_MaterialBoards.Material = B.Material; UPDATE Sch_DailyProductionPlan SET Board = B.Board FROM (SELECT DISTINCT Material, Board FROM #tmpProductionPlan) AS B WHERE Sch_DailyProductionPlan.Material = B.Material AND [Date] >= '{0}'; INSERT INTO Sch_DailyProductionPlan (Material,Board,[Date]) SELECT B.Material, B.Board, B.[Date] FROM Sch_DailyProductionPlan AS A RIGHT JOIN #tmpProductionPlan AS B ON A.Material = B.Material AND A.Board = B.Board AND A.[Date] = B.[Date] WHERE A.ID IS NULL; INSERT INTO Sch_DailyProductionPlanMovements (ProductionPlanID, Quantity, [Date], Username) SELECT A.ID, B.Quantity - A.Quantity, GETDATE(), '{1}' AS Username FROM vw_Sch_DailyProductionPlan AS A FULL OUTER JOIN #tmpProductionPlan AS B ON A.Material = B.Material AND A.Board = B.Board AND A.[Date] = B.[Date] WHERE A.Quantity <> B.Quantity;", LastMonday(Delta.CurrentDate).ToString("yyyy-MM-dd"), User.Current.Username)) Then
                        imported = True
                        LoadingScreen.Hide()
                        productionplan.Rows.Clear()
                        ProductionPlan_dgv.DataSource = Nothing
                        FlashAlerts.ShowConfirm("Plan de producción guardado correctamente.")
                    Else
                        LoadingScreen.Hide()
                        FlashAlerts.ShowError("Error al guardar el plan de producción.")
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ValidateWorkingDates() As Boolean
        Dim dates As DataTable = productionplan.DefaultView.ToTable(True, "Fecha")
        For Each row As DataRow In dates.Rows
            If productionplan.Compute("COUNT(Material)", String.Format("Fecha = #{0}# AND Cantidad <> 0", row.Item("Fecha"))) > 0 AndAlso Not (current_calendar.ContainsKey(CDate(row.Item("Fecha")).Date) AndAlso current_calendar.Item(CDate(row.Item("Fecha")).Date)) Then
                If MessageBox.Show("Existen dias inhábiles en el plan de producción. ¿Continuar con la carga aun así?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub NewBoards_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles NewBoards_dgv.DataError
        e.Cancel = True
    End Sub

    Private Sub NewMaterials_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles NewMaterials_dgv.DataError
        e.Cancel = True
    End Sub

    Private Function SaveBoards() As Boolean
        If new_boards.Rows.Count > 0 Then
            If new_boards.Compute("COUNT(Board)", "Class IS NULL OR Volume IS NULL OR ShiftCombination IS NULL OR InstalledCapacity IS NULL OR RealCapacity IS NULL") = 0 Then
                If SQL.Current.Bulk(new_boards, "Mfg_Boards") Then
                    new_boards.Rows.Clear()
                    Return True
                Else
                    FlashAlerts.ShowError("Error al intentar guardar los tableros.")
                    Return False
                End If
            Else
                FlashAlerts.ShowInformation("Debes ingresar toda la información necesaria de los tableros.")
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Function SaveHarns() As Boolean
        If new_material.Rows.Count > 0 Then
            If new_material.Compute("COUNT(Material)", "CustomerPN IS NULL OR Description IS NULL OR StdPack IS NULL OR Business IS NULL OR StartProduction IS NULL OR EndProduction IS NULL OR Class IS NULL OR MRP IS NULL") = 0 Then
                If SQL.Current.Bulk(new_material, "Sch_Materials") Then
                    If new_material.Rows.Count > 0 Then
                        Dim new_material_list As New ArrayList
                        For Each row As DataRow In new_material.Rows
                            new_material_list.Add(row.Item("Material"))
                        Next
                        Select Case CR.UpdateMaterialListBOM(new_material_list)
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
                    new_material.Rows.Clear()
                    Return True
                Else
                    FlashAlerts.ShowError("Error al intentar guardar los arneses.")
                    Return False
                End If
            Else
                FlashAlerts.ShowInformation("Debes ingresar toda la información necesaria de los arneses.")
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub SAP_btn_Click(sender As Object, e As EventArgs) Handles SAP_btn.Click
        If new_material.Rows.Count > 0 Then
            Dim sap As New SAP
            If sap.Available Then
                LoadingScreen.Show()
                Dim plants As New ArrayList
                plants.Add(Parameter("SYS_PlantCode"))

                Dim count As Integer = 0
                Dim materials As New ArrayList
                For Each m As DataRow In new_material.Rows
                    count += 1
                    materials.Add(m.Item("Material"))
                    If materials.Count = 200 OrElse count = new_material.Rows.Count Then
                        Dim filename As String = GF.TempTXTPath
                        If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(plants, materials, filename) Then
                            Dim txt = CSV.Datatable(filename, vbTab, True, False)
                            TryDelete(filename)
                            If txt IsNot Nothing Then
                                'txt.DefaultView.RowFilter = "MRP_CONTROLLER <> '' AND (MATERIAL LIKE 'C%' OR ([MATERIAL_TYPE] = 'HALB' AND [BUM] NOT IN ('EA') AND NOT IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,1),SUBSTRING([MATERIAL],1,1)) = 'L' AND (PROC_TYPE = 'F' OR (PROC_TYPE = 'E' AND [DESCRIPTION] LIKE '%TERM%'))))"
                                txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                                txt.Columns.Add("DBL_RV", GetType(Double), "Convert([ROUNDING_VALUE],'System.Double')")
                                txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")

                                Dim all_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "DBL_RV", "UNIT_PRICE", "MRP_CONTROLLER")
                                Dim new_mrps As DataTable = all_data.DefaultView.ToTable(True, "MRP_CONTROLLER")
                                For Each row As DataRow In new_mrps.Rows
                                    If mrps.Rows.Find(row.Item("MRP_CONTROLLER")) Is Nothing Then
                                        mrps.Rows.Add(row.Item("MRP_CONTROLLER"))
                                    End If
                                Next

                                SQL.Current.Upsert(mrps, "tmpMRP", "CREATE TABLE #tmpMRP([MRP] [varchar](5) NOT NULL)", "MERGE Sch_MRPControllers AS target USING #tmpMRP AS source ON target.MRP = source.MRP WHEN NOT MATCHED THEN INSERT (MRP,Username) VALUES (source.MRP,'DeltaERP');")
                                For Each row As DataRow In all_data.Rows
                                    Dim material = new_material.Rows.Find(row.Item("RT_MATERIAL"))
                                    If material IsNot Nothing Then
                                        material.Item("Description") = row.Item("DESCRIPTION")
                                        material.Item("StdPack") = row.Item("DBL_RV")
                                        material.Item("MRP") = row.Item("MRP_CONTROLLER")
                                    End If
                                Next
                                LoadingScreen.Hide()
                            Else
                                LoadingScreen.Hide()
                                FlashAlerts.ShowError("Error al leer el archivo.")
                                Exit Sub
                            End If
                        Else
                            LoadingScreen.Hide()
                            FlashAlerts.ShowError("Error al descargar la información.")
                            Exit Sub
                        End If
                        materials.Clear()
                    End If
                Next
            Else
                FlashAlerts.ShowError("Sesion de SAP no encontrada.")
            End If
        End If
    End Sub

    Private Sub NewMaterialRowChanging(sender As Object, e As DataRowChangeEventArgs)
        If e.Action = DataRowAction.Delete Then
            For Each row As DataRow In productionplan.Select(String.Format("Material = '{0}'", e.Row.Item("Material", DataRowVersion.Current)))
                productionplan.Rows.Remove(row)
            Next

            For Each row As DataRow In pivot_productionplan.Select(String.Format("Material = '{0}'", e.Row.Item("Material", DataRowVersion.Current)))
                pivot_productionplan.Rows.Remove(row)
            Next

            For Each row As DataRow In new_materialboards.Select(String.Format("Material = '{0}'", e.Row.Item("Material", DataRowVersion.Current)))
                If productionplan.Compute("COUNT(Material)", String.Format("Tablero = '{0}' AND Material <> '{1}'", row.Item("Board"), e.Row.Item("Material", DataRowVersion.Current))) = 0 Then
                    For Each row_board As DataRow In new_boards.Select(String.Format("Board = '{0}'", row.Item("Board")))
                        new_boards.Rows.Remove(row_board)
                    Next
                End If
                new_materialboards.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub NewBoardColumChanging(sender As Object, e As DataColumnChangeEventArgs)
        If e.Column.ColumnName = "Board" Then
            For Each row As DataRow In productionplan.Select(String.Format("Tablero = '{0}'", e.Row.Item("Board", DataRowVersion.Current)))
                row.Item("Tablero") = e.ProposedValue
            Next

            For Each row As DataRow In pivot_productionplan.Select(String.Format("Tablero = '{0}'", e.Row.Item("Board", DataRowVersion.Current)))
                row.Item("Tablero") = e.ProposedValue
            Next

            For Each row As DataRow In new_materialboards.Select(String.Format("Board = '{0}'", e.Row.Item("Board", DataRowVersion.Current)))
                If existing_materialboard_list.Rows.Find({row.Item("Material"), e.ProposedValue}) IsNot Nothing Then
                    row.Delete()
                Else
                    row.Item("Board") = e.ProposedValue
                End If
            Next

            If existing_board_list.ContainsKey(e.ProposedValue.ToString.ToUpper) Then
                e.Row.Delete()
                Boards_tab.Text = String.Format("Tableros Nuevos ({0})", new_boards.Rows.Count)
            End If
        End If
    End Sub

    Private Sub NewMaterialColumChanging(sender As Object, e As DataColumnChangeEventArgs)
        If e.Column.ColumnName = "Business" Then
            For Each row In new_boards.Select(String.Format("Board = '{0}'", productionplan.Select(String.Format("Material = '{0}'", e.Row.Item("Material"))).First.Item("Tablero")))
                row.Item("Business") = e.ProposedValue.ToString.ToUpper
            Next
        End If
    End Sub

    Private Sub ProductionPlan_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles ProductionPlan_dgv.CellFormatting
        If IsDate(ProductionPlan_dgv.Columns(e.ColumnIndex).Name) AndAlso (Not current_calendar.ContainsKey(CDate(ProductionPlan_dgv.Columns(e.ColumnIndex).Name)) OrElse Not current_calendar.Item(CDate(ProductionPlan_dgv.Columns(e.ColumnIndex).Name))) Then
            e.CellStyle.BackColor = Color.LightCoral
        End If
    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub

    Private Sub Filename_txt_TextChanged(sender As Object, e As EventArgs) Handles Filename_txt.TextChanged

    End Sub
End Class