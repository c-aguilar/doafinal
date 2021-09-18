Imports System.IO.Ports
Imports System.Threading
Imports System.Text.RegularExpressions
Public Class Scale
    Dim _continue As Boolean = False
    Dim _serialPort As SerialPort
    Dim thScale As Thread
    Public InternalTimer As New System.Windows.Forms.Timer With {.Enabled = True, .Interval = 500}
    Public Property NewValue As Decimal
    Public Property OldValue As Decimal = 0
    Public Property IsStable As Boolean = False
    Public Property IsReading As Boolean = False
    Public Property IsError As Boolean = False

    Private Sub ReadScale()
        Try
            'While True 'PARA PRUEBAS POR FALTA DE UNA BASCULA
            '    Me.NewValue = 1
            '    Me.OldValue = 1
            '    Me.IsReading = True
            '    Me.IsStable = True
            '    Thread.Sleep(500)
            'End While

            Me.IsError = False
            _serialPort = Nothing
            _serialPort = New SerialPort
            With _serialPort
                .ParityReplace = &H3B
                .PortName = My.Settings.COM
                .BaudRate = My.Settings.Baudrate
                .Parity = IO.Ports.Parity.None
                .DataBits = My.Settings.Databits
                .StopBits = My.Settings.Stopbits
                .Handshake = IO.Ports.Handshake.None
                .RtsEnable = False
                .ReceivedBytesThreshold = 1
                .NewLine = vbCrLf
                .ReadTimeout = 2000
                .Close()
                .Open()
            End With
            _continue = True


            While _continue AndAlso _serialPort IsNot Nothing AndAlso _serialPort.IsOpen()
                Me.IsReading = True
                Dim strReturn As String = ""
                Dim incoming As String = ""

                Select Case My.Settings.ScaleModel
                    Case "Ohaus Ranger Count 3000"
                        _serialPort.WriteLine("IP")
                        Try
                            incoming = _serialPort.ReadLine()
                            strReturn = Regex.Match(incoming, "\-?[0-9]+(\.[0-9]+)?", RegexOptions.None).Value
                        Catch ex As Exception
                            strReturn = ""
                        End Try
                    Case "Avery Weigh-Tronix ZK840"

                        Dim tara As Decimal = 0
                        _serialPort.WriteLine("M") 'PEDIR LA TARA
                        Try
                            incoming = _serialPort.ReadLine().Trim
                            If incoming.StartsWith("1G") OrElse incoming.StartsWith("1N") Then
                                incoming = incoming.Remove(0, 2).Trim()
                            ElseIf incoming.StartsWith("1GM") OrElse incoming.StartsWith("1NM") Then
                                incoming = incoming.Remove(0, 3).Trim()
                            End If
                            strReturn = Regex.Match(incoming, "\-?[0-9]+(\.[0-9]+)?", RegexOptions.None).Value
                        Catch ex As Exception
                            strReturn = ""
                        End Try
                        If IsNumeric(strReturn) Then
                            tara = CDec(strReturn)
                        End If



                        _serialPort.WriteLine("W")
                        Try
                            incoming = _serialPort.ReadLine().Trim
                            If incoming.StartsWith("1G") OrElse incoming.StartsWith("1N") Then
                                incoming = incoming.Remove(0, 2).Trim()
                            ElseIf incoming.StartsWith("1GM") OrElse incoming.StartsWith("1NM") Then
                                incoming = incoming.Remove(0, 3).Trim()
                            End If
                            strReturn = Regex.Match(incoming, "\-?[0-9]+(\.[0-9]+)?", RegexOptions.None).Value
                        Catch ex As Exception
                            strReturn = ""
                        End Try
                        If IsNumeric(strReturn) Then
                            strReturn = CDec(strReturn) - tara
                        End If

                    Case Else ' "Ohaus 3000 Series", "Ohaus Defender 3000"
                        Dim ComBuffer As Byte()
                        Dim btRead As Integer
                        Try
                            btRead = _serialPort.BytesToRead
                            If btRead > 50 Then
                                ComBuffer = New Byte(btRead - 1) {}
                                _serialPort.Read(ComBuffer, 0, btRead)
                                Dim longBuffer As Long
                                longBuffer = ComBuffer.Length
                                For i = 0 To longBuffer - 1
                                    incoming &= Chr(ComBuffer(i))
                                Next
                                If incoming.Length > 2 Then
                                    Dim isNum As Boolean = False
                                    For i = 1 To incoming.Length
                                        If IsNumeric(Mid(incoming, i, 1)) Or Mid(incoming, i, 1) = "." Then
                                            strReturn &= Mid(incoming, i, 1)
                                            isNum = True
                                        Else
                                            If isNum Then Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Catch generatedExceptionName As TimeoutException
                            strReturn = ""
                        End Try
                End Select

                If IsNumeric(strReturn) Then
                    Me.OldValue = Me.NewValue
                    Me.NewValue = CDec(strReturn)
                    If Me.OldValue = NewValue Then
                        Me.IsStable = True
                    Else
                        Me.IsStable = False
                    End If
                End If

                Select Case My.Settings.ScaleModel
                    Case "Ohaus Ranger Count 3000", "Avery Weigh-Tronix ZK840"
                        Thread.Sleep(400)
                    Case Else

                End Select
            End While
        Catch ex As Exception
            Me.IsError = True
        Finally
            Me.NewValue = 0
            Me.OldValue = 0
            Me.IsStable = True
            Me.IsReading = False
            If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                _serialPort.Close()
            End If
        End Try
    End Sub

    Public Sub StartReading()
        StopReading()
        Me.IsStable = False
        thScale = New Thread(AddressOf ReadScale)
        thScale.IsBackground = True
        thScale.Start()
        Me.InternalTimer.Enabled = True
        Me.InternalTimer.Start()
    End Sub

    Public Sub StopReading()
        _continue = False
        Me.InternalTimer.Stop()
        While Me.IsReading
            'DEJAR QUE TERMINE DE LEER
        End While
        If thScale IsNot Nothing Then
            If thScale.IsAlive Then
                thScale.Abort()
            End If
        End If   
        If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
            _serialPort.Close()
        End If
    End Sub

    Public Sub Dispose()
        StopReading()
        Me.InternalTimer.Stop()
        Me.InternalTimer.Dispose()
        If _serialPort IsNot Nothing Then
            _serialPort.Dispose()
        End If
    End Sub
End Class
