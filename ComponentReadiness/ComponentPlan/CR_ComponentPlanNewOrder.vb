Imports System.Runtime.InteropServices
Public Class CR_ComponentPlanNewOrder
    Public Property Partnumber As String
    Public Property PickUpDate As Date
    Public Property Quantity As Decimal
    Public Property TSA As String
    Public Property Item As String
    Public Property EditMode As Boolean = False

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

    Private Sub CR_ComponentPlanNewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewQuantity_nud.Value = Me.Quantity
        Date_dtp.MinDate = Delta.CurrentDate.Date
        Date_dtp.Value = Me.PickUpDate
        TSA_txt.Text = Me.TSA
        Item_txt.Text = Me.Item
        If EditMode Then
            Me.Title_lbl.Text = "Editar Schedule Line " & Me.Partnumber
            TSA_txt.ReadOnly = True
            Item_txt.ReadOnly = True
        Else
            Me.Title_lbl.Text = "Crear Schedule Line " & Me.Partnumber
        End If
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If (EditMode OrElse NewQuantity_nud.Value > 0) AndAlso TSA_txt.MaskCompleted AndAlso Item_txt.MaskCompleted Then
            Me.PickUpDate = Date_dtp.Value.Date
            Me.Quantity = NewQuantity_nud.Value
            Me.TSA = TSA_txt.Text
            Me.Item = Item_txt.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            FlashAlerts.ShowError("Falta información por agregar.")
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class