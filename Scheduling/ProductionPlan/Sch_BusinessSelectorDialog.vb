Public Class Sch_BusinessSelectorDialog
    Public Property Family As String
    Public Property Business As String

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        If Not cboFamily.SelectedItem = "" Then
            Me.Family = cboFamily.SelectedItem
            If Not cboBusiness.SelectedItem = "" Then
                Me.Business = cboBusiness.SelectedItem
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            cboFamily.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BusinessSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If User.Current.IsAdmin Then
            GF.FillCombobox(cboFamily, SQL.Current.GetDatatable("SELECT DISTINCT Family FROM Sch_Business AS B INNER JOIN Sch_MRPControllers AS M ON B.MRP = M.MRP ORDER BY Family"))
        Else
            GF.FillCombobox(cboFamily, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Family FROM Sch_Business AS B INNER JOIN Sch_MRPControllers AS M ON B.MRP = M.MRP WHERE M.Username = '{0}' ORDER BY Family", User.Current.Username)))
        End If
    End Sub

    Private Sub cboFamily_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFamily.SelectionChangeCommitted
        GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable({"Business"}, "Sch_Business", "Family", cboFamily.SelectedItem, {"Business"}))
    End Sub
End Class