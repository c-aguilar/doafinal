Imports DPUruNet
Imports DPUruNet.Constants
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class Fingerprint
    ' See the SDK documentation for an explanation on threshold scores.
    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF
    Public Shared Property ThresholdScore As Integer = DPFJ_PROBABILITY_ONE * 1 / 1000000
    Dim _reader As Reader
    Private Shared _fpreader As New Fingerprint
    Public Shared ReadOnly Property Current As Fingerprint
        Get
            Return _fpreader
        End Get
    End Property

    Public Shared Function GetBadge() As String
        Dim fingerprinter As New Indentification
        If fingerprinter.ShowDialog = Windows.Forms.DialogResult.OK Then
            fingerprinter.Dispose()
            Return fingerprinter.IdentifiedBadge
        Else
            fingerprinter.Dispose()
            Return ""
        End If
    End Function

    Public Sub New()

    End Sub

    Public Property Reader() As Reader
        Get
            Return _reader
        End Get
        Set(ByVal value As Reader)
            _reader = value
        End Set
    End Property

    Public Property Reset() As Boolean
        Get
            Return _reset
        End Get
        Set(ByVal value As Boolean)
            _reset = value
        End Set
    End Property
    Private _reset As Boolean

    Public Function OpenReader() As Boolean
        Me.Reset = False
        Dim result As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE

        Me.Reset = False
        result = Me.Reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)

        If result <> Constants.ResultCode.DP_SUCCESS Then
            MessageBox.Show("Error:  " & result.ToString())
            Reset = True
            Return False
        End If

        Return True
    End Function

    Public Shared Sub RefreshFingerprintDatabase()
        Dim operators As DataTable = SQL.Current.GetDatatable("SELECT Badge, Fingerprint FROM Smk_Operators WHERE [Active] = 1 AND Fingerprint IS NOT NULL ORDER BY Badge;")
        FingerprintsDatabaseList = New List(Of FingerprintData)
        For Each row As DataRow In operators.Rows
            FingerprintsDatabaseList.Add(New FingerprintData(row.Item("Badge"), Fmd.DeserializeXml(row.Item("Fingerprint"))))
        Next
    End Sub

    Public Shared Property FingerprintsDatabaseList As List(Of FingerprintData)
    Public Shared ReadOnly Property FingerprintDatabaseFMDArray As List(Of Fmd)
        Get
            Dim list As New List(Of Fmd)
            For Each i In Fingerprint.FingerprintsDatabaseList
                list.Add(i.FMD)
            Next
            Return list
        End Get
    End Property

    Public Class FingerprintData
        Public Sub New(badge As String, fmd As Fmd)
            Me.Badge = badge
            Me.FMD = fmd
        End Sub
        Public Property Badge As String
        Public Property FMD As Fmd
    End Class

    ''' <summary>
    ''' Hookup capture handler and start capture.
    ''' </summary>
    ''' <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
    ''' <returns>Returns true if successful; false if unsuccessful</returns>
    Public Function StartCaptureAsync(ByVal OnCaptured As Reader.CaptureCallback) As Boolean
        AddHandler Me.Reader.On_Captured, OnCaptured

        If Not CaptureFingerAsync() Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Cancel the capture and then close the reader.
    ''' </summary>
    ''' <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
    Public Sub CancelCaptureAndCloseReader(ByVal OnCaptured As Reader.CaptureCallback)
        If Me.Reader IsNot Nothing Then
            Reader.CancelCapture()

            ' Dispose of reader handle and unhook reader events.
            Reader.Dispose()

            If (Reset) Then
                Me.Reader = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' Check quality of the resulting capture.
    ''' </summary>
    Public Function CheckCaptureResult(ByVal captureResult As CaptureResult) As Boolean
        If captureResult.Data Is Nothing Then
            If captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                Reset = True
                Throw New Exception("" & captureResult.ResultCode.ToString())
            End If

            If captureResult.Quality <> Constants.CaptureQuality.DP_QUALITY_CANCELED Then
                Throw New Exception("Quality - " & captureResult.Quality.ToString())
            End If
            Return False
        End If
        Return True
    End Function

    ''' <summary>Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors. </summary>
    Public Function CaptureFingerAsync() As Boolean
        Try
            Me.GetStatus()

            Dim captureResult = Me.Reader.CaptureAsync(Formats.Fid.ANSI, _
                                                   CaptureProcessing.DP_IMG_PROC_DEFAULT, _
                                                    Me.Reader.Capabilities.Resolutions(0))

            If captureResult <> ResultCode.DP_SUCCESS Then
                Reset = True
                Throw New Exception("" + captureResult.ToString())
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Error:  " & ex.Message)
            Return False
        End Try
    End Function



    ''' <summary>
    ''' Check the device status before starting capture.
    ''' </summary>
    Private Sub GetStatus()
        Dim result = Me.Reader.GetStatus()

        If (result <> ResultCode.DP_SUCCESS) Then
            If Reader IsNot Nothing Then
                Reset = True
                Throw New Exception("" & result.ToString())
            End If
        End If

        If (Me.Reader.Status.Status = ReaderStatuses.DP_STATUS_BUSY) Then
            Threading.Thread.Sleep(50)
        ElseIf (Me.Reader.Status.Status = ReaderStatuses.DP_STATUS_NEED_CALIBRATION) Then
            Me.Reader.Calibrate()
        ElseIf (Me.Reader.Status.Status <> ReaderStatuses.DP_STATUS_READY) Then
            Throw New Exception("Reader Status - " & Reader.Status.Status.ToString())
        End If
    End Sub


    ''' <summary>
    ''' Create a bitmap from raw data in row/column format.
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateBitmap(ByVal bytes As [Byte](), ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim rgbBytes As Byte() = New Byte(bytes.Length * 3 - 1) {}

        For i As Integer = 0 To bytes.Length - 1
            rgbBytes((i * 3)) = bytes(i)
            rgbBytes((i * 3) + 1) = bytes(i)
            rgbBytes((i * 3) + 2) = bytes(i)
        Next
        Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)

        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)

        For i As Integer = 0 To bmp.Height - 1
            Dim p As New IntPtr(data.Scan0.ToInt64() + data.Stride * i)
            System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3)
        Next

        bmp.UnlockBits(data)
        Return bmp
    End Function
End Class
