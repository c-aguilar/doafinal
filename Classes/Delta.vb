Imports System.Drawing
Imports System.Drawing.Drawing2D
Module Delta
    Public Const APP As String = "Delta ERP"
    Public MainForm As Form
    Public W3D As New Simple3Des("delta_aguilar")
    Public GlobalProvider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Private Parameters As New Hashtable
    Private UserPhotos As New Hashtable

    Dim _start As DateTime


    Public Function CurrentDate() As Date
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
        Dim conn As New SQL(SQL.Current.ConnectionString)
        conn.Insert("Sys_UserAlerts", {"Username", "[To]", "[Description]"}, {User.Current.Username, [to], description})
        conn = Nothing
    End Sub

    Public Sub Alert([from] As String, [to] As String, description As String)
        Dim conn As New SQL(SQL.Current.ConnectionString)
        conn.Insert("Sys_UserAlerts", {"Username", "[To]", "[Description]"}, {[from], [to], description})
        conn = Nothing
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

    Public Function Parameter(parameter_name As String, Optional [default] As String = "") As String
        If Parameters.ContainsKey(parameter_name) Then
            Return Parameters(parameter_name)
        Else
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

    Public Function NextSaturday([date] As Date) As Date
        If Not DatePart(DateInterval.Weekday, [date]) = vbSaturday Then
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
        If IsDBNull(value) Then
            Return replacement
        Else
            Return value
        End If
    End Function
End Module
