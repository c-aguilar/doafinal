Public Class Helper

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields As System.Reflection.PropertyInfo() = GetType(T).GetProperties()

        For Each field As System.Reflection.PropertyInfo In fields
            table.Columns.Add(field.Name, field.PropertyType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As System.Reflection.PropertyInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function
End Class
