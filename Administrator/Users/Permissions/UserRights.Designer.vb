﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRights
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserRights))
        Me.UserRights_Username_cbo = New System.Windows.Forms.ComboBox()
        Me.dgvData = New CAguilar.DataGridViewWithFilters()
        Me.UserRights_Save_btn = New System.Windows.Forms.Button()
        Me.UserRights_Active_chk = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserRights_Username_cbo
        '
        Me.UserRights_Username_cbo.FormattingEnabled = True
        Me.UserRights_Username_cbo.Location = New System.Drawing.Point(72, 12)
        Me.UserRights_Username_cbo.Name = "UserRights_Username_cbo"
        Me.UserRights_Username_cbo.Size = New System.Drawing.Size(181, 21)
        Me.UserRights_Username_cbo.TabIndex = 0
        '
        'dgvData
        '
        Me.dgvData.AllowColumnHiding = True
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(12, 41)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.ShowRowNumber = True
        Me.dgvData.Size = New System.Drawing.Size(705, 552)
        Me.dgvData.TabIndex = 1
        '
        'UserRights_Save_btn
        '
        Me.UserRights_Save_btn.Image = CType(resources.GetObject("UserRights_Save_btn.Image"), System.Drawing.Image)
        Me.UserRights_Save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserRights_Save_btn.Location = New System.Drawing.Point(321, 12)
        Me.UserRights_Save_btn.Name = "UserRights_Save_btn"
        Me.UserRights_Save_btn.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.UserRights_Save_btn.Size = New System.Drawing.Size(98, 23)
        Me.UserRights_Save_btn.TabIndex = 2
        Me.UserRights_Save_btn.Text = "Save"
        Me.UserRights_Save_btn.UseVisualStyleBackColor = True
        '
        'UserRights_Active_chk
        '
        Me.UserRights_Active_chk.AutoSize = True
        Me.UserRights_Active_chk.Location = New System.Drawing.Point(259, 16)
        Me.UserRights_Active_chk.Name = "UserRights_Active_chk"
        Me.UserRights_Active_chk.Size = New System.Drawing.Size(56, 17)
        Me.UserRights_Active_chk.TabIndex = 3
        Me.UserRights_Active_chk.Text = "Active"
        Me.UserRights_Active_chk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Logon ID:"
        '
        'UserRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 605)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UserRights_Active_chk)
        Me.Controls.Add(Me.UserRights_Save_btn)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.UserRights_Username_cbo)
        Me.Name = "UserRights"
        Me.ShowIcon = False
        Me.Text = "Administrator"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserRights_Username_cbo As System.Windows.Forms.ComboBox
    Friend WithEvents dgvData As CAguilar.DataGridViewWithFilters
    Friend WithEvents UserRights_Save_btn As System.Windows.Forms.Button
    Friend WithEvents UserRights_Active_chk As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
