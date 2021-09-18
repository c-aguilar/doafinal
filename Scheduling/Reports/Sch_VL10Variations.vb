Public Class Sch_VL10Variations

    Private Sub VL10Variations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboFamily, SQL.Current.GetDatatable("SELECT DISTINCT Family FROM Sch_Business ORDER BY Family"))
        cboFamily.Items.Add("*")
        cboFamily.SelectedItem = "*"
        cboBusiness.Items.Add("*")
        cboBusiness.SelectedItem = "*"
        dtpFrom.Value = LastMonday()
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
        dgvVariations.DataSource = Nothing
        dgvLastWeek.DataSource = Nothing
        dgvCurrentWeek.DataSource = Nothing
        Dim last_week As String = DatePart(DateInterval.WeekOfYear, dtpFrom.Value.AddDays(-7)).ToString("00")
        Dim current_week As String = DatePart(DateInterval.WeekOfYear, dtpFrom.Value).ToString("00")
        Dim last_year As String = dtpFrom.Value.AddDays(-7).Year
        Dim current_year As String = dtpFrom.Value.Year
        Dim query_W1 As String
        Dim query_W2 As String
        If cboFamily.SelectedItem = "*" Then
            query_W1 = String.Format("SELECT ISNULL(M.Business,'') AS Business,ISNULL(M.CustomerPN,'') AS CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
         "V.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
         "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business RIGHT OUTER JOIN Sys_Calendar AS C ON C.Date = V.DeliveryDate " & _
         "WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
         "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,V.Material " & _
         "UNION ALL " & _
         "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
         "V.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
         "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business " & _
         "WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
         "GROUP BY M.Business,M.CustomerPN,V.Material " & _
         "UNION ALL " & _
         "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'Shipped' AS [Week]," & _
         "V.Material,ISNULL(SUM(Quantity),0) AS Quantity " & _
         "FROM (SELECT DISTINCT Material FROM Sch_VL10 WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1}) AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business " & _
         "LEFT OUTER JOIN Sch_ZMDESNR AS Z ON V.Material = Z.Material " & _
         "AND [Date] = '{2}' " & _
         "GROUP BY M.Business,M.CustomerPN,V.Material;", last_week, last_year, dtpFrom.Value.AddDays(-7).ToString("yyyy-MM-dd"))

            query_W2 = String.Format("SELECT ISNULL(M.Business,'') AS Business,ISNULL(M.CustomerPN,'') AS CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
         "V.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
         "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business RIGHT OUTER JOIN Sys_Calendar AS C ON C.Date = V.DeliveryDate " & _
         "WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
         "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,V.Material " & _
          "UNION ALL " & _
         "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
         "V.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
         "FROM Sch_VL10 AS V LEFT OUTER JOIN Sch_Materials AS M ON V.Material = M.Material LEFT OUTER JOIN Sch_Business AS B ON M.Business = B.Business " & _
         "WHERE DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
         "GROUP BY M.Business,M.CustomerPN,V.Material;", current_week, current_year, dtpFrom.Value.ToString("yyyy-MM-dd"))
        ElseIf cboBusiness.SelectedItem = "*" Then
            query_W1 = String.Format("SELECT M.Business,M.CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
          "M.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
          "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business CROSS JOIN Sys_Calendar AS C LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND C.Date = V.DeliveryDate AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} " & _
          "WHERE B.Family='{3}' AND  [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
          "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,M.Material " & _
          "UNION ALL " & _
          "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
          "M.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
          "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
          "WHERE B.Family='{3}' " & _
          "GROUP BY M.Business,M.CustomerPN,M.Material " & _
          "UNION ALL " & _
          "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'Shipped' AS [Week]," & _
          "M.Material,ISNULL(SUM(Quantity),0) AS Quantity " & _
          "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ZMDESNR AS Z ON M.Material = Z.Material " & _
          "AND [Date] = '{2}' " & _
          "WHERE B.Family='{3}' " & _
          "GROUP BY M.Business,M.CustomerPN,M.Material;", last_week, last_year, dtpFrom.Value.AddDays(-7).ToString("yyyy-MM-dd"), cboFamily.SelectedItem)

            query_W2 = String.Format("SELECT ISNULL(M.Business,'') AS Business,ISNULL(M.CustomerPN,'') AS CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
                "M.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
                "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business CROSS JOIN Sys_Calendar AS C LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND C.Date = V.DeliveryDate AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} " & _
                "WHERE B.Family='{3}' AND  [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
                "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,M.Material " & _
                 "UNION ALL " & _
          "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
          "M.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
          "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
          "WHERE B.Family='{3}' " & _
          "GROUP BY M.Business,M.CustomerPN,M.Material;", current_week, current_year, dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem)
        Else
            query_W1 = String.Format("SELECT M.Business,M.CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
            "M.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
            "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business CROSS JOIN Sys_Calendar AS C LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND C.Date = V.DeliveryDate AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} " & _
            "WHERE B.Family='{3}' AND B.Business = '{4}' AND  [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
            "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,M.Material " & _
            "UNION ALL " & _
            "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
            "M.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
            "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
            "WHERE B.Family='{3}' AND B.Business = '{4}' " & _
            "GROUP BY M.Business,M.CustomerPN,M.Material " & _
            "UNION ALL " & _
            "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'Shipped' AS [Week]," & _
            "M.Material,ISNULL(SUM(Quantity),0) AS Quantity " & _
            "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_ZMDESNR AS Z ON M.Material = Z.Material " & _
            "AND [Date] = '{2}' " & _
            "WHERE B.Family='{3}' AND B.Business = '{4}' " & _
            "GROUP BY M.Business,M.CustomerPN,M.Material;", last_week, last_year, dtpFrom.Value.AddDays(-7).ToString("yyyy-MM-dd"), cboFamily.SelectedItem, cboBusiness.SelectedItem)

            query_W2 = String.Format("SELECT M.Business,M.CustomerPN,CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2)  AS [Week]," & _
                "M.Material,ISNULL(Sum(OpenQuantity),0) AS Quantity " & _
                "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business CROSS JOIN Sys_Calendar AS C LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND C.Date = V.DeliveryDate AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} " & _
                "WHERE B.Family='{3}' AND B.Business = '{4}' AND  [Date] BETWEEN '{2}' AND DATEADD(D,112,'{2}') " & _
                "GROUP BY CONVERT(VARCHAR,DATEPART(YY,[Date])) + '/' + RIGHT('0' + CONVERT(VARCHAR,DATEPART(WK,[Date])),2),M.Business,M.CustomerPN,M.Material " & _
                "UNION ALL " & _
            "SELECT ISNULL(M.Business,''),ISNULL(M.CustomerPN,''),'PastDue' AS [Week], " & _
            "M.Material,ISNULL(SUM(OpenQuantity),0) AS Quantity " & _
            "FROM Sch_Materials AS M INNER JOIN Sch_Business AS B ON M.Business = B.Business LEFT OUTER JOIN Sch_VL10 AS V ON M.Material = V.Material AND DATEPART(WK,DownloadDate) = {0} AND DATEPART(YY,DownloadDate) = {1} AND DeliveryDate < '{2}' " & _
            "WHERE B.Family='{3}' AND B.Business = '{4}' " & _
            "GROUP BY M.Business,M.CustomerPN,M.Material;", current_week, current_year, dtpFrom.Value.ToString("yyyy-MM-dd"), cboFamily.SelectedItem, cboBusiness.SelectedItem)
        End If

        Dim pivoter_w1 As New PivotTable(SQL.Current.GetDatatable(query_W1))
        Dim pivoter_w2 As New PivotTable(SQL.Current.GetDatatable(query_W2))
        Dim pivot_w1 = pivoter_w1.PivotData("Business", "Material", "CustomerPN", "Quantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
        Dim pivot_w2 = pivoter_w2.PivotData("Business", "Material", "CustomerPN", "Quantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
        pivot_w1.TableName = "W1"
        pivot_w2.TableName = "W2"

        If Not pivot_w1.Columns.Contains("PastDue") Then pivot_w1.Columns.Add("PastDue", GetType(Integer))
        If Not pivot_w2.Columns.Contains("PastDue") Then pivot_w2.Columns.Add("PastDue", GetType(Integer))


        Dim ds As New DataSet
        ds.Tables.Add(pivot_w1)
        ds.Tables.Add(pivot_w2)

        Dim report As New DataTable("Variations")
        report.Merge(pivot_w1.DefaultView.ToTable(True, "Business", "Material", "CustomerPN"))
        report.PrimaryKey = {report.Columns("Material")}
        For Each row As DataRow In pivot_w2.Rows
            If report.Rows.Find(row.Item("Material")) Is Nothing Then report.Rows.Add(row.Item("Business"), row.Item("Material"), row.Item("CustomerPN"))
        Next

        ds.Tables.Add(report)
        ds.Relations.Add(New DataRelation("RW1", ds.Tables("Variations").Columns("Material"), ds.Tables("W1").Columns("Material"), False))
        ds.Relations.Add(New DataRelation("RW2", ds.Tables("Variations").Columns("Material"), ds.Tables("W2").Columns("Material"), False))

        ds.Tables("Variations").Columns.Add(New DataColumn("PastDue", GetType(Integer), String.Format("(ISNULL(AVG(Child(RW1).[Shipped]),0) - ISNULL(AVG(Child(RW1).[{0}/{1}]),0) - ISNULL(AVG(Child(RW1).[PastDue]),0)) * -1", last_year, last_week)))
        ds.Tables("Variations").Columns.Add(New DataColumn("Current PastDue", GetType(Integer), String.Format("ISNULL(AVG(Child(RW2).[PastDue]),0)", last_year, last_week)))

        Dim expression_wks As String = ""
        Dim cnter As Integer = 0
        For Each col As DataColumn In pivot_w1.Columns
            If Not {"Business", "CustomerPN", "Material", "PastDue", "Shipped", String.Format("{0}/{1}", last_year, last_week), String.Format("{0}/{1}", current_year, current_week)}.Contains(col.ColumnName) Then
                If Not ds.Tables("W2").Columns.Contains(col.ColumnName) Then
                    ds.Tables("W2").Columns.Add(col.ColumnName, col.DataType)
                End If
                ds.Tables("Variations").Columns.Add(New DataColumn(col.ColumnName, GetType(Integer), String.Format("ISNULL(AVG(Child(RW2).[{0}]),0) - ISNULL(AVG(Child(RW1).[{0}]),0)", col.ColumnName)))
                expression_wks &= String.Format("+[{0}]", col.ColumnName)
                cnter += 1
            ElseIf col.ColumnName = String.Format("{0}/{1}", current_year, current_week) Then
                ds.Tables("Variations").Columns.Add(New DataColumn(col.ColumnName, GetType(Integer), String.Format("IIF([PastDue]<0,ISNULL(AVG(Child(RW2).[{0}]),0) - ISNULL(AVG(Child(RW1).[{0}]),0) - [PastDue], ISNULL(AVG(Child(RW2).[{0}]),0) - ISNULL(AVG(Child(RW1).[{0}]),0))", col.ColumnName)))
                expression_wks &= String.Format("+[{0}]", col.ColumnName)
                cnter += 1
            End If
            If cnter = 4 Then
                ds.Tables("Variations").Columns.Add(New DataColumn("On LeadTime", GetType(Integer), expression_wks.Trim("+")))
                cnter += 1
            End If
        Next
        ds.Tables("W2").Columns("PastDue").SetOrdinal(3)
        ds.Tables("W1").Columns("PastDue").SetOrdinal(3)
        ds.Tables("W1").Columns("Shipped").SetOrdinal(5)
        dgvLastWeek.DataSource = ds.Tables("W1")
        dgvCurrentWeek.DataSource = ds.Tables("W2")
        dgvVariations.DataSource = ds.Tables("Variations")
        'dgvVariations.Columns("Balance").Visible = False
        LoadingScreen.Hide()
    End Sub

    Private Sub dgvVariations_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvVariations.CellFormatting
        If e.ColumnIndex > 4 Then
            If e.Value > 0 Then
                e.CellStyle.BackColor = Color.Crimson
                e.CellStyle.ForeColor = Color.White
            ElseIf e.Value < 0 Then
                e.CellStyle.BackColor = Color.Orange
            End If
        ElseIf e.ColumnIndex = 4 Then
            If e.Value > dgvVariations("PastDue", e.RowIndex).Value Then
                e.CellStyle.BackColor = Color.Crimson
                e.CellStyle.ForeColor = Color.White
            ElseIf e.Value < dgvVariations("PastDue", e.RowIndex).Value Then
                e.CellStyle.BackColor = Color.Orange
            End If
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpFrom.Value = LastMonday(dtpFrom.Value)
    End Sub

    Private Sub dgvVariations_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvVariations.RowsAdded
        dgvVariations.Rows(e.RowIndex).ContextMenuStrip = cmsReports
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If dgvVariations.DataSource IsNot Nothing Then
            LoadingScreen.Show()
            Dim cl As New List(Of MyExcel.ColorRange)
            For Each row As DataGridViewRow In dgvVariations.Rows
                For i = 4 To dgvVariations.Columns.Count - 1
                    If row.Cells(i).Value > 0 Then
                        cl.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(row.Index + 2, i + 1), Color.Crimson))
                    ElseIf row.Cells(i).Value < 0 Then
                        cl.Add(New MyExcel.ColorRange(MyExcel.ExcelCellReference(row.Index + 2, i + 1), Color.Orange))
                    End If
                Next
            Next
            If MyExcel.SaveAs({DTable.FromDatagridview(dgvVariations, "Variations"), DTable.FromDatagridview(dgvLastWeek, "Last Week"), DTable.FromDatagridview(dgvCurrentWeek, "Current Week")}, False, , {cl}) Then
                LoadingScreen.Hide()
                FlashAlerts.ShowConfirm("Done!")
            Else
                LoadingScreen.Hide()
            End If

        End If
    End Sub

    Private Sub Sch_VL10Variations_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class