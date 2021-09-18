<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDFViewer
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
        Me.wbMain = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbMain
        '
        Me.wbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbMain.Location = New System.Drawing.Point(0, 0)
        Me.wbMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMain.Name = "wbMain"
        Me.wbMain.Size = New System.Drawing.Size(881, 608)
        Me.wbMain.TabIndex = 0
        '
        'PDFViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 608)
        Me.Controls.Add(Me.wbMain)
        Me.Name = "PDFViewer"
        Me.ShowIcon = False
        Me.Text = "Delta PDF Viewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbMain As System.Windows.Forms.WebBrowser
End Class
