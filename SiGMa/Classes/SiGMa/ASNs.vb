Imports System
Imports System.IO
Imports SiGMaDesktop.SQAValidation
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class ASNs
    Public Property Original_document As String
    Public Property ID As String
    Public Property IDoc_number As String
    Public Property Deliv_Date As String
    Public Property Material As String
    Public Property Plant As String
    Public Property Vendor As String
    Public Property Purchase_order_no As String
    Public Property Item As Integer
    Public Property Delivery_quantity As Decimal
    Public Property Delivery As String
    Public Property Status_of_IDoc_data_processing As Integer
    Public Property ASN_Data_Status As Integer
    Public Property ASN_Posting_Status As Integer
    Public Property Deletion_Indicator As String
    Public Property Cumulative_quantity As Decimal
    Public Property JIT_No As String
    Public Property GRT As Integer
    Public ASNsList As List(Of ASNs) '= New List(Of ASNs)
    Dim AsnStatusList As List(Of ASNsStatus) = New List(Of ASNsStatus)
    Dim sap As SAP

    Public Class routesASNs
        Public Property ASN As String
        Public Property IdRoute As Integer
    End Class

    Public Class ASNsStatus
        Public Property ASN As String
        Public Property Status As String
    End Class

    Public Class Y497
        Public Property Plant As String
        Public Property Material As String
        Public Property ASN As String
        Public Property OutstandingQty As Decimal
        Public Property Vendor As String
        Public Property PO As String
        Public Property Item As String
        Public Property UoM As String
        Public Property Qty As Decimal
    End Class

    'Public Sub New(ByVal _Original_document As String, ByVal _ID As String, ByVal _IDoc_number As String, ByVal _Deliv_Date As String, ByVal _Material As String, ByVal _Plant As String, ByVal _Vendor As String,
    '               ByVal _Purchase_order_no As String, ByVal _Item As Integer, ByVal _Delivery_quantity As Decimal, ByVal _Delivery As String, ByVal _Status_of_IDoc_data_processing As Integer, ByVal _ASN_Data_Status As Integer,
    '               ByVal _ASN_Posting_Status As Integer, ByVal _Deletion_Indicator As String, ByVal _Cumulative_quantity As Decimal, ByVal _JIT_No As String, ByVal _GRT As Integer)
    '    Original_document = _Original_document
    '    ID = _ID
    '    IDoc_number = _IDoc_number
    '    Deliv_Date = _Deliv_Date
    '    Material = _Material
    '    Plant = _Plant
    '    Vendor = _Vendor
    '    Purchase_order_no = _Purchase_order_no
    '    Item = _Item
    '    Delivery_quantity = _Delivery_quantity
    '    Delivery = _Delivery
    '    Status_of_IDoc_data_processing = _Status_of_IDoc_data_processing
    '    ASN_Data_Status = _ASN_Data_Status
    '    ASN_Posting_Status = _ASN_Posting_Status
    '    Deletion_Indicator = _Deletion_Indicator
    '    Cumulative_quantity = _Cumulative_quantity
    '    JIT_No = _JIT_No
    '    GRT = _GRT
    'End Sub

    Public Function downloadY497(plant As ArrayList, idRoute As String) As List(Of Y497)
        Try
