Public Class Sch_ImportProductionPlan
    Dim data As DataTable
    Dim productionplan As DataTable
    Dim imported As Boolean = False
    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        ofd.Title = "Open Production Plan File..."
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Filename_txt.Text = ofd.FileName
            Dim sheet = SheetSelector.Get(ofd.FileName)
            data = DTable.FromFile(ofd.FileName, True, False, String.Format("SELECT * FROM [{0}]", sheet))
            Convert()
        End If
    End Sub
    Private Sub Convert()
        LoadingScreen.Show()
        Dim errors As Integer = 0
        If data IsNot Nothing Then
            ProductionPlan_dgv.DataSource = Nothing
            productionplan.Rows.Clear()
            If List_rb.Checked AndAlso data.Columns.Count >= 4 Then
                For Each row As DataRow In data.Rows
                    If IsDate(row.Item(2)) AndAlso IsNumeric(row.Item(3)) AndAlso Not IsDBNull(row.Item(3)) Then
                        Try
                            productionplan.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3))
                        Catch ex As Exception
                            errors += 1
                        End Try
                    Else
                        errors += 1
                    End If
                Next
            ElseIf ColumnHeader_rb.Checked AndAlso data.Columns.Count >= 3 AndAlso IsDate(data.Columns(2).ColumnName) Then
                For c = 2 To data.Columns.Count - 1
                    If IsDate(data.Columns(c).ColumnName) Then
                        For Each row As DataRow In data.Rows
                            If IsNumeric(row.Item(2)) AndAlso Not IsDBNull(row.Item(2)) Then
                                Try
                                    productionplan.Rows.Add(row.Item(0), row.Item(1), CDate(data.Columns(c).ColumnName), row.Item(2))
                                Catch ex As Exception
                                    errors += 1
                                End Try
                            Else
                                errors += 1
                            End If
                        Next
                    Else
                        errors += 1
                    End If
                Next
            Else
                errors = -2
            End If
            ProductionPlan_dgv.DataSource = productionplan
        Else
            ProductionPlan_dgv.DataSource = Nothing
            errors = -1
        End If
        LoadingScreen.Hide()
        Select Case errors
            Case 0
                Save_btn.Enabled = True
            Case -1
                Save_btn.Enabled = False
                MsgBox("Error on reading file.", MsgBoxStyle.Information, APP)
            Case -2
                Save_btn.Enabled = False
                MsgBox("Error on converting data to specific layout.", MsgBoxStyle.Exclamation, APP)
            Case Else
                If productionplan.Rows.Count = 0 Then
                    Save_btn.Enabled = False
                    MsgBox("Error on converting data to specific layout.", MsgBoxStyle.Exclamation, APP)
                Else
                    Save_btn.Enabled = True
                    MsgBox(String.Format("{0} error(s) found.", errors), MsgBoxStyle.Exclamation, APP)
                End If
        End Select
    End Sub

    Private Sub Sch_ImportProductionPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productionplan = New DataTable
        productionplan.Columns.Add("Material")
        productionplan.Columns.Add("Board")
        productionplan.Columns.Add("Date", GetType(Date))
        productionplan.Columns.Add("Quantity", GetType(Integer))
        productionplan.PrimaryKey = {productionplan.Columns("Material"), productionplan.Columns("Board"), productionplan.Columns("Date")}
        ProductionPlan_dgv.DataSource = productionplan
    End Sub

    Private Sub List_rb_CheckedChanged(sender As Object, e As EventArgs) Handles List_rb.CheckedChanged
        If data IsNot Nothing Then Convert()
    End Sub

    Private Sub Sch_ImportProductionPlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If imported Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If productionplan.Rows.Count > 0 Then
            If SQL.Current.Upsert(productionplan, "tmpProductionPlan", "CREATE TABLE #tmpProductionPlan ([Material] [char](8) NOT NULL,[Board] [varchar](15) NOT NULL,[Date] [date] NOT NULL,[Quantity] [smallint] NOT NULL)", "MERGE Sch_DailyProductionPlan AS target USING #tmpProductionPlan AS source ON target.Material = source.Material AND target.Board = source.Board AND target.[Date] = source.[Date] WHEN MATCHED THEN UPDATE SET Quantity = source.Quantity WHEN NOT MATCHED THEN INSERT (Material,Board,[Date],Quantity) VALUES (source.Material,source.Board,source.Date,source.Quantity);") Then
                imported = True
                MsgBox("Successfully imported!", MsgBoxStyle.Information, APP)
            Else
                MsgBox("Error on saving production plan.", MsgBoxStyle.Critical, APP)
            End If
        End If
    End Sub
End Class