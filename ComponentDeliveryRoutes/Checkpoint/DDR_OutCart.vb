Public Class DDR_OutCart
    Public Property CartID As String
    Private Sub DDR_InCollecting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CartID <> "" Then
            Cart_txt.Text = CartID
            Badge_txt.Focus()
        End If
    End Sub

    Private Sub Cart_txt_Validated(sender As Object, e As EventArgs) Handles Cart_txt.Validated
        If Cart_txt.Text.Trim <> "" Then
            ReadCart()
        End If
    End Sub

    Private Sub Cart_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Cart_txt.KeyDown
        If Cart_txt.Text.Trim <> "" AndAlso e.KeyCode = Keys.Enter Then
            ReadCart()
        End If
    End Sub

    Private Sub Badge_txt_Validated(sender As Object, e As EventArgs) Handles Badge_txt.Validated
        If Badge_txt.Text.Trim <> "" Then
            ReadBadge()
        End If
    End Sub

    Private Sub Badge_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Badge_txt.KeyDown
        If Badge_txt.Text.Trim <> "" AndAlso e.KeyCode = Keys.Enter Then
            ReadBadge()
        End If
    End Sub

    Private Sub ReadCart()
        Dim option_scan As String = Cart_txt.Text.ToUpper.Trim
        Select Case option_scan
            Case "CANCEL"
                Me.Close()
            Case Else
                If CDR.Carts.Exists(Function(f) f.ID.ToLower = option_scan.ToLower) Then
                    Dim cart As CDR.Cart = CDR.Carts.Find(Function(f) f.ID.ToLower = option_scan.ToLower)
                    cart.Refresh()
                    If cart.Status = CDR.Status.WaitingDelivery Then
                        CartID = cart.ID.ToLower
                        Badge_txt.Clear()
                        Badge_txt.Focus()
                    Else
                        CartID = ""
                        Cart_txt.Clear()
                        Cart_txt.Focus()
                        FlashAlerts.ShowError("El carro no se encuentra surtido.", 1, True)
                    End If
                Else
                End If
        End Select
    End Sub
    Private Sub ReadBadge()
        If Badge_txt.Text.ToUpper = "CANCEL" Then
            Me.Close()
        Else
            If CartID = "" Then
                Cart_txt.Clear()
                Cart_txt.Focus()
                Exit Sub
            End If
            If SQL.Current.Exists(String.Format("SELECT Badge FROM Smk_Operators WHERE Badge = '{0}' AND Active = 1 AND Area IN ('SMK','REC','CDR')", Strings.Right(Badge_txt.Text, Parameter("SYS_BadgeLength", 9)))) Then
                Dim badge As String = Strings.Right(Badge_txt.Text, Parameter("SYS_BadgeLength", 9))
                'CERRAR LA ULTIMA VUELTA
                Dim cart As CDR.Cart = CDR.Carts.Find(Function(f) f.ID.ToLower = CartID)
                SQL.Current.Execute(String.Format("UPDATE DDR_CartsLoopRegister SET DeliveringBadge = '{1}', DeliveryDate = GETDATE(), [Status] = 'D' WHERE ID = {0}", cart.CurrentLoopID, badge))
                cart.Refresh()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Badge_txt.Clear()
                Badge_txt.Focus()
                FlashAlerts.ShowError("Gafete no registrado.")
            End If
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.Close()
    End Sub

    Private Sub CDR_ExitRoute_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CDR_ExitRoute_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CartID <> "" Then
            Badge_txt.Focus()
        Else
            Cart_txt.Focus()
        End If
    End Sub
End Class