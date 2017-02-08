using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shifts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlShifts.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
    }

    protected void gvShifts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ShiftDetails"))
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;

            var shiftID = int.Parse(gvShifts.DataKeys[rowIndex]["shiftID"].ToString());
            Response.Redirect("ShiftDetails.aspx?shift=" + shiftID.ToString());
        }
    }

    public static string Limit(object Desc)
    {
        if (Desc.ToString().Length > 25)
        {
            return Desc.ToString().Substring(0, 25) + " . . .";
        }
        else
            return Desc.ToString();
    }

    protected void gvShifts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                if (tc.HasControls())
                {
                    // search for the header link
                    LinkButton lnk = (LinkButton)tc.Controls[0];
                    if (lnk != null)
                    {
                        // inizialize a new image
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        // setting the dynamically URL of the image
                        img.ImageUrl = "Assets/Images/" + (gvShifts.SortDirection == SortDirection.Ascending ? "arrow_up" : "arrow_down") + ".png";
                        img.Width = 16;
                        img.Height = 8;
                        // checking if the header link is the user's choice
                        if (gvShifts.SortExpression == lnk.CommandArgument)
                        {
                            // adding a space and the image to the header link
                            tc.Controls.Add(img);
                        }
                    }
                }
            }
        }
    }
}