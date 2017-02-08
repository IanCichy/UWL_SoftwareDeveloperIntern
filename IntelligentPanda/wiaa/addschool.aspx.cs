using Rlis.Sql;
using System;
using System.Data;
using System.Web.UI;

public partial class wiaa_addschool : System.Web.UI.Page
{
    private String arrivalDate, arrivalString, schoolName, password, phone, fax, address, city, zip,
        fname, lname, title, email, director, coach, mst, mdt, mtt, fst, fdt, ftt, msf, mdf, mtf, fsf, fdf, ftf,
        thursdate, fridate, mStudyT, mStudyF, fStudyT, fStudyF, mEagleST, mEagleSF, mEagleDT, mEagleDF, fEagleST, fEagleSF, fEagleDT, fEagleDF;

    private String[] friArr, thurArr;

    protected void Page_Load(object sender, EventArgs e)
    {
        submitButton.Enabled = true;

        if (!Account.hasRights(1))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!Page.IsPostBack)
        {
            mstTextBox.Text = "0";
            mdtTextBox.Text = "0";
            mttTextBox.Text = "0";
            fstTextBox.Text = "0";
            fdtTextBox.Text = "0";
            fttTextBox.Text = "0";
            msfTextBox.Text = "0";
            mdfTextBox.Text = "0";
            mtfTextBox.Text = "0";
            fsfTextBox.Text = "0";
            fdfTextBox.Text = "0";
            ftfTextBox.Text = "0";
            mStudyTTextBox.Text = "0";
            mStudyFTextBox.Text = "0";
            fStudyFTextBox.Text = "0";
            fStudyTTextBox.Text = "0";
            mESingleTTextBox.Text = "0";
            mESingleFTextBox.Text = "0";
            mEDoubleTTextBox.Text = "0";
            mEDoubleFTextBox.Text = "0";
            fESingleTTextBox.Text = "0";
            fESingleFTextBox.Text = "0";
            fEDoubleTTextBox.Text = "0";
            fEDoubleFTextBox.Text = "0";
        }

