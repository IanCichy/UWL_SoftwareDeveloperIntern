using Rlis.Sql;
using System;
using System.Data;

/// <summary>
/// Summary description for WiaaReservation
/// </summary>
public class WiaaReservation : Reservation
{
    public int fst { get; set; }

    public int fsf { get; set; }

    public int fdt { get; set; }

    public int fdf { get; set; }

    public int ftt { get; set; }

    public int ftf { get; set; }

    public int fStudyT { get; set; }

    public int fStudyF { get; set; }

    public int fEagleST { get; set; }

    public int fEagleSF { get; set; }

    public int fEagleDT { get; set; }

    public int fEagleDF { get; set; }

    public int mst { get; set; }

    public int msf { get; set; }

    public int mdt { get; set; }

    public int mdf { get; set; }

    public int mtt { get; set; }

    public int mtf { get; set; }

    public int mStudyT { get; set; }

    public int mStudyF { get; set; }

    public int mEagleST { get; set; }

    public int mEagleSF { get; set; }

    public int mEagleDT { get; set; }

    public int mEagleDF { get; set; }

    public string schoolPhone { get; set; }

    public string schoolFax { get; set; }

    public string schoolAddress { get; set; }

    public string city { get; set; }

    public string zip { get; set; }

    public string title { get; set; }

    public string athleticDir { get; set; }

    public string coachName { get; set; }

    public string hallAssign { get; set; }

    public int amount { get; set; }

    public int amount2 { get; set; }

    public int amount3 { get; set; }

    public WiaaReservation(string email)
    {
        this.email = email;
        loadReservation();
    }

    private void loadReservation()
    {
        DataSet ds = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text,
            "SELECT * FROM WiaaSchoolReservations WHERE ContactEmail='" + email + "' AND Year = " + Settings.Year + "");
        DataRow r = ds.Tables[0].Rows[0];
        school = r["SchoolName"].ToString();
        schoolPhone = r["Phone"].ToString();
        schoolFax = r["Fax"].ToString();
        schoolAddress = r["Address"].ToString();
        city = r["City"].ToString();
        zip = r["Zip"].ToString();
        lname = r["ContactLName"].ToString();
        fname = r["ContactFName"].ToString();
        title = r["ContactTitle"].ToString();
        cell = r["ContactCellPhone"].ToString();
        athleticDir = r["AthleticDirectorName"].ToString();
        coachName = r["CoachName"].ToString();
        arrival = r["ExpectedArrival"].ToString();
        comments = r["Comment"].ToString();
        mst = Int32.Parse(r["MST"].ToString());
        msf = Int32.Parse(r["MSF"].ToString());
        fst = Int32.Parse(r["FST"].ToString());
        fsf = Int32.Parse(r["FSF"].ToString());
        mdt = Int32.Parse(r["MDT"].ToString());
        mdf = Int32.Parse(r["MDF"].ToString());
        fdt = Int32.Parse(r["FDT"].ToString());
        fdf = Int32.Parse(r["FDF"].ToString());
        mtt = Int32.Parse(r["MTT"].ToString());
        mtf = Int32.Parse(r["MTF"].ToString());
        ftt = Int32.Parse(r["FTT"].ToString());
        ftf = Int32.Parse(r["FTF"].ToString());
        mStudyT = Int32.Parse(r["MStudyT"].ToString());
        mStudyF = Int32.Parse(r["MStudyF"].ToString());
        fStudyT = Int32.Parse(r["FStudyT"].ToString());
        fStudyF = Int32.Parse(r["FStudyF"].ToString());
        mEagleST = Int32.Parse(r["MEagleST"].ToString());
        mEagleSF = Int32.Parse(r["MEagleSF"].ToString());
        mEagleDT = Int32.Parse(r["MEagleDT"].ToString());
        mEagleDF = Int32.Parse(r["MEagleDF"].ToString());
        fEagleST = Int32.Parse(r["FEagleST"].ToString());
        fEagleSF = Int32.Parse(r["FEagleSF"].ToString());
        fEagleDT = Int32.Parse(r["FEagleDT"].ToString());
        fEagleDF = Int32.Parse(r["FEagleDF"].ToString());
        password = r["Password"].ToString();

        billTotal = Int32.Parse(r["BillTotal"].ToString());
        refund = Int32.Parse(r["Refund"].ToString());
        refundExp = r["RefundExplanation"].ToString();
        paidBy = r["PaidBy"].ToString();
        checkNumber = r["CheckNumber"].ToString();
        amount = (r["amount"].ToString() != "") ? Convert.ToInt32(r["amount"].ToString()) : 0;

        paidBy2 = r["PaidBy2"].ToString();
        checkNumber2 = r["CheckNumber2"].ToString();
        amount2 = (r["amount2"].ToString() != "") ? Convert.ToInt32(r["amount2"].ToString()) : 0;

