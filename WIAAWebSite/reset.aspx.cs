using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class reset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the url parameters
        string email = Request.QueryString["email"].ToString();
        string token = Request.QueryString["token"].ToString();

        //Make sure the user actually exists, if not, redirect
        int rows = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT count(*) FROM PasswordReset WHERE Email = '" + email + "' and Token = '" + token + "'").ToString());
        if (rows < 1)
        {
            Response.Redirect("password.aspx");
        }

        txtEmail.Text = email;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Both password fields must match
        if (txtPassword.Text != txtPasswordConfirm.Text)
        {
            Security.ShowAlertMessage("Your passwords do not match!");
            return;
        }

        string password = Security.EncryptString(txtPassword.Text, Settings.PassPhrase);

        // Update the user's password
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET Password = '" + password + "' WHERE ContactEmail = '" + txtEmail.Text + "' AND Year = " + Settings.Year + "");
        Response.Redirect("login.aspx");
    }
}