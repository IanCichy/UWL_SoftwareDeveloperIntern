using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices; //needed for eagle authentication

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
        if (!HttpContext.Current.Request.IsSecureConnection && !HttpContext.Current.Request.Url.ToString().Contains("http://localhost"))
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

    public static string EncryptString(string Message, string Passphrase)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

        // Step 1. We hash the passphrase using MD5
        // We use the MD5 hash generator as the result is a 128 bit byte array
        // which is a valid length for the TripleDES encoder we use below

        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

        // Step 2. Create a new TripleDESCryptoServiceProvider object
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

        // Step 3. Setup the encoder
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;

        // Step 4. Convert the input string to a byte[]
        byte[] DataToEncrypt = UTF8.GetBytes(Message);

        // Step 5. Attempt to encrypt the string
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            // Clear the TripleDes and Hashprovider services of any sensitive information
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }

        // Step 6. Return the encrypted string as a base64 encoded string
        return Convert.ToBase64String(Results);
    }

    /// <summary>
    /// REQUIRED FOR EAGLE AUTHENTICATION - DO NOT REMOVE
    /// </summary>
    [DllImport("advapi32.dll")]
    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

    /// <summary>
    /// Checks whether or not a user is authenticated via the eagle domain
    /// </summary>
    /// <param name="username">NetID (8.4)</param>
    /// <param name="password">User password</param>
    /// <returns>True if user successfully logs in to the domain</returns>
    public static bool AuthenticateEagle(string username, string password)
    {
        System.IntPtr hToken;
        if (LogonUser(username, "eagle", password, 3, 0, out hToken)) return true;
        else return false;
    }

    /// <summary>
    /// Generates a random token.
    /// </summary>
    /// <returns>The random token</returns>
    public static string GenerateToken(string connectionString)
    {
        var token = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, "SELECT NEWID()");
        return token.ToString();
    }
}
