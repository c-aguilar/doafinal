Public Class MAn_MandatoryPermitsVsBOM
    Dim comparative As DataTable
    Private Sub MAn_MandatoryPermitsVsBOM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comparative = SQL.Current.GetDatatable("SELECT P.Number AS Permiso,P.Material,P.OldPartnumber AS [Componente Anterior],P.NewPartnumber AS [Componente Nuevo],P.IssueDate AS [Fecha de Creacion] FROM MAn_EngineeringPermits AS P INNER JOIN Sys_CurrentBOM AS B ON P.Material = B.Material AND P.OldPartnumber = B.Partnumber WHERE P.[Type] = 'M'")
        Report_dgv.DataSource = comparative
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        comparative = SQL.Current.GetDatatable("SELECT P.Number AS Permiso,P.Material,P.OldPartnumber AS [Componente Anterior],P.NewPartnumber AS [Componente Nuevo],P.IssueDate AS [Fecha de Creacion] FROM MAn_EngineeringPermits AS P INNER JOIN Sys_CurrentBOM AS B ON P.Material = B.Material AND P.OldPartnumber = B.Partnumber WHERE P.[Type] = 'M'")
        Report_dgv.DataSource = comparative
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Report_dgv.DataSource IsNot Nothing Then
            Delta.Export(comparative, Title_lbl.Text)
        End If
    End Sub
End Class