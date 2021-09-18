Imports System.Runtime.InteropServices
Public Class CR_HarnRequirementDetails
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, BoardTitle_lbl.MouseDown, DescriptionTitle_lbl.MouseDown, BusinessTitle_lbl.MouseDown, FamilyTitle_lbl.MouseDown, Board_lbl.MouseDown, Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Public Property Material As String
    Public Property DefaultLocation As Point
    Private Sub CR_HarnRequirementDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Material_lbl.Text = Me.Material
        Description_lbl.Text = SQL.Current.GetString("Description", "Sch_Materials", "Material", Me.Material, "")
        Business_lbl.Text = SQL.Current.GetString("Business", "Sch_Materials", "Material", Me.Material, "")
        Family_lbl.Text = SQL.Current.GetString("Family", "Sch_Business", "Business", Business_lbl.Text, "")
        Board_lbl.Text = String.Join(",", SQL.Current.GetList("Board", "Sch_MaterialBoards", {"Material", "Active"}, {Me.Material, 1}).ToArray)
        Me.Location = Me.DefaultLocation
    End Sub

    Private Sub CR_HarnRequirementDetails_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub

    Private Sub CR_HarnRequirementDetails_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class