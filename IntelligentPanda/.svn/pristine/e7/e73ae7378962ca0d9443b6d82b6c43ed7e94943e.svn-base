using Rlis.Sql;
using System;
using System.Data;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Account.isAuthenticated())
        {
            Response.Redirect("~/Account/login.aspx");
        }

        string db = Request.QueryString["db"].ToString();
        string query = Request.QueryString["query"].ToString();

        lblDB.Text = db;
        lblQuery.Text = query;

        DataSet searchResults = SqlHelper.ExecuteDataset(Settings.PandaConnection, CommandType.Text, "SELECT * FROM wiaa.dbo.WiaaSchoolReservations WHERE SchoolName Like '%" + query + "%' AND Year = " + Settings.Year + "");
        gridReservations.DataSource = searchResults;
        gridReservations.DataBind();

        if (searchResults.Tables[0].Rows.Count != 0)
        {
            DataSet searchResults2 = SqlHelper.ExecuteDataset(Settings.PandaConnection, CommandType.Text, "SELECT * FROM wiaa.dbo.ReservedRooms WHERE School Like '%" + query + "%'");
            gridRoomsReserved.DataSource = searchResults2;
            gridRoomsReserved.DataBind();
        }
    }
}