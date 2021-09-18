Public Class Sch_LevelScheduleNewLevelResult
    Public Property TotalRows As Integer
    Public Property TotalColumns As Integer
    Public Property WrongHarn As Integer
    Public Property WrongPlant As Integer
    Public Property WrongVersion As Integer
    Public Property WrongWeek As Integer
    Public Property WrongQuantity As Integer
    Private Sub Sch_LevelScheduleNewLevelResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HarnTotal_lbl.Text = TotalRows
        PlantTotal_lbl.Text = TotalRows
        VersionTotal_lbl.Text = TotalRows
        WeekTotal_lbl.Text = TotalRows
        QuantityTotal_lbl.Text = TotalRows * (TotalColumns - 4)
        HarnWrong_lbl.Text = WrongHarn
        PlantWrong_lbl.Text = WrongPlant
        VersionWrong_lbl.Text = WrongVersion
        WeekWrong_lbl.Text = WrongWeek
        QuantityWrong_lbl.Text = WrongQuantity
        HarnOK_lbl.Text = TotalRows - WrongHarn
        PlantOK_lbl.Text = TotalRows - WrongPlant
        VersionOK_lbl.Text = TotalRows - WrongVersion
        WeekOK_lbl.Text = TotalRows - WrongWeek
        QuantityOK_lbl.Text = (TotalRows * (TotalColumns - 4)) - WrongQuantity
        Harns_pb.Image = If(HarnOK_lbl.Text = HarnTotal_lbl.Text, My.Resources.ok_16, My.Resources.cross_16)
        Plant_pb.Image = If(PlantOK_lbl.Text = PlantTotal_lbl.Text, My.Resources.ok_16, My.Resources.cross_16)
        Version_pb.Image = If(VersionOK_lbl.Text = VersionTotal_lbl.Text, My.Resources.ok_16, My.Resources.cross_16)
        Week_pb.Image = If(WeekOK_lbl.Text = WeekTotal_lbl.Text, My.Resources.ok_16, My.Resources.cross_16)
        Quantity_pb.Image = If(QuantityOK_lbl.Text = QuantityTotal_lbl.Text, My.Resources.ok_16, My.Resources.cross_16)
    End Sub

    Private Sub Accept_btn_Click(sender As Object, e As EventArgs) Handles Accept_btn.Click
        Me.Close()
    End Sub

    Private Sub Sch_LevelScheduleNewLevelResult_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class