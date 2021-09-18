Public Class SiGMaReporter
    Dim ParameterList As New List(Of Parameter)
    Dim sb As SearchBox
    Public Property DataSource As DataTable
    Public Property Title As String
    Public Property Area As String
    Dim excel As Excel
    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GF.FillCombobox(Report_cbo, SQL.Current.GetDatatable(String.Format("SELECT Alias, Name FROM Sys_Reports ORDER BY Alias")), "Alias", "Name")
        sb = New SearchBox
        sb.MdiParent = Me.MdiParent
        sb.SetNewDataGridView(Me.Report_dgv)

        Title_lbl.Text = ""

        AddHandler Report_cbo.KeyDown, AddressOf DeltaReporter_KeyDown
    End Sub

    Private Class Parameter
        Public Property Name As String = ""
        Public Property [Alias] As String = ""
        Public Property DataType As String = "String"
        Public Property DefaultValue As String = ""
        Public Property Condition As Condition = Condition.Equal
        Public Property Values As New ArrayList
        Public Property Control As Control
        Public Property ConditionButton As New Button
        Public Property ListButton As New Button
        Public Property FilterActiveCheckbox As New CheckBox
    End Class

    Public Enum Condition
        Equal
        NotEqual
        GreaterThan
        MinorThan
        GreaterOrEqualThan
        MinorOrEqualThan
        [In]
        NotIn
    End Enum

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If Not IsNothing(Me.DataSource) Then
            excel = New Excel
            excel.Print(Me.DataSource, Me.Area, Me.Title)
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        If Not IsNothing(Me.DataSource) Then
            Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Clipboard.SetDataObject(Report_dgv.GetClipboardContent())
            Report_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Status("Copiado")
        End If
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        sb.Show()
        sb.BringToFront()
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = text
    End Sub

    Private Sub ReportViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sb.Dispose()
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        excel = New Excel()
        If Me.DataSource IsNot Nothing Then excel.Export(Me.DataSource, Strings.Left(Me.Title.Replace("*", "").Replace("?", "").Replace(":", "").Replace("\", "").Replace("/", ""), 30))
    End Sub

    Private Sub Run_btn_Click(sender As Object, e As EventArgs) Handles Run_btn.Click
        LoadReport()
    End Sub

    Private Sub LoadReport()
        If Report_cbo.SelectedValue IsNot Nothing Then
            'LoadingScreen.Show()
            Dim command As New SqlClient.SqlCommand
            Dim [select] As String = SQL.Current.GetString("Command", "Sys_Reports", "Name", Report_cbo.SelectedValue, "")
            Dim filter As String = SQL.Current.GetString("Filter", "Sys_Reports", "Name", Report_cbo.SelectedValue, "")
            Dim sort As String = SQL.Current.GetString("Sort", "Sys_Reports", "Name", Report_cbo.SelectedValue, "")
            Dim groupby As String = SQL.Current.GetString("[Group]", "Sys_Reports", "Name", Report_cbo.SelectedValue, "")
            Dim having As String = SQL.Current.GetString("[Having]", "Sys_Reports", "Name", Report_cbo.SelectedValue, "")
            If sort <> "" Then sort = "ORDER BY " & sort
            If groupby <> "" Then groupby = "GROUP BY " & groupby
            If having <> "" Then having = "HAVING " & having
            Dim extra_filter As New ArrayList
            Dim counter As Integer = 1
            For Each p In ParameterList
                If p.FilterActiveCheckbox.Checked Then
                    Select Case p.DataType
                        Case "Date"
                            Select Case p.Condition
                                Case Condition.Equal
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} = {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.NotEqual
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <> {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} > {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} >= {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} < {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.Date
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value.Date
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <= {1}", p.Name, String.Format("@p{0}", counter)))
                            End Select
                        Case "DateTime"
                            Select Case p.Condition
                                Case Condition.Equal
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} = {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.NotEqual
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <> {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} > {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} >= {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} < {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.DbType = DbType.DateTime
                                    cmd_parameter.Value = CType(p.Control, DateTimePicker).Value
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <= {1}", p.Name, String.Format("@p{0}", counter)))
                            End Select
                        Case "Boolean"
                            Dim cmd_parameter As New SqlClient.SqlParameter
                            cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                            cmd_parameter.DbType = DbType.Boolean
                            cmd_parameter.Value = CType(p.Control, CheckBox).Checked
                            command.Parameters.Add(cmd_parameter)
                            extra_filter.Add(String.Format("{0} = {1}", p.Name, String.Format("@p{0}", counter)))
                        Case "Integer", "Double", "Decimal"
                            Select Case p.Condition
                                Case Condition.Equal
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} = {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.NotEqual
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <> {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} > {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.GreaterOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} >= {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} < {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.MinorOrEqualThan
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} <= {1}", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.In
                                    extra_filter.Add(String.Format("{0} IN ({1})", p.Name, String.Join(",", p.Values.ToArray)))
                                Case Condition.NotIn
                                    extra_filter.Add(String.Format("{0} NOT IN ({1})", p.Name, String.Join(",", p.Values.ToArray)))
                            End Select
                        Case "String"
                            Select Case p.Condition
                                Case Condition.Equal
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} LIKE '{1}'", p.Name, p.Control.Text)) 'String.Format("@p{0}", counter)
                                Case Condition.NotEqual
                                    Dim cmd_parameter As New SqlClient.SqlParameter
                                    cmd_parameter.ParameterName = String.Format("@p{0}", counter)
                                    cmd_parameter.Value = p.Control.Text
                                    command.Parameters.Add(cmd_parameter)
                                    extra_filter.Add(String.Format("{0} NOT LIKE '{1}'", p.Name, String.Format("@p{0}", counter)))
                                Case Condition.In
                                    Dim new_values As New ArrayList
                                    For Each v In p.Values
                                        new_values.Add(v.ToString.Replace("'", "''"))
                                    Next
                                    extra_filter.Add(String.Format("{0} IN ('{1}')", p.Name, String.Join("','", new_values.ToArray)))
                                Case Condition.NotIn
                                    Dim new_values As New ArrayList
                                    For Each v In p.Values
                                        new_values.Add(v.ToString.Replace("'", "''"))
                                    Next
                                    extra_filter.Add(String.Format("{0} NOT IN ('{1}')", p.Name, String.Join("','", new_values.ToArray)))
                            End Select
                    End Select
                    counter += 1
                End If
            Next
            If filter = "" Then
                If extra_filter.Count = 0 Then
                    [select] = String.Format("{0} {1} {2} {3};", [select], groupby, having, sort)
                Else
                    [select] = String.Format("{0} WHERE {1} {2} {3} {4};", [select], String.Join(" AND ", extra_filter.ToArray), groupby, having, sort)
                End If
            Else
                If extra_filter.Count = 0 Then
                    [select] = String.Format("{0} WHERE {1} {2} {3} {4};", [select], filter, groupby, having, sort)
                Else
                    [select] = String.Format("{0} WHERE {1} AND {2} {3} {4} {5};", [select], filter, String.Join(" AND ", extra_filter.ToArray), groupby, having, sort)
                End If
            End If
            command.CommandText = [select]
            Me.DataSource = SQL.Current.GetDatatable(command)
            Report_dgv.DataSource = Me.DataSource
            'LoadingScreen.Hide()
        End If
    End Sub


    Private Sub LoadParameters()
        ParameterList.Clear()
        Controls_flp.Controls.Clear()
        Dim parameters As DataTable = SQL.Current.GetDatatable(String.Format("SELECT Alias,Parameter,DataType,ISNULL(DefaultValue,'') AS DefaultValue,DefaultCondition,DefaultStatus FROM Sys_ReportParameters WHERE ReportName = '{0}' ORDER BY OrdinalPosition;", Report_cbo.SelectedValue))
        For Each p As DataRow In parameters.Rows
            Dim item As New Parameter
            item.Alias = p.Item("Alias")
            item.DataType = p.Item("DataType")
            item.Name = p.Item("Parameter")
            item.DefaultValue = p.Item("DefaultValue")
            item.FilterActiveCheckbox.Checked = p.Item("DefaultStatus")
            If Not item.FilterActiveCheckbox.Checked Then item.ConditionButton.Enabled = False
            Select Case p.Item("DefaultCondition")
                Case "Equal"
                    item.Condition = Condition.Equal
                Case "NotEqual"
                    item.Condition = Condition.NotEqual
                Case "GreaterThan"
                    item.Condition = Condition.GreaterThan
                Case "GreaterOrEqualThan"
                    item.Condition = Condition.GreaterOrEqualThan
                Case "MinorThan"
                    item.Condition = Condition.MinorThan
                Case "MinorOrEqualThan"
                    item.Condition = Condition.MinorOrEqualThan
                Case "In"
                    item.Condition = Condition.In
                Case "NotIn"
                    item.Condition = Condition.NotIn
            End Select
            item.ConditionButton.BackgroundImageLayout = ImageLayout.Zoom
            Select Case item.Condition
                Case Condition.Equal
                    item.ConditionButton.Image = My.Resources.equal
                    item.ListButton.Visible = False
                Case Condition.NotEqual
                    item.ConditionButton.Image = My.Resources.not_equal
                    item.ListButton.Visible = False
                Case Condition.GreaterThan
                    item.ConditionButton.Image = My.Resources.greater
                    item.ListButton.Visible = False
                Case Condition.GreaterOrEqualThan
                    item.ConditionButton.Image = My.Resources.greater_equal
                    item.ListButton.Visible = False
                Case Condition.MinorThan
                    item.ConditionButton.Image = My.Resources.minor
                    item.ListButton.Visible = False
                Case Condition.MinorOrEqualThan
                    item.ConditionButton.Image = My.Resources.minor_equal_
                    item.ListButton.Visible = False
                Case Condition.In
                    item.ConditionButton.Image = My.Resources._in
                    item.ListButton.Visible = True
                Case Condition.NotIn
                    item.ConditionButton.Image = My.Resources.not_in
                    item.ListButton.Visible = True
            End Select
            item.ConditionButton.FlatStyle = FlatStyle.Flat
            item.ConditionButton.FlatAppearance.BorderSize = 0
            item.ConditionButton.Size = New Size(21, 21)
            item.ConditionButton.Margin = New Padding(0, 2, 0, 0)
            item.ConditionButton.Cursor = Cursors.Hand
            item.ConditionButton.Tag = item
            item.ListButton.FlatStyle = FlatStyle.Flat
            item.ListButton.FlatAppearance.BorderSize = 0
            item.ListButton.Size = New Size(20, 20)
            item.ListButton.Margin = New Padding(0, 3, 0, 0)
            item.ListButton.Cursor = Cursors.Hand
            item.ListButton.Tag = item
            'item.ListButton.BackgroundImage = My.Resources.text_list_bullets
            item.ListButton.BackgroundImageLayout = ImageLayout.Zoom
            item.FilterActiveCheckbox.Tag = item
            item.FilterActiveCheckbox.AutoSize = True
            item.FilterActiveCheckbox.Margin = New Padding(0, 6, 0, 0)
            AddHandler item.ConditionButton.Click, AddressOf ConditionClick
            AddHandler item.FilterActiveCheckbox.CheckedChanged, AddressOf FilterStateChanged
            AddHandler item.ListButton.Click, AddressOf ListClick

            Dim flp As New FlowLayoutPanel
            flp.AutoSize = True
            flp.FlowDirection = FlowDirection.LeftToRight

            Dim label As New Label
            label.AutoSize = True
            label.Text = String.Format("{0}: ", item.Alias)

            Select Case item.DataType
                Case "Date"
                    Dim control As New DateTimePicker
                    control.CustomFormat = "MM/dd/yyyy"
                    control.Format = DateTimePickerFormat.Custom
                    control.Size = New Size(100, 20)
                    control.Enabled = item.FilterActiveCheckbox.Checked
                    AddHandler control.KeyDown, AddressOf DeltaReporter_KeyDown
                    If item.DefaultValue <> "" AndAlso Date.TryParse(item.DefaultValue, Nothing) Then control.Value = CDate(item.DefaultValue)
                    item.Control = control
                    flp.Controls.Add(item.FilterActiveCheckbox)
                    flp.Controls.Add(item.ConditionButton)
                    flp.Controls.Add(control)
                    Controls_flp.Controls.Add(label)
                    Controls_flp.Controls.Add(flp)
                Case "DateTime"
                    Dim control As New DateTimePicker
                    control.CustomFormat = "MM/dd/yyyy HH:mm"
                    control.Format = DateTimePickerFormat.Custom
                    control.Size = New Size(130, 20)
                    control.Enabled = item.FilterActiveCheckbox.Checked
                    AddHandler control.KeyDown, AddressOf DeltaReporter_KeyDown
                    If item.DefaultValue <> "" AndAlso Date.TryParse(item.DefaultValue, Nothing) Then control.Value = CDate(item.DefaultValue)
                    item.Control = control
                    flp.Controls.Add(item.FilterActiveCheckbox)
                    flp.Controls.Add(item.ConditionButton)
                    flp.Controls.Add(control)
                    Controls_flp.Controls.Add(label)
                    Controls_flp.Controls.Add(flp)
                Case "Boolean"
                    Dim control As New CheckBox
                    control.Text = item.Alias
                    control.AutoSize = True
                    control.RightToLeft = Windows.Forms.RightToLeft.Yes
                    control.Enabled = item.FilterActiveCheckbox.Checked
                    AddHandler control.KeyDown, AddressOf DeltaReporter_KeyDown
                    If item.DefaultValue <> "" AndAlso Boolean.TryParse(item.DefaultValue, Nothing) Then control.Checked = CBool(item.DefaultValue)
                    item.Control = control
                    flp.Controls.Add(item.FilterActiveCheckbox)
                    flp.Controls.Add(control)
                    Controls_flp.Controls.Add(flp)
                Case Else
                    Dim control As New TextBox
                    control.Size = New Size(100, 20)
                    control.Text = item.DefaultValue
                    control.Enabled = item.FilterActiveCheckbox.Checked
                    AddHandler control.KeyDown, AddressOf DeltaReporter_KeyDown
                    item.Control = control
                    flp.Controls.Add(item.FilterActiveCheckbox)
                    flp.Controls.Add(item.ConditionButton)
                    flp.Controls.Add(control)
                    flp.Controls.Add(item.ListButton)
                    Controls_flp.Controls.Add(label)
                    Controls_flp.Controls.Add(flp)
            End Select
            ParameterList.Add(item)
        Next
    End Sub

    Private Sub Report_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Report_cbo.SelectionChangeCommitted
        Me.Title = Report_cbo.GetItemText(Report_cbo.Items(Report_cbo.SelectedIndex))
        Title_lbl.Text = Me.Title
        Me.DataSource = Nothing
        Report_dgv.DataSource = Nothing
        LoadParameters()
    End Sub

    Private Sub FilterStateChanged(sender As Object, e As EventArgs)
        Dim cb = CType(sender, CheckBox)
        Dim p As Parameter = cb.Tag
        If p.Condition = Condition.In OrElse p.Condition = Condition.NotIn Then
            p.ListButton.Enabled = cb.Checked
        Else
            p.Control.Enabled = cb.Checked
        End If
        p.ConditionButton.Enabled = cb.Checked
    End Sub

    Private Sub ConditionClick(sender As Object, e As EventArgs)
        'Dim cs As New ConditionSelector
        Dim p As Parameter = CType(sender, Button).Tag
        'Select Case p.DataType
        '    Case "Date", "DateTime"
        '        cs.In_btn.Enabled = False
        '        cs.In_lbl.Enabled = False
        '    Case "String"
        '        cs.Greater_btn.Enabled = False
        '        cs.GreaterEqual_btn.Enabled = False
        '        cs.Minor_btn.Enabled = False
        '        cs.MinorEqual_btn.Enabled = False
        '        cs.Greater_lbl.Enabled = False
        '        cs.GreaterEqual_lbl.Enabled = False
        '        cs.Minor_lbl.Enabled = False
        '        cs.MinorEqual_lbl.Enabled = False
        'End Select

        'If cs.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    If p.Condition = Condition.In AndAlso cs.Condition <> Condition.In Then
        '        p.Control.Text = ""
        '        p.Control.Enabled = True
        '        p.Values.Clear()
        '    ElseIf p.Condition = Condition.NotIn AndAlso cs.Condition <> Condition.NotIn Then
        '        p.Control.Text = ""
        '        p.Control.Enabled = True
        '        p.Values.Clear()
        '    End If
        '    p.Condition = cs.Condition
        Select Case p.Condition
                Case Condition.Equal
                    p.ConditionButton.Image = My.Resources.equal
                    p.ListButton.Visible = False
                Case Condition.NotEqual
                    p.ConditionButton.Image = My.Resources.not_equal
                    p.ListButton.Visible = False
                Case Condition.GreaterThan
                    p.ConditionButton.Image = My.Resources.greater
                    p.ListButton.Visible = False
                Case Condition.GreaterOrEqualThan
                    p.ConditionButton.Image = My.Resources.greater_equal
                    p.ListButton.Visible = False
                Case Condition.MinorThan
                    p.ConditionButton.Image = My.Resources.minor
                    p.ListButton.Visible = False
                Case Condition.MinorOrEqualThan
                    p.ConditionButton.Image = My.Resources.minor_equal_
                    p.ListButton.Visible = False
                Case Condition.In
                    p.ConditionButton.Image = My.Resources._in
                    p.ListButton.Visible = True
                    p.Control.Text = ""
                    p.Control.Enabled = False
                Case Condition.NotIn
                    p.ConditionButton.Image = My.Resources.not_in
                    p.ListButton.Visible = True
                    p.Control.Text = ""
                    p.Control.Enabled = False
            End Select
        'End If
    End Sub

    Private Sub ListClick(sender As Object, e As EventArgs)
        Dim p As Parameter = CType(sender, Button).Tag
        Dim ld As New ListDialog
        ld.Items.AddRange(p.Values)
        ld.Title = p.Alias
        ld.AcceptDuplicates = False
        If ld.ShowDialog() = Windows.Forms.DialogResult.OK Then
            p.Values.Clear()
            p.Values = ld.Items
            If p.Values.Count > 0 Then
                p.Control.Text = String.Join(",", p.Values.ToArray)
            Else
                p.Control.Text = ""
            End If
        End If
        ld.Dispose()
    End Sub

    Private Sub DeltaReporter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub DeltaReporter_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F5 Then
            LoadReport()
        End If
    End Sub

    Private Sub exportExcel_btn_Click(sender As Object, e As EventArgs)
        excel = New Excel
        excel.Export(Me.DataSource, Me.Title)
    End Sub
End Class