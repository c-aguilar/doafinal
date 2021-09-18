Imports System.Runtime.InteropServices
Public Class PopupReport
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Public Property Datasource As DataTable
    Public Property Title As String
    Public Property StartLocation As Point
    Public Property Formats As String(,)
    Public Property DisposeOnClosing As Boolean = True
    Public Property ReturnDataRow As Boolean = False
    Public Property DataRowView As DataRowView = Nothing
    Dim is_exporting As Boolean = False

    Const WM_NCHITTEST As Integer = &H84
    Const HTBOTTOMRIGHT As Integer = 17
    Const HTBOTTOM As Integer = 15
    Const HTRIGHT As Integer = 11
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14


    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    Select Case m.Msg
    '        Case WM_NCHITTEST
    '            Dim loc As New Point(m.LParam.ToInt32 And &HFFFF, m.LParam.ToInt32 >> 16)
    '            loc = PointToClient(loc)
    '            Dim blnRight As Boolean = (loc.X > Width - 9)
    '            Dim blnBottom As Boolean = (loc.Y > Height - 9)
    '            If blnRight And blnBottom Then
    '                m.Result = CType(HTBOTTOMRIGHT, IntPtr)
    '                Return
    '            ElseIf blnRight Then
    '                m.Result = CType(HTRIGHT, IntPtr)
    '                Return
    '            ElseIf blnBottom Then
    '                m.Result = CType(HTBOTTOM, IntPtr)
    '                Return
    '            End If
    '    End Select
    '    MyBase.WndProc(m)
    'End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStripMain.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        resizeDir = ResizeDirection.None
    End Sub

    Private Sub PopupReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = Me.Title
        Report_dgv.DataSource = Me.Datasource
        Me.Location = Me.StartLocation
        If Formats IsNot Nothing Then
            For i = 0 To (Formats.Length - 1) / 2
                Report_dgv.Columns(Formats(i, 0)).DefaultCellStyle.Format = Formats(i, 1)
            Next
        End If
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        is_exporting = True
        Delta.Export(Me.Datasource, Me.Datasource.TableName)
        is_exporting = False
    End Sub

    Private Sub Smk_SerialMovements_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If Not Report_dgv.FilterDisplayed AndAlso Not is_exporting Then Me.Close()
    End Sub

    Private Sub Smk_SerialMovements_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DisposeOnClosing Then Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        Report_dgv.SelectAll()
        Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = Report_dgv.GetClipboardContent()
        Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub

    Private Sub Report_dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Report_dgv.CellContentDoubleClick
        If ReturnDataRow AndAlso e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            Me.DataRowView = Report_dgv.Rows(e.RowIndex).DataBoundItem
            Me.Close()
        End If
    End Sub

    Private Const BorderWidth As Integer = 6
    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    Public Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value
            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Me.Cursor = Cursors.SizeWE
                Case ResizeDirection.Right
                    Me.Cursor = Cursors.SizeWE
                Case ResizeDirection.Top
                    Me.Cursor = Cursors.SizeNS
                Case ResizeDirection.Bottom
                    Me.Cursor = Cursors.SizeNS
                Case ResizeDirection.BottomLeft
                    Me.Cursor = Cursors.SizeNESW
                Case ResizeDirection.TopRight
                    Me.Cursor = Cursors.SizeNESW
                Case ResizeDirection.BottomRight
                    Me.Cursor = Cursors.SizeNWSE
                Case ResizeDirection.TopLeft
                    Me.Cursor = Cursors.SizeNWSE
                Case Else
                    Me.Cursor = Cursors.Default
            End Select
        End Set
    End Property

    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        Dim dir As Integer = -1
        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select
        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
        End If
    End Sub

    Private Sub PopupReport_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Location.X < BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopLeft
        ElseIf e.Location.X < BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomLeft
        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomRight
        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopRight
        ElseIf e.Location.X < BorderWidth Then
            resizeDir = ResizeDirection.Left
        ElseIf e.Location.X > Me.Width - BorderWidth Then
            resizeDir = ResizeDirection.Right
        ElseIf e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.Top
        ElseIf e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.Bottom
        Else
            resizeDir = ResizeDirection.None
        End If
    End Sub

    Private Sub Resize_pb_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            ResizeForm(resizeDir)
        End If
    End Sub

    Private Sub Report_dgv_MouseMove(sender As Object, e As MouseEventArgs) Handles Report_dgv.MouseMove
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMain_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStripMain.MouseMove
        Me.Cursor = Cursors.Default
    End Sub
End Class