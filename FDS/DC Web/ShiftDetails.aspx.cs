﻿using FDS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class ShiftDetails : System.Web.UI.Page
{
    private Shift shift;
    private int shiftID, reportID;
    private Employee employee;
    private List<Product> AllProducts;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["shift"] == null)
        {
            Response.Redirect("Reports.aspx"); 
        }

        if (Request.Params["Report"] == null)
        {
            btnBack.Visible = false;
            btnResolve.Visible = false;
            btnUnResolve.Visible = false;
        }
        else
        {
            shiftID = int.Parse(Request.Params["shift"]);
            Session["ShiftID"] = shiftID;
            reportID = int.Parse(Request.Params["Report"]);
            btnBack.Visible = true;
            btnResolve.Visible = true;
            btnUnResolve.Visible = true;
        }

        sqlPizzaCount.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlInventoryChanges.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlSales.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;

        shift = Shift.GetShiftById(int.Parse(Request.Params["shift"]));
        employee = shift.Employee;

        if (!IsPostBack)
        {
            lblEmployee.Text = employee.EagleId;
            lblShift.Text = shift.shiftStart + " <u>to</u><br/>&nbsp&nbsp&nbsp&nbsp " + shift.shiftEnd;
            txtCashIn.Text = shift.CashInTotal != null ? ((decimal)shift.CashInTotal).ToString("C") : "";
            txtCashOut.Text = shift.CashOutTotal != null ? ((decimal)shift.CashOutTotal).ToString("C") : "";
            if (shift.ReasonNotBalanced != null && !shift.ReasonNotBalanced.ToString().Trim().Equals(""))
            {
                lblReason.Text = shift.ReasonNotBalanced.Replace("-----", "<br/>");
            }
            else
            {
                lblReason.Text = "NONE";
            }
            colorRows();
        }
    }

    protected void btnEditCash_Click(object sender, EventArgs e)
    {
        txtCashIn.ReadOnly = false;
        txtCashOut.ReadOnly = false;
        Shift shift = Shift.GetShiftById(int.Parse(Request.Params["shift"]));
        txtCashIn.Text = shift.CashInTotal != null ? (String.Format("{0:###.00}", shift.CashInTotal)) : "";
        txtCashOut.Text = shift.CashOutTotal != null ? (String.Format("{0:###.00}", shift.CashOutTotal)) : "";
        divEditCash.Style["Display"] = "none";
        divConfirmEdit.Style["Display"] = "inline";
    }

    protected void btnConfirmEdit_Click(object sender, EventArgs e)
    {
        if (decimal.Parse(txtCashIn.Text.ToString()) >= 0 && decimal.Parse(txtCashOut.Text.ToString()) >= 0)
        {
            FDS.Shift.UpdateCash(decimal.Parse(txtCashIn.Text.ToString()), decimal.Parse(txtCashOut.Text.ToString()), int.Parse(Request.Params["shift"]));
            txtCashIn.ReadOnly = true;
            txtCashOut.ReadOnly = true;
            divEditCash.Style["Display"] = "inline";
            divConfirmEdit.Style["Display"] = "none";
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Session["error"] = "Please Ensure Correct Totals Are Entered.";
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportDetails.aspx?report=" + Request.Params["Report"]);
    }

    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void DeleteSale_Click(object sender, GridViewDeleteEventArgs e)
    {
        int shiftID = int.Parse(e.Keys["ShiftID"].ToString());
        int prodID = int.Parse(e.Values["productID"].ToString());
        int amount = int.Parse(e.Values["amount"].ToString());
        String soldOn = e.Values["soldOn"].ToString();

        FDS.Shift.DeleteSale(shiftID, soldOn, prodID, amount);
        gvSales.DataBind();
        Response.Redirect(Request.RawUrl);
    }

    protected void btnNewSale_Click(object sender, EventArgs e)
    {
        divNewSale.Style["Display"] = "None";
        divAddSale.Style["Display"] = "inline";

        AllProducts = FDS.Product.GetAllProductsForHall(Hall.GetHallById(int.Parse((string)Session["hall"])));
        foreach (Product p in AllProducts)
        {
            ddlProductName.Items.Add(new ListItem(p.Name));
            ddlProductID.Items.Add(new ListItem(p.ProductId.ToString()));
            ddlProductCost.Items.Add(new ListItem(p.Price.ToString()));
            ddlProductInventory.Items.Add(new ListItem(p.Inventory.ToString()));
        }
        ddlProductID.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAmount.Text = "";
        divAddSale.Style["Display"] = "None";
        divNewSale.Style["Display"] = "inline";
        Response.Redirect(Request.RawUrl);
    }

    protected void ddlSelectProduct(object sender, EventArgs e)
    {
        ddlProductID.SelectedIndex = ddlProductName.SelectedIndex;
        ddlProductCost.SelectedIndex = ddlProductName.SelectedIndex;
        ddlProductInventory.SelectedIndex = ddlProductName.SelectedIndex;
    }

    protected void btnAddSale_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (IsValid)
        {
            int pID = int.Parse(ddlProductID.Text);
            int inventory = int.Parse(ddlProductInventory.Text);
            int amount = 0;
            int isCredit = 0;
            String Reason = "DCWeb Added Sale By: " + Session["username"] + " --- " + txtReason.Text;

            if (txtAmount.Text.Equals(""))
            {
                Session["error"] = "Please provide an amount.";
                Response.Redirect(Request.RawUrl);
            }
            if (txtReason.Text.Equals(""))
            {
                Session["error"] = "Please provide a reason.";
                Response.Redirect(Request.RawUrl);
            }

            if (chkCredit.Checked == true)
            {
                isCredit = 1;
            }
            else
            {
                isCredit = 0;
            }

            amount = int.Parse(txtAmount.Text);
            Decimal cost = Decimal.Parse(ddlProductCost.Text) * amount;

            if (amount > inventory)
            {
                Session["error"] = "Amount entered is greater than the current inventory.";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                FDS.Shift.AddSale(pID, shift.ShiftId, employee.GetEmployeeId(), amount, cost, isCredit, Reason);
                Session["success"] = "Sale added to shift: " + employee.EagleId +
                    "- Product: " + ddlProductName.Text +
                    "- Amount: " + amount;
            }

            txtAmount.Text = "";
            gvSales.DataBind();
            divAddSale.Style["Display"] = "none";
            divNewSale.Style["Display"] = "inline";
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void btnResolve_Click(object sender, EventArgs e)
    {
        FDS.Shift.Resolve(shiftID, reportID);
        Response.Redirect("ReportDetails.aspx?report=" + Request.Params["Report"]);
    }

    protected void btnUnResolve_Click(object sender, EventArgs e)
    {
        FDS.Shift.UnResolve(shiftID, reportID);
        Response.Redirect("ReportDetails.aspx?report=" + Request.Params["Report"]);
    }

    public void colorRows()
    {
        foreach (GridViewRow row in gvPizzaCounts.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                int rowIndex = row.RowIndex;
                int usrCountOut, sysCountOut;

                int usrCountIn = int.Parse(gvPizzaCounts.Rows[rowIndex].Cells[3].Text.ToString());
                int sysCountIn = int.Parse(gvPizzaCounts.Rows[rowIndex].Cells[4].Text.ToString());

                try
                {
                    usrCountOut = int.Parse(gvPizzaCounts.Rows[rowIndex].Cells[5].Text.ToString());
                }
                catch (Exception)
                {
                    usrCountOut = 0;
                }

                try
                {
                    sysCountOut = int.Parse(gvPizzaCounts.Rows[rowIndex].Cells[6].Text.ToString());
                }
                catch (Exception)
                {
                    sysCountOut = 0;
                }

                if (usrCountIn != sysCountIn)
                {
                    row.Cells[3].BackColor = Color.FromArgb(255, 207, 124);
                    row.Cells[4].BackColor = Color.FromArgb(255, 207, 124);
                }

                if (usrCountOut != sysCountOut)
                {
                    row.Cells[5].BackColor = Color.FromArgb(255, 160, 126);
                    row.Cells[6].BackColor = Color.FromArgb(255, 160, 126);
                }
            }
        }
    }
}