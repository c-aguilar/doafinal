<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smk_Kiosk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smk_Kiosk))
        Me.DieCenter_lbl = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Partial_btn = New System.Windows.Forms.Button()
        Me.Open_btn = New System.Windows.Forms.Button()
        Me.Change_btn = New System.Windows.Forms.Button()
        Me.Store_btn = New System.Windows.Forms.Button()
        Me.Empty_btn = New System.Windows.Forms.Button()
        Me.Find_btn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Option_txt = New CAguilar.WaterMarkTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DieCenter_lbl
        '
        Me.DieCenter_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DieCenter_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.DieCenter_lbl.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DieCenter_lbl.ForeColor = System.Drawing.Color.White
        Me.DieCenter_lbl.Location = New System.Drawing.Point(12, 9)
        Me.DieCenter_lbl.Name = "DieCenter_lbl"
        Me.DieCenter_lbl.Size = New System.Drawing.Size(925, 43)
        Me.DieCenter_lbl.TabIndex = 30
        Me.DieCenter_lbl.Text = "Kiosko de Supermercado"
        Me.DieCenter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 55)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(925, 489)
        Me.TableLayoutPanel1.TabIndex = 51
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Partial_btn)
        Me.Panel3.Controls.Add(Me.Open_btn)
        Me.Panel3.Controls.Add(Me.Change_btn)
        Me.Panel3.Controls.Add(Me.Store_btn)
        Me.Panel3.Controls.Add(Me.Empty_btn)
        Me.Panel3.Controls.Add(Me.Find_btn)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(115, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(694, 483)
        Me.Panel3.TabIndex = 0
        '
        'Partial_btn
        '
        Me.Partial_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Partial_btn.BackColor = System.Drawing.Color.White
        Me.Partial_btn.BackgroundImage = CType(resources.GetObject("Partial_btn.BackgroundImage"), System.Drawing.Image)
        Me.Partial_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Partial_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Partial_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Partial_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partial_btn.Location = New System.Drawing.Point(24, 370)
        Me.Partial_btn.Name = "Partial_btn"
        Me.Partial_btn.Size = New System.Drawing.Size(264, 93)
        Me.Partial_btn.TabIndex = 42
        Me.Partial_btn.Text = "PARCIAL"
        Me.Partial_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Partial_btn.UseVisualStyleBackColor = False
        '
        'Open_btn
        '
        Me.Open_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Open_btn.BackColor = System.Drawing.Color.White
        Me.Open_btn.BackgroundImage = CType(resources.GetObject("Open_btn.BackgroundImage"), System.Drawing.Image)
        Me.Open_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Open_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Open_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Open_btn.Location = New System.Drawing.Point(407, 228)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(264, 93)
        Me.Open_btn.TabIndex = 41
        Me.Open_btn.Text = "ABRIR"
        Me.Open_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Open_btn.UseVisualStyleBackColor = False
        '
        'Change_btn
        '
        Me.Change_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Change_btn.BackColor = System.Drawing.Color.White
        Me.Change_btn.BackgroundImage = CType(resources.GetObject("Change_btn.BackgroundImage"), System.Drawing.Image)
        Me.Change_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Change_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Change_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Change_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Change_btn.Location = New System.Drawing.Point(24, 228)
        Me.Change_btn.Name = "Change_btn"
        Me.Change_btn.Size = New System.Drawing.Size(264, 93)
        Me.Change_btn.TabIndex = 40
        Me.Change_btn.Text = "CAMBIO"
        Me.Change_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Change_btn.UseVisualStyleBackColor = False
        '
        'Store_btn
        '
        Me.Store_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Store_btn.BackColor = System.Drawing.Color.White
        Me.Store_btn.BackgroundImage = CType(resources.GetObject("Store_btn.BackgroundImage"), System.Drawing.Image)
        Me.Store_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Store_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Store_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Store_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Store_btn.Location = New System.Drawing.Point(407, 86)
        Me.Store_btn.Name = "Store_btn"
        Me.Store_btn.Size = New System.Drawing.Size(264, 93)
        Me.Store_btn.TabIndex = 39
        Me.Store_btn.Text = "ALTA"
        Me.Store_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Store_btn.UseVisualStyleBackColor = False
        '
        'Empty_btn
        '
        Me.Empty_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Empty_btn.BackColor = System.Drawing.Color.White
        Me.Empty_btn.BackgroundImage = CType(resources.GetObject("Empty_btn.BackgroundImage"), System.Drawing.Image)
        Me.Empty_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Empty_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Empty_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Empty_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Empty_btn.Location = New System.Drawing.Point(407, 370)
        Me.Empty_btn.Name = "Empty_btn"
        Me.Empty_btn.Size = New System.Drawing.Size(264, 93)
        Me.Empty_btn.TabIndex = 38
        Me.Empty_btn.Text = "VACIO"
        Me.Empty_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Empty_btn.UseVisualStyleBackColor = False
        '
        'Find_btn
        '
        Me.Find_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Find_btn.BackColor = System.Drawing.Color.White
        Me.Find_btn.BackgroundImage = CType(resources.GetObject("Find_btn.BackgroundImage"), System.Drawing.Image)
        Me.Find_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Find_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Find_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Find_btn.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Find_btn.Location = New System.Drawing.Point(24, 86)
        Me.Find_btn.Name = "Find_btn"
        Me.Find_btn.Size = New System.Drawing.Size(264, 93)
        Me.Find_btn.TabIndex = 37
        Me.Find_btn.Text = "BUSCAR"
        Me.Find_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Find_btn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.Option_txt)
        Me.Panel2.Location = New System.Drawing.Point(216, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(263, 41)
        Me.Panel2.TabIndex = 27
        '
        'Option_txt
        '
        Me.Option_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Option_txt.BackColor = System.Drawing.Color.White
        Me.Option_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option_txt.ForeColor = System.Drawing.Color.Black
        Me.Option_txt.Location = New System.Drawing.Point(3, 3)
        Me.Option_txt.Name = "Option_txt"
        Me.Option_txt.Size = New System.Drawing.Size(257, 35)
        Me.Option_txt.TabIndex = 24
        Me.Option_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Option_txt.WaterMarkColor = System.Drawing.Color.Gray
        Me.Option_txt.WaterMarkText = "Escanea una opcion..."
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Location = New System.Drawing.Point(815, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(107, 483)
        Me.Panel4.TabIndex = 1
        '
        'Smk_Kiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 556)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.DieCenter_lbl)
        Me.Name = "Smk_Kiosk"
        Me.ShowIcon = False
        Me.Text = "Supermarket"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DieCenter_lbl As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Partial_btn As System.Windows.Forms.Button
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents Change_btn As System.Windows.Forms.Button
    Friend WithEvents Store_btn As System.Windows.Forms.Button
    Friend WithEvents Empty_btn As System.Windows.Forms.Button
    Friend WithEvents Find_btn As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Option_txt As CAguilar.WaterMarkTextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
