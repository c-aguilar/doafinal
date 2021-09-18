<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_KanbansManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_KanbansManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.Delete_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBoard = New System.Windows.Forms.ComboBox()
        Me.Show_btn = New System.Windows.Forms.Button()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.pnlRecalculate = New System.Windows.Forms.Panel()
        Me.chkKeepContainer = New System.Windows.Forms.CheckBox()
        Me.chkCheck = New System.Windows.Forms.CheckBox()
        Me.chkBoth = New System.Windows.Forms.CheckBox()
        Me.btnRecalculate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Kanbans_dgv = New CAguilar.DataGridViewWithFilters()
        Me.Kanban_ID_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Code_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Partnumber_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Board_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Kit_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_EngineeringLocation_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Slot_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Side_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Section_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Route_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_SupermarketLocation_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Container_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Pieces_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Index_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Date_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Comment_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_NewRoute_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_NewSupermarketLocation_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_NewContainer_col = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Kanban_NewPieces_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kanban_Update_chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel6.SuspendLayout()
        Me.pnlRecalculate.SuspendLayout()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1558, 25)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Generación de Kanbans"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.cboBusiness)
        Me.Panel6.Controls.Add(Me.Delete_btn)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.cboBoard)
        Me.Panel6.Controls.Add(Me.Show_btn)
        Me.Panel6.Controls.Add(Me.Save_btn)
        Me.Panel6.Location = New System.Drawing.Point(5, 31)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(178, 219)
        Me.Panel6.TabIndex = 117
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Negocio:"
        '
        'cboBusiness
        '
        Me.cboBusiness.FormattingEnabled = True
        Me.cboBusiness.Location = New System.Drawing.Point(8, 22)
        Me.cboBusiness.Name = "cboBusiness"
        Me.cboBusiness.Size = New System.Drawing.Size(163, 21)
        Me.cboBusiness.TabIndex = 8
        '
        'Delete_btn
        '
        Me.Delete_btn.Image = CType(resources.GetObject("Delete_btn.Image"), System.Drawing.Image)
        Me.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete_btn.Location = New System.Drawing.Point(71, 153)
        Me.Delete_btn.Name = "Delete_btn"
        Me.Delete_btn.Size = New System.Drawing.Size(100, 26)
        Me.Delete_btn.TabIndex = 7
        Me.Delete_btn.Text = "Eliminar"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tablero:"
        '
        'cboBoard
        '
        Me.cboBoard.FormattingEnabled = True
        Me.cboBoard.Location = New System.Drawing.Point(8, 65)
        Me.cboBoard.Name = "cboBoard"
        Me.cboBoard.Size = New System.Drawing.Size(163, 21)
        Me.cboBoard.TabIndex = 0
        '
        'Show_btn
        '
        Me.Show_btn.Image = CType(resources.GetObject("Show_btn.Image"), System.Drawing.Image)
        Me.Show_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Show_btn.Location = New System.Drawing.Point(71, 92)
        Me.Show_btn.Name = "Show_btn"
        Me.Show_btn.Size = New System.Drawing.Size(100, 25)
        Me.Show_btn.TabIndex = 6
        Me.Show_btn.Text = "Mostrar"
        '
        'Save_btn
        '
        Me.Save_btn.Image = CType(resources.GetObject("Save_btn.Image"), System.Drawing.Image)
        Me.Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_btn.Location = New System.Drawing.Point(71, 121)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(100, 26)
        Me.Save_btn.TabIndex = 3
        Me.Save_btn.Text = "Guardar"
        '
        'pnlRecalculate
        '
        Me.pnlRecalculate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRecalculate.Controls.Add(Me.chkKeepContainer)
        Me.pnlRecalculate.Controls.Add(Me.chkCheck)
        Me.pnlRecalculate.Controls.Add(Me.chkBoth)
        Me.pnlRecalculate.Controls.Add(Me.btnRecalculate)
        Me.pnlRecalculate.Controls.Add(Me.Label4)
        Me.pnlRecalculate.Controls.Add(Me.btnUpdate)
        Me.pnlRecalculate.Controls.Add(Me.Label3)
        Me.pnlRecalculate.Controls.Add(Me.Panel2)
        Me.pnlRecalculate.Controls.Add(Me.Label2)
        Me.pnlRecalculate.Controls.Add(Me.Panel3)
        Me.pnlRecalculate.Controls.Add(Me.Panel5)
        Me.pnlRecalculate.Location = New System.Drawing.Point(5, 256)
        Me.pnlRecalculate.Name = "pnlRecalculate"
        Me.pnlRecalculate.Size = New System.Drawing.Size(178, 270)
        Me.pnlRecalculate.TabIndex = 118
        '
        'chkKeepContainer
        '
        Me.chkKeepContainer.AutoSize = True
        Me.chkKeepContainer.Checked = True
        Me.chkKeepContainer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKeepContainer.ForeColor = System.Drawing.Color.Black
        Me.chkKeepContainer.Location = New System.Drawing.Point(39, 55)
        Me.chkKeepContainer.Name = "chkKeepContainer"
        Me.chkKeepContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkKeepContainer.Size = New System.Drawing.Size(131, 17)
        Me.chkKeepContainer.TabIndex = 17
        Me.chkKeepContainer.Text = "Conservar contenedor"
        Me.chkKeepContainer.UseVisualStyleBackColor = True
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Checked = True
        Me.chkCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCheck.ForeColor = System.Drawing.Color.Black
        Me.chkCheck.Location = New System.Drawing.Point(78, 106)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCheck.Size = New System.Drawing.Size(92, 17)
        Me.chkCheck.TabIndex = 15
        Me.chkCheck.Text = "Marcar Todos"
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'chkBoth
        '
        Me.chkBoth.AutoSize = True
        Me.chkBoth.Checked = True
        Me.chkBoth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoth.ForeColor = System.Drawing.Color.Black
        Me.chkBoth.Location = New System.Drawing.Point(79, 32)
        Me.chkBoth.Name = "chkBoth"
        Me.chkBoth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkBoth.Size = New System.Drawing.Size(91, 17)
        Me.chkBoth.TabIndex = 14
        Me.chkBoth.Text = "Uso y reserva"
        Me.chkBoth.UseVisualStyleBackColor = True
        '
        'btnRecalculate
        '
        Me.btnRecalculate.Image = CType(resources.GetObject("btnRecalculate.Image"), System.Drawing.Image)
        Me.btnRecalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecalculate.Location = New System.Drawing.Point(72, 3)
        Me.btnRecalculate.Name = "btnRecalculate"
        Me.btnRecalculate.Size = New System.Drawing.Size(100, 25)
        Me.btnRecalculate.TabIndex = 5
        Me.btnRecalculate.Text = "Recalcular"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(94, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Diferencia"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpdate
        '
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(72, 129)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(100, 25)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Actualizar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(98, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "No existe"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel2.Location = New System.Drawing.Point(155, 203)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(119, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Igual"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Crimson
        Me.Panel3.Location = New System.Drawing.Point(155, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Location = New System.Drawing.Point(155, 245)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 10
        '
        'Kanbans_dgv
        '
        Me.Kanbans_dgv.AllowColumnHiding = True
        Me.Kanbans_dgv.AllowUserToAddRows = False
        Me.Kanbans_dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        Me.Kanbans_dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Kanbans_dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Kanbans_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanbans_dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Kanbans_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Kanbans_dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kanban_ID_col, Me.Kanban_Code_col, Me.Kanban_Partnumber_col, Me.Kanban_Board_col, Me.Kanban_Kit_col, Me.Kanban_EngineeringLocation_col, Me.Kanban_Slot_col, Me.Kanban_Side_col, Me.Kanban_Section_col, Me.Kanban_Route_col, Me.Kanban_SupermarketLocation_col, Me.Kanban_Container_col, Me.Kanban_Pieces_col, Me.Kanban_Index_col, Me.Kanban_Date_col, Me.Kanban_Comment_col, Me.Kanban_NewRoute_col, Me.Kanban_NewSupermarketLocation_col, Me.Kanban_NewContainer_col, Me.Kanban_NewPieces_col, Me.Kanban_Update_chk})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kanbans_dgv.DefaultCellStyle = DataGridViewCellStyle17
        Me.Kanbans_dgv.DefaultRowFilter = Nothing
        Me.Kanbans_dgv.EnableHeadersVisualStyles = False
        Me.Kanbans_dgv.Location = New System.Drawing.Point(189, 31)
        Me.Kanbans_dgv.Name = "Kanbans_dgv"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanbans_dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.Kanbans_dgv.ShowRowNumber = True
        Me.Kanbans_dgv.Size = New System.Drawing.Size(1364, 727)
        Me.Kanbans_dgv.TabIndex = 119
        '
        'Kanban_ID_col
        '
        Me.Kanban_ID_col.Frozen = True
        Me.Kanban_ID_col.HeaderText = "ID"
        Me.Kanban_ID_col.Name = "Kanban_ID_col"
        Me.Kanban_ID_col.Visible = False
        Me.Kanban_ID_col.Width = 50
        '
        'Kanban_Code_col
        '
        Me.Kanban_Code_col.Frozen = True
        Me.Kanban_Code_col.HeaderText = "Codigo"
        Me.Kanban_Code_col.Name = "Kanban_Code_col"
        Me.Kanban_Code_col.ReadOnly = True
        Me.Kanban_Code_col.Width = 60
        '
        'Kanban_Partnumber_col
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_Partnumber_col.DefaultCellStyle = DataGridViewCellStyle3
        Me.Kanban_Partnumber_col.HeaderText = "No. de Parte"
        Me.Kanban_Partnumber_col.Name = "Kanban_Partnumber_col"
        Me.Kanban_Partnumber_col.ReadOnly = True
        Me.Kanban_Partnumber_col.Width = 70
        '
        'Kanban_Board_col
        '
        Me.Kanban_Board_col.HeaderText = "Tablero"
        Me.Kanban_Board_col.Name = "Kanban_Board_col"
        Me.Kanban_Board_col.ReadOnly = True
        Me.Kanban_Board_col.Width = 70
        '
        'Kanban_Kit_col
        '
        Me.Kanban_Kit_col.HeaderText = "Kit"
        Me.Kanban_Kit_col.Name = "Kanban_Kit_col"
        Me.Kanban_Kit_col.Width = 60
        '
        'Kanban_EngineeringLocation_col
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_EngineeringLocation_col.DefaultCellStyle = DataGridViewCellStyle4
        Me.Kanban_EngineeringLocation_col.HeaderText = "Local Ing."
        Me.Kanban_EngineeringLocation_col.Name = "Kanban_EngineeringLocation_col"
        Me.Kanban_EngineeringLocation_col.Width = 60
        '
        'Kanban_Slot_col
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_Slot_col.DefaultCellStyle = DataGridViewCellStyle5
        Me.Kanban_Slot_col.HeaderText = "Slot"
        Me.Kanban_Slot_col.Name = "Kanban_Slot_col"
        Me.Kanban_Slot_col.Width = 50
        '
        'Kanban_Side_col
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_Side_col.DefaultCellStyle = DataGridViewCellStyle6
        Me.Kanban_Side_col.HeaderText = "Lado"
        Me.Kanban_Side_col.Name = "Kanban_Side_col"
        Me.Kanban_Side_col.Width = 50
        '
        'Kanban_Section_col
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_Section_col.DefaultCellStyle = DataGridViewCellStyle7
        Me.Kanban_Section_col.HeaderText = "Sección"
        Me.Kanban_Section_col.Name = "Kanban_Section_col"
        Me.Kanban_Section_col.Width = 50
        '
        'Kanban_Route_col
        '
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanban_Route_col.DefaultCellStyle = DataGridViewCellStyle8
        Me.Kanban_Route_col.HeaderText = "Ruta"
        Me.Kanban_Route_col.Name = "Kanban_Route_col"
        Me.Kanban_Route_col.ReadOnly = True
        Me.Kanban_Route_col.Width = 90
        '
        'Kanban_SupermarketLocation_col
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Kanban_SupermarketLocation_col.DefaultCellStyle = DataGridViewCellStyle9
        Me.Kanban_SupermarketLocation_col.HeaderText = "Local Smk"
        Me.Kanban_SupermarketLocation_col.Name = "Kanban_SupermarketLocation_col"
        Me.Kanban_SupermarketLocation_col.ReadOnly = True
        Me.Kanban_SupermarketLocation_col.Width = 60
        '
        'Kanban_Container_col
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_Container_col.DefaultCellStyle = DataGridViewCellStyle10
        Me.Kanban_Container_col.HeaderText = "Contdr."
        Me.Kanban_Container_col.Name = "Kanban_Container_col"
        Me.Kanban_Container_col.ReadOnly = True
        Me.Kanban_Container_col.Width = 50
        '
        'Kanban_Pieces_col
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N0"
        Me.Kanban_Pieces_col.DefaultCellStyle = DataGridViewCellStyle11
        Me.Kanban_Pieces_col.HeaderText = "Piezas"
        Me.Kanban_Pieces_col.Name = "Kanban_Pieces_col"
        Me.Kanban_Pieces_col.ReadOnly = True
        Me.Kanban_Pieces_col.Width = 50
        '
        'Kanban_Index_col
        '
        Me.Kanban_Index_col.HeaderText = "Tarjeta"
        Me.Kanban_Index_col.Name = "Kanban_Index_col"
        Me.Kanban_Index_col.ReadOnly = True
        Me.Kanban_Index_col.Width = 50
        '
        'Kanban_Date_col
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "d"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.Kanban_Date_col.DefaultCellStyle = DataGridViewCellStyle12
        Me.Kanban_Date_col.HeaderText = "Fecha"
        Me.Kanban_Date_col.Name = "Kanban_Date_col"
        Me.Kanban_Date_col.ReadOnly = True
        Me.Kanban_Date_col.Width = 70
        '
        'Kanban_Comment_col
        '
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanban_Comment_col.DefaultCellStyle = DataGridViewCellStyle13
        Me.Kanban_Comment_col.HeaderText = "Comentario"
        Me.Kanban_Comment_col.Name = "Kanban_Comment_col"
        Me.Kanban_Comment_col.Width = 110
        '
        'Kanban_NewRoute_col
        '
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanban_NewRoute_col.DefaultCellStyle = DataGridViewCellStyle14
        Me.Kanban_NewRoute_col.HeaderText = "Recal. Ruta"
        Me.Kanban_NewRoute_col.Name = "Kanban_NewRoute_col"
        Me.Kanban_NewRoute_col.Visible = False
        Me.Kanban_NewRoute_col.Width = 90
        '
        'Kanban_NewSupermarketLocation_col
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Kanban_NewSupermarketLocation_col.DefaultCellStyle = DataGridViewCellStyle15
        Me.Kanban_NewSupermarketLocation_col.HeaderText = "Recal. Local Smk"
        Me.Kanban_NewSupermarketLocation_col.Name = "Kanban_NewSupermarketLocation_col"
        Me.Kanban_NewSupermarketLocation_col.ReadOnly = True
        Me.Kanban_NewSupermarketLocation_col.Visible = False
        Me.Kanban_NewSupermarketLocation_col.Width = 70
        '
        'Kanban_NewContainer_col
        '
        Me.Kanban_NewContainer_col.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Kanban_NewContainer_col.HeaderText = "Recal. Contdr."
        Me.Kanban_NewContainer_col.Items.AddRange(New Object() {"1/4", "1/2", "16s", "8s", "4s", "2s", "JT", "StdPack"})
        Me.Kanban_NewContainer_col.Name = "Kanban_NewContainer_col"
        Me.Kanban_NewContainer_col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kanban_NewContainer_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Kanban_NewContainer_col.Visible = False
        Me.Kanban_NewContainer_col.Width = 60
        '
        'Kanban_NewPieces_col
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        Me.Kanban_NewPieces_col.DefaultCellStyle = DataGridViewCellStyle16
        Me.Kanban_NewPieces_col.HeaderText = "Recal. Piezas"
        Me.Kanban_NewPieces_col.Name = "Kanban_NewPieces_col"
        Me.Kanban_NewPieces_col.ReadOnly = True
        Me.Kanban_NewPieces_col.Visible = False
        Me.Kanban_NewPieces_col.Width = 60
        '
        'Kanban_Update_chk
        '
        Me.Kanban_Update_chk.HeaderText = "Actualizar"
        Me.Kanban_Update_chk.Name = "Kanban_Update_chk"
        Me.Kanban_Update_chk.Visible = False
        Me.Kanban_Update_chk.Width = 70
        '
        'CDR_KanbansManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1558, 763)
        Me.Controls.Add(Me.Kanbans_dgv)
        Me.Controls.Add(Me.pnlRecalculate)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label7)
        Me.Name = "CDR_KanbansManagement"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        Me.Panel6.ResumeLayout(False)
        Me.pnlRecalculate.ResumeLayout(False)
        Me.pnlRecalculate.PerformLayout()
        CType(Me.Kanbans_dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBusiness As System.Windows.Forms.ComboBox
    Friend WithEvents Delete_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBoard As System.Windows.Forms.ComboBox
    Friend WithEvents Show_btn As System.Windows.Forms.Button
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents pnlRecalculate As System.Windows.Forms.Panel
    Friend WithEvents chkKeepContainer As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkBoth As System.Windows.Forms.CheckBox
    Friend WithEvents btnRecalculate As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Kanbans_dgv As CAguilar.DataGridViewWithFilters
    Friend WithEvents Kanban_ID_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Code_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Partnumber_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Board_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Kit_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_EngineeringLocation_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Slot_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Side_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Section_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Route_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_SupermarketLocation_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Container_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Pieces_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Index_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Date_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Comment_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_NewRoute_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_NewSupermarketLocation_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_NewContainer_col As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Kanban_NewPieces_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kanban_Update_chk As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
