Public Class DDR_Containerization
    Dim raw As RawMaterial
    Dim _scale As New Scale
    Private Sub DDR_Containerization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            ReadPartnumber()
        End If
    End Sub


    Private Sub ReadPartnumber()
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                raw = New RawMaterial(Partnumber_txt.Text)
                Description_lbl.Text = raw.Description
                Icon_pb.Image = IIf(raw.UnitWeightValidated, My.Resources.tick_32, My.Resources.cross_32)
                Dim containerization = SQL.Current.GetRecord("CDR_Containerization", "Partnumber", raw.Partnumber)
                If containerization.Count > 0 Then
                    C14_nud.Value = containerization("cnt_1_4")
                    C12_nud.Value = containerization("cnt_1_2")
                    C16s_nud.Value = containerization("cnt_16s")
                    C8s_nud.Value = containerization("cnt_8s")
                    C4s_nud.Value = containerization("cnt_4s")
                    C2s_nud.Value = containerization("cnt_2s")
                    CJT_nud.Value = containerization("cnt_jt")
                End If

                Send14_btn.Enabled = True
                Send12_btn.Enabled = True
                Send16_btn.Enabled = True
                Send8_btn.Enabled = True
                Send4_btn.Enabled = True
                Send2_btn.Enabled = True
                SendJT_btn.Enabled = True

                If raw.UoM = RawMaterial.UnitOfMeasure.PC OrElse raw.UoM = RawMaterial.UnitOfMeasure.ROL Then
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/" & raw.UoM.ToString
                    StdPack_txt.Text = CInt(raw.RoundingValue)
                ElseIf SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, "PC", raw.UoM.ToString}) OrElse SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, raw.UoM.ToString, "PC"}) Then
                    raw.WeightOnGr = RawMaterial.GetWeightByUoM(raw.Partnumber, "PC")
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/PC"
                    StdPack_txt.Text = CInt(RawMaterial.ConvertUoM(raw.Partnumber, raw.UoM.ToString, raw.RoundingValue, "PC"))
                ElseIf SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, "ROL", raw.UoM.ToString}) OrElse SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, raw.UoM.ToString, "ROL"}) Then
                    raw.WeightOnGr = RawMaterial.GetWeightByUoM(raw.Partnumber, "ROL")
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/ROL"
                    StdPack_txt.Text = CInt(RawMaterial.ConvertUoM(raw.Partnumber, raw.UoM.ToString, raw.RoundingValue, "ROL"))
                Else
                    Clear()
                    FlashAlerts.ShowError("El número de parte no se puede contenerizar en PC.")
                End If
                If Scale_chk.Checked AndAlso raw IsNot Nothing Then _scale.StartReading()
            Else
                Clear()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Clear()
        _scale.StopReading()
        raw = Nothing
        Icon_pb.Image = Nothing
        Partnumber_txt.Clear()
        Description_lbl.Text = ""
        CurrentWeight_lbl.Text = ""
        CurrentWeight_lbl.ForeColor = Color.Black
        StdPack_txt.Clear()
        UoM_lbl.Text = ""
        C14_nud.Value = 0
        C12_nud.Value = 0
        C16s_nud.Value = 0
        C8s_nud.Value = 0
        C4s_nud.Value = 0
        C2s_nud.Value = 0
        CJT_nud.Value = 0

        Qty14_lbl.Text = "0"
        Qty12_lbl.Text = "0"
        Qty16_lbl.Text = "0"
        Qty8_lbl.Text = "0"
        Qty4_lbl.Text = "0"
        Qty2_lbl.Text = "0"
        QtyJT_lbl.Text = "0"

        Send14_btn.Enabled = False
        Send12_btn.Enabled = False
        Send16_btn.Enabled = False
        Send8_btn.Enabled = False
        Send4_btn.Enabled = False
        Send2_btn.Enabled = False
        SendJT_btn.Enabled = False
        C14_nud.BackColor = Color.Ivory
        C12_nud.BackColor = Color.Ivory
        C16s_nud.BackColor = Color.Ivory
        C8s_nud.BackColor = Color.Ivory
        C4s_nud.BackColor = Color.Ivory
        C2s_nud.BackColor = Color.Ivory
        CJT_nud.BackColor = Color.Ivory
        Partnumber_txt.Focus()
    End Sub

    Private Sub Scale_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Scale_chk.CheckedChanged
        If Scale_chk.Checked AndAlso raw IsNot Nothing Then
            _scale.StartReading()
        ElseIf Not Scale_chk.Checked Then
            _scale.StopReading()
        End If

    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim weight As Decimal = _scale.NewValue
        If weight >= 0 AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Weight_lbl.Text = weight
            Qty14_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C1_4)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            Qty12_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C1_2)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            Qty16_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C16s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            Qty8_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C8s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            Qty4_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C4s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            Qty2_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.C2s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            QtyJT_lbl.Text = Math.Ceiling(((weight - CDR.ContainerWeight(CDR.RouteContainer.JT)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
        End If

        If _scale.IsReading AndAlso _scale.IsStable Then
            Weight_lbl.BackColor = Color.LimeGreen
            Weight_lbl.ForeColor = Color.White
        ElseIf _scale.IsReading Then
            Weight_lbl.BackColor = Color.Maroon
            Weight_lbl.ForeColor = Color.White
        Else
            Weight_lbl.BackColor = Color.DimGray
            Weight_lbl.ForeColor = Color.Black
        End If
        Application.DoEvents()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If raw IsNot Nothing Then
            If CJT_nud.Value < C2s_nud.Value AndAlso Not CJT_nud.Value = 0 Then
                FlashAlerts.ShowError("La cantidad en JT no puede ser menor a 2s.")
            ElseIf C2s_nud.Value < C4s_nud.Value AndAlso Not C2s_nud.Value = 0 Then
                FlashAlerts.ShowError("La cantidad en 2s no puede ser menor a 4s.")
            ElseIf C4s_nud.Value < C8s_nud.Value AndAlso Not C4s_nud.Value = 0 Then
                FlashAlerts.ShowError("La cantidad en 4s no pueder ser menor a 8s.")
            ElseIf C8s_nud.Value < C16s_nud.Value AndAlso Not C8s_nud.Value = 0 Then
                FlashAlerts.ShowError("La cantidad en 8s no puede ser menor a 16s.")
            ElseIf C16s_nud.Value < C12_nud.Value Then
                FlashAlerts.ShowError("La cantidad en 16s no puede ser menor a 1/2 16s.")
            ElseIf C12_nud.Value < C14_nud.Value Then
                FlashAlerts.ShowError("La cantidad en 1/2 16s no puede ser menor a 1/4 16s.")
            Else
                If SQL.Current.Exists("CDR_Containerization", "Partnumber", raw.Partnumber) Then
                    If SQL.Current.Update("CDR_Containerization", {"Cnt_JT", "Cnt_2s", "Cnt_4s", "Cnt_8s", "Cnt_16s", "Cnt_1_2", "Cnt_1_4", "Cnt_StdPack"}, {CJT_nud.Value, C2s_nud.Value, C4s_nud.Value, C8s_nud.Value, C16s_nud.Value, C12_nud.Value, C14_nud.Value, StdPack_txt.Text}, "Partnumber", raw.Partnumber) Then
                        Log(raw.Partnumber, "CDR_UpdateContainerization")
                        Clear()
                        FlashAlerts.ShowConfirm("Hecho.")
                    Else
                        FlashAlerts.ShowError("No fue posible actualizar la contenerización.")
                    End If
                Else
                    If SQL.Current.Insert("CDR_Containerization", {"Cnt_JT", "Cnt_2s", "Cnt_4s", "Cnt_8s", "Cnt_16s", "Cnt_1_2", "Cnt_1_4", "Cnt_StdPack", "Partnumber"}, {CJT_nud.Value, C2s_nud.Value, C4s_nud.Value, C8s_nud.Value, C16s_nud.Value, C12_nud.Value, C14_nud.Value, StdPack_txt.Text, raw.Partnumber}) Then
                        Log(raw.Partnumber, "CDR_UpdateContainerization")
                        Clear()
                        FlashAlerts.ShowConfirm("Hecho.")
                    Else
                        FlashAlerts.ShowError("No fue posible actualizar la contenerización.")
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub Sample_btn_Click(sender As Object, e As EventArgs) Handles Sample_btn.Click
        _scale.StopReading()
        If User.Current.HasPermission("Supermarket_SamplesWeight_Edit_flag") Then
            Dim new_sample As New Smk_SamplesWeight
            new_sample.ShowDialog()
            new_sample.Dispose()

            If raw IsNot Nothing Then
                raw = New RawMaterial(raw.Partnumber) 'VOLVER A CARGAR PESO UNITARIO Y VALIDACION
                Icon_pb.Image = IIf(raw.UnitWeightValidated, My.Resources.tick_32, My.Resources.cross_32)
                If raw.UoM = RawMaterial.UnitOfMeasure.PC OrElse raw.UoM = RawMaterial.UnitOfMeasure.ROL Then
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/" & raw.UoM.ToString
                    StdPack_txt.Text = CInt(raw.RoundingValue)
                ElseIf SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, "PC", raw.UoM.ToString}) OrElse SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, raw.UoM.ToString, "PC"}) Then
                    raw.WeightOnGr = RawMaterial.GetWeightByUoM(raw.Partnumber, "PC")
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/PC"
                    StdPack_txt.Text = CInt(RawMaterial.ConvertUoM(raw.Partnumber, raw.UoM.ToString, raw.RoundingValue, "PC"))
                ElseIf SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, "ROL", raw.UoM.ToString}) OrElse SQL.Current.Exists("Sys_ConversionUnits", {"Partnumber", "BuM", "AuM"}, {raw.Partnumber, raw.UoM.ToString, "ROL"}) Then
                    raw.WeightOnGr = RawMaterial.GetWeightByUoM(raw.Partnumber, "ROL")
                    CurrentWeight_lbl.Text = raw.WeightOnGr
                    CurrentWeight_lbl.ForeColor = IIf(raw.WeightOnGr = 0, Color.Red, Color.Black)
                    UoM_lbl.Text = "g/ROL"
                    StdPack_txt.Text = CInt(RawMaterial.ConvertUoM(raw.Partnumber, raw.UoM.ToString, raw.RoundingValue, "ROL"))
                End If
            End If
            _scale.StartReading()
        Else
            FlashAlerts.ShowError("No tienes autorización para realizar esta acción.")
        End If
    End Sub

    Private Sub DDR_Containerization_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub

    Private Sub Settings_btn_Click(sender As Object, e As EventArgs) Handles Settings_btn.Click
        _scale.StopReading()
        Dim settings As New Smk_SmkSettings
        settings.ShowDialog()
        settings.Dispose()
        If raw IsNot Nothing Then _scale.StartReading()
    End Sub

    Private Sub Send14_btn_Click(sender As Object, e As EventArgs) Handles Send14_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C1_4)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C14_nud.Value = quantity
                C14_nud.BackColor = Color.Lime
            Else
                C14_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub Send12_btn_Click(sender As Object, e As EventArgs) Handles Send12_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C1_2)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C12_nud.Value = quantity
                C12_nud.BackColor = Color.Lime
            Else
                C12_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub Send16_btn_Click(sender As Object, e As EventArgs) Handles Send16_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C16s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C16s_nud.Value = quantity
                C16s_nud.BackColor = Color.Lime
            Else
                C16s_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub Send8_btn_Click(sender As Object, e As EventArgs) Handles Send8_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C8s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C8s_nud.Value = quantity
                C8s_nud.BackColor = Color.Lime
            Else
                C8s_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub Send4_btn_Click(sender As Object, e As EventArgs) Handles Send4_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C4s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C4s_nud.Value = quantity
                C4s_nud.BackColor = Color.Lime
            Else
                C4s_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub Send2_btn_Click(sender As Object, e As EventArgs) Handles Send2_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.C2s)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                C2s_nud.Value = quantity
                C2s_nud.BackColor = Color.Lime
            Else
                C2s_nud.Value = 0
            End If
        End If
    End Sub

    Private Sub SendJT_btn_Click(sender As Object, e As EventArgs) Handles SendJT_btn.Click
        If _scale.IsReading AndAlso _scale.IsStable AndAlso raw IsNot Nothing AndAlso raw.WeightOnGr > 0 Then
            Dim quantity As Integer = Math.Ceiling(((_scale.NewValue - CDR.ContainerWeight(CDR.RouteContainer.JT)) * My.Settings.SupermarketComponentScaleFactor * 1000) / raw.WeightOnGr)
            If quantity >= 0 Then
                CJT_nud.Value = quantity
                CJT_nud.BackColor = Color.Lime
            Else
                CJT_nud.Value = 0
            End If
        End If
    End Sub
End Class