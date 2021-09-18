﻿Public Class REC
    Public Shared Sub PrintLabel(serialnumber As String)
        ZPL.PrintTo(BuildLabel(serialnumber), My.Settings.Printer)
    End Sub

    Public Shared Function CriticalLabel(partnumber As String, area As String, comment As String, user As String) As String
        Return ZPL.TryChangeResolution(My.Resources.ZPL_CriticalLabel, 300, My.Settings.PrinterResolution).Replace("@partnumber", partnumber).Replace("@area", area).Replace("@comment", comment).Replace("@user", user)
    End Function

    Public Shared Function QualityLabel(partnumber As String, reason As String, user As String) As String
        Return ZPL.TryChangeResolution(My.Resources.ZPL_QualityLabel, 300, My.Settings.PrinterResolution).Replace("@partnumber", partnumber).Replace("@reason", reason).Replace("@user", user)
    End Function

    Public Shared Function ControlledLabel(partnumber As String) As String
        Return ZPL.TryChangeResolution(My.Resources.ZPL_ControlledLabel, 300, My.Settings.PrinterResolution).Replace("@partnumber", partnumber)
    End Function

    Public Shared Sub PrintLabel(serialnumbers As ArrayList)
        Dim serials As String = ""
        For Each s In serialnumbers
            serials &= BuildLabel(s)
        Next
        ZPL.PrintTo(serials, My.Settings.Printer)
    End Sub

    'IMPRIME PASANDOLE TODO LA INFORMACION DE LA SERIE
    Public Shared Sub PrintLabels(serialnumbers As DataTable, Optional print_receiving_alert_labels As Boolean = False)
        Dim serials As String = ""
        Dim current_partnumber As String = ""
        Dim current_masternumber As String = ""
        For Each serial As DataRow In serialnumbers.Rows
            If print_receiving_alert_labels Then

                If Parameter("REC_CreateMasterLabel", False) AndAlso Not IsDBNull(serial.Item("Masternumber")) AndAlso current_masternumber <> serial.Item("Masternumber") Then
                    current_masternumber = serial.Item("Masternumber")
                    Dim qty_master As Decimal = SQL.Current.GetScalar("SUM(OriginalQuantity)", "vw_Smk_Serials", "Masternumber", current_masternumber)
                    serials &= BuildMasterLabel(serial, qty_master)
                End If

                If Parameter("REC_PrintCriticalAlertLabel", False) AndAlso current_partnumber <> serial.Item("Partnumber") Then
                    Dim is_critical As Hashtable = SQL.Current.GetRecord(String.Format("SELECT Partnumber,C.Area,Comment,FullName FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 AND C.Partnumber = '{0}';", serial.Item("Partnumber")))
                    If is_critical IsNot Nothing AndAlso is_critical.Count > 0 Then
                        serials &= CriticalLabel(is_critical("partnumber"), is_critical("area"), is_critical("comment"), is_critical("fullname"))
                    End If
                End If
                current_partnumber = serial.Item("Partnumber")

                If Parameter("REC_PrintQualityAlertLabel", False) Then
                    Dim is_alerted As Hashtable = SQL.Current.GetRecord(String.Format("SELECT Partnumber,dbo.Qly_AlertReasons(Partnumber, '{1}') AS Reason,FullName FROM Qly_PartnumberAlerts AS Q INNER JOIN Sys_Users AS U ON Q.Username = U.Username WHERE Q.Active = 1 AND Q.Partnumber = '{0}' ORDER BY [Date];", current_partnumber, CDate(serial.Item("Date")).ToString("yyyy-MM-dd HH:mm:ss")))
                    If is_alerted IsNot Nothing AndAlso is_alerted.Count > 0 Then
                        serials &= QualityLabel(is_alerted("partnumber"), is_alerted("reason"), is_alerted("fullname"))
                    End If
                End If

                If Parameter("REC_PrintControlledAlertLabel", False) Then
                    If SQL.Current.Exists("Rec_ControlledPartnumbers", {"Partnumber", "Active"}, {current_partnumber, 1}) Then
                        serials &= ControlledLabel(current_partnumber)
                    End If
                End If
            End If
            serials &= BuildLabel(serial)
        Next
        ZPL.PrintTo(serials, My.Settings.Printer)
    End Sub

    'IMPRIME MIENTRAS EXISTA UNA LA COLUMNA DE LA SERIE, NUMERO DE PARTE Y FECHA
    Public Shared Sub PrintLabels(serialnumbers As DataRow(), Optional print_receiving_alert_labels As Boolean = False)
        Dim serials As String = ""
        Dim current_partnumber As String = ""
        For Each serial As DataRow In serialnumbers
            If print_receiving_alert_labels AndAlso current_partnumber <> serial.Item("Partnumber") Then
                If Parameter("REC_PrintCriticalAlertLabel", False) AndAlso current_partnumber <> serial.Item("Partnumber") Then
                    Dim is_critical As Hashtable = SQL.Current.GetRecord(String.Format("SELECT Partnumber,C.Area,Comment,FullName FROM Rec_CriticalPartnumbers AS C INNER JOIN Sys_Users AS U ON C.Username = U.Username WHERE C.Active = 1 AND C.Partnumber = '{0}';", serial.Item("Partnumber")))
                    If is_critical IsNot Nothing AndAlso is_critical.Count > 0 Then
                        serials &= CriticalLabel(is_critical("partnumber"), is_critical("area"), is_critical("comment"), is_critical("fullname"))
                    End If
                End If
                current_partnumber = serial.Item("Partnumber")

                If Parameter("REC_PrintQualityAlertLabel", False) Then
                    Dim is_alerted As Hashtable = SQL.Current.GetRecord(String.Format("SELECT Partnumber,dbo.Qly_AlertReasons(Partnumber, '{1}') AS Reason,FullName FROM Qly_PartnumberAlerts AS Q INNER JOIN Sys_Users AS U ON Q.Username = U.Username WHERE Q.Active = 1 AND Q.Partnumber = '{0}' ORDER BY [Date];", current_partnumber, CDate(serial.Item("Date")).ToString("yyyy-MM-dd HH:mm:ss")))
                    If is_alerted IsNot Nothing AndAlso is_alerted.Count > 0 Then
                        serials &= QualityLabel(is_alerted("partnumber"), is_alerted("reason"), is_alerted("fullname"))
                    End If
                End If

                If Parameter("REC_PrintControlledAlertLabel", False) Then
                    If SQL.Current.Exists("Rec_ControlledPartnumbers", {"Partnumber", "Active"}, {current_partnumber, 1}) Then
                        serials &= ControlledLabel(current_partnumber)
                    End If
                End If
            End If
            serials &= BuildLabel(serial.Item("Serialnumber").ToString)
        Next
        ZPL.PrintTo(serials, My.Settings.Printer)
    End Sub

    Private Shared Function BuildLabel(serialnumber As String) As String
        Dim rd As Hashtable = SQL.Current.GetRecord(String.Format("SELECT id,serialnumber,partnumber,description,[date],currentquantity,uom,location,warehousename,redtag,critical,supplierpartnumber,suppliername,labellegend,trucknumber FROM vw_Smk_Serials WHERE serialnumber='{0}'", serialnumber))
        If rd.Count > 0 Then
            Dim zpl_label As String = ZPL.TryChangeResolution(My.Resources.ZPL_ReceivingLabel, 300, My.Settings.PrinterResolution)
            zpl_label = zpl_label.Replace("@serieS", rd("serialnumber").ToString.Substring(rd("serialnumber").ToString.Length - 6, 6))
            zpl_label = zpl_label.Replace("@serieO", rd("serialnumber").ToString.Substring(0, rd("serialnumber").ToString.Length - 6))
            zpl_label = zpl_label.Replace("@serie", rd("serialnumber"))

            zpl_label = zpl_label.Replace("@qr", Alphanumeric.ToAlphanumeric(Strings.Right(rd("serialnumber"), 10)))

            zpl_label = zpl_label.Replace("@partnumber", rd("partnumber"))
            zpl_label = zpl_label.Replace("@supplierpart", If(IsDBNull(rd("supplierpartnumber")), "", rd("supplierpartnumber")))
            zpl_label = zpl_label.Replace("@suppliername", If(IsDBNull(rd("suppliername")), "", rd("suppliername")))
            zpl_label = zpl_label.Replace("@date", CDate(rd("date")).ToString("dd-MM-yy"))
            zpl_label = zpl_label.Replace("@hour", CDate(rd("date")).ToString("HH:mm"))
            If Math.Truncate(CDec(rd("currentquantity"))) <> CDec(rd("currentquantity")) Then
                zpl_label = zpl_label.Replace("@qty", Math.Round(CDec(rd("currentquantity")), 1))
            Else
                zpl_label = zpl_label.Replace("@qty", CInt(rd("currentquantity")))
            End If
            zpl_label = zpl_label.Replace("@uom", rd("uom"))
            If rd("location").ToString.Length = 8 Then
                zpl_label = zpl_label.Replace("@service", String.Format("{0}-{1}-{2}-{3}", rd("location").ToString.Substring(0, 2), rd("location").ToString.Substring(2, 2), rd("location").ToString.Substring(4, 2), rd("location").ToString.Substring(6, 2)))
            Else
                zpl_label = zpl_label.Replace("@service", rd("location"))
            End If
            zpl_label = zpl_label.Replace("@warehouse", rd("warehousename"))

            zpl_label = zpl_label.Replace("@redtag", If(rd("redtag"), "Q", ""))
            zpl_label = zpl_label.Replace("@description", If(IsDBNull(rd("description")), "", rd("description")))
            zpl_label = zpl_label.Replace("@legend", If(IsDBNull(rd("labellegend")), "", rd("labellegend")))
            zpl_label = zpl_label.Replace("@week", DatePart(DateInterval.WeekOfYear, CDate(rd("date"))))
            zpl_label = zpl_label.Replace("@truck", If(IsDBNull(rd("trucknumber")), "", rd("trucknumber")))
            BuildLabel = zpl_label
        Else
            BuildLabel = ""
        End If
        rd.Clear()
        rd = Nothing
        GC.Collect()
    End Function

    Private Shared Function BuildLabel(serialnumber As DataRow) As String
       Dim zpl_label As String = ZPL.TryChangeResolution(My.Resources.ZPL_ReceivingLabel, 300, My.Settings.PrinterResolution)
        zpl_label = zpl_label.Replace("@serieS", serialnumber.Item("serialnumber").ToString.Substring(serialnumber.Item("serialnumber").ToString.Length - 6, 6))
        zpl_label = zpl_label.Replace("@serieO", serialnumber.Item("serialnumber").ToString.Substring(0, serialnumber.Item("serialnumber").ToString.Length - 6))
        zpl_label = zpl_label.Replace("@serie", serialnumber.Item("serialnumber"))
        zpl_label = zpl_label.Replace("@qr", Alphanumeric.ToAlphanumeric(Strings.Right(serialnumber.Item("serialnumber"), 10)))
        zpl_label = zpl_label.Replace("@partnumber", serialnumber.Item("partnumber"))
        zpl_label = zpl_label.Replace("@supplierpart", If(IsDBNull(serialnumber.Item("supplierpartnumber")), "", serialnumber.Item("supplierpartnumber")))
        zpl_label = zpl_label.Replace("@suppliername", If(IsDBNull(serialnumber.Item("suppliername")), "", serialnumber.Item("suppliername")))
        zpl_label = zpl_label.Replace("@date", CDate(serialnumber.Item("date")).ToString("dd-MM-yy"))
        zpl_label = zpl_label.Replace("@hour", CDate(serialnumber.Item("date")).ToString("HH:mm"))
        If Math.Truncate(CDec(serialnumber.Item("currentquantity"))) <> CDec(serialnumber.Item("currentquantity")) Then
            zpl_label = zpl_label.Replace("@qty", Math.Round(CDec(serialnumber.Item("currentquantity")), 1))
        Else
            zpl_label = zpl_label.Replace("@qty", CInt(serialnumber.Item("currentquantity")))
        End If
        zpl_label = zpl_label.Replace("@uom", serialnumber.Item("uom"))
        If serialnumber.Item("location").ToString.Length = 8 Then
            zpl_label = zpl_label.Replace("@service", String.Format("{0}-{1}-{2}-{3}", serialnumber.Item("location").ToString.Substring(0, 2), serialnumber.Item("location").ToString.Substring(2, 2), serialnumber.Item("location").ToString.Substring(4, 2), serialnumber.Item("location").ToString.Substring(6, 2)))
        Else
            zpl_label = zpl_label.Replace("@service", serialnumber.Item("location"))
        End If
        zpl_label = zpl_label.Replace("@warehouse", serialnumber.Item("warehousename"))

        zpl_label = zpl_label.Replace("@redtag", If(serialnumber.Item("redtag"), "Q", ""))
        zpl_label = zpl_label.Replace("@description", If(IsDBNull(serialnumber.Item("description")), "", serialnumber.Item("description")))
        zpl_label = zpl_label.Replace("@legend", If(IsDBNull(serialnumber.Item("labellegend")), "", serialnumber.Item("labellegend")))
        zpl_label = zpl_label.Replace("@week", DatePart(DateInterval.WeekOfYear, CDate(serialnumber.Item("date"))))
        zpl_label = zpl_label.Replace("@truck", If(IsDBNull(serialnumber.Item("trucknumber")), "", serialnumber.Item("trucknumber")))
        Return zpl_label
    End Function

    Private Shared Function BuildMasterLabel(serialnumber As DataRow, quantity As Decimal) As String
        Dim zpl_label As String = ZPL.TryChangeResolution(My.Resources.ZPL_MasterLabel, 300, My.Settings.PrinterResolution)
        zpl_label = zpl_label.Replace("@serieS", serialnumber.Item("masternumber").ToString.Substring(serialnumber.Item("masternumber").ToString.Length - 6, 6))
        zpl_label = zpl_label.Replace("@serieO", serialnumber.Item("masternumber").ToString.Substring(0, serialnumber.Item("masternumber").ToString.Length - 6))
        zpl_label = zpl_label.Replace("@serie", serialnumber.Item("masternumber"))
        zpl_label = zpl_label.Replace("@partnumber", serialnumber.Item("partnumber"))
        zpl_label = zpl_label.Replace("@date", CDate(serialnumber.Item("date")).ToString("dd-MM-yy"))
        zpl_label = zpl_label.Replace("@hour", CDate(serialnumber.Item("date")).ToString("HH:mm"))
        If Math.Truncate(quantity) <> quantity Then
            zpl_label = zpl_label.Replace("@qty", Math.Round(quantity, 1))
        Else
            zpl_label = zpl_label.Replace("@qty", CInt(quantity))
        End If
        zpl_label = zpl_label.Replace("@uom", serialnumber.Item("uom"))
        If serialnumber.Item("location").ToString.Length = 8 Then
            zpl_label = zpl_label.Replace("@service", String.Format("{0}-{1}-{2}-{3}", serialnumber.Item("location").ToString.Substring(0, 2), serialnumber.Item("location").ToString.Substring(2, 2), serialnumber.Item("location").ToString.Substring(4, 2), serialnumber.Item("location").ToString.Substring(6, 2)))
        Else
            zpl_label = zpl_label.Replace("@service", serialnumber.Item("location"))
        End If
        zpl_label = zpl_label.Replace("@warehouse", serialnumber.Item("warehousename"))

        zpl_label = zpl_label.Replace("@redtag", If(serialnumber.Item("redtag"), "Q", ""))
        zpl_label = zpl_label.Replace("@description", If(IsDBNull(serialnumber.Item("description")), "", serialnumber.Item("description")))
        zpl_label = zpl_label.Replace("@legend", If(IsDBNull(serialnumber.Item("labellegend")), "", serialnumber.Item("labellegend")))
        zpl_label = zpl_label.Replace("@week", DatePart(DateInterval.WeekOfYear, CDate(serialnumber.Item("date"))))
        zpl_label = zpl_label.Replace("@truck", If(IsDBNull(serialnumber.Item("trucknumber")), "", serialnumber.Item("trucknumber")))
        Return zpl_label
    End Function
End Class
