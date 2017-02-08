using System;
using System.Runtime.InteropServices;

public partial class Login : System.Web.UI.Page
{
    [DllImport("advapi32.dll")]

    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

    protected void Page_Load(object sender, EventArgs e)
    {
        Security.UseSecure();
        errordiv.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String userLevel = DeskDA.getUserAdminType(username.Text);
        String errorMessage = "";

        if (userLevel.Equals(""))
        {
            errorMessage = "You are not authorized to use this program.";
        }
        else
        {
            System.IntPtr hToken;
            if (LogonUser(username.Text, "eagle", password.Text, 3, 0, out hToken))
            {
                // Set session vars
                //if (username.Text.Equals("afiltz") || username.Text.Equals("slong") || username.Text.Equals("carlson.kayl") || username.Text.Equals("nzika"))
                //{
                //   userLevel = "ALL";
                //   Session["UserInfo"] = new UserData(username.Text, userLevel);
                //   Response.Redirect("DualAdmin.aspx");
                //}
                // else
                // {
                Session["UserInfo"] = new UserData(username.Text, userLevel);
                //Response.Redirect("Administrator.aspx?hallid=" + userLevel);
                Response.Redirect("ChooseHall.aspx");
                // }
            }
            else
            {
                errorMessage = "Invalid password, please try again.";
            }
        }

        errordiv.InnerHtml = errorMessage;
        errordiv.Visible = true;
    }
}