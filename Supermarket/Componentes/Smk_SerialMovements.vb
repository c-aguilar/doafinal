Public Class Smk_SerialMovements

    Public Property Serialnumber As String

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub MyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Movements_dgv.MouseDown, ToolStripMain.MouseDown, Title_lbl.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
        Cursor.Current = Cursors.SizeAll
    End Sub
    Private Sub MyMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, Movements_dgv.MouseMove, ToolStripMain.MouseMove, Title_lbl.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub MyMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, Movements_dgv.MouseUp, ToolStripMain.MouseUp, Title_lbl.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Smk_SerialMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = Me.Serialnumber
        Movements_dgv.DataSource = Sql.Current.GetDatatable(String.Format("SELECT D.[Description],M.[Location],M.Quantity,S.UoM ,O.Fullname,M.[Date],T.Posted,T.Quantity+AdjustmentQuantity AS [TransferQuantity],T.FromSloc,T.ToSloc,DocumentNumber,U.Fullname AS [TransferUser] FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username WHERE S.Serialnumber = '{0}' ORDER BY M.[Date] DESC;", Me.Serialnumber), Me.Serialnumber)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        If Movements_dgv.DataSource IsNot Nothing Then
            Dim ed As New ExportDialog
            If ed.ShowDialog = Windows.Forms.DialogResult.OK Then
                Select Case ed.ChoosenFormat
                    Case ExportDialog.Format.Excel
                        If MyExcel.SaveAs(Movements_dgv.DataSource, Title_lbl.Text, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.CSV
                        If CSV.SaveAs(Movements_dgv.DataSource, True) Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                    Case ExportDialog.Format.PDF
                        Dim pdf As New PDF
                        pdf.DataSource = Movements_dgv.DataSource
                        pdf.Title = Title_lbl.Text
                        pdf.Subtitle = Application.ProductName
                        pdf.Orientation = pdf.Orientations.Landscape
                        pdf.PageNumber = True
                        pdf.PageNumberPosition = pdf.Page.Position.BottomCenter
                        If pdf.SaveAs() Then
                            FlashAlerts.ShowConfirm("Exportado.")
                        End If
                        pdf.Dispose()
                End Select
            End If
        End If
    End Sub

    Private Sub Smk_SerialMovements_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub

    Private Sub Smk_SerialMovements_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMain_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripMain.ItemClicked

    End Sub
End Class