        paidBy3 = r["PaidBy3"].ToString();
        checkNumber3 = r["CheckNumber3"].ToString();
        amount3 = (r["amount3"].ToString() != "") ? Convert.ToInt32(r["amount3"].ToString()) : 0;

        misctotal = r["MiscCharges"].ToString();
        miscexplanation = r["MiscExplanation"].ToString();
    }

    public void updateSchoolInformation()
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET SchoolName = '" + school +
                                                                                                  "', ContactLName = '" + lname +
                                                                                                  "', Phone = '" + schoolPhone +
                                                                                                  "', ContactFName = '" + fname +
                                                                                                  "', ContactCellPhone = '" + cell +
                                                                                                  "', ContactTitle = '" + title +
                                                                                                  "', Address = '" + schoolAddress +
                                                                                                  "', City = '" + city +
                                                                                                  "', Zip = '" + zip +
                                                                                                  "', Fax = '" + schoolFax +
                                                                                                  "', AthleticDirectorName = '" + athleticDir +
                                                                                                  "', CoachName = '" + coachName +
                                                                                                  "' WHERE ContactEmail = '" + email + "' AND Year = " + Settings.Year + "");
    }

    public void updateReservations()
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET MST = " + mst +
                                                                                                               ", MSF = " + msf +
                                                                                                               ", MDT = " + mdt +
                                                                                                               ", MDF = " + mdf +
                                                                                                               ", MTT = " + mtt +
                                                                                                               ", MTF = " + mtf +
                                                                                                               ", MStudyT = " + mStudyT +
                                                                                                               ", MStudyF = " + mStudyF +
                                                                                                               ", MEagleST = " + mEagleST +
                                                                                                               ", MEagleSF = " + mEagleSF +
                                                                                                               ", MEagleDT = " + mEagleDT +
                                                                                                               ", MEagleDF = " + mEagleDF +
                                                                                                               ", FST = " + fst +
                                                                                                               ", FSF = " + fsf +
                                                                                                               ", FDT = " + fdt +
                                                                                                               ", FDF = " + fdf +
                                                                                                               ", FTT = " + ftt +
                                                                                                               ", FTF = " + ftf +
                                                                                                               ", FStudyT = " + fStudyT +
                                                                                                               ", FStudyF = " + fStudyF +
                                                                                                               ", FEagleST = " + fEagleST +
                                                                                                               ", FEagleSF = " + fEagleSF +
                                                                                                               ", FEagleDT = " + fEagleDT +
                                                                                                               ", FEagleDF = " + fEagleDF +
                                                                                                               " WHERE ContactEmail = '" + email + "' AND Year = " + Settings.Year + "");
    }

    public void updateBilling()
    {
        SqlHelper.ExecuteNonQuery(Settings.WIAAConnection, CommandType.Text, "UPDATE WiaaSchoolReservations SET Refund = " + refund +
                                                                                                                ", RefundExplanation = '" + refundExp +
                                                                                                                "', BillTotal = " + billTotal +
                                                                                                                ", PaidBy = '" + paidBy +
                                                                                                                "', PaidBy2 = '" + paidBy2 +
                                                                                                                "', PaidBy3 = '" + paidBy3 +
                                                                                                                "', Amount = '" + amount +
                                                                                                                "', Amount2 = '" + amount2 +
                                                                                                                "', Amount3 = '" + amount3 +
                                                                                                                "', CheckNumber = '" + checkNumber +
                                                                                                                "', CheckNumber2 = '" + checkNumber2 +
                                                                                                                "', CheckNumber3 = '" + checkNumber3 +
                                                                                                                "' WHERE ContactEmail = '" + email + "' AND Year = " + Settings.Year + "");
    }

    /// <summary>
    /// Gets the bill total
    /// </summary>
    /// <returns>The total</returns>
    public int GetTotal()
    {
        int singleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SingleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());
        int doubleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT doubleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());

        int totalSinglesCost = (fst + mst + fsf + msf) * singleCost;
        int totalDoublesCost = (fdt + mdt + fdf + mdf) * doubleCost;

        return totalDoublesCost + totalSinglesCost;
    }

    /// <summary>
    /// Gets the total cost for females only
    /// </summary>
    /// <returns>The total</returns>
    public int GetFemaleCost()
    {
        int singleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SingleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());
        int doubleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT doubleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());

        int totalSinglesCost = (fst + fsf) * singleCost;
        int totalDoublesCost = (fdt + fdf) * doubleCost;

        return totalSinglesCost + totalDoublesCost;
    }

    /// <summary>
    /// Gets the total cost for males only
    /// </summary>
    /// <returns>The Total</returns>
    public int GetMaleCost()
    {
        int singleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SingleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());
        int doubleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT doubleCost FROM RoomCosts WHERE Year = '" + Settings.Year + "'").ToString());

        int totalSinglesCost = (mst + msf) * singleCost;
        int totalDoublesCost = (mdt + mdf) * doubleCost;

        return totalSinglesCost + totalDoublesCost;
    }
}