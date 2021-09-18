Public Class Sch_VL10WaterfallReport
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
        Waterfall_dgv.DataSource = Nothing
        Dim material As String = ""
        If material_items.Count > 0 Then
            material = String.Join("','", material_items.ToArray)
        Else
            material = Material_txt.Text.Trim
        End If
        Dim vl10 As DataTable
        If material = "*" OrElse material = "" Then
            vl10 = SQL.Current.GetDatatable(String.Format("SELECT Material,ShipTo,DeliveryDate,OpenQuantity,CONVERT(VARCHAR(16),DownloadDate,121) AS DownloadDate,CONVERT(CHAR(4),DATEPART(Year,DeliveryDate)) + '/' + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(Wk,DeliveryDate)),2) AS [Week] FROM Sch_VL10 WHERE DeliveryDate BETWEEN '{0}' AND '{1}' ORDER BY DeliveryDate", From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        Else
            vl10 = SQL.Current.GetDatatable(String.Format("SELECT Material,ShipTo,DeliveryDate,OpenQuantity,CONVERT(VARCHAR(16),DownloadDate,121) AS DownloadDate,CONVERT(CHAR(4),DATEPART(Year,DeliveryDate)) + '/' + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(Wk,DeliveryDate)),2) AS [Week] FROM Sch_VL10 WHERE Material IN ('{0}') AND DeliveryDate BETWEEN '{1}' AND '{2}' ORDER BY DeliveryDate", material, From_dtp.Value.ToString("yyyy-MM-dd"), To_dtp.Value.ToString("yyyy-MM-dd")))
        End If
        Dim pivoter As New PivotTable(vl10)
        Dim pivot As DataTable = Nothing
        If Daily_rb.Checked Then
            If OnlyMaterial_rb.Checked Then
                pivot = pivoter.PivotDates("Material", "DownloadDate", "OpenQuantity", AggregateFunction.Sum, "DeliveryDate", "System.Int32")

                pivot.DefaultView.Sort = "Material,DownloadDate"
            ElseIf MaterialAndShipTo_rb.Checked Then
                pivot = pivoter.PivotDates("Material", "ShipTo", "DownloadDate", "OpenQuantity", AggregateFunction.Sum, "DeliveryDate", "System.Int32")
                pivot.DefaultView.Sort = "Material,ShipTo,DownloadDate"
            End If
        ElseIf Weekly_rb.Checked Then
            If OnlyMaterial_rb.Checked Then
                pivot = pivoter.PivotData("Material", "DownloadDate", "OpenQuantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
                pivot.DefaultView.Sort = "Material,DownloadDate"
            ElseIf MaterialAndShipTo_rb.Checked Then
                pivot = pivoter.PivotData("Material", "ShipTo", "DownloadDate", "OpenQuantity", AggregateFunction.Sum, {"Week"}, "System.Int32")
                pivot.DefaultView.Sort = "Material,ShipTo,DownloadDate"
            End If
        End If
        Waterfall_dgv.DataSource = pivot.DefaultView
        LoadingScreen.Hide()
    End Sub

    Private Function GetMonday(d As Date) As Date
        While d.DayOfWeek <> DayOfWeek.Monday
            d = d.AddDays(-1)
        End While
        Return d
    End Function

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
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

    Private Sub Waterfall_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Waterfall_dgv.CellFormatting
        If IsDBNull(e.Value) OrElse e.Value = "0" Then
            e.CellStyle.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub Sch_VL10WaterfallReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class