        thursdate = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Date FROM Dates WHERE Day = 'Thursday'").ToString();
        fridate = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Date FROM Dates WHERE Day = 'Friday'").ToString();
        char[] split = { ' ' };
        thurArr = thursdate.Split(split);
        friArr = fridate.Split(split);
    }

    /// <summary>
    /// Adds a new school into the WiaaSchoolReservations table.
    /// </summary>
    private void submitSchool()
    {
        schoolName = schoolNameTextBox.Text;
        password = passwordTextBox.Text;
        phone = phoneNumberTextBox.Text;
        fax = faxTextBox.Text;
        address = addressTextBox.Text;
        city = cityTextBox.Text;
        zip = zipTextBox.Text;
        fname = firstNameTextBox.Text;
        lname = lastNameTextBox.Text;
        title = contactTitleTextBox.Text;
        email = contactEmailTextBox.Text;
        director = athleticDirectorTextBox.Text;
        coach = coachNameTextBox.Text;
        mst = mstTextBox.Text;
        mdt = mdtTextBox.Text;
        mtt = mttTextBox.Text;
        fst = fstTextBox.Text;
        fdt = fdtTextBox.Text;
        ftt = fttTextBox.Text;
        msf = msfTextBox.Text;
        mdf = mdfTextBox.Text;
        mtf = mtfTextBox.Text;
        fsf = fsfTextBox.Text;
        fdf = fdfTextBox.Text;
        ftf = ftfTextBox.Text;
        mStudyT = mStudyTTextBox.Text;
        mStudyF = mStudyFTextBox.Text;
        fStudyT = fStudyTTextBox.Text;
        fStudyF = fStudyFTextBox.Text;
        mEagleST = mESingleTTextBox.Text;
        mEagleSF = mESingleFTextBox.Text;
        mEagleDT = mEDoubleTTextBox.Text;
        mEagleDF = mEDoubleFTextBox.Text;
        fEagleST = fESingleTTextBox.Text;
        fEagleSF = fESingleFTextBox.Text;
        fEagleDT = fEDoubleTTextBox.Text;
        fEagleDF = fEDoubleFTextBox.Text;
        if (expectedDayDropDown.SelectedItem.Text == "Thursday")
            arrivalDate = thurArr[0];
        else if (expectedDayDropDown.SelectedItem.Text == "Friday")
            arrivalDate = friArr[0];
        if (arrivalDate != null)
            arrivalString = arrivalDate + " " + expectedArrivalDropDown.Text;
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "INSERT INTO WiaaSchoolReservations (SchoolName, Password, Phone, Fax, Address, City, Zip, ContactFName, ContactLName, ContactTitle, ContactEmail, AthleticDirectorName, CoachName,MST, MSF, FST, FSF, MDT, MDF, FDT, FDF,MTT, MTF, FTT, FTF, ExpectedArrival, Year, MStudyT, MStudyF, FStudyT, FStudyF, MEagleST, MEagleSF, MEagleDT, MEagleDF, FEagleST, FEagleSF, FEagleDT, FEagleDF) VALUES('" + schoolName + "','" + password + "','" + phone + "','" + fax + "','" + address + "','" + city + "','" + zip + "','" + fname + "','" + lname + "','" + title + "','" + email + "','" + director + "','" + coach + "'," + mst + "," + msf + "," + fst + "," + fsf + "," + mdt + "," + mdf + "," + fdt + "," + fdf + "," + mtt + "," + mtf + "," + ftt + "," + ftf + ",'" + arrivalString + "','" + Settings.Year + "'," + mStudyT + "," + mStudyF + "," + fStudyT + "," + fStudyF + "," + mEagleST + "," + mEagleSF + "," + mEagleDT + "," + mEagleDF + "," + fEagleST + "," + fEagleSF + "," + fEagleDT + "," + fEagleDF + ")");
    }

    /// <summary>
    /// Checks to make sure all the fields are filled out, then calls submitSchool().
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void submitButton_Click(object sender, EventArgs e)
    {
        submitButton.Enabled = false;
        if (validate())
        {
            submitSchool();
            submitButton.Enabled = true;
            Response.Redirect("addschool.aspx");
        }
    }

    /// <summary>
    /// Validates all fields.
    /// </summary>
    /// <returns>Returns true if all required fields are filled out.</returns>
    private bool validate()
    {
        if (schoolNameTextBox.Text == "" || passwordTextBox.Text == "" || phoneNumberTextBox.Text == ""
            || faxTextBox.Text == "" || addressTextBox.Text == "" || cityTextBox.Text == "" ||
            zipTextBox.Text == "" || firstNameTextBox.Text == "" || lastNameTextBox.Text == "" ||
            contactTitleTextBox.Text == "" || contactEmailTextBox.Text == "" ||
            athleticDirectorTextBox.Text == "" || coachNameTextBox.Text == "" ||
            expectedArrivalDropDown.Text == "" || expectedDayDropDown.Text == "")
        {
            Security.ShowAlertMessage("You must fill out every field in order to submit the information.");
            return false;
        }
        return true;
    }

    /// <summary>
    /// When the expected day is changed, changes the times.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void expectedDayDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (expectedDayDropDown.Text == "Thursday")
        {
            expectedArrivalDropDown.Items.Clear();
            expectedArrivalDropDown.Items.Add("3:00 PM");
            expectedArrivalDropDown.Items.Add("4:00 PM");
            expectedArrivalDropDown.Items.Add("5:00 PM");
            expectedArrivalDropDown.Items.Add("6:00 PM");
            expectedArrivalDropDown.Items.Add("7:00 PM");
            expectedArrivalDropDown.Items.Add("8:00 PM");
            expectedArrivalDropDown.Items.Add("9:00 PM");
            expectedArrivalDropDown.Items.Add("10:00 PM");
            expectedArrivalDropDown.Items.Add("11:00 PM");
            //expectedArrivalDropDown.Items.Add("12:00 AM"); Currently removed as per Deb.
        }
        else if (expectedDayDropDown.Text == "Friday")
        {
            expectedArrivalDropDown.Items.Clear();
            expectedArrivalDropDown.Items.Add("8:00 AM");
            expectedArrivalDropDown.Items.Add("9:00 AM");
            expectedArrivalDropDown.Items.Add("10:00 AM");
            expectedArrivalDropDown.Items.Add("11:00 AM");
            expectedArrivalDropDown.Items.Add("12:00 PM");
            expectedArrivalDropDown.Items.Add("1:00 PM");
            expectedArrivalDropDown.Items.Add("2:00 PM");
        }
        else
        {
            expectedArrivalDropDown.Items.Clear();
            expectedArrivalDropDown.Items.Add("-----------------------");
        }
    }
}