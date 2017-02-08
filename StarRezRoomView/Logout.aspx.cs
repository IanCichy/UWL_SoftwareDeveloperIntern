using System;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["success"] = "Successfully logged out.";
        Response.Redirect("login.aspx");
    }
}