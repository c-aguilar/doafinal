Imports System.Runtime.InteropServices
Public Class Sch_LevelScheduleBOMVariation
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function
    Public Property Datasource As DataTable
    Public Property DefaultLocation As Point
    Public Property Title As String
    Private Sub Sch_LevelScheduleBOMVariation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = Me.Title
        Differences_dgv.DataSource = Me.Datasource
        Me.Location = Me.DefaultLocation
    End Sub

    Private Sub Sch_LevelScheduleBOMVariation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Differences_dgv.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Sch_LevelScheduleBOMVariation_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If Not Differences_dgv.FilterDisplayed Then Me.Close()
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStripMain.MouseDown, Title_lbl.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Copy_btn_Click(sender As Object, e As EventArgs) Handles Copy_btn.Click
        Differences_dgv.SelectAll()
        Differences_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Dim data_o As DataObject = Differences_dgv.GetClipboardContent()
        Differences_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Clipboard.SetDataObject(data_o, True)
    End Sub
End Class