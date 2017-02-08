using Rlis.Sql;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public static void populateWiaaSchoolDropDown(DropDownList listToPopulate)
    {
        DataSet schools = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "Select SchoolName, ContactEmail FROM WiaaSchoolReservations Where Year =" + Settings.Year + " and Cancelled = 'False' ORDER BY SchoolName");
        listToPopulate.DataSource = schools;
        listToPopulate.DataTextField = "SchoolName";
        listToPopulate.DataValueField = "ContactEmail";
        listToPopulate.DataBind();
        listToPopulate.Items.Insert(0, new ListItem("Choose a school...", "-1"));
        listToPopulate.SelectedItem.Selected = false;
        listToPopulate.Items.FindByValue("-1").Selected = true;
    }

    public static void populateNcaaSchoolDropDown(DropDownList listToPopulate)
    {
        DataSet schools = SqlHelper.ExecuteDataset(Settings.NCAAConnection, CommandType.Text, "Select DisplayName,Email FROM ReservationsView ORDER BY DisplayName");
        listToPopulate.DataSource = schools;
        listToPopulate.DataTextField = "DisplayName";
        listToPopulate.DataValueField = "Email";
        listToPopulate.DataBind();
        listToPopulate.Items.Insert(0, new ListItem("School/Name...", "-1"));
        listToPopulate.SelectedItem.Selected = false;
        listToPopulate.Items.FindByValue("-1").Selected = true;
    }
}