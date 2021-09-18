Public Class Sch_UploadWaterfallReport
    Dim material_items As New ArrayList
    Dim sb As SearchBox
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.SetNewDataGridView(Me.Waterfall_dgv)
        sb.MdiParent = Me.MdiParent
        To_dtp.Value = GetMonday(Now)
        From_dtp.Value = GetMonday(Now).AddDays(-112)
        Material_txt.Text = "*"
    End Sub

#Region "Generic Controls"
    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(Waterfall_dgv.DataSource, Title_lbl.Text)
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        If Not IsNothing(Waterfall_dgv.DataSource) Then
            Clipboard.SetDataObject(Waterfall_dgv.GetClipboardContent())
        End If
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        sb.Show()
        sb.BringToFront()
    End Sub
#End Region

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        Waterfall_dgv.DataSource = Nothing
        LoadingScreen.Show()
        Dim material As String = ""
        If material_items.Count > 0 Then
            material = String.Join("','", material_items.ToArray)
        Else
            material = Material_txt.Text.Trim
        End If
        Dim report As New DataTable
        report.Columns.Add("Material")
        report.Columns.Add("Upload", GetType(Date))
        Dim weeks As DataTable = SQL.Current.GetDatatable(String.Format("SELECT * FROM Sch_UploadWeeks WHERE Date BETWEEN '{0}' AND '{1}';", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        For Each d As DataRow In weeks.Rows
            For i = 1 To 16
                If Not report.Columns.Contains(d.Item(i)) Then
                    report.Columns.Add(d.Item(i), GetType(Integer))
                End If
            Next
            Dim upload As DataTable
            If material = "*" OrElse material = "" Then
                upload = SQL.Current.GetDatatable(String.Format("SELECT Material,UploadDate,Day1+Day2+Day3+Day4+Day5+Day6+Day7 AS Week1,Day8+Day9+Day10+Day11+Day12+Day13+Day14 AS Week2,Week3,Week4,Week5,Week6,Week7,Week8,Week9,Week10,Week11,Week12,Week13,Week14,Week15,Week16 FROM Sch_SAP_ProductionPlan WHERE [Week] = '{0}';", CDate(d.Item("Date")).ToString("yyyy-MM-dd")))
            Else
                upload = SQL.Current.GetDatatable(String.Format("SELECT Material,UploadDate,Day1+Day2+Day3+Day4+Day5+Day6+Day7 AS Week1,Day8+Day9+Day10+Day11+Day12+Day13+Day14 AS Week2,Week3,Week4,Week5,Week6,Week7,Week8,Week9,Week10,Week11,Week12,Week13,Week14,Week15,Week16 FROM Sch_SAP_ProductionPlan WHERE [Week] = '{0}' AND Material IN ('{1}');", CDate(d.Item("Date")).ToString("yyyy-MM-dd"), material))
            End If
            For Each m As DataRow In upload.Rows
                Dim new_row = report.NewRow
                new_row.Item("Material") = m.Item("Material")
                new_row.Item("Upload") = m.Item("UploadDate")
                For i = 1 To 16
                    new_row.Item(d.Item(i)) = m.Item("Week" & i)
                Next
                report.Rows.Add(new_row)
            Next
        Next
        report.DefaultView.Sort = "Material,Upload"
        Waterfall_dgv.DataSource = report
        LoadingScreen.Hide()
    End Sub

    Private Function GetMonday(d As Date) As Date
        While d.DayOfWeek <> DayOfWeek.Monday
            d = d.AddDays(-1)
        End While
        Return d
    End Function

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(material_items)
        ld.Title = "Material"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            material_items = ld.Items
            If material_items.Count > 0 Then
                Material_txt.Text = String.Join(",", material_items.ToArray)
                Material_txt.Enabled = False
            Else
                Material_txt.Clear()
                Material_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub dgvReport_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Waterfall_dgv.CellFormatting
        If IsDBNull(e.Value) Then e.CellStyle.BackColor = Color.LightGray
    End Sub

    Private Sub Sch_UploadWaterfallReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class
