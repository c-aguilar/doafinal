Imports System.Data.SqlClient

Public Class ContainersContent
    Public Property IdContainerContent As Integer '0
    Public Property IdContainer As Integer '1
    Public Property PartNumber As String '2
    Public Property Qty As Decimal '3
    Public Property UOM As String '4
    Public Property ASN As String '5
    Public Property possibleASNs As List(Of String) '6
    Public contentList As List(Of ContainersContent)

    Public Function getContentByRoute(ByVal idRoute As Integer) As List(Of ContainersContent)
        contentList = New List(Of ContainersContent)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        Dim sqlquery As String = String.Format("SELECT CC.[IdContainerContent]
                                                          ,ISNULL([Qty],'') AS [Qty]
                                                          ,ISNULL([UOM],'') AS [UOM]
                                                          ,ISNULL([ASN],'') AS [ASN]
                                                          ,ISNULL(CC.[IdContainer],'') AS [IdContainer]
                                                          ,ISNULL([PartNumber],'') AS [PartNumber] 
                                                FROM [ContainersContent] CC INNER JOIN [Containers] C ON C.IdContainer = CC.IdContainer WHERE C.IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        contentList.Add(New ContainersContent() With {
                                                            .IdContainerContent = Convert.ToInt32(row.Item("IdContainerContent")),
                                                            .Qty = Convert.ToDecimal(row.Item("Qty")),
                                                            .UOM = Convert.ToString(row.Item("UOM")),
                                                            .ASN = Convert.ToString(row.Item("ASN")),
                                                            .IdContainer = Convert.ToInt32(row.Item("IdContainer")),
                                                            .PartNumber = Convert.ToString(row.Item("PartNumber"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return contentList
    End Function
End Class
