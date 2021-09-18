Public Class SMK
    Public Shared Function IsSerial(serial As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(serial, "\w?\d" & Parameter("SYS_PlantCode") & "[0-9]{10}", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function

    Public Shared Function NextFIFO(partnumber As String) As String
        Return SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "Status"}, {partnumber, "S"}, {"ID ASC"}, "").ToUpper
    End Function

    Public Shared Function NextFIFO(partnumber As String, warehouse As String) As String
        Dim fifo As String = SQL.Current.GetString("TOP 1 Serialnumber", "vw_Smk_Serials", {"Partnumber", "Warehouse", "Status"}, {partnumber, warehouse, "S"}, {"ID ASC"}, "").ToUpper
        If fifo = "" Then
            fifo = NextFIFO(partnumber)
        End If
        Return fifo
    End Function
    Public Shared Function CurrentSerial(partnumber As String, Optional ignore_zero As Boolean = True) As String
        If ignore_zero Then
            Return SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Status IN ('O','C') AND CurrentQuantity > 0 ORDER BY ID ASC;", partnumber))
        Else
            Return SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Status IN ('O','C') ORDER BY ID ASC;", partnumber))
        End If
    End Function
End Class
