using FDS;
using System;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!HttpContext.Current.Request.IsSecureConnection && !HttpContext.Current.Request.Url.ToString().Contains("localhost"))
        //{
        //    string redirectUrl = HttpContext.Current.Request.Url.ToString().Replace("http:", "https:");
        //    HttpContext.Current.Response.Redirect(redirectUrl);
        //}
    }

    protected void btnLogin_OnClick(object sender, EventArgs e)
    {
        if (txtUsername.Text.Equals("PizzaDelivery"))
        {
            Session["username"] = "PizzaDelivery";
            Response.Redirect("PizzaDelivery.aspx");
            return;
        }

        // If the employee's credentials are invalid, show an error and do not log in.
        if (!Employee.IsValidCredentials(txtUsername.Text, txtPassword.Text))
        {
            Session["error"] = "Invalid credentials";
            Response.Redirect("login.aspx");
            return;
        }
        var employee = Employee.GetEmployeeByEagleId(txtUsername.Text);

        // If there is no employee with this eagle ID or the employee is not an admin and has no
        // halls that they're a DC of, show an error and do not log in.
        if (employee == null || (employee.GetDCOfHalls().Count == 0 && !employee.IsAdmin()))
        {
            Session["error"] = "You are not a DC of any halls.";
            Response.Redirect("login.aspx");
            return;
        }

        // Get a list of the halls the employee is a DC of
        var dcHalls = employee.GetDCOfHalls();

        // Set the session username to the eagle ID of the employee
        Session["username"] = employee.EagleId;

        // If employee is an admin or DC of multiple halls, redirect to choose hall page. If not,
        // redirect to home page for only hall and set session hall
        if (employee.IsAdmin() || dcHalls.Count > 1)
        {
            Session["info"] = "You are a DC of multiple halls, please choose one.";
            Response.Redirect("chooseHall.aspx");
        }
        else
        {
            Session["hall"] = dcHalls[0].HallId.ToString();
            Response.Redirect("Home.aspx");
        }
    }
}