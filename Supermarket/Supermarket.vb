Public Class SMK
    Public Shared Function IsSerialFormat(serial As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(serial, "^[sS]?\d" & Parameter("SYS_PlantCode") & "[0-9]{10}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Public Shared Function IsMasterSerialFormat(serial As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(serial, Parameter("SYS_PlantCode") & "M[0-9]{9}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Public Shared Function IsLinkSerialFormat(serial As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(serial, Parameter("SYS_PlantCode") & "L[0-9]{9}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Public Shared Function IsRawMaterialFormat(partnumber As String) As Boolean
        'Return System.Text.RegularExpressions.Regex.IsMatch(partnumber, "^(?=.*\d)[A-Za-z\d]{8}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Return System.Text.RegularExpressions.Regex.IsMatch(partnumber, "^[A-Za-z0-9]{8}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function

    Public Shared Function NextFIFO(partnumber As String) As String
        Dim fifo As String = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Status IN ('S','Q','T') AND RedTag = 0 AND InvoiceTrouble = 0 ORDER BY ID ASC", partnumber))
        Return fifo
    End Function

    Public Shared Function Minimum(partnumber As String, warehouse As String) As Integer
        Return SQL.Current.GetScalar("Minimum", "Smk_Map", {"Partnumber", "Warehouse"}, {partnumber, warehouse}, 0)
    End Function

    Public Shared Function Maximum(partnumber As String, warehouse As String) As Integer
        Return SQL.Current.GetScalar("Maximum", "Smk_Map", {"Partnumber", "Warehouse"}, {partnumber, warehouse}, 0)
    End Function

    Public Shared Function GetServiceLocations(partnumber As String) As String
        Return RawMaterial.GetServiceLocations(partnumber)
    End Function

    Public Shared Function GetServiceLocation(partnumber As String, warehouse As String) As String
        Return RawMaterial.GetServiceLocation(partnumber, warehouse)
    End Function

    Public Shared Function NextFIFO(partnumber As String, warehouse As String) As String
        Dim fifo As String = SQL.Current.GetString(String.Format("SELECT TOP 1 Serialnumber FROM vw_Smk_Serials WHERE Partnumber = '{0}' AND Warehouse = '{1}' AND Status IN ('S','Q','T') AND RedTag = 0 AND InvoiceTrouble = 0 ORDER BY ID ASC", partnumber, warehouse))
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

    Public Shared Function FormatLinkLabel(partnumber As String, description As String, serial As String) As String
        Return My.Resources.ZPL_LinkLabel.Replace("@partnumber", partnumber).Replace("@description", description).Replace("@serial", serial)
    End Function

End Class
