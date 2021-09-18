Imports System.IO.Ports
Imports System.Threading
Public Class CDR_HealingContainerization
    Dim thread_A As Threading.Thread
    Dim part_weight As Decimal = 0
    Dim part_uom As String

    Dim serial As CDR.Kanban
    Dim old_qty As Decimal = 0
    Dim is_new As Boolean = False
    Dim _scale As New Scale


    Private Sub CDR_HealingContainerization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        Kanban_txt.Focus()
    End Sub


    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso part_weight > 0 Then
            Quantity_lbl.Text = Math.Round(((_scale.NewValue - CDR.ContainerWeight(SelectedContainer())) * My.Settings.SupermarketComponentScaleFactor * 1000) / part_weight, 0)
        End If
        If _scale.IsReading AndAlso _scale.IsStable Then
            Confirm_btn.Visible = True
            Quantity_lbl.BackColor = Color.GreenYellow
            Quantity_lbl.ForeColor = Color.White
        ElseIf _scale.IsReading Then
            Confirm_btn.Visible = False
            Quantity_lbl.BackColor = Color.Maroon
            Quantity_lbl.ForeColor = Color.White
        Else
            Confirm_btn.Visible = False
            Quantity_lbl.BackColor = Color.DimGray
            Quantity_lbl.ForeColor = Color.Black
        End If
        Application.DoEvents()
    End Sub

    Private Sub CleanKanbanInfo()
        is_new = False
        serial = Nothing
        part_weight = 0
        Partnumber_lbl.Text = ""
        Description_lbl.Text = ""
        Quantity_lbl.Text = ""
        Uom_lbl.Text = ""
        UncheckContainers()
        Message_lbl.Visible = False
        New_lbl.Visible = False
    End Sub

    Private Sub Kanban_txt_Validated(sender As Object, e As EventArgs) Handles Kanban_txt.Validated
        If Kanban_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadKanban)
            thread_A.Start()
        End If
    End Sub

    Public Function IsContainerSelected() As Boolean
        If S16_rb.Checked Then
            Return True
        ElseIf S8_rb.Checked Then
            Return True
        ElseIf S4_rb.Checked Then
            Return True
        ElseIf S2_rb.Checked Then
            Return True
        ElseIf JT_rb.Checked Then
            Return True
        ElseIf Half_rb.Checked Then
            Return True
        ElseIf Quarter_rb.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SelectedContainer() As CDR.RouteContainer
        If S16_rb.Checked Then
            Return CDR.RouteContainer.C16s
        ElseIf S8_rb.Checked Then
            Return CDR.RouteContainer.C8s
        ElseIf S4_rb.Checked Then
            Return CDR.RouteContainer.C4s
        ElseIf S2_rb.Checked Then
            Return CDR.RouteContainer.C2s
        ElseIf JT_rb.Checked Then
            Return CDR.RouteContainer.JT
        ElseIf Half_rb.Checked Then
            Return CDR.RouteContainer.C1_2
        ElseIf Quarter_rb.Checked Then
            Return CDR.RouteContainer.C1_4
        Else
            Return CDR.RouteContainer.None
        End If
    End Function


    Public Function SelectedContainerStr() As String
        If S16_rb.Checked Then
            Return "16S"
        ElseIf S8_rb.Checked Then
            Return "8S"
        ElseIf S4_rb.Checked Then
            Return "4S"
        ElseIf S2_rb.Checked Then
            Return "2S"
        ElseIf JT_rb.Checked Then
            Return "JT"
        ElseIf Half_rb.Checked Then
            Return "1/2"
        ElseIf Quarter_rb.Checked Then
            Return "1/4"
        Else
            Return "STDPACK"
        End If
    End Function

    Public Sub CheckContainer(container As CDR.RouteContainer)
        UncheckContainers()
        Select Case container
            Case CDR.RouteContainer.C16s
                S16_rb.Checked = True
            Case CDR.RouteContainer.C8s
                S8_rb.Checked = True
            Case CDR.RouteContainer.C4s
                S4_rb.Checked = True
            Case CDR.RouteContainer.C2s
                S2_rb.Checked = True
            Case CDR.RouteContainer.JT
                JT_rb.Checked = True
            Case CDR.RouteContainer.C1_4
                Quarter_rb.Checked = True
            Case CDR.RouteContainer.C1_2
                Half_rb.Checked = True
        End Select
    End Sub

    Public Sub UncheckContainers()
        S16_rb.Checked = False
        S8_rb.Checked = False
        S4_rb.Checked = False
        S2_rb.Checked = False
        JT_rb.Checked = False
        Half_rb.Checked = False
        Quarter_rb.Checked = False
    End Sub

    Private Sub Kanban_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kanban_txt.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Kanban_txt.Text.Trim <> "" Then
            thread_A = New Threading.Thread(AddressOf ReadKanban)
            thread_A.Start()
        End If
    End Sub

    Delegate Sub ReadIt()

    Private Sub ReadKanban()
        If Kanban_txt.InvokeRequired Then
            Dim dgt As New ReadIt(AddressOf ReadKanban)
            Invoke(dgt)
        ElseIf Kanban_txt.Text.ToUpper.Trim = "-OK-" Then
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            ConfirmKanban()
        ElseIf CDR.IsKanban(Kanban_txt.Text) Then
            Dim kanban_id As Integer = CDR.KanbanID(Kanban_txt.Text)
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            serial = New CDR.Kanban(kanban_id)
            If serial.Exists Then
                Partnumber_lbl.ReadOnly = True
                Partnumber_lbl.Text = serial.Partnumber
                Description_lbl.Text = RawMaterial.GetDescription(serial.Partnumber)
                Quantity_lbl.Text = 0
                Uom_lbl.Text = "PC"
                part_weight = RawMaterial.GetWeightByUoM(serial.Partnumber, "PC")
                If serial.Container = "" Then
                    UncheckContainers()
                    Message_lbl.Text = "Elija el tipo de Contenedor para continuar."
                    Message_lbl.Visible = True
                Else
                    CheckContainer(serial.Container)
                    Message_lbl.Visible = False
                End If
            Else
                Partnumber_lbl.ReadOnly = False
                Description_lbl.Text = ""
                Uom_lbl.Text = ""
                part_weight = 0
                UncheckContainers()
                Message_lbl.Text = "Escriba el No. de Parte y elija el tipo" & vbCrLf & "de Contenedor para continuar."
                Message_lbl.Visible = True
                Partnumber_lbl.Clear()
                Partnumber_lbl.Focus()
            End If
            If Not _scale.IsReading Then _scale.StartReading()
        ElseIf Kanban_txt.Text.ToUpper = "NEW" Then
            Kanban_txt.Clear()
            NewKanban()
        ElseIf Kanban_txt.Text.ToUpper.Trim = "CLOSE" Then
            Kanban_txt.Clear()
            Me.Close()
        Else
            CleanKanbanInfo()
            Kanban_txt.Clear()
            Kanban_txt.Focus()
            FlashAlerts.ShowError("Kanban incorrecta.", 1, True)
        End If
    End Sub

    Public Sub NewKanban()
        CleanKanbanInfo()
        is_new = True
        New_lbl.Visible = True
        Partnumber_lbl.ReadOnly = False
        Message_lbl.Text = "Escriba el No. de Parte y elija el tipo" & vbCrLf & "de Contenedor para continuar."
        Message_lbl.Visible = True
        Partnumber_lbl.Clear()
        Partnumber_lbl.Focus()
        _scale.StartReading()
    End Sub

    Public Sub ConfirmKanban()
        If is_new Then
            If SMK.IsRawMaterialFormat(Partnumber_lbl.Text) AndAlso RawMaterial.Exists(RawMaterial.Format(Partnumber_lbl.Text)) Then
                If IsContainerSelected() Then
                    Dim qty As Integer = CInt(Quantity_lbl.Text)
                    If _scale.IsReading AndAlso _scale.IsStable AndAlso qty > 0 Then
                        _scale.StopReading()
                        Dim partnumber As String = RawMaterial.Format(Partnumber_lbl.Text)
                        Dim rack, location As String
                        location = RawMaterial.GetServiceLocation(partnumber, My.Settings.Warehouse)
                        rack = Strings.Left(location, 2)
                        If SQL.Current.Execute(String.Format("INSERT INTO CDR_Kanbans (Partnumber,Board,Description,Kit,EngLoc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requirement,[2h],Quantity,Frequency,Hrs,Comment,Rack,Local,Generic)" & _
                                                          "VALUES ('{1}','-','{2}','','','','','','0',{3},'{4}',1,'',1,1,1,1,1,'Healing','{5}','{6}',1);", "", partnumber, Description_lbl.Text, qty, SelectedContainerStr, rack, location)) Then

                            If Not SQL.Current.Exists("CDR_Containerization", "Partnumber", partnumber) Then 'NO ACTUALIZAR, SOLO AGREGAR SINO EXISTE PORQUE NO SE PUEDE CONFIAR COMPLETAMENTE EN EL OPERADOR
                                Select Case SelectedContainer()
                                    Case CDR.RouteContainer.C16s
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_16s", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.C8s
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_8s", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.C4s
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_4s", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.C2s
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_2s", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.JT
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_JT", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.C1_4
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_1_4", "Partnumber"}, {qty, partnumber})
                                    Case CDR.RouteContainer.C1_2
                                        SQL.Current.Insert("CDR_Containerization", {"Cnt_1_2", "Partnumber"}, {qty, partnumber})
                                End Select
                            End If
                            Dim id As Integer = SQL.Current.GetScalar("MAX(ID)", "CDR_Kanbans", {"Partnumber", "Pieces", "Container", "Local", "Comment"}, {partnumber, qty, SelectedContainerStr(), location, "Healing"})
                            Log(String.Format("{0}|{1}|{2}|{3}|New", id, partnumber, SelectedContainer, qty), "CDR_KanbanHealing")
                            CDR.Print(id, False)
                            CleanKanbanInfo()
                            FlashAlerts.ShowConfirm("Kanban actualizada.")
                        Else
                            FlashAlerts.ShowError("No es posible crear la kanban.")
                        End If
                    Else
                        FlashAlerts.ShowError("La cantidad no puede ser Cero.")
                    End If
                Else
                    FlashAlerts.ShowError("Selecciona el contenedor correcto.")
                End If
            Else
                FlashAlerts.ShowError("Ingresa el numero de parte correcto.")
            End If
        ElseIf serial IsNot Nothing Then
            If serial.Exists Then
                Dim qty As Integer = CInt(Quantity_lbl.Text)
                If _scale.IsReading AndAlso _scale.IsStable AndAlso qty > 0 Then
                    _scale.StopReading()
                    If SQL.Current.Exists("CDR_Containerization", "Partnumber", serial.Partnumber) Then
                        Select Case SelectedContainer()
                            Case CDR.RouteContainer.C16s
                                SQL.Current.Update("CDR_Containerization", "Cnt_16s", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.C8s
                                SQL.Current.Update("CDR_Containerization", "Cnt_8s", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.C4s
                                SQL.Current.Update("CDR_Containerization", "Cnt_4s", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.C2s
                                SQL.Current.Update("CDR_Containerization", "Cnt_2s", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.JT
                                SQL.Current.Update("CDR_Containerization", "Cnt_JT", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.C1_4
                                SQL.Current.Update("CDR_Containerization", "Cnt_1_4", qty, "Partnumber", serial.Partnumber)
                            Case CDR.RouteContainer.C1_2
                                SQL.Current.Update("CDR_Containerization", "Cnt_1_2", qty, "Partnumber", serial.Partnumber)
                        End Select
                    Else
                        Select Case SelectedContainer()
                            Case CDR.RouteContainer.C16s
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_16s", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.C8s
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_8s", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.C4s
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_4s", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.C2s
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_2s", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.JT
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_JT", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.C1_4
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_1_4", "Partnumber"}, {qty, serial.Partnumber})
                            Case CDR.RouteContainer.C1_2
                                SQL.Current.Insert("CDR_Containerization", {"Cnt_1_2", "Partnumber"}, {qty, serial.Partnumber})
                        End Select
                    End If
                    Dim rack, location As String
                    location = RawMaterial.GetServiceLocation(serial.Partnumber, My.Settings.Warehouse)
                    rack = Strings.Left(location, 2)
                    SQL.Current.Update("CDR_Kanbans", {"Pieces", "Local", "Rack", "Container"}, {qty, location, rack, SelectedContainer()}, "ID", serial.ID)
                    Log(String.Format("{0}|{1}|{2}|{3}", serial.Code, serial.Partnumber, SelectedContainer, qty), "CDR_KanbanHealing")
                    CDR.Print(serial.ID, False)
                    CleanKanbanInfo()
                    FlashAlerts.ShowConfirm("Kanban actualizada.")
                Else
                    FlashAlerts.ShowError("La cantidad no puede ser Cero.")
                End If
            ElseIf SMK.IsRawMaterialFormat(Partnumber_lbl.Text) AndAlso RawMaterial.Exists(RawMaterial.Format(Partnumber_lbl.Text)) Then
                If IsContainerSelected() Then
                    Dim qty As Integer = CInt(Quantity_lbl.Text)
                    If _scale.IsReading AndAlso _scale.IsStable AndAlso qty > 0 Then
                        _scale.StopReading()
                        serial.Partnumber = RawMaterial.Format(Partnumber_lbl.Text)
                        serial.Container = SelectedContainer()

                        Dim rack, location As String
                        location = RawMaterial.GetServiceLocation(serial.Partnumber, My.Settings.Warehouse)
                        rack = Strings.Left(location, 2)
                        SQL.Current.Execute(String.Format("SET IDENTITY_INSERT dbo.CDR_Kanbans ON; INSERT INTO CDR_Kanbans (ID,Partnumber,Board,Description,Kit,EngLoc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requirement,[2h],Quantity,Frequency,Hrs,Comment,Rack,Local,Generic)" & _
                                                          "VALUES ({0},'{1}','-','{2}','','','','','','0',{3},'{4}',1,'',1,1,1,1,1,'Healing','{5}','{6}',1); SET IDENTITY_INSERT dbo.CDR_Kanbans OFF;", serial.ID, serial.Partnumber, Description_lbl.Text, qty, serial.Container, rack, location))
                        If SQL.Current.Exists("CDR_Containerization", "Partnumber", serial.Partnumber) Then
                            Select Case SelectedContainer()
                                Case CDR.RouteContainer.C16s
                                    SQL.Current.Update("CDR_Containerization", "Cnt_16s", qty, "Partnumber", serial.Partnumber)
                                Case CDR.RouteContainer.C8s
                                    SQL.Current.Update("CDR_Containerization", "Cnt_8s", qty, "Partnumber", serial.Partnumber)
                                Case CDR.RouteContainer.C4s
                                    SQL.Current.Update("CDR_Containerization", "Cnt_4s", qty, "Partnumber", serial.Partnumber)
                                Case CDR.RouteContainer.C2s
                                    SQL.Current.Update("CDR_Containerization", "Cnt_2s", qty, "Partnumber", serial.Partnumber)
                                Case CDR.RouteContainer.JT
                                    SQL.Current.Update("CDR_Containerization", "Cnt_JT", qty, "Partnumber", serial.Partnumber)
                            End Select
                        Else
                            Select Case SelectedContainer()
                                Case CDR.RouteContainer.C16s
                                    SQL.Current.Insert("CDR_Containerization", {"Cnt_16s", "Partnumber"}, {qty, serial.Partnumber})
                                Case CDR.RouteContainer.C8s
                                    SQL.Current.Insert("CDR_Containerization", {"Cnt_8s", "Partnumber"}, {qty, serial.Partnumber})
                                Case CDR.RouteContainer.C4s
                                    SQL.Current.Insert("CDR_Containerization", {"Cnt_4s", "Partnumber"}, {qty, serial.Partnumber})
                                Case CDR.RouteContainer.C2s
                                    SQL.Current.Insert("CDR_Containerization", {"Cnt_2s", "Partnumber"}, {qty, serial.Partnumber})
                                Case CDR.RouteContainer.JT
                                    SQL.Current.Insert("CDR_Containerization", {"Cnt_JT", "Partnumber"}, {qty, serial.Partnumber})
                            End Select
                        End If
                        Log(String.Format("{0}|{1}|{2}|{3}|Generic", serial.ID, serial.Partnumber, serial.Container, qty), "CDR_KanbanHealing")
                        CDR.Print(serial.ID, False)
                        CleanKanbanInfo()
                        FlashAlerts.ShowConfirm("Kanban actualizada.")
                    Else
                        FlashAlerts.ShowError("La cantidad no puede ser Cero.")
                    End If
                Else
                    FlashAlerts.ShowError("Selecciona el contenedor correcto.")
                End If
            Else
                FlashAlerts.ShowError("Ingresa el numero de parte correcto.")
            End If
        End If
    End Sub

    Private Sub Partnumber_lbl_TextChanged(sender As Object, e As EventArgs) Handles Partnumber_lbl.TextChanged
        If serial IsNot Nothing Then
            If SMK.IsRawMaterialFormat(Partnumber_lbl.Text) Then
                Description_lbl.Text = RawMaterial.GetDescription(Partnumber_lbl.Text)
                Uom_lbl.Text = "PC"
                part_weight = RawMaterial.GetWeightByUoM(Partnumber_lbl.Text, "PC")
                Kanban_txt.Focus()
            Else
                Description_lbl.Text = ""
                Uom_lbl.Text = ""
                UncheckContainers()
            End If
        ElseIf is_new Then
            If SMK.IsRawMaterialFormat(Partnumber_lbl.Text) Then
                Description_lbl.Text = RawMaterial.GetDescription(Partnumber_lbl.Text)
                Uom_lbl.Text = "PC"
                part_weight = RawMaterial.GetWeightByUoM(Partnumber_lbl.Text, "PC")
                Kanban_txt.Focus()
            End If
        End If
    End Sub


    Private Sub Container_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Kanban_txt.Focus()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub


    Private Sub CDR_HealingContainerization_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Kanban_txt.Focus()
    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        Kanban_txt.Focus()
        ConfirmKanban()
    End Sub

    Private Sub JT_rb_CheckedChanged(sender As Object, e As EventArgs) Handles S8_rb.CheckedChanged, S4_rb.CheckedChanged, S2_rb.CheckedChanged, S16_rb.CheckedChanged, Quarter_rb.CheckedChanged, JT_rb.CheckedChanged, Half_rb.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            Kanban_txt.Focus()
        End If
    End Sub

    Private Sub New_btn_Click(sender As Object, e As EventArgs) Handles New_btn.Click
        Kanban_txt.Clear()
        NewKanban()
        Partnumber_lbl.Focus()
    End Sub


    Private Sub CDR_HealingContainerization_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.Dispose()
    End Sub
End Class