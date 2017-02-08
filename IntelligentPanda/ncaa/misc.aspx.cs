using Rlis.Sql;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ncaa_misc : System.Web.UI.Page
{
    private int year;
    /*This regular expression will match any dollar amount such as 23.50, $23.50, or even a negative -23.50*/
    private Regex currencyRegex = new Regex(@"^[+|-|\$]?[0-9]{1,3}(?:,?[0-9]{3})*\.[0-9]{2}$");
    /*This regular expression matches any number greater than or equal to one*/
    private Regex number = new Regex(@"[1-9]+");
    private double num, num2;
    private double chargeVal, chargeAmount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(2))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        DateTime currentDate = DateTime.Now;
        year = currentDate.Year;

        /*Only if the page isn't a post back, we load the volunteers and schools*/
        if (!Page.IsPostBack)
        {
            txtTotal.Text = "0.00";
            Common.populateNcaaSchoolDropDown(ddlReservation);
        }
    }

    protected void ddlChargeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChargeType.Text == "Other")
        {
            otherLabel.Visible = true;
            otherTextBox.Visible = true;
            dollarLabel.Visible = true;
            dollarTextBox.Visible = true;
        }
        else
        {
            otherLabel.Visible = false;
            otherTextBox.Visible = false;
            dollarLabel.Visible = false;
            dollarTextBox.Visible = false;
            otherTextBox.Text = "";
            dollarTextBox.Text = "";
        }
    }

    protected void ddlReservation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["NcaaReservation"] = new NcaaReservation(ddlReservation.SelectedValue);
    }

    protected void btnAddCharge_Click(object sender, EventArgs e)
    {
        /*Get the charge amount for a lost access card or a lost room key --- NOTE there are other charges in the database as well*/
        /*Take the substring of length-2 because pulling amount from database returns 4 decimal digits*/
        String lostCard = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT LostAccessCard FROM HousingCharges WHERE Year = " + year + "").ToString();
        lostCard = lostCard.Substring(0, lostCard.Length - 2);
        String lostKey = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT LostRoomKey FROM HousingCharges WHERE Year = " + year + "").ToString();
        lostKey = lostKey.Substring(0, lostKey.Length - 2);
        String blanket = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Blanket FROM HousingCharges WHERE Year = " + year + "").ToString();
        blanket = blanket.Substring(0, blanket.Length - 2);
        String sheet = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Sheet FROM HousingCharges WHERE Year = " + year + "").ToString();
        sheet = sheet.Substring(0, sheet.Length - 2);
        String pillow = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Pillow FROM HousingCharges WHERE Year = " + year + "").ToString();
        pillow = pillow.Substring(0, pillow.Length - 2);
        String pillowcase = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Pillowcase FROM HousingCharges WHERE Year = " + year + "").ToString();
        pillowcase = pillowcase.Substring(0, pillowcase.Length - 2);
        String towel = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Towel FROM HousingCharges WHERE Year = " + year + "").ToString();
        towel = towel.Substring(0, towel.Length - 2);
        String washcloth = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Washcloth FROM HousingCharges WHERE Year = " + year + "").ToString();
        washcloth = washcloth.Substring(0, washcloth.Length - 2);
        String screen = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT ScreenRemoval FROM HousingCharges WHERE Year = " + year + "").ToString();
        screen = screen.Substring(0, screen.Length - 2);
        String fan = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Fan FROM HousingCharges WHERE Year = " + year + "").ToString();
        fan = fan.Substring(0, fan.Length - 2);

        num = int.Parse(schoolNumberTextBox.Text);
        Match matchNumber = number.Match(schoolNumberTextBox.Text);
        if (matchNumber.Success)
        {
            num = int.Parse(schoolNumberTextBox.Text);
            if (ddlChargeType.Text == "Lost Access Card")
            {
                charge(lostCard);
            }
            else if (ddlChargeType.Text == "Lost Room Key")
            {
                charge(lostKey);
            }
            else if (ddlChargeType.Text == "Fan")
            {
                charge(fan);
            }
            else if (ddlChargeType.Text == "Blanket")
            {
                charge(blanket);
            }
            else if (ddlChargeType.Text == "Sheet")
            {
                charge(sheet);
            }
            else if (ddlChargeType.Text == "Pillow")
            {
                charge(pillow);
            }
            else if (ddlChargeType.Text == "Pillowcase")
            {
                charge(pillowcase);
            }
            else if (ddlChargeType.Text == "Towel")
            {
                charge(towel);
            }
            else if (ddlChargeType.Text == "Washcloth")
            {
                charge(washcloth);
            }
            else if (ddlChargeType.Text == "Screen Removal")
            {
                charge(screen);
            }
            else if (ddlChargeType.Text == "Other")
            {
                String amount = "(" + num.ToString() + ")";
                String dollarAmount = dollarTextBox.Text;
                /*Match the regular expression to the dollar amount to make sure the user is entering in money correctly*/
                Match m = currencyRegex.Match(dollarAmount);
                if (m.Success)
                {
                    /*trim leading dollar sign if user inputs one*/
                    if (dollarAmount.StartsWith("$"))
                    {
                        dollarAmount = dollarAmount.TrimStart('$');
                    }
                    double chargeAmount = num * double.Parse(dollarAmount);
                    double total = double.Parse(txtTotal.Text) + chargeAmount;
                    txtTotal.Text = total.ToString("N2");
                    checkListBox.Items.Add(" " + otherTextBox.Text + " " + "(" + num.ToString() + ") - $" + chargeAmount.ToString("N2"));
                }
                else
                {
                    Security.ShowAlertMessage("Invalid Syntax. Be sure to follow every amount with \".xx\" where xx is a value." +
    " Example: 200.50");
                }
            }
        }
        else
        {
            Security.ShowAlertMessage("Invalid Syntax. You must type an integer greater than or equal to 1.");
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        for (int i = checkListBox.Items.Count - 1; i >= 0; i--)
        {
            if (checkListBox.Items[i].Selected)
            {
                String item = checkListBox.Items[i].ToString();
                String[] temp = item.Split('$');
                double dollars = double.Parse(temp[1]);
                checkListBox.Items.RemoveAt(i);
                double finalTotal = double.Parse(txtTotal.Text) - dollars;
                txtTotal.Text = finalTotal.ToString("N2");
            }
        }
    }

    protected void btnCharge_Click(object sender, EventArgs e)
    {
        NcaaReservation res = (NcaaReservation)Session["NcaaReservation"];
        String[] schoolChargeExp;
        foreach (ListItem item in checkListBox.Items)
        {
            schoolChargeExp = item.ToString().Split('-');
            res.miscexplanation = res.miscexplanation + "-" + schoolChargeExp[0];
        }
        if (res.misctotal == "")
        {
            res.misctotal = "0";
        }
        double total = double.Parse(res.misctotal) + double.Parse(txtTotal.Text);
        res.misctotal = total.ToString();
        String paid = ddlReservation.Text;
        res.updateCharges();
        Response.Redirect("Receipts/charge.aspx");
    }

    protected void charge(string chargeType)
    {
        chargeAmount = double.Parse(chargeType) * num;
        double total = double.Parse(txtTotal.Text) + chargeAmount;
        txtTotal.Text = total.ToString("N2");
        checkListBox.Items.Add(" " + ddlChargeType.Text + " " + "(" + num.ToString() + ") - $" + chargeAmount.ToString("N2"));
    }
}