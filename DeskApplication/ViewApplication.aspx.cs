using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ViewApplication : System.Web.UI.Page
{
    private String appID;
    private Application app;
    private Boolean blindHall;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["appID"] == null)
        {
            content.InnerHtml = "Invalid request";
        }
        else
        {
            appID = (String)Request["appID"];

            if (Session["UserInfo"] == null)
            {
                content.InnerHtml = "There was an error.  Please login again <a href=\"~/Login.aspx\" target=\"_self\">here</a>";
            }
            else
            {
                UserData data = (UserData)Session["UserInfo"];
                app = DeskDA.getSubmittedApplication(appID);

                if (app == null)
                {
                    content.InnerHtml = "Invalid application ID";
                }
                else
                {
                    if (!app.hallID.Equals(data.hallID) && !data.hallID.Equals("ALL")) // Not supposed to be viewing this application
                    {
                        content.InnerHtml = "You do not have permission to view this application";
                    }
                    else // User is good to go, show them the data
                    {
                        blindHall = DeskDA.getHallBlindPreference(app.hallID);

                        // Static stuff
                        updateStatic();

                        // Questions stuff
                        updateQuestions();

                        // Interview Times stuff
                        updateInterviewTimes();
                    }                    
                }
            }
        }
    }

    protected void updateStatic()
    {
        /*
        stuidbox.Text = app.stuid;
        majorbox.Text = app.major;
        yearbox.Text = app.year;
        workstudybox.Text = app.work;
        creditbox.Text = app.credits;
        phonebox.Text = app.phone;
        gpabox.Text = app.gpa;
        */
        lblStudentId.InnerText = app.stuid;
        lblMajor.InnerText = app.major;
        lblYear.InnerText = app.year;
        lblWorkStudy.InnerText = app.work;
        lblCredit.InnerText = app.credits;
        lblPhone.InnerText = app.phone;
        lblGpa.InnerText = app.gpa;
        lblMail_Return.InnerText = app.mail_return;

        if (blindHall)
        {
            /*
            firstnamebox.Text = "HIDDEN";
            lastnamebox.Text = "HIDDEN";
            emailbox.Text = "HIDDEN";
             * */
            lblFirst.Visible = false;
            lblLast.Visible = false;
            lblEmail.Visible = false;
        }
        else
        {
            /*
            firstnamebox.Text = app.firstName;
            lastnamebox.Text = app.lastName;
            emailbox.Text = app.email;
             * */
            lblFirst.InnerText = app.firstName;
            lblLast.InnerText = app.lastName;
            lblEmail.InnerText = app.email;
        }
    }

    protected void updateQuestions()
    {
        questions.DataSource = DeskDA.getApplicationQuestionsAndAnswers(appID);
        questions.DataBind();
    }

    protected void updateInterviewTimes()
    {
        DataSet interviewTimes = DeskDA.getTimesForDateAndHall(app.hallID);
        outerRep.DataSource = interviewTimes.Tables[interviewTimes.Tables.Count - 1];
        outerRep.DataBind();

        DataTable appInterviewTimes = DeskDA.getApplicationInterviewTimesTEMP(appID);

        int index = 0;

        foreach (RepeaterItem item in outerRep.Items)
        {
            Repeater innerRepeater = (Repeater)item.FindControl("innerRep");

            DataTable tempTable = interviewTimes.Tables[index].Copy();

            innerRepeater.DataSource = tempTable;
            innerRepeater.DataBind();

            foreach (RepeaterItem nestIt in innerRepeater.Items)
            {
                HiddenField field = (HiddenField)nestIt.FindControl("timeID");               

                DataRow[] foundRows;
                foundRows = appInterviewTimes.Select("TimeID = '" + field.Value + "'");

                if (foundRows.Length > 0)
                {
                    CheckBox box = (CheckBox)nestIt.FindControl("verifytime");
                    box.Checked = true;
                }
            }

            index++;
        }
    }




    
    #region Excel Export

    protected void btnExportApp_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=App.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "applicaiton/vnd.ms-word";
        //applicaiton/vnd.ms-word  OR application/vnd.xls
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        allQuestions.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());

        Response.End();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    #endregion Excel Export



}
