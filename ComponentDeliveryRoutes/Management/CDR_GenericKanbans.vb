Public Class CDR_GenericKanbans

    Private Sub CDR_GenericKanbans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadKanbans()
    End Sub

    Private Sub LoadKanbans()
        Generic_dgv.DataSource = SQL.Current.GetDatatable("SELECT [Code] AS Codigo, Partnumber AS [No. de Parte],Description AS Descripcion,Board AS Tablero,Kit,Business AS Negocio,Comment AS Comentario,Rack,Local AS [Localizacion] FROM CDR_Kanbans WHERE Generic = 1")
    End Sub

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim data As New DataTable
        data.Columns.Add("Partnumber")
        data.Columns.Add("Description")
        data.Columns.Add("Board")
        data.Columns.Add("Kit")
        data.Columns.Add("Business")
        data.Columns.Add("Comment")
        data.Columns.Add("Rack")
        data.Columns.Add("Local")
        data.Columns.Add("Generic", GetType(Boolean))

        Dim columns(8) As SqlClient.SqlBulkCopyColumnMapping

        columns(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
        columns(1) = New SqlClient.SqlBulkCopyColumnMapping("Board", "Board")
        columns(2) = New SqlClient.SqlBulkCopyColumnMapping("Description", "Description")
        columns(3) = New SqlClient.SqlBulkCopyColumnMapping("Kit", "Kit")
        columns(4) = New SqlClient.SqlBulkCopyColumnMapping("Business", "Business")
        columns(5) = New SqlClient.SqlBulkCopyColumnMapping("Comment", "Comment")
        columns(6) = New SqlClient.SqlBulkCopyColumnMapping("Rack", "Rack")
        columns(7) = New SqlClient.SqlBulkCopyColumnMapping("Local", "Local")
        columns(8) = New SqlClient.SqlBulkCopyColumnMapping("Generic", "Generic")


        Dim clipboard = DTable.FromClipboard(8)
        If clipboard IsNot Nothing Then
            For Each row As DataRow In clipboard.Rows
                data.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), True)
            Next
            If SQL.Current.Bulk(data, "CDR_Kanbans", columns) Then
                LoadKanbans()
                FlashAlerts.ShowConfirm(String.Format("{0} kanbans agregadas!", data.Rows.Count))
            Else
                FlashAlerts.ShowError("Error al guardar la información proporcionada.")
            End If
        Else
            FlashAlerts.ShowError("No fue posible obtener la información del portapapeles.")
        End If
    End Sub
End Class