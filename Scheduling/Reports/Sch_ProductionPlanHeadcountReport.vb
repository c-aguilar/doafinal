Public Class Sch_ProductionPlanHeadcountReport

    Private Sub ProductionPlanHeadcountReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboFamily, SQL.Current.GetDatatable("SELECT DISTINCT Family FROM Sch_Business AS B INNER JOIN Sch_MRPControllers AS M ON B.MRP = M.MRP ORDER BY Family"))
        cboFamily.Items.Add("*")
        cboFamily.SelectedItem = "*"
        cboBusiness.Items.Add("*")
        cboBusiness.SelectedItem = "*"
        dtpFrom.Value = LastMonday().AddDays(-3)
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

        Dim query As String = "SELECT M.Business,PP.Material,M.CustomerPN,ISNULL(SP.ShippingPoints,0) AS SPoints,"
        Dim query_b As String

        If cboFamily.SelectedItem = "*" Then
            query_b = String.Format(" FROM Sch_SAP_ProductionPlan AS PP LEFT OUTER JOIN Sch_ShippingPoints AS SP ON PP.Material = SP.Material LEFT OUTER JOIN Sch_Materials AS M ON PP.Material = M.Material WHERE [Date]='{0}' ORDER BY PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd"))
        ElseIf cboBusiness.SelectedItem = "*" Then
            query_b = String.Format(" FROM Sch_SAP_ProductionPlan AS PP LEFT OUTER JOIN Sch_ShippingPoints AS SP ON PP.Material = SP.Material LEFT OUTER JOIN Sch_Materials AS M ON PP.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business WHERE [Date]='{0}' AND B.Family='{1}' ORDER BY B.Family,PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem)
        Else
            query_b = String.Format(" FROM Sch_SAP_ProductionPlan AS PP LEFT OUTER JOIN Sch_ShippingPoints AS SP ON PP.Material = SP.Material LEFT OUTER JOIN Sch_Materials AS M ON PP.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business WHERE [Date]='{0}' AND B.Family='{1}' AND B.Business = '{2}' ORDER BY B.Family,B.Business,PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem, cboBusiness.SelectedItem)
        End If



        For i = 1 To 14
            query &= String.Format("Day{0}*ISNULL(ShippingPoints,0)/808 AS Day{0},", i)
        Next
        For i = 3 To 16
            query &= String.Format("Week{0}*ISNULL(ShippingPoints,0)/808 AS Week{0},", i)
        Next
        Dim data As DataTable = SQL.Current.GetDatatable(query.Trim(",") & query_b, "Headcount")
        data.Columns("SPoints").SetOrdinal(3)
        Dim total = data.NewRow
        For Each col As DataColumn In data.Columns
            If Not {"Material", "Business", "CustomerPN", "SPoints"}.Contains(col.ColumnName) Then
                total.Item(col.ColumnName) = data.Compute(String.Format("SUM([{0}])", col.ColumnName), "")
            ElseIf col.ColumnName = "Material" Then
                total.Item(col.ColumnName) = "Total"
            End If
        Next
        data.Rows.Add(total)
        dgvHeadcount.DataSource = data
        For Each col As DataColumn In data.Columns
            If Not {"Material", "Business", "CustomerPN", "SPoints"}.Contains(col.ColumnName) Then
                dgvHeadcount.Columns(col.ColumnName).DefaultCellStyle.Format = "N1"
            End If
        Next
        If cboFamily.SelectedItem = "*" Then
            dgvProductionPlan.DataSource = SQL.Current.GetDatatable(String.Format("SELECT ISNULL(B.Family,'') AS Family,ISNULL(M.Business,0) AS Business,PP.* FROM Sch_SAP_ProductionPlan AS PP LEFT OUTER JOIN Sch_Materials AS M PP.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business WHERE Date='{0}' ORDER BY B.Family,B.Business,PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd")), "ProductionPlan")
        ElseIf cboBusiness.SelectedItem = "*" Then
            dgvProductionPlan.DataSource = SQL.Current.GetDatatable(String.Format("SELECT B.Family,M.Business,PP.* FROM Sch_SAP_ProductionPlan AS PP INNER JOIN Sch_Materials AS M PP.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business WHERE Date='{0}' AND Family='{1}' ORDER BY B.Family,B.Business,PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem), "ProductionPlan")
        Else
            dgvProductionPlan.DataSource = SQL.Current.GetDatatable(String.Format("SELECT B.Family,M.Business,PP.* FROM Sch_SAP_ProductionPlan AS PP INNER JOIN Sch_Materials AS M PP.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business WHERE Date='{0}' AND Family='{1}' AND M.Business='{2}' ORDER BY B.Family,B.Business,PP.Material", dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem, cboBusiness.SelectedItem), "ProductionPlan")
        End If

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If dgvHeadcount.DataSource IsNot Nothing Then
            If MyExcel.SaveAs({dgvHeadcount.DataSource, dgvProductionPlan.DataSource}, False) Then
                MsgBox("Done!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Sch_ProductionPlanHeadcountReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class