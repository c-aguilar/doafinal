Public Class Alphanumeric
    Shared letters() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z"}
    Shared alphaLenght As Integer = 7
    Public Shared Function ToDecimal(value As String) As Long
        Try
            If value.Length > alphaLenght Then
                Return 0
            End If
            Dim dec As Int64 = 0
            Dim i = value.Length
            For Each chr As Char In value.ToCharArray
                dec += DecimalPosition(i, chr)
                i -= 1
            Next
            Return dec
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ToAlphanumeric(value As Long) As String
        Dim alpha As String = ""
        For i = alphaLenght - 1 To 0 Step -1
            Dim resid As Integer = Math.Truncate(value / Math.Pow(letters.Length, i))
            alpha &= letters(resid)
            value -= resid * Math.Pow(letters.Length, i)
        Next
        Return alpha
    End Function
    Private Shared Function DecimalPosition(position As Integer, chr As Char) As Long
        For i = 0 To letters.Length - 1
            If letters(i) = chr Then
                Return i * Math.Pow(letters.Length, position - 1)
            End If
        Next
        Return 0
    End Function
    Public Shared Function IsValidAlphanumeric(value As String) As Boolean
        value = value.ToUpper
        If Not value.Length = alphaLenght Then
            Return False
        End If
        For Each l In value.ToCharArray
            If Not letters.Contains(l) Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
