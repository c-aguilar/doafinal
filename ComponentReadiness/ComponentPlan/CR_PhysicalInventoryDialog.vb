Public Class CR_PhysicalInventoryDialog
    Public Property Partnumber As String
    Public Property Quantity As Decimal
    Public Property UoM As String
    Private Sub CR_PhysicalInventoryDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewQuantity_nud.Value = Me.Quantity
        Dim uoms As ArrayList = SQL.Current.GetList(String.Format("SELECT DISTINCT BuM FROM (SELECT BuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}' UNION ALL SELECT AuM FROM Sys_ConversionUnits WHERE Partnumber = '{0}') AS Units ORDER BY BuM", Me.Partnumber))
        If Not uoms.Contains(Me.UoM) Then
            uoms.Add(Me.UoM)
        End If
        UoM_cbo.Items.AddRange(uoms.ToArray)
        UoM_cbo.SelectedItem = Me.UoM
        Me.Title_lbl.Text = String.Format("Inventario Manual {0}", Me.Partnumber)
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If UoM_cbo.SelectedItem = "PC" Then
            Me.Quantity = Math.Round(NewQuantity_nud.Value, 0)
        Else
            Me.Quantity = NewQuantity_nud.Value
        End If
        Me.UoM = UoM_cbo.SelectedItem
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class