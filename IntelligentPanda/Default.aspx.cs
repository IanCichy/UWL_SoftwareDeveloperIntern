﻿using System;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.isAuthenticated())
        {
            Response.Redirect("~/Account/login.aspx");
        }
    }
}