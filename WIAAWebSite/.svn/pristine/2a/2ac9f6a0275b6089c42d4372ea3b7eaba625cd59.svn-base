using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class food : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        divFood.InnerHtml = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Food from WiaaConfig WHERE Year = '" + Settings.Year + "'").ToString();
    }
}
