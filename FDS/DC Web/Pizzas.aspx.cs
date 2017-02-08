﻿using FDS;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pizzas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlPizzas.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizza.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        btnAddingPizza.Enabled = false;//Disabled for now
        btnSellProgramPizza.Enabled = false;//Disabled for now

    }

    #region AddPizza

    protected void btnAddPizza_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (IsValid)
        {
            Pizza newPizza = Pizza.AddPizza(txtName.Text, txtBrand.Text, Hall.GetHallById(int.Parse((string)Session["hall"])), decimal.Parse(txtPrice.Text), int.Parse(txtInventory.Text), chkActive.Checked);
             if (newPizza == null && Pizza.GetProductByNameAndHall(txtName.Text, Hall.GetHallById(int.Parse((string)Session["hall"]))) != null)
             {
                 Session["error"] = "There is already a product with that name in this hall.";
                 Response.Redirect(Request.RawUrl);
             }
             else if (newPizza == null)
             {
                 Session["error"] = "There was a problem adding this product. Please contact RLIS with the full details of your issue.";
                 Response.Redirect(Request.RawUrl);
             }
            divAddPizza.Style["Display"] = "none";
            divAddingPizza.Style["Display"] = "inline";
            gvPizzas.DataBind();
        }
        txtBrand.Text = "";
        txtInventory.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";
        chkActive.Checked = false;
    }

    /*
     * Displays controls for adding a pizza 
     */

    protected void btnAddingPizza_Click(object sender, EventArgs e)
    {
        divAddPizza.Style["Display"] = "inline";
        divAddingPizza.Style["Display"] = "none";
    }

    /*
     * Cancels the creation of a new pizza and clears fields
     */

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBrand.Text = "";
        txtInventory.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";
        chkActive.Checked = false;
        divAddingPizza.Style["Display"] = "inline";
        Response.Redirect(Request.RawUrl);
    }

    #endregion AddPizza

    /*
     * Method to filter gridview to show the selected amount of rows per page
     */

    protected void DdlItemsfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvPizzas.PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        gvPizzas.DataBind();
    }

    /*
     * Displays a hidden 5th row which contains the "reason" field when editiing a pizza
     */

    protected void gvPizzas_Edit(object sender, EventArgs e)
    {
        gvPizzas.Columns[5].Visible = true;
    }

    /*
    * Hides a hidden 5th row which contains the "reason" field when editiing a pizza
    */

    protected void gvPizzas_Cancel(object sender, EventArgs e)
    {
        gvPizzas.Columns[5].Visible = false;
    }

    /*
     * Keeps track of the edit reason when updating a row in the pizza gridview 
     * Also, records the user which made the edit and refreshes the page
     */

    protected void gvPizzas_Update(object sender, EventArgs e)
    {
        String Reason = "";
        try
        {
            foreach (GridViewRow row in gvPizzas.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && ((TextBox)row.FindControl("EditReason") != null) &&
                    (!((TextBox)row.FindControl("EditReason")).Text.ToString().Trim().Equals("")))
                {
                    TextBox Rsn = (TextBox)row.FindControl("EditReason");
                    Reason = Rsn.Text.ToString();
                    break;
                }
            }
        }
        catch (Exception)
        {
        }
        gvPizzas.Columns[5].Visible = false;
        Session["Reason"] = "DC Web User: " + Session["username"] + " - " + Reason;
        if (Reason.Equals(""))
        {
            Session["error"] = "Please Enter A Valid Reason";
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void gvPizzas_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        gvPizzaInventory.DataBind();
    }

    #region Program Pizza

    /*
     * Hides all current controls and displays a seperate gridview for 
     * program pizza entering by DC's
     */

    protected void btnSellProgramPizza_Click(object sender, EventArgs e)
    {
        gvPizzas.Visible = false;
        gvPizzaInventory.Visible = false;
        gvProgramPizza.Visible = true;
        divAddingPizza.Style["Display"] = "none";
        divProgramPizza.Style["Display"] = "inline";
    }

    protected void btnConfirmProgramPizza_Click(object sender, EventArgs e)
    {
        int Quantity = -1;
        String Reason = "ERROR";
        Button btn = (Button)sender;
        var ProductID = int.Parse(btn.CommandArgument.ToString());
        int Inventory = FDS.Pizza.ProgramCount(ProductID);
        try
        {
            foreach (GridViewRow row in gvProgramPizza.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && ((TextBox)row.FindControl("txtReason") != null) && ((TextBox)row.FindControl("txtQuantity") != null)
                    && (!((TextBox)row.FindControl("txtReason")).Text.ToString().Trim().Equals("")))
                {
                    TextBox Rsn = (TextBox)row.FindControl("txtReason");
                    TextBox Qty = (TextBox)row.FindControl("txtQuantity");
                    Quantity = int.Parse(Qty.Text.ToString());
                    Reason = Rsn.Text.ToString();
                    break;
                    //System.Diagnostics.Debug.WriteLine(Rsn.Text.ToString());
                    //System.Diagnostics.Debug.WriteLine(Qty.Text.ToString());
                    //OnClientClick="return confirm('Are you sure you want to confirm this item?');"
                }
            }

            if (Inventory - Quantity >= 0 && Quantity > 0)
            {
                Inventory -= Quantity;
                FDS.Pizza.ProgramPizza(ProductID, Hall.GetHallById(int.Parse((string)Session["hall"])), Session["username"].ToString(), Quantity, Reason);
                FDS.Pizza.ProgramUpdate(ProductID, Inventory);
            }
            else
            {
                throw new FormatException();
            }
            Session["success"] = Quantity + " : Program Pizza(s) <br/>Given For: " + Reason;
            Response.Redirect(Request.RawUrl);
        }
        catch (FormatException)
        {
            Session["error"] = "There was a problem with the quantity or reason!<br/> Please ensure the quantity is lower that the inventory count and a valid reason is entered.";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    #endregion Program Pizza

    #region Excel Export

    /*
     * Export to excel
     *
     */

    protected void btnExportPizza_Click(object sender, EventArgs e)
    {
        gvPizzas.AllowPaging = false;
        gvPizzas.PageSize = int.MaxValue;
        gvPizzas.Columns.RemoveAt(6);
        gvPizzas.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=PizzaInventory.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        gvPizzas.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    #endregion Excel Export

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post:Standard method used for all gridviews to display up/down arrows
     * when the data rows are being sorted
     */

    protected void gvPizzas_RowCreated(object sender, GridViewRowEventArgs e)
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
                        img.ImageUrl = "Assets/Images/" + (gvPizzas.SortDirection == SortDirection.Ascending ? "arrow_up" : "arrow_down") + ".png";
                        img.Width = 16;
                        img.Height = 8;
                        // checking if the header link is the user's choice
                        if (gvPizzas.SortExpression == lnk.CommandArgument)
                        {
                            // adding a space and the image to the header link
                            tc.Controls.Add(img);
                        }
                    }
                }
            }
        }
    }

    /*
Possible Delete Method Upon Approval
 *                             <!--<asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this item?');"
                        OnClick="DeleteItem_Click" CommandArgument='<%# Eval("productID") %>' CommandName="ProdID" Text="Delete" />!-->
protected void DeleteItem_Click(object sender, EventArgs e)
{
    Button btn = (Button)sender;
    FDS.Pizza.DeletePizza(int.Parse(btn.CommandArgument.ToString()));
    gvPizzas.DataBind();

    Response.Redirect(Request.RawUrl);
}
*/

}