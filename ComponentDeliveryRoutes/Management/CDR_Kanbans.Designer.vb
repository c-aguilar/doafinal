<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDR_Kanbans
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDR_Kanbans))
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.kan_chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.kan_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_partnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_board = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_kit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_engloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_slot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_side = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_section = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_route = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_container = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.kan_pieces = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_business = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_requirement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_2h = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_frequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_hrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.btnRecalculate = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBoard = New System.Windows.Forms.ComboBox()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.dgvActual = New System.Windows.Forms.DataGridView()
        Me.kan_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_codea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_partnumbera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_descriptiona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_racka = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_locala = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_boarda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_kita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_engloca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_slota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_sidea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_sectiona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_routea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_containera = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.kan_piecesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_indexa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_businessa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_requirementa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_quantitya = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_2hrsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_frequencya = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_hrsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_commenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kan_updateda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.pnlRecalculate = New System.Windows.Forms.Panel()
        Me.chkKeepContainer = New System.Windows.Forms.CheckBox()
        Me.chkCheck = New System.Windows.Forms.CheckBox()
        Me.chkBoth = New System.Windows.Forms.CheckBox()
        Me.cmsActual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.dgvActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlRecalculate.SuspendLayout()
        Me.cmsActual.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kan_chk, Me.kan_code, Me.kan_partnumber, Me.kan_description, Me.kan_rack, Me.kan_local, Me.kan_board, Me.kan_kit, Me.kan_engloc, Me.kan_slot, Me.kan_side, Me.kan_section, Me.kan_route, Me.kan_container, Me.kan_pieces, Me.kan_index, Me.kan_business, Me.kan_requirement, Me.kan_quantity, Me.kan_2h, Me.kan_frequency, Me.kan_hrs})
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.Location = New System.Drawing.Point(191, 0)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.Size = New System.Drawing.Size(813, 345)
        Me.dgvResult.TabIndex = 3
        Me.dgvResult.Visible = False
        '
        'kan_chk
        '
        Me.kan_chk.HeaderText = "Actualizar"
        Me.kan_chk.Name = "kan_chk"
        '
        'kan_code
        '
        Me.kan_code.DataPropertyName = "Code"
        Me.kan_code.HeaderText = "ID"
        Me.kan_code.Name = "kan_code"
        Me.kan_code.ReadOnly = True
        '
        'kan_partnumber
        '
        Me.kan_partnumber.DataPropertyName = "Partnumber"
        Me.kan_partnumber.HeaderText = "Partnumber"
        Me.kan_partnumber.Name = "kan_partnumber"
        '
        'kan_description
        '
        Me.kan_description.DataPropertyName = "Description"
        Me.kan_description.HeaderText = "Descripcion"
        Me.kan_description.Name = "kan_description"
        '
        'kan_rack
        '
        Me.kan_rack.DataPropertyName = "Rack"
        Me.kan_rack.HeaderText = "Rack"
        Me.kan_rack.Name = "kan_rack"
        '
        'kan_local
        '
        Me.kan_local.DataPropertyName = "Local"
        Me.kan_local.HeaderText = "Localizacion"
        Me.kan_local.Name = "kan_local"
        Me.kan_local.ReadOnly = True
        '
        'kan_board
        '
        Me.kan_board.DataPropertyName = "Board"
        Me.kan_board.HeaderText = "Tablero"
        Me.kan_board.Name = "kan_board"
        '
        'kan_kit
        '
        Me.kan_kit.DataPropertyName = "Kit"
        Me.kan_kit.HeaderText = "Kit"
        Me.kan_kit.Name = "kan_kit"
        '
        'kan_engloc
        '
        Me.kan_engloc.DataPropertyName = "EngLoc"
        Me.kan_engloc.HeaderText = "EngLoc"
        Me.kan_engloc.Name = "kan_engloc"
        '
        'kan_slot
        '
        Me.kan_slot.DataPropertyName = "Slot"
        Me.kan_slot.HeaderText = "Slot"
        Me.kan_slot.Name = "kan_slot"
        Me.kan_slot.ReadOnly = True
        '
        'kan_side
        '
        Me.kan_side.DataPropertyName = "Side"
        Me.kan_side.HeaderText = "Lado"
        Me.kan_side.Name = "kan_side"
        Me.kan_side.ReadOnly = True
        '
        'kan_section
        '
        Me.kan_section.DataPropertyName = "Section"
        Me.kan_section.HeaderText = "Seccion"
        Me.kan_section.Name = "kan_section"
        Me.kan_section.ReadOnly = True
        '
        'kan_route
        '
        Me.kan_route.DataPropertyName = "Route"
        Me.kan_route.HeaderText = "Ruta"
        Me.kan_route.Name = "kan_route"
        Me.kan_route.ReadOnly = True
        '
        'kan_container
        '
        Me.kan_container.DataPropertyName = "Container"
        Me.kan_container.HeaderText = "Contenedor"
        Me.kan_container.Items.AddRange(New Object() {"1/4", "1/2", "16S", "8S", "4S", "2S", "JT", "STDPACK"})
        Me.kan_container.Name = "kan_container"
        '
        'kan_pieces
        '
        Me.kan_pieces.DataPropertyName = "Pieces"
        Me.kan_pieces.HeaderText = "Piezas"
        Me.kan_pieces.Name = "kan_pieces"
        Me.kan_pieces.ReadOnly = True
        '
        'kan_index
        '
        Me.kan_index.DataPropertyName = "Index"
        Me.kan_index.HeaderText = "Tarjeta"
        Me.kan_index.Name = "kan_index"
        Me.kan_index.ReadOnly = True
        '
        'kan_business
        '
        Me.kan_business.DataPropertyName = "Business"
        Me.kan_business.HeaderText = "Negocio"
        Me.kan_business.Name = "kan_business"
        Me.kan_business.ReadOnly = True
        '
        'kan_requirement
        '
        Me.kan_requirement.DataPropertyName = "Requirement"
        Me.kan_requirement.HeaderText = "Requerimiento"
        Me.kan_requirement.Name = "kan_requirement"
        Me.kan_requirement.ReadOnly = True
        '
        'kan_quantity
        '
        Me.kan_quantity.DataPropertyName = "Quantity"
        Me.kan_quantity.HeaderText = "Cantidad"
        Me.kan_quantity.Name = "kan_quantity"
        Me.kan_quantity.ReadOnly = True
        '
        'kan_2h
        '
        Me.kan_2h.DataPropertyName = "2h"
        Me.kan_2h.HeaderText = "2Hras"
        Me.kan_2h.Name = "kan_2h"
        Me.kan_2h.ReadOnly = True
        '
        'kan_frequency
        '
        Me.kan_frequency.DataPropertyName = "Frequency"
        Me.kan_frequency.HeaderText = "Frecuencia"
        Me.kan_frequency.Name = "kan_frequency"
        Me.kan_frequency.ReadOnly = True
        '
        'kan_hrs
        '
        Me.kan_hrs.DataPropertyName = "Hrs"
        Me.kan_hrs.HeaderText = "Horas"
        Me.kan_hrs.Name = "kan_hrs"
        Me.kan_hrs.ReadOnly = True
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
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Location = New System.Drawing.Point(155, 245)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Crimson
        Me.Panel3.Location = New System.Drawing.Point(155, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel2.Location = New System.Drawing.Point(155, 203)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 7
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShow.Location = New System.Drawing.Point(71, 92)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(100, 25)
        Me.btnShow.TabIndex = 6
        Me.btnShow.Text = "Mostrar"
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
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(71, 121)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 26)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Guardar"
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
        'SplitContainer
        '
        Me.SplitContainer.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.dgvActual)
        Me.SplitContainer.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.dgvResult)
        Me.SplitContainer.Panel2.Controls.Add(Me.Panel7)
        Me.SplitContainer.Size = New System.Drawing.Size(1008, 705)
        Me.SplitContainer.SplitterDistance = 352
        Me.SplitContainer.TabIndex = 4
        '
        'dgvActual
        '
        Me.dgvActual.AllowUserToAddRows = False
        Me.dgvActual.AllowUserToDeleteRows = False
        Me.dgvActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kan_ID, Me.kan_codea, Me.kan_partnumbera, Me.kan_descriptiona, Me.kan_racka, Me.kan_locala, Me.kan_boarda, Me.kan_kita, Me.kan_engloca, Me.kan_slota, Me.kan_sidea, Me.kan_sectiona, Me.kan_routea, Me.kan_containera, Me.kan_piecesa, Me.kan_indexa, Me.kan_businessa, Me.kan_requirementa, Me.kan_quantitya, Me.kan_2hrsa, Me.kan_frequencya, Me.kan_hrsa, Me.kan_commenta, Me.kan_updateda})
        Me.dgvActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvActual.Location = New System.Drawing.Point(191, 0)
        Me.dgvActual.Name = "dgvActual"
        Me.dgvActual.Size = New System.Drawing.Size(813, 348)
        Me.dgvActual.TabIndex = 4
        '
        'kan_ID
        '
        Me.kan_ID.HeaderText = "Identity"
        Me.kan_ID.Name = "kan_ID"
        Me.kan_ID.ReadOnly = True
        Me.kan_ID.Visible = False
        '
        'kan_codea
        '
        Me.kan_codea.DataPropertyName = "ID"
        Me.kan_codea.HeaderText = "ID"
        Me.kan_codea.Name = "kan_codea"
        '
        'kan_partnumbera
        '
        Me.kan_partnumbera.DataPropertyName = "Partnumber"
        Me.kan_partnumbera.HeaderText = "Partnumber"
        Me.kan_partnumbera.Name = "kan_partnumbera"
        '
        'kan_descriptiona
        '
        Me.kan_descriptiona.DataPropertyName = "Description"
        Me.kan_descriptiona.HeaderText = "Descripcion"
        Me.kan_descriptiona.Name = "kan_descriptiona"
        '
        'kan_racka
        '
        Me.kan_racka.DataPropertyName = "Rack"
        Me.kan_racka.HeaderText = "Rack"
        Me.kan_racka.Name = "kan_racka"
        '
        'kan_locala
        '
        Me.kan_locala.DataPropertyName = "Local"
        Me.kan_locala.HeaderText = "Localizacion"
        Me.kan_locala.Name = "kan_locala"
        '
        'kan_boarda
        '
        Me.kan_boarda.DataPropertyName = "Board"
        Me.kan_boarda.HeaderText = "Tablero"
        Me.kan_boarda.Name = "kan_boarda"
        Me.kan_boarda.ReadOnly = True
        '
        'kan_kita
        '
        Me.kan_kita.DataPropertyName = "Kit"
        Me.kan_kita.HeaderText = "Kit"
        Me.kan_kita.Name = "kan_kita"
        '
        'kan_engloca
        '
        Me.kan_engloca.DataPropertyName = "EngLoc"
        Me.kan_engloca.HeaderText = "No"
        Me.kan_engloca.Name = "kan_engloca"
        '
        'kan_slota
        '
        Me.kan_slota.DataPropertyName = "Slot"
        Me.kan_slota.HeaderText = "Slot"
        Me.kan_slota.Name = "kan_slota"
        '
        'kan_sidea
        '
        Me.kan_sidea.DataPropertyName = "Side"
        Me.kan_sidea.HeaderText = "Lado"
        Me.kan_sidea.Name = "kan_sidea"
        '
        'kan_sectiona
        '
        Me.kan_sectiona.DataPropertyName = "Section"
        Me.kan_sectiona.HeaderText = "Seccion"
        Me.kan_sectiona.Name = "kan_sectiona"
        '
        'kan_routea
        '
        Me.kan_routea.DataPropertyName = "Route"
        Me.kan_routea.HeaderText = "Ruta"
        Me.kan_routea.Name = "kan_routea"
        Me.kan_routea.ReadOnly = True
        '
        'kan_containera
        '
        Me.kan_containera.DataPropertyName = "Container"
        Me.kan_containera.HeaderText = "Contenedor"
        Me.kan_containera.Items.AddRange(New Object() {"1/4", "1/2", "16S", "8S", "4S", "2S", "JT", "STDPACK"})
        Me.kan_containera.Name = "kan_containera"
        '
        'kan_piecesa
        '
        Me.kan_piecesa.DataPropertyName = "Pieces"
        Me.kan_piecesa.HeaderText = "Piezas"
        Me.kan_piecesa.Name = "kan_piecesa"
        Me.kan_piecesa.ReadOnly = True
        '
        'kan_indexa
        '
        Me.kan_indexa.DataPropertyName = "Index"
        Me.kan_indexa.HeaderText = "Tarjeta"
        Me.kan_indexa.Name = "kan_indexa"
        Me.kan_indexa.ReadOnly = True
        '
        'kan_businessa
        '
        Me.kan_businessa.DataPropertyName = "Business"
        Me.kan_businessa.HeaderText = "Negocio"
        Me.kan_businessa.Name = "kan_businessa"
        Me.kan_businessa.ReadOnly = True
        '
        'kan_requirementa
        '
        Me.kan_requirementa.DataPropertyName = "Requirement"
        Me.kan_requirementa.HeaderText = "Requerimiento"
        Me.kan_requirementa.Name = "kan_requirementa"
        Me.kan_requirementa.ReadOnly = True
        '
        'kan_quantitya
        '
        Me.kan_quantitya.DataPropertyName = "Quantity"
        Me.kan_quantitya.HeaderText = "Cantidad"
        Me.kan_quantitya.Name = "kan_quantitya"
        Me.kan_quantitya.ReadOnly = True
        '
        'kan_2hrsa
        '
        Me.kan_2hrsa.DataPropertyName = "2h"
        Me.kan_2hrsa.HeaderText = "2Hras"
        Me.kan_2hrsa.Name = "kan_2hrsa"
        Me.kan_2hrsa.ReadOnly = True
        '
        'kan_frequencya
        '
        Me.kan_frequencya.DataPropertyName = "Frequency"
        Me.kan_frequencya.HeaderText = "Frecuencia"
        Me.kan_frequencya.Name = "kan_frequencya"
        Me.kan_frequencya.ReadOnly = True
        '
        'kan_hrsa
        '
        Me.kan_hrsa.HeaderText = "Horas"
        Me.kan_hrsa.Name = "kan_hrsa"
        Me.kan_hrsa.ReadOnly = True
        '
        'kan_commenta
        '
        Me.kan_commenta.DataPropertyName = "Hrs"
        Me.kan_commenta.HeaderText = "Comentario"
        Me.kan_commenta.Name = "kan_commenta"
        '
        'kan_updateda
        '
        Me.kan_updateda.DataPropertyName = "Date"
        Me.kan_updateda.HeaderText = "Updated"
        Me.kan_updateda.Name = "kan_updateda"
        Me.kan_updateda.ReadOnly = True
        Me.kan_updateda.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(191, 348)
        Me.Panel4.TabIndex = 5
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.btnFind)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.cboBusiness)
        Me.Panel6.Controls.Add(Me.btnDelete)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.cboBoard)
        Me.Panel6.Controls.Add(Me.btnShow)
        Me.Panel6.Controls.Add(Me.btnSave)
        Me.Panel6.Location = New System.Drawing.Point(6, 7)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(178, 219)
        Me.Panel6.TabIndex = 15
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(71, 185)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(100, 25)
        Me.btnFind.TabIndex = 16
        Me.btnFind.Text = "Buscar"
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
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(71, 153)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 26)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Eliminar"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.pnlRecalculate)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(191, 345)
        Me.Panel7.TabIndex = 4
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
        Me.pnlRecalculate.Location = New System.Drawing.Point(5, 6)
        Me.pnlRecalculate.Name = "pnlRecalculate"
        Me.pnlRecalculate.Size = New System.Drawing.Size(178, 270)
        Me.pnlRecalculate.TabIndex = 14
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
        'cmsActual
        '
        Me.cmsActual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.HistorialToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmsActual.Name = "cmsActual"
        Me.cmsActual.Size = New System.Drawing.Size(121, 70)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'HistorialToolStripMenuItem
        '
        Me.HistorialToolStripMenuItem.Name = "HistorialToolStripMenuItem"
        Me.HistorialToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.HistorialToolStripMenuItem.Text = "Historial"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1008, 25)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Generacion de Kanbans"
        '
        'CDR_Kanbans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CDR_Kanbans"
        Me.ShowIcon = False
        Me.Text = "Component Delivery Routes"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.dgvActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.pnlRecalculate.ResumeLayout(False)
        Me.pnlRecalculate.PerformLayout()
        Me.cmsActual.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBoard As System.Windows.Forms.ComboBox
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents btnRecalculate As System.Windows.Forms.Button
    Private WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvActual As System.Windows.Forms.DataGridView
    Friend WithEvents cmsActual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistorialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents pnlRecalculate As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents chkBoth As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBusiness As System.Windows.Forms.ComboBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkKeepContainer As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents kan_chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents kan_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_partnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_board As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_kit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_engloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_slot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_side As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_section As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_route As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_container As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents kan_pieces As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_business As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_requirement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_2h As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_frequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_hrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_codea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_partnumbera As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_descriptiona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_racka As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_locala As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_boarda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_kita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_engloca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_slota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_sidea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_sectiona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_routea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_containera As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents kan_piecesa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_indexa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_businessa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_requirementa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_quantitya As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_2hrsa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_frequencya As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_hrsa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_commenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kan_updateda As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
