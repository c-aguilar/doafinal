Imports Microsoft.VisualBasic.Strings
Public Class Sch_ProductionPlanDailyHigh
    Dim weeks_toShow As Integer
    Dim from_day As Date
    Dim frozen_days As Integer = 0
    Dim ds_production_plan As DataSet
    ' Dim pp_pivot As DataTable = Nothing
    Dim original_pp_pivot As DataTable = Nothing
    Dim original_pp_comments As DataTable = Nothing
    Dim changes_saved As Boolean = True
    Dim selected_business, selected_family As String
    Dim cms_rowIndex, cms_columnIndex As Integer
    Dim sap_update As Date
    Dim sb As SearchBox
#Region "Form"
    Private Sub ProductionPlanDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frozen_days = Parameter("SCH_FrozenDays", 0)
        from_day = LastSunday()
        weeks_toShow = 3
        tstbWeeksToDisplay.Text = weeks_toShow
        SumarizeByCombo.SelectedItem = "Class"
        PastDueCombo.SelectedItem = "Weekly"
        ShowCombo.SelectedItem = "Only Requirements"
        InitialDateButton.Text = from_day.ToShortDateString
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
        options.MinDate = DateAdd(DateInterval.Day, frozen_days + 1, CurrentDate)
        options.MaxDate = from_day.AddDays(((weeks_toShow - 1) * 7) - 1)
        If options.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadingScreen.Show()
            For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                If Not {"Material", "*"}.Contains(row.Item("Material")) Then

                    Dim requirements As DataRow = ds_production_plan.Tables("Requirements").Rows.Find({row.Item("Material"), row.Item("Board")})
                    Dim avg_requirements As DataRow = ds_production_plan.Tables("AverageRequirements").Rows.Find({row.Item("Material"), row.Item("Board")})
                    Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                    Dim capacities As DataRow = ds_production_plan.Tables("Capacities").Rows.Find({row.Item("Material"), row.Item("Board")})
                    If options.ReplaceExisitng Then
                        For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                            If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                                If CDate(column.ColumnName).Date >= options.From.Date AndAlso CDate(column.ColumnName).Date <= options.To.Date Then
                                    row.Item(column.ColumnName) = 0
                                End If
                            End If
                        Next
                    End If
                    If capacities IsNot Nothing AndAlso material.Item("Volume").ToString.ToLower <> "low" Then
                        Dim sum_capacities As Single = 0
                        Dim sum_scheduled As Integer = 0
                        Dim previous_column As DataColumn = Nothing
                        For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                            If Not {"Material", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                                Dim pd_column_tolook As Date

                                If options.AverageRequirements Then
                                    pd_column_tolook = NextSaturday(CDate(column.ColumnName).AddDays(7 * (options.AverageWeeks - 1)))
                                Else
                                    pd_column_tolook = NextSaturday(CDate(column.ColumnName))
                                End If
                                Dim pd_column_week As String = "PD_" & NextSaturday(CDate(column.ColumnName)).ToString("MM/dd/yyyy")
                                Dim pd_column As String = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                                While Not ds_production_plan.Tables("CurrentProductionPlan").Columns.Contains(pd_column)
                                    pd_column_tolook = pd_column_tolook.AddDays(-1)
                                    pd_column = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                                End While
                                If CDate(column.ColumnName).Date >= options.From.Date AndAlso CDate(column.ColumnName).Date <= options.To.Date _
                                    AndAlso Not CDate(column.ColumnName).Date < material.Item("StartProduction") AndAlso Not CDate(column.ColumnName).Date > material.Item("EndProduction") Then
                                    If row.Item(pd_column) < 0 Then 'SI AUN EXISTE PASTDUE
                                        sum_capacities += capacities.Item(column.ColumnName)
                                        Dim qty_toschedule As Integer = 0
                                        If options.AverageWeeks Then
                                            Dim avg_requeriment As Integer = Math.Ceiling((avg_requirements.Item(column.ColumnName) + avg_requirements.Item(CDate(column.ColumnName).AddDays(7 * (options.AverageWeeks - 1)).ToString("MM/dd/yyyy"))) / 2)
                                            If avg_requeriment < avg_requirements.Item(column.ColumnName) Then
                                                qty_toschedule = avg_requirements.Item(column.ColumnName)
                                            Else
                                                qty_toschedule = avg_requeriment
                                            End If
                                        Else
                                            qty_toschedule = requirements.Item(column.ColumnName)
                                        End If
                                        If options.RoundByStandarPack Then
                                            qty_toschedule = Math.Ceiling(qty_toschedule / material.Item("StdPack")) * material.Item("StdPack")
                                        End If
                                        If row.Item(pd_column_week) + qty_toschedule < 0 Then qty_toschedule += Math.Abs(row.Item(pd_column_week)) 'Agregar el pastdue a la programacion

                                        If qty_toschedule > Math.Ceiling(capacities.Item(column.ColumnName)) Then qty_toschedule = Math.Ceiling(capacities.Item(column.ColumnName)) 'Programar al maximo de capacidad diaria

                                        If sum_scheduled + qty_toschedule > sum_capacities Then qty_toschedule = Math.Ceiling(sum_capacities - sum_scheduled) 'Programar al maximo de capacidad acumulada


                                        If Not options.AllowPositive Then
                                            If row.Item(pd_column) + qty_toschedule > 0 Then qty_toschedule = Math.Abs(row.Item(pd_column)) 'No generar banco...
                                        End If

                                        row.Item(column.ColumnName) = qty_toschedule
                                        sum_scheduled += qty_toschedule
                                    Else
                                        sum_capacities = 0
                                        sum_scheduled = 0
                                    End If

                                    ''Si lo weeklydppp < req_week + pastdue
                                    'If options.ReplaceExisitng Then
                                    '    If row.Item(pd_column) < 0 Then
                                    '        Dim dppp As Integer = 0
                                    '        If options.AverageRequirements Then
                                    '            dppp = avg_requirements(column.ColumnName)
                                    '        Else
                                    '            dppp = requirements(column.ColumnName)
                                    '        End If
                                    '        If row.Item(pd_column) < 0 Then 'Si pastdue > dppp
                                    '            If dppp > Math.Abs(row.Item(pd_column)) Then
                                    '                dppp = Math.Abs(row.Item(pd_column))
                                    '            End If
                                    '            sum_capacities += capacities.Item(column.ColumnName)
                                    '            If capacities.Item(column.ColumnName) > 0 AndAlso capacities.Item(column.ColumnName) < 1 Then
                                    '                If previous_column IsNot Nothing Then
                                    '                    dppp = 1
                                    '                ElseIf sum_capacities > dppp Then
                                    '                    dppp = 0
                                    '                Else
                                    '                    dppp = 0
                                    '                End If
                                    '            Else
                                    '                If dppp > capacities.Item(column.ColumnName) Then
                                    '                    dppp = capacities.Item(column.ColumnName)
                                    '                ElseIf options.RoundByStandarPack Then
                                    '                    dppp = Math.Ceiling(dppp / material.Item("StdPack")) * material.Item("StdPack")
                                    '                    If dppp > capacities.Item(column.ColumnName) Then
                                    '                        dppp = capacities.Item(column.ColumnName)
                                    '                    End If
                                    '                End If
                                    '            End If
                                    '            sum_scheduled += dppp

                                    '        End If
                                    '    End If
                                    'Else
                                    '    If row(column.ColumnName) = 0 AndAlso row.Item(pd_column) < 0 Then
                                    '        Dim dppp As Integer = 0
                                    '        If options.AverageRequirements Then
                                    '            dppp = avg_requirements(column.ColumnName)
                                    '        Else
                                    '            dppp = requirements(column.ColumnName)
                                    '        End If
                                    '        If row.Item(pd_column) < 0 Then 'Si pastdue > dppp
                                    '            If dppp > Math.Abs(row.Item(pd_column)) Then
                                    '                dppp = Math.Abs(row.Item(pd_column))
                                    '            End If

                                    '            If dppp > capacities.Item(column.ColumnName) Then
                                    '                dppp = capacities.Item(column.ColumnName)
                                    '            ElseIf options.RoundByStandarPack Then
                                    '                dppp = Math.Ceiling(dppp / material.Item("StdPack")) * material.Item("StdPack")
                                    '                If dppp > capacities.Item(column.ColumnName) Then
                                    '                    dppp = capacities.Item(column.ColumnName)
                                    '                End If
                                    '            End If
                                    '        End If
                                    '    End If
                                    'End If
                                End If
                                previous_column = column
                            End If
                        Next
                    End If
                End If
            Next
            'PROSEGUIR CON BAJO VOLUMEN

            Dim headcount = SQL.Current.GetDatatable("Mfg_Headcount", "Family", selected_family)
            headcount.PrimaryKey = {headcount.Columns("Shift")}
            Dim shifts As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sys_Shifts")
            shifts.PrimaryKey = {shifts.Columns("Shift")}

            Dim dec_column As New DataTable
            dec_column.Columns.Add("Material", GetType(String))
            dec_column.Columns.Add("Board", GetType(String))
            dec_column.Columns.Add("Quantity", GetType(Single))
            dec_column.PrimaryKey = {dec_column.Columns("Material"), dec_column.Columns("Board")}

            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    If CDate(column.ColumnName).Date >= options.From.Date AndAlso CDate(column.ColumnName).Date <= options.To.Date Then
                        Dim shifts_onday As DataRow = ds_production_plan.Tables("WorkingShifts").Rows.Find(column.ColumnName)
                        For Each shift As DataRow In shifts.Rows
                            If shifts_onday.Item("WorkingShifts").ToString.ToLower.Contains(shift.Item("Shift").ToString.ToLower) Then 'Verificar que es ese dia si trabaje el turno
                                Dim headcount_shift As DataRow = headcount.Rows.Find(shift.Item("Shift"))
                                Dim available_headcount As Integer
                                If headcount_shift IsNot Nothing Then
                                    available_headcount = headcount_shift.Item("LowVolume")
                                Else
                                    available_headcount = 0
                                End If
                                If available_headcount = 0 Then Continue For

                                Dim pd_column_tolook As Date
                                If options.AverageRequirements Then
                                    pd_column_tolook = NextSaturday(CDate(column.ColumnName).AddDays(7 * (options.AverageWeeks - 1)))
                                Else
                                    pd_column_tolook = NextSaturday(CDate(column.ColumnName))
                                End If
                                Dim pd_column_week As String = "PD_" & NextSaturday(CDate(column.ColumnName)).ToString("MM/dd/yyyy")
                                Dim pd_column As String = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                                While Not ds_production_plan.Tables("CurrentProductionPlan").Columns.Contains(pd_column)
                                    pd_column_tolook = pd_column_tolook.AddDays(-1)
                                    pd_column = "PD_" & pd_column_tolook.ToString("MM/dd/yyyy")
                                End While
                                'AndAlso Not CDate(column.ColumnName).Date < material.Item("StartProduction") AndAlso Not CDate(column.ColumnName).Date > material.Item("EndProduction") Then

                                'Req * Seconds * Operators 'Req esta dividido entre la cantidad de turnos en los que corre para balancear las cantidades
                                Dim total_secondsmen As Integer = (From pp In ds_production_plan.Tables("CurrentProductionPlan")
                                                         Join m In ds_production_plan.Tables("Materials")
                                                         On pp.Field(Of String)("Material") Equals m.Field(Of String)("Material") And pp.Field(Of String)("Board") Equals m.Field(Of String)("Board")
                                                         Where m.Field(Of String)("Volume").ToLower = "low" And m.Field(Of String)("ShiftCombination").ToLower.Contains(shift.Item("Shift").ToString.ToLower) And pp.Field(Of Integer)(pd_column) < 0 AndAlso pp.Field(Of String)("Material") <> "Material"
                                                         Select New With {.Quantity = pp.Field(Of Integer)(pd_column) / m.Field(Of String)("ShiftCombination").Length, .Seconds = m.Field(Of Integer)("Seconds"), .Operators = m.Field(Of Int16)("Operators")}).Sum(Function(s) s.Quantity * s.Operators * s.Seconds)

                                'Dim total_requeriment As Object = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}] * Child(PPMaterials).[Seconds] * Child(PPMaterials).[Operators])", pd_column), String.Format("[{0}] < 0 AND MAX(Child(PPMaterials).[Volume]) = 'Low' AND MAX(Child(PPMaterials).[ShiftCombination]) LIKE '%{1}%'", pd_column, shift.Item("Shift")))
                                If total_secondsmen < 0 Then
                                    For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                                        If Not {"Material", "*"}.Contains(row.Item("Material")) AndAlso row.Item(pd_column) < 0 Then
                                            Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                                            If material.Item("Volume").ToString.ToLower = "low" AndAlso material.Item("ShiftCombination").ToString.ToLower.Contains(shift.Item("Shift").ToString.ToLower) Then 'Verificar que sea bajo volumen y ademas ese numero de parte se construya en ese turno
                                                Dim penetration As Single = ((row.Item(pd_column) / material.Item("ShiftCombination").ToString.Length) * material.Item("Seconds") * material.Item("Operators")) / total_secondsmen
                                                Dim segs_to_mfg As Single = shift.Item("ManufacturingSeconds") * available_headcount * penetration
                                                Dim pieces As Single = segs_to_mfg / (material.Item("Seconds") * material.Item("Operators"))
                                                If pieces > Math.Abs(row.Item(pd_column)) Then
                                                    pieces = Math.Abs(row.Item(pd_column))
                                                End If
                                                Dim row_dec As DataRow = dec_column.Rows.Find({row.Item("Material"), row.Item("Board")})
                                                Dim rounded As Integer = 0
                                                If row_dec Is Nothing Then
                                                    rounded = Math.Ceiling(pieces)
                                                    dec_column.Rows.Add(row.Item("Material"), row.Item("Board"), pieces - rounded)
                                                    row.Item(column.ColumnName) += rounded
                                                Else
                                                    row_dec.Item("Quantity") += pieces
                                                    If row_dec.Item("Quantity") > 0 Then
                                                        rounded = Math.Ceiling(row_dec.Item("Quantity"))
                                                        row_dec.Item("Quantity") -= rounded
                                                        row.Item(column.ColumnName) += rounded
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    'Vaciar resultados al plan de producción
                                    'For Each row As DataRow In dec_column.Rows
                                    '    If row.Item("Quantity") > 0 Then
                                    '        Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                                    '        If shifts_onday.Item("WorkingShifts").ToString.Contains(shift.Item("Shift")) Then
                                    '            Dim pp As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({row.Item("Material"), row.Item("Board")})
                                    '            Dim rounded As Integer = Math.Ceiling(row.Item("Quantity"))
                                    '            pp.Item(column.ColumnName) += rounded
                                    '            row.Item("Quantity") -= rounded
                                    '            Exit For
                                    '        End If
                                    '    End If
                                    'Next
                                End If
                            End If
                        Next
                    End If
                End If
            Next


            If SumarizeByCombo.SelectedItem.ToString.Contains("Day") Then
                SumarizeByDay()
            End If
            LoadingScreen.Hide()
            changes_saved = False
        End If
        options.Dispose()
    End Sub

    Private Sub InitialDateButton_Click(sender As Object, e As EventArgs) Handles InitialDateButton.Click
        Dim cd As New Calendar
        cd.SelectedDate = from_day
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
            from_day = cd.SelectedDate
            InitialDateButton.Text = from_day.ToShortDateString
            LoadProductionPlan()
        End If
        cd.Dispose()
    End Sub


    Private Sub tstbWeeksToDisplay_KeyDown(sender As Object, e As KeyEventArgs) Handles tstbWeeksToDisplay.KeyDown
        If e.KeyCode = Keys.Enter Then
            ValidateDays()
        End If
    End Sub
    Private Sub tstbWeeksToDisplay_Validated(sender As Object, e As EventArgs) Handles tstbWeeksToDisplay.Validated
        ValidateDays()
    End Sub
    Private Sub tsbtnPrev_Click(sender As Object, e As EventArgs) Handles tsbtnPrev.Click
        from_day = from_day.AddDays(-7)
        InitialDateButton.Text = from_day.ToShortDateString
        LoadProductionPlan()
    End Sub
    Private Sub tsbtnNext_Click(sender As Object, e As EventArgs) Handles tsbtnNext.Click
        from_day = from_day.AddDays(7)
        InitialDateButton.Text = from_day.ToShortDateString
        LoadProductionPlan()
    End Sub
    Private Sub SumarizeByCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SumarizeByCombo.SelectedIndexChanged
        If Not IsNothing(ds_production_plan) Then
            Cursor.Current = Cursors.WaitCursor
            FormatGrid()
            If ShowCombo.SelectedItem = "Only Requirements" Then
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) > 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) > 0 Or Material IN ('Material','*'))"
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
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) > 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) > 0 Or Material IN ('Material','*'))"
            Else
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = ""
            End If
            Cursor.Current = Cursors.Arrow
        End If
        dgvProductionPlan.Focus()
    End Sub
    Private Sub ChangeBusinessButton_Click(sender As Object, e As EventArgs) Handles ChangeBusinessButton.Click
        Dim bsd As New Sch_BusinessSelectorDialog
        If bsd.ShowDialog = Windows.Forms.DialogResult.OK Then
            selected_family = bsd.Family
            selected_business = bsd.Business
            If selected_business = "" Then
                ChangeBusinessButton.Text = selected_family
            Else
                ChangeBusinessButton.Text = String.Format("{0} / {1}", selected_family, selected_business)
            End If
            LoadProductionPlan()
        End If
        bsd.Dispose()
    End Sub
