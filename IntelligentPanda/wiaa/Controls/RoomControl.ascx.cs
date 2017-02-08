using Rlis.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wiaa_Controls_RoomControl : System.Web.UI.UserControl
{
    private bool recommend = false;
    private bool includeTriples;
    private bool includeStudies;
    private int roomsNeeded;

    /// <summary>
    /// The map file that gets set on RoomControl.ascx.
    /// </summary>
    private string map;

    /// <summary>
    /// Keeps track of what the room type is.
    /// </summary>
    private enum RoomType
    {
        Single,
        Double,
        Triple,
        Study
    };

    private RoomType roomType;

    /// <summary>
    /// Sets and gets the map file to be opened and parsed.
    /// </summary>
    public string Map
    {
        get
        {
            return map;
        }
        set
        {
            map = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["RoomsClicked"] = null;
            if (Request.Url.ToString().Contains("roomsNeeded"))
            {
                roomsNeeded = int.Parse(Request.QueryString["roomsNeeded"].ToString());
                //this might be unecessary
                recommend = true;
            }
            if (Request.Url.ToString().Contains("triples"))
            {
                includeStudies = bool.Parse(Request.QueryString["studies"].ToString());
                includeTriples = bool.Parse(Request.QueryString["triples"].ToString());
            }
            readFile(recommend);
        }
    }

    /// <summary>
    /// Reads the .map file that is specified by the Map value set on RoomControl.ascx.
    /// After the file is parsed, a list of Room objects is created, which is used as
    /// the datasource for the Repeater.
    /// If the room is reserved, the button color will be red.
    /// </summary>
    public void readFile(bool recommend)
    {
        //reset the datasource to avoid errors
        Repeater1.DataSource = null;
        Color color;
        string line;
        string[] roomElements;
        List<Room> roomList = new List<Room>();
        List<string> roomsToRecommend = new List<string>();
        if (recommend == true)
        {
            roomsToRecommend = recommendRooms();
            if (roomsToRecommend.Count != roomsNeeded)
            {
                Security.ShowAlertMessage("There are not enough rooms available in " + Session["Hall"].ToString());
                recommend = false;
            }
        }

        StreamReader file = File.OpenText(HttpContext.Current.Server.MapPath("~/HallFiles/" + map + ".map"));
        //parse the whole file
        while ((line = file.ReadLine()) != null)
        {
            roomElements = line.Split(' ');
            string hall = map.Remove(map.Length - 1);
            string reserved = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Reserved FROM ReservedRooms where Room = '" + roomElements[0] + "' AND Hall = '" + hall + "'").ToString();
            string gender = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Gender FROM ReservedRooms WHERE Room = '" + roomElements[0] + "'").ToString();
            List<string> roomsClicked = new List<string>();
            if (Session["RoomsClicked"] != null) roomsClicked = (List<string>)Session["RoomsClicked"];
            //if the room is reserved, the button turns red.
            if (reserved == "True" && gender.Equals(""))
            {
                color = Color.Red;
            }
            else if (gender.Equals("M") && reserved.Equals("True"))
            {
                color = Color.DodgerBlue;
            }
            else if (gender.Equals("F") && reserved.Equals("True"))
            {
                color = Color.HotPink;
            }
            else if (recommend == true && Session["Hall"].ToString() == map.Substring(0, map.Length - 1))
            {
                if (roomsToRecommend.Contains(roomElements[0].ToString()))
                {
                    color = Color.Lime;
                }
                else
                {
                    if (Session["Hall"].ToString().Equals("Eagle"))
                    {
                        if (gender.Equals("M")) color = Color.LightCyan;
                        else if (gender.Equals("F")) color = Color.MistyRose;
                        else color = Color.Empty;
                    }
                    else color = Color.Empty;
                }
            }
            else if (gender.Equals("M") && roomsClicked.Contains(roomElements[0]))
            {
                color = Color.LightBlue;
            }
            else if (gender.Equals("M"))
            {
                color = Color.LightCyan;
            }
            else if (gender.Equals("F") && roomsClicked.Contains(roomElements[0]))
            {
                color = Color.LightPink;
            }
            else if (gender.Equals("F"))
            {
                color = Color.MistyRose;
            }
            else
            {
                color = Color.Empty;
            }
            Room room = new Room(roomElements[0], roomElements[1], roomElements[2], roomElements[3], roomElements[4], color);
            roomList.Add(room);
        }
        Repeater1.DataSource = roomList;
        Repeater1.DataBind();
    }

    /// <summary>
    /// Rooms that are already reserved are red, rooms you have clicked are yellow.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Room_Click(object sender, CommandEventArgs e)
    {
        try
        {
            //casting the sender as a Button allows us to get the properties of the clicked button
            Button btnRoomClicked = (Button)sender;
            string roomNum = btnRoomClicked.Text;
            Color colr = btnRoomClicked.BackColor;
            string reserved = "";
            string reservedOther = "";
            string gender = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Gender FROM ReservedRooms WHERE Room = '" + roomNum + "'").ToString();

            if (Session["Hall"].ToString().Equals("Eagle"))
            {
                reserved = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Reserved FROM ReservedRooms where Room = '" + roomNum + "' AND Hall = '" + Session["Hall"].ToString() + "'").ToString();
                reservedOther = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Reserved FROM ReservedRooms where Room LIKE '" + roomNum.Substring(0, 3) + "%' AND Room <> '" + roomNum + "' AND Hall = '" + Session["Hall"].ToString() + "'").ToString();
            }

            if (btnRoomClicked.BackColor == Color.Red || btnRoomClicked.BackColor == Color.DodgerBlue || btnRoomClicked.BackColor == Color.HotPink)
            {
                string school = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT School FROM ReservedRooms WHERE Hall = '" + Session["Hall"].ToString() + "' AND Room = '" + roomNum + "'").ToString();
                string type = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Type FROM ReservedRooms WHERE Hall = '" + Session["Hall"].ToString() + "' AND Room = '" + roomNum + "'").ToString();

                if (type == "Triple") roomType = RoomType.Triple;
                else if (type == "Study") roomType = RoomType.Study;
                else if (type == "Single") roomType = RoomType.Study;
                else if (type == "Double") roomType = RoomType.Double;

                Security.ShowAlertMessage("Room " + roomNum + " has already been reserved by " + school + "!");
                //return;
            }
            else if (!Session["Hall"].ToString().Equals("Eagle"))
            {
                if (btnRoomClicked.BackColor == Color.Yellow)
                {
                    lstRoomsHidden.Items.Remove(roomNum);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.White;
                    ((List<string>)Session["RoomsClicked"]).Remove(roomNum);
                }
                else
                {
                    lstRoomsHidden.Items.Add(roomNum);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.Yellow;
                }
            }
            else if (reserved.Equals("False") && reservedOther.Equals("False"))
            {
                if (btnRoomClicked.BackColor == Color.LightBlue)
                {
                    SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "UPDATE ReservedRooms SET Gender = 'F' WHERE Hall = '" + Session["Hall"].ToString() + "' AND Room LIKE '" + roomNum.Substring(0, 3) + "%'");
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.LightPink;
                }
                else if (btnRoomClicked.BackColor == Color.LightPink && !suiteRoomClicked(roomNum)) //&&SuiteRoom check
                {
                    lstRoomsHidden.Items.Remove(roomNum);
                    SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "UPDATE ReservedRooms SET Gender = NULL WHERE Hall = '" + Session["Hall"].ToString() + "' AND Room LIKE '" + roomNum.Substring(0, 3) + "%'");
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.Empty;
                    ((List<string>)Session["RoomsClicked"]).Remove(roomNum);
                }
                else if (btnRoomClicked.BackColor == Color.LightPink)
                {
                    lstRoomsHidden.Items.Remove(roomNum);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.MistyRose;
                    ((List<string>)Session["RoomsClicked"]).Remove(roomNum);
                }
                else if (btnRoomClicked.BackColor == Color.LightCyan)
                {
                    lstRoomsHidden.Items.Add(roomNum);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.LightBlue;
                }
                else if (btnRoomClicked.BackColor == Color.MistyRose)
                {
                    lstRoomsHidden.Items.Add(roomNum);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.LightPink;
                }
                else
                {
                    lstRoomsHidden.Items.Add(roomNum);
                    SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "UPDATE ReservedRooms SET Gender = 'M' WHERE Hall = '" + Session["Hall"].ToString() + "' AND Room LIKE '" + roomNum.Substring(0, 3) + "%'");
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.LightBlue;
                }
            }
            else
            {
                if (btnRoomClicked.BackColor == Color.LightBlue || btnRoomClicked.BackColor == Color.LightPink)
                {
                    lstRoomsHidden.Items.Remove(roomNum);
                    UpdateRoomsClicked();
                    if (gender.Equals("M")) btnRoomClicked.BackColor = Color.LightCyan;
                    else btnRoomClicked.BackColor = Color.MistyRose;
                    ((List<string>)Session["RoomsClicked"]).Remove(roomNum);
                }
                else
                {
                    lstRoomsHidden.Items.Add(roomNum);
                    UpdateRoomsClicked();
                }
            }
        }
        catch (Exception ex)
        {
        }
        if (Session["Hall"].ToString().Equals("Eagle"))
            readFile(false);
        //readFile(false);
    }

    private bool suiteRoomClicked(string roomNum)
    {
        List<string> roomsClicked = new List<string>();
        if (Session["RoomsClicked"] != null) roomsClicked = (List<string>)Session["RoomsClicked"];
        if (roomNum[3] == 'A')
        {
            string s = roomNum.Substring(0, 3) + "B";
            return roomsClicked.Contains(s);
        }
        else
        {
            string s = roomNum.Substring(0, 3) + "A";
            return roomsClicked.Contains(s);
        }
    }

    /// <summary>
    /// Updates a Session variable that is all the rooms clicked.
    /// We do this because we have to be able to pass this information
    /// to reserve.aspx, since the submit button is on that page.
    /// </summary>
    public void UpdateRoomsClicked()
    {
        List<string> roomsClicked = new List<string>();
        if (Session["RoomsClicked"] != null) roomsClicked = (List<string>)Session["RoomsClicked"];
        foreach (ListItem list in lstRoomsHidden.Items)
        {
            if (!roomsClicked.Contains(list.Text))
            {
                roomsClicked.Add(list.Text);
            }
        }
        if (Session["RoomsClicked"] == null) Session["RoomsClicked"] = roomsClicked;
    }

    /// <summary>
    /// Recommends rooms based on the hall selected.
    /// </summary>
    private List<string> recommendRooms()
    {
        string type;
        bool isCube;
        List<string> wingsToReserve = new List<string>();
        List<string> rooms = new List<string>();
        try
        {
            type = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT * FROM ReservedRooms where WING = '1A' and Hall = '" + Session["Hall"].ToString() + "'").ToString();
            //will only get here if above select statement works, else we know that the hall does not have cubes
            isCube = true;
        }
        catch
        {
            isCube = false;
        }
        //BEST CASE: # of rooms in any given wing/cube is >= total rooms needed +2 (leave 2 open)
        //Second best: #of rooms in two consecutive wings is >= total rooms needed + 2
        if (isCube)
        {
            wingsToReserve = parseCubeHall(roomsNeeded);
        }
        else
        {
            wingsToReserve = parseWingHall(roomsNeeded);
        }

        return getRoomsToRecommend(wingsToReserve);
    }

    /// <summary>
    /// Parses halls that have cubes (ie. Angell), to determine which cubes have enough rooms for the school
    /// </summary>
    /// <param name="roomsNeeded">The number of rooms the school needs to reserve</param>
    /// <returns>A list of cubes</returns>
    private List<string> parseCubeHall(int roomsNeeded)
    {
        Dictionary<string, int> roomsPerWing = new Dictionary<string, int>();
        List<string> wingsToReserve = new List<string>();
        string hall = Session["Hall"].ToString();
        string wing = "";
        int roomsAvailable;
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j == 0) wing = i + "A";
                else if (j == 1) wing = i + "B";
                else if (j == 2) wing = i + "C";
                else wing = i + "D";

                string type = ReserveHelper.determineRoomTypes(includeStudies, includeTriples);
                roomsAvailable = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT count(*) FROM ReservedRooms WHERE Reserved = 'False' and Hall = '" + hall + "' and Wing = '" + wing + "' AND (Type =" + type + ")").ToString());
                roomsPerWing.Add(wing, roomsAvailable);
                if (roomsAvailable >= roomsNeeded)
                {
                    wingsToReserve.Add(wing);
                    return wingsToReserve;
                }
            }
        }
        //Only gets here if no cube had enough rooms by itself
        //Now analyze Dictionary roomsPerWing, to determine which two consecutive Wings have enough rooms in that hall
        int tempVal = 0;
        string tempWing = "";
        foreach (var entry in roomsPerWing)
        {
            wing = entry.Key;
            if (tempVal + entry.Value >= roomsNeeded + 2)
            {
                //checks if wings are on same floor
                if (tempWing[0] == wing[0])
                {
                    wingsToReserve.Add(wing);
                    wingsToReserve.Add(tempWing);
                    return wingsToReserve;
                }
            }
            tempWing = entry.Key;
            tempVal = entry.Value;
        }
        //If we get here, there were not two consecutive Wings with enough rooms in that hall.
        //When this happens, just return the empty list, and select top(roomsNeeded) from that hall.
        return wingsToReserve;
    }

    /// <summary>
    /// Parses halls that have wings (not cubes) to determine which wings have enough space for the school
    /// </summary>
    /// <param name="roomsNeeded">How many rooms the school needs to reserve</param>
    /// <returns>A list of wings</returns>
    private List<string> parseWingHall(int roomsNeeded)
    {
        Dictionary<string, int> roomsPerWing = new Dictionary<string, int>();
        List<string> wingsToReserve = new List<string>();
        string hall = Session["Hall"].ToString();
        string wing = "";
        int roomsAvailable;
        //These two for loops cycle through each floor 1-5 and either Long (L) or Short (S)
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                wing = (j == 0) ? i + "L" : i + "S";
                string type = ReserveHelper.determineRoomTypes(includeStudies, includeTriples);
                roomsAvailable = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT count(*) FROM ReservedRooms WHERE Reserved = 'False' and Hall = '" + hall + "' AND Wing = '" + wing + "' AND (Type =" + type + ")").ToString());
                roomsPerWing.Add(wing, roomsAvailable);
                if (roomsAvailable >= roomsNeeded)
                {
                    wingsToReserve.Add(wing);
                    return wingsToReserve;
                }
            }
        }
        //Only gets to this point if no wing had enough rooms by itself
        //Now we want to analyze the Dictionary roomsPerWing, to determine which two consecutive Wings have enough rooms in that hall
        int tempVal = 0;
        string tempWing = "";
        foreach (var entry in roomsPerWing)
        {
            wing = entry.Key;
            if (tempVal + entry.Value >= roomsNeeded + 2)
            {
                //checks if wings are on same floor
                if (tempWing[0] == wing[0])
                {
                    wingsToReserve.Add(wing);
                    wingsToReserve.Add(tempWing);
                    return wingsToReserve;
                }
            }
            tempWing = entry.Key;
            tempVal = entry.Value;
        }
        //If we get here, there were not two consecutive Wings with enough rooms in that hall.
        //When this happens, just return the empty list, and select top(roomsNeeded) from that hall.
        return wingsToReserve;
    }

    private List<string> getRoomsToRecommend(List<string> wingsToReserve)
    {
        List<string> rooms = new List<string>();
        string type = ReserveHelper.determineRoomTypes(includeStudies, includeTriples);
        //count of 0 means that there were not consecutive wings able to hold school
        if (wingsToReserve.Count == 0)
        {
            DataSet dsRooms = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT TOP " + roomsNeeded + " Room FROM ReservedRooms WHERE Reserved = 'False' and Hall = '" + Session["Hall"].ToString() + "' and (Type =" + type + ")");
            for (int i = 0; i < roomsNeeded; i++)
            {
                try
                {
                    rooms.Add(dsRooms.Tables[0].Rows[i]["Room"].ToString());
                }
                catch
                {
                    //There were not enough rooms to reserve in this hall
                    return rooms;
                }
            }
        }
        else
        {
            int i;
            string wings = (wingsToReserve.Count > 1) ? " and (Wing = '" + wingsToReserve[0].ToString() + "' or Wing = '" + wingsToReserve[1].ToString() + "')" : "and Wing = '" + wingsToReserve[0].ToString() + "'";
            string query = "SELECT TOP " + roomsNeeded + " Room FROM ReservedRooms WHERE Reserved = 'False' and Hall = '" + Session["Hall"].ToString() + "'" + wings + " and (Type = " + type + ")";
            DataSet dsRooms = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, query);
            for (i = 0; i < roomsNeeded; i++)
            {
                rooms.Add(dsRooms.Tables[0].Rows[i]["Room"].ToString());
            }
            dsRooms.Clear();
        }
        return rooms;
    }
}