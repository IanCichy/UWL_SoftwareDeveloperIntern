using Rlis.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wiaa_reserve : System.Web.UI.Page
{
    private bool includeTriples;
    private bool includeStudies;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(1))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            //Note that the order upon which these functions are called, is important
            Common.populateWiaaSchoolDropDown(schoolDropDown);
            updateSelectedOptions();
            initPageSettings();
        }

        loadRoomsAvailable();
    }

    /// <summary>
    /// Initialize the page load settings - mainly to determine if someone was redirected here after
    /// clicking the recommend button. If they were, the url will contain various parameters.
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
        if (Request.Url.ToString().Contains("triples"))
        {
            bool studiesVisible = bool.Parse(Request.QueryString["studies"].ToString());
            bool triplesVisible = bool.Parse(Request.QueryString["triples"].ToString());
            ToggleCheckBox.Items.FindByText("Triples").Selected = triplesVisible;
            ToggleCheckBox.Items.FindByText("Studies").Selected = studiesVisible;
            MaleTriple.Visible = triplesVisible;
            FemaleTriple.Visible = triplesVisible;
            MaleStudy.Visible = studiesVisible;
            FemaleStudy.Visible = studiesVisible;
        }
        //We do this because we want to keep the previous panel still visible
        if (schoolDropDown.SelectedValue != "-1" && Session["Panel"] != null)
        {
            Control c = UpdatePanel1.FindControl(Session["Panel"].ToString());
            Panel lastPanel = (Panel)c;
            lastPanel.Visible = true;
        }
    }

    /// <summary> Determines the rooms available for every hall and updates the totals at the top of
    /// the page. The number will change color depending on availability. > 50 rooms = Blue. < 50 &&
    /// > 20 = Green. < 20 = Red. </summary>
    private void loadRoomsAvailable()
    {
        int sanford = ReserveHelper.getTotalAvailableRoomsWiaa("Sanford");
        if (sanford > 50)
            sanfordCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (sanford <= 50 && sanford > 20)
            sanfordCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (sanford <= 20)
            sanfordCountLabel.ForeColor = System.Drawing.Color.Red;
        if (sanford == 0)
            sanfordCountLabel.ForeColor = System.Drawing.Color.Gray;
        sanfordCountLabel.Text = sanford.ToString();

        int white = ReserveHelper.getTotalAvailableRoomsWiaa("White");
        if (white > 50)
            whiteCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (white <= 50 && white > 20)
            whiteCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (white <= 20)
            whiteCountLabel.ForeColor = System.Drawing.Color.Red;
        if (white == 0)
            whiteCountLabel.ForeColor = System.Drawing.Color.Gray;
        whiteCountLabel.Text = white.ToString();

        int angell = ReserveHelper.getTotalAvailableRoomsWiaa("Angell");
        if (angell > 50)
            angellCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (angell <= 50 && angell > 20)
            angellCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (angell <= 20)
            angellCountLabel.ForeColor = System.Drawing.Color.Red;
        if (angell == 0)
            angellCountLabel.ForeColor = System.Drawing.Color.Gray;
        angellCountLabel.Text = angell.ToString();

        int coate = ReserveHelper.getTotalAvailableRoomsWiaa("Coate");
        if (coate > 50)
            coateCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (coate <= 50 && coate > 20)
            coateCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (coate <= 20)
            coateCountLabel.ForeColor = System.Drawing.Color.Red;
        if (coate == 0)
            coateCountLabel.ForeColor = System.Drawing.Color.Gray;
        coateCountLabel.Text = coate.ToString();

        int drake = ReserveHelper.getTotalAvailableRoomsWiaa("Drake");
        if (drake > 50)
            drakeCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (drake <= 50 && drake > 20)
            drakeCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (drake <= 20)
            drakeCountLabel.ForeColor = System.Drawing.Color.Red;
        if (drake == 0)
            drakeCountLabel.ForeColor = System.Drawing.Color.Gray;
        drakeCountLabel.Text = drake.ToString();

        int hutch = ReserveHelper.getTotalAvailableRoomsWiaa("Hutchison");
        if (hutch > 50)
            hutchCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (hutch <= 50 && hutch > 20)
            hutchCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (hutch <= 20)
            hutchCountLabel.ForeColor = System.Drawing.Color.Red;
        if (hutch == 0)
            hutchCountLabel.ForeColor = System.Drawing.Color.Gray;
        hutchCountLabel.Text = hutch.ToString();

        int laux = ReserveHelper.getTotalAvailableRoomsWiaa("Laux");
        if (laux > 50)
            lauxCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (laux <= 50 && drake > 20)
            lauxCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (laux <= 20)
            lauxCountLabel.ForeColor = System.Drawing.Color.Red;
        if (laux == 0)
            lauxCountLabel.ForeColor = System.Drawing.Color.Gray;
        lauxCountLabel.Text = laux.ToString();

        int reuter = ReserveHelper.getTotalAvailableRoomsWiaa("Reuter");
        if (reuter > 50)
            reuterCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (reuter <= 50 && reuter > 20)
            reuterCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (reuter <= 20)
            reuterCountLabel.ForeColor = System.Drawing.Color.Red;
        if (reuter == 0)
            reuterCountLabel.ForeColor = System.Drawing.Color.Gray;
        reuterCountLabel.Text = reuter.ToString();

        int wentz = ReserveHelper.getTotalAvailableRoomsWiaa("Wentz");
        if (wentz > 50)
            wentzCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (wentz <= 50 && wentz > 20)
            wentzCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (wentz <= 20)
            wentzCountLabel.ForeColor = System.Drawing.Color.Red;
        if (wentz == 0)
            wentzCountLabel.ForeColor = System.Drawing.Color.Gray;
        wentzCountLabel.Text = wentz.ToString();

        int eagle = ReserveHelper.getTotalAvailableRoomsWiaa("Eagle");
        if (eagle > 50)
            eagleCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        if (eagle <= 50 && eagle > 20)
            eagleCountLabel.ForeColor = System.Drawing.Color.Orange;
        if (eagle <= 20)
            eagleCountLabel.ForeColor = System.Drawing.Color.Red;
        if (eagle == 0)
            eagleCountLabel.ForeColor = System.Drawing.Color.Gray;
        eagleCountLabel.Text = eagle.ToString();
    }

    protected void HallDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string hall = HallDropDown.Text;
        Session["Hall"] = hall;
        if (Session["Panel"] != null)
        {
            Control c = UpdatePanel1.FindControl(Session["Panel"].ToString());
            Panel lastPanel = (Panel)c;
            lastPanel.Visible = false;
        }
        Control con = UpdatePanel1.FindControl("pnl" + hall + "1");
        Panel panel = (Panel)con;
        panel.Visible = true;
        Session["Panel"] = panel.ID.ToString();
    }

    protected void schoolDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["School"] = schoolDropDown.SelectedItem.Text;
            refresh(Session["School"].ToString());
            getRoomsNeeded();

            int roomsReserved = Int32.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT COUNT(School) FROM [wiaa].[dbo].[ReservedRooms] WHERE School = @school".ToString(), new SqlParameter("@school", Session["School"].ToString())).ToString());
            //If school has reservations, display the print button
            if (roomsReserved > 0)
            {
                btnPrint.Visible = true;
                pExistingReservations.Visible = true;
                var roomsReader = SqlHelper.ExecuteReader(Settings.WIAAConnection, CommandType.Text, "SELECT Room FROM [wiaa].[dbo].[ReservedRooms] WHERE School = @school ORDER BY Room", new SqlParameter("@school", Session["School"].ToString()));
                roomsReader.Read();
                string r = roomsReader.GetString(0);

                var genderReader = SqlHelper.ExecuteReader(Settings.WIAAConnection, CommandType.Text, "SELECT (case when Gender is null then '' else Gender END) FROM [wiaa].[dbo].[ReservedRooms] WHERE School = @school ORDER BY Room", new SqlParameter("@school", Session["School"].ToString()));
                genderReader.Read();
                string s = genderReader.GetString(0);

                String list = "";

                list = r + " " + s;
                while (roomsReader.Read() && genderReader.Read())
                {
                    list += "," + roomsReader.GetString(0) + " " + genderReader.GetString(0);
                }

                Session["Rooms"] = list;
                Session["Hall"] = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT HallAssignment FROM [wiaa].[dbo].[WiaaSchoolReservations] WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString();
            }
            else
            {
                btnPrint.Visible = false;
                pExistingReservations.Visible = false;
            }
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
        school = school.Trim();
        txtMST.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtMDT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtMTT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtMSF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtMDF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtMTF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFST.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFDT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFTT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFSF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFDF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtFTF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtStudyMT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtStudyMF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtStudyFT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtStudyFF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleMST.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleMSF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleMDT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleMDF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleFST.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleFSF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleFDT.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtEagleFDF.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
        txtTotalRoom.Text = getRoomsNeeded().ToString();
        txtComment.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Comment FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", school), new SqlParameter("@year", Settings.Year)).ToString();
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateSelectedOptions();
    }

    /// <summary>
    /// Updates the room types being shown based on whether or not the Triples or Studies check
    /// boxes are selected.
    /// </summary>
    private void updateSelectedOptions()
    {
        //TODO: Make it so when visible=false also set those text boxes to 0, in case user tries an update
        foreach (ListItem item in ToggleCheckBox.Items)
        {
            if (item.Selected == false)
            {
                if (item.Text == "Triples")
                {
                    //MaleTriple.Visible = false; //Made visible initially and kept visible for less confusion
                    //FemaleTriple.Visible = false;
                    includeTriples = false;
                }
                if (item.Text == "Studies")
                {
                    //MaleStudy.Visible = false; //Made visible initially and kept visible for less confusion
                    //FemaleStudy.Visible = false;
                    includeStudies = false;
                }
            }
            else if (item.Selected == true)
            {
                if (item.Text == "Triples")
                {
                    MaleTriple.Visible = true;
                    FemaleTriple.Visible = true;
                    includeTriples = true;
                }
                if (item.Text == "Studies")
                {
                    MaleStudy.Visible = true;
                    FemaleStudy.Visible = true;
                    includeStudies = true;
                }
            }
        }
        Session["Triples"] = includeTriples;
        Session["Studies"] = includeStudies;
    }

    /// <summary>
    /// This will get the total rooms needed.
    /// </summary>
    /// <returns>Rooms needed</returns>
    private int getRoomsNeeded()
    {
        int mSingles;
        int mst = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int msf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (mst < msf)
            mSingles = msf;
        else mSingles = mst;

        int mDoubles;
        int mdt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int mdf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (mdt < mdf)
            mDoubles = mdf;
        else mDoubles = mdt;

        int mTriples;
        int mtt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int mtf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (mtt < mtf)
            mTriples = mtf;
        else mTriples = mtt;

        int fSingles;
        int fst = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int fsf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (fst < fsf)
            fSingles = fsf;
        else fSingles = fst;

        int fDoubles;
        int fdt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int fdf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (fdt < fdf)
            fDoubles = fdf;
        else fDoubles = fdt;

        int fTriples;
        int ftt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int ftf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (ftt < ftf)
            fTriples = ftf;
        else fTriples = ftt;

        int mStudies;
        int MStudyT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int MStudyF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (MStudyT < MStudyF)
            mStudies = MStudyF;
        else mStudies = MStudyT;

        int fStudies;
        int FStudyT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int FStudyF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (FStudyT < FStudyF)
            fStudies = FStudyF;
        else fStudies = FStudyT;

        int MEagleSingles;
        int MEagleST = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int MEagleSF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (MEagleST < MEagleSF)
            MEagleSingles = MEagleSF;
        else MEagleSingles = MEagleST;

        int MEagleDoubles;
        int MEagleDT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int MEagleDF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (MEagleDT < MEagleDF)
            MEagleDoubles = MEagleDF;
        else MEagleDoubles = MEagleDT;

        int FEagleSingles;
        int FEagleST = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int FEagleSF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (FEagleST < FEagleSF)
            FEagleSingles = FEagleSF;
        else FEagleSingles = FEagleST;

        int FEagleDoubles;
        int FEagleDT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        int FEagleDF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school AND Year = @year", new SqlParameter("@school", Session["School"].ToString()), new SqlParameter("@year", Settings.Year)).ToString());
        if (FEagleDT < FEagleDF)
            FEagleDoubles = FEagleDF;
        else FEagleDoubles = FEagleDT;

        int rooms = mSingles + mDoubles + mTriples + fSingles + fDoubles + fTriples + mStudies + fStudies + MEagleSingles + MEagleDoubles + FEagleDoubles + FEagleSingles;
        return rooms;
    }

    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        Response.Redirect("reserve.aspx?school=" + schoolDropDown.SelectedItem.Text + "&hall=" + HallDropDown.Text + "&roomsNeeded=" + getRoomsNeeded() + "&triples=" + Session["Triples"].ToString() + "&studies=" + Session["Studies"].ToString());
    }

    protected void btnReview_Click(object sender, EventArgs e)
    {
        List<string> clickedRooms = ((List<string>)Session["RoomsClicked"]);
        clickedRooms.Sort();
        txtReservations.Text = string.Join(",", clickedRooms.ToArray());
        Session["Rooms"] = txtReservations.Text;
        txtSelected.Text = clickedRooms.Count.ToString();
        if (clickedRooms.Count.ToString().Equals(txtTotalRoom.Text.ToString()))
        {
            txtSelected.BackColor = System.Drawing.Color.LimeGreen;
            btnAccept.Enabled = true;
        }
        else
        {
            txtSelected.BackColor = System.Drawing.Color.Red;
            btnAccept.Enabled = false;
        }
        btnAccept.Visible = true;
        pReserve.Visible = true;
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        List<string> clickedRooms = ((List<string>)Session["RoomsClicked"]);
        int totalClicked = clickedRooms.Count;
        if (int.Parse(txtTotalRoom.Text) != totalClicked)
        {
            Security.ShowAlertMessage("The number of rooms that " + schoolDropDown.SelectedItem.Text + " needs, does not match the number you are trying to reserve.");
        }
        else
        {
            string[] roomsToReserve = txtReservations.Text.Split(',');
            foreach (string s in roomsToReserve)
            {
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE ReservedRooms SET Reserved = 1, School = @school WHERE Hall = @hall AND Room = @room", new SqlParameter("@school", schoolDropDown.SelectedItem.Text), new SqlParameter("@hall", HallDropDown.Text), new SqlParameter("@room", s));
                SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET HallAssignment = @hall WHERE SchoolName = @school AND Year = @year", new SqlParameter("@hall", HallDropDown.Text), new SqlParameter("@school", schoolDropDown.SelectedItem.Text), new SqlParameter("@year", Settings.Year));
            }
            Response.Redirect("Receipts/housing.aspx");
        }
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET Comment = '" + txtComment.Text.Replace("'", "''") + "' WHERE ContactEmail = '" + schoolDropDown.SelectedItem.Value.ToString() + "' AND Year = " + Settings.Year + "");
        Security.ShowAlertMessage("Comment updated!");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receipts/housing.aspx");
    }
}