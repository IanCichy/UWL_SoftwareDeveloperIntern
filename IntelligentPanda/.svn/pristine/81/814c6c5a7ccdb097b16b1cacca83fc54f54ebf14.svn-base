using Rlis.Sql;
using System.Data;
using System.Web;

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
    public static void Login(string username)
    {
        try
        {
            string user = SqlHelper.ExecuteScalar(Settings.PandaConnection, CommandType.Text, "SELECT Username FROM [Users] WHERE Username = '" + username + "'").ToString();
            HttpContext.Current.Session["Login"] = username;
        }
        catch
        {
            Security.ShowAlertMessage("You do not have permissions to access this page.");
            return;
        }

        HttpContext.Current.Response.Redirect("~/");
    }

    public static void Logout()
    {
        HttpContext.Current.Session["Login"] = null;
    }

    /// <summary>
    /// Checks if the current logged in user is an admin.
    /// </summary>
    /// <returns>true if user is an admin</returns>
    public static bool hasRights(int pid)
    {
        if (!isAuthenticated()) return false;
        string username = HttpContext.Current.Session["Login"].ToString();
        try
        {
            string user = SqlHelper.ExecuteScalar(Settings.PandaConnection, CommandType.Text, "SELECT Username FROM UserPermissions WHERE Pid = " + pid + " AND Username = '" + username + "'").ToString();
            return true;
        }
        catch
        {
            //Security.ShowAlertMessage("You do not have permissions to access this page.");
            return false;
        }
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