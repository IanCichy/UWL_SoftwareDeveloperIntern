using Rlis.Sql;
using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Summary description for NCAAReservation
/// </summary>
public class NcaaReservation : Reservation
{
    public int fsingles { get; set; }

    public int msingles { get; set; }

    public int fdoubles { get; set; }

    public int mdoubles { get; set; }

    public int suites { get; set; }

    public List<RoomReservation> reservedRooms { get; set; }

    public NcaaReservation()
    {
        reservedRooms = new List<RoomReservation>();
    }

    public NcaaReservation(string email)
    {
        reservedRooms = new List<RoomReservation>();
        this.email = email;
        loadReservation();
    }

    public static List<RoomReservation> GetAllNCAARooms()
    {
        List<RoomReservation> rooms = new List<RoomReservation>();
        DataSet roomsDataSet = SqlHelper.ExecuteDataset(Settings.NCAAConnection, CommandType.Text,
                        "SELECT A.Hall, A.Room, A.Beds, R.Gender FROM dbo.RoomAssignments A JOIN dbo.Rooms R ON A.Hall=R.Hall AND A.Room=R.Room");
        DataTable t = roomsDataSet.Tables[0];

        foreach (DataRow row in t.Rows)
        {
            RoomReservation rr;
            if (row["Gender"] == DBNull.Value)
            {
                rr = new RoomReservation(row["Hall"].ToString(), row["Room"].ToString(), Int32.Parse(row["Beds"].ToString()), ' ');
            }
            else
            {
                rr = new RoomReservation(row["Hall"].ToString(), row["Room"].ToString(), Int32.Parse(row["Beds"].ToString()), row["Gender"].ToString().ToLower().ToCharArray()[0]);
            }
            rooms.Add(rr);
        }

        return rooms;
    }

