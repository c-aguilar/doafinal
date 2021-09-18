Public Class Smk_Kiosk

    Private Sub Smk_Kiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Warehouse_lbl.Text = String.Format("Estación {0}", SQL.Current.GetString("Name", "Smk_Warehouses", "Warehouse", My.Settings.Warehouse, ""))
    End Sub

    Private Sub Smk_Kiosk_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Option_txt.Focus()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        Dim fadeback As New FadeBackground(Smk_FindSerialKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Store_btn_Click(sender As Object, e As EventArgs) Handles Store_btn.Click
        Dim fadeback As New FadeBackground(Smk_StoreSerialKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Change_btn_Click(sender As Object, e As EventArgs) Handles Change_btn.Click
        Dim fadeback As New FadeBackground(Smk_ChangeLocationKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Open_btn_Click(sender As Object, e As EventArgs) Handles Open_btn.Click
        Dim fadeback As New FadeBackground(Smk_OpenSerialKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Partial_btn_Click(sender As Object, e As EventArgs) Handles Partial_btn.Click
        Dim fadeback As New FadeBackground(Smk_PartialDiscountKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Empty_btn_Click(sender As Object, e As EventArgs) Handles Empty_btn.Click
        Dim fadeback As New FadeBackground(Smk_DeclareEmptyKiosk)
        fadeback.ShowDialog()
        Option_txt.Focus()
    End Sub

    Private Sub Option_txt_TextChanged(sender As Object, e As EventArgs) Handles Option_txt.TextChanged
        Dim option_scan As String = Option_txt.Text.ToUpper.Trim
        Select Case option_scan
            Case "EMPTY", "VACIO"
                Dim fadeback As New FadeBackground(Smk_DeclareEmptyKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "FIND", "BUSCAR"
                Dim fadeback As New FadeBackground(Smk_FindSerialKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "OPEN", "ABRIR"
                Dim fadeback As New FadeBackground(Smk_OpenSerialKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "PARTIAL", "PARCIAL"
                Dim fadeback As New FadeBackground(Smk_PartialDiscountKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "CHANGE", "CAMBIO"
                Dim fadeback As New FadeBackground(Smk_ChangeLocationKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case "STORE", "ALTA"
                Dim fadeback As New FadeBackground(Smk_StoreSerialKiosk)
                fadeback.ShowDialog()
                Option_txt.Focus()
                Option_txt.Clear()
            Case Else

        End Select
    End Sub
End Class