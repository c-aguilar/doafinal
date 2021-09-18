Imports CAguilar
Public Class CDR_KanbanPrint
    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable("SELECT DISTINCT Business FROM CDR_Kanbans ORDER BY Business"))
    End Sub

    Private Sub cboBusiness_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBusiness.SelectionChangeCommitted
        GF.FillCombobox(cboBoard, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Board FROM CDR_Kanbans WHERE Business='{0}' ORDER BY Board", cboBusiness.SelectedItem)))
    End Sub

    Private Sub cboBoard_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBoard.SelectionChangeCommitted
        GF.FillCombobox(cboKit, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Kit FROM CDR_Kanbans WHERE Board='{0}' ORDER BY Kit", cboBoard.SelectedItem)))
    End Sub

    Private Sub btnPrintAll_Click(sender As Object, e As EventArgs) Handles btnPrintAll.Click
        If cboKit.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"Business", "Board", "Kit"}, {cboBusiness.SelectedItem, cboBoard.SelectedItem, cboKit.SelectedItem}, {"EngLoc ASC", "[Index] ASC"}), chkBusinessDouble.Checked)
        ElseIf cboBoard.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"Business", "Board"}, {cboBusiness.SelectedItem, cboBoard.SelectedItem}, {"Kit ASC", "EngLoc ASC", "[Index] ASC"}), chkBusinessDouble.Checked)
        ElseIf cboBusiness.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"Business"}, {cboBusiness.SelectedItem}, {"Board ASC", "Kit ASC", "EngLoc ASC", "[Index] ASC"}), chkBusinessDouble.Checked)
        End If
    End Sub

    Private Sub btnPrintID_Click(sender As Object, e As EventArgs) Handles btnPrintID.Click
        If CDR.IsKanban(txtID.Text) Then CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"ID"}, {CDR.KanbanID(txtID.Text)}), chkIDDouble.Checked)
    End Sub

    Private Sub btnPrintPartnumber_Click(sender As Object, e As EventArgs) Handles btnPrintPartnumber.Click
        If txtPartnumber.Text <> "" Then CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"Partnumber"}, {txtPartnumber.Text}, {"Business ASC", "Kit ASC", "EngLoc ASC", "[Index] ASC"}), chkPartnumberDouble.Checked)
    End Sub

    Private Sub btnPrintComment_Click(sender As Object, e As EventArgs) Handles btnPrintComment.Click
        If txtComment.Text <> "" Then CDR.Print(SQL.Current.GetDatatable("CDR_Kanbans", {"Comment"}, {txtComment.Text.Trim}, {"ID ASC"}), chkComment.Checked)
    End Sub

    Private Sub CDR_KanbanPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class