    public static List<NcaaReservation> FindReservations(string hall, string room)
    {
        string whereClause = String.Format(" WHERE Hall='{0}' AND Room='{1}'", hall, room);
        DataSet ds = SqlHelper.ExecuteDataset(Settings.NCAAConnection, CommandType.Text, "SELECT School AS Email FROM dbo.RoomAssignments " + whereClause);
        List<NcaaReservation> reservations = new List<NcaaReservation>();
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            reservations.Add(new NcaaReservation(r["Email"].ToString()));
        }
        return reservations;
    }

    public static void RemoveReservation(string hall, string room, string displayName)
    {
        string email = SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, String.Format("SELECT Email FROM dbo.Reservations WHERE (FName + ' ' + LName) = '{0}' OR School = '{0}'", displayName)).ToString();
        string whereClause = String.Format(" WHERE Hall='{0}' AND Room='{1}'", hall, room);
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, String.Format("DELETE FROM dbo.RoomAssignments {0} AND School='{1}'", whereClause, email));
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "UPDATE dbo.Rooms SET Gender=NULL " + whereClause);
    }

    private void loadReservation()
    {
        DataSet ds = SqlHelper.ExecuteDataset(Settings.NCAAConnection, CommandType.Text,
            "SELECT * FROM dbo.Reservations WHERE Email='" + email + "'");
        DataRow r = ds.Tables[0].Rows[0];
        role = r["Role"].ToString();
        lname = r["LName"].ToString();
        fname = r["FName"].ToString();
        school = r["School"].ToString();
        cell = r["Cell"].ToString();
        hallpref = r["HallPref"].ToString();
        arrival = r["Arrival"].ToString();
        departure = r["Departure"].ToString();
        special = Boolean.Parse(r["SpecialAccomodations"].ToString());
        explanation = r["SpecialExplanation"].ToString();
        comments = r["Comment"].ToString();
        fsingles = Int32.Parse(r["FemaleSingles"].ToString());
        msingles = Int32.Parse(r["MaleSingles"].ToString());
        fdoubles = Int32.Parse(r["FemaleDoubles"].ToString());
        mdoubles = Int32.Parse(r["MaleDoubles"].ToString());
        suites = Int32.Parse(r["Suites"].ToString());
        billTotal = Int32.Parse(r["BillTotal"].ToString());
        refund = Int32.Parse(r["Refund"].ToString());
        paidBy = r["PaidBy"].ToString();
        checkNumber = r["CheckNumber"].ToString();
        paidBy2 = r["PaidBy2"].ToString();
        checkNumber2 = r["CheckNumber2"].ToString();
        misctotal = r["MiscTotal"].ToString();
        miscexplanation = r["MiscExplanation"].ToString();
        billNote = r["BillNote"] == DBNull.Value ? "" : r["BillNote"].ToString();

        TimeSpan totalDays = (DateTime.Parse(departure) - DateTime.Parse(arrival));
        billTotal = ((fsingles * 35) + (msingles * 35) + (fdoubles * 50) + (mdoubles * 50)) * (totalDays.Days);

        DataSet roomsDataSet = SqlHelper.ExecuteDataset(Settings.NCAAConnection, CommandType.Text,
                        "SELECT A.Hall, A.Room, A.Beds, R.Gender FROM dbo.RoomAssignments A JOIN dbo.Rooms R ON A.Hall=R.Hall AND A.Room=R.Room WHERE School='" + email + "'");
        DataTable t = roomsDataSet.Tables[0];

        foreach (DataRow row in t.Rows)
        {
            if (row["Gender"] == DBNull.Value)
            {
                RoomReservation rr = new RoomReservation(row["Hall"].ToString(), row["Room"].ToString(), Int32.Parse(row["Beds"].ToString()), ' ');
                reservedRooms.Add(rr);
            }
            else
            {
                RoomReservation rr = new RoomReservation(row["Hall"].ToString(), row["Room"].ToString(), Int32.Parse(row["Beds"].ToString()), row["Gender"].ToString().ToLower().ToCharArray()[0]);
                reservedRooms.Add(rr);
            }
        }

        calculateBilling();
    }

    public void updateCharges()
    {
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "UPDATE Reservations SET MiscTotal='"
            + misctotal + "', MiscExplanation='" + miscexplanation + "' WHERE Email='" + email + "'");
    }

    private void calculateBilling()
    {
        billTotal = 0;

        foreach (RoomReservation res in reservedRooms)
        {
            if (hallpref == "Reuter")
            {
                billTotal += 35 * res.beds;
            }
            else
            {
                if (res.beds == 2)
                {
                    billTotal += 50;
                }
                else
                {
                    billTotal += 35;
                }
            }
        }

        billTotal *= (DateTime.Parse(departure) - DateTime.Parse(arrival)).Days;
    }

    public void reserve()
    {
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "INSERT INTO Reservations (Role, LName, FName, School, Email, Cell, HallPref, Password, Arrival, Departure, Year, MaleSingles, FemaleSingles, MaleDoubles, FemaleDoubles, Suites, SpecialAccomodations, SpecialExplanation, Comment) Values ('" + role + "', '" + lname + "', '" + fname + "', '" + school + "', '" + email + "', '" + cell + "', '" + hallpref + "', '" + password + "', '" + arrival + "', '" + departure + "', " + Settings.Year + ", " + msingles + ", " + fsingles + ", " + mdoubles + ", " + fdoubles + ", " + suites + ", '" + special + "', '" + explanation + "', '" + comments + "')");
    }

    public void update()
    {
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "UPDATE Reservations SET Role = '" + role +
                                                                                                  "', LName = '" + lname +
                                                                                                  "', FName = '" + fname +
                                                                                                  "', School = '" + school +
                                                                                                  "', Email = '" + email +
                                                                                                  "', Cell = '" + cell +
                                                                                                  "', HallPref = '" + hallpref +
                                                                                                  "', Arrival = '" + arrival +
                                                                                                  "', Departure = '" + departure +
                                                                                                  "', Year = " + Settings.Year +
                                                                                                  ", MaleSingles = " + msingles +
                                                                                                  ", FemaleSingles = " + fsingles +
                                                                                                  ", MaleDoubles = " + mdoubles +
                                                                                                  ", FemaleDoubles = " + fdoubles +
                                                                                                  ", Suites = " + suites +
                                                                                                  " WHERE Email = '" + email + "'");
    }

    /// <summary>
    /// Update Billing information.
    /// </summary>
    public void updateBilling()
    {
        SqlHelper.ExecuteNonQuery(Settings.NCAAConnection, CommandType.Text, "UPDATE Reservations SET BillTotal = " + billTotal +
                                                                                                          ", Refund = " + refund +
                                                                                                          ", PaidBy = '" + paidBy +
                                                                                                          "', CheckNumber = '" + checkNumber +
                                                                                                          "', PaidBy2 = '" + paidBy2 +
                                                                                                          "', CheckNumber2 = '" + checkNumber2 +
                                                                                                          "', Amount = " + amount +
                                                                                                          ", Amount2 = " + amount2 +
                                                                                                          ", BillNote = '" + billNote +
                                                                                                          "' WHERE Email = '" + email + "'");
    }
}