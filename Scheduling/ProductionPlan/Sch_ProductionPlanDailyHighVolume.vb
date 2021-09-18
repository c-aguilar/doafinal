Imports Microsoft.VisualBasic.Strings
Public Class Sch_ProductionPlanDailyHighVolume
    Dim from_day As Date
    Dim to_day As Date
    Dim frozen_days As Integer = 0
    Dim ds_production_plan As DataSet
    Dim original_pp_pivot As DataTable = Nothing
    Dim original_pp_comments As DataTable = Nothing
    Dim changes_saved As Boolean = True
    Dim selected_business, selected_family As String
    Dim cms_rowIndex, cms_columnIndex As Integer
    Dim sap_update As Date
    Dim selected_family_headcount As DataTable
    Dim stop_sum As Boolean = False
    Dim sb As SearchBox
#Region "Form"
    Private Sub ProductionPlanDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frozen_days = Parameter("SCH_FrozenDays", 0)
        from_day = LastSunday()
        to_day = from_day.AddDays(20)
        SumarizeByCombo.SelectedItem = "Class"
        PastDueCombo.SelectedItem = "Weekly"
        ShowCombo.SelectedItem = "Only Requirements"
        InitialDateButton.Text = String.Format("{0} - {1}", from_day.ToString("M/d/yy"), to_day.ToString("M/d/yy"))
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.dgvProductionPlan)
    End Sub
    Private Sub ProductionPlanDaily_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not changes_saved Then
            Select Case MessageBox.Show("Save changes before close?", "Changes not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case Windows.Forms.DialogResult.Yes
                    Save()
                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
            End Select
        Else
            e.Cancel = False
        End If
    End Sub
    Private Sub ProductionPlanDaily_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
#End Region
#Region "ToolStrip"
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        rtbLog.Copy()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If rtbLog.Text.Trim <> "" Then
            If SaveTXT(rtbLog.Lines) Then
                MsgBox("Done!", MsgBoxStyle.Information, APP)
            End If
        End If
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        Clipboard.SetDataObject(dgvProductionPlan.GetClipboardContent())
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs)
        If Not IsNothing(ds_production_plan) Then
            MyExcel.Print(ds_production_plan.Tables("CurrentProductionPlan"), False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape)
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        If Not changes_saved Then
            Save()
        End If
    End Sub

    Private Sub AutoScheduleButton_Click(sender As Object, e As EventArgs) Handles AutoScheduleToolStripMenuItem.Click
        Dim options As New Sch_AutoScheduleOptions
        options.MinDate = DateAdd(DateInterval.Day, frozen_days + 1, CurrentDate).Date
        options.MaxDate = to_day ' from_day.AddDays(((weeks_toShow - 1) * 7) - 1).Date
        If options.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadingScreen.Show()
            'DETENER LA SUMATORIA AUTOMATICA
            stop_sum = True
            'CREAR TABLA PARA GUARDAR LAS CANTIDADES QUE NO SE DESEAN MODIFICAR CON LA OPCION "REPLACE EXISTING VALUES"
            Dim frozen_qtys As New DataTable
            frozen_qtys.Columns.Add("Material")
            frozen_qtys.Columns.Add("Board")
            frozen_qtys.Columns.Add("Date", GetType(Date))
            frozen_qtys.Columns.Add("Quantity", GetType(Integer))
            frozen_qtys.PrimaryKey = {frozen_qtys.Columns("Material"), frozen_qtys.Columns("Board"), frozen_qtys.Columns("Date")}

            'DEJAR EL PLAN DE PRODUCCION EN CEROS
            For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                'OMITIR LOS RENGLONES DE SUMATORIA
                If Not {"Material", "*"}.Contains(row.Item("Material")) Then
                    For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                        'OMITIR LAS COLUMNAS QUE NO SON FECHAS, Y ADEMAS NO ESTAN DENTRO DEL RANGO SELECCIONADO POR EL USUARIO Y AQUELLAS QUE NO TIENEN CANTIDAD
                        If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) _
                            AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") AndAlso _
                            CDate(column.ColumnName).Date >= options.From.Date AndAlso CDate(column.ColumnName).Date <= options.To.Date _
                            AndAlso row.Item(column.ColumnName) > 0 Then
                            'GUARDAR LOS REGISTROS QUE SI TIENE CANTIDAD MAYOR A 0
                            If options.ReplaceExisitng Then frozen_qtys.Rows.Add(row.Item("Material"), row.Item("Board"), CDate(column.ColumnName), row.Item(column.ColumnName))
                            row.Item(column.ColumnName) = 0
                        End If
                    Next
                End If
            Next

            'OBTENER EL HEADCOUNT POR TURNO DE LA FAMILIA
            Dim headcount = SQL.Current.GetDatatable("Mfg_Headcount", "Family", selected_family)
            headcount.PrimaryKey = {headcount.Columns("Shift")}
            'OBTENER LA INFO DE CADA TURNO DE PLANTA
            Dim shifts As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sys_Shifts")
            shifts.PrimaryKey = {shifts.Columns("Shift")}

            'TABLA PARA ACUMULAR CANTIDADES DECIMALES DEL PLAN DE PRODUCCION Y USARLAS ACOMPLETEN CANTIDAD ENTERAS
            Dim dec_column As New DataTable
            dec_column.Columns.Add("Material", GetType(String))
            dec_column.Columns.Add("Board", GetType(String))
            dec_column.Columns.Add("Quantity", GetType(Single))
            dec_column.PrimaryKey = {dec_column.Columns("Material"), dec_column.Columns("Board")}

            'RECORRER CADA COLUMNA DEL PLAN
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                'OMITIR COLUMNAS QUE NO SON FECHAS, Y AQUELLAS QUE NO CORRESPONDAN AL PERIODO SELECCIONADO POR EL USUARIO
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) _
                    AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") _
                    AndAlso CDate(column.ColumnName).Date >= options.From.Date AndAlso CDate(column.ColumnName).Date <= options.To.Date Then

                    'OBTENER LOS TURNOS QUE SE TRABAJAN EN EL DIA TAL
                    Dim shifts_onday As DataRow = ds_production_plan.Tables("WorkingShifts").Rows.Find(column.ColumnName)
                    'RECORRER CADA TURNO
                    For Each shift As DataRow In shifts.Rows
                        'VALIDAR QUE SE TRABAJE EN LA FAMILIA TRABAJE EN TAL TURNO DEL DIA
                        If shifts_onday.Item("WorkingShifts").ToString.ToLower.Contains(shift.Item("Shift").ToString.ToLower) Then
                            'OBTENER EL HEADCOUNT DEL TURNO EN ESPECIFICO
                            Dim headcount_shift As DataRow = headcount.Rows.Find(shift.Item("Shift"))
                            Dim available_headcount As Integer = 0
                            If headcount_shift IsNot Nothing Then available_headcount = headcount_shift.Item("LowVolume")
                            'TERMINAR EL CICLO SI NO HAY HEADCOUNT EN EL TURNO
                            If available_headcount = 0 Then Continue For

                            'SI EXISTE HEADCOUNT DISPONIBLE:
                            'CALCULAR SEGUNDOS-HOMBRE DEL TURNO
                            Dim total_secondsmen_available As Integer = shift.Item("ManufacturingSeconds") * available_headcount

                            'DEFINIR LA FECHA/COLUMNA DE PASTDUE QUE SE DEBE ESTAR CONSIDERANDO PARA REALIZAR EL PLAN
                            Dim pd_column_tolook As Date
                            If options.AverageRequirements Then
                                ' SI EL USUARIO SELECCIONO AVERAGE BY WEEK ENTONCES LA COLUMNA DEL PAST DUE SERA LA COLUMNA DEL SABADO DE LA SEMANA X
                                ' X DEPENDERA DE LA CANTIDAD DE SEMANAS A PROMEDIAR QUE USUARIO SELECCIONO
                                pd_column_tolook = NextSaturday(CDate(column.ColumnName).AddDays(7 * (options.AverageWeeks - 1)))
                            Else
                                'SI NO ES AVERAGE BY WEEK, LA COLUMNA DEL PAST DUE SERA LA INMEDIATA
                                pd_column_tolook = CDate(column.ColumnName)
                            End If


                            Dim pd_column As String = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                            'VALIDAR QUE LA COLUMNA DEL PAST DUE A CONSIDERAR EXISTA, POR SI EL USUARIO SELECCIONO MAS DE 1 SEMANA DE PROMEDIO
                            While Not ds_production_plan.Tables("CurrentProductionPlan").Columns.Contains(pd_column)
                                pd_column_tolook = pd_column_tolook.AddDays(-1)
                                pd_column = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                            End While

                            'CALCULAR EL TOTAL DE SEGUNDOS-HOMBRE QUE SE NECESITAN PARA TODO EL PAST DUE
                            'REQ * SEGUNDOS * OPERADORES
                            'REQ esta dividido entre la cantidad de turnos en los que corre el numero de parte para balancear las cantidades a producir por turno
                            Dim total_secondsmen As Integer = (From pp In ds_production_plan.Tables("CurrentProductionPlan")
                                                     Join m In ds_production_plan.Tables("Materials")
                                                     On pp.Field(Of String)("Material") Equals m.Field(Of String)("Material") And pp.Field(Of String)("Board") Equals m.Field(Of String)("Board")
                                                     Where m.Field(Of String)("Volume").ToLower = "low" And m.Field(Of String)("ShiftCombination").ToLower.Contains(shift.Item("Shift").ToString.ToLower) And pp.Field(Of Integer)(pd_column) < 0 AndAlso pp.Field(Of String)("Material") <> "Material"
                                                     Select New With {.Quantity = pp.Field(Of Integer)(pd_column) / m.Field(Of String)("ShiftCombination").Length, .Seconds = m.Field(Of Integer)("Seconds"), .Operators = m.Field(Of Int16)("Operators")}).Sum(Function(s) s.Quantity * s.Operators * s.Seconds)

                            'VALIDAR QUE AUN SE NECESITEN SEGUNDOS-HOMBRE PARA ACABAR CON EL PAST DUE
                            If total_secondsmen < 0 Then
                                'RECORRER TODOS LOS NUMEROS DE PLAN
                                For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                                    'VALIDAR QUE NO SEA UN RENGLON DE SUMATORIA
                                    If Not {"Material", "*"}.Contains(row.Item("Material")) Then
                                        'BUSCAR SI EXISTE CANTIDAD CONGELADA
                                        Dim frozen_qty = frozen_qtys.Rows.Find({row.Item("Material"), row.Item("Board"), CDate(column.ColumnName)})
                                        If frozen_qty IsNot Nothing Then
                                            row.Item(column.ColumnName) = frozen_qty.Item("Quantity")
                                            'BUSCAR INFORMACION DEL NUMERO DE PARTE
                                            Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                                            'DESCONTAR LOS SEGUNDOS-HOMBRE UTILIZADOS EN ESTA CANTIDAD
                                            total_secondsmen_available -= frozen_qty.Item("Quantity") * material.Item("Seconds") * material.Item("Operators")
                                            'ELIMINAR DEL REGISTRO DE CONGELADOS
                                            frozen_qtys.Rows.Remove(frozen_qty)
                                        Else
                                            'VALIDAR QUE AUN EXISTAN SEGUNDOS-HOMBRE DISPONIBLES EN EL TURNO ACTUAL, SINO SALIR DEL CICLO
                                            If total_secondsmen_available <= 0 Then Exit For
                                            'VALIDAR AUN TENGA PAST DUE
                                            If row.Item(pd_column) < 0 Then
                                                'TRAER INFORMACION DEL NUMERO DE PARTE ACTUAL
                                                Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                                                'VALIDAR QUE EL NUMERO DE PARTE SE CONTRUYA EN EL TURNO ACTUAL
                                                If material.Item("ShiftCombination").ToString.ToLower.Contains(shift.Item("Shift").ToString.ToLower) Then
                                                    'CALCULAR LA PENETRACION DEL NUMERO DE PARTE EN EL PAS DUE, PARA DAR PRIORIDAD EN BASE A LA CANTIDAD DE PAST DUE Y RECURSOS NECESARIOS
                                                    Dim penetration As Single = ((row.Item(pd_column) / material.Item("ShiftCombination").ToString.Length) * material.Item("Seconds") * material.Item("Operators")) / total_secondsmen
                                                    'DEFINIR LOS SEGUNDOS-HOMBRE QUE SE ASIGNARAN AL NUMERO DE PARTE EN EL TURNO
                                                    Dim segs_to_mfg As Single = shift.Item("ManufacturingSeconds") * available_headcount * penetration
                                                    'CALCULAR CUANTAS PIEZAS DEBERIAN PRODUCIR CON LOS SEGUNDOS-HOMBRES ASIGNADOS
                                                    Dim pieces As Single = segs_to_mfg / (material.Item("Seconds") * material.Item("Operators"))


                                                    'BUSCAR CANTIDAD PARCIALES "DISPONIBLES"
                                                    Dim row_dec As DataRow = dec_column.Rows.Find({row.Item("Material"), row.Item("Board")})
                                                    Dim rounded As Integer = 0
                                                    If row_dec Is Nothing Then
                                                        'CALCULAR LA PARTE ENTERA DE LA CANTIDAD A PRODUCIR
                                                        rounded = Math.Ceiling(pieces)

                                                        'VALIDAR SI EL USUARIO DESEA REDONDEAR A STDPACK
                                                        If options.RoundByStandarPack Then
                                                            rounded = Math.Ceiling(rounded / material.Item("StdPack")) * material.Item("StdPack")
                                                            'VALIDAR SI EXISTIRA STOCK POSITIVO Y SI EL USUARIO DESEA MANTENERLO
                                                            If Not options.AllowPositive AndAlso pieces > Math.Abs(row.Item(pd_column)) Then
                                                                rounded = Math.Abs(row.Item(pd_column))
                                                            End If
                                                        ElseIf rounded > Math.Abs(row.Item(pd_column)) Then 'SINO, VALIDAR QUE NO SE GENEREN POSITIVOS
                                                            rounded = Math.Abs(row.Item(pd_column))
                                                        End If

                                                        'GUARDAR LA PARTE DECIMAL PARA USARLA EN OTRO CICLO
                                                        'GUARDARA NEGATIVOS CUANDO ESTE REDONDEADO A STDPACK, LO CUAL AYUDARA A QUE NO SE PROGRAME OTRO STDPACK EN UN DIA PROXIMO
                                                        dec_column.Rows.Add(row.Item("Material"), row.Item("Board"), pieces - rounded)
                                                        'SUMAR LA NUEVA CANTIDAD DE PRODUCCION EN EL PLAN
                                                        row.Item(column.ColumnName) += rounded
                                                        'DESCONTAR LOS SEGUNDOS-HOMBRE QUE SE UTILIZARAN A LOS DISPONIBLES
                                                        total_secondsmen_available -= rounded * material.Item("Seconds") * material.Item("Operators")
                                                    Else
                                                        'SUMAR LA NUEVA CANTIDAD MAS LOS PARCIALES ACUMULADOS
                                                        row_dec.Item("Quantity") += pieces
                                                        'SI LOS PARCIALES YA REPRESENTAN AL MENOS 1 PIEZA
                                                        If row_dec.Item("Quantity") >= 1 Then
                                                            'CALCULAR LA PARTE ENTERA DE LA CANTIDAD A PRODUCIR
                                                            rounded = Math.Ceiling(row_dec.Item("Quantity"))
                                                            'VALIDAR SI EL USUARIO DESEA REDONDEAR A STDPACK
                                                            If options.RoundByStandarPack Then
                                                                rounded = Math.Ceiling(rounded / material.Item("StdPack")) * material.Item("StdPack")
                                                                'VALIDAR SI EXISTIRA STOCK POSITIVO Y SI EL USUARIO DESEA MANTENERLO
                                                                If Not options.AllowPositive AndAlso pieces > Math.Abs(row.Item(pd_column)) Then
                                                                    rounded = Math.Abs(row.Item(pd_column))
                                                                End If
                                                            ElseIf rounded > Math.Abs(row.Item(pd_column)) Then 'SINO, VALIDAR QUE NO SE GENEREN POSITIVOS
                                                                rounded = Math.Abs(row.Item(pd_column))
                                                            End If
                                                            'DESCONTAR LAS PIEZAS A PRODUCIR AL ACUMULADO DE PARCIALES
                                                            row_dec.Item("Quantity") -= rounded
                                                            'SUMAR LA NUEVA CANTIDAD DE PRODUCCION EN EL PLAN
                                                            row.Item(column.ColumnName) += rounded
                                                            'DESCONTAR LOS SEGUNDOS-HOMBRE QUE SE UTILIZARAN A LOS DISPONIBLES
                                                            total_secondsmen_available -= rounded * material.Item("Seconds") * material.Item("Operators")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If

                                Next
                            End If
                            For Each frozen As DataRow In frozen_qtys.Rows
                                Dim pp = ds_production_plan.Tables("CurrentproductionPlan").Rows.Find({frozen.Item("Material"), frozen.Item("Board")})
                                pp.Item(CDate(frozen.Item("Date")).ToString("MM/dd/yyyy")) = frozen.Item("Quantity")
                            Next
                        End If
                    Next
                End If
            Next
            stop_sum = False
            FormatGrid()
            LoadingScreen.Hide()
            changes_saved = False
        End If
        options.Dispose()
    End Sub

    Private Sub InitialDateButton_Click(sender As Object, e As EventArgs) Handles InitialDateButton.Click
        Dim cdr As New CalendarRange
        cdr.From = from_day
        cdr.To = to_day
        If cdr.ShowDialog = Windows.Forms.DialogResult.OK Then
            from_day = cdr.From
            to_day = cdr.To
            InitialDateButton.Text = String.Format("{0}-{1}", from_day.ToString("MM/dd/yy"), to_day.ToString("MM/dd/yy"))
            LoadProductionPlan()
        End If
        cdr.Dispose()
    End Sub

    Private Sub tsbtnPrev_Click(sender As Object, e As EventArgs)
        from_day = from_day.AddDays(-7)
        InitialDateButton.Text = from_day.ToShortDateString
        LoadProductionPlan()
    End Sub
    Private Sub tsbtnNext_Click(sender As Object, e As EventArgs)
        from_day = from_day.AddDays(7)
        InitialDateButton.Text = from_day.ToShortDateString
        LoadProductionPlan()
    End Sub
    Private Sub SumarizeByCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SumarizeByCombo.SelectedIndexChanged
        If Not IsNothing(ds_production_plan) Then
            Cursor.Current = Cursors.WaitCursor
            FormatGrid()
            If ShowCombo.SelectedItem = "Only Requirements" Then
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) <> 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) <> 0 Or Material IN ('Material','*'))"
            Else
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = ""
            End If
            Cursor.Current = Cursors.Arrow
        End If
        dgvProductionPlan.Focus()
    End Sub
    Private Sub PastDueCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PastDueCombo.SelectedIndexChanged
        If Not IsNothing(ds_production_plan) Then
            Cursor.Current = Cursors.WaitCursor
            FormatGrid()
            If ShowCombo.SelectedItem = "Only Requirements" Then
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) <> 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) <> 0 Or Material IN ('Material','*'))"
            Else
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = ""
            End If
            Cursor.Current = Cursors.Arrow
        End If
        dgvProductionPlan.Focus()
    End Sub
    Private Sub ChangeBusinessButton_Click(sender As Object, e As EventArgs) Handles ChangeBusinessButton.Click
        SelectBusiness()
    End Sub
