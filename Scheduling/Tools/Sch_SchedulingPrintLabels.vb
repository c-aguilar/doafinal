Public Class Sch_SchedulingPrintLabels
    Dim labels As DataTable
    Private Sub SchedulingPrintLabels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        labels = New DataTable
        labels.Columns.Add("Material")
        labels.Columns.Add("StdPack", GetType(Integer))
        labels.Columns.Add("Quantity", GetType(Integer))
        labels.Columns.Add("Copies", GetType(Integer))
        labels.Columns.Add("Ship To")
        labels.Columns.Add("Container")
        labels.Columns.Add("Document")
        labels.Columns.Add("Status")
        labels.Columns("StdPack").DefaultValue = 1
        labels.Columns("Quantity").DefaultValue = 1
        labels.Columns("Copies").DefaultValue = 1
        labels.Columns("StdPack").AllowDBNull = False
        labels.Columns("Quantity").AllowDBNull = False
        labels.Columns("Copies").AllowDBNull = False

        labels.Columns("Status").DefaultValue = "Waiting"
        labels.Columns("Ship To").DefaultValue = ""
        labels.Columns("Container").DefaultValue = ""
        labels.Columns("Document").DefaultValue = ""
        Materials_dgv.DataSource = labels
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If labels.Rows.Count > 0 Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                For Each l As DataRowView In labels.DefaultView
                    'Dim x = l.Item("StdPack")
                    'Dim y = l.Item("Quantity")
                    If l.Item("Quantity") <= l.Item("StdPack") Then
                        If Not (IsNothing(l.Item("Material")) OrElse IsDBNull(l.Item("Material"))) AndAlso sap.ZMDEPR(Parameter("SYS_PlantCode"), l.Item("Material"), IIf(IsNothing(l.Item("Ship To")) OrElse IsDBNull(l.Item("Ship To")), "", l.Item("Ship To")), IIf(IsNothing(l.Item("Container")) OrElse IsDBNull(l.Item("Container")), "", l.Item("Container")), l.Item("Quantity"), Delta.NullReplace(l.Item("Document"), ""), 1, l.Item("Copies")) Then
                            l.Item("Status") = "Printed"
                        Else
                            l.Item("Status") = "Error"
                        End If
                    Else
                        If Not (IsNothing(l.Item("Material")) OrElse IsDBNull(l.Item("Material"))) AndAlso sap.ZMDEPR(Parameter("SYS_PlantCode"), l.Item("Material"), IIf(IsNothing(l.Item("Ship To")) OrElse IsDBNull(l.Item("Ship To")), "", l.Item("Ship To")), IIf(IsNothing(l.Item("Container")) OrElse IsDBNull(l.Item("Container")), "", l.Item("Container")), l.Item("StdPack"), Delta.NullReplace(l.Item("Document"), ""), Math.Floor(l.Item("Quantity") / l.Item("StdPack")), l.Item("Copies")) Then
                            Dim quantity_remaining = l.Item("Quantity") - (Math.Floor(l.Item("Quantity") / l.Item("StdPack")) * l.Item("StdPack"))
                            If quantity_remaining > 0 Then
                                sap.ZMDEPR(Parameter("SYS_PlantCode"), l.Item("Material"), IIf(IsNothing(l.Item("Ship To")) OrElse IsDBNull(l.Item("Ship To")), "", l.Item("Ship To")), IIf(IsNothing(l.Item("Container")) OrElse IsDBNull(l.Item("Container")), "", l.Item("Container")), quantity_remaining, Delta.NullReplace(l.Item("Document"), ""), 1, l.Item("Copies"))
                            End If
                            l.Item("Status") = "Printed"
                        Else
                            l.Item("Status") = "Error"
                        End If
                    End If
                    Materials_dgv.Refresh()
                Next
                LoadingScreen.Hide()
            Else
                LoadingScreen.Hide()
                MsgBox("SAP's session not found.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim cb = DTable.FromClipboard()
        If cb IsNot Nothing Then
            For Each row As DataRow In cb.Rows
                Try
                    Dim nr = labels.NewRow
                    For i = 0 To 6
                        If i < cb.Columns.Count AndAlso Not IsDBNull(row.Item(i)) AndAlso Not IsNothing(row.Item(i)) AndAlso Not row.Item(i).ToString.Trim = "" Then
                            nr.Item(i) = row.Item(i)
                        End If
                    Next
                    labels.Rows.Add(nr)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub Materials_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Materials_dgv.CellFormatting
        If Materials_dgv.Columns(e.ColumnIndex).Name = "status_img" Then
            Select Case Materials_dgv.Rows(e.RowIndex).Cells("Status").Value
                Case "Waiting"
                    e.Value = My.Resources.information_16
                Case "Printed"
                    e.Value = My.Resources.ok_16
                Case "Error"
                    e.Value = My.Resources.critical_16
            End Select
        End If
    End Sub

    Private Sub SchedulingPrintLabels_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Materials_dgv.Columns("status_img").DisplayIndex = 8
    End Sub

    Private Sub Materials_dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Materials_dgv.DataError
        e.Cancel = True
    End Sub

    Private Sub ShipTo_btn_Click(sender As Object, e As EventArgs) Handles ShipTo_btn.Click
        For Each l As DataRow In labels.Rows
            l.Item("Ship To") = SQL.Current.GetString(String.Format("SELECT TOP 1 ShipTo FROM Sch_VL10 WHERE Material = '{0}' ORDER BY DownloadDate DESC,DeliveryDate ASC", l.Item("Material")), "")
        Next
    End Sub

    Private Sub Document_btn_Click(sender As Object, e As EventArgs) Handles Document_btn.Click
        For Each l As DataRow In labels.Rows
            l.Item("Document") = SQL.Current.GetString(String.Format("SELECT TOP 1 OriginDocument FROM Sch_VL10 WHERE Material = '{0}' ORDER BY DownloadDate DESC,DeliveryDate ASC", l.Item("Material")), "")
        Next
    End Sub

    Private Sub Sch_SchedulingPrintLabels_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class