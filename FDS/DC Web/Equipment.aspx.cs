using FDS;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Equipment : System.Web.UI.Page
{

                             /* <!--  <asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this item?');"
                                OnClick="DeleteItem_Click" CommandArgument='<%# Eval("equipmentID") %>' CommandName="EquipID" Text="Delete" /> !-->*/


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlEquipment.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlHistory.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;

        if (gvEquipment.EditIndex < 0)
        {
            lblConditionChanged.Text = "";
            lblStatusChanged.Text = "";
        }
    }

    protected void btnAddEquipment_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (IsValid)
        {
            FDS.Equipment newEquipment = FDS.Equipment.CreateEquipment(Hall.GetHallById(int.Parse((string)Session["hall"])), txtName.Text, txtCategory.Text);
            if (newEquipment == null && FDS.Equipment.GetEquipmentByHallAndName(Hall.GetHallById(int.Parse((string)Session["hall"])), txtName.Text) != null)
            {
                Session["error"] = "There is already equipment with that name in this hall.";
                Response.Redirect(Request.RawUrl);
            }
            else if (newEquipment == null)
            {
                Session["error"] = "There was a problem adding this equipment. Please contact RLIS with the full details of your issue.";
                Response.Redirect(Request.RawUrl);
            }
            divAddEquipment.Style["Display"] = "none";
            divAddingEquipment.Style["Display"] = "inline";
            gvEquipment.DataBind();

            txtName.Text = "";
            txtCategory.Text = "";
        }
    }

    #region Excel Export

    protected void btnExportEquip_Click(object sender, EventArgs e)
    {
        gvEquipment.AllowPaging = false;
        gvEquipment.PageSize = int.MaxValue;
        gvEquipment.Columns.RemoveAt(4);
        gvEquipment.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=EquipmentInventory.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        gvEquipment.RenderControl(htmlWrite);
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
 *
 * Possible Delete Method Upon Approval
 */

    protected void DeleteItem_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        FDS.Equipment.DeleteEquipment(int.Parse(btn.CommandArgument.ToString()));
        gvEquipment.DataBind();

        //Response.Redirect(Request.RawUrl);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtCategory.Text = "";
        divAddingEquipment.Style["Display"] = "inline";
        Response.Redirect(Request.RawUrl);
    }

    protected void lnkAddEquipment_Click(object sender, EventArgs e)
    {
        divAddEquipment.Style["Display"] = "inline";
        divAddingEquipment.Style["Display"] = "none";
    }

    protected void gvEquipment_RowEdit(object sender, GridViewEditEventArgs e)
    {
        //METHOD TO COME LATER TO AUTO SET VALUES
    }

    protected void DdlItemsfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvEquipment.PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        gvEquipment.DataBind();
    }

    protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblConditionChanged.Text = ((DropDownList)sender).SelectedValue;
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblStatusChanged.Text = ((DropDownList)sender).SelectedValue;
    }

    protected void sqlEquipment_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblConditionChanged.Text = "";
        lblStatusChanged.Text = "";
    }

    protected void EquipHistory_Click(object sender, EventArgs e) 
    {
        Button btn = (Button)sender;
        var EquipID = int.Parse(btn.CommandArgument.ToString());
        Session["EquipId"] = EquipID;
        gvEquipHistory.DataBind();
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post:Standard method used for all gridviews to display up/down arrows
     * when the data rows are being sorted
     */

    protected void gvEquipment_RowCreated(object sender, GridViewRowEventArgs e)
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
                        img.ImageUrl = "Assets/Images/" + (gvEquipment.SortDirection == SortDirection.Ascending ? "arrow_up" : "arrow_down") + ".png";
                        img.Width = 16;
                        img.Height = 8;
                        // checking if the header link is the user's choice
                        if (gvEquipment.SortExpression == lnk.CommandArgument)
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