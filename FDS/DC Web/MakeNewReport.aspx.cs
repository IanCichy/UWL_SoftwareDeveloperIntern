using FDS;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MakeNewReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlShifts.ConnectionString = FDS.Connections.FDSConnection().ConnectionString;
    }

    /*
     * Created: Ian Cichy - 6/3/14
     * Pre/Post: Used to generate a new report,
     * checks shifts that are to be included and adds them to the
     * database for that report. Also checks for a valid title
     * and start/end dates for the Report.
     */

    protected void btnMakeReport_Click(object sender, EventArgs e)
    {
        DateTime start = DateTime.Today;
        DateTime end = DateTime.Today;
        String reportName = "";

        Page.Validate();
        if (IsValid)
        {
            try
            {
                start = DateTime.Parse(txtStart.Text.ToString());
                end = DateTime.Parse(txtEnd.Text.ToString());
                reportName = txtTitle.Text.Trim();
                int rowIndex = 0;

                if ((!reportName.Equals("")))
                {
                    var newReport = Report.AddReport(reportName, Hall.GetHallById(int.Parse((string)Session["hall"])), start, end);
                    foreach (GridViewRow row in gvShifts.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chk = (CheckBox)row.FindControl("isReported");
                            if (chk != null && chk.Checked)
                            {
                                var shiftID = int.Parse(gvShifts.DataKeys[rowIndex]["shiftID"].ToString());
                                rowIndex++;
                                Report newShift = Report.AddShiftToReport(newReport, shiftID);
                            }
                            else
                            {
                                rowIndex++;
                            }
                        }
                    }
                }
                else
                {
                    throw new System.FormatException();
                }
            }
            catch (System.FormatException)
            {
                Session["error"] = "Please Provide Valid Start/End Dates And A Report Name.";
                Response.Redirect(Request.RawUrl);
            }
        }
        Session["success"] = "Report Created From: " + start + " To: " + end + "<br/>Name: " + reportName;
        Response.Redirect("Reports.aspx");
    }

    /*
     * Created: Ian Cichy - 6/6/14
     * Pre/Post: Used to Automatically read the system date/time
     * and fill in the date/time for the current report. Selects
     * dates in the range of SUNDAY to SATURDAY for the current week.
     */

    protected void btnAutoDate_Click(object sender, EventArgs e)
    {
        DateTime s = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        while (!s.DayOfWeek.Equals(DayOfWeek.Sunday))
        {
            s = s.AddDays(-1);
        }
        txtStart.Text = s.ToString();
        txtEnd.Text = s.AddDays(7).AddSeconds(-1).ToString();
        /*
         * Updates the Calendar to reflect the auto date funciton
         */
        SelectedDatesCollection theDates = cldrReport.SelectedDates;
        theDates.Clear();
        for (int i = 0; i < 7; i++)
        {
            theDates.Add(s.AddDays(i));
        }
    }

    /*
     * Created: Ian Cichy - 6/9/14
     * Pre/Post: Used to update the text boxes that display the
     * dates with the current selection start and end dates
     */

    protected void cldrReport_SelectionChanged(object sender, EventArgs e)
    {
        txtStart.Text = cldrReport.SelectedDate.ToString();
        txtEnd.Text = cldrReport.SelectedDate.AddDays(7).AddSeconds(-1).ToString();
    }

    /*
     * Created: Ian Cichy - 6/9/14
     * Pre/Post: Used to Automatically check all shifts for
     * inclusion in the current report that is being generated
     */

    protected void btnCheckAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvShifts.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)row.FindControl("isReported");
                if (chk != null && chk.Checked)
                {
                    chk.Checked = false;
                }
                else
                {
                    chk.Checked = true;
                }
            }
        }
    }

    /*
     * Created: Ian Cichy/Andrew Hannrahan - 6/9/14
     * Pre/Post: Used to redirect to the details of a specific shift
     * by grabbing the current row index and building a url
     */

    protected void gvShifts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ShiftDetails"))
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;

            var shiftID = int.Parse(gvShifts.DataKeys[rowIndex]["shiftID"].ToString());
            Response.Redirect("ShiftDetails.aspx?shift=" + shiftID.ToString());
        }
    }

    /*
     * Created: Ian Cichy - 6/5/14
     * Pre/Post: used to check the length of notes
     * as to not create bad gridview sizes.
     * Limits characters displayed in the table to : 25
     */

    public static string Limit(object Desc)
    {
        if (Desc.ToString().Length > 25)
        {
            return Desc.ToString().Substring(0, 25) + " . . .";
        }
        else
            return Desc.ToString();
    }
}