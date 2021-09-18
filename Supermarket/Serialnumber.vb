Public Class Serialnumber
    Private _warehouse As String
    Private _warehousename As String
    Private _statusname As String
    Private _status As SerialStatus
    Private _current_qty, _current_qty_bum As Decimal

    Public Sub New(serialnumber As String, partnumber As String, quantity As Decimal, current_quantity As Decimal, current_quantity_bun As Decimal, uom As String, [date] As Date, warehouse As Char, warehousename As String, consumption_type As String, sloc As String, _
                   status As Char, statusname As String, location As String, weight As Decimal, container_id As String, truck As String, _
                   redtag As Boolean, invoicetrouble As Boolean, critical As Boolean, scanner As String, expiration_date As Date, lot As String, id As Integer, material_type As String, random_sloc As String, service_sloc As String, dull_sloc As String, mrp As String, [new] As Boolean, ordering_wipautoincrement As Boolean, is_sensitive As Boolean, master_number As String, link_label As String)
        Me.SerialNumber = serialnumber.ToUpper
        Me.Partnumber = partnumber.ToUpper
        Me.Quantity = quantity
        Me.UoM = RawMaterial.StrToUnitOfMeasure(uom)
        Me.Date = [date]
        _warehouse = warehouse
        _warehousename = warehousename
        Me.Sloc = sloc
        Me.Consumption = RawMaterial.StrToConsumptionType(consumption_type)
        Me.Exists = True
        _status = StrToSerialStatus(status)
        If Me.Status = SerialStatus.Deleted Then Me.Exists = False
        _statusname = statusname
        _current_qty = current_quantity
        _current_qty_bum = current_quantity_bun
        Me.Weight = weight
        Me.ContainerID = container_id
        Me.Location = location
        Me.TruckNumber = truck
        Me.RedTag = redtag
        Me.InvoiceTrouble = invoicetrouble
        Me.Critical = critical
        Me.Scanner = scanner
        Me.ExpirationDate = expiration_date
        Me.Lot = lot
        Me.ID = id
        Me.[New] = [new]
        Me.OrderingWIPAutoincrement = ordering_wipautoincrement
        Me.Type = RawMaterial.StrToMaterialType(material_type)
        Me.RandomSloc = random_sloc
        Me.ServiceSloc = service_sloc
        Me.DullSloc = dull_sloc
        Me.MRP = mrp
        Me.IsSensitive = is_sensitive
        Me.Masternumber = master_number
        Me.Linklabel = link_label
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
            Me.UoM = RawMaterial.StrToUnitOfMeasure(serial.Item("uom"))

            Me.Date = serial.Item("date")
            _warehouse = serial.Item("warehouse")
            _warehousename = serial.Item("warehousename")
            Me.Sloc = serial.Item("sloc")
            Me.Consumption = RawMaterial.StrToConsumptionType(serial.Item("consumptiontype"))
            Me.Exists = True
            _status = StrToSerialStatus(serial.Item("status"))
            If Me.Status = SerialStatus.Deleted Then Me.Exists = False
            _statusname = serial.Item("statusdescription")
            Me.Location = If(serial.Item("location") = "", "", serial.Item("location"))
            Me.Weight = serial.Item("weight")
            Me.ContainerID = serial.Item("containerid")
            Me.TruckNumber = If(serial.Item("trucknumber") = "", "", serial.Item("trucknumber"))
            Me.RedTag = serial.Item("redtag")
            Me.InvoiceTrouble = serial.Item("invoicetrouble")
            Me.Critical = serial.Item("critical")
            Me.Scanner = If(serial.Item("scanner") = "", "", serial.Item("scanner"))
            Me.ExpirationDate = If(serial.Item("expirationdate") = "", New Date(2100, 12, 31), serial.Item("expirationdate"))
            Me.Lot = If(serial.Item("lot") = "", "", serial.Item("lot"))
            Me.ID = serial.Item("id")
            Me.[New] = serial.Item("new")
            Me.Type = RawMaterial.StrToMaterialType(serial.Item("materialtype"))
            Me.RandomSloc = serial.Item("randomsloc")
            Me.ServiceSloc = serial.Item("servicesloc")
            Me.DullSloc = serial.Item("dullsloc")
            Me.MRP = serial.Item("mrp")
            Me.OrderingWIPAutoincrement = serial.Item("orderingwipautoincrement")
            _current_qty = serial.Item("currentquantity")
            _current_qty_bum = serial.Item("currentquantityinbum")
            Me.IsSensitive = CBool(serial.Item("issensitive"))
            Me.Masternumber = serial.Item("masternumber")
            Me.Linklabel = serial.Item("linklabel")
        Else
            Me.Exists = False
            Me.Status = SerialStatus.Unexist
        End If
        serial = Nothing
        GC.Collect()
    End Sub
    Private Shared Function StrToSerialStatus(status As String) As SerialStatus
        Select Case status.ToUpper
            Case "N"
                Return SerialStatus.New
            Case "P"
                Return SerialStatus.Pending
            Case "S"
                Return SerialStatus.Stored
            Case "O"
                Return SerialStatus.Open
            Case "C"
                Return SerialStatus.OnCutter
            Case "E"
                Return SerialStatus.Empty
            Case "Q"
                Return SerialStatus.Quality
            Case "T"
                Return SerialStatus.Tracker
            Case "U"
                Return SerialStatus.ServiceOnQuality
            Case "D"
                Return SerialStatus.Deleted
            Case "R"
                Return SerialStatus.Presupermarket
            Case Else
                Return SerialStatus.Deleted
        End Select
    End Function

    Public Property [New] As Boolean
    Public Property Location As String
    Public Property Exists As Boolean
    Public Property SerialNumber As String
    Public Property Partnumber As String
    Public Property Quantity As Decimal
    Public Property UoM As RawMaterial.UnitOfMeasure
    Public Property MRP As String
    Public Property Type As RawMaterial.MaterialType
    Public Property [Date] As Date
    Public Property OrderingWIPAutoincrement As Boolean = False
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
            Case SerialStatus.Presupermarket
                result = SQL.Current.Update("Smk_Serials", "Status", "R", "ID", Me.ID)
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
                    Case SerialStatus.Presupermarket
                        _statusname = SQL.Current.GetString("Description", "Smk_SerialStatus", "Status", "R", "")
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
    Public Property Weight As Decimal
    Public Property ContainerID As String
    Public Property TruckNumber As String
    Public Property InvoiceTrouble As Boolean
    Public Property RedTag As Boolean
    Public Property Critical As Boolean
    Public Property Scanner As Integer
    Public Property ExpirationDate As Date
    Public Property Lot As String
    Public Property ID As Integer
    Public Property IsSensitive As Boolean
    Public Property Masternumber As String = ""
    Public Property Linklabel As String = ""
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
        'NO SE ESTAN DIFERENCIANDO EL SERVICIO O RESERVA
        If SQL.Current.Update("Smk_Serials", "Location", new_location, "ID", Me.ID) Then
            If Me.Location <> new_location Then InsertMovement(SerialMovement.ChangeLocation, 0, new_location, 0, User.Current.Badge)


            Me.Location = new_location
            Return True
        End If
        Return False
    End Function

    Public Function ChangeLocation(new_location As String, badge As String) As Boolean
        'NO SE ESTAN DIFERENCIANDO EL SERVICIO O RESERVA
        If SQL.Current.Update("Smk_Serials", "Location", new_location, "ID", Me.ID) Then
            If Me.Location <> new_location Then InsertMovement(SerialMovement.ChangeLocation, 0, new_location, 0, badge)
            Me.Location = new_location
            Return True
        End If
        Return False
    End Function

    Public Function Store(location As String) As Boolean
        If InsertMovement(SerialMovement.StoreContainer, 0, location, 0, User.Current.Badge) Then
            'MOVER DEL SLOC 0001 AL CORRECTO CUANDO SEA MATERIAL DE SERVICIOS U OBSOLETOS
            If (Me.Consumption = RawMaterial.ConsumptionType.Service OrElse Me.Consumption = RawMaterial.ConsumptionType.Obsolete) AndAlso "0001" <> Me.RandomSloc Then InsertTransfer(LastMovementID, Me.CurrentQuantity, "0001", Me.RandomSloc)
            If SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"S", location}, "ID", Me.ID) Then
                Me.Status = SerialStatus.Stored
                Me.Location = location
                If Me.CurrentQuantity > 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax(True)
                UpdateSloc()
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Store(location As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.StoreContainer, 0, location, 0, badge) Then
            'MOVER DEL SLOC 0001 AL CORRECTO CUANDO SEA MATERIAL DE SERVICIOS U OBSOLETOS
            If Me.Consumption = RawMaterial.ConsumptionType.Service OrElse Me.Consumption = RawMaterial.ConsumptionType.Obsolete Then InsertTransfer(LastMovementID, Me.CurrentQuantity, "0001", Me.RandomSloc)
            If SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"S", location}, "ID", Me.ID) Then
                Me.Status = SerialStatus.Stored
                Me.Location = location
                If Me.CurrentQuantity > 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax(True)
                'UpdateSloc()
                Return True
            Else
                Return False
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

            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", location}, "ID", Me.ID)
            Me.Location = location
            Me.Status = SerialStatus.Open
            UpdateSloc()

            'REPORTAR EL WIP EN EL MODULO DE ORDERING
            OrderingAutoincrement_WIP()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function OpenAndLink(location As String, link_serial_id As Integer) As Boolean
        If InsertMovement(SerialMovement.OpenAndLink, 0, location, 0, User.Current.Badge) AndAlso SQL.Current.Insert("Smk_LinkLabelMovements", {"LinkID", "SerialID", "Badge"}, {link_serial_id, Me.ID, User.Current.Badge}) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)

            Dim nextserial As String = SMK.NextFIFO(Me.Partnumber, My.Settings.Warehouse)
            If Not nextserial = Me.SerialNumber AndAlso Not nextserial = "" Then 'REPORTAR FIFO QUEBRADO
                SQL.Current.Insert("Smk_BrokenFIFO", {"TakenSerialnumber", "NextSerialnumber", "Badge"}, {Me.SerialNumber, nextserial, User.Current.Badge})
            End If

            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, User.Current.Badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})

            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", location}, "ID", Me.ID)
            Me.Location = location
            Me.Status = SerialStatus.Open
            UpdateSloc()

            'REPORTAR EL WIP EN EL MODULO DE ORDERING
            OrderingAutoincrement_WIP()
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

            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", location}, "ID", Me.ID)
            Me.Location = location
            Me.Status = SerialStatus.Open
            UpdateSloc()
            OrderingAutoincrement_WIP()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function OpenAndLink(location As String, badge As String, link_serial_id As Integer) As Boolean
        If InsertMovement(SerialMovement.OpenAndLink, 0, location, 0, badge) AndAlso SQL.Current.Insert("Smk_LinkLabelMovements", {"LinkID", "SerialID", "Badge"}, {link_serial_id, Me.ID, badge}) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)

            Dim nextserial As String = SMK.NextFIFO(Me.Partnumber, My.Settings.Warehouse)
            If Not nextserial = Me.SerialNumber AndAlso Not nextserial = "" Then 'REPORTAR FIFO QUEBRADO
                SQL.Current.Insert("Smk_BrokenFIFO", {"TakenSerialnumber", "NextSerialnumber", "Badge"}, {Me.SerialNumber, nextserial, badge})
            End If

            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})

            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", location}, "ID", Me.ID)
            Me.Location = location
            Me.Status = SerialStatus.Open
            UpdateSloc()
            OrderingAutoincrement_WIP()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function LinkSerial(ByVal link_serial_id As Integer) As Boolean
        If InsertMovement(SerialMovement.LinkOpenSerial, 0, "", 0, User.Current.Badge) AndAlso SQL.Current.Insert("Smk_LinkLabelMovements", New String() {"LinkID", "SerialID", "Badge"}, New Object() {link_serial_id, Me.ID, User.Current.Badge}) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PartialDiscount(quantity As Decimal) As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, User.Current.Badge) Then
                InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
                SensitiveRegistry(fp_badge)
                If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                _current_qty -= quantity
                Return True
            Else
                Return False
            End If
        ElseIf InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PartialDiscount(quantity As Decimal, badge As String) As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, badge) Then
                InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
                SensitiveRegistry(fp_badge)
                If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                _current_qty -= quantity
                Return True
            Else
                Return False
            End If
        ElseIf InsertMovement(SerialMovement.PartialDiscount, -quantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CriticalBinDiscount(quantity As Decimal, kanban_id As Integer) As Boolean
        If InsertMovement(SerialMovement.CriticalBinDiscount, -quantity, Right("00000000" & kanban_id, 8), 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            SQL.Current().Execute(String.Format("UPDATE DDR_CartsLoopKanbans SET [Status] = 'C' WHERE Kanban = {0} AND [Status] IN ('H','M');", kanban_id))
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty -= quantity
            Return True
        End If
        Return False
    End Function

    Public Function CriticalBinDiscount(quantity As Decimal, kanban_id As Integer, badge As String) As Boolean
        If InsertMovement(SerialMovement.CriticalBinDiscount, -quantity, Right("00000000" & kanban_id, 8), 0, badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            SQL.Current().Execute(String.Format("UPDATE DDR_CartsLoopKanbans SET [Status] = 'C' WHERE Kanban = {0} AND [Status] IN  ('H','M');", kanban_id))
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty -= quantity
            Return True
        End If
        Return False
    End Function

    Public Function DiscountByRewind(quantity As Decimal, badge As String) As Boolean
        If InsertMovement(SerialMovement.RewindCableBarrel, -quantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.ServiceSloc)
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MoverPartialDiscount(quantity As Decimal) As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
                InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
                SensitiveRegistry(fp_badge)
                If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                _current_qty -= quantity
                Return True
            Else
                Return False
            End If
        ElseIf InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MoverPartialDiscount(quantity As Decimal, sloc As String) As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
                InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
                If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                _current_qty -= quantity
                SensitiveRegistry(fp_badge)
                'Mover la cantidad de inventario al sloc segun el tipo de Mover
                InsertMovement(SerialMovement.MoverTransference, 0, "", 0, User.Current.Badge)
                InsertTransfer(LastMovementID, quantity, Me.DullSloc, sloc)
                Return True
            Else
                Return False
            End If
        ElseIf InsertMovement(SerialMovement.MoverPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, quantity, Me.Sloc, Me.DullSloc)
            If _current_qty - quantity = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
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
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso InsertMovement(SerialMovement.ManualAdjustment, new_quantity - _current_qty, "", 0, User.Current.Badge) Then
                SensitiveRegistry(fp_badge)
                _current_qty = new_quantity
                UpdateAuditDate()
                Return True
            Else
                Return False
            End If
        ElseIf InsertMovement(SerialMovement.ManualAdjustment, new_quantity - _current_qty, "", 0, User.Current.Badge) Then
            _current_qty = new_quantity
            UpdateAuditDate()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function APIAdjust(new_quantity As Decimal, new_weight As Decimal, container_id As String) As Boolean
        If InsertMovement(SerialMovement.APIAdjustment, new_quantity - _current_qty, "", 0, User.Current.Badge) Then
            SQL.Current.Update("Smk_Serials", {"Status", "Weight", "ContainerID"}, {"O", new_weight, container_id}, "ID", Me.ID)
            _current_qty = new_quantity
            Me.Weight = new_weight
            Me.ContainerID = container_id
            UpdateAuditDate()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SensitiveRegistry(badge As String)
        SQL.Current.Insert("Smk_SensitiveRegistry", {"MovementID", "Badge"}, {Me.LastMovementID, badge})
    End Sub

    Public Function DiscountByRoute(kanbanloop_delta_id As Integer, quantity_bum As Decimal, badge As String) As Boolean 'ESTA FUNCION SOLO DEBE RECIBIR CANTIDADES EN BUM Y LA SERIE NUNCA DEBE ESTAR EN CERO
        If Me.CurrentQuantityInBum > 0 Then
            If Not (Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive) Then
                Dim quantity_uom As Decimal = quantity_bum / (Me.CurrentQuantityInBum / Me.CurrentQuantity) 'FORMULA PARA CONVERTIR LA CANTIDAD DE BUM A UOM
                If InsertMovement(SerialMovement.DiscountByRoute, -quantity_uom, "", 0, badge) Then
                    InsertTransfer(LastMovementID, quantity_uom, Me.Sloc, Me.DullSloc)
                    SQL.Current.Insert("CDR_SerialDiscounts", {"IDKanbanLoop", "IDSerialMovement"}, {kanbanloop_delta_id, LastMovementID}) 'REGISTRAR LA KANBAN SCANNEADA A LA QUE CORRESPONDE EL DESCUENTO
                    If _current_qty - quantity_uom = 0 AndAlso Parameter("Smk_AutoMinMaxReport", False) Then ReportMinMax()
                    _current_qty -= quantity_uom
                    Return True
                Else
                    Return False
                End If
            Else
                FlashAlerts.ShowError("Material Sensitivo.")
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function DeclareEmpty(badge As String)
        If InsertMovement(SerialMovement.DeclareEmpty, -Me.CurrentQuantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
            If Me.Status = SerialStatus.Stored OrElse Me.Status = SerialStatus.Quality OrElse Me.Status = SerialStatus.Tracker Then
                'DESACTIVAR ALERTAS DE MATERIAL FALTANTE DE RUTAS
                SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})
            End If
            Me.UpdateStatus(SerialStatus.Empty)
            If Me.Type = RawMaterial.MaterialType.Cable Then SQL.Current.Delete("Smk_CableNextSerials", "Serialnumber", Me.SerialNumber)
            If Parameter("Smk_AutoMinMaxReport", False) AndAlso _current_qty > 0 Then ReportMinMax()
            _current_qty = 0
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub OrderingAutoincrement_WIP()
        If Me.Consumption = RawMaterial.ConsumptionType.Total AndAlso Me.OrderingWIPAutoincrement AndAlso Me.CurrentQuantity > 0 Then SQL.Current.Execute(String.Format("EXEC sp_CR_IncrementWIP '{0}', {1}, '{2}';", Me.Partnumber, Me.CurrentQuantity, Me.UoM.ToString))
    End Sub

    Private Function DeclareEmptyByDiscrepancy(badge As String)
        If InsertMovement(SerialMovement.DeclareEmptyByDiscrepancy, -Me.CurrentQuantity, "", 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
            'ESTA FUNCION NO DEBE QUITAR ALERTAS DE FALTANTES EN RUTAS
            Me.UpdateStatus(SerialStatus.Empty)
            If Me.Type = RawMaterial.MaterialType.Cable Then SQL.Current.Delete("Smk_CableNextSerials", "Serialnumber", Me.SerialNumber)
            If Parameter("Smk_AutoMinMaxReport", False) AndAlso _current_qty > 0 Then ReportMinMax()
            _current_qty = 0
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Empty() As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            If User.Current.HasPermission("Supermarket_SkipSensitiveControl_flag") Then
                If Me.DeclareEmpty(User.Current.Badge) Then
                    SensitiveRegistry(User.Current.Badge)
                    Return True
                Else
                    Return False
                End If
            Else
                Dim fp_badge As String = Fingerprint.GetBadge()
                If fp_badge <> "" AndAlso Me.DeclareEmpty(User.Current.Badge) Then
                    SensitiveRegistry(fp_badge)
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return Me.DeclareEmpty(User.Current.Badge)
        End If
    End Function


    Public Function Empty(badge As String) As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso Me.DeclareEmpty(badge) Then
                SensitiveRegistry(fp_badge)
                Return True
            Else
                Return False
            End If
        Else
            Return Me.DeclareEmpty(badge)
        End If
    End Function

    Public Function EmptyByRoute(badge As String) As Boolean
        If Not (Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive) Then
            If InsertMovement(SerialMovement.DeclareEmptyByRoute, -Me.CurrentQuantity, "", 0, badge) Then
                InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.DullSloc)
                Me.UpdateStatus(SerialStatus.Empty)
                If Parameter("Smk_AutoMinMaxReport", False) AndAlso _current_qty > 0 Then ReportMinMax()
                _current_qty = 0
                Me.Status = SerialStatus.Empty
                UpdateSloc()
                Return True
            Else
                Return False
            End If
        Else
            FlashAlerts.ShowError("Material Sensitivo.")
            Return False
        End If
    End Function

    Public Function EmptyByDiscrepancy() As Boolean
        If Parameter("SMK_SensitiveFingerprintRegistry", False) AndAlso Me.IsSensitive Then
            Dim fp_badge As String = Fingerprint.GetBadge()
            If fp_badge <> "" AndAlso Me.DeclareEmptyByDiscrepancy(User.Current.Badge) Then
                SensitiveRegistry(fp_badge)
                Return True
            Else
                Return False
            End If
        Else
            Return Me.DeclareEmptyByDiscrepancy(User.Current.Badge)
        End If
    End Function

    Private Sub ReportMinMax(Optional ByVal is_store As Boolean = False)
        If is_store Then
            SQL.Current.Execute(String.Format("EXEC sp_Smk_ReportMinMax '{0}',{1},'{2}','{3}',1;", Me.SerialNumber, Me.CurrentQuantity, Me.UoM.ToString, Me.Partnumber))
        Else
            SQL.Current.Execute(String.Format("EXEC sp_Smk_ReportMinMax '{0}',{1},'{2}','{3}',0;", Me.SerialNumber, Me.CurrentQuantity, Me.UoM.ToString, Me.Partnumber))
        End If
    End Sub

    Private Sub UpdateAuditDate()
        SQL.Current.Execute("UPDATE Smk_Serials SET LastAudit = GETDATE() WHERE ID = " & Me.ID)
    End Sub

    '========================SOLO CABLES Y TERMINALES ===========================
    Public Function RandomToCutter(new_weight As Decimal, cutter_id As String, badge As String, Optional container_id As String = "") As Boolean
        If Me.Type = RawMaterial.MaterialType.Cable AndAlso InsertMovement(SerialMovement.RandomToCutter, 0, cutter_id, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)
            SQL.Current.Update("Smk_Serials", {"Status", "Location", "Weight", "ContainerID"}, {"C", RawMaterial.GetServiceLocation(Me.Partnumber, My.Settings.Warehouse), new_weight, container_id}, "ID", Me.ID)
            Me.Status = SerialStatus.OnCutter
            Me.Weight = Weight
            Me.ContainerID = container_id
            UpdateSloc()
            SQL.Current.Delete("Smk_CableNextSerials", "Serialnumber", Me.SerialNumber) 'Por si estuviera en pendiente por surtir
            UpdateAuditDate()
            Log(String.Format("{0}|{1}|{2}", Me.SerialNumber, new_weight, container_id), "Smk_CableInitialWeight")
            Return True
        ElseIf (Me.Type = RawMaterial.MaterialType.Terminal OrElse Me.Type = RawMaterial.MaterialType.Calibre) AndAlso InsertMovement(SerialMovement.RandomToCutter, 0, cutter_id, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)
            SQL.Current.Update("Smk_Serials", {"Status", "Location", "Weight"}, {"C", RawMaterial.GetServiceLocation(Me.Partnumber, My.Settings.Warehouse), new_weight}, "ID", Me.ID)
            Me.Status = SerialStatus.OnCutter
            Me.Weight = Weight
            Me.ContainerID = container_id
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    '========================SOLO CABLES Y TERMINALES ===========================
    Public Function RandomToService(new_weight As Decimal, badge As String, Optional container_id As String = "") As Boolean
        If Me.Type = RawMaterial.MaterialType.Cable AndAlso InsertMovement(SerialMovement.RandomToService, 0, Location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)
            SQL.Current.Update("Smk_Serials", {"Status", "Location", "Weight", "ContainerID"}, {"O", RawMaterial.GetServiceLocation(Me.Partnumber, My.Settings.Warehouse), new_weight, container_id}, "ID", Me.ID)
            Me.Status = SerialStatus.Open
            Me.Weight = Weight
            Me.ContainerID = container_id
            UpdateSloc()
            SQL.Current.Delete("Smk_CableNextSerials", "Serialnumber", Me.SerialNumber) 'Por si estuviera en pendiente por surtir
            UpdateAuditDate()
            Log(String.Format("{0}|{1}|{2}", Me.SerialNumber, new_weight, container_id), "Smk_SerialInitialWeight")
            Return True
        ElseIf (Me.Type = RawMaterial.MaterialType.Terminal OrElse Me.Type = RawMaterial.MaterialType.Calibre) AndAlso InsertMovement(SerialMovement.RandomToService, 0, Location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.ServiceSloc)
            SQL.Current.Update("Smk_Serials", {"Status", "Location", "Weight"}, {"O", RawMaterial.GetServiceLocation(Me.Partnumber, My.Settings.Warehouse), new_weight}, "ID", Me.ID)
            Me.Status = SerialStatus.Open
            Me.Weight = Weight
            UpdateSloc()
            UpdateAuditDate()
            Log(String.Format("{0}|{1}|{2}", Me.SerialNumber, new_weight, container_id), "Smk_SerialInitialWeight")
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ServiceToCutter(cutter_id As String, badge As String) As Boolean
        If (Me.Type = RawMaterial.MaterialType.Cable OrElse Me.Type = RawMaterial.MaterialType.Terminal OrElse Me.Type = RawMaterial.MaterialType.Calibre) AndAlso InsertMovement(SerialMovement.ServiceToCutter, 0, cutter_id, 0, badge) Then
            Me.UpdateStatus(SerialStatus.OnCutter)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CutterToService(new_quantity As Decimal, new_weight As Decimal, badge As String) As Boolean
        If (Me.Type = RawMaterial.MaterialType.Cable OrElse Me.Type = RawMaterial.MaterialType.Terminal OrElse Me.Type = RawMaterial.MaterialType.Calibre) AndAlso InsertMovement(SerialMovement.ToService, new_quantity - Me.CurrentQuantity, Me.Location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity - new_quantity, Me.Sloc, Me.DullSloc)
            _current_qty = new_quantity
            Me.UpdateStatus(SerialStatus.Open)
            Me.SetWeight(new_weight)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CutterToService(new_quantity As Decimal, badge As String) As Boolean
        If (Me.Type = RawMaterial.MaterialType.Cable OrElse Me.Type = RawMaterial.MaterialType.Terminal OrElse Me.Type = RawMaterial.MaterialType.Calibre) AndAlso InsertMovement(SerialMovement.ToService, new_quantity - Me.CurrentQuantity, Me.Location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity - new_quantity, Me.Sloc, Me.DullSloc)
            _current_qty = new_quantity
            Me.UpdateStatus(SerialStatus.Open)
            Return True
        Else
            Return False
        End If
    End Function



    Public Function SetWeight(weight As Decimal) As Boolean
        If SQL.Current.Update("Smk_Serials", "Weight", weight, "ID", Me.ID) Then
            Me.Weight = weight
            UpdateAuditDate()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SetWeight(weight As Decimal, container_id As String) As Boolean
        If SQL.Current.Update("Smk_Serials", {"Weight", "ContainerID"}, {weight, container_id}, "ID", Me.ID) Then
            Me.Weight = weight
            Me.ContainerID = container_id
            UpdateAuditDate()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ChangeCutter(cutter_id As String, badge As String) As Boolean
        Return Me.Status = SerialStatus.OnCutter AndAlso InsertMovement(SerialMovement.ChangeCutter, 0, cutter_id, 0, badge)
    End Function

    '^ ================================ SOLO CABLES ========================================================== ^

    Public Function TransferRandom(new_location As String, new_warehouse As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandom, 0, new_location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetRandomSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"Location"}, {new_location}, "ID", Me.ID)
            Me.Location = new_location
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
            SQL.Current.Update("Smk_Serials", {"Location"}, {new_location}, "ID", Me.ID)
            Me.Location = new_location
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
            SQL.Current.Update("Smk_Serials", {"Location"}, {new_location}, "ID", Me.ID)
            Me.Location = new_location
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
            SQL.Current.Update("Smk_Serials", {"Location"}, {new_location}, "ID", Me.ID)
            Me.Location = new_location
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
            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", new_location}, "ID", Me.ID)
            Me.Location = new_location
            Me.Warehouse = new_warehouse
            Me.Status = SerialStatus.Open
            UpdateSloc()
            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, User.Current.Badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TransferRandomToService(new_location As String, new_warehouse As String, badge As String) As Boolean
        If InsertMovement(SerialMovement.TransferRandomToService, 0, new_location, 0, badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, GetServiceSloc(new_warehouse))
            SQL.Current.Update("Smk_Serials", {"Status", "Location"}, {"O", new_location}, "ID", Me.ID)
            Me.Location = new_location
            Me.Warehouse = new_warehouse
            Me.Status = SerialStatus.Open
            UpdateSloc()
            'DESACTIVAR ALERTAS DE MATERIAL FALTANTE
            SQL.Current.Update("Smk_MissingAlerts", {"Active", "AnswerBy", "Answer", "SerialID"}, {0, badge, "Surtido por supermercado.", Me.ID}, {"Partnumber", "Active"}, {Me.Partnumber, 1})
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ReturnToRandom(location As String) As Boolean
        If InsertMovement(SerialMovement.ReturnToRandom, 0, location, 0, User.Current.Badge) Then
            InsertTransfer(LastMovementID, Me.CurrentQuantity, Me.Sloc, Me.RandomSloc)
            Me.UpdateStatus(SerialStatus.Stored)
            SQL.Current.Update("Smk_Serials", "Location", location, "ID", Me.ID)
            Me.Location = location
            UpdateSloc()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ReturnFromEmpty() As Boolean
        Dim qty As Decimal = SQL.Current.GetScalar(String.Format("SELECT TOP 1 ABS(Quantity) FROM Smk_SerialMovements WHERE SerialID = {0} AND Movement = '{1}' ORDER BY [Date] DESC", Me.ID, MovementCode(SerialMovement.DeclareEmpty)), 0)
        Dim empty_id As Integer = SQL.Current.GetScalar(String.Format("SELECT TOP 1 ID FROM Smk_SerialMovements WHERE SerialID = {0} AND Movement = '{1}' ORDER BY [Date] DESC", Me.ID, MovementCode(SerialMovement.DeclareEmpty)), 0)
        If InsertMovement(SerialMovement.ReturnFromEmpty, qty, "", 0, User.Current.Badge) Then
            'BUSCAR SI YA SE POSTEO EL DECLARADO VACIO
            'ID = 0 SIGNIFICA QUE NO HAY UN MOVIMIENTO DE TRANSFERENCIA PARA CANCELAR
            If empty_id = 0 OrElse SQL.Current.Exists("Smk_SAPTransfers", {"MovementID", "Posted"}, {empty_id, 1}) Then 'YA SE POSTEO O NO HAY UN MOVIMIENTO Z11 PARA CANCELAR, POR LO TANTO SE VA A REGISTRAR LA TRANSFERENCIA DE REVERSA
                If Me.Consumption = RawMaterial.ConsumptionType.Total OrElse (Me.Type = RawMaterial.MaterialType.Cable AndAlso Me.Weight <= 0) Then 'POR SI UN BARRIL FUE DECLARADO VACIO SIN PESARLO, Y OBLIGAR AL USUARIO AL VOLVER A PESARLO AL QUERER USARLO
                    InsertTransfer(LastMovementID, qty, Me.Sloc, Me.RandomSloc)
                    Me.UpdateStatus(SerialStatus.Stored)
                    UpdateSloc()
                Else
                    InsertTransfer(LastMovementID, qty, Me.Sloc, Me.ServiceSloc)
                    Me.UpdateStatus(SerialStatus.Open)
                    Me.Status = SerialStatus.Open
                    UpdateSloc()
                End If
            Else 'NO SE HA POSTEADO
                'CANCELAR EL POSTEO
                SQL.Current.Execute(String.Format("UPDATE Smk_SAPTransfers SET Posted = 1, PostedDate = GETDATE(), DocumentNumber = 'MovementCanceled', AdjustmentQuantity = 0, PostedUsername = '{0}' WHERE MovementID = {1};", User.Current.Username, empty_id))
                If Me.Consumption = RawMaterial.ConsumptionType.Total OrElse (Me.Type = RawMaterial.MaterialType.Cable AndAlso Me.Weight <= 0) Then 'POR SI UN BARRIL FUE DECLARADO VACIO SIN PESARLO, Y OBLIGAR AL USUARIO AL VOLVER A PESARLO AL QUERER USARLO
                    Me.UpdateStatus(SerialStatus.Stored)
                    UpdateSloc()
                Else
                    Me.UpdateStatus(SerialStatus.Open)
                    UpdateSloc()
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ToQuality(ByVal location As String) As Boolean
        Select Case Me.Status
            Case SerialStatus.Open, SerialStatus.OnCutter, SerialStatus.ServiceOnQuality
                If SQL.Current.Update("Smk_Serials", {"Status", "RedTag", "Location"}, {"U", 1, location}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.ToQuality, 0, location, 0, User.Current.Badge)
                    Me.RedTag = True
                    Me.Status = SerialStatus.ServiceOnQuality
                    Me.Location = location
                    Return True
                Else
                    Return False
                End If
            Case Else
                If SQL.Current.Update("Smk_Serials", {"Status", "RedTag", "Location"}, {"Q", 1, location}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.ToQuality, 0, location, 0, User.Current.Badge)
                    Me.RedTag = True
                    Me.Status = SerialStatus.Quality
                    Me.Location = location
                    Return True
                Else
                    Return False
                End If
        End Select
    End Function

    Public Function LockQuality() As Boolean
        Select Case Me.Status
            Case SerialStatus.Open, SerialStatus.OnCutter, SerialStatus.ServiceOnQuality
                If SQL.Current.Update("Smk_Serials", {"Status", "RedTag"}, {"U", 1}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.LockQuality, 0, "", 0, User.Current.Badge)
                    Me.RedTag = True
                    Me.Status = SerialStatus.ServiceOnQuality
                    Return True
                Else
                    Return False
                End If
            Case Else
                If SQL.Current.Update("Smk_Serials", {"Status", "RedTag"}, {"Q", 1}, "ID", Me.ID) Then
                    InsertMovement(SerialMovement.LockQuality, 0, "", 0, User.Current.Badge)
                    Me.RedTag = True
                    Me.Status = SerialStatus.Quality
                    Return True
                Else
                    Return False
                End If
        End Select
    End Function

    Public Function UnlockQuality() As Boolean
        If Me.RedTag Then
            If SQL.Current.Update("Smk_Serials", "RedTag", 0, "ID", Me.ID) Then
                InsertMovement(SerialMovement.UnlockQuality, 0, "", 0, User.Current.Badge)
                Me.RedTag = False
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ToTracker(ByVal location As String, issue_id As Integer) As Boolean
        If SQL.Current.Update("Smk_Serials", {"Status", "InvoiceTrouble", "Location"}, {"T", 1, location}, "ID", Me.ID) Then
            InsertMovement(SerialMovement.ToTracker, 0, location, 0, User.Current.Badge)
            SQL.Current.Insert("Rec_TrackerIssueSerials", {"IssueID", "SerialID"}, {issue_id, Me.ID})
            Me.InvoiceTrouble = True
            Me.Status = SerialStatus.Tracker
            Me.Location = location
            Return True
        Else
            Return False
        End If
    End Function

    Public Function UnlockTracker(Optional transfer_0002 As Boolean = True) As Boolean
        If Me.InvoiceTrouble Then
            If SQL.Current.Execute(String.Format("UPDATE Smk_Serials SET [Date] = GETDATE(), InvoiceTrouble = 0 WHERE ID = {0} AND InvoiceTrouble = 1;", Me.ID)) Then 'LE CAMBIA TAMBIEN LA FECHA PARA QUE EL COMPARATIVO DE LA MB51 SALGA CORRECTO
                InsertMovement(SerialMovement.UnlockTracker, 0, "", 0, User.Current.Badge)
                If Me.Consumption = RawMaterial.ConsumptionType.Service OrElse Me.Consumption = RawMaterial.ConsumptionType.Obsolete Then InsertTransfer(LastMovementID, Me.Quantity, "0001", Me.RandomSloc)
                If transfer_0002 AndAlso Me.CurrentQuantity < Me.Quantity Then 'GENERAR TRANSFERENCIA DE MATERIAL TOMADO SIN PAGAR
                    InsertTransfer(LastMovementID, Me.Quantity - Me.CurrentQuantity, Me.RandomSloc, Me.DullSloc)
                End If
                Log(String.Format("{0}|{1}", Me.SerialNumber, Me.Date), "Rec_ReleaseFromTracker") 'SE DEJA EL REGISTRO DEL LOG PARA NO PERDER LA FECHA REAL DE LA LLEGADA DE LA SERIE
                Me.InvoiceTrouble = False
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function TrackerPartialDiscount(ByVal quantity As Decimal) As Boolean
        If InsertMovement(SerialMovement.TrackerPartialDiscount, -quantity, "", 0, User.Current.Badge) Then
            If _current_qty - quantity = 0 Then ReportMinMax() 'EJECUTAR ESTA ACCION ANTES DE DESCONTAR LA CANTIDAD A LA SERIE, NO EDITAR
            _current_qty -= quantity
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TrackerPartialDiscount(ByVal quantity As Decimal, badge As String) As Boolean
        If InsertMovement(SerialMovement.TrackerPartialDiscount, -quantity, "", 0, badge) Then
            If _current_qty - quantity = 0 Then ReportMinMax() 'EJECUTAR ESTA ACCION ANTES DE DESCONTAR LA CANTIDAD A LA SERIE, NO EDITAR
            _current_qty -= quantity
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
            Case SerialMovement.DeclareEmptyByDiscrepancy
                Return "DED"
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
            Case SerialMovement.UnlockQuality
                Return "QYU"
            Case SerialMovement.ToService
                Return "TSE"
            Case SerialMovement.ToTracker
                Return "TTT"
            Case SerialMovement.UnlockTracker
                Return "TTU"
            Case SerialMovement.TrackerPartialDiscount
                Return "TPD"
            Case SerialMovement.TransferRandom
                Return "TRM"
            Case SerialMovement.TransferRandomToService
                Return "TRS"
            Case SerialMovement.TransferService
                Return "TTS"
            Case SerialMovement.ServiceToCutter
                Return "STC"
            Case SerialMovement.RandomToCutter
                Return "RTC"
            Case SerialMovement.RewindCableBarrel
                Return "RCB"
            Case SerialMovement.RandomToService
                Return "RTS"
            Case SerialMovement.LockQuality
                Return "QLK"
            Case SerialMovement.F2F3Disposing
                Return "F23"
            Case SerialMovement.OpenAndLink
                Return "OAL"
            Case SerialMovement.LinkOpenSerial
                Return "LOS"
            Case SerialMovement.CriticalBinDiscount
                Return "CBD"
            Case SerialMovement.APIAdjustment
                Return "API"
            Case SerialMovement.RampToPresupermarket
                Return "RTP"
            Case Else
                Return ""
        End Select
    End Function

    Private Function InsertTransfer(id_movement As Integer, quantity As Decimal, from_sloc As String, to_sloc As String) As Boolean
        'quantity = cantidad que se transfiere entre slocs
        If from_sloc = to_sloc Then
            SQL.Current.Insert("Smk_SAPTransfers", {"MovementID", "Quantity", "FromSloc", "ToSloc", "Posted", "DocumentNumber", "PostedUsername"}, {id_movement, quantity, from_sloc, to_sloc, 1, "Delta Validation", "deltaerp"})
            Return True
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
        Presupermarket
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
        DeclareEmptyByDiscrepancy
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
        UnlockTracker
        ToQuality
        UnlockQuality
        LockQuality
        ServiceToCutter
        RandomToCutter
        RewindCableBarrel
        RandomToService
        F2F3Disposing
        OpenAndLink
        LinkOpenSerial
        CriticalBinDiscount
        APIAdjustment
        RampToPresupermarket
    End Enum
End Class
