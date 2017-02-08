using System;

public partial class wiaa_Receipts_receipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PDF pdf = new PDF();
        pdf.createReceiptPDF();
    }
}