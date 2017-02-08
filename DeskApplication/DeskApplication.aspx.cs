using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class DeskApplication : System.Web.UI.Page
{
    public String hallName;
    public String hallID;

    protected void Page_Load(object sender, EventArgs e)
    {

        Security.UseSecure();

        // Show regular message
        if (Request["hall"] == null)
        {
            DataTable table = DeskDA.getValidHalls();
            allpagesrep.DataSource = table;
            allpagesrep.DataBind();

            int index = 0;

            foreach (RepeaterItem it in allpagesrep.Items)
            {
                HyperLink link = (HyperLink)it.FindControl("link");
                String curHall = DeskDA.getValidHallName(table.Rows[index]["HallID"].ToString());
                link.Text = curHall;
                link.NavigateUrl = "DeskApplication.aspx?hall=" + curHall;

                index++;
            }
            
            allpagestextdiv.InnerHtml = DeskDA.getApplicationText("WelcomeApplication", "ALL")["Text"].ToString();
            content.Visible = false;
            return;
        }
        else
        {
            allpages.Visible = false;
            hallName = Request["hall"].ToString();
        }
        hallID = DeskDA.getValidHallID(hallName);

        // If previewing, dont check for date bounds, and remove the submit button
        bool previewApp = false;
        Object prevObj = Request["preview"];
        
        if (prevObj != null)
        {
            previewApp = true;
            submitdiv.InnerHtml = "";
        }


        //CHANGE OF QUESTION FOR REUTER HALL
        if (hallID.Equals("00063"))
        {
            lblMail.Text = "Would you be willing to return mid-August to work the desk?";
        }

        if (hallID.Equals("")) // Invalid Hall, tell the user
        {
            content.InnerHtml = "Invalid hall";
        }
        else
        {
            DataRow verifRow = DeskDA.verifyHallApplicationBounds(hallID);
                        
            if (verifRow["Verified"].ToString().Equals("0") && !previewApp) // Student should not be applying
            {
                if (verifRow["Invalid"].ToString().Equals("0")) // Wrong date
                {
                    content.InnerHtml = "This hall is closed for applications. Valid dates are from " + verifRow["StartDate"] + " to " + verifRow["EndDate"];
                }

                else // Hall isnt even listed in the table for date bounds
                {
                    content.InnerHtml = "This hall is not prepared to accept applications";
                }
            }

            else // Student is good to go, show them the page
            {
                if (!Page.IsPostBack)
                {
                    introtext.InnerHtml = DeskDA.getApplicationText("PreApplication", hallID)["text"].ToString();
                    prequestion.InnerHtml = DeskDA.getApplicationText("PreQuestion", hallID)["text"].ToString();
                    postquestion.InnerHtml = DeskDA.getApplicationText("PreInterviewTimes", hallID)["text"].ToString();
                    postapplication.InnerHtml = DeskDA.getApplicationText("PostApplication", hallID)["text"].ToString();


                    // Questions stuff
                    questions.DataSource = DeskDA.getQuestionsForHall(hallID);
                    questions.DataBind();

                    foreach (RepeaterItem item in questions.Items)
                    {
                        TextBox box = (TextBox)item.FindControl("questionbox");
                        box.TextMode = TextBoxMode.MultiLine;
                    }

                    // Interview Times stuff
                    DataSet interviewTimes = DeskDA.getTimesForDateAndHall(hallID);
                    outerRep.DataSource = interviewTimes.Tables[interviewTimes.Tables.Count - 1];
                    outerRep.DataBind();

                    int index = 0;

                    foreach (RepeaterItem item in outerRep.Items)
                    {
                        Repeater innerRepeater = (Repeater)item.FindControl("innerRep");

                        DataTable tempTable = interviewTimes.Tables[index].Copy();

                        innerRepeater.DataSource = tempTable;
                        innerRepeater.DataBind();

                        index++;
                    }
                }
            }

        }
    }

    protected void ClickSubmit(object sender, EventArgs e)
    {
        // Application Stuff
        int appID = DeskDA.SubmitApplication(hallID, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox4.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox12.Text);

        // Questions stuff
        foreach (RepeaterItem item in questions.Items)
        {
            HiddenField f = (HiddenField)item.FindControl("idtext");
            TextBox box = (TextBox)item.FindControl("questionbox");
            DeskDA.AddApplicationAnswer(appID, Int32.Parse(f.Value), box.Text.Replace("'", "''"));
        }

        // Interview times stuff
        foreach (RepeaterItem item in outerRep.Items)
        {
            Repeater innerRep = (Repeater)item.FindControl("innerRep");

            foreach (RepeaterItem it in innerRep.Items)
            {
                CheckBox chk = (CheckBox)it.FindControl("verifytime");

                if (chk.Checked)
                {
                    HiddenField timeID = (HiddenField)it.FindControl("timeID");
                    DeskDA.AddApplicationInterviewTime(appID, Int32.Parse(timeID.Value));
                }
            }
        }


        Session["hallID"] = hallID;
        Session["appID"] = appID;
        Response.Redirect("ApplicationConfirmation.aspx");
    }
}
