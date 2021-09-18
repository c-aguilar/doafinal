Public Class Smk_TimeSusceptibleMaterial
    Dim selected_partnumbers As New List(Of String)
    Dim from_date, to_date As Date
    Private Sub Smk_PickUpMoverManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Partnumbers_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
    End Sub

    Private Sub LoadPartnumbers()
        from_date = From_dtp.Value
        to_date = To_dtp.Value
        Dim partnumbers As DataTable
        If selected_partnumbers.Count > 0 Then
            partnumbers = SQL.Current.GetDatatable(String.Format("SELECT DISTINCT R.Partnumber,R.MaterialType FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE R.Expirable = 1 AND R.Partnumber IN ('{0}') AND M.Quantity < 0 AND M.[Date] BETWEEN '{1} 00:00:01' AND '{2} 23:59:59' ORDER BY R.Partnumber;", String.Join("','", selected_partnumbers.ToArray), from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd")))
        ElseIf Partnumber_txt.Text.Trim = "" Or Partnumber_txt.Text.Trim = "*" Then
            partnumbers = SQL.Current.GetDatatable(String.Format("SELECT DISTINCT R.Partnumber,R.MaterialType FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE R.Expirable = 1 AND M.Quantity < 0 AND M.[Date] BETWEEN '{0} 00:00:01' AND '{1} 23:59:59' ORDER BY R.Partnumber;", from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd")))
        Else
            partnumbers = SQL.Current.GetDatatable(String.Format("SELECT DISTINCT R.Partnumber,R.MaterialType FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber WHERE R.Expirable = 1 AND R.Partnumber = '{0}' AND M.Quantity < 0 AND M.[Date] BETWEEN '{1} 00:00:01' AND '{2} 23:59:59' ORDER BY R.Partnumber;", Partnumber_txt.Text.Trim, from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd")))
        End If
        Partnumbers_dgv.DataSource = partnumbers
    End Sub


    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Partnumbers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Partnumbers_dgv.Columns("print_btn").Index Then
            Dim partnumber As String = Partnumbers_dgv.Rows(e.RowIndex).Cells("Partnumber").Value
            Dim materialtype As String = Partnumbers_dgv.Rows(e.RowIndex).Cells("MaterialType").Value
            Dim printing As New PDF
            With printing
                .Logo = New PDF.Logotype()
                .Logo.Image = My.Resources.APTIV
                .Logo.Alignment = CAguilar.PDF.Page.Align.Left
                .Logo.Format = System.Drawing.Imaging.ImageFormat.Png
                .Title = "Control de Material Sensitivo Susceptible al Tiempo"
                .TitleFontSize = 20
                .TitleAlign = PDF.Page.Align.Center
                .Subtitle = String.Format("NO. DE PARTE: {1}{0}DESCRIPCION:{2}", vbCrLf, partnumber, materialtype)
                .SubtitleAlign = PDF.Page.Align.Right
                .DataSource = SQL.Current.GetDatatable(String.Format("SELECT CONVERT(VARCHAR, S.[Date], 110) AS RECEPCION,CONVERT(VARCHAR, S.ExpirationDate, 110) AS CADUCIDAD,CONVERT(VARCHAR, DATEADD(MONTH,-1,S.ExpirationDate), 110) AS ROTACION,CONVERT(VARCHAR, M.[Date], 110) AS ENTREGA,S.Quantity AS ENTRADA,ABS(M.Quantity) AS SALIDA,dbo.Smk_SerialQuantityForDate(S.ID,M.[Date]) AS EXISTENCIA, S.SerialNumber AS OBSERVACIONES FROM Smk_SerialMovements AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID WHERE S.Partnumber = '{0}' AND M.Quantity < 0 AND M.[Date] BETWEEN '{1} 00:00:01' AND '{2} 23:59:59' ORDER BY M.[Date]; ", partnumber, from_date.ToString("yyyy-MM-dd"), to_date.ToString("yyyy-MM-dd")))
                .Footer = String.Format("EANW_5-1_PC_OM_02_10_F01_ES{0} Fecha Efectiva:22-Oct-09", vbCrLf)
                .FooterAlign = PDF.Page.Align.Left
                .PageNumber = True
                .PageNumberPosition = PDF.Page.Position.BottomRight
                .ColumnsWidths = {12, 12, 12, 12, 12, 12, 12, 16}
            End With
            Dim filename As String = GF.TempPDFPath
            If printing.Save(filename) Then
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                FlashAlerts.ShowError("Error al imprimir el reporte.")
            End If
        End If
    End Sub


    Private Sub Smk_PickUpMoverManual_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Items_btn_Click(sender As Object, e As EventArgs) Handles Items_btn.Click
        Dim ld As New ListDialog
        ld.Items.AddRange(selected_partnumbers)
        ld.Title = "Nos. de Parte"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            selected_partnumbers.Clear()
            For Each p In ld.Items
                If Not selected_partnumbers.Contains(RawMaterial.Format(p)) Then
                    selected_partnumbers.Add(RawMaterial.Format(p))
                End If
            Next
            If selected_partnumbers.Count > 0 Then
                Partnumber_txt.Text = String.Join(",", selected_partnumbers.ToArray)
                Partnumber_txt.Enabled = False
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Enabled = True
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadPartnumbers()
    End Sub
End Class