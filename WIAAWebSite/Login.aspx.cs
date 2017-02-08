using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Security.UseSecure();
        DateTime regBegin = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegBegin FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");
        DateTime regEnd = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegEnd FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");

        // Set text on Login page
        divLogin.InnerHtml = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Login from WiaaConfig WHERE Year = '" + Settings.Year + "'").ToString();
     
        // If registration isn't open, don't display the create reservation option, or the log in option.
        if (!Settings.isRegistrationOpen(regBegin))
        {
            btnNewRes.Visible = false;
            divCredentials.Visible = false;
            lblResStart.Text = "Reservations can be made from " + regBegin.ToString("MMMM dd") + "th at " + regBegin.ToString("h:mm tt") + " through " + regEnd.ToString("MMMM dd") + "st at " + regEnd.ToString("h:mm tt") + ".";
        }
            
        else
        {
            btnNewRes.Visible = true;
            divCredentials.Visible = true;
            lblResStart.Text = "New School Reservations are not accepted after " + regEnd.ToString("MMMM dd") + " at " + regEnd.ToString("h:mm tt") + ".";
        }

        if (Settings.isRegistrationOver(regEnd))
        {
            btnNewRes.Visible = false;
        }
    }

    /// <summary>
    /// Log in the user and redirect to viewapp.aspx
    /// </summary>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Account.Login(txtEmail.Text, txtPassword.Text);
    }

    /// <summary>
    /// Redirect to application.aspx to create a new reservation.
    /// </summary>
    protected void btnNewRes_Click(object sender, EventArgs e)
    {
        Response.Redirect("application.aspx");
    }
}