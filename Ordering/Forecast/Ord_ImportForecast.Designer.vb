<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ImportForecast
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ord_ImportForecast))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Filename_txt = New System.Windows.Forms.TextBox()
        Me.Open_btn = New System.Windows.Forms.Button()
        Me.Forecast_dgv = New CAguilar.DataGridViewWithFilters()
        Me.File_txt = New System.Windows.Forms.Label()
        CType(Me.Forecast_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1000, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Importar Pronostico de Requerimientos"
        '
        'Save_btn
        '
        Me.Save_btn.Enabled = False
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(467, 29)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 25)
        Me.Save_btn.TabIndex = 17
        Me.Save_btn.Text = "Guardar"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Filename_txt
        '
        Me.Filename_txt.Location = New System.Drawing.Point(60, 32)
        Me.Filename_txt.Name = "Filename_txt"
        Me.Filename_txt.ReadOnly = True
        Me.Filename_txt.Size = New System.Drawing.Size(295, 20)
        Me.Filename_txt.TabIndex = 19
        '
        'Open_btn
        '
        Me.Open_btn.Image = CType(resources.GetObject("Open_btn.Image"), System.Drawing.Image)
        Me.Open_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Open_btn.Location = New System.Drawing.Point(361, 29)
        Me.Open_btn.Name = "Open_btn"
        Me.Open_btn.Size = New System.Drawing.Size(100, 25)
        Me.Open_btn.TabIndex = 21
        Me.Open_btn.Text = "Abrir..."
        Me.Open_btn.UseVisualStyleBackColor = True
        '
        'Forecast_dgv
        '
        Me.Forecast_dgv.AllowColumnHiding = True
        Me.Forecast_dgv.AllowUserToAddRows = False
        Me.Forecast_dgv.AllowUserToDeleteRows = False
        Me.Forecast_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Forecast_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Forecast_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Forecast_dgv.Location = New System.Drawing.Point(9, 59)
        Me.Forecast_dgv.Name = "Forecast_dgv"
        Me.Forecast_dgv.ReadOnly = True
        Me.Forecast_dgv.ShowRowNumber = True
        Me.Forecast_dgv.Size = New System.Drawing.Size(983, 386)
        Me.Forecast_dgv.TabIndex = 22
        '
        'File_txt
        '
        Me.File_txt.AutoSize = True
        Me.File_txt.Location = New System.Drawing.Point(9, 35)
        Me.File_txt.Name = "File_txt"
        Me.File_txt.Size = New System.Drawing.Size(46, 13)
        Me.File_txt.TabIndex = 23
        Me.File_txt.Text = "Archivo:"
        '
        'Ord_ImportForecast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 454)
        Me.Controls.Add(Me.File_txt)
        Me.Controls.Add(Me.Forecast_dgv)
        Me.Controls.Add(Me.Open_btn)
        Me.Controls.Add(Me.Filename_txt)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.Label4)
        Me.Name = "Ord_ImportForecast"
        Me.ShowIcon = False
        Me.Text = "Ordering"
        CType(Me.Forecast_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Filename_txt As System.Windows.Forms.TextBox
    Friend WithEvents Open_btn As System.Windows.Forms.Button
    Friend WithEvents Forecast_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents File_txt As System.Windows.Forms.Label
End Class
