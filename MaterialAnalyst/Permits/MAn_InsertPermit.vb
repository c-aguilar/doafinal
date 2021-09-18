Imports System.Text.RegularExpressions
Public Class MAn_InsertPermit
    Dim partnumbers As DataTable
    Dim complete As Boolean = False
    Private Sub MAn_InsertPermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        partnumbers = New DataTable
        partnumbers.Columns.Add("Material", GetType(String))
        partnumbers.Columns.Add("Componente Anterior", GetType(String))
        partnumbers.Columns.Add("Componente Nuevo", GetType(String))
        partnumbers.Columns.Add("Cantidad", GetType(Decimal))
        partnumbers.PrimaryKey = {partnumbers.Columns("Material"), partnumbers.Columns("Componente Anterior")}
        Partnumbers_dgv.DataSource = partnumbers

    End Sub

    Private Sub Clean()
        partnumbers.Clear()
        Number_txt.Clear()
        Platform_txt.Clear()
        Originator_txt.Clear()
        Comment_txt.Clear()
        Description_txt.Clear()
        Material_txt.Clear()
        OldPartnumber_txt.Clear()
        NewPartnumber_txt.Clear()
        Errors_rtb.Clear()
        Quantity_nud.Value = 0
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        Try
            If SCH.IsMaterialFormat(Material_txt.Text) AndAlso Harn.Exist(Material_txt.Text) Then
                If SMK.IsRawMaterialFormat(OldPartnumber_txt.Text) AndAlso RawMaterial.Exists(OldPartnumber_txt.Text) Then
                    If SMK.IsRawMaterialFormat(NewPartnumber_txt.Text) AndAlso RawMaterial.Exists(NewPartnumber_txt.Text) Then
                        partnumbers.Rows.Add(Material_txt.Text, OldPartnumber_txt.Text, NewPartnumber_txt.Text, Quantity_nud.Value)
                    Else
                        FlashAlerts.ShowError("El número del Componente Nuevo no existe.")
                    End If
                Else
                    FlashAlerts.ShowError("El número del Componente Anterior no existe.")
                End If
            Else
                FlashAlerts.ShowError("El número de Material no existe.")
            End If
        Catch ex As Exception
            FlashAlerts.ShowError("Error al agregar el registro.")
        End Try
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If Integer.TryParse(Number_txt.Text, Nothing) Then
            If Issue_dtp.Value < Expiration_dtp.Value Then
                If Issue_dtp.Value <= Last_dtp.Value Then
                    If partnumbers.Rows.Count > 0 Then
                        Dim ok_cnt As Integer = 0
                        For Each row As DataRow In partnumbers.Rows
                            If SQL.Current.Insert("MAn_EngineeringPermits", {"Number", "Material", "OldPartnumber", "NewPartnumber", "NewQuantity", "Platform", "Originator", "Description", "[Type]", "IssueDate", "ExpirationDate", "LastAdjustment", "Comment"}, {CInt(Number_txt.Text), row.Item("Material"), row.Item("Componente Anterior"), row.Item("Componente Nuevo"), row.Item("Cantidad"), Platform_txt.Text, Originator_txt.Text, Description_txt.Text, If(Mandatory_rb.Checked, "M", "S"), Issue_dtp.Value, Expiration_dtp.Text, Last_dtp.Value, Comment_txt.Text}) Then
                                ok_cnt += 1
                            End If
                        Next
                        If ok_cnt = partnumbers.Rows.Count Then
                            FlashAlerts.ShowConfirm("Permiso agregado correctamente.")
                        ElseIf ok_cnt = 0 Then
                            FlashAlerts.ShowError("Error al cargar el permiso.")
                        Else
                            FlashAlerts.ShowInformation("Permiso agregado con errores.")
                        End If
                        Clean()
                    Else
                        FlashAlerts.ShowError("Se debe ingresar al menos un número de material y componentes.")
                    End If
                Else
                    FlashAlerts.ShowError("Fecha de último ajuste incorrecta.")
                End If
            Else
                FlashAlerts.ShowError("Fecha de creación y expiración incorrectas.")
            End If
        Else
            FlashAlerts.ShowError("Número de permiso incorrecto.")
        End If
    End Sub

    Private Sub Load_btn_Click(sender As Object, e As EventArgs) Handles Load_btn.Click
        Try
            If IsNumeric(Number_txt.Text) Then
                Dim permit As Integer = CInt(Number_txt.Text)
                LoadingScreen.Show()
                Main_wb.Navigate(New Uri("http://usflmia-ww02/eng/ac2_permit/EditPermit.asp?PermitNum=" & permit))
                Clean()
                Number_txt.Text = permit
                WaitForPageLoad()
                For Each f As HtmlElement In Main_wb.Document.GetElementsByTagName("form")
                    Dim harns As New List(Of String)
                    Dim description As String = ""
                    If f.GetAttribute("name") = "F1" Then 'F1 ES EL FORM DONDE VIENEN LOS DATOS DEL PERMISO
                        Dim table As HtmlElement = f.GetElementsByTagName("table").Item(0) 'LEER LA TABLA PRINCIPAL
                        Dim tr_cnt As Integer = 1
                        For Each tr As HtmlElement In table.GetElementsByTagName("tr") 'LEER TODOS LOS TR
                            Select Case tr_cnt
                                Case 1 'NO DE PERMISO
                                    If Strings.Left(tr.GetElementsByTagName("td").Item(1).OuterText.ToUpper.Trim, 2) = "MP" Then
                                        Mandatory_rb.Checked = True
                                    Else
                                        Standar_rb.Checked = True
                                    End If
                                Case 3 'ISSUE DATE
                                    Issue_dtp.Value = CDate(tr.GetElementsByTagName("td").Item(2).OuterText.ToUpper.Replace("ISSUE DATE:", "").Trim).Date
                                    Last_dtp.Value = Issue_dtp.Value
                                Case 4 'EXPIRATION DATE
                                    Expiration_dtp.Value = CDate(tr.GetElementsByTagName("td").Item(1).OuterText.ToUpper.Replace("EXPIRATION:", "").Trim).Date
                                Case 6 'NUMEROS DE ARNESES
                                    For Each h In tr.GetElementsByTagName("td").Item(0).OuterText.Trim.Replace(" ", "").Split(",").ToList
                                        If Harn.Exist(Harn.Format(h)) Then
                                            harns.Add(Harn.Format(h))
                                        Else
                                            Errors_rtb.Text &= String.Format("Arnes {0} no existe.{1}", h, vbCrLf)
                                        End If
                                    Next
                                Case 7 'PLATAFORMA
                                    Platform_txt.Text = tr.GetElementsByTagName("td").Item(1).OuterText.Replace("Customer:", "").Trim
                                Case 10 'DESCRIPCION
                                    description = tr.GetElementsByTagName("td").Item(0).OuterText.Replace("Description of Variance:", "").Trim
                                    Description_txt.Text = description
                                Case 14
                                    Originator_txt.Text = tr.GetElementsByTagName("td").Item(0).OuterText.Replace("Originator", "").Replace(":", "").Trim.Split(" ").GetValue(0) & " " & _
                                        tr.GetElementsByTagName("td").Item(0).OuterText.Replace("Originator", "").Replace(":", "").Trim.Split(" ").GetValue(1)
                            End Select
                            tr_cnt += 1
                        Next
                        If harns.Count > 0 Then
                            Dim pattern_material As String = "(\b[pe\d]{8}\b)"
                            Dim pattern_pn As String = "((?![A-Za-z]{8})\b[A-Za-z\d]{8}\b)" '@pn EN LOS OTROS PATTERS DEBE SER SUSTITUIDO POR pattern_pn, PARA EIVTAR CONFUSIONES CON LOS PATTERNS
                            Dim patterns As New List(Of PermitPattern)
                            'patterns.Add(New PermitPattern("(?<=For.*)For\s+.*@mat\s+.*from\s+.*@pn\s+.*to\s+.*@pn(?=.*For.*@mat)", False, True, "from\s+.*@pn\s+.*to\s+.*@pn".Replace("@pn", pattern_pn))) 'ESTE PATTERN ES PARA CUANDO HAY UN LISTADO DE 'FORs'
                            'patterns.Add(New PermitPattern("(for\s+.*@mat\s+.*@pn\s+instead\s+of\s+@pn)", True, True, "@pn\s+instead\s+of\s+@pn"))
                            patterns.Add(New PermitPattern("from\s+@pn\s+to\s+@pn", False, False)) 'FALSE INVERSO, EL PRIMER COMPONENTE ES EL ANTIGUO
                            patterns.Add(New PermitPattern("@pn\s+instead\s+of\s+@pn", True, False)) 'TRUE ORDENADO, EL PRIMER COMPONENTE ES EL NUEVO
                            patterns.Add(New PermitPattern("@pn(.*?)to(.*?)@pn", False, False))
                            patterns.Add(New PermitPattern("@pn(.*?)instead\s*of(.*?)@pn", True, False))

                            Dim reg_ex As Regex
                            Dim matches As Match
                            description = description.Replace(vbCrLf, " ")
                            For Each pattern In patterns
                                reg_ex = New Regex(pattern.Pattern.Replace("@pn", pattern_pn).Replace("@mat", pattern_material), RegexOptions.IgnoreCase)
                                matches = reg_ex.Match(description)

                                Do While matches.Success
                                    Dim match_str As String = matches.Value
                                    If pattern.SpecificMaterial Then 'SPECIFICMATERIAL ES CUANDO EL PATTERN ESPECIFICA PARA CUALES ARNESES APLICA EL SUSTITUTO
                                        description = description.Replace(match_str, "") 'AL SER SPECIFICMATERIAL SE DEBE ELIMNAR EL MATCH EL TEXTO ORIGINAL PARA EVITAR DUPLICADOS
                                        For Each parts As Match In Regex.Matches(match_str, pattern.PartnumbersPattern) 'RECORRER TODOS LOS SUSTITUTOS
                                            Dim part1 As String = Regex.Matches(parts.Value, pattern_pn).Item(0).Value
                                            Dim part2 As String = Regex.Matches(parts.Value, pattern_pn).Item(1).Value

                                            If RawMaterial.Exists(part1) AndAlso RawMaterial.Exists(part2) Then
                                                For Each material As Match In Regex.Matches(match_str, pattern_material) 'RECORRER TODOS LOS ARNESES DENTRO DEL MATCH
                                                    If harns.Contains(material.Value) Then 'VALIDAR QUE EL MATCH SEA UN ARNES DEL ENCABEZADO
                                                        If pattern.Sorted Then
                                                            If partnumbers.Rows.Find({material.Value, part2}) Is Nothing Then partnumbers.Rows.Add(material.Value, part2, part1, 0)
                                                        Else
                                                            If partnumbers.Rows.Find({material.Value, part1}) Is Nothing Then partnumbers.Rows.Add(material.Value, part1, part2, 0)
                                                        End If
                                                    End If
                                                Next
                                            ElseIf Not RawMaterial.Exists(part1) Then
                                                Errors_rtb.Text &= String.Format("Componente {0} no existe.{1}", part1, vbCrLf)
                                            Else
                                                Errors_rtb.Text &= String.Format("Componente {0} no existe.{1}", part2, vbCrLf)
                                            End If
                                        Next
                                    Else 'NO SE ESPECIFICA LOS ARNES A LOS QUE EL SUSTITUTO APLICA
                                        Dim part1 As String = Regex.Matches(match_str, pattern_pn).Item(0).Value
                                        Dim part2 As String = Regex.Matches(match_str, pattern_pn).Item(1).Value
                                        If RawMaterial.Exists(part1) AndAlso RawMaterial.Exists(part2) Then
                                            For Each h In harns 'SE RECORREN TODOS LOS ARNESES DEL ENCABEZADO PRINCIPAL
                                                If pattern.Sorted Then
                                                    If partnumbers.Rows.Find({h, part2}) Is Nothing Then partnumbers.Rows.Add(h, part2, part1, 0)
                                                Else
                                                    If partnumbers.Rows.Find({h, part1}) Is Nothing Then partnumbers.Rows.Add(h, part1, part2, 0)
                                                End If
                                            Next
                                        ElseIf Not RawMaterial.Exists(part1) Then
                                            Errors_rtb.Text &= String.Format("Componente {0} no existe.{1}", part1, vbCrLf)
                                        Else
                                            Errors_rtb.Text &= String.Format("Componente {0} no existe.{1}", part2, vbCrLf)
                                        End If
                                    End If
                                    matches = matches.NextMatch()
                                Loop
                            Next
                        End If
                    End If
                Next
                LoadingScreen.Hide()
            End If
        Catch ex As Exception
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Error al obtener la información de la web.")
        End Try
    End Sub

    Private Class PermitPattern
        Public Sub New(pattern As String, sorted As Boolean, specific_material As Boolean, Optional pns_pattern As String = "")
            Me.Pattern = pattern
            Me.Sorted = sorted
            Me.SpecificMaterial = specific_material
            Me.PartnumbersPattern = pns_pattern
        End Sub
        Public Property Pattern As String
        Public Property Sorted As Boolean
        Public Property SpecificMaterial As Boolean
        Public Property PartnumbersPattern As String
    End Class

    Private Sub WaitForPageLoad()
        AddHandler Main_wb.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not complete
            Application.DoEvents()
        End While
        complete = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If Main_wb.ReadyState = WebBrowserReadyState.Complete Then
            complete = True
            RemoveHandler Main_wb.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub

End Class