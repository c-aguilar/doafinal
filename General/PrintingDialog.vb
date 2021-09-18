Public Class PrintingDialog

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public ReadOnly Property ChoosenFormat As Format
        Get
            If rbExcel.Checked Then
                Return Format.Excel
            Else
                Return Format.PDF
            End If
        End Get
    End Property


    Public Enum Format
        Excel
        PDF
    End Enum

    Private Sub ExportDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class