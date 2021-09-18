Public Class Picklist
    Public Sub New(id As Integer)
        Dim record As Hashtable = SQL.Current.GetRecord("CR_Picklist", "ID", id)
        If record IsNot Nothing AndAlso record.Count > 0 Then
            Me.ID = id
            Me.Material = record.Item("material")
            Me.Quantity = record.Item("quantity")
            Me.ManufacturingDate = record.Item("manufacturingdate")
            Me.ShippingDate = record.Item("shippingdate")
        End If
    End Sub
    Public Sub New(id As Integer, material As String, quantity As Integer, manufacturing_date As Date, shipping_date As Date)
        Me.ID = id
        Me.Material = material
        Me.Quantity = quantity
        Me.ManufacturingDate = manufacturing_date
        Me.ShippingDate = shipping_date
    End Sub
    Public Property ID As Integer
    Public Property ManufacturingDate As Date
    Public Property ShippingDate As Date
    Public Property Material As String
    Public Property Quantity As Integer

    Public Sub Print()
        Dim ds As DataTable = SQL.Current.GetDatatable(String.Format("SELECT PP.Partnumber AS [No. de Parte],R.[Description] AS Descripcion,PP.Quantity AS Cantidad,R.UoM AS Unidad,dbo.Smk_Locations(R.Partnumber) AS Localizacion,'' AS Comentario FROM CR_Picklist AS P INNER JOIN CR_PicklistPartnumbers AS PP ON P.ID = PP.PicklistID INNER JOIN Sys_RawMaterial AS R ON PP.Partnumber = R.Partnumber WHERE P.ID = {0} AND R.UoM = 'PC' AND R.[Description] NOT LIKE 'term%' AND R.[Description] NOT LIKE 'cabl%' AND R.[Description] NOT LIKE 'seal%' AND R.[Description] NOT LIKE 'cond cnvlt%';", Me.ID))
        Dim tmp As String = GF.TempPDFPath
        Dim pdf As New PDF
        pdf.Title = String.Format("Picklist de Material | ID {0}", Me.ID)
        pdf.TitleFontSize = 14
        pdf.Subtitle = String.Format("Arnes: {1} - {2} PC{0}Fecha de manufactura: {3}{0}Fecha de embarque: {4}", vbCrLf, Me.Material, Me.Quantity, Me.ManufacturingDate.ToShortDateString, Me.ShippingDate.ToShortDateString)
        pdf.Footer = String.Format("Picklist de Material | ID {0} | Planta {1}", Me.ID, Parameter("SYS_PlantCode"))
        pdf.PageNumber = True
        pdf.Logo = New PDF.Logotype()
        pdf.Logo.Image = My.Resources.APTIV
        pdf.Logo.Alignment = pdf.Page.Align.Right
        pdf.Logo.Format = System.Drawing.Imaging.ImageFormat.Png
        pdf.DataSource = ds
        pdf.HeaderFontSize = 10
        pdf.Save(tmp)

        Dim tmp_sq As String = GF.TempPDFPath
        Dim pdf_sq As New PDFPicklistParts(Me.ID)
        pdf_sq.PageNumber = True
        pdf_sq.PageNumberPosition = pdf.Page.Position.BottomCenter
        pdf_sq.Footer = "ID " & Me.ID
        pdf_sq.FooterAlign = pdf.Page.Align.Right
        pdf_sq.Orientation = pdf.Orientations.Vertical
        pdf_sq.DataSource = ds
        pdf_sq.Save(tmp_sq)

        Dim view1 As New PDFViewer
        view1.Filename = tmp

        Dim view2 As New PDFViewer
        view2.Filename = tmp_sq

        view1.Show()
        view2.Show()
    End Sub
End Class