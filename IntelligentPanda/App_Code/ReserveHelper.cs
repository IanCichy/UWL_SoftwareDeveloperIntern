using Rlis.Sql;
using System.Data;

/// <summary>
/// Summary description for ReserveHelper
/// </summary>
public class ReserveHelper
{
    public static int getTotalAvailableRoomsWiaa(string hall)
    {
        return int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT count(*) FROM ReservedRooms WHERE Hall = '" + hall + "' and Reserved = 'False'").ToString());
    }

    public static int getTotalAvailableRoomsNcaa(string hall)
    {
        return int.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT sum(OpenBeds) FROM Beds_View WHERE Hall = '" + hall + "' and OpenBeds>0").ToString());
    }

    public static string determineRoomTypes(bool includeStudies, bool includeTriples)
    {
        string type = "";
        if (includeTriples && includeStudies)
        {
            type = "'Double' or Type = 'Triple' or Type = 'Study'";
        }
        else if (includeTriples && !includeStudies)
        {
            type = "'Double' or Type = 'Triple'";
        }
        else if (!includeTriples && includeStudies)
        {
            type = "'Double' or Type = 'Study'";
        }
        else
        {
            type = "'Double'";
        }

        return type;
    }

    /// <summary>
    /// Gets the status of a room in Reuter Hall for volunteers.
    /// This includes whether it is empty, full, or partially full.
    /// </summary>
    /// <param name="roomNumber">The room number to check</param>
    /// <returns>Status of room</returns>
    public static string getVolunteerRoomStatus(string roomNumber)
    {
        SqlConnect conn = new SqlConnect(Settings.WIAAConnection);
        string[] parametersA = { "@Room" };
        string[] valuesA = { roomNumber };
        string bedA = conn.Select("[Bed A]", "VolunteerRoomReservations", "Room = @Room", parametersA, valuesA);

        string[] parametersB = { "@Room" };
        string[] valuesB = { roomNumber };
        string bedB = conn.Select("[Bed B]", "VolunteerRoomReservations", "Room = @Room", parametersB, valuesB);

        string[] parametersC = { "@Room" };
        string[] valuesC = { roomNumber };
        string bedC = conn.Select("[Bed C]", "VolunteerRoomReservations", "Room = @Room", parametersC, valuesC);

        string[] parametersD = { "@Room" };
        string[] valuesD = { roomNumber };
        string bedD = conn.Select("[Bed D]", "VolunteerRoomReservations", "Room = @Room", parametersD, valuesD);

        if (bedA == "" && bedB == "" && bedC == "" && bedD == "")
        {
            return "Empty";
        }
        else if (bedA != "" && bedB != "" && bedC != "" && bedD != "")
        {
            return "Full";
        }
        else
        {
            return "Partial";
        }
    }
}