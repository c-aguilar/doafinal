Public Class Serialnumber
    Private _warehouse As String
    Private _warehousename As String
    Private _statusname As String
    Private _status As SerialStatus
    Private _current_qty, _current_qty_bum As Decimal

    Public Sub New(serialnumber As String, partnumber As String, quantity As Decimal, current_quantity As Decimal, current_quantity_bun As Decimal, uom As String, [date] As Date, warehouse As Char, warehousename As String, container As String, consumption_type As String, sloc As String, _
                   status As Char, statusname As String, randomlocal As String, servicelocal As String, weight As Decimal, currentweight As Decimal, truck As String, _
                   redtag As Boolean, invoicetrouble As Boolean, critical As Boolean, masterlabel As Boolean, scanner As String, expiration_date As Date, lot As String, id As Integer, material_type As String, random_sloc As String, service_sloc As String, dull_sloc As String, mrp As String)
        Me.SerialNumber = serialnumber.ToUpper
        Me.Partnumber = partnumber.ToUpper
        Me.Quantity = quantity
        Select Case uom
            Case "PC"
                Me.UoM = RawMaterial.UnitOfMeasure.PC
            Case "M"
                Me.UoM = RawMaterial.UnitOfMeasure.M
            Case "FT"
                Me.UoM = RawMaterial.UnitOfMeasure.FT
            Case "KG"
                Me.UoM = RawMaterial.UnitOfMeasure.KG
            Case "LB"
                Me.UoM = RawMaterial.UnitOfMeasure.LB
            Case "L"
                Me.UoM = RawMaterial.UnitOfMeasure.L
        End Select
        Me.Date = [date]
        _warehouse = warehouse
        _warehousename = warehousename
        Me.Container = container
        Me.Sloc = sloc

        If consumption_type = RawMaterial.ConsumptionType.Partial.ToString Then
            Me.Consumption = RawMaterial.ConsumptionType.Partial
        ElseIf consumption_type = RawMaterial.ConsumptionType.Mixed.ToString Then
            Me.Consumption = RawMaterial.ConsumptionType.Mixed
        Else
            Me.Consumption = RawMaterial.ConsumptionType.Total
        End If
        Me.Exist = True
        Select Case status
            Case "N"
                _status = SerialStatus.New
            Case "P"
                _status = SerialStatus.Pending
            Case "S"
                _status = SerialStatus.Stored
            Case "O"
                _status = SerialStatus.Open
            Case "C"
                _status = SerialStatus.OnCutter
            Case "E"
                _status = SerialStatus.Empty
            Case "Q"
                _status = SerialStatus.Quality
            Case "T"
                _status = SerialStatus.Tracker
            Case "U"
                _status = SerialStatus.ServiceOnQuality
            Case "D"
                _status = SerialStatus.Deleted
                Me.Exist = False
        End Select
        _statusname = statusname
        _current_qty = current_quantity
        _current_qty_bum = current_quantity_bun
        Me.RandomLocation = randomlocal
        Me.ServiceLocation = servicelocal
        Me.Weight = weight
        Me.CurrentWeight = currentweight
        Me.TruckNumber = truck
        Me.RedTag = redtag
        Me.InvoiceTrouble = invoicetrouble
        Me.Critical = critical
        Me.MasterLabel = masterlabel
        Me.Scanner = scanner
        Me.ExpirationDate = expiration_date
        Me.Lot = lot
        Me.ID = id
        Select Case material_type
            Case "Tape"
                Me.Type = RawMaterial.MaterialType.Tape
            Case "Terminal"
                Me.Type = RawMaterial.MaterialType.Terminal
            Case "Component"
                Me.Type = RawMaterial.MaterialType.Component
            Case "Cable"
                Me.Type = RawMaterial.MaterialType.Cable
            Case "Conduit"
                Me.Type = RawMaterial.MaterialType.Conduit
        End Select
        Me.RandomSloc = random_sloc
        Me.ServiceSloc = service_sloc
        Me.DullSloc = dull_sloc
        Me.MRP = mrp
    End Sub
    Public Sub New(serialnumber As String)
        If serialnumber.ToUpper.StartsWith("S") Then
            serialnumber = serialnumber.Remove(0, 1)
        End If
        Me.SerialNumber = serialnumber.ToUpper
        Dim serial As Hashtable = SQL.Current.GetRecord("vw_Smk_Serials", "SerialNumber", serialnumber)
        If serial IsNot Nothing AndAlso serial.Count > 0 Then
            Me.Partnumber = serial.Item("partnumber")
            Me.Quantity = serial.Item("originalquantity")

            Select Case serial.Item("uom").ToString.ToUpper
                Case "PC"
                    Me.UoM = RawMaterial.UnitOfMeasure.PC
                Case "M"
                    Me.UoM = RawMaterial.UnitOfMeasure.M
                Case "FT"
                    Me.UoM = RawMaterial.UnitOfMeasure.FT
                Case "KG"
                    Me.UoM = RawMaterial.UnitOfMeasure.KG
                Case "LB"
                    Me.UoM = RawMaterial.UnitOfMeasure.LB
                Case "L"
                    Me.UoM = RawMaterial.UnitOfMeasure.L
            End Select

            Me.Date = serial.Item("date")
            _warehouse = serial.Item("warehouse")
            _warehousename = serial.Item("warehousename")
            Me.Container = serial.Item("container")
            Me.Sloc = serial.Item("sloc")
            If serial.Item("consumptiontype") = RawMaterial.ConsumptionType.Partial.ToString Then
                Me.Consumption = RawMaterial.ConsumptionType.Partial
            ElseIf serial.Item("consumptiontype") = RawMaterial.ConsumptionType.Mixed.ToString Then
                Me.Consumption = RawMaterial.ConsumptionType.Mixed
            Else
                Me.Consumption = RawMaterial.ConsumptionType.Total
            End If

            Me.Exist = True
            Select Case serial.Item("status")
                Case "N"
                    _status = SerialStatus.New
                Case "P"
                    _status = SerialStatus.Pending
                Case "S"
                    _status = SerialStatus.Stored
                Case "O"
                    _status = SerialStatus.Open
                Case "C"
                    _status = SerialStatus.OnCutter
                Case "E"
                    _status = SerialStatus.Empty
                Case "Q"
                    _status = SerialStatus.Quality
                Case "T"
                    _status = SerialStatus.Tracker
                Case "U"
                    _status = SerialStatus.ServiceOnQuality
                Case "D"
                    _status = SerialStatus.Deleted
                    Me.Exist = False
            End Select
            _statusname = serial.Item("statusdescription")
            Me.RandomLocation = If(serial.Item("randomlocation") = "", "", serial.Item("randomlocation"))
            Me.ServiceLocation = If(serial.Item("servicelocation") = "", "", serial.Item("servicelocation"))
            Me.Weight = serial.Item("weight")
            Me.CurrentWeight = serial.Item("currentweight")
            Me.TruckNumber = If(serial.Item("trucknumber") = "", "", serial.Item("trucknumber"))
            Me.RedTag = serial.Item("redtag")
            Me.InvoiceTrouble = serial.Item("invoicetrouble")
            Me.Critical = serial.Item("critical")
            Me.MasterLabel = serial.Item("masterlabel")
            Me.Scanner = If(serial.Item("scanner") = "", "", serial.Item("scanner"))
            Me.ExpirationDate = If(serial.Item("expirationdate") = "", New Date(2100, 12, 31), serial.Item("expirationdate"))
            Me.Lot = If(serial.Item("lot") = "", "", serial.Item("lot"))
            Me.ID = serial.Item("id")
            Select Case StrConv(serial.Item("materialtype"), VbStrConv.ProperCase)
                Case "Tape"
                    Me.Type = RawMaterial.MaterialType.Tape
                Case "Terminal"
                    Me.Type = RawMaterial.MaterialType.Terminal
                Case "Component"
                    Me.Type = RawMaterial.MaterialType.Component
                Case "Cable"
                    Me.Type = RawMaterial.MaterialType.Cable
                Case "Conduit"
                    Me.Type = RawMaterial.MaterialType.Conduit
            End Select
            Me.RandomSloc = serial.Item("randomsloc")
            Me.ServiceSloc = serial.Item("servicesloc")
            Me.DullSloc = serial.Item("dullsloc")
            Me.MRP = serial.Item("mrp")
            _current_qty = serial.Item("currentquantity")
            _current_qty_bum = serial.Item("currentquantityinbum")
        Else
            Me.Exist = False
            Me.Status = SerialStatus.Unexist
        End If
        serial = Nothing
        GC.Collect()
    End Sub
    Public Property Exist As Boolean
    Public Property SerialNumber As String
    Public Property Partnumber As String
    Public Property Quantity As Decimal
    Public Property UoM As RawMaterial.UnitOfMeasure
    Public Property MRP As String
    Public Property Type As RawMaterial.MaterialType
    Public Property [Date] As Date
    Public Property Warehouse As String
        Get
            Return _warehouse
        End Get
        Set(value As String)
            If value <> _warehouse Then
                _warehouse = value
                _warehousename = SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", value, "")
            End If
        End Set
    End Property

    Public Property WarehouseName As String
        Get
            Return _warehousename
        End Get
        Set(value As String)
            _warehousename = value
        End Set
    End Property
    Public Property Sloc As String
    Public Property Container As String
    Public Function UpdateStatus(new_status As SerialStatus) As Boolean
        Dim result As Boolean
        Select Case new_status
            Case SerialStatus.Stored
                result = SQL.Current.Update("Smk_Serials", "Status", "S", "ID", Me.ID)
            Case SerialStatus.Open
                result = SQL.Current.Update("Smk_Serials", "Status", "O", "ID", Me.ID)
            Case SerialStatus.OnCutter
                result = SQL.Current.Update("Smk_Serials", "Status", "C", "ID", Me.ID)
            Case SerialStatus.Empty
                result = SQL.Current.Update("Smk_Serials", "Status", "E", "ID", Me.ID)
            Case SerialStatus.Deleted
                result = SQL.Current.Update("Smk_Serials", "Status", "D", "ID", Me.ID)
            Case SerialStatus.Tracker
                result = SQL.Current.Update("Smk_Serials", "Status", "T", "ID", Me.ID)
            Case SerialStatus.Quality
                result = SQL.Current.Update("Smk_Serials", "Status", "Q", "ID", Me.ID)
            Case SerialStatus.ServiceOnQuality
                result = SQL.Current.Update("Smk_Serials", "Status", "U", "ID", Me.ID)
            Case SerialStatus.New
                result = SQL.Current.Update("Smk_Serials", "Status", "N", "ID", Me.ID)
            Case SerialStatus.Pending
                result = SQL.Current.Update("Smk_Serials", "Status", "P", "ID", Me.ID)
            Case Else
                result = False
        End Select
        If result Then Me.Status = new_status
        Return result
    End Function
    Public Property Status As SerialStatus
        Get
            Return _status
        End Get
        Set(value As SerialStatus)
            If value <> _status Then
                Select Case value
                    Case SerialStatus.Stored
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "S", "")
                    Case SerialStatus.Open
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "O", "")
                    Case SerialStatus.OnCutter
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "C", "")
                    Case SerialStatus.Empty
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "E", "")
                    Case SerialStatus.New
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "N", "")
                    Case SerialStatus.Pending
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "P", "")
                    Case SerialStatus.Quality
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "Q", "")
                    Case SerialStatus.ServiceOnQuality
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "U", "")
                    Case SerialStatus.Tracker
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "T", "")
                End Select
                _status = value
            End If
        End Set
    End Property
    Private Sub UpdateSloc()
        Me.Sloc = SQL.Current.GetString("Sloc", "vw_Smk_Serials", "ID", Me.ID, "")
    End Sub

    Public ReadOnly Property StatusName As String
        Get
            Return _statusname
        End Get
    End Property
    Public Property Consumption As RawMaterial.ConsumptionType
    Public Property RandomLocation As String
    Public Property ServiceLocation As String
    Public ReadOnly Property CurrentLocation As String
        Get
            Select Case Me.Status
                Case SerialStatus.OnCutter, SerialStatus.Open
                    Return Me.ServiceLocation
                Case Else
                    Return Me.RandomLocation
            End Select
        End Get
    End Property
    Public Property Weight As Decimal
    Public Property CurrentWeight As Decimal
    Public Property TruckNumber As String
    Public Property InvoiceTrouble As Boolean
    Public Property RedTag As Boolean
    Public Property Critical As Boolean
    Public Property MasterLabel As Boolean
    Public Property Scanner As Integer
    Public Property ExpirationDate As Date
    Public Property Lot As String
    Public Property ID As Integer
    Public ReadOnly Property CurrentQuantity As Decimal
        Get
            Return _current_qty
        End Get
    End Property
    Public ReadOnly Property CurrentQuantityInBum As Decimal
        Get
            Return _current_qty_bum
        End Get
    End Property

    Public Function ChangeLocation(new_location As String) As Boolean
        Select Case Me.Status
            Case SerialStatus.Empty And Me.Type = RawMaterial.MaterialType.Cable
                Dim SMS As New SQL(Parameter("SMK_SMSBarrelsStringConn2"))
                Dim barrel_status As String = SMS.GetString("serial_status", "tblSerials", "serial_number", Me.SerialNumber, "")
                Select Case barrel_status
                    Case "RANDOM"
                        Return SMS.Update("tblSerials", "serial_randomLocal", new_location, "serial_number", Me.SerialNumber)
                    Case "SMK", "ON CUTTER"
                        Return SMS.Update("tblSerials", "serial_serviceLocal", new_location, "serial_number", Me.SerialNumber)
                    Case Else
                        Return False
                End Select
            Case Else
                'NO SE ESTAN DIFERENCIANDO EL SERVICIO O RESERVA
                If SQL.Current.Update("Smk_Serials", {"ServiceLocation", "RandomLocation"}, {new_location, new_location}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.ChangeLocation, 0, new_location, 0, User.Current.Badge)
                    Me.ServiceLocation = new_location
                    Return True
                End If
        End Select
        Return False
    End Function

    Public Function ChangeLocation(new_location As String, badge As String) As Boolean
        Select Case Me.Status
            Case SerialStatus.Empty And Me.Type = RawMaterial.MaterialType.Cable
                Dim SMS As New SQL(Parameter("SMK_SMSBarrelsStringConn2"))
                Dim barrel_status As String = SMS.GetString("serial_status", "tblSerials", "serial_number", Me.SerialNumber, "")
                Select Case barrel_status
                    Case "RANDOM"
                        Return SMS.Update("tblSerials", "serial_randomLocal", new_location, "serial_number", Me.SerialNumber)
                    Case "SMK", "ON CUTTER"
                        Return SMS.Update("tblSerials", "serial_serviceLocal", new_location, "serial_number", Me.SerialNumber)
                    Case Else
                        Return False
                End Select
            Case Else
                'NO SE ESTAN DIFERENCIANDO EL SERVICIO O RESERVA
                If SQL.Current.Update("Smk_Serials", {"ServiceLocation", "RandomLocation"}, {new_location, new_location}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.ChangeLocation, 0, new_location, 0, badge)
                    Me.ServiceLocation = new_location
                    Return True
                End If
        End Select
        Return False
    End Function

    Public Function Store(location As String) As Boolean
        If InsertMovement(SerialMovement.StoreContainer, 0, location, 0, User.Current.Badge) Then
            If Me.Type = RawMaterial.MaterialType.Cable Then
                Dim SMS As New SQL(Parameter("SMK_SMSBarrelsStringConn2"))
                If SMS.Insert("tblSerials", {"serial_number", "serial_partNumber", "serial_stdPack", "serial_uom", "serial_randomLocal", "serial_lenghtQuantity", "serial_warehouse", "serial_status"}, {Me.SerialNumber, Me.Partnumber, Me.CurrentQuantity, Me.UoM.ToString, location, Me.CurrentQuantity, My.Settings.Warehouse, "RANDOM"}) Then
                    Dim cable_sloc As String = SMS.GetString("ware_randomSloc", "catWarehouse", "ware_name", My.Settings.Warehouse, "0001")
                    If "0001" <> cable_sloc Then 'TODO EL MATERIAL SE DEBE RECIBIR EN EL SLOC 1, DE LO CONTRARIOSE DEBE HACER OTRO PROCESO
                        InsertTransfer(LastMovementID, Me.CurrentQuantity, "0001", cable_sloc)
                    End If
                    SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation"}, {"E", location}, "ID", Me.ID)
                    Me.Status = SerialStatus.Empty
                    Me.RandomLocation = location
                    Me.Warehouse = cable_sloc
                    UpdateSloc()
                    Return True
                Else
                    Return False
                End If
            Else
                If SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation"}, {"S", location}, "ID", Me.ID) Then
                    Me.Status = SerialStatus.Stored
                    Me.RandomLocation = location
                    If Me.CurrentQuantity > 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                    UpdateSloc()
                    Return True
                Else
                    Return False
                End If

            End If
        Else
            Return False
        End If
    End Function

    Public Function Store(location As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.StoreContainer, 0, location, 0, badge) Then
            If Me.Type = RawMaterial.MaterialType.Cable Then
                Dim SMS As New SQL(Parameter("SMK_SMSBarrelsStringConn2"))
                If SMS.Insert("tblSerials", {"serial_number", "serial_partNumber", "serial_stdPack", "serial_uom", "serial_randomLocal", "serial_lenghtQuantity", "serial_warehouse", "serial_status"}, {Me.SerialNumber, Me.Partnumber, Me.CurrentQuantity, Me.UoM.ToString, location, Me.CurrentQuantity, My.Settings.Warehouse, "RANDOM"}) Then
                    Dim cable_sloc As String = SMS.GetString("ware_randomSloc", "catWarehouse", "ware_name", My.Settings.Warehouse, "0001")
                    If "0001" <> cable_sloc Then 'TODO EL MATERIAL SE DEBE RECIBIR EN EL SLOC 1, DE LO CONTRARIOSE DEBE HACER OTRO PROCESO
                        InsertTransfer(LastMovementID, Me.CurrentQuantity, "0001", cable_sloc)
                    End If
                    SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation"}, {"E", location}, "ID", Me.ID)
                    Me.Status = SerialStatus.Empty
                    Me.RandomLocation = location
                    Me.Warehouse = cable_sloc
                    UpdateSloc()
                    Return True
                Else
                    Return False
                End If
            Else
                If SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation"}, {"S", location}, "ID", Me.ID) Then
                    Me.Status = SerialStatus.Stored
                    Me.RandomLocation = location
                    If Me.CurrentQuantity > 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                    UpdateSloc()
                    Return True
                Else
                    Return False
                End If

            End If
        Else
            Return False
        End If
    End Function

    Public Function Open(location As String) As Boolean
        If InsertMovement(SerialMovement.OpenContainer, 0, location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)

            Dim nextserial As String = SMK.NextFIFO(Me.Partnumber, My.Settings.Warehouse)
            If Not nextserial = Me.SerialNumber AndAlso Not nextserial = "" Then 'REPORTAR FIFO QUEBRADO
                SQL.Current.Insert("Smk_BrokenFIFO", {"TakenSerialnumber", "NextSerialnumber", "Badge"}, {Me.SerialNumber, nextserial, User.Current.Badge})
            End If

            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, User.Current.Badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})

            SQL.Current.Update("Smk_Serials", {"Status", "ServiceLocation"}, {"O", location}, "ID", Me.ID)
            Me.ServiceLocation = location
            Me.Status = SerialStatus.Open
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Open(location As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.OpenContainer, 0, location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)

            Dim nextserial As String = SMK.NextFIFO(Me.Partnumber, My.Settings.Warehouse)
            If Not nextserial = Me.SerialNumber AndAlso Not nextserial = "" Then 'REPORTAR FIFO QUEBRADO
                SQL.Current.Insert("Smk_BrokenFIFO", {"TakenSerialnumber", "NextSerialnumber", "Badge"}, {Me.SerialNumber, nextserial, badge})
            End If

            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})

            SQL.Current.Update("Smk_Serials", {"Status", "ServiceLocation"}, {"O", location}, "ID", Me.ID)
            Me.ServiceLocation = location
            Me.Status = SerialStatus.Open
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PartialDiscount(quantity As Decimal) As Boolean
        If InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PartialDiscount(quantity As Decimal, badge As String) As Boolean
        If InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MoverPartialDiscount(quantity As Decimal) As Boolean
        If InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MoverPartialDiscount(quantity As Decimal, sloc As String) As Boolean
        If InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            _current_qty -= quantity

            'Mover la cantidad de inventario al sloc segun el tipo de Mover
            InsertMovement(SerialMovement.MoverTransference, 0, "", 0, User.Current.Badge)
            InsertTransfer(LastMovementID, quantity, Me.DullSloc, sloc)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ManualAdjust(new_quantity As Decimal) As Boolean
        If InsertMovement(SerialMovement.ManualAdjustment, new_quantity - _current_qty, "", 0, User.Current.Badge) Then
            _current_qty = new_quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DiscountByRoute(quantity As Decimal, badge As String) As Boolean
        If InsertMovement(SerialMovement.DiscountByRoute, -quantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Empty() As Boolean
        If InsertMovement(SerialMovement.DeclareEmpty, -Me.CurrentQuantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
            Me.UpdateStatus(SerialStatus.Empty)
            If Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty = 0
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Empty(badge As String) As Boolean
        If InsertMovement(SerialMovement.DeclareEmpty, -Me.CurrentQuantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
            Me.UpdateStatus(SerialStatus.Empty)
            If Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty = 0
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function EmptyByRoute(badge As String) As Boolean
        If InsertMovement(SerialMovement.DeclareEmptyByRoute, -Me.CurrentQuantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
            SQL.Current.Update("Smk_Serials", "Status", "E", "ID", Me.ID)
            If Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty = 0
            Me.Status = SerialStatus.Empty
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    'Private Sub ReportMinimum()
    '    Dim containers = SQL.Current.GetScalar(String.Format("SELECT COUNT(Serialnumber) FROM vw_Smk_Serials WHERE [Partnumber] = '{0}' AND Status IN ('S','O','C','N','T','P') AND CurrentQuantity > 0;", Me.Partnumber))
    '    If containers = 0 Then
    '        SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(74), Me.SerialNumber, Me.CurrentQuantity, Me.UoM.ToString), Language.Sentence(75), "DeltaERP"})
    '        Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(76), Me.Partnumber))
    '    Else
    '        Dim minimum = SQL.Current.GetScalar("SUM(Minimum)", "Smk_Map", "Partnumber", Me.Partnumber, 1)
    '        'VALIDAR QUE SEA EL MINIMO Y QUE NO EXISTA YA OTRO REPORTE NO CONTESTADO O CON FECHA PROMESA AUN NO CUMPLIDA
    '        If containers < minimum AndAlso Not SQL.Current.Exists(String.Format("SELECT ID FROM Ord_RawMaterialAlerts WHERE Partnumber = '{0}' AND LEFT([Type],3) = 'Min' AND (PromiseDate IS NULL Or PromiseDate >= GETDATE());", Me.Partnumber)) Then
    '            SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(72), containers, minimum), Language.Sentence(73), "DeltaERP"})
    '            Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(77), Me.Partnumber, containers))
    '        End If
    '    End If
    'End Sub

    'Private Sub ReportMaximum()
    '    'VALIDAR QUE ESTE NUMERO NO SE HAYA REPORTADO YA ESTE DIA
    '    If Not SQL.Current.Exists(String.Format("SELECT ID FROM Ord_RawMaterialAlerts WHERE Partnumber = '{0}' AND LEFT([Type],3) = 'Max' AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE());", Me.Partnumber)) Then
    '        'TOMA EN CUENTA SOLO SERIES VIVAS
    '        Dim containers = SQL.Current.GetScalar(String.Format("SELECT COUNT(Serialnumber) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('S','O','C') AND CurrentQuantity > 0;", Me.Partnumber))
    '        Dim maximum = SQL.Current.GetScalar("SUM(Maximum)", "Smk_Map", "Partnumber", Me.Partnumber, 1)
    '        'VALIDAR QUE SEA MAYOR AL MAXIMO
    '        If containers > maximum Then
    '            SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(78), containers, maximum), Language.Sentence(79), "DeltaERP"})
    '            Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(80), Me.Partnumber, containers))
    '        End If
    '    End If

    'End Sub

    Private Sub ReportMinMax()
        Dim containers = SQL.Current.GetScalar(String.Format("SELECT COUNT(Serialnumber) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND ([Status] IN ('S','O','C','T','Q','U') OR ([Status] IN ('N','P') AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE()))) AND CurrentQuantity > 0;", Me.Partnumber))
        Dim maximum = SQL.Current.GetScalar("SUM(Maximum)", "Smk_Map", "Partnumber", Me.Partnumber, 1)
        Dim minimum = SQL.Current.GetScalar("SUM(Minimum)", "Smk_Map", "Partnumber", Me.Partnumber, 1)
        If minimum = 0 Then minimum = 1
        If maximum = 0 Then maximum = 1

        If containers > maximum AndAlso Not SQL.Current.Exists(String.Format("SELECT ID FROM Ord_RawMaterialAlerts WHERE Partnumber = '{0}' AND LEFT([Type],3) = 'Max' AND CONVERT(DATE,[Date]) = CONVERT(DATE,GETDATE());", Me.Partnumber)) Then
            SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(78), containers, maximum), Language.Sentence(79), "DeltaERP"})
            'Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(80), Me.Partnumber, containers))
        Else 'DESACTIVAR MAXIMOS
            SQL.Current.Execute(String.Format("UPDATE Ord_RawMaterialAlerts SET Answer = 'Desactivado por baja de material.', AnswerUsername = 'DeltaERP', AnswerDate = GETDATE() WHERE LEFT([Type],3) = 'Max' AND [Answer] IS NULL AND Partnumber = '{0}';", Me.Partnumber))
        End If

        If containers >= minimum Then 'YA NO ESTA MINIMO
            'DESACTIVAR CRITICOS Y MINIMOS
            SQL.Current.Execute(String.Format("UPDATE Ord_RawMaterialAlerts SET Answer = LEFT('Desactivado por alta de material. ' + [Answer], 100), AnswerUsername = 'DeltaERP', AnswerDate = GETDATE(), PromiseDate = GETDATE() WHERE LEFT([Type],3) IN ('Min','Cri') AND PromiseDate IS NULL AND Partnumber = '{0}';", Me.Partnumber))
        ElseIf containers = 0 Then 'CRITICO
            SQL.Current.Execute(String.Format("UPDATE Ord_RawMaterialAlerts SET Answer = 'Desactivado por cambio de estado a Critico.', AnswerUsername = 'DeltaERP', AnswerDate = GETDATE(), PromiseDate = GETDATE() WHERE LEFT([Type],3) IN ('Min') AND PromiseDate IS NULL AND Partnumber = '{0}';", Me.Partnumber))
            SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(74), Me.SerialNumber, Me.CurrentQuantity, Me.UoM.ToString), Language.Sentence(75), "DeltaERP"})
            Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(76), Me.Partnumber))
        Else 'MINIMO
            SQL.Current.Insert("Ord_RawMaterialAlerts", {"Partnumber", "Comment", "Type", "Badge"}, {Me.Partnumber, String.Format(Language.Sentence(72), containers, minimum), Language.Sentence(73), "DeltaERP"})
            'Delta.Alert("DeltaERP", SQL.Current.GetString("Username,", "Ord_MRPControllers", "MRP", Me.MRP, ""), String.Format(Language.Sentence(77), Me.Partnumber, containers))
        End If

    End Sub

    Public Function ChangeCutter() As Boolean
        Return True
    End Function

    Public Function TransferRandom(new_location As String, new_warehouse As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandom, 0, new_location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetRandomSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"RandomLocation", "Warehouse"}, {new_location, new_warehouse}, "ID", Me.ID)
            Me.RandomLocation = new_location
            Me.Warehouse = new_warehouse
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferRandom(new_location As String, new_warehouse As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandom, 0, new_location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetRandomSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"RandomLocation", "Warehouse"}, {new_location, new_warehouse}, "ID", Me.ID)
            Me.RandomLocation = new_location
            Me.Warehouse = new_warehouse
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferService(new_location As String, new_warehouse As String) As Boolean
        If InsertMovement(SerialMovement.TransferService, 0, new_location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetServiceSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"RandomLocation", "Warehouse"}, {new_location, new_warehouse}, "ID", Me.ID)
            Me.ServiceLocation = new_location
            Me.Warehouse = new_warehouse
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferService(new_location As String, new_warehouse As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.TransferService, 0, new_location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetServiceSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"RandomLocation", "Warehouse"}, {new_location, new_warehouse}, "ID", Me.ID)
            Me.ServiceLocation = new_location
            Me.Warehouse = new_warehouse
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferRandomToService(new_location As String, new_warehouse As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandomToService, 0, new_location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetServiceSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation", "Warehouse"}, {"O", new_location, new_warehouse}, "ID", Me.ID)
            Me.ServiceLocation = new_location
            Me.Warehouse = new_warehouse
            Me.Status = SerialStatus.Open
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferRandomToService(new_location As String, new_warehouse As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandomToService, 0, new_location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetServiceSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"Status", "RandomLocation", "Warehouse"}, {"O", new_location, new_warehouse}, "ID", Me.ID)
            Me.ServiceLocation = new_location
            Me.Warehouse = new_warehouse
            Me.Status = SerialStatus.Open
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ReturnToRandom(location As String) As Boolean
        If Me.Type <> RawMaterial.MaterialType.Cable Then
            If InsertMovement(SerialMovement.ReturnToRandom, 0, location, 0, User.Current.Badge) Then
                InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.RandomSloc)
                SQL.Current.Update("Smk_Serials", "Status", "S", "ID", Me.ID)
                Me.Status = SerialStatus.Stored
                Me.RandomLocation = location
                UpdateSloc()
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ReturnFromEmpty() As Boolean
        If Me.Type <> RawMaterial.MaterialType.Cable Then
            Dim qty As Decimal = SQL.Current.GetScalar(String.Format("SELECT TOP 1 ABS(Quantity) FROM Smk_SerialMovements WHERE SerialID = {0} AND Movement = '{1}' ORDER BY [Date] DESC", Me.ID, MovementCode(SerialMovement.DeclareEmpty)), 0)
            Dim empty_id As Integer = SQL.Current.GetScalar(String.Format("SELECT TOP 1 ID FROM Smk_SerialMovements WHERE SerialID = {0} AND Movement = '{1}' ORDER BY [Date] DESC", Me.ID, MovementCode(SerialMovement.DeclareEmpty)), 0)
            If InsertMovement(SerialMovement.ReturnFromEmpty, qty, "", 0, User.Current.Badge) Then
                'BUSCAR SI YA SE POSTEO EL DECLARADO VACIO
                If SQL.Current.Exists("Smk_SAPTransfers", {"MovementID", "Posted"}, {empty_id, 1}) Then 'YA SE POSTEO
                    If Me.Consumption = RawMaterial.ConsumptionType.Total Then
                        InsertTransfer(LastMovementID, qty, Me.Sloc, Me.RandomSloc)
                        SQL.Current.Update("Smk_Serials", "Status", "S", "ID", Me.ID)
                        Me.Status = SerialStatus.Stored
                        UpdateSloc()
                    Else
                        InsertTransfer(LastMovementID, qty, Me.Sloc, Me.ServiceSloc)
                        SQL.Current.Update("Smk_Serials", "Status", "O", "ID", Me.ID)
                        Me.Status = SerialStatus.Open
                        UpdateSloc()
                    End If
                Else 'NO SE HA POSTEADO
                    'CANCELAR EL POSTEO
                    SQL.Current.Execute(String.Format("UPDATE Smk_SAPTransfers SET Posted = 1, PostedDate = GETDATE(), DocumentNumber = 'MovementCanceled', AdjustmentQuantity = 0, PostedUsername = '{0}' WHERE MovementID = {1};", User.Current.Username, empty_id))
                    If Me.Consumption = RawMaterial.ConsumptionType.Total Then
                        SQL.Current.Update("Smk_Serials", "Status", "S", "ID", Me.ID)
                        Me.Status = SerialStatus.Stored
                        UpdateSloc()
                    Else
                        SQL.Current.Update("Smk_Serials", "Status", "O", "ID", Me.ID)
                        Me.Status = SerialStatus.Open
                        UpdateSloc()
                    End If
                End If
                _current_qty = qty
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ToQuality(ByVal location As String) As Boolean
            Select Case Me.Status
                Case SerialStatus.Open, SerialStatus.OnCutter, SerialStatus.ServiceOnQuality
                    If SQL.Current.Update("Smk_Serials", {"Status", "RedTag", "RandomLocation", "ServiceLocation"}, {"U", 1, location, location}, "ID", Me.ID) Then
                        InsertMovement(SerialMovement.ToQuality, 0, location, 0, User.Current.Badge)
                        Me.RedTag = True
                        Me.Status = SerialStatus.ServiceOnQuality
                        Me.RandomLocation = location
                        Me.ServiceLocation = location
                        Return True
                    Else
                        Return False
                    End If
                Case Else
                    If SQL.Current.Update("Smk_Serials", {"Status", "RedTag", "RandomLocation", "ServiceLocation"}, {"Q", 1, location, location}, "ID", Me.ID) Then
                        InsertMovement(SerialMovement.ToQuality, 0, location, 0, User.Current.Badge)
                        Me.RedTag = True
                        Me.Status = SerialStatus.Quality
                        Me.RandomLocation = location
                        Me.ServiceLocation = location
                        Return True
                    Else
                        Return False
                    End If
            End Select
    End Function

    Public Function ToTracker(ByVal location As String) As Boolean
        If SQL.Current.Update("Smk_Serials", New String() {"Status", "InvoiceTrouble", "RandomLocation", "ServiceLocation"}, New Object() {"T", 1, location, location}, "ID", Me.ID) Then
            InsertMovement(SerialMovement.ToTracker, 0, location, 0, User.Current.Badge)
            Me.InvoiceTrouble = True
            Me.Status = SerialStatus.Tracker
            Me.RandomLocation = location
            Me.ServiceLocation = location
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TrackerPartialDiscount(ByVal quantity As Decimal) As Boolean
        If InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            SQL.Current.Insert("Rec_TrackerDeliveredQuantities", New String() {"SerialID", "Quantity"}, New Object() {Me.ID, quantity})
            _current_qty -= quantity
            If _current_qty = 0 Then ReportMinMax()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TrackerPartialDiscount(ByVal quantity As Decimal, badge As String) As Boolean
        If InsertMovement(SerialMovement.TrackerPartialDiscount, -quantity, "", 0, badge) Then
            SQL.Current.Insert("Rec_TrackerDeliveredQuantities", New String() {"SerialID", "Quantity"}, New Object() {Me.ID, quantity})
            _current_qty -= quantity
            If _current_qty = 0 Then ReportMinMax()
            Return True
        Else
            Return False
        End If
    End Function

    Private Property LastMovementID As Integer

    Private Function InsertMovement(movement As SerialMovement, quantity As Decimal, location As String, seconds As Integer, badge As String) As Boolean
        'quantity = cantidad que se descuenta a la serie
        If SQL.Current.Insert("Smk_SerialMovements", {"SerialID", "Movement", "Quantity", "Badge", "Location", "Seconds"}, {Me.ID, MovementCode(movement), quantity, badge, location, seconds}) Then
            LastMovementID = SQL.Current.GetScalar("MAX(ID)", "Smk_SerialMovements", {"SerialID", "Movement"}, {Me.ID, MovementCode(movement)})
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MovementCode(movement As SerialMovement) As String
        Select Case movement
            Case SerialMovement.ChangeCutter
                Return "CCR"
            Case SerialMovement.ChangeLocation
                Return "CLN"
            Case SerialMovement.DeclareEmpty
                Return "DEY"
            Case SerialMovement.DeclareEmptyByRoute
                Return "DER"
            Case SerialMovement.DiscountByRoute
                Return "PDR"
            Case SerialMovement.ManualAdjustment
                Return "MAT"
            Case SerialMovement.MoverPartialDiscount
                Return "MPD"
            Case SerialMovement.MoverTransference
                Return "MTE"
            Case SerialMovement.OpenContainer
                Return "OCR"
            Case SerialMovement.PartialDiscount
                Return "PDT"
            Case SerialMovement.ReturnFromEmpty
                Return "RFE"
            Case SerialMovement.ReturnToRandom
                Return "RTR"
            Case SerialMovement.StoreContainer
                Return "SCR"
            Case SerialMovement.ToQuality
                Return "TQY"
            Case SerialMovement.ToService
                Return "TSE"
            Case SerialMovement.ToTracker
                Return "TTT"
            Case SerialMovement.TrackerPartialDiscount
                Return "TPD"
            Case SerialMovement.TransferRandom
                Return "TRM"
            Case SerialMovement.TransferRandomToService
                Return "TRS"
            Case SerialMovement.TransferService
                Return "TTS"
            Case Else
                Return ""
        End Select
    End Function

    Private Function InsertTransfer(id_movement As Integer, quantity As Decimal, from_sloc As String, to_sloc As String) As Boolean
        'quantity = cantidad que se transfiere entre slocs
        If from_sloc = to_sloc Then
            Return True
            'Return SQL.Current.Insert("Smk_SAPTransfers", {"MovementID", "Quantity", "FromSloc", "ToSloc", "Posted", "DocumentNumber", "PostedUsername"}, {id_movement, quantity, from_sloc, to_sloc, 1, "Delta Validation", User.Current.Username})
        Else
            Return SQL.Current.Insert("Smk_SAPTransfers", {"MovementID", "Quantity", "FromSloc", "ToSloc"}, {id_movement, quantity, from_sloc, to_sloc})
        End If
    End Function

    Public Property RandomSloc As String

    Public Property ServiceSloc As String

    Public Property DullSloc As String

    Private Function GetRandomSloc(warehouse As String) As String
        Return SQL.Current.GetString("RandomSloc", "Smk_SAPSlocs", {"Warehouse", "Process"}, {warehouse, Me.Consumption.ToString}, "")
    End Function

    Private Function GetServiceSloc(warehouse As String) As String
        Return SQL.Current.GetString("ServiceSloc", "Smk_SAPSlocs", {"Warehouse", "Process"}, {warehouse, Me.Consumption.ToString}, "")
    End Function

    Private Function GetDullSloc(warehouse As String) As String
        Return SQL.Current.GetString("DullSloc", "Smk_SAPSlocs", {"Warehouse", "Process"}, {warehouse, Me.Consumption.ToString}, "")
    End Function

    Public Enum SerialStatus
        [New]
        Pending
        Stored
        Open
        OnCutter
        Empty
        Deleted
        Quality
        Tracker
        Unexist
        ServiceOnQuality
    End Enum

    Public Enum SerialMovement
        StoreContainer
        OpenContainer
        MoverPartialDiscount
        MoverTransference
        PartialDiscount
        TrackerPartialDiscount
        DiscountByRoute
        DeclareEmpty
        DeclareEmptyByRoute
        TransferRandom
        TransferService
        TransferRandomToService
        ChangeLocation
        ChangeCutter
        ToService
        ReturnToRandom
        ReturnFromEmpty
        ManualAdjustment
        ToTracker
        ToQuality
    End Enum
End Class
