Public Class DeltaPivoter
    Dim sb As SearchBox
    Public Property DataSource As DataTable
    Public Property Title As String
    Public Property Rows As List(Of String)
    Public Property Columns As List(Of String)
    Public Property Values As List(Of String)

    Private Class Field
        Public Property Name As String
        Public Property Aggregate As AggregateFunction
        Public Property Status As FieldStatus
    End Class

    Private Enum FieldStatus
        Field
        Row
        Column
        Value
    End Enum

    Private Sub DeltaPivoter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Report_dgv)

        Title_lbl.Text = Me.Title
        RefreshFields()
    End Sub

    Private Sub RefreshFields()
        Fields_flp.Controls.Clear()
        For Each column As DataColumn In Me.DataSource.Columns
            Dim field As New Field
            field.Name = column.ColumnName
            field.Aggregate = AggregateFunction.Sum
            field.Status = FieldStatus.Field
            Dim lbl As New Label
            lbl.Tag = column.ColumnName
            lbl.Text = column.ColumnName
            lbl.BackColor = Color.White
            lbl.AutoSize = False
            lbl.Size = New Size(145, 15)
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.Margin = New Padding(1)
            lbl.Tag = field
            lbl.ImageAlign = ContentAlignment.MiddleRight
            lbl.ContextMenuStrip = Aggregates_cms
            AddHandler lbl.MouseDown, AddressOf Field_MouseDown
            Fields_flp.Controls.Add(lbl)
        Next
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub ReportViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Report_dgv.DataSource IsNot Nothing Then Delta.Export(Report_dgv.DataSource, Strings.Left("Pivote " & Me.Title.Replace("*", "").Replace("?", "").Replace(":", "").Replace("\", "").Replace("/", ""), 30))
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If Not IsNothing(Report_dgv.DataSource) AndAlso MyExcel.Print(Report_dgv.DataSource, False, Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape) Then
            FlashAlerts.ShowConfirm("¡Hecho!")
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(Report_dgv.DataSource) Then
            Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Clipboard.SetDataObject(Report_dgv.GetClipboardContent())
            Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Status("Copiado")
        End If
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = text
    End Sub

    Private Sub PivotIt()
        LoadingScreen.Show()
        Dim rows As New List(Of String)
        Dim columns As New List(Of String)
        Dim values As New List(Of String)
        Dim aggregates As New List(Of AggregateFunction)
        For Each lbl As Label In Rows_flp.Controls
            rows.Add(CType(lbl.Tag, Field).Name)
        Next
        For Each lbl As Label In Columns_flp.Controls
            columns.Add(CType(lbl.Tag, Field).Name)
        Next
        For Each lbl As Label In Values_flp.Controls
            values.Add(CType(lbl.Tag, Field).Name)
            aggregates.Add(CType(lbl.Tag, Field).Aggregate)
        Next
        Dim pivot As DataTable = DatatablePivoter.Get(Me.DataSource, rows.ToArray, columns.ToArray, values.ToArray, aggregates.ToArray, , TotalColumns_chk.Checked, TotalRow_chk.Checked)
        If pivot IsNot Nothing Then
            Report_dgv.DataSource = Nothing
            Report_dgv.DataSource = pivot
            LoadingScreen.Hide()
        Else
            LoadingScreen.Hide()
            FlashAlerts.ShowError("Error al generar la tabla pivote.")
        End If
    End Sub



    Private Sub Refresh_btn_Click(sender As Object, e As EventArgs) Handles Refresh_btn.Click
        PivotIt()
    End Sub

    Private Sub Field_DragEnter(sender As Object, e As DragEventArgs) Handles Fields_flp.DragEnter, Rows_flp.DragEnter, Columns_flp.DragEnter, Values_flp.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub Fields_flp_DragDrop(sender As Object, e As DragEventArgs) Handles Fields_flp.DragDrop
        With CType(e.Data.GetData(GetType(Label)), Label)
            .Parent = CType(sender, FlowLayoutPanel)
            CType(.Tag, Field).Status = FieldStatus.Field
            .Image = Nothing
        End With
    End Sub

    Private Sub Rows_flp_DragDrop(sender As Object, e As DragEventArgs) Handles Rows_flp.DragDrop
        With CType(e.Data.GetData(GetType(Label)), Label)
            .Parent = CType(sender, FlowLayoutPanel)
            CType(.Tag, Field).Status = FieldStatus.Row
            .Image = Nothing
        End With
    End Sub

    Private Sub Columns_flp_DragDrop(sender As Object, e As DragEventArgs) Handles Columns_flp.DragDrop
        With CType(e.Data.GetData(GetType(Label)), Label)
            .Parent = CType(sender, FlowLayoutPanel)
            CType(.Tag, Field).Status = FieldStatus.Column
            .Image = Nothing
        End With
    End Sub

    Private Sub Values_flp_DragDrop(sender As Object, e As DragEventArgs) Handles Values_flp.DragDrop
        With CType(e.Data.GetData(GetType(Label)), Label)
            .Parent = CType(sender, FlowLayoutPanel)
            CType(.Tag, Field).Status = FieldStatus.Value
            Select Case CType(.Tag, Field).Aggregate
                Case AggregateFunction.Sum
                    .Image = Sum_cmsi.Image
                Case AggregateFunction.Average
                    .Image = Average_cmsi.Image
                Case AggregateFunction.Count
                    .Image = Count_cmsi.Image
                Case AggregateFunction.Min
                    .Image = Minimum_cmsi.Image
                Case AggregateFunction.Max
                    .Image = Maximum_cmsi.Image
                Case AggregateFunction.First
                    .Image = First_cmsi.Image
                Case AggregateFunction.Last
                    .Image = Last_cmsi.Image
                Case AggregateFunction.Exists
                    .Image = Exists_cmsi.Image
            End Select
        End With
    End Sub

    Private Sub Field_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            CType(sender, Label).DoDragDrop(sender, DragDropEffects.Move)
        End If
    End Sub

    Private Sub Aggregates_cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Aggregates_cms.Opening
        With CType(Aggregates_cms.SourceControl.Tag, Field)
            If .Status = FieldStatus.Value Then
                Sum_cmsi.Checked = False
                Average_cmsi.Checked = False
                Count_cmsi.Checked = False
                Minimum_cmsi.Checked = False
                Maximum_cmsi.Checked = False
                First_cmsi.Checked = False
                Last_cmsi.Checked = False
                Exists_cmsi.Checked = False
                Select Case .Aggregate
                    Case AggregateFunction.Sum
                        Sum_cmsi.Checked = True
                    Case AggregateFunction.Average
                        Average_cmsi.Checked = True
                    Case AggregateFunction.Count
                        Count_cmsi.Checked = True
                    Case AggregateFunction.Min
                        Minimum_cmsi.Checked = True
                    Case AggregateFunction.Max
                        Maximum_cmsi.Checked = True
                    Case AggregateFunction.First
                        First_cmsi.Checked = True
                    Case AggregateFunction.Last
                        Last_cmsi.Checked = True
                    Case AggregateFunction.Exists
                        Exists_cmsi.Checked = True
                End Select
            Else
                e.Cancel = True
            End If
        End With
    End Sub

    Private Sub Sum_cmsi_Click(sender As Object, e As EventArgs) Handles Sum_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Sum_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Sum
        End With
    End Sub

    Private Sub Count_cmsi_Click(sender As Object, e As EventArgs) Handles Count_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Count_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Count
        End With
    End Sub

    Private Sub Average_cmsi_Click(sender As Object, e As EventArgs) Handles Average_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Average_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Average
        End With
    End Sub

    Private Sub Maximum_cmsi_Click(sender As Object, e As EventArgs) Handles Maximum_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Maximum_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Max
        End With
    End Sub

    Private Sub Minimum_cmsi_Click(sender As Object, e As EventArgs) Handles Minimum_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Minimum_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Min
        End With
    End Sub

    Private Sub First_cmsi_Click(sender As Object, e As EventArgs) Handles First_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = First_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.First
        End With
    End Sub

    Private Sub Last_cmsi_Click(sender As Object, e As EventArgs) Handles Last_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Last_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Last
        End With
    End Sub

    Private Sub Exists_cmsi_Click(sender As Object, e As EventArgs) Handles Exists_cmsi.Click
        With CType(Aggregates_cms.SourceControl, Label)
            .Image = Exists_cmsi.Image
            CType(.Tag, Field).Aggregate = AggregateFunction.Exists
        End With
    End Sub

    Private Sub Report_dgv_DataSourceChanged(sender As Object, e As EventArgs) Handles Report_dgv.DataSourceChanged
        If Report_dgv.DataSource IsNot Nothing Then
            For Each col As DataGridViewColumn In Report_dgv.Columns
                Select Case CType(Report_dgv.DataSource, DataTable).Columns(col.DataPropertyName).DataType
                    Case GetType(Decimal), GetType(Double)
                        col.DefaultCellStyle.Format = "N2"
                End Select
            Next
        End If
    End Sub
End Class