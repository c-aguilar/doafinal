Public Class PartNumbersAdministration
    Dim previousRows As Integer

    Private Sub loadPNBtn_Click(sender As Object, e As EventArgs) Handles loadPNBtn.Click
        If plantCB.Text IsNot "" Then
            Dim sap As New SAP
            Me.Cursor = Cursors.WaitCursor
            If sap.Available Then
                Dim filename As String = GF.TempTXTPath
                If sap.AQ25ZPACK_INSTR_MM_MARC_ALL(plantCB.Text, filename, "F", "*") Then
                    Dim txt = CSV.Datatable(filename, vbTab, True, False)
                    If txt IsNot Nothing Then
                        txt.Columns.Add("RT_MATERIAL", GetType(String), "IIF(LEN([MATERIAL]) > 8,SUBSTRING([MATERIAL],LEN(MATERIAL)-7,8),[MATERIAL])")
                        txt.Columns.Add("UNIT_PRICE", GetType(Decimal), "IIF(Convert([PRICE_UNIT],'System.Decimal') > 0,Convert([STD_PRICE],'System.Decimal') /Convert([PRICE_UNIT],'System.Decimal') ,0)")
                        Dim bulk_data = txt.DefaultView.ToTable(True, "RT_MATERIAL", "DESCRIPTION", "BUM", "UNIT_PRICE")
                        If SQL.Current.Upsert(bulk_data, "tmp_RawMaterial", "CREATE TABLE #tmp_RawMaterial 
	                                                                        ([PartNumber] [varchar](15) NOT NULL,
	                                                                        [Description] [varchar](max) NULL,
	                                                                        [UoM] [varchar](3) NOT NULL,
	                                                                        [UnitCost] [decimal](18, 7) NOT NULL);",
                                                                            "MERGE dbo.Sys_RawMaterial AS target USING #tmp_RawMaterial AS source ON target.PartNumber = source.PartNumber 
                                                                            WHEN MATCHED THEN 
	                                                                            UPDATE SET [Description] = source.[Description],
			                                                                        UnitCost = source.UnitCost,
			                                                                        target.UoM = source.UoM
	                                                                        WHEN NOT MATCHED THEN INSERT (PartNumber,[Description],UoM,UnitCost) 
	                                                                            VALUES (source.Partnumber,source.[Description],source.UoM,source.UnitCost);") Then
                            Dim actualRows As Integer = SQL.Current.GetScalar("SELECT COUNT (*) FROM dbo.Sys_RawMaterial")
                            Dim loadedRows As Integer = actualRows - previousRows
                            SQL.Current.FillDataGrid(partNumbersDGV, "SELECT TOP 500 * FROM dbo.Sys_RawMaterial", True, False, False)
                            Me.Cursor = Nothing
                            MessageBox.Show(loadedRows.ToString() + " part numbers were loaded", "Done")
                        Else
                            Me.Cursor = Nothing
                            MessageBox.Show("Data bulk error")
                        End If
                    Else
                        Me.Cursor = Nothing
                        MessageBox.Show("Error reading file")
                    End If
                Else
                    Me.Cursor = Nothing
                    MessageBox.Show("Error downloading information")
                End If
            Else
                Me.Cursor = Nothing
                MessageBox.Show("No SAP session found")
            End If
        Else
            Me.Cursor = Nothing
            MessageBox.Show("Please enter a plant.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub PartNumbersAdministration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plants As ArrayList = SQL.Current.GetList("SELECT Plant FROM dbo.Sys_Plants")
        For Each item As String In plants
            plantCB.Items.Add(item)
        Next
        SQL.Current.FillDataGrid(partNumbersDGV, "SELECT TOP 500 * FROM dbo.Sys_RawMaterial", True, False, False)
        previousRows = SQL.Current.GetScalar("SELECT COUNT (*) FROM dbo.Sys_RawMaterial")
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        SQL.Current.FillDataGrid(partNumbersDGV, String.Format("SELECT TOP 500 * FROM dbo.Sys_RawMaterial WHERE PartNumber Like '%'+'{0}'+'%'", searchTB.Text), True, False, False)
    End Sub
End Class