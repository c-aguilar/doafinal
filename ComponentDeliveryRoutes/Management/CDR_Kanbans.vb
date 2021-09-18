Imports CAguilar
Public Class CDR_Kanbans
    Dim current_board As String = ""
    Dim current_business As String = ""
    Dim changes_saved As Boolean = True
    Dim row_index_cms As Integer = -1
    Dim sb As SearchBox
    Private Sub frmKanbans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboBusiness, SQL.Current.GetDatatable("SELECT DISTINCT Business FROM CDR_ProductionControl ORDER BY Business"))
        dgvResult.AutoGenerateColumns = False
        sb = New SearchBox(dgvActual)
    End Sub

    Private Sub cboBusiness_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBusiness.SelectionChangeCommitted
        cboBoard.SelectedIndex = -1
        GF.FillCombobox(cboBoard, SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Board FROM CDR_ProductionControl WHERE Board IS NOT NULL AND Business='{0}' ORDER BY Board", cboBusiness.SelectedItem)))
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If cboBusiness.SelectedIndex > -1 Then
            If Not changes_saved AndAlso MessageBox.Show("Existen cambios si guardar. Deseas actualizar en la base de datos?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvActual.Rows
                    If CBool(row.Cells("kan_updateda").Value) AndAlso SQL.Current.Update("CDR_Kanbans", {"Container", "Pieces", "Frequency", "Hrs", "Comment", "Rack", "Local", "Partnumber", "Description"}, {row.Cells("kan_containera").Value, row.Cells("kan_piecesa").Value, row.Cells("kan_frequencya").Value, row.Cells("kan_hrsa").Value, row.Cells("kan_commenta").Value, row.Cells("kan_racka").Value, row.Cells("kan_locala").Value, row.Cells("kan_partnumbera").Value, row.Cells("kan_descriptiona").Value}, {"Code"}, {row.Cells("kan_codea").Value}) Then
                        SQL.Current.Execute(String.Format("INSERT INTO CDR_KanbansHistory (kanID,Partnumber,Board,Description,Kit,Engloc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requeriment,[2h],Quantity,Frequency,Hrs,Comment,Rack,Local,[Date],Code) " & _
                                                           "SELECT ID,Partnumber,Board,Description,Kit,Engloc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requeriment,[2h],Quantity,Frequency,Hrs,Comment,Rack,[Local],GETDATE(),Code " & _
                                                           "FROM CDR_Kanbans WHERE Code='{0}'", row.Cells("kan_codea").Value))
                    End If
                Next
            End If
            changes_saved = True
            dgvActual.Rows.Clear()
            dgvResult.Rows.Clear()
            dgvResult.Visible = False
            current_business = cboBusiness.SelectedItem
            If cboBoard.SelectedIndex > -1 Then
                current_board = cboBoard.SelectedItem
            Else
                current_board = ""
            End If
            LoadKanbans()
        Else
            current_business = ""
        End If
    End Sub

    Private Sub dgvActual_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvActual.CurrentCellDirtyStateChanged
        If dgvActual.Columns(dgvActual.CurrentCell.ColumnIndex).Name = "kan_containera" Then
            dgvActual.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Try
                Dim qty_container As Double = SQL.Current.GetScalar(String.Format("SELECT dbo.CDR_ContainerQuantity('{0}','{1}')", dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_partnumbera").Value, dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_containera").Value))
                dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_piecesa").Value = qty_container
                dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_frequencya").Value = Math.Ceiling(dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_quantitya").Value * dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_requirementa").Value / qty_container)
                dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_hrsa").Value = Math.Floor(qty_container / Math.Ceiling(dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_quantitya").Value * dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_requirementa").Value / 8.5))
                dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_updateda").Value = 1
                changes_saved = False
            Catch ex As Exception
                FlashAlerts.ShowError("Hubo un error al recalcular los valores. Compruebe que la informacion necesaria es correcta.")
            End Try
        End If
    End Sub

    Private Sub dgvActual_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvActual.CellEndEdit
        If dgvActual.Columns(e.ColumnIndex).Name = "kan_partnumbera" Then
            dgvActual.Rows(e.RowIndex).Cells("kan_descriptiona").Value = RawMaterial.GetDescription(dgvActual.Rows(e.RowIndex).Cells("kan_partnumbera").Value)

            Dim container As String = SQL.Current.GetString(String.Format("SELECT dbo.CDR_RightNameContainer('{0}',{1})", dgvActual.Rows(e.RowIndex).Cells("kan_partnumbera").Value, dgvActual.Rows(e.RowIndex).Cells("kan_requirementa").Value))
            Dim qty_container As Double = SQL.Current.GetScalar(String.Format("SELECT dbo.CDR_RightContainer('{0}',{1})", dgvActual.Rows(e.RowIndex).Cells("kan_partnumbera").Value, dgvActual.Rows(e.RowIndex).Cells("kan_requirementa").Value))

            CType(dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_containera"), DataGridViewComboBoxCell).Value = container
            dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_piecesa").Value = qty_container
            dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_frequencya").Value = Math.Ceiling(dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_quantitya").Value * dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_requirementa").Value / qty_container)
            dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_hrsa").Value = Math.Floor(qty_container / Math.Ceiling(dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_quantitya").Value * dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_requirementa").Value / 8.5))
            dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_locala").Value = SQL.Current.GetString(String.Format(CDR.Query("PartLocation"), dgvActual.Rows(e.RowIndex).Cells("kan_partnumbera").Value, dgvActual.Rows(e.RowIndex).Cells("kan_businessa").Value))
            dgvActual.Rows(dgvActual.CurrentCell.RowIndex).Cells("kan_racka").Value = SQL.Current.GetString(String.Format(CDR.Query("PartRack"), dgvActual.Rows(e.RowIndex).Cells("kan_partnumbera").Value, dgvActual.Rows(e.RowIndex).Cells("kan_businessa").Value))
        End If
        dgvActual.Rows(e.RowIndex).Cells("kan_updateda").Value = 1
        changes_saved = False
    End Sub

    Private Sub dgvResult_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvResult.CurrentCellDirtyStateChanged
        With dgvResult.Rows(dgvResult.CurrentCell.RowIndex)
            If dgvResult.Columns(dgvResult.CurrentCell.ColumnIndex).Name = "kan_container" Then
                dgvResult.CommitEdit(DataGridViewDataErrorContexts.Commit)
                Try
                    Dim qty_container As Double = SQL.Current.GetScalar(String.Format("SELECT dbo.CDR_ContainerQuantity('{0}','{1}')", .Cells("kan_partnumber").Value, .Cells("kan_container").Value))
                    .Cells("kan_pieces").Value = qty_container
                    .Cells("kan_frequency").Value = Math.Ceiling(.Cells("kan_quantity").Value * .Cells("kan_requirement").Value / qty_container)
                    .Cells("kan_hrs").Value = Math.Floor(qty_container / Math.Ceiling(.Cells("kan_quantity").Value * .Cells("kan_requirement").Value / 8.5))
                    If Not IsDBNull(.Cells("kan_code").Value) Then
                        Dim r As Hashtable = SQL.Current.GetRecord("Kanbans", "kan_code", .Cells("kan_code").Value)
                        If Not IsNothing(r) AndAlso r("kan_description") = .Cells("kan_description").Value AndAlso r("kan_kit") = .Cells("kan_kit").Value AndAlso r("kan_slot") = .Cells("kan_slot").Value AndAlso r("kan_side") = .Cells("kan_side").Value AndAlso r("kan_section") = .Cells("kan_section").Value _
                                    AndAlso r("kan_route") = .Cells("kan_route").Value AndAlso r("kan_pieces") = .Cells("kan_pieces").Value AndAlso r("kan_container") = .Cells("kan_container").Value AndAlso r("kan_index") = .Cells("kan_index").Value AndAlso r("kan_business") = .Cells("kan_business").Value _
                                    AndAlso r("kan_requirement") = .Cells("kan_requirement").Value AndAlso r("kan_2h") = .Cells("kan_2h").Value AndAlso r("kan_quantity") = .Cells("kan_quantity").Value AndAlso r("kan_frequency") = .Cells("kan_frequency").Value AndAlso r("kan_hrs") = .Cells("kan_hrs").Value _
                                    AndAlso r("kan_rack") = .Cells("kan_rack").Value AndAlso r("kan_local") = .Cells("kan_local").Value Then
                            .DefaultCellStyle.BackColor = Color.LimeGreen
                            .DefaultCellStyle.ForeColor = Color.Black
                        Else
                            .DefaultCellStyle.BackColor = Color.Crimson
                            .DefaultCellStyle.ForeColor = Color.White
                        End If
                    End If
                Catch ex As Exception
                    FlashAlerts.ShowError("Hubo un error al recalcular los valores. Compruebe que la informacion necesaria es correcta.")
                End Try
            End If
        End With
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not changes_saved Then
            For Each row As DataGridViewRow In dgvActual.Rows
                If CBool(row.Cells("kan_updateda").Value) AndAlso SQL.Current.Update("CDR_Kanbans", {"Container", "Pieces", "Frequency", "Hrs", "Comment", "Rack", "[Local]", "Partnumber", "Description"}, {row.Cells("kan_containera").Value, row.Cells("kan_piecesa").Value, row.Cells("kan_frequencya").Value, row.Cells("kan_hrsa").Value, row.Cells("kan_commenta").Value, row.Cells("kan_racka").Value, row.Cells("kan_locala").Value, row.Cells("kan_partnumbera").Value, row.Cells("kan_descriptiona").Value}, {"Code"}, {row.Cells("kan_codea").Value}) Then
                    SQL.Current.Execute(String.Format("INSERT INTO CDR_KanbansHistory (kanID,Partnumber,Board,Description,Kit,Engloc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requirement,[2h],Quantity,Frequency,Hrs,Comment,Rack,[Local],[Date],Code) " & _
                                                        "SELECT ID,Partnumber,Board,Description,Kit,Engloc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requirement,[2h],Quantity,Frequency,Hrs,Comment,Rack,[Local],GETDATE(),Code " & _
                                                        "FROM CDRKanbans WHERE Code='{0}';", row.Cells("kan_codea").Value))
                End If
            Next
            changes_saved = True
            FlashAlerts.ShowConfirm("Hecho!")
        End If
    End Sub

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialToolStripMenuItem.Click
        Dim history As New CDR_KanbanHistory
        history.code = dgvActual.Rows(row_index_cms).Cells("kan_codea").Value
        history.Show(Me)
    End Sub

    Private Sub dgvActual_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvActual.CellMouseEnter
        row_index_cms = e.RowIndex
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If MessageBox.Show("Seguro de eliminar esta kanban del sistema?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If SQL.Current.Delete("CDR_Kanbans", "Code", dgvActual.Rows(row_index_cms).Cells("kan_codea").Value) Then
                SQL.Current.Execute(String.Format("INSERT INTO CDR_KanbansHistory (ID,partnumber,board,description,kit,slot,side,section,route,pieces,container,index,business,requirement,[2h],quantity,frequency,hrs,comment,rack,[local],[dat]e,code) " & _
                                                              "SELECT TOP 1 ID,partnumber,board,description,kit,slot,side,section,route,pieces,container,[index],business,requirement,[2h],quantity,frequency,hrs,'Eliminado',rack,[local],GETDATE(),code " & _
                                                              "FROM CDR_KanbansHistory WHERE ID={0} ORDER BY [Date] DESC", dgvActual.Rows(row_index_cms).Cells("kan_ID").Value))
                dgvActual.Rows.RemoveAt(row_index_cms)
            End If
        End If
    End Sub

    Private Sub btnRecalculate_Click(sender As Object, e As EventArgs) Handles btnRecalculate.Click
        Try
            If cboBusiness.SelectedIndex > -1 Then
                chkCheck.Checked = False
                current_business = cboBusiness.SelectedItem
                If cboBoard.SelectedIndex > -1 Then
                    current_board = cboBoard.SelectedItem
                    Dim squery As String = ""
                    If chkBoth.Checked Then
                        If chkKeepContainer.Checked Then
                            squery = CDR.Query("RecalculateKanban_Both_Board_SameContainer")
                        Else
                            squery = CDR.Query("RecalculateKanban_Both_Board")
                        End If
                    Else
                        If chkKeepContainer.Checked Then
                            squery = CDR.Query("RecalculateKanban_Use_Board_SameContainer")
                        Else
                            squery = CDR.Query("RecalculateKanban_Use_Board")
                        End If
                    End If
                    dgvResult.Rows.Clear()
                    dgvResult.Visible = True
                    For Each r As DataRow In SQL.Current.GetDatatable(String.Format(squery, current_business, current_board)).Rows
                        dgvResult.Rows.Add(False, r("code"), r("partnumber"), r("description"), r("rack"), r("location"), r("board"), r("kit"), r("loc"), r("slot"), r("side"), r("section"), r("route"), r("container_name"), r("container_pieces"), r("i"), r("Business"), r("requirement"), r("quantity"), r("2h"), r("frequency"), r("hrs"))
                        With dgvResult.Rows(dgvResult.Rows.GetLastRow(DataGridViewElementStates.None))
                            If IsDBNull(r("code")) Then
                                .DefaultCellStyle.BackColor = Color.Gray
                                .DefaultCellStyle.ForeColor = Color.White
                            ElseIf IsDiff(r("description"), r("description")) OrElse IsDiff(r("kit"), r("kit")) OrElse IsDiff(r("engloc"), r("loc")) OrElse IsDiff(r("slot"), r("slot")) OrElse IsDiff(r("side"), r("side")) OrElse IsDiff(r("section"), r("section")) _
                                OrElse IsDiff(r("route"), r("route")) OrElse IsDiff(r("pieces"), r("container_pieces")) OrElse IsDiff(r("container"), r("container_name")) OrElse IsDiff(r("index"), r("i")) OrElse IsDiff(r("business"), r("Business")) _
                                 OrElse IsDiff(r("requirement"), r("requirement")) OrElse IsDiff(r("2h"), r("2h")) OrElse IsDiff(r("quantity"), r("quantity")) OrElse IsDiff(r("frequency"), r("frequency")) OrElse IsDiff(r("hrs"), r("hrs")) _
                                 OrElse IsDiff(r("rack"), r("rack")) OrElse IsDiff(r("local"), r("location")) Then
                                .DefaultCellStyle.BackColor = Color.Crimson
                                .DefaultCellStyle.ForeColor = Color.White
                            Else
                                .DefaultCellStyle.BackColor = Color.LimeGreen
                            End If
                        End With
                    Next
                Else
                    current_board = ""
                    Dim squery As String = ""
                    If chkBoth.Checked Then
                        If chkKeepContainer.Checked Then
                            squery = CDR.Query("RecalculateKanban_Both_Business_SameContainer")
                        Else
                            squery = CDR.Query("RecalculateKanban_Both_Business")
                        End If
                    Else
                        If chkKeepContainer.Checked Then
                            squery = CDR.Query("RecalculateKanban_Use_Business_SameContainer")
                        Else
                            squery = CDR.Query("RecalculateKanban_Use_Business")
                        End If
                    End If
                    dgvResult.Rows.Clear()
                    dgvResult.Visible = True
                    For Each r As DataRow In SQL.Current.GetDatatable(String.Format(squery, current_business)).Rows
                        dgvResult.Rows.Add(False, r("code"), r("partnumber"), r("description"), r("rack"), r("location"), r("board"), r("kit"), r("loc"), r("slot"), r("side"), r("section"), r("Route"), r("container_name"), r("container_pieces"), r("i"), r("Business"), r("requirement"), r("quantity"), r("2h"), r("frequency"), r("hrs"))
                        With dgvResult.Rows(dgvResult.Rows.GetLastRow(DataGridViewElementStates.None))
                            If IsDBNull(r("code")) Then
                                .DefaultCellStyle.BackColor = Color.Gray
                                .DefaultCellStyle.ForeColor = Color.White
                            ElseIf IsDiff(r("description"), r("description")) OrElse IsDiff(r("kit"), r("kit")) OrElse IsDiff(r("engloc"), r("loc")) OrElse IsDiff(r("slot"), r("slot")) OrElse IsDiff(r("side"), r("side")) OrElse IsDiff(r("section"), r("section")) _
                                OrElse IsDiff(r("route"), r("Route")) OrElse IsDiff(r("pieces"), r("container_pieces")) OrElse IsDiff(r("container"), r("container_name")) OrElse IsDiff(r("index"), r("i")) OrElse IsDiff(r("business"), r("Business")) _
                                 OrElse IsDiff(r("requirement"), r("requirement")) OrElse IsDiff(r("2h"), r("2h")) OrElse IsDiff(r("quantity"), r("quantity")) OrElse IsDiff(r("frequency"), r("frequency")) OrElse IsDiff(r("hrs"), r("hrs")) _
                                 OrElse IsDiff(r("rack"), r("rack")) OrElse IsDiff(r("local"), r("location")) Then
                                .DefaultCellStyle.BackColor = Color.Crimson
                                .DefaultCellStyle.ForeColor = Color.White
                            Else
                                .DefaultCellStyle.BackColor = Color.LimeGreen
                            End If
                        End With
                    Next
                End If
            End If
            LoadKanbans()
        Catch ex As Exception
            FlashAlerts.ShowError("Surgio un problema al cargar la informacion. Valida la contenerizacion y requiriento de Control de Produccion del negocio seleccionado.")
        End Try
    End Sub

    Private Function IsDiff(x As Object, y As Object)
        If IsDBNull(x) Then
            If IsDBNull(y) Then
                Return False
            Else
                Return True
            End If
        ElseIf IsDBNull(y) Then
            Return True
        ElseIf x = y Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub dgvResult_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellEndEdit
        With dgvResult.Rows(e.RowIndex)
            If .Cells("kan_partnumber").ColumnIndex = e.ColumnIndex Then
                Dim qty_container As Double = SQL.Current.GetScalar(String.Format("SELECT dbo.CDR_ContainerQuantity('{0}','{1}')", .Cells("kan_partnumber").Value, .Cells("kan_container").Value))
                .Cells("kan_pieces").Value = qty_container
                .Cells("kan_frequency").Value = Math.Ceiling(.Cells("kan_quantity").Value * .Cells("kan_requirement").Value / qty_container)
                .Cells("kan_hrs").Value = Math.Floor(qty_container / Math.Ceiling(.Cells("kan_quantity").Value * .Cells("kan_requirement").Value / 8.5))
                If Not IsDBNull(.Cells("kan_code").Value) AndAlso SQL.Current.GetString("partnumber", "CDR_Kanbans", "Code", .Cells("kan_code").Value, "###") <> .Cells("kan_partnumber").Value Then
                    .Cells("kan_code").Value = DBNull.Value
                ElseIf IsDBNull(.Cells("kan_code").Value) AndAlso SQL.Current.Exists("CDR_Kanbans", {"partnumber", "board", "kit"}, {.Cells("kan_partnumber").Value, current_board, .Cells("kan_kit").Value}) Then
                    .Cells("kan_code").Value = SQL.Current.GetString("Code", "CDR_Kanbans", {"Partnumber", "board", "kit"}, {.Cells("kan_partnumber").Value, current_board, .Cells("kan_kit").Value}, "")
                End If
            End If
            If IsDBNull(.Cells("kan_code").Value) Then
                .DefaultCellStyle.BackColor = Color.Gray
                .DefaultCellStyle.ForeColor = Color.White
            Else
                Dim r As Hashtable = SQL.Current.GetRecord("CDR_Kanbans", "Code", .Cells("kan_code").Value)
                If Not IsNothing(r) AndAlso RNull(r("description")) = RNull(.Cells("kan_description").Value) AndAlso RNull(r("kit")) = RNull(.Cells("kan_kit").Value) AndAlso RNull(r("engloc")) = RNull(.Cells("kan_engloc").Value) AndAlso RNull(r("slot")) = RNull(.Cells("kan_slot").Value) AndAlso RNull(r("side")) = RNull(.Cells("kan_side").Value) AndAlso RNull(r("section")) = RNull(.Cells("kan_section").Value) _
                            AndAlso RNull(r("route")) = RNull(.Cells("kan_route").Value) AndAlso RNull(r("pieces")) = RNull(.Cells("kan_pieces").Value) AndAlso RNull(r("container")) = RNull(.Cells("kan_container").Value) AndAlso RNull(r("index")) = RNull(.Cells("kan_index").Value) AndAlso RNull(r("business")) = RNull(.Cells("kan_business").Value) _
                            AndAlso RNull(r("requirement")) = RNull(.Cells("kan_requirement").Value) AndAlso RNull(r("2h")) = RNull(.Cells("kan_2h").Value) AndAlso RNull(r("quantity")) = RNull(.Cells("kan_quantity").Value) AndAlso RNull(r("frequency")) = RNull(.Cells("kan_frequency").Value) AndAlso RNull(r("hrs")) = RNull(.Cells("kan_hrs").Value) _
                            AndAlso RNull(r("rack")) = RNull(.Cells("kan_rack").Value) AndAlso RNull(r("local")) = RNull(.Cells("kan_local").Value) Then
                    .DefaultCellStyle.BackColor = Color.LimeGreen
                    .DefaultCellStyle.ForeColor = Color.Black
                Else
                    .DefaultCellStyle.BackColor = Color.Crimson
                    .DefaultCellStyle.ForeColor = Color.White
                End If
            End If
        End With

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If current_business <> "" AndAlso dgvResult.Rows.Count > 0 AndAlso MessageBox.Show("Seguro de reemplazar esta informacion en la base de datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim errors As Boolean = False
            For Each row As DataGridViewRow In dgvResult.Rows
                If row.Cells("kan_chk").Value = True Then
                    If Not IsDBNull(row.Cells("kan_code").Value) AndAlso row.DefaultCellStyle.BackColor = Color.Crimson Then
                        If SQL.Current.Update("CDR_Kanbans", {"container", "pieces", "[frequency]", "hrs", "rack", "[local]", "partnumber", "[description]", "slot", "side", "section", "business", "requirement", "[2h]", "engloc", "[route]", "quantity"},
                                           {row.Cells("kan_container").Value, row.Cells("kan_pieces").Value, row.Cells("kan_frequency").Value, row.Cells("kan_hrs").Value, row.Cells("kan_rack").Value, row.Cells("kan_local").Value, row.Cells("kan_partnumber").Value, row.Cells("kan_description").Value, row.Cells("kan_slot").Value, row.Cells("kan_side").Value, row.Cells("kan_section").Value, row.Cells("kan_business").Value, row.Cells("kan_requirement").Value, row.Cells("kan_2h").Value, row.Cells("kan_engloc").Value, row.Cells("kan_route").Value, row.Cells("kan_quantity").Value}, {"code"}, {row.Cells("kan_code").Value}) Then
                            SQL.Current.Execute(String.Format("INSERT INTO CDR_KanbansHistory (kanID,partnumber,board,description,kit,engloc,slot,side,section,route,pieces,container,[index],business,requirement,[2h],quantity,frequency,hrs,comment,rack,[local],[date],code) " & _
                                                                "SELECT ID,partnumber,board,description,kit,engloc,slot,side,section,route,pieces,container,[index],business,requirement,[2h],quantity,frequency,hrs,comment,rack,[local],GETDATE(),code " & _
                                                                "FROM CDR_Kanbans WHERE code='{0}'", row.Cells("kan_code").Value))
                        Else
                            errors = True
                        End If
                    ElseIf IsDBNull(row.Cells("kan_code").Value) AndAlso row.DefaultCellStyle.BackColor = Color.Gray AndAlso Not IsDBNull(row.Cells("kan_pieces").Value) Then
                        If SQL.Current.Insert("CDR_Kanbans", {"partnumber", "board", "[description]", "kit", "engloc", "slot", "side", "section", "[route]", "pieces", "container", "[index]", "business", "requirement", "[2h]", "quantity", "[frequency]", "hrs", "comment", "rack", "[local]"},
                                              {row.Cells("kan_partnumber").Value, row.Cells("kan_board").Value, row.Cells("kan_description").Value, row.Cells("kan_kit").Value, row.Cells("kan_engloc").Value, row.Cells("kan_slot").Value, row.Cells("kan_side").Value, row.Cells("kan_section").Value, row.Cells("kan_route").Value, row.Cells("kan_pieces").Value, row.Cells("kan_container").Value, row.Cells("kan_index").Value, row.Cells("kan_business").Value, row.Cells("kan_requirement").Value, row.Cells("kan_2h").Value, row.Cells("kan_quantity").Value, row.Cells("kan_frequency").Value, row.Cells("kan_hrs").Value, "Alta", row.Cells("kan_rack").Value, row.Cells("kan_local").Value}) Then
                            SQL.Current.Execute(String.Format("INSERT INTO CDR_KanbansHistory (kanID,partnumber,board,description,kit,engloc,slot,side,section,route,pieces,container,[index],business,requirement,[2h],quantity,frequency,hrs,comment,rack,[local],[date],code) " & _
                                                            "SELECT ID,partnumber,board,description,kit,engloc,slot,side,section,route,pieces,container,[index],business,requirement,[2h],quantity,frequency,hrs,comment,rack,[local],GETDATE(),code " & _
                                                            "FROM CDR_Kanbans WHERE board='{0}' AND kit='{1}' AND partnumber='{2}';", row.Cells("kan_board").Value, row.Cells("kan_kit").Value, row.Cells("kan_partnumber").Value))
                        Else
                            errors = True
                        End If
                    Else
                        errors = True
                    End If
                End If

            Next
            dgvResult.Rows.Clear()
            LoadKanbans()
            If errors Then
                FlashAlerts.ShowInformation("Hecho! Pero se presentaron algunos errores que no fueron actualizados.")
            Else
                FlashAlerts.ShowConfirm("Hecho!")
            End If
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim r As Hashtable = SQL.Current.GetRecord("Kanbans", "kan_code", dgvActual.Rows(row_index_cms).Cells("kan_codea").Value)
        If Not IsNothing(r) Then
            ZPL.PrintTo(CDR.BuildKanban(r("kan_code"), r("kan_partnumber"), r("kan_engloc"), r("kan_slot"), r("kan_side"), r("kan_section"), r("kan_board"), r("kan_kit"), r("kan_route"), r("kan_description"), r("kan_pieces"), r("kan_container"), r("kan_index"), r("kan_business"), r("kan_rack"), r("kan_local"), r("kan_date")))
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If current_business <> "" AndAlso MessageBox.Show("¿Eliminar kanbans?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes AndAlso
            MessageBox.Show("Se eliminara completamente esta informacion de la base de datos. ¿Seguro de continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If current_board <> "" Then
                If Not SQL.Current.Delete("CDR_Kanbans", {"Business", "Board"}, {current_business, current_board}) Then
                    FlashAlerts.ShowError("Error al tratar de eliminar las kanbans.")
                End If
            Else
                If Not SQL.Current.Delete("CDR_Kanbans", "Business", current_business) Then
                    FlashAlerts.ShowError("Error al tratar de eliminar las kanbans.")
                End If
            End If
            LoadKanbans()
        End If
    End Sub

    Private Sub LoadKanbans()
        dgvActual.Rows.Clear()
        If current_business <> "" AndAlso current_board <> "" Then
            For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT ID,code, partnumber, description, rack, [local], board, kit, engloc, slot, side, section, route, container,pieces, [index], business, requirement,quantity, [2h], frequency, hrs, comment,0 updated FROM CDR_Kanbans WHERE business='{0}' AND board='{1}' ORDER BY kit,engloc,[index]", current_business, current_board)).Rows
                dgvActual.Rows.Add(r.ItemArray)
                dgvActual.Rows(dgvActual.Rows.GetLastRow(DataGridViewElementStates.None)).ContextMenuStrip = cmsActual
            Next
        ElseIf current_business <> "" Then
            For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT ID,code, partnumber, description, rack, [local], board, kit, engloc, slot, side, section, route, container,pieces, [index], business, requirement,quantity, [2h], frequency, hrs, comment,0 updated FROM CDR_Kanbans WHERE business='{0}' ORDER BY board,kit,engloc,[index]", current_business)).Rows
                dgvActual.Rows.Add(r.ItemArray)
                dgvActual.Rows(dgvActual.Rows.GetLastRow(DataGridViewElementStates.None)).ContextMenuStrip = cmsActual
            Next
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        sb.Show()
    End Sub

    Private Sub chkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheck.CheckedChanged
        For Each row As DataGridViewRow In dgvResult.Rows
            row.Cells("kan_chk").Value = chkCheck.Checked
        Next
    End Sub

    Private Function RNull(value As Object) As Object
        If IsDBNull(value) Then
            Return ""
        Else
            Return value
        End If
    End Function

    Private Sub CDR_Kanbans_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub
End Class