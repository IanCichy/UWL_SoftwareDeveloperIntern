using System;

public partial class PizzaDelivery : System.Web.UI.Page
{
    /*
    * Created by: Ian Cichy - 6/15
    * pre/post: Load for gridviews to display pizzacounts for dilvery team
    */

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlPizzaStats.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats1.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats2.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats3.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats4.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats5.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats6.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats7.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats8.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        sqlPizzaStats9.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
    }
}