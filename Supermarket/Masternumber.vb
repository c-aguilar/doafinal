Public Class Masternumber
    Public Sub New(masternumber As String)
        Dim record As Hashtable = SQL.Current.GetRecord("Smk_MasterLabels", "Masternumber", masternumber)
        If record IsNot Nothing AndAlso record.Count > 0 Then
            Me.Masternumber = masternumber.ToUpper
            Me.Exists = True
            Me.Badge = record.Item("badge")
            Me.ID = record.Item("id")
            For Each serial As DataRow In SQL.Current.GetDatatable(String.Format("SELECT S.Serialnumber FROM Smk_MasterSerials AS M INNER JOIN Smk_Serials AS S ON M.SerialID = S.ID WHERE MasterID = {0};", Me.ID)).Rows
                Serials.Add(New Serialnumber(serial.Item("Serialnumber")))
            Next
        End If
    End Sub
    Public Property Badge As String = ""
    Public Property Exists As Boolean = False
    Public Property ID As Integer = 0
    Public Property Masternumber As String
    Public Property Serials As New List(Of Serialnumber)
    Public ReadOnly Property TotalQuantity As Decimal
        Get
            Return Me.Serials.Sum(Function(s) s.Quantity)
        End Get
    End Property
    Public Function GeneralStatus() As MasterStatus
        If Serials.Where(Function(w) w.Status = Serialnumber.SerialStatus.New Or w.Status = Serialnumber.SerialStatus.Pending).Count = Serials.Count Then
            Return MasterStatus.Pending
        ElseIf Serials.Where(Function(w) w.Status = Serialnumber.SerialStatus.Stored).Count = Serials.Count Then
            Return MasterStatus.Stored
        ElseIf Serials.Where(Function(w) w.Status = Serialnumber.SerialStatus.Quality).Count = Serials.Count Then
            Return MasterStatus.Quality
        ElseIf Serials.Where(Function(w) w.Status = Serialnumber.SerialStatus.Tracker).Count = Serials.Count Then
            Return MasterStatus.Tracker
        ElseIf Serials.Where(Function(w) w.Status = Serialnumber.SerialStatus.Presupermarket).Count = Serials.Count Then
            Return MasterStatus.Presupermarket
        Else
            Return MasterStatus.Mixed
        End If
    End Function
    Public Function GeneralLocation() As String
        Dim location As String = Serials.Item(0).Location
        If Serials.Exists(Function(w) w.Location <> location) Then
            Return ""
        Else
            Return location
        End If
    End Function
    Enum MasterStatus
        Pending
        Presupermarket
        Stored
        Quality
        Tracker
        Mixed
    End Enum
End Class
