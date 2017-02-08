﻿using FDS;
using System;

public partial class AddEmployee : System.Web.UI.Page
{
    /*
 * Created by: Ian Cichy - 6/15
 * pre/post: Redirect to the choose hall page if none is selected
 */

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
            return;
        }
    }

    /*
 * Created by: Ian Cichy - 6/15
 * pre/post: adds an employee to the current hall as a worker
 */

    protected void btnAddEmployee_OnClick(object sender, EventArgs e)
    {
        if ((txtEagleID.Text.ToString() != null) && (txtEagleID.Text.ToString().Trim() != ""))
        {
            var employee = Employee.AddNewEmployee(txtEagleID.Text);
            var hall = Hall.GetHallById(int.Parse(String.Format("{0}", Session["hall"])));
            employee.AddEmployeeToHall(hall);
            Session["success"] = String.Format("{0} was successfully added to {1}.", employee.EagleId, hall.Name);
            Response.Redirect("index.aspx");
        }
        else
        {
            Session["error"] = "Please Enter A Valid Eagle ID";
            Response.Redirect(Request.RawUrl);
        }
    }
}