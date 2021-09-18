Public Class ProductionPlan
    Dim thread_A As Threading.Thread
    Dim thread_B As Threading.Thread
    Dim thread_C As Threading.Thread
    Dim thread_A_finished As Boolean = False
    Dim thread_B_finished As Boolean = False
    Dim thread_C_finished As Boolean = False

    Dim pc_total_balanced_requirements As DataTable
    Dim pc_scheduling_requirements As DataTable
    Dim pc_programreadiness_requirements As DataTable
    Dim bom As DataTable
    Dim harns As DataTable
    Public Shared Property WorkingCalendar As New Dictionary(Of Date, Boolean)

    Private Sub New()

    End Sub

    Public Shared Sub RefreshWorkingCalendar()
        WorkingCalendar.Clear()
        'CARGAR EL DICCIONARIO DE DIAS LABORALES
        'CARGAR TOP 500, LA CONSULTA ES MUY RAPIDA Y ASI EVITAMOS ESTAR CARGANDO FECHAS NUEVAS
        Dim calendar_dt As DataTable = SQL.Current.GetDatatable(String.Format("SELECT TOP 500 [Date],WorkingShifts FROM Sys_Calendar WHERE [Date] >= DATEADD(DAY,-30,GETDATE());"))
        For Each row As DataRow In calendar_dt.Rows
            WorkingCalendar.Add(CDate(row.Item("Date")).Date, Not IsDBNull(row.Item("WorkingShifts")))
        Next
    End Sub

    Public Shared Function WorkingDays([from] As Date, [to] As Date) As Integer
        WorkingDays = 0
        While [from] <= [to]
            If ProductionPlan.WorkingCalendar([from].Date) Then WorkingDays += 1
            [from] = [from].AddDays(1)
        End While
    End Function

    'Public Function WorkingHours([from] As Date, [to] As Date) As Integer
    '    WorkingHours = 0
    '    While from < [to]
    '        from = from.AddHours(1)
    '        If ProductionPlan.WorkingCalendar(from.Date) Then
    '            WorkingHours += 1
    '        Else 'OMITIR TODAS LAS HORAS DE ESE DIA PARA HACERLO MAS EFICIENTE
    '            from = New Date(from.Year, from.Month, from.Day, 23, from.Minute, 0)
    '        End If
    '    End While
    'End Function

    Public Sub New(horizon As Date)
        ProductionPlan.RefreshWorkingCalendar()
        Me.Horizon = horizon.Date
        Dim harn_list As New Dictionary(Of String, Harn)
        Dim bom_list As New Dictionary(Of String, BOM)
        Me.StartDate = LastMonday(Delta.CurrentDate)
        'OBTENER REQUERIMIENTO DE ARNESES, INFO DE ARNESES Y BOM
        thread_A = New Threading.Thread(AddressOf GetRequirements)
        thread_B = New Threading.Thread(AddressOf GetBOM)
        thread_C = New Threading.Thread(AddressOf GetHarns)
        thread_A.Start()
        thread_B.Start()
        thread_C.Start()

        While Not thread_A_finished OrElse Not thread_B_finished OrElse Not thread_C_finished

        End While

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
        For Each row As DataRow In pc_total_balanced_requirements.Rows
            If harn_list.ContainsKey(row.Item("Material")) Then
                If Not Me.Items.ContainsKey(row.Item("Material")) Then
                    Me.Items.Add(row.Item("Material"), New ProductionPlanItem(harn_list.Item(row.Item("Material"))))
                End If
                Me.Items.Item(row.Item("Material")).Items.Add(row.Item("Date"), New ProductionPlanItemDate(row.Item("Date"), row.Item("PlanQuantity"), row.Item("RealQuantity")))
            End If
        Next
        'For Each row As DataRow In pc_scheduling_requirements.Rows
        '    Me.Items.Item(row.Item("Material")).Items.Item(row.Item("Date")).SchedulingItems.Add(row.Item("ID"), New ProductionPlanItemDateDetails(row.Item("ID"), row.Item("Board"), row.Item("Quantity")))
        'Next
        'For Each row As DataRow In pc_programreadiness_requirements.Rows
        '    Me.Items.Item(row.Item("Material")).Items.Item(row.Item("Date")).SchedulingItems.Add(row.Item("ID"), New ProductionPlanItemDateDetails(row.Item("ID"), row.Item("Quantity")))
        'Next
        pc_programreadiness_requirements = Nothing
        pc_scheduling_requirements = Nothing
        pc_total_balanced_requirements = Nothing
        harns = Nothing
        bom = Nothing
    End Sub

    Public Property Horizon As Date
    Public Property LastChangeDate As Date
    Public Property StartDate As Date
    Public Property Items As New Dictionary(Of String, ProductionPlanItem)
    Private Sub GetRequirements()
        'vw_Sch_SAP_Upload_Balance
        'vw_SchPR_DailyProductionPlanBalance
        pc_total_balanced_requirements = SQL.Current.GetDatatable(String.Format("SELECT Material, [Date], PlanQuantity, RealQuantity FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY Material, [Date];", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")))
        Me.LastChangeDate = SQL.Current.GetDate("SELECT MAX([Date]) AS [Date] FROM (SELECT MAX([Date]) AS [Date] FROM Sch_DailyProductionPlanMovements UNION ALL SELECT MAX([Date]) AS [Date] FROM PR_ProductionPlanMovements) AS MD", Delta.CurrentDate)
        thread_A_finished = True
    End Sub

    Private Sub GetBOM()
        'bom = SQL.Current.GetDatatable(String.Format("SELECT Material, Partnumber, SUM(Quantity) AS Quantity FROM vw_Sys_BOM_Stg2 WHERE Material IN (SELECT DISTINCT Material FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}')  GROUP BY Material, Partnumber HAVING (SUM(Quantity) > 0) ORDER BY Material,Partnumber;", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd"))) 'CONSULTAR DE ESTA MANERA STG2 ES MAS RAPIDO QUE STG3
        bom = SQL.Current.GetDatatable(String.Format("SELECT Material, Partnumber,Quantity FROM Sys_CurrentBOM WHERE Material IN (SELECT DISTINCT Material FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}') ORDER BY Material,Partnumber;", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd"))) 'CONSULTAR DE ESTA MANERA STG2 ES MAS RAPIDO QUE STG3
        thread_B_finished = True
    End Sub
    Private Sub GetHarns()
        'pc_scheduling_requirements = SQL.Current.GetDatatable(String.Format("SELECT ID, Material, Board, [Date], Quantity FROM vw_Sch_DailyProductionPlan WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY Material, Board, [Date];", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")))
        'pc_programreadiness_requirements = SQL.Current.GetDatatable(String.Format("SELECT ID, Material, [Date], Quantity FROM vw_PR_ProductionPlan WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY Material, Board, [Date];", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")))
        harns = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sch_Materials WHERE IsHarn = 1 AND Material IN (SELECT DISTINCT Material FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}');", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd")))
        thread_C_finished = True
    End Sub
    Public Sub Update(horizon As Date)
        Me.Horizon = horizon
        Me.StartDate = LastMonday(Delta.CurrentDate)
        pc_total_balanced_requirements = SQL.Current.GetDatatable(String.Format("SELECT Material, [Date], PlanQuantity, RealQuantity FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}' ORDER BY Material, [Date];", Me.StartDate.ToString("yyyy-MM-dd"), horizon.ToString("yyyy-MM-dd")))
        Me.LastChangeDate = SQL.Current.GetDate("SELECT MAX([Date]) AS [Date] FROM (SELECT MAX([Date]) AS [Date] FROM Sch_DailyProductionPlanMovements UNION ALL SELECT MAX([Date]) AS [Date] FROM PR_ProductionPlanMovements) AS MD", Delta.CurrentDate)
        harns = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sch_Materials WHERE IsHarn = 1 AND Material IN (SELECT DISTINCT Material FROM vw_SchPR_DailyProductionPlanBalance WHERE [Date] BETWEEN '{0}' AND '{1}');", Me.StartDate.ToString("yyyy-MM-dd"), horizon.ToString("yyyy-MM-dd")))

        Dim harn_list As New Dictionary(Of String, Harn)
        Dim no_bom_list As New List(Of String)

        For Each row As DataRow In harns.Rows
            If Me.Items.ContainsKey(row.Item("Material")) Then
                Dim bom As BOM = Me.Items.Item(row.Item("Material")).Harn.BOM.Clone() 'UTILIZAR EL BOM QUE YA SE DESCARGO, ADVERTENCIA: SI EL BOM CAMBIA ESTE NO SE REFLEJARA AL UTILIZAR ESTE METODO
                harn_list.Add(row.Item("Material"), New Harn(row.Item("Material"), row.Item("CustomerPN"), row.Item("Description"), row.Item("StdPack"), New Business(row.Item("Business"), ""), row.Item("Class"), Delta.NullReplace(row.Item("MRP"), ""), bom))
            Else
                harn_list.Add(row.Item("Material"), New Harn(row.Item("Material"), row.Item("CustomerPN"), row.Item("Description"), row.Item("StdPack"), New Business(row.Item("Business"), ""), row.Item("Class"), Delta.NullReplace(row.Item("MRP"), ""), New BOM(row.Item("Material"))))
                no_bom_list.Add(row.Item("Material"))
            End If
        Next

        If no_bom_list.Count > 0 Then 'SE REALIZA ESTA OPERACION PARA NO TENER QUE ACTUALIZAR EL BOM CONSTANTEMENTE, YA QUE ES EL QUERY MAS TARDADO
            Dim bom_list As New Dictionary(Of String, BOM)
            bom = SQL.Current.GetDatatable(String.Format("SELECT Material, Partnumber, Quantity FROM Sys_CurrentBOM WHERE Material IN ('{0}') AND Quantity > 0 ORDER BY Material,Partnumber;", String.Join("','", no_bom_list)))
            For Each row As DataRow In bom.Rows 'LA TABLA BOM ESTA SORTEADA POR MATERIAL Y COMPONENTE
                If Not bom_list.ContainsKey(row.Item("Material")) Then
                    bom_list.Add(row.Item("Material"), New BOM(row.Item("Material")))
                End If
                bom_list.Item(row.Item("Material")).Items.Add(row.Item("Partnumber"), New BOMItem(row.Item("Partnumber"), row.Item("Quantity")))
            Next
            For Each b In bom_list.Values
                If harn_list.ContainsKey(b.Material) Then
                    harn_list.Item(b.Material).BOM = b.Clone()
                End If
            Next
        End If

        'VACIAR INFORMACION ANTIGUA
        For Each i In Me.Items
            If harn_list.ContainsKey(i.Value.Harn.Material) Then
                Me.Items.Item(i.Value.Harn.Material).Harn = harn_list.Item(i.Value.Harn.Material)
            End If
            i.Value.Items.Clear()
        Next

        For Each row As DataRow In pc_total_balanced_requirements.Rows
            If harn_list.ContainsKey(row.Item("Material")) Then
                If Not Me.Items.ContainsKey(row.Item("Material")) Then
                    Me.Items.Add(row.Item("Material"), New ProductionPlanItem(harn_list.Item(row.Item("Material"))))
                End If
                Me.Items.Item(row.Item("Material")).Items.Add(row.Item("Date"), New ProductionPlanItemDate(row.Item("Date"), row.Item("PlanQuantity"), row.Item("RealQuantity")))
            End If
        Next
    End Sub

    Public Sub Update(material_list As List(Of String)) 'ESTA FUNCION SOLO ACTUALIZA EL BALANCE DE LOS ARNESES ENVIADOS
        pc_total_balanced_requirements = SQL.Current.GetDatatable(String.Format("SELECT Material, [Date], PlanQuantity, RealQuantity FROM vw_SchPR_DailyProductionPlanBalance WHERE Material IN ('{2}') AND [Date] BETWEEN '{0}' AND '{1}' ORDER BY Material, [Date];", Me.StartDate.ToString("yyyy-MM-dd"), Me.Horizon.ToString("yyyy-MM-dd"), String.Join("','", material_list)))
        For Each i In material_list
            Me.Items.Item(i).Items.Clear() 'VACIAR LA LISTA DE LOS REQUERIMIENTOS
        Next
        For Each row As DataRow In pc_total_balanced_requirements.Rows 'RECORRER EL REQUERIMIENTO OBTENIDO Y VACIAR EN CADA ITEM
            Me.Items.Item(row.Item("Material")).Items.Add(row.Item("Date"), New ProductionPlanItemDate(row.Item("Date"), row.Item("PlanQuantity"), row.Item("RealQuantity")))
        Next
        pc_total_balanced_requirements = Nothing
    End Sub
    Public Function Clone() As ProductionPlan
        Dim pp_clone As New ProductionPlan
        pp_clone.LastChangeDate = Me.LastChangeDate
        pp_clone.StartDate = Me.StartDate
        pp_clone._horizon = Me._horizon
        For Each i In Me.Items
            pp_clone.Items.Add(i.Key, i.Value.Clone())
        Next
        Return pp_clone
    End Function
End Class

Public Class ProductionPlanItem
    Public Sub New(harn As Harn)
        Me.Harn = harn
    End Sub
    Public Property Harn As Harn
    Public Property Items As New Dictionary(Of Date, ProductionPlanItemDate) 'ESTA ORDENADO POR FECHA ASCENDENTE
    Public Function Accumulated([to] As Date) As Integer
        If [to].Date < Delta.CurrentDate.Date Then 'SI ES UNA FECHA PASADA DEBE REGRESAR 0
            Return 0
        ElseIf [to].Date = Delta.CurrentDate.Date Then 'SI ES LA FECHA ACTUAL DEBE CALCULAR LAS PIEZAS SOBREPRODUCIDAS O PENDIENTES PARA SUMARLAS AL PLAN DEL DIA
            Dim sum_balance = Aggregate i In Me.Items
                       Where i.Key.Date.Date <= [to].Date
                       Into Sum(i.Value.Balance)
            sum_balance = Delta.NullReplace(sum_balance, 0)
            If sum_balance > 0 Then 'SE CONSTRUYERON DE MAS
                Return 0
            Else 'PLAN AL 100% O NO SE CUMPLIO EL PLAN
                Return Math.Abs(sum_balance)
            End If
        ElseIf Not Me.Items.ContainsKey([to].Date) OrElse (Me.Items.ContainsKey([to].Date) AndAlso Me.Items.Item([to].Date).Balance = 0) Then 'SI LA FECHA ES FUTURA Y NO TIENE PLAN REGRESA CERO
            Return 0
        Else 'SI ES UNA FECHA FUTURA Y TIENE PLAN DEBE CALCULAR LAS PIEZAS SOBREPRODUCIDAS PARA RESTARLAS
            Dim sum_balance = Aggregate i In Me.Items
                       Where i.Key.Date.Date < [to].Date
                       Into Sum(i.Value.Balance)
            sum_balance = Delta.NullReplace(sum_balance, 0)
            If sum_balance > 0 AndAlso sum_balance - Me.Items([to]).Plan > 0 Then 'SE CONSTRUYERON DE MAS AUN PARA CUBRIR LO DEL DIA
                Return 0
            ElseIf sum_balance > 0 AndAlso sum_balance - Me.Items([to]).Plan < 0 Then 'SE CONSTRUYERON DE MAS PERO NO SUFICIENTES PARA CUBRIR LO DEL DIA
                Return Me.Items([to]).Plan - sum_balance
            Else 'NO SE HAN CONSTRUIDO DE MAS
                Return Me.Items.Item([to]).Plan
            End If
        End If
    End Function

    Public Function PastDue() As Integer
        Dim sum_balance = Aggregate i In Me.Items
                       Where i.Key.Date.Date <= Delta.CurrentDate.AddDays(-1).Date
                       Into Sum(i.Value.Balance)
        sum_balance = Delta.NullReplace(sum_balance, 0)
        If sum_balance > 0 Then 'SE CONSTRUYERON DE MAS
            Return 0
        Else 'PLAN AL 100% O NO SE CUMPLIO EL PLAN
            Return Math.Abs(sum_balance)
        End If
    End Function

    Public Function Clone() As ProductionPlanItem
        Dim ppi_clone As New ProductionPlanItem(Me.Harn)
        For Each i In Me.Items
            ppi_clone.Items.Add(i.Key, i.Value.Clone)
        Next
        Return ppi_clone
    End Function
End Class

Public Class ProductionPlanItemDate
    Private Sub New()

    End Sub
    Public Sub New([date] As Date, plan As Integer, real As Integer)
        Me.Date = [date]
        Me.Plan = plan
        Me.Real = real
    End Sub
    Public Property [Date] As Date
    Public Property Plan As Integer
    Public Property Real As Integer
    Public Property SchedulingItems As New Dictionary(Of Integer, ProductionPlanItemDateDetails)
    Public Property ProgramReadinessItems As New Dictionary(Of Integer, ProductionPlanItemDateDetails)
    Public ReadOnly Property Balance As Integer
        Get
            Return Me.Real - Me.Plan
        End Get
    End Property

    Public Function Clone() As ProductionPlanItemDate
        Dim ppid_clone As New ProductionPlanItemDate
        ppid_clone.Date = Me.Date
        ppid_clone.Plan = Me.Plan
        ppid_clone.Real = Me.Real
        For Each i In Me.SchedulingItems
            ppid_clone.SchedulingItems.Add(i.Key, i.Value.Clone())
        Next
        For Each i In Me.ProgramReadinessItems
            ppid_clone.ProgramReadinessItems.Add(i.Key, i.Value.Clone())
        Next
        Return ppid_clone
    End Function
End Class

Public Class ProductionPlanItemDateDetails
    Implements ICloneable

    Public Sub New(id As Integer, board As String, quantity As Integer)
        Me.ID = id
        Me.Board = board
        Me.Quantity = quantity
    End Sub
    Public Sub New(id As Integer, quantity As Integer)
        Me.ID = id
        Me.Quantity = quantity
    End Sub
    Public Property ID As Integer
    Public Property Board As String
    Public Property Quantity As Integer

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function
End Class
