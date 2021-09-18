Imports System.Math 'Container'
Public Class Smk_CableSelectTara
    Public Property ContainerID As String
    Public Property DollyID As String
    Public Property ContainerWeight As Decimal
    Public Property DollyWeight As Decimal
    Public Property ContainerClass As String = "containers"
    Dim Maximum As Integer = 0
    Dim Page As Integer = 1
    Private Sub frmDollys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Maximum = Me.Width
        Fill()
    End Sub
    Private Sub Fill()
        plItems.Controls.Clear()
        If ContainerClass = "containers" Then
            Title_lbl.Text = "Seleccion de Contenedor"
            Dim counter As Integer = 0
            Dim row As Integer = 0
            For Each rd As DataRow In SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Cable-Container';").Rows
                If ((counter + 1) * 248) > Maximum Then
                    row += 1
                    counter = 0
                End If
                Dim pb As New PictureBox
                Dim code As New Label
                Dim name As New Label

                pb.Cursor = Cursors.Hand
                code.Cursor = Cursors.Hand
                name.Cursor = Cursors.Hand

                pb.AccessibleDescription = rd("ID")
                code.AccessibleDescription = rd("ID")
                name.AccessibleDescription = rd("ID")

                AddHandler pb.Click, AddressOf Item_Click
                AddHandler code.Click, AddressOf Item_Click
                AddHandler name.Click, AddressOf Item_Click

                With pb
                    .Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", rd("ID"), My.Resources.No_image_available)
                    .Size = New Size(193, 200)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 0, 5 + (row * 305), 5 + (row * 305) + 59))
                End With
                With code
                    .AutoSize = True
                    .Text = "*" & rd("ID") & "*"
                    .Font = New Font("CCode39", 18)
                    .Padding = New Padding(5)
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 1, 5 + (row * 305), 5 + (row * 305) + 200))
                End With
                With name
                    .Text = rd("Name").ToString.ToUpper
                    .AutoSize = False
                    .Size = New Size(193, 30)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .ForeColor = Color.Black
                    .Font = New Font("Microsoft Sans Serif", 18)
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), 267 + (row * 305))
                End With
                plItems.Controls.Add(pb)
                plItems.Controls.Add(code)
                plItems.Controls.Add(name)
                counter += 1
            Next
            If counter = 0 Then
                DollyID = ""
                DollyWeight = 0
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        ElseIf ContainerClass = "only-containers" Then
            Title_lbl.Text = "Seleccion de Contenedor"
            Dim counter As Integer = 0
            Dim row As Integer = 0
            For Each rd As DataRow In SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Cable-Container';").Rows
                If ((counter + 1) * 248) > Maximum Then
                    row += 1
                    counter = 0
                End If
                Dim pb As New PictureBox
                Dim code As New Label
                Dim name As New Label

                pb.Cursor = Cursors.Hand
                code.Cursor = Cursors.Hand
                name.Cursor = Cursors.Hand

                pb.AccessibleDescription = rd("ID")
                code.AccessibleDescription = rd("ID")
                name.AccessibleDescription = rd("ID")

                AddHandler pb.Click, AddressOf Item_Click
                AddHandler code.Click, AddressOf Item_Click
                AddHandler name.Click, AddressOf Item_Click

                With pb
                    .Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", rd("ID"), My.Resources.No_image_available)
                    .Size = New Size(193, 200)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 0, 5 + (row * 305), 5 + (row * 305) + 59))
                End With
                With code
                    .AutoSize = True
                    .Text = "*" & rd("ID") & "*"
                    .Font = New Font("CCode39", 18)
                    .Padding = New Padding(5)
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 1, 5 + (row * 305), 5 + (row * 305) + 200))
                End With
                With name
                    .Text = rd("Name").ToString.ToUpper
                    .AutoSize = False
                    .Size = New Size(193, 30)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .ForeColor = Color.Black
                    .Font = New Font("Microsoft Sans Serif", 18)
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), 267 + (row * 305))
                End With
                plItems.Controls.Add(pb)
                plItems.Controls.Add(code)
                plItems.Controls.Add(name)
                counter += 1
            Next
            If counter = 0 Then
                DollyID = ""
                DollyWeight = 0
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        ElseIf ContainerClass = "api-containers" Then
            Title_lbl.Text = "Seleccion de Contenedor"
            Dim counter As Integer = 0
            Dim row As Integer = 0
            For Each rd As DataRow In SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'API-Container';").Rows
                If ((counter + 1) * 248) > Maximum Then
                    row += 1
                    counter = 0
                End If
                Dim code As New Label
                Dim name As New Label

                code.Cursor = Cursors.Hand
                name.Cursor = Cursors.Hand

                code.AccessibleDescription = rd("ID")
                name.AccessibleDescription = rd("ID")
                AddHandler code.Click, AddressOf Item_Click
                AddHandler name.Click, AddressOf Item_Click

                With code
                    .AutoSize = True
                    .Text = "*" & rd("ID") & "*"
                    .Font = New Font("CCode39", 18)
                    .Padding = New Padding(5)
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), 5 + (row * 95))
                End With
                With name
                    .Text = rd("Name").ToString.ToUpper
                    .AutoSize = False
                    .Size = New Size(193, 30)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .ForeColor = Color.Black
                    .Font = New Font("Microsoft Sans Serif", 18)
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), 60 + (row * 95))
                End With
                plItems.Controls.Add(code)
                plItems.Controls.Add(name)
                counter += 1
            Next
            If counter = 0 Then
                DollyID = ""
                DollyWeight = 0
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            Title_lbl.Text = "Seleccion de Dolly"
            Dim counter As Integer = 0
            Dim row As Integer = 0
            For Each rd As DataRow In SQL.Current.GetDatatable("SELECT ID, Name FROM Smk_Containers WHERE Class = 'Cable-Dolly';").Rows
                If ((counter + 1) * 248) > Maximum Then
                    row += 1
                    counter = 0
                End If
                Dim pb As New PictureBox
                Dim code As New Label
                Dim name As New Label

                pb.Cursor = Cursors.Hand
                code.Cursor = Cursors.Hand
                name.Cursor = Cursors.Hand

                pb.AccessibleDescription = rd("ID")
                code.AccessibleDescription = rd("ID")
                name.AccessibleDescription = rd("ID")

                AddHandler pb.Click, AddressOf Item_Click
                AddHandler code.Click, AddressOf Item_Click
                AddHandler name.Click, AddressOf Item_Click

                With pb
                    .Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", rd("ID"), My.Resources.No_image_available)
                    .Size = New Size(193, 200)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 0, 5 + (row * 305), 5 + (row * 305) + 59))
                End With
                With code
                    .AutoSize = True
                    .Text = "*" & rd("ID") & "*"
                    .Font = New Font("CCode39", 18)
                    .Padding = New Padding(5)
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), IIf((counter Mod 2) = 1, 5 + (row * 305), 5 + (row * 305) + 200))
                End With
                With name
                    .Text = rd("Name").ToString.ToUpper
                    .AutoSize = False
                    .Size = New Size(193, 30)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .ForeColor = Color.Black
                    .Font = New Font("Microsoft Sans Serif", 18)
                    .Location = New Point((55 * (counter + 1)) + (counter * 193), 267 + (row * 305))
                End With
                plItems.Controls.Add(pb)
                plItems.Controls.Add(code)
                plItems.Controls.Add(name)
                counter += 1
            Next
            If counter = 0 Then
                ContainerID = ""
                ContainerWeight = 0
                ContainerClass = "dollys"
                Fill()
            End If
        End If
    End Sub

    Private Sub txtItem_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem.Validated
        If txtItem.Text <> "" AndAlso txtItem.Text.ToUpper <> "CLOSE" Then
            ReadOption()
        End If
    End Sub

    Public Sub ReadOption()
        If ContainerClass = "containers" Then
            If SQL.Current.Exists("Smk_Containers", {"ID", "Class"}, {txtItem.Text, "Cable-Container"}) Then
                ContainerID = txtItem.Text
                ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", txtItem.Text, 0)
                txtItem.Clear()
                txtItem.Focus()
                ContainerClass = "dollys"
                Fill()
            Else
                txtItem.Clear()
                txtItem.Focus()
                FlashAlerts.ShowError("Contenedor no encontrado.")
            End If
        ElseIf ContainerClass = "only-containers" Then
            If SQL.Current.Exists("Smk_Containers", {"ID", "Class"}, {txtItem.Text, "Cable-Container"}) Then
                ContainerID = txtItem.Text
                ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", txtItem.Text, 0)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                txtItem.Clear()
                txtItem.Focus()
                FlashAlerts.ShowError("Contenedor no encontrado.")
            End If
        ElseIf ContainerClass = "api-containers" Then
            If SQL.Current.Exists("Smk_Containers", {"ID", "Class"}, {txtItem.Text, "API-Container"}) Then
                ContainerID = txtItem.Text
                ContainerWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", txtItem.Text, 0)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                txtItem.Clear()
                txtItem.Focus()
                FlashAlerts.ShowError("Contenedor no encontrado.")
            End If
        Else
            If SQL.Current.Exists("Smk_Containers", {"ID", "Class"}, {txtItem.Text, "Cable-Dolly"}) Then
                DollyID = txtItem.Text
                DollyWeight = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", txtItem.Text, 0)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                txtItem.Clear()
                txtItem.Focus()
                FlashAlerts.ShowError("Dolly no encontrado.")
            End If
        End If
    End Sub

    Private Sub Smk_CableSelectTara_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtItem.Focus()
    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItem.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtItem.Text <> "" Then
            ReadOption()
        End If
    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem.TextChanged
        If txtItem.Text.ToUpper = "CLOSE" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        ElseIf txtItem.Text.Length = 5 Then
            ReadOption()
        End If
    End Sub

    Private Sub Item_Click(sender As Object, e As EventArgs)
        txtItem.Text = sender.AccessibleDescription
        ReadOption()
    End Sub

    Private Sub Close_btn_Click(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class