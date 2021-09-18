Public Class CDR
    Private Shared _routes As List(Of Route)
    Private Shared _shifts As List(Of Shift)
    Private Shared _lastshift As String
    Public Shared Sub CleanRoutesInfo()
        _routes = Nothing
    End Sub

    Public Shared ReadOnly Property Routes As List(Of Route)
        'SE CARGA LA INFORMACION DE TODAS LAS RUTAS NO CONSUMIR RECURSOS DE RED CADA VEZ QUE SE QUIERA CONSULTAR COMO ESTA LA RUTA
        Get
            'VERIFICAR SI NO SE HAN CARGADO LAS RUTAS O YA CAMBIO LA FECHA
            If _routes Is Nothing OrElse _lastshift <> CurrentShift Then
                _lastshift = CurrentShift
                Dim cdr_conn As New SQL(SQL.Current.ConnectionString)
                _shifts = Nothing 'PARA RECARGAR LOS TURNOS
                _routes = New List(Of Route)
                For Each r As DataRow In cdr_conn.GetDatatable(String.Format("SELECT R.*,ISNULL(FullName,'') AS FullName FROM CDR_Routes AS R LEFT OUTER JOIN Smk_Operators AS O ON R.Operator = O.Badge WHERE R.Shift = dbo.Sys_Shift(GETDATE()) AND Warehouse = '{0}';", SQL.Current.GetString("Warehouse", "CDR_AuthorizedCheckpoints", "MachineName", Environment.MachineName, ""))).Rows
                    _routes.Add(New Route(r.Item("Route"), r.Item("Description"), r.Item("Shift"), r.Item("Warehouse"), r.Item("Operator"), r.Item("FullName"), r.Item("ContainersLoopGoal"), r.Item("ContainersDailyGoal"), r.Item("Loops"), r.Item("PrimaryWalkings"), r.Item("SecondaryWalkings"), r.Item("ExtraPaid")))
                Next
            End If
            Return _routes
        End Get
    End Property

    Public Shared ReadOnly Property Shifts As List(Of Shift)
        Get
            If _shifts Is Nothing Then
                _shifts = New List(Of Shift)
                Dim cdr_conn As New SQL(SQL.Current.ConnectionString)
                For Each r As DataRow In cdr_conn.GetDatatable("SELECT * FROM Sys_Shifts ORDER BY Shift").Rows
                    Dim s As New Shift
                    s.Name = r.Item("Shift")
                    s.Start = New Date(Now.Year, Now.Month, Now.Day, TimeSpan.Parse(r.Item("Start").ToString).Hours, TimeSpan.Parse(r.Item("Start").ToString).Minutes, TimeSpan.Parse(r.Item("Start").ToString).Seconds)
                    s.Ending = New Date(Now.Year, Now.Month, Now.Day, TimeSpan.Parse(r.Item("End").ToString).Hours, TimeSpan.Parse(r.Item("End").ToString).Minutes, TimeSpan.Parse(r.Item("End").ToString).Seconds)
                    s.Seconds = r.Item("CDRSeconds")
                    _shifts.Add(s)
                Next
            End If
            Return _shifts
        End Get
    End Property

    Public Shared ReadOnly Property CurrentShift As String
        Get
            Dim connection As New SQL(SQL.Current.ConnectionString)
            Dim current_shift As String = connection.GetString("SELECT dbo.Sys_Shift(GETDATE());")
            connection = Nothing
            Return current_shift
        End Get
    End Property

    Public Class Shift
        Public Property Name As String
        Public Property Start As Date
        Public Property Ending As Date
        Public Property Seconds As Integer
    End Class

    Public Class Route
        Dim _status As Status
        Dim _loop As Integer = 0
        Sub New(route As Integer, name As String, shift As String, warehouse As String, badge As String, operatorname As String, containers_loop As Integer, containers_daily As Integer, loops As Integer, primarywalkings As Integer, secondarywalkings As Integer, extrapaid As Integer)
            Me.Route = route
            Me.Name = name
            Me.Shift = shift
            Me.Warehouse = warehouse
            Me.Badge = badge
            Me.OperatorName = operatorname
            Me.ContainersLoopGoal = containers_loop
            Me.ContainersDailyGoal = containers_daily
            Me.LoopsGoal = loops
            Me.ExtraPaid = extrapaid
            Me.PrimaryWalkings = primarywalkings
            Me.SecondaryWalkings = secondarywalkings

            Dim cdr_conn As New SQL(SQL.Current.ConnectionString)
            Me.Started = cdr_conn.Exists(String.Format("SELECT ID FROM CDR_StartingWorkRegister WHERE [Route] = {0} AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE())", Me.Route))
            Me.ScannedKanbans = New DataTable
            Me.ScannedKanbans.Columns.Add("ID", GetType(Integer))
            Me.ScannedKanbans.Columns.Add("Result")
            Me.ScannedKanbans.Columns.Add("Kanban", GetType(String), "'S' + SUBSTRING('0000000000' + CONVERT(ID,'System.String'),LEN(CONVERT(ID,'System.String')) + 1,10)")
            Me.ScannedKanbans.PrimaryKey = {Me.ScannedKanbans.Columns("ID")}

            If Me.Started Then
                _loop = cdr_conn.GetScalar(String.Format("SELECT TOP 1 ID FROM CDR_RoutesLoopRegister WHERE Route = {0} AND OutDate IS NULL ORDER BY InDate DESC", Me.Route), 0)
                If _loop = 0 Then
                    _status = CDR.Status.OUT
                Else
                    _status = CDR.Status.IN
                    For Each k As DataRow In cdr_conn.GetDatatable(String.Format("SELECT Kanban,Result FROM CDR_RoutesLoopKanbans WHERE LoopID = {0} ORDER BY ID ASC", _loop)).Rows
                        Me.ScannedKanbans.Rows.Add(k.Item("Kanban"), k.Item("Result"))
                    Next
                End If
            Else
                _status = CDR.Status.OUT
            End If

            Dim loops_done As DataTable = cdr_conn.GetDatatable(String.Format("SELECT ID,InDate,OutDate,C.Kanbans AS Containers FROM CDR_RoutesLoopRegister AS L INNER JOIN (SELECT LoopID,COUNT(Kanban) AS Kanbans FROM CDR_RoutesLoopKanbans GROUP BY LoopID) AS C ON L.ID = C.LoopID WHERE CONVERT(DATE,InDate) = CONVERT(DATE,GETDATE()) AND [Route] = {0} AND Badge = '{1}' ORDER BY ID ASC;", Me.Route, Me.Badge))
            For Each l As DataRow In loops_done.Rows
                If IsDBNull(l.Item("OutDate")) Then
                    Me.Loops.Add(New [Loop](l.Item("ID"), l.Item("InDate"), l.Item("Containers")))
                Else
                    Me.Loops.Add(New [Loop](l.Item("ID"), l.Item("InDate"), l.Item("OutDate"), l.Item("Containers")))
                End If
            Next
        End Sub
        Public Sub GoIn()
            Dim conn As New SQL(SQL.Current.ConnectionString)
            If Me.Status = CDR.Status.OUT Then
                conn.Insert("CDR_RoutesLoopRegister", {"Route", "Badge"}, {Me.Route, Me.Badge})
                _loop = conn.GetScalar("MAX(ID)", "CDR_RoutesLoopRegister", {"Route", "Badge"}, {Me.Route, Me.Badge})
                Me.Loops.Add(New [Loop](_loop, Delta.CurrentDate, 0))
                _status = CDR.Status.IN
            End If
            conn = Nothing
        End Sub

        Public Sub GoOut()

            If Me.Status = CDR.Status.IN Then
                Dim conn As New SQL(SQL.Current.ConnectionString)
                'VALIDAR SI EL SISTEMA DEBE DESCONTAR MATERIAL POR CUESTION DE LA RUTA
                If Parameter("CDR_DiscountByKanban") Then
                    For Each k As DataRow In Me.ScannedKanbans.Rows
                        'OMITIR VOLVER A BUSCAR SI EXISTE LA KANBAN
                        If k.Item("Result") = "OK" Then
                            Dim kanban As Hashtable = conn.GetRecord({"Partnumber", "Pieces"}, "CDR_Kanbans", "ID", k.Item("id"))
                            Dim current_serial As String = SMK.CurrentSerial(kanban("partnumber"))
                            'DESCONTAR MATERIAL HASTA QUE ESTE COMPLETA LA CANTIDAD O NO EXISTA NINGUNA SERIE EN SERVICIO
                            While current_serial <> ""
                                Dim serial As New Serialnumber(current_serial)
                                If serial.CurrentQuantity >= kanban("pieces") Then
                                    serial.DiscountByRoute(kanban("pieces"), Me.Badge)
                                    current_serial = ""
                                Else
                                    kanban("pieces") = kanban("pieces") - serial.CurrentQuantity
                                    serial.DiscountByRoute(serial.CurrentQuantity, Me.Badge)
                                    current_serial = SMK.CurrentSerial(kanban("partnumber"))
                                End If
                                serial = Nothing
                            End While
                            kanban = Nothing
                        End If
                    Next
                End If
                conn.Execute("UPDATE CDR_RoutesLoopRegister SET OutDate = GETDATE() WHERE ID = " & Me.CurrentLoopID)
                Me.Loops.Find(Function(f) f.ID = _loop).OutDate = Delta.CurrentDate
                Me.Loops.Find(Function(f) f.ID = _loop).Completed = True
                Me.ScannedKanbans.Rows.Clear()
                _loop = 0
                _status = CDR.Status.OUT
                conn = Nothing
            End If
        End Sub

        Public Sub RegisterScannedKanban(id As Integer, result As String)
            Dim conn As New SQL(SQL.Current.ConnectionString)
            conn.Insert("CDR_RoutesLoopKanbans", {"LoopID", "Kanban", "Result"}, {Me.CurrentLoopID, id, result})
            Me.ScannedKanbans.Rows.Add(id, result)
            Me.Loops.Find(Function(f) f.ID = Me.CurrentLoopID).Containers += 1
            conn = Nothing
        End Sub
        Public Property Name As String
        Public Property Route As Integer
        Public Property ContainersLoopGoal As Integer
        Public Property ContainersDailyGoal As Integer
        Public Property LoopsGoal As Integer
        Public ReadOnly Property LoopsCounter As Integer
            Get
                Return Me.Loops.Count
            End Get
        End Property
        Public Property ExtraPaid As Integer
        Public Property Shift As String
        Public Property Badge As String
        Public Property OperatorName As String
        Public Property PrimaryWalkings As Integer
        Public Property SecondaryWalkings As Integer
        Public Property Started As Boolean 'INDICA SI LA RUTA A SIDO INICIADA EN EL TURNO (HECHO EL CHECKLIST INICIAL)
        Public ReadOnly Property Status As Status 'INDICA SI LA RUTA ESTA DENTRO O FUERA DE SMK
            Get
                Return _status
            End Get
        End Property
        Public Property ScannedKanbans As DataTable 'ALMACENA LAS KANBANS ESCANEADAS EN LA VUELTA ACTUAL
        Public ReadOnly Property CurrentLoopID As Integer 'INDICA EL ID DE LA VUELTA ACTUAL EN CASO DE QUE LA RUTA SE ENCUENTRE DENTRO DE SMK, SINO DEBERIA DEVOLVER 0
            Get
                Return _loop
            End Get
        End Property
        Public Property Warehouse As String
        Public ReadOnly Property MovedContainers As Integer
            Get
                Return Me.Loops.Sum(Function(f) f.Containers)
            End Get
        End Property

        Public Property Loops As New List(Of [Loop])
    End Class

    Public Class [Loop]
        Public Sub New(id As Integer, in_date As Date, containers As Integer)
            Me.ID = id
            Me.InDate = in_date
            Me.Containers = containers
            Me.Completed = False
        End Sub
        Public Sub New(id As Integer, in_date As Date, out_date As Date, containers As Integer)
            Me.ID = id
            Me.InDate = in_date
            Me.OutDate = out_date
            Me.Containers = containers
            Me.Completed = True
        End Sub
        Public Property ID As Integer
        Public Property InDate As Date
        Public Property OutDate As Date
        Public Property Containers As Integer
        Public Property Completed As Boolean
    End Class

    Public Enum Status
        [IN]
        [OUT]
    End Enum

    Public Shared Function BuildKanban(code As Object, partnumber As Object, loc_line As Object, slot As Object, side As Object, section As Object, board As Object, kit As Object, route As Object, description As Object, quantity As Object, container As Object, [index] As Object, business As Object, rack As Object, [local] As Object, [date] As Object)
        Dim z As String = CDR.Query("zpl_kanban")
        z = z.Replace("@code", RNull(code))
        z = z.Replace("@partnumber", RNull(partnumber))
        z = z.Replace("@linea", String.Format("{0}-{1}-{2}", RNull(slot), RNull(side), RNull(section)))
        z = z.Replace("@loc_linea", RNull(loc_line))
        z = z.Replace("@tablero", RNull(board))
        z = z.Replace("@kit", RNull(kit))
        z = z.Replace("@ruta", RNull(route))
        z = z.Replace("@descripcion", RNull(description))
        z = z.Replace("@cantidad", RNull(quantity))
        z = z.Replace("@contenedor", RNull(container))
        z = z.Replace("@tarjeta", RNull([index]))
        z = z.Replace("@total", 2)
        z = z.Replace("@negocio", RNull(business))
        z = z.Replace("@rack", RNull(rack))
        Dim loc As String = RNull([local])
        If loc.Length = 8 Then
            z = z.Replace("@localizacion", String.Format("{0}-{1}-{2}-{3}", Strings.Left(loc, 2), Strings.Left(Strings.Right(loc, 6), 2), Strings.Left(Strings.Right(loc, 4), 2), Strings.Right(loc, 2)))
        Else
            z = z.Replace("@localizacion", loc)
        End If
        z = z.Replace("@rev", RNull([date]))
        Return z
    End Function

    Private Shared Function RNull(value As Object) As Object
        If IsDBNull(value) Then
            Return ""
        Else
            Return value
        End If
    End Function

    Public Shared Function IsKanban(code As String) As Boolean
        If System.Text.RegularExpressions.Regex.IsMatch(code.ToUpper.Trim, "S[0-9]{8,10}$") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function KanbanID(code As String) As Integer
        Return CInt(code.ToUpper.Trim.Remove(0, 1))
    End Function

    Public Shared Function Query(name As String) As String
        Select Case name.ToLower
            Case "partlocation"
                Return "SELECT dbo.CDR_GetLocation('{0}','{1}');"

            Case "partrack"
                Return "SELECT dbo.CDR_GetRack('{0}','{1}');"

            Case "recalculatekanban_both_board"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' AND E.board = '{1}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2 WHERE PC.business='{0}' AND E.board = '{1}' ORDER BY E.Kit,E.Loc,i,Code;"

            Case "recalculatekanban_both_board_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' AND E.board = '{1}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2 WHERE PC.business='{0}' AND E.board = '{1}' ORDER BY E.Kit,E.Loc,i,Code;"

            Case "recalculatekanban_both_business"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2 WHERE PC.business='{0}'  ORDER BY E.Board,E.Kit,E.Loc,i,code;"

            Case "recalculatekanban_both_business_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc,i,code;"

            Case "recalculatekanban_use_board"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' AND E.board='{1}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_board_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' AND E.board='{1}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_business"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_business_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Route,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,MAX(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "sapvsloj_description"
                Return "SELECT E.partnumber,SUM(quantity) AS quantity,MAX(description) AS description FROM CDR_Engineering AS E LEFT OUTER JOIN Sys_RawMaterial AS RW ON E.Partnumber = RW.Partnumber WHERE E.Board='{0}' GROUP BY E.Partnumber;"

            Case "zpl_kanban"
                Return "^XA  ^PW1200   ^JZY   ^LH40,20  ^FWB ^FO5,70^BCB,40,Y,N,N,N^FD@code^FS^FO700,135^BCB,40,N,N,N,N^FD@partnumber^FS ^FO95,80^A0,25,25^FDNUMERO DE PARTE^FS  ^FO140,5^FB360,1,0,C,0^A0,80,80^FD@partnumber^FS  ^FO215,135^A0,30,30^FDPUNTO DE USO^FS  ^FO215,15^A0,30,30^FDRUTA^FS  ^FO255,290^A0,15,15^FDLOC LINEA^FS  ^FO255,120^A0,25,25^FDDIRECCION^FS  ^FO315,270^FB100,2,0,C,0^A0,50,50^FD@loc_linea^FS  ^FO280,90^GB1,180,60^FS  ^FO300,90^FB180,1,0,C,0^A0,40,40^FR^FD@tablero^FS  ^FO355,90^FB180,1,0,C,0^A0,40,40^FD@kit^FS  ^FO290,5^FB85,2,0,C,0^A0,80,80^FD@ruta^FS  ^FO400,125^A0,20,20^FDDESCRIPCION^FS  ^FO420,5^FB360,2,0,C,0^A0,20,20^FD@descripcion^FS  ^FO462,22^A0,18,18^FDCANTIDAD      TIPO CTN      TARJETA      TOTAL^FS  ^FO495,265^FB95,1,0,C,0^A0,40,40^FD@cantidad^FS  ^FO495,170^FB95,1,0,C,0^A0,40,40^FD@contenedor^FS  ^FO495,80^FB95,1,0,C,0^A0,40,40^FD@tarjeta^FS  ^FO495,5^FB75,1,0,C,0^A0,40,40^FD@total^FS  ^FO533,5^GB1,250,60^FS  ^FO550,5^FB250,1,0,C,0^A0,45,45^FR^FD@negocio^FS  ^FO555,265^A0,25,25^FDNEGOCIO^FS  ^FO605,275^A0,30,30^FDRACK^FS  ^FO605,40^A0,30,30^FDLOCALIZACION^FS  ^FO645,260^FB100,1,0,C,0^A0,55,55^FD@rack^FS  ^FO650,20^A0,35,35^FD@localizacion^FS   ^FO700,0^FB140,2,0,R,0^A0,25,25^FD@rev^FS  ^FO80,5^GB1,360,4^FS  ^FO120,5^GB1,360,4^FS   ^FO200,5^GB1,360,4^FS  ^FO240,5^GB1,360,4^FS   ^FO280,90^GB1,275,2^FS  ^FO390,5^GB1,360,4^FS  ^FO450,5^GB1,360,4^FS  ^FO480,5^GB1,360,4^FS  ^FO530,5^GB1,360,4^FS  ^FO635,5^GB1,360,4^FS  ^FO690,5^GB1,360,4^FS  ^FO240,270^GB150,2,1^FS  ^FO200,90^GB190,2,1^FS  ^FO450,80^GB80,2,1^FS  ^FO450,170^GB80,2,1^FS  ^FO450,260^GB80,2,1^FS  ^FO590,255^GB100,2,1^FS  ^FO590,5^GB1,360,4^FS  ^XZ"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Sub Print(kanbans As DataTable, [double] As Boolean)
        Try
            If Not IsNothing(kanbans) Then
                If kanbans.Rows.Count > 0 Then
                    Dim z_kanbans As String = ""
                    For Each r As DataRow In kanbans.Rows
                        z_kanbans &= CDR.BuildKanban(r("Code"), r("Partnumber"), r("EngLoc"), r("Slot"), r("Side"), r("Section"), r("Board"), r("Kit"), r("Route"), r("Description"), r("Pieces"), r("Container"), r("Index"), r("Business"), r("Rack"), r("Local"), r("Date"))
                        If [double] Then
                            z_kanbans &= CDR.BuildKanban(r("Code"), r("Partnumber"), r("EngLoc"), r("Slot"), r("Side"), r("Section"), r("Board"), r("Kit"), r("Route"), r("Description"), r("Pieces"), r("Container"), r("Index"), r("Business"), r("Rack"), r("Local"), r("Date"))
                        End If
                    Next
                    ZPL.PrintTo(z_kanbans)
                    FlashAlerts.ShowConfirm("Impreso.")
                Else
                    FlashAlerts.ShowError("Nada para imprimir.")
                End If
            Else
                FlashAlerts.ShowError("Error al tratar de imprimir.")
            End If
        Catch ex As Exception
            FlashAlerts.ShowError("Surgio un error al tratar de imprimir: " & ex.Message)
        End Try
    End Sub
End Class
