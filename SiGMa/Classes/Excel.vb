Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports exc = Microsoft.Office.Interop.Excel

Public Class Excel
    Public Property PrintingDialog As Object
    Public Property MessageBoxButton As Object
    Dim range As exc.Range
    Dim oExcel As exc.Application = New exc.Application
    Dim oBook = oExcel.Workbooks.Add
    Dim oSheet As exc.Worksheet = oBook.Worksheets(1)

    Public Sub Export(datasource As DataTable, title As String, Optional colors As List(Of MyExcel.ColorRange) = Nothing)
        If datasource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        oSheet = oBook.ActiveSheet
                        Dim fileDate As String = DateTime.Now.ToString("MM-dd-yyyy")
                        Dim file As String = "SQA_Workload_" + fileDate
                        Dim ExportedFileName As String = file
                        oSheet.Name = ExportedFileName
                        Dim DataArray(datasource.Rows.Count - 1, datasource.Columns.Count - 1) As Object
                        For r = 0 To datasource.Rows.Count - 1
                            For c = 0 To datasource.Columns.Count - 1
                                DataArray(r, c) = datasource.Rows.Item(r).Item(c).ToString()
                            Next
                        Next
                        Dim columnTitles(datasource.Columns.Count - 1) As String
                        For c = 0 To datasource.Columns.Count - 1
                            columnTitles(c) = datasource.Columns(c).ColumnName
                        Next
                        oSheet.Range("A1").Resize(1, datasource.Columns.Count).Value = columnTitles
                        oSheet.Range("A2").Resize(datasource.Rows.Count, datasource.Columns.Count).Value = DataArray
                        oBook.SaveAs(ExportedFileName)
                        oExcel.Quit()
                        closeExcelFile()
                        open(ExportedFileName)
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(datasource, True) Then
                            MessageBox.Show(Me, "Exported", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            MessageBox.Show(Me, "The file could not be exported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        Dim fileDate As String = DateTime.Now.ToString("MM-dd-yyyy")
                        Dim file As String = "SQA_Workload_" + fileDate
                        Dim ExportedFileName As String = file
                        pdf.DataSource = datasource
                        pdf.Title = title
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = PDF.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = PDF.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            MessageBox.Show(Me, "Exported", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            MessageBox.Show(Me, "The file could not be exported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Public Sub ExportDiscrepancies(route As String, Optional datasourceMatWOasn As DataTable = Nothing, Optional datasourceIncomASN As DataTable = Nothing)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        'Dim range As Microsoft.Office.Interop.Excel.Range

        Dim fileDate As String = DateTime.Now.ToString("MM-dd-yyyy")
        Dim file As String = "Discrepancies_Route" + route + "_" + fileDate
        Dim ExportedFileName As String = file

        wBook = Excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        'If Not datasourceMatWOasn Is Nothing Then
        dset.Tables.Add(datasourceMatWOasn)
        dset.Tables(0).TableName = "MaterialWOasn"
        'End If
        'If Not datasourceIncomASN Is Nothing Then
        dset.Tables.Add(datasourceIncomASN)
        dset.Tables(1).TableName = "IncompleteASNs"
        'End If
        'Export dt
        Dim table As Integer = 0
        Dim dt As System.Data.DataTable
        For Each dataTable As DataTable In dset.Tables
            wSheet = wBook.ActiveSheet
            dt = dset.Tables(table)
            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                Excel.Cells(1, colIndex) = dc.ColumnName
            Next
            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    Excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next
            If table = 0 Then
                wBook.Sheets.Add(After:=wSheet)
            End If
            table += 1
        Next
        Dim sheet1 As Microsoft.Office.Interop.Excel.Worksheet = wBook.Sheets("Sheet1")
        sheet1.Name = "Material Without ASN"
        Dim sheet2 As Microsoft.Office.Interop.Excel.Worksheet = wBook.Sheets("Sheet2")
        sheet2.Name = "Incomplete ASNs"
        Try
            wBook.SaveAs(ExportedFileName, True)
        Catch ex As Exception
            MsgBox("Error a guardar el archivo. Revise la direccion", MsgBoxStyle.Exclamation, "Error")
            wSheet = Nothing
            wBook = Nothing
            Excel.Quit()
            Excel = Nothing
            GC.Collect()
            Exit Sub
        End Try

        Excel.Visible = True
        releaseObject(wSheet)
        releaseObject(wBook)
        releaseObject(Excel)

        GC.Collect()
    End Sub

    Public Sub Export(datasource As DataView, title As String, Optional colors As List(Of MyExcel.ColorRange) = Nothing)
        If datasource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                'LoadingScreen.Show()
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        oSheet = oBook.ActiveSheet
                        oSheet.Name = title
                        oBook.SaveAs(title)
                        oExcel.Quit()
                        closeExcelFile()
                        open(title)
                        'If MyExcel.SaveAs(datasource, Strings.Left(title, 30), False, colors) Then
                        '    'LoadingScreen.Hide()
                        '    FlashAlerts.ShowConfirm("Exportado.")
                        'Else
                        '    'LoadingScreen.Hide()
                        'End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(datasource.ToTable, True) Then
                            'LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            'LoadingScreen.Hide()
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = datasource.ToTable
                        pdf.Title = title
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = PDF.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = PDF.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            'LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            'LoadingScreen.Hide()
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Public Function Print(datasource As DataTable, area As String, title As String) As Boolean
        If datasource IsNot Nothing Then
            'Dim ed As New PrintingDialog
            'If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    'LoadingScreen.Show()
            '    Select Case ed.ChoosenFormat
            '        Case PrintingDialog.Format.Excel
            If MyExcel.Print(datasource.DefaultView.ToTable, False) Then ', Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
                'LoadingScreen.Hide()
                MessageBox.Show("Printed")
            Else
                MessageBox.Show("")
            End If
            'Case PrintingDialog.Format.PDF
            'Dim filename As String = title & "|" & Today.ToString("MM/dd/yyyy HH:mm") 'GF.TempPDFPath
            'Dim pdf As New PDF
            'pdf.Title = title
            'pdf.TitleFontSize = 14
            'pdf.Subtitle = area & "|" & Today.ToString("MM/dd/yyyy HH:mm")
            ''pdf.Footer = String.Format("{0} | {1}", title) ', Parameter("SYS_PlantCode")
            'pdf.PageNumber = True
            'pdf.Logo = New PDF.Logotype()
            ''pdf.Logo.Image = My.Resources.APTIV
            'pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            'pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            'pdf.DataSource = datasource
            'pdf.HeaderFontSize = 10
            'pdf.CellFontSize = 11

            'If pdf.Save(filename) Then
            '    'LoadingScreen.Hide()
            '    'Dim viewer As New PDFViewer
            '    'viewer.Filename = filename
            '    'viewer.ShowDialog()
            '    'viewer.Dispose()
            '    'TryDelete(filename)
            '    Return True
            'Else
            '    FlashAlerts.ShowError("Error al imprimir.")
            '    Return False
            'End If
            'End Select
        End If
        'End If
    End Function

#Region "Close excel process"
    Public Sub closeExcelFile()
        Try
            range = Nothing
            oSheet = Nothing
            oExcel.Workbooks.Close()
            oExcel.Quit()

            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            releaseObject(oSheet)
            releaseObject(oBook)
            releaseObject(oExcel)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "closeExcelFile")
        End Try
    End Sub

    Private Function releaseObject(obj As Object) As Integer
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
        Return 0
    End Function
#End Region

#Region "Open excel"
    Public Function open(bookName As String, Optional sheetName As String = "", Optional visible As Boolean = False) As Boolean
        Try
            Dim filepath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim file As String = filepath + "\" + bookName
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
            startInfo.FileName = "EXCEL.EXE"
            startInfo.Arguments = file
            Process.Start(startInfo)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excel open Error")
        End Try
    End Function
#End Region
End Class
