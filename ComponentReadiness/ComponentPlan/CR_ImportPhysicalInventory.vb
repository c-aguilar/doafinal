Public Class CR_ImportPhysicalInventory
    Dim inventory_dt As DataTable
    Dim valid_uoms As DataTable

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim clip As DataTable = DTable.clipboardExcelToDataTable(False)
        If clip Is Nothing Then
            clip = DTable.FromClipboard(False, True)
        End If
        If clip IsNot Nothing Then
            If clip.Columns.Count >= 3 Then
                Try
                    For Each row As DataRow In clip.Rows
                        inventory_dt.Rows.Add(RawMaterial.Format(row.Item(0)), If(row.Item(2).ToString.Trim.ToUpper = "PC", Math.Round(Math.Abs(CDec(row.Item(1))), 0), Math.Abs(CDec(row.Item(1)))), row.Item(2).ToString.Trim.ToUpper, RawMaterial.Exists(RawMaterial.Format(row.Item(0))), RawMaterial.ValidUoM(RawMaterial.Format(row.Item(0)), row.Item(2).ToString.Trim))
                    Next
                Catch ex As Exception
                    FlashAlerts.ShowError("Error con la información.")
                Finally
                    Inventory_dgv.DataSource = inventory_dt
                End Try
            Else
                FlashAlerts.ShowError("Error con la información.")
            End If
        Else
            FlashAlerts.ShowError("No existe nada en el portapapeles.")
        End If
    End Sub

    Private Sub CR_ImportPhysicalInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inventory_dt = New DataTable
        inventory_dt.Columns.Add("Partnumber")
        inventory_dt.Columns.Add("Quantity", GetType(Decimal))
        inventory_dt.Columns.Add("UoM")
        inventory_dt.Columns.Add("ValidPartnumber", GetType(Boolean))
        inventory_dt.Columns.Add("ValidUoM", GetType(Boolean))
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If inventory_dt.Rows.Count > 0 Then
            inventory_dt.DefaultView.RowFilter = "ValidPartnumber = 'True' AND ValidUoM = 'True'"
            Dim bulk_dt As DataTable = inventory_dt.DefaultView.ToTable(True)
            bulk_dt.Columns.Add("Username")
            For Each row As DataRow In bulk_dt.Rows
                row.Item("Username") = User.Current.Username
            Next

            Dim col_map(3) As SqlClient.SqlBulkCopyColumnMapping
            col_map(0) = New SqlClient.SqlBulkCopyColumnMapping("Partnumber", "Partnumber")
            col_map(1) = New SqlClient.SqlBulkCopyColumnMapping("Quantity", "Quantity")
            col_map(2) = New SqlClient.SqlBulkCopyColumnMapping("UoM", "UoM")
            col_map(3) = New SqlClient.SqlBulkCopyColumnMapping("Username", "Username")


            If SQL.Current.Bulk(bulk_dt, "Ord_WIPStock", col_map) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                FlashAlerts.ShowError("No fue posible guardar la información.")
            End If
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Inventory_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Inventory_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso Not Inventory_dgv.Rows(e.RowIndex).IsNewRow Then
            If e.ColumnIndex = Inventory_dgv.Columns("Inventory_Partnumber_col").Index Then
                If Inventory_dgv.Rows(e.RowIndex).Cells("Inventory_ValidPartnumber_col").Value Then
                    e.CellStyle.BackColor = Color.LightGreen
                Else
                    e.CellStyle.BackColor = Color.LightCoral
                End If
            ElseIf e.ColumnIndex = Inventory_dgv.Columns("Inventory_UoM_col").Index Then
                If Inventory_dgv.Rows(e.RowIndex).Cells("Inventory_ValidUoM_col").Value Then
                    e.CellStyle.BackColor = Color.LightGreen
                Else
                    e.CellStyle.BackColor = Color.LightCoral
                End If
            End If
        End If
    End Sub
End Class