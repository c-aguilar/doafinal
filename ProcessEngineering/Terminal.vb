Public Class Terminal
    Public Sub New(partnumber As String)
        Dim record As Hashtable = SQL.Current.GetRecord("PE_Terminals", "Partnumber", partnumber)
        Me.Partnumber = partnumber
        Me.Gage = record.Item("gage")
        Me.CCH = record.Item("cch")
        Me.CCW = record.Item("ccw")
        Me.ICH = record.Item("ich")
        Me.ICW = record.Item("icw")
        Me.StrippingLength = record.Item("strippinglength")
        Me.Tolerance = record.Item("tolerance")
    End Sub
    Public Sub New(partnumber As String, gage As Decimal, cch As Decimal, ccw As Decimal, ich As Decimal, icw As Decimal, strippinglength As Decimal, tolerance As Decimal, tension As Integer)
        Me.Partnumber = partnumber
        Me.Gage = gage
        Me.ICH = ich
        Me.ICW = icw
        Me.CCH = cch
        Me.CCW = ccw
        Me.StrippingLength = strippinglength
        Me.Tolerance = tolerance
    End Sub
    Public Property Partnumber As String
    Public Property Gage As Decimal
    Public Property CCH As Decimal
    Public Property CCW As Decimal
    Public Property ICH As Decimal
    Public Property ICW As Decimal
    Public Property StrippingLength As Decimal
    Public Property Tension As Integer
    Public Property Tolerance As Decimal
End Class
