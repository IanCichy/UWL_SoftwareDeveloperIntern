//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Data.Sql;

//using System.Data.SqlClient;

//using System.Data.SqlTypes;



///// <summary>
///// Summary description for Connection
///// </summary>
//public class Connection
//{
//    public Connection()
//    {

//    }

//    public static SqlConnection WIAAConn = new SqlConnection("Data Source=SDB-RESLIFEC\\RESLIFE;Initial Catalog=wiaa;User Id=wiaa_web;Password=xa5rEJe2");

//    public static void StoreReservation(Reservation theReservation) 
//    {
//        SqlHelper.ExecuteDataset(WIAAConn, "InsSchoolReservation",
//            new SqlParameter("@schoolName", theReservation.schoolName),
//            new SqlParameter("@password", theReservation.password),
//            new SqlParameter("@phone", theReservation.phone),
//            new SqlParameter("@fax", theReservation.fax),
//            new SqlParameter("@address", theReservation.address),
//            new SqlParameter("@city", theReservation.city),
//            new SqlParameter("@zip", theReservation.zip),
//            new SqlParameter("@contactFName", theReservation.contactFName),
//            new SqlParameter("@contactLName", theReservation.contactLName),
//            new SqlParameter("@contactTitle", theReservation.contactTitle),
//            new SqlParameter("@contactEmail", theReservation.contactEmail),
//            new SqlParameter("@athleticDirectorName", theReservation.athleticDirectorName),
//            new SqlParameter("@coachName", theReservation.coachName),
//            new SqlParameter("@expectedArrival", theReservation.expectedArrival),
//            new SqlParameter("@reservationTime", theReservation.reservationTime),
//            new SqlParameter("@MSF", theReservation.MSF),
//            new SqlParameter("@MST", theReservation.MST),
//            new SqlParameter("@FSF", theReservation.FSF),
//            new SqlParameter("@FST", theReservation.FST),
//            new SqlParameter("@MDF", theReservation.MDF),
//            new SqlParameter("@MDT", theReservation.MDT),
//            new SqlParameter("@FDT", theReservation.FDT),
//            new SqlParameter("@FDF", theReservation.FDF),
//            new SqlParameter("@MTT", theReservation.MTT),
//            new SqlParameter("@MTF", theReservation.MTF),
//            new SqlParameter("@FTT", theReservation.FTT),
//            new SqlParameter("@FTF", theReservation.FTF),
//            new SqlParameter("@MStudyT", theReservation.MStudyT),
//            new SqlParameter("@MStudyF", theReservation.MStudyF),
//            new SqlParameter("@FStudyT", theReservation.FStudyT),
//            new SqlParameter("@FStudyF", theReservation.FStudyF),
//            new SqlParameter("@MEagleST", theReservation.MEagleST),
//            new SqlParameter("@MEagleSF", theReservation.MEagleSF),
//            new SqlParameter("@MEagleDT", theReservation.MEagleDT),
//            new SqlParameter("@MEagleDF", theReservation.MEagleDF),
//            new SqlParameter("@FEagleST", theReservation.FEagleST),
//            new SqlParameter("@FEagleSF", theReservation.FEagleSF),
//            new SqlParameter("@FEagleDT", theReservation.FEagleDT),
//            new SqlParameter("@FEagleSD", theReservation.FEagleDF));
//    }
  
//    public static bool duplicateSchool(string email, string phone)
//    {
//        DataSet ds = SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select * from dbo.WiaaSchoolReservations WHERE (Phone='" + phone + "' OR ContactEmail ='" + email + "') AND Year =" + DateTime.Now.Year.ToString());
//        if (ds.Tables[0].Rows.Count > 0)
//            return true;
//        //else
//        return false;
//    }
//    public static Reservation getReservation(string email,string password)//lets use email to get reservation k?
//    {
//        Reservation theRes = new Reservation();
//        DataSet ds = SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select * from dbo.WiaaSchoolReservations Where ContactEmail= '" + email.Replace("'", "''") + "' AND Password = '" + password.Replace("'", "''") + "' AND Year =" + DateTime.Now.Year);
//        if(ds!=null)
//        {
//            DataRow row = ds.Tables[0].Rows[0];

