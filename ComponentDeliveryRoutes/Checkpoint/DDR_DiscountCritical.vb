Public Class DDR_DiscountCritical
    Public Property Badge As String
    Private Sub DDR_DiscountCritical_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CDR_PrintKanban_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Kanban_txt.Text.Trim <> "" Then
            ReadKanban()
        End If
    End Sub

    Private Sub ReadKanban()
        If CDR.IsKanban(Kanban_txt.Text) Then
            Dim kanban As New CDR.Kanban(CDR.KanbanID(Kanban_txt.Text))
            If kanban.Exists Then
                If Not RawMaterial.IsSensitive(kanban.Partnumber) Then
                    Dim current_serial As String = SMK.CurrentSerial(kanban.Partnumber)
                    If current_serial <> "" Then
                        Dim serial As New Serialnumber(current_serial)
                        If kanban.Pieces > 0 Then
                            'piezas convertidas a la unidad de medida de la serie
                            Dim pieces_uom As Decimal = SQL.Current().GetScalar(String.Format("SELECT dbo.Sys_UnitConversion(K.Partnumber,'PC',K.Pieces,S.UoM) FROM CDR_Kanbans AS K INNER JOIN Smk_Serials AS S ON K.ID = {0} AND S.SerialNumber = '{1}';", kanban.ID, serial.SerialNumber))
                            If pieces_uom <= serial.CurrentQuantity Then
                                serial.CriticalBinDiscount(pieces_uom, kanban.ID, Me.Badge)
                            Else
                                serial.CriticalBinDiscount(serial.CurrentQuantity, kanban.ID, Me.Badge)
                            End If
                            Kanban_txt.Clear()
                            Kanban_txt.Focus()
                            FlashAlerts.ShowConfirm("Descuento de critico realizado.")
                        Else
                            Kanban_txt.Clear()
                            Kanban_txt.Focus()
                            MsgBox("La kanban no existe, genera una nueva y descuenta el critico nuevamente.", MsgBoxStyle.Critical)
                            'serial.CriticalBinDiscount(0, kanban.ID, Me.Badge)
                        End If
                    Else
                        FlashAlerts.ShowError("No hay ninguna serie abierta para descontar.")
                    End If
                Else
                    Kanban_txt.Clear()
                    Kanban_txt.Focus()
                    MsgBox("El número de parte es sensitivo, debe realizarse baja parcial en el area.", MsgBoxStyle.Critical)
                End If
            Else
                Kanban_txt.Clear()
                Kanban_txt.Focus()
                MsgBox("La kanban no existe, genera una nueva y descuenta el critico nuevamente.", MsgBoxStyle.Critical)
            End If
        ElseIf Kanban_txt.Text.ToUpper.Trim = "CLOSE" Then
            Kanban_txt.Clear()
            Me.Close()
        Else
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            FlashAlerts.ShowError("Kanban incorrecta.")
        End If
    End Sub

    Private Sub CDR_PrintKanban_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class