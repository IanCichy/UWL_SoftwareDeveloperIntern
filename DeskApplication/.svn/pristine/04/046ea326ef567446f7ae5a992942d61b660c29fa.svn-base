using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for DeskDA
/// </summary>
public class DeskDA
{
    public DeskDA()
    {
    }

    // Admin 
    public static DataSet getAdministratorsByHall()
    {
        DataTable dt = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllValidHallsWithAdmins").Tables[0];

        DataSet finalDS = new DataSet();

        foreach (DataRow dr in dt.Rows)
        {
            DataSet temp = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllAdministratorsForHall",
            new SqlParameter("@hallID", dr["HallID"].ToString()));

            DataTable tempTable = temp.Tables[0].Copy();
            tempTable.TableName = dr["HallID"].ToString();
            finalDS.Tables.Add(tempTable);
        }

        finalDS.Tables.Add(dt.Copy());

        return finalDS;
    }
    public static DataTable getAllAdministratorsForHall(String hallid)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllAdministratorsForHall", new SqlParameter("@hallID", hallid)).Tables[0];
    }

        


    public static void addAdministrator(String username, String hallID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "AddAdministrator",
            new SqlParameter("@username", username),
            new SqlParameter("@hallID", hallID));
    }
/*
      public static void removeAdministrator(String id)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "RemoveAdministrator",
            new SqlParameter("@id", Int32.Parse(id)));
    }
*/
    public static Boolean verifyUsername(String userName)
    {
        return (Boolean)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "VerifyUsername",
            new SqlParameter("@user", userName));
    }
    
    public static String getUserAdminType(String userName)
    {
        Object ret = SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "ValidateUser", new SqlParameter("@username", userName));

        if (ret == null)
        {
            return "";
        }
        else
        {
            return (String)ret;
        }
    }

    // App text 
    public static DataRow getApplicationText(String textName, String hallID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetApplicationText", new SqlParameter("@name", textName), new SqlParameter("@hallID", hallID)).Tables[0].Rows[0];
    }

    public static DataTable getAllApplicationTexts()
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllApplicationTexts").Tables[0];
    }

    public static void setApplicationText(String name, String text, String hallID, bool defaultContent)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "UpdateHallText",
            new SqlParameter("@hallID", hallID),
            new SqlParameter("@name", name),
            new SqlParameter("@text", text),
            new SqlParameter("@default", defaultContent));
    }

    // Date bounds
    public static DataRow verifyHallApplicationBounds(String hallID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "VerifyApplicationBoundForHall", new SqlParameter("@hallID", hallID)).Tables[0].Rows[0];
    }

    public static DataTable getHallApplicationBounds(String hallID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllDateBoundsForHall", new SqlParameter("@hallID", hallID)).Tables[0];
    }

    public static Boolean addDateRangeForHall(String startDate, String endDate, String label, String hallID)
    {
        Int32 success = (Int32)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
             "AddDateRange",
             new SqlParameter("@hallID", hallID),
             new SqlParameter("@startDate", startDate),
             new SqlParameter("@endDate", endDate),
             new SqlParameter("@label", label));

        if (success == 0)
            return false;
        else
            return true;
    }

    public static bool updateDateRangeForHall(String dateRangeID, String startDate, String endDate, String label, String hallID)
    {
        Int32 success = (Int32)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
             "UpdateDateRange",
             new SqlParameter("@dateRangeID", Int32.Parse(dateRangeID)),
             new SqlParameter("@hallID", hallID),
             new SqlParameter("@startDate", startDate),
             new SqlParameter("@endDate", endDate),
             new SqlParameter("@label", label));

        if (success == 0)
            return false;
        else
            return true;
    }

    public static void removeDateRangeForHall(String dateRangeID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
             "RemoveDateRange",
             new SqlParameter("@dateRangeID", Int32.Parse(dateRangeID)));

    }

    public static DataTable getAllApplicationsForDateBound(String dateRangeID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllApplicationsForDateBound", new SqlParameter("@dateBoundID", Int32.Parse(dateRangeID))).Tables[0];
    }

    // Questions
    public static DataSet getQuestionsForHall(String hallID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetInterviewQuestionsForHall", new SqlParameter("@hallID", hallID));
    }

    public static int addQuestionForHall(String question, String hallID)
    {
        return SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "AddQuestion",
            new SqlParameter("@hallID", hallID),
            new SqlParameter("@question", question));
    }

    public static void removeQuestion(String questionID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "RemoveQuestion",
            new SqlParameter("@questionID", Int32.Parse(questionID)));
    }

    public static void moveQuestionUp(String questionID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "MoveQuestionUp",
            new SqlParameter("@questionID", Int32.Parse(questionID)));
    }

    public static void moveQuestionDown(String questionID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "MoveQuestionDown",
            new SqlParameter("@questionID", Int32.Parse(questionID)));

    }

    public static String getValidHallID(String hallName)
    {
        String temp = (String)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetValidHallIDFromName", new SqlParameter("@hallName", hallName));
        if (temp == null)
            return "";
        else
            return temp;
    }

    public static String getValidHallName(String hallID)
    {
        String temp = (String)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                    "GetValidHallNameFromID", new SqlParameter("@hallID", hallID));
        if (temp == null)
            return "";
        else
            return temp;
    }

    public static DataTable getValidHalls()
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetAllValidHalls").Tables[0];
    }

    // Interview times
    public static void AddInterviewTime(String hallID, String startDate, String endDate)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "AddInterviewTime",
                new SqlParameter("@hallID", hallID),
                new SqlParameter("@startTime", startDate),
                new SqlParameter("@endTime", endDate));
    }

    public static void removeInterviewTime(String timeID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "RemoveInterviewTime",
                new SqlParameter("@timeID", Int32.Parse(timeID)));
    }

    public static void removeAllInterviewTimesForHall(String hallID)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "ClearInterviewTimesForHall",
                new SqlParameter("@hallID", hallID));
    }

        // Returns a DataSet with N tables, where N is the amount of availible days for interviewing, and each table
        // has start time and an end time
    public static DataSet getTimesForDateAndHall(String hallID)
    {
        DataSet finalDS = new DataSet();

        DataSet dates = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetInterviewDatesForHall", new SqlParameter("@hallid", hallID));

        foreach (DataRow dr in dates.Tables[0].Rows)
        {
            DataSet temp = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "GetInterviewTimesForHallByDate",
                new SqlParameter("@hallid", hallID),
                new SqlParameter("@date", dr["Date"].ToString()));

            DataTable tempTable = temp.Tables[0].Copy();
            tempTable.TableName = dr["Date"].ToString();
            finalDS.Tables.Add(tempTable);
        }

        finalDS.Tables.Add(dates.Tables[0].Copy());

        return finalDS;
    }

    // Application

    public static int SubmitApplication(String hallID, String stuID, String firstName, String lastName, String phone,
        String email, String major, String year, String work, String credit, String gpa, String mailRet)
    {
        return (int)(Decimal)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "SubmitApplication", new SqlParameter("@hallID", hallID),
                new SqlParameter("@stuID", stuID),
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email),
                new SqlParameter("@major", major),
                new SqlParameter("@year", year),
                new SqlParameter("@work", work),
                new SqlParameter("@credit", credit),
                new SqlParameter("@gpa", gpa),
                new SqlParameter("@mail_return", mailRet));

    }

    public static Application getSubmittedApplication(String id)
    {
        DataTable table = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
            "GetSubmittedApplication", new SqlParameter("@appID", Int32.Parse(id))).Tables[0];

        if (table.Rows.Count == 0)
        {
            return null;
        }
        else
        {
            DataRow dr = table.Rows[0];
            return new Application(dr["hallID"].ToString(), dr["id"].ToString(), dr["stuID"].ToString(), dr["first"].ToString(), dr["last"].ToString(), dr["email"].ToString(), dr["phone"].ToString(), dr["major"].ToString(), dr["year"].ToString(), dr["work"].ToString(), dr["credit"].ToString(), dr["gpa"].ToString(), dr["mail_return"].ToString());
        }
    }

    public static int AddApplicationInterviewTime(int appID, int timeID)
    {
        return (int)(Decimal)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "AddApplicationInterviewTime",
                new SqlParameter("@appID", appID),
                new SqlParameter("@timeID", timeID));
    }

    public static int AddApplicationAnswer(int appID, int questionID, String answer)
    {
        return (int)(Decimal)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                        "AddApplicationAnswer",
                        new SqlParameter("@appID", appID),
                        new SqlParameter("@questionID", questionID),
                        new SqlParameter("@answer", answer));
    }

    public static DataTable getApplicationQuestionsAndAnswers(String id)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
              "GetApplicationAnswersAndQuestions",
              new SqlParameter("@appID", Int32.Parse(id))).Tables[0];
    }

    public static DataTable getApplicationInterviewTimesTEMP(String appID)
    {
        return SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
              "GetApplicationInterviewTimes",
              new SqlParameter("@appID", Int32.Parse(appID))).Tables[0];        
    }

    // Misc
    public static bool getHallBlindPreference(String hallID)
    {
        Object obj = SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "GetBlindPreferenceForHall",
                new SqlParameter("@hallID", hallID));

        if (obj == null)
        {
            return false;
        }
        else
        {
            return (Boolean)obj;
        }
    }

    public static void setHallBlindPreference(String hallID, Boolean blind)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "SetBlindPreferenceForHall",
                new SqlParameter("@hallID", hallID),
                new SqlParameter("@blind", blind));
    }

    public static void setHallDefQPreference(String hallID, Boolean def)
    {
        SqlHelper.ExecuteNonQuery(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
                "SetDefQForHall",
                new SqlParameter("@hallID", hallID),
                new SqlParameter("@def", def));
    }

    public static Boolean getDefQ(String hallID)
    {
          return (Boolean)SqlHelper.ExecuteScalar(Connection.CONNECTIONSTR, CommandType.StoredProcedure,
          "getDefQ",
          new SqlParameter("@hallID", hallID));
    }

    public static Dictionary<string, string> getAllHallsForUser(string username)
    {
        Dictionary<string, string> validHalls = new Dictionary<string,string>();
        var v = SqlHelper.ExecuteDataset(Connection.CONNECTIONSTR, CommandType.StoredProcedure, "getAllHallsForUser", new SqlParameter("@username", username));
        foreach (DataRow item in v.Tables[0].Rows)
        {
            validHalls.Add(item["Hall"].ToString(), item["hallID"].ToString());
        }
        return validHalls;
    }
}
