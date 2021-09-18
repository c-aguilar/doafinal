Public Class CDR_KanbansManagement
    Dim current_board As String = ""
    Dim current_business As String = ""
    Dim recalculating As Boolean = False
    Dim kanbans As New Dictionary(Of Integer, CDR.Kanban)
    Private Sub CDR_KanbansManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable("SELECT DISTINCT Business FROM Sch_Business ORDER BY Business"), "Business", "Business")
    End Sub

    Private Sub cboBusiness_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBusiness.SelectionChangeCommitted
        GF.FillCombobox(cboBoard, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Board FROM Mfg_Boards WHERE Business='{0}' ORDER BY Board", cboBusiness.SelectedValue), "Board", "Board"))
        cboBoard.SelectedIndex = -1
    End Sub

    Private Sub Show_btn_Click(sender As Object, e As EventArgs) Handles Show_btn.Click
        current_business = ""
        current_board = ""
        recalculating = False
        If cboBusiness.SelectedIndex > -1 Then
            Kanbans_dgv.Rows.Clear()
            Kanbans_dgv.Columns("Kanben_NewRoute_col").Visible = False
            Kanbans_dgv.Columns("Kanban_NewSupermarketLocation_col").Visible = False
            Kanbans_dgv.Columns("Kanban_NewContainer_col").Visible = False
            Kanbans_dgv.Columns("Kanban_NewPieces_col").Visible = False
            Kanbans_dgv.Columns("Kanban_Update_chk").Visible = False
            kanbans.Clear()
            current_business = cboBusiness.SelectedValue
            Dim kanbans_dt As DataTable
            If cboBoard.SelectedIndex > -1 Then
                current_board = cboBoard.SelectedValue
                kanbans_dt = SQL.Current.GetDatatable("SELECT [ID],[Code],[Partnumber],[Business],[Board],[Kit],[EngineeringLocation],[Slot],[Side],[Section],[Route],[Pieces],[Container],[Index],[SupermarketLocation],[Date],[Comment] FROM CDR2_Kanbans WHERE Business = '{0}' AND Board = '{1}' AND [Active] = 1", current_business, current_board)
            Else
                kanbans_dt = SQL.Current.GetDatatable("SELECT [ID],[Code],[Partnumber],[Business],[Board],[Kit],[EngineeringLocation],[Slot],[Side],[Section],[Route],[Pieces],[Container],[Index],[SupermarketLocation],[Date],[Comment] FROM CDR2_Kanbans WHERE Business = '{0}' AND [Active] = 1", current_business)
            End If
            For Each row As DataRow In kanbans_dt.Rows
                kanbans.Add(row.Item("ID"), New CDR.Kanban(row.Item("ID"), NullReplace(row.Item("Code"), ""), NullReplace(row.Item("Partnumber"), ""), NullReplace(row.Item("Business"), ""), NullReplace(row.Item("Board"), ""), NullReplace(row.Item("Kit"), ""), NullReplace(row.Item("EngineeringLocation"), ""), NullReplace(row.Item("Slot"), ""), NullReplace(row.Item("Side"), ""), NullReplace(row.Item("Section"), ""), NullReplace(row.Item("Route"), ""), NullReplace(row.Item("Pieces"), ""), NullReplace(row.Item("Container"), ""), NullReplace(row.Item("Index"), ""), NullReplace(row.Item("SupermarketLocation"), ""), NullReplace(row.Item("Date"), ""), NullReplace(row.Item("Generic"), ""), NullReplace(row.Item("Comment"), "")))
            Next
            For Each i In kanbans
                With i.Value
                    Kanbans_dgv.Rows.Add(.ID, .Code, .Partnumber, .Business, .Board, .Kit, .EngineeringLocation, .Slot, .Side, .Section, .Route, .SupermarketLocation, .Container, .Pieces, .Index, .Date, .Comment)
                End With
            Next
        End If
    End Sub

    Private Sub Kanbans_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Kanbans_dgv.CellFormatting
        If recalculating Then

        End If
    End Sub

    Private Sub btnRecalculate_Click(sender As Object, e As EventArgs) Handles btnRecalculate.Click
        If kanbans.Count > 0 Then
            LoadingScreen.Show()
            recalculating = True
            Kanbans_dgv.Columns("Kanben_NewRoute_col").Visible = True
            Kanbans_dgv.Columns("Kanban_NewSupermarketLocation_col").Visible = True
            Kanbans_dgv.Columns("Kanban_NewContainer_col").Visible = True
            Kanbans_dgv.Columns("Kanban_NewPieces_col").Visible = True
            Kanbans_dgv.Columns("Kanban_Update_chk").Visible = True

            Dim kanbans_dt As DataTable
            If cboBoard.SelectedIndex > -1 Then
                If chkBoth.Checked Then
                    If chkKeepContainer.Checked Then
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, Container AS New_Container, Pieces AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE M.Business = '{0}' AND E.Board = '{1}' AND K.[Active] = 1", current_business, current_board)
                    Else
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, dbo.CDR_RightContainer(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0)) AS New_Container, dbo.CDR_ContainerQuantity(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0))) AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE Business = '{0}' AND Board = '{1}' AND [Active] = 1", current_business, current_board)
                    End If
                Else
                    If chkKeepContainer.Checked Then
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, Container AS New_Container, Pieces AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE Business = '{0}' AND Board = '{1}' AND [Active] = 1 AND [Index] = 1", current_business, current_board)
                    Else
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, dbo.CDR_RightContainer(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0)) AS New_Container, dbo.CDR_ContainerQuantity(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0))) AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE Business = '{0}' AND Board = '{1}' AND [Active] = 1 AND [Index] = 1", current_business, current_board)
                    End If
                End If
            Else
                If chkBoth.Checked Then
                    If chkKeepContainer.Checked Then
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, Container AS New_Container, Pieces AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE M.Business = '{0}' AND K.[Active] = 1", current_business)
                    Else
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, dbo.CDR_RightContainer(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0)) AS New_Container, dbo.CDR_ContainerQuantity(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0))) AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE M.Business = '{0}' AND K.[Active] = 1", current_business)
                    End If
                Else
                    If chkKeepContainer.Checked Then
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, Container AS New_Container, Pieces AS New_PiecesFROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE M.Business = '{0}' AND K.[Active] = 1 AND K.[Index] = 1", current_business)
                    Else
                        kanbans_dt = SQL.Current.GetDatatable("SELECT [ID], dbo.CDR_GetLocation(Partnumber,Business) AS New_SupermarketLocation, dbo.CDR_RoutesName(Board) AS New_Routes, dbo.CDR_RightContainer(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0)) AS New_Container, dbo.CDR_ContainerQuantity(Partnumber,ISNULL(dbo.CDR_RightContainer(Partnumber,dbo.CDR_PartnumberRequirement(Partnumber,Business,Board),0))) AS New_Pieces FROM CDR_Engineering AS E INNER JOIN Mfg_Boards AS M ON E.Board = M.Board FULL JOIN Sch_ CDR2_Kanbans AS K ON M.Business = K.Business AND E.Board = K.Board AND E.Partnumber = K.Partnumber AND E.Kit = K.Kit AND E.Loc = K.EngineeringLocation AND E.Slot = K.Slot AND E.Side = K.Side AND E.Section AND K.Section WHERE M.Business = '{0}' AND K.[Active] = 1 AND K.[Index] = 1", current_business)
                    End If
                End If
            End If
            For Each row As DataRow In kanbans_dt.Rows

            Next
            LoadingScreen.Hide()
        End If
    End Sub
End Class