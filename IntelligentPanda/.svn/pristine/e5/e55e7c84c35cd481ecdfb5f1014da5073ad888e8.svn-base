using System;

public partial class Account_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Security.UseSecure();

        try
        {
            string logout = Request.Params["logout"].ToString();
            if (logout == "true")
            {
                Account.Logout();
            }
        }
        catch { }
    }

    /// <summary>
    /// Logs a user in if they are found in the Login table
    /// </summary>
    protected void loginbutton_Click(object sender, EventArgs e)
    {
        if (Security.AuthenticateEagle(username.Text, password.Text) == true)
        {
            Account.Login(username.Text);
        }
        else
        {
            Security.ShowAlertMessage("Invalid Credentials");
        }
    }
}