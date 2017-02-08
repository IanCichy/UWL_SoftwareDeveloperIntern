using Rlis.Sql;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ncaa_update : System.Web.UI.Page
{
    private string email;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(2))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            Common.populateNcaaSchoolDropDown(ddlReservations);
        }
    }

    /// <summary>
    /// Changes the active reservation
    /// </summary>
    protected void ddlReservations_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlArrivalDay.ClearSelection();
        ddlDepartureDay.ClearSelection();
        rblRole.ClearSelection();
        rblHallPref.ClearSelection();
        email = ddlReservations.SelectedItem.Value.ToString();
        refreshReservation(email);
        showRooms(email);
    }

    /// <summary>
    /// Displays all reserved rooms for current selection
    /// </summary>
    protected void showRooms(string email)
    {
        NcaaReservation res = new NcaaReservation(email);
        tblRooms.Rows.Clear();
        foreach (RoomReservation r in res.reservedRooms)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            if (r.hall == "Reuter")
            {
                cell.Text = String.Format("{0} {1} ({2})\n", r.hall, r.room, r.beds);
            }
            else
            {
                cell.Text = String.Format("{0} {1} ({2}) - {3}\n", r.hall, r.room, r.beds, r.gender == 'f' ? "Female" : "Male");
            }
            row.Cells.Add(cell);
            tblRooms.Rows.Add(row);
        }
    }

    /// <summary>
    /// Updates the reservation information
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        NcaaReservation res = new NcaaReservation();
        res.role = rblRole.SelectedValue;
        res.lname = txtLastName.Text;
        res.fname = txtFirstName.Text;
        res.school = txtSchoolName.Text;
        res.email = txtEmail.Text;
        res.cell = txtCellPhone.Text;
        res.hallpref = rblHallPref.SelectedValue;
        res.arrival = ddlArrivalDay.SelectedValue;
        res.departure = ddlDepartureDay.SelectedValue;
        res.fsingles = int.Parse(txtFemaleSingles.Text);
        res.msingles = int.Parse(txtMaleSingles.Text);
        res.fdoubles = int.Parse(txtFemaleDoubles.Text);
        res.mdoubles = int.Parse(txtMaleDoubles.Text);
        res.suites = int.Parse(txtSuites.Text);
        res.update();
        Security.ShowAlertMessage("You changes have been saved.");

        refreshReservation(res.email);
    }

    /// <summary>
    /// Reloads all text boxes based on updated information.
    /// </summary>
    /// <param name="email">The reservation to load</param>
    private void refreshReservation(string email)
    {
        NcaaReservation res = new NcaaReservation(email);
        rblRole.Items.FindByValue(res.role).Selected = true;
        txtLastName.Text = res.lname;
        txtFirstName.Text = res.fname;
        txtSchoolName.Text = res.school;
        txtEmail.Text = res.email;
        txtCellPhone.Text = res.cell;
        rblHallPref.Items.FindByValue(res.hallpref).Selected = true;
        ddlArrivalDay.Items.FindByValue(res.arrival.Split(' ')[0]).Selected = true;
        ddlDepartureDay.Items.FindByValue(res.departure.Split(' ')[0]).Selected = true;
        txtFemaleSingles.Text = res.fsingles.ToString();
        txtMaleSingles.Text = res.msingles.ToString();
        txtMaleDoubles.Text = res.mdoubles.ToString();
        txtFemaleDoubles.Text = res.fdoubles.ToString();
        txtSuites.Text = res.suites.ToString();
        txtCost.Text = res.billTotal.ToString();
        txtNote.Text = res.billNote.ToString();
        txtComments.Text = res.comments.ToString();
        txtCheckNumber.Text = res.checkNumber.ToString();
        txtPaymentAmount.Text = res.amount == 0 ? "" : res.amount.ToString();
        txtSecondCheckNumber.Text = res.checkNumber2.ToString();
        txtSecondPaymentAmount.Text = res.amount2 == 0 ? "" : res.amount2.ToString();
        Session["NcaaReservation"] = res;
    }

    /// <summary>
    /// Displays the second payment information
    /// </summary>
    protected void btnSecondPayment_Click(object sender, EventArgs e)
    {
        trSecondCheckNumber.Visible = true;
        trSecondPaidBy.Visible = true;
        trSecondAmount.Visible = true;
    }

    /// <summary>
    /// Removes second payment information
    /// </summary>
    protected void btnRemoveSecondPayment_Click(object sender, EventArgs e)
    {
        trSecondCheckNumber.Visible = false;
        trSecondPaidBy.Visible = false;
        trSecondAmount.Visible = false;
    }

    /// <summary>
    /// Updates the billing information in the database and prints billing receipt
    /// </summary>
    protected void btnFinalize_Click(object sender, EventArgs e)
    {
        NcaaReservation res = (NcaaReservation)Session["NcaaReservation"];
        int refund = 0;
        int secondPaymentAmount = 0;
        int paymentAmount = int.Parse(txtPaymentAmount.Text);
        int totalCost = int.Parse(txtCost.Text);
        string note = txtNote.Text;
        string checkNumber = txtCheckNumber.Text;
        string secondCheckNumber = "";
        string paidBy = ddlPaidBy.SelectedItem.Text;
        string secondPaidBy = "";

        // If the second payment is visible
        if (trSecondPaidBy.Visible == true)
        {
            secondCheckNumber = txtSecondCheckNumber.Text;
            secondPaidBy = ddlSecondPaidBy.SelectedItem.Text;
            secondPaymentAmount = int.Parse(txtSecondPaymentAmount.Text);
        }

        // if the payment amount is greater than the total cost, calculate a refund
        if ((paymentAmount + secondPaymentAmount) > totalCost)
        {
            refund = paymentAmount + secondPaymentAmount - totalCost;
        }

        if ((paymentAmount + secondPaymentAmount) < totalCost)
        {
            Security.ShowAlertMessage("You must pay in full.");
        }
        else
        {
            res.billNote = note;
            res.billTotal = totalCost;
            res.refund = refund;
            res.paidBy = paidBy;
            res.checkNumber = checkNumber;
            res.amount = paymentAmount;
            res.paidBy2 = secondPaidBy;
            res.checkNumber2 = secondCheckNumber;
            res.amount2 = secondPaymentAmount;
            res.updateBilling();
            Session["NcaaReservation"] = res;
            Response.Redirect("Receipts/billing.aspx");
        }
    }

    /// <summary>
    /// Updates the comment for the reservation
    /// </summary>
    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "UPDATE Reservations SET Comment = '" + txtComments.Text.Replace("'", "''") + "' WHERE Email = '" + ddlReservations.SelectedItem.Value.ToString() + "'");
        Security.ShowAlertMessage("Comment updated!");
    }
}