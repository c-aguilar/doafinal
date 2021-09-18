Public Class Smk_APIPrint
    Dim partnumber As RawMaterial
    Dim Serial As Serialnumber
    Dim Ticket As String

    Private Sub Serial_txt_TextChanged(sender As Object, e As EventArgs) Handles Serial_txt.TextChanged
        If SMK.IsSerialFormat(Serial_txt.Text) OrElse SMK.IsLinkSerialFormat(Serial_txt.Text) Then
            For Each s As DataRow In SQL.Current.GetDatatable(String.Format("SELECT T.[Ticket],SerialNumber,[Consecutive] FROM [Smk_APITicketSerials] AS T INNER JOIN Smk_Serials AS S ON T.SerialID = S.ID WHERE S.SerialNumber IN ('{0}') ORDER BY Consecutive ", Serial_txt.Text)).Rows
                Serial = New Serialnumber(s.Item("serialnumber"))
                partnumber = New RawMaterial(Serial.Partnumber)
                PrintLabel(s.Item("consecutive"))
                Ticket = s.Item("ticket")
            Next
        End If
    End Sub

    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles List_btn.Click
        Dim ld As New ListDialog
        ld.Title = "Numeros de Serie"
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each s As DataRow In SQL.Current.GetDatatable(String.Format("SELECT T.[Ticket],SerialNumber,[Consecutive] FROM [Smk_APITicketSerials] AS T INNER JOIN Smk_Serials AS S ON T.SerialID = S.ID WHERE S.SerialNumber IN ('{0}') ORDER BY Consecutive ", String.Join("','", ld.Items.ToArray))).Rows
                Serial = New Serialnumber(s.Item("serialnumber"))
                partnumber = New RawMaterial(Serial.Partnumber)
                Ticket = s.Item("ticket")
                PrintLabel(s.Item("consecutive"))
            Next
        End If
    End Sub


    Private Sub PrintLabel(folio As String)
        Dim zpl_label As String = ZPL.TryChangeResolution(My.Resources.ZPL_APILabel, 300, My.Settings.PrinterResolution)
        zpl_label = zpl_label.Replace("@serieS", Serial.SerialNumber.Substring(Serial.SerialNumber.Length - 6, 6))
        zpl_label = zpl_label.Replace("@serieO", Serial.SerialNumber.Substring(0, Serial.SerialNumber.Length - 6))
        zpl_label = zpl_label.Replace("@serie", Serial.SerialNumber)

        zpl_label = zpl_label.Replace("@qr", Alphanumeric.ToAlphanumeric(Strings.Right(Serial.SerialNumber, 10)))

        zpl_label = zpl_label.Replace("@partnumber", Serial.Partnumber)
        zpl_label = zpl_label.Replace("@date", Delta.CurrentDate.ToString("dd-MM-yy"))
        zpl_label = zpl_label.Replace("@hour", Delta.CurrentDate.ToString("HH:mm"))
        zpl_label = zpl_label.Replace("@qty", If(Serial.UoM = RawMaterial.UnitOfMeasure.PC, CInt(Serial.CurrentQuantity), Math.Round(Serial.CurrentQuantity, 3)))

        zpl_label = zpl_label.Replace("@uom", Serial.UoM.ToString)
        If Serial.Location.ToString.Length = 8 Then
            zpl_label = zpl_label.Replace("@service", String.Format("{0}-{1}-{2}-{3}", Serial.Location.Substring(0, 2), Serial.Location.Substring(2, 2), Serial.Location.Substring(4, 2), Serial.Location.Substring(6, 2)))
        Else
            zpl_label = zpl_label.Replace("@service", Serial.Location)
        End If
        zpl_label = zpl_label.Replace("@warehouse", Serial.WarehouseName)
        zpl_label = zpl_label.Replace("@description", partnumber.Description)
        zpl_label = zpl_label.Replace("@api", Parameter("SYS_APIName"))
        zpl_label = zpl_label.Replace("@ticket", Ticket)
        zpl_label = zpl_label.Replace("@folio", folio)
        zpl_label = zpl_label.Replace("@weight", Math.Round(Serial.Weight, 3) & " KG")
        ZPL.PrintTo(zpl_label, My.Settings.Printer)
    End Sub

    Private Sub Smk_APIPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class