Public Class VA32_DeliveryCorrection
    Dim materials_dt As New DataTable
    Private Sub VA32_DeliveryCorrection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        materials_dt.Columns.Add("Material")
        materials_dt.Columns.Add("Quantity", GetType(Integer))
        materials_dt.Columns.Add("Result")
        dgvMaterials.DataSource = materials_dt
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        Dim clipboard = DTable.clipboardExcelToDataTable(False)
        If clipboard IsNot Nothing Then
            'Prevent refresh
            dgvMaterials.DataSource = Nothing
            Dim error_counter As Integer = 0
            For Each c As DataRow In clipboard.Rows
                Try
                    materials_dt.Rows.Add(c.Item(0).ToString.Trim, CInt(c.Item(1)), "Waiting")
                Catch ex As Exception
                    error_counter += 1
                End Try
            Next
            dgvMaterials.DataSource = materials_dt
            If error_counter > 0 Then
                MsgBox(String.Format("{0} errores encontrados al pegar.", error_counter), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If txtShipTo.Text <> "" AndAlso txtDelivery.Text <> "" AndAlso materials_dt.Rows.Count > 0 AndAlso MessageBox.Show("¿Continuar con correccion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            LoadingScreen.Show()
            Dim sap As New SAP
            If sap.Available Then
                Dim materials As New ArrayList
                For Each r As DataRow In materials_dt.Rows
                    If Not materials.Contains(r.Item("Material")) Then
                        materials.Add(r.Item("Material"))
                    End If
                Next
                Dim filename As String = GF.TempTXTPath
                If sap.VL10(Parameter("SCH_ShippingPoint"), txtShipTo.Text, materials, filename) Then
                    Dim vl10_txt = CSV.Datatable(filename, vbTab, True, True, 0)
                    If vl10_txt IsNot Nothing Then
                        Dim vl10 = vl10_txt.DefaultView.ToTable(True, "Material", "OriginDoc.")
                        vl10.PrimaryKey = {vl10.Columns("Material")}
                        For Each m As DataRow In materials_dt.Rows
                            Dim od = vl10.Rows.Find(m.Item("Material"))
                            If od IsNot Nothing Then
                                If sap.VA32(od.Item("OriginDoc."), txtDelivery.Text, m.Item("Material"), m.Item("Quantity"), dtpDate.Value) Then
                                    m.Item("Result") = "OK - Corrected."
                                Else
                                    m.Item("Result") = "Error - Not corrected."
                                End If
                            Else
                                m.Item("Result") = "No Origin Document found."
                            End If
                        Next
                        LoadingScreen.Hide()
                        MsgBox("Finished!", MsgBoxStyle.Information)
                        btnRun.Enabled = False
                    Else
                        LoadingScreen.Hide()
                        MsgBox("Error on reading Origin Documents file.", MsgBoxStyle.Exclamation)
                    End If
                Else
                    LoadingScreen.Hide()
                    MsgBox("Error on getting Origin Documents.", MsgBoxStyle.Exclamation)
                End If
            Else
                LoadingScreen.Hide()
                MsgBox("SAP session not found.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub dgvMaterials_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMaterials.CellFormatting
        If e.ColumnIndex = 2 Then
            Select Case e.Value
                Case "Waiting"
                    e.CellStyle.BackColor = Color.LightGray
                Case "OK - Corrected."
                    e.CellStyle.BackColor = Color.LightGreen
                Case "Error - Not corrected.", "No Origin Document found."
                    e.CellStyle.BackColor = Color.LightCoral
            End Select
        End If
    End Sub

    Private Sub VA32_DeliveryCorrection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class