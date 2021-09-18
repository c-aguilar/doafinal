Public Class CDR
    Private Shared _routes As List(Of Route)
    Private Shared _carts As List(Of Cart)
    Private Shared _shifts As List(Of Shift)
    Private Shared _lastshift As String
    Public Shared Sub CleanRoutesInfo()
        _routes = Nothing
    End Sub

    Public Shared ReadOnly Property Routes As List(Of Route)
        'SE CARGA LA INFORMACION DE TODAS LAS RUTAS NO CONSUMIR RECURSOS DE RED CADA VEZ QUE SE QUIERA CONSULTAR COMO ESTA LA RUTA
        Get
            'VERIFICAR SI NO SE HAN CARGADO LAS RUTAS O YA CAMBIO LA FECHA
            If _routes Is Nothing OrElse _lastshift <> CurrentShift() Then
                _lastshift = CurrentShift()
                _shifts = Nothing 'PARA RECARGAR LOS TURNOS
                _routes = New List(Of Route)
                For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT R.*,ISNULL(O.FullName,'') AS FullName FROM CDR_Routes AS R LEFT OUTER JOIN Smk_Operators AS O ON R.Operator = O.Badge WHERE R.Shift = dbo.Sys_Shift(GETDATE()) AND Warehouse = '{0}';", My.Settings.Warehouse)).Rows
                    _routes.Add(New Route(r.Item("Route"), r.Item("Description"), r.Item("Shift"), r.Item("Warehouse"), r.Item("Operator"), r.Item("FullName"), r.Item("ContainersLoopGoal"), r.Item("ContainersDailyGoal"), r.Item("Loops"), r.Item("PrimaryWalkings"), r.Item("SecondaryWalkings"), r.Item("ExtraPaid")))
                Next
            End If
            Return _routes
        End Get
    End Property

    Public Shared ReadOnly Property Carts As List(Of Cart)
        'SE CARGA LA INFORMACION DE TODAS LAS RUTAS NO CONSUMIR RECURSOS DE RED CADA VEZ QUE SE QUIERA CONSULTAR COMO ESTA LA RUTA
        Get
            'VERIFICAR SI NO SE HAN CARGADO LAS RUTAS O YA CAMBIO LA FECHA
            If _carts Is Nothing OrElse _carts.Count = 0 Then
                _lastshift = CurrentShift()
                _shifts = Nothing 'PARA RECARGAR LOS TURNOS
                _carts = New List(Of Cart)
                For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT * FROM DDR_Carts WHERE Warehouse = '{0}' AND Active = 1;", My.Settings.Warehouse)).Rows
                    _carts.Add(New Cart(r.Item("ID"), r.Item("Description"), r.Item("Warehouse")))
                Next
            End If
            Return _carts
        End Get
    End Property

    Public Shared Sub RefreshRoute(id As Integer)
        If _routes IsNot Nothing Then
            If _routes.Exists(Function(x) x.Route = id) Then
                _routes.Remove(_routes.First(Function(x) x.Route = id))
            End If
            For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT R.*,ISNULL(O.FullName,'') AS FullName FROM CDR_Routes AS R LEFT OUTER JOIN Smk_Operators AS O ON R.Operator = O.Badge WHERE R.Shift = dbo.Sys_Shift(GETDATE()) AND R.Route = {0};", id)).Rows
                _routes.Add(New Route(r.Item("Route"), r.Item("Description"), r.Item("Shift"), r.Item("Warehouse"), r.Item("Operator"), r.Item("FullName"), r.Item("ContainersLoopGoal"), r.Item("ContainersDailyGoal"), r.Item("Loops"), r.Item("PrimaryWalkings"), r.Item("SecondaryWalkings"), r.Item("ExtraPaid")))
            Next
        End If
    End Sub


    Public Shared ReadOnly Property Shifts As List(Of Shift)
        Get
            If _shifts Is Nothing Then
                _shifts = New List(Of Shift)
                For Each r As DataRow In SQL.Current.GetDatatable("SELECT * FROM Sys_Shifts ORDER BY Shift").Rows
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

    Public Class Shift
        Public Property Name As String
        Public Property Start As Date
        Public Property Ending As Date
        Public Property Seconds As Integer
    End Class

    Public Class Cart
        Dim _status As Status = CDR.Status.WaitingIn
        Dim _loop As Integer = 0
        Sub New(id As String, description As String, warehouse As String)
            ScannedKanbansTable.Columns.Add("KanbanID", GetType(Integer))
            ScannedKanbansTable.Columns.Add("Result", GetType(Boolean))

            Me.ID = id
            Me.Description = description
            Me.Warehouse = warehouse
            Me.Refresh()
        End Sub
        Public Sub Refresh()
            Me.ScannedKanbansTable.Clear()
            Me.ScannedKanbans.Clear()
            Dim current_loop As Hashtable = SQL.Current.GetRecord(String.Format("SELECT TOP 1 * FROM DDR_CartsLoopRegister WHERE Cart = '{0}' ORDER BY ID DESC", Me.ID))
            If current_loop IsNot Nothing AndAlso current_loop.Count > 0 Then
                _loop = current_loop.Item("id")
                Me.CollectingBadge = current_loop.Item("collectingbadge")
                Me.ScannigInBadge = current_loop.Item("scanninginbadge")
                Me.PickingBadge = current_loop.Item("pickingbadge")
                Me.ScanningOutBadge = current_loop.Item("scanningoutbadge")
                Me.DeliveringBadge = current_loop.Item("deliveringbadge")

                Me._status = CartStatus(current_loop.Item("status"))
                Select Case Me.Status
                    Case CDR.Status.WaitingIn
                        Me.OperatorName = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.CollectingBadge, "")
                        Me.StatusTime = current_loop.Item("arrivaldate")
                    Case CDR.Status.In
                        Me.OperatorName = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.ScannigInBadge, "")
                        Me.StatusTime = current_loop.Item("indate")
                    Case CDR.Status.Picking
                        Me.OperatorName = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.PickingBadge, "")
                        Me.StatusTime = current_loop.Item("pickingdate")
                    Case CDR.Status.Out
                        Me.StatusTime = Delta.CurrentDate
                    Case CDR.Status.WaitingDelivery
                        Me.OperatorName = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.ScanningOutBadge, "")
                        Me.StatusTime = current_loop.Item("outdate")
                    Case CDR.Status.Delivering
                        Me.OperatorName = SQL.Current.GetString("Fullname", "Smk_Operators", "Badge", Me.DeliveringBadge, "")
                        Me.StatusTime = current_loop.Item("deliverydate")
                End Select

                For Each k As DataRow In SQL.Current.GetDatatable(String.Format("SELECT ID,Kanban,Result,Status FROM DDR_CartsLoopKanbans WHERE LoopID = {0} ORDER BY ID ASC", _loop)).Rows
                    Me.ScannedKanbans.Add(New ScannedKanban(k.Item("Kanban"), "", CBool(k.Item("Result")), k.Item("ID"), PickingStatus(k.Item("Status"))))
                    Me.ScannedKanbansTable.Rows.Add(k.Item("Kanban"), CBool(k.Item("Result")))
                Next

                'REGISTRO DE INICIO DE TURNO DESACTIVADO
                ''COMPROBAR SI NO HUBO CAMBIO DE TURNO DESDE LA ULTIMA ENTRADA DEL CARRO
                'If SQL.Current.Exists(String.Format("SELECT ID FROM DDR_StartingWorkRegister WHERE CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()) AND dbo.Sys_Shift([Date]) = dbo.Sys_Shift(GETDATE()) AND Cart = '{0}'", Me.ID)) Then
                '    Me.Started = True
                'Else
                '    Me.Started = False
                'End If
                Me.Started = True
            Else
                _status = CDR.Status.Out
                Me.StatusTime = Delta.CurrentDate
            End If

            Me.Icon.OperatorName = Me.OperatorName
            Me.Icon.Status = Me.Status
            Me.Icon.Cart = Me.Description
            Me.Icon.StatusTime = Me.StatusTime
            Me.Icon.Containers = Me.ScannedKanbans.Count
            Me.Icon.PickedupContainers = Me.ScannedKanbans.Where(Function(w) w.Status = ScannedKanban.PickingStatus.Finished OrElse w.Status = ScannedKanban.PickingStatus.Critical OrElse w.Status = ScannedKanban.PickingStatus.MissingMaterial).Count()
            Me.Icon.RefreshData()
        End Sub
        Public Property ID As String
        Public Property Description As String
        Public Property Started As Boolean
        Public Property CollectingBadge As String
        Public Property ScannigInBadge As String
        Public Property PickingBadge As String
        Public Property ScanningOutBadge As String
        Public Property DeliveringBadge As String
        Public Property OperatorName As String
        Public Property StatusTime As Date = Delta.CurrentDate
        Public Property Icon As New DDR_CartStatus
        Public ReadOnly Property Status As Status 'INDICA SI LA RUTA ESTA DENTRO O FUERA DE SMK
            Get
                Return _status
            End Get
        End Property
        Public Property ScannedKanbans As New List(Of ScannedKanban) 'ALMACENA LAS KANBANS ESCANEADAS EN LA VUELTA ACTUAL
        Public Property ScannedKanbansTable As New DataTable

        Public ReadOnly Property CurrentLoopID As Integer 'INDICA EL ID DE LA VUELTA ACTUAL EN CASO DE QUE EL CARRO SE ENCUENTRE DENTRO DE SMK, SINO DEBERIA DEVOLVER 0
            Get
                Return _loop
            End Get
        End Property
        Public Property Warehouse As String

        Public Sub GoIn(badge As String)
            SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET InDate = GETDATE(), ScanningInBadge = '{1}', Status = 'I' WHERE ID = {0}", Me.CurrentLoopID, badge))
            Me.Refresh()
        End Sub

        Public Sub EndOut() 'TERMINO ESCANEO DE SALIDA
            SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET PickingEndDate = ISNULL(PickingEndDate,GETDATE()) , OutEndDate = GETDATE(), Status = 'Y' WHERE ID = {0}", Me.CurrentLoopID))
            Me.Refresh()
        End Sub

        Public Sub StartOut(badge As String)
            SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET OutDate = GETDATE(), ScanningOutBadge = '{1}' WHERE ID = {0}", Me.CurrentLoopID, badge))
            Me.Refresh()
        End Sub

        Public Function RegisterScannedKanban(id_kanban As Integer, result As Boolean) As Boolean
            If SQL.Current.Insert("DDR_CartsLoopKanbans", {"LoopID", "Kanban", "Result"}, {Me.CurrentLoopID, id_kanban, result}) Then
                SQL.Current().Execute(String.Format("UPDATE DDR_CartsLoopKanbans SET [Status] = 'F' WHERE Kanban = {0} AND LoopID <> {1} AND [Status] IN ('C','H');", id_kanban, Me.CurrentLoopID)) 'BORRAR CRITICOS EN CASO DE QUE HAYAN PASADO UN PASO
                If result Then
                    Me.ScannedKanbans.Add(New ScannedKanban(id_kanban, New CDR.Kanban(id_kanban).Partnumber, result, SQL.Current.GetScalar("ID", "DDR_CartsLoopKanbans", {"LoopID", "Kanban", "Result"}, {Me.CurrentLoopID, id_kanban, result})))
                Else
                    Me.ScannedKanbans.Add(New ScannedKanban(id_kanban, New CDR.Kanban(id_kanban).Partnumber, result))
                End If
                Me.ScannedKanbansTable.Rows.Add(id_kanban, result)
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Function PickingStatus(status As String) As ScannedKanban.PickingStatus
            Select Case status
                Case "H"
                    Return ScannedKanban.PickingStatus.Hold
                Case "M"
                    Return ScannedKanban.PickingStatus.MissingMaterial
                Case "F"
                    Return ScannedKanban.PickingStatus.Finished
                Case "P"
                    Return ScannedKanban.PickingStatus.PartiallyCompleted
                Case "C"
                    Return ScannedKanban.PickingStatus.Critical
                Case Else
                    Return ScannedKanban.PickingStatus.Hold
            End Select
        End Function

        Public Shared Function CartStatus(status As String) As CDR.Status
            Select Case status
                Case "W"
                    Return CDR.Status.WaitingIn
                Case "I"
                    Return CDR.Status.In
                Case "P"
                    Return CDR.Status.Picking
                Case "O"
                    Return CDR.Status.Out
                Case "Y"
                    Return CDR.Status.WaitingDelivery
                Case "D"
                    Return CDR.Status.Delivering
                Case Else
                    Return "W"
            End Select
        End Function
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

            Me.Started = SQL.Current.Exists(String.Format("SELECT ID FROM CDR_StartingWorkRegister WHERE [Route] = {0} AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE())", Me.Route))
            Me.ScannedKanbans = New List(Of ScannedKanban)

            If Me.Started Then
                _loop = SQL.Current.GetScalar(String.Format("SELECT TOP 1 ID FROM CDR_RoutesLoopRegister WHERE Route = {0} AND CONVERT(DATE,InDate) = CONVERT(DATE,GETDATE()) AND OutDate IS NULL ORDER BY InDate DESC", Me.Route), 0)
                If _loop = 0 Then
                    _status = CDR.Status.OUT
                Else
                    _status = CDR.Status.IN
                    For Each k As DataRow In SQL.Current.GetDatatable(String.Format("SELECT L.Kanban,K.Partnumber,L.Result FROM CDR_RoutesLoopKanbans AS L INNER JOIN CDR_Kanbans AS K ON L.Kanban = K.ID WHERE L.LoopID = {0} ORDER BY L.ID ASC", _loop)).Rows
                        Me.ScannedKanbans.Add(New ScannedKanban(k.Item("Kanban"), k.Item("Partnumber"), CBool(k.Item("Result"))))
                    Next
                End If
            Else
                _status = CDR.Status.OUT
            End If

            Dim loops_done As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ID,InDate,OutDate,C.Kanbans AS Containers FROM CDR_RoutesLoopRegister AS L INNER JOIN (SELECT LoopID,COUNT(Kanban) AS Kanbans FROM CDR_RoutesLoopKanbans GROUP BY LoopID) AS C ON L.ID = C.LoopID WHERE CONVERT(DATE,InDate) = CONVERT(DATE,GETDATE()) AND [Route] = {0} AND Badge = '{1}' ORDER BY ID ASC;", Me.Route, Me.Badge))
            For Each l As DataRow In loops_done.Rows
                If IsDBNull(l.Item("OutDate")) Then
                    Me.Loops.Add(New [Loop](l.Item("ID"), l.Item("InDate"), l.Item("Containers")))
                Else
                    Me.Loops.Add(New [Loop](l.Item("ID"), l.Item("InDate"), l.Item("OutDate"), l.Item("Containers")))
                End If
            Next
        End Sub
        Public Sub GoIn()
            If Me.Status = CDR.Status.OUT Then
                SQL.Current.Insert("CDR_RoutesLoopRegister", {"Route", "Badge"}, {Me.Route, Me.Badge})
                _loop = SQL.Current.GetScalar("MAX(ID)", "CDR_RoutesLoopRegister", {"Route", "Badge"}, {Me.Route, Me.Badge})
                Me.Loops.Add(New [Loop](_loop, Delta.CurrentDate, 0))
                _status = CDR.Status.IN
            End If
        End Sub

        Public Sub GoOut()
            If Me.Status = CDR.Status.IN Then
                'VALIDAR SI EL SISTEMA DEBE DESCONTAR MATERIAL POR CUESTION DE LA RUTA
                If Parameter("CDR_DiscountByKanban") Then
                    For Each k As ScannedKanban In Me.ScannedKanbans
                        'OMITIR VOLVER A BUSCAR SI EXISTE LA KANBAN
                        If k.Result Then
                            Dim kanban As Hashtable = SQL.Current.GetRecord({"Partnumber", "Pieces"}, "CDR_Kanbans", "ID", k.KanbanID)
                            Dim current_serial As String = SMK.CurrentSerial(kanban("partnumber"))
                            'DESCONTAR MATERIAL HASTA QUE ESTE COMPLETA LA CANTIDAD O NO EXISTA NINGUNA SERIE EN SERVICIO
                            While current_serial <> "" AndAlso CDec(kanban("pieces")) > 0
                                Dim serial As New Serialnumber(current_serial)
                                If serial.CurrentQuantityInBum >= kanban("pieces") Then
                                    serial.DiscountByRoute(k.DeltaID, kanban("pieces"), Me.Badge)
                                    current_serial = ""
                                Else
                                    kanban("pieces") = kanban("pieces") - serial.CurrentQuantityInBum
                                    serial.DiscountByRoute(k.DeltaID, serial.CurrentQuantityInBum, Me.Badge)
                                    current_serial = SMK.CurrentSerial(kanban("partnumber"))
                                End If
                                serial = Nothing
                            End While
                            kanban = Nothing
                        End If
                    Next
                End If
                SQL.Current.Execute("UPDATE CDR_RoutesLoopRegister SET OutDate = GETDATE() WHERE ID = " & Me.CurrentLoopID)
                Me.Loops.Find(Function(f) f.ID = _loop).OutDate = Delta.CurrentDate
                Me.Loops.Find(Function(f) f.ID = _loop).Completed = True
                Me.ScannedKanbans.Clear()
                _loop = 0
                _status = CDR.Status.OUT
            End If
        End Sub

        Public Function RegisterScannedKanban(id_kanban As Integer, result As Boolean) As Boolean
            If SQL.Current.Insert("CDR_RoutesLoopKanbans", {"LoopID", "Kanban", "Result"}, {Me.CurrentLoopID, id_kanban, result}) Then
                If result Then
                    Me.ScannedKanbans.Add(New ScannedKanban(id_kanban, New CDR.Kanban(id_kanban).Partnumber, result, SQL.Current.GetScalar("ID", "CDR_RoutesLoopKanbans", {"LoopID", "Kanban", "Result"}, {Me.CurrentLoopID, id_kanban, result})))
                Else
                    Me.ScannedKanbans.Add(New ScannedKanban(id_kanban, New CDR.Kanban(id_kanban).Partnumber, result))
                End If
                Me.Loops.Find(Function(f) f.ID = Me.CurrentLoopID).Containers += 1
                Return True
            Else
                Return False
            End If
        End Function
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
        Public Property ScannedKanbans As List(Of ScannedKanban) 'ALMACENA LAS KANBANS ESCANEADAS EN LA VUELTA ACTUAL

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

    Public Class ScannedKanban
        Public Sub New(kanban_id As Integer, partnumber As String, result As Boolean, Optional delta_id As Integer = 0, Optional status As PickingStatus = PickingStatus.Hold)
            Me.KanbanID = kanban_id
            Me.Result = result
            Me.DeltaID = delta_id
            Me.Status = status
        End Sub
        Public Property KanbanID As Integer
        Public Property Partnumber As Integer
        Public Property Result As Boolean
        Public Property DeltaID As Integer
        Public Property Status As PickingStatus
        Public Enum PickingStatus
            Hold
            Finished
            PartiallyCompleted
            Critical
            MissingMaterial
        End Enum
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
        WaitingIn
        [In]
        Picking
        [Out]
        WaitingDelivery
        Delivering
    End Enum

    Public Shared Function BuildKanban(code As Object, partnumber As Object, loc_line As Object, slot As Object, side As Object, section As Object, board As Object, kit As Object, route As Object, description As Object, quantity As Object, container As Object, [index] As Object, business As Object, rack As Object, [local] As Object, [date] As Object)
        Dim z As String = Parameter("CDR_ZPLKanban", "^XA  ^PW1200   ^JZY   ^LH40,20  ^FWB ^FO5,70^BCB,40,Y,N,N,N^FD@code^FS^FO700,135^BCB,40,N,N,N,N^FD@partnumber^FS ^FO95,80^A0,25,25^FDNUMERO DE PARTE^FS  ^FO140,5^FB360,1,0,C,0^A0,80,80^FD@partnumber^FS  ^FO215,135^A0,30,30^FDPUNTO DE USO^FS  ^FO215,15^A0,30,30^FDRUTA^FS  ^FO255,290^A0,15,15^FDLOC LINEA^FS  ^FO255,120^A0,25,25^FDDIRECCION^FS  ^FO315,270^FB100,2,0,C,0^A0,50,50^FD@loc_line^FS ^FO280,90^GB1,180,60^FS  ^FO300,90^FB180,1,0,C,0^A0,40,40^FR^FD@board^FS  ^FO355,90^FB180,1,0,C,0^A0,40,40^FD@kit^FS  ^FO290,5^FB85,2,0,C,0^A0,80,80^FD@route^FS  ^FO400,125^A0,20,20^FDDESCRIPCION^FS  ^FO420,5^FB360,2,0,C,0^A0,20,20^FD@description^FS  ^FO462,22^A0,18,18^FDCANTIDAD      TIPO CTN      TARJETA      TOTAL^FS  ^FO495,265^FB95,1,0,C,0^A0,40,40^FD@quantity^FS  ^FO495,170^FB95,1,0,C,0^A0,40,40^FD@container^FS  ^FO495,80^FB95,1,0,C,0^A0,40,40^FD@card^FS  ^FO495,5^FB75,1,0,C,0^A0,40,40^FD@total^FS  ^FO533,5^GB1,250,60^FS  ^FO550,5^FB250,1,0,C,0^A0,45,45^FR^FD@business^FS  ^FO555,265^A0,25,25^FDNEGOCIO^FS  ^FO605,275^0,30,30^FDRACK^FS  ^FO605,40^A0,30,30^FDLOCALIZACION^FS  ^FO645,260^FB100,1,0,C,0^A0,55,55^FD@rack^FS  ^FO650,20^A0,35,35^FD@location^FS   ^FO700,0^FB140,2,0,R,0^A0,25,25^FD@rev^FS  ^FO80,5^GB1,360,4^FS  ^FO120,5^GB1,360,4^FS   ^FO200,5^GB1,360,4^FS  ^FO240,5^GB1,360,4^FS   ^FO280,90^GB1,275,2^FS  ^FO390,5^GB1,360,4^FS  ^FO450,5^GB1,360,4^FS  ^FO480,5^GB1,360,4^FS  ^FO530,5^GB1,360,4^FS  ^FO635,5^GB1,360,4^FS  ^FO690,5^GB1,360,4^FS  ^FO240,270^GB150,2,1^FS  ^FO200,90^GB190,2,1^FS  ^FO450,80^GB80,2,1^FS  ^FO450,170^GB80,2,1^FS  ^FO450,260^GB80,2,1^FS  ^FO590,255^GB100,2,1^FS  ^FO590,5^GB1,360,4^FS  ^XZ")
        z = ZPL.TryChangeResolution(z, 200, My.Settings.PrinterResolution)
        z = z.Replace("@code", RNull(code))
        z = z.Replace("@partnumber", RNull(partnumber))
        If Parameter("CDR_KanbanPrintLineLocation", False) Then
            z = z.Replace("@loc_line", String.Format("{0}-{1}-{2}", RNull(slot), RNull(side), RNull(section)))
        Else
            z = z.Replace("@loc_line", RNull(loc_line))
        End If
        z = z.Replace("@board", RNull(board))
        z = z.Replace("@kit", RNull(kit))
        z = z.Replace("@route", RNull(route))
        z = z.Replace("@description", RNull(description))
        z = z.Replace("@quantity", RNull(quantity))
        z = z.Replace("@container", RNull(container))
        z = z.Replace("@card", RNull([index]))
        z = z.Replace("@total", 2)
        z = z.Replace("@business", RNull(business))
        z = z.Replace("@rack", RNull(rack))
        Dim loc As String = RNull([local])
        If loc.Length = 8 Then
            z = z.Replace("@location", String.Format("{0}-{1}-{2}-{3}", Strings.Left(loc, 2), Strings.Left(Strings.Right(loc, 6), 2), Strings.Left(Strings.Right(loc, 4), 2), Strings.Right(loc, 2)))
        Else
            z = z.Replace("@location", loc)
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


    Public Shared Function ContainerWeight(container As RouteContainer) As Decimal
        Select Case container
            Case RouteContainer.C1_4
                Return Parameter("CDR_1/4_ContainerWeight", 0.136)
            Case RouteContainer.C1_2
                Return Parameter("CDR_1/2_ContainerWeight", 0.136)
            Case RouteContainer.C16s
                Return Parameter("CDR_16s_ContainerWeight", 0.114)
            Case RouteContainer.C8s
                Return Parameter("CDR_8s_ContainerWeight", 0.208)
            Case RouteContainer.C4s
                Return Parameter("CDR_4s_ContainerWeight", 0.365)
            Case RouteContainer.C2s
                Return Parameter("CDR_2s_ContainerWeight", 0.565)
            Case RouteContainer.JT
                Return Parameter("CDR_JT_ContainerWeight", 1.285)
            Case Else
                Return 0
        End Select
    End Function

    Public Enum RouteContainer
        C1_4
        C1_2
        C16s
        C8s
        C4s
        C2s
        JT
        None
    End Enum

    Public Shared Function Query(name As String) As String
        Select Case name.ToLower
            Case "partlocation"
                Return "SELECT dbo.CDR_GetLocation('{0}','{1}');"

            Case "partrack"
                Return "SELECT dbo.CDR_GetRack('{0}','{1}');"

            Case "recalculatekanban_both_board"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' AND E.board = '{1}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2  AND K.Active = 1 WHERE PC.business='{0}' AND E.board = '{1}' ORDER BY E.Kit,E.Loc,i,Code;"

            Case "recalculatekanban_both_board_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' AND E.board = '{1}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2  AND K.Active = 1 WHERE PC.business='{0}' AND E.board = '{1}' ORDER BY E.Kit,E.Loc,i,Code;"

            Case "recalculatekanban_both_business"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2  AND K.Active = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc,i,code;"

            Case "recalculatekanban_both_business_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' UNION ALL SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,2 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 2  AND K.Active = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc,i,code;"

            Case "recalculatekanban_use_board"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' AND E.board='{1}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_board_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' AND E.board='{1}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_business"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_pieces,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS frequency,FLOOR(dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "recalculatekanban_use_business_samecontainer"
                Return "SELECT code,E.partnumber,E.board,RM.description,E.kit,E.loc,E.slot,E.side,E.section,R.Description AS Route,R.Route AS RouteID,CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) AS container_pieces,ISNULL(K.Container,dbo.CDR_RightNameContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)) AS container_name,1 AS i,PC.business,PC.requirement,E.quantity,CEILING(E.Quantity*PC.requirement/8.5)*2 AS [2h],CEILING(E.Quantity*PC.requirement/CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2)))) AS frequency,FLOOR(CONVERT(DECIMAL,ISNULL(pieces,dbo.CDR_RightContainer(E.Partnumber,CEILING(E.Quantity*PC.requirement/8.5)*2))) / CEILING(E.Quantity*PC.requirement/8.5)) AS hrs,dbo.CDR_GetRack(E.Partnumber,K.business) AS rack,dbo.CDR_GetLocation(E.Partnumber,K.business) AS location,K.description,K.kit,K.engloc,K.slot,K.side,K.section,K.route,K.pieces,K.container,K.[index],K.business,K.requirement,K.[2h],K.quantity,K.frequency,K.hrs,K.comment,K.rack,K.[local] FROM CDR_Engineering AS E INNER JOIN (SELECT business,board,AVG(Requirement) AS requirement FROM CDR_ProductionControl GROUP BY business,board) AS PC ON E.Board = PC.Board LEFT OUTER JOIN CDR_Containerization AS CT ON E.Partnumber = CT.Partnumber LEFT OUTER JOIN Sys_RawMaterial AS RM ON E.Partnumber = RM.Partnumber INNER JOIN CDR_RoutesBoards AS B ON E.Board = B.Board LEFT OUTER JOIN CDR_Routes AS R ON B.Route = R.Route LEFT OUTER JOIN CDR_Kanbans AS K ON E.Partnumber = K.Partnumber AND E.Board = K.Board AND E.Kit = K.Kit AND [index] = 1  AND K.Active = 1 WHERE PC.business='{0}' ORDER BY E.Board,E.Kit,E.Loc;"

            Case "sapvsloj_description"
                Return "SELECT E.partnumber,SUM(quantity) AS quantity,MAX(description) AS description FROM CDR_Engineering AS E LEFT OUTER JOIN Sys_RawMaterial AS RW ON E.Partnumber = RW.Partnumber WHERE E.Board='{0}' GROUP BY E.Partnumber;"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Sub Print(ID As Integer, Optional twice As Boolean = False)
        CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"ID"}, {ID}), twice)
    End Sub

    Public Shared Sub Print(kanbans As DataTable, twice As Boolean)
        Try
            If Not IsNothing(kanbans) Then
                If kanbans.Rows.Count > 0 Then
                    Dim z_kanbans As String = ""
                    For Each r As DataRow In kanbans.Rows
                        z_kanbans &= CDR.BuildKanban(r("Code"), r("Partnumber"), r("EngLoc"), r("Slot"), r("Side"), r("Section"), r("Board"), r("Kit"), r("Route"), r("Description"), r("Pieces"), r("Container"), r("Index"), r("Business"), r("Rack"), r("Local"), r("Date"))
                        If twice Then
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

    Public Class Kanban
        Public Sub New(id As Integer, code As String, partnumber As String, business As String, board As String, kit As String, engineering_location As String, slot As String, side As String, section As String, route As String, pieces As Integer, container As String, index As Integer, supermarket_location As String, [date] As Date, generic As Boolean, comment As String)
            Me.ID = id
            Me.Code = code
            Me.Partnumber = partnumber
            Me.Business = business
            Me.Board = board
            Me.Kit = kit
            Me.EngineeringLocation = engineering_location
            Me.Slot = slot
            Me.Side = side
            Me.Section = section
            Me.Route = route
            Me.Pieces = pieces
            Me.Container = container
            Me.Index = index
            Me.SupermarketLocation = supermarket_location
            Me.Date = [date]
            Me.Generic = generic
            Me.Comment = comment
        End Sub

        Public Sub New(id As Integer)
            Me.ID = id
            Dim kanban As Hashtable = SQL.Current.GetRecord("CDR_Kanbans", "ID", id)
            If kanban IsNot Nothing AndAlso kanban.Count > 0 Then
                Me.Code = kanban.Item("code")
                Me.Partnumber = kanban.Item("partnumber")
                Me.Container = kanban.Item("container")
                Me.Pieces = NullReplace(kanban.Item("pieces"), 0)
                Me.Exists = True
            Else
                Me.Exists = False
            End If
        End Sub

        Public Property ID As Integer
        Public Property Code As String
        Public Property Partnumber As String
        Public Property Business As String
        Public Property Board As String
        Public Property Kit As String
        Public Property EngineeringLocation As String
        Public Property Slot As String
        Public Property Side As String
        Public Property Section As String
        Public Property Route As String
        Public Property Pieces As Integer
        Public Property Container As String
        Public Property Index As Integer
        Public Property SupermarketLocation As String
        Public Property [Date] As Date
        Public Property Generic As Boolean
        Public Property Comment As String
        Public Property Exists As Boolean = True
    End Class

    Public Class Carrousel
        Public Property Badges As New List(Of String)
        Public Sub New()
            Me.Refresh()
        End Sub
        Private Sub Refresh()
            Me.Items.Clear()
            Dim carrousel_dt As DataTable = SQL.Current.GetDatatable("SELECT * FROM DDR_CartsLoopRegister AS L INNER JOIN vw_DDR_LoopKanbans AS K ON L.ID = K.LoopID WHERE CONVERT(DATE,ISNULL(DeliveryDate,ISNULL(OutDate,ISNULL(PickingDate,ISNULL(InDate,ArrivalDate))))) = CONVERT(DATE,GETDATE())  ORDER BY L.ID;")
            For Each row As DataRow In carrousel_dt.Rows
                Dim item As New CarrouselItem
                item.ID = row.Item("ID")
                item.Cart = row.Item("Cart")
                item.Status = CDR.Cart.CartStatus(row.Item("Status"))
                Select Case item.Status
                    Case CDR.Status.WaitingIn
                        item.CollectingBadge = row.Item("CollectingBadge")
                        item.ArrivalDate = row.Item("ArrivalDate")
                        If Not _badges.Contains(item.CollectingBadge) Then _badges.Add(item.CollectingBadge)
                    Case CDR.Status.In
                        item.CollectingBadge = row.Item("CollectingBadge")
                        item.ArrivalDate = row.Item("ArrivalDate")
                        item.ScanningBadge = row.Item("ScanningInBadge")
                        item.InDate = row.Item("InDate")
                        item.InEndDate = NullReplace(row.Item("InEndDate"), Delta.CurrentDate)
                        If Not _badges.Contains(item.ScanningBadge) Then _badges.Add(item.ScanningBadge)
                    Case CDR.Status.Picking
                        item.CollectingBadge = row.Item("CollectingBadge")
                        item.ArrivalDate = row.Item("ArrivalDate")
                        item.ScanningBadge = row.Item("ScanningInBadge")
                        item.InDate = row.Item("InDate")
                        item.InEndDate = NullReplace(row.Item("InEndDate"), Delta.CurrentDate)
                        item.PickingBadge = row.Item("PickingBadge")
                        item.PickingDate = row.Item("PickingDate")
                        item.PickingEndDate = NullReplace(row.Item("PickingEndDate"), Delta.CurrentDate)
                        If Not _badges.Contains(item.PickingBadge) Then _badges.Add(item.PickingBadge)
                    Case CDR.Status.WaitingDelivery
                        item.CollectingBadge = row.Item("CollectingBadge")
                        item.ArrivalDate = row.Item("ArrivalDate")
                        item.ScanningBadge = row.Item("ScanningInBadge")
                        item.InDate = row.Item("InDate")
                        item.InEndDate = NullReplace(row.Item("InEndDate"), Delta.CurrentDate)
                        item.PickingBadge = row.Item("PickingBadge")
                        item.PickingDate = row.Item("PickingDate")
                        item.PickingEndDate = NullReplace(row.Item("PickingEndDate"), Delta.CurrentDate)
                        item.ScanningOutBadge = row.Item("ScanningOutBadge")
                        item.OutDate = row.Item("OutDate")
                        item.OutEndDate = NullReplace(row.Item("OutEndDate"), Delta.CurrentDate)
                        If Not _badges.Contains(item.ScanningOutBadge) Then _badges.Add(item.ScanningOutBadge)
                    Case CDR.Status.Delivering
                        item.CollectingBadge = row.Item("CollectingBadge")
                        item.ArrivalDate = row.Item("ArrivalDate")
                        item.ScanningBadge = row.Item("ScanningInBadge")
                        item.InDate = row.Item("InDate")
                        item.InEndDate = NullReplace(row.Item("InEndDate"), Delta.CurrentDate)
                        item.PickingBadge = row.Item("PickingBadge")
                        item.PickingDate = row.Item("PickingDate")
                        item.PickingEndDate = NullReplace(row.Item("PickingEndDate"), Delta.CurrentDate)
                        item.ScanningOutBadge = row.Item("ScanningOutBadge")
                        item.OutDate = row.Item("OutDate")
                        item.OutEndDate = NullReplace(row.Item("OutEndDate"), Delta.CurrentDate)
                        item.DeliveringBadge = row.Item("DeliveringBadge")
                        item.DeliveryDate = row.Item("DeliveryDate")
                        item.DeliveryEndDate = NullReplace(row.Item("DeliveryEndDate"), Delta.CurrentDate)
                        If Not _badges.Contains(item.DeliveringBadge) Then _badges.Add(item.DeliveringBadge)
                    Case CDR.Status.Out

                End Select

                item.HoldKanbans = row.Item("Hold")
                item.FinishedKanbans = row.Item("Finished")
                item.PartialKanbans = row.Item("Partial")
                item.AbortedKanbans = row.Item("Aborted")
                item.CriticalKanbans = row.Item("Critical")
                item.TotalKanbans = row.Item("KanbanCount")
                Me.Items.Add(item)
            Next
            _badges.Sort()
            If Items.Count > 0 Then
                Me.CurrentIndexBadge = 0
                Me.CurrentIndex = 0
            Else
                Me.CurrentIndex = -1
                Me.CurrentIndexBadge = -1
            End If
        End Sub
        Private Property CurrentIndex As Integer
        Private Property CurrentIndexBadge As Integer
        Public Property Items As New List(Of CarrouselItem)
        Public Function NextCart() As CarrouselItem
            If CurrentIndex = Me.Items.Count Then
                Return Nothing
            End If
            NextCart = Me.Items.Item(Me.CurrentIndex)
            Me.CurrentIndex += 1
        End Function
        Public Function NextBadge() As String
            If Me.CurrentIndexBadge = -1 OrElse Me.CurrentIndexBadge >= Me.Badges.Count Then
                Return ""
            End If
            NextBadge = Me.Badges(Me.CurrentIndexBadge)
            Me.CurrentIndexBadge += 1
        End Function
    End Class

    Public Class CarrouselItem
        Public Property ID As Integer
        Public Property Cart As String
        Public Property CollectingBadge As String
        Public Property ScanningBadge As String
        Public Property PickingBadge As String
        Public Property ScanningOutBadge As String
        Public Property DeliveringBadge As String
        Public Property ArrivalDate As Date
        Public Property InDate As Date
        Public Property InEndDate As Date
        Public Property PickingDate As Date
        Public Property PickingEndDate As Date
        Public Property OutDate As Date
        Public Property OutEndDate As Date
        Public Property DeliveryDate As Date
        Public Property DeliveryEndDate As Date
        Public Property TotalKanbans As Integer
        Public Property HoldKanbans As Integer
        Public Property FinishedKanbans As Integer
        Public Property PartialKanbans As Integer
        Public Property AbortedKanbans As Integer
        Public Property CriticalKanbans As Integer
        Public Property Status As CDR.Status
    End Class

End Class
