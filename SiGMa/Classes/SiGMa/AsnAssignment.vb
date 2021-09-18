Imports System
Imports System.IO
Imports SiGMaDesktop.SQAValidation
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports SiGMaDesktop.ASNs
Imports System.Linq

Public Class AsnAssignment
    Public Property ASNsRecordsList As List(Of ASNsRecords)
    Public Property ASNsRecordsRefreshList As List(Of ASNsRecords)
    Public Property ASNsSAPList As List(Of ASNsSAP)
    Dim ASNsClass As New ASNs

    Public Class ASNsRecords
        Public Property PartNumber As String
        Public Property Qty As Decimal
        Public Property ASN As String
        Public Property Plant As String
        Public Property IdContainerContent As Integer
        Public Property IdContainer As Integer
        Public Property ASNstatus As String
    End Class

    Public Class ASNsSAP
        Public Property Plant As String
        Public Property PartNumber As String
        Public Property Qty As Decimal
        Public Property ASN As String
    End Class

    Public Class PossibleASNs
        Public Property IdContainerContent As Integer
        Public Property ASN As String
    End Class

    Public Function getASNrecordsList(idRoute As Integer, containersContentList As List(Of ContainersContent)) As List(Of ASNsRecords)
        ASNsRecordsRefreshList = New List(Of ASNsRecords)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        'Query para traer tablas de ASNs multiplicadas por ContainersContent
        Dim sqlquery As String = String.Format("WITH Container AS (
	                                                    SELECT 
		                                                    CC.IdContainer, CC.IdContainerContent, CC.PartNumber, CC.Qty, CC.UOM, C.Plant, C.IdRoute
	                                                    FROM ContainersContent CC 
	                                                    INNER JOIN Containers C ON C.IdContainer = CC.IdContainer),
                                                    AsnContainers AS (SELECT * FROM AsnsInContainer AIC),
                                                    AsnStatus AS (SELECT * FROM ASNsStatus ),
                                                    RoutesASN AS (SELECT DISTINCT * FROM Routes_ASNs)
                                                    SELECT DISTINCT
	                                                    C.*, RA.*, ASNS.Status
                                                    FROM Container C
                                                    LEFT JOIN RoutesASN RA ON RA.IdRoute = C.IdRoute
                                                    LEFT JOIN AsnContainers AC ON AC.IdContainer = C.IdContainer
                                                    LEFT JOIN AsnStatus ASNS ON ASNS.ASN = RA.ASN
                                                    WHERE ASNS.Status <> 'NFND' AND ASNS.Status <> 'CMPLT' AND C.IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        'Generar lista de tablas multiplicadas
                        ASNsRecordsRefreshList.Add(New ASNsRecords() With {
                                                            .PartNumber = Convert.ToString(row.Item("PartNumber")),
                                                            .Qty = Convert.ToDecimal(row.Item("Qty")),
                                                            .Plant = Convert.ToString(row.Item("Plant")),
                                                            .ASN = Convert.ToString(row.Item("ASN")),
                                                            .IdContainerContent = Convert.ToInt32(row.Item("IdContainerContent")),
                                                            .IdContainer = Convert.ToInt32(row.Item("IdContainer")),
                                                            .ASNstatus = Convert.ToString(row.Item("Status"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
            'agregar nuevos registros
            For Each var In ASNsRecordsRefreshList
                Dim findRecord As ASNsRecords = New ASNsRecords
                findRecord = ASNsRecordsList.Find(Function(x) x.IdContainerContent = var.IdContainerContent And x.ASN = var.ASN)
                If findRecord Is Nothing Then
                    ASNsRecordsList.Add(New ASNsRecords() With {
                                                            .PartNumber = var.PartNumber,
                                                            .Qty = var.Qty,
                                                            .Plant = var.Plant,
                                                            .ASN = var.ASN,
                                                            .IdContainerContent = var.IdContainerContent,
                                                            .IdContainer = var.IdContainer,
                                                            .ASNstatus = var.ASNstatus
                                                        })
                End If
            Next
            'eliminar ASNs que ya fueron asignados
            'Dim containerToDelete As String
            'For Each var In ASNsRecordsList.ToList()
            '    Dim findAsnAssigned As ContainersContent
            '    findAsnAssigned = containersContentList.Find(Function(x) x.ASN = var.ASN)
            '    If Not findAsnAssigned Is Nothing AndAlso Not findAsnAssigned Is "" Then
            '        'containerToDelete = findAsnAssigned.IdContainerContent
            '        ASNsRecordsList.Remove(var)
            '        Dim containerToDelete As String = var.IdContainerContent
            '        For Each lely In ASNsRecordsList.ToList()
            '            Dim findContainer = New ASNsRecords
            '            findContainer = ASNsRecordsList.Find(Function(x) x.IdContainerContent = containerToDelete)
            '            If Not findContainer Is Nothing Then
            '                ASNsRecordsList.Remove(findContainer)
            '            End If
            '        Next
            '    End If
            'Next
            'For Each var In ASNsRecordsList.ToList()
            '    Dim findAsnAssigned As ContainersContent
            '    findAsnAssigned = containersContentList.Find(Function(x) x.IdContainerContent = containerToDelete)
            '    If Not findAsnAssigned Is Nothing AndAlso Not findAsnAssigned Is "" Then
            '        containerToDelete = findAsnAssigned.IdContainerContent
            '        ASNsRecordsList.Remove(var)
            '    End If
            'Next
        End Using
        Return ASNsRecordsList
    End Function

    Public Function getSapAsnList(ASNsList As List(Of ASNs), plantsList As ArrayList, idRoute As String) As List(Of ASNsSAP)
        Try
            If ASNsList Is Nothing Then
                ASNsList = ASNsClass.getSapASNs(idRoute)
            End If
            ASNsSAPList = New List(Of ASNsSAP)
            ASNsSAPList.Clear()
            For Each var In ASNsList
                ASNsSAPList.Add(New ASNsSAP() With {
                                            .Plant = var.Plant,
                                            .ASN = var.Original_document,
                                            .PartNumber = var.Material,
                                            .Qty = var.Delivery_quantity
                            })
            Next
            Return ASNsSAPList
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ASNassignment(idRoute As Integer, plantsList As ArrayList, ASNsList As List(Of ASNs), containersContentList As List(Of ContainersContent)) As List(Of ContainersContent)
        Try
            ASNsRecordsList = New List(Of ASNsRecords)
            ASNsRecordsList.Clear()
            ASNsRecordsList = getASNrecordsList(idRoute, containersContentList)
            ASNsSAPList = New List(Of ASNsSAP)
            ASNsSAPList.Clear()
            ASNsSAPList = getSapAsnList(ASNsList, plantsList, idRoute)
            Dim findSapRecords As ASNsSAP
            Dim findRecord As ASNsRecords
            Dim possibleASNs As List(Of PossibleASNs) = New List(Of PossibleASNs)
            If Not ASNsRecordsList Is Nothing Then
#Region "Paso 1" 'PN, PLNT, QTY, ASN
                For Each var In ASNsRecordsList.ToList()
                    findSapRecords = New ASNsSAP
                    findSapRecords = ASNsSAPList.Find(Function(x) x.PartNumber = var.PartNumber And x.ASN = var.ASN And x.Qty = var.Qty And x.Plant = var.Plant)
                    If Not findSapRecords Is Nothing Then
                        Dim count As Integer = 0
                        Dim findContentlist As List(Of ContainersContent) = New List(Of ContainersContent)
                        For Each z In containersContentList
                            findContentlist.Add(New ContainersContent() With {
                                                            .Qty = z.Qty,
                                                            .PartNumber = z.PartNumber
                                                        })
                        Next
                        For Each y In findContentlist
                            If y.PartNumber = var.PartNumber And y.Qty = var.Qty Then
                                count = count + 1
                            End If
                        Next
                        If count > 1 Then
                            Continue For
                        Else
                            Dim item = containersContentList.FirstOrDefault(Function(x) x.IdContainerContent = var.IdContainerContent)
                            Dim index = containersContentList.IndexOf(item)
                            item.ASN = var.ASN
                            containersContentList(index) = item
                            Dim containerToDelete = var.IdContainerContent
                            Dim ASNToDelete = var.ASN
                            Dim PNtoDelete = var.PartNumber
                            ASNsRecordsList.Remove(var)
                            For Each lely In ASNsRecordsList.ToList()
                                Dim findContainer = New ASNsRecords
                                findContainer = ASNsRecordsList.Find(Function(x) x.IdContainerContent = containerToDelete)
                                If Not findContainer Is Nothing Then
                                    ASNsRecordsList.Remove(findContainer)
                                End If
                            Next
                            For Each lely In ASNsRecordsList.ToList()
                                Dim findContainer = New ASNsRecords
                                findContainer = ASNsRecordsList.Find(Function(x) x.ASN = ASNToDelete And x.PartNumber = PNtoDelete)
                                If Not findContainer Is Nothing Then
                                    ASNsRecordsList.Remove(findContainer)
                                End If
                            Next
                        End If
                        'ASNsRecordsList = getASNrecordsList(idRoute, containersContentList)
                    End If
                Next
#Region "txt paso 1"
                If File.Exists("C:\aptiv\containerContent1.txt") Then
                    File.Delete("C:\aptiv\containerContent1.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent1.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent1.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                End If
#End Region
#End Region
#Region "Paso 2" 'PN, PLNT, ASN

                For Each var In ASNsRecordsList.ToList()
                    findSapRecords = New ASNsSAP
                    findSapRecords = ASNsSAPList.Find(Function(x) x.PartNumber = var.PartNumber And x.ASN = var.ASN And x.Plant = var.Plant)
                    If Not findSapRecords Is Nothing Then
                        Dim count As Integer = 0
                        Dim findContentlist As List(Of ASNsRecords) = New List(Of ASNsRecords)
                        For Each z In ASNsRecordsList
                            findContentlist.Add(New ASNsRecords() With {
                                                            .ASN = z.ASN,
                                                            .PartNumber = z.PartNumber
                                                        })
                        Next
                        For Each y In ASNsSAPList
                            If y.PartNumber = var.PartNumber Then 'And y.ASN = var.ASN Then
                                count = count + 1
                            End If
                        Next
                        If count > 1 Then
                            Continue For
                        Else
                            Dim item = containersContentList.First(Function(x) x.IdContainerContent = var.IdContainerContent)
                            Dim index = containersContentList.IndexOf(item)
                            item.ASN = var.ASN
                            containersContentList(index) = item
                            Dim containerToDelete = var.IdContainerContent
                            Dim ASNToDelete = var.ASN
                            Dim PNtoDelete = var.PartNumber
                            ASNsRecordsList.Remove(var)
                            For Each lely In ASNsRecordsList.ToList()
                                Dim findContainer = New ASNsRecords
                                findContainer = ASNsRecordsList.Find(Function(x) x.IdContainerContent = containerToDelete)
                                If Not findContainer Is Nothing Then
                                    ASNsRecordsList.Remove(findContainer)
                                End If
                            Next
                            For Each lely In ASNsRecordsList.ToList()
                                Dim findContainer = New ASNsRecords
                                findContainer = ASNsRecordsList.Find(Function(x) x.ASN = ASNToDelete And x.PartNumber = PNtoDelete)
                                If Not findContainer Is Nothing Then
                                    ASNsRecordsList.Remove(findContainer)
                                End If
                            Next
                        End If
                    End If
                Next
#Region "txt paso 2"
                If File.Exists("C:\aptiv\containerContent2.txt") Then
                    File.Delete("C:\aptiv\containerContent2.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent2.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent2.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                End If
#End Region
#End Region
#Region "Paso 3" 'PN, PLNT, QTY
                Dim ASNdistinct = From A In ASNsRecordsList
                                  Select A.IdContainerContent, A.PartNumber, A.Plant, A.Qty Distinct
                Dim ASNDistinctList As List(Of ASNsRecords) = New List(Of ASNsRecords)
                For Each o In ASNdistinct
                    ASNDistinctList.Add(New ASNsRecords() With {
                                                            .PartNumber = o.PartNumber,
                                                            .Qty = o.Qty,
                                                            .Plant = o.Plant,
                                                            .IdContainerContent = o.IdContainerContent
                                                        })
                Next
#Region "txt asn distinct"
                If File.Exists("C:\aptiv\ASNdistinct.txt") Then
                    File.Delete("C:\aptiv\ASNdistinct.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\ASNdistinct.txt", True)
                    For Each var In ASNdistinct
                        sw.WriteLine(" IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty)
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\ASNdistinct.txt", True)
                    For Each var In ASNdistinct
                        sw.WriteLine(" IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty)
                    Next
                    sw.Close()
                End If
#End Region
                For Each var In ASNDistinctList.ToList()
                    For Each p In ASNsSAPList
                        'findSapRecords = New ASNsSAP
                        'findSapRecords = ASNsSAPList.Find(Function(x) x.PartNumber = var.PartNumber And x.Plant = var.Plant)
                        'If Not findSapRecords Is Nothing Then
                        If var.PartNumber = p.PartNumber And var.Plant = p.Plant And var.Qty = p.Qty Then
                            possibleASNs.Add(New PossibleASNs() With {
                                             .IdContainerContent = var.IdContainerContent,
                                             .ASN = p.ASN
                                             })
                        End If
                        'Continue For
                        'End If
                    Next
                Next
#Region "txt paso 3"
                If File.Exists("C:\aptiv\containerContent3.txt") Then
                    File.Delete("C:\aptiv\containerContent3.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent3.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent3.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                End If
#End Region
#End Region
#Region "Paso 4" 'PN, PLNT
                For Each var In ASNDistinctList.ToList()
                    For Each p In ASNsSAPList
                        'findSapRecords = New ASNsSAP
                        'findSapRecords = ASNsSAPList.Find(Function(x) x.PartNumber = var.PartNumber And x.Plant = var.Plant)
                        'If Not findSapRecords Is Nothing Then
                        If var.PartNumber = p.PartNumber And var.Plant = p.Plant Then
                            possibleASNs.Add(New PossibleASNs() With {
                                             .IdContainerContent = var.IdContainerContent,
                                             .ASN = p.ASN
                                             })
                        End If
                        'Continue For
                        'End If
                    Next
                Next
#Region "Asignar posibles ASNs a containersContent"
                Dim possibleASNdistinct = From D In possibleASNs
                                          Select D.ASN, D.IdContainerContent Distinct
                Dim possibleASNlist As List(Of PossibleASNs) = New List(Of PossibleASNs)
                For Each m In possibleASNdistinct
                    possibleASNlist.Add(New PossibleASNs() With {
                                             .IdContainerContent = m.IdContainerContent,
                                             .ASN = m.ASN
                                             })
                Next
#Region "txt posibles asn"
                If File.Exists("C:\aptiv\posiblesasn.txt") Then
                    File.Delete("C:\aptiv\posiblesasn.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\posiblesasn.txt", True)
                    For Each var In possibleASNlist
                        sw.WriteLine(" IdCC " & var.IdContainerContent & " PN " & " asn " & var.ASN)
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\posiblesasn.txt", True)
                    For Each var In possibleASNlist
                        sw.WriteLine(" IdCC " & var.IdContainerContent & " PN " & " asn " & var.ASN)
                    Next
                    sw.Close()
                End If
#End Region
                For Each k In possibleASNlist
                    Dim findPossibleASN As ContainersContent
                    findPossibleASN = New ContainersContent
                    findPossibleASN = containersContentList.Find(Function(x) x.IdContainerContent = k.IdContainerContent)
                    If Not findPossibleASN Is Nothing Then
                        If findPossibleASN.possibleASNs Is Nothing Then
                            findPossibleASN.possibleASNs = New List(Of String)
                        End If
                        findPossibleASN.possibleASNs.Add(k.ASN)
                    End If
                Next
#End Region
#Region "txt paso 4"
                If File.Exists("C:\aptiv\containerContent4.txt") Then
                    File.Delete("C:\aptiv\containerContent4.txt")
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent4.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                Else
                    Dim sw As StreamWriter = New StreamWriter("C:\aptiv\containerContent4.txt", True)
                    For Each var In containersContentList
                        sw.WriteLine("IdC " & var.IdContainer & " IdCC " & var.IdContainerContent & " PN " & var.PartNumber & " qty " & var.Qty & " asn " & var.ASN)
                        If Not var.possibleASNs Is Nothing Then
                            For Each x In var.possibleASNs
                                sw.WriteLine(x.ToString())
                            Next
                        End If
                    Next
                    sw.Close()
                End If
#End Region
#End Region
                Return containersContentList
            End If
            Return containersContentList
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
