Imports DPUruNet

Public Class ReaderSelection

    Private _readers As ReaderCollection

    Private _reader As Reader
    Public Property CurrentReader() As Reader
        Get
            Return _reader
        End Get
        Set(ByVal value As Reader)
            _reader = value
        End Set
    End Property


    ''' <summary>
    ''' Clear the control of readers, get readers and display.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        cboReaders.Text = String.Empty
        cboReaders.Items.Clear()
        cboReaders.SelectedIndex = -1
        Try

            _readers = ReaderCollection.GetReaders()

            For Each Reader As Reader In _readers
                cboReaders.Items.Add(Reader.Description.SerialNumber)
            Next

            If cboReaders.Items.Count > 0 Then
                cboReaders.SelectedIndex = 0
                btnCaps.Enabled = True
                btnSelect.Enabled = True
            Else
                btnSelect.Enabled = False
                btnCaps.Enabled = False
            End If
        Catch ex As Exception
            REM message box:
            MessageBox.Show("Valida que el lector este conectado." + ex.Message, "Error")
        End Try
    End Sub

    Private _capabilities As Capabilities
    Private Sub btnCaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaps.Click
        _reader = _readers(cboReaders.SelectedIndex)

        If (_capabilities Is Nothing) Then
            _capabilities = New Capabilities()
            _capabilities.Sender = Me
        End If

        _capabilities.ShowDialog()

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Fingerprint.Current.Reader = _readers(cboReaders.SelectedIndex)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ReaderSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRefresh_Click(sender, e)
    End Sub
End Class