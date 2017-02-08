using Rlis.Sql;
using System;
using System.Data;
using System.Web.UI;

public partial class wiaa_reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(2))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        DataSet reservations = SqlHelper.ExecuteDataset(Settings.PandaConnection, CommandType.Text, "SELECT * FROM ncaa.dbo.ReservationInfo order by Role, LName");
        gridReservations.DataSource = reservations;
        gridReservations.DataBind();

        DataSet contactInfo = SqlHelper.ExecuteDataset(Settings.PandaConnection, CommandType.Text, "SELECT * FROM ncaa.dbo.ContactInformation order by Role, LName");
        gridContact.DataSource = contactInfo;
        gridContact.DataBind();

        DataSet roomsReserved = SqlHelper.ExecuteDataset(Settings.PandaConnection, CommandType.Text,
            @"SELECT
	            rm.Hall,
	            rm.Room,
	            ISNULL(rm.Gender,' ') AS Gender,
	            ra.Beds,
	            r.FName + ' ' + r.LName AS Name,
	            r.School,
	            r.Email
            FROM ncaa.dbo.Rooms rm
	        JOIN ncaa.dbo.RoomAssignments ra
		        ON rm.Hall=ra.Hall AND rm.Room=ra.Room
	        JOIN ncaa.dbo.Reservations r
		        ON ra.School = r.Email");
        gridRoomsReserved.DataSource = roomsReserved;
        gridRoomsReserved.DataBind();
    }

    //Will export the grid view into an excel file
    protected void exportButton_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition",
        "attachment;filename=NCAA_" + rblReport.SelectedItem.Text + ".xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than
        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //Whenever you add a new GridView, you must add another else if here:

        if (Session["Grid"].ToString() == "gridReservations")
        {
            gridReservations.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "gridContact")
        {
            gridContact.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "gridRoomsReserved")
        {
            gridRoomsReserved.RenderControl(htmlWrite);
        }

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String selected = rblReport.SelectedValue.ToString();
        Session["Selected"] = selected;
    }

    //The case number refers to the value of the radio button that is clicked. The first one
    //has a value of 0, second has a value of 1, etc. You will have to be sure to give each new
    //option a value, and then add a new case for that value.
    protected void generateButton_Click(object sender, EventArgs e)
    {
        int panel = int.Parse(Session["Selected"].ToString());
        switch (panel)
        {
            case 0: pnlReservations.Visible = true;
                pnlContactInfo.Visible = false;
                pnlRoomsReserved.Visible = false;
                Session["Grid"] = "gridReservations";
                goto default;
            case 1: pnlContactInfo.Visible = true;
                pnlReservations.Visible = false;
                pnlRoomsReserved.Visible = false;
                Session["Grid"] = "gridContact";
                goto default;
            case 2: pnlRoomsReserved.Visible = true;
                pnlContactInfo.Visible = false;
                pnlReservations.Visible = false;
                Session["Grid"] = "gridRoomsReserved";
                goto default;
            default: break;
        }
    }
}