Imports System.Runtime.InteropServices
Public Class CR_ActiveRawMaterialSerials
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Dim is_closing As Boolean = True

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStripMain.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Public Property Partnumber As String
    Public Property DefaultLocation As Point
    Private Sub Smk_SerialMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = Me.Partnumber
        Serials_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT SerialNumber,OriginalQuantity,CurrentQuantity,UoM,StatusDescription,Location,WarehouseName,S.[Date],RedTag,InvoiceTrouble,CONVERT(BIT,CASE WHEN C.ID IS NULL THEN 0 ELSE 1 END) AS Controlled FROM vw_Smk_Serials AS S LEFT OUTER JOIN Rec_ControlledPartnumbers AS C ON S.Partnumber = C.Partnumber AND C.[Active] = 1 WHERE S.Partnumber = '{0}' AND S.[Status] NOT IN ('E','D') ORDER BY S.ID;", Me.Partnumber), "Series")
        Me.Location = Me.DefaultLocation
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        is_closing = False
        Delta.Export(Serials_dgv.DataSource, Title_lbl.Text)
        is_closing = True
    End Sub

    Private Sub Smk_SerialMovements_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If is_closing AndAlso Not Serials_dgv.Focused Then Me.Close()
    End Sub

    Private Sub Smk_SerialMovements_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Serials_dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Serials_dgv.CellPainting
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
        End If

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
        End If
    End Sub

    Private Sub Serials_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Serials_dgv.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("InvoiceTrouble").Index AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("InvoiceTrouble").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(69, 179, 157)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = Serials_dgv.Columns("RedTag").Index AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("RedTag").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(120, 69, 103)
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso CBool(Serials_dgv.Rows(e.RowIndex).Cells("Controlled").Value) Then
            e.CellStyle.BackColor = Color.FromArgb(247, 220, 111)
        End If
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class