#End Region
#Region "DataGridView"
    Private Sub dgvProductionPlan_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductionPlan.CellFormatting
        With dgvProductionPlan.Columns(e.ColumnIndex).HeaderText.Trim("<").Trim(">")
            If .Contains("Week") OrElse {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                If .Contains("Week") AndAlso {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                    e.CellStyle.BackColor = Color.FromArgb(67, 131, 163)
                Else
                    e.CellStyle.BackColor = Color.FromArgb(127, 191, 223)
                End If
                e.CellStyle.ForeColor = Color.White
            ElseIf .Contains("Past Due") Then
                If Not IsDBNull(e.Value) AndAlso e.Value > 0 Then
                    e.CellStyle.ForeColor = Color.Blue
                ElseIf Not IsDBNull(e.Value) AndAlso e.Value < 0 Then
                    e.CellStyle.ForeColor = Color.Red
                ElseIf Not IsDBNull(e.Value) Then
                    e.CellStyle.ForeColor = Color.LightGray
                End If
                e.CellStyle.BackColor = Color.Azure
            ElseIf .Contains("Grand Total") Then
                e.CellStyle.BackColor = Color.Black
                e.CellStyle.ForeColor = Color.White
            ElseIf Not {"Material", "Class", "Board", "Comment"}.Contains(.ToString) AndAlso Not .Contains("Past Due") AndAlso CDate(.Split(" ").GetValue(0).ToString.Trim("<")).Date <= DateAdd(DateInterval.Day, frozen_days, CurrentDate) Then
                e.CellStyle.BackColor = Color.WhiteSmoke
            End If

            If e.Value.ToString = "0" Then
                e.CellStyle.ForeColor = Color.Gray
            ElseIf Not .Contains("Material") AndAlso Not .Contains("Class") AndAlso Not .Contains("Board") AndAlso Not .Contains("Comment") AndAlso Not .Contains("Past Due") AndAlso Not .Contains("Week") AndAlso Not .Contains("Grand Total") AndAlso Not {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                e.CellStyle.Font = New Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold)
            End If
        End With

    End Sub
    Private Sub dgvProductionPlan_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvProductionPlan.DataError
        dgvProductionPlan.CancelEdit()
    End Sub
    Private Sub dgvProductionPlan_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductionPlan.SelectionChanged
        If dgvProductionPlan.SelectedCells.Count = 1 Then
            Dim cell As DataGridViewCell = dgvProductionPlan.SelectedCells.Item(0)
            If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(dgvProductionPlan.Columns(cell.ColumnIndex).Name) _
                AndAlso Not dgvProductionPlan.Columns(cell.ColumnIndex).Name.StartsWith("Week") _
                AndAlso Not dgvProductionPlan.Columns(cell.ColumnIndex).Name.StartsWith("PD_") Then

                Dim row As DataGridViewRow = dgvProductionPlan.Rows(cell.RowIndex)
                If Not {"Material", "*"}.Contains(row.Cells("Material").Value) Then
                    Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If material IsNot Nothing Then
                        lblCustomer.Text = material.Item("CustomerPN")
                        lblDescription.Text = material.Item("Description")
                        lblStdPack.Text = material.Item("StdPack")
                        lblFrom.Text = material.Item("StartProduction")
                        lblTo.Text = material.Item("EndProduction")
                        lblBusiness.Text = material.Item("Business")
                        lblBoardClass.Text = material.Item("Class")
                        lblVolume.Text = material.Item("Volume")
                        lblShift.Text = material.Item("ShiftCombination")
                    Else
                        lblCustomer.Text = "-"
                        lblDescription.Text = "-"
                        lblStdPack.Text = "-"
                        lblFrom.Text = "-"
                        lblTo.Text = "-"
                        lblBusiness.Text = "-"
                        lblBoardClass.Text = "-"
                        lblVolume.Text = "-"
                        lblShift.Text = "-"
                    End If


                    lblMaterial.Text = row.Cells("Material").Value
                    lblBoard.Text = row.Cells("Board").Value
                    lblPastdue.Text = If(row.Cells(cell.ColumnIndex + 1).Value > 0, String.Format("+{0}", row.Cells(cell.ColumnIndex + 1).Value), row.Cells(cell.ColumnIndex + 1).Value)
                    Dim schedule As DataRow = ds_production_plan.Tables("SumProductionPlan").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If schedule IsNot Nothing Then
                        lblSchedule.Text = CInt(schedule.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name))
                    Else
                        lblSchedule.Text = "-"
                    End If

                    Dim requirements As DataRow = ds_production_plan.Tables("Requirements").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If requirements IsNot Nothing Then
                        lblRequirements.Text = requirements.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name)
                    Else
                        lblRequirements.Text = "-"
                    End If
                    Dim avg_requirements As DataRow = ds_production_plan.Tables("AverageRequirements").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If avg_requirements IsNot Nothing Then
                        lblAvgRequirements.Text = avg_requirements.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name)
                    Else
                        lblAvgRequirements.Text = "-"
                    End If

                    Dim eps_production As DataRow = ds_production_plan.Tables("Production").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If eps_production IsNot Nothing Then
                        lblEPS.Text = eps_production.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name)
                    Else
                        lblEPS.Text = "-"
                    End If
                Else
                    ResetMaterialLabelData()
                End If
                dgvVL10.DataSource = SQL.Current.GetDatatable(String.Format("SELECT V.ShipTo,V.DeliveryDate AS [D.Date], dbo.DDC(F.Family, V.DeliveryDate, Mx.MaxDate) AS [P.P. Date],OpenQuantity AS Qty,CONVERT(BIT,CASE WHEN V.DeliveryDate < CONVERT(DATE,Mx.MaxDate) THEN 1 ELSE 0 END) AS [P.D.] " & _
                                                                        "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN " & _
                                                                        "Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_Families AS F ON B.Family = F.Family INNER JOIN " & _
                                                                        "(SELECT 'MxD' AS Flag,MAX(DownloadDate) AS MaxDate FROM dbo.Sch_VL10) AS Mx ON Mx.Flag = 'MxD' AND V.DownloadDate = Mx.MaxDate WHERE V.Material = '{0}' " & _
                                                                        "ORDER BY V.DeliveryDate", row.Cells("Material").Value))
            Else
                ResetMaterialLabelData()
                Dim row As DataGridViewRow = dgvProductionPlan.Rows(cell.RowIndex)
                lblMaterial.Text = row.Cells("Material").Value
                lblBoard.Text = row.Cells("Board").Value
                Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                If material IsNot Nothing Then
                    lblCustomer.Text = material.Item("CustomerPN")
                    lblDescription.Text = material.Item("Description")
                    lblStdPack.Text = material.Item("StdPack")
                    lblFrom.Text = material.Item("StartProduction")
                    lblTo.Text = material.Item("EndProduction")
                    lblBusiness.Text = material.Item("Business")
                    lblBoardClass.Text = material.Item("Class")
                    lblVolume.Text = material.Item("Volume")
                    lblShift.Text = material.Item("ShiftCombination")
                Else
                    lblCustomer.Text = "-"
                    lblDescription.Text = "-"
                    lblStdPack.Text = "-"
                    lblFrom.Text = "-"
                    lblTo.Text = "-"
                    lblBusiness.Text = "-"
                    lblBoardClass.Text = "-"
                    lblVolume.Text = "-"
                    lblShift.Text = "-"
                    lblEPS.Text = "-"
                End If

                dgvVL10.DataSource = SQL.Current.GetDatatable(String.Format("SELECT V.ShipTo,V.DeliveryDate AS [D.Date], dbo.DDC(F.Family, V.DeliveryDate, Mx.MaxDate) AS [P.P. Date],OpenQuantity AS Qty,CONVERT(BIT,CASE WHEN V.DeliveryDate < CONVERT(DATE,Mx.MaxDate) THEN 1 ELSE 0 END) AS [P.D.] " & _
                                                                        "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN " & _
                                                                        "Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_Families AS F ON B.Family = F.Family INNER JOIN " & _
                                                                        "(SELECT 'MxD' AS Flag,MAX(DownloadDate) AS MaxDate FROM dbo.Sch_VL10) AS Mx ON Mx.Flag = 'MxD' AND V.DownloadDate = Mx.MaxDate WHERE V.Material = '{0}' " & _
                                                                        "ORDER BY V.DeliveryDate", row.Cells("Material").Value))
            End If
            lblSelection.Text = ""

        Else
            ResetMaterialLabelData()
            Dim sum As Single = 0
            Dim counter As Integer = 0
            For Each c As DataGridViewCell In dgvProductionPlan.SelectedCells
                If IsNumeric(c.Value) Then
                    sum += c.Value
                    counter += 1
                End If
            Next
            dgvVL10.DataSource = Nothing
            lblSelection.Text = String.Format("Sum: {0}   Avg: {1}   Count: {2}", sum, Math.Round(sum / counter, 3), counter)
        End If
    End Sub
    Private Sub ResetMaterialLabelData()
        lblMaterial.Text = "-"
        lblBoard.Text = "-"
        lblCustomer.Text = "-"
        lblPastdue.Text = "-"
        lblSchedule.Text = "-"
        lblDescription.Text = "-"
        lblStdPack.Text = "-"
        lblFrom.Text = "-"
        lblTo.Text = "-"
        lblBusiness.Text = "-"
        lblRequirements.Text = "-"
        lblAvgRequirements.Text = "-"
        lblBusiness.Text = "-"
        lblStdPack.Text = "-"
        lblBoardClass.Text = "-"
        lblVolume.Text = "-"
        lblShift.Text = "-"
        lblEPS.Text = "-"
    End Sub
#End Region
#Region "ComboBox FamilyBusiness"
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        LoadingScreen.Show()
        LoadProductionPlan()
        LoadingScreen.Hide()
    End Sub
#End Region
#Region "Functions"

    Private Sub ProductionPlan_Changed(sender As Object, e As DataColumnChangeEventArgs)
        If Not {"Material", "Class", "Board", "Comment"}.Contains(e.Column.ColumnName) AndAlso Not e.Row.Item("Material") = "*" Then
            changes_saved = False
            Dim total As Integer = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("Sum([{0}])", e.Column.ColumnName), String.Format("Material = '{0}'", e.Row.Item("Material")))
            Dim sumpp_rows() As Data.DataRow
            sumpp_rows = ds_production_plan.Tables("SumProductionPlan").Select(String.Format("Material = '{0}'", e.Row.Item("Material")))
            For i = 0 To sumpp_rows.Length - 1
                sumpp_rows(i).Item(e.Column.ColumnName) = total
            Next

            If Not stop_sum Then
                If SumarizeByCombo.SelectedItem.ToString.Contains("Day") Then
                    Dim gt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Grand Total"})
                    If gt IsNot Nothing Then
                        gt.Item(e.Column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", e.Column.ColumnName), "[Material] <> '*'")
                    Else
                        Dim ngt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
                        ngt.Item("Material") = "*"
                        ngt.Item("Class") = "*"
                        ngt.Item("Board") = "*Grand Total"
                        ngt.Item(e.Column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", e.Column.ColumnName), "[Material] <> '*'")
                        ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(ngt)
                    End If
                End If

                Select Case SumarizeByCombo.SelectedItem
                    Case "Class"
                        Dim st As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Sum " & e.Row.Item("Class")})
                        If st IsNot Nothing Then
                            st.Item(e.Column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", e.Column.ColumnName), String.Format("[Material] <> '*' AND [Class] = '{0}'", e.Row.Item("Class")))
                        Else
                            Dim nst As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
                            nst.Item("Material") = "*"
                            nst.Item("Class") = e.Row.Item("Class")
                            nst.Item("Board") = "*Sum " & e.Row.Item("Class")
                            nst.Item(e.Column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", e.Column.ColumnName), String.Format("[Material] <> '*' AND [Class] = '{0}'", e.Row.Item("Class")))
                            ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(nst)
                        End If
                    Case "Capacity Usage"
                        Dim st As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Total Cap. Use"})
                        If st IsNot Nothing Then
                            Dim ds As New DataSet()
                            ds.Tables.Add(New DataView(ds_production_plan.Tables("CurrentProductionPlan"), String.Format("Material <> '*'", e.Column.ColumnName), "", DataViewRowState.CurrentRows).ToTable("ProductionPlan", False, "Material", "Board", e.Column.ColumnName))
                            ds.Tables.Add(New DataView(ds_production_plan.Tables("Materials"), "", "", DataViewRowState.CurrentRows).ToTable("Materials", False, "Material", "Board", "Operators", "Seconds"))
                            ds.Relations.Add(New DataRelation("PPM", {ds.Tables("ProductionPlan").Columns("Material"), ds.Tables("ProductionPlan").Columns("Board")}, {ds.Tables("Materials").Columns("Material"), ds.Tables("Materials").Columns("Board")}))
                            ds.Tables("ProductionPlan").Columns.Add("Use", GetType(Integer), String.Format("AVG(Child(PPM).[Seconds]) * AVG(Child(PPM).[Operators]) * [{0}]", e.Column.ColumnName))

                            Dim total_capacity As Integer = DailyCapacity(e.Column.ColumnName)
                            If total_capacity > 0 Then
                                st.Item(e.Column.ColumnName) = Math.Round((ds.Tables("ProductionPlan").Compute(String.Format("SUM([{0}])", "Use"), "") / total_capacity) * 100, 0)
                            ElseIf Not IsDBNull(st.Item(e.Column.ColumnName)) Then
                                st.Item(e.Column.ColumnName) = DBNull.Value
                            End If
                        End If
                    Case "Capacity Usage,Class"
                        Dim st As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Cap. Use " & e.Row.Item("Class")})
                        If st IsNot Nothing Then
                            Dim ds As New DataSet()
                            ds.Tables.Add(New DataView(ds_production_plan.Tables("CurrentProductionPlan"), String.Format("[Class] = '{0}' AND Material <> '*'", e.Row.Item("Class")), "", DataViewRowState.CurrentRows).ToTable("ProductionPlan", False, "Material", "Board", e.Column.ColumnName))
                            ds.Tables.Add(New DataView(ds_production_plan.Tables("Materials"), String.Format("[Class] = '{0}'", e.Row.Item("Class")), "", DataViewRowState.CurrentRows).ToTable("Materials", False, "Material", "Board", "Operators", "Seconds"))
                            ds.Relations.Add(New DataRelation("PPM", {ds.Tables("ProductionPlan").Columns("Material"), ds.Tables("ProductionPlan").Columns("Board")}, {ds.Tables("Materials").Columns("Material"), ds.Tables("Materials").Columns("Board")}))
                            ds.Tables("ProductionPlan").Columns.Add("Use", GetType(Integer), String.Format("AVG(Child(PPM).[Seconds]) * AVG(Child(PPM).[Operators]) * [{0}]", e.Column.ColumnName))

                            Dim total_capacity As Integer = DailyCapacity(e.Column.ColumnName)
                            If total_capacity > 0 Then
                                st.Item(e.Column.ColumnName) = Math.Round((ds.Tables("ProductionPlan").Compute(String.Format("SUM([{0}])", "Use"), "") / total_capacity) * 100, 0)
                            ElseIf Not IsDBNull(st.Item(e.Column.ColumnName)) Then
                                st.Item(e.Column.ColumnName) = DBNull.Value
                            End If
                        End If
                End Select
            End If
        ElseIf e.Column.ColumnName = "Comment" Then
            changes_saved = False
        End If
    End Sub

    Private Sub LoadProductionPlan()
        dgvProductionPlan.EndEdit()
        If Not changes_saved Then
            Select Case MessageBox.Show("Save changes before refresh?", "Changes not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case Windows.Forms.DialogResult.Yes
                    Save()
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        If Not selected_family = "" Then
            LoadingScreen.Show()
            Cursor.Current = Cursors.WaitCursor
            dgvProductionPlan.DataSource = Nothing
            dgvProductionPlan.Columns.Clear()
            Application.DoEvents()
            'OBTENER LA ULTIMA FECHA DE DESCARGA DE LA VL10
            sap_update = SQL.Current.MyDate(SQL.Current.GetString("SELECT MAX(DownloadDate) FROM Sch_VL10;", Now.ToShortDateString))

            'CARGAR PLAN DE PRODUCCION SEGUN LAS FECHAS Y NEGOCIOS SELECCIONADOS, ESTA TABLA TAMBIEN SE GUARDA INTEGRA PARA DESPUES COMPARAR SI HUBO CAMBIOS EN EL PLAN DEL USUARIO Y ALMACENARLOS EN LA BASE DE DATOS
            original_pp_pivot = GetProductionPlan(from_day, to_day, selected_business, selected_family)
            'CLONAR INFO DEL PLAN, ESTA COPIA SE UTILIZA PARA SUMAR EL MISMO NUMERO DE PARTE EN DIFERENTES TABLEROS
            Dim sum_pp As DataTable = original_pp_pivot.Copy()
            sum_pp.PrimaryKey = {sum_pp.Columns("Material"), sum_pp.Columns("Board")}
            sum_pp.TableName = "SumProductionPlan"


            'VACIAR EL PLAN ORIGINAL A UNA NUEVA TABLA, ESTA TABLA SERA LA QUE EL USUARIO PODRA EDITAR
            Dim production_plan As New DataTable("CurrentProductionPlan")
            production_plan.Columns.Add("Material", GetType(String))
            production_plan.Columns.Add("Class", GetType(String))
            production_plan.Columns.Add("Board", GetType(String))
            production_plan.PrimaryKey = {production_plan.Columns("Material"), production_plan.Columns("Board")}
            production_plan.Merge(original_pp_pivot.DefaultView.ToTable(False, "Material", "Class", "Board"))

            'DECLARAR EL DATASET MAESTRO, AQUI SE ALMACENARAN TODAS LAS TABLAS PARA PODER HACER RELATIONS
            ds_production_plan = New DataSet
            ds_production_plan.Tables.Add(production_plan) 'Plan de producccion para el usuario
            ds_production_plan.Tables.Add(sum_pp) 'Plan de producción sumado para numeros de parte en varios tableros
            ds_production_plan.Tables.Add(GetMaterialWithPastDueAndStock(from_day, to_day, selected_business, selected_family)) 'TABLA CON LOS NUMEROS DE PARTE,TABLERO,DESCRIPCION,STDPACK,PASTDUE,ETC
            'ds_production_plan.Tables.Add(GetCapacities(from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family))
            ds_production_plan.Tables.Add(GetProduction(from_day, to_day, selected_business, selected_family)) 'OBTENER LA PRODUCCION DE EPS
            ds_production_plan.Tables.Add(GetRequirements(True, from_day, to_day, selected_business, selected_family, False, False)) 'REQUERIMIENTOS DIARIOS
            ds_production_plan.Tables.Add(GetRequirements(False, from_day, to_day, selected_business, selected_family, False, False)) 'REQUERIMIENTOS PROMEDIADOS POR SEMANA
            ds_production_plan.Tables.Add(GetWorkingShifts(from_day, to_day)) 'TURNOS A TRABAR POR FECHA
            ds_production_plan.Tables.Add(GetLastWksRequeriments(selected_business, selected_family)) 'REQUERIMIENTOS DE LA VL10 PASADA


            '*********************** RELATIONS *******************************************************************************************************************************************
            ds_production_plan.Relations.Add(New DataRelation("PPMaterials", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Materials").Columns("Material"), ds_production_plan.Tables("Materials").Columns("Board")}, True))
            'ds_production_plan.Relations.Add(New DataRelation("PPCapacities", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Capacities").Columns("Material"), ds_production_plan.Tables("Capacities").Columns("Board")}, True))
            ds_production_plan.Relations.Add(New DataRelation("PPEPSProduction", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Production").Columns("Material"), ds_production_plan.Tables("Production").Columns("Board")}, True))
            ds_production_plan.Relations.Add(New DataRelation("PPRequirements", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Requirements").Columns("Material"), ds_production_plan.Tables("Requirements").Columns("Board")}, True))
            ds_production_plan.Relations.Add(New DataRelation("PPAvgRequirements", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("AverageRequirements").Columns("Material"), ds_production_plan.Tables("AverageRequirements").Columns("Board")}, True))
            ds_production_plan.Relations.Add(New DataRelation("PPSumPP", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("SumProductionPlan").Columns("Material"), ds_production_plan.Tables("SumProductionPlan").Columns("Board")}, True))

            '*****************************************************************************************************************************************************************************

            Dim last_pd_column As String = ""
            Dim total_expression As String = ""
            Dim week_expression As String = ""
            Dim last_week As Integer = 0
            For Each col As DataColumn In original_pp_pivot.Columns
                Select Case col.ColumnName
                    Case "Material", "Class", "Board"

                    Case Else
                        Dim new_col As New DataColumn
                        new_col.ColumnName = col.ColumnName
                        new_col.DataType = col.DataType
                        total_expression &= String.Format("[{0}]+", col.ColumnName)

                        Dim new_pd As New DataColumn
                        new_pd.ColumnName = "PD_" & col.ColumnName
                        new_pd.DataType = GetType(Integer)

                        If last_pd_column = "" Then
                            If CDate(col.ColumnName).Date >= sap_update.Date Then
                                If CDate(col.ColumnName).Date = sap_update.Date Then
                                    If CDate(col.ColumnName).Date >= CurrentDate.Date Then
                                        new_pd.Expression = String.Format("Convert(Avg(Child(PPSumPP).[{0}]),'System.Int32') + ISNULL(Avg(Child(PPMaterials).Stock),0) - ISNULL(Avg(Child(PPRequirements).[{0}]),0) - ISNULL(Avg(Child(PPMaterials).PastDue),0)", col.ColumnName) ' PP + Stock - Req - PastDue 
                                    Else
                                        new_pd.Expression = String.Format("ISNULL(Avg(Child(PPEPSProduction).[{0}]),0) + ISNULL(Avg(Child(PPMaterials).Stock),0) - ISNULL(Avg(Child(PPRequirements).[{0}]),0) - ISNULL(Avg(Child(PPMaterials).PastDue),0)", col.ColumnName) ' PP + Stock - Req - PastDue 
                                    End If
                                Else
                                    If CDate(col.ColumnName).Date >= CurrentDate.Date Then
                                        new_pd.Expression = String.Format("Convert(Avg(Child(PPSumPP).[{0}]),'System.Int32') - ISNULL(Avg(Child(PPRequirements).[{0}]),0) - ISNULL(Avg(Child(PPMaterials).PastDue),0)", col.ColumnName) 'PP - Req - PastDue 
                                    Else
                                        new_pd.Expression = String.Format("ISNULL(Avg(Child(PPEPSProduction).[{0}]),0) - ISNULL(Avg(Child(PPRequirements).[{0}]),0) - ISNULL(Avg(Child(PPMaterials).PastDue),0)", col.ColumnName) 'PP - Req - PastDue 
                                    End If
                                End If
                                last_pd_column = "PD_" & col.ColumnName
                            ElseIf CDate(col.ColumnName).Date = sap_update.AddDays(-1).Date Then
                                new_pd.Expression = "-ISNULL(Avg(Child(PPMaterials).PastDue),0)"
                            Else
                                new_pd.Expression = "0"
                            End If
                        Else
                            If CDate(col.ColumnName).Date >= CurrentDate.Date Then
                                new_pd.Expression = String.Format("Convert(Avg(Child(PPSumPP).[{0}]),'System.Int32') - ISNULL(Avg(Child(PPRequirements).[{0}]),0) + [{1}]", col.ColumnName, last_pd_column) ' PP - Req - LastPastDue
                            Else
                                new_pd.Expression = String.Format("ISNULL(Avg(Child(PPEPSProduction).[{0}]),0) - ISNULL(Avg(Child(PPRequirements).[{0}]),0) + [{1}]", col.ColumnName, last_pd_column) ' EPS - Req - LastPastDue
                            End If
                            last_pd_column = "PD_" & col.ColumnName
                        End If

                        If last_week = 0 Then
                            last_week = DatePart(DateInterval.WeekOfYear, CDate(col.ColumnName).Date)
                            week_expression = String.Format("[{0}]+", col.ColumnName)
                        ElseIf last_week = DatePart(DateInterval.WeekOfYear, CDate(col.ColumnName).Date) Then
                            week_expression &= String.Format("[{0}]+", col.ColumnName)
                        Else
                            Dim week_col As New DataColumn
                            week_col.DataType = GetType(UInt32)
                            week_col.ColumnName = "Week " & last_week
                            week_col.Expression = week_expression.Trim("+")
                            ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(week_col)

                            Dim reqs_week_col As New DataColumn
                            reqs_week_col.DataType = GetType(UInt32)
                            reqs_week_col.ColumnName = "Week " & last_week
                            reqs_week_col.Expression = week_expression.Trim("+")
                            ds_production_plan.Tables("Requirements").Columns.Add(reqs_week_col)

                            last_week = DatePart(DateInterval.WeekOfYear, CDate(col.ColumnName).Date)
                            week_expression = String.Format("[{0}]+", col.ColumnName)
                        End If
                        ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(new_col)
                        If Not new_pd.Expression = "0" Then ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(new_pd)
                End Select
            Next
            Dim last_week_col As New DataColumn
            last_week_col.DataType = GetType(UInt32)
            last_week_col.ColumnName = "Week " & last_week
            last_week_col.Expression = week_expression.Trim("+")
            ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(last_week_col)

            Dim reqs_last_week_col As New DataColumn
            reqs_last_week_col.DataType = GetType(UInt32)
            reqs_last_week_col.ColumnName = "Week " & last_week
            reqs_last_week_col.Expression = week_expression.Trim("+")
            ds_production_plan.Tables("Requirements").Columns.Add(reqs_last_week_col)

            Dim col_total As New DataColumn
            col_total.ColumnName = "Grand Total"
            col_total.DataType = GetType(Integer)
            col_total.Expression = total_expression.Trim("+")
            ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(col_total)

            GetMaterialsComments(from_day, to_day, selected_business, selected_family)
            ds_production_plan.Tables("CurrentProductionPlan").Merge(original_pp_comments)
            ds_production_plan.Tables("CurrentProductionPlan").Merge(original_pp_pivot)

            frozen_days = Parameter("SCH_FrozenDays", 0)
            SetProductionPlanDatasource()
            LoadingScreen.Hide()
        End If

        Cursor.Current = Cursors.Arrow
    End Sub
    Private Sub SetProductionPlanDatasource()
        AddHandler ds_production_plan.Tables("CurrentProductionPlan").ColumnChanged, New DataColumnChangeEventHandler(AddressOf ProductionPlan_Changed)
        'AddHandler ds_production_plan.Tables("CurrentProductionPlan").RowChanged, New DataRowChangeEventHandler(AddressOf z)
        For Each col As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
            Dim grid_column As New DataGridViewTextBoxColumn
            grid_column.DataPropertyName = col.ColumnName
            grid_column.Name = col.ColumnName
            grid_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If col.ColumnName.StartsWith("PD_") Then
                grid_column.HeaderText = "Past Due"
                grid_column.Width = 40
                grid_column.Visible = False
            ElseIf col.ColumnName.StartsWith("Week") Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 40
                grid_column.Visible = False
            ElseIf col.ColumnName = "Material" Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 70
                grid_column.ReadOnly = True
                grid_column.Frozen = True
            ElseIf col.ColumnName = "Class" Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 70
                grid_column.ReadOnly = True
                grid_column.Frozen = True
            ElseIf col.ColumnName = "Board" Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 100
                grid_column.ReadOnly = True
                grid_column.Frozen = True
            ElseIf col.ColumnName = "Grand Total" Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 70
                grid_column.Visible = False
            ElseIf col.ColumnName = "Comment" Then
                grid_column.HeaderText = col.ColumnName
                grid_column.Width = 120
            Else
                grid_column.HeaderText = String.Format("{0} {1}", col.ColumnName, CDate(col.ColumnName).ToString("dddd"))
                grid_column.Width = 70
                If DateDiff(DateInterval.Day, CurrentDate.Date, CDate(col.ColumnName).Date) <= frozen_days Then
                    grid_column.ReadOnly = True
                End If
            End If
            grid_column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvProductionPlan.Columns.Add(grid_column)
        Next
        If ShowCombo.SelectedItem = "Only Requirements" Then
            ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) <> 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) <> 0 Or Material IN ('Material','*'))"
        End If
        dgvProductionPlan.DataSource = ds_production_plan.Tables("CurrentProductionPlan").DefaultView
        FormatGrid()
    End Sub
    Private Function GetMaterialWithPastDueAndStock([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim materials As DataTable
        Dim query As String = ""
        If selected_business = "" Then
            query = String.Format(My.Resources.PP_MaterialsByFamily, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "High")
        Else
            query = String.Format(My.Resources.PP_MaterialsByBusiness, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "High")
        End If
        materials = SQL.Current.GetDatatable(query)
        materials.PrimaryKey = {materials.Columns("Material"), materials.Columns("Board")}
        materials.TableName = "Materials"
        Return materials
    End Function
    Private Function GetRequirements(average As Boolean, [from] As Date, [to] As Date, selected_business As String, selected_family As String, saturdays As Boolean, sundays As Boolean) As DataTable
        Dim requirements As DataTable
        If average Then
            Dim divider As Integer = 5
            Dim wkd1 As Integer = 7 'Saturdays Weekday 
            Dim wkd2 As Integer = 1 'Sundays Weekday
            If saturdays Then
                divider += 1
                wkd1 = 8 'Nunca se cumple, por lo tanto los toma en cuenta
            End If
            If sundays Then
                divider += 1
                wkd2 = 8 'Nunca se cumple, por lo tanto los toma en cuenta
            End If
            If selected_business = "" Then
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_AverageRequirementsByFamily, wkd1, wkd2, divider, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "High"))
            Else
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_AverageRequirementsByBusiness, wkd1, wkd2, divider, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "High"))
            End If

        Else
            If selected_business = "" Then
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_RequirementsByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "High"))
            Else

                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_RequirementsByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "High"))
            End If
        End If

        Dim req_pivoter As New PivotTable(requirements)
        Dim req_pivot As DataTable = req_pivoter.PivotDates("Material", "Board", "OpenQuantity", AggregateFunction.Sum, "DeliveryDate", "System.Int32")
        req_pivot.PrimaryKey = {req_pivot.Columns("Material"), req_pivot.Columns("Board")}
        Dim exp As String = ""
        For Each col As DataColumn In req_pivot.Columns
            If Not {"Material", "Board"}.Contains(col.ColumnName) Then
                exp &= String.Format("[{0}]+", col.ColumnName)
            End If
        Next
        exp = exp.Trim("+")
        req_pivot.Columns.Add("Total", GetType(Integer), exp)
        If average Then
            req_pivot.TableName = "AverageRequirements"
        Else
            req_pivot.TableName = "Requirements"
        End If
        Return req_pivot
    End Function

    Private Function GetProduction([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim production As DataTable
        If selected_business = "" Then
            production = SQL.Current.GetDatatable(String.Format(My.Resources.PP_EPSProductionByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "High"))
        Else

            production = SQL.Current.GetDatatable(String.Format(My.Resources.PP_EPSProductionByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "High"))
        End If

        Dim prod_pivoter As New PivotTable(production)
        Dim prod_pivot As DataTable = prod_pivoter.PivotDates("Material", "Board", "Quantity", AggregateFunction.Sum, "Date", "System.Int32")
        prod_pivot.PrimaryKey = {prod_pivot.Columns("Material"), prod_pivot.Columns("Board")}
        'Dim exp As String = ""
        'For Each col As DataColumn In prod_pivot.Columns
        '    If Not {"Material", "Board"}.Contains(col.ColumnName) Then
        '        exp &= String.Format("[{0}]+", col.ColumnName)
        '    End If
        'Next
        'exp = exp.Trim("+")
        'prod_pivot.Columns.Add("Total", GetType(Integer), exp)
        prod_pivot.TableName = "Production"
        Return prod_pivot
    End Function

    'Private Function GetCapacities([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
    '    Dim capacity As DataTable
    '    If selected_business = "" Then
    '        capacity = SQL.Current.GetDatatable(String.Format(My.Resources.PP_BoardCapacitiesByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
    '    Else
    '        capacity = SQL.Current.GetDatatable(String.Format(My.Resources.PP_BoardCapacitiesByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
    '    End If
    '    capacity.Columns.Add("Capacity", GetType(Single))
    '    Dim shifts As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sys_Shifts")
    '    shifts.PrimaryKey = {shifts.Columns("Shift")}
    '    Dim seconds As Integer
    '    For Each row As DataRow In capacity.Rows
    '        seconds = 0
    '        For Each shift In row.Item("BoardShifts").ToString.ToCharArray
    '            If row.Item("DayShifts").ToString.ToUpper.Contains(shift.ToString.ToUpper) Then seconds += shifts.Compute("SUM([ManufacturingSeconds])", String.Format("[Shift]='{0}'", shift))
    '        Next
    '        row.Item("Capacity") = Math.Round(seconds / row.Item("Seconds"), 2)
    '    Next
    '    Dim cap_pivoter As New PivotTable(capacity)
    '    Dim cap_pivot As DataTable = cap_pivoter.PivotDates("Material", "Board", "Capacity", AggregateFunction.First, "Date", "System.Single")
    '    cap_pivot.PrimaryKey = {cap_pivot.Columns("Material"), cap_pivot.Columns("Board")}
    '    cap_pivot.TableName = "Capacities"
    '    Return cap_pivot
    'End Function
    Private Function GetWorkingShifts([from] As Date, [to] As Date) As DataTable
        Dim dates As DataTable = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(VARCHAR(10),[Date],101) AS [Date],ISNULL([WorkingShifts],'') AS WorkingShifts FROM Sys_Calendar WHERE [Date] BETWEEN '{0}' AND '{1}'", [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd")), "WorkingShifts")
        dates.PrimaryKey = {dates.Columns("Date")}
        Return dates
    End Function
    Private Function GetProductionPlan([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim pp_table As DataTable
        If selected_business = "" Then
            pp_table = SQL.Current.GetDatatable(String.Format(My.Resources.PP_ByFamily, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "High"))
        Else
            pp_table = SQL.Current.GetDatatable(String.Format(My.Resources.PP_ByBusiness, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "High"))
        End If
        Dim pp_pivoter As New PivotTable(pp_table)
        Dim pp_pivot = pp_pivoter.PivotDates("Material", "Class", "Board", "Quantity", AggregateFunction.First, "Date", "System.UInt32")
        pp_pivot.PrimaryKey = {pp_pivot.Columns("Material"), pp_pivot.Columns("Board")}
        pp_pivot.TableName = "ProductionPlan"
        Return pp_pivot
    End Function
    Private Sub GetMaterialsComments([from] As Date, [to] As Date, selected_business As String, selected_family As String)
        If selected_business = "" Then
            original_pp_comments = SQL.Current.GetDatatable(String.Format(My.Resources.PP_CommentsByFamily, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
        Else
            original_pp_comments = SQL.Current.GetDatatable(String.Format(My.Resources.PP_CommentsByBusiness, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
        End If
        original_pp_comments.PrimaryKey = {original_pp_comments.Columns("Material"), original_pp_comments.Columns("Board")}
        original_pp_comments.TableName = "Comments"
    End Sub
    Private Function GetLastWksRequeriments(selected_business As String, selected_family As String) As DataTable
        Dim last_week_full As Date = SQL.Current.GetDate(String.Format("SELECT MAX(DownloadDate) FROM Sch_VL10 WHERE Convert(DATE,DownloadDate) BETWEEN '{0}' AND '{1}';", sap_update.AddDays(-6 - Weekday(sap_update)).ToString("yyyy-MM-dd"), sap_update.AddDays(-Weekday(sap_update)).ToString("yyyy-MM-dd"))) 'domingo y sabado de la semana pasada
        Dim from_date As Date = sap_update.AddDays(1 - Weekday(sap_update)) 'domingo de la semana actual
        Dim to_date As Date = sap_update.AddDays(35 - Weekday(sap_update)) 'sabado de la quinta semana, por lo tanto solo carga 5 semanas para no ralentizar el programa
        If to_date.Date > to_day.Date Then to_date = to_day
        If selected_business = "" Then
            Return SQL.Current.GetDatatable(String.Format("SELECT V.[Material],CONVERT(VARCHAR(10),dbo.DDC(F.Family,DeliveryDate,'{1}'),120) AS [Date],SUM(OpenQuantity) AS Quantity " & _
                                                                               "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business INNER JOIN " & _
                                                                               "Sch_Families AS F ON B.Family = F.Family WHERE DeliveryDate >= '{1}' AND DownloadDate = '{0}' AND F.Family = '{4}' AND dbo.DDC(F.Family,DeliveryDate,'{1}') BETWEEN '{2}' AND '{3}' " & _
                                                                               "GROUP BY V.Material,dbo.DDC(F.Family,DeliveryDate,'{1}')", last_week_full.ToString("yyyy-MM-dd hh:mm:ss.fff"), last_week_full.ToString("yyyy-MM-dd"), from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd"), selected_family), "VL10LastWeek")
        Else
            Return SQL.Current.GetDatatable(String.Format("SELECT V.[Material],CONVERT(VARCHAR(10),dbo.DDC(F.Family,DeliveryDate,'{1}'),120) AS [Date],SUM(OpenQuantity) AS Quantity " & _
                                                                               "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business INNER JOIN " & _
                                                                               "Sch_Families AS F ON B.Family = F.Family WHERE DeliveryDate >= '{1}' AND DownloadDate = '{0}' AND F.Family = '{4}' AND B.Business = '{5}' AND dbo.DDC(F.Family,DeliveryDate,'{1}') BETWEEN '{2}' AND '{3}' " & _
                                                                               "GROUP BY V.Material,dbo.DDC(F.Family,DeliveryDate,'{1}')", last_week_full.ToString("yyyy-MM-dd hh:mm:ss.fff"), last_week_full.ToString("yyyy-MM-dd"), from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd"), selected_family, selected_business), "VL10LastWeek")
        End If
    End Function
    Private Sub FormatGrid()

        Dim sub_rows() As Data.DataRow
        sub_rows = ds_production_plan.Tables("CurrentProductionPlan").Select("Board = '*Grand Total' OR Board LIKE '[*]Sum%' OR Board LIKE '[*]Cap. Use%' OR Board = '*Total Cap. Use'")
        For i = sub_rows.Length - 1 To 0 Step -1
            sub_rows(i).Delete()
        Next

        Select Case SumarizeByCombo.SelectedItem
            Case "Day", "Day,Week", "Day,Material", "Day,Week,Material"
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class DESC,Board DESC,Material ASC"
                SumarizeByDay()
            Case "Class", "Class,Week"
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class ASC,Board DESC,Material ASC"
                SumarizeByClass()
            Case "Capacity Usage"
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class DESC,Board DESC,Material ASC"
                SumarizeByCapacity()
            Case "Capacity Usage,Class"
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class ASC,Board DESC,Material ASC"
                SumarizeByClassCapacity()
        End Select

        For Each row As DataGridViewRow In dgvProductionPlan.Rows
            If {"Material", "*"}.Contains(row.Cells("Material").Value) Then
                row.ReadOnly = True
            Else
                Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                If material IsNot Nothing Then
                    For Each column As DataGridViewColumn In dgvProductionPlan.Columns
                        If Not {"Material", "Board", "Class", "Comment", "Grand Total"}.Contains(column.Name) AndAlso Not column.Name.StartsWith("Week") AndAlso Not column.Name.StartsWith("PD_") Then
                            If CDate(column.Name).Date < material.Item("StartProduction") OrElse CDate(column.Name).Date > material.Item("EndProduction") Then
                                row.Cells(column.Name).ReadOnly = True
                                row.Cells(column.Name).Style.BackColor = Color.LightGray
                            End If
                        End If
                    Next
                End If
            End If
        Next

        For Each column As DataGridViewColumn In dgvProductionPlan.Columns
            If column.HeaderText = "Past Due" Then
                Select Case PastDueCombo.SelectedItem
                    Case "None"
                        column.Visible = False
                    Case "Daily"
                        column.Visible = True
                    Case "Weekly"
                        If column.Index < dgvProductionPlan.Columns.Count - 2 AndAlso dgvProductionPlan.Columns(column.Index + 1).HeaderText.StartsWith("Week") Then
                            column.Visible = True
                        Else
                            column.Visible = False
                        End If
                End Select
            ElseIf column.HeaderText.StartsWith("Week") Then
                If SumarizeByCombo.SelectedItem.ToString.Contains("Week") Then
                    column.Visible = True
                Else
                    column.Visible = False
                End If
            ElseIf column.HeaderText = "Grand Total" Then
                If SumarizeByCombo.SelectedItem.ToString.Contains("Material") Then
                    column.Visible = True
                Else
                    column.Visible = False
                End If
            ElseIf column.HeaderText = "Material" OrElse column.HeaderText = "Class" OrElse column.HeaderText = "Board" OrElse column.HeaderText = "Comment" Then
                column.Visible = True
            Else
                column.Visible = True
            End If
        Next
        dgvProductionPlan.Refresh()
    End Sub
    Private Sub SumarizeByDay()
        Dim ngt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
        ngt.Item("Material") = "*"
        ngt.Item("Class") = "*"
        ngt.Item("Board") = "*Grand Total"
        For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
            If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                ngt.Item(column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", column.ColumnName), "[Material] <> '*'")
            End If
        Next
        ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(ngt)
    End Sub
    Private Sub SumarizeByClass()
        Dim classes As DataTable = ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable(True, "Class")
        For Each c As DataRow In classes.Rows
            Dim nst As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
            nst.Item("Material") = "*"
            nst.Item("Class") = c.Item("Class")
            nst.Item("Board") = "*Sum " & c.Item("Class")
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    nst.Item(column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", column.ColumnName), String.Format("[Class] = '{0}'", c.Item("Class")))
                End If
            Next
            ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(nst)
        Next
    End Sub

    Private Sub SumarizeByClassCapacity()
        Dim total_capacity As Integer

        Dim classes As DataTable = ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable(True, "Class")
        For Each c As DataRow In classes.Rows
            Dim nst As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
            nst.Item("Material") = "*"
            nst.Item("Class") = c.Item("Class")
            nst.Item("Board") = "*Cap. Use " & c.Item("Class")
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    Dim ds As New DataSet()
                    ds.Tables.Add(New DataView(ds_production_plan.Tables("CurrentProductionPlan"), String.Format("[Class] = '{0}' AND Material <> '*'", c.Item("Class")), "", DataViewRowState.CurrentRows).ToTable("ProductionPlan", False, "Material", "Board", column.ColumnName))
                    ds.Tables.Add(New DataView(ds_production_plan.Tables("Materials"), String.Format("[Class] = '{0}'", c.Item("Class")), "", DataViewRowState.CurrentRows).ToTable("Materials", False, "Material", "Board", "Operators", "Seconds"))
                    ds.Relations.Add(New DataRelation("PPM", {ds.Tables("ProductionPlan").Columns("Material"), ds.Tables("ProductionPlan").Columns("Board")}, {ds.Tables("Materials").Columns("Material"), ds.Tables("Materials").Columns("Board")}))
                    ds.Tables("ProductionPlan").Columns.Add("Use", GetType(Integer), String.Format("AVG(Child(PPM).[Seconds]) * AVG(Child(PPM).[Operators]) * [{0}]", column.ColumnName))
                    total_capacity = DailyCapacity(column.ColumnName)
                    If total_capacity > 0 Then
                        nst.Item(column.ColumnName) = Math.Round((ds.Tables("ProductionPlan").Compute("SUM([Use])", "") / total_capacity) * 100, 0)
                    End If
                End If
            Next
            ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(nst)
        Next
    End Sub

    Private Function DailyCapacity(day As String) As Integer
        Dim shifts_onday As DataRow = ds_production_plan.Tables("WorkingShifts").Rows.Find(day)
        Dim total_capacity = 0
        For Each shift As DataRow In selected_family_headcount.Rows
            If shifts_onday.Item("WorkingShifts").ToString.Contains(shift.Item("Shift")) Then
                total_capacity += (shift.Item("Headcount") * shift("ManufacturingSeconds"))
            End If
        Next
        Return total_capacity
    End Function

    Private Sub SumarizeByCapacity()
        Dim total_capacity As Integer
        Dim classes As DataTable = ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable(True, "Class")
        Dim nst As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
        nst.Item("Material") = "*"
        nst.Item("Class") = "*"
        nst.Item("Board") = "*Total Cap. Use"
        For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
            If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                Dim ds As New DataSet()
                ds.Tables.Add(New DataView(ds_production_plan.Tables("CurrentProductionPlan"), String.Format("Material <> '*'", column.ColumnName), "", DataViewRowState.CurrentRows).ToTable("ProductionPlan", False, "Material", "Board", column.ColumnName))
                ds.Tables.Add(ds_production_plan.Tables("Materials").DefaultView.ToTable("Materials", False, "Material", "Board", "Operators", "Seconds"))
                ds.Relations.Add(New DataRelation("PPM", {ds.Tables("ProductionPlan").Columns("Material"), ds.Tables("ProductionPlan").Columns("Board")}, {ds.Tables("Materials").Columns("Material"), ds.Tables("Materials").Columns("Board")}, False))
                ds.Tables("ProductionPlan").Columns.Add("Use", GetType(Integer), String.Format("AVG(Child(PPM).[Seconds]) * AVG(Child(PPM).[Operators]) * [{0}]", column.ColumnName))
                total_capacity = DailyCapacity(column.ColumnName)
                If total_capacity > 0 Then
                    nst.Item(column.ColumnName) = Math.Round((ds.Tables("ProductionPlan").Compute("SUM([Use])", "") / total_capacity) * 100, 0)
                End If
            End If
        Next
        ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(nst)
    End Sub

    Private Sub Save()
        LoadingScreen.Show()
        Dim errors As Integer = 0
        For Each row As DataRow In original_pp_pivot.Rows
            Dim current As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({row.Item("Material"), row.Item("Board")})
            For Each col As DataColumn In original_pp_pivot.Columns
                If Not col.ColumnName = "Material" AndAlso Not col.ColumnName = "Board" Then
                    If row.Item(col.ColumnName) <> current.Item(col.ColumnName) Then
                        If SQL.Current.Execute(String.Format("MERGE Sch_DailyProductionPlan AS target USING (SELECT '{0}','{1}','{2}',{3}) AS source (Material,Board,[Date],Quantity) " & _
                                            "ON (target.Material = source.Material AND target.Board = source.Board AND target.[Date] = source.[Date]) WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity " & _
                                            "WHEN NOT MATCHED THEN INSERT(Material,Board,[Date],Quantity) VALUES (source.Material,source.Board, source.[Date],source.Quantity);", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName))) Then
                            row.Item(col.ColumnName) = current.Item(col.ColumnName)
                            Log(String.Format("{0}|{1}|{2}|{3}|OK", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName)))
                            Delta.Log(String.Format("{0}|{1}|{2}|{3}|OK", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName)), "Sch_ChangeProductionPlan")
                        Else
                            errors += 1
                            Log(String.Format("{0}|{1}|{2}|{3}|ERROR", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName)))
                        End If
                    End If
                End If
            Next

            Dim orig_comment As DataRow = original_pp_comments.Rows.Find({current.Item("Material"), current.Item("Board")})
            If orig_comment IsNot Nothing AndAlso current.Item("Comment").ToString <> orig_comment.Item("Comment").ToString Then 'SI TENIA COMENTARIO Y SE CAMBIO
                If SQL.Current.Update("Sch_DailyProductionPlanComments", {"Comment"}, {current.Item("Comment").ToString}, {"Material", "Board"}, {current.Item("Material"), current.Item("Board")}) Then
                    orig_comment.Item("Comment") = current.Item("Comment")
                    Log(String.Format("{0}|{1}|Comment|{2}|OK", row.Item("Material"), row.Item("Board"), current.Item("Comment")))
                    Delta.Log(String.Format("{0}|{1}|Comment|{2}|OK", row.Item("Material"), row.Item("Board"), current.Item("Comment")), "Sch_ChangeProductionPlan")
                Else
                    errors += 1
                    Log(String.Format("{0}|{1}|Comment|{2}|ERROR", row.Item("Material"), row.Item("Board"), current.Item("Comment")))
                End If
            ElseIf orig_comment Is Nothing AndAlso Not IsDBNull(current.Item("Comment")) AndAlso Not current.Item("Comment").ToString.Trim = "" Then 'NO TENIA COMENTARIO Y SE AGREGO UNO
                If SQL.Current.Insert("Sch_DailyProductionPlanComments", {"Material", "Board", "Comment"}, {current.Item("Material"), current.Item("Board"), Strings.Left(current.Item("Comment").ToString.Trim, 200)}) Then
                    original_pp_comments.Rows.Add(current.Item("Material"), current.Item("Board"), current.Item("Comment"))
                    Log(String.Format("{0}|{1}|Comment|{2}|OK", row.Item("Material"), row.Item("Board"), current.Item("Comment")))
                    Delta.Log(String.Format("{0}|{1}|Comment|{2}|OK", row.Item("Material"), row.Item("Board"), current.Item("Comment")), "Sch_ChangeProductionPlan")
                Else
                    errors += 1
                    Log(String.Format("{0}|{1}|Comment|{2}|ERROR", row.Item("Material"), row.Item("Board"), current.Item("Comment")))
                End If
            End If
        Next
        original_pp_comments.AcceptChanges()
        original_pp_pivot.AcceptChanges()
        changes_saved = True
        Log(String.Format("Finished with {0} errors...", errors))
        LoadingScreen.Hide()
    End Sub
    'Private Sub ValidateDays()
    '    If IsNumeric(tstbWeeksToDisplay.Text) AndAlso CInt(tstbWeeksToDisplay.Text) > 0 AndAlso CInt(tstbWeeksToDisplay.Text) <> weeks_toShow Then
    '        If CInt(tstbWeeksToDisplay.Text) > 12 Then
    '            weeks_toShow = 12
    '            tstbWeeksToDisplay.Text = 12
    '        ElseIf CInt(tstbWeeksToDisplay.Text) < 3 Then
    '            weeks_toShow = 3
    '            tstbWeeksToDisplay.Text = 3
    '        Else
    '            weeks_toShow = CInt(tstbWeeksToDisplay.Text)
    '        End If
    '        LoadProductionPlan()
    '    Else
    '        tstbWeeksToDisplay.Text = weeks_toShow
    '    End If
    'End Sub
    Private Sub Log(text As String)
        Try
            rtbLog.DeselectAll()
            rtbLog.AppendText(text & Environment.NewLine)
            rtbLog.SelectionStart = rtbLog.TextLength
            rtbLog.ScrollToCaret()
            rtbLog.Refresh()
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        rtbLog.Focus()
        rtbLog.SelectAll()
        rtbLog.Refresh()
    End Sub

    Private Sub ProductionPlanDaily_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SelectBusiness()
    End Sub

    Private Sub SelectBusiness()
        Dim bsd As New Sch_BusinessSelectorDialog
        If bsd.ShowDialog = Windows.Forms.DialogResult.OK Then
            selected_family = bsd.Family
            selected_business = bsd.Business
            If selected_business = "" Then
                ChangeBusinessButton.Text = selected_family
            Else
                ChangeBusinessButton.Text = String.Format("{0} / {1}", selected_family, selected_business)
            End If
            selected_family_headcount = SQL.Current.GetDatatable(String.Format("SELECT LowVolume AS Headcount,H.Shift,ManufacturingSeconds FROM Mfg_Headcount AS H INNER JOIN Sys_Shifts AS S ON H.Shift = S.Shift WHERE Family = '{0}'", selected_family))
            LoadProductionPlan()
        End If
        bsd.Dispose()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If Not changes_saved Then
            Select Case MessageBox.Show("Save changes before close?", "Changes not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case Windows.Forms.DialogResult.Yes
                    Save()
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Dim import As New Sch_ImportProductionPlan
        If import.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            LoadProductionPlan()
        End If
        import.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Delta.Export(ds_production_plan.Tables("CurrentProductionPlan").DefaultView, "PP_" & ChangeBusinessButton.Text.Replace("/", "-"))
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Not IsNothing(ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable) Then
            MyExcel.Print(ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape, , False)
        End If
    End Sub

    Private Sub dgvProductionPlan_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvProductionPlan.CellContextMenuStripNeeded
        cms_rowIndex = e.RowIndex
        cms_columnIndex = e.ColumnIndex
    End Sub

    Private Sub LowVolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowVolumeToolStripMenuItem.Click
        Dim chart As New Sch_ChartHeadcountWorkloadSchedule
        Dim dv As New DataView(ds_production_plan.Tables("CurrentProductionPlan"))
        dv.RowFilter = String.Format("[{0}] > 0 AND [Material] <> '*'", dgvProductionPlan.Columns(cms_columnIndex).Name)
        Dim dt As DataTable = dv.ToTable(False, "Material", "Board", dgvProductionPlan.Columns(cms_columnIndex).Name)
        dt.Columns(2).ColumnName = "Quantity"
        dt.Columns.Add("Shifts", GetType(String))
        dt.Columns.Add("Seconds", GetType(Integer))
        dt.Columns.Add("Operators", GetType(Integer))
        dt.Columns.Add("Man-seconds", GetType(Integer))
        Dim sum As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
            row.Item("Shifts") = material.Item("ShiftCombination")
            row.Item("Seconds") = material.Item("Seconds")
            row.Item("Operators") = material.Item("Operators")
            row.Item("Man-seconds") = row.Item("Quantity") * material("Seconds") * material.Item("Operators")
            sum += row.Item("Quantity") * material("Seconds") * material.Item("Operators")
        Next
        chart.Shifts = SQL.Current.GetDatatable(String.Format("SELECT S.Shift,ManufacturingSeconds,LowVolume AS Operators FROM Sys_Calendar INNER JOIN Sys_Shifts AS S ON WorkingShifts LIKE '%'  + Shift + '%' INNER JOIN Mfg_Headcount AS H ON S.Shift = H.Shift AND H.Family = '{0}' WHERE [Date] = '{1}'", selected_family, CDate(dgvProductionPlan.Columns(cms_columnIndex).Name)))
        chart.TotalManSeconds = sum
        chart.Datasource = dt
        chart.Title = dgvProductionPlan.Columns(cms_columnIndex).HeaderText
        chart.Show(Me)
    End Sub

    Private Sub cmsCellOptions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsCellOptions.Opening
        If cms_rowIndex = -1 OrElse cms_columnIndex = -1 Then
            e.Cancel = True
        Else
            With dgvProductionPlan.Columns(cms_columnIndex).Name
                If .StartsWith("PD_") OrElse .StartsWith("Week") OrElse .Contains("Material") OrElse .Contains("Class") OrElse .Contains("Board") OrElse .Contains("Comment") OrElse .Contains("Grand Total") Then
                    e.Cancel = True
                End If
            End With
        End If
    End Sub

    Private Sub ShowCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ShowCombo.SelectedIndexChanged
        If Not IsNothing(ds_production_plan) Then
            If ShowCombo.SelectedItem = "Only Requirements" Then
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) <> 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) <> 0 Or Material IN ('Material','*'))"
            Else
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = ""
            End If
        End If
        dgvProductionPlan.Focus()
    End Sub

    Private Sub dgvProductionPlan_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvProductionPlan.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            With dgvProductionPlan.Columns(e.ColumnIndex).HeaderText
                If Not .Contains("Material") AndAlso Not .Contains("Class") AndAlso Not .Contains("Board") AndAlso Not .Contains("Comment") AndAlso Not .Contains("Past Due") AndAlso Not .Contains("Week") AndAlso Not .Contains("Grand Total") Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                    If Not {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                        Dim br As System.Drawing.Drawing2D.LinearGradientBrush = Nothing
                        Dim format As New StringFormat
                        format.Alignment = StringAlignment.Center
                        format.LineAlignment = StringAlignment.Center

                        If CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).Date < CurrentDate.Date Then
                            Dim pp As Integer = ds_production_plan.Tables("SumProductionPlan").Compute(String.Format("Avg([{0}])", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                            Dim eps_qty As Integer = ds_production_plan.Tables("Production").Compute(String.Format("Avg([{0}])", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                            If pp > eps_qty Then
                                br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.OrangeRed, Color.DarkRed, 90, True)
                                e.Graphics.FillRectangle(br, e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10)
                                e.Graphics.DrawString(eps_qty, New Font("Microsoft Sans Serif", 6), Brushes.White, New Rectangle(e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10), format)
                            ElseIf pp < eps_qty Then
                                br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.DodgerBlue, Color.MidnightBlue, 90, True)
                                e.Graphics.FillRectangle(br, e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10)
                                e.Graphics.DrawString(eps_qty, New Font("Microsoft Sans Serif", 6), Brushes.White, New Rectangle(e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10), format)
                            ElseIf pp > 0 Then
                                br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.Lime, Color.Green, 90, True)
                                e.Graphics.FillRectangle(br, e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10)
                                e.Graphics.DrawString(eps_qty, New Font("Microsoft Sans Serif", 6), Brushes.White, New Rectangle(e.CellBounds.Right - 18, e.CellBounds.Location.Y + 10, 18, e.CellBounds.Height - 10), format)
                            End If
                        End If

                        If CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).Date >= sap_update.AddDays(1 - Weekday(sap_update)) AndAlso CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).Date <= sap_update.AddDays(35 - Weekday(sap_update)) Then
                            Dim curr_req As Object = ds_production_plan.Tables("Requirements").Compute(String.Format("SUM([{0}])", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                            Dim last_req As Object = ds_production_plan.Tables("VL10LastWeek").Compute("SUM(Quantity)", String.Format("Material = '{0}' AND [Date] = '{1}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value, CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).ToString("yyyy-MM-dd")))
                            If IsDBNull(curr_req) Then curr_req = 0
                            If IsDBNull(last_req) Then last_req = 0
                            If curr_req > last_req Then
                                br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.OrangeRed, Color.DarkRed, 90, True)
                                e.Graphics.FillPolygon(br, {New Point(e.CellBounds.Location.X + 2, e.CellBounds.Location.Y + 10), New Point(e.CellBounds.Location.X + 7, e.CellBounds.Location.Y + 2), New Point(e.CellBounds.Location.X + 12, e.CellBounds.Location.Y + 10)}, Drawing2D.FillMode.Alternate) 'triangulo arriba
                                e.Graphics.DrawString(String.Format("{0} / {1}", last_req, curr_req), New Font("Microsoft Sans Serif", 7), Brushes.DimGray, e.CellBounds.X + 1, e.CellBounds.Location.Y + 10, StringFormat.GenericDefault)
                            ElseIf curr_req < last_req Then
                                br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.MidnightBlue, Color.DodgerBlue, 90, True)
                                e.Graphics.FillPolygon(br, {New Point(e.CellBounds.Location.X + 2, e.CellBounds.Location.Y + 2), New Point(e.CellBounds.Location.X + 7, e.CellBounds.Location.Y + 10), New Point(e.CellBounds.Location.X + 12, e.CellBounds.Location.Y + 2)}, Drawing2D.FillMode.Alternate) 'triangulo abajo
                                e.Graphics.DrawString(String.Format("{0} / {1}", last_req, curr_req), New Font("Microsoft Sans Serif", 7), Brushes.DimGray, e.CellBounds.X + 1, e.CellBounds.Location.Y + 10, StringFormat.GenericDefault)
                            ElseIf curr_req > 0 Then
                                e.Graphics.DrawString(curr_req, New Font("Microsoft Sans Serif", 7), Brushes.DimGray, e.CellBounds.X + 1, e.CellBounds.Location.Y + 10, StringFormat.GenericDefault)
                            End If
                        End If

                        If CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).Date = sap_update.Date Then
                            Dim stock_qty As Integer = ds_production_plan.Tables("Materials").Compute(String.Format("Avg(Stock)", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                            br = New System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.DimGray, Color.Black, 90, True)
                            e.Graphics.FillRectangle(br, e.CellBounds.Right - 18, e.CellBounds.Location.Y, 18, 10)
                            e.Graphics.DrawString(stock_qty, New Font("Microsoft Sans Serif", 6), Brushes.White, New Rectangle(e.CellBounds.Right - 18, e.CellBounds.Location.Y, 18, 10), format)
                        End If

                        If br IsNot Nothing Then br.Dispose()
                    End If
                    If dgvProductionPlan("Material", e.RowIndex).Value = "*" AndAlso (dgvProductionPlan("Board", e.RowIndex).Value = "*Total Cap. Use" OrElse dgvProductionPlan("Board", e.RowIndex).Value.ToString.Contains("*Cap. Use")) AndAlso Not IsDBNull(e.Value) Then
                        e.Graphics.DrawString("%", New Font("Microsoft Sans Serif", 10), Brushes.White, e.CellBounds.Right - 18, e.CellBounds.Location.Y + 3, StringFormat.GenericDefault)
                    End If
                    e.Handled = True
                End If

            End With
        End If
    End Sub
End Class