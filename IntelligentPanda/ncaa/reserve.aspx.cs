using Rlis.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ncaa_reserve : System.Web.UI.Page
{
    private bool includeTriples;
    private bool includeStudies;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(2))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            //Note that the order upon which these functions are called, is important
            Common.populateNcaaSchoolDropDown(schoolDropDown);
            initPageSettings();
        }
        loadRoomsAvailable();
        if (schoolDropDown.SelectedValue == "-1" && Session["NCAAPanel"] != null)
        {
            Control c = UpdatePanel1.FindControl(Session["NCAAPanel"].ToString());
            Panel lastPanel = (Panel)c;
            lastPanel.Visible = true;
        }

        Session["Gender"] = rdbGender.SelectedValue;
        try
        {
            Session["Beds"] = Int32.Parse(ddlBeds.SelectedValue);
        }
        catch (Exception)
        {
            Session["Beds"] = 1;
        }
    }

    /// <summary>
    /// Determines the rooms available for every hall and updates the totals at the top of the page.
    /// The number will change color depending on availability.
    /// > 50 rooms = Blue. < 50 && > 20 = Green. < 20 = Red.
    /// </summary>
    private void loadRoomsAvailable()
    {
        int reuter = ReserveHelper.getTotalAvailableRoomsNcaa("Reuter");
        if (reuter < 50 && reuter > 20)
            reuterCountLabel.ForeColor = System.Drawing.Color.Green;
        if (reuter < 20)
            reuterCountLabel.ForeColor = System.Drawing.Color.Red;
        reuterCountLabel.Text = reuter.ToString();

        int eagle = ReserveHelper.getTotalAvailableRoomsNcaa("Eagle");
        if (eagle < 50 && eagle > 20)
            eagleCountLabel.ForeColor = System.Drawing.Color.Green;
        if (eagle < 20)
            eagleCountLabel.ForeColor = System.Drawing.Color.Red;
        eagleCountLabel.Text = eagle.ToString();
    }

    /// <summary>
    /// Initialize the page load settings - mainly to determine if someone was redirected here after clicking the
    /// recommend button. If they were, the url will contain various parameters.
    /// </summary>
    private void initPageSettings()
    {
        if (Request.Url.ToString().Contains("roomsNeeded"))
        {
            schoolDropDown.SelectedItem.Selected = false;
            HallDropDown.SelectedItem.Selected = false;
            string school = Request.QueryString["school"].ToString();
            schoolDropDown.Items.FindByText(Request.QueryString["school"].ToString()).Selected = true;
            HallDropDown.Items.FindByText(Request.QueryString["hall"].ToString()).Selected = true;
            refresh(school);
        }
        //We do this because we want to keep the previous panel still visible
        if (Session["NCAAPanel"] != null)
        {
            Control c = UpdatePanel1.FindControl(Session["NCAAPanel"].ToString());
            Panel lastPanel = (Panel)c;
            lastPanel.Visible = true;
        }
    }

    protected void HallDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string hall = HallDropDown.Text;
        Session["Hall"] = hall;
        if (Session["NCAAPanel"] != null)
        {
            Control c = UpdatePanel1.FindControl(Session["NCAAPanel"].ToString());
            Panel lastPanel = (Panel)c;
            lastPanel.Visible = false;
        }
        Control con = UpdatePanel1.FindControl("pnl" + hall + "1");
        Panel panel = (Panel)con;
        if (con == null)
        {
            Session["NCAAPanel"] = null;
            return;
        }
        panel.Visible = true;
        Session["NCAAPanel"] = panel.ID.ToString();
    }

    protected void schoolDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["School"] = schoolDropDown.SelectedItem.Text;
            refresh(Session["School"].ToString());
            getRoomsNeeded();
        }
        catch
        {
            Response.Redirect("reserve.aspx");
        }
    }

    /// <summary>
    /// Refresh the text boxes which state how many rooms of that type are needed
    /// </summary>
    /// <param name="school">The school for which the textboxes info is coming from</param>
    private void refresh(string school)
    {
        NcaaReservation res = new NcaaReservation(schoolDropDown.SelectedValue.ToString());
        txtComments.Text = res.comments;
        lblHallPreference.Text = res.hallpref;
        txtMaleEagleSingle.Text = res.msingles.ToString();
        txtMaleEagleDouble.Text = res.mdoubles.ToString();
        txtFemaleEagleSingle.Text = res.fsingles.ToString();
        txtFemaleEagleDouble.Text = res.fdoubles.ToString();
        txtSuites.Text = res.suites.ToString();
        txtTotalRoom.Text = getRoomsNeeded().ToString();
    }

    /// <summary>
    /// This will get the total rooms needed.
    /// </summary>
    /// <returns>Rooms needed</returns>
    private int getRoomsNeeded()
    {
        int msingles = int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT MaleSingles FROM ReservationsView WHERE DisplayName = '" + Session["School"].ToString() + "' and Year = " + Settings.Year + "").ToString());

        int mdoubles = int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT MaleDoubles FROM ReservationsView WHERE DisplayName = '" + Session["School"].ToString() + "' and Year = " + Settings.Year + "").ToString());

        int fsingles = int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT FemaleSingles FROM ReservationsView WHERE DisplayName = '" + Session["School"].ToString() + "' and Year = " + Settings.Year + "").ToString());

        int fdoubles = int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT FemaleDoubles FROM ReservationsView WHERE DisplayName = '" + Session["School"].ToString() + "' and Year = " + Settings.Year + "").ToString());

        int suites = int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT Suites FROM ReservationsView WHERE DisplayName = '" + Session["School"].ToString() + "' and Year = " + Settings.Year + "").ToString());

        int rooms = msingles + mdoubles + fsingles + fdoubles + suites;
        return rooms;
    }

    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        Response.Redirect("reserve.aspx?school=" + schoolDropDown.Text + "&hall=" + HallDropDown.Text + "&roomsNeeded=" + getRoomsNeeded() + "&triples=" + Session["Triples"].ToString() + "&studies=" + Session["Studies"].ToString());
    }

    protected void btnReview_Click(object sender, EventArgs e)
    {
        List<string> clickedRooms = ((List<string>)Session["RoomsClicked"]);
        if (clickedRooms == null)
        {
            clickedRooms = new List<string>();
        }
        List<string> displayRooms = new List<string>();
        foreach (string room in clickedRooms)
        {
            string[] tokens = room.Split(':');
            string gender = tokens[1] == "f" ? "female" : "male";
            int beds = Int32.Parse(tokens[2]);
            string bedString = beds > 1 ? " beds" : " bed";
            displayRooms.Add(tokens[0] + " - " + gender + ", " + beds + bedString);
        }
        displayRooms.Sort();
        txtReservations.Text = string.Join(",\n", displayRooms.ToArray());
        string roomsText = string.Join(",", clickedRooms.ToArray());
        Session["Rooms"] = roomsText;
        btnAccept.Visible = true;
        pReserve.Visible = true;
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        if (schoolDropDown.Text == "-1")
        {
            Security.ShowAlertMessage("Please select a school!");
            return;
        }

        List<string> clickedRooms = ((List<string>)Session["RoomsClicked"]);
        if (clickedRooms == null)
        {
            clickedRooms = new List<string>();
        }
        int totalClicked = clickedRooms.Count;
        Regex eagle = new Regex(".*[a-bA-B]");

        string[] roomsToReserve = Session["Rooms"].ToString().Split(',');
        foreach (string s in roomsToReserve)
        {
            if (s == "") continue;
            string[] tokens = s.Split(':');
            string room = tokens[0];
            string gender = tokens[1];
            string beds = tokens[2];
            string hall = eagle.IsMatch(room) ? "Eagle" : "Reuter";
            SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "EXECUTE dbo.InsertReservation '" + hall + "', '" + room + "', '" + schoolDropDown.Text + "', '" + gender + "', " + beds);
        }
        Session["NcaaEmail"] = schoolDropDown.Text;
        Response.Redirect("Receipts/housing.aspx");
        //}
    }

    protected void rdbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Gender"] = ((RadioButtonList)sender).SelectedValue;
    }

    protected void ddlBeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Beds"] = Int32.Parse(((DropDownList)sender).SelectedValue);
    }
}