using System;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] == null)
        {
            Response.Redirect("~/Account/login.aspx");
        }
        lblUser.Text = Session["Login"].ToString();
    }

    protected void btnSearchWiaa_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/search.aspx?db=wiaa&query=" + txtSearch.Text);
    }

    protected void btnSearchNcaa_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/search.aspx?db=ncaa&query=" + txtSearch.Text);
    }
}