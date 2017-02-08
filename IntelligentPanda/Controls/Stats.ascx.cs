using Rlis.Google;
using Rlis.Sql;
using System;
using System.Data;

public partial class Controls_Stats : System.Web.UI.UserControl
{
    public string conference { get; set; }

    public string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        loadStats();
    }

    private void loadStats()
    {
        lblFriday.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT totalFriday FROM QuickInfo WHERE Year = " + Settings.Year + "").ToString();
        lblThursday.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT totalThursday FROM QuickInfo WHERE Year = " + Settings.Year + "").ToString();
        lblSchoolsPrevious.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT registeredSchools FROM QuickInfo WHERE Year = " + (Settings.Year - 1) + "").ToString();
        lblSchoolsCurrent.Text = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT registeredSchools FROM QuickInfo WHERE Year = " + Settings.Year + "").ToString();

        DataSet ds = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT * From QuickInfo WHERE Year = " + Settings.Year + "");

        GoogleChart c = new GoogleChart();
        c.title = "WIAA Traditional Rooms";
        c.height = 500;
        c.addColumn("string", "Day");
        c.addColumn("number", "Singles");
        c.addColumn("number", "Doubles");
        c.addColumn("number", "Triples");
        c.addColumn("number", "Studies");
        c.addRow("'Thursday', " +
                   ds.Tables[0].Rows[0]["singleThursday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["doubleThursday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["tripleThursday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["studyThursday"].ToString() + "");
        c.addRow("'Friday', " +
                   ds.Tables[0].Rows[0]["singleFriday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["doubleFriday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["tripleFriday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["studyFriday"].ToString() + "");
        lt.Text = c.generateChart(GoogleChart.ChartType.BarChart);

        GoogleChart eagleChart = new GoogleChart();
        eagleChart.elementId = "chart_div_eagle";
        eagleChart.title = "WIAA Eagle Hall";
        eagleChart.addColumn("string", "Day");
        eagleChart.addColumn("number", "Singles");
        eagleChart.addColumn("number", "Doubles");
        eagleChart.addRow("'Thursday', " +
                   ds.Tables[0].Rows[0]["singleEagleThursday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["doubleEagleThursday"].ToString() + "");
        eagleChart.addRow("'Friday', " +
                   ds.Tables[0].Rows[0]["singleEagleFriday"].ToString() + ", " +
                   ds.Tables[0].Rows[0]["doubleEagleFriday"].ToString() + "");
        lt2.Text = eagleChart.generateChart(GoogleChart.ChartType.BarChart);
    }
}