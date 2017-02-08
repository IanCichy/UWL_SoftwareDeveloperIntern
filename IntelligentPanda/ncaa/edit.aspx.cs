using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class ncaa_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.hasRights(2))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        if (!IsPostBack)
        {
            List<RoomReservation> rooms = NcaaReservation.GetAllNCAARooms();
            List<NcaaReservation> reservations = new List<NcaaReservation>();
            foreach (RoomReservation room in rooms)
            {
                if (reservations == null || reservations.Count == 0)
                {
                    reservations = NcaaReservation.FindReservations(room.hall, room.room);
                }
                NcaaReservation res = reservations[0];
                reservations.RemoveAt(0);
                cblRooms.Items.Add(String.Format("{0} {1} - {2}", room.hall, room.room, res.school == "" ? res.fname + " " + res.lname : res.school));
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in cblRooms.Items)
        {
            if (li.Selected)
            {
                NcaaReservation.RemoveReservation(li.Text.Split(' ')[0], li.Text.Split(' ')[1], li.Text.Split('-')[1].Trim());
            }
        }
    }
}