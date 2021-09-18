<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_Dashboard))
        Me.DropDownMenu2 = New CAguilar.DropDownMenu()
        Me.RunAllSuggestions_btn = New System.Windows.Forms.Button()
        Me.Copy_btn = New System.Windows.Forms.Button()
        Me.ImportPhysicalInventory_btn = New System.Windows.Forms.Button()
        Me.Export_btn = New System.Windows.Forms.Button()
        Me.Refresh_btn = New System.Windows.Forms.Button()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.DropDownMenu2.ChildPanel.SuspendLayout()
        Me.DropDownMenu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DropDownMenu2
        '
        Me.DropDownMenu2.BackColor = System.Drawing.Color.Transparent
        '
        'DropDownMenu2.MainPanel
        '
        Me.DropDownMenu2.ChildPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DropDownMenu2.ChildPanel.AutoScroll = True
        Me.DropDownMenu2.ChildPanel.BackColor = System.Drawing.Color.White
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.RunAllSuggestions_btn)
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.Copy_btn)
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.ImportPhysicalInventory_btn)
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.Export_btn)
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.Refresh_btn)
        Me.DropDownMenu2.ChildPanel.Controls.Add(Me.Find_btn)
        Me.DropDownMenu2.ChildPanel.Location = New System.Drawing.Point(2, 31)
        Me.DropDownMenu2.ChildPanel.Name = "MainPanel"
        Me.DropDownMenu2.ChildPanel.Size = New System.Drawing.Size(1079, 131)
        Me.DropDownMenu2.ChildPanel.TabIndex = 20
        Me.DropDownMenu2.DisplayedText = "Plan de Componentes"
        Me.DropDownMenu2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DropDownMenu2.Expanded = True
        Me.DropDownMenu2.ForcedHeight = 175
        Me.DropDownMenu2.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.DropDownMenu2.HeaderForeColor = System.Drawing.Color.White
        Me.DropDownMenu2.Location = New System.Drawing.Point(0, 0)
        Me.DropDownMenu2.Margin = New System.Windows.Forms.Padding(0)
        Me.DropDownMenu2.Name = "DropDownMenu2"
        Me.DropDownMenu2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.DropDownMenu2.Size = New System.Drawing.Size(1178, 175)
        Me.DropDownMenu2.TabIndex = 2
        '
        'RunAllSuggestions_btn
        '
        Me.RunAllSuggestions_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RunAllSuggestions_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RunAllSuggestions_btn.FlatAppearance.BorderSize = 0
        Me.RunAllSuggestions_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RunAllSuggestions_btn.ForeColor = System.Drawing.Color.Black
        Me.RunAllSuggestions_btn.Image = CType(resources.GetObject("RunAllSuggestions_btn.Image"), System.Drawing.Image)
        Me.RunAllSuggestions_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RunAllSuggestions_btn.Location = New System.Drawing.Point(9, 119)
        Me.RunAllSuggestions_btn.Name = "RunAllSuggestions_btn"
        Me.RunAllSuggestions_btn.Padding = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.RunAllSuggestions_btn.Size = New System.Drawing.Size(145, 21)
        Me.RunAllSuggestions_btn.TabIndex = 7
        Me.RunAllSuggestions_btn.Text = "Ejecutar Sugerencias"
        Me.RunAllSuggestions_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RunAllSuggestions_btn.UseVisualStyleBackColor = True
        '
        'Copy_btn
        '
        Me.Copy_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Copy_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Copy_btn.FlatAppearance.BorderSize = 0
        Me.Copy_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Copy_btn.ForeColor = System.Drawing.Color.Black
        Me.Copy_btn.Image = CType(resources.GetObject("Copy_btn.Image"), System.Drawing.Image)
        Me.Copy_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Copy_btn.Location = New System.Drawing.Point(10, 77)
        Me.Copy_btn.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.Copy_btn.Name = "Copy_btn"
        Me.Copy_btn.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.Copy_btn.Size = New System.Drawing.Size(91, 20)
        Me.Copy_btn.TabIndex = 6
        Me.Copy_btn.Text = "Copiar"
        Me.Copy_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Copy_btn.UseVisualStyleBackColor = True
        '
        'ImportPhysicalInventory_btn
        '
        Me.ImportPhysicalInventory_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImportPhysicalInventory_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImportPhysicalInventory_btn.FlatAppearance.BorderSize = 0
        Me.ImportPhysicalInventory_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportPhysicalInventory_btn.ForeColor = System.Drawing.Color.Black
        Me.ImportPhysicalInventory_btn.Image = CType(resources.GetObject("ImportPhysicalInventory_btn.Image"), System.Drawing.Image)
        Me.ImportPhysicalInventory_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImportPhysicalInventory_btn.Location = New System.Drawing.Point(9, 98)
        Me.ImportPhysicalInventory_btn.Name = "ImportPhysicalInventory_btn"
        Me.ImportPhysicalInventory_btn.Padding = New System.Windows.Forms.Padding(0, 0, 17, 0)
        Me.ImportPhysicalInventory_btn.Size = New System.Drawing.Size(145, 20)
        Me.ImportPhysicalInventory_btn.TabIndex = 5
        Me.ImportPhysicalInventory_btn.Text = "Inventario en WIP"
        Me.ImportPhysicalInventory_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ImportPhysicalInventory_btn.UseVisualStyleBackColor = True
        '
        'Export_btn
        '
        Me.Export_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Export_btn.FlatAppearance.BorderSize = 0
        Me.Export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Export_btn.ForeColor = System.Drawing.Color.Black
        Me.Export_btn.Image = CType(resources.GetObject("Export_btn.Image"), System.Drawing.Image)
        Me.Export_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Export_btn.Location = New System.Drawing.Point(9, 54)
        Me.Export_btn.Name = "Export_btn"
        Me.Export_btn.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Export_btn.Size = New System.Drawing.Size(91, 20)
        Me.Export_btn.TabIndex = 4
        Me.Export_btn.Text = "Exportar"
        Me.Export_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Export_btn.UseVisualStyleBackColor = True
        '
        'Refresh_btn
        '
        Me.Refresh_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Refresh_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Refresh_btn.FlatAppearance.BorderSize = 0
        Me.Refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Refresh_btn.ForeColor = System.Drawing.Color.Black
        Me.Refresh_btn.Image = CType(resources.GetObject("Refresh_btn.Image"), System.Drawing.Image)
        Me.Refresh_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Refresh_btn.Location = New System.Drawing.Point(9, 6)
        Me.Refresh_btn.Name = "Refresh_btn"
        Me.Refresh_btn.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Refresh_btn.Size = New System.Drawing.Size(91, 20)
        Me.Refresh_btn.TabIndex = 4
        Me.Refresh_btn.Text = "Actualizar"
        Me.Refresh_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Refresh_btn.UseVisualStyleBackColor = True
        '
        'Find_btn
        '
        Me.Find_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Find_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Find_btn.FlatAppearance.BorderSize = 0
        Me.Find_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Find_btn.ForeColor = System.Drawing.Color.Black
        Me.Find_btn.Image = CType(resources.GetObject("Find_btn.Image"), System.Drawing.Image)
        Me.Find_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Find_btn.Location = New System.Drawing.Point(9, 31)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.Find_btn.Size = New System.Drawing.Size(91, 20)
        Me.Find_btn.TabIndex = 2
        Me.Find_btn.Text = "Buscar"
        Me.Find_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Find_btn.UseVisualStyleBackColor = True
        '
        'Smk_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1178, 744)
        Me.Controls.Add(Me.DropDownMenu2)
        Me.Name = "Smk_Dashboard"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        Me.DropDownMenu2.ChildPanel.ResumeLayout(False)
        Me.DropDownMenu2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DropDownMenu2 As CAguilar.DropDownMenu
    Friend WithEvents RunAllSuggestions_btn As System.Windows.Forms.Button
    Friend WithEvents Copy_btn As System.Windows.Forms.Button
    Friend WithEvents ImportPhysicalInventory_btn As System.Windows.Forms.Button
    Friend WithEvents Export_btn As System.Windows.Forms.Button
    Friend WithEvents Refresh_btn As System.Windows.Forms.Button
    Friend WithEvents Find_btn As System.Windows.Forms.Button
End Class
