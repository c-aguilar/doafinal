Public Class MSpec
    Public Sub New(partnumber As String)
        Dim record As Hashtable = SQL.Current.GetRecord("PE_MSpecs", "Partnumber", partnumber)
        Me.Partnumber = record.Item("partnumber")
        Me.Gage = record.Item("gage")
        Me.CC = record.Item("cc")
        Me.SAPColor = record.Item("sapcolor")
        Me.SAPStripeColor = record.Item("sapstripecolor")
        Me.Threads = record.Item("threads")
    End Sub
    Public Sub New(partnumber As String, gage As Decimal, cc As Decimal, sapcolor As String, sapstripecolor As String, threads As Integer)
        Me.Partnumber = partnumber
        Me.Gage = gage
        Me.CC = cc
        Me.SAPColor = sapcolor
        Me.SAPStripeColor = sapstripecolor
        Me.Threads = threads
    End Sub
    Public Property Partnumber As String
    Public Property Gage As Decimal
    Public Property CC As Decimal
    Public Property SAPColor As String
    Public Property SAPStripeColor As String
    Public Property Threads As Integer
End Class
