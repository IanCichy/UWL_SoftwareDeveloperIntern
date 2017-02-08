using FDS;
using System;
using System.Drawing;

public partial class Options : System.Web.UI.Page
{
    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: validates hall and username as well as loading the current hall message to display.
     * redirects based on failed parameter
     */

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }

        var employee = Employee.GetEmployeeByEagleId(String.Format("{0}", Session["username"]));
        if (employee == null)
        {
            Session["warning"] = "You must be logged in to do this.";
            Response.Redirect("login.aspx");
            return;
        }

        //Removes the changeHall button if only one hall is available to the employee
        var halls = employee.IsAdmin() ? Hall.GetAllHalls() : employee.GetDCOfHalls();
        if (halls.Count == 1)
        {
            btnChangeHall.Enabled = false;
            btnChangeHall.Visible = false;
        }

        //Loads the hall message and date from the most current message update
        if (!IsPostBack)
        {
            txtMOTD.Text = FDS.Options.GetMessage(Hall.GetHallById(int.Parse(Session["hall"].ToString())));
            lblDateUpdated.Text = "Last Updated: " + FDS.Options.GetMessageDate(Hall.GetHallById(int.Parse(Session["hall"].ToString())));
        }
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Updates the Message of the day for the respective hall
     * Checks to see the message is less than  1024 characters else prints error message
     * date and username of DC are also recorded
     */

    protected void btnUpdateMOTD_Click(object sender, EventArgs e)
    {
        if (txtMOTD.Text.Length < 1024)
        {
            FDS.Options.UpdateMessage(Hall.GetHallById(int.Parse(Session["hall"].ToString())), txtMOTD.Text, Session["username"].ToString(), DateTime.Now);
            txtMOTD.Text = FDS.Options.GetMessage(Hall.GetHallById(int.Parse(Session["hall"].ToString())));
            lblDateUpdated.Text = FDS.Options.GetMessageDate(Hall.GetHallById(int.Parse(Session["hall"].ToString())));
            lblDateUpdated.BackColor = Color.AntiqueWhite;
        }
        else
        {
            Session["warning"] = "Your message is " + txtMOTD.Text.Length + " characters long. The maximum allowed is 1024.";
            Response.Redirect(Request.RawUrl);
        }
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Redirect to the choose hall page
     */

    protected void btnChangeHall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChooseHall.aspx");
    }
}