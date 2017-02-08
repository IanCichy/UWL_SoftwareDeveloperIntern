using Rlis.Sql;
using System;
using System.Data;
using System.Web.UI;

public partial class wiaa_addschool : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(1))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            txtComments.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Notes FROM WiaaConfig WHERE Year = " + Settings.Year + "").ToString();
        }
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Notes = '" + txtComments.Text.Replace("'", "''") + "' WHERE Year = '" + Settings.Year.ToString() + "'");
        Security.ShowAlertMessage("Comment updated!");
    }
}