using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>
/// Summary description for Data
/// </summary>
public static class Data
{
    // connection strings
    private const String SRRVConnectionString =
        "Data Source=SDB-ResLifeC\\reslife;Initial Catalog=StarRezRoomView;User Id=FrontDesk;Password=DG#eQ*=CT";

    [DllImport("advapi32.dll")]
    private static extern bool LogonUser(string username, string domain, string password, int logonType, int logonProvider, out IntPtr phToken);

    public static bool IsValidCredentials(string username, string password)
    {
        IntPtr hToken;
        return LogonUser(username, "eagle", password, 3, 0, out hToken)
        ;
    }

    public static SqlConnection SRRVConnection()
    {
        return new SqlConnection(SRRVConnectionString);
    }

    public static Color GetRoomColor(String Room)
    {
        // Create a new command
        var command = new SqlCommand("SELECT * FROM Occupants2 where Room like '%' + @Room + '%'")
        {
            CommandType = CommandType.Text,
            Connection = Data.SRRVConnection()
        };
        command.Parameters.Add(new SqlParameter("Room", Room));

        // Execute the command
        command.Connection.Open();
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
        }
        else
        {
            return Color.White;
        }

        var numOccupants = int.Parse(String.Format("{0}", reader["Occupants"]));
        var roomType = (String.Format("{0}", reader["RoomType"]));
        reader.Close();
        command.Connection.Close();

