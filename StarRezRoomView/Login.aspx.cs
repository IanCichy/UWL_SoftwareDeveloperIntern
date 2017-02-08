using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_OnClick(object sender, EventArgs e)
    {
        
        // If the employee's credentials are invalid, show an error and do not log in.
        if (!Data.IsValidCredentials(txtUsername.Text, txtPassword.Text))
        {
            Response.Redirect("login.aspx");
            return;
        }


    }
}