//            theRes.phone= (row["Phone"].Equals(DBNull.Value)) ? null : (string)row["Phone"];
//            theRes.address = (row["Address"].Equals(DBNull.Value)) ? " " : (string)row["Address"];
//            theRes.athleticDirectorName = (row["AthleticDirectorName"].Equals(DBNull.Value)) ? " " : (string)row["AthleticDirectorName"];
//            try
//            {
//                theRes.cancelled = (row["Cancelled"].Equals(false)) ? null : (string)row["Cancelled"];
//            }
//            catch
//            {
//                ShowAlertMessage("Your reservation has been canceled. If you feel that this is an error, please contact Residence Life Information Services at 608-789-2300.");
//            }
//                theRes.checkNumber = (row["CheckNumber"].Equals(DBNull.Value)) ? null : (string)row["CheckNumber"];
//            theRes.city = (row["City"].Equals(DBNull.Value)) ? null : (string)row["City"];
//            theRes.coachName = (row["CoachName"].Equals(DBNull.Value)) ? "" : (string)row["CoachName"];
//            theRes.comment = (row["Comment"].Equals(DBNull.Value)) ? "" : (string)row["Comment"];
//            theRes.contactEmail = (row["ContactEmail"].Equals(DBNull.Value)) ? " " : (string)row["ContactEmail"];
//            theRes.contactFName = (row["ContactFName"].Equals(DBNull.Value)) ? " " : (string)row["ContactFName"];
//            theRes.contactLName = (row["ContactLName"].Equals(DBNull.Value)) ? " " : (string)row["ContactLName"];
//            theRes.contactTitle = (row["ContactTitle"].Equals(DBNull.Value)) ? null : (string)row["ContactTitle"];
//            theRes.expectedArrival= (row["ExpectedArrival"].Equals(DBNull.Value)) ? DateTime.Now : DateTime.Parse(row["ExpectedArrival"].ToString());
//            theRes.fax = (row["Fax"].Equals(DBNull.Value)) ? "" : (string)row["Fax"];
//            theRes.FDF = (row["FDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FDF"].ToString());
//            theRes.FDT = (row["FDT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FDT"].ToString());
//            theRes.FSF = (row["FDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FSF"].ToString());
//            theRes.FST = (row["FDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FST"].ToString());
//            theRes.FTF = (row["FDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FTF"].ToString());
//            theRes.FTT = (row["FDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FTT"].ToString());
//            theRes.MDF = (row["MDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MDF"].ToString());
//            theRes.MDT = (row["MDT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MDT"].ToString());
//            theRes.MSF = (row["MSF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MSF"].ToString());
//            theRes.MST = (row["MST"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MST"].ToString());
//            theRes.MTF = (row["MTF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MTF"].ToString());
//            theRes.MTT = (row["MTT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MTT"].ToString());
//            theRes.MStudyT = (row["MStudyT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MStudyT"].ToString());
//            theRes.MStudyF = (row["MStudyF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MStudyF"].ToString());
//            theRes.FStudyT = (row["FStudyT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FStudyT"].ToString());
//            theRes.MStudyT = (row["FStudyT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FStudyT"].ToString());
//            theRes.MEagleST = (row["MEagleST"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MEagleST"].ToString());
//            theRes.MEagleSF = (row["MEagleSF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MEagleSF"].ToString());
//            theRes.MEagleDT = (row["MEagleDT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MEagleDT"].ToString());
//            theRes.MEagleDF = (row["MEagleDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["MEagleDF"].ToString());
//            theRes.FEagleST = (row["FEagleST"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FEagleST"].ToString());
//            theRes.FEagleSF = (row["FEagleSF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FEagleSF"].ToString());
//            theRes.FEagleDT = (row["FEagleDT"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FEagleDT"].ToString());
//            theRes.FEagleDF = (row["FEagleDF"].Equals(DBNull.Value)) ? 0 : int.Parse(row["FEagleDF"].ToString());
//            theRes.reservationTime = (row["ReservationTime"].Equals(DBNull.Value)) ? DateTime.Now : DateTime.Parse(row["ReservationTime"].ToString());
//            theRes.schoolName = (row["SchoolName"].Equals(DBNull.Value)) ? "" : (string)row["SchoolName"];
//            theRes.zip = (row["Zip"].Equals(DBNull.Value)) ? "" : row["Zip"].ToString();
//            return theRes;
//        }
//        return null;
//    }
//    public static bool isAdmin(String uName, String pword)
//    {
//        DataSet ds = SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select * from dbo.login Where userName= '" + uName.Trim() + "' AND password = '" + pword.Trim()+"'");
//        return ds.Tables[0].Rows.Count > 0;
//    }