        if (roomType != null)
        {
            if (roomType.Equals("Traditional Single") && (numOccupants == 1))
            {
                return Color.FromArgb(189, 212, 130); //Green
            }
            else if (roomType.Equals("Traditional Double") && (numOccupants == 2))
            {
                return Color.FromArgb(239, 207, 103); //yellow
            }
            else if (roomType.Equals("Traditional Triple") && (numOccupants == 3))
            {
                return Color.FromArgb(226, 147, 101); //Orange
            }
            else if (roomType.Equals("Triple Double") && (numOccupants == 3))
            {
                return Color.FromArgb(213, 100, 98); //Red
            }
            else if (roomType.Equals("Eagle Single") && (numOccupants == 1))
            {
                return Color.FromArgb(60, 161, 189); //blue
            }
            else if (roomType.Equals("Eagle Double") && (numOccupants == 2))
            {
                return Color.FromArgb(189, 212, 130); //Green
            }
            else if (roomType.Equals("Eagle Triple") && (numOccupants == 3))
            {
                return Color.FromArgb(239, 207, 103); //yellow
            }
            else if (roomType.Equals("Eagle Double Single") && (numOccupants == 2))
            {
                return Color.FromArgb(226, 147, 101); //Orange
            }
            else if (roomType.Equals("Hutchison Triple") && (numOccupants == 3))
            {
                return Color.FromArgb(226, 147, 101); //Orange
            }
            else if (roomType.Equals("4 Person Study") && (numOccupants == 4))
            {
                return Color.FromArgb(195, 146, 226); //Lblue
            }
            else if (roomType.Equals("5 Person Study") && (numOccupants == 5))
            {
                return Color.FromArgb(195, 146, 226); //Lblue
            }
            else if (roomType.Contains("Suite") && (numOccupants == 4))
            {
                return Color.FromArgb(239, 207, 103); //yellow
            }
            else
            {
                return Color.FromArgb(207, 101, 186); //ERRPinkishREd
            }
        }
        return Color.White;
    }

    public static Color GetRoomColorGendered(String Room)
    {
        // Create a new command
        var command = new SqlCommand("SELECT * FROM Occupants2 where Room like '%' + @Room + '%'")
        {
            CommandType = CommandType.Text,
            Connection = Data.SRRVConnection()
        };
        command.Parameters.Add(new SqlParameter("Room", Room));

        // Execute the command
        command.Connection.Open();
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
        }
        else
        {
            return Color.White;
        }

        var numOccupants = int.Parse(String.Format("{0}", reader["Occupants"]));
        var roomType = (String.Format("{0}", reader["RoomType"]));
        var Gender = (String.Format("{0}", reader["Gender"]));

        reader.Close();
        command.Connection.Close();

        if (roomType != null)
        {
            if (roomType.Equals("Traditional Single") && (numOccupants == 1) && (Gender.Equals("M")))
            {
                return Color.FromArgb(207, 251, 255); //LightBlue
            }
            else if (roomType.Equals("Traditional Single") && (numOccupants == 1) && (Gender.Equals("F")))
            {
                return Color.FromArgb(232, 192, 221); //LightPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Traditional Double") && (numOccupants == 2) && (Gender.Equals("M")))
            {
                return Color.FromArgb(127, 213, 232);//MedBlue
            }
            else if (roomType.Equals("Traditional Double") && (numOccupants == 2) && (Gender.Equals("F")))
            {
                return Color.FromArgb(222, 116, 232);//DGPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Traditional Triple") && (numOccupants == 3) && (Gender.Equals("M")))
            {
                return Color.FromArgb(69, 140, 156);//Darkblue
            }
            else if (roomType.Equals("Traditional Triple") && (numOccupants == 3) && (Gender.Equals("F")))
            {
                return Color.FromArgb(148, 62, 156);//MedPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Triple Double") && (numOccupants == 3) && (Gender.Equals("M")))
            {
                return Color.FromArgb(223, 178, 141); //LightBrwn
            }
            else if (roomType.Equals("Triple Double") && (numOccupants == 3) && (Gender.Equals("F")))
            {
                return Color.FromArgb(232, 130, 113); //Redpink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Eagle Single") && (numOccupants == 1) && (Gender.Equals("M")))
            {
                return Color.FromArgb(207, 251, 255); //LightBlue
            }
            else if (roomType.Equals("Eagle Single") && (numOccupants == 1) && (Gender.Equals("F")))
            {
                return Color.FromArgb(232, 192, 221); //LightPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Eagle Double") && (numOccupants == 2) && (Gender.Equals("M")))
            {
                return Color.FromArgb(69, 140, 156);//Darkblue
            }
            else if (roomType.Equals("Eagle Double") && (numOccupants == 2) && (Gender.Equals("F")))
            {
                return Color.FromArgb(190, 50, 226); //DrkPur
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Eagle Triple") && (numOccupants == 3) && (Gender.Equals("M")))
            {
                return Color.FromArgb(127, 213, 232);//MedBlue
            }
            else if (roomType.Equals("Eagle Triple") && (numOccupants == 3) && (Gender.Equals("F")))
            {
                return Color.FromArgb(222, 116, 232);//DGPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Eagle Double Single") && (numOccupants == 2) && (Gender.Equals("M")))
            {
                return Color.FromArgb(223, 178, 141); //LightBrwn
            }
            else if (roomType.Equals("Eagle Double Single") && (numOccupants == 2) && (Gender.Equals("F")))
            {
                return Color.FromArgb(232, 130, 113); //Redpink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("Hutchison Triple") && (numOccupants == 3) && (Gender.Equals("M")))
            {
                return Color.FromArgb(69, 140, 156);//MedBlue
            }
            else if (roomType.Equals("Hutchison Triple") && (numOccupants == 3) && (Gender.Equals("F")))
            {
                return Color.FromArgb(148, 62, 156);//MedPink
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("4 Person Study") && (numOccupants == 4) && (Gender.Equals("M")))
            {
                return Color.FromArgb(40, 156, 141); //5PersonStudy
            }
            else if (roomType.Equals("4 Person Study") && (numOccupants == 4) && (Gender.Equals("F")))
            {
                return Color.FromArgb(104, 45, 156); //5personstudy
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Equals("5 Person Study") && (numOccupants == 5) && (Gender.Equals("M")))
            {
                return Color.FromArgb(40, 156, 141); //5PersonStudy
            }
            else if (roomType.Equals("5 Person Study") && (numOccupants == 5) && (Gender.Equals("F")))
            {
                return Color.FromArgb(104, 45, 156); //5personstudy
            }
            //--------------------------------------------------------------------------------------------
            else if (roomType.Contains("Suite") && (numOccupants == 4))
            {
                return Color.FromArgb(239, 207, 103); //yellow
            }
            else if (roomType.Contains("Suite") && (numOccupants == 4))
            {
                return Color.FromArgb(239, 207, 103); //yellow
            }
            //--------------------------------------------------------------------------------------------
            else
            {
                if (Gender.Equals("F"))
                {
                    return Color.FromArgb(156, 60, 45); //ErrorPin
                }
                else if (Gender.Equals("M"))
                {
                    return Color.FromArgb(146, 101, 63); //ErrorDarkBrown
                }
                else
                {
                    return Color.FromArgb(225, 242, 85); //yellow
                }
            }
        }
        return Color.White;
    }

    public static ArrayList getOccupantDetails(string SID)
    {
        ArrayList Details = new ArrayList();

        // Create a new command
        var command = new SqlCommand("SELECT * FROM Occupants WHERE StudentID = @SID")
        {
            CommandType = CommandType.Text,
            Connection = Data.SRRVConnection()
        };
        command.Parameters.Add(new SqlParameter("SID", SID));

        // Execute the command
        command.Connection.Open();
        var reader = command.ExecuteReader();

        // Read the results and return the first employee id if there is one
        if (reader.Read())
        {
            Details.Add(String.Format("{0}", reader["FName"]));
            Details.Add(String.Format("{0}", reader["LName"]));
            Details.Add(String.Format("{0}", reader["Gender"]));
            Details.Add(String.Format("{0}", reader["Age"]));
            Details.Add(String.Format("{0}", reader["International"]));
            Details.Add(String.Format("{0}", reader["Email"]));
            Details.Add(String.Format("{0}", reader["Cell"]));
            Details.Add(String.Format("{0}", reader["CheckInDate"]));
            Details.Add(String.Format("{0}", reader["CheckOutDate"]));
            Details.Add(String.Format("{0}", reader["Room"]));
            Details.Add(String.Format("{0}", reader["RoomType"]));
            Details.Add(String.Format("{0}", reader["Disabled"]));
        }

        return Details;
    }



    public static ArrayList getHallDetails(string HallName)
    {
        ArrayList Details = new ArrayList();

        // Create a new command
        var command = new SqlCommand("SELECT * FROM Halls WHERE Name = @HallName")
        {
            CommandType = CommandType.Text,
            Connection = Data.SRRVConnection()
        };
        command.Parameters.Add(new SqlParameter("HallName", HallName));

        // Execute the command
        command.Connection.Open();
        var reader = command.ExecuteReader();

        // Read the results and return the first employee id if there is one
        if (reader.Read())
        {
            Details.Add(String.Format("{0}", reader["Name"]));
            Details.Add(String.Format("{0}", reader["Rooms"]));
            Details.Add(String.Format("{0}", reader["Beds"]));
            Details.Add(String.Format("{0}", reader["MStudents"]));
            Details.Add(String.Format("{0}", reader["FStudents"]));
            Details.Add(String.Format("{0}", reader["Elevator"]));

        }

        return Details;
    }
}