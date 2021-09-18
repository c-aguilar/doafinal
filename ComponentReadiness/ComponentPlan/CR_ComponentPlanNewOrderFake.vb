Public Class CR_ComponentPlanNewOrderFake
    Public Property Partnumber As String
    Public Property PickUpDate As Date
    Public Property Quantity As Decimal
    Public Property EditMode As Boolean = False
    Private Sub CR_ComponentPlanNewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Partnumber_lbl.Text = Me.Partnumber
        NewQuantity_nud.Value = Me.Quantity
        Date_dtp.MinDate = Delta.CurrentDate.Date
        Date_dtp.Value = Me.PickUpDate.Date
        If EditMode Then
            Me.Text = "Editar Schedule Line (Simulación)"
        Else
            Date_dtp.Enabled = False
            Me.Text = "Crear Schedule Line (Simulación)"
        End If
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If EditMode OrElse NewQuantity_nud.Value > 0 Then
            Me.PickUpDate = Date_dtp.Value.Date
            Me.Quantity = NewQuantity_nud.Value
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