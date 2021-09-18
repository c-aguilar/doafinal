Public Class MAn_ZMF47

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Dim sap As New SSAP
        If sap.Available Then
            Dim filename As String = GF.TempTXTPath
            If rbOnlySave.Checked And Partnumber_txt.Text <> "" Then 'SOLO EDITAR
                sap.ZMF47v4("FV38", Partnumber_txt.Text, MinKGnud.Value, MaxKGnud.Value, MinLnud.Value, MaxLnud.Value, MinMnud.Value, MaxMnud.Value, MinPCnud.Value, MaxPCnud.Value)
            ElseIf sap.AQ25SYSTQV000492RPT_ZMF47("FV38", filename, Partnumber_txt.Text) Then
                Dim zmf47 As DataTable = CSV.Datatable(filename, vbTab, True, True, 2)
                filename = GF.TempTXTPath
                If (Partnumber_txt.Text = "" AndAlso sap.ZAPI_MATINFO("FV38", filename, {"0002"})) OrElse (Partnumber_txt.Text <> "" AndAlso sap.ZAPI_MATINFO("FV38", Partnumber_txt.Text, "0002", filename)) Then
                    Dim zapi As DataTable = CSV.Datatable(filename, vbTab, True, True, 4)
                    'zapi.Columns.Add("New_Material", GetType(String), "SUBSTRING('00000000' + [Material], LEN('00000000' + [Material]) - 7, 8)")

                    Dim zapimatinfo As New DataTable
                    zapimatinfo.Columns.Add("Partnumber")
                    zapimatinfo.Columns.Add("Quantity", GetType(Decimal))
                    zapimatinfo.Columns.Add("UoM")
                    zapimatinfo.PrimaryKey = {zapimatinfo.Columns("Partnumber")}
                    For Each row As DataRow In zapi.DefaultView.ToTable(False, "Material", "Material description", "Unrestricted stock", "Base UOM").Rows
                        zapimatinfo.Rows.Add(row.Item("Material"), CDec(row.Item("Unrestricted stock")), row.Item("Base UOM"))
                    Next

                    Dim requeriment As New DataTable("REQUERIMIENTO")
                    requeriment.Columns.Add("Material")
                    requeriment.Columns.Add("Partnumber")
                    requeriment.Columns.Add("Quantity", GetType(Decimal))
                    requeriment.Columns.Add("UoM")


                    Dim not_enough As New DataTable("COMPARATIVO")
                    not_enough.Columns.Add("Partnumber")
                    not_enough.Columns.Add("Errores", GetType(Integer))
                    not_enough.Columns.Add("Requerimiento", GetType(Decimal))
                    not_enough.Columns.Add("Stock", GetType(Decimal))
                    not_enough.Columns.Add("Pendiente", GetType(Decimal))
                    not_enough.Columns.Add("Tracker", GetType(Decimal))
                    not_enough.Columns.Add("UC", GetType(Decimal))
                    not_enough.Columns.Add("Diff", GetType(Decimal), "Stock + Pendiente - Requerimiento")
                    not_enough.Columns.Add("Cost Diff", GetType(Decimal), "UC * Diff")

                    Dim transfers As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,SUM(Quantity) AS Quantity FROM vw_Smk_PendingTransfers WHERE ToSloc = '0002' OR FromSloc = '0002' GROUP BY Partnumber")
                    transfers.PrimaryKey = {transfers.Columns("Partnumber")}

                    Dim tracker As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,dbo.Sys_UnitConversion(Partnumber,UoM,SUM(OriginalQuantity-CurrentQuantity),BuM) AS Quantity FROM vw_Smk_Serials WHERE InvoiceTrouble = 1 AND [Status] = 'T' GROUP BY Partnumber,UoM,BuM")
                    tracker.PrimaryKey = {tracker.Columns("Partnumber")}

                    Dim costs As DataTable = SQL.Current.GetDatatable("SELECT Partnumber,UnitCost FROM Sys_RawMaterial")
                    costs.PrimaryKey = {costs.Columns("Partnumber")}

                    For Each row As DataRow In zmf47.Rows
                        requeriment.Rows.Add(row.Item("Material"), row.Item("Material_1"), CDec(row.Item("Reqmt Qty")), row.Item("BUn"))
                    Next
                    Dim requeriment_total As DataTable = DatatablePivoter.Get(requeriment, {"Partnumber", "UoM"}, {}, {"Quantity", "Material"}, {AggregateFunction.Sum, AggregateFunction.Count})
                    requeriment_total.DefaultView.Sort = "[Conteo de Material] DESC"

                    If Reportrb.Checked Then
                        For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                            Dim stock As DataRow = zapimatinfo.Rows.Find(row.Item("Partnumber"))
                            Dim pending As DataRow = transfers.Rows.Find(row.Item("Partnumber"))
                            Dim ontracker As DataRow = tracker.Rows.Find(row.Item("Partnumber"))
                            Dim uc As DataRow = costs.Rows.Find(row.Item("Partnumber"))
                            Dim s, p, t, c As Decimal
                            If stock IsNot Nothing Then
                                s = stock.Item("Quantity")
                            Else
                                s = 0
                            End If

                            If pending IsNot Nothing Then
                                p = pending.Item("Quantity")
                            Else
                                p = 0
                            End If

                            If ontracker IsNot Nothing Then
                                t = ontracker.Item("Quantity")
                            Else
                                t = 0
                            End If
                            If uc IsNot Nothing Then
                                c = uc.Item("UnitCost")
                            Else
                                c = 0
                            End If

                            not_enough.Rows.Add(row.Item("Partnumber"), row.Item("Conteo de Material"), row.Item("Suma de Quantity"), s, p, t, c)
                        Next
                        MyExcel.SaveAs({not_enough, requeriment})
                    ElseIf rbAvailable.Checked AndAlso Partnumber_txt.Text = "" Then 'PROCESAR TODOS MASIVAMENTE
                        Dim partnumbers As New ArrayList
                        For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                            Dim stock As DataRow = zapimatinfo.Rows.Find(row.Item("Partnumber"))
                            If stock IsNot Nothing Then
                                If stock.Item("Quantity") >= row.Item("Suma de Quantity") Then
                                    partnumbers.Add(row.Item("Partnumber"))
                                Else
                                    not_enough.Rows.Add(row.Item("Partnumber"), row.Item("Conteo de Material"), row.Item("Suma de Quantity"), stock.Item("Quantity"))
                                End If
                            Else
                                not_enough.Rows.Add(row.Item("Partnumber"), row.Item("Conteo de Material"), row.Item("Suma de Quantity"), 0)
                            End If
                        Next
                        If partnumbers.Count > 0 Then
                            sap.ZMF47v1("FV38", partnumbers)
                        End If
                        MyExcel.SaveAs({not_enough, requeriment}, False)
                    ElseIf rbOnlySave.Checked Then 'SOLO EDITAR
                        For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                            sap.ZMF47v4("FV38", row.Item("Partnumber"), MinKGnud.Value, MaxKGnud.Value, MinLnud.Value, MaxLnud.Value, MinMnud.Value, MaxMnud.Value, MinPCnud.Value, MaxPCnud.Value)
                        Next
                    Else
                        For Each row As DataRow In requeriment_total.DefaultView.ToTable().Rows
                            Dim stock As DataRow = zapimatinfo.Rows.Find(row.Item("Partnumber"))
                            Clipboard.SetText(row.Item("Partnumber"))
                            If stock IsNot Nothing AndAlso stock.Item("Quantity") > 0 Then
                                If stock.Item("Quantity") >= row.Item("Suma de Quantity") Then 'INVENTARIO SUFICIENTE
                                    sap.ZMF47v1("FV38", row.Item("Partnumber"))
                                ElseIf rbForce.Checked Then  'NO SUFICIENTE
                                    sap.ZMF47v2("FV38", row.Item("Partnumber"), MinKGnud.Value, MaxKGnud.Value, MinLnud.Value, MaxLnud.Value, MinMnud.Value, MaxMnud.Value, MinPCnud.Value, MaxPCnud.Value, False)
                                End If
                            ElseIf rbForce.Checked Then  'SIN INVENTARIO
                                sap.ZMF47v2("FV38", row.Item("Partnumber"), MinKGnud.Value, MaxKGnud.Value, MinLnud.Value, MaxLnud.Value, MinMnud.Value, MaxMnud.Value, MinPCnud.Value, MaxPCnud.Value, True)
                            End If
                        Next
                    End If

                End If
                MsgBox("Terminado!")
            End If
        End If


        'Dim mt As Decimal = 0.1
        'Dim kgl As Decimal = 0.001
        'Dim pc As Decimal = 1

        'Dim sap As New SAP
        ''If sap.ZMF47v1("FV38") Then
        'Dim filename As String = GF.TempTXTPath
        'Dim dt As New DataTable
        'If sap.ZMF47v0("FV38", filename) Then
        '    Dim data As DataTable = CSV.Datatable(filename, vbTab, True, True, 2)
        '    dt.Columns.Add("Partnumber")
        '    dt.Columns.Add("Quantity", GetType(Decimal))
        '    dt.Columns.Add("UoM")
        '    dt.Columns.Add("NewQuantity")
        '    dt.Columns.Add("Cnt", GetType(Integer))
        '    If data IsNot Nothing Then
        '        data.DefaultView.RowFilter = "[Reqmt Qty] <> ''"
        '        For Each row As DataRow In data.DefaultView.ToTable(False, "Components", "Reqmt Qty", "Uni").Rows
        '            dt.Rows.Add(row.Item("Components"), CDec(row.Item("Reqmt Qty")), row.Item("Uni"), If({"KG", "L"}.Contains(row.Item("Uni")), Math.Min(CDec(row.Item("Reqmt Qty")), kgl), If(row.Item("Uni") = "M", Math.Min(CDec(row.Item("Reqmt Qty")), mt), Math.Min(CDec(row.Item("Reqmt Qty")), pc))), 1)
        '        Next
        '    End If


        '    Dim uniques As DataTable = dt.DefaultView.ToTable(True, "Partnumber", "UoM")
        '    uniques.Columns.Add("Errors", GetType(Integer))
        '    For Each row As DataRow In uniques.Rows
        '        row.Item("Errors") = dt.Compute("SUM(Cnt)", "Partnumber = '" & row.Item("Partnumber") & "'")
        '    Next
        '    uniques.DefaultView.Sort = "Errors DESC"
        '    MsgBox(dt.Compute("SUM(Cnt)", ""))
        '    For Each row In uniques.DefaultView
        '        If SQL.Current.GetScalar("SELECT SUM(CurrentQuantityInBuM)  FROM vw_Smk_Serials WHERE Partnumber = '" & row.Item("Partnumber") & "' AND InvoiceTrouble = 0 AND [Status] NOT IN ('E','D')") > 0 Then
        '            Clipboard.SetText(row.Item("Partnumber"))
        '            Select Case row.Item("UoM")
        '                Case "PC"
        '                    sap.ZMF47v2("FV38", row.Item("Partnumber"), pc, "PC")
        '                Case "M"
        '                    sap.ZMF47v2("FV38", row.Item("Partnumber"), mt, "M")
        '                Case "KG"
        '                    sap.ZMF47v2("FV38", row.Item("Partnumber"), kgl, "KG")
        '                Case "L"
        '                    sap.ZMF47v2("FV38", row.Item("Partnumber"), kgl, "L")
        '            End Select
        '        End If
        '    Next
        'End If


        ''If sap.ZMF47v2("FV38", Partnumber_txt.Text, Quantity_txt.Text, UoM_txt.Text) Then
        ''    MsgBox("LISTO")
        ''Else
        ''    MsgBox("ERROR")
        ''End If
        ''End If
    End Sub
    Public Class SSAP
        Dim sapgui As Object
        Dim application As Object
        Dim connection As Object
        Public Property Session As Object
        Dim _available As Boolean = False

        Public Sub New()
            Try
                sapgui = GetObject("SAPGUI")
                If IsNothing(sapgui) Then
                    _available = False
                Else
                    application = sapgui.GetScriptingEngine
                    connection = application.children(0)
                    Session = connection.children(0)
                    _available = True
                End If
            Catch ex As Exception
                _available = False
            End Try
        End Sub

        Public ReadOnly Property Available As Boolean
            Get
                Return _available
            End Get
        End Property

        Public Function ZMF47v0(plant As String, filename As String) As Boolean 'DEVUELVE EL ARCHIVO
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Session.findById("wnd[0]/usr/ctxtSO_MATNR-LOW").text = ""
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/mbar/menu[0]/menu[2]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus()
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Session.findById("wnd[1]/usr/ctxtDY_PATH").text = filename
                Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = ""
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Session.findById("wnd[0]/tbar[0]/btn[15]").press()
                Session.findById("wnd[0]/tbar[0]/btn[15]").press()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZAPI_MATINFO(plant As String, partnumber As String, sloc As String, filename As String) As Boolean
            Try
                Check_System()
                Session.findById("wnd[0]").maximize()
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZAPI_MATINFO"
                Session.findById("wnd[0]").sendVKey(0)
                Check_System()
                Session.findById("wnd[0]/usr/ctxtS_PLANT-LOW").text = plant
                Session.findById("wnd[0]/usr/ctxtS_MATNR-LOW").text = partnumber
                Session.findById("wnd[0]/usr/btn%_S_LGORT_%_APP_%-VALU_PUSH").press()
                Clipboard.SetText(String.Join(vbCrLf, sloc))
                Session.findById("wnd[1]/tbar[0]/btn[16]").press()
                Session.findById("wnd[1]/tbar[0]/btn[24]").press()
                Check_System()
                Clipboard.Clear()
                Session.findById("wnd[1]/tbar[0]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[45]").press()
                Check_System()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus()
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Check_System()
                Session.findById("wnd[1]/usr/ctxtDY_PATH").text = filename
                Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = ""
                Session.findById("wnd[1]/tbar[0]/btn[11]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[0]/btn[12]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[0]/btn[12]").press()
                Check_System()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZMF47v1(plant As String) As Boolean 'CORRE MANUALMENTE LO PENDIENTE
            Check_System()
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Session.findById("wnd[0]/usr/ctxtSO_MATNR-LOW").text = ""
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select()
                Session.findById("wnd[0]/tbar[1]/btn[18]").press() 'select all
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[6]").press() 'PROCESS
                Session.findById("wnd[0]").sendVKey(11)
                While Session.findById("wnd[0]/tbar[0]/btn[11]", False) IsNot Nothing AndAlso Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) Is Nothing
                    Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'SAVE
                End While
                If Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZMF47v1(plant As String, partnumber As String) As Boolean 'CORRE MANUALMENTE LO PENDIENTE
            Check_System()
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Session.findById("wnd[0]/usr/ctxtSO_MATNR-LOW").text = partnumber
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select()
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[6]").press() 'PROCESS
                Session.findById("wnd[0]").sendVKey(11)
                While Session.findById("wnd[0]/tbar[0]/btn[11]", False) IsNot Nothing AndAlso Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) Is Nothing
                    Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'SAVE
                End While
                If Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZMF47v1(plant As String, partnumbers As ArrayList) As Boolean 'CORRE MANUALMENTE LO PENDIENTE
            Check_System()
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Clipboard.SetText(String.Join(vbCrLf, partnumbers.ToArray))
                Session.findById("wnd[0]/usr/btn%_SO_MATNR_%_APP_%-VALU_PUSH").press()
                Session.findById("wnd[1]/tbar[0]/btn[16]").press()
                Session.findById("wnd[1]/tbar[0]/btn[24]").press()
                Session.findById("wnd[1]/tbar[0]/btn[8]").press()
                Clipboard.Clear()
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()

                Check_System()
                Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select()
                Check_System()
                Session.findById("wnd[0]/tbar[1]/btn[6]").press() 'PROCESS
                Session.findById("wnd[0]").sendVKey(11)
                While Session.findById("wnd[0]/tbar[0]/btn[11]", False) IsNot Nothing AndAlso Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) Is Nothing
                    Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'SAVE
                End While
                If Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZMF47v2(plant As String, partnumber As String, min_g As Integer, max_g As Integer, min_l As Integer, max_l As Integer, min_m As Integer, max_m As Integer, min_pc As Integer, max_pc As Integer, msg As Boolean) As Boolean
            'AJUSTA EL NUMERO DE PARTE
            Check_System()
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Session.findById("wnd[0]/usr/ctxtSO_MATNR-LOW").text = partnumber
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select() 'select all
                Session.findById("wnd[0]/tbar[1]/btn[18]").press() 'change
                Check_System()
                Dim r As New Random
                Dim sum As Decimal = 0
                Dim quantity As Decimal
                Dim uom As String = ""
                While Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]", False) IsNot Nothing
                    Select Case Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text
                        Case "G"
                            quantity = r.Next(min_g, max_g)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) > max_g Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "KG"
                        Case "KG"
                            quantity = r.Next(min_g, max_g)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) * 1000 > max_g Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "G"
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "KG"
                        Case "MM"
                            quantity = r.Next(min_m, max_m)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) > max_m Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "M"
                        Case "M"
                            quantity = r.Next(min_m, max_m)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) * 1000 > max_m Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "MM"
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "M"
                        Case "ML"
                            quantity = r.Next(min_l, max_l)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) > max_l Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "L"
                        Case "L"
                            quantity = r.Next(min_l, max_l)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) * 1000 > max_l Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "ML"
                                sum += quantity / 1000
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) / 1000
                            End If
                            uom = "L"
                        Case Else
                            quantity = r.Next(min_pc, max_pc)
                            If CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text) > max_pc Then
                                Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                                sum += quantity
                            Else
                                sum += CDec(Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text)
                            End If
                            uom = "PC"
                    End Select
                    Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'Save
                End While
                If Session.findById("wnd[0]/sbar", False) IsNot Nothing AndAlso Session.findById("wnd[0]/sbar", False).Text = "Postprocessing record(s) changed" Then
                    Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select()
                    If msg Then MsgBox(partnumber & vbCrLf & "Z11: " & sum & " UOM: " & uom & vbCrLf & "Presiona OK despues de realizar el movimiento....", MsgBoxStyle.Information)
                    Session.findById("wnd[0]/tbar[1]/btn[6]").press() 'PROCESS
                    Session.findById("wnd[0]").sendVKey(11)
                    While Session.findById("wnd[0]/tbar[0]/btn[11]", False) IsNot Nothing AndAlso Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) Is Nothing
                        Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'SAVE
                    End While
                Else
                    Return False
                End If
                If Session.findById("wnd[0]/usr/txtCMIMSG-HEADLINE", False) IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ZMF47v4(plant As String, partnumber As String, min_g As Integer, max_g As Integer, min_l As Integer, max_l As Integer, min_m As Integer, max_m As Integer, min_pc As Integer, max_pc As Integer) As Boolean 'SOLO EDITAR
            'AJUSTA EL NUMERO DE PARTE
            Check_System()
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZMF47"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/ctxtPA_WERKS").text = plant
                Session.findById("wnd[0]/usr/ctxtSO_MATNR-LOW").text = partnumber
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Session.findById("wnd[0]/mbar/menu[1]/menu[3]/menu[0]").select() 'select all
                Session.findById("wnd[0]/tbar[1]/btn[18]").press() 'change
                Check_System()
                Dim r As New Random
                Dim sum As Decimal = 0
                Dim quantity As Decimal
                Dim uom As String = ""
                While Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]", False) IsNot Nothing
                    Select Case Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text
                        Case "G"
                            quantity = r.Next(min_g, max_g)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                        Case "KG"
                            quantity = r.Next(min_g, max_g)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "G"
                        Case "MM"
                            quantity = r.Next(min_m, max_m)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                        Case "M"
                            quantity = r.Next(min_m, max_m)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "MM"
                        Case "ML"
                            quantity = r.Next(min_l, max_l)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                        Case "L"
                            quantity = r.Next(min_l, max_l)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/ctxtCOWB_COMP-ERFME[3,0]").text = "ML"
                        Case Else
                            quantity = r.Next(min_pc, max_pc)
                            Session.findById("wnd[0]/usr/subTABLE:SAPLCOWB:0540/tblSAPLCOWBTCTRL_0540/txtCOWB_COMP-ERFMG_R[2,0]").text = quantity
                    End Select
                    Session.findById("wnd[0]/tbar[0]/btn[11]").press() 'Save
                End While
                If Session.findById("wnd[0]/sbar", False) IsNot Nothing AndAlso Session.findById("wnd[0]/sbar", False).Text = "Postprocessing record(s) changed" Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function AQ25SYSTQV000492RPT_ZMF47(plant As String, filename As String, partnumber As String) As Boolean
            Try
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/nstart_report"
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/txtD_SREPOVARI-REPORT").text = "AQ25SYSTQV000492RPT_ZMF47====="
                Session.findById("wnd[0]/usr/txtD_SREPOVARI-REPORT").setFocus()
                Session.findById("wnd[0]").sendVKey(0)
                Session.findById("wnd[0]/usr/rad%ALV").setFocus()
                Session.findById("wnd[0]/usr/rad%ALV").select()
                Session.findById("wnd[0]/usr/ctxtSP$00001-LOW").text = plant
                Session.findById("wnd[0]/usr/ctxtSP$00002-LOW").text = ""
                Session.findById("wnd[0]/usr/ctxtSP$00028-LOW").text = partnumber
                Session.findById("wnd[0]/usr/ctxtSP$00029-LOW").text = ""
                Session.findById("wnd[0]/usr/ctxtSP$00042-LOW").text = ""
                Session.findById("wnd[0]/usr/ctxtSP$00042-LOW").setFocus()
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Session.findById("wnd[0]/tbar[1]/btn[45]").press()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus()
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Session.findById("wnd[1]/usr/ctxtDY_PATH").text = IO.Path.GetDirectoryName(filename)
                Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = IO.Path.GetFileName(filename)
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Session.findById("wnd[0]/tbar[0]/btn[15]").press()
                Session.findById("wnd[0]/tbar[0]/btn[15]").press()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Sub Check_System()
            Try
                Dim retid As Object
                retid = Session.findById("wnd[1]", False)
                While retid IsNot Nothing AndAlso retid.Text = "System Messages"
                    Session.findById("wnd[1]/tbar[0]/btn[12]").press()
                    retid = Session.findById("wnd[1]", False)
                End While
                Batchadmin()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Batchadmin()
            Dim retid As Object
            retid = Session.findById("wnd[0]/sbar", False)
            While retid IsNot Nothing
                Dim var As String = Session.findById("wnd[0]/sbar").Text
                If var.Contains("BATCHADMIN") Then
                    Session.findById("wnd[0]").sendVKey(0)
                End If
                retid = Session.findById("wnd[0]/sbar", False)
                If Not var.Contains("BATCHADMIN") Then
                    Exit While
                End If
            End While
            retid = Nothing
        End Sub

        Public Function ZAPI_MATINFO(plant As String, filename As String, ParamArray slocs() As String) As Boolean 'ACTUALIZADA
            Try
                Check_System()
                Session.findById("wnd[0]").maximize()
                Session.findById("wnd[0]/tbar[0]/okcd").text = "/NZAPI_MATINFO"
                Session.findById("wnd[0]").sendVKey(0)
                Check_System()
                Session.findById("wnd[0]/usr/ctxtS_MATNR-LOW").text = "*"
                Session.findById("wnd[0]/usr/ctxtS_PLANT-LOW").text = plant
                Session.findById("wnd[0]/usr/ctxtS_LGORT-LOW").text = slocs(0)
                Session.findById("wnd[0]/usr/btn%_S_LGORT_%_APP_%-VALU_PUSH").press()
                Check_System()
                For i = 0 To slocs.Length - 1
                    Session.findById("wnd[1]/usr/tabsTAB_STRIP/tabpSIVA/ssubSCREEN_HEADER:SAPLALDB:3010/tblSAPLALDBSINGLE/ctxtRSCSEL_255-SLOW_I[1," & i & "]").text = slocs(i)
                Next
                Session.findById("wnd[1]/tbar[0]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/usr/ctxtS_BESKZ-LOW").text = "F"
                Session.findById("wnd[0]/usr/ctxtP_VARNT").text = ""
                Session.findById("wnd[0]/tbar[1]/btn[8]").press()
                Check_System()
                Session.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select()
                Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus()
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Check_System()
                Session.findById("wnd[1]/usr/ctxtDY_PATH").text = IO.Path.GetDirectoryName(filename)
                Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = IO.Path.GetFileName(filename)
                Session.findById("wnd[1]/tbar[0]/btn[0]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[0]/btn[12]").press()
                Check_System()
                Session.findById("wnd[0]/tbar[0]/btn[12]").press()
                Check_System()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

    Private Sub MAn_ZMF47_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class