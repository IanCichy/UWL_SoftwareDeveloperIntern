using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChooseHall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string username = ((UserData)Session["UserInfo"]).userName.ToString();
            ddlHall.DataSource = DeskDA.getAllHallsForUser(username);
            ddlHall.DataTextField = "Key";
            ddlHall.DataValueField = "Value";
            ddlHall.DataBind();
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        UserData data = (UserData)Session["UserInfo"];
        data.hallID = ddlHall.SelectedItem.Value;
        Response.Redirect("Administrator.aspx?hallid=" + ddlHall.SelectedItem.Value);
    }
}