Imports System.Drawing
Imports System.Drawing.Drawing2D

Module Delta
    Public Server As String
    Public Instance As String
    Public Database As String
    Public UID As String
    Public Password As String

    Public Const APP As String = "Delta ERP"
    Public MainForm As Form
    Public W3D As New Simple3Des("delta_aguilar")
    Public GlobalProvider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Private Parameters As New Hashtable
    Private UserPhotos As New Hashtable
    Public Property SandBox As Boolean = False
    Public Chart_Helper As New System.Windows.Forms.DataVisualization.Charting.Chart
    Public CP_IND As Double = Delta.Chart_Helper.DataManipulator.Statistics.InverseNormalDistribution(0.95)
    Public FingerprintReader As DPUruNet.Reader
    Dim _start As DateTime

    Public Function CurrentDate() As Date
        'Return New Date(2019, 8, 1)
        Return Now()
    End Function

    Public Sub Log(description As String, key_word As String)
        SQL.Current.Insert("Sys_Log", {"[User]", "[Description]", "KeyWord"}, {User.Current.Username, Left(description, 100), Left(key_word, 50)})
    End Sub

    Public Sub Log(description As String, key_word As String, badge As String)
        SQL.Current.Insert("Sys_Log", {"[User]", "[Description]", "KeyWord"}, {badge, Left(description, 100), Left(key_word, 50)})
    End Sub

    Public Sub Log(description As String, key_word As String, user As User)
        SQL.Current.Insert("Sys_Log", {"[User]", "[Description]", "KeyWord"}, {user.Username, Left(description, 100), Left(key_word, 50)})
    End Sub

    Public Sub Alert([to] As String, description As String)
        SQL.Current.Insert("Sys_UserAlerts", {"Username", "[To]", "[Description]"}, {User.Current.Username, [to], description})
    End Sub

    Public Sub Alert([from] As String, [to] As String, description As String)
        SQL.Current.Insert("Sys_UserAlerts", {"Username", "[To]", "[Description]"}, {[from], [to], description})
    End Sub

    Public Function SaveTXT(text As String) As Boolean
        Dim dialog As New SaveFileDialog
        dialog.Filter = "Text Documents (*.txt)|*.txt"
        dialog.Title = "Save as..."
        If dialog.ShowDialog = DialogResult.OK Then
            Using writer As New IO.StreamWriter(dialog.FileName, False, System.Text.Encoding.UTF8)
                For Each line In text.Split(Environment.NewLine)
                    writer.WriteLine(line)
                Next
                writer.Flush()
                writer.Close()
            End Using
            Return True
        End If
        Return False
    End Function

    Public Function SaveTXT(text As String()) As Boolean
        Dim dialog As New SaveFileDialog
        dialog.Filter = "Text Documents (*.txt)|*.txt"
        dialog.Title = "Save as..."
        If dialog.ShowDialog = DialogResult.OK Then
            Using writer As New IO.StreamWriter(dialog.FileName, False, System.Text.Encoding.UTF8)
                For Each line In text
                    writer.WriteLine(line)
                Next
                writer.Flush()
                writer.Close()
            End Using
            Return True
        End If
        Return False
    End Function

    Public Function Parameter(parameter_name As String, Optional [default] As String = "", Optional force_updating As Boolean = False) As String
        If Not force_updating AndAlso Parameters.ContainsKey(parameter_name) Then
            Return Parameters(parameter_name)
        Else
            If Parameters.ContainsKey(parameter_name) Then Parameters.Remove(parameter_name)
            Parameters.Add(parameter_name, SQL.Current.GetString("Value", "Sys_Parameters", "Parameter", parameter_name, [default]))
            Return Parameters(parameter_name)
        End If
    End Function

    Public Sub SendToPrinter(filename As String)
        Dim info As New ProcessStartInfo
        info.Verb = "print"
        info.FileName = filename
        info.CreateNoWindow = True
        info.WindowStyle = ProcessWindowStyle.Hidden

        Dim p As New Process
        p.StartInfo = info
        p.Start()

        p.WaitForInputIdle()
        System.Threading.Thread.Sleep(3000)
        If Not p.CloseMainWindow() Then
            p.Kill()
        End If
    End Sub

    Public Sub TryDelete(file As String)
        For i = 0 To 2
            Try
                If IO.File.Exists(file) Then
                    IO.File.Delete(file)
                End If
            Catch ex As Exception

            End Try
            Application.DoEvents()
        Next
    End Sub

    Public Function WorkDay(ByVal [date] As Date, ByVal days As Integer) As Date
        While days > 0
            [date] = [date].AddDays(1)
            Select Case [date].DayOfWeek
                Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                    days -= 1
            End Select
        End While
        Return [date]
    End Function

    Public Function BackWorkDay(ByVal [date] As Date, ByVal days As Integer) As Date
        While days > 0
            [date] = [date].AddDays(-1)
            Select Case [date].DayOfWeek
                Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                    days -= 1
            End Select
        End While
        Return [date]
    End Function

    Public Function NextSaturday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbSaturday Then
            [date] = [date].AddDays(vbSaturday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date]
    End Function

    Public Function NextSunday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbSunday Then
            [date] = [date].AddDays(vbSaturday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date]
    End Function

    Public Function NextMonday() As Date
        Dim d As Date = CurrentDate()
        If Not DatePart(DateInterval.Weekday, d) = vbMonday Then
            d = d.AddDays(vbMonday - DatePart(DateInterval.Weekday, d))
        End If
        Return d.AddDays(7)
    End Function

    Public Function NextMonday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbMonday Then
            [date] = [date].AddDays(vbMonday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date].AddDays(7)
    End Function
    Public Function LastMonday() As Date
        Dim d As Date = CurrentDate()
        If Not DatePart(DateInterval.Weekday, d) = vbMonday Then
            d = d.AddDays(vbMonday - DatePart(DateInterval.Weekday, d))
        End If
        Return d
    End Function

    Public Function LastMonday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbMonday Then
            [date] = [date].AddDays(vbMonday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date]
    End Function

    Public Function LastSaturday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbSaturday Then
            [date] = [date].AddDays(vbSaturday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date]
    End Function

    Public Function LastSunday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbSunday Then
            [date] = [date].AddDays(vbSunday - DatePart(DateInterval.Weekday, [date]))
        End If
        Return [date]
    End Function

    Public Function LastSunday() As Date
        Dim d As Date = CurrentDate()
        If Not DatePart(DateInterval.Weekday, d) = vbSunday Then
            d = d.AddDays(vbSunday - DatePart(DateInterval.Weekday, d))
        End If
        Return d
    End Function

    Public Function GetUserPhoto(badge As String) As Image
        If UserPhotos.ContainsKey(badge) Then
            Return UserPhotos(badge)
        Else
            UserPhotos.Add(badge, SQL.Current.GetImage("Picture", "Sys_UserPhotos", "Badge", badge, My.Resources.No_image_available))
            Return UserPhotos(badge)
        End If
    End Function

    Public Function SaveUserPhoto(badge As String, picture As Image) As Boolean
        Try
            Dim streamMini = New System.IO.MemoryStream()
            Dim pic_mini = ResizeImage(picture, New Size(150, 200), False)
            pic_mini.Save(streamMini, System.Drawing.Imaging.ImageFormat.Png)
            streamMini.Position = 0
            Dim mini() As Byte = streamMini.GetBuffer
            SQL.Current.Delete("Sys_UserPhotos", "Badge", badge)
            SQL.Current.Insert("Sys_UserPhotos", {"Badge", "Picture"}, {badge, mini})
            UserPhotos(badge) = pic_mini
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Public Function NullReplace(ByVal value As Object, ByVal replacement As Object) As Object
        If IsNothing(value) OrElse IsDBNull(value) OrElse String.Empty = value.ToString Then
            Return replacement
        Else
            Return value
        End If
    End Function

    Public Function NullReplace(ByVal value As Object, ByVal replacement As Integer) As Integer
        If IsNothing(value) OrElse IsDBNull(value) OrElse String.Empty = value.ToString Then
            Return replacement
        Else
            Return value
        End If
    End Function

    Public Function NullReplace(ByVal value As Object, ByVal replacement As Decimal) As Decimal
        If IsNothing(value) OrElse IsDBNull(value) Then
            Return replacement
        Else
            Return value
        End If
    End Function

    Public Function NullReplace(ByVal value As Object, ByVal replacement As String) As String
        If IsNothing(value) OrElse IsDBNull(value) OrElse String.Empty = value.ToString Then
            Return replacement
        Else
            Return value
        End If
    End Function

    Public Function Between([date] As Date, [from] As Date, [to] As Date) As Boolean
        Return [date].Date >= [from].Date AndAlso [date].Date <= [to].Date
    End Function

    
    

    Public Function CurrentShift() As String
        CurrentShift = SQL.Current.GetString("SELECT dbo.Sys_Shift(GETDATE());")
    End Function

    Public Function IsValidID(id As String, lenght As Integer) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(id, "^[A-Za-z0-9]{" & lenght & "}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function

    Public Sub ShowPopup(datasource As DataTable, title As String, width As Single, height As Single, location As Point, Optional format_list As String(,) = Nothing)
        Dim popup As New PopupReport
        popup.Size = New Size(width, height)
        popup.Datasource = datasource
        popup.Title = title
        popup.StartLocation = location
        popup.Formats = format_list
        popup.Show()
    End Sub

    Public Function GetFromPopup(datasource As DataTable, title As String, width As Single, height As Single, location As Point, Optional format_list As String(,) = Nothing) As DataRowView
        Dim popup As New PopupReport
        popup.Size = New Size(width, height)
        popup.Datasource = datasource
        popup.Title = title
        popup.StartLocation = location
        popup.Formats = format_list
        popup.ReturnDataRow = True
        popup.DisposeOnClosing = False
        popup.ShowDialog()
        GetFromPopup = popup.DataRowView
        popup.Dispose()
    End Function

    Public Sub Export(datasource As DataTable, title As String, Optional colors As List(Of MyExcel.ColorRange) = Nothing)
        If datasource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadingScreen.Show()
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(datasource, Strings.Left(title, 30), False, , colors) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(datasource, True) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = datasource
                        pdf.Title = title
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Public Sub Export(datasource As DataView, title As String, Optional colors As List(Of MyExcel.ColorRange) = Nothing)
        If datasource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadingScreen.Show()
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(datasource, Strings.Left(title, 30), False, , colors) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(datasource.ToTable, True) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = datasource.ToTable
                        pdf.Title = title
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Exportado.")
                        Else
                            LoadingScreen.Hide()
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Public Sub Print(datasource As DataTable, area As String, title As String)
        If datasource IsNot Nothing Then
            Dim ed As New PrintingDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadingScreen.Show()
                Select Case ed.ChoosenFormat
                    Case PrintingDialog.Format.Excel
                        If MyExcel.Print(datasource.DefaultView.ToTable, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
                            LoadingScreen.Hide()
                            FlashAlerts.ShowConfirm("Impreso.")
                        End If
                    Case PrintingDialog.Format.PDF
                        Dim filename As String = GF.TempPDFPath
                        Dim pdf As New PDF
                        pdf.Title = title
                        pdf.TitleFontSize = 14
                        pdf.Subtitle = area & "|" & Delta.CurrentDate.ToString("MM/dd/yyyy HH:mm")
                        pdf.Footer = String.Format("{0} | {1}", title, Parameter("SYS_PlantCode"))
                        pdf.PageNumber = True
                        pdf.Logo = New PDF.Logotype()
                        pdf.Logo.Image = My.Resources.APTIV
                        pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
                        pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
                        pdf.DataSource = datasource
                        pdf.HeaderFontSize = 10
                        pdf.CellFontSize = 11

                        If pdf.Save(filename) Then
                            LoadingScreen.Hide()
                            Dim viewer As New PDFViewer
                            viewer.Filename = filename
                            viewer.ShowDialog()
                            viewer.Dispose()
                            TryDelete(filename)
                        Else
                            FlashAlerts.ShowError("Error al imprimir.")
                        End If
                End Select
            End If
        End If
    End Sub

    Public Sub SetDataGridViewDeltaStyle(ByRef datagridview As CAguilar.DataGridViewWithFilters)
        'With datagridview
        '    With .ColumnHeadersDefaultCellStyle
        '        .BackColor = Color.FromArgb(64, 64, 64)
        '        .ForeColor = Color.White
        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
        '        .WrapMode = DataGridViewTriState.True
        '        .Font = New Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular)
        '    End With
        '    .ColumnHeadersHeight = 33
        '    .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        '    .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        '    .RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        '    .EnableHeadersVisualStyles = False
        'End With
    End Sub
End Module
