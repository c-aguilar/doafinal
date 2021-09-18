Public Class Ord_PrintMover
    Private Sub Ord_PrintMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = SQL.Current.GetDatatable("SELECT [FullName],U.Username FROM Sys_Users AS U INNER JOIN (SELECT DISTINCT Username FROM Ord_Movers) AS M ON U.Username = M.Username ")
        GF.FillCombobox(Username_cbo, users, "Fullname", "Username")
        If users.Compute("COUNT(Username)", String.Format("Username = '{0}'", User.Current.Username)) > 0 Then
            Username_cbo.SelectedValue = User.Current.Username
        Else
            Username_cbo.SelectedValue = "*"
        End If
        CType(Movers_dgv.Columns("print_btn"), DataGridViewImprovedButtonColumn).DefaultImage = My.Resources.printer_16
    End Sub

    Private Sub LoadMovers()
        Dim movers As DataTable
        If ID_rb.Checked AndAlso IsNumeric(ID_txt.Text) Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.ID = {0};", ID_txt.Text))
            Movers_dgv.DataSource = movers
        ElseIf Username_rb.Checked Then
            movers = SQL.Current.GetDatatable(String.Format("SELECT ID,Fullname, Requisitor, Customer, Partnumbers, T.[Description], Locality, [Date] FROM Ord_Movers AS M INNER JOIN Sys_Users AS U ON M.Username = U.Username INNER JOIN Ord_MoverTypes AS T ON M.[Type] = T.[Type] INNER JOIN (SELECT MoverID,COUNT(*) AS Partnumbers FROM Ord_MoverPartnumbers GROUP BY MoverID) AS P ON M.ID = P.MoverID WHERE M.Status IN ('{0}','{1}','{2}') AND M.Username = '{3}';", If(Approved_chk.Checked, "A", ""), If(PickedUp_chk.Checked, "P", ""), If(Shipped_chk.Checked, "S", ""), Username_cbo.SelectedValue))
            Movers_dgv.DataSource = movers
        End If
    End Sub

    Private Sub Movers_dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Movers_dgv.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Movers_dgv.Columns("print_btn").Index Then
            Dim filename As String = GF.TempPDFPath
            Dim mover As Hashtable = SQL.Current.GetRecord("Ord_Movers", "ID", Movers_dgv.Rows(e.RowIndex).Cells("id").Value)
            Dim user_authorization As String = SQL.Current.GetString("FullName", "Sys_Users", "Username", mover("approvalusername"), "")
            Dim type As String = SQL.Current.GetString("[Description]", "Ord_MoverTypes", "[Type]", mover("type"), "")

            Dim pdf As New PDF
            pdf.Title = String.Format("Mover de Material | ID {0}", mover("id"))
            pdf.TitleFontSize = 14
            pdf.Subtitle = String.Format("Planta: {7}{0}Autorizado por: {1}{0}Fecha: {2}{0}Destino: {3}{0}Requisitor: {4}{0}Tipo: {5}{0}Comentario: {6}", vbCrLf, user_authorization, mover("date"), mover("locality"), mover("requisitor"), type, mover("comment"), Parameter("SYS_PlantCode"))
            pdf.Footer = String.Format("Mover de Material | ID {0} | Planta {1}", mover("id"), Parameter("SYS_PlantCode"))
            pdf.PageNumber = True
            pdf.Logo = New PDF.Logotype()
            pdf.Logo.Image = My.Resources.APTIV
            pdf.Logo.Alignment = CAguilar.PDF.Page.Align.Right
            pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
            pdf.DataSource = SQL.Current.GetDatatable(String.Format("SELECT M.[Partnumber] AS Material,ISNULL([Description],'') AS Descripcion,CASE WHEN M.UoM = 'PC' THEN LEFT(CONVERT(VARCHAR(10),[Quantity]),LEN(CONVERT(VARCHAR(10),[Quantity]))-4) ELSE CONVERT(VARCHAR(10),[Quantity]) END AS Cantidad, M.[UoM] AS Unidad,[TSA] AS TSA,ISNULL(dbo.Smk_Locations(M.[Partnumber]),'') AS [Localizacion] FROM Ord_MoverPartnumbers AS M LEFT OUTER JOIN Sys_RawMaterial AS R ON M.Partnumber = R.Partnumber WHERE MoverID = {0} ORDER BY ISNULL(dbo.Smk_Locations(M.[Partnumber]),'');", mover("id")))
            pdf.HeaderFontSize = 10
            pdf.CellFontSize = 11
            pdf.ColumnsWidths = {15, 25, 15, 15, 15, 15}
            If pdf.Save(filename) Then
                Dim viewer As New PDFViewer
                viewer.Filename = filename
                viewer.ShowDialog()
                viewer.Dispose()
                TryDelete(filename)
            Else
                FlashAlerts.ShowError("Error al imprimir mover.")
            End If
        End If
    End Sub

    Private Sub Approved_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Shipped_chk.CheckedChanged, PickedUp_chk.CheckedChanged, Approved_chk.CheckedChanged
        LoadMovers()
    End Sub

    Private Sub Find_btn_Click(sender As Object, e As EventArgs) Handles Find_btn.Click
        LoadMovers()
    End Sub

    Private Sub ID_txt_Enter(sender As Object, e As EventArgs) Handles ID_txt.Enter
        ID_rb.Checked = True
    End Sub

    Private Sub Username_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Username_cbo.SelectionChangeCommitted
        Username_rb.Checked = True
    End Sub

    Private Sub Ord_PrintMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class