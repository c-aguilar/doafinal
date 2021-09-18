Public Class Smk_FindSerialKiosk

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadingScreen.Show()
        Dim status As New ArrayList
        If Receiving_chk.Checked Then status.AddRange({"N", "P"})
        If Random_chk.Checked Then status.Add("S")
        If Service_chk.Checked Then status.AddRange({"O", "C"})
        If Quality_chk.Checked Then status.AddRange({"Q", "U"})
        If Tracker_chk.Checked Then status.Add("T")
        If Empty_chk.Checked Then status.Add("E")
        If Presupermarket_chk.Checked Then status.Add("R")

        Dim serials = SQL.Current.GetDatatable(String.Format("SELECT S.SerialNumber,S.Partnumber,S.OriginalQuantity,S.CurrentQuantity,S.UoM,S.StatusDescription,CASE WHEN S.Status = 'C' THEN dbo.Smk_SerialLastCutterName(S.ID) ELSE S.Location END Location,S.WarehouseName,S.[Date],S.Linklabel,S.RedTag,S.InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled,S.IsSensitive FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE S.Partnumber = '{0}' AND S.[Status] IN ('{1}') ORDER BY S.ID;", Partnumber_txt.Text, String.Join("','", status.ToArray)), "Series")
        Serials_dgv.DataSource = serials
        Dim partnumber As New RawMaterial(Partnumber_txt.Text)
        If partnumber.Exist Then
            Partnumber_lbl.Text = partnumber.Partnumber
            Description_lbl.Text = partnumber.Description
            Type_lbl.Text = partnumber.Type.ToString
            Supplier_lbl.Text = partnumber.SupplierPartnumber
            Location_lbl.Text = RawMaterial.GetServiceLocations(partnumber.Partnumber)
            UoM_lbl.Text = partnumber.UoM.ToString
            Select Case partnumber.Consumption
                Case RawMaterial.ConsumptionType.Total
                    Consumption_lbl.Text = "Directo"
                Case RawMaterial.ConsumptionType.Partial
                    Consumption_lbl.Text = "Parcial"
                Case RawMaterial.ConsumptionType.Obsolete
                    Consumption_lbl.Text = "Obsolete"
                Case RawMaterial.ConsumptionType.Service
                    Consumption_lbl.Text = "Service"
                Case RawMaterial.ConsumptionType.Mixed
                    Consumption_lbl.Text = "Mixto"
                Case RawMaterial.ConsumptionType.CAO
                    Consumption_lbl.Text = "CAO"
            End Select
            Total_lbl.Text = SQL.Current.GetScalar(String.Format("SELECT SUM(dbo.Sys_UnitConversion(Partnumber,UoM,CurrentQuantity,'{2}')) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND [Status] IN ('{1}')", Partnumber_txt.Text, String.Join("','", status.ToArray), partnumber.UoM.ToString))
            If RawMaterial.IsControlled(partnumber.Partnumber) Then
                Controlled_pb.Visible = True
                Controlled_lbl.Visible = True
            Else
                Controlled_pb.Visible = False
                Controlled_lbl.Visible = False
            End If
            If RawMaterial.IsSensitive(partnumber.Partnumber) Then
                Sensitive_lbl.Visible = True
                Sensitive_pb.Visible = True
            Else
                Sensitive_lbl.Visible = False
                Sensitive_pb.Visible = False
            End If

            LoadingScreen.Hide()
        Else
            Total_lbl.Text = ""
            Partnumber_lbl.Text = ""
            Description_lbl.Text = ""
            Type_lbl.Text = ""
            Supplier_lbl.Text = ""
            Location_lbl.Text = ""
            Consumption_lbl.Text = ""
            Controlled_pb.Visible = False
            Controlled_lbl.Visible = False
            Sensitive_lbl.Visible = False
            Sensitive_pb.Visible = False
            LoadingScreen.Hide()
            FlashAlerts.ShowError("No existe el numero de parte.")
        End If

    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        Delta.Export(Serials_dgv.DataSource, Title_lbl.Text)
    End Sub

    Private Sub Smk_FindSerialKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Smk_FindSerial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            Find_btn.PerformClick()
            Partnumber_txt.Clear()
            Partnumber_txt.Focus()
        ElseIf Partnumber_txt.Text.ToUpper = "CLOSE" Then
            Me.Close()
        End If
    End Sub


    Private Sub Smk_FindSerialKiosk_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Partnumber_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
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

    Private Sub Serials_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Serials_dgv.CellFormatting
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
