using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
	public Reservation()
	{

	}

    public string school { get; set; }
    public string schoolPhone { get; set; }
    public string fax { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public string lname { get; set; }
    public string fname { get; set; }
    public string email { get; set; }
    public string title { get; set; }
    public string cell { get; set; }
    public string athleticDir { get; set; }
    public string coach { get; set; }
    public string password { get; set; }
    public DateTime arrival { get; set; }
    public int mst { get; set; }
    public int msf { get; set; }
    public int fst { get; set; }
    public int fsf { get; set; }
    public int mdt { get; set; }
    public int mdf { get; set; }
    public int fdt { get; set; }
    public int fdf { get; set; }
    public bool specNeeds { get; set; }
    public int hallPref { get; set; }
    public int specNeedsRoomsT { get; set; }
    public int specNeedsRoomsF { get; set; }
    

    /// <summary>
    /// Save the reservation to the database using the stored procedure, SaveReservation
    /// </summary>
    public void SaveReservation()
    {
        SqlHelper.ExecuteDataset(Settings.WIAAConnection, "SaveReservation",
            new SqlParameter("@school", school),
            new SqlParameter("@phone", schoolPhone),
            new SqlParameter("@fax", fax),
            new SqlParameter("@address", address),
            new SqlParameter("@city", city),
            new SqlParameter("@zip", zip),
            new SqlParameter("@lname", lname),
            new SqlParameter("@fname", fname),
            new SqlParameter("@email", email),
            new SqlParameter("@title", title),
            new SqlParameter("@cell", cell),
            new SqlParameter("@athleticDir", athleticDir),
            new SqlParameter("@coach", coach),
            new SqlParameter("@password", password),
            new SqlParameter("@arrival", arrival),
            new SqlParameter("@mst", mst),
            new SqlParameter("@msf", msf),
            new SqlParameter("@fst", fst),
            new SqlParameter("@fsf", fsf),
            new SqlParameter("@mdt", mdt),
            new SqlParameter("@mdf", mdf),
            new SqlParameter("@fdt", fdt),
            new SqlParameter("@fdf", fdf),
            new SqlParameter("@year", Settings.Year),
            new SqlParameter("@specNeeds", specNeeds),
            new SqlParameter("@hallPref", hallPref),
            new SqlParameter("@specNeedsRoomsT", specNeedsRoomsT),
            new SqlParameter("@specNeedsRoomsF", specNeedsRoomsF));
    }

    /// <summary>
    /// Updates reservation information using the stored procedure, UpdateReservation
    /// </summary>
    public void UpdateReservation()
    {
        SqlHelper.ExecuteDataset(Settings.WIAAConnection, "UpdateReservation",
            new SqlParameter("@school", school),
            new SqlParameter("@phone", schoolPhone),
            new SqlParameter("@fax", fax),
            new SqlParameter("@address", address),
            new SqlParameter("@city", city),
            new SqlParameter("@zip", zip),
            new SqlParameter("@lname", lname),
            new SqlParameter("@fname", fname),
            new SqlParameter("@email", email),
            new SqlParameter("@title", title),
            new SqlParameter("@cell", cell),
            new SqlParameter("@athleticDir", athleticDir),
            new SqlParameter("@coach", coach),
            new SqlParameter("@mst", mst),
            new SqlParameter("@msf", msf),
            new SqlParameter("@fst", fst),
            new SqlParameter("@fsf", fsf),
            new SqlParameter("@mdt", mdt),
            new SqlParameter("@mdf", mdf),
            new SqlParameter("@fdt", fdt),
            new SqlParameter("@fdf", fdf),
            new SqlParameter("@year", Settings.Year),
            new SqlParameter("@specNeeds", specNeeds),
            new SqlParameter("@hallPref", hallPref),
            new SqlParameter("@specNeedsRoomsT", specNeedsRoomsT),
            new SqlParameter("@specNeedsRoomsF", specNeedsRoomsF));
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
