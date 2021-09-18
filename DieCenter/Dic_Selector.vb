Public Class Dic_Selector
    Dim Options As DataTable
    Dim deliver As Boolean = False
    Private Sub Dic_Selector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Option_txt.Focus()
        LoadOptions()
    End Sub

    Private Sub LoadOptions()
        Options = SQL.Current.GetDatatable(String.Format("SELECT '*' + DieCenter + '*' AS Code,DieCenter AS Name FROM DiC_Centers WHERE Warehouse = '{0}' AND Active = 1;", My.Settings.Warehouse))
        deliver = SQL.Current.Exists("DiC_Centers", {"Warehouse", "WithinTerminals", "Active"}, {My.Settings.Warehouse, 1, 1})
        If deliver Then Options.Rows.Add("*Entregar*", "Entregar")
        Picklist_dgv.DataSource = Options
    End Sub

    Private Sub Option_txt_Validated(sender As Object, e As EventArgs) Handles Option_txt.Validated
        If Option_txt.Text <> "" Then
            ReadOption()
        End If
    End Sub

    Private Sub Option_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Option_txt.KeyDown
        If Option_txt.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            ReadOption()
        End If
    End Sub

    Private Sub ReadOption()
        Select Case Option_txt.Text.ToUpper
            Case "ENTREGAR"
                If deliver Then
                    Dim background As New FadeBackground()
                    Dim deliv As New DiC_DeliverTerminal
                    background.Show()
                    deliv.ShowDialog()
                    background.Close()
                    background.Dispose()
                    Option_txt.Clear()
                    Option_txt.Focus()
                Else
                    Option_txt.Clear()
                    Option_txt.Focus()
                    FlashAlerts.ShowError("Opción incorrecta.")
                End If
            Case Else
                If Options.Compute("COUNT(Name)", String.Format("Name = '{0}'", Option_txt.Text)) = 1 Then
                    Dim background As New FadeBackground()
                    Dim pick As New DiC_Picklist
                    pick.DieCenter = StrConv(Option_txt.Text, VbStrConv.ProperCase)
                    pick.AutoCloseForm = True
                    background.Show()
                    pick.ShowDialog()
                    background.Close()
                    background.Dispose()
                    Option_txt.Clear()
                    Option_txt.Focus()
                Else
                    Option_txt.Clear()
                    Option_txt.Focus()
                    FlashAlerts.ShowError("Opción incorrecta.")
                End If
        End Select
    End Sub

    Private Sub Dic_Selector_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class