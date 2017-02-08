using FDS;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class PizzaStats : System.Web.UI.Page
{
    /*
    * Created by: Ian Cichy - 6/15
    * pre/post: Server Connections and redirect if no hall is selected
    * Gets all possible terms for stats and selects the most recent term in the database
    * Then displays the correct stats in the gridview
    */

    private List<Term> Terms;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlPizzaStats.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;

        if (!IsPostBack)
        {
            Terms = Term.GetAllTerms();
            foreach (var term in Terms)
            {
                ddlTerms.Items.Add(new ListItem(term.Name));
            }
            Session["startDate"] = Term.getTermStartDate(Terms[ddlTerms.SelectedIndex]);
            Session["endDate"] = Term.getTermEndDate(Terms[ddlTerms.SelectedIndex]);
            gvPizzaStats.DataBind();
        }
    }

    /*
     * Gets all possible terms for stats and selects the most recent term in the database
     * Then displays the correct stats in the gridview
     */

    protected void ddlTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
        Terms = Term.GetAllTerms();
        Session["startDate"] = Term.getTermStartDate(Terms[ddlTerms.SelectedIndex]);
        Session["endDate"] = Term.getTermEndDate(Terms[ddlTerms.SelectedIndex]);
        gvPizzaStats.DataBind();
    }

    /*
    * Created by: Ian Cichy - 6/14
    * pre/post:Standard method used for all gridviews to display up/down arrows
    * when the data rows are being sorted
    */

    protected void gvPizzaStats_RowCreated(object sender, GridViewRowEventArgs e)
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
                        img.ImageUrl = "Assets/Images/" + (gvPizzaStats.SortDirection == SortDirection.Ascending ? "arrow_up" : "arrow_down") + ".png";
                        img.Width = 16;
                        img.Height = 8;
                        // checking if the header link is the user's choice
                        if (gvPizzaStats.SortExpression == lnk.CommandArgument)
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