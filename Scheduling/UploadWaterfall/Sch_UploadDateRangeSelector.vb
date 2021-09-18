Public Class Sch_UploadDateRangeSelector

    Private Sub btnShowDates_Click(sender As Object, e As EventArgs) Handles btnShowDates.Click
        Dim h As New Sch_DownloadedDatesUpload
        h.ShowDialog()
        h.Dispose()
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim sap As New SAP
        If sap.Available Then
            If SQL.Current.Exists("SELECT TOP 1 Material FROM Sch_SAP_ProductionPlan WHERE [Week] = '" & dtpWeek.Value.ToString("yyyy-MM-dd") & "'") Then
                If MessageBox.Show("Selected week already exists on database. Replace upload data?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    SQL.Current.Execute("DELETE FROM Sch_SAP_ProductionPlan WHERE [Week] = '" & dtpWeek.Value.ToString("yyyy-MM-dd") & "'")
                Else
                    Exit Sub
                End If
            End If
            LoadingScreen.Show()
            Dim filename As String = IO.Path.Combine(IO.Path.GetTempPath, Now.ToString("yyMMddHHmmss") & ".txt")
            If sap.AQ25ZPACK_INSTR_JC_UPLOAD_SCH(Parameter("SYS_PlantCode"), dtpFrom.Value, dtpTo.Value, filename) Then
                Dim upload = CSV.Datatable(filename, vbTab, True, False, 2)
                If upload IsNot Nothing Then
                    upload.Columns.Add("UploadDate", GetType(Date), "Convert([Date],'System.DateTime')")
                    upload.Columns.Add("UploadTime", GetType(Date), "Convert([Time],'System.DateTime')")
                    upload.DefaultView.Sort = "Material,UploadDate DESC,UploadTime DESC"
                    Dim all = upload.DefaultView.ToTable(False, "Material", "MRPCn", "User name", "UploadDate", "UploadTime", "Quantity", "Quantity_1", "Quantity_2", "Quantity_3", "Quantity_4", "Quantity_5", "Quantity_6", "Quantity_7", "Quantity_8", "Quantity_9", "Quantity_10", "Quantity_11", "Quantity_12", "Quantity_13", "Quantity_14", "Quantity_15", "Quantity_16", "Quantity_17", "Quantity_18", "Quantity_19", "Quantity_20", "Quantity_21", "Quantity_22", "Quantity_23", "Quantity_24", "Quantity_25", "Quantity_26", "Quantity_27")
                    Dim distinct As New DataTable
                    distinct.Columns.Add("Material")
                    distinct.Columns.Add("MRP")
                    distinct.Columns.Add("Username")
                    distinct.Columns.Add("Upload", GetType(Date))
                    distinct.Columns.Add("Week", GetType(Date))
                    For i = 1 To 28
                        distinct.Columns.Add("Q" & i, GetType(Integer))
                    Next
                    distinct.PrimaryKey = {distinct.Columns("Material")}
                    For Each row As DataRow In all.Rows
                        If distinct.Rows.Find(row.Item("Material")) Is Nothing Then distinct.Rows.Add(row.Item("Material"), row.Item("MRPCn"), row.Item("User name"), Date.Parse(CDate(row.Item("UploadDate")).ToShortDateString & " " & CDate(row.Item("UploadTime")).ToShortTimeString), dtpWeek.Value, CInt(row.Item("Quantity")), CInt(row.Item("Quantity_1")), CInt(row.Item("Quantity_2")), CInt(row.Item("Quantity_3")), CInt(row.Item("Quantity_4")), CInt(row.Item("Quantity_5")), CInt(row.Item("Quantity_6")), CInt(row.Item("Quantity_7")), CInt(row.Item("Quantity_8")), CInt(row.Item("Quantity_9")), CInt(row.Item("Quantity_10")), CInt(row.Item("Quantity_11")), CInt(row.Item("Quantity_12")), CInt(row.Item("Quantity_13")), CInt(row.Item("Quantity_14")), CInt(row.Item("Quantity_15")), CInt(row.Item("Quantity_16")), CInt(row.Item("Quantity_17")), CInt(row.Item("Quantity_18")), CInt(row.Item("Quantity_19")), CInt(row.Item("Quantity_20")), CInt(row.Item("Quantity_21")), CInt(row.Item("Quantity_22")), CInt(row.Item("Quantity_23")), CInt(row.Item("Quantity_24")), CInt(row.Item("Quantity_25")), CInt(row.Item("Quantity_26")), CInt(row.Item("Quantity_27")))
                    Next
                    If SQL.Current.Bulk(distinct, "Sch_SAP_ProductionPlan") Then
                        LoadingScreen.Hide()
                        MsgBox("Successfully done!", MsgBoxStyle.Information)
                    Else
                        LoadingScreen.Hide()
                        MsgBox("Error on bulking.", MsgBoxStyle.Critical)
                    End If
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("Error on downloading data.", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("SAP's session not found.", MsgBoxStyle.Critical)
        End If
        sap = Nothing
    End Sub

    Private Sub dtpWeek_ValueChanged(sender As Object, e As EventArgs) Handles dtpWeek.ValueChanged
        dtpWeek.Value = LastMonday(dtpWeek.Value)
    End Sub

    Private Sub UploadDateRangeSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = LastMonday(Now)
        dtpTo.Value = LastMonday(Now)
        dtpWeek.Value = LastMonday(Now)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpTo.Value = NextMonday(dtpFrom.Value)
        dtpWeek.Value = NextMonday(dtpFrom.Value)
    End Sub

    Private Sub Sch_UploadDateRangeSelector_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class