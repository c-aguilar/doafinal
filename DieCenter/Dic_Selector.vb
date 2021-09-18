Public Class Dic_Selector
    Public Property Warehouse As String
    Dim DieCenters As ArrayList
    Dim Options As DataTable
    Private Sub Dic_Selector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Warehouse = "" Then
            Me.Warehouse = SQL.Current.GetString("Warehouse", "Dic_AuthorizedCheckpoints", "MachineName", Environment.MachineName, "")
        End If
        DieCenters = SQL.Current.GetList("DieCenter", "DiC_Centers", {"Warehouse"}, {Me.Warehouse})
        Option_txt.Focus()
        LoadOptions()
    End Sub

    Private Sub LoadOptions()
        Options = SQL.Current.GetDatatable(String.Format("SELECT '*' + DieCenter + '*' AS Code,DieCenter AS Name FROM DiC_Centers WHERE Warehouse = '{0}';", Me.Warehouse))
        Options.Rows.Add("*Entregar*", "Entregar")
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
                Dim background As New FadeBackground()
                Dim deliv As New DiC_DeliverTerminal
                deliv.Warehouse = Me.Warehouse
                background.Show()
                deliv.ShowDialog()
                background.Close()
                background.Dispose()
                Option_txt.Clear()
                Option_txt.Focus()
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
                    FlashAlerts.ShowError("Opcion incorrecta.")
                End If
        End Select
    End Sub

    Private Sub Dic_Selector_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class