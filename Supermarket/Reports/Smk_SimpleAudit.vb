Public Class Smk_SimpleAudit
    Dim report As DataTable
    Private Sub Smk_SimpleAudit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If report IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(report, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(report, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = report
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        If report IsNot Nothing Then
            LoadingScreen.Show()
            Dim filename As String = GF.TempPDFPath
            Dim pdf As New PDF
            pdf.Title = String.Format("DEEDS Operaciones de Mexico.{0}Auditoria Diaria de Confiabilidad de Inventario.", vbCrLf)
            pdf.TitleFontSize = 14
            pdf.Subtitle = "Fecha: " & CurrentDate.ToString("MM/dd/yyyy HH:mm")
            pdf.Footer = String.Format("Auditado por: _______________ {0}Corregido por: _______________", vbCrLf)
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = report
            pdf.Orientation = CAguilar.PDF.Orientations.Landscape
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 12

            If pdf.Save(filename) Then
                LoadingScreen.Hide()
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                LoadingScreen.Hide()
                FlashAlerts.ShowError("Error al imprimir la auditoria.")
            End If
        End If
    End Sub
    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadingScreen.Show()
        Dim location_serial_filter As String

        If LocationA_txt.Text.Trim <> "" AndAlso LocationA_txt.Text.Trim <> "*" Then
            If Integer.TryParse(LocationA_txt.Text, Nothing) Then
                If LocationB_txt.Text <> "" Then
                    If Integer.TryParse(LocationB_txt.Text, Nothing) Then
                        location_serial_filter = String.Format("AND CONVERT(INTEGER, CASE WHEN Location NOT LIKE '%[^0-9]%' THEN Location  ELSE -1 END) BETWEEN {0} AND {1}", Strings.Left(LocationA_txt.Text.Trim & "00000000", 8), Strings.Left(LocationB_txt.Text.Trim & "99999999", 8))
                    Else
                        FlashAlerts.ShowError("Rango de locales incorrecto.")
                        Exit Sub
                    End If
                Else
                    location_serial_filter = String.Format("AND [Location] LIKE '{0}%'", LocationA_txt.Text.Trim)
                End If
            Else
                FlashAlerts.ShowError("Local incorrecto.")
                Exit Sub
            End If
        Else
            location_serial_filter = ""
        End If
        report = SQL.Current.GetDatatable(String.Format("SELECT [Location] AS Local,Warehousename AS Estacion,StatusDescription AS Estatus,Serialnumber,CurrentQuantity AS Cantidad,UoM AS Unidad,Partnumber AS [No. de Parte] FROM vw_Smk_Serials WHERE Status IN ('S','O','C','Q','T','U') AND InvoiceTrouble = 0 {0} ORDER BY [Location];", location_serial_filter))
        Report_dgv.DataSource = report
        LoadingScreen.Hide()
    End Sub

    Private Sub Smk_SimpleAudit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class