//    public static Config getConfig() //load up our site config. Its simple Content Management.
//    {
//        Config theConfig = new Config();
//        DataSet ds = SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select * From dbo.WiaaConfig WHERE Year = '" + Settings.Year + "'");
//        if (ds.Tables[0].Rows.Count > 0)
//        {
//            theConfig.parkInfo = (String)ds.Tables[0].Rows[0]["Parking"];
//            theConfig.foodInfo = (String)ds.Tables[0].Rows[0]["Food"];
//            theConfig.checkInEnd = (DateTime)ds.Tables[0].Rows[0]["CheckInEnd"];
//            theConfig.checkInStart = (DateTime)ds.Tables[0].Rows[0]["CheckInBegin"];
//            theConfig.doubleCost = double.Parse(ds.Tables[0].Rows[0]["DoubleCost"].ToString());
//            theConfig.singleCost = double.Parse(ds.Tables[0].Rows[0]["SingleCost"].ToString());
//            theConfig.tripleCost = double.Parse(ds.Tables[0].Rows[0]["TripleCost"].ToString());
//            theConfig.regStart = (DateTime)ds.Tables[0].Rows[0]["RegBegin"];
//            theConfig.regEnd = (DateTime)ds.Tables[0].Rows[0]["RegEnd"];
//            theConfig.year = (int)ds.Tables[0].Rows[0]["Year"];
//            theConfig.familyHousing = false; //Remove this when we have real familyHousing
//            return theConfig;
//        }
//        else
//            return null;
        


//    }
//    public static void saveConfig(Config savedConfig)
//    {
        
//        SqlHelper.ExecuteNonQuery(WIAAConn, "dbo.CreateConfig",
//            new SqlParameter("@singleCost", savedConfig.singleCost),
//            new SqlParameter("@doubleCost", savedConfig.doubleCost),
//            new SqlParameter("@tripleCost", savedConfig.tripleCost),
//            new SqlParameter("@checkInBegin", savedConfig.checkInStart),
//            new SqlParameter("@checkinEnd",savedConfig.checkInEnd ),//
//            new SqlParameter("@regBegin",savedConfig.regStart ),//
//            new SqlParameter("@regEnd", savedConfig.regEnd),
//            new SqlParameter("@parkInfo", savedConfig.parkInfo),
//            new SqlParameter("@foodInfo", savedConfig.foodInfo),
//            new SqlParameter("@familyHousing",savedConfig.familyHousing),
//            new SqlParameter("@year", savedConfig.year));


//    }
//    public static Boolean isValid(string pword, string user)
//    {
//        DataSet ds = SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select * from dbo.WiaaSchoolReservations where Password = '" + pword.Replace("'", "''") + "' and ContactEmail = '" + user.Replace("'", "''") + "' and Year = " + DateTime.Now.Year);
//        if (ds.Tables[0].Rows.Count > 0)
//            return true;
//        //else
//        return false;
//    }
//    public static DataSet getSchoolList()
//    {
//        return SqlHelper.ExecuteDataset(WIAAConn, CommandType.Text, "Select SchoolName, ExpectedArrival, HallAssignment from dbo.WiaaSchoolReservations where year = " + DateTime.Now.Year.ToString() + "ORDER BY HallAssignment, SchoolName");
//    }

//    public static void ShowAlertMessage(string error)
//    {
//        Page page = HttpContext.Current.Handler as Page;
//        if (page != null)
//        {
//            error = error.Replace("'", "\'");
//            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
//        }
//    }

//}
