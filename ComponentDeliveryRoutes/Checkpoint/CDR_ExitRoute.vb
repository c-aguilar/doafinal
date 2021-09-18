Public Class CDR_ExitRoute

    Private Sub CDR_ExitRoute_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Route_txt_Validated(sender As Object, e As EventArgs) Handles Route_txt.Validated
        If Route_txt.Text.Trim <> "" Then
            ReadOption()
        End If
    End Sub

    Private Sub Route_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Route_txt.KeyDown
        If Route_txt.Text.Trim <> "" AndAlso e.KeyCode = Keys.Enter Then
            ReadOption()
        End If
    End Sub

    Private Sub ReadOption()
        Dim scan As String = Route_txt.Text.ToUpper.Trim
        Route_txt.Clear()
        Route_txt.Focus()
        Select Case scan
            Case "CANCEL"
                Me.Close()
            Case Else
                If CDR.Routes.Exists(Function(f) f.Name.ToLower = scan.ToLower) Then
                    Dim route = CDR.Routes.Find(Function(f) f.Name.ToLower = scan.ToLower)
                    If route.Status = CDR.Status.IN Then
                        route.GoOut()
                        FlashAlerts.ShowConfirm("Salida registrada.", , True)
                        Me.Close()
                    Else
                        If route.Started Then
                            FlashAlerts.ShowError("La ruta se encuentra en Manufactura.")
                        Else
                            FlashAlerts.ShowError("La ruta no ha sido iniciada.")
                        End If
                    End If
                Else
                    FlashAlerts.ShowError("Ruta incorrecta.")
                End If
        End Select
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.Close()
    End Sub

    Private Sub CDR_ExitRoute_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CDR_ExitRoute_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Route_txt.Focus()
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class