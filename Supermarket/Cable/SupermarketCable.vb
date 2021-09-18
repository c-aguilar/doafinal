Public Class SupermarketCable
    Public Shared Property CurrentBadge As String
    Public Shared Function ReturnBadge(Optional ByVal cutter As String = "") As Boolean
        If Not CBool(Parameter("SMK_CableAskForBadge")) Then
            SupermarketCable.CurrentBadge = "DeltaERP"
            Return True
        End If
        If cutter <> "" AndAlso CBool(Parameter("SMK_CableActiveCutterRoutes", "False")) Then
            Dim route As Integer = SQL.Current.GetScalar(String.Format("SELECT RouteID FROM Smk_CableRouteCutters WHERE CutterID = '{0}' AND RouteID IN (SELECT ID FROM Smk_CableRoutes WHERE Shift = dbo.Sys_Shift(GETDATE()));", cutter))
            If route = 0 Then
                Dim badge As New Smk_BadgeKiosk
                If badge.ShowDialog = Windows.Forms.DialogResult.OK Then
                    SupermarketCable.CurrentBadge = badge.SelectedBadge
                    Return True
                Else
                    SupermarketCable.CurrentBadge = ""
                    Return False
                End If
            Else
                Dim route_badge As String = SQL.Current.GetString("Badge", "Smk_CableOperatorRegistry", {"Active", "RouteID"}, {1, route}, "")
                If route_badge = "" Then
                    Dim badge As New Smk_BadgeKiosk
                    If badge.ShowDialog = Windows.Forms.DialogResult.OK Then
                        SupermarketCable.CurrentBadge = badge.SelectedBadge
                        Return True
                    Else
                        SupermarketCable.CurrentBadge = ""
                        Return False
                    End If
                Else
                    SupermarketCable.CurrentBadge = route_badge
                    ReturnBadge = True
                End If
            End If
        Else
            Dim background As New FadeBackground()
            Dim badge As New Smk_BadgeKiosk
            background.Show()
            If badge.ShowDialog() = DialogResult.OK Then
                SupermarketCable.CurrentBadge = badge.SelectedBadge
                ReturnBadge = True
            Else
                SupermarketCable.CurrentBadge = ""
                ReturnBadge = False
            End If
            badge.Dispose()
            background.Close()
            background.Dispose()
        End If
    End Function
    Public Shared Sub PrintEmptylLabel(ByVal serial As String)
        ' Imprimir una etiqueta indicando que el barril ya fue declarado vacio.
    End Sub
    Public Shared Sub AutoNextSerial(partnumber As String, warehouse As String)
        If Parameter("SMK_CableNextSerialMode") <> "None" Then
            If Parameter("SMK_CableNextSerialMode") = "MaximumBelow" Then
                If SQL.Current.GetScalar(String.Format("SELECT COUNT(ID) FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Warehouse = '{1}' AND Status IN ('C','O');", partnumber, warehouse)) < SQL.Current.GetScalar("Maximum", "Smk_Map", {"Partnumber", "Warehouse"}, {partnumber, warehouse}) Then
                    Dim next_serial = SMK.NextFIFO(partnumber, warehouse)
                    If SMK.IsSerialFormat(next_serial) Then
                        SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {next_serial, warehouse, SupermarketCable.CurrentBadge})
                    End If
                Else
                    FlashAlerts.ShowInformation("El maximo en servicio esta completo." & vbCrLf & "No se genero ninguna serie para surtir.", 4)
                End If
            Else 'ALWAYS
                Dim next_serial = SMK.NextFIFO(partnumber, warehouse)
                If SMK.IsSerialFormat(next_serial) Then
                    SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {next_serial, warehouse, SupermarketCable.CurrentBadge})
                End If
            End If
        End If
    End Sub

    Public Shared Sub ManualNextSerial(ByVal partnumber As String, ByVal badge As String)
        Dim nextSerial As String = SQL.Current.GetString(String.Format("SELECT TOP 1 N.Serialnumber FROM Smk_CableNextSerials AS N INNER JOIN Smk_Serials AS S ON N.Serialnumber = S.Serialnumber WHERE Partnumber = '{0}' AND N.Warehouse = '{1}';", partnumber, My.Settings.Warehouse))
        If nextSerial <> "" Then
            If SQL.Current.GetScalar(String.Format("SELECT ISNULL(Maximum,0) - ISNULL(Serials,0) AS RemainQty FROM Smk_Map AS M LEFT OUTER JOIN (SELECT Partnumber,COUNT(ID) Serials FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Warehouse = '{1}' AND Status IN ('O','C') GROUP BY Partnumber) AS Cnt ON Cnt.Partnumber = M.Partnumber WHERE M.Partnumber = '{0}' AND M.Warehouse = '{1}';", partnumber, My.Settings.Warehouse)) > 0 Then
                nextSerial = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Status = 'S' AND Partnumber = '{0}' AND Warehouse  = '{1}' AND Serialnumber NOT IN (SELECT Serialnumber FROM Smk_CableNextSerials) ORDER BY ID ASC;", partnumber, My.Settings.Warehouse))
                If nextSerial = "" Then
                    nextSerial = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Status = 'S' AND Partnumber = '{0}' AND Serialnumber NOT IN (SELECT Serialnumber FROM Smk_CableNextSerials) ORDER BY ID ASC;", partnumber))
                    If nextSerial <> "" Then
                        SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {nextSerial, My.Settings.Warehouse, badge})
                        REC.PrintLabel(nextSerial)
                    Else
                        Dim zpl_label As String = My.Resources.ZPL_NoMaterial
                        If My.Settings.PrinterResolution = 200 Then
                            zpl_label = ZPL.TryChangeResolution(zpl_label, 300, 200)
                        End If
                        ZPL.PrintTo(zpl_label.Replace("@partnumber", partnumber).Replace("@date", Now.ToString("dd-MM-yy HH:mm")), My.Settings.Printer)
                        MsgBox("No existe material en planta para surtir. Notifique a su supervisor.", MsgBoxStyle.Exclamation)
                    End If
                Else
                    SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {nextSerial, My.Settings.Warehouse, badge})
                    REC.PrintLabel(nextSerial)
                End If
            Else
                REC.PrintLabel(nextSerial)
            End If
        Else
            nextSerial = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Status = 'S' AND Partnumber = '{0}' AND Warehouse  = '{1}' AND Serialnumber NOT IN (SELECT Serialnumber FROM Smk_CableNextSerials) ORDER BY ID ASC;", partnumber, My.Settings.Warehouse))
            If nextSerial = "" Then
                nextSerial = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Status = 'S' AND Partnumber = '{0}' AND Serialnumber NOT IN (SELECT Serialnumber FROM Smk_CableNextSerials) ORDER BY ID ASC;", partnumber))
                If nextSerial <> "" Then
                    SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {nextSerial, My.Settings.Warehouse, badge})
                    REC.PrintLabel(nextSerial)
                Else
                    Dim zpl_label As String = My.Resources.ZPL_NoMaterial
                    If My.Settings.PrinterResolution = 200 Then
                        zpl_label = ZPL.TryChangeResolution(zpl_label, 300, 200)
                    End If
                    ZPL.PrintTo(zpl_label.Replace("@partnumber", partnumber).Replace("@date", Now.ToString("dd-MM-yy HH:mm")), My.Settings.Printer)

                    MsgBox("No existe material en planta para surtir. Notifique a su supervisor.", MsgBoxStyle.Exclamation)
                End If
            Else
                SQL.Current.Insert("Smk_CableNextSerials", {"Serialnumber", "Warehouse", "Badge"}, {nextSerial, My.Settings.Warehouse, badge})
                REC.PrintLabel(nextSerial)
            End If
        End If
    End Sub
End Class
