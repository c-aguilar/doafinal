<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReaderSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReaderSelection))
        Me.cboReaders = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCaps = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboReaders
        '
        Me.cboReaders.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboReaders.Location = New System.Drawing.Point(20, 31)
        Me.cboReaders.Name = "cboReaders"
        Me.cboReaders.Size = New System.Drawing.Size(256, 21)
        Me.cboReaders.TabIndex = 8
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.Delta_ERP.My.Resources.Resources.arrow_refresh
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(30, 57)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(115, 23)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "Actualizar"
        '
        'btnCaps
        '
        Me.btnCaps.Enabled = False
        Me.btnCaps.Image = CType(resources.GetObject("btnCaps.Image"), System.Drawing.Image)
        Me.btnCaps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaps.Location = New System.Drawing.Point(151, 57)
        Me.btnCaps.Name = "btnCaps"
        Me.btnCaps.Size = New System.Drawing.Size(115, 23)
        Me.btnCaps.TabIndex = 10
        Me.btnCaps.Text = "Capacidades"
        '
        'btnSelect
        '
        Me.btnSelect.Enabled = False
        Me.btnSelect.Image = Global.Delta_ERP.My.Resources.Resources.tick_16
        Me.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelect.Location = New System.Drawing.Point(30, 86)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(115, 23)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "Seleccionar"
        '
        'btnBack
        '
        Me.btnBack.Image = Global.Delta_ERP.My.Resources.Resources.critical_16
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.Location = New System.Drawing.Point(151, 86)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 23)
        Me.btnBack.TabIndex = 12
        Me.btnBack.Text = "Cancelar"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(296, 25)
        Me.lblTitle.TabIndex = 38
        Me.lblTitle.Text = "Seleccionar Lector"
        '
        'ReaderSelect
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(296, 121)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnCaps)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.cboReaders)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(312, 159)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(312, 159)
        Me.Name = "ReaderSelect"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboReaders As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCaps As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
End Class
