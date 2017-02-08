using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wiaa_Controls_ReuterRoomControl : System.Web.UI.UserControl
{
    /// <summary>
    /// The map file that gets set on RoomControl.ascx.
    /// </summary>
    private string map;

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
            Session["ReuterRoomsClicked"] = null;
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
            string roomStatus = ReserveHelper.getVolunteerRoomStatus(roomElements[0]);
            if (roomStatus == "Full")
            {
                color = Color.Red;
            }
            else if (roomStatus == "Partial")
            {
                color = Color.LightGreen;
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
            if (btnRoomClicked.BackColor == Color.Red)
            {
                Security.ShowAlertMessage("Room " + roomNum + " has already been reserved!");
            }
            else if (btnRoomClicked.BackColor == Color.Yellow)
            {
                lstRoomsHidden.Items.Remove(roomNum);
                UpdateRoomsClicked();
                btnRoomClicked.BackColor = Color.White;
                ((List<string>)Session["ReuterRoomsClicked"]).Remove(roomNum);
            }
            else
            {
                if (lstRoomsHidden.Items.Count > 0)
                {
                    Security.ShowAlertMessage("Warning - Only one room may be reserved per volunteer.");
                }
                lstRoomsHidden.Items.Add(roomNum);
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
        if (Session["ReuterRoomsClicked"] != null) roomsClicked = (List<string>)Session["ReuterRoomsClicked"];
        foreach (ListItem list in lstRoomsHidden.Items)
        {
            if (!roomsClicked.Contains(list.Text))
            {
                roomsClicked.Add(list.Text);
            }
        }
        if (Session["ReuterRoomsClicked"] == null) Session["ReuterRoomsClicked"] = roomsClicked;
    }
}