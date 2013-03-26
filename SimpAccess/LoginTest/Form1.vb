Public Class Form1

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim lgIn As New SimpAccess.FormLogin
        lgIn.ShowDialog()
        lblSucess.Text = lgIn.LoginSucceeded.ToString
    End Sub
End Class
