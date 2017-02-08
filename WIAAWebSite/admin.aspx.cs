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

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void adminLogButton_Click(object sender, EventArgs e)
    {
        String adUser = userBox.Text;
        String adWord = adPwordBox.Text;
        if (Security.AuthenticateEagle(adUser, adWord) == true)
        {
            try
            {
                string user = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Username FROM [Users] WHERE Username = '" + adUser + "'").ToString();
                HttpContext.Current.Session["Login"] = adUser;
            }
            catch
            {
                Security.ShowAlertMessage("You do not have permissions to access this page.");
                return;
            }

            Session["uType"] = "Admin";
            Response.Redirect("config.aspx");
        }
        else
        {
            Security.ShowAlertMessage("Invalid Credentials");
        }
    }
}
