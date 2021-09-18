Public Class Profile


    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If User.Current.OnDomain Then
            lblUsername.Text = User.Current.Properties("sAMAccountName")
            lblName.Text = User.Current.Properties("name")
            lblEmail.Text = User.Current.Properties("mail")
            lblTitle.Text = User.Current.Properties("title")
            lblDepartment.Text = User.Current.Properties("department")
            lblCostcenter.Text = User.Current.Properties("costCenter")
            lblAddress.Text = User.Current.Properties("physicalDeliveryOfficeName")
        Else
            lblUsername.Text = User.Current.Username
            lblName.Text = User.Current.FullName
            lblEmail.Text = ""
            lblTitle.Text = ""
            lblDepartment.Text = ""
            lblCostcenter.Text = ""
            lblAddress.Text = ""
        End If

    End Sub

    Private Sub Profile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class