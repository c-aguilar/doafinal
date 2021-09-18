Imports System.ComponentModel
Public Class PEng_Leadcodes
    Dim CurrentUserBusiness As List(Of Business)
    Dim LoadedLeadcodes As BindingList(Of Leadcode)


    Private Sub PEng_Leadcodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentUserBusiness = New List(Of Business)
        For Each business In SQL.Current.GetList("Business", "PE_BusinessOwners", {"Username"}, {User.Current.Username})
            CurrentUserBusiness.Add(New Business(business)) 'AG
        Next
        Dim families As DataTable = SQL.Current.GetDatatable("SELECT Family FROM Sch_Families WHERE Family NOT IN ('DeltaERP','Unclassified');") 'TRAER LAS FAMILIAS Y OMITIR LOS NEGOCIOS QUE NO EXISTEN
        families.Rows.Add("(Todos)") 'AGREGAR EL ITEM (TODOS)
        GF.FillCombobox(Family_Find_cbo, families, "Family", "Family") 'LLENAR EL COMBO
        Family_Find_cbo.SelectedValue = "(Todos)" 'SELECCIONAR POR DEFAULT EL ITEM (TODOS)

    End Sub

    Private Sub Business_Find_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Family_Find_cbo.SelectionChangeCommitted
        If Family_Find_cbo.SelectedValue = "(Todos)" Then 'VACIAR EL COMBO DE PLATAFORMAS CUANDO SE SELECCIONE LA FAMILIA (TODOS)
            Business_Find_cbo.SelectedIndex = -1
            Business_Find_cbo.Items.Clear()
        Else
            Dim business As DataTable = SQL.Current.GetDatatable({"Business"}, "Sch_Business", "Family", Family_Find_cbo.SelectedValue) 'TRAER TODOS LOS NEGOCIOS DE LA FAMILIA SELECCIONADA
            business.Rows.Add("(Todos)") 'AGREGAR EL ITEM (TODOS)
            GF.FillCombobox(Business_Find_cbo, business, "Business", "Business") 'LLENAR EL COMBO
            Business_Find_cbo.SelectedValue = "(Todos)" 'SELECCIONAR POR DEFAULT EL ITEM (TODOS)
        End If
    End Sub

    Private Sub Leadcode_Find_btn_Click(sender As Object, e As EventArgs) Handles Leadcode_Find_btn.Click
        Find("Leadcode")
    End Sub

    Private Sub BusinessPlatform_Find_btn_Click(sender As Object, e As EventArgs) Handles BusinessPlatform_Find_btn.Click
        Find("Business")
    End Sub

    Private Sub Cutter_Find_btn_Click(sender As Object, e As EventArgs) Handles Cutter_Find_btn.Click
        Find("Cutter")
    End Sub

    Private Sub MSpec_Find_btn_Click(sender As Object, e As EventArgs) Handles MSpec_Find_btn.Click
        Find("MSpec")
    End Sub

    Private Sub Terminal_Find_btn_Click(sender As Object, e As EventArgs) Handles Terminal_Find_btn.Click
        Find("Terminal")
    End Sub

    Public Sub Find(by As String)
        LoadedLeadcodes = New BindingList(Of Leadcode)
        Dim leadcodes_dt As DataTable = Nothing
        Select Case by
            Case "Leadcode"
                If Leadcode.Exist(Leadcode_Find_txt.Text) Then
                    leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", "Leadcode", Leadcode_Find_txt.Text)
                Else
                    FlashAlerts.ShowError("El leadcode no existe.")
                    Exit Sub
                End If
            Case "Business"
                If Family_Find_cbo.SelectedValue = "(Todos)" Then
                    If OnlyActive_chk.Checked Then
                        leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", "Active", 1)
                    Else
                        leadcodes_dt = SQL.Current.GetDatatable("SELECT * FROM vw_PE_LeadcodeBusiness")
                    End If
                Else
                    If Business_Find_cbo.SelectedValue = "(Todos)" Then
                        If OnlyActive_chk.Checked Then
                            leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", {"Active", "Family"}, {1, Family_Find_cbo.SelectedValue})
                        Else
                            leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", {"Family"}, {Family_Find_cbo.SelectedValue})
                        End If
                    Else
                        If OnlyActive_chk.Checked Then
                            leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", {"Active", "Family", "Business"}, {1, Family_Find_cbo.SelectedValue, Business_Find_cbo.SelectedValue})
                        Else
                            leadcodes_dt = SQL.Current.GetDatatable("vw_PE_LeadcodeBusiness", {"Family", "Business"}, {Family_Find_cbo.SelectedValue, Business_Find_cbo.SelectedValue})
                        End If
                    End If
                End If
            Case "Cutter"

            Case "MSpec"
                If RawMaterial.Exists(MSpec_Find_txt.Text) Then
                    If OnlyActive_chk.Checked Then
                        leadcodes_dt = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_PE_LeadcodeBusiness WHERE Active = 1 AND (MSpec_A = '{0}' OR MSpec_B = '{0}')", MSpec_Find_txt.Text))
                    Else
                        leadcodes_dt = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_PE_LeadcodeBusiness WHERE (MSpec_A = '{0}' OR MSpec_B = '{0}')", MSpec_Find_txt.Text))
                    End If
                Else
                    FlashAlerts.ShowError("El MSpec no existe.")
                    Exit Sub
                End If
            Case "Terminal"
                If RawMaterial.Exists(Terminal_Find_txt.Text) Then
                    If OnlyActive_chk.Checked Then
                        leadcodes_dt = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_PE_LeadcodeBusiness WHERE Active = 1 AND (Terminal_A = '{0}' OR Terminal_B = '{0}' OR Terminal_C = '{0}')", Terminal_Find_txt.Text))
                    Else
                        leadcodes_dt = SQL.Current.GetDatatable(String.Format("SELECT * FROM vw_PE_LeadcodeBusiness WHERE (Terminal_A = '{0}' OR Terminal_B = '{0}' OR Terminal_C = '{0}')", Terminal_Find_txt.Text))
                    End If
                Else
                    FlashAlerts.ShowError("La Terminal no existe.")
                    Exit Sub
                End If
        End Select

        For Each row As DataRow In leadcodes_dt.Rows
            LoadedLeadcodes.Add(New Leadcode(row.Item("Leadcode"), New MSpec(row.Item("MSpec_A")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        Next
        Database_dgv.Columns.Clear()
        
        Database_dgv.DataSource = LoadedLeadcodes
    End Sub




    Private Sub Database_dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Database_dgv.CellFormatting
        Select Case Database_dgv.Columns(e.ColumnIndex).Name
            Case "MSpec_A_col", "Length_A_col", "Gage_A_col", "CC_A_col", "SAPColor_A_col", "SAPStripeColor_A_col", "Threads_A_col"
                e.CellStyle.BackColor = Color.LightGray
            Case "Terminal_A_col", "TerminalGage_A_col", "CCH_A_col", "CCW_A_col", "ICH_A_col", "ICW_A_col", "StrippingLenght_A_col", "Tension_A_col", "Die_A_col", "Presser_A_col", "Seal_A_col", "SealColor_A_col"

            Case "Terminal_B_col", "TerminalGage_B_col", "CCH_B_col", "CCW_B_col", "ICH_B_col", "ICW_B_col", "StrippingLenght_B_col", "Tension_B_col", "Die_B_col", "Presser_B_col", "Seal_B_col", "SealColor_B_col"
                e.CellStyle.BackColor = Color.LightGray
            Case "MSpec_B_col", "Lenght_B_col", "Gage_B_col", "CC_B_col", "SAPColor_B_col", "SAPStripeColor_B_col", "Threads_B_col"

            Case "Terminal_C_col", "TerminalGage_C_col", "CCH_C_col", "CCW_C_col", "ICH_C_col", "ICW_C_col", "StrippingLenght_C_col", "Tension_C_col", "Die_C_col", "Presser_C_col", "Seal_C_col", "SealColor_C_col"
                e.CellStyle.BackColor = Color.LightGray
            Case "BatchType_col", "BatchQuantity_col", "Sequence_col", "Print_col", "Ink_col", "Wire_col", "Process_col", "Pcs_Hr_col", "CycleTime_col", "Min_col", "Max_col", "DefaultCutter_col", "Type_col", "Active_col"

            Case "Material_col", "Quantity_col", "Family_col", "Business_col"
                e.CellStyle.BackColor = Color.LightGray
        End Select
    End Sub
End Class