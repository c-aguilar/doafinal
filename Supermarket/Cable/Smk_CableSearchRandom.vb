Imports CAguilar
Public Class Smk_CableSearchRandom
    Dim partnumber As String = ""
    Private Sub Partnumber_rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Partnumber_rb.CheckedChanged
        If Partnumber_rb.Checked Then
            partnumber = ""
            NextSerial_btn.Enabled = True
            Item_txt.WaterMarkText = "Escriba el numero de parte..."
            Item_txt.Clear()
            Item_txt.Focus()
        Else
            partnumber = ""
            NextSerial_btn.Enabled = False
            Item_txt.WaterMarkText = "Escriba el numero de serie..."
            Item_txt.Clear()
            Item_txt.Focus()
        End If
    End Sub

    Private Sub Smk_CableSearchRandom_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Item_txt.Focus()
    End Sub

    Private Sub Search()
        If Partnumber_rb.Checked Then
            dgvResults.DataSource = SQL.Current.GetDatatable({"Serialnumber Serie,Partnumber [No. de Parte],CurrentQuantity AS Cantidad,UoM AS Unidad,Location AS [Local],[Date] AS Fecha, WarehouseName AS Estacion"}, "vw_Smk_Serials", {"Partnumber", "Status"}, {Item_txt.Text, "S"})
            partnumber = Item_txt.Text
            If RawMaterial.IsControlled(partnumber) Then
                Controlled_pb.Visible = True
                Controlled_lbl.Visible = True
            Else
                Controlled_pb.Visible = False
                Controlled_lbl.Visible = False
            End If
        Else
            partnumber = ""
            If SMK.IsSerialFormat(Item_txt.Text) Then
                Dim serial As New Serialnumber(Item_txt.Text)
                If serial.Exists Then
                    dgvResults.DataSource = SQL.Current.GetDatatable({"Serialnumber Serie,Partnumber [No. de Parte],CurrentQuantity AS Cantidad,UoM AS Unidad,Location AS [Local],[Date] AS Fecha, WarehouseName AS Estacion"}, "vw_Smk_Serials", {"ID", "Status"}, {serial.ID, "S"})
                    If RawMaterial.IsControlled(serial.Partnumber) Then
                        Controlled_pb.Visible = True
                        Controlled_lbl.Visible = True
                    Else
                        Controlled_pb.Visible = False
                        Controlled_lbl.Visible = False
                    End If
                Else
                    Item_txt.Clear()
                    Item_txt.Focus()
                    FlashAlerts.ShowError("La serie no existe.")
                End If
            Else
                Item_txt.Clear()
                Item_txt.Focus()
                FlashAlerts.ShowError("Serie incorrecta.")
            End If
        End If
    End Sub

    Private Sub NextSerial_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextSerial_btn.Click
        If partnumber <> "" Then
            Dim containers = SQL.Current.GetScalar(String.Format("SELECT COUNT(Serialnumber) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Status IN ('O','C') AND CurrentQuantity > 0 AND Warehouse = '{1}';", Me.partnumber, My.Settings.Warehouse))
            Dim maximum = SQL.Current.GetScalar("Maximum", "Smk_Map", {"Partnumber", "Warehouse"}, {partnumber, My.Settings.Warehouse}, 0)
            If containers < maximum Then
                SupermarketCable.ManualNextSerial(partnumber, "DeltaERP")
            Else
                Dim newAdmin As New Sys_Authentication
                If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If newAdmin.User.HasPermission("Supermarket_CableExtraContainer_Ask_flag") Then
                        SupermarketCable.ManualNextSerial(partnumber, newAdmin.User.Badge)
                    Else
                        FlashAlerts.ShowError("No tienes autorización para realizar esta accion.")
                    End If
                Else
                    FlashAlerts.ShowError("Accion cancelada.")
                End If
            End If
        End If
    End Sub

    Private Sub Dispose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Smk_CableSearchRandom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Item_txt_TextChanged(sender As Object, e As EventArgs) Handles Item_txt.TextChanged
        If Item_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        ElseIf Serial_rb.Checked AndAlso SMK.IsSerialFormat(Item_txt.Text) Then
            Search()
        ElseIf Partnumber_rb.Checked AndAlso SMK.IsRawMaterialFormat(Item_txt.Text) Then
            Search()
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

End Class