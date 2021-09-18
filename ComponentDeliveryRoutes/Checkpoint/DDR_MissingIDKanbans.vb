Public Class DDR_MissingIDKanbans
    Public Property ID_Loop As Integer
    Dim data As DataTable
    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub

    Public Sub RefreshData()
        Missings_dgv.DataSource = Nothing
        data = SQL.Current.GetDatatable(String.Format("SELECT Kanban, S.Partnumber AS [No. de Parte], R.[Description] AS Descripcion,MAX(M.ID) AS MovementID FROM DDR_CartsLoopKanbans AS K INNER JOIN Smk_DDRSerialDiscount AS D ON K.ID = D.KanbanLoopID INNER JOIN Smk_SerialMovements AS M ON D.SerialMovementID = M.ID INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID INNER JOIN Sys_RawMaterial AS R ON S.Partnumber = R.Partnumber LEFT OUTER JOIN CDR_Kanbans AS CK ON K.Kanban = CK.ID WHERE LoopID = {0} AND (CK.Pieces IS NULL OR CK.Pieces <= 1) GROUP BY Kanban, S.Partnumber, R.[Description]", ID_Loop))
        data.PrimaryKey = {data.Columns("Kanban")}
        If data.Rows.Count = 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Missings_dgv.DataSource = data.DefaultView.ToTable("data", True, "Kanban", "No. de Parte", "Descripcion")
        End If
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If CDR.IsKanban(Kanban_txt.Text) AndAlso data.Rows.Find(CDR.KanbanID(Kanban_txt.Text)) IsNot Nothing Then
            Dim row As DataRow = data.Rows.Find(CDR.KanbanID(Kanban_txt.Text))
            If row IsNot Nothing Then
                Dim adk As New DDR_AddMissingKanban
                adk.Partnumber = row.Item("No. de Parte")
                adk.ID_Kanban = row.Item("Kanban")
                adk.ID_Movement = row.Item("MovementID")
                If adk.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    FlashAlerts.ShowConfirm("Kanban Actualizada.")
                    RefreshData()
                Else
                    FlashAlerts.ShowError("Proceso Cancelado.")
                End If
                adk.Dispose()
                Kanban_txt.Clear()
                Kanban_txt.Focus()
            Else
                Kanban_txt.Clear()
                Kanban_txt.Focus()
                FlashAlerts.ShowError("Kanban incorrecta.")
            End If
        Else
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            FlashAlerts.ShowError("Kanban incorrecta.")
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DDR_MissingIDKanbans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
        Kanban_txt.Focus()
    End Sub
End Class