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
            readFile();
        }
    }

    /// <summary>
    /// Reads the .map file that is specified by the Map value set on RoomControl.ascx.
    /// After the file is parsed, a list of Room objects is created, which is used as
    /// the datasource for the Repeater.
    /// If the room is reserved, the button color will be red.
    /// </summary>
    private void readFile()
    {
        //reset the datasource to avoid errors
        Repeater1.DataSource = null;
        Color color;
        string line;
        string[] roomElements;
        List<Room> roomList = new List<Room>();

        StreamReader file = File.OpenText(HttpContext.Current.Server.MapPath("~/HallFiles/" + map + ".map"));
        //parse the whole file
        while ((line = file.ReadLine()) != null)
        {
            roomElements = line.Split(' ');
            string hall = map.Remove(map.Length - 1);
            string gender = SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT Gender FROM Beds_View where Room = '" + roomElements[0] + "' AND Hall = '" + hall + "'").ToString();
            int openBeds = Int32.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT OpenBeds FROM Beds_View where Room = '" + roomElements[0] + "' AND Hall = '" + hall + "'").ToString());
            int beds = Int32.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT Beds FROM Beds_View where Room = '" + roomElements[0] + "' AND Hall = '" + hall + "'").ToString());

            //if the room is reserved, the button turns red.
            if (openBeds <= 0)
            {
                color = Color.Red;
            }
            else if (beds == openBeds)
            {
                color = Color.Empty;
            }
            else
            {
                if (gender == "f")
                {
                    color = Color.LightPink;
                }
                else if (gender == "m")
                {
                    color = Color.CornflowerBlue;
                }
                else
                {
                    color = Color.LightGreen;
                }
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
            string gender = (string)Session["Gender"];
            int openBeds = Int32.Parse(SqlHelper.ExecuteScalar(Settings.NCAAConnection, CommandType.Text, "SELECT OpenBeds FROM Beds_View where Room = '" + roomNum + "' AND Hall = '" + Session["Hall"].ToString() + "'").ToString());
            int beds = (int)Session["Beds"];
            string roomString = roomNum + ":" + gender.ToLower().Substring(0, 1) + ":" + beds;
            if (btnRoomClicked.BackColor == Color.Red)
            {
                Security.ShowAlertMessage("Room " + roomNum + " has already been reserved!");
                //return;
            }
            else if (btnRoomClicked.BackColor == Color.Yellow)
            {
                btnRoomClicked.BackColor = Color.White;
                List<string> roomsclicked = ((List<string>)Session["RoomsClicked"]);
                foreach (string s in roomsclicked)
                {
                    if (s.Split(':')[0] == roomNum)
                    {
                        lstRoomsHidden.Items.Remove(s);
                        roomsclicked.Remove(s);
                        UpdateRoomsClicked();
                    }
                }
                Session["RoomsClicked"] = roomsclicked;
            }
            else if (beds > openBeds)
            {
                Security.ShowAlertMessage("Room " + roomNum + " has " + openBeds + " beds left and you are trying to reserve " + beds + " beds!");
            }
            else if (btnRoomClicked.BackColor == Color.CornflowerBlue)
            {
                if (gender == "Female")
                {
                    Security.ShowAlertMessage("This room is a male room and you are currently selecting rooms for females.");
                }
                else
                {
                    lstRoomsHidden.Items.Add(roomString);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.Yellow;
                }
            }
            else if (btnRoomClicked.BackColor == Color.LightPink)
            {
                if (gender == "Male")
                {
                    Security.ShowAlertMessage("This room is a female room and you are currently selecting rooms for males.");
                }
                else
                {
                    lstRoomsHidden.Items.Add(roomString);
                    UpdateRoomsClicked();
                    btnRoomClicked.BackColor = Color.Yellow;
                }
            }
            else
            {
                lstRoomsHidden.Items.Add(roomString);
                UpdateRoomsClicked();
                btnRoomClicked.BackColor = Color.Yellow;
            }
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// Updates a Session variable that is all the rooms clicked.
    /// We do this because we have to be able to pass this information
    /// to reserve.aspx, since the submit button is on that page.
    /// </summary>
    private void UpdateRoomsClicked()
    {
        List<string> roomsClicked = new List<string>();
        Dictionary<string, string> genders = new Dictionary<string, string>();
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
}