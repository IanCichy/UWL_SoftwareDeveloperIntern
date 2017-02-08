using FDS;
using System;
using System.Web.UI.WebControls;

public partial class ChooseHall : System.Web.UI.Page
{
    /*
 * Created by: Ian Cichy - 6/15
 * pre/post: Loads the list of possible halls available to this employee if they have multiple
 * also verifies that the employee has valid credentials else redirects to the login
 */

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["hall"] = null;

        var employee = Employee.GetEmployeeByEagleId(String.Format("{0}", Session["username"]));

        if (employee == null)
        {
            Session["warning"] = "You must be logged in to do this.";
            Response.Redirect("login.aspx");
            return;
        }

        var halls = employee.IsAdmin() ? Hall.GetAllHalls() : employee.GetDCOfHalls();

        foreach (var hall in halls)
        {
            ddlHalls.Items.Add(new ListItem(hall.Name, String.Format("{0}", hall.HallId)));
        }

        if (ddlHalls.Items.Count == 1)
        {
            Session["hall"] = ddlHalls.SelectedValue;
            Response.Redirect("Home.aspx");
        }
    }

    /*
 * Created by: Ian Cichy - 6/15
 * pre/post: Redirect to the home page after hall selection
 */

    protected void btnChooseHall_OnClick(object sender, EventArgs e)
    {
        Session["hall"] = ddlHalls.SelectedValue;
        Response.Redirect("Home.aspx");
    }
}