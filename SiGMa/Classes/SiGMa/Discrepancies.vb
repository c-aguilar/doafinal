Imports System.Data.SqlClient

Public Class Discrepancies
    Public Class ASNmissingMaterial
        Public Property ASN As String
        Public Property PartNumber As String
        Public Property Quantity As String
    End Class
    Public Class MaterialWithOutASN
        Public Property Plant As String
        Public Property Pallet As String
        Public Property PartNumber As String
        Public Property Quantity As String
    End Class

    Public Function getASNmissingMaterial(idRoute As String) As List(Of ASNmissingMaterial)
        Dim ASNmissingMaterialList As List(Of ASNmissingMaterial) = New List(Of ASNmissingMaterial)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        'Query para traer tablas de ASNs multiplicadas por ContainersContent
        Dim sqlquery As String = String.Format("WITH MissingMaterial AS(
	                                                    SELECT A.Original_document AS ASN, A.Material AS PartNumber 
	                                                    FROM [Routes_ASNs] RA
	                                                    INNER JOIN ASNsStatus ASS ON ASS.ASN = RA.ASN
	                                                    INNER JOIN ASNs A ON A.Original_document = RA.ASN
	                                                    WHERE RA.IdRoute = {0}
	                                                    EXCEPT
	                                                    SELECT CC.ASN, CC.PartNumber
	                                                    FROM [Routes] R 
	                                                    INNER JOIN Containers C ON C.IdRoute = R.IdRoute 
	                                                    INNER JOIN ContainersContent CC ON CC.IdContainer = C.IdContainer
	                                                    WHERE CC.ASN IS NOT NULL AND R.IdRoute = {0}
	                                                    )
	                                                    SELECT MM.*, A.Delivery_quantity AS Qty FROM MissingMaterial MM 
                                                    INNER JOIN ASNs A ON A.Original_document = MM.ASN", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        'Generar lista de tablas multiplicadas
                        ASNmissingMaterialList.Add(New ASNmissingMaterial() With {
                                                            .PartNumber = Convert.ToString(row.Item("PartNumber")),
                                                            .Quantity = Convert.ToDecimal(row.Item("Qty")),
                                                            .ASN = Convert.ToString(row.Item("ASN"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return ASNmissingMaterialList
    End Function

    Public Function getMaterialWithOutASN(idRoute As String) As List(Of MaterialWithOutASN)
        Dim materialWOasnList As List(Of MaterialWithOutASN) = New List(Of MaterialWithOutASN)
        Dim conn As SqlConnection = New SqlConnection(Form1.Current.connString)
        'Query para traer tablas de ASNs multiplicadas por ContainersContent
        Dim sqlquery As String = String.Format("SELECT C.Plant, C.IdPallet, CC.PartNumber, CC.Qty
	                                            FROM ContainersContent CC
	                                            INNER JOIN Containers C ON C.IdContainer = CC.IdContainer
	                                            WHERE CC.ASN IS NULL AND C.IdRoute = {0}", idRoute)
        Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        Dim dt As DataTable = New DataTable()
        Using conn
            conn.Open()
            Using reader As SqlDataReader = command.ExecuteReader()
                If (reader.HasRows) Then
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        'Generar lista de tablas multiplicadas
                        materialWOasnList.Add(New MaterialWithOutASN() With {
                                                            .Plant = Convert.ToString(row.Item("Plant")),
                                                            .Pallet = Convert.ToString(row.Item("IdPallet")),
                                                            .PartNumber = Convert.ToString(row.Item("PartNumber")),
                                                            .Quantity = Convert.ToDecimal(row.Item("Qty"))
                                                        })
                    Next
                End If
            End Using
            conn.Close()
        End Using
        Return materialWOasnList
    End Function
End Class
