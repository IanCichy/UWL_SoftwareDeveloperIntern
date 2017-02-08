using Rlis.Sql;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wiaa_misc : System.Web.UI.Page
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
        if (!(Account.hasRights(1) || Account.hasRights(3)))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        DateTime currentDate = DateTime.Now;
        year = currentDate.Year;

        /*Only if the page isn't a post back, we load the volunteers and schools*/
        if (!Page.IsPostBack)
        {
            loadVolunteers();
            loadSchools();
            totalTextBox.Text = "0.00";
            totalTextBoxVol.Text = "0.00";
        }
    }

    private void loadSchools()
    {
        DataSet schools = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "Select SchoolName FROM WiaaSchoolReservations Where Cancelled = 'False' AND Year =" + year + " ORDER BY SchoolName");
        schoolDropDown.DataSource = schools;
        schoolDropDown.DataTextField = "SchoolName";
        schoolDropDown.DataValueField = "SchoolName";
        schoolDropDown.DataBind();
        schoolDropDown.Items.Add(new ListItem("Choose a school...", "-1"));
        schoolDropDown.SelectedItem.Selected = false;
        schoolDropDown.Items.FindByValue("-1").Selected = true;
    }

    private void loadVolunteers()
    {
        DataSet volunteers = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "Select FName + ' ' + LName AS Name FROM WiaaVolunteerInfo Where Cancelled = 'False' AND Year =" + year + " ORDER BY LName, FName");
        volDropDown.DataSource = volunteers;
        volDropDown.DataTextField = "Name";
        volDropDown.DataValueField = "Name";
        volDropDown.DataBind();
        volDropDown.Items.Add(new ListItem("Choose volunteer...", "-1"));
        volDropDown.SelectedItem.Selected = false;
        volDropDown.Items.FindByValue("-1").Selected = true;
    }

    protected void schoolButton_Click(object sender, EventArgs e)
    {
        schoolPanel.Visible = true;
        volPanel.Visible = false;
        otherLabel.Visible = false;
        otherTextBox.Visible = false;
        dollarLabel.Visible = false;
        dollarTextBox.Visible = false;
        otherTextBox.Text = "";
        dollarTextBox.Text = "";
        otherLabel2.Visible = false;
        otherTextBox2.Visible = false;
        dollarLabel2.Visible = false;
        dollarTextBox2.Visible = false;
        otherTextBox2.Text = "";
        dollarTextBox2.Text = "";
    }

    protected void volButton_Click(object sender, EventArgs e)
    {
        schoolPanel.Visible = false;
        volPanel.Visible = true;
        otherLabel.Visible = false;
        otherTextBox.Visible = false;
        dollarLabel.Visible = false;
        dollarTextBox.Visible = false;
        otherTextBox.Text = "";
        dollarTextBox.Text = "";
        otherLabel2.Visible = false;
        otherTextBox2.Visible = false;
        dollarLabel2.Visible = false;
        dollarTextBox2.Visible = false;
        otherTextBox2.Text = "";
        dollarTextBox2.Text = "";
    }

    protected void chargeDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (schoolPanel.Visible == true)
        {
            if (chargeDropDown.Text == "Other")
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
        if (volPanel.Visible == true)
        {
            if (chargeDropDown2.Text == "Other")
            {
                otherLabel2.Visible = true;
                otherTextBox2.Visible = true;
                dollarLabel2.Visible = true;
                dollarTextBox2.Visible = true;
            }
            else
            {
                otherLabel2.Visible = false;
                otherTextBox2.Visible = false;
                dollarLabel2.Visible = false;
                dollarTextBox2.Visible = false;
                otherTextBox2.Text = "";
                dollarTextBox2.Text = "";
            }
        }
    }

    /*Save sessions of the school and volunteers to be used for the receipts*/

    protected void schoolDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["School"] = schoolDropDown.Text;
    }

    protected void volDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Volunteer"] = volDropDown.Text;
    }

    public static void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    protected void addChargeButton_Click(object sender, EventArgs e)
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
        String laundryCard = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT LostAccessCard FROM HousingCharges WHERE Year = " + year + "").ToString();
        laundryCard = laundryCard.Substring(0, laundryCard.Length - 2);
        String cleaning = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Cleaning FROM HousingCharges WHERE Year = " + year + "").ToString();
        cleaning = cleaning.Substring(0, cleaning.Length - 2);

        if (schoolPanel.Visible == true)
        {
            num = int.Parse(schoolNumberTextBox.Text);
            Match matchNumber = number.Match(schoolNumberTextBox.Text);
            if (matchNumber.Success)
            {
                num = int.Parse(schoolNumberTextBox.Text);
                if (chargeDropDown.Text == "Lost Access Card")
                {
                    charge(lostCard);
                }
                else if (chargeDropDown.Text == "Lost Room Key")
                {
                    charge(lostKey);
                }
                else if (chargeDropDown.Text == "Fan")
                {
                    charge(fan);
                }
                else if (chargeDropDown.Text == "Blanket")
                {
                    charge(blanket);
                }
                else if (chargeDropDown.Text == "Sheet")
                {
                    charge(sheet);
                }
                else if (chargeDropDown.Text == "Pillow")
                {
                    charge(pillow);
                }
                else if (chargeDropDown.Text == "Pillowcase")
                {
                    charge(pillowcase);
                }
                else if (chargeDropDown.Text == "Towel")
                {
                    charge(towel);
                }
                else if (chargeDropDown.Text == "Washcloth")
                {
                    charge(washcloth);
                }
                else if (chargeDropDown.Text == "Screen Removal")
                {
                    charge(screen);
                }
                else if (chargeDropDown.Text == "Laundry Card")
                {
                    charge(laundryCard);
                }
                else if (chargeDropDown.Text == "Cleaning")
                {
                    charge(cleaning);
                }
                else if (chargeDropDown.Text == "Other")
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
                        double total = double.Parse(totalTextBox.Text) + chargeAmount;
                        totalTextBox.Text = total.ToString("N2");
                        checkListBox.Items.Add(" " + otherTextBox.Text + " " + "(" + num.ToString() + ") - $" + chargeAmount.ToString("N2"));
                    }
                    else
                    {
                        ShowAlertMessage("Invalid Syntax. Be sure to follow every amount with \".xx\" where xx is a value." +
        " Example: 200.50");
                    }
                }
            }
            else
            {
                ShowAlertMessage("Invalid Syntax. You must type an integer greater than or equal to 1.");
            }
        }
        else if (volPanel.Visible == true)
        {
            num2 = int.Parse(volNumberTextBox.Text);
            /*We split the volunteer name because in the database it is stored as FName and LName, but in the drop down, it is their whole name*/
            String[] volunteer = volDropDown.Text.Split(' ');
            String fname = volunteer[0];
            String lname = volunteer[1];
            String miscExp = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscExplanation FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            String miscCharge = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscCharges FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            if (chargeDropDown2.Text == "Lost Access Card")
            {
                charge(lostCard);
            }
            else if (chargeDropDown2.Text == "Lost Room Key")
            {
                charge(lostKey);
            }
            else if (chargeDropDown2.Text == "Fan")
            {
                charge(fan);
            }
            else if (chargeDropDown2.Text == "Blanket")
            {
                charge(blanket);
            }
            else if (chargeDropDown2.Text == "Sheet")
            {
                charge(sheet);
            }
            else if (chargeDropDown2.Text == "Pillow")
            {
                charge(pillow);
            }
            else if (chargeDropDown2.Text == "Pillowcase")
            {
                charge(pillowcase);
            }
            else if (chargeDropDown2.Text == "Towel")
            {
                charge(towel);
            }
            else if (chargeDropDown2.Text == "Washcloth")
            {
                charge(washcloth);
            }
            else if (chargeDropDown2.Text == "Screen Removal")
            {
                charge(screen);
            }
            else if (chargeDropDown2.Text == "Laundry Card")
            {
                charge(laundryCard);
            }
            else if (chargeDropDown2.Text == "Cleaning")
            {
                charge(cleaning);
            }
            else if (chargeDropDown2.Text == "Other")
            {
                String amount = "(" + num2.ToString() + ")";
                String dollarAmount = dollarTextBox2.Text;
                /*Match the regular expression to the dollar amount to make sure the user is entering in money correctly*/
                Match m = currencyRegex.Match(dollarAmount);
                if (m.Success)
                {
                    if (dollarAmount.StartsWith("$"))
                    {
                        dollarAmount = dollarAmount.TrimStart('$');
                    }
                    chargeAmount = double.Parse(dollarAmount) * num2;
                    double total = double.Parse(totalTextBoxVol.Text) + chargeAmount;
                    totalTextBoxVol.Text = total.ToString("N2");
                    checkListBox2.Items.Add(" " + otherTextBox2.Text + " " + "(" + num2.ToString() + ") - $" + chargeAmount.ToString("N2"));
                }
                else
                {
                    ShowAlertMessage("Invalid Syntax. Be sure to follow every amount with \".xx\" where xx is a value." +
    " Example: 200.50");
                }
            }
        }
    }

    protected void charge(String chargeType)
    {
        if (schoolPanel.Visible == true)
        {
            chargeAmount = double.Parse(chargeType) * num;
            double total = double.Parse(totalTextBox.Text) + chargeAmount;
            totalTextBox.Text = total.ToString("N2");
            checkListBox.Items.Add(" " + chargeDropDown.Text + " " + "(" + num.ToString() + ") - $" + chargeAmount.ToString("N2"));
        }
        else if (volPanel.Visible == true)
        {
            chargeAmount = double.Parse(chargeType) * num2;
            double total = double.Parse(totalTextBoxVol.Text) + chargeAmount;
            totalTextBoxVol.Text = total.ToString("N2");
            checkListBox2.Items.Add(" " + chargeDropDown2.Text + " " + "(" + num2.ToString() + ") - $" + chargeAmount.ToString("N2"));
        }
    }

    protected void removeButton(object sender, EventArgs e)
    {
        if (schoolPanel.Visible == true)
        {
            for (int i = checkListBox.Items.Count - 1; i >= 0; i--)
            {
                if (checkListBox.Items[i].Selected)
                {
                    String item = checkListBox.Items[i].ToString();
                    String[] temp = item.Split('$');
                    double dollars = double.Parse(temp[1]);
                    checkListBox.Items.RemoveAt(i);
                    double finalTotal = double.Parse(totalTextBox.Text) - dollars;
                    totalTextBox.Text = finalTotal.ToString("N2");
                }
            }
        }
        else if (volPanel.Visible == true)
        {
            for (int i = checkListBox2.Items.Count - 1; i >= 0; i--)
            {
                if (checkListBox2.Items[i].Selected)
                {
                    String item = checkListBox2.Items[i].ToString();
                    String[] temp = item.Split('$');
                    double dollars = double.Parse(temp[1]);
                    checkListBox2.Items.RemoveAt(i);
                    double finalTotal = double.Parse(totalTextBoxVol.Text) - dollars;
                    totalTextBoxVol.Text = finalTotal.ToString("N2");
                }
            }
        }
    }

    protected void chargeButton_Click(object sender, EventArgs e)
    {
        if (schoolPanel.Visible == true)
        {
            Session["ChargeAmount"] = totalTextBox.Text;
            Session["ChargeReason"] = "";
            String[] schoolChargeExp;
            String schoolName = Session["School"].ToString().Replace("'", "''");
            /*Get the current miscellaneous explanation/charge for this school (if exists) so we can add onto it, not replace it*/
            String miscExp = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscExplanation FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' AND Year = " + year + "").ToString();
            String miscCharge = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscCharges FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' AND Year = " + year + "").ToString();
            foreach (ListItem item in checkListBox.Items)
            {
                schoolChargeExp = item.ToString().Split('-');
                Session["ChargeReason"] = Session["ChargeReason"].ToString() + "-" + schoolChargeExp[0];
                miscExp = miscExp + "-" + schoolChargeExp[0];
            }
            double total = double.Parse(miscCharge) + double.Parse(totalTextBox.Text);
            miscCharge = total.ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET MiscCharges = " + miscCharge + " WHERE SchoolName = '" + schoolName + "' AND Year = " + year + "").ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET MiscExplanation = '" + miscExp + "' WHERE SchoolName = '" + schoolName + "' AND Year = " + year + "").ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET MiscPayment = '" + ddlSchoolPayType.Text + "' WHERE SchoolName = '" + schoolName + "' AND Year = " + year + "").ToString();
            Response.Redirect("Receipts/chargeSchool.aspx");
        }
        else if (volPanel.Visible == true)
        {
            Session["ChargeAmount"] = totalTextBoxVol.Text;
            Session["ChargeReason"] = "";
            String[] name = Session["Volunteer"].ToString().Split(' ');
            String fname = name[0];
            String lname = name[1];
            String[] volChargeExp;
            /*Get the current miscellaneous explanation/charge for this school (if exists) so we can add onto it, not replace it*/
            String miscExp = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscExplanation FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            String miscCharge = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscCharges FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            foreach (ListItem item in checkListBox2.Items)
            {
                volChargeExp = item.ToString().Split('-');
                Session["ChargeReason"] = Session["ChargeReason"].ToString() + "-" + volChargeExp[0];
                miscExp = miscExp + "-" + volChargeExp[0];
            }
            double total = double.Parse(miscCharge) + double.Parse(totalTextBoxVol.Text);
            miscCharge = total.ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET MiscCharges = " + miscCharge + " WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET MiscExplanation = '" + miscExp + "' WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET MiscPayment = '" + ddlVolPaymentType.Text + "' WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + year + "").ToString();
            Response.Redirect("Receipts/chargeVolunteer.aspx");
        }
    }
}