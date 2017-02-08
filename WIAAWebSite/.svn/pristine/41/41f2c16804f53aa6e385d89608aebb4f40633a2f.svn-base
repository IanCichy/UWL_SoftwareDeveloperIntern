using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class application : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        DateTime regBegin = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegBegin FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");
        DateTime regEnd = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegEnd FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");

        if (!Settings.isRegistrationOpen(regBegin)) { Response.Redirect("login.aspx"); }

        if (!Page.IsPostBack)
        {
            ddlArrivalDay_SelectedIndexChanged(null, null);
        }

        // Determine which part of the application to show.
        // This is based of the "page" parameter in the url.
        try
        {
            switch (Request.QueryString["page"].ToString())
            {
                case "1":
                    pnlMainApp.Visible = false;
                    pnlFinalize.Visible = false;
                    pnlRoomsNeeded.Visible = true;
                    break;
                case "2":
                    Reservation res = (Reservation)Session["CurrentApp"];
                    pnlMainApp.Visible = false;
                    pnlFinalize.Visible = true;
                    pnlRoomsNeeded.Visible = false;
                    lblAthleticDir.Text = res.athleticDir;
                    lblCoach.Text = res.coach;
                    DateTime day = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegEnd FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");
                    lblRegEndDay.Text = day.ToString("MMMM dd");
                    DateTime time = (DateTime)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RegEnd FROM WiaaConfig WHERE Year = '" + Settings.Year + "'");
                    lblRegEndTime.Text = time.ToString("h:mm tt");
                    break;
                default:
                    break;
            }
        }
        catch { }
    }

    /// <summary>
    /// Continues the application to the page where you pick how many rooms you need.
    /// </summary>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        // Do not continue if passwords do not match
        if (txtPassword.Text != txtPasswordConfirm.Text)
        {
            Security.ShowAlertMessage("Your passwords do not match!");
        }
        // Do not continue if an arrival time had not been chosen
        else if (ddlArrivalTime.SelectedValue.Equals("")) 
        {
            Security.ShowAlertMessage("Please choose an arrival time");
        }
        else
        {
            string arrivalDay = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "Select [Date] FROM [Dates] where Day = '" + ddlArrivalDay.Text + "'").ToString().Split(' ')[0];
            string arrivalTime = ddlArrivalTime.SelectedValue.ToString();
            DateTime arrival = Convert.ToDateTime(arrivalDay);
            arrival = arrival.AddHours(double.Parse(arrivalTime));

            Reservation res = new Reservation();
            res.school = txtSchoolName.Text;
            res.schoolPhone = txtSchoolPhone.Text;
            res.fax = txtSchoolFax.Text;
            res.address = txtSchoolAddress.Text;
            res.city = txtSchoolCity.Text;
            res.zip = txtSchoolZip.Text;
            res.lname = txtLastName.Text;
            res.fname = txtFirstName.Text;
            res.email = txtEmail.Text;
            res.title = txtTitle.Text;
            res.cell = txtCellPhone.Text;
            res.athleticDir = txtAthleticDir.Text;
            res.coach = txtCoach.Text;
            res.password = Security.EncryptString(txtPassword.Text, Settings.PassPhrase);
            res.arrival = arrival;
            res.specNeeds = rblSpecNeeds.SelectedValue == "1" ? true : false;
            res.hallPref = Convert.ToInt32(rblHallPref.SelectedValue);
            //res.specNeedsRooms = Convert.ToInt32(txtSpecNeedsRooms.Text);

            // Do not allow the application to continue if that email has already been used.
            if (SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName FROM WiaaSchoolReservations WHERE ContactEmail = '" + res.email + "' AND Year = " + Settings.Year + "") != null)
            {
                Security.ShowAlertMessage("That email address has already been used to fill out an application.");
            }
            else
            {
                Session["CurrentApp"] = res;
                Response.Redirect("application.aspx?page=1");
            }
        }
    }

    /// <summary>
    /// Redirects to the final page of the application.
    /// </summary>
    protected void btnNextFinalize_Click(object sender, EventArgs e)
    {
        Reservation res = (Reservation)Session["CurrentApp"];
        res.mst = int.Parse(txtMST.Text);
        res.msf = int.Parse(txtMSF.Text);
        res.fst = int.Parse(txtFST.Text);
        res.fsf = int.Parse(txtFSF.Text);
        res.mdt = int.Parse(txtMDT.Text);
        res.mdf = int.Parse(txtMDF.Text);
        res.fdt = int.Parse(txtFDT.Text);
        res.fdf = int.Parse(txtFDF.Text);
        res.specNeedsRoomsT = int.Parse(txtSpecNeedsT.Text);
        res.specNeedsRoomsF = int.Parse(txtSpecNeedsF.Text);
        Session["CurrentApp"] = res;
        Response.Redirect("application.aspx?page=2");
    }

    /// <summary>
    /// Saves a reservation to the database.
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Reservation res = (Reservation)Session["CurrentApp"];
        res.SaveReservation();
        Response.Redirect("confirmation.aspx");
    }


    /// <summary>
    /// Repopulates the arrival time dropdown based on the day chosen.
    /// </summary>
    protected void ddlArrivalDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlArrivalDay.SelectedValue == "Thursday")
        {
            ddlArrivalTime.Items.Clear();
            ddlArrivalTime.Items.Add(new ListItem("", null));
            ddlArrivalTime.Items.Add(new ListItem("3:00 PM", "15"));
            ddlArrivalTime.Items.Add(new ListItem("4:00 PM", "16"));
            ddlArrivalTime.Items.Add(new ListItem("5:00 PM", "17"));
            ddlArrivalTime.Items.Add(new ListItem("6:00 PM", "18"));
            ddlArrivalTime.Items.Add(new ListItem("7:00 PM", "19"));
            ddlArrivalTime.Items.Add(new ListItem("8:00 PM", "20"));
            ddlArrivalTime.Items.Add(new ListItem("9:00 PM", "21"));
            ddlArrivalTime.Items.Add(new ListItem("10:00 PM", "22"));
            ddlArrivalTime.Items.Add(new ListItem("11:00 PM", "23"));
            //ddlArrivalTime.Items.Add(new ListItem("12:00 AM", "24")); Currently removed as per Deb.
        }
        else
        {
            ddlArrivalTime.Items.Clear();
            ddlArrivalTime.Items.Add(new ListItem("", null));
            ddlArrivalTime.Items.Add(new ListItem("8:00 AM", "8"));
            ddlArrivalTime.Items.Add(new ListItem("9:00 AM", "9"));
            ddlArrivalTime.Items.Add(new ListItem("10:00 AM", "10"));
            ddlArrivalTime.Items.Add(new ListItem("11:00 AM", "11"));
            ddlArrivalTime.Items.Add(new ListItem("12:00 PM", "12"));
            ddlArrivalTime.Items.Add(new ListItem("1:00 PM", "13"));
            ddlArrivalTime.Items.Add(new ListItem("2:00 PM", "14"));
        }
    }
}