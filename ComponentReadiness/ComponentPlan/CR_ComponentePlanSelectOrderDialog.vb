Public Class CR_ComponentePlanSelectOrderDialog
    Public Property Datasource As DataTable
    Public Property SelectedID As Integer
    Private Sub CR_ComponentePlanSelectOrderDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Orders_dgv.DataSource = Me.Datasource
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If Orders_dgv.SelectedRows.Count = 1 Then
            Me.SelectedID = Orders_dgv.SelectedRows.Item(0).Cells("Order_ID_col").Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()
    End Sub
End Class