#Region "Format inputs to SAP"
            Dim extraAsn As ArrayList
            extraAsn = SQL.Current.GetList(String.Format("SELECT DISTINCT RA.ASN
                                    FROM [Routes_ASNs] RA
                                    LEFT JOIN ASNs A ON A.original_document = RA.ASN
                                    WHERE RA.IdRoute = {0}", idRoute))
            If File.Exists("C:\aptiv\scannedASNs.txt") Then
                File.Delete("C:\aptiv\scannedASNs.txt")
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\scannedASNs.txt", True)
                For Each var In extraAsn
                    sw.WriteLine(var)
                Next
                sw.Close()
            Else
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\scannedASNs.txt", True)
                For Each var In extraAsn
                    sw.WriteLine(var.ASN)
                Next
                sw.Close()
            End If
            If File.Exists("C:\aptiv\plants.txt") Then
                File.Delete("C:\aptiv\plants.txt")
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\plants.txt", True)
                For Each var In plant
                    sw.WriteLine(var)
                Next
                sw.Close()
            Else
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\plants.txt", True)
                For Each var In plant
                    sw.WriteLine(var)
                Next
                sw.Close()
            End If
            If File.Exists("C:\aptiv\downloaded497.txt") Then
                File.Delete("C:\aptiv\downloaded497.txt")
            End If
            If File.Exists("C:\aptiv\downloaded4970.txt") Then
                File.Delete("C:\aptiv\downloaded4970.txt")
            End If
#End Region
            Dim y497List As List(Of Y497) = New List(Of Y497)()
            sap = New SAP
            If sap.Available Then
                sap.Check_System()
                sap.Session.findById("wnd[0]").maximize
                sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/nY_DN3_47000497"
                sap.Session.findById("wnd[0]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/usr/ctxtS_WERKS-LOW").text = "FV31"
                sap.Session.findById("wnd[0]/usr/btn%_S_WERKS_%_APP_%-VALU_PUSH").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
                sap.Check_System()
                sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv"
                sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "plants.txt"
                sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[8]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/usr/btn%_S_XBLNR_%_APP_%-VALU_PUSH").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
                sap.Check_System()
                sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv\"
                sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "scannedASNs.txt"
                sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
                sap.Check_System()
                'revisar si no se encontro nada
                Dim recordFound = sap.Session.findById("wnd[0]/sbar").Text 'If not records found. Manage exception
                ' si no encuentra nada, marcara la opcion 0 outstanding
                If (recordFound = "No records found!") Then
                    sap.Session.findById("wnd[0]/usr/chkP_MENGE").selected = True
                    sap.Session.findById("wnd[0]/usr/chkP_MENGE").setFocus
                    sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
                    sap.Check_System()
                    sap.Session.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select
                    sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select
                    sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus
                    sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                    sap.Check_System()
                    recordFound = sap.Session.findById("wnd[0]/sbar").Text 'If not records found. Manage exception
                    If (recordFound = "No records found!") Then
                        Return Nothing
                    Else
                        sap.Session.findById("wnd[1]/usr/ctxtDY_PATH").text = "C:\aptiv" 'Path.GetDirectoryName(filename)
                        sap.Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = "downloaded497.txt" 'Path.GetFileName(filename)
                        sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                        sap.Check_System()
                        Dim txt As DataTable = New DataTable
                        txt = CSV.Datatable("C:\aptiv\downloaded497.txt", vbTab, False, False)
                        If txt IsNot Nothing Then
                            txt.Columns.RemoveAt(0)
                            txt.Rows(0).Delete()
                            txt.Rows(0).Delete()
                            txt.Rows(0).Delete()
                            txt.Rows(0).Delete()
                            txt.Rows(0).Delete()
                            Dim dataTable497 = txt.DefaultView.ToTable(True, "Col2", "Col3", "Col5", "Col6", "Col8", "Col12", "Col13", "Col14", "Col15")
                            y497List = (From dr In dataTable497.Rows Select New Y497() With {
                            .Plant = dr("Col2").ToString(),
                            .Material = dr("Col3").ToString(),
                            .ASN = dr("Col5").ToString(),
                            .OutstandingQty = Convert.ToDecimal(dr("Col6")),
                            .Vendor = dr("Col8").ToString(),
                            .PO = dr("Col12").ToString(),
                            .Item = dr("Col13").ToString(),
                            .UoM = dr("Col14").ToString(),
                            .Qty = Convert.ToDecimal(dr("Col15"))
                        }).ToList()
                            Return y497List
                        Else
                            Return Nothing
                        End If
                    End If
                End If
                ' si encuentra algo, seguira con la descarga
                sap.Session.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select
                sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select
                sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus
                sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/usr/ctxtDY_PATH").text = "C:\aptiv" 'Path.GetDirectoryName(filename)
                sap.Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = "downloaded497.txt" 'Path.GetFileName(filename)
                sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/tbar[0]/btn[3]").press 'atras
                sap.Check_System()
                sap.Session.findById("wnd[0]/tbar[0]/btn[3]").press 'atras
                sap.Check_System()
                Dim txt2 As DataTable = New DataTable
                txt2 = CSV.Datatable("C:\aptiv\downloaded497.txt", vbTab, False, False)
                txt2.Columns.RemoveAt(0)
                txt2.Rows(0).Delete()
                txt2.Rows(0).Delete()
                txt2.Rows(0).Delete()
                txt2.Rows(0).Delete()
                txt2.Rows(0).Delete()
                Dim dataTable4972 = txt2.DefaultView.ToTable(True, "Col2", "Col3", "Col5", "Col6", "Col8", "Col12", "Col13", "Col14", "Col15")
                y497List = (From dr In dataTable4972.Rows Select New Y497() With {
                    .Plant = dr("Col2").ToString(),
                    .Material = dr("Col3").ToString(),
                    .ASN = dr("Col5").ToString(),
                    .OutstandingQty = Convert.ToDecimal(dr("Col6")),
                    .Vendor = dr("Col8").ToString(),
                    .PO = dr("Col12").ToString(),
                    .Item = dr("Col13").ToString(),
                    .UoM = dr("Col14").ToString(),
                    .Qty = Convert.ToDecimal(dr("Col15"))
                }).ToList()
#Region "0 outstanding"
                sap.Check_System()
                sap.Session.findById("wnd[0]").maximize
                sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/nY_DN3_47000497"
                sap.Session.findById("wnd[0]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/usr/ctxtS_WERKS-LOW").text = "FV31"
                sap.Session.findById("wnd[0]/usr/btn%_S_WERKS_%_APP_%-VALU_PUSH").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
                sap.Check_System()
                sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv"
                sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "plants.txt"
                sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[8]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/usr/btn%_S_XBLNR_%_APP_%-VALU_PUSH").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
                sap.Check_System()
                sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv\"
                sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "scannedASNs.txt"
                sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/usr/chkP_MENGE").selected = True '0 outstanding
                sap.Session.findById("wnd[0]/usr/chkP_MENGE").setFocus '0 outstanding
                sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
                sap.Check_System()
                sap.Session.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select
                sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select
                sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus
                sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                sap.Check_System()
                sap.Session.findById("wnd[1]/usr/ctxtDY_PATH").text = "C:\aptiv" 'Path.GetDirectoryName(filename)
                sap.Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = "downloaded4970.txt" 'Path.GetFileName(filename)
                sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
                sap.Check_System()
                Dim txt0 As DataTable = New DataTable
                txt0 = CSV.Datatable("C:\aptiv\downloaded4970.txt", vbTab, False, False)
                If txt0 IsNot Nothing Then
                    txt0.Columns.RemoveAt(0)
                    txt0.Rows(0).Delete()
                    txt0.Rows(0).Delete()
                    txt0.Rows(0).Delete()
                    txt0.Rows(0).Delete()
                    txt0.Rows(0).Delete()
                    Dim dataTable4970 = txt0.DefaultView.ToTable(True, "Col2", "Col3", "Col5", "Col6", "Col8", "Col12", "Col13", "Col14", "Col15")
                    y497List = (From dr In dataTable4970.Rows Select New Y497() With {
                        .Plant = dr("Col2").ToString(),
                        .Material = dr("Col3").ToString(),
                        .ASN = dr("Col5").ToString(),
                        .OutstandingQty = Convert.ToDecimal(dr("Col6")),
                        .Vendor = dr("Col8").ToString(),
                        .PO = dr("Col12").ToString(),
                        .Item = dr("Col13").ToString(),
                        .UoM = dr("Col14").ToString(),
                        .Qty = Convert.ToDecimal(dr("Col15"))
                    }).ToList()
                Else
                    Return y497List
                End If
#End Region
                Return y497List
            Else
                MessageBox.Show("No SAP session found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return y497List
        Catch
            Return Nothing
        End Try
    End Function

    Public Function downloadStartReport(plant As ArrayList, asn As List(Of ScannedASN)) As String
        Try
#Region "Format inputs to SAP"
            If File.Exists("C:\aptiv\scannedASNs.txt") Then
                File.Delete("C:\aptiv\scannedASNs.txt")
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\scannedASNs.txt", True)
                For Each var In asn
                    sw.WriteLine(var.ASN)
                Next
                sw.Close()
            Else
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\scannedASNs.txt", True)
                For Each var In asn
                    sw.WriteLine(var.ASN)
                Next
                sw.Close()
            End If
            If File.Exists("C:\aptiv\plants.txt") Then
                File.Delete("C:\aptiv\plants.txt")
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\plants.txt", True)
                For Each var In plant
                    sw.WriteLine(var)
                Next
                sw.Close()
            Else
                Dim sw As StreamWriter = New StreamWriter("C:\aptiv\plants.txt", True)
                For Each var In plant
                    sw.WriteLine(var)
                Next
                sw.Close()
            End If
            If File.Exists("C:\aptiv\downloadStartReport.txt") Then
                File.Delete("C:\aptiv\downloadStartReport.txt")
            End If
#End Region
            sap = New SAP
            sap.Check_System()
            sap.Session.findById("wnd[0]/tbar[0]/okcd").text = "/nstart_report"
            sap.Session.findById("wnd[0]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/txtD_SREPOVARI-REPORT").text = "AQ25SYSTQV000696-AS-SGM-ASN==="
            sap.Session.findById("wnd[0]/usr/txtD_SREPOVARI-REPORT").setFocus
            sap.Session.findById("wnd[0]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/btn%_SP$00001_%_APP_%-VALU_PUSH").press
            sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
            sap.Check_System()
            sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv"
            sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "scannedASNs.txt"
            sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap.Session.findById("wnd[1]/tbar[0]/btn[8]").press
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/ctxtSP$00004-LOW").text = "" 'aqui
            sap.Session.findById("wnd[0]/usr/ctxtSP$00005-LOW").setFocus
            sap.Session.findById("wnd[0]/usr/btn%_SP$00005_%_APP_%-VALU_PUSH").press
            sap.Session.findById("wnd[1]/tbar[0]/btn[23]").press
            sap.Check_System()
            sap.Session.findById("wnd[2]/usr/ctxtDY_PATH").text = "C:\aptiv"
            sap.Session.findById("wnd[2]/usr/ctxtDY_FILENAME").text = "plants.txt"
            sap.Session.findById("wnd[2]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap.Session.findById("wnd[1]/tbar[0]/btn[8]").press
            sap.Check_System()
            sap.Session.findById("wnd[0]/usr/rad%ALV").setFocus
            sap.Session.findById("wnd[0]/usr/rad%ALV").select
            sap.Session.findById("wnd[0]/tbar[1]/btn[8]").press
            sap.Check_System()
            Dim recordFound = sap.Session.findById("wnd[0]/sbar").Text 'If not records found. Manage exception
            If (recordFound = "No data was selected" Or recordFound = "No records found!") Then
                sap = Nothing
                Return "No data"
            End If
            sap.Session.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select
            sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").select
            sap.Session.findById("wnd[1]/usr/subSUBSCREEN_STEPLOOP:SAPLSPO5:0150/sub:SAPLSPO5:0150/radSPOPLI-SELFLAG[1,0]").setFocus
            sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap.Session.findById("wnd[1]/usr/ctxtDY_PATH").text = "C:\aptiv"
            sap.Session.findById("wnd[1]/usr/ctxtDY_FILENAME").text = "downloadStartReport.txt"
            sap.Session.findById("wnd[1]/tbar[0]/btn[0]").press
            sap.Check_System()
            sap = Nothing
            Return "Successs"
        Catch ex As Exception
            sap = Nothing
            Return "Error"
        End Try
    End Function

    Public Function getSapASNs(idRoute As String) As List(Of ASNs)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT DISTINCT A.* FROM [Routes_ASNs] RA
                                                INNER JOIN ASNs A ON A.original_document = RA.ASN
                                                WHERE RA.IdRoute = {0}", idRoute)
        ASNsList = New List(Of ASNs)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        ASNsList.Add(New ASNs() With {
                                                            .Original_document = Convert.ToString(row.Item("Original_document")),
                                                            .ID = Convert.ToString(row.Item("ID")),
                                                            .IDoc_number = Convert.ToString(row.Item("IDoc_number")),
                                                            .Deliv_Date = Convert.ToString(row.Item("Deliv_Date")),
                                                            .Material = Convert.ToString(row.Item("Material")),
                                                            .Plant = Convert.ToString(row.Item("Plant")),
                                                            .Vendor = Convert.ToString(row.Item("Vendor")),
                                                            .Purchase_order_no = Convert.ToString(row.Item("Purchase_order_no")),
                                                            .Item = Convert.ToInt32(row.Item("Item")),
                                                            .Delivery_quantity = Convert.ToDecimal(row.Item("Delivery_quantity")),
                                                            .Delivery = Convert.ToString(row.Item("Delivery")),
                                                            .Status_of_IDoc_data_processing = Convert.ToInt32(row.Item("Status_of_IDoc_data_processing")),
                                                            .ASN_Data_Status = Convert.ToInt32(row.Item("ASN_Data_Status")),
                                                            .ASN_Posting_Status = Convert.ToInt32(row.Item("ASN_Posting_Status")),
                                                            .Deletion_Indicator = Convert.ToString(row.Item("Deletion_Indicator")),
                                                            .Cumulative_quantity = Convert.ToDecimal(row.Item("Cumulative_quantity")),
                                                            .JIT_No = Convert.ToString(row.Item("JIT_No")),
                                                            .GRT = Convert.ToInt32(row.Item("GRT"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return ASNsList
    End Function

    Public Function insertRoutesASNs(ASNs As List(Of ScannedASN), idRoute As Integer) As Boolean
        Dim data As DataTable = New DataTable()
        Dim routesAsnList As List(Of routesASNs) = New List(Of routesASNs)
        Dim asnsInContainer As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT AIC.ASN FROM AsnsInContainer AIC
                                                                                INNER JOIN Containers C ON C.IdContainer = AIC.IdContainer
                                                                                WHERE C.IdRoute = @idRoute", idRoute))
        If asnsInContainer IsNot Nothing Then
            For Each x In asnsInContainer
                routesAsnList.Add(New routesASNs With {
                                        .ASN = x.ToString(),
                                        .IdRoute = idRoute
                                  })
            Next
        End If
        For Each var In ASNs
            routesAsnList.Add(New routesASNs With {
                                    .ASN = var.ASN,
                                    .IdRoute = idRoute
                              })
        Next
        data = ToDataTable(routesAsnList)
        If SQL.Current.Upsert(data, "tmp_routesAsns", "CREATE TABLE #tmp_routesAsns	(ASN VARCHAR(20), IdRoute int);",
                              "MERGE dbo.Routes_ASNs AS target USING #tmp_routesAsns AS source ON target.ASN = source.ASN AND 
                              target.IdRoute = source.IdRoute
		                        WHEN MATCHED THEN 
			                        UPDATE SET ASN = source.ASN
		                        WHEN NOT MATCHED THEN INSERT (ASN, IdRoute) 
			                        VALUES (source.ASN, source.IdRoute);") Then
            Return True
        End If
        Return False
    End Function

    Public Function insertASNsStatus(ASNs As List(Of ScannedASN), idRoute As String) As List(Of ASNsStatus)
        Dim data As DataTable = New DataTable()
        Dim asnsInContainer As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT AIC.ASN FROM AsnsInContainer AIC
                                                                                INNER JOIN Containers C ON C.IdContainer = AIC.IdContainer
                                                                                WHERE C.IdRoute = @idRoute", idRoute))
        If asnsInContainer IsNot Nothing Then
            For Each var In asnsInContainer
                If SQL.Current.Exists("[ASNs]", "[Original_document]", var.ASN) Then
                    AsnStatusList.Add(New ASNsStatus With {
                                        .ASN = var.ASN,
                                        .Status = "DLD"
                                  })
                Else
                    AsnStatusList.Add(New ASNsStatus With {
                                        .ASN = var.ASN,
                                        .Status = "NFND"
                                  })
                End If
            Next
        End If
        For Each var In ASNs
            If SQL.Current.Exists("[ASNs]", "[Original_document]", var.ASN) Then
                AsnStatusList.Add(New ASNsStatus With {
                                    .ASN = var.ASN,
                                    .Status = "DLD"
                              })
            Else
                AsnStatusList.Add(New ASNsStatus With {
                                    .ASN = var.ASN,
                                    .Status = "NFND"
                              })
            End If
        Next
        data = ToDataTable(AsnStatusList)
        Dim Asns_data = data.DefaultView.ToTable(True)
        If SQL.Current.Upsert(Asns_data, "tmp_AsnsStatus", "CREATE TABLE #tmp_AsnsStatus (ASN VARCHAR(20), [Status] VARCHAR(5));",
                              "MERGE dbo.ASNsStatus AS target USING #tmp_AsnsStatus AS source ON target.ASN = source.ASN
                                WHEN MATCHED THEN 
	                                UPDATE SET [Status] = source.[Status]
                                WHEN NOT MATCHED THEN INSERT (ASN, [Status]) 
	                                VALUES (source.ASN, source.[Status]);") Then
            Dim ASNdistinct = From A In AsnStatusList
                              Select A.ASN, A.Status Distinct
            Dim ASNDistinctList As List(Of ASNsStatus) = New List(Of ASNsStatus)
            For Each o In ASNdistinct
                ASNDistinctList.Add(New ASNsStatus() With {
                                                            .ASN = o.ASN,
                                                            .Status = o.Status
                                                        })
            Next
            Return ASNDistinctList
        End If
        Return Nothing
    End Function

    Public Shared Function ToDataTable(Of T)(ByVal data As IList(Of T)) As DataTable
        Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table As DataTable = New DataTable()

        For i As Integer = 0 To props.Count - 1
            Dim prop As PropertyDescriptor = props(i)
            table.Columns.Add(prop.Name, prop.PropertyType)
        Next

        Dim values As Object() = New Object(props.Count - 1) {}

        For Each item As T In data

            For i As Integer = 0 To values.Length - 1
                values(i) = props(i).GetValue(item)
            Next

            table.Rows.Add(values)
        Next

        Return table
    End Function

    Public Shared Function getRoutesASNs(idRoute As Integer) As List(Of routesASNs)
        Dim routesASNsList As List(Of routesASNs) = New List(Of routesASNs)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT [ASN],[IdRoute]
                                                  FROM [Routes_ASNs]
                                                  WHERE IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        routesASNsList.Add(New routesASNs() With {
                                                            .ASN = Convert.ToString(row.Item("ASN")),
                                                            .IdRoute = Convert.ToString(row.Item("IdRoute"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return routesASNsList
    End Function
End Class
