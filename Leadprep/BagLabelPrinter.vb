Public Class BagLabelPrinter

    Private Sub BagLabelPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BagLabelPrinter_Print_btn_Click(sender As Object, e As EventArgs) Handles BagLabelPrinter_Print_btn.Click
        Dim last_id As Long = Parameter("SYS_LastCuttingBagLabelID")
        If SQL.Current.Update("Sys_Parameters", {"Value"}, {last_id + BagLabelPrinter_Quantity_nud.Value}, "Parameter", "SYS_LastCuttingBagLabelID") Then
            'ZPL.TryChangeResolution("^XA^CFA,40^FO80,70^FD     =============/ DELTA /=============^FS^FO40,40^GB1130,90,3^FS^BY4,2,150^FO100,190^B1R,N,120,Y,N^FD@id^FS^BY6,2,150^FO450,250^B1N,N,200,Y,N^FD@id^FS^XZ", 200, 300)
            Dim zpl_label As String = "^XA^CFA,40^FO280,70^FD=========/ DELTA /=========^FS^FO250,40^GB700,90,3^FS^BY4^FO100,120^BCR,120,Y,N,N^FD@id^FS^FO1000,120^BCB,120,Y,N,N^FD@id^FS^BY4^FO380,280^BCN,160,Y,N,N^FD@id^FS^XZ"
            Dim all_labels As String = ""
            For i = 1 To BagLabelPrinter_Quantity_nud.Value
                last_id += 1
                all_labels &= zpl_label.Replace("@id", Alphanumeric.ToAlphanumeric(last_id))
            Next
            ZPL.Print(all_labels)
            MsgBox("Done!", MsgBoxStyle.Information, APP)
        End If
    End Sub

    Private Sub BagLabelPrinter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class