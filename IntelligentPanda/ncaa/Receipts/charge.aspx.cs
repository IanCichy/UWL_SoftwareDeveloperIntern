using System;

public partial class ncaa_Receipts_charge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NCAAPDF pdf = new NCAAPDF();
        pdf.createChargePDF();
    }
}