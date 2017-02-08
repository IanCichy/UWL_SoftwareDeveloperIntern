using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// This class has security related methods to making your web application more secure.
/// </summary>
public class Security
{
    /// <summary>
    /// Will use a secure connection if not localhost.
    /// </summary>
    public static void UseSecure()
    {
        if (!HttpContext.Current.Request.IsSecureConnection && !HttpContext.Current.Request.Url.ToString().Contains("localhost"))
        {
            string redirectUrl = HttpContext.Current.Request.Url.ToString().Replace("http:", "https:");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
    }

    /// <summary>
    /// Displays a popup message on screen.
    /// </summary>
    /// <param name="error">The message to display.</param>
    public static void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    /// <summary>
    /// Displays a message on screen if the session is getting close to timing out. Must call on page load.
    /// </summary>
    public static void CheckSessionTimeout()
    {
        String msgSession = "Warning SESSION TIMEOUT: Within next 3 minutes, if you stay on this page," +
                   " our system will redirect to the login page. Please save changed data.";
        //time to remind, 3 minutes before session ends
        int int_MilliSecondsTimeReminder = (HttpContext.Current.Session.Timeout * 60000) - 3 * 60000;
        //time to redirect, 5 milliseconds before session ends
        int int_MilliSecondsTimeOut = (HttpContext.Current.Session.Timeout * 60000) - 5;

        string str_Script = @"
            var myTimeReminder, myTimeOut; 
            clearTimeout(myTimeReminder); 
            clearTimeout(myTimeOut); " +
                "var sessionTimeReminder = " +
            int_MilliSecondsTimeReminder.ToString() + "; " +
                "var sessionTimeout = " + int_MilliSecondsTimeOut.ToString() + ";" +
                "function doReminder(){ alert('" + msgSession + "'); }" +
                "function doRedirect(){ window.location.href='Login.aspx'; }" + @"
            myTimeReminder=setTimeout('doReminder()', sessionTimeReminder); 
            myTimeOut=setTimeout('doRedirect()', sessionTimeout); ";
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(),
              "CheckSessionOut", str_Script, true);
    }
}
