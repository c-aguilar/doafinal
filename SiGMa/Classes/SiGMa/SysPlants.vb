Public Class SysPlants

    Public Property Plant As String
    Public Property BusinessName As String
    Public Property Active As Boolean
    Public Property Plants As ArrayList
    Private Shared _selectedPlant As New SysPlants

    Public Shared ReadOnly Property Current As SysPlants
        Get
            Return _selectedPlant
        End Get
    End Property

    Public Function Login(selected_plant As String)
        Me.Plant = SQL.Current.GetString("Plant", "dbo.Sys_Plants", "Plant", selected_plant, "")
        Me.BusinessName = SQL.Current.GetString("BusinessName", "dbo.Sys_Plants", "Plant", selected_plant, "")
        Me.Active = SQL.Current.Exists("dbo.Sys_Plants", {"Plant", "Active"}, {selected_plant, 1})
    End Function

    Public Function getAllPlants() As ArrayList
        Plants = SQL.Current.GetList("SELECT Plant FROM dbo.Sys_Plants")
        Return Plants
    End Function

    Public Function getRoutesPlants(idRoute As Integer) As ArrayList
        Plants = SQL.Current.GetList(String.Format("SELECT [Plant] FROM [Routes_Plants] WHERE [IdRoute] = {0}", idRoute))
        Return Plants
    End Function

End Class
