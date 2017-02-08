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

public partial class SchoolList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet schoolHallAssign = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, ExpectedArrival, HallAssignment From SchoolList ORDER BY SchoolName");
            hallAssignGrid.DataSource = schoolHallAssign;
            hallAssignGrid.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Security.AuthenticateEagle(txtLogin.Text, txtPassword.Text) == true)
        {
            int count = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT count(*) from Users WHERE Username = '" + txtLogin.Text + "'").ToString());
            if (count != 0)
            {
                DataSet schoolHallAssign = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT * From SchoolList ORDER BY SchoolName");
                hallAssignGrid.DataSource = schoolHallAssign;
                hallAssignGrid.DataBind();
            }
            else
            {
                Security.ShowAlertMessage("Invalid Credentials");
            }
        }
        else
        {
            Security.ShowAlertMessage("Invalid Credentials");
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=SchoolList2013.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        hallAssignGrid.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}
