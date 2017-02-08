﻿using FDS;
using System;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowMessages();
        LoadJquery();
    }

    private void ShowMessages()
    {

        if (Session["username"] == null)
        {
            Menu_Links.Style["display"] = "none";
            Username.Visible = false;
            // If not already on login page, go to login page
            if (!Page.AppRelativeVirtualPath.Equals("~/login.aspx")) Response.Redirect("login.aspx");
        }
        else
        {
            Username.Visible = true;
            Username.Text = Session["username"].ToString();
        }

        if (Session["hall"] == null)
        {
            Menu_Links.Style["display"] = "none";
        }

        // If there is an error message, display it and clear the error message
        if (Session["error"] != null)
        {
            lblError.Text = String.Format("{0}", Session["error"]);
            Session["error"] = null;
        }
        else
        {
            divError.Style["display"] = "none";
        }

        // If there is a warning message, display it and clear the warning message
        if (Session["warning"] != null)
        {
            lblWarning.Text = String.Format("{0}", Session["warning"]);
            Session["warning"] = null;
        }
        else
        {
            divWarning.Style["display"] = "none";
        }

        // If there is an info message, display it and clear the info message
        if (Session["info"] != null)
        {
            lblInfo.Text = String.Format("{0}", Session["info"]);
            Session["info"] = null;
        }
        else
        {
            divInfo.Style["display"] = "none";
        }

        // If there is a success message, display it and clear the success message
        if (Session["success"] != null)
        {
            lblSuccess.Text = String.Format("{0}", Session["success"]);
            Session["success"] = null;
        }
        else
        {
            divSuccess.Style["display"] = "none";
        }

        if (Session["hall"] != null)
        {
            var CurrentHall = Hall.GetHallById(int.Parse(String.Format("{0}", Session["hall"])));
            lblHall.Text = CurrentHall.Name + " Hall";
            lblHallID.Text = CurrentHall.HallId.ToString();
        }


        if ((Session["username"] != null) && (Session["username"].Equals("PizzaDelivery")))
        {
            Menu_Links.Style["display"] = "none";
            if (!Page.AppRelativeVirtualPath.Equals("~/PizzaDelivery.aspx"))
                Response.Redirect("PizzaDelivery.aspx");
        }
        
    }

    private void LoadJquery()
    {
        var jqueryResDef = new ScriptResourceDefinition();
        jqueryResDef.Path = "~/Scripts/jquery-2.1.0.min.js";
        jqueryResDef.DebugPath = "~/Scripts/jquery-2.1.0.min.js";
        jqueryResDef.CdnPath = "http://ajax.microsoft.com/ajax/jquery/jquery-2.1.0.min.js";
        jqueryResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jquery/jquery-2.1.0.min.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, jqueryResDef);
    }
}