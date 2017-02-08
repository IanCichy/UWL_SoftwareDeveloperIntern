using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((String)Session["uType"] != "Admin")
            Response.Redirect("index.aspx");

        ftbHomePage.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Home FROM WiaaConfig").ToString();
        ftbFood.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Food FROM WiaaConfig").ToString();
        ftbParking.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Parking FROM WiaaConfig").ToString();
        ftbHousing.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Housing FROM WiaaConfig").ToString();
        ftbLogin.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Login FROM WiaaConfig").ToString();
    }

    protected void btnSaveConfig_Click(object sender, EventArgs e)
    {

        string homePage = ftbHomePage.ViewStateText;
        string foodPage = ftbFood.ViewStateText;
        string parkingPage = ftbParking.ViewStateText;
        string housingPage = ftbHousing.ViewStateText;
        string loginPage = ftbLogin.ViewStateText;
        if (homePage != null)
        {
            homePage.Replace("'", @"\'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Home = '" + homePage + "' WHERE Year = " + Settings.Year + "");
        }
        if (foodPage != null)
        {
            foodPage.Replace("'", @"\'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Food = '" + foodPage+ "' WHERE Year = " + Settings.Year + "");
        }
        if (parkingPage != null)
        {
            parkingPage.Replace("'", @"\'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Parking = '" + parkingPage + "' WHERE Year = " + Settings.Year + "");
        }
        if (housingPage != null)
        {
            housingPage.Replace("'", @"\'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Housing = '" + housingPage + "' WHERE Year = " + Settings.Year + "");
        }
        if (loginPage != null)
        {
            loginPage.Replace("'", @"\'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaConfig SET Login = '" + loginPage + "' WHERE Year = " + Settings.Year + "");
        }
        Response.Redirect("config.aspx");
    }
}