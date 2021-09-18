Public Class Smk_CableSearchService
    Private Sub Partnumber_rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Partnumber_rb.CheckedChanged
        If Partnumber_rb.Checked Then
            Item_txt.WaterMarkText = "Escriba el numero de parte..."
            Item_txt.Clear()
            Item_txt.Focus()
        Else
            Item_txt.WaterMarkText = "Escriba el numero de serie..."
            Item_txt.Clear()
            Item_txt.Focus()
        End If
    End Sub

    Private Sub Smk_CableSearchService_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Item_txt.Focus()
    End Sub

    Private Sub Smk_CableSearchService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Smk_CableSearchService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CType(Smk_dgv.Columns("print_smk_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
        CType(Cutters_dgv.Columns("print_cutter_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
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

    Private Sub Search()
        If Item_txt.Text <> "" Then
            If Partnumber_rb.Checked Then
                Smk_dgv.DataSource = SQL.Current.GetDatatable({"Serialnumber,Partnumber,Description,OriginalQuantity,CurrentQuantity,UoM,Container,Location,dbo.Smk_SerialLastMovementDate(ID,'TSE') AS LastMovement,WarehouseName"}, "vw_Smk_Serials", {"Partnumber", "Status"}, {Item_txt.Text, "O"})
                Cutters_dgv.DataSource = SQL.Current.GetDatatable({"Serialnumber,Partnumber,Description,OriginalQuantity,CurrentQuantity,UoM,Container,WarehouseName,dbo.Smk_SerialLastCutterName(ID) AS CutterName,ROUND(DATEDIFF(MINUTE,dbo.Smk_SerialLastCutterDate(ID),GETDATE())/60,1) AS Hours"}, "vw_Smk_Serials", {"Partnumber", "Status"}, {Item_txt.Text, "C"})
                RefreshMaximus(Item_txt.Text)
                Local_lbl.Text = RawMaterial.GetServiceLocations(Item_txt.Text)
                If RawMaterial.IsControlled(Item_txt.Text) Then
                    Controlled_pb.Visible = True
                    Controlled_lbl.Visible = True
                Else
                    Controlled_pb.Visible = False
                    Controlled_lbl.Visible = False
                End If
                Item_txt.Clear()
                Item_txt.Focus()
            Else
                Dim serial As New Serialnumber(Item_txt.Text)
                Smk_dgv.DataSource = SQL.Current.GetDatatable({"Serialnumber,Partnumber,Description,OriginalQuantity,CurrentQuantity,UoM,Container,Location,dbo.Smk_SerialLastMovementDate(ID,'TSE') AS LastMovement,WarehouseName"}, "vw_Smk_Serials", {"ID", "Status"}, {serial.ID, "O"})
                Cutters_dgv.DataSource = SQL.Current.GetDatatable({"Serialnumber,Partnumber,Description,OriginalQuantity,CurrentQuantity,UoM,Container,WarehouseName,dbo.Smk_SerialLastCutterName(ID) AS CutterName,ROUND(DATEDIFF(MINUTE,dbo.Smk_SerialLastCutterDate(ID),GETDATE())/60,1) AS Hours"}, "vw_Smk_Serials", {"ID", "Status"}, {serial.ID, "C"})
                RefreshMaximus(serial.Partnumber)
                Local_lbl.Text = RawMaterial.GetServiceLocations(serial.Partnumber)
                If RawMaterial.IsControlled(serial.Partnumber) Then
                    Controlled_pb.Visible = True
                    Controlled_lbl.Visible = True
                Else
                    Controlled_pb.Visible = False
                    Controlled_lbl.Visible = False
                End If
                Item_txt.Clear()
                Item_txt.Focus()
                If serial.Exists Then
                    Select Case serial.Status
                        Case Serialnumber.SerialStatus.Stored
                            FlashAlerts.ShowError("La serie esta en reserva.")
                        Case Serialnumber.SerialStatus.Empty
                            FlashAlerts.ShowError("Serie declarada vacia.")
                        Case Serialnumber.SerialStatus.New, Serialnumber.SerialStatus.Pending, Serialnumber.SerialStatus.Presupermarket
                            FlashAlerts.ShowError("La serie no ha sido dada de alta.")
                    End Select
                Else
                    FlashAlerts.ShowError("La serie no existe.")
                End If
            End If
        End If
    End Sub

    Private Sub RefreshMaximus(partnumber As String)
        Max_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT W.Name AS Estacion,M.Maximum AS Maximo,ISNULL(C.Cnt,0) AS [Actual] FROM Smk_Map AS M INNER JOIN Smk_Warehouses AS W ON M.Warehouse = W.Warehouse LEFT OUTER JOIN (SELECT Partnumber,COUNT(ID) AS Cnt FROM Smk_Serials WHERE Status IN ('O','C') AND [New] = 1 GROUP BY Partnumber) AS C ON M.Partnumber = C.Partnumber WHERE M.Partnumber = '{0}';", partnumber))
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Smk_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Smk_dgv.CellContentClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = Smk_dgv.Columns("print_smk_btn").Index Then
            REC.PrintLabel(Smk_dgv("Serialnumber_smk", e.RowIndex).Value)
            FlashAlerts.ShowConfirm("Impresion enviada.")
        End If
    End Sub

    Private Sub Cutters_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Cutters_dgv.CellContentClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = Cutters_dgv.Columns("print_cutter_btn").Index Then
            REC.PrintLabel(Cutters_dgv("Serialnumber_cutter", e.RowIndex).Value)
            FlashAlerts.ShowConfirm("Impresion enviada.")
        End If
    End Sub
End Class