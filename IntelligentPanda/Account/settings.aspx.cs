using System;

public partial class Account_settings : System.Web.UI.Page
{
    private bool autoprint = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        autoprint = Settings.AutomaticallyPrintReceipts();
        chkAutoprint.Checked = autoprint;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Settings.SetAutomaticallyPrintReceipts(autoprint);
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void chkAutoprint_CheckedChanged(object sender, EventArgs e)
    {
        autoprint = !autoprint;
    }
}