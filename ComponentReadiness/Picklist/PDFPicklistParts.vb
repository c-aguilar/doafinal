Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.Font
Imports System.IO
Imports CAguilar
Public Class PDFPicklistParts : Implements IDisposable
    Dim _title, _subtitle, _header, _footer As String
    Dim _filename As String = ""
    Dim _page_number As Boolean = False
    Dim _width As Integer
    Dim _size As Size
    Dim _rotation As Orientations
    Dim data As DataTable = Nothing
    Dim _header_align As Page.Align
    Dim _footer_align As Page.Align
    Dim _pagenumber_position As Page.Position
    Dim _columns_widths() As Single = Nothing

    Public Sub New(id As Integer)
        Me.ID = id
        _title = ""
        _subtitle = ""
        _header = ""
        _footer = ""
        _header_align = Page.Align.Left
        _footer_align = Page.Align.Left
        _pagenumber_position = Page.Position.BottomRight
        _page_number = False
        _size = Size.Letter
        _width = 100
        _rotation = Orientations.Vertical
    End Sub
    Public Property ID As Integer
    Private Function Get3of9() As Font
        If Not FontFactory.IsRegistered("3 of 9 Barcode") Then
            Dim path As String = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts), "3of9barcode.TTF")
            FontFactory.Register(path)
        End If
        Return FontFactory.GetFont("3 of 9 Barcode", 20, 0)
    End Function

    Public Function Save(ByVal filename As String) As Boolean
        Try
            Dim document As Document
            If _size = PDF.Size.A4 AndAlso _rotation = Orientations.Vertical Then
                document = New Document(PageSize.A4)
            ElseIf _size = PDF.Size.A4 AndAlso _rotation = Orientations.Landscape Then
                document = New Document(PageSize.A4.Rotate)
            ElseIf _size = PDF.Size.Legal AndAlso _rotation = Orientations.Vertical Then
                document = New Document(PageSize.LEGAL)
            ElseIf _size = PDF.Size.Legal AndAlso _rotation = Orientations.Landscape Then
                document = New Document(PageSize.LEGAL.Rotate)
            ElseIf _size = PDF.Size.Tabloid AndAlso _rotation = Orientations.Vertical Then
                document = New Document(PageSize.TABLOID)
            ElseIf _size = PDF.Size.Tabloid AndAlso _rotation = Orientations.Landscape Then
                document = New Document(PageSize.TABLOID.Rotate)
            ElseIf _rotation = Orientations.Landscape Then
                document = New Document(PageSize.LETTER.Rotate)
            Else
                document = New Document(PageSize.LETTER)
            End If
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filename, FileMode.Create))
            Dim helper As New Page(_header, _header_align, _footer, _footer_align, _page_number, _pagenumber_position)
            writer.PageEvent = helper
            document.Open()
            Dim font_title As Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, 1)
            Dim font_subtitle As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, 0)
            Dim font_number As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, 0)
            Dim font_part As Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, 1)
            Dim font_descrip As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, 0)
            Dim font_pcs As Font = FontFactory.GetFont(FontFactory.HELVETICA, 11, 1)
            Dim gray_background = New GrayColor(190)
            If _title <> String.Empty Then document.Add(New Paragraph(_title, font_title))
            If _subtitle <> String.Empty Then document.Add(New Paragraph(_subtitle, font_subtitle))
            If Not IsNothing(data) Then
                document.Add(New Paragraph(" ", font_part))
                Dim table As New PdfPTable(3)
                table.WidthPercentage = _width
                If Not IsNothing(_columns_widths) Then
                    table.SetWidths(_columns_widths)
                End If
                Dim cnt As Integer = 1
                For Each r As DataRow In data.Rows

                    Dim cell = New PdfPCell
                    cell.FixedHeight = 60
                    'If CBool(r.Item(6)) Then
                    cell.PaddingTop = -6
                    'End If
                    cell.UseBorderPadding = False

                    Dim number As New Paragraph(String.Format(" {0} / ID {1}", cnt, Me.ID), font_number)
                    'If CBool(r.Item(6)) Then
                    '    number.SpacingAfter = -14
                    'Else
                    number.SpacingAfter = -8
                    'End If

                    number.Alignment = Element.ALIGN_LEFT
                    cell.AddElement(number)

                    Dim part As New Paragraph(r.Item("No. de Parte").ToString, font_part) 'NO DE PARTE
                    part.SpacingAfter = -12
                    part.Alignment = Element.ALIGN_CENTER
                    cell.AddElement(part)

                    cell.AddElement(New Paragraph(" ", font_part))

                    Dim descrip As New Paragraph(r.Item("Descripcion").ToString, font_descrip) 'DESCRIPCION
                    descrip.Alignment = Element.ALIGN_CENTER
                    descrip.SpacingAfter = -5
                    cell.AddElement(descrip)

                    Dim pcs As New Paragraph(String.Format("{0} {1}  ", r.Item("Cantidad").ToString, r.Item("Unidad").ToString), font_pcs) 'QTY UOM
                    pcs.Alignment = Element.ALIGN_RIGHT
                    pcs.SpacingAfter = -14
                    cell.AddElement(pcs)

                    Dim locals As New Paragraph(String.Format("{0}", Delta.NullReplace(r.Item("Localizacion"), "")), font_number)
                    locals.Alignment = Element.ALIGN_LEFT
                    cell.AddElement(locals)

                    table.AddCell(cell)
                    cnt += 1
                Next
                If data.Rows.Count Mod 3 = 1 Then
                    table.AddCell(New PdfPCell())
                    table.AddCell(New PdfPCell())
                ElseIf data.Rows.Count Mod 3 = 2 Then
                    table.AddCell(New PdfPCell())
                End If

                document.Add(table)
            End If
            document.Close()
            _filename = filename
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SaveAs() As Boolean
        Try
            Dim dialog As New SaveFileDialog
            dialog.Filter = "PDF (*.pdf)|*.pdf"
            dialog.Title = "Guardar como..."
            If dialog.ShowDialog = DialogResult.OK Then
                Dim document As Document
                If _size = PDF.Size.A4 AndAlso _rotation = Orientations.Vertical Then
                    document = New Document(PageSize.A4)
                ElseIf _size = PDF.Size.A4 AndAlso _rotation = Orientations.Landscape Then
                    document = New Document(PageSize.A4.Rotate)
                ElseIf _size = PDF.Size.Legal AndAlso _rotation = Orientations.Vertical Then
                    document = New Document(PageSize.LEGAL)
                ElseIf _size = PDF.Size.Legal AndAlso _rotation = Orientations.Landscape Then
                    document = New Document(PageSize.LEGAL.Rotate)
                ElseIf _size = PDF.Size.Tabloid AndAlso _rotation = Orientations.Vertical Then
                    document = New Document(PageSize.TABLOID)
                ElseIf _size = PDF.Size.Tabloid AndAlso _rotation = Orientations.Landscape Then
                    document = New Document(PageSize.TABLOID.Rotate)
                ElseIf _rotation = Orientations.Landscape Then
                    document = New Document(PageSize.LETTER.Rotate)
                Else
                    document = New Document(PageSize.LETTER)
                End If
                Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(dialog.FileName, FileMode.Create))
                Dim helper As New Page(_header, _header_align, _footer, _footer_align, _page_number, _pagenumber_position)
                writer.PageEvent = helper
                document.Open()
                Dim font_title As Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, 1)
                Dim font_subtitle As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, 0)
                Dim font_td As Font = FontFactory.GetFont(FontFactory.HELVETICA, 7)
                Dim font_tr As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, 1)
                Dim gray_background = New GrayColor(190)
                If _title <> String.Empty Then document.Add(New Paragraph(_title, font_title))
                If _subtitle <> String.Empty Then document.Add(New Paragraph(_subtitle, font_subtitle))
                If Not IsNothing(data) Then
                    document.Add(New Paragraph(" ", font_td))
                    Dim table As New PdfPTable(data.Columns.Count)
                    table.WidthPercentage = _width
                    If Not IsNothing(_columns_widths) Then
                        table.SetWidths(_columns_widths)
                    End If

                    For Each column As DataColumn In data.Columns
                        Dim cell = New PdfPCell(New Phrase(column.ColumnName, font_tr))
                        cell.BackgroundColor = gray_background
                        table.AddCell(cell)
                    Next
                    For Each r As DataRow In data.Rows
                        For Each column As DataColumn In data.Columns
                            table.AddCell(New Phrase(r.Item(column.Ordinal).ToString, font_td))
                        Next
                    Next
                    document.Add(table)
                End If
                document.Close()
                _filename = dialog.FileName
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public WriteOnly Property Width As Single
        Set(value As Single)
            _width = value
        End Set
    End Property

    Public WriteOnly Property ColumnsWidths As Single()
        Set(value As Single())
            _columns_widths = value
        End Set
    End Property

    Public WriteOnly Property Title As String
        Set(value As String)
            _title = value
        End Set
    End Property

    Public WriteOnly Property Subtitle As String
        Set(value As String)
            _subtitle = value
        End Set
    End Property

    Public WriteOnly Property Header As String
        Set(value As String)
            _header = value
        End Set
    End Property

    Public WriteOnly Property Footer As String
        Set(value As String)
            _footer = value
        End Set
    End Property

    Public WriteOnly Property PageNumber As Boolean
        Set(value As Boolean)
            _page_number = value
        End Set
    End Property

    Public WriteOnly Property PageNumberPosition As Page.Position
        Set(value As Page.Position)
            _pagenumber_position = value
        End Set
    End Property

    Public WriteOnly Property HeaderAlign As Page.Align
        Set(value As Page.Align)
            _header_align = value
        End Set
    End Property

    Public WriteOnly Property FooterAlign As Page.Align
        Set(value As Page.Align)
            _footer_align = value
        End Set
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return _filename
        End Get
    End Property



    Public WriteOnly Property Orientation As Orientations
        Set(value As Orientations)
            _rotation = value
        End Set
    End Property

    Public WriteOnly Property DataSource As DataTable
        Set(value As DataTable)
            data = value
        End Set
    End Property

    Public Enum Size
        Letter
        Legal
        A4
        Tabloid
    End Enum

    Public Enum Orientations
        Vertical
        Landscape
    End Enum

    Public Class Page
        Implements IPdfPageEvent
        Private template As PdfTemplate
        Private content_byte As PdfContentByte
        Private base_font As BaseFont = Nothing

        'Dim page_counter As Integer = 2
        Dim header_color As BaseColor = New BaseColor(255, 255, 255)
        'Dim footer_color As BaseColor = New BaseColor(0, 255, 255)
        Dim header_font As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8)
        Dim footer_font As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8)

        Dim header_text, footer_text As String
        Dim header_align, footer_align As Align
        Dim page_position As Position
        Dim page_number As Boolean
        Public Sub New(header As String, header_align As Align, footer As String, footer_align As Align, page_number As Boolean, page_position As Position, Optional color_header() As Single = Nothing)
            header_text = header
            footer_text = footer
            Me.page_number = page_number
            Me.header_align = header_align
            Me.footer_align = footer_align
            Me.page_position = page_position
            If Not IsNothing(color_header) Then
                header_color = New BaseColor(color_header(0), color_header(1), color_header(2))
            End If
        End Sub

        Public Enum Align
            Center
            Left
            Right
        End Enum

        Public Enum Position
            TopLeft
            TopCenter
            TopRight
            BottomLeft
            BottomCenter
            BottomRight
        End Enum

        Private Sub Header(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As Document)
            Dim header_table As New PdfPTable(1)
            Dim header_cell As PdfPCell
            With header_table
                header_cell = New PdfPCell(New iTextSharp.text.Phrase(header_text, header_font))
                header_cell.Border = 0
                header_cell.BackgroundColor = header_color
                If header_align = Align.Center Then
                    header_cell.HorizontalAlignment = Element.ALIGN_CENTER
                ElseIf header_align = Align.Right Then
                    header_cell.HorizontalAlignment = Element.ALIGN_RIGHT
                Else
                    header_cell.HorizontalAlignment = Element.ALIGN_LEFT
                End If
                .AddCell(header_cell)
                header_table.TotalWidth = document.PageSize.Width - 70
                header_table.WriteSelectedRows(0, -1, 36, document.PageSize.Height - 25, writer.DirectContent)

                If page_number Then
                    Dim number_text As String = "Pagina " & document.PageNumber & " de "
                    Dim lenght As Single = base_font.GetWidthPoint(number_text, header_font.Size)
                    Select Case page_position
                        Case Position.TopRight
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(document.PageSize.Width - 100, document.PageSize.Height - 35)
                            content_byte.ShowText(number_text)
                            content_byte.EndText()

                            content_byte.AddTemplate(template, document.PageSize.Width - 100 + lenght, document.PageSize.Height - 35)
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(300, 300)
                            content_byte.EndText()
                        Case Position.TopCenter
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(document.PageSize.Width / 2 - lenght / 2, document.PageSize.Height - 35)
                            content_byte.ShowText(number_text)
                            content_byte.EndText()

                            content_byte.AddTemplate(template, document.PageSize.Width / 2 - lenght / 2 + lenght, document.PageSize.Height - 35)
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(300, 300)
                            content_byte.EndText()
                        Case Position.TopLeft
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(40, document.PageSize.Height - 35)
                            content_byte.ShowText(number_text)
                            content_byte.EndText()

                            content_byte.AddTemplate(template, 40 + lenght, document.PageSize.Height - 35)
                            content_byte.BeginText()
                            content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                            content_byte.SetTextMatrix(300, 300)
                            content_byte.EndText()
                    End Select
                End If
            End With
        End Sub


        Private Sub Footer(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
            Dim _lenght As Single = base_font.GetWidthPoint(footer_text, footer_font.Size)
            Select Case footer_align
                Case Align.Left
                    content_byte.BeginText()
                    content_byte.SetFontAndSize(footer_font.BaseFont, footer_font.Size)
                    content_byte.SetTextMatrix(40, 30)
                    content_byte.ShowText(footer_text)
                    content_byte.EndText()
                Case Align.Center
                    content_byte.BeginText()
                    content_byte.SetFontAndSize(footer_font.BaseFont, footer_font.Size)
                    content_byte.SetTextMatrix(document.PageSize.Width / 2 - _lenght / 2, 30)
                    content_byte.ShowText(footer_text)
                    content_byte.EndText()
                Case Align.Right
                    content_byte.BeginText()
                    content_byte.SetFontAndSize(footer_font.BaseFont, footer_font.Size)
                    content_byte.SetTextMatrix(document.PageSize.Width - _lenght - 40, 30)
                    content_byte.ShowText(footer_text)
                    content_byte.EndText()
            End Select


            If page_number Then
                Dim number_text As String = "Pagina " & document.PageNumber & " de "
                Dim lenght As Single = base_font.GetWidthPoint(number_text, header_font.Size)
                Select Case page_position
                    Case Position.BottomRight
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(document.PageSize.Width - 113, 30)
                        content_byte.ShowText(number_text)
                        content_byte.EndText()

                        content_byte.AddTemplate(template, document.PageSize.Width - 112 + lenght, 30)
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(300, 300)
                        content_byte.EndText()
                    Case Position.BottomCenter
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(document.PageSize.Width / 2 - lenght / 2, 30)
                        content_byte.ShowText(number_text)
                        content_byte.EndText()

                        content_byte.AddTemplate(template, document.PageSize.Width / 2 - lenght / 2 + lenght, 30)
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(300, 300)
                        content_byte.EndText()
                    Case Position.BottomLeft
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(40, 30)
                        content_byte.ShowText(number_text)
                        content_byte.EndText()

                        content_byte.AddTemplate(template, 40 + lenght, 30)
                        content_byte.BeginText()
                        content_byte.SetFontAndSize(header_font.BaseFont, header_font.Size)
                        content_byte.SetTextMatrix(300, 300)
                        content_byte.EndText()
                End Select
            End If
        End Sub

        Public Sub OnChapter(writer As PdfWriter, document As Document, paragraphPosition As Single, title As Paragraph) Implements IPdfPageEvent.OnChapter

        End Sub

        Public Sub OnChapterEnd(writer As PdfWriter, document As Document, paragraphPosition As Single) Implements IPdfPageEvent.OnChapterEnd

        End Sub

        Public Sub OnCloseDocument(writer As PdfWriter, document As Document) Implements IPdfPageEvent.OnCloseDocument
            template.BeginText()
            template.SetFontAndSize(header_font.BaseFont, header_font.Size)
            template.ShowText((writer.PageNumber).ToString)
            template.EndText()
        End Sub

        Public Sub OnEndPage(writer As PdfWriter, document As Document) Implements IPdfPageEvent.OnEndPage
            Header(writer, document)
            Footer(writer, document)
        End Sub

        Public Sub OnGenericTag(writer As PdfWriter, document As Document, rect As Rectangle, text As String) Implements IPdfPageEvent.OnGenericTag

        End Sub

        Public Sub OnOpenDocument(writer As PdfWriter, document As Document) Implements IPdfPageEvent.OnOpenDocument
            Try
                base_font = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
                content_byte = writer.DirectContent
                template = content_byte.CreateTemplate(50, 50)

            Catch de As DocumentException
                MsgBox(de.Message())
            Catch ioe As IOException
                MsgBox(ioe.Message())
            End Try
        End Sub

        Public Sub OnParagraph(writer As PdfWriter, document As Document, paragraphPosition As Single) Implements IPdfPageEvent.OnParagraph

        End Sub

        Public Sub OnParagraphEnd(writer As PdfWriter, document As Document, paragraphPosition As Single) Implements IPdfPageEvent.OnParagraphEnd

        End Sub

        Public Sub OnSection(writer As PdfWriter, document As Document, paragraphPosition As Single, depth As Integer, title As Paragraph) Implements IPdfPageEvent.OnSection

        End Sub

        Public Sub OnSectionEnd(writer As PdfWriter, document As Document, paragraphPosition As Single) Implements IPdfPageEvent.OnSectionEnd

        End Sub

        Public Sub OnStartPage(writer As PdfWriter, document As Document) Implements IPdfPageEvent.OnStartPage
            'writer.PageCount = page_counter
            'page_counter += 1
        End Sub
    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: eliminar estado administrado (objetos administrados).
            End If

            ' TODO: liberar recursos no administrados (objetos no administrados) e invalidar Finalize() below.
            ' TODO: Establecer campos grandes como Null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: invalidar Finalize() sólo si la instrucción Dispose(ByVal disposing As Boolean) anterior tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Ponga el código de limpieza en la instrucción Dispose(ByVal disposing As Boolean) anterior.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub
#End Region

End Class

