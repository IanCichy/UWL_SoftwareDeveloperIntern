using System;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

public partial class Stats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
    }
}