Imports System.IO.Ports
Imports System.Threading
Public Class DDR_AddMissingKanban
    Dim thread_A As Threading.Thread
    Dim part_weight As Decimal = 0
    Dim _scale As New Scale

    Public Property ID_Kanban As Integer
    Public Property ID_Movement As Integer
    Public Property Partnumber As String
    Private Sub CDR_HealingContainerization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler _scale.InternalTimer.Tick, AddressOf ScaleTick
        ReadKanban()
    End Sub


    Private Sub ScaleTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _scale.IsReading AndAlso part_weight > 0 Then
            Quantity_lbl.Text = Math.Round(((_scale.NewValue - ContainerWeight()) * My.Settings.SupermarketComponentScaleFactor * 1000) / part_weight, 0)
        Else
            Quantity_lbl.Text = "0"
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

    Public Function SelectedContainer() As String
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
            Return ""
        End If
    End Function

    Public Sub CheckContainer(container As String)
        UncheckContainers()
        Select Case container
            Case "16S"
                S16_rb.Checked = True
            Case "8S"
                S8_rb.Checked = True
            Case "4S"
                S4_rb.Checked = True
            Case "2S"
                S2_rb.Checked = True
            Case "JT"
                JT_rb.Checked = True
            Case "1/4"
                Quarter_rb.Checked = True
            Case "1/2"
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

    Delegate Sub ReadIt()

    Private Sub ReadKanban()
        ID_lbl.Text = "ID: " & ID_Kanban
        Partnumber_lbl.Text = Partnumber
        Partnumber_lbl.ReadOnly = True
        Description_lbl.Text = RawMaterial.GetDescription(Partnumber)
        Uom_lbl.Text = "PC"
        part_weight = RawMaterial.GetWeightByUoM(Partnumber, "PC")
        UncheckContainers()
        Partnumber_lbl.Focus()
        If Not _scale.IsReading Then _scale.StartReading()
    End Sub

    Public Sub ConfirmKanban()
        If IsContainerSelected() Then
            Dim qty As Integer = CInt(Quantity_lbl.Text)
            If _scale.IsReading AndAlso _scale.IsStable AndAlso qty > 0 Then
                _scale.StopReading()

                Dim rack, location As String
                location = RawMaterial.GetServiceLocation(Partnumber, My.Settings.Warehouse)
                rack = Strings.Left(location, 2)
                If SQL.Current.Exists("CDR_Kanbans", "ID", ID_Kanban) Then
                    SQL.Current.Update("CDR_Kanbans", {"Partnumber", "Pieces", "Description", "Container", "Rack", "Local"}, {Partnumber, qty, Description_lbl.Text, SelectedContainer(), rack, location}, {"ID"}, {ID_Kanban})
                Else
                    SQL.Current.Execute(String.Format("SET IDENTITY_INSERT dbo.CDR_Kanbans ON; INSERT INTO CDR_Kanbans (ID,Partnumber,Board,Description,Kit,EngLoc,Slot,Side,Section,Route,Pieces,Container,[Index],Business,Requirement,[2h],Quantity,Frequency,Hrs,Comment,Rack,Local,Generic)" & _
                                                                      "VALUES ({0},'{1}','-','{2}','','','','','','0',{3},'{4}',1,'',1,1,1,1,1,'Healing','{5}','{6}',1); SET IDENTITY_INSERT dbo.CDR_Kanbans OFF;", ID_Kanban, Partnumber, Description_lbl.Text, qty, SelectedContainer, rack, location))
                End If

                Dim serial_id As Integer = SQL.Current.GetScalar("SerialID", "Smk_SerialMovements", "ID", ID_Movement)
                Dim current_qty As Integer = SQL.Current.GetScalar("dbo.Sys_UnitConversion(Partnumber,UoM,CurrentQuantity,'PC') AS CurrentQty", "vw_Smk_Serials", "ID", serial_id)
                If SQL.Current.Execute(String.Format("UPDATE Smk_SerialMovements SET Quantity = -dbo.Sys_UnitConversion(S.Partnumber,'PC', {0}, S.UoM) FROM Smk_Serials AS S WHERE SerialID = S.ID AND Smk_SerialMovements.ID = {1};", Math.Min(current_qty, qty), ID_Movement)) Then
                    SQL.Current.Execute(String.Format("UPDATE Smk_SAPTransfers SET Quantity = ABS(SM.Quantity), Posted = 0 FROM Smk_SerialMovements AS SM WHERE MovementID = SM.ID AND SM.ID = {0};", ID_Movement))
                    Log(String.Format("{0}|{1}|{2}", ID_Movement, current_qty, qty), "DDR_FixKanbanDiscount")
                End If


                If SQL.Current.Exists("CDR_Containerization", "Partnumber", Partnumber) Then
                    Select Case SelectedContainer()
                        Case "16S"
                            SQL.Current.Update("CDR_Containerization", "Cnt_16s", qty, "Partnumber", Partnumber)
                        Case "8S"
                            SQL.Current.Update("CDR_Containerization", "Cnt_8s", qty, "Partnumber", Partnumber)
                        Case "4S"
                            SQL.Current.Update("CDR_Containerization", "Cnt_4s", qty, "Partnumber", Partnumber)
                        Case "2S"
                            SQL.Current.Update("CDR_Containerization", "Cnt_2s", qty, "Partnumber", Partnumber)
                        Case "JT"
                            SQL.Current.Update("CDR_Containerization", "Cnt_JT", qty, "Partnumber", Partnumber)
                    End Select
                Else
                    Select Case SelectedContainer()
                        Case "16S"
                            SQL.Current.Insert("CDR_Containerization", {"Cnt_16s", "Partnumber"}, {qty, Partnumber})
                        Case "8S"
                            SQL.Current.Insert("CDR_Containerization", {"Cnt_8s", "Partnumber"}, {qty, Partnumber})
                        Case "4S"
                            SQL.Current.Insert("CDR_Containerization", {"Cnt_4s", "Partnumber"}, {qty, Partnumber})
                        Case "2S"
                            SQL.Current.Insert("CDR_Containerization", {"Cnt_2s", "Partnumber"}, {qty, Partnumber})
                        Case "JT"
                            SQL.Current.Insert("CDR_Containerization", {"Cnt_JT", "Partnumber"}, {qty, Partnumber})
                    End Select
                End If
                Log(String.Format("{0}|{1}|{2}|{3}|Generic", ID_Kanban, Partnumber, SelectedContainer, qty), "CDR_KanbanHealing")
                CDR.Print(ID_Kanban, False)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                FlashAlerts.ShowError("La cantidad no puede ser Cero.")
            End If
        Else
            FlashAlerts.ShowError("Selecciona el contenedor correcto.")
        End If
    End Sub

    Private Function ContainerWeight() As Decimal
        Select Case SelectedContainer()
            Case "1/4"
                Return 0.136
            Case "1/2"
                Return 0.136
            Case "16S"
                Return 0.126
            Case "8S"
                Return 0.1505
            Case "4S"
                Return 0.2855
            Case "2S"
                Return 0.5785
            Case "JT"
                Return 1.3
            Case Else
                Return 0
        End Select
    End Function

    Private Sub CDR_HealingContainerization_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Confirm_btn_Click(sender As Object, e As EventArgs) Handles Confirm_btn.Click
        ConfirmKanban()
    End Sub

    Private Sub JT_rb_CheckedChanged(sender As Object, e As EventArgs) Handles S8_rb.CheckedChanged, S4_rb.CheckedChanged, S2_rb.CheckedChanged, S16_rb.CheckedChanged, Quarter_rb.CheckedChanged, JT_rb.CheckedChanged, Half_rb.CheckedChanged

    End Sub

    Private Sub CDR_HealingContainerization_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _scale.StopReading()
        _scale.Dispose()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class