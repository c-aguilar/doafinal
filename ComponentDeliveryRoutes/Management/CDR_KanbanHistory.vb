Imports CAguilar
Public Class CDR_KanbanHistory
    Public code As String
    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvResult.DataSource = SQL.Current.GetDatatable(String.Format("SELECT code ID,board Tablero,business Negocio,partnumber Partnumber,description Descripcion,kit Kit,slot Slot,side Lado,section Seccion,route Ruta,container Contenedor,pieces Piezas,[index] Tarjeta,requeriment Requerimiento,[2H],quantity Cantidad,frequency Frecuencia,hrs Horas,comment Comentario,rack Rack,[local] Local,[date] Actualizacion FROM CDR_KanbansHistory WHERE code='{0}' ORDER BY date DESC", code))
    End Sub

    Private Sub frmHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class