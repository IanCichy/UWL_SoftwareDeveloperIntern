﻿using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["Report"] == null)
        {
            Response.Redirect("Reports.aspx");
        }

        sqlShifts.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;

        if (!IsPostBack)
        {
            int Report = (int.Parse(Request.Params["Report"]));
        }

        if (Session["ShiftID"]!=null  && int.Parse(Session["ShiftID"].ToString()) >= 0)
        {
            colorRow(int.Parse(Session["ShiftID"].ToString()));
        }


        colorRows();
    }


    public void colorRow(int ID)
    {
        foreach (GridViewRow row in gvShifts.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
               int key = int.Parse(gvShifts.DataKeys[row.RowIndex].Value.ToString());
               if (key == ID)
               {
                   row.Cells[0].BackColor = Color.FromArgb(214, 139, 139);
                   row.Cells[1].BackColor = Color.FromArgb(214, 139, 139);
                   row.Cells[2].BackColor = Color.FromArgb(214, 139, 139);
                   row.Cells[3].BackColor = Color.FromArgb(214, 139, 139);
                   row.Cells[4].BackColor = Color.FromArgb(214, 139, 139);
                   row.Cells[9].BackColor = Color.FromArgb(214, 139, 139);
               }
            }
        }
    }




    /*
     * Created by: Ian Cichy - 1/22/15
     * pre/post:Colors Rows in the gridview to represent different errors or resolved checkbox selections
     */

    public void colorRows()
    {
        foreach (GridViewRow row in gvShifts.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox pizza = (CheckBox)row.Cells[5].Controls[0];
                CheckBox cshIn = (CheckBox)row.Cells[6].Controls[0];
                CheckBox cshOut = (CheckBox)row.Cells[7].Controls[0];
                CheckBox Resolved = (CheckBox)row.Cells[8].Controls[0];

                if (Resolved != null && Resolved.Checked)
                {
                    row.Cells[8].BackColor = Color.FromArgb(195, 232, 158);
                }
                else
                {
                    if (pizza != null && pizza.Checked)
                    {
                        row.Cells[5].BackColor = Color.FromArgb(255, 207, 124);
                    }
                    if (cshIn != null && cshIn.Checked)
                    {
                        row.Cells[6].BackColor = Color.FromArgb(255, 160, 126);
                    }
                    if (cshOut != null && cshOut.Checked)
                    {
                        row.Cells[7].BackColor = Color.FromArgb(214, 139, 139);
                    }
                }
            }
        }
    }

    /*
     * Created by: Ian Cichy - 1/22/15
     * pre/post:Upon selection takes you to the shift details of the shift selected in the gridview
     */

    protected void gvShifts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ShiftDetails"))
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;

            var shiftID = int.Parse(gvShifts.DataKeys[rowIndex]["shiftID"].ToString());
            Response.Redirect("ShiftDetails.aspx?report=" + Request.Params["Report"] + "&shift=" + shiftID.ToString());
        }
    }

    protected void btnViewWeeklyAccountable_Click(object sender, EventArgs e)
    {
        Response.Redirect("WeeklyReport.aspx?report=" + int.Parse(Request.Params["Report"]));
    }

    protected void btnViewWeeklyNonAccountable_Click(object sender, EventArgs e)
    {
        Response.Redirect("WeeklyReportNoAccount.aspx?report=" + int.Parse(Request.Params["Report"]));
    }
}