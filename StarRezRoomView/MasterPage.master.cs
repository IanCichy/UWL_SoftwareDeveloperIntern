using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void ShowMessages()
    {
        if (Session["username"] == null)
        {
            // If not already on login page, go to login page
            if (!Page.AppRelativeVirtualPath.Equals("~/login.aspx")) Response.Redirect("login.aspx");
        }
    }
}