Public Class Sch_VL10VsCapacityReport
    Dim ds As New DataSet
    Private Sub VL10VsCapacityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboFamily, SQL.Current.GetDatatable("SELECT DISTINCT Family FROM Sch_Business ORDER BY Family"))
        cboFamily.Items.Add("*")
        cboFamily.SelectedItem = "*"
        cboBusiness.Items.Add("*")
        cboBusiness.SelectedItem = "*"
        dtpFrom.Value = LastMonday()
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        LoadingScreen.Show()
        If cboFamily.SelectedItem = "*" Then
            Dim week As String = DatePart(DateInterval.WeekOfYear, dtpFrom.Value).ToString("00")
            Dim year As String = dtpFrom.Value.Year
            Dim query As String = String.Format("SELECT ISNULL(Business,'') AS Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2) AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,Sum(OpenQuantity) AS Quantity " & _
                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_ContractedCapacity_tmp  AS C ON V.Material = C.Material WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate >= '{2}' " & _
                "GROUP BY Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2),V.Material,C.BoardCode " & _
                "UNION ALL " & _
                "SELECT ISNULL(Business,'') AS Business,'PastDue' AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,SUM(OpenQuantity) AS PastDue " & _
                "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_ContractedCapacity_tmp AS C ON V.Material = C.Material WHERE DeliveryDate < '{2}' AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} GROUP BY M.Business,V.Material,C.BoardCode", week, year, dtpFrom.Value)

            Dim pivoter As New PivotTable(SQL.Current.GetDatatable(query))
            Dim pivot = pivoter.PivotData("Business", "Material", "BoardCode", "Quantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
            pivot.DefaultView.Sort = "Business,BoardCode,Material"
            Dim vl10_contracted = pivot.DefaultView.ToTable()
            vl10_contracted.TableName = "VL10Contracted"
            Dim vl10_installed = pivot.DefaultView.ToTable()
            vl10_installed.TableName = "VL10Installed"
            Dim contracted As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sch_ContractedCapacity_tmp", "CapacityContracted")
            Dim installed As DataTable = SQL.Current.GetDatatable("SELECT Board AS BoardCode,InstalledCapacity FROM Mfg_Boards", "CapacityInstalled")


            ds = New DataSet
            ds.Tables.Add(vl10_contracted)
            ds.Tables.Add(vl10_installed)
            ds.Tables.Add(contracted)
            ds.Tables.Add(installed)
            ds.Relations.Add(New DataRelation("CC", ds.Tables("VL10Contracted").Columns("Material"), ds.Tables("CapacityContracted").Columns("Material"), False))
            ds.Relations.Add(New DataRelation("CI", ds.Tables("VL10Installed").Columns("BoardCode"), ds.Tables("CapacityInstalled").Columns("BoardCode"), False))
            ds.Tables("VL10Contracted").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CC).[ContractedCapacity]),0) * 5")
            ds.Tables("VL10Contracted").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Contracted").Columns("PastDue").SetOrdinal(4)


            ds.Tables("VL10Installed").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CI).[InstalledCapacity]),0) * 5")
            ds.Tables("VL10Installed").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Installed").Columns("PastDue").SetOrdinal(4)
            dgvContracted.DataSource = ds.Tables("VL10Contracted")
            dgvInstalled.DataSource = ds.Tables("VL10Installed")
        ElseIf cboBusiness.SelectedItem = "*" Then
            Dim week As String = DatePart(DateInterval.WeekOfYear, dtpFrom.Value).ToString("00")
            Dim year As String = dtpFrom.Value.Year
            Dim query As String = String.Format("SELECT ISNULL(M.Business,'') AS Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2) AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,Sum(OpenQuantity) AS Quantity " & _
                "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ContractedCapacity_tmp AS C ON V.Material = C.Material " & _
                "WHERE B.Family = '{3}' AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate >= '{2}' " & _
                "GROUP BY M.Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2),V.Material,C.BoardCode " & _
                "UNION ALL " & _
                "SELECT ISNULL(M.Business,'') AS Business,'PastDue' AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,SUM(OpenQuantity) AS PastDue " & _
                "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ContractedCapacity_tmp AS C ON V.Material = C.Material  " & _
                "WHERE B.Family = '{3}' AND DeliveryDate < '{2}' AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} GROUP BY M.Business,V.Material,C.BoardCode", week, year, dtpFrom.Value, cboFamily.SelectedItem)

            Dim pivoter As New PivotTable(SQL.Current.GetDatatable(query))
            Dim pivot = pivoter.PivotData("Business", "Material", "BoardCode", "Quantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
            pivot.DefaultView.Sort = "Business,BoardCode,Material"
            Dim vl10_contracted = pivot.DefaultView.ToTable()
            vl10_contracted.TableName = "VL10Contracted"
            Dim vl10_installed = pivot.DefaultView.ToTable()
            vl10_installed.TableName = "VL10Installed"
            Dim contracted As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sch_ContractedCapacity_tmp", "CapacityContracted")
            Dim installed As DataTable = SQL.Current.GetDatatable("SELECT Board AS BoardCode,InstalledCapacity FROM Mfg_Boards", "CapacityInstalled")


            ds = New DataSet
            ds.Tables.Add(vl10_contracted)
            ds.Tables.Add(vl10_installed)
            ds.Tables.Add(contracted)
            ds.Tables.Add(installed)
            ds.Relations.Add(New DataRelation("CC", ds.Tables("VL10Contracted").Columns("Material"), ds.Tables("CapacityContracted").Columns("Material"), False))
            ds.Relations.Add(New DataRelation("CI", ds.Tables("VL10Installed").Columns("BoardCode"), ds.Tables("CapacityInstalled").Columns("BoardCode"), False))
            ds.Tables("VL10Contracted").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CC).[ContractedCapacity]),0) * 5")
            ds.Tables("VL10Contracted").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Contracted").Columns("PastDue").SetOrdinal(4)


            ds.Tables("VL10Installed").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CI).[InstalledCapacity]),0) * 5")
            ds.Tables("VL10Installed").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Installed").Columns("PastDue").SetOrdinal(4)
            dgvContracted.DataSource = ds.Tables("VL10Contracted")
            dgvInstalled.DataSource = ds.Tables("VL10Installed")
        Else
            Dim week As String = DatePart(DateInterval.WeekOfYear, dtpFrom.Value).ToString("00")
            Dim year As String = dtpFrom.Value.Year
            Dim query As String = String.Format("SELECT ISNULL(M.Business,'') AS Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2) AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,Sum(OpenQuantity) AS Quantity " & _
                "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ContractedCapacity_tmp AS C ON V.Material = C.Material " & _
                "WHERE B.Family = '{3}' AND M.Business = '{4}' AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate >= '{2}' " & _
                "GROUP BY M.Business,CONVERT(VARCHAR,DATEPART(YY,DeliveryDate)) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,DeliveryDate)),2),V.Material,C.BoardCode " & _
                "UNION ALL " & _
                "SELECT ISNULL(M.Business,'') AS Business,'PastDue' AS [Week],V.Material,ISNULL(C.BoardCode,'') AS BoardCode,SUM(OpenQuantity) AS PastDue " & _
                "FROM Sch_VL10 AS V INNER JOIN Sch_Materials AS M ON V.Material = M.Material INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ContractedCapacity_tmp AS C ON V.Material = C.Material  " & _
                "WHERE B.Family = '{3}' AND M.Business = '{4}' AND DeliveryDate < '{2}' AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} GROUP BY M.Business,V.Material,C.BoardCode", week, year, dtpFrom.Value, cboFamily.SelectedItem, cboBusiness.SelectedItem)

            Dim pivoter As New PivotTable(SQL.Current.GetDatatable(query))
            Dim pivot = pivoter.PivotData("Business", "Material", "BoardCode", "Quantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
            pivot.DefaultView.Sort = "Business,BoardCode,Material"
            Dim vl10_contracted = pivot.DefaultView.ToTable()
            vl10_contracted.TableName = "VL10Contracted"
            Dim vl10_installed = pivot.DefaultView.ToTable()
            vl10_installed.TableName = "VL10Installed"
            Dim contracted As DataTable = SQL.Current.GetDatatable("SELECT * FROM Sch_ContractedCapacity_tmp", "CapacityContracted")
            Dim installed As DataTable = SQL.Current.GetDatatable("SELECT Board AS BoardCode,InstalledCapacity FROM Mfg_Boards", "CapacityInstalled")


            ds = New DataSet
            ds.Tables.Add(vl10_contracted)
            ds.Tables.Add(vl10_installed)
            ds.Tables.Add(contracted)
            ds.Tables.Add(installed)
            ds.Relations.Add(New DataRelation("CC", ds.Tables("VL10Contracted").Columns("Material"), ds.Tables("CapacityContracted").Columns("Material"), False))
            ds.Relations.Add(New DataRelation("CI", ds.Tables("VL10Installed").Columns("BoardCode"), ds.Tables("CapacityInstalled").Columns("BoardCode"), False))
            ds.Tables("VL10Contracted").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CC).[ContractedCapacity]),0) * 5")
            ds.Tables("VL10Contracted").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Contracted").Columns("PastDue").SetOrdinal(4)


            ds.Tables("VL10Installed").Columns.Add("Capacity", GetType(Integer), "ISNULL(AVG(Child(CI).[InstalledCapacity]),0) * 5")
            ds.Tables("VL10Installed").Columns("Capacity").SetOrdinal(3)
            ds.Tables("VL10Installed").Columns("PastDue").SetOrdinal(4)
            dgvContracted.DataSource = ds.Tables("VL10Contracted")
            dgvInstalled.DataSource = ds.Tables("VL10Installed")
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpFrom.Value = LastMonday(dtpFrom.Value)
    End Sub


    Private Sub dgvContracted_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvContracted.CellFormatting
        If e.ColumnIndex > 3 Then
            If e.Value > dgvContracted("Capacity", e.RowIndex).Value Then
                dgvContracted(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Crimson
                dgvContracted(e.ColumnIndex, e.RowIndex).Style.ForeColor = Color.White
                'e.CellStyle.BackColor = Color.Crimson
                'e.CellStyle.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub dgvInstalled_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvInstalled.CellFormatting
        If e.ColumnIndex > 3 Then
            If dgvInstalled("Capacity", e.RowIndex).Value < ds.Tables("VL10Installed").Compute(String.Format("SUM([{0}])", ds.Tables("VL10Installed").Columns(e.ColumnIndex).ColumnName), String.Format("BoardCode = '{0}'", dgvInstalled("BoardCode", e.RowIndex).Value)) Then
                e.CellStyle.BackColor = Color.Crimson
                e.CellStyle.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If dgvContracted.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            Dim cl_contracted As New List(Of MyExcel.ColorRange)
            For Each row As DataGridViewRow In dgvContracted.Rows
                For i = 4 To dgvContracted.Columns.Count - 1
                    If row.Cells(i).Value > row.Cells("Capacity").Value Then
                        cl_contracted.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(row.Index + 2, i + 1), Color.Crimson))
                    End If
                Next
            Next

            Dim cl_installed As New List(Of MyExcel.ColorRange)
            For Each row As DataGridViewRow In dgvInstalled.Rows
                For i = 4 To dgvInstalled.Columns.Count - 1
                    If dgvInstalled("Capacity", row.Index).Value < ds.Tables("VL10Installed").Compute(String.Format("SUM([{0}])", ds.Tables("VL10Installed").Columns(i).ColumnName), String.Format("BoardCode = '{0}'", dgvInstalled("BoardCode", row.Index).Value)) Then
                        cl_installed.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(row.Index + 2, i + 1), Color.Crimson))
                    End If
                Next
            Next


            If MyExcel.SaveAs({dgvContracted.DataSource, dgvInstalled.DataSource}, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape, {cl_contracted, cl_installed}) Then
                LoadingScreen.Hide()
                MsgBox("Done!", MsgBoxStyle.Information)
            Else
                LoadingScreen.Hide()
            End If
        End If
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

    Private Sub Sch_VL10VsCapacityReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class