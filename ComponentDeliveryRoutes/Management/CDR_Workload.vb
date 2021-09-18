Imports CAguilar

Public Class CDR_Workload

    Private Sub CDR_Workload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(cboRoutes, SQL.Current.GetDatatable("SELECT Route,Description + ' T.' + Shift AS Description FROM CDR_Routes ORDER BY Description"), "Description", "Route")
    End Sub

    Private Sub cboRoutes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRoutes.SelectionChangeCommitted
        If cboRoutes.SelectedIndex > -1 Then RefreshData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvAll.SelectedRows.Count = 1 Then
            If SQL.Current.Exists("CDR_RoutesBoards", "Board", dgvAll.SelectedRows.Item(0).Cells("all_board").Value) Then
                If SQL.Current.Update("CDR_RoutesBoards", {"Route"}, {cboRoutes.SelectedValue}, "Board", dgvAll.SelectedRows.Item(0).Cells("all_board").Value) Then
                    Dim new_route As String = SQL.Current.GetString("Description", "Routes", "Route", cboRoutes.SelectedValue, "")
                    SQL.Current.Update("CDR_Kanbans", {"Route"}, {new_route}, {"Board"}, {dgvAll.SelectedRows.Item(0).Cells("all_board").Value})
                End If
            Else
                If SQL.Current.Insert("CDR_RoutesBoards", {"Route", "Board"}, {cboRoutes.SelectedValue, dgvAll.SelectedRows.Item(0).Cells("all_board").Value}) Then
                    Dim new_route As String = SQL.Current.GetString("Description", "Routes", "Route", cboRoutes.SelectedValue, "")
                    SQL.Current.Update("CDR_Kanbans", {"Route"}, {new_route}, {"Board"}, {dgvAll.SelectedRows.Item(0).Cells("all_board").Value})
                End If
            End If
            RefreshData()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvActual.SelectedRows.Count = 1 Then
            SQL.Current.Delete("CDR_RoutesBoards", "Board", dgvActual.SelectedRows.Item(0).Cells("a_board").Value)
            RefreshData()
        End If
    End Sub

    Private Sub RefreshData()
        dgvActual.Rows.Clear()
        dgvAll.Rows.Clear()
        ctWorkload.Series(0).Points.Clear()
        For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT Business,B.Board FROM CDR_RoutesBoards AS B INNER JOIN (SELECT Business,Board FROM CDR_ProductionControl GROUP BY Business,Board) AS C ON B.Board = C.Board WHERE B.Route = {0};", cboRoutes.SelectedValue)).Rows
            dgvActual.Rows.Add(r.Item(0), r.Item(1))
        Next
        For Each r As DataRow In SQL.Current.GetDatatable(String.Format("SELECT Business,C.Board FROM (SELECT Business,Board FROM CDR_ProductionControl GROUP BY Business,Board) AS C LEFT OUTER JOIN CDR_RoutesBoards AS B ON C.Board = B.Board WHERE B.Route IS NULL;")).Rows
            dgvAll.Rows.Add(r.Item(0), r.Item(1))
        Next
        Dim wl As DataTable = SQL.Current.GetDatatable(String.Format("SELECT R.Description AS route,COUNT(DISTINCT Business) AS business,COUNT(DISTINCT B.Board) AS boards,SUM(CASE WHEN [Index] = 1 THEN 1 ELSE 0 END) AS containers,AVG(PrimaryWalkings) + AVG(SecondaryWalkings) AS walkings,ROUND(ISNULL(AVG(CONVERT(FLOAT,Frequency)),0),3) AS frequency,ISNULL(ROUND(((SUM(CASE WHEN [Index] = 1 THEN 1 ELSE 0 END) * {0} * AVG(CONVERT(FLOAT,Frequency))) + (((AVG(PrimaryWalkings) + AVG(SecondaryWalkings))/2.0)*8)) / 28800.0,3),0) AS workload FROM CDR_Routes AS R LEFT OUTER JOIN CDR_RoutesBoards AS B ON R.Route = B.Route LEFT OUTER JOIN CDR_Kanbans AS K ON B.Board = K.Board GROUP BY R.Description ORDER BY R.Description;", Parameter("CDR_ATT")))
        dgvResult.DataSource = wl
        For Each r As DataRow In wl.Rows
            ctWorkload.Series(ctWorkload.Series.Count - 1).Points.AddXY(r("route"), r("workload") * 100)
        Next
    End Sub

    Private Sub CDR_Workload_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CDR_Workload_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Dim wl As DataTable = SQL.Current.GetDatatable(String.Format("SELECT R.Description AS Ruta,COUNT(DISTINCT Business) AS Negocios,COUNT(DISTINCT Board) AS Tableros,COUNT(ID) AS TotalContenedores,AVG(PrimaryWalkings) + AVG(SecondaryWalkings) AS TotalCaminares,ROUND(ISNULL(AVG(CONVERT(FLOAT,Frequency)),0),3) AS FrecuenciaPromedio,ISNULL(ROUND(((COUNT(ID) * {0} * AVG(CONVERT(FLOAT,Frequency))) + (((AVG(PrimaryWalkings) + AVG(SecondaryWalkings))/2.0)*8)) / 28800.0,3),0)*100 AS [Carga] FROM CDR_Routes AS R LEFT OUTER JOIN CDR_RoutesBoards AS B ON R.Route = B.Route LEFT OUTER JOIN CDR_Kanbans AS K ON B.Board = K.Board GROUP BY R.Description ORDER BY R.Description;", Parameter("CDR_ATT")))
        'dgvResult.DataSource = wl
        'For Each r As DataRow In wl.Rows
        '    ctWorkload.Series(ctWorkload.Series.Count - 1).Points.AddXY(r("Ruta"), r("Carga"))
        'Next

        Dim wl As DataTable = SQL.Current.GetDatatable(String.Format("SELECT R.Description AS route,COUNT(DISTINCT Business) AS business,COUNT(DISTINCT B.Board) AS boards,SUM(CASE WHEN [Index] = 1 THEN 1 ELSE 0 END) AS containers,AVG(PrimaryWalkings) + AVG(SecondaryWalkings) AS walkings,ROUND(ISNULL(AVG(CONVERT(FLOAT,Frequency)),0),3) AS frequency,ISNULL(ROUND(((SUM(CASE WHEN [Index] = 1 THEN 1 ELSE 0 END) * {0} * AVG(CONVERT(FLOAT,Frequency))) + (((AVG(PrimaryWalkings) + AVG(SecondaryWalkings))/2.0)*8)) / 28800.0,3),0) AS workload FROM CDR_Routes AS R LEFT OUTER JOIN CDR_RoutesBoards AS B ON R.Route = B.Route LEFT OUTER JOIN CDR_Kanbans AS K ON B.Board = K.Board GROUP BY R.Description ORDER BY R.Description;", Parameter("CDR_ATT")))
        dgvResult.DataSource = wl
        For Each r As DataRow In wl.Rows
            ctWorkload.Series(ctWorkload.Series.Count - 1).Points.AddXY(r("route"), r("workload") * 100)
        Next
    End Sub
End Class