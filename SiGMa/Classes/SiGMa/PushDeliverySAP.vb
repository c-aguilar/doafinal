Imports System.Data.SqlClient
Imports System.IO

Public Class PushDeliverySAP
    Public Function LM00_4_5_1_2(plant As String, delivery_type As String, shipping_point As String, ship_to As String, sales_org As String, dist_chl As String, division As String, sloc As String,
                                 header_text As String, ByRef items As List(Of PushDeliveryPallet)) As PushDeliveryResult
        Dim result As New PushDeliveryResult
        result.Finished = False
        Try
            Dim sap As SAP = New SAP()
            sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/nLM00"
            sap.Session.findById("wnd[0]").sendVKey(0)
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/btnRLMOB-PSAVE").press() 'F1/SAVE
            sap.Session.findById("wnd[0]/usr/btnTEXT4").press() 'SHIPPING
            sap.Session.findById("wnd[0]/usr/btnTEXT5").press() 'PUSH DELIVERY
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-WERKS").text = plant
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "1" 'CREATE
            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DELV_TYPE").text = delivery_type
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-VKORG").text = sales_org
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-VSTEL").text = shipping_point
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-VTWEG").text = dist_chl
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-SHIP_TO").text = ship_to
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-SPART").text = division
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LGORT").text = sloc
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-HTEXT").text = header_text
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0150").text = "2" 'Select
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0150").setFocus()
            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
            sap.Check_System()

            'LEER DUMMY DELIVERY
            result.DummyDelivery = sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DELIVERY").text.ToString.Trim

            For Each pallet As PushDeliveryPallet In items
                'COLOCAR NP DE PALLET Y LABEL
                sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").text = pallet.ContainerNumber
                sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").setFocus()
                sap.Session.findById("wnd[0]").sendVKey(0)
                sap.Check_System()


                'CACHAR SI HAY ERROR Y TERMINAR EL PROCESO
                If sap.Session.findById("wnd[0]/usr/txtV_ERROR_TEXT", False) IsNot Nothing Then
                    result.ErrorMessage = String.Join(" ", sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[0,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[2,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[3,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[4,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[5,0]").text.ToString.Trim).Trim

                    'SALIR DE LM00
                    sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/n"
                    sap.Session.findById("wnd[0]").sendVKey(0)
                    Return result
                End If

                sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").text = pallet.PushDeliveryLabels.Item(0)
                sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").setFocus()
                sap.Session.findById("wnd[0]").sendVKey(0)
                sap.Check_System()

                'CACHAR SI HAY ERROR Y TERMINAR EL PROCESO
                If sap.Session.findById("wnd[0]/usr/txtV_ERROR_TEXT", False) IsNot Nothing Then
                    result.ErrorMessage = String.Join(" ", sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[0,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[2,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[3,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[4,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[5,0]").text.ToString.Trim).Trim
                    sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/n"
                    sap.Session.findById("wnd[0]").sendVKey(0)
                    Return result
                End If

                For Each material In pallet.Items
                    result.LastItemReference = material.ItemReference

                    sap.Session.findById("wnd[0]/usr/txtST_SCREEN-MATNR").text = material.Material
                    sap.Session.findById("wnd[0]/usr/txtST_SCREEN-PICK").text = material.Quantity
                    sap.Session.findById("wnd[0]/usr/txtST_SCREEN-UOM").text = material.UoM
                    sap.Session.findById("wnd[0]/usr/txtST_SCREEN-UOM").setFocus()
                    sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
                    sap.Check_System()

                    'CACHAR ALGUN ERROR
                    If sap.Session.findById("wnd[0]/usr/txtV_ERROR_TEXT", False) IsNot Nothing Then
                        result.ErrorMessage = String.Join(" ", sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[0,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[2,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[3,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[4,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[5,0]").text.ToString.Trim).Trim

                        If result.ErrorMessage.ToLower = "pallet should have all pi materials or non pi materials" Then
                            'CREAR OTRA LABEL
                            sap.Session.findById("wnd[0]/usr/btnBACK").press() 'BACK DEL ERROR
                            sap.Session.findById("wnd[0]/usr/btnCONTINUE").press() 'F1 END
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT008").press() 'FINISH
                            sap.Session.findById("wnd[0]/usr/btnSELECT").press() 'YED
                            sap.Session.findById("wnd[0]/usr/btnBACK").press() 'BACK

                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "4" 'OPCION PRINT
                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
                            sap.Check_System()
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LABEL_QTY").text = "1" 'UNA LABEL
                            sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT007").press() 'IMPRIMIR

                            'LEER NUEVA LABEL
                            Dim message As String = sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text
                            Dim new_label As String = message.Split(" ").GetValue(0).ToString.Trim
                            pallet.PushDeliveryLabels.Add(new_label)
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()

                            'REINGRESAR AL DUMMY DELIVERY
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DELIVERY").text = result.DummyDelivery 'DUMMY DELIVERY INICIAL
                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "2" 'CHANGE
                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
                            sap.Check_System()

                            'COLOCAR NP DE PALLET Y NUEVA LABEL
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").text = pallet.ContainerNumber
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").text = new_label
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Check_System()

                            'INGRESAR EL MATERIAL
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-MATNR").text = material.Material
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-PICK").text = material.Quantity
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-UOM").text = material.UoM
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-UOM").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
                            sap.Check_System()

                            'CACHAR SI HAY OTRO ERRORY TERMINAR EL PROCESO
                            If sap.Session.findById("wnd[0]/usr/txtV_ERROR_TEXT", False) IsNot Nothing Then
                                result.ErrorMessage = String.Join(" ", sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[0,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[2,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[3,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[4,0]").text.ToString.Trim, sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[5,0]").text.ToString.Trim).Trim

                                'SALIR DE LM00
                                sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/n"
                                sap.Session.findById("wnd[0]").sendVKey(0)
                                Return result
                            End If


                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LOGREF").text = material.LogisticsReferenceNumber
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LOGREF").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-STACK_CODE").text = material.StackCode
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-STACK_CODE").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DAMAGE_CODE").text = IIf(material.Damage, "1", "2") '?? 
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DAMAGE_CODE").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)

                            'FINALIZAR LA NUEVA LABEL Y REGRESAR A LA ANTERIOR
                            sap.Session.findById("wnd[0]/usr/btnCONTINUE").press()
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/btnSELECT").press()
                            sap.Session.findById("wnd[0]/usr/btnBACK").press()
                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "2"
                            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Check_System()
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").text = pallet.ContainerNumber
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONTAINER").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Check_System()
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").text = pallet.PushDeliveryLabels.Item(0) 'LABEL ANTERIOR
                            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-CONT#").setFocus()
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            sap.Check_System()
                            sap.Session.findById("wnd[0]/usr/btnSELECT").press()
                            result.ErrorMessage = ""
                        Else
                            'ERROR NO CONTROLADO, SALIR DE LM00
                            sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/n"
                            sap.Session.findById("wnd[0]").sendVKey(0)
                            Return result
                        End If
                    Else
                        'CONTINUAR CON LOS DEMAS DATOS
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LOGREF").text = material.LogisticsReferenceNumber
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LOGREF").setFocus()
                        sap.Session.findById("wnd[0]").sendVKey(0)
                        sap.Check_System()
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-STACK_CODE").text = material.StackCode
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-STACK_CODE").setFocus()
                        sap.Session.findById("wnd[0]").sendVKey(0)
                        sap.Check_System()
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DAMAGE_CODE").text = IIf(material.Damage, "1", "2") '?? 
                        sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DAMAGE_CODE").setFocus()
                        sap.Session.findById("wnd[0]").sendVKey(0)
                        sap.Check_System()
                    End If
                Next
                'TERMINAR EL PALLET
                sap.Session.findById("wnd[0]/usr/btnCONTINUE").press() 'F1 END
                sap.Session.findById("wnd[0]/usr/btnBACK").press() 'NO PRINT
                sap.Session.findById("wnd[0]/usr/btnBACK").press() 'F3 BACK ---------------------------------------
            Next
            'TERMINAR EL DELIVERY
            sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT008").press() 'F8 FINISH
            sap.Session.findById("wnd[0]/usr/btnSELECT").press() 'YES
            sap.Session.findById("wnd[0]/usr/btnBACK").press() 'F3 BACK

            'POSTEAR EL DELIVERY

            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DELIVERY").text = result.DummyDelivery
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "3" 'OPCION POST
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
            sap.Session.findById("wnd[0]").sendVKey(0)
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/btnPB_POST").press()
            sap.Session.findById("wnd[0]/usr/btnBACK").press()

            While result.SAPDelivery = ""
                sap.Session.findById("wnd[0]/usr/txtST_SCREEN-DELIVERY").text = result.DummyDelivery
                sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "3" 'OPCION DISPLAY
                sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
                sap.Session.findById("wnd[0]").sendVKey(0)
                sap.Check_System()
                result.SAPDelivery = sap.Session.findById("wnd[0]/usr/txtTBL_ZMDEPUSHDELVHDR-DELIVERY").text.ToString.Trim 'SAP DELIVERY
                sap.Session.findById("wnd[0]/usr/btnBACK").press()
            End While

            'SALIR DE LM00
            sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/n"
            sap.Session.findById("wnd[0]").sendVKey(0)
            result.Finished = True
        Catch ex As Exception
            result.Finished = False
        End Try
        Return result
    End Function

    Public Function LM00_4_5_4(plant As String, quantity As Integer, Optional printer As String = "") As PushDeliveryLabels
        Dim result As New PushDeliveryLabels
        Try
            Dim sap As SAP = New SAP()
            sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/nLM00"
            sap.Session.findById("wnd[0]").sendVKey(0)
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/btnRLMOB-PSAVE").press() 'F1/SAVE
            sap.Session.findById("wnd[0]/usr/btnTEXT4").press() 'SHIPPING
            sap.Session.findById("wnd[0]/usr/btnTEXT5").press() 'PUSH DELIVERY
            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-WERKS").text = plant
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").text = "4" 'PRINT LABEL
            sap.Session.findById("wnd[0]/usr/txtV_OPTION_0100").setFocus()
            sap.Session.findById("wnd[0]").sendVKey(0) 'ENTER
            sap.Check_System()

            If printer <> "" Then
                sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT008").press()
                sap.Session.findById("wnd[0]/usr/txtST_PRINTER_SCREEN-V_PRNTR_CODE").text = printer
                sap.Session.findById("wnd[0]/usr/txtST_PRINTER_SCREEN-V_PRNTR_CODE").setFocus()
                sap.Session.findById("wnd[0]").sendVKey(0)
            End If

            sap.Session.findById("wnd[0]/usr/txtST_SCREEN-LABEL_QTY").text = quantity
            sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT007").press() 'PRINT
            sap.Check_System()
            Dim message As String = sap.Session.findById("wnd[0]/usr/sub:SAPMZMDEPD:1400/txtTBL_ERROR_DATA[1,0]").text
            sap.Session.findById("wnd[0]/usr/btnBACK").press()
            sap.Session.findById("wnd[0]/usr/btn%#AUTOTEXT004").press()
            sap.Session.findById("wnd[0]/usr/btnRLMOB-PBACK").press()
            sap.Session.findById("wnd[0]/usr/btnRLMOB-PBACK").press()

            message = message.ToLower.Trim.Trim(".")
            Dim [from], [to] As Double
            [from] = CDbl(message.Split(" ").GetValue(0))
            [to] = CDbl(message.Split(" ").GetValue(2))
            Dim len As Integer = message.Split(" ").GetValue(0).ToString.Trim.Length
            For i = [from] To [to]
                result.Items.Add(Strings.Right("0000000000000000" & i, len))
            Next
            result.Created = True
        Catch ex As Exception
            result.Created = False
            result.Items.Clear()
        End Try
        Return result
    End Function

    Public Class PushDeliveryLabels
        Public Property Created As Boolean = False
        Public Property Items As New List(Of String)
    End Class

    Public Class PushDeliveryResult
        Public Property Finished As Boolean = False
        Public Property DummyDelivery As String
        Public Property SAPDelivery As String
        Public Property ErrorMessage As String
        Public Property LastItemReference As String
    End Class

    Public Class PushDeliveryPallet
        Public Property ContainerNumber As String
        Public Property Items As New List(Of MaterialItem)
        Public Property PushDeliveryLabels As New List(Of String)
        Public Class MaterialItem
            Public Property Material As String
            Public Property Quantity As Decimal
            Public Property LogisticsReferenceNumber As String 'GUIA
            Public Property UoM As String
            Public Property StackCode As String 'default 0
            Public Property Damage As Boolean 'default vacio
            Public Property ItemReference As String '
        End Class
    End Class

    Public Class MaterialItemContent
        Public Property Material As String
        Public Property Quantity As Decimal
        Public Property LogisticsReferenceNumber As String 'GUIA
        Public Property UoM As String
        Public Property StackCode As String 'default 0
        Public Property Damage As Boolean 'default vacio
        Public Property ItemReference As String '
        Public Property idPallet As String
    End Class

    Public Function getPushDeliveryPallet(idRoute As String, pushDeliveryLabelsList As PushDeliveryLabels) As List(Of PushDeliveryPallet)
        Dim pushDeliveryPalletList As List(Of PushDeliveryPallet) = New List(Of PushDeliveryPallet)
        Dim contentList As List(Of MaterialItemContent) = New List(Of MaterialItemContent)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT IdContainer FROM [Containers] WHERE (IdRoute = {0} AND IsPallet = 1) 
                                            AND IdContainer IN (SELECT IdPallet FROM [Containers] WHERE IdRoute = {0})", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        pushDeliveryPalletList.Add(New PushDeliveryPallet() With {
                                                            .ContainerNumber = Convert.ToString(row.Item("IdContainer"))
                                                        })
                    Next
                End If
            End Using
        End Using
        conn.Close()
        Dim i As Integer = 0
        For Each item In pushDeliveryLabelsList.Items
            For i = i To pushDeliveryPalletList.Count - 1
                pushDeliveryPalletList(i).PushDeliveryLabels.Add(item)
                i = i + 1
                Exit For
            Next
        Next
        Dim connConent As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlqueryContent As String = String.Format("SELECT idPallet, PartNumber, Qty, ISNULL(CarriersGuide,'') AS CarriersGuide, UOM FROM ContainersContent CC INNER JOIN Containers C ON CC.idContainer = C.idContainer WHERE C.idRoute = {0}", idRoute)
        Dim commandContent As SqlCommand = New SqlCommand(sqlqueryContent, connConent)
        Dim dtContent As DataTable = New DataTable()
        Using connConent
            connConent.Open()
            Using reader As SqlDataReader = commandContent.ExecuteReader()
                If (reader.HasRows) Then
                    dtContent.Load(reader)
                    For Each row As DataRow In dtContent.Rows
                        contentList.Add(New MaterialItemContent() With {
                                                            .UoM = Convert.ToString(row.Item("UoM")),
                                                            .StackCode = "0",
                                                            .Quantity = Convert.ToString(row.Item("Qty")),
                                                            .Damage = False,
                                                            .idPallet = Convert.ToString(row.Item("idPallet")),
                                                            .ItemReference = "", 'no se que pedo
                                                            .LogisticsReferenceNumber = Convert.ToString(row.Item("CarriersGuide")),
                                                            .Material = Convert.ToString(row.Item("PartNumber"))
                                                        })
                    Next
                End If
            End Using
        End Using
        connConent.Close()
        For Each x In pushDeliveryPalletList
            For Each var In contentList
                If var.idPallet = x.ContainerNumber Then
                    x.Items.Add(New PushDeliveryPallet.MaterialItem() With {
                                .Material = var.Material,
                                .Damage = var.Damage,
                                .ItemReference = var.ItemReference,
                                .LogisticsReferenceNumber = var.LogisticsReferenceNumber,
                                .Quantity = var.Quantity,
                                .StackCode = var.StackCode,
                                .UoM = var.UoM
                            })
                End If
            Next
            x.ContainerNumber = "C0009381"
        Next
        Return pushDeliveryPalletList
    End Function

    Public Shared regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("APTIV\SiGMa\Settings")

    Public Sub printPushDeliveries(pushDelivery As String, sapPushDelivery As String, idPallet As Integer, plant As String)
        If regKey.GetValue("Printer") Is Nothing OrElse regKey.GetValue("Printer").ToString() = "" And regKey.GetValue("DPI") Is Nothing OrElse regKey.GetValue("DPI").ToString() = "" Then
            MessageBox.Show("Please go to settings and select a printer", "Printer not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim plantName As String = SQL.Current.GetString(String.Format("SELECT [BusinessName] FROM [Sys_Plants] WHERE Plant = '{0}'", plant))
            Dim ZPLquery As String = SQL.Current.GetString(String.Format("SELECT [Value] FROM [Sys_Parameters] WHERE Parameter like 'PushDelivery'+'{0}'+'%'", regKey.GetValue("DPI").ToString()))
            Dim ZPLReplace As String = ZPLquery
            ZPLReplace = ZPLReplace.Replace(".PUSHDEL", sapPushDelivery)
            ZPLReplace = ZPLReplace.Replace(".PLANTNAME", plantName)
            ZPLReplace = ZPLReplace.Replace(".PLANTCODE", plant)
            ZPLReplace = ZPLReplace.Replace(".SERIAL", pushDelivery)
            ZPLReplace = ZPLReplace.Replace(".ID", idPallet)
            'Dim path As String = "c:\temp\zpl.txt"
            'If Not File.Exists(path) Then
            '    Using sw As StreamWriter = File.CreateText(path)
            '        sw.WriteLine(ZPLReplace)
            '    End Using
            'Else
            '    File.Delete(path)
            '    Using sw As StreamWriter = File.CreateText(path)
            '        sw.WriteLine(ZPLReplace)
            '    End Using
            'End If
            ZPL.PrintTo(ZPLReplace, regKey.GetValue("Printer").ToString())
            'File.Copy(path, regKey.GetValue("Printer").ToString())
            'MessageBox.Show("Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class
