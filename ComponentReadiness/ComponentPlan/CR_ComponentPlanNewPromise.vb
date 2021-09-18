Imports System.Runtime.InteropServices
Public Class CR_ComponentPlanNewPromise
    Public Property Partnumber As String
    Public Property Quantity As Decimal
    Public Property [Date] As Date
    Public Property MinDate As Date
    Public Property UoM As String
    Public Property Comment As String

    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Title_lbl.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub CR_ComponentPlanNewPromise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewQuantity_nud.Value = Me.Quantity
        Dim uoms As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT BuM FROM (SELECT BuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}' UNION ALL SELECT AuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}') AS Units ORDER BY BuM", Me.Partnumber))
        If Not uoms.Contains(Me.UoM) Then
            uoms.Add(Me.UoM)
        End If
        UoM_cbo.Items.AddRange(uoms.ToArray)
        UoM_cbo.SelectedItem = Me.UoM
        Date_dtp.MinDate = Me.MinDate.Date
        Title_lbl.Text = "Agregar Promesa " & Me.Partnumber
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        Me.Quantity = NewQuantity_nud.Value
        Me.UoM = UoM_cbo.SelectedItem
        Me.Date = Date_dtp.Value.Date
        Me.Comment = Comment_txt.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class