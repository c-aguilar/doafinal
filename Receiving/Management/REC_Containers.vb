Public Class REC_Containers

    Private Sub REC_Containers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetContainers()
    End Sub
    Private Sub GetContainers()
        GF.FillCombobox(ID_cbo, SQL.Current.GetDatatable("SELECT '#####' AS ID,'(Nuevo)' AS Name,'' AS Class UNION ALL SELECT ID, Name, Class FROM Smk_Containers ORDER BY Class,Name"), "Name", "ID")
    End Sub

    Private Sub Badge_cbo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ID_cbo.SelectionChangeCommitted
        If ID_cbo.SelectedValue = "#####" Then
            Clean()
        Else
            ID_txt.ReadOnly = True
            ID_txt.Text = ID_cbo.SelectedValue
            Name_txt.Text = SQL.Current.GetString("Name", "Smk_Containers", "ID", ID_cbo.SelectedValue, "")
            Class_cbo.SelectedItem = SQL.Current.GetString("Class", "Smk_Containers", "ID", ID_cbo.SelectedValue, "")
            Weight_nud.Value = SQL.Current.GetScalar("Weight", "Smk_Containers", "ID", ID_cbo.SelectedValue, 0)
            Picture_pb.Image = SQL.Current.GetImage("Image", "Smk_Containers", "ID", ID_cbo.SelectedValue, My.Resources.No_image_available)
        End If
    End Sub

    Private Sub Clean()
        ID_cbo.SelectedValue = "#####"
        Picture_pb.Image = Nothing
        ID_txt.ReadOnly = False
        ID_txt.Clear()
        Name_txt.Clear()
        Class_cbo.SelectedIndex = -1
        Weight_nud.Value = 0
        ID_txt.Focus()
    End Sub
    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        If ID_cbo.SelectedValue = "#####" Then
            If ID_txt.MaskCompleted Then
                If Class_cbo.SelectedIndex > -1 Then
                    If Name_txt.Text <> "" Then
                        If SQL.Current.Exists("Smk_Containers", "ID", ID_txt.Text) Then
                            FlashAlerts.ShowError("El ID ya existe.")
                        Else
                            If SQL.Current.Insert("Smk_Containers", {"ID", "Name", "Class", "Image", "Weight"}, {ID_txt.Text, Name_txt.Text, Class_cbo.SelectedItem, ImageBytes(Picture_pb.Image), Weight_nud.Value}) Then
                                GetContainers()
                                Clean()
                                FlashAlerts.ShowConfirm("Registrado.")
                            Else
                                FlashAlerts.ShowError("Error al registrar el contenedor.")
                            End If
                        End If
                    Else
                        FlashAlerts.ShowInformation("Ingresa el nombre del contenedor.")
                    End If
                Else
                    FlashAlerts.ShowInformation("Selecciona el tipo de contenedor.")
                End If
            Else
                FlashAlerts.ShowInformation("El ID del contenedor debe contener 5 caracteres.")
            End If
        Else
            If Class_cbo.SelectedIndex > -1 Then
                If Name_txt.Text <> "" Then
                    SQL.Current.Update("Smk_Containers", {"Name", "Image", "Class", "Weight"}, {Name_txt.Text, ImageBytes(Picture_pb.Image), Class_cbo.SelectedItem, Weight_nud.Value}, "ID", ID_cbo.SelectedValue)
                    GetContainers()
                    Clean()
                    FlashAlerts.ShowConfirm("Actualizado.")
                Else
                    FlashAlerts.ShowInformation("Ingresa el nombre del contenedor.")
                End If
            Else
                FlashAlerts.ShowInformation("Selecciona el tipo de contenedor.")
            End If
        End If
    End Sub

    Private Function ImageBytes(picture As Image) As Byte()
        Try
            Dim streamMini = New System.IO.MemoryStream()
            Dim pic_mini = Delta.ResizeImage(picture, New Size(200, 220), False)
            pic_mini.Save(streamMini, System.Drawing.Imaging.ImageFormat.Png)
            streamMini.Position = 0
            Dim mini() As Byte = streamMini.GetBuffer
            Return mini
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If ID_cbo.SelectedValue <> "#####" Then
            If MessageBox.Show("¿Seguro de eliminar este contenedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If SQL.Current.Delete("Smk_Containers", "ID", ID_cbo.SelectedValue) Then
                    FlashAlerts.ShowConfirm("Eliminado.")
                    GetContainers()
                    Clean()
                Else
                    FlashAlerts.ShowError("No es posible eliminar el contenedor.")
                End If
            End If
        End If
    End Sub

    Private Sub Picture_btn_Click(sender As Object, e As EventArgs) Handles Picture_btn.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog()
        dialog.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
        If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim img As Image = Image.FromFile(dialog.FileName)
            Picture_pb.Image = img
        End If
    End Sub

    Private Sub REC_Operators_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class