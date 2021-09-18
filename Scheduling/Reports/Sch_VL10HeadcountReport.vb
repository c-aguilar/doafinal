Public Class Sch_VL10HeadcountReport


    Private Sub ProductionPlanHeadcountReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboFamily, SQL.Current.GetDatatable("SELECT DISTINCT Family FROM Sch_Business ORDER BY Family"))
        cboFamily.Items.Add("*")
        cboFamily.SelectedItem = "*"
        cboBusiness.Items.Add("*")
        cboBusiness.SelectedItem = "*"
        dtpFrom.Value = LastMonday()
        dtpTo.Value = LastMonday(Now.AddDays(20)).AddDays(4)
    End Sub


    Private Sub cboFamily_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFamily.SelectionChangeCommitted
        If cboFamily.SelectedItem = "*" Then
            cboBusiness.Items.Clear()
            cboBusiness.Items.Add("*")
            cboBusiness.SelectedItem = "*"
        Else
            cboBusiness.Items.Clear()
            GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable(String.Format("SELECT Business FROM Sch_Business WHERE Family = '{0}' ORDER BY Business", cboFamily.SelectedItem)))
            cboBusiness.Items.Add("*")
            cboBusiness.SelectedItem = "*"
        End If
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        LoadingScreen.Show()
        If cboFamily.SelectedItem = "*" Then
            Dim data As DataTable = SQL.Current.GetDatatable(String.Format("SELECT ISNULL(VL10.[Material],'EMPTY_MATERIAL') AS Material,SC.[Date],ISNULL(OpenQuantity,0) AS Quantity,ISNULL((ShippingPoints * OpenQuantity) / 802,0) AS SPoints,ISNULL(SM.Business,'EMPTY_BUSINESS') AS Business " & _
                                                                           "FROM Sys_Calendar AS SC LEFT OUTER JOIN vw_Sch_DailyCustomerRequirements AS VL10 " & _
                                                                           "ON SC.[Date] = VL10.DeliveryDate LEFT OUTER JOIN Sch_Materials AS SM ON VL10.Material = SM.Material LEFT OUTER JOIN Sch_ShippingPoints AS SP ON VL10.Material = SP.Material " & _
                                                                           "WHERE SC.[Date] BETWEEN '{0}' AND '{1}' ORDER BY SC.Date ", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd")))
            Dim pivoter As New PivotTable(data)
            Dim headcount = pivoter.PivotDates("Business", "SPoints", AggregateFunction.Sum, "Date", "System.Double")
            Dim total = headcount.NewRow
            For Each col As DataColumn In headcount.Columns
                If col.ColumnName = "Business" Then
                    total.Item(col.ColumnName) = "Total"
                ElseIf col.ColumnName = "SPoints" Then

                Else
                    total.Item(col.ColumnName) = headcount.Compute(String.Format("SUM([{0}])", col.ColumnName), "")
                End If
            Next
            headcount.Rows.Add(total)
            dgvHeadcount.DataSource = headcount
            For Each col As DataColumn In headcount.Columns
                If col.ColumnName = "Business" Then

                ElseIf col.ColumnName = "SPoints" Then

                Else
                    dgvHeadcount.Columns(col.ColumnName).DefaultCellStyle.Format = "N1"
                End If
            Next

            Dim vl10 = pivoter.PivotDates("Material", "Business", "Quantity", AggregateFunction.Sum, "Date", "System.Int32")
            dgvVL10.DataSource = vl10
        ElseIf cboBusiness.SelectedItem = "*" Then

        Else

        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If dgvHeadcount.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            If MyExcel.SaveAs({DTable.FromDatagridview(dgvHeadcount, "Headcount"), DTable.FromDatagridview(dgvVL10, "VL10")}, False) Then
                LoadingScreen.Hide()
                MsgBox("Done!", MsgBoxStyle.Information)
            Else
                LoadingScreen.Hide()
            End If
        End If
    End Sub
    Private Sub dgvHeadcount_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvHeadcount.RowsAdded
        dgvHeadcount.Rows(e.RowIndex).ContextMenuStrip = cmsReports
    End Sub

    Private Sub Sch_VL10HeadcountReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class