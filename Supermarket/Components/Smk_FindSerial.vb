Public Class Smk_FindSerial

    Private Sub Partnumber_txt_Enter(sender As Object, e As EventArgs) Handles Partnumber_txt.Enter
        Partnumber_rb.Checked = True
    End Sub

    Private Sub Serial_txt_Enter(sender As Object, e As EventArgs) Handles Serial_txt.Enter
        Serial_rb.Checked = True
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        If Partnumber_rb.Checked Then
            Dim status As New ArrayList
            If Receiving_chk.Checked Then status.AddRange({"N", "P"})
            If Random_chk.Checked Then status.Add("S")
            If Service_chk.Checked Then status.AddRange({"O", "C"})
            If Empty_chk.Checked Then status.Add("E")
            If Quality_chk.Checked Then status.AddRange({"Q", "U"})
            If Tracker_chk.Checked Then status.Add("T")
            If Cutters_chk.Checked Then status.Add("C")
            If Presupermarket_chk.Checked Then status.Add("R")

            If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
                Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,S.Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,WarehouseName,S.Sloc,S.[Date],CASE WHEN [Status] = 'E' THEN dbo.Smk_SerialEmptyDate(S.ID) ELSE NULL END AS DateEmpty,S.Linklabel,RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE S.Partnumber = '{0}' AND [Status] IN ('{1}') ORDER BY S.ID", Partnumber_txt.Text, String.Join("','", status.ToArray)), "Series")
                Sustitute_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT DISTINCT Number AS Permiso, NewPartnumber AS Sustituto,M.Business AS Negocio,ISNULL(S.Total,0) AS [Inventario Disponible],ISNULL(BuM,'-') AS Unidad FROM MAn_EngineeringPermits AS P INNER JOIN Sch_Materials AS M ON P.Material = M.Material LEFT OUTER JOIN vw_Smk_AvailableStock AS S ON P.NewPartnumber = S.Partnumber WHERE P.OldPartnumber = '{0}' AND P.[Type] = 'S' AND GETDATE() BETWEEN P.IssueDate AND P.ExpirationDate", Partnumber_txt.Text))

                Dim partnumber As New RawMaterial(Partnumber_txt.Text)
                If partnumber.Exist Then
                    Partnumber_lbl.Text = partnumber.Partnumber
                    Description_lbl.Text = partnumber.Description
                    Supplier_lbl.Text = partnumber.SupplierPartnumber
                    Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
                    Owner_lbl.Text = RawMaterial.GetMRPUserFullname(partnumber.Partnumber)
                    Select Case partnumber.Consumption
                        Case RawMaterial.ConsumptionType.Total
                            Consumption_lbl.Text = "Directo"
                        Case RawMaterial.ConsumptionType.Partial
                            Consumption_lbl.Text = "Parcial"
                        Case RawMaterial.ConsumptionType.Obsolete
                            Consumption_lbl.Text = "Obsoleto"
                        Case RawMaterial.ConsumptionType.Service
                            Consumption_lbl.Text = "Service"
                        Case RawMaterial.ConsumptionType.Mixed
                            Consumption_lbl.Text = "Mixto"
                        Case RawMaterial.ConsumptionType.CAO
                            Consumption_lbl.Text = "CAO"
                    End Select
                    Total_lbl.Text = String.Format("{0} {1}", SQL.Current.GetScalar(String.Format("SELECT SUM(CurrentQuantityInBuM) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}')", Partnumber_txt.Text, String.Join("','", status.ToArray))), partnumber.UoM.ToString)
                    If RawMaterial.IsControlled(partnumber.Partnumber) Then
                        Controlled_pb.Visible = True
                        Controlled_lbl.Visible = True
                    Else
                        Controlled_pb.Visible = False
                        Controlled_lbl.Visible = False
                    End If
                    If RawMaterial.IsSensitive(partnumber.Partnumber) Then
                        Sensitive_pb.Visible = True
                        Sensitive_lbl.Visible = True
                    Else
                        Sensitive_pb.Visible = False
                        Sensitive_lbl.Visible = False
                    End If
                Else
                    Total_lbl.Text = ""
                    Partnumber_lbl.Text = ""
                    Description_lbl.Text = ""
                    Supplier_lbl.Text = ""
                    Location_lbl.Text = ""
                    Consumption_lbl.Text = ""
                    Total_lbl.Text = ""
                    Owner_lbl.Text = ""
                    Controlled_pb.Visible = False
                    Controlled_lbl.Visible = False
                    Sensitive_pb.Visible = False
                    Sensitive_lbl.Visible = False
                End If
            ElseIf Partnumber_txt.Text = "" OrElse Partnumber_txt.Text = "*" Then
                Total_lbl.Text = ""
                Partnumber_lbl.Text = ""
                Description_lbl.Text = ""
                Supplier_lbl.Text = ""
                Location_lbl.Text = ""
                Consumption_lbl.Text = ""
                Owner_lbl.Text = ""
                Controlled_pb.Visible = False
                Controlled_lbl.Visible = False
                Sensitive_pb.Visible = False
                Sensitive_lbl.Visible = False
                Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,S.Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,WarehouseName,S.Sloc,S.[Date],CASE WHEN [Status] = 'E' THEN dbo.Smk_SerialEmptyDate(S.ID) ELSE NULL END AS DateEmpty,S.Linklabel,RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE [Status] IN ('{0}') ORDER BY S.ID", String.Join("','", status.ToArray)), "Series")
            Else
                FlashAlerts.ShowInformation("Captura el número de parte completo.")
            End If
        ElseIf Serial_rb.Checked Then
            If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsMasterSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
                Dim partnumber As RawMaterial
                If SMK.IsSerialFormat(Serial_txt.Text) Then
                    Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,S.Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,WarehouseName,S.Sloc,S.[Date],CASE WHEN Status = 'E' THEN dbo.Smk_SerialEmptyDate(S.ID) ELSE NULL END AS DateEmpty,S.Linklabel,RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE SerialNumber = '{0}'", Serial_txt.Text), "Series")
                    partnumber = New RawMaterial(SQL.Current.GetString("Partnumber", "Smk_Serials", "Serialnumber", Serial_txt.Text, ""))
                ElseIf SMK.IsMasterSerialFormat(Serial_txt.Text) Then
                    Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,S.Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,WarehouseName,S.Sloc,S.[Date],CASE WHEN Status = 'E' THEN dbo.Smk_SerialEmptyDate(S.ID) ELSE NULL END AS DateEmpty,S.Linklabel,RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE Masternumber = '{0}'", Serial_txt.Text), "Series")
                    partnumber = New RawMaterial(SQL.Current.GetString("TOP 1 Partnumber", "vw_Smk_Serials", "Masternumber", Serial_txt.Text, ""))
                Else
                    Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,S.Partnumber,[Description],MaterialType,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,WarehouseName,S.Sloc,S.[Date],CASE WHEN Status = 'E' THEN dbo.Smk_SerialEmptyDate(S.ID) ELSE NULL END AS DateEmpty,S.Linklabel,RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE S.Linklabel = '{0}'", Serial_txt.Text), "Series")
                    partnumber = New RawMaterial(SQL.Current.GetString("TOP 1 Partnumber", "vw_Smk_Serials", "Linklabel", Serial_txt.Text, ""))
                End If
                If partnumber.Exist Then
                    Partnumber_lbl.Text = partnumber.Partnumber
                    Description_lbl.Text = partnumber.Description
                    Supplier_lbl.Text = partnumber.SupplierPartnumber
                    Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
                    Owner_lbl.Text = RawMaterial.GetMRPUserFullname(partnumber.Partnumber)
                    Select Case partnumber.Consumption
                        Case RawMaterial.ConsumptionType.Total
                            Consumption_lbl.Text = "Directo"
                        Case RawMaterial.ConsumptionType.Partial
                            Consumption_lbl.Text = "Parcial"
                        Case RawMaterial.ConsumptionType.Service
                            Consumption_lbl.Text = "Servicio"
                        Case RawMaterial.ConsumptionType.Obsolete
                            Consumption_lbl.Text = "Obsoleto"
                        Case RawMaterial.ConsumptionType.Mixed
                            Consumption_lbl.Text = "Mixto"
                        Case RawMaterial.ConsumptionType.CAO
                            Consumption_lbl.Text = "CAO"
                    End Select
                    If RawMaterial.IsControlled(partnumber.Partnumber) Then
                        Controlled_pb.Visible = True
                        Controlled_lbl.Visible = True
                    Else
                        Controlled_pb.Visible = False
                        Controlled_lbl.Visible = False
                    End If

                    If RawMaterial.IsSensitive(partnumber.Partnumber) Then
                        Sensitive_pb.Visible = True
                        Sensitive_lbl.Visible = True
                    Else
                        Sensitive_pb.Visible = False
                        Sensitive_lbl.Visible = False
                    End If
                Else
                    Total_lbl.Text = ""
                    Partnumber_lbl.Text = ""
                    Description_lbl.Text = ""
                    Supplier_lbl.Text = ""
                    Location_lbl.Text = ""
                    Consumption_lbl.Text = ""
                    Owner_lbl.Text = ""
                    Controlled_pb.Visible = False
                    Controlled_lbl.Visible = False
                    Sensitive_pb.Visible = False
                    Sensitive_lbl.Visible = False
                End If
            Else
                FlashAlerts.ShowInformation("Captura el número de serie completo.")
            End If
        End If
        LoadingScreen.Hide()
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(Serials_dgv.DataSource, Title_lbl.Text)
    End Sub

    Private Sub Smk_FindSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Serial_txt.Clear()
        Serial_txt.Focus()
        CType(Serials_dgv.Columns("details_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.question_16
    End Sub

    Private Sub Smk_FindSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            Find_btn.PerformClick()
        End If
    End Sub

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsMasterSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            Find_btn.PerformClick()
        End If
    End Sub

    Private Sub Serials_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Serials_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("details_btn").Index Then
            Dim sm As New Smk_SerialMovements
            sm.Serialnumber = Serials_dgv.Rows(e.RowIndex).Cells("Serialnumber").Value
            sm.Show()
        End If
    End Sub

    Private Sub Serials_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Serials_dgv.CellPainting
        'HEADERS
        If e.RowIndex = -1 AndAlso e.ColumnIndex = Serials_dgv.Columns("InvoiceTrouble").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.warning_16, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Serials_dgv.Columns("RedTag").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.shield, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Serials_dgv.Columns("Controlled").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.battery_low, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Serials_dgv.Columns("Sensitive").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.radioactivity, rect)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Serials_dgv.Columns("Linklabel").Index Then
            Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
            e.Graphics.DrawImage(My.Resources.link_16, rect)
            e.Handled = True
        End If
        'CELLS
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("InvoiceTrouble").Index Then
            If CBool(Serials_dgv.Rows(e.RowIndex).Cells("InvoiceTrouble").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.warning_16, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("RedTag").Index Then
            If CBool(Serials_dgv.Rows(e.RowIndex).Cells("RedTag").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.shield, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("Controlled").Index Then
            If CBool(Serials_dgv.Rows(e.RowIndex).Cells("Controlled").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.battery_low, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("Sensitive").Index Then
            If CBool(Serials_dgv.Rows(e.RowIndex).Cells("Sensitive").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.radioactivity, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("Linklabel").Index Then
            If Not IsDBNull(Serials_dgv.Rows(e.RowIndex).Cells("Linklabel").Value) Then
                Dim rect As New System.Drawing.Rectangle(e.CellBounds.Right - 16 - ((e.CellBounds.Width - 16) / 2), e.CellBounds.Bottom - 16 - ((e.CellBounds.Height - 16) / 2), 16, 16)
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Graphics.DrawImage(My.Resources.link_16, rect)
                e.Handled = True
            Else
                If e.State = DataGridViewElementStates.Selected Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.SelectionBackground)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                Else
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub News_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Serials_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("InvoiceTrouble").Index AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("InvoiceTrouble").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(69, 179, 157)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("RedTag").Index AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("RedTag").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(120, 69, 103)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("Controlled").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(247, 220, 111)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("Sensitive").Index AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("Sensitive").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(255, 217, 156)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("Linklabel").Index AndAlso Not IsDBNull(Serials_dgv.Rows(e.RowIndex).Cells("Linklabel").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(255, 153, 51)
        End If
    End Sub
End Class