﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dvd : System.Web.UI.Page
{
    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Checks for a valid session hall varaible and redirects if it is not valid
     * also connects to the database
     */

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlDvd.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Generates a base report with all DVD's labeld as good with other options
     * to change the status of the dvd's for submission
     */

    protected void btnDvdReport_Click(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        gvDvd.Style["width"] = "60%";
        gvDvd.Style["margin-left"] = "auto";
        gvDvd.Style["margin-right"] = "auto";
        btnDvdReport.Style["Display"] = "none";
        LblItems.Visible = false;
        DdlItemsfilter.Visible = false;
        gvDvd.Columns[5].Visible = true;

        gvDvd.AllowPaging = false;
        gvDvd.DataBind();

        foreach (GridViewRow row in gvDvd.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList Btnlst = (RadioButtonList)row.FindControl("rbtLstRating");
                var isPurchased = Boolean.Parse(gvDvd.DataKeys[row.RowIndex]["Purchased"].ToString());
                var isMissing = Boolean.Parse(gvDvd.DataKeys[row.RowIndex]["Missing"].ToString());
                var isDamaged = Boolean.Parse(gvDvd.DataKeys[row.RowIndex]["Damaged"].ToString());
                var isReserved = Boolean.Parse(gvDvd.DataKeys[row.RowIndex]["Reserved"].ToString());

                if (isPurchased)
                {
                    Btnlst.SelectedIndex = 3;
                }
                else if (isMissing)
                {
                    Btnlst.SelectedIndex = 2;
                }
                else if (isDamaged)
                {
                    Btnlst.SelectedIndex = 1;
                }
                else if (isReserved)
                {
                    Btnlst.SelectedIndex = 0;
                }
                else
                {
                    Btnlst.SelectedIndex = 0;
                }
            }
        }
        SelectedIndex_RdoBtnLst(sender, e);
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Filter number of items per page. Takes in an integer and set the pagesize of the gridview
     */

    protected void DdlItemsfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvDvd.PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        gvDvd.DataBind();
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Takes in the gridview and submits a gridview with full row coloring
     * dependent on the value of the radiobuttonlist
     */

    protected void SelectedIndex_RdoBtnLst(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvDvd.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList Btnlst = (RadioButtonList)row.FindControl("rbtLstRating");

                if (Btnlst.SelectedIndex == 3)
                {
                    row.BackColor = Color.FromArgb(255, 255, 125);
                }
                else if (Btnlst.SelectedIndex == 2)
                {
                    row.BackColor = Color.FromArgb(255, 207, 125);
                }
                else if (Btnlst.SelectedIndex == 1)
                {
                    row.BackColor = Color.FromArgb(255, 160, 125);
                }
                else
                {
                    row.BackColor = Color.FromArgb(195, 230, 125);
                }
            }
        }
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Prepares the gidview to be exported/submitted as a full report by using the
     * radiobuttionlist to add text labels to the fields
     * --Also removes any rows that are good and do not need to be reported
     */

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvDvd.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList Btnlst = (RadioButtonList)row.FindControl("rbtLstRating");
                if (Btnlst.SelectedIndex == 1)
                {
                    row.Cells[5].Text = "Damaged";
                }
                else if (Btnlst.SelectedIndex == 2)
                {
                    row.Cells[5].Text = "Missing";
                }
                else if (Btnlst.SelectedIndex == 3)
                {
                    row.Cells[5].Text = "Purchased";
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        btnGenerate.Visible = false;
        btnExport.Visible = true;
    }

    /*
     * Created by: Ian Cichy - 6/15
     * pre/post: Exports the updated gridview with only the needed rows to excel
     * Has extra loops to replace controls with literal data fields to be handeled by 
     * the html text writer which only accepts plaintext copydata
     */

    protected void btnExportDvd_Click(object sender, EventArgs e)
    {
        gvDvd.AllowPaging = false;
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=DvdInventory.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        foreach (GridViewRow row in gvDvd.Rows)
        {
            row.BackColor = gvDvd.Rows[row.RowIndex].BackColor;
            foreach (TableCell cell in row.Cells)
            {
                cell.CssClass = "textmode";
                List<Control> controls = new List<Control>();

                //Add controls to be removed to Generic List
                foreach (Control control in cell.Controls)
                {
                    controls.Add(control);
                }

                //Loop through the controls to be removed and replace then with Literal
                foreach (Control control in controls)
                {
                    switch (control.GetType().Name)
                    {
                        case "HyperLink":
                            cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                            break;

                        case "TextBox":
                            cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                            break;

                        case "LinkButton":
                            cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                            break;

                        case "CheckBox":
                            cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                            break;

                        case "RadioButton":
                            cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                            break;
                    }
                    cell.Controls.Remove(control);
                }
            }
        }
        gvDvd.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}