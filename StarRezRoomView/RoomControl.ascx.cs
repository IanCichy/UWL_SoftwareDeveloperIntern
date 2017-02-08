using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomControl : System.Web.UI.UserControl
{
    private string map;

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
        if (!IsPostBack)
        {
            readFile();
            Session["Room"] = "";
        }
        else
        {
        }
    }

    /// <summary>
    /// Reads the .map file that is specified by the Map value set on RoomControl.ascx. After the
    /// file is parsed, a list of Room objects is created, which is used as the datasource for the Repeater.
    /// </summary>
    public void readFile()
    {
        //reset the datasource to avoid errors
        rptrRooms.DataSource = null;
        Color color;
        string line;
        String[] roomElements;
        List<Room> roomList = new List<Room>();

        StreamReader file = File.OpenText(HttpContext.Current.Server.MapPath("~/HallFiles/" + map + ".map"));
        //parse the whole file
        while ((line = file.ReadLine()) != null)
        {
            roomElements = line.Split(' ');
            string hall = map.Remove(map.Length - 1);

            color = Color.FromArgb(239, 207, 103); //yellow
            
            Room room = new Room(roomElements[0], roomElements[1], roomElements[2], roomElements[3], roomElements[4], color);
            roomList.Add(room);
        }
        rptrRooms.DataSource = roomList;
        rptrRooms.DataBind();
    }

    protected void btnRoom_Click(object sender, EventArgs e)
    {
        ResetSelected();
        Button btnRoomClicked = (Button)sender;
        Session["Color"] = btnRoomClicked.BackColor;//Grabs color for gridview header
        btnRoomClicked.CssClass = "RoomButtonSelected";
        string roomNum = btnRoomClicked.Text;
        string Hall = Session["Hall"].ToString();

        if ((Hall.Equals("EagleGray")) || (Hall.Equals("EagleMaroon")))
        {
            Session["Room"] = "Eagle-" + roomNum.Substring(0, 3) + "-" + roomNum.Substring(3);
        }
        else
        {
            Session["Room"] = Hall + "-" + roomNum;
        }
    }

    public void ResetSelected()
    {
        string Hall = Session["Hall"].ToString();
        foreach (Control c in rptrRooms.Items)
        {
            if (c.FindControl("btnRoom") != null)
            {
                Button Btn = (Button)c.FindControl("btnRoom");
                Btn.CssClass = "RoomButton";
            }
        }
    }

    public void ColorRooms()
    {
        string Hall = Session["Hall"].ToString();
        foreach (Control c in rptrRooms.Items)
        {
            if (c.FindControl("btnRoom") != null)
            {
                Button Btn = (Button)c.FindControl("btnRoom");
                string roomNum = Btn.Text;

                if ((Hall.Equals("EagleGray")) || (Hall.Equals("EagleMaroon")))
                {
                    Session["Room"] = "Eagle-" + roomNum.Substring(0, 3) + "-" + roomNum.Substring(3);
                }
                else
                {
                    Session["Room"] = Hall + "-" + roomNum;
                }

                Btn.BackColor = Data.GetRoomColor(Session["Room"].ToString());
            }
        }
        Session["Room"] = null;
    }

    public void ColorRoomsGendered()
    {
        string Hall = Session["Hall"].ToString();
        foreach (Control c in rptrRooms.Items)
        {
            if (c.FindControl("btnRoom") != null)
            {
                Button Btn = (Button)c.FindControl("btnRoom");
                string roomNum = Btn.Text;

                if ((Hall.Equals("EagleGray")) || (Hall.Equals("EagleMaroon")))
                {
                    Session["Room"] = "Eagle-" + roomNum.Substring(0, 3) + "-" + roomNum.Substring(3);
                }
                else
                {
                    Session["Room"] = Hall + "-" + roomNum;
                }

                Btn.BackColor = Data.GetRoomColorGendered(Session["Room"].ToString());
            }
        }
        Session["Room"] = null;
    }
}