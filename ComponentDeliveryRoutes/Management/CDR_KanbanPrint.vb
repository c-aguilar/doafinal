Imports CAguilar
Public Class CDR_KanbanPrint
    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable("SELECT DISTINCT Business FROM CDR_Kanbans ORDER BY Business"))
    End Sub

    Private Sub cboBusiness_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBusiness.SelectionChangeCommitted
        GF.FillCombobox(cboBoard, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Board FROM CDR_Kanbans WHERE Business='{0}' AND Active = 1 ORDER BY Board", cboBusiness.SelectedItem)))
    End Sub

    Private Sub cboBoard_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBoard.SelectionChangeCommitted
        GF.FillCombobox(cboKit, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Kit FROM CDR_Kanbans WHERE Board='{0}'  AND Active = 1 ORDER BY Kit", cboBoard.SelectedItem)))
    End Sub

    Private Sub btnPrintAll_Click(sender As Object, e As EventArgs) Handles btnPrintAll.Click
        If cboKit.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE Business = '{0}' AND Board = '{1}' AND Kit = '{2}' AND ID NOT IN(936248,936249,936250,936251,936252,936253,936254,936255,936256,936257,936258,936259,936260,936261,936262,936263,936264,936265,936266,936267,936268,936269,936270,936271,936272,936273,936274,936275,936276,936277,936278,936279,936280,936281,936282,936283,936284,936285,936286,936287,936288,936289,936290,936291,936292,936293,936294,936295,936296,936297,936298,936299,936300,936301,936302,936303,936621) AND Active = 1 ORDER BY EngLoc ASC,Partnumber, [Index] ASC", cboBusiness.SelectedItem, cboBoard.SelectedItem, cboKit.SelectedItem)), chkBusinessDouble.Checked)
        ElseIf cboBoard.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE Business = '{0}' AND Board = '{1}' AND Active = 1 AND ID NOT IN(936248,936249,936250,936251,936252,936253,936254,936255,936256,936257,936258,936259,936260,936261,936262,936263,936264,936265,936266,936267,936268,936269,936270,936271,936272,936273,936274,936275,936276,936277,936278,936279,936280,936281,936282,936283,936284,936285,936286,936287,936288,936289,936290,936291,936292,936293,936294,936295,936296,936297,936298,936299,936300,936301,936302,936303,936621) ORDER BY Kit ASC, EngLoc ASC,Partnumber, [Index] ASC", cboBusiness.SelectedItem, cboBoard.SelectedItem)), chkBusinessDouble.Checked)
        ElseIf cboBusiness.SelectedIndex > -1 Then
            CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE Business = '{0}'  AND Active = 1 ORDER BY Kit ASC, EngLoc ASC,Partnumber, [Index] ASC", cboBusiness.SelectedItem)), chkBusinessDouble.Checked)
        End If
    End Sub

    Private Sub btnPrintID_Click(sender As Object, e As EventArgs) Handles btnPrintID.Click
        If CDR.IsKanban(txtID.Text) Then CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE K.ID = '{0}'", CDR.KanbanID(txtID.Text))), chkIDDouble.Checked)
    End Sub

    Private Sub btnPrintPartnumber_Click(sender As Object, e As EventArgs) Handles btnPrintPartnumber.Click
        If txtPartnumber.Text <> "" Then CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE K.Partnumber = '{0}'  AND Active = 1 ORDER BY Business ASC, Kit ASC, EngLoc ASC, [Index] ASC", txtPartnumber.Text)), chkPartnumberDouble.Checked)
    End Sub

    Private Sub btnPrintComment_Click(sender As Object, e As EventArgs) Handles btnPrintComment.Click
        If txtComment.Text <> "" Then CDR.Print(SQL.Current.GetDatatable(String.Format("SELECT [ID],[Partnumber],[Board],K.[Description],[Kit],[EngLoc],[Slot],[Side],[Section],R.[Description] AS [Route],[Pieces],[Container],[Index],[Business],[Requirement],[2h],[Quantity],[Frequency],[Hrs],[Comment],[Rack],[Local],[Date],[Code] FROM CDR_Kanbans AS K LEFT OUTER JOIN CDR_Routes AS R ON K.[Route] = R.[Route] WHERE K.Comment = '{0}'  AND Active = 1 ORDER BY ID", txtComment.Text.Trim)), chkComment.Checked)
    End Sub

    Private Sub CDR_KanbanPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class