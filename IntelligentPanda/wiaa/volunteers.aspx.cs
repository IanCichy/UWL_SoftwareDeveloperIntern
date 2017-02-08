using Rlis.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wiaa_volunteers : System.Web.UI.Page
{
    private Regex currencyRegex = new Regex(@"^[+|-|\$]?[0-9]{1,3}(?:,?[0-9]{3})*\.[0-9]{2}$");
    private String[] friArr, thurArr;
    private int Thursday, Friday;
    private String thursdate, fridate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Account.hasRights(1) || Account.hasRights(3)))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            loadVolunteers();
        }
    }

    /// <summary>
    /// Adds a New Volunteer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void submitButton_Click(object sender, EventArgs e)
    {
        String fname = firstNameTextBox.Text.Trim();
        String lname = lastNameTextBox.Text.Trim();
        String phone = phoneNumberTextBox.Text;
        String contactEmail = contactEmailTextBox.Text;
        if (contactEmail == "")
        {
            ShowAlertMessage("You must fill out Contact Email.");
        }
        String fax = faxTextBox.Text;
        String address = addressTextBox.Text;
        String city = cityTextBox.Text;
        String zip = zipTextBox.Text;

        int rst = 0;
        int rsf = 0;
        foreach (ListItem item in dayCheckBox.Items)
        {
            if (item.Selected)
            {
                if (item.Text == "Thursday")
                    rst = 1;
                if (item.Text == "Friday")
                    rsf = 1;
            }
        }
        //USE IF USING EXPECTED ARRIVAL
        //SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "INSERT INTO WiaaVolunteerInfo (FName, LName, Phone, ContactEmail, Fax, Address, City, Zip, RST, RSF, Year, ExpectedArrival) VALUES ('" + fname + "','" + lname + "','" + phone + "','" + contactEmail + "','" + fax + "','" + address + "','" + city + "','" + zip + "'," + rst + "," + rsf + "," + year + ",'" + arrivalString + "')");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "INSERT INTO WiaaVolunteerInfo (FName, LName, Phone, ContactEmail, Fax, Address, City, Zip, RST, RSF, Year, Cancelled) VALUES ('" + fname + "','" + lname + "','" + phone + "','" + contactEmail + "','" + fax + "','" + address + "','" + city + "','" + zip + "'," + rst + "," + rsf + "," + Settings.Year + ",'False')");
        Response.Redirect("volunteers.aspx");
    }

    //Load Volunteers into dropdown list
    private void loadVolunteers()
    {
        DataSet volunteers = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "Select FName + ' ' + LName AS Name FROM WiaaVolunteerInfo Where Cancelled = 'False' AND Year =" + Settings.Year + " ORDER BY FName, LName");

        volunteerDropDown2.DataSource = volunteers;
        volunteerDropDown2.DataTextField = "Name";
        volunteerDropDown2.DataValueField = "Name";
        volunteerDropDown2.DataBind();
        volunteerDropDown2.Items.Insert(0, new ListItem("Choose volunteer...", "-1"));
        volunteerDropDown2.SelectedItem.Selected = false;
        volunteerDropDown2.Items.FindByValue("-1").Selected = true;
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

    /*The Drop down that is on the Update Volunteer Info page*/

    protected void volunteerDropDown2_SelectedIndexChanged(object sender, EventArgs e)
    {
        initialPaymentTextBox.Text = "";
        String fullname = volunteerDropDown2.Text;
        Session["Volunteer"] = fullname;
        lblName.Text = fullname;
        String[] str = fullname.Split(' ');
        String fname = str[0];
        String lname = str[1];
        updateEmail.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT ContactEmail FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        Session["EmailID"] = updateEmail.Text; //used as identifier in select statements - make primary key
        updateFName.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FName FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updateLName.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT LName FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updatePhone.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Phone FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updateAddress.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Address FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updateFax.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Fax FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updateCity.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT City FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        updateZip.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Zip FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();
        txtComment.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Comments FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' AND Year = " + Settings.Year + "").ToString();

        Thursday = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RST FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString());
        Friday = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RSF FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString());
        if (Thursday == 1) updateCheckBoxList.Items.FindByText("Thursday").Selected = true;
        else { updateCheckBoxList.Items.FindByText("Thursday").Selected = false; }
        if (Friday == 1) updateCheckBoxList.Items.FindByText("Friday").Selected = true;
        else { updateCheckBoxList.Items.FindByText("Friday").Selected = false; }
        volRefundTextBox.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Refund FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        refundExpTextBox.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RefundExplanation FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        finalTotalTextBox.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FinalTotal FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        checkNumberTextBox.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT CheckNumber FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        String paid = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Paid FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString().Trim();
        String paidby = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT PaidBy FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        String secondPaidBy = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SecondPaidBy FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString().Trim();
        String secondCheck = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SecondCheckNumber FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();

        loadReservedRooms();
        calculateBilling();
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        String fullname = volunteerDropDown2.Text;
        String[] str = fullname.Split(' ');
        String fname = str[0];
        String lname = str[1];
        String newFname = updateFName.Text;
        String newLname = updateLName.Text;
        String phone = updatePhone.Text;
        String email = updateEmail.Text;
        String address = updateAddress.Text;
        String fax = updateFax.Text;
        String city = updateCity.Text;
        String zip = updateZip.Text;
        String comments = txtComment.Text;
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET FName = '" + newFname + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET LName = '" + newLname + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Phone = '" + phone + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET ContactEmail = '" + email + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Address = '" + address + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Fax = '" + fax + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET City = '" + city + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Zip = '" + zip + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Comments = '" + comments + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        int rst = 0;
        int rsf = 0;
        foreach (ListItem item in updateCheckBoxList.Items)
        {
            if (item.Selected)
            {
                if (item.Text == "Thursday")
                    rst = 1;
                if (item.Text == "Friday")
                    rsf = 1;
            }
        }
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET RST = " + rst + " WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET RSF = " + rsf + " WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
        calculateBilling();
        ShowAlertMessage("Volunteer Info has been updated!");
    }

    private void calculateBilling()
    {
        Thursday = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RST FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString());
        Friday = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RSF FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString());
        int roomsNeeded = Thursday + Friday;
        int reuterCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT ReuterCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());
        singleRoomTextBox.Text = "$" + (reuterCost * roomsNeeded).ToString();
        subTotalTextBox.Text = singleRoomTextBox.Text;
    }

    protected void calculateButton_Click(object sender, EventArgs e)
    {
        finalTotalTextBox.Text = "";
        String[] sub = subTotalTextBox.Text.Split('$');
        String amount = initialPaymentTextBox.Text;
        Match m = currencyRegex.Match(amount);

        if (initialPaymentTextBox.Text == "")
        {
            finalTotalTextBox.Text = subTotalTextBox.Text;
        }
        else if (m.Success)
        {
            if (amount.StartsWith("$"))
            {
                amount = amount.TrimStart('$');
            }
            double subTotal = double.Parse(sub[1]);
            double refund = double.Parse(amount) - double.Parse(sub[1]);
            finalTotalTextBox.Text = "$" + (subTotal).ToString();
            volRefundTextBox.Text = "$" + refund.ToString();
        }
        else
        {
            Security.ShowAlertMessage("Invalid Syntax. Be sure to follow every amount with \".xx\" where xx is a value." +
                " Example: 200.50");
        }
        Session["VolRefund"] = volRefundTextBox.Text;
        if (volRefundTextBox.Text == "")
        {
            Session["VolRefund"] = "0";
        }
        Session["VolFinalTotal"] = finalTotalTextBox.Text;
    }

    protected void addPayment_Click(object sender, EventArgs e)
    {
        secondPayment.Visible = true;
    }

    protected void removePayment_Click(object sender, EventArgs e)
    {
        secondPayment.Visible = false;
        checkNumberTextBox2.Text = "";
    }

    protected void updateAllButton_Click(object sender, EventArgs e)
    {
        if (finalTotalTextBox.Text == "")
        {
            Security.ShowAlertMessage("You must calculate the final total first!");
        }
        else
        {
            String paidby = paidbyDropDown.Text;
            String check = checkNumberTextBox.Text;
            String refund = volRefundTextBox.Text;
            String refundExp = refundExpTextBox.Text;
            String secondPaid = paidbyDropDown2.Text;
            String secondCheck = checkNumberTextBox2.Text;
            String comment = txtComment.Text;
            String finalTotal = finalTotalTextBox.Text;
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET PaidBy ='" + paidby + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET CheckNumber ='" + check + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Refund ='" + refund + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET RefundExplanation ='" + refundExp + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Comments ='" + comment + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET FinalTotal ='" + finalTotal + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            if (secondPayment.Visible == true)
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET SecondPaidBy ='" + secondPaid + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET SecondCheckNumber ='" + secondCheck + "' WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            }
            else
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET SecondPaidBy = NULL WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET SecondCheckNumber = NULL WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            }

            printReceipt.Visible = true;
            Security.ShowAlertMessage("All information has been saved. You can now print the receipt.");
        }
    }

    protected void printReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/wiaa/receipts/volunteerReceipt.aspx");
    }

    protected void clearButton_Click(object sender, EventArgs e)
    {
        initialPaymentTextBox.Text = "";
        volRefundTextBox.Text = "";
        finalTotalTextBox.Text = "";
    }

    private void loadReservedRooms()
    {
        String reserved = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Room FROM WiaaVolunteerInfo WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'").ToString();
        roomReservedLabel.Text = reserved;
        if (reserved == "")
        {
            roomReservedLabel.Text = "None";
        }
    }

    protected void removeRoomButton_Click(object sender, EventArgs e)
    {
        String fullname = volunteerDropDown2.Text;
        String reservation = roomReservedLabel.Text;
        if (reservation == "None")
        {
            ShowAlertMessage("This volunteer has not reserved a room.");
        }
        else
        {
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Room = null WHERE ContactEmail = '" + Session["EmailID"].ToString() + "' AND Year = '" + Settings.Year + "'");
            String bedA = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed A] FROM VolunteerRoomReservations WHERE Room = '" + reservation + "'").ToString();
            String bedB = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed B] FROM VolunteerRoomReservations WHERE Room = '" + reservation + "'").ToString();
            String bedC = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed C] FROM VolunteerRoomReservations WHERE Room = '" + reservation + "'").ToString();
            String bedD = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed D] FROM VolunteerRoomReservations WHERE Room = '" + reservation + "'").ToString();
            if (bedA == fullname) SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed A] = null WHERE Room = '" + reservation + "'");
            else if (bedB == fullname) SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed B] = null WHERE Room = '" + reservation + "'");
            else if (bedC == fullname) SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed C] = null WHERE Room = '" + reservation + "'");
            else if (bedD == fullname) SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed D] = null WHERE Room = '" + reservation + "'");
            ShowAlertMessage("The reservation has been canceled.");
        }
    }

    protected void btnLookUp_Click(object sender, EventArgs e)
    {
        string fullname = volunteerDropDown2.Text;
        SqlConnect conn = new SqlConnect(Settings.WIAAConnection);
        string[] parameters = { "@Name" };
        string[] values = { fullname };
        string result = conn.Select("Room", "VolunteerRoomReservations", "([Bed A] = @Name or [Bed B] = @Name or [Bed C] = @Name or [Bed D] = @Name)", parameters, values);
        Security.ShowAlertMessage(fullname + " is currently staying in room " + result + ".");
    }

    protected void btnReview_Click(object sender, EventArgs e)
    {
        List<string> clickedRooms = ((List<string>)Session["ReuterRoomsClicked"]);
        clickedRooms.Sort();
        
        if (clickedRooms.Count > 1)
        {
            Security.ShowAlertMessage("You have chosen too many rooms. Rooms currently selected: " + string.Join(",", clickedRooms.ToArray()));
        }
        else
        {
            String bedA = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed A] FROM VolunteerRoomReservations WHERE Room = '" + clickedRooms.ToArray()[0] + "'").ToString();
            String bedB = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed B] FROM VolunteerRoomReservations WHERE Room = '" + clickedRooms.ToArray()[0] + "'").ToString();
            String bedC = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed C] FROM VolunteerRoomReservations WHERE Room = '" + clickedRooms.ToArray()[0] + "'").ToString();
            String bedD = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed D] FROM VolunteerRoomReservations WHERE Room = '" + clickedRooms.ToArray()[0] + "'").ToString();

            lblReview.Text = string.Join(",", clickedRooms.ToArray());
            lblReview2.Text = "<u><b>Occupants:</b></u>";
            if (!bedA.Equals("")) lblReview2.Text += "<br/>" + bedA;
            if (!bedB.Equals("")) lblReview2.Text += "<br/>" + bedB;
            if (!bedC.Equals("")) lblReview2.Text += "<br/>" + bedC;
            if (!bedD.Equals("")) lblReview2.Text += "<br/>" + bedD;
            divFinalize.Visible = true;
        }
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        string fullname = volunteerDropDown2.Text;
        string fname = fullname.Split(' ')[0];
        string lname = fullname.Split(' ')[1];

        if (lookUp() != null)
        {
            Security.ShowAlertMessage("Volunteer has already reserved a room.");
        }
        else
        {
            string bedA = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed A] FROM VolunteerRoomReservations WHERE Room = '" + lblReview.Text + "'").ToString();
            string bedB = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed B] FROM VolunteerRoomReservations WHERE Room = '" + lblReview.Text + "'").ToString();
            string bedC = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed C] FROM VolunteerRoomReservations WHERE Room = '" + lblReview.Text + "'").ToString();
            string bedD = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT [Bed D] FROM VolunteerRoomReservations WHERE Room = '" + lblReview.Text + "'").ToString();

            if (bedA == null || bedA == "")
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed A] = '" + volunteerDropDown2.Text + "' WHERE Room = '" + lblReview.Text + "'");
            }
            else if (bedB == null || bedB == "")
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed B] = '" + volunteerDropDown2.Text + "' WHERE Room = '" + lblReview.Text + "'");
            }
            else if (bedC == null || bedC == "")
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed C] = '" + volunteerDropDown2.Text + "' WHERE Room = '" + lblReview.Text + "'");
            }
            else if (bedD == null || bedD == "")
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE VolunteerRoomReservations SET [Bed D] = '" + volunteerDropDown2.Text + "' WHERE Room = '" + lblReview.Text + "'");
            }
            SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Room = '" + lblReview.Text + "' WHERE FName = '" + fname + "' AND LName = '" + lname + "'");
            Session["VolunteerRoom"] = lblReview.Text;
            Response.Redirect("~/wiaa/receipts/volunteerHousing.aspx");
        }
    }

    private string lookUp()
    {
        try
        {
            string fullname = volunteerDropDown2.Text;
            SqlConnect conn = new SqlConnect(Settings.WIAAConnection);
            string[] parameters = { "@Name" };
            string[] values = { fullname };
            string result = conn.Select("Room", "VolunteerRoomReservations", "([Bed A] = @Name or [Bed B] = @Name or [Bed C] = @Name or [Bed D] = @Name)", parameters, values);
            return result;
        }
        catch
        {
            return null;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "DELETE FROM WiaaVolunteerInfo WHERE ContactEmail = '" + updateEmail.Text + "'");
        Response.Redirect("volunteers.aspx");
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaVolunteerInfo SET Comments = '" + txtComment.Text.Replace("'", "''") + "' WHERE ContactEmail = '" + updateEmail.Text + "'");
        Security.ShowAlertMessage("Comment updated!");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/wiaa/receipts/volunteerHousing.aspx");
    }
}