using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    /// <summary>
    /// Logs a user in redirects them to view their application.
    /// </summary>
    /// <param name="email">The email the user signed up with</param>
    /// <param name="password">The users password</param>
    public static void Login(string email, string password)
    {
        try
        {
            string hashedPassword = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Password] FROM WiaaSchoolReservations WHERE ContactEmail = '" + email + "' AND Year = " + Settings.Year + "").ToString();
            if (hashedPassword == Security.EncryptString(password, Settings.PassPhrase))
            {
                HttpContext.Current.Session["Login"] = email;
                HttpContext.Current.Response.Redirect("viewapp.aspx");
            }
        }
        catch { Security.ShowAlertMessage("Invalid credentials"); }
    }

    /// <summary>
    /// Makes sure a user is authenticated.
    /// </summary>
    /// <returns>true if the user is authenticated</returns>
    public static bool isAuthenticated()
    {
        if (HttpContext.Current.Session["Login"] != null) return true;

        return false;
    }
}