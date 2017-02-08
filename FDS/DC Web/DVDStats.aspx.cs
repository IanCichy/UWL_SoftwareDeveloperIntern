using System;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class DVDStats : System.Web.UI.Page
{
    /*
    * Created by: Ian Cichy - 7/15
    * pre/post: Server Connections and redirect if no hall is selected
    */

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlDVDStats.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
    }

    /*
    * Created by: Ian Cichy - 7/15
    * pre/post:Adjusts the size of the number of items per page in the gridview selected
    */

    protected void DdlItemsfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvDVDStats.PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        gvDVDStats.DataBind();
    }

    /*
    * Created by: Ian Cichy - 7/15
    * pre/post:Standard method used for all gridviews to display up/down arrows
    * when the data rows are being sorted
    */

    protected void gvDVDStats_RowCreated(object sender, GridViewRowEventArgs e)
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
                        img.ImageUrl = "Assets/Images/" + (gvDVDStats.SortDirection == SortDirection.Ascending ? "arrow_up" : "arrow_down") + ".png";
                        img.Width = 16;
                        img.Height = 8;
                        // checking if the header link is the user's choice
                        if (gvDVDStats.SortExpression == lnk.CommandArgument)
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