using FDS;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
    private List<Term> Terms;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["hall"] == null)
        {
            Session["warning"] = "No hall chosen. Please choose a hall";
            Response.Redirect("chooseHall.aspx");
        }
        sqlReports.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
        if (!IsPostBack)
        {
            Terms = Term.GetAllTerms();
            foreach (var term in Terms)
            {
                ddlTerms.Items.Add(new ListItem(term.Name));
            }
            Session["startDate"] = Term.getTermStartDate(Terms[ddlTerms.SelectedIndex]);
            Session["endDate"] = Term.getTermEndDate(Terms[ddlTerms.SelectedIndex]);
            gvReports.DataBind();
        }
    }

    /*
     * Gets all possible terms for stats and selects the most recent term in the database
     * Then displays the correct stats in the gridview
     */

    protected void ddlTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
        Terms = Term.GetAllTerms();
        Session["startDate"] = Term.getTermStartDate(Terms[ddlTerms.SelectedIndex]);
        Session["endDate"] = Term.getTermEndDate(Terms[ddlTerms.SelectedIndex]);
        gvReports.DataBind();
    }

    protected void btnAllTaxForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assets/Forms/Deposit_Form.xlsx");
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post:Simple Redirect to make a new report
     */

    protected void btnMakeNewReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("MakeNewReport.aspx");
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post:Simple Redirect to the detail page for that Report
     *  - Gets ReportID for the row in the table
     */

    protected void ReportDetails_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        var ReportID = int.Parse(btn.CommandArgument.ToString());
        Response.Redirect("ReportDetails.aspx?report=" + ReportID.ToString());
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post: Delets the selected report
     */

    protected void DeleteReport_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        FDS.Report.DeleteReport(int.Parse(btn.CommandArgument.ToString()));
        gvReports.DataBind();

        Response.Redirect(Request.RawUrl);
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post: Updates the start and end dates in the correct textboxes
     * when the date is selected on the calendar control
     * adds one day and subtracts one second to get the time of 11:59:59 for that day
     */

    protected void cldrReport_SelectionChanged(object sender, EventArgs e)
    {
        txtStart.Text = cldrReport.SelectedDates[0].ToString();
        txtEnd.Text = cldrReport.SelectedDates[cldrReport.SelectedDates.Count - 1].AddDays(1).AddSeconds(-1).ToString();
        Session["startDate"] = txtStart.Text;
        Session["endDate"] = txtEnd.Text;
        gvReports.DataBind();
    }

    /*
     * Created by: Ian Cichy - 6/14
     * pre/post: Updates the Start/End Textboxes as well
     * as updating the calendar control for the following auto select buttons
     * Week: Selects current week
     * Month: Selects current month
     * Year: Selects current year
     */

    protected void btnWeek_Click(object sender, EventArgs e)
    {
        DateTime begin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        while (!begin.DayOfWeek.Equals(DayOfWeek.Sunday))
        {
            begin = begin.AddDays(-1);
        }
        txtStart.Text = begin.ToString();
        DateTime end = begin.AddDays(7).AddSeconds(-1);
        txtEnd.Text = end.ToString();
        /*
         * Updates the Calendar to reflect the auto date funciton(week)
         */
        SelectedDatesCollection theDates = cldrReport.SelectedDates;
        theDates.Clear();
        while (!begin.Date.Day.Equals(end.Date.Day))
        {
            theDates.Add(begin);
            begin = begin.AddDays(1);
        }
        theDates.Add(begin);
        Session["startDate"] = txtStart.Text;
        Session["endDate"] = txtEnd.Text;
        gvReports.DataBind();
    }

    protected void btnMonth_Click(object sender, EventArgs e)
    {
        DateTime begin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        txtStart.Text = begin.ToString();
        DateTime end = begin.AddMonths(1).AddSeconds(-1);
        txtEnd.Text = end.ToString();
        /*
         * Updates the Calendar to reflect the auto date funciton(month)
         */
        SelectedDatesCollection theDates = cldrReport.SelectedDates;
        theDates.Clear();
        while (!begin.Date.Day.Equals(end.Date.Day))
        {
            theDates.Add(begin);
            begin = begin.AddDays(1);
        }
        theDates.Add(begin);
        Session["startDate"] = txtStart.Text;
        Session["endDate"] = txtEnd.Text;
        gvReports.DataBind();
    }

    protected void btnYear_Click(object sender, EventArgs e)
    {
        DateTime begin = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
        txtStart.Text = begin.ToString();
        DateTime end = begin.AddYears(1).AddSeconds(-1);
        txtEnd.Text = end.ToString();
        /*
         * Updates the Calendar to reflect the auto date funciton(year)
         */
        SelectedDatesCollection theDates = cldrReport.SelectedDates;
        theDates.Clear();
        while (!begin.Date.Equals(end.Date))
        {
            theDates.Add(begin);
            begin = begin.AddDays(1);
        }
        theDates.Add(begin);
        Session["startDate"] = txtStart.Text;
        Session["endDate"] = txtEnd.Text;
        gvReports.DataBind();
    }
}