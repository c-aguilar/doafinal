Imports System.Data.SqlClient

Public Class Containers
    Public Property IdContainer As Integer
    Public Property ReceivedDate As String
    Public Property Plant As String
    Public Property IdPushDelivery As String
    Public Property HasDamage As Boolean
    Public Property IdPallet As Integer
    Public Property IsPallet As Boolean
    Public Property IdRoute As Integer
    Public Property VendorInfo As String
    Public Property CarriersGuide As String
    Public containersList As List(Of Containers)
    Public ASNinContainerList As List(Of ASNinContainer)

    Public Class ASNinContainer
        Public Property IdContainer As Integer
        Public Property ASN As String
        Public Property ASNstatus As String
    End Class

    Public Function getContainersByRoute(ByVal idRoute As Integer) As List(Of Containers)
        containersList = New List(Of Containers)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT [IdContainer]
                                                      ,[ReceivedDate]
                                                      ,ISNULL([Plant], '') AS [Plant]
                                                      ,ISNULL([IdPushDelivery], '') AS [IdPushDelivery]
                                                      ,ISNULL([HasDamage], '') AS [HasDamage]
                                                      ,ISNULL([IdPallet],'') AS [IdPallet]
                                                      ,ISNULL([IsPallet],'') AS [IsPallet]
                                                      ,ISNULL([IdRoute],'') AS [IdRoute]
                                                      ,ISNULL([VendorInfo],'') AS [VendorInfo] 
                                                      ,ISNULL([CarriersGuide],'') AS [CarriersGuide]
                                                FROM [Containers] WHERE IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        containersList.Add(New Containers() With {
                                                            .IdContainer = Convert.ToInt32(row.Item("IdContainer")),
                                                            .ReceivedDate = Convert.ToString(row.Item("ReceivedDate")),
                                                            .Plant = Convert.ToString(row.Item("Plant")),
                                                            .IdPushDelivery = Convert.ToString(row.Item("IdPushDelivery")),
                                                            .HasDamage = Convert.ToBoolean(row.Item("HasDamage")),
                                                            .IdPallet = Convert.ToInt32(row.Item("IdPallet")),
                                                            .IsPallet = Convert.ToBoolean(row.Item("IsPallet")),
                                                            .IdRoute = Convert.ToInt32(row.Item("IdRoute")),
                                                            .VendorInfo = Convert.ToString(row.Item("VendorInfo")),
                                                            .CarriersGuide = Convert.ToString(row.Item("CarriersGuide"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return containersList
    End Function

    Public Function getASNinContainer(ByVal idRoute As Integer) As List(Of ASNinContainer)
        ASNinContainerList = New List(Of ASNinContainer)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT AIC.[IdContainer]
                                                      ,AIC.[ASN]
	                                                  ,ISNULL(ASNS.[Status], 'NotVal') AS [Status]
                                                  FROM [AsnsInContainer] AIC
                                                  INNER JOIN Containers C ON C.IdContainer = AIC.IdContainer
                                                  LEFT JOIN ASNsStatus ASNS ON ASNS.ASN = AIC.ASN
                                                  WHERE C.IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        ASNinContainerList.Add(New ASNinContainer() With {
                                                            .IdContainer = Convert.ToInt32(row.Item("IdContainer")),
                                                            .ASN = Convert.ToString(row.Item("ASN")),
                                                            .ASNstatus = Convert.ToString(row.Item("Status"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return ASNinContainerList
    End Function

End Class
