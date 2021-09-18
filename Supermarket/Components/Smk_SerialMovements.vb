Imports System.Runtime.InteropServices
Public Class Smk_SerialMovements
    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    End Function

    Dim is_exporting As Boolean = False


    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStripMain.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Public Property Serialnumber As String

    Private Sub Smk_SerialMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Title_lbl.Text = Me.Serialnumber
        Movements_dgv.DataSource = SQL.Current.GetDatatable(String.Format("SELECT D.[Description],CASE WHEN M.Movement IN ('CCR','RTC','STC') THEN C.Name ELSE M.[Location] END AS Location,M.Quantity,S.UoM ,O.Fullname,M.[Date],T.Posted,T.Quantity-AdjustmentQuantity AS [TransferQuantity],T.FromSloc,T.ToSloc,DocumentNumber,U.Fullname AS [TransferUser]  FROM [Smk_SerialMovements] AS M LEFT OUTER JOIN Smk_MovementsDescription AS D ON M.Movement = D.Movement LEFT OUTER JOIN Smk_Serials AS S ON M.SerialID = S.ID LEFT OUTER JOIN Smk_SAPTransfers AS T ON M.ID = T.MovementID LEFT OUTER JOIN Smk_Operators AS O ON M.Badge = O.Badge LEFT OUTER JOIN Sys_Users AS U ON T.PostedUsername = U.Username LEFT OUTER JOIN PE_Cutters AS C ON M.Location = C.ID WHERE S.Serialnumber = '{0}' ORDER BY M.[Date] DESC;", Me.Serialnumber), Me.Serialnumber)
    End Sub

    Private Sub Export_btn_Click(sender As Object, e As EventArgs) Handles Export_btn.Click
        is_exporting = True
        Delta.Export(Movements_dgv.DataSource, Title_lbl.Text)
        is_exporting = False
    End Sub

    Private Sub Smk_SerialMovements_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If Not Movements_dgv.FilterDisplayed AndAlso Not is_exporting Then Me.Close()
    End Sub

    Private Sub Smk_SerialMovements_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub

End Class