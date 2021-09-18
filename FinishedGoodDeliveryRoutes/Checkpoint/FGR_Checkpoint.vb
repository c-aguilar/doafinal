Public Class FGR_Checkpoint
    Dim Routes As DataTable
    Private Sub FGR_Checkpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Option_txt.Focus()
        LoadOptions()
    End Sub

    Private Sub LoadOptions()
        Warehouse_lbl.Text = String.Format("Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
        Routes = SQL.Current.GetDatatable(String.Format("SELECT '*FGR' + CONVERT(VARCHAR(4),Route) + '*' AS Route,[Description] FROM FGR_Routes WHERE Warehouse = '{0}' AND Active = 1;", My.Settings.Warehouse))
        Routes.PrimaryKey = {Routes.Columns("Route")}
        Picklist_dgv.DataSource = Routes
    End Sub

    Private Sub FGR_Checkpoint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Option_txt_Validated(sender As Object, e As EventArgs) Handles Option_txt.Validated
        If Option_txt.Text <> "" Then ReadRoute()
    End Sub

    Private Sub ReadRoute()
        Dim option_scan As String = Option_txt.Text.ToUpper.Trim
        If Routes.Rows.Find(String.Format("*{0}*", option_scan)) IsNot Nothing Then
            Dim background As New FadeBackground()
            Dim scan As New FGR_SerialScan
            scan.Route = CInt(option_scan.Replace("FGR", ""))
            background.Show()
            scan.ShowDialog()
            background.Close()
            background.Dispose()
            Option_txt.Clear()
            Option_txt.Focus()
        Else
            Option_txt.Clear()
            Option_txt.Focus()
            FlashAlerts.ShowError("La ruta no existe.")
        End If
    End Sub

    Private Sub Option_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Option_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Option_txt.Text <> "" Then
            ReadRoute()
        End If
    End Sub
End Class