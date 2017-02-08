using System;

public partial class ncaa_addreservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        NcaaReservation res = new NcaaReservation();
        res.role = rblRole.SelectedValue;
        res.lname = txtLastName.Text;
        res.fname = txtFirstName.Text;
        res.school = txtSchoolName.Text;
        res.email = txtEmail.Text;
        res.cell = txtCellPhone.Text;
        res.hallpref = rblHallPref.SelectedValue;
        res.arrival = ddlArrivalDay.SelectedValue;
        res.departure = ddlDepartureDay.SelectedValue;
        res.fsingles = int.Parse(txtFemaleSingles.Text);
        res.msingles = int.Parse(txtMaleSingles.Text);
        res.fdoubles = int.Parse(txtFemaleDoubles.Text);
        res.mdoubles = int.Parse(txtMaleDoubles.Text);
        res.suites = int.Parse(txtSuites.Text);

        res.reserve();
        Security.ShowAlertMessage("You changes have been saved.");
    }
}