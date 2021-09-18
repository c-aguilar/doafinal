Public Class FGR_CancelSerialMovements
    Dim serials As DataTable
    Private Sub Bkf_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        If serials.Compute("COUNT(Serialnumber)", "Canceling = 1") > 0 AndAlso MessageBox.Show("¿Seguro de cancelar estos movimientos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            LoadingScreen.Show()
            Dim to_canceling = serials.Select("Canceling = 1")
            For Each s In to_canceling
                SQL.Current.Update("FGR_SerialMovements", {"Active"}, {0}, {"Serialnumber", "Movement"}, {s.Item("Serialnumber"), s.Item("Movimiento")})
            Next
            RefreshSerials()
            LoadingScreen.Hide()
        End If
    End Sub

    Private Sub FGR_Backflush_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshSerials()
    End Sub

    Private Sub RefreshSerials()
        serials = SQL.Current.GetDatatable("SELECT Serialnumber,[Description] AS Ruta,[Date] AS Fecha, Movement AS Movimiento,CONVERT(BIT,0) AS Canceling FROM FGR_SerialMovements AS S LEFT OUTER JOIN FGR_Routes AS R ON S.[Route] = R.[Route] WHERE Posted = 0 AND S.[Active] = 1")
        serials.PrimaryKey = {serials.Columns("Serialnumber")}
        Serial_dgv.DataSource = serials
    End Sub

    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        RefreshSerials()
        Cancel_btn.Enabled = False
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(serials.DefaultView.ToTable(False, "Serialnumber", "Ruta", "Fecha", "Movimiento"), Title_lbl.Text)
    End Sub

    Private Sub SelectAll_chk_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll_chk.CheckedChanged
        If serials IsNot Nothing Then
            For Each s As DataRow In serials.Rows
                s.Item("Canceling") = SelectAll_chk.Checked
            Next
        End If
    End Sub
End Class