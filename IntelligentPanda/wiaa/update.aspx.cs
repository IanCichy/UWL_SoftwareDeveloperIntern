using Rlis.Sql;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

public partial class wiaa_update : System.Web.UI.Page
{
    /// <summary>
    /// The current date -> dynamically set.
    /// </summary>
    private DateTime currentDate;

    /// <summary>
    /// This regular expression matches currency -- cents are optional.
    /// </summary>
    private Regex currencyRegex = new Regex(@"^[+|-|\$]?[0-9]{1,3}(?:,?[0-9]{3})*(\.[0-9]{2})?$");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(1))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        currentDate = DateTime.Now;

        if (!Page.IsPostBack)
        {
            Common.populateWiaaSchoolDropDown(ddlSchoolName);
        }
    }

    /// <summary>
    /// Will execute upon changing the selected index in the schoolDropDown
    /// </summary>
    protected void ddlSchoolName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //in try/catch to catch error if user drops down to "choose a school..." --> refreshes page
        WiaaReservation res = new WiaaReservation(ddlSchoolName.SelectedValue.ToString());
        txtFinalTotal.Text = "";
        txtRefund.Text = "";
        txtInitialPayment.Text = "";
        try
        {
            Session["School"] = ddlSchoolName.SelectedItem.Text;
            txtSchoolName.Text = ddlSchoolName.SelectedItem.Text;
            txtPhoneNumber.Text = res.schoolPhone;
            txtFirstName.Text = res.fname;
            txtLastName.Text = res.lname;
            txtPassword.Text = res.password;
            txtContactTitle.Text = res.title;
            txtContactEmail.Text = res.email;
            txtAddress.Text = res.schoolAddress;
            txtFax.Text = res.schoolFax;
            txtCity.Text = res.city;
            txtZip.Text = res.zip;
            txtAthleticDir.Text = res.athleticDir;
            txtCoach.Text = res.coachName;
            txtMST.Text = res.mst.ToString();
            txtMDT.Text = res.mdt.ToString();
            txtMTT.Text = res.mtt.ToString();
            txtMSF.Text = res.msf.ToString();
            txtMDF.Text = res.mdf.ToString();
            txtMTF.Text = res.mtf.ToString();
            txtFST.Text = res.fst.ToString();
            txtFDT.Text = res.fdt.ToString();
            txtFTT.Text = res.ftt.ToString();
            txtFSF.Text = res.fsf.ToString();
            txtFDF.Text = res.fdf.ToString();
            txtFTF.Text = res.ftf.ToString();
            txtMStudyT.Text = res.mStudyT.ToString();
            txtMStudyF.Text = res.mStudyF.ToString();
            txtFStudyT.Text = res.fStudyT.ToString();
            txtFStudyF.Text = res.fStudyF.ToString();
            txtMEagleST.Text = res.mEagleST.ToString();
            txtMEagleSF.Text = res.mEagleSF.ToString();
            txtMEagleDT.Text = res.mEagleDT.ToString();
            txtMEagleDF.Text = res.mEagleDF.ToString();
            txtFEagleST.Text = res.fEagleST.ToString();
            txtFEagleSF.Text = res.fEagleSF.ToString();
            txtFEagleDT.Text = res.fEagleDT.ToString();
            txtFEagleDF.Text = res.fEagleDF.ToString();
            txtComments.Text = res.comments;
            txtRefundExplanation.Text = res.refundExp;
            txtAmount.Text = res.amount.ToString();
            txtAmount2.Text = res.amount2.ToString();
            txtAmount3.Text = res.amount3.ToString();
            String refund = res.refund.ToString();
            txtRefund.Text = refund;
            txtCheckNumber.Text = res.checkNumber;
            txtCheckNumber2.Text = res.checkNumber2;
            txtCheckNumber3.Text = res.checkNumber3;
            int paidAmount = res.amount + res.amount2 + res.amount3;
            txtInitialPayment.Text = "$" + paidAmount.ToString();

            String arrival = res.arrival;
            String[] strArray = arrival.Split(' ');
            expectedDayTextBox.Text = strArray[0];

            String[] timeArray = strArray[1].Split(':');
            String time = timeArray[0];
            expectedTimeTextBox.Text = time + ":00 " + strArray[2];

            Session["WiaaReservation"] = res;

            updateRoomsNeeded();
            calculateBillingInfo();
            populateChecklistBox();
        }
        catch (Exception ex)
        {
            Response.Redirect("update.aspx");
        }
    }

    /// <summary>
    /// Will update the total rooms needed and the billing info
    /// </summary>
    protected void updateButton_Click(object sender, EventArgs e)
    {
        WiaaReservation res = (WiaaReservation)Session["WiaaReservation"];
        txtFinalTotal.Text = "";
        res.mst = int.Parse(txtMST.Text);
        res.msf = int.Parse(txtMSF.Text);
        res.mdt = int.Parse(txtMDT.Text);
        res.mdf = int.Parse(txtMDF.Text);
        res.mtt = int.Parse(txtMTT.Text);
        res.mtf = int.Parse(txtMTF.Text);
        res.fst = int.Parse(txtFST.Text);
        res.fsf = int.Parse(txtFSF.Text);
        res.fdt = int.Parse(txtFDT.Text);
        res.fdf = int.Parse(txtFDF.Text);
        res.ftt = int.Parse(txtFTT.Text);
        res.ftf = int.Parse(txtFTF.Text);
        res.mStudyT = int.Parse(txtMStudyT.Text);
        res.mStudyF = int.Parse(txtMStudyF.Text);
        res.fStudyT = int.Parse(txtFStudyT.Text);
        res.fStudyF = int.Parse(txtFStudyF.Text);
        res.mEagleST = int.Parse(txtMEagleST.Text);
        res.mEagleSF = int.Parse(txtMEagleSF.Text);
        res.mEagleDT = int.Parse(txtMEagleDT.Text);
        res.mEagleDF = int.Parse(txtMEagleDF.Text);
        res.fEagleST = int.Parse(txtFEagleST.Text);
        res.fEagleSF = int.Parse(txtFEagleSF.Text);
        res.fEagleDT = int.Parse(txtFEagleDT.Text);
        res.fEagleDF = int.Parse(txtFEagleDF.Text);

        res.updateReservations();
        updateRoomsNeeded();
        calculateBillingInfo();
        Security.ShowAlertMessage("Room Reservation Info has been updated for " + Session["School"].ToString() + "!");
    }

    /// <summary>
    /// Updates the contact information and the School Information
    /// </summary>
    protected void updateInfo_Click(object sender, EventArgs e)
    {
        WiaaReservation res = (WiaaReservation)Session["WiaaReservation"];
        res.fname = txtFirstName.Text.Replace("'", "''");
        res.lname = txtLastName.Text.Replace("'", "''");
        res.title = txtContactTitle.Text.Replace("'", "''");
        res.email = txtContactEmail.Text.Replace("'", "''");
        res.schoolFax = txtAddress.Text.Replace("'", "''");
        res.schoolFax = txtFax.Text.Replace("'", "''");
        res.city = txtCity.Text.Replace("'", "''");
        res.zip = txtZip.Text.Replace("'", "''");
        res.athleticDir = txtAthleticDir.Text.Replace("'", "''");
        res.coachName = txtCoach.Text.Replace("'", "''");
        res.school = txtSchoolName.Text;
        res.schoolPhone = txtPhoneNumber.Text.Replace("'", "''");

        res.updateSchoolInformation();
        Session["WiaaReservation"] = res;
        Security.ShowAlertMessage("School and Contact Information has been updated for " + res.school + "!");
    }

    /// <summary>
    /// Method used to determine the "Total Rooms Needed"
    /// </summary>
    public void updateRoomsNeeded()
    {
        WiaaReservation res = (WiaaReservation)Session["WiaaReservation"];

        int mSingles;
        int mst = res.mst;
        int msf = res.msf;
        if (mst < msf)
            mSingles = msf;
        else mSingles = mst;

        int mDoubles;
        int mdt = res.mdt;
        int mdf = res.mdf;
        if (mdt < mdf)
            mDoubles = mdf;
        else mDoubles = mdt;

        int mTriples;
        int mtt = res.mtt;
        int mtf = res.mtf;
        if (mtt < mtf)
            mTriples = mtf;
        else mTriples = mtt;

        int fSingles;
        int fst = res.fst;
        int fsf = res.fsf;
        if (fst < fsf)
            fSingles = fsf;
        else fSingles = fst;

        int fDoubles;
        int fdt = res.fdt;
        int fdf = res.fdf;
        if (fdt < fdf)
            fDoubles = fdf;
        else fDoubles = fdt;

        int fTriples;
        int ftt = res.ftt;
        int ftf = res.ftf;
        if (ftt < ftf)
            fTriples = ftf;
        else fTriples = ftt;

        int mStudies;
        int MStudyT = res.mStudyT;
        int MStudyF = res.mStudyF;
        if (MStudyT < MStudyF)
            mStudies = MStudyF;
        else mStudies = MStudyT;

        int fStudies;
        int FStudyT = res.fStudyT;
        int FStudyF = res.fStudyF;
        if (FStudyT < FStudyF)
            fStudies = FStudyF;
        else fStudies = FStudyT;

        int MEagleSingles;
        int MEagleST = res.mEagleST;
        int MEagleSF = res.mEagleSF;
        if (MEagleST < MEagleSF)
            MEagleSingles = MEagleSF;
        else MEagleSingles = MEagleST;

        int MEagleDoubles;
        int MEagleDT = res.mEagleDT;
        int MEagleDF = res.mEagleDF;
        if (MEagleDT < MEagleDF)
            MEagleDoubles = MEagleDF;
        else MEagleDoubles = MEagleDT;

        int FEagleSingles;
        int FEagleST = res.fEagleST;
        int FEagleSF = res.fEagleSF;
        if (FEagleST < FEagleSF)
            FEagleSingles = FEagleSF;
        else FEagleSingles = FEagleST;

        int FEagleDoubles;
        int FEagleDT = res.fEagleDT;
        int FEagleDF = res.fEagleDF;
        if (FEagleDT < FEagleDF)
            FEagleDoubles = FEagleDF;
        else FEagleDoubles = FEagleDT;

        int rooms = mSingles + mDoubles + mTriples + fSingles + fDoubles + fTriples + mStudies + fStudies + MEagleSingles + MEagleDoubles + FEagleDoubles + FEagleSingles;
        totalRoomsTextBox.Text = rooms.ToString();
    }

    protected void clearRefundButton_Click(object sender, EventArgs e)
    {
        txtRefund.Text = "$0.00";
        txtFinalTotal.Text = "";
        txtInitialPayment.Text = "";
    }

    /// <summary>
    /// Calculates the Final Total to see if a refund is needed or not.
    /// </summary>
    protected void calculateButton_Click(object sender, EventArgs e)
    {
        WiaaReservation res = (WiaaReservation)Session["WiaaReservation"];
        int finalTotal = int.Parse(txtFinalTotal.Text);
        int amount = int.Parse(txtAmount.Text);
        int amount2 = 0;
        int amount3 = 0;
        int refund = 0;
        int totalAmount = amount;
        string paidBy2 = "";
        string paidBy3 = "";

        // If a second payment option is visible, add that amount to total amount being paid.
        if (secondPayment.Visible)
        {
            amount2 = int.Parse(txtAmount2.Text);
            totalAmount = amount + amount2;
            paidBy2 = ddlPaidBy2.Text;
            res.checkNumber2 = txtCheckNumber2.Text;
        }

        if (thirdPayment.Visible)
        {
            amount3 = int.Parse(txtAmount3.Text);
            totalAmount = totalAmount + amount3;
            paidBy3 = ddlPaidBy3.Text;
            res.checkNumber3 = txtCheckNumber3.Text;
        }

        // if the total amount is less than the final amount, show warning message.
        if (totalAmount < finalTotal)
        {
            Security.ShowAlertMessage("You must pay in full!");
            btnSaveBilling.Visible = false;
            return;
        }
        else if (totalAmount > finalTotal)
        {
            refund = totalAmount - finalTotal;
            divRefund.Visible = true;
            txtRefund.Text = refund.ToString();
        }

        res.paidBy = ddlPaidBy.Text;
        res.paidBy2 = paidBy2;
        res.paidBy3 = paidBy3;
        res.amount = amount;
        res.amount2 = amount2;
        res.amount3 = amount3;
        res.checkNumber = txtCheckNumber.Text;
        res.refund = refund;
        res.billTotal = finalTotal;

        Session["WiaaReservation"] = res;
        btnSaveBilling.Visible = true;
    }

    /// <summary>
    /// Calculates the amount being charged for singles, doubles, triples, etc.
    /// </summary>
    private void calculateBillingInfo()
    {
        int totalSingles;
        int billingSingles;
        String schoolName = Session["School"].ToString().Replace("'", "''");
        totalSingles = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MST + FST + MSF + FSF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingSingles = totalSingles * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SingleCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        singlesCost.Text = "$" + billingSingles.ToString();
        Session["SinglesCost"] = singlesCost.Text;

        int totalDoubles;
        int billingDoubles;
        totalDoubles = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MDT + MDF + FDT + FDF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingDoubles = totalDoubles * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT DoubleCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        doublesCost.Text = "$" + billingDoubles.ToString();
        Session["DoublesCost"] = doublesCost.Text;

        int totalTriples;
        int billingTriples;
        totalTriples = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MTT + MTF + FTT + FTF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingTriples = totalTriples * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT TripleCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        triplesCost.Text = "$" + billingTriples.ToString();
        Session["TriplesCost"] = triplesCost.Text;

        int totalStudies;
        int billingStudies;
        totalStudies = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MStudyT + MStudyF + FStudyT + FStudyF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingStudies = totalStudies * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT StudyCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        studiesCost.Text = "$" + billingStudies.ToString();
        Session["StudiesCost"] = studiesCost.Text;

        int totalEagleSingles;
        int billingEagleSingles;
        totalEagleSingles = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MEagleST + MEagleSF + FEagleST + FEagleSF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingEagleSingles = totalEagleSingles * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT EagleSingleCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        eagleSinglesCost.Text = "$" + billingEagleSingles.ToString();
        Session["EagleSinglesCost"] = eagleSinglesCost.Text;

        int totalEagleDoubles;
        int billingEagleDoubles;
        totalEagleDoubles = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SUM(MEagleDT + MEagleDF + FEagleDT + FEagleDF) FROM WiaaSchoolReservations WHERE SchoolName = '" + schoolName + "' and Year = " + Settings.Year + "").ToString());
        billingEagleDoubles = totalEagleDoubles * int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT EagleDoubleCost FROM RoomCosts WHERE year = " + Settings.Year + "").ToString());
        eagleDoublesCost.Text = "$" + billingEagleDoubles.ToString();
        Session["EagleDoublesCost"] = eagleDoublesCost.Text;

        int totalCost = billingTriples + billingSingles + billingDoubles + billingStudies + billingEagleSingles + billingEagleDoubles;
        txtSubTotal.Text = "$" + totalCost.ToString();
        txtFinalTotal.Text = totalCost.ToString();
    }

    private void populateChecklistBox()
    {
        DataSet rooms = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT Hall + ' ' + Room AS RoomAssignment FROM ReservedRooms WHERE School = '" + ddlSchoolName.SelectedItem.Text.Replace("'","''") + "'");
        editResCheckBox.DataSource = rooms;
        editResCheckBox.DataTextField = "RoomAssignment";
        editResCheckBox.DataBind();
    }

    /// <summary>
    /// Will remove reservations for rooms that are checked when the remove button is pressed
    /// </summary>
    protected void remove_Click(object sender, EventArgs e)
    {
        for (int i = editResCheckBox.Items.Count - 1; i >= 0; i--)
        {
            if (editResCheckBox.Items[i].Selected)
            {
                String temp = editResCheckBox.Items[i].Text;
                String[] array = temp.Split(' ');
                String hall = array[0];
                String room = array[1];
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE ReservedRooms SET Reserved = 0, School = null WHERE Hall = '" + hall + "' and Room = '" + room + "'");
                editResCheckBox.Items.RemoveAt(i);
            }
        }
    }

    protected void hide_Click(object sender, EventArgs e)
    {
        editResPanel.Visible = false;
    }

    protected void printReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receipts/receipt.aspx");
    }

    protected void removeRooms_Click(object sender, EventArgs e)
    {
        editResPanel.Visible = true;
    }

    /// <summary>
    /// Adds a second payment option.
    /// Ex --> Coach has school check but needs to pay more because reserving rooms in Eagle,
    /// they may also pay with cash or a personal check. Hence, a second payment.
    /// </summary>
    protected void addPayment_Click(object sender, EventArgs e)
    {
        secondPayment.Visible = true;
    }

    protected void addThirdPayment_Click(object sender, EventArgs e)
    {
        thirdPayment.Visible = true;
    }

    protected void removePayment_Click(object sender, EventArgs e)
    {
        secondPayment.Visible = false;
        ddlPaidBy2.Items.Clear();
        txtCheckNumber2.Text = "";
    }

    protected void removethirdPayment_Click(object sender, EventArgs e)
    {
        thirdPayment.Visible = false;
        ddlPaidBy3.Items.Clear();
        txtCheckNumber3.Text = "";
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET Comment = '" + txtComments.Text.Replace("'", "''") + "' WHERE ContactEmail = '" + ddlSchoolName.SelectedItem.Value.ToString() + "' AND Year = " + Settings.Year + "");
        Security.ShowAlertMessage("Comment updated!");
    }

    /// <summary>
    /// Save all billing information to the database
    /// </summary>
    protected void btnSaveBilling_Click(object sender, EventArgs e)
    {
        WiaaReservation res = (WiaaReservation)Session["WiaaReservation"];
        res.refundExp = txtRefundExplanation.Text.Replace("'", "''");
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET Comment += '\nRefund Notes: " + res.refundExp + "' WHERE ContactEmail = '" + ddlSchoolName.SelectedItem.Value.ToString() + "' AND Year = " + Settings.Year + "");
        res.updateBilling();
        //printReceipt.Visible = true; Combined save and print to reduce number of clicks
        Session["WiaaReservation"] = res;
        Response.Redirect("Receipts/receipt.aspx"); //Eliminates the need for the print receipts button
        //Security.ShowAlertMessage("All information has been saved. You can now print the receipt."); Unecessary message, removed to reduce number of clicks
    }
}