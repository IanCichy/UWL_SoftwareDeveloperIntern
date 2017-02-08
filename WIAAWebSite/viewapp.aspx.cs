﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class viewapp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.isAuthenticated()) { Response.Redirect("login.aspx"); }

        Reservation res = new Reservation();
        DataSet ds = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT * FROM WiaaSchoolReservations WHERE Year = '" + Settings.Year + "' AND ContactEmail = '" + Session["Login"].ToString() + "'");

        res.school = ds.Tables[0].Rows[0]["SchoolName"].ToString();
        res.schoolPhone = ds.Tables[0].Rows[0]["Phone"].ToString();
        res.fax = ds.Tables[0].Rows[0]["Fax"].ToString();
        res.address = ds.Tables[0].Rows[0]["Address"].ToString();
        res.city = ds.Tables[0].Rows[0]["City"].ToString();
        res.zip = ds.Tables[0].Rows[0]["Zip"].ToString();
        res.lname = ds.Tables[0].Rows[0]["ContactLName"].ToString();
        res.fname = ds.Tables[0].Rows[0]["ContactFName"].ToString();
        res.email = Session["Login"].ToString();
        res.title = ds.Tables[0].Rows[0]["ContactTitle"].ToString();
        res.cell = ds.Tables[0].Rows[0]["ContactCellPhone"].ToString();
        res.athleticDir = ds.Tables[0].Rows[0]["AthleticDirectorName"].ToString();
        res.coach = ds.Tables[0].Rows[0]["CoachName"].ToString();
        res.fst = int.Parse(ds.Tables[0].Rows[0]["FST"].ToString());
        res.mst = int.Parse(ds.Tables[0].Rows[0]["MST"].ToString());
        res.fsf = int.Parse(ds.Tables[0].Rows[0]["FSF"].ToString());
        res.msf = int.Parse(ds.Tables[0].Rows[0]["MSF"].ToString());
        res.fdt = int.Parse(ds.Tables[0].Rows[0]["FDT"].ToString());
        res.mdt = int.Parse(ds.Tables[0].Rows[0]["MDT"].ToString());
        res.fdf = int.Parse(ds.Tables[0].Rows[0]["FDF"].ToString());
        res.mdf = int.Parse(ds.Tables[0].Rows[0]["MDF"].ToString());
        Session["CurrentApp"] = res;

        if (!Page.IsPostBack)
        {
            txtSchoolName.Text = res.school;
            txtSchoolPhone.Text = res.schoolPhone;
            txtSchoolFax.Text = res.fax;
            txtSchoolAddress.Text = res.address;
            txtSchoolCity.Text = res.city;
            txtSchoolZip.Text = res.zip;
            txtLastName.Text = res.lname;
            txtFirstName.Text = res.fname;
            txtTitle.Text = res.title;
            txtCellPhone.Text = res.cell;
            txtAthleticDir.Text = res.athleticDir;
            txtCoach.Text = res.coach;
            txtFST.Text = res.fst.ToString();
            txtFSF.Text = res.fsf.ToString();
            txtFDT.Text = res.fdt.ToString();
            txtFDF.Text = res.fdf.ToString();
            txtMST.Text = res.mst.ToString();
            txtMSF.Text = res.msf.ToString();
            txtMDT.Text = res.mdt.ToString();
            txtMDF.Text = res.mdf.ToString();
            lblFemaleCost.Text = "$" + res.GetFemaleCost().ToString();
            lblMaleCost.Text = "$" + res.GetMaleCost().ToString();
            lblTotalCost.Text = "$" + res.GetTotal().ToString();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Reservation res = (Reservation)Session["CurrentApp"];
        res.school = txtSchoolName.Text;
        res.schoolPhone = txtSchoolPhone.Text;
        res.fax = txtSchoolFax.Text;
        res.address = txtSchoolAddress.Text;
        res.city = txtSchoolCity.Text;
        res.zip = txtSchoolZip.Text;
        res.lname = txtLastName.Text;
        res.fname = txtFirstName.Text;
        res.title = txtTitle.Text;
        res.cell = txtCellPhone.Text;
        res.athleticDir = txtAthleticDir.Text;
        res.coach = txtCoach.Text;
        res.mst = int.Parse(txtMST.Text);
        res.msf = int.Parse(txtMSF.Text);
        res.fst = int.Parse(txtFST.Text);
        res.fsf = int.Parse(txtFSF.Text);
        res.mdt = int.Parse(txtMDT.Text);
        res.mdf = int.Parse(txtMDF.Text);
        res.fdt = int.Parse(txtFDT.Text);
        res.fdf = int.Parse(txtFDF.Text);
        lblFemaleCost.Text = "$" + res.GetFemaleCost().ToString();
        lblMaleCost.Text = "$" + res.GetMaleCost().ToString();
        lblTotalCost.Text = "$" + res.GetTotal().ToString();
        res.UpdateReservation();

        string emailBody = "<h3>School Information</h3>" +
                            "      School Name: " + res.school + "<br/>" +
                            "            Phone: " + res.schoolPhone + "<br/>" +
                            "              Fax: " + res.fax + "<br/>" +
                            "          Address: " + res.address + "<br/>" +
                            "             City: " + res.city + "<br/>" +
                            "              Zip: " + res.zip + "<br/>" +
                            "<h3>Contact Information</h3>" +
                            "       First Name: " + res.fname + "<br/>" +
                            "        Last Name: " + res.lname + "<br/>" +
                            "            Email: " + res.email + "<br/>" +
                            "    Contact Title: " + res.title + "<br/>" +
                            "       Cell Phone: " + res.cell + "<br/>" +
                            "Athletic Director: " + res.athleticDir + "<br/>" +
                            "       Coach Name: " + res.coach + "<br/>" +
                            "<h3>Thursday Reservations</h3>" +
                            "   Female Singles: " + res.fst + "<br/>" +
                            "     Male Singles: " + res.mst + "<br/>" +
                            "   Female Doubles: " + res.fdt + "<br/>" +
                            "     Male Doubles: " + res.mdt + "<br/>" +
                            "<h3>Friday Reservations</h3>" +
                            "   Female Singles: " + res.fsf + "<br/>" +
                            "     Male Singles: " + res.msf + "<br/>" +
                            "   Female Doubles: " + res.fdf + "<br/>" +
                            "     Male Doubles: " + res.mdf + "<br/>" +
                            "<h3>Total Cost</h3>" +
                            "Amount Due (Females): $" + res.GetFemaleCost() + "<br/>" +
                            "  Amount Due (Males): $" + res.GetMaleCost() + "<br/>" +
                            "        <b>Total Due:</b> $" + res.GetTotal() + "<br/><br/>";

       // Email.sendUpdate(res.email, "2014 WIAA State Track and Field - Reservation Update Confirmation", emailBody);
        Security.ShowAlertMessage("Your reservation has been updated");
    }
}