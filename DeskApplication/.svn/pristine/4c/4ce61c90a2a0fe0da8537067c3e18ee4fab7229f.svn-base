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

public partial class ViewApplications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionInfo sess = SessionHandler.handleAdminSession(Request["hallid"].ToString(), "ViewApplications.aspx", (UserData)Session["UserInfo"]);
        Boolean blindHall = false;

        if (!sess.valid)
        {
            Response.Redirect(sess.redirectText);
        }

        // "ALL" = hallID
        if (sess.hideGlobalData)
        {
            daterangehallrep.DataSource = DeskDA.getValidHalls();
            daterangehallrep.DataBind();            
        }
        else // HallID !="ALL", show only 1 hall
        {
            DataTable table = new DataTable();
            String[] vals = {DeskDA.getValidHallName(sess.hallID), sess.hallID};
            table.Columns.Add("Hall");
            table.Columns.Add("HallID");
            table.Rows.Add(vals);

            daterangehallrep.DataSource = table;
            daterangehallrep.DataBind();
            blindHall = DeskDA.getHallBlindPreference(sess.hallID);
        }


        foreach (RepeaterItem it in daterangehallrep.Items)
        {
            Repeater rangeLabelRep = (Repeater)it.FindControl("daterangerepouter");
            HiddenField hallIDField = (HiddenField)it.FindControl("hallIDhidden");

            rangeLabelRep.DataSource = DeskDA.getHallApplicationBounds(hallIDField.Value);
            rangeLabelRep.DataBind();

            foreach (RepeaterItem nestedIt in rangeLabelRep.Items)
            {
                Repeater applicationLabelRep = (Repeater)nestedIt.FindControl("daterangerepinner");
                HiddenField dateBoundIDField = (HiddenField)nestedIt.FindControl("dateboundIDhidden");

                DataTable dt = DeskDA.getAllApplicationsForDateBound(dateBoundIDField.Value);
                applicationLabelRep.DataSource = dt;
                applicationLabelRep.DataBind();

                int index = 0;

                if (!sess.hideGlobalData && blindHall)
                {
                    foreach (RepeaterItem reallyNestedIt in applicationLabelRep.Items)
                    {
                        HyperLink link = (HyperLink)reallyNestedIt.FindControl("applink");
                        link.NavigateUrl = "ViewApplication.aspx?appID=" + dt.Rows[index]["id"].ToString();
                        link.Text = dt.Rows[index]["stuID"].ToString();                      

                        index++;
                    }
                }
                else
                {
                    foreach (RepeaterItem reallyNestedIt in applicationLabelRep.Items)
                    {
                        HyperLink link = (HyperLink)reallyNestedIt.FindControl("applink");
                        link.NavigateUrl = "ViewApplication.aspx?appID=" + dt.Rows[index]["id"].ToString();
                        link.Text = dt.Rows[index]["first"].ToString() + " " + dt.Rows[index]["last"].ToString(); 
 
                        index++;
                    }
                }
            }
        }
    }
}
