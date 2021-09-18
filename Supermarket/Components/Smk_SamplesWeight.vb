Imports System.IO.Ports
Imports System.Threading
Public Class Smk_SamplesWeight
    Dim raw As RawMaterial
    Dim _scale As New Scale
    Dim factor As Decimal = 1
    Private Sub Smk_PartialDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Partnumber_txt.Focus()
        Scale_chk.Checked = My.Settings.SupermarketComponentScale
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
    End Sub

    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.NewValue >= 0 AndAlso raw IsNot Nothing Then
            NewWeight_nud.Value = ((_scale.NewValue * My.Settings.SupermarketComponentScaleFactor) / (Quantity_nud.Value * factor)) * 1000 'EN GRAMOS
            Weight_lbl.Text = String.Format("{0} Kg", (_scale.NewValue * My.Settings.SupermarketComponentScaleFactor)) 'PESO DE LA BASCULA EN KG
        End If

        If _scale.IsReading AndAlso _scale.IsStable Then
            NewWeight_nud.BackColor = Color.LimeGreen
            NewWeight_nud.ForeColor = Color.White
            SaveSamples_btn.Enabled = True
        ElseIf _scale.IsReading Then
            NewWeight_nud.BackColor = Color.Maroon
            NewWeight_nud.ForeColor = Color.White
            SaveSamples_btn.Enabled = False
        Else
            NewWeight_nud.BackColor = Color.DimGray
            NewWeight_nud.ForeColor = Color.Black
            SaveSamples_btn.Enabled = False
        End If
        Application.DoEvents()
    End Sub

    Private Sub ReadPartnumber()
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            If RawMaterial.Exists(Partnumber_txt.Text) Then
                raw = New RawMaterial(Partnumber_txt.Text)
                Description_lbl.Text = raw.Description
                CurrentWeight_lbl.Text = raw.WeightOnGr & " g/" & raw.UoM.ToString
                If Scale_chk.Checked Then _scale.StartReading()
                If raw.UoM = RawMaterial.UnitOfMeasure.PC Then
                    UoM_cbo.Items.Clear()
                    UoM_cbo.Items.Add(raw.UoM.ToString)
                Else
                    Dim uoms As ArrayList = RawMaterial.GetUoMOptions(raw.Partnumber)
                    If Not uoms.Contains(raw.UoM.ToString) Then uoms.Add(raw.UoM.ToString)
                    UoM_cbo.Items.Clear()
                    UoM_cbo.Items.AddRange(uoms.ToArray)
                End If
            Else
                Partnumber_txt.Clear()
                Partnumber_txt.Focus()
                FlashAlerts.ShowError("El número de parte no existe.")
            End If
        End If
    End Sub

    Private Sub Clean()
        raw = Nothing
        factor = 1
        CurrentWeight_lbl.Text = "-"
        Quantity_nud.Value = 1
        Partnumber_txt.Clear()
        Partnumber_txt.Focus()
        Description_lbl.Text = "-"
        Weight_lbl.Text = ""
        _scale.StopReading()
    End Sub

    Private Sub Smk_PartialDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Partnumber_txt_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_txt.TextChanged
        If SMK.IsRawMaterialFormat(Partnumber_txt.Text) Then
            ReadPartnumber()
        End If
    End Sub

    Private Sub Scale_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Scale_chk.CheckedChanged
        NewWeight_nud.Enabled = Not Scale_chk.Checked
        If Scale_chk.Checked AndAlso raw IsNot Nothing Then _scale.StartReading()
    End Sub

    Private Sub List_btn_Click(sender As Object, e As EventArgs) Handles Settings_btn.Click
        Dim newAdmin As New Sys_Authentication
        If newAdmin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If newAdmin.User.HasPermission("Supermarket_CableScaleSettings_Change_flag") Then
                Clean()
                Dim settings As New Smk_SmkSettings
                settings.ShowDialog()
                settings.Dispose()
            Else
                FlashAlerts.ShowError("No tienes autorización para realizar esta accion.")
            End If
        Else
            FlashAlerts.ShowError("Acción cancelada.")
        End If
    End Sub

    Private Sub SaveSamples_btn_Click(sender As Object, e As EventArgs) Handles SaveSamples_btn.Click
        If raw IsNot Nothing Then
            If ((Scale_chk.Checked AndAlso _scale.IsReading AndAlso _scale.IsStable) OrElse Not Scale_chk.Checked) AndAlso NewWeight_nud.Value > 0 Then



                If SQL.Current.Update("Sys_RawMaterial", {"WeightOnGr", "UnitWeightValidated"}, {NewWeight_nud.Value, 1}, "Partnumber", raw.Partnumber) Then
                    Clean()
                    FlashAlerts.ShowConfirm("¡Hecho!")
                Else
                    FlashAlerts.ShowError("Error al actualizar el peso unitario.")
                End If
            Else
                FlashAlerts.ShowError("Espera a que la bascula se estabilice.")
            End If
        End If
    End Sub

    Private Sub Smk_SamplesWeight_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
        Clean()
    End Sub

    Private Sub UoM_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UoM_cbo.SelectedIndexChanged
        factor = RawMaterial.ConvertUoM(raw.Partnumber, UoM_cbo.SelectedItem, 1, raw.UoM.ToString)
    End Sub
End Class