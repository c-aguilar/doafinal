Public Class Ord_NewMover
    Dim partnumbers As DataTable
    Dim types As DataTable
    Dim mover_approved As Boolean = False
    Private Sub Ord_NewMover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        partnumbers = New DataTable
        partnumbers.Columns.Add("Partnumber")
        partnumbers.Columns.Add("Quantity", GetType(Decimal))
        partnumbers.Columns.Add("UoM")
        partnumbers.Columns.Add("TSA")
        partnumbers.PrimaryKey = {partnumbers.Columns("Partnumber")}
        Partnumbers_dgv.DataSource = partnumbers

        types = SQL.Current.GetDatatable("SELECT * FROM Ord_MoverTypes")
        types.PrimaryKey = {types.Columns("Type")}
        GF.FillCombobox(Type_cbo, types, "Description", "Type")
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Partnumber_txt.MaskCompleted Then
            Dim partnumber As DataRow = partnumbers.Rows.Find(Partnumber_txt.Text)
            If partnumber IsNot Nothing Then
                partnumber.Item("Quantity") = If(UOM_cbo.SelectedItem = "PC", CInt(Quantity_nud.Value), CDec(Quantity_nud.Value))
                partnumber.Item("UoM") = UOM_cbo.SelectedItem
                partnumber.Item("TSA") = TSA_txt.Text
            Else
                partnumbers.Rows.Add(Partnumber_txt.Text, If(UOM_cbo.SelectedItem = "PC", CInt(Quantity_nud.Value), CDec(Quantity_nud.Value)), UOM_cbo.SelectedItem, TSA_txt.Text)
            End If
            Partnumber_txt.Clear()
            Quantity_nud.Value = 1
            UOM_cbo.SelectedItem = "PC"
            TSA_txt.Clear()
            Partnumber_txt.Focus()
        Else
            FlashAlerts.ShowInformation("El numero de parte debe contener 8 caracteres.")
        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        mover_approved = False
        If partnumbers.Rows.Count > 0 Then
            If Requisitor_txt.Text.Trim <> "" AndAlso Customer_txt.Text.Trim <> "" AndAlso Type_cbo.SelectedItem IsNot Nothing AndAlso Reason_txt.Text.Trim <> "" AndAlso Comment_txt.Text.Trim <> "" AndAlso Locality_txt.Text.Trim <> "" Then
                Dim autoapproval As Boolean = types.Rows.Find(Type_cbo.SelectedValue).Item("AutoApproval")
                If (autoapproval OrElse User.Current.HasPermission("Ordering_Movers_AutomaticApprovement_flag")) Then
                    If SQL.Current.Insert("Ord_Movers", {"Username", "Requisitor", "Customer", "[Type]", "Reason", "Comment", "Locality", "[Status]", "ApprovalUsername"}, {User.Current.Username, Requisitor_txt.Text, Customer_txt.Text, Type_cbo.SelectedValue, Reason_txt.Text, Comment_txt.Text, Locality_txt.Text, "A", User.Current.Username}) Then
                        mover_approved = True
                        BulkPartnumbers()
                    Else
                        FlashAlerts.ShowError("Error al crear el mover.")
                    End If
                ElseIf Not SQL.Current.Insert("Ord_Movers", {"Username", "Requisitor", "Customer", "[Type]", "Reason", "Comment", "Locality", "[Status]"}, {User.Current.Username, Requisitor_txt.Text, Customer_txt.Text, Type_cbo.SelectedValue, Reason_txt.Text, Comment_txt.Text, Locality_txt.Text, "N"}) Then
                    FlashAlerts.ShowError("Error al crear el mover.")
                Else
                    BulkPartnumbers()
                End If
            Else
                FlashAlerts.ShowError("Todos los campos son requeridos.")
            End If
        Else
            FlashAlerts.ShowError("No hay ningun numero de parte agregado.")
        End If
    End Sub

    Private Sub BulkPartnumbers()
        Dim id As Integer = SQL.Current.GetScalar("MAX(ID)", "Ord_Movers", "Username", User.Current.Username)
        Dim dt_bulk As New DataTable
        dt_bulk.Columns.Add("ID", GetType(Integer))
        dt_bulk.Columns("ID").DefaultValue = id
        dt_bulk.Merge(partnumbers)
        If SQL.Current.Bulk(dt_bulk, "Ord_MoverPartnumbers") Then
            Requisitor_txt.Clear()
            Customer_txt.Clear()
            Type_cbo.SelectedIndex = -1
            Reason_txt.Clear()
            Comment_txt.Clear()
            Locality_txt.Clear()
            partnumbers.Clear()
            FlashAlerts.ShowConfirm("Mover creado: " & id, 3)
            If mover_approved Then
                Dim filename As String = GF.TempPDFPath
                Dim mover As Hashtable = SQL.Current.GetRecord("Ord_Movers", "ID", id)
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

        Else
            SQL.Current.Delete("Ord_Movers", "ID", id)
            FlashAlerts.ShowError("Error al guardar numeros de parte.")
        End If
    End Sub

    Private Sub Paste_btn_Click(sender As Object, e As EventArgs) Handles Paste_btn.Click
        Dim clipboard As DataTable = DTable.FromClipboard()
        If clipboard.Columns.Count >= 4 Then
            For Each c As DataRow In clipboard.Rows
                If {"PZ", "PCS", "PIEZAS", "PIECES"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "PC"
                End If
                If {"MT", "MTS", "METROS", "METERS"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "M"
                End If
                If {"FTS", "FEET", "PIES", "PIE"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "FT"
                End If
                If {"KGS", "KILOS", "KILO"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "KG"
                End If
                If {"LBS", "LIBRAS", "LIBRA"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "LB"
                End If
                If {"LT", "LTS", "LITROS", "LITRO", "LITERS"}.Contains(c.Item(2).ToString.ToUpper) Then
                    c.Item(2) = "L"
                End If

                If {"PC", "M", "FT", "L", "KG", "LB"}.Contains(c.Item(2).ToString.ToUpper) Then
                    Dim partnumber As DataRow = partnumbers.Rows.Find(Strings.Right("00000000" & c.Item(0), 8))
                    If partnumber IsNot Nothing Then
                        partnumber.Item("Quantity") = If(c.Item(2).ToString.ToUpper = "PC", CInt(c.Item(1)), CDec(c.Item(1)))
                        partnumber.Item("UoM") = c.Item(2)
                        partnumber.Item("TSA") = c.Item(3)
                    Else
                        Dim pn As New RawMaterial(Strings.Right("00000000" & c.Item(0), 8))
                        If pn.Exist Then
                            Select Case pn.UoM
                                Case RawMaterial.UnitOfMeasure.PC
                                    partnumbers.Rows.Add(pn.Partnumber, CInt(c.Item(1)), pn.UoM.ToString, c.Item(3))
                                Case RawMaterial.UnitOfMeasure.M, RawMaterial.UnitOfMeasure.FT
                                    partnumbers.Rows.Add(pn.Partnumber, CDec(c.Item(1)), IIf({"M", "FT"}.Contains(c.Item(2).ToString.ToUpper), c.Item(2).ToString.ToUpper, pn.UoM.ToString), c.Item(3))
                                Case RawMaterial.UnitOfMeasure.LB, RawMaterial.UnitOfMeasure.KG
                                    partnumbers.Rows.Add(pn.Partnumber, CDec(c.Item(1)), IIf({"LB", "KG"}.Contains(c.Item(2).ToString.ToUpper), c.Item(2).ToString.ToUpper, pn.UoM.ToString), c.Item(3))
                                Case RawMaterial.UnitOfMeasure.L
                                    partnumbers.Rows.Add(pn.Partnumber, CDec(c.Item(1)), pn.UoM.ToString, c.Item(3))
                            End Select
                        Else
                            FlashAlerts.ShowError("No existe el numero de parte " & pn.Partnumber)
                        End If
                    End If
                Else
                    FlashAlerts.ShowError("Unidad de medida incorrecta.")
                End If
            Next
        Else
            FlashAlerts.ShowError("No hay nada en el portapapeles.")
        End If
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If Partnumber_txt.MaskCompleted Then
            Quantity_nud.Focus()
        End If
    End Sub

    Private Sub Partnumber_txt_Validated(sender As Object, e As EventArgs) Handles Partnumber_txt.Validated
        If Partnumber_txt.MaskCompleted Then
            Dim partnumber As New RawMaterial(Partnumber_txt.Text)
            If partnumber.Exist Then
                Description_txt.Text = partnumber.Description
                UOM_cbo.SelectedItem = partnumber.UoM.ToString
                If partnumber.UoM = RawMaterial.UnitOfMeasure.PC Then
                    Quantity_nud.DecimalPlaces = 0
                Else
                    Quantity_nud.DecimalPlaces = 3
                End If
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowError("No existe el numero de parte.")
            End If
        End If
    End Sub

    Private Sub ToolStripMain_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripMain.ItemClicked

    End Sub

    Private Sub Ord_NewMover_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class