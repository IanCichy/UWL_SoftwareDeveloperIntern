using System;

public partial class wiaa_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.isAuthenticated())
        {
            Response.Redirect("~/Account/login.aspx");
        }

        try
        {
            string permission = Request.QueryString["permission"].ToString();
            error.Visible = true;
        }
        catch { }
    }
}