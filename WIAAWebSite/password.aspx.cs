using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string token = Security.GenerateToken(Settings.WIAAConnection);
        Email.resetPassword(email, token);
        Security.ShowAlertMessage("Instructions to reset your password have been sent to the email you provided.");
    }
}