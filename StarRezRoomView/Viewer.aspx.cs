using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Viewer : System.Web.UI.Page
{
    private RoomControl RC;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlOccupant.ConnectionString = Data.SRRVConnection().ConnectionString;

        string hall = HallDropDown.Text.Replace(" ", "");
        Session["Hall"] = hall;

        if (!chkGender.Checked)
        {
            FillColorMapNonG();
        }
        else
        {
            FillColorMapG();
        }
    }

    protected void HallDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string hall = HallDropDown.Text.Replace(" ", "");
            Session["Hall"] = hall;

            try
            {
                ArrayList Details = Data.getHallDetails(Session["Hall"].ToString());
                Details.ToArray();

                lblHall.Text = Details[0].ToString();
                lblRooms.Text = Details[1].ToString();
                lblBeds.Text = Details[2].ToString();
                lblMale.Text = Details[3].ToString();
                lblFemale.Text = Details[4].ToString();
                lblEle.Text = Details[4].ToString();
            }
            catch (Exception)
            {
            }

            //Makes sure all other panels are set to visible=false when swapping halls
            for (int i = 1; i < HallDropDown.Items.Count; i++)
            {
                Control con = UpdPnlRoomView.FindControl(HallDropDown.Items[i].Text.Replace(" ", ""));
                Panel lastPanel = (Panel)con;
                lastPanel.Visible = false;
            }

            Control con2 = UpdPnlRoomView.FindControl(hall);
            Panel panel = (Panel)con2;

            Control con3 = panel.FindControl("tbc" + Session["Hall"].ToString());
            AjaxControlToolkit.TabContainer tabCon = (AjaxControlToolkit.TabContainer)con3;

            Control con4 = tabCon.FindControl("Tbp" + Session["Hall"].ToString() + (tabCon.ActiveTabIndex + 1));
            AjaxControlToolkit.TabPanel tbp = (AjaxControlToolkit.TabPanel)con4;

            Control con5 = tbp.FindControl("Rmc" + Session["Hall"].ToString() + (tabCon.ActiveTabIndex + 1));
            RC = (RoomControl)con5;

            if (!chkGender.Checked)
            {
                RC.ColorRooms();
            }
            else
            {
                RC.ColorRoomsGendered();
            }

            panel.Visible = true;
            Session["Panel"] = panel;
        }
        catch (Exception)
        {
        }




    }

    protected void Tbc_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            Control con2 = UpdPnlRoomView.FindControl(Session["Hall"].ToString());
            Panel panel = (Panel)con2;

            Control con3 = panel.FindControl("tbc" + Session["Hall"].ToString());
            AjaxControlToolkit.TabContainer tabCon = (AjaxControlToolkit.TabContainer)con3;

            Control con4 = tabCon.FindControl("Tbp" + Session["Hall"].ToString() + (tabCon.ActiveTabIndex + 1));
            AjaxControlToolkit.TabPanel tbp = (AjaxControlToolkit.TabPanel)con4;

            Control con5 = tbp.FindControl("Rmc" + Session["Hall"].ToString() + (tabCon.ActiveTabIndex + 1));
            RC = (RoomControl)con5;

            if (!chkGender.Checked)
            {
                RC.ColorRooms();
            }
            else
            {
                RC.ColorRoomsGendered();
            }
        }
        catch (Exception)
        {
        }
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        lblStudentID.Text = gvOccupants.SelectedRow.Cells[0].Text;
        ArrayList Details = Data.getOccupantDetails(lblStudentID.Text);

        Details.ToArray();

        lblFName.Text = Details[0].ToString();
        lblLName.Text = Details[1].ToString();
        lblGender.Text = Details[2].ToString();
        lblAge.Text = Details[3].ToString();
        lblInternational.Text = Details[4].ToString().ToLower();
        lblEmail.Text = Details[5].ToString();
        lblCell.Text = Details[6].ToString(); ;
        lblCheckInDate.Text = Details[7].ToString();
        lblCheckOutDate.Text = Details[8].ToString();
        lblRoom.Text = Details[9].ToString();
        lblRoomType.Text = Details[10].ToString();
        lblDisabled.Text = Details[11].ToString().ToLower();

        mpe.Show();
    }

    protected void FillColorMapNonG()
    {
        if (Session["Hall"].ToString().Contains("Angell") ||
            Session["Hall"].ToString().Contains("Coate") ||
            Session["Hall"].ToString().Contains("Drake") ||
            Session["Hall"].ToString().Contains("Hutch"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(189, 212, 130); //Green
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(239, 207, 103); //Yellow
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(226, 147, 101); //Orange
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(213, 100, 98); //Red
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 101, 186); //ERRPinkishREd
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else if (Session["Hall"].ToString().Contains("Laux") ||
            Session["Hall"].ToString().Contains("Wentz") ||
            Session["Hall"].ToString().Contains("Sanford") ||
            Session["Hall"].ToString().Contains("White"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(189, 212, 130); //Green
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(239, 207, 103); //Yellow
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(226, 147, 101); //Orange
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(213, 100, 98); //Red
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("4/5 Person Study"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(195, 146, 226); //Lblue
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 101, 186); //ERRPinkishREd
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else if (Session["Hall"].ToString().Contains("Eagle"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(60, 161, 189); //blue
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(189, 212, 130); //Green
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(239, 207, 103); //yellow
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(226, 147, 101); //Orange
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 101, 186); //ERRPinkishREd
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else
        {
        }
    }

    protected void FillColorMapG()
    {
        if (Session["Hall"].ToString().Contains("Angell") ||
            Session["Hall"].ToString().Contains("Coate") ||
            Session["Hall"].ToString().Contains("Drake") ||
            Session["Hall"].ToString().Contains("Hutch"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Male"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Female"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 251, 255); //LightBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 192, 221); //LightPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(127, 213, 232);//DGBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(222, 116, 232);//DGPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(69, 140, 156);//MedBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(148, 62, 156);//MedPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(223, 178, 141); //Greenblu
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 130, 113); //Redpink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(146, 101, 63); //ErrorBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(156, 60, 45); //ErrorPin
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else if (Session["Hall"].ToString().Contains("Laux") ||
            Session["Hall"].ToString().Contains("Wentz") ||
            Session["Hall"].ToString().Contains("Sanford") ||
            Session["Hall"].ToString().Contains("White"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Male"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Female"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 251, 255); //LightBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 192, 221); //LightPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(127, 213, 232);//DGBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(222, 116, 232);//DGPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(69, 140, 156);//MedBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(148, 62, 156);//MedPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("4/5 Person Study"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(40, 156, 141); //5PersonStudy
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("4/5 Person Study"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(104, 45, 156); //5personstudy
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(223, 178, 141); //Greenblu
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 130, 113); //Redpink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(146, 101, 63); //ErrorBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(156, 60, 45); //ErrorPin
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else if (Session["Hall"].ToString().Contains("Eagle"))
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Controls.Add(new LiteralControl("Male"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Female"));
            c.ColumnSpan = 2;
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(207, 251, 255); //LightBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 192, 221); //LightPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(69, 140, 156);//MedBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(190, 50, 226); //DrkPur
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(127, 213, 232);//DGBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Triple"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(222, 116, 232);//DGPink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(223, 178, 141); //Greenblu
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Double Single"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(232, 130, 113); //Redpink
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);

            r = new TableRow();
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(146, 101, 63); //ErrorBlue
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl("Not Full"));
            r.Cells.Add(c);
            c = new TableCell();
            c.Controls.Add(new LiteralControl(""));
            c.BackColor = Color.FromArgb(156, 60, 45); //ErrorPin
            r.Cells.Add(c);
            ColorMap.Rows.Add(r);
        }
        else
        {
        }
    }

    protected void gvOccupants_DataBinding(object sender, EventArgs e)
    {
        if (Session["Color"] != null)
        {
            gvOccupants.HeaderStyle.BackColor = (Color)Session["Color"];
        }
    }

}