#End Region
#Region "DataGridView"
    Private Sub dgvProductionPlan_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductionPlan.CellFormatting
        With dgvProductionPlan.Columns(e.ColumnIndex).HeaderText
            If .Contains("Week") OrElse {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                If .Contains("Week") AndAlso {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                    e.CellStyle.BackColor = Color.FromArgb(67, 131, 163)
                Else
                    e.CellStyle.BackColor = Color.FromArgb(127, 191, 223)
                End If
                e.CellStyle.ForeColor = Color.White
                e.CellStyle.Font = New Font("Consolas", 10, FontStyle.Bold)
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
            ElseIf Not .Contains("Material") AndAlso Not .Contains("Class") AndAlso Not .Contains("Board") AndAlso Not .Contains("Comment") AndAlso Not .Contains("Past Due") AndAlso CDate(.Split(" ").GetValue(0).ToString.Trim("<")).Date <= DateAdd(DateInterval.Day, frozen_days, CurrentDate) Then
                e.CellStyle.BackColor = Color.WhiteSmoke
            End If
            If e.Value.ToString = "0" Then
                e.CellStyle.ForeColor = Color.Gray
            ElseIf Not .Contains("Material") AndAlso Not .Contains("Class") AndAlso Not .Contains("Board") AndAlso Not .Contains("Comment") AndAlso Not .Contains("Past Due") AndAlso Not .Contains("Week") AndAlso Not .Contains("Grand Total") AndAlso Not {"Material", "*"}.Contains(dgvProductionPlan("Material", e.RowIndex).Value) Then
                Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value, dgvProductionPlan.Rows(e.RowIndex).Cells("Board").Value})
                If material.Item("Volume") = "High" Then
                    Dim capacity As DataRow = ds_production_plan.Tables("Capacities").Rows.Find({dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value, dgvProductionPlan.Rows(e.RowIndex).Cells("Board").Value})
                    If capacity IsNot Nothing Then
                        Dim capacity_value As Single = Math.Ceiling(CDec(capacity.Item(dgvProductionPlan.Columns(e.ColumnIndex).Name)))
                        If CInt(e.Value) > capacity_value Then
                            e.CellStyle.BackColor = Color.LightCoral
                        End If
                    End If
                End If
                If CDate(dgvProductionPlan.Columns(e.ColumnIndex).Name).Date < CurrentDate.Date Then
                    Dim pp As Integer = ds_production_plan.Tables("SumProductionPlan").Compute(String.Format("Avg([{0}])", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                    Dim eps As Integer = ds_production_plan.Tables("Production").Compute(String.Format("Avg([{0}])", dgvProductionPlan.Columns(e.ColumnIndex).Name), String.Format("Material = '{0}'", dgvProductionPlan.Rows(e.RowIndex).Cells("Material").Value))
                    If pp > eps Then
                        e.CellStyle.ForeColor = Color.Crimson
                        e.CellStyle.Font = New Font("Consolas", 10, FontStyle.Strikeout)
                    ElseIf pp = eps Then
                        e.CellStyle.ForeColor = Color.Green
                        e.CellStyle.Font = New Font("Consolas", 10, FontStyle.Regular)
                    Else
                        e.CellStyle.ForeColor = Color.Blue
                        e.CellStyle.Font = New Font("Consolas", 10, FontStyle.Underline)
                    End If
                Else
                    e.CellStyle.Font = New Font("Consolas", 10, FontStyle.Bold)
                End If
            End If
            If Not .Contains("Material") AndAlso Not .Contains("Class") AndAlso Not .Contains("Board") AndAlso Not .Contains("Comment") Then
                e.CellStyle.Font = New Font("Consolas", 10, e.CellStyle.Font.Style)
            End If
        End With

    End Sub
    Private Sub dgvProductionPlan_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvProductionPlan.DataError
        dgvProductionPlan.CancelEdit()
    End Sub
    Private Sub dgvProductionPlan_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvProductionPlan.CellBeginEdit
        'original_value = If(IsDBNull(pp_pivot.Rows(e.RowIndex).Item(e.ColumnIndex)), "", pp_pivot.Rows(e.RowIndex).Item(e.ColumnIndex))
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

                    Dim capacity As DataRow = ds_production_plan.Tables("Capacities").Rows.Find({row.Cells("Material").Value, row.Cells("Board").Value})
                    If capacity IsNot Nothing Then
                        lblCapacity.Text = CDec(capacity.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name)).ToString("0.00")
                        If Math.Ceiling(CDec(capacity.Item(dgvProductionPlan.Columns(cell.ColumnIndex).Name))) < CInt(cell.Value) Then
                            lblCapacity.BackColor = Color.LightCoral
                            lblCapacity.ForeColor = Color.White
                        Else
                            lblCapacity.BackColor = Color.LightSlateGray
                            lblCapacity.ForeColor = Color.White
                        End If
                    Else
                        lblCapacity.BackColor = Color.LightSlateGray
                        lblCapacity.Text = "-"
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
            lblSelection.Text = String.Format("Sum: {0}   Avg: {1}   Count: {2}", sum, sum / counter, counter)
        End If
    End Sub
    Private Sub ResetMaterialLabelData()
        lblMaterial.Text = "-"
        lblBoard.Text = "-"
        lblCustomer.Text = "-"
        lblPastdue.Text = "-"
        lblSchedule.Text = "-"
        lblCapacity.Text = "-"
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
            Dim total As Integer = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("Sum([{0}])", e.Column.ColumnName), String.Format("Material = '{0}'", e.Row.Item("Material")))
            Dim sumpp_rows() As Data.DataRow
            sumpp_rows = ds_production_plan.Tables("SumProductionPlan").Select(String.Format("Material = '{0}'", e.Row.Item("Material")))
            For i = 0 To sumpp_rows.Length - 1
                sumpp_rows(i).Item(e.Column.ColumnName) = total
            Next
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
            If SumarizeByCombo.SelectedItem.ToString.Contains("Class") Then
                If SumarizeByCombo.SelectedItem.ToString.Contains("Capacity") Then
                    Dim total_capacity As Integer
                    Dim headcount As DataTable = SQL.Current.GetDatatable(String.Format("SELECT LowVolume AS Headcount,H.Shift,ManufacturingSeconds FROM Mfg_Headcount AS H INNER JOIN Sys_Shifts AS S ON H.Shift = S.Shift WHERE Family = '{0}'", selected_family))
                    Dim st As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Cap. Use " & e.Row.Item("Class")})
                    If st Is Nothing Then
                        st = ds_production_plan.Tables("CurrentProductionPlan").NewRow
                        st.Item("Material") = "*"
                        st.Item("Class") = e.Row.Item("Class")
                        st.Item("Board") = "*Cap. Use " & e.Row.Item("Class")
                        ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(st)
                    End If
                    Dim shifts_onday As DataRow = ds_production_plan.Tables("WorkingShifts").Rows.Find(e.Column.ColumnName)
                    total_capacity = 0
                    For Each shift As DataRow In headcount.Rows
                        If shifts_onday.Item("WorkingShifts").ToString.Contains(shift.Item("Shift")) Then
                            total_capacity += (shift.Item("Headcount") * shift("ManufacturingSeconds"))
                        End If
                    Next
                    If total_capacity > 0 Then
                        Dim dv As New DataView(ds_production_plan.Tables("CurrentProductionPlan"))
                        dv.RowFilter = String.Format("[{0}] <> 0 AND [Material] <> '*' AND [Class] = '{1}'", e.Column.ColumnName, e.Row.Item("Class"))
                        Dim dt As DataTable = dv.ToTable(False, "Material", "Board", e.Column.ColumnName)
                        Dim use As Integer = 0
                        For Each row As DataRow In dt.Rows
                            Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                            use += (row.Item(e.Column.ColumnName) * material("Seconds") * material.Item("Operators"))
                        Next
                        st.Item(e.Column.ColumnName) = Math.Round((use / total_capacity) * 100, 0)
                    Else
                        st.Item(e.Column.ColumnName) = DBNull.Value
                    End If
                Else
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
                End If

            End If
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
        LoadingScreen.Show()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If Not selected_family = "" Then
            dgvProductionPlan.DataSource = Nothing
            dgvProductionPlan.Columns.Clear()

            sap_update = SQL.Current.MyDate(SQL.Current.GetString("SELECT MAX(DownloadDate) FROM Sch_VL10;", Now.ToShortDateString))
            'Dim sap_update As Date = SQL.Current.MyDate(SQL.Current.GetString("SELECT TOP 1 UpdatedDate FROM Sch_CurrentInventory;", Now.ToShortDateString))

            original_pp_pivot = GetProductionPlan(from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family)
            Dim sum_pp As DataTable = original_pp_pivot.Copy()
            sum_pp.PrimaryKey = {sum_pp.Columns("Material"), sum_pp.Columns("Board")}
            sum_pp.TableName = "SumProductionPlan"

            Dim production_plan As New DataTable
            production_plan.TableName = "CurrentProductionPlan"
            production_plan.Columns.Add("Material", GetType(String))
            production_plan.Columns.Add("Class", GetType(String))
            production_plan.Columns.Add("Board", GetType(String))
            production_plan.PrimaryKey = {production_plan.Columns("Material"), production_plan.Columns("Board")}
            For Each row In original_pp_pivot.Rows
                production_plan.Rows.Add(row("Material"), row("Class"), row("Board"))
            Next

            'Dim decimal_pp As DataTable = production_plan.Copy
            'decimal_pp.PrimaryKey = {decimal_pp.Columns("Material"), decimal_pp.Columns("Board")}
            'decimal_pp.TableName = "DecimalProductionPlan"

            ds_production_plan = New DataSet
            ds_production_plan.Tables.Add(production_plan) 'Plan de producccion para el usuario
            'ds_production_plan.Tables.Add(decimal_pp) 'Plan de producción para auto scheduling
            ds_production_plan.Tables.Add(sum_pp) 'Plan de producción sumado para numeros de parte en varios tableros
            ds_production_plan.Tables.Add(New DataTable(""))
            ds_production_plan.Tables.Add(GetMaterialWithPastDueAndStock(from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family))
            ds_production_plan.Tables.Add(GetCapacities(from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family))
            ds_production_plan.Tables.Add(GetProduction(from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family))
            ds_production_plan.Tables.Add(GetRequirements(True, from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family, False, False))
            ds_production_plan.Tables.Add(GetRequirements(False, from_day, from_day.AddDays((weeks_toShow * 7) - 1), selected_business, selected_family, False, False))
            ds_production_plan.Tables.Add(GetWorkingShifts(from_day, from_day.AddDays((weeks_toShow * 7) - 1)))

            '*********************** RELATIONS *******************************************************************************************************************************************
            ds_production_plan.Relations.Add(New DataRelation("PPMaterials", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Materials").Columns("Material"), ds_production_plan.Tables("Materials").Columns("Board")}, True))
            ds_production_plan.Relations.Add(New DataRelation("PPCapacities", {ds_production_plan.Tables("CurrentProductionPlan").Columns("Material"), ds_production_plan.Tables("CurrentProductionPlan").Columns("Board")}, {ds_production_plan.Tables("Capacities").Columns("Material"), ds_production_plan.Tables("Capacities").Columns("Board")}, True))
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
                        ds_production_plan.Tables("CurrentProductionPlan").Columns.Add(new_pd)
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

            GetMaterialsComments(from_day, from_day.AddDays(weeks_toShow * 7), selected_business, selected_family)
            ds_production_plan.Tables("CurrentProductionPlan").Merge(original_pp_comments)
            ds_production_plan.Tables("CurrentProductionPlan").Merge(original_pp_pivot)

            AddHandler ds_production_plan.Tables("CurrentProductionPlan").ColumnChanged, New DataColumnChangeEventHandler(AddressOf ProductionPlan_Changed)

            frozen_days = Parameter("SCH_FrozenDays", 0)
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
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) > 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) > 0 Or Material IN ('Material','*'))"
            End If
            ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class ASC,Board DESC,Material ASC"
            dgvProductionPlan.DataSource = ds_production_plan.Tables("CurrentProductionPlan").DefaultView
            FormatGrid()
        End If
        LoadingScreen.Hide()
        Cursor.Current = Cursors.Arrow
    End Sub
    Private Function GetMaterialWithPastDueAndStock([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim materials As DataTable
        If selected_business = "" Then
            materials = SQL.Current.GetDatatable(String.Format(My.Resources.PP_MaterialsByFamily, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family, "D"))
        Else
            materials = SQL.Current.GetDatatable(String.Format(My.Resources.PP_MaterialsByBusiness, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business, "D"))
        End If
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
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_AverageRequirementsByFamily, wkd1, wkd2, divider, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
            Else
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_AverageRequirementsByBusiness, wkd1, wkd2, divider, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
            End If

        Else
            If selected_business = "" Then
                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_RequirementsByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
            Else

                requirements = SQL.Current.GetDatatable(String.Format(My.Resources.PP_RequirementsByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
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
            production = SQL.Current.GetDatatable(String.Format(My.Resources.PP_EPSProductionByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
        Else

            production = SQL.Current.GetDatatable(String.Format(My.Resources.PP_EPSProductionByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
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

    Private Function GetCapacities([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim capacity As DataTable
        If selected_business = "" Then
            capacity = SQL.Current.GetDatatable(String.Format(My.Resources.PP_BoardCapacitiesByFamily, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
        Else
            capacity = SQL.Current.GetDatatable(String.Format(My.Resources.PP_BoardCapacitiesByBusiness, from.ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
        End If
        capacity.Columns.Add("Capacity", GetType(Single))
        Dim shifts As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sys_Shifts")
        shifts.PrimaryKey = {shifts.Columns("Shift")}
        Dim seconds As Integer
        For Each row As DataRow In capacity.Rows
            seconds = 0
            For Each shift In row.Item("BoardShifts").ToString.ToCharArray
                If row.Item("DayShifts").ToString.ToUpper.Contains(shift.ToString.ToUpper) Then seconds += shifts.Compute("SUM([ManufacturingSeconds])", String.Format("[Shift]='{0}'", shift))
            Next
            row.Item("Capacity") = Math.Round(seconds / CDec(row.Item("Seconds")), 2)
        Next
        Dim cap_pivoter As New PivotTable(capacity)
        Dim cap_pivot As DataTable = cap_pivoter.PivotDates("Material", "Board", "Capacity", AggregateFunction.First, "Date", "System.Single")
        cap_pivot.PrimaryKey = {cap_pivot.Columns("Material"), cap_pivot.Columns("Board")}
        cap_pivot.TableName = "Capacities"
        Return cap_pivot
    End Function
    Private Function GetWorkingShifts([from] As Date, [to] As Date) As DataTable
        Dim dates As DataTable = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(VARCHAR(10),[Date],101) AS [Date],ISNULL([WorkingShifts],'') AS WorkingShifts FROM Sys_Calendar WHERE [Date] BETWEEN '{0}' AND '{1}'", [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd")), "WorkingShifts")
        dates.PrimaryKey = {dates.Columns("Date")}
        Return dates
    End Function
    Private Function GetProductionPlan([from] As Date, [to] As Date, selected_business As String, selected_family As String) As DataTable
        Dim pp_table As DataTable
        If selected_business = "" Then
            pp_table = SQL.Current.GetDatatable(String.Format(My.Resources.PP_ByFamily, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_family))
        Else
            pp_table = SQL.Current.GetDatatable(String.Format(My.Resources.PP_ByBusiness, [from].ToString("yyyy-MM-dd"), [to].ToString("yyyy-MM-dd"), selected_business))
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
    Private Sub FormatGrid()
        If SumarizeByCombo.SelectedItem.ToString.Contains("Day") Then
            ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class DESC,Board DESC,Material ASC"
            SumarizeByDay()
        Else
            ds_production_plan.Tables("CurrentProductionPlan").DefaultView.Sort = "Class ASC,Board DESC,Material ASC"
            Dim gt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Grand Total"})
            If gt IsNot Nothing Then
                ds_production_plan.Tables("CurrentProductionPlan").Rows.Remove(gt)
            End If
        End If
        If SumarizeByCombo.SelectedItem.ToString.Contains("Class") Then
            Dim sub_rows() As Data.DataRow
            sub_rows = ds_production_plan.Tables("CurrentProductionPlan").Select("Board LIKE '[*]Sum%' OR Board LIKE '[*]Cap. Use%'")
            For i = sub_rows.Length - 1 To 0 Step -1
                sub_rows(i).Delete()
            Next
            If SumarizeByCombo.SelectedItem.ToString.Contains("Capacity") Then
                SumarizeByClassCapacity()
            Else
                SumarizeByClass()
            End If
        Else
            Dim sub_rows() As Data.DataRow
            sub_rows = ds_production_plan.Tables("CurrentProductionPlan").Select("Board LIKE '[*]Sum%' OR Board LIKE '[*]Cap. Use%'")
            For i = sub_rows.Length - 1 To 0 Step -1
                sub_rows(i).Delete()
            Next
        End If
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
        Dim gt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Grand Total"})
        If gt IsNot Nothing Then
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                'Dim total As Integer = 0
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    'For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                    '    If Not row.Equals(gt) Then
                    '        total += row(column.ColumnName)
                    '    End If
                    'Next
                    'gt.Item(column.ColumnName) = total
                    gt.Item(column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", column.ColumnName), "[Material] <> '*'")
                End If
            Next
        Else
            Dim ngt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
            ngt.Item("Material") = "*"
            ngt.Item("Class") = "*"
            ngt.Item("Board") = "*Grand Total"
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                'Dim total As Integer = 0
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    'For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                    '    total += row(column.ColumnName)
                    'Next
                    'ngt.Item(column.ColumnName) = total
                    ngt.Item(column.ColumnName) = ds_production_plan.Tables("CurrentProductionPlan").Compute(String.Format("SUM([{0}])", column.ColumnName), "[Material] <> '*'")
                End If
            Next
            ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(ngt)
        End If
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
        Dim headcount As DataTable = SQL.Current.GetDatatable(String.Format("SELECT LowVolume AS Headcount,H.Shift,ManufacturingSeconds FROM Mfg_Headcount AS H INNER JOIN Sys_Shifts AS S ON H.Shift = S.Shift WHERE Family = '{0}'", selected_family))
        Dim classes As DataTable = ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable(True, "Class")
        For Each c As DataRow In classes.Rows
            Dim nst As DataRow = ds_production_plan.Tables("CurrentProductionPlan").NewRow
            nst.Item("Material") = "*"
            nst.Item("Class") = c.Item("Class")
            nst.Item("Board") = "*Cap. Use " & c.Item("Class")
            For Each column As DataColumn In ds_production_plan.Tables("CurrentProductionPlan").Columns
                If Not {"Material", "Class", "Board", "Grand Total", "Comment"}.Contains(column.ColumnName) AndAlso Not column.ColumnName.StartsWith("PD_") AndAlso Not column.ColumnName.StartsWith("Week") Then
                    Dim shifts_onday As DataRow = ds_production_plan.Tables("WorkingShifts").Rows.Find(column.ColumnName)
                    total_capacity = 0
                    For Each shift As DataRow In headcount.Rows
                        If shifts_onday.Item("WorkingShifts").ToString.Contains(shift.Item("Shift")) Then
                            total_capacity += (shift.Item("Headcount") * shift("ManufacturingSeconds"))
                        End If
                    Next
                    If total_capacity > 0 Then
                        Dim dv As New DataView(ds_production_plan.Tables("CurrentProductionPlan"))
                        dv.RowFilter = String.Format("[{0}] > 0 AND [Material] <> '*' AND [Class] = '{1}'", column.ColumnName, c.Item("Class"))
                        Dim dt As DataTable = dv.ToTable(False, "Material", "Board", column.ColumnName)
                        Dim use As Integer = 0
                        For Each row As DataRow In dt.Rows
                            Dim material As DataRow = ds_production_plan.Tables("Materials").Rows.Find({row.Item("Material"), row.Item("Board")})
                            use += (row.Item(column.ColumnName) * material("Seconds") * material.Item("Operators"))
                        Next
                        nst.Item(column.ColumnName) = Math.Round((use / total_capacity) * 100, 0)
                    End If
                End If
            Next
            ds_production_plan.Tables("CurrentProductionPlan").Rows.Add(nst)
        Next
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
                            Log(String.Format("""{0} - {1}"" [{2}] {3} Saved... OK", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName)))
                        Else
                            errors += 1
                            Log(String.Format("""{0} - {1}"" [{2}] {3} Not saved... ERROR", row.Item("Material"), row.Item("Board"), col.ColumnName, current.Item(col.ColumnName)))
                        End If
                    End If
                End If
            Next

            Dim r_comment As DataRow = original_pp_comments.Rows.Find({current.Item("Material"), current.Item("Board")})
            If r_comment IsNot Nothing AndAlso current.Item("Comment").ToString <> r_comment.Item("Comment").ToString Then 'SI TENIA COMENTARIO
                SQL.Current.Update("Sch_DailyProductionPlanComments", {"Comment"}, {current.Item("Comment").ToString}, {"Material", "Board"}, {current.Item("Material"), current.Item("Board")})
            ElseIf Not IsDBNull(current.Item("Comment")) AndAlso Not current.Item("Comment").ToString.Trim = "" Then 'NO TENIA COMENTARIO Y SE AGREGO UNO
                SQL.Current.Insert("Sch_DailyProductionPlanComments", {"Material", "Board", "Comment"}, {current.Item("Material"), current.Item("Board"), Strings.Left(current.Item("Comment").ToString.Trim, 200)})
            End If
        Next

        changes_saved = True
        Log(String.Format("Saved with {0} errors...", errors))
        LoadingScreen.Hide()
    End Sub
    Private Sub ValidateDays()
        If IsNumeric(tstbWeeksToDisplay.Text) AndAlso CInt(tstbWeeksToDisplay.Text) > 0 AndAlso CInt(tstbWeeksToDisplay.Text) <> weeks_toShow Then
            If CInt(tstbWeeksToDisplay.Text) > 12 Then
                weeks_toShow = 12
                tstbWeeksToDisplay.Text = 12
            ElseIf CInt(tstbWeeksToDisplay.Text) < 3 Then
                weeks_toShow = 3
                tstbWeeksToDisplay.Text = 3
            Else
                weeks_toShow = CInt(tstbWeeksToDisplay.Text)
            End If
            LoadProductionPlan()
        Else
            tstbWeeksToDisplay.Text = weeks_toShow
        End If
    End Sub
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
        Dim bsd As New Sch_BusinessSelectorDialog
        If bsd.ShowDialog = Windows.Forms.DialogResult.OK Then
            selected_family = bsd.Family
            selected_business = bsd.Business
            If selected_business = "" Then
                ChangeBusinessButton.Text = selected_family
            Else
                ChangeBusinessButton.Text = String.Format("{0} / {1}", selected_family, selected_business)
            End If
            LoadProductionPlan()
        End If
        bsd.Dispose()
    End Sub

    Private Sub dgvProductionPlan_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductionPlan.CellEndEdit
        Dim gt As DataRow = ds_production_plan.Tables("CurrentProductionPlan").Rows.Find({"*", "*Grand Total"})
        If gt IsNot Nothing Then
            Dim column As DataGridViewColumn = dgvProductionPlan.Columns(e.ColumnIndex)
            If Not {"Material", "Class", "Board", "Comment", "Grand Total"}.Contains(column.Name) AndAlso Not column.Name.StartsWith("Week") AndAlso Not column.Name.StartsWith("PD_") Then
                Dim total As Integer = 0
                For Each row As DataRow In ds_production_plan.Tables("CurrentProductionPlan").Rows
                    If Not row.Equals(gt) Then
                        total += row.Item(column.Name)
                    End If
                Next
                gt.Item(column.Name) = total
            End If
        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Delta.Export(ds_production_plan.Tables("CurrentProductionPlan").DefaultView, "PP_" & ChangeBusinessButton.Text.Replace("/", "-"))
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Not IsNothing(ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable) Then
            MyExcel.Print(ds_production_plan.Tables("CurrentProductionPlan").DefaultView.ToTable, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape, , False)
        End If
    End Sub

    Private Sub dgvProductionPlan_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductionPlan.RowValidated

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

    Private Sub dgvProductionPlan_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub cmsCellOptions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsCellOptions.Opening
        If cms_rowIndex = -1 Then
            e.Cancel = True
        End If
        With dgvProductionPlan.Columns(cms_columnIndex).Name
            If .StartsWith("PD_") OrElse .StartsWith("Week") OrElse .Contains("Material") OrElse .Contains("Class") OrElse .Contains("Board") OrElse .Contains("Comment") OrElse .Contains("Grand Total") Then
                e.Cancel = True
            End If
        End With
    End Sub

    Private Sub ShowCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ShowCombo.SelectedIndexChanged
        If Not IsNothing(ds_production_plan) Then
            If ShowCombo.SelectedItem = "Only Requirements" Then
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = "(ISNULL(Avg(Child(PPRequirements).[Total]),0) > 0 Or ISNULL(Avg(Child(PPMaterials).PastDue),0) > 0 Or Material IN ('Material','*'))"
            Else
                ds_production_plan.Tables("CurrentProductionPlan").DefaultView.RowFilter = ""
            End If
        End If
        dgvProductionPlan.Focus()
    End